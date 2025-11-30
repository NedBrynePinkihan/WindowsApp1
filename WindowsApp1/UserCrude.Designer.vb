Imports System.Data
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms ' Required for MessageBox, DialogResult etc.

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserCrude
    Inherits System.Windows.Forms.Form

    ' Database Connection - Now a member of the UserCrude class
    ' NOTE: This connection string should be handled securely in a real application.
    Dim conn As New MySqlConnection("server=localhost; userid=root; password=root; database=labact2")


    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnUpdateBook = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.DGVLibrary = New System.Windows.Forms.DataGridView()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSaveBook = New System.Windows.Forms.Button()
        Me.txtEdition = New System.Windows.Forms.TextBox()
        Me.txtAuthor = New System.Windows.Forms.TextBox()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.txtPartNumber = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPartName = New System.Windows.Forms.TextBox()
        CType(Me.DGVLibrary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnUpdateBook
        '
        Me.btnUpdateBook.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnUpdateBook.Location = New System.Drawing.Point(551, 501)
        Me.btnUpdateBook.Name = "btnUpdateBook"
        Me.btnUpdateBook.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdateBook.TabIndex = 32
        Me.btnUpdateBook.Text = "Update"
        Me.btnUpdateBook.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(33, 37)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(872, 20)
        Me.txtSearch.TabIndex = 31
        '
        'DGVLibrary
        '
        Me.DGVLibrary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVLibrary.Location = New System.Drawing.Point(22, 73)
        Me.DGVLibrary.Name = "DGVLibrary"
        Me.DGVLibrary.Size = New System.Drawing.Size(1059, 343)
        Me.DGVLibrary.TabIndex = 30
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Location = New System.Drawing.Point(1023, 554)
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(75, 23)
        Me.LogoutToolStripMenuItem.TabIndex = 29
        Me.LogoutToolStripMenuItem.Text = "Logout"
        Me.LogoutToolStripMenuItem.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(926, 34)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(155, 23)
        Me.btnSearch.TabIndex = 28
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Red
        Me.btnDelete.Location = New System.Drawing.Point(421, 502)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 27
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnSaveBook
        '
        Me.btnSaveBook.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnSaveBook.Location = New System.Drawing.Point(324, 502)
        Me.btnSaveBook.Name = "btnSaveBook"
        Me.btnSaveBook.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveBook.TabIndex = 26
        Me.btnSaveBook.Text = "Save"
        Me.btnSaveBook.UseVisualStyleBackColor = False
        '
        'txtEdition
        '
        Me.txtEdition.Location = New System.Drawing.Point(651, 465)
        Me.txtEdition.Name = "txtEdition"
        Me.txtEdition.Size = New System.Drawing.Size(100, 20)
        Me.txtEdition.TabIndex = 25
        '
        'txtAuthor
        '
        Me.txtAuthor.Location = New System.Drawing.Point(636, 422)
        Me.txtAuthor.Name = "txtAuthor"
        Me.txtAuthor.Size = New System.Drawing.Size(100, 20)
        Me.txtAuthor.TabIndex = 24
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(396, 429)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(100, 20)
        Me.txtTitle.TabIndex = 23
        '
        'txtPartNumber
        '
        Me.txtPartNumber.Location = New System.Drawing.Point(120, 429)
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.Size = New System.Drawing.Size(156, 20)
        Me.txtPartNumber.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(562, 472)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Quantity"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(548, 429)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Type of vehicle"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(323, 436)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Manufacturer"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 432)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Part Number"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(656, 502)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 33
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(57, 458)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Part Name"
        '
        'txtPartName
        '
        Me.txtPartName.Location = New System.Drawing.Point(120, 455)
        Me.txtPartName.Name = "txtPartName"
        Me.txtPartName.Size = New System.Drawing.Size(156, 20)
        Me.txtPartName.TabIndex = 22
        '
        'UserCrude
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1136, 589)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnUpdateBook)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.DGVLibrary)
        Me.Controls.Add(Me.LogoutToolStripMenuItem)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSaveBook)
        Me.Controls.Add(Me.txtEdition)
        Me.Controls.Add(Me.txtAuthor)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.txtPartName)
        Me.Controls.Add(Me.txtPartNumber)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "UserCrude"
        Me.Text = "UserCrude"
        CType(Me.DGVLibrary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnUpdateBook As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents DGVLibrary As DataGridView
    Friend WithEvents LogoutToolStripMenuItem As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnSaveBook As Button
    Friend WithEvents txtEdition As TextBox
    Friend WithEvents txtAuthor As TextBox
    Friend WithEvents txtTitle As TextBox
    Friend WithEvents txtPartNumber As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnClear As Button ' Added Clear Button definition

    Private Sub txtBookID_TextChanged(sender As Object, e As EventArgs) Handles txtPartNumber.TextChanged, txtPartName.TextChanged
        ' This handler is kept but typically empty for a ReadOnly BookID field
    End Sub

    ' Renamed to reflect the main class name
    Private Sub UserCrude_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupInactivityTracking(Me)
        ' LoginForm.UpdateActivityTime()
        LoadBookData()
        ' Set initial button text for btnSaveBook (for Insert)
        btnSaveBook.Text = "Save"
        ' Disable the Update and Delete buttons initially until a row is selected
        btnUpdateBook.Enabled = False
        btnDelete.Enabled = False
    End Sub

    ' Helper method to load data into the DataGridView
    Private Sub LoadBookData()
        Dim query As String = "SELECT PartNumber, Name,Manufacturer, Typeofvehicle, Quantity FROM component_inventory_tbl"
        Try
            If conn.State <> ConnectionState.Open Then conn.Open()
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            DGVLibrary.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error loading book data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' Clears the input fields and sets button states to "Save" mode
    Private Sub ClearBookFields()
        txtPartNumber.Text = ""
        txtPartName.Text = ""
        txtTitle.Text = ""
        txtAuthor.Text = ""
        txtEdition.Text = ""
        txtSearch.Text = "" ' Also clear the search box

        btnUpdateBook.Enabled = False ' Disable Update/Delete when fields are cleared
        btnDelete.Enabled = False

        LoadBookData() ' Reload the full data set to clear search filter
    End Sub

    ' --- Validation: Ensures all fields are filled and Author field contains only letters/spaces ---
    Private Function ValidateBookFields() As Boolean
        If String.IsNullOrEmpty(txtTitle.Text) OrElse
            String.IsNullOrEmpty(txtPartName.Text) OrElse
            String.IsNullOrEmpty(txtAuthor.Text) OrElse
            String.IsNullOrEmpty(txtEdition.Text) Then
            MessageBox.Show("Every field must be filled in (Part Name, Manufacturer, Typeofvehicle, Quantity).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        ' INPUT MUST BE LETTERS! (Includes spaces, hyphens, and apostrophes for common names)
        If Not Regex.IsMatch(txtAuthor.Text, "^[a-zA-Z\s\-']+$") Then
            MessageBox.Show("Typeofvehicle Name: INPUT MUST BE LETTERS! (Numbers or special characters like @#$ are not allowed).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAuthor.Focus()
            Return False
        End If

        Return True
    End Function


    ' --- 1. SAVE Button (Insert) ---
    Private Sub btnSaveBook_Click(sender As Object, e As EventArgs) Handles btnSaveBook.Click
        ResetTimer()
        LoginForm.UpdateActivityTime()
        If Not ValidateBookFields() Then Exit Sub ' <--- Calls the fixed validation function

        ' **VALIDATION ADDED FOR TYPE OF VEHICLE**
        If IsNumeric(txtAuthor.Text) AndAlso Not String.IsNullOrWhiteSpace(txtAuthor.Text) Then
            MessageBox.Show("Type of Vehicle cannot be a number. Please enter a description (e.g., 'Cruiser', 'Sport Bike').", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAuthor.Focus()
            Exit Sub
        End If

        ' **QUANTITY VALIDATION**
        If Not IsNumeric(txtEdition.Text) Then
            MessageBox.Show("Quantity must be a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtEdition.Focus()
            Exit Sub
        End If

        ' **THIS SECTION IS NOW ONLY FOR INSERTING NEW RECORDS ("Save")**
        Dim query As String = "INSERT INTO component_inventory_tbl (PartNumber, Name, Manufacturer, Typeofvehicle, Quantity) VALUES (@id, @Name, @Manufacturer, @Typeofvehicle, @Quantity)"
        Try
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@id", txtPartNumber.Text)
                cmd.Parameters.AddWithValue("@Name", txtPartName.Text)
                cmd.Parameters.AddWithValue("@Manufacturer", txtTitle.Text)
                cmd.Parameters.AddWithValue("@Typeofvehicle", txtAuthor.Text)
                cmd.Parameters.AddWithValue("@Quantity", CDec(txtEdition.Text))
                cmd.ExecuteNonQuery()

                MessageBox.Show(txtPartNumber.Text & " was added successfully in the inventory catalogue.")
                'AuditLogManager.LogAction(LoginForm.LoggedInUsername, "Inventory System: Added new Part Number " & lastId & " (" & txtTitle.Text & ")")
            End Using
        Catch ex As Exception
            MessageBox.Show("Error adding Part Number: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            LoadBookData()
            ClearBookFields()
        End Try
        ResetTimer()
    End Sub



    ' **NEW Subroutine for the dedicated Update button**
    Private Sub btnUpdateBook_Click(sender As Object, e As EventArgs) Handles btnUpdateBook.Click
        ResetTimer()
        LoginForm.UpdateActivityTime()
        If Not ValidateBookFields() Then Exit Sub

        ' **VALIDATION ADDED FOR TYPE OF VEHICLE**
        If IsNumeric(txtAuthor.Text) AndAlso Not String.IsNullOrWhiteSpace(txtAuthor.Text) Then
            MessageBox.Show("Type of Vehicle cannot be a number. Please enter a description (e.g., 'Cruiser', 'Sport Bike').", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAuthor.Focus()
            Exit Sub
        End If

        ' **QUANTITY VALIDATION**
        If Not IsNumeric(txtEdition.Text) Then
            MessageBox.Show("Quantity must be a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtEdition.Focus()
            Exit Sub
        End If

        ' Ensure a BookID is present (meaning a record was selected)
        If String.IsNullOrEmpty(txtPartNumber.Text) Then
            MessageBox.Show("Select a Part Number to update first.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim query As String = "UPDATE component_inventory_tbl SET Manufacturer=@Manufacturer, Name=@Name, Typeofvehicle=@Typeofvehicle, Quantity=@Quantity WHERE PartNumber=@id"

        Try
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Manufacturer", txtTitle.Text)
                cmd.Parameters.AddWithValue("@Name", txtPartName.Text)
                cmd.Parameters.AddWithValue("@Typeofvehicle", txtAuthor.Text)
                cmd.Parameters.AddWithValue("@Quantity", CDec(txtEdition.Text))
                cmd.Parameters.AddWithValue("@id", txtPartNumber.Text)

                If cmd.ExecuteNonQuery() > 0 Then
                    AuditLogging.AddEntry("Inventory System: Updated Part Number", "Username: " & txtPartNumber.Text)
                    MessageBox.Show("Part Number" & txtPartNumber.Text & " updated successfully.")
                Else
                    MessageBox.Show("Part Number " & txtPartNumber.Text & " not found or no changes were made.")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating Part Number: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            LoadBookData()
            ClearBookFields()
        End Try
        ResetTimer()
    End Sub


    ' --- 3. DELETE Button (Now fully functional when enabled) ---
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
            LoadBookData()
            ClearBookFields()
        End Try
    End Sub


    ' --- 4. SEARCH Button ---
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ResetTimer()
        ' LoginForm.UpdateActivityTime()
        If String.IsNullOrEmpty(txtSearch.Text) Then
            LoadBookData()
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
                DGVLibrary.DataSource = table

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


    ' --- 5. CLEAR Button ---
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ' LoginForm.UpdateActivityTime()
        ClearBookFields()
    End Sub


    ' --- DataGridView Row Click Handler (Populate fields and enable Update/Delete) ---
    Private Sub DGVLibrary_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVLibrary.CellContentClick
        ' LoginForm.UpdateActivityTime()
        ' Ensure the click is on a valid row, not the header
        ResetTimer()
        If e.RowIndex >= 0 AndAlso e.RowIndex < DGVLibrary.Rows.Count - 1 Then ' Exclude the new row placeholder
            Dim row As DataGridViewRow = DGVLibrary.Rows(e.RowIndex)

            ' Populate the text fields with the selected row's data
            If row.Cells("PartNumber").Value IsNot DBNull.Value Then txtPartNumber.Text = row.Cells("PartNumber").Value.ToString() Else txtPartNumber.Text = ""
            If row.Cells("Name").Value IsNot DBNull.Value Then txtPartName.Text = row.Cells("Name").Value.ToString() Else txtPartNumber.Text = ""
            If row.Cells("Manufacturer").Value IsNot DBNull.Value Then txtTitle.Text = row.Cells("Manufacturer").Value.ToString() Else txtTitle.Text = ""
            If row.Cells("Typeofvehicle").Value IsNot DBNull.Value Then txtAuthor.Text = row.Cells("Typeofvehicle").Value.ToString() Else txtAuthor.Text = ""
            If row.Cells("Quantity").Value IsNot DBNull.Value Then txtEdition.Text = row.Cells("Quantity").Value.ToString() Else txtEdition.Text = ""

            ' *** KEY STEP: Enable Update and Delete buttons now that a row is selected ***
            btnUpdateBook.Enabled = True
            btnDelete.Enabled = True
        End If
    End Sub


    ' --- Logout Button ---
    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        ' AuditLogManager.LogAction(LoginForm.LoggedInUsername, "Logged out from Library form.")
        ' LoginForm.LoggedInUsername = ""
        ' LoginForm.LoggedInRole = ""
        ' Me.Close()
        ' LoginForm.Show()
        MessageBox.Show("Logged out functionality would redirect to the login screen.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information)
        StopTimer()
    End Sub

    Friend WithEvents Label5 As Label
    Friend WithEvents txtPartName As TextBox

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub txtTitle_TextChanged(sender As Object, e As EventArgs) Handles txtTitle.TextChanged

    End Sub
End Class