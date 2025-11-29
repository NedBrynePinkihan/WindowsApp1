<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LoginForm
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
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.chkShowPassword = New System.Windows.Forms.CheckBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Lcreate = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(282, 245)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Username"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(343, 242)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(145, 20)
        Me.txtUsername.TabIndex = 0
        Me.txtUsername.Text = "admin"
        '
        'chkShowPassword
        '
        Me.chkShowPassword.AutoSize = True
        Me.chkShowPassword.Location = New System.Drawing.Point(343, 298)
        Me.chkShowPassword.Name = "chkShowPassword"
        Me.chkShowPassword.Size = New System.Drawing.Size(102, 17)
        Me.chkShowPassword.TabIndex = 2
        Me.chkShowPassword.Text = "Show Password"
        Me.chkShowPassword.UseVisualStyleBackColor = True
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnLogin.Location = New System.Drawing.Point(343, 321)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(68, 23)
        Me.btnLogin.TabIndex = 2
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(282, 272)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(404, 226)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Login"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(343, 268)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(145, 20)
        Me.txtPassword.TabIndex = 1
        Me.txtPassword.Text = "Admin.1234"
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Red
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.ForeColor = System.Drawing.SystemColors.Control
        Me.btnExit.Location = New System.Drawing.Point(417, 321)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(71, 23)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'Lcreate
        '
        Me.Lcreate.AutoSize = True
        Me.Lcreate.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Lcreate.Location = New System.Drawing.Point(370, 347)
        Me.Lcreate.Name = "Lcreate"
        Me.Lcreate.Size = New System.Drawing.Size(84, 13)
        Me.Lcreate.TabIndex = 8
        Me.Lcreate.Text = "Create Account."
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.blue_mountain_layers_5k_2560x1440
        Me.ClientSize = New System.Drawing.Size(786, 509)
        Me.Controls.Add(Me.Lcreate)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.chkShowPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.Label1)
        Me.Name = "LoginForm"
        Me.Text = "Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents chkShowPassword As CheckBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnExit As Button
    Friend WithEvents Lcreate As Label
End Class
