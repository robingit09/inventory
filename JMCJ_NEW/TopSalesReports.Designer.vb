﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TopSalesReports
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
        Me.gpFilter = New System.Windows.Forms.GroupBox()
        Me.cbYear = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbCustomer = New System.Windows.Forms.ComboBox()
        Me.cbMonth = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbPrintMethod = New System.Windows.Forms.ComboBox()
        Me.gpFilter.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(265, 189)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 3
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'gpFilter
        '
        Me.gpFilter.Controls.Add(Me.cbYear)
        Me.gpFilter.Controls.Add(Me.Label1)
        Me.gpFilter.Controls.Add(Me.Label3)
        Me.gpFilter.Controls.Add(Me.cbCustomer)
        Me.gpFilter.Controls.Add(Me.cbMonth)
        Me.gpFilter.Controls.Add(Me.Label2)
        Me.gpFilter.Location = New System.Drawing.Point(12, 23)
        Me.gpFilter.Name = "gpFilter"
        Me.gpFilter.Size = New System.Drawing.Size(328, 136)
        Me.gpFilter.TabIndex = 2
        Me.gpFilter.TabStop = False
        Me.gpFilter.Text = "Filter"
        '
        'cbYear
        '
        Me.cbYear.FormattingEnabled = True
        Me.cbYear.Location = New System.Drawing.Point(73, 81)
        Me.cbYear.Name = "cbYear"
        Me.cbYear.Size = New System.Drawing.Size(238, 21)
        Me.cbYear.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Customer"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Year:"
        '
        'cbCustomer
        '
        Me.cbCustomer.FormattingEnabled = True
        Me.cbCustomer.Location = New System.Drawing.Point(73, 25)
        Me.cbCustomer.Name = "cbCustomer"
        Me.cbCustomer.Size = New System.Drawing.Size(238, 21)
        Me.cbCustomer.TabIndex = 0
        '
        'cbMonth
        '
        Me.cbMonth.FormattingEnabled = True
        Me.cbMonth.Location = New System.Drawing.Point(73, 52)
        Me.cbMonth.Name = "cbMonth"
        Me.cbMonth.Size = New System.Drawing.Size(238, 21)
        Me.cbMonth.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Month:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 194)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Print Method:"
        '
        'cbPrintMethod
        '
        Me.cbPrintMethod.FormattingEnabled = True
        Me.cbPrintMethod.Location = New System.Drawing.Point(102, 191)
        Me.cbPrintMethod.Name = "cbPrintMethod"
        Me.cbPrintMethod.Size = New System.Drawing.Size(157, 21)
        Me.cbPrintMethod.TabIndex = 22
        '
        'TopSalesReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 241)
        Me.Controls.Add(Me.cbPrintMethod)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.gpFilter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "TopSalesReports"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Top Sales Reports"
        Me.gpFilter.ResumeLayout(False)
        Me.gpFilter.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnPrint As Button
    Friend WithEvents gpFilter As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbCustomer As ComboBox
    Friend WithEvents cbYear As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cbMonth As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cbPrintMethod As ComboBox
End Class
