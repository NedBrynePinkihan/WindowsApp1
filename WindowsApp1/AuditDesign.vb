Imports MySql.Data.MySqlClient

Public Class AuditDesign
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Audit.AddEntry(LoggedUserId, LoggedUsername, LoggedUserRole, "VIew Stock", "Succesfully Viewed")
        Dim query As String = "SELECT idaudit, userid, username, role, actiontype, detail, date, time, timestamp FROM audit_tbl"

        Try
            Using conn As New MySqlConnection("server=localhost; userid=root; password=root; database=student_db;")

                Dim adapter As New MySqlDataAdapter(query, conn)
                Dim table As New DataTable()
                adapter.Fill(table)
                dgvAudit.DataSource = table

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub AuditDesign_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupInactivityTracking(Me)
    End Sub
End Class