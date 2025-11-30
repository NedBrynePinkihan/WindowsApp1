Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Text.RegularExpressions

Public Class InventoryListForm ' Main Library System Form

    Dim conn As New MySqlConnection("server=localhost; userid=root; password=root; database=labact2")

    Private Sub FormLibrary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupInactivityTracking(Me)
        LoginForm.UpdateActivityTime()
        LoadBookData()
        ' Set initial button text for btnSaveBook (for Insert)
        btnSaveBook.Text = "Save"
        ' Disable the Update and Delete buttons initially until a row is selected
        btnUpdateBook.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Private Sub LoadBookData()
        Dim query As String = "SELECT PartNumber, Name, Manufacturer, Typeofvehicle, Quantity FROM component_inventory_tbl"
        Try
            conn.Open()
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            DGVLibrary.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error loading Part Number: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' Clears the input fields and sets btnSaveBook for "Save" (Insert) mode
    Private Sub ClearBookFields()
        txtBookID.Text = ""
        txtTitle.Text = ""
        txtAuthor.Text = ""
        txtEdition.Text = ""
        btnSaveBook.Text = "Save"

    End Sub

    ' --- Validation: Ensures Author field contains only letters and spaces (no numbers) ---
    Private Function ValidateBookFields() As Boolean
        If String.IsNullOrEmpty(txtTitle.Text) OrElse String.IsNullOrEmpty(txtAuthor.Text) OrElse String.IsNullOrEmpty(txtEdition.Text) Then
            MessageBox.Show("Every field must be filled in.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        ' INPUT MUST BE LETTERS! (Includes spaces, hyphens, and apostrophes for common names)
        If Regex.IsMatch(txtAuthor.Text, "[\d]") Then
            MessageBox.Show("Typeofvehicle Name: INPUT MUST BE LETTERS! (Numbers are not allowed).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAuthor.Focus()
            Return False
        End If

        Return True
    End Function



    Private Sub btnSaveBook_Click(sender As Object, e As EventArgs) Handles btnSaveBook.Click
        ResetTimer()
        If Not ValidateBookFields() Then Exit Sub

        ' **NEW QUANTITY VALIDATION**
        If Not IsNumeric(txtEdition.Text) Then
            MessageBox.Show("Quantity must be a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtEdition.Focus()
            Exit Sub
        End If

        ' **THIS SECTION IS NOW ONLY FOR INSERTING NEW RECORDS ("Save")**
        Dim query As String = "INSERT INTO component_inventory_tbl (PartNumber, Name, Manufacturer, Typeofvehicle, Quantity) VALUES (@PartNumber, @Name, @Manufacturer, @Typeofvehicle, @Quantity)"
        Try
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@PartNumber", txtPartName.Text)
                cmd.Parameters.AddWithValue("Name", txtPartName.Text)
                cmd.Parameters.AddWithValue("@Manufacturer", txtTitle.Text)
                cmd.Parameters.AddWithValue("@Typeofvehicle", txtAuthor.Text)
                ' Convert to a Decimal/Numeric type (CDec) after validation
                cmd.Parameters.AddWithValue("@Quantity", CDec(txtEdition.Text))
                cmd.ExecuteNonQuery()

                Dim lastId As Long = Convert.ToInt64(New MySqlCommand("SELECT LAST_INSERT_ID();", conn).ExecuteScalar())

                MessageBox.Show("Part Number added successfully ")
                AuditLogging.AddEntry("Inventory System: Added new Part Number", "Part Number" & lastId & " (" & txtTitle.Text & ")")
            End Using
        Catch ex As Exception
            MessageBox.Show("Error adding Part Number: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            LoadBookData()
            ClearBookFields()
        End Try
    End Sub



    ' **NEW Subroutine for the dedicated Update button**
    Private Sub btnUpdateBook_Click(sender As Object, e As EventArgs) Handles btnUpdateBook.Click
        ResetTimer()

        If Not ValidateBookFields() Then Exit Sub

        ' **NEW QUANTITY VALIDATION**
        If Not IsNumeric(txtEdition.Text) Then
            MessageBox.Show("Quantity must be a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtEdition.Focus()
            Exit Sub
        End If

        ' Ensure a BookID is present (meaning a record was selected)
        If String.IsNullOrEmpty(txtBookID.Text) Then
            MessageBox.Show("Select a part to update first.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim query As String = "UPDATE component_inventory_tbl SET Manufacturer=@Manufacturer, Typeofvehicle=@Typeofvehicle, Quantity=@Quantity WHERE PartNumber=@id"

        Try
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Manufacturer", txtTitle.Text)
                cmd.Parameters.AddWithValue("@Typeofvehicle", txtAuthor.Text)
                ' Convert to a Decimal/Numeric type (CDec) after validation
                cmd.Parameters.AddWithValue("@Quantity", CDec(txtEdition.Text))
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtBookID.Text))

                If cmd.ExecuteNonQuery() > 0 Then
                    AuditLogging.AddEntry("Inventory System: Updated Part Numbeer", "Part Number: " & txtBookID.Text)
                    MessageBox.Show("Part Number " & txtBookID.Text & " updated successfully.")
                Else
                    MessageBox.Show("Part Number" & txtBookID.Text & " not found or no changes were made.")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating Part: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            LoadBookData()
            ClearBookFields()
        End Try

    End Sub


    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ResetTimer()

        If String.IsNullOrEmpty(txtBookID.Text) Then
            MessageBox.Show("Select a part to delete first.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim bookIdToDelete As Integer = Convert.ToInt32(txtBookID.Text)
        Dim query As String = "DELETE FROM component_inventory_tbl WHERE PartNumber=@id"

        If MessageBox.Show("Are you sure you want to delete Part Number " & bookIdToDelete & "?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        Try
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@id", bookIdToDelete)
                If cmd.ExecuteNonQuery() > 0 Then
                    AuditLogging.AddEntry("Inventory System: Deleted record for Part Number", "Part Number: " & bookIdToDelete)
                    MessageBox.Show("Part Number " & bookIdToDelete & " deleted successfully.")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error deleting Part Number: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            LoadBookData()
            ClearBookFields()
        End Try
    End Sub


    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ResetTimer()
        If String.IsNullOrEmpty(txtSearch.Text) Then
            LoadBookData()
            Exit Sub
        End If

        Dim searchTerm As String = "%" & txtSearch.Text & "%"
        Dim query As String = "SELECT PartNumber, Name, Manufacturer, Typeofvehicle, Quantity FROM component_inventory_tbl WHERE PartNumber LIKE @term OR Manufacturer LIKE @term OR Typeofvehicle LIKE @term"

        Try
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@term", searchTerm)
                Dim adapter As New MySqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                DGVLibrary.DataSource = table
            End Using
        Catch ex As Exception
            MsgBox("Error searching: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub



    Private Sub DGVLibrary_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVLibrary.CellContentClick
        LoginForm.UpdateActivityTime()
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DGVLibrary.Rows(e.RowIndex)
            txtBookID.Text = row.Cells("PartNumber").Value.ToString()
            txtTitle.Text = row.Cells("Manufacturer").Value.ToString()
            txtPartName.Text = row.Cells("Name").Value.ToString()
            txtAuthor.Text = row.Cells("Typeofvehicle").Value.ToString()
            txtEdition.Text = row.Cells("Quantity").Value.ToString()

            ' Change btnSaveBook text to indicate a new action is required
            btnSaveBook.Text = "Save"

            ' Enable Update and Delete buttons now that a row is selected

        End If
    End Sub



    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click

        'AuditLogManager.LogAction(LoggedUsername, "Logged out from Library form.")
        'LoggedUsername = ""
        'LoggedUserRole = ""
        'Me.Close()
        'LoginForm.Show()
        Logout(Me)
    End Sub

    Private Sub txtBookID_TextChanged(sender As Object, e As EventArgs) Handles txtBookID.TextChanged

    End Sub

    Private Sub txtEdition_TextChanged(sender As Object, e As EventArgs) Handles txtEdition.TextChanged

    End Sub

    ' You might want to add a Clear button/functionality too
    ' Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
    '     ClearBookFields()
    ' End Sub

End Class