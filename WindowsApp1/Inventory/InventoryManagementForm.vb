Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient
Public Class InventoryManagementForm
    Private conn As MySqlConnection = MySqlConnector.Connect()

    Private oldPartNumber As String = ""
    Private oldPartName As String = ""
    Private oldManufacturer As String = ""
    Private oldVehicleType As String = ""
    Private oldQuantity As Integer = 0

    Private Sub txtPartNumber_TextChanged(sender As Object, e As EventArgs) Handles txtPartNumber.TextChanged, txtPartName.TextChanged
    End Sub


    Private Sub InventoryManagementForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupInactivityTracking(Me)
        ' LoginForm.UpdateActivityTime()
        LoadDGVInventory()
        ' Set initial button text for btnSave (for Insert)
        btnSave.Text = "Save"
        ' Disable the Update and Delete buttons initially until a row is selected
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        ToggleByUserRole()
    End Sub

    Private Sub ToggleByUserRole()
        If LoggedUserRole = "Admin" Then
            btnUpdate.Enabled = True
            btnUpdate.Visible = True

            btnDelete.Enabled = True
            btnDelete.Visible = True

        ElseIf LoggedUserRole = "Staff" Then
            btnUpdate.Enabled = False
            btnUpdate.Visible = False

            btnDelete.Enabled = False
            btnDelete.Visible = False
        End If
    End Sub



    Private Sub LoadDGVInventory()
        Dim query As String = "Select PartNumber, Name,Manufacturer, Typeofvehicle, Quantity FROM component_inventory_tbl"
        Try
            If conn.State <> ConnectionState.Open Then conn.Open()
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgvInventory.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error loading part data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub


    Private Sub ClearTextFields()
        txtPartNumber.Text = ""
        txtPartName.Text = ""
        txtManufacture.Text = ""
        txtVehicleType.Text = ""
        txtQuantity.Text = ""
        txtSearch.Text = "" '

        btnUpdate.Enabled = False '
        btnDelete.Enabled = False

        LoadDGVInventory()
    End Sub

    Private Function ValidateTextFields() As Boolean
        If String.IsNullOrEmpty(txtManufacture.Text) OrElse
            String.IsNullOrEmpty(txtPartName.Text) OrElse
            String.IsNullOrEmpty(txtVehicleType.Text) OrElse
            String.IsNullOrEmpty(txtQuantity.Text) Then
            MessageBox.Show("Every field must be filled in (Part Name, Manufacturer, Typeofvehicle, Quantity).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If


        If Not Regex.IsMatch(txtVehicleType.Text, "^[a-zA-Z\s\-']+$") Then
            MessageBox.Show("Typeofvehicle Name: INPUT MUST BE LETTERS! (Numbers or special characters like @#$ are not allowed).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtVehicleType.Focus()
            Return False
        End If

        Return True
    End Function



    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ResetTimer()
        If Not ValidateTextFields() Then Exit Sub

        If IsNumeric(txtVehicleType.Text) AndAlso Not String.IsNullOrWhiteSpace(txtVehicleType.Text) Then
            MessageBox.Show("Type of Vehicle cannot be a number. Please enter a description (e.g., 'Cruiser', 'Sport Bike').", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtVehicleType.Focus()
            Exit Sub
        End If


        If Not IsNumeric(txtQuantity.Text) Then
            MessageBox.Show("Quantity must be a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtQuantity.Focus()
            Exit Sub
        End If


        Dim query As String = "INSERT INTO component_inventory_tbl (PartNumber, Name, Manufacturer, Typeofvehicle, Quantity) VALUES (@id, @Name, @Manufacturer, @Typeofvehicle, @Quantity)"
        Try
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@id", txtPartNumber.Text)
                cmd.Parameters.AddWithValue("@Name", txtPartName.Text)
                cmd.Parameters.AddWithValue("@Manufacturer", txtManufacture.Text)
                cmd.Parameters.AddWithValue("@Typeofvehicle", txtVehicleType.Text)
                cmd.Parameters.AddWithValue("@Quantity", CDec(txtQuantity.Text))
                cmd.ExecuteNonQuery()

                AuditLogging.AddEntry("Inventory System: Added new Part Number", "Part Number: " &
                    txtPartNumber.Text &
                    ", Part Name: " & txtPartName.Text &
                    ", Manufacturer: " & txtManufacture.Text &
                    ", Type of vehicle: " & txtVehicleType.Text &
                    ", Quantity: " & txtQuantity.Text)

                MessageBox.Show(txtPartNumber.Text & " was added successfully in the inventory catalogue.")
            End Using
        Catch ex As Exception
            MessageBox.Show("Error adding Part Number: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            LoadDGVInventory()
            ClearTextFields()
        End Try
        ResetTimer()
    End Sub




    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ResetTimer()
        If Not ValidateTextFields() Then Exit Sub


        If IsNumeric(txtVehicleType.Text) AndAlso Not String.IsNullOrWhiteSpace(txtVehicleType.Text) Then
            MessageBox.Show("Type of Vehicle cannot be a number. Please enter a description (e.g., 'Cruiser', 'Sport Bike').", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtVehicleType.Focus()
            Exit Sub
        End If


        If Not IsNumeric(txtQuantity.Text) Then
            MessageBox.Show("Quantity must be a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtQuantity.Focus()
            Exit Sub
        End If


        If String.IsNullOrEmpty(txtPartNumber.Text) Then
            MessageBox.Show("Select a Part Number to update first.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim query As String = "UPDATE component_inventory_tbl SET Manufacturer=@Manufacturer, Name=@Name, Typeofvehicle=@Typeofvehicle, Quantity=@Quantity WHERE PartNumber=@id"

        Try
            Using conn = MySqlConnector.Connect()
                conn.Open()
                Using cmd As New MySqlCommand("SELECT * FROM component_inventory_tbl WHERE partNumber=@oldPartNumber", conn)
                    cmd.Parameters.AddWithValue("@oldPartNumber", oldPartNumber)
                    Dim reader As MySqlDataReader = cmd.ExecuteReader()

                    If reader.Read() Then
                        oldPartNumber = reader("PartNumber").ToString()
                        oldPartName = reader("Name").ToString()
                        oldManufacturer = reader("Manufacturer").ToString()
                        oldVehicleType = reader("Typeofvehicle").ToString()
                        oldQuantity = Convert.ToInt32(reader("Quantity"))
                    End If
                End Using
            End Using

            Using conn = MySqlConnector.Connect()
                conn.Open()
                Using cmd As New MySqlCommand("UPDATE component_inventory_tbl SET PartNumber=@newPartNumber, Manufacturer=@Manufacturer, Name=@Name, Typeofvehicle=@Typeofvehicle, Quantity=@Quantity WHERE PartNumber=@oldPartNumber", conn)
                    cmd.Parameters.AddWithValue("@oldPartNumber", oldPartNumber)

                    cmd.Parameters.AddWithValue("@newPartNumber", txtPartNumber.Text)
                    cmd.Parameters.AddWithValue("@Manufacturer", txtManufacture.Text)
                    cmd.Parameters.AddWithValue("@Name", txtPartName.Text)
                    cmd.Parameters.AddWithValue("@Typeofvehicle", txtVehicleType.Text)
                    cmd.Parameters.AddWithValue("@Quantity", CDec(txtQuantity.Text))

                    If cmd.ExecuteNonQuery() > 0 Then
                        AuditLogging.AddEntry("Inventory System: Modified Inventory Item", "Old values: (" &
                    "Part Number: " & oldPartNumber &
                    ", Part Name: " & oldPartName &
                    ", Manufacturer: " & oldManufacturer &
                    ", Type of vehicle: " & oldVehicleType &
                    ", Quantity: " & oldQuantity & "), " &
                    "New values: (" &
                    "Part Number: " & txtPartNumber.Text &
                    ", Part Name: " & txtPartName.Text &
                    ", Manufacturer: " & txtManufacture.Text &
                    ", Type of vehicle: " & txtVehicleType.Text &
                    ", Quantity: " & txtQuantity.Text & ")")
                        MessageBox.Show("Part Number" & txtPartNumber.Text & " updated successfully.")
                    Else
                        AuditLogging.AddEntry("Inventory System: Failed Modifying Inventory Item", "Attempted value changes: (" &
                    "Part Number: " & txtPartNumber.Text &
                    ", Part Name: " & txtPartName.Text &
                    ", Manufacturer: " & txtManufacture.Text &
                    ", Type of vehicle: " & txtVehicleType.Text &
                    ", Quantity: " & txtQuantity.Text & ")")
                        MessageBox.Show("Part Number " & txtPartNumber.Text & " not found or no changes were made.")
                    End If

                    oldPartNumber = txtPartNumber.Text
                End Using
            End Using
        Catch ex As Exception
            AuditLogging.AddEntry("Inventory System: Error Modifying Inventory Item", "Attempted value changes: (" &
                    "Part Number: " & txtPartNumber.Text &
                    ", Part Name: " & txtPartName.Text &
                    ", Manufacturer: " & txtManufacture.Text &
                    ", Type of vehicle: " & txtVehicleType.Text &
                    ", Quantity: " & txtQuantity.Text & ")")
            MessageBox.Show("Part Number " & txtPartNumber.Text & " not found or no changes were made.")
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            LoadDGVInventory()
            ClearTextFields()
        End Try
        ResetTimer()
    End Sub


    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ResetTimer()
        ' LoginForm.UpdateActivityTime()
        If String.IsNullOrEmpty(txtPartNumber.Text) Then
            MessageBox.Show("Select a Part Number to delete first.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim query As String = "DELETE FROM component_inventory_tbl WHERE PartNumber=@id"

        If MessageBox.Show("Are you sure you want to delete Part Number ID " & txtPartNumber.Text & "?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        Try
            If conn.State <> ConnectionState.Open Then conn.Open()
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@id", txtPartNumber.Text)
                If cmd.ExecuteNonQuery() > 0 Then
                    MessageBox.Show("Part Number " & txtPartNumber.Text & " deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ' AuditLogManager.LogAction(LoginForm.LoggedInUsername, "Library System: Deleted record for book ID " & bookIdToDelete)
                Else
                    MessageBox.Show("Part Number " & txtPartNumber.Text & " not found.", "Delete Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error deleting Part Number: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            LoadDGVInventory()
            ClearTextFields()
        End Try
    End Sub



    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ResetTimer()
        ' LoginForm.UpdateActivityTime()
        If String.IsNullOrEmpty(txtSearch.Text) Then
            LoadDGVInventory()
            Exit Sub
        End If

        Dim searchTerm As String = "%" & txtSearch.Text & "%"
        ' Search across ID, Title, and Author
        Dim query As String = "SELECT PartNumber,Name, Manufacturer, Typeofvehicle, Quantity FROM component_inventory_tbl WHERE PartNumber LIKE @term OR Manufacturer LIKE @term OR Typeofvehicle LIKE @term"

        Try
            If conn.State <> ConnectionState.Open Then conn.Open()
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@term", searchTerm)
                Dim adapter As New MySqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                dgvInventory.DataSource = table

                If table.Rows.Count = 0 Then
                    MessageBox.Show("No Part Number found matching your search term.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error searching: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            ResetTimer()
        End Try

    End Sub



    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ' LoginForm.UpdateActivityTime()
        ClearTextFields()
    End Sub


    Private Sub DGVLibrary_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInventory.CellContentClick
        ' LoginForm.UpdateActivityTime()
        ' Ensure the click is on a valid row, not the header
        ResetTimer()
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvInventory.Rows.Count - 1 Then ' Exclude the new row placeholder
            Dim row As DataGridViewRow = dgvInventory.Rows(e.RowIndex)

            ' Populate the text fields with the selected row's data
            If row.Cells("PartNumber").Value IsNot DBNull.Value Then txtPartNumber.Text = row.Cells("PartNumber").Value.ToString() Else txtPartNumber.Text = ""
            If row.Cells("Name").Value IsNot DBNull.Value Then txtPartName.Text = row.Cells("Name").Value.ToString() Else txtPartNumber.Text = ""
            If row.Cells("Manufacturer").Value IsNot DBNull.Value Then txtManufacture.Text = row.Cells("Manufacturer").Value.ToString() Else txtManufacture.Text = ""
            If row.Cells("Typeofvehicle").Value IsNot DBNull.Value Then txtVehicleType.Text = row.Cells("Typeofvehicle").Value.ToString() Else txtVehicleType.Text = ""
            If row.Cells("Quantity").Value IsNot DBNull.Value Then txtQuantity.Text = row.Cells("Quantity").Value.ToString() Else txtQuantity.Text = ""

            btnUpdate.Enabled = True
            btnDelete.Enabled = True
        End If
    End Sub


    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        'Logout(Me)
        Me.Hide()

        AdminUserManagementForm.Show()
    End Sub


    Private Sub DGVLibrary_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInventory.CellClick
        ResetTimer()

        CellValuesToTextboxes(dgvInventory.CurrentRow.Index)
        btnUpdate.Enabled = True
        btnDelete.Enabled = True

        ResetTimer()
    End Sub

    Private Sub CellValuesToTextboxes(rowIndex As Integer)
        If rowIndex >= 0 Then
            txtPartNumber.Text = dgvInventory.Rows(rowIndex).Cells("PartNumber").Value.ToString()
            txtPartName.Text = dgvInventory.Rows(rowIndex).Cells("Name").Value.ToString()
            txtManufacture.Text = dgvInventory.Rows(rowIndex).Cells("Manufacturer").Value.ToString()
            txtQuantity.Text = dgvInventory.Rows(rowIndex).Cells("Quantity").Value.ToString()

            oldPartNumber = txtPartName.Text
        Else
            txtPartNumber.Text = ""
            txtPartName.Text = ""
            txtManufacture.Text = ""
            txtQuantity.Text = ""
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadDGVInventory()
    End Sub
End Class