<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdminUserManagementForm
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Me.DGVUserAdmin = New System.Windows.Forms.DataGridView()
        Me.lbl = New System.Windows.Forms.Label()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MainToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddUserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Password = New System.Windows.Forms.Label()
        Me.txtusername = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.cmbRole = New System.Windows.Forms.ComboBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.DGVUserAdmin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGVUserAdmin
        '
        Me.DGVUserAdmin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVUserAdmin.Location = New System.Drawing.Point(12, 49)
        Me.DGVUserAdmin.Name = "DGVUserAdmin"
        Me.DGVUserAdmin.Size = New System.Drawing.Size(497, 256)
        Me.DGVUserAdmin.TabIndex = 0
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.Location = New System.Drawing.Point(12, 33)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(57, 13)
        Me.lbl.TabIndex = 1
        Me.lbl.Text = "Authorized"
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.Black
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnUpdate.Location = New System.Drawing.Point(523, 196)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(585, 45)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(100, 20)
        Me.txtID.TabIndex = 3
        '
        'btnView
        '
        Me.btnView.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnView.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnView.Location = New System.Drawing.Point(523, 225)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(75, 23)
        Me.btnView.TabIndex = 5
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = False
        '
        'btnRemove
        '
        Me.btnRemove.BackColor = System.Drawing.Color.Red
        Me.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemove.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnRemove.Location = New System.Drawing.Point(523, 254)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(75, 23)
        Me.btnRemove.TabIndex = 6
        Me.btnRemove.Text = "Delete"
        Me.btnRemove.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(520, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "ID"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(520, 133)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Status"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MainToolStripMenuItem, Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(890, 24)
        Me.MenuStrip1.TabIndex = 18
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MainToolStripMenuItem
        '
        Me.MainToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewToolStripMenuItem, Me.UserDatabaseToolStripMenuItem, Me.AddUserToolStripMenuItem})
        Me.MainToolStripMenuItem.Name = "MainToolStripMenuItem"
        Me.MainToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.MainToolStripMenuItem.Text = "Main"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'UserDatabaseToolStripMenuItem
        '
        Me.UserDatabaseToolStripMenuItem.Name = "UserDatabaseToolStripMenuItem"
        Me.UserDatabaseToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.UserDatabaseToolStripMenuItem.Text = "User Database"
        '
        'AddUserToolStripMenuItem
        '
        Me.AddUserToolStripMenuItem.Name = "AddUserToolStripMenuItem"
        Me.AddUserToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AddUserToolStripMenuItem.Text = "Add User"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BackupToolStripMenuItem, Me.RestoreToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.MenuToolStripMenuItem.Text = "Menu"
        '
        'BackupToolStripMenuItem
        '
        Me.BackupToolStripMenuItem.Name = "BackupToolStripMenuItem"
        Me.BackupToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.BackupToolStripMenuItem.Text = "Backup"
        '
        'RestoreToolStripMenuItem
        '
        Me.RestoreToolStripMenuItem.Name = "RestoreToolStripMenuItem"
        Me.RestoreToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.RestoreToolStripMenuItem.Text = "Restore"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(520, 162)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Role"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button1.Location = New System.Drawing.Point(523, 308)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 21
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(516, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Username"
        '
        'Password
        '
        Me.Password.AutoSize = True
        Me.Password.Location = New System.Drawing.Point(516, 106)
        Me.Password.Name = "Password"
        Me.Password.Size = New System.Drawing.Size(53, 13)
        Me.Password.TabIndex = 23
        Me.Password.Text = "Password"
        '
        'txtusername
        '
        Me.txtusername.Location = New System.Drawing.Point(585, 73)
        Me.txtusername.Name = "txtusername"
        Me.txtusername.Size = New System.Drawing.Size(100, 20)
        Me.txtusername.TabIndex = 24
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(585, 99)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(100, 20)
        Me.txtPassword.TabIndex = 25
        '
        'cmbStatus
        '
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"Authorized", "Unauthorized", "Pending"})
        Me.cmbStatus.Location = New System.Drawing.Point(585, 133)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(121, 21)
        Me.cmbStatus.TabIndex = 26
        '
        'cmbRole
        '
        Me.cmbRole.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.cmbRole.FormattingEnabled = True
        Me.cmbRole.Items.AddRange(New Object() {"Admin", "Staff"})
        Me.cmbRole.Location = New System.Drawing.Point(585, 162)
        Me.cmbRole.Name = "cmbRole"
        Me.cmbRole.Size = New System.Drawing.Size(121, 21)
        Me.cmbRole.TabIndex = 27
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(279, 368)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Idle Time: 00:00:00"
        '
        'AdminUserManagementForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(890, 478)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbRole)
        Me.Controls.Add(Me.cmbStatus)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtusername)
        Me.Controls.Add(Me.Password)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.DGVUserAdmin)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "AdminUserManagementForm"
        Me.Text = "Authorized"
        CType(Me.DGVUserAdmin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DGVUserAdmin As DataGridView
    Friend WithEvents lbl As Label
    Friend WithEvents btnUpdate As Button
    Friend WithEvents txtID As TextBox
    Friend WithEvents btnView As Button
    Friend WithEvents btnRemove As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MainToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Password As Label
    Friend WithEvents txtusername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents cmbStatus As ComboBox
    Friend WithEvents cmbRole As ComboBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label5 As Label
    Friend WithEvents MenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BackupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RestoreToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UserDatabaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddUserToolStripMenuItem As ToolStripMenuItem
End Class
