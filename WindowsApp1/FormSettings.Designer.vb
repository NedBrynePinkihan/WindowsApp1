<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSettings
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
        Me.DGV_AuditLogs = New System.Windows.Forms.DataGridView()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.txtUserFilter = New System.Windows.Forms.TextBox()
        Me.txtTimeFilter = New System.Windows.Forms.TextBox()
        Me.btnRefreshLogs = New System.Windows.Forms.Button()
        Me.btnBackup = New System.Windows.Forms.Button()
        Me.btnRestore = New System.Windows.Forms.Button()
        CType(Me.DGV_AuditLogs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_AuditLogs
        '
        Me.DGV_AuditLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_AuditLogs.Location = New System.Drawing.Point(91, 41)
        Me.DGV_AuditLogs.Name = "DGV_AuditLogs"
        Me.DGV_AuditLogs.Size = New System.Drawing.Size(240, 150)
        Me.DGV_AuditLogs.TabIndex = 0
        '
        'btnFilter
        '
        Me.btnFilter.Location = New System.Drawing.Point(164, 246)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(75, 23)
        Me.btnFilter.TabIndex = 1
        Me.btnFilter.Text = "Filter"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'txtUserFilter
        '
        Me.txtUserFilter.Location = New System.Drawing.Point(164, 220)
        Me.txtUserFilter.Name = "txtUserFilter"
        Me.txtUserFilter.Size = New System.Drawing.Size(100, 20)
        Me.txtUserFilter.TabIndex = 2
        '
        'txtTimeFilter
        '
        Me.txtTimeFilter.Location = New System.Drawing.Point(338, 207)
        Me.txtTimeFilter.Name = "txtTimeFilter"
        Me.txtTimeFilter.Size = New System.Drawing.Size(100, 20)
        Me.txtTimeFilter.TabIndex = 3
        '
        'btnRefreshLogs
        '
        Me.btnRefreshLogs.Location = New System.Drawing.Point(215, 342)
        Me.btnRefreshLogs.Name = "btnRefreshLogs"
        Me.btnRefreshLogs.Size = New System.Drawing.Size(75, 23)
        Me.btnRefreshLogs.TabIndex = 4
        Me.btnRefreshLogs.Text = "Refresh"
        Me.btnRefreshLogs.UseVisualStyleBackColor = True
        '
        'btnBackup
        '
        Me.btnBackup.Location = New System.Drawing.Point(338, 342)
        Me.btnBackup.Name = "btnBackup"
        Me.btnBackup.Size = New System.Drawing.Size(75, 23)
        Me.btnBackup.TabIndex = 5
        Me.btnBackup.Text = "Backup"
        Me.btnBackup.UseVisualStyleBackColor = True
        '
        'btnRestore
        '
        Me.btnRestore.Location = New System.Drawing.Point(478, 342)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(75, 23)
        Me.btnRestore.TabIndex = 6
        Me.btnRestore.Text = "Restore"
        Me.btnRestore.UseVisualStyleBackColor = True
        '
        'FormSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnRestore)
        Me.Controls.Add(Me.btnBackup)
        Me.Controls.Add(Me.btnRefreshLogs)
        Me.Controls.Add(Me.txtTimeFilter)
        Me.Controls.Add(Me.txtUserFilter)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.DGV_AuditLogs)
        Me.Name = "FormSettings"
        Me.Text = "FormSettings"
        CType(Me.DGV_AuditLogs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DGV_AuditLogs As DataGridView
    Friend WithEvents btnFilter As Button
    Friend WithEvents txtUserFilter As TextBox
    Friend WithEvents txtTimeFilter As TextBox
    Friend WithEvents btnRefreshLogs As Button
    Friend WithEvents btnBackup As Button
    Friend WithEvents btnRestore As Button
End Class
