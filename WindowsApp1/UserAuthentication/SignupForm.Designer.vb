<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SignupForm
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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.btnRegister = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtCPassword = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbl8minChar = New System.Windows.Forms.Label()
        Me.lblNumber = New System.Windows.Forms.Label()
        Me.lblSpecialchar = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Location = New System.Drawing.Point(139, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(86, 13)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Regisration Form"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Username"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(110, 40)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(156, 20)
        Me.txtUsername.TabIndex = 2
        '
        'btnRegister
        '
        Me.btnRegister.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRegister.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.btnRegister.Location = New System.Drawing.Point(110, 210)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.Size = New System.Drawing.Size(75, 23)
        Me.btnRegister.TabIndex = 3
        Me.btnRegister.Text = "Register"
        Me.btnRegister.UseVisualStyleBackColor = False
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(110, 69)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(156, 20)
        Me.txtPassword.TabIndex = 4
        '
        'txtCPassword
        '
        Me.txtCPassword.Location = New System.Drawing.Point(110, 95)
        Me.txtCPassword.Name = "txtCPassword"
        Me.txtCPassword.Size = New System.Drawing.Size(156, 20)
        Me.txtCPassword.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Password"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Confirm Password"
        '
        'lbl8minChar
        '
        Me.lbl8minChar.AutoSize = True
        Me.lbl8minChar.Location = New System.Drawing.Point(107, 132)
        Me.lbl8minChar.Name = "lbl8minChar"
        Me.lbl8minChar.Size = New System.Drawing.Size(105, 13)
        Me.lbl8minChar.TabIndex = 8
        Me.lbl8minChar.Text = "At least 8 Characters"
        '
        'lblNumber
        '
        Me.lblNumber.AutoSize = True
        Me.lblNumber.Location = New System.Drawing.Point(107, 158)
        Me.lblNumber.Name = "lblNumber"
        Me.lblNumber.Size = New System.Drawing.Size(89, 13)
        Me.lblNumber.TabIndex = 9
        Me.lblNumber.Text = "At least 1 number"
        '
        'lblSpecialchar
        '
        Me.lblSpecialchar.AutoSize = True
        Me.lblSpecialchar.Location = New System.Drawing.Point(107, 184)
        Me.lblSpecialchar.Name = "lblSpecialchar"
        Me.lblSpecialchar.Size = New System.Drawing.Size(135, 13)
        Me.lblSpecialchar.TabIndex = 10
        Me.lblSpecialchar.Text = "At least 1 special character"
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Red
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBack.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnBack.Location = New System.Drawing.Point(191, 210)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 23)
        Me.btnBack.TabIndex = 11
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'SignupForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(288, 248)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.lblSpecialchar)
        Me.Controls.Add(Me.lblNumber)
        Me.Controls.Add(Me.lbl8minChar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCPassword)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.btnRegister)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblTitle)
        Me.Name = "SignupForm"
        Me.Text = "Register"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents btnRegister As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtCPassword As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lbl8minChar As Label
    Friend WithEvents lblNumber As Label
    Friend WithEvents lblSpecialchar As Label
    Friend WithEvents btnBack As Button
End Class
