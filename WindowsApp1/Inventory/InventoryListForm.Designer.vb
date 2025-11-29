<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventoryListForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBookID = New System.Windows.Forms.TextBox()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.txtAuthor = New System.Windows.Forms.TextBox()
        Me.txtEdition = New System.Windows.Forms.TextBox()
        Me.btnSaveBook = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.Button()
        Me.DGVLibrary = New System.Windows.Forms.DataGridView()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnUpdateBook = New System.Windows.Forms.Button()
        Me.txtPartName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.DGVLibrary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(52, 412)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Part Number"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(290, 408)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Manufacturer"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(290, 448)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Type of vehicle"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(522, 405)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Quantity"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1032, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Label5"
        '
        'txtBookID
        '
        Me.txtBookID.Location = New System.Drawing.Point(133, 405)
        Me.txtBookID.Name = "txtBookID"
        Me.txtBookID.Size = New System.Drawing.Size(100, 20)
        Me.txtBookID.TabIndex = 5
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(375, 401)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(100, 20)
        Me.txtTitle.TabIndex = 6
        '
        'txtAuthor
        '
        Me.txtAuthor.Location = New System.Drawing.Point(385, 441)
        Me.txtAuthor.Name = "txtAuthor"
        Me.txtAuthor.Size = New System.Drawing.Size(100, 20)
        Me.txtAuthor.TabIndex = 7
        '
        'txtEdition
        '
        Me.txtEdition.Location = New System.Drawing.Point(611, 398)
        Me.txtEdition.Name = "txtEdition"
        Me.txtEdition.Size = New System.Drawing.Size(100, 20)
        Me.txtEdition.TabIndex = 8
        '
        'btnSaveBook
        '
        Me.btnSaveBook.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnSaveBook.Location = New System.Drawing.Point(362, 499)
        Me.btnSaveBook.Name = "btnSaveBook"
        Me.btnSaveBook.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveBook.TabIndex = 10
        Me.btnSaveBook.Text = "Save"
        Me.btnSaveBook.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Red
        Me.btnDelete.Location = New System.Drawing.Point(465, 499)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 11
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(1010, 12)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 12
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Location = New System.Drawing.Point(996, 534)
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(75, 23)
        Me.LogoutToolStripMenuItem.TabIndex = 13
        Me.LogoutToolStripMenuItem.Text = "Logout"
        Me.LogoutToolStripMenuItem.UseVisualStyleBackColor = True
        '
        'DGVLibrary
        '
        Me.DGVLibrary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVLibrary.Location = New System.Drawing.Point(30, 38)
        Me.DGVLibrary.Name = "DGVLibrary"
        Me.DGVLibrary.Size = New System.Drawing.Size(1041, 342)
        Me.DGVLibrary.TabIndex = 14
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(30, 12)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(974, 20)
        Me.txtSearch.TabIndex = 15
        '
        'btnUpdateBook
        '
        Me.btnUpdateBook.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnUpdateBook.Location = New System.Drawing.Point(567, 499)
        Me.btnUpdateBook.Name = "btnUpdateBook"
        Me.btnUpdateBook.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdateBook.TabIndex = 16
        Me.btnUpdateBook.Text = "Update"
        Me.btnUpdateBook.UseVisualStyleBackColor = False
        '
        'txtPartName
        '
        Me.txtPartName.Location = New System.Drawing.Point(115, 454)
        Me.txtPartName.Name = "txtPartName"
        Me.txtPartName.Size = New System.Drawing.Size(156, 20)
        Me.txtPartName.TabIndex = 24
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(52, 457)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 13)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Part Name"
        '
        'InventoryListForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 569)
        Me.Controls.Add(Me.txtPartName)
        Me.Controls.Add(Me.Label6)
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
        Me.Controls.Add(Me.txtBookID)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "InventoryListForm"
        Me.Text = "FormLibrary"
        CType(Me.DGVLibrary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtBookID As TextBox
    Friend WithEvents txtTitle As TextBox
    Friend WithEvents txtAuthor As TextBox
    Friend WithEvents txtEdition As TextBox
    Friend WithEvents btnSaveBook As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents LogoutToolStripMenuItem As Button
    Friend WithEvents DGVLibrary As DataGridView
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnUpdateBook As Button
    Friend WithEvents txtPartName As TextBox
    Friend WithEvents Label6 As Label
End Class
