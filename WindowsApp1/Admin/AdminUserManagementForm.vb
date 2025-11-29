Imports MySql.Data.MySqlClient
Imports System.Data ' Required for DataTable
Imports System.Diagnostics ' Required for Process (Backup/Restore)
Imports System.IO ' Required for File operations (Backup/Restore)
Imports System.Windows.Forms ' Required for OpenFileDialog/SaveFileDialog

Public Class AdminUserManagementForm ' Admin User Management Form

    ' !!! CRITICAL: UPDATE THIS PATH to your MySQL Server's 'bin' folder !!!
    ' This ensures the mysqldump.exe and mysql.exe tools can be found.
    Private Const MYSQL_BIN_PATH As String = "C:\Program Files\MySQL\MySQL Server 8.0\bin\"

    Dim conn As New MySqlConnection("server=localhost; userid=root; password=root; database=labact2")

    ' Load DataGridView on load
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupInactivityTracking(Me)
        LoginForm.UpdateActivityTime()
        If LoggedUserRole <> "Admin" Then
            MessageBox.Show("Access Denied. Only Administrators can view User Management.", "Security Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
            LoginForm.Show()
            Exit Sub
        End If
        LoadUserData()
    End Sub

    ' Helper to load/refresh User Data
    Private Sub LoadUserData()
        Dim query As String = "SELECT id, username, password, role, status FROM user_tbl"
        Try
            conn.Open()
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            DGVUserAdmin.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error loading user data: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' --- User Management CRUD with Audit Log ---

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        ResetTimer()
        If Not ValidateIdInput() Then Exit Sub

        Dim userIdToRemove As Integer = Convert.ToInt32(txtID.Text)
        Dim query As String = "DELETE FROM user_tbl WHERE id=@id"

        If MessageBox.Show("Are you sure you want to delete user ID " & userIdToRemove & "?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        Try
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@id", userIdToRemove)
                Dim rowsAffected = cmd.ExecuteNonQuery()
                If rowsAffected > 0 Then
                    MessageBox.Show("User removed successfully.")
                    AuditLogManager.LogAction(LoggedUsername, "User Management: Deleted user ID " & userIdToRemove)
                Else
                    MessageBox.Show("No user found with the specified ID.")
                    AuditLogManager.LogAction(LoggedUsername, "User Management: Failed attempt to delete user ID " & userIdToRemove, isSuccess:=False)
                End If
            End Using
            LoadUserData()
        Catch ex As Exception
            MessageBox.Show("Error removing user: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            txtID.Clear()
            cmbStatus.Text = ""
            cmbRole.Text = ""
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ResetTimer()
        If Not ValidateIdInput() Then Exit Sub
        If String.IsNullOrEmpty(cmbStatus.Text) OrElse String.IsNullOrEmpty(cmbRole.Text) Then
            MessageBox.Show("Please select a Status and Role to update.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim userIdToUpdate As Integer = Convert.ToInt32(txtID.Text)
        Dim newStatus As String = cmbStatus.Text
        Dim newRole As String = cmbRole.Text

        Dim query As String = "UPDATE user_tbl SET status=@status, role=@role WHERE id=@id"

        Try
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@status", newStatus)
                cmd.Parameters.AddWithValue("@role", newRole)
                cmd.Parameters.AddWithValue("@id", userIdToUpdate)

                Dim rowsAffected = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    MessageBox.Show("User ID " & userIdToUpdate & " updated successfully (Status: " & newStatus & ", Role: " & newRole & ").")
                    AuditLogManager.LogAction(LoggedUsername, "User Management: Updated user ID " & userIdToUpdate & " to Status=" & newStatus & ", Role=" & newRole)
                Else
                    MessageBox.Show("No user found with ID " & userIdToUpdate & " to update.")
                End If
            End Using
            LoadUserData()
        Catch ex As Exception
            MessageBox.Show("Error updating user: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            txtID.Clear()
            cmbStatus.Text = ""
            cmbRole.Text = ""
        End Try
    End Sub

    Private Function ValidateIdInput() As Boolean
        If String.IsNullOrEmpty(txtID.Text) Then
            MessageBox.Show("Please select an ID or enter one in the ID field.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        ' Check if ID is numeric
        If Not Integer.TryParse(txtID.Text, New Integer()) Then
            MessageBox.Show("ID must be a number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Return True
    End Function

    ' --- Navigation and Search ---

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        ResetTimer()
        LoadUserData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click ' Search button
        ResetTimer()
        If String.IsNullOrEmpty(txtID.Text) Then
            MessageBox.Show("Please enter a User ID or Username to search.", "Input Required")
            Exit Sub
        End If

        Dim searchTerm As String = "%" & txtID.Text & "%"
        ' Search by ID or Username (assuming txtID can be used for both or rename for clarity)
        Dim query As String = "SELECT id, username, role, status FROM user_tbl WHERE id LIKE @searchTerm OR username LIKE @searchTerm"

        Try
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@searchTerm", searchTerm)
                Dim adapter As New MySqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                DGVUserAdmin.DataSource = table
            End Using
            If DGVUserAdmin.Rows.Count = 0 Then
                MessageBox.Show("No users found matching the search term.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox("Error searching: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' Populate fields on DataGridView single-click
    Private Sub DGVUserAdmin_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVUserAdmin.CellContentClick
        LoginForm.UpdateActivityTime()
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DGVUserAdmin.Rows(e.RowIndex)
            txtID.Text = row.Cells("id").Value.ToString()
            txtusername.Text = row.Cells("username").Value.ToString()
            txtPassword.Text = row.Cells("password").Value.ToString()
            cmbStatus.Text = row.Cells("status").Value.ToString()
            cmbRole.Text = row.Cells("role").Value.ToString()
        End If
    End Sub

    ' Handle DataGridView Double Click event (renamed for clarity/consistency)
    Private Sub DGVUserAdmin_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVUserAdmin.CellDoubleClick
        DGVUserAdmin_CellContentClick(sender, e) ' Reuse single-click logic
    End Sub

    ' --- Backup and Restore Implementation (Now using MYSQL_BIN_PATH) ---


    ' --- Navigation Menu Clicks ---

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs)
        AuditLogManager.LogAction(LoggedUsername, "Logged out from Admin form.")
        LoggedUsername = "" ' Clear session info
        LoggedUserRole = ""
        Me.Close()
        LoginForm.Show()
    End Sub

    Private Sub AddProfileToolStripMenuItem_Click(sender As Object, e As EventArgs)

        MessageBox.Show("Please use the 'Register' link on the login screen (Form1) to create new user profiles, or a dedicated Add User button on this form (Form2) if implemented.", "Suggestion")
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        LoginForm.UpdateActivityTime()
    End Sub

    Private Sub ViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem.Click
        ResetTimer()
    End Sub

    Private Sub UserDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserDatabaseToolStripMenuItem.Click
        ' Assuming UserCrude form exists
        UserCrude.Show()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub AuditLogsToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub AddUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddUserToolStripMenuItem.Click
        ResetTimer()
        Me.Close()
        SignupForm.LoadAdminUser()
        SignupForm.Show()
    End Sub

    Private Sub BackUpToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BackUpToolStripMenuItem1.Click
        ResetTimer()
        Backup1.RestoreDatabase()
    End Sub

    Private Sub RestoreToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RestoreToolStripMenuItem1.Click
        ResetTimer()
        Backup1.RestoreDatabase()
    End Sub

    Private Sub AuditLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AuditLogToolStripMenuItem.Click
        ResetTimer()
    End Sub

    Private Sub MainToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MainToolStripMenuItem.Click
        ResetTimer()
    End Sub
End Class