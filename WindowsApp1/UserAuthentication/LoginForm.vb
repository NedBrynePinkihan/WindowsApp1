Imports System.Security.Cryptography
Imports System.Text
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms ' Required for Timer/Application.Idle
Imports System.Data ' Required for ConnectionState

Public Class LoginForm
    ' Store the logged-in user's information globally for access in other forms
    ' For Idle Time
    Private Shared LastActivityTime As DateTime = DateTime.Now
    'Private Const IDLE_TIMEOUT_SECONDS As Integer = 15 ' 30 sec timeout

    ' Existing code for ComputeSHA256Hash and conn declaration...
    Public Function ComputeSHA256Hash(ByVal rawData As String) As String
        Using sha256Hash As SHA256 = SHA256.Create()
            Dim bytes As Byte() = sha256Hash.ComputeHash(Encoding.UTF32.GetBytes(rawData))
            Dim builder As New StringBuilder()
            For Each b As Byte In bytes
                builder.Append(b.ToString("x2"))
            Next
            Return builder.ToString()
        End Using
    End Function

    Dim conn As New MySqlConnection("server=localhost; userid=root; password=root; database=labact2;")
    Private loginAttempts As Integer = 0
    Private maxtAttempts As Integer = 3

    ' The following three subs are for Idle Timeout management
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPassword.UseSystemPasswordChar = True
        'AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle ' Existing Idle Handler
        Me.KeyPreview = True ' To capture key presses for activity check
    End Sub

    'Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
    '    RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    'End Sub

    'Private Sub Application_Idle(sender As Object, e As EventArgs)
    '    ' Check for idle time only when the login form is NOT visible (i.e., when a user is logged in to another form)
    '    If Not Me.Visible AndAlso LoggedInUsername <> "" Then
    '        If (DateTime.Now - LastActivityTime).TotalSeconds > IDLE_TIMEOUT_SECONDS Then
    '            ' Log out the user
    '            AuditLogManager.LogAction(LoggedInUsername, "System Idle Timeout - User automatically logged out.")
    '            MessageBox.Show("You have been inactive for " & IDLE_TIMEOUT_SECONDS & " seconds. You are automatically logged out.", "Idle Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    '            ' Close all forms (except this one, which will be shown)
    '            For Each frm As Form In Application.OpenForms
    '                If Not frm Is Me Then
    '                    frm.Close()
    '                End If
    '            Next

    '            ' Reset login state and show Form1
    '            LoggedInUsername = ""
    '            LoggedInRole = ""
    '            Me.Show()
    '            ' Reset LastActivityTime when the login form is visible
    '            LastActivityTime = DateTime.Now
    '        End If
    '    End If
    'End Sub

    ' Update LastActivityTime on common user interactions (you need to call this from all forms)
    ' For Form1, we only need to update it on the login button click.
    Public Shared Sub UpdateActivityTime()
        LastActivityTime = DateTime.Now
    End Sub

    ' --- Login Logic with Audit Log ---
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        'UpdateActivityTime() ' Activity update

        SetLoginForm(Me)
        TimeoutCounterForm.Show()

        ' Input Validation: Check for empty fields
        If String.IsNullOrEmpty(txtUsername.Text) OrElse String.IsNullOrEmpty(txtPassword.Text) Then
            MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'AuditLogManager.LogAction(txtUsername.Text & " (Attempt)", "Login Failure - Empty fields.", isSuccess:=False)
            Exit Sub
        End If

        Dim query As String = "SELECT id, username, role, status FROM user_tbl WHERE username=@username AND password=@password"
        Dim conn As New MySqlConnection("server=localhost; userid=root; password=root; database=labact2")

        Try
            conn.Open()
            Dim hashedPassword As String = ComputeSHA256Hash(txtPassword.Text)
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@username", txtUsername.Text)
            cmd.Parameters.AddWithValue("@password", hashedPassword)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                ' Login Success
                Dim status As String = reader.GetString("status")
                LoggedUserId = reader.GetInt32("id")
                LoggedUsername = reader.GetString("username")
                LoggedUserRole = reader.GetString("role")

                If status = "Authorized" Then

                    AuditLogManager.LogAction(LoggedUsername, "Login Successful (Role: " & LoggedUserRole & ")", isSuccess:=True)
                    MessageBox.Show("Login successful. Welcome, " & LoggedUserRole & ".", "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Hide()

                    ' Determine which form to show based on Role
                    If LoggedUserRole = "Admin" Then
                        AdminUserManagementForm.Show() ' Admin Form (User Management/Settings)
                    ElseIf LoggedUserRole = "Staff" Then
                        InventoryListForm.Show() ' Staff/Default User Form (Library System)
                    Else
                        InventoryListForm.Show() ' Default to Library Form if role is unrecognized/new
                    End If

                ElseIf status = "Pending" Then
                    AuditLogManager.LogAction(txtUsername.Text, "Login Failure - Account Pending.", isSuccess:=False)
                    MessageBox.Show("Your account is Pending. Please wait for authorization.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    ' If status is unauthorized/other, treat it as a restricted login
                    AuditLogManager.LogAction(LoggedUsername, "Login Successful - Unauthorized Status (Role: " & LoggedUserRole & ")", isSuccess:=True)
                    MessageBox.Show("Login successful. Your account is Unauthorized/Restricted.", "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Hide()
                    InventoryListForm.Show() ' Restricted view, perhaps
                End If

                ' Reset fields and attempts on successful login
                txtUsername.Text = ""
                txtPassword.Text = ""
                loginAttempts = 0
            Else
                ' Login Failure
                loginAttempts += 1
                AuditLogManager.LogAction(txtUsername.Text & " (Attempt)", "Login Failure - Invalid credentials. Attempt: " & loginAttempts, isSuccess:=False)

                If loginAttempts >= maxtAttempts Then
                    MessageBox.Show("Too many failed attempts. Application will close.", "Access Locked", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Application.Exit()
                Else
                    MessageBox.Show("Invalid username or password. Attempts left: " & (maxtAttempts - loginAttempts), "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            reader.Close()

        Catch ex As Exception
            AuditLogManager.LogAction("SYSTEM", "Database Error during login for user: " & txtUsername.Text, isSuccess:=False)
            MsgBox("Error connecting to database or during login: " & ex.Message)
        Finally
            If conn.State() = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' --- Other Handlers ---
    ' (Existing Handlers)
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub
    Private Sub Lcreate_Click(sender As Object, e As EventArgs) Handles Lcreate.Click
        Me.Hide()
        SignupForm.Show()
        txtUsername.Text = ""
        txtPassword.Text = ""
        chkShowPassword.Checked = False
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        If chkShowPassword.Checked Then
            txtPassword.UseSystemPasswordChar = False
        Else
            txtPassword.UseSystemPasswordChar = True
        End If
    End Sub
End Class