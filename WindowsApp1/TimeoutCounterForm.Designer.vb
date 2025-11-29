<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TimeoutCounterForm
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
        Me.lblTimeoutTimer = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblTimeoutTimer
        '
        Me.lblTimeoutTimer.AutoSize = True
        Me.lblTimeoutTimer.Location = New System.Drawing.Point(42, 40)
        Me.lblTimeoutTimer.Name = "lblTimeoutTimer"
        Me.lblTimeoutTimer.Size = New System.Drawing.Size(39, 13)
        Me.lblTimeoutTimer.TabIndex = 0
        Me.lblTimeoutTimer.Text = "Label1"
        '
        'TimeoutCounterForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(295, 98)
        Me.Controls.Add(Me.lblTimeoutTimer)
        Me.Name = "TimeoutCounterForm"
        Me.Text = "TimeoutCounterForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTimeoutTimer As Label
End Class
