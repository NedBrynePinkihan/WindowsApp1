Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions
Imports Google.Protobuf.WellKnownTypes
Imports MySql.Data.MySqlClient

Public Class AddUserForm
    Dim conn As New MySqlConnection("server=localhost; userid=root; password=root; database=labact2;")
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
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        Me.Close()
        AdminUserManagementForm.Show()
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        'txtID.Text = ""
        'txtUsername.Text = ""
        'txtPassword.Text = ""
        'cmbStatus.Text = ""
        'cmbRole.Text = ""
        If txtPassword.Text.Length < 8 OrElse
            Not Regex.IsMatch(txtPassword.Text, "\d") OrElse
            Not Regex.IsMatch(txtPassword.Text, "[\W_]") Then
            MessageBox.Show("Password must be at least 8 characters long and include at least 1 number and 1 special character.", "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim query As String = "INSERT INTO user_tbl(id, username, password, status, role) VALUES (@id, @username, @password, @status, @role)"
        Try
            Using conn As New MySqlConnection("server=localhost; userid=root; password=root; database=labact2")
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", txtID.Text)
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text)
                    cmd.Parameters.AddWithValue("@password", ComputeSHA256Hash(txtPassword.Text))
                    cmd.Parameters.AddWithValue("@status", cmbStatus.Text)
                    cmd.Parameters.AddWithValue("@role", cmbRole.Text)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("User registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using
        Catch ex As MySqlException
            If ex.Number = 1062 Then
                MessageBox.Show("Username already exists.")
            Else
                MsgBox(ex.Message)
            End If
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
        Dim query As String = "UPDATE INTO usertbl(id, username, password, status, role) VALUES (@id, @username, @password, @status, @role)"
        Try
            Using conn As New MySqlConnection("server=localhost; userid=root; password=root; database=labact2")
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", txtID.Text)
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text)
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text)
                    cmd.Parameters.AddWithValue("@status", cmbStatus.Text)
                    cmd.Parameters.AddWithValue("@role", cmbRole.Text)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("User Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using
        Catch ex As MySqlException
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs)
        Dim query As String = "DELETE FROM user_tbl WHERE id=@id"
        Try
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtID.Text))
                Dim rowsAffected = cmd.ExecuteNonQuery()
                If rowsAffected > 0 Then
                    MessageBox.Show("User removed successfully.")
                Else
                    MessageBox.Show("No user found with the specified ID.")
                End If
            End Using
            txtID.Clear()
            txtUsername.Clear()
            txtPassword.Clear()
            cmbStatus.Text = ""
            cmbRole.Text = ""
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs)


    End Sub
End Class