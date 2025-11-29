<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddUserForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbRole = New System.Windows.Forms.ComboBox()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID"
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(86, 20)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(100, 20)
        Me.txtID.TabIndex = 1
        '
        'cmbStatus
        '
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"Authorized", "Pending", "Unauthorized"})
        Me.cmbStatus.Location = New System.Drawing.Point(86, 98)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(100, 21)
        Me.cmbStatus.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Username"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Password"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 101)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Status"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(86, 46)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(100, 20)
        Me.txtUsername.TabIndex = 7
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(86, 72)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(100, 20)
        Me.txtPassword.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Role"
        '
        'cmbRole
        '
        Me.cmbRole.FormattingEnabled = True
        Me.cmbRole.Items.AddRange(New Object() {"Staff", "Admin"})
        Me.cmbRole.Location = New System.Drawing.Point(86, 125)
        Me.cmbRole.Name = "cmbRole"
        Me.cmbRole.Size = New System.Drawing.Size(100, 21)
        Me.cmbRole.TabIndex = 10
        '
        'btnCreate
        '
        Me.btnCreate.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCreate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreate.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCreate.Location = New System.Drawing.Point(47, 169)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(67, 23)
        Me.btnCreate.TabIndex = 12
        Me.btnCreate.Text = "Create"
        Me.btnCreate.UseVisualStyleBackColor = False
        '
        'btnHome
        '
        Me.btnHome.BackColor = System.Drawing.Color.Red
        Me.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHome.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHome.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnHome.Location = New System.Drawing.Point(131, 169)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(55, 23)
        Me.btnHome.TabIndex = 15
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = False
        '
        'Form5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(239, 220)
        Me.Controls.Add(Me.btnHome)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.cmbRole)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbStatus)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form5"
        Me.Text = "User Profile"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtID As TextBox
    Friend WithEvents cmbStatus As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbRole As ComboBox
    Friend WithEvents btnCreate As Button
    Friend WithEvents btnHome As Button
End Class
