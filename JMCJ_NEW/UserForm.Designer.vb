<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserForm
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
        Me.txtFN = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLN = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbPosition = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.txtPW = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtCPW = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtContactNo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtInCaseOfEmergency = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtFN
        '
        Me.txtFN.Location = New System.Drawing.Point(79, 70)
        Me.txtFN.Name = "txtFN"
        Me.txtFN.Size = New System.Drawing.Size(201, 20)
        Me.txtFN.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "First Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(287, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Last Name:"
        '
        'txtLN
        '
        Me.txtLN.Location = New System.Drawing.Point(354, 70)
        Me.txtLN.Name = "txtLN"
        Me.txtLN.Size = New System.Drawing.Size(201, 20)
        Me.txtLN.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(561, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Position:"
        '
        'cbPosition
        '
        Me.cbPosition.FormattingEnabled = True
        Me.cbPosition.Location = New System.Drawing.Point(691, 70)
        Me.cbPosition.Name = "cbPosition"
        Me.cbPosition.Size = New System.Drawing.Size(205, 21)
        Me.cbPosition.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Username:"
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(79, 110)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(201, 20)
        Me.txtUser.TabIndex = 7
        '
        'txtPW
        '
        Me.txtPW.Location = New System.Drawing.Point(354, 110)
        Me.txtPW.Name = "txtPW"
        Me.txtPW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPW.Size = New System.Drawing.Size(201, 20)
        Me.txtPW.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(287, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Password:"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(821, 22)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(89, 29)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtCPW
        '
        Me.txtCPW.Location = New System.Drawing.Point(691, 110)
        Me.txtCPW.Name = "txtCPW"
        Me.txtCPW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCPW.Size = New System.Drawing.Size(205, 20)
        Me.txtCPW.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(561, 113)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Confirm Password:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 31)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Address:"
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(79, 178)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(201, 20)
        Me.txtAddress.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(287, 181)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Contact Number:"
        '
        'txtContactNo
        '
        Me.txtContactNo.Location = New System.Drawing.Point(380, 178)
        Me.txtContactNo.Name = "txtContactNo"
        Me.txtContactNo.Size = New System.Drawing.Size(175, 20)
        Me.txtContactNo.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(561, 181)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(116, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "In Case Of Emergency:"
        '
        'txtInCaseOfEmergency
        '
        Me.txtInCaseOfEmergency.Location = New System.Drawing.Point(691, 178)
        Me.txtInCaseOfEmergency.Name = "txtInCaseOfEmergency"
        Me.txtInCaseOfEmergency.Size = New System.Drawing.Size(205, 20)
        Me.txtInCaseOfEmergency.TabIndex = 18
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 150)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(898, 73)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Other Information"
        '
        'UserForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(922, 251)
        Me.Controls.Add(Me.txtInCaseOfEmergency)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtContactNo)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.txtCPW)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtPW)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbPosition)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtLN)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFN)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "UserForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Form"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtFN As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtLN As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cbPosition As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtUser As TextBox
    Friend WithEvents txtPW As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents txtCPW As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtContactNo As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtInCaseOfEmergency As TextBox
    Friend WithEvents GroupBox1 As GroupBox
End Class
