Imports MySql.Data.MySqlClient

Public Class MySqlConnector
    Public Shared Function Connect() As MySqlConnection
        Return New MySqlConnection("server=localhost; userid=root; password=root; database=labact2;")
    End Function

    Public Shared Function DatabaseName() As String
        Return "labact2"
    End Function
End Class