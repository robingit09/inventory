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
        Me.testNo = New System.Windows.Forms.RadioButton()
        Me.testYes = New System.Windows.Forms.RadioButton()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnTruncate = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.testNo)
        Me.GroupBox1.Controls.Add(Me.testYes)
        Me.GroupBox1.Location = New System.Drawing.Point(33, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(151, 68)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Test Mode"
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
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(800, 12)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(97, 36)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnTruncate)
        Me.GroupBox2.Location = New System.Drawing.Point(244, 60)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(258, 68)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Truncate Database"
        '
        'btnTruncate
        '
        Me.btnTruncate.Location = New System.Drawing.Point(177, 39)
        Me.btnTruncate.Name = "btnTruncate"
        Me.btnTruncate.Size = New System.Drawing.Size(75, 23)
        Me.btnTruncate.TabIndex = 0
        Me.btnTruncate.Text = "TRUNCATE"
        Me.btnTruncate.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(909, 404)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Settings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "System Settings"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents testNo As RadioButton
    Friend WithEvents testYes As RadioButton
    Friend WithEvents btnSave As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnTruncate As Button
End Class
