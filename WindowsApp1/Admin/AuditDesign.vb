Imports MySql.Data.MySqlClient

Public Class AuditDesign
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim query As String = "SELECT auditId, userID, username, role, actionType, details, date, time, timeStamp FROM auditlog"

        Try
            Using conn As New MySqlConnection("server=localhost; userid=root; password=root; database=labact2;")

                Dim adapter As New MySqlDataAdapter(query, conn)
                Dim table As New DataTable()
                adapter.Fill(table)
                dgvAudit.DataSource = table
                AuditLogging.AddEntry("Viewed Audit Logs")
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub AuditDesign_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupInactivityTracking(Me)
        ResetTimer()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
        AdminUserManagementForm.Show()
    End Sub
End Class