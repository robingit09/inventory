﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TermNotification
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbRemaining = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbYear = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbMonth = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgvLedger = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remaining = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateIssue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Customer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvoiceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ledger = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsPaid = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.IsFloating = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PaymentType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BankDetails = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CounterNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Terms = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvLedger, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbRemaining)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.cbYear)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbMonth)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtCustomer)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnFilter)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.GroupBox1.Location = New System.Drawing.Point(12, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(744, 95)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter"
        '
        'cbRemaining
        '
        Me.cbRemaining.FormattingEnabled = True
        Me.cbRemaining.Location = New System.Drawing.Point(453, 63)
        Me.cbRemaining.Name = "cbRemaining"
        Me.cbRemaining.Size = New System.Drawing.Size(195, 21)
        Me.cbRemaining.TabIndex = 20
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(387, 66)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 13)
        Me.Label15.TabIndex = 21
        Me.Label15.Text = "Remaining:"
        '
        'cbYear
        '
        Me.cbYear.FormattingEnabled = True
        Me.cbYear.Location = New System.Drawing.Point(241, 61)
        Me.cbYear.Name = "cbYear"
        Me.cbYear.Size = New System.Drawing.Size(129, 21)
        Me.cbYear.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(203, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Year:"
        '
        'cbMonth
        '
        Me.cbMonth.FormattingEnabled = True
        Me.cbMonth.Location = New System.Drawing.Point(70, 61)
        Me.cbMonth.Name = "cbMonth"
        Me.cbMonth.Size = New System.Drawing.Size(129, 21)
        Me.cbMonth.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Month:"
        '
        'txtCustomer
        '
        Me.txtCustomer.Location = New System.Drawing.Point(70, 23)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.Size = New System.Drawing.Size(300, 20)
        Me.txtCustomer.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Customer:"
        '
        'btnFilter
        '
        Me.btnFilter.Location = New System.Drawing.Point(654, 61)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(75, 23)
        Me.btnFilter.TabIndex = 4
        Me.btnFilter.Text = "Filter"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(936, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(296, 25)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "C O L O R  W A R N I N G"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Red
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(1249, 65)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 13)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "Label4111"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(1249, 89)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 14)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Over Due"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Orange
        Me.Label11.ForeColor = System.Drawing.Color.Orange
        Me.Label11.Location = New System.Drawing.Point(1141, 65)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 13)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Label4111"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Yellow
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(1035, 65)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 13)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Label4111"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(1141, 89)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 14)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Due Date"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(1034, 89)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 14)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "3 Days"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(931, 89)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 14)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "5 Days"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Blue
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(932, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Label4111"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(819, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 14)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "7 Days"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.LimeGreen
        Me.Label4.ForeColor = System.Drawing.Color.LimeGreen
        Me.Label4.Location = New System.Drawing.Point(820, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Label4111"
        '
        'dgvLedger
        '
        Me.dgvLedger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLedger.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Remaining, Me.DateIssue, Me.Customer, Me.InvoiceNo, Me.Ledger, Me.Amount, Me.IsPaid, Me.IsFloating, Me.PaymentType, Me.BankDetails, Me.CheckDate, Me.CounterNo, Me.Terms, Me.Status})
        Me.dgvLedger.Location = New System.Drawing.Point(12, 123)
        Me.dgvLedger.Name = "dgvLedger"
        Me.dgvLedger.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLedger.Size = New System.Drawing.Size(1355, 377)
        Me.dgvLedger.TabIndex = 29
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Width = 5
        '
        'Remaining
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Remaining.DefaultCellStyle = DataGridViewCellStyle1
        Me.Remaining.HeaderText = "Remaining"
        Me.Remaining.Name = "Remaining"
        Me.Remaining.ReadOnly = True
        '
        'DateIssue
        '
        Me.DateIssue.HeaderText = "Date Invoice"
        Me.DateIssue.Name = "DateIssue"
        Me.DateIssue.ReadOnly = True
        '
        'Customer
        '
        Me.Customer.HeaderText = "Customer"
        Me.Customer.Name = "Customer"
        Me.Customer.ReadOnly = True
        '
        'InvoiceNo
        '
        Me.InvoiceNo.HeaderText = "Invoice No"
        Me.InvoiceNo.Name = "InvoiceNo"
        Me.InvoiceNo.ReadOnly = True
        '
        'Ledger
        '
        Me.Ledger.HeaderText = "Ledger Type"
        Me.Ledger.Name = "Ledger"
        Me.Ledger.ReadOnly = True
        '
        'Amount
        '
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        Me.Amount.ReadOnly = True
        '
        'IsPaid
        '
        Me.IsPaid.HeaderText = "Is Paid?"
        Me.IsPaid.Name = "IsPaid"
        Me.IsPaid.ReadOnly = True
        '
        'IsFloating
        '
        Me.IsFloating.HeaderText = "Is Floating?"
        Me.IsFloating.Name = "IsFloating"
        Me.IsFloating.ReadOnly = True
        '
        'PaymentType
        '
        Me.PaymentType.HeaderText = "Payment Type"
        Me.PaymentType.Name = "PaymentType"
        Me.PaymentType.ReadOnly = True
        Me.PaymentType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PaymentType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'BankDetails
        '
        Me.BankDetails.HeaderText = "Bank Details"
        Me.BankDetails.Name = "BankDetails"
        Me.BankDetails.ReadOnly = True
        '
        'CheckDate
        '
        Me.CheckDate.HeaderText = "Check Date"
        Me.CheckDate.Name = "CheckDate"
        Me.CheckDate.ReadOnly = True
        '
        'CounterNo
        '
        Me.CounterNo.HeaderText = "Counter No"
        Me.CounterNo.Name = "CounterNo"
        Me.CounterNo.ReadOnly = True
        '
        'Terms
        '
        Me.Terms.HeaderText = "Terms"
        Me.Terms.Name = "Terms"
        Me.Terms.ReadOnly = True
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(100, 26)
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(99, 22)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'TermNotification
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1370, 557)
        Me.Controls.Add(Me.dgvLedger)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "TermNotification"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Term Notification"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvLedger, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cbRemaining As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents cbYear As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cbMonth As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCustomer As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnFilter As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dgvLedger As DataGridView
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents Remaining As DataGridViewTextBoxColumn
    Friend WithEvents DateIssue As DataGridViewTextBoxColumn
    Friend WithEvents Customer As DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNo As DataGridViewTextBoxColumn
    Friend WithEvents Ledger As DataGridViewTextBoxColumn
    Friend WithEvents Amount As DataGridViewTextBoxColumn
    Friend WithEvents IsPaid As DataGridViewCheckBoxColumn
    Friend WithEvents IsFloating As DataGridViewCheckBoxColumn
    Friend WithEvents PaymentType As DataGridViewTextBoxColumn
    Friend WithEvents BankDetails As DataGridViewTextBoxColumn
    Friend WithEvents CheckDate As DataGridViewTextBoxColumn
    Friend WithEvents CounterNo As DataGridViewTextBoxColumn
    Friend WithEvents Terms As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
End Class
