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
        Dim query As String = "SELECT id, username, role, status FROM user_tbl"
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
        LoginForm.UpdateActivityTime()
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
        LoginForm.UpdateActivityTime()
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
        LoginForm.UpdateActivityTime()
        LoadUserData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click ' Search button
        LoginForm.UpdateActivityTime()
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
            cmbStatus.Text = row.Cells("status").Value.ToString()
            cmbRole.Text = row.Cells("role").Value.ToString()
        End If
    End Sub

    ' Handle DataGridView Double Click event (renamed for clarity/consistency)
    Private Sub DGVUserAdmin_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVUserAdmin.CellDoubleClick
        DGVUserAdmin_CellContentClick(sender, e) ' Reuse single-click logic
    End Sub

    ' --- Backup and Restore Implementation (Now using MYSQL_BIN_PATH) ---

    Private Sub BackupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupToolStripMenuItem.Click
        LoginForm.UpdateActivityTime()
        Using sfd As New SaveFileDialog()
            sfd.Filter = "SQL Backup File (*.sql)|*.sql|All files (*.*)|*.*"
            sfd.FileName = "labact2_backup_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".sql"
            sfd.Title = "Save Database Backup File"

            If sfd.ShowDialog() = DialogResult.OK Then
                Dim backupFile As String = sfd.FileName
                ' Arguments for mysqldump (using root credentials)
                Dim arguments As String = String.Format("-u{0} -p{1} {2} -r ""{3}""", "root", "root", "labact2", backupFile)

                Try
                    ' FIX: Use the full path for mysqldump.exe
                    Dim startInfo As New ProcessStartInfo()
                    startInfo.FileName = MYSQL_BIN_PATH & "mysqldump.exe"
                    startInfo.Arguments = arguments
                    startInfo.CreateNoWindow = True
                    startInfo.UseShellExecute = False
                    startInfo.RedirectStandardError = True ' Capture errors

                    Using process As Process = Process.Start(startInfo)
                        process.WaitForExit()
                        Dim errorOutput As String = process.StandardError.ReadToEnd()

                        If process.ExitCode = 0 AndAlso String.IsNullOrEmpty(errorOutput) Then
                            MessageBox.Show("Database backup successful! File saved to: " & backupFile, "Backup Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            AuditLogManager.LogAction(LoggedUsername, "Database Backup: Successful to " & backupFile)
                        Else
                            MessageBox.Show("Database backup failed. Error details: " & errorOutput & Environment.NewLine & "Check if path is correct: " & MYSQL_BIN_PATH, "Backup Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            AuditLogManager.LogAction(LoggedUsername, "Database Backup: Failed. Error: " & errorOutput, isSuccess:=False)
                        End If
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error executing mysqldump: " & ex.Message & Environment.NewLine & "Check if this path is correct: " & MYSQL_BIN_PATH, "Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub RestoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestoreToolStripMenuItem.Click
        LoginForm.UpdateActivityTime()
        If MessageBox.Show("WARNING: Restoring the database will overwrite ALL current data in 'labact2'. Are you absolutely sure?", "Confirm Database Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then Exit Sub

        Using ofd As New OpenFileDialog()
            ofd.Filter = "SQL Backup File (*.sql)|*.sql"
            ofd.Title = "Select Database Backup File to Restore"

            If ofd.ShowDialog() = DialogResult.OK Then
                Dim restoreFile As String = ofd.FileName
                ' Arguments for mysql restore
                Dim arguments As String = String.Format("-u{0} -p{1} {2} < ""{3}""", "root", "root", "labact2", restoreFile)

                Try
                    ' FIX: Use the full path for mysql.exe
                    Dim startInfo As New ProcessStartInfo()
                    startInfo.FileName = MYSQL_BIN_PATH & "mysql.exe"
                    startInfo.Arguments = arguments
                    startInfo.CreateNoWindow = True
                    startInfo.UseShellExecute = False
                    startInfo.RedirectStandardError = True ' Capture errors

                    Using process As Process = Process.Start(startInfo)
                        process.WaitForExit()
                        Dim errorOutput As String = process.StandardError.ReadToEnd()

                        If process.ExitCode = 0 AndAlso String.IsNullOrEmpty(errorOutput) Then
                            MessageBox.Show("Database restore successful! Please refresh the form to view the restored data.", "Restore Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            AuditLogManager.LogAction(LoggedUsername, "Database Restore: Successful from " & restoreFile)
                            LoadUserData() ' Refresh DataGridView
                        Else
                            MessageBox.Show("Database restore failed. Error details: " & errorOutput & Environment.NewLine & "Check if path is correct: " & MYSQL_BIN_PATH, "Restore Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            AuditLogManager.LogAction(LoggedUsername, "Database Restore: Failed. Error: " & errorOutput, isSuccess:=False)
                        End If
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error executing mysql restore: " & ex.Message & Environment.NewLine & "Check if this path is correct: " & MYSQL_BIN_PATH, "Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

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
        ' Assuming FormSettings exists
        FormSettings.ShowDialog()
    End Sub

    Private Sub ViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem.Click
        ' No implementation needed here based on prompt
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
        Me.Close()
        SignupForm.LoadAdminUser()
        SignupForm.Show()
    End Sub
End Class