Imports System.Security.Cryptography
Imports System.Text
Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions

Public Class SignupForm
    ' (Existing ComputeSHA256Hash function)


    Public Sub LoadAdminUser()
        Me.Text = "Add Profile"
        lblTitle.Text = "Add New Admin Profile"
    End Sub

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

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoginForm.UpdateActivityTime()
        lbl8minChar.ForeColor = Color.Red
        lblNumber.ForeColor = Color.Red
        lblSpecialchar.ForeColor = Color.Red
    End Sub
    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        Dim password As String = txtPassword.Text

        If password.Length >= 8 Then
            lbl8minChar.ForeColor = Color.Green
        Else
            lbl8minChar.ForeColor = Color.Red
        End If

        If Regex.IsMatch(password, "\d") Then
            lblNumber.ForeColor = Color.Green
        Else
            lblNumber.ForeColor = Color.Red
        End If

        If Regex.IsMatch(password, "[\W_]") Then
            lblSpecialchar.ForeColor = Color.Green
        Else
            lblSpecialchar.ForeColor = Color.Red
        End If
    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        LoginForm.UpdateActivityTime()
        ' --- Validation checks (Existing and improved for completeness) ---
        If txtUsername.Text = "" Or txtPassword.Text = "" Or txtCPassword.Text = "" Then
            MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If txtPassword.Text <> txtCPassword.Text Then
            MessageBox.Show("Passwords do not match.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If txtPassword.Text.Length < 8 OrElse
           Not Regex.IsMatch(txtPassword.Text, "\d") OrElse
           Not Regex.IsMatch(txtPassword.Text, "[\W_]") Then
            MessageBox.Show("Password must be at least 8 characters Min. and include at least 1 number and 1 special character.", "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        ' --- End Validation ---

        ' Assumes new users are 'Pending' and 'Staff' by default
        Dim query As String = "INSERT INTO user_tbl(username, password, status, role) VALUES (@username, @password, 'Pending', 'Staff')"

        Try
            Using conn As New MySqlConnection("server=localhost; userid=root; password=root; database=labact2")
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text)
                    cmd.Parameters.AddWithValue("@password", ComputeSHA256Hash(txtPassword.Text))
                    cmd.ExecuteNonQuery()

                    AuditLogManager.LogAction(txtUsername.Text, "New user registered (Status: Pending, Role: Staff)")
                    MessageBox.Show("User registered successfully! Your account is currently Pending authorization.", "Registration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.Close()
                    If LoggedUserRole = "Admin" Then
                        AdminUserManagementForm.Show()
                    Else
                        LoginForm.Show()
                    End If
                End Using
            End Using
        Catch ex As MySqlException
            If ex.Number = 1062 Then ' MySQL error code for Duplicate entry for key 'PRIMARY' or unique constraint
                MessageBox.Show("Username already exists. Please choose a different username.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                AuditLogManager.LogAction(txtUsername.Text, "Registration Failure - Username already exists.", isSuccess:=False)
            Else
                MsgBox("Database Error: " & ex.Message)
                AuditLogManager.LogAction("SYSTEM", "Database Error during registration: " & ex.Message, isSuccess:=False)
            End If
        End Try
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        LoginForm.UpdateActivityTime()
        Me.Close()

        If LoggedUserRole = "Admin" Then
            AdminUserManagementForm.Show()
        Else
            LoginForm.Show()
        End If
    End Sub
End Class