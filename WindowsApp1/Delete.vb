Imports MySql.Data.MySqlClient
Imports System.Net

Public Class SSS
    Public LoggedUserId As Integer = 0
    Public LoggedUsername As String = ""
    Public LoggedUserRole As String = ""

    'Private Shared ReadOnly ConnectionString As String = "server=localhost; userid=root; password=root; database=labact2;"

    '''' <suASDAmmary>
    '''' Logs an action performed by a user or the system.
    '''' </summary>
    '''' <param name="username">The username of the user performing the action (or "SYSTEM").</param>
    '''' <param name="action">A description of the action (e.g., "Login Successful", "Added book ID 5").</param>
    '''' <param name="isSuccess">Indicates if the action was successful (for logins/failures).</param>
    'Public Shared Sub LogAction(ByVal username As String, ByVal action As String, Optional ByVal isSuccess As Boolean = True)
    '    Dim query As String = "INSERT INTO audit_log_tbl (user, date, time, action, is_success, ip_address) VALUES (@user, @date, @time, @action, @isSuccess, @ip)"

    '    Try
    '        Using conn As New MySqlConnection(ConnectionString)
    '            conn.Open()
    '            Using cmd As New MySqlCommand(query, conn)
    '                ' Parameters from your audit log table structure
    '                cmd.Parameters.AddWithValue("@user", username)
    '                cmd.Parameters.AddWithValue("@date", Date.Now.ToString("yyyy-MM-dd"))
    '                cmd.Parameters.AddWithValue("@time", Date.Now.ToString("HH:mm:ss"))
    '                cmd.Parameters.AddWithValue("@action", action)
    '                cmd.Parameters.AddWithValue("@isSuccess", isSuccess)

    '                ' Get local IP address (a simple attempt, more robust methods exist)
    '                Dim host As String = Dns.GetHostName()
    '                Dim ipAddress As String = ""
    '                Try
    '                    ipAddress = Dns.GetHostEntry(host).AddressList.FirstOrDefault(Function(ip) ip.AddressFamily = Net.Sockets.AddressFamily.InterNetwork)?.ToString()
    '                Catch ex As Exception
    '                    ipAddress = "N/A"
    '                End Try
    '                cmd.Parameters.AddWithValue("@ip", ipAddress)

    '                cmd.ExecuteNonQuery()
    '            End Using
    '        End Using
    '    Catch ex As Exception
    '        ' In a real system, you'd log this error to a file, but for now, ignore or show
    '        Console.WriteLine("Audit Log Error: " & ex.Message)
    '    End Try
    'End Sub
End Class
