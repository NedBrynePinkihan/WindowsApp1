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


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPassword.UseSystemPasswordChar = True

        Me.KeyPreview = True ' 
    End Sub


    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        SetLoginForm(Me)
        TimeoutCounterForm.Show()


        If String.IsNullOrEmpty(txtUsername.Text) OrElse String.IsNullOrEmpty(txtPassword.Text) Then
            MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

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

                Dim status As String = reader.GetString("status")
                LoggedUserId = reader.GetInt32("id")
                LoggedUsername = reader.GetString("username")
                LoggedUserRole = reader.GetString("role")

                If status = "Authorized" Then
                    AuditLogging.AddEntry("Login Successful")

                    MessageBox.Show("Login successful. Welcome, " & LoggedUserRole & ".", "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Hide()


                    If LoggedUserRole = "Admin" Then
                        AdminUserManagementForm.Show()
                    ElseIf LoggedUserRole = "Staff" Then

                        InventoryManagementForm.Show()
                    Else

                    End If

                ElseIf status = "Pending" Then
                    AuditLogging.AddEntry("Login Failure - Account Pending")
                    MessageBox.Show("Your account is Pending. Please wait for authorization.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else

                    AuditLogging.AddEntry("Login Successful - Unauthorized Status")
                    MessageBox.Show("Login successful. Your account is Unauthorized/Restricted.", "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Hide()
                    InventoryManagementForm.Show()

                End If


                txtUsername.Text = ""
                txtPassword.Text = ""
                loginAttempts = 0
            Else

                loginAttempts += 1
                AuditLogging.AddEntry("txtUsername.Text & " & " (Attempt)" & "Login Failure - Invalid credentials.", "Attempt: " & loginAttempts)

                If loginAttempts >= maxtAttempts Then
                    MessageBox.Show("Too many failed attempts. Application will close.", "Access Locked", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Application.Exit()
                Else
                    MessageBox.Show("Invalid username or password. Attempts left: " & (maxtAttempts - loginAttempts), "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            reader.Close()

        Catch ex As Exception
            AuditLogging.AddEntry("Database Error during login for user: ", "Username: " & txtUsername.Text)
            MsgBox("Error connecting to database or during login: " & ex.Message)
        Finally
            If conn.State() = ConnectionState.Open Then conn.Close()
        End Try
    End Sub


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