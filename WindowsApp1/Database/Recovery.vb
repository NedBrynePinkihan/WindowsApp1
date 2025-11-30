Imports MySql.Data.MySqlClient

Public Class Recovery
    Private Shared Function GetMysqlsdumpLocation() As String
        Return "C:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump.exe"
    End Function

    Public Shared Sub RestoreFromFile()
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "SQL Files (*.sql)|*.sql"
        ofd.Title = "Select Inventory Backup File"

        If ofd.ShowDialog() <> DialogResult.OK Then Exit Sub

        Dim sqlFile As String = ofd.FileName

        Dim script As String = IO.File.ReadAllText(sqlFile)

        Dim commands() As String = script.Split(New String() {";"}, StringSplitOptions.RemoveEmptyEntries)

        HandleDatabaseIntegrity()
        Dim connString As String = "server=localhost; userid=root; password=root; database=" & MySqlConnector.DatabaseName() & ";"
        Using conn As New MySqlConnection(connString)
            conn.Open()

            For Each cmdText As String In commands
                Dim cleanCmd As String = cmdText.Trim()

                If cleanCmd <> "" Then
                    Using cmd As New MySqlCommand(cleanCmd, conn)
                        Try
                            cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            MessageBox.Show("Error running command: " & cleanCmd & vbCrLf & ex.Message, "Database Restore Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            AuditLogging.AddEntry("Inventory database restore error", ex.Message)
                        End Try
                    End Using
                End If
            Next
            AuditLogging.AddEntry("Inventory database restored", "")
            MessageBox.Show("Database was restored successfully. ", "Database Restore Successful")

            conn.Close()
        End Using
    End Sub

    Public Shared Sub HandleDatabaseIntegrity()
        Dim connString As String = "server=localhost; userid=root; password=root;"
        Dim databaseExists As Boolean = False

        Using conn As New MySqlConnection(connString)
            conn.Open()

            Using cmd As New MySqlCommand("SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = '" & MySqlConnector.DatabaseName() & "';", conn)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    databaseExists = True
                End If
            End Using
            conn.Close()
        End Using

        If databaseExists = False Then
            Using conn As New MySqlConnection(connString)
                conn.Open()

                Using cmd2 As New MySqlCommand($"CREATE DATABASE {MySqlConnector.DatabaseName()};", conn)
                    Try
                        cmd2.ExecuteNonQuery()
                    Catch ex As Exception
                        MessageBox.Show("Error creating new database. " & ex.Message, "Database Restore Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using

                conn.Close()
            End Using
        End If
    End Sub

    Public Shared Sub BackupToFile()
        Dim sfd As New SaveFileDialog()
        sfd.Filter = "SQL Files (*.sql)|*.sql"
        sfd.Title = "Save Inventory Backup"
        sfd.FileName = $"database-inventory_{DateTime.Now:yyyyMMdd_HHmmss}.sql"

        If sfd.ShowDialog() <> DialogResult.OK Then Exit Sub

        Dim backupFile As String = sfd.FileName

        Dim arguments As String =
        "--user=root --password=root --databases " & MySqlConnector.DatabaseName() & " --result-file=""" & backupFile & """"

        Try
            Dim p As New Process()
            p.StartInfo.FileName = GetMysqlsdumpLocation()
            p.StartInfo.Arguments = arguments
            p.StartInfo.UseShellExecute = False
            p.StartInfo.CreateNoWindow = True

            p.Start()
            p.WaitForExit()
            AuditLogging.AddEntry("Database backed up", "")
            MessageBox.Show("Inventory database was successfully backed up. Saved to: " & backupFile, "Database Backup Successful")
        Catch ex As Exception
            MessageBox.Show("Nakalimutan mong palitan ang direktori ng """"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump.exe""""! Baka 8.2 ang bersyon, o iba." & Environment.NewLine & ex.Message, "Database Backup Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogging.AddEntry("Inventory database back up error", ex.Message)
        End Try
    End Sub
End Class