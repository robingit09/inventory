<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.testYes = New System.Windows.Forms.RadioButton()
        Me.testNo = New System.Windows.Forms.RadioButton()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.testNo)
        Me.GroupBox1.Controls.Add(Me.testYes)
        Me.GroupBox1.Location = New System.Drawing.Point(46, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(151, 68)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "For Testing"
        '
        'testYes
        '
        Me.testYes.AutoSize = True
        Me.testYes.Location = New System.Drawing.Point(21, 29)
        Me.testYes.Name = "testYes"
        Me.testYes.Size = New System.Drawing.Size(43, 17)
        Me.testYes.TabIndex = 0
        Me.testYes.TabStop = True
        Me.testYes.Text = "Yes"
        Me.testYes.UseVisualStyleBackColor = True
        '
        'testNo
        '
        Me.testNo.AutoSize = True
        Me.testNo.Location = New System.Drawing.Point(87, 29)
        Me.testNo.Name = "testNo"
        Me.testNo.Size = New System.Drawing.Size(39, 17)
        Me.testNo.TabIndex = 1
        Me.testNo.TabStop = True
        Me.testNo.Text = "No"
        Me.testNo.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(572, 12)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(97, 36)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(695, 404)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Settings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "System Settings"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents testNo As RadioButton
    Friend WithEvents testYes As RadioButton
    Friend WithEvents btnSave As Button
End Class
