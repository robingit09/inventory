﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LedgerReports
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
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.cbLedgerType = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbpayment_mode = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbYear = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbMonth = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbCustomer = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(266, 201)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(106, 23)
        Me.btnPrint.TabIndex = 26
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'cbLedgerType
        '
        Me.cbLedgerType.FormattingEnabled = True
        Me.cbLedgerType.Location = New System.Drawing.Point(110, 98)
        Me.cbLedgerType.Name = "cbLedgerType"
        Me.cbLedgerType.Size = New System.Drawing.Size(262, 21)
        Me.cbLedgerType.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Ledger Type:"
        '
        'cbpayment_mode
        '
        Me.cbpayment_mode.FormattingEnabled = True
        Me.cbpayment_mode.Location = New System.Drawing.Point(110, 66)
        Me.cbpayment_mode.Name = "cbpayment_mode"
        Me.cbpayment_mode.Size = New System.Drawing.Size(262, 21)
        Me.cbpayment_mode.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Payment Type:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(222, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "By Year:"
        '
        'cbYear
        '
        Me.cbYear.FormattingEnabled = True
        Me.cbYear.Location = New System.Drawing.Point(275, 132)
        Me.cbYear.Name = "cbYear"
        Me.cbYear.Size = New System.Drawing.Size(97, 21)
        Me.cbYear.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "By Month:"
        '
        'cbMonth
        '
        Me.cbMonth.FormattingEnabled = True
        Me.cbMonth.Location = New System.Drawing.Point(110, 132)
        Me.cbMonth.Name = "cbMonth"
        Me.cbMonth.Size = New System.Drawing.Size(97, 21)
        Me.cbMonth.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Customer"
        '
        'cbCustomer
        '
        Me.cbCustomer.FormattingEnabled = True
        Me.cbCustomer.Location = New System.Drawing.Point(110, 33)
        Me.cbCustomer.Name = "cbCustomer"
        Me.cbCustomer.Size = New System.Drawing.Size(262, 21)
        Me.cbCustomer.TabIndex = 15
        '
        'LedgerReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(403, 279)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.cbLedgerType)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbpayment_mode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbYear)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbMonth)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbCustomer)
        Me.Name = "LedgerReports"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ledger Reports"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnPrint As Button
    Friend WithEvents cbLedgerType As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cbpayment_mode As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cbYear As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbMonth As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbCustomer As ComboBox
End Class
