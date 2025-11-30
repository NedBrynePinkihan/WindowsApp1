Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ListView
Imports MySql.Data.MySqlClient

Public Class AuditLogging

    Public Shared Sub AddEntry(userID As Integer, username As String, role As String, actionType As String, details As String)
        Try
            Using conn = MySqlConnector.Connect()
                conn.Open()

                Dim query As String =
                "INSERT INTO auditlog (UserID, Username, Role, ActionType, Date, Time, TimeStamp, Details)
                 VALUES (@uid, @uname, @role, @action, CURDATE(), CURTIME(), NOW(), @details)"

                Using cmd As New MySqlCommand(query, conn)

                    If userID <= 0 Then
                        cmd.Parameters.AddWithValue("@uid", 0)
                    Else
                        cmd.Parameters.AddWithValue("@uid", userID)
                    End If

                    cmd.Parameters.AddWithValue("@uname", username)
                    cmd.Parameters.AddWithValue("@role", role)
                    cmd.Parameters.AddWithValue("@action", actionType)
                    cmd.Parameters.AddWithValue("@details", details)

                    cmd.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Audit Error: " & ex.Message)
        End Try
    End Sub


    Public Shared Sub AddEntry(actionType As String, details As String)
        AddEntry(LoggedUserId, LoggedUsername, LoggedUserRole, actionType, details)
    End Sub

    Public Shared Sub AddEntry(actionType As String)
        AddEntry(actionType, "")
    End Sub
End Class

