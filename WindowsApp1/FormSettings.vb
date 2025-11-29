Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.IO

Public Class FormSettings ' Admin Settings and Audit Log View Form

    Dim conn As New MySqlConnection("server=localhost; userid=root; password=root; database=labact2")

    Private Sub FormSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoginForm.UpdateActivityTime()
        ' Admin-only access guard
        If LoggedUserRole <> "Admin" Then
            MessageBox.Show("Access Denied. Only Administrators can access Settings.", "Security Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
            Exit Sub
        End If
        LoadAuditLogs()
    End Sub

    Private Sub LoadAuditLogs()
        Dim query As String = "SELECT ID, user, date, time, action, is_success FROM audit_log_tbl ORDER BY date DESC, time DESC"

        Try
            conn.Open()
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            DGV_AuditLogs.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error loading Audit Logs: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        LoginForm.UpdateActivityTime()
        Dim query As String = "SELECT ID, user, date, time, action, is_success FROM audit_log_tbl WHERE 1=1 "
        Dim parameters As New List(Of MySqlParameter)

        ' Filter by User
        If Not String.IsNullOrEmpty(txtUserFilter.Text) Then
            query &= " AND user LIKE @user "
            parameters.Add(New MySqlParameter("@user", "%" & txtUserFilter.Text & "%"))
        End If

        ' Filter by Time (e.g., "8:00 AM")
        If Not String.IsNullOrEmpty(txtTimeFilter.Text) Then
            query &= " AND TIME(time) = TIME(@time) "
            parameters.Add(New MySqlParameter("@time", txtTimeFilter.Text))
        End If

        query &= " ORDER BY date DESC, time DESC"

        Try
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
                For Each p As MySqlParameter In parameters
                    cmd.Parameters.Add(p)
                Next
                Dim adapter As New MySqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                DGV_AuditLogs.DataSource = table
            End Using
        Catch ex As Exception
            MessageBox.Show("Error filtering Audit Logs: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub btnRefreshLogs_Click(sender As Object, e As EventArgs) Handles btnRefreshLogs.Click
        LoginForm.UpdateActivityTime()
        LoadAuditLogs()
        txtUserFilter.Clear()
        txtTimeFilter.Clear()
    End Sub
    'final'
    ' --- Backup and Restore Placeholders ---
    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        LoginForm.UpdateActivityTime()
        MessageBox.Show("Database Backup is a placeholder. Implementation requires external tools like mysqldump and system process execution.", "Backup - Placeholder", MessageBoxButtons.OK, MessageBoxIcon.Information)
        AuditLogManager.LogAction(LoggedUsername, "Attempted Database Backup (Placeholder)")
    End Sub

    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        LoginForm.UpdateActivityTime()
        MessageBox.Show("Database Restore is a placeholder. Implementation requires careful file handling and external tools, and should only be done by system admins.", "Restore - Placeholder", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        AuditLogManager.LogAction(LoggedUsername, "Attempted Database Restore (Placeholder)")
    End Sub

    Private Sub DGV_AuditLogs_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_AuditLogs.CellContentClick

    End Sub
End Class