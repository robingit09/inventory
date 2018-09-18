<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LedgerForm
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
        Me.rPaidNo = New System.Windows.Forms.RadioButton()
        Me.rPaidYes = New System.Windows.Forms.RadioButton()
        Me.cbDisable = New System.Windows.Forms.CheckBox()
        Me.btnAddCustomer = New System.Windows.Forms.Button()
        Me.dtpPaid = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.gpPaid = New System.Windows.Forms.GroupBox()
        Me.cbPaymentType = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.txtInvoiceNo = New System.Windows.Forms.TextBox()
        Me.txtCounterNo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpDateIssue = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbCustomer = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbTerms = New System.Windows.Forms.ComboBox()
        Me.gpCheck = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpCheckDate = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbFloatingYes = New System.Windows.Forms.RadioButton()
        Me.rbFloatingNo = New System.Windows.Forms.RadioButton()
        Me.txtBankDetails = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbLedgerType = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnSaveAndPrint = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnAddInvoice = New System.Windows.Forms.Button()
        Me.gpInvoiceList = New System.Windows.Forms.GroupBox()
        Me.invoice_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.date_invoice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amount_paid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.action = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.gpPaid.SuspendLayout()
        Me.gpCheck.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpInvoiceList.SuspendLayout()
        Me.SuspendLayout()
        '
        'rPaidNo
        '
        Me.rPaidNo.AutoSize = True
        Me.rPaidNo.Location = New System.Drawing.Point(88, 19)
        Me.rPaidNo.Name = "rPaidNo"
        Me.rPaidNo.Size = New System.Drawing.Size(39, 17)
        Me.rPaidNo.TabIndex = 1
        Me.rPaidNo.TabStop = True
        Me.rPaidNo.Text = "No"
        Me.rPaidNo.UseVisualStyleBackColor = True
        '
        'rPaidYes
        '
        Me.rPaidYes.AutoSize = True
        Me.rPaidYes.Location = New System.Drawing.Point(21, 19)
        Me.rPaidYes.Name = "rPaidYes"
        Me.rPaidYes.Size = New System.Drawing.Size(43, 17)
        Me.rPaidYes.TabIndex = 0
        Me.rPaidYes.TabStop = True
        Me.rPaidYes.Text = "Yes"
        Me.rPaidYes.UseVisualStyleBackColor = True
        '
        'cbDisable
        '
        Me.cbDisable.AutoSize = True
        Me.cbDisable.Location = New System.Drawing.Point(309, 106)
        Me.cbDisable.Name = "cbDisable"
        Me.cbDisable.Size = New System.Drawing.Size(61, 17)
        Me.cbDisable.TabIndex = 43
        Me.cbDisable.Text = "Disable"
        Me.cbDisable.UseVisualStyleBackColor = True
        '
        'btnAddCustomer
        '
        Me.btnAddCustomer.Location = New System.Drawing.Point(309, 29)
        Me.btnAddCustomer.Name = "btnAddCustomer"
        Me.btnAddCustomer.Size = New System.Drawing.Size(88, 23)
        Me.btnAddCustomer.TabIndex = 42
        Me.btnAddCustomer.Text = "Add Customer"
        Me.btnAddCustomer.UseVisualStyleBackColor = True
        '
        'dtpPaid
        '
        Me.dtpPaid.Location = New System.Drawing.Point(103, 314)
        Me.dtpPaid.Name = "dtpPaid"
        Me.dtpPaid.Size = New System.Drawing.Size(200, 20)
        Me.dtpPaid.TabIndex = 41
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 314)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "Date paid"
        '
        'gpPaid
        '
        Me.gpPaid.Controls.Add(Me.rPaidNo)
        Me.gpPaid.Controls.Add(Me.rPaidYes)
        Me.gpPaid.Location = New System.Drawing.Point(15, 250)
        Me.gpPaid.Name = "gpPaid"
        Me.gpPaid.Size = New System.Drawing.Size(154, 52)
        Me.gpPaid.TabIndex = 39
        Me.gpPaid.TabStop = False
        Me.gpPaid.Text = "Is paid ?"
        '
        'cbPaymentType
        '
        Me.cbPaymentType.FormattingEnabled = True
        Me.cbPaymentType.Location = New System.Drawing.Point(103, 213)
        Me.cbPaymentType.Name = "cbPaymentType"
        Me.cbPaymentType.Size = New System.Drawing.Size(200, 21)
        Me.cbPaymentType.TabIndex = 38
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 216)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 13)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "Payment Type"
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(103, 171)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(200, 20)
        Me.txtAmount.TabIndex = 36
        '
        'txtInvoiceNo
        '
        Me.txtInvoiceNo.Location = New System.Drawing.Point(103, 137)
        Me.txtInvoiceNo.MaxLength = 5
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.Size = New System.Drawing.Size(200, 20)
        Me.txtInvoiceNo.TabIndex = 35
        '
        'txtCounterNo
        '
        Me.txtCounterNo.Location = New System.Drawing.Point(103, 103)
        Me.txtCounterNo.MaxLength = 5
        Me.txtCounterNo.Name = "txtCounterNo"
        Me.txtCounterNo.Size = New System.Drawing.Size(200, 20)
        Me.txtCounterNo.TabIndex = 34
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 174)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Amount"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Invoice Number"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Counter No"
        '
        'dtpDateIssue
        '
        Me.dtpDateIssue.Location = New System.Drawing.Point(103, 65)
        Me.dtpDateIssue.Name = "dtpDateIssue"
        Me.dtpDateIssue.Size = New System.Drawing.Size(200, 20)
        Me.dtpDateIssue.TabIndex = 30
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Date Issue"
        '
        'cbCustomer
        '
        Me.cbCustomer.FormattingEnabled = True
        Me.cbCustomer.Location = New System.Drawing.Point(103, 31)
        Me.cbCustomer.Name = "cbCustomer"
        Me.cbCustomer.Size = New System.Drawing.Size(200, 21)
        Me.cbCustomer.TabIndex = 28
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Customer"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(410, 294)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 13)
        Me.Label11.TabIndex = 46
        Me.Label11.Text = "Terms"
        '
        'cbTerms
        '
        Me.cbTerms.FormattingEnabled = True
        Me.cbTerms.Location = New System.Drawing.Point(502, 291)
        Me.cbTerms.Name = "cbTerms"
        Me.cbTerms.Size = New System.Drawing.Size(200, 21)
        Me.cbTerms.TabIndex = 44
        '
        'gpCheck
        '
        Me.gpCheck.Controls.Add(Me.Label9)
        Me.gpCheck.Controls.Add(Me.dtpCheckDate)
        Me.gpCheck.Controls.Add(Me.GroupBox2)
        Me.gpCheck.Controls.Add(Me.txtBankDetails)
        Me.gpCheck.Controls.Add(Me.Label8)
        Me.gpCheck.Enabled = False
        Me.gpCheck.Location = New System.Drawing.Point(413, 27)
        Me.gpCheck.Name = "gpCheck"
        Me.gpCheck.Size = New System.Drawing.Size(289, 259)
        Me.gpCheck.TabIndex = 48
        Me.gpCheck.TabStop = False
        Me.gpCheck.Text = "Check"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 169)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Check date"
        '
        'dtpCheckDate
        '
        Me.dtpCheckDate.Location = New System.Drawing.Point(78, 169)
        Me.dtpCheckDate.Name = "dtpCheckDate"
        Me.dtpCheckDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpCheckDate.TabIndex = 19
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbFloatingYes)
        Me.GroupBox2.Controls.Add(Me.rbFloatingNo)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(9, 195)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(154, 52)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Is floating ?"
        '
        'rbFloatingYes
        '
        Me.rbFloatingYes.AutoSize = True
        Me.rbFloatingYes.Location = New System.Drawing.Point(20, 22)
        Me.rbFloatingYes.Name = "rbFloatingYes"
        Me.rbFloatingYes.Size = New System.Drawing.Size(43, 17)
        Me.rbFloatingYes.TabIndex = 1
        Me.rbFloatingYes.TabStop = True
        Me.rbFloatingYes.Text = "Yes"
        Me.rbFloatingYes.UseVisualStyleBackColor = True
        '
        'rbFloatingNo
        '
        Me.rbFloatingNo.AutoSize = True
        Me.rbFloatingNo.Location = New System.Drawing.Point(97, 22)
        Me.rbFloatingNo.Name = "rbFloatingNo"
        Me.rbFloatingNo.Size = New System.Drawing.Size(39, 17)
        Me.rbFloatingNo.TabIndex = 0
        Me.rbFloatingNo.TabStop = True
        Me.rbFloatingNo.Text = "No"
        Me.rbFloatingNo.UseVisualStyleBackColor = True
        '
        'txtBankDetails
        '
        Me.txtBankDetails.Location = New System.Drawing.Point(10, 37)
        Me.txtBankDetails.Multiline = True
        Me.txtBankDetails.Name = "txtBankDetails"
        Me.txtBankDetails.Size = New System.Drawing.Size(268, 114)
        Me.txtBankDetails.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Bank details"
        '
        'cbLedgerType
        '
        Me.cbLedgerType.Enabled = False
        Me.cbLedgerType.FormattingEnabled = True
        Me.cbLedgerType.Location = New System.Drawing.Point(502, 322)
        Me.cbLedgerType.Name = "cbLedgerType"
        Me.cbLedgerType.Size = New System.Drawing.Size(200, 21)
        Me.cbLedgerType.TabIndex = 47
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(410, 328)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 13)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = "Ledger Type"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(723, 51)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(268, 126)
        Me.txtRemarks.TabIndex = 50
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(720, 27)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 13)
        Me.Label12.TabIndex = 49
        Me.Label12.Text = "Remarks"
        '
        'btnSaveAndPrint
        '
        Me.btnSaveAndPrint.Location = New System.Drawing.Point(894, 310)
        Me.btnSaveAndPrint.Name = "btnSaveAndPrint"
        Me.btnSaveAndPrint.Size = New System.Drawing.Size(97, 37)
        Me.btnSaveAndPrint.TabIndex = 52
        Me.btnSaveAndPrint.Text = "Save and Print"
        Me.btnSaveAndPrint.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(894, 257)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(97, 37)
        Me.btnSave.TabIndex = 51
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.invoice_no, Me.date_invoice, Me.amount, Me.amount_paid, Me.action})
        Me.DataGridView1.Location = New System.Drawing.Point(6, 42)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(598, 131)
        Me.DataGridView1.TabIndex = 53
        '
        'btnAddInvoice
        '
        Me.btnAddInvoice.Location = New System.Drawing.Point(529, 13)
        Me.btnAddInvoice.Name = "btnAddInvoice"
        Me.btnAddInvoice.Size = New System.Drawing.Size(75, 23)
        Me.btnAddInvoice.TabIndex = 54
        Me.btnAddInvoice.Text = "Add +"
        Me.btnAddInvoice.UseVisualStyleBackColor = True
        '
        'gpInvoiceList
        '
        Me.gpInvoiceList.Controls.Add(Me.btnAddInvoice)
        Me.gpInvoiceList.Controls.Add(Me.DataGridView1)
        Me.gpInvoiceList.Location = New System.Drawing.Point(15, 368)
        Me.gpInvoiceList.Name = "gpInvoiceList"
        Me.gpInvoiceList.Size = New System.Drawing.Size(613, 191)
        Me.gpInvoiceList.TabIndex = 55
        Me.gpInvoiceList.TabStop = False
        Me.gpInvoiceList.Text = "Invoice List"
        '
        'invoice_no
        '
        Me.invoice_no.HeaderText = "Invoice No"
        Me.invoice_no.Name = "invoice_no"
        Me.invoice_no.ReadOnly = True
        '
        'date_invoice
        '
        Me.date_invoice.HeaderText = "Date Invoice"
        Me.date_invoice.Name = "date_invoice"
        Me.date_invoice.ReadOnly = True
        '
        'amount
        '
        Me.amount.HeaderText = "Amount"
        Me.amount.Name = "amount"
        Me.amount.ReadOnly = True
        '
        'amount_paid
        '
        Me.amount_paid.HeaderText = "Amount Paid"
        Me.amount_paid.Name = "amount_paid"
        Me.amount_paid.ReadOnly = True
        '
        'action
        '
        Me.action.HeaderText = "Action"
        Me.action.Name = "action"
        Me.action.ReadOnly = True
        Me.action.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.action.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'LedgerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 582)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btnSaveAndPrint)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cbTerms)
        Me.Controls.Add(Me.gpCheck)
        Me.Controls.Add(Me.cbLedgerType)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cbDisable)
        Me.Controls.Add(Me.btnAddCustomer)
        Me.Controls.Add(Me.dtpPaid)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.gpPaid)
        Me.Controls.Add(Me.cbPaymentType)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.txtInvoiceNo)
        Me.Controls.Add(Me.txtCounterNo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpDateIssue)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbCustomer)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gpInvoiceList)
        Me.Name = "LedgerForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ledger Form"
        Me.gpPaid.ResumeLayout(False)
        Me.gpPaid.PerformLayout()
        Me.gpCheck.ResumeLayout(False)
        Me.gpCheck.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpInvoiceList.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rPaidNo As RadioButton
    Friend WithEvents rPaidYes As RadioButton
    Friend WithEvents cbDisable As CheckBox
    Friend WithEvents btnAddCustomer As Button
    Friend WithEvents dtpPaid As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents gpPaid As GroupBox
    Friend WithEvents cbPaymentType As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents txtInvoiceNo As TextBox
    Friend WithEvents txtCounterNo As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpDateIssue As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents cbCustomer As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents cbTerms As ComboBox
    Friend WithEvents gpCheck As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents dtpCheckDate As DateTimePicker
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rbFloatingYes As RadioButton
    Friend WithEvents rbFloatingNo As RadioButton
    Friend WithEvents txtBankDetails As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cbLedgerType As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents btnSaveAndPrint As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnAddInvoice As Button
    Friend WithEvents gpInvoiceList As GroupBox
    Friend WithEvents invoice_no As DataGridViewTextBoxColumn
    Friend WithEvents date_invoice As DataGridViewTextBoxColumn
    Friend WithEvents amount As DataGridViewTextBoxColumn
    Friend WithEvents amount_paid As DataGridViewTextBoxColumn
    Friend WithEvents action As DataGridViewButtonColumn
End Class
