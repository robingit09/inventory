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
        Me.rbFloatingNo = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpCheckDate = New System.Windows.Forms.DateTimePicker()
        Me.txtBankDetails = New System.Windows.Forms.TextBox()
        Me.rPaidNo = New System.Windows.Forms.RadioButton()
        Me.rPaidYes = New System.Windows.Forms.RadioButton()
        Me.rbFloatingYes = New System.Windows.Forms.RadioButton()
        Me.cbDisable = New System.Windows.Forms.CheckBox()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cbTerms = New System.Windows.Forms.ComboBox()
        Me.btnAddCustomer = New System.Windows.Forms.Button()
        Me.btnSaveAndPrint = New System.Windows.Forms.Button()
        Me.gpCheck = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cbLedgerType = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
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
        Me.dgvProd = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Barcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.product = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.brand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.less = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.add_less = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.sell_price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.action = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.gpCheck.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gpPaid.SuspendLayout()
        CType(Me.dgvProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'txtBankDetails
        '
        Me.txtBankDetails.Location = New System.Drawing.Point(10, 37)
        Me.txtBankDetails.Multiline = True
        Me.txtBankDetails.Name = "txtBankDetails"
        Me.txtBankDetails.Size = New System.Drawing.Size(268, 114)
        Me.txtBankDetails.TabIndex = 17
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
        'cbDisable
        '
        Me.cbDisable.AutoSize = True
        Me.cbDisable.Location = New System.Drawing.Point(330, 95)
        Me.cbDisable.Name = "cbDisable"
        Me.cbDisable.Size = New System.Drawing.Size(61, 17)
        Me.cbDisable.TabIndex = 52
        Me.cbDisable.Text = "Disable"
        Me.cbDisable.UseVisualStyleBackColor = True
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(756, 42)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(215, 120)
        Me.txtRemarks.TabIndex = 47
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(439, 278)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 13)
        Me.Label11.TabIndex = 46
        Me.Label11.Text = "Terms"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(753, 18)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 13)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "Remarks"
        '
        'cbTerms
        '
        Me.cbTerms.FormattingEnabled = True
        Me.cbTerms.Location = New System.Drawing.Point(531, 275)
        Me.cbTerms.Name = "cbTerms"
        Me.cbTerms.Size = New System.Drawing.Size(200, 21)
        Me.cbTerms.TabIndex = 43
        '
        'btnAddCustomer
        '
        Me.btnAddCustomer.Location = New System.Drawing.Point(330, 18)
        Me.btnAddCustomer.Name = "btnAddCustomer"
        Me.btnAddCustomer.Size = New System.Drawing.Size(88, 23)
        Me.btnAddCustomer.TabIndex = 51
        Me.btnAddCustomer.Text = "Add Customer"
        Me.btnAddCustomer.UseVisualStyleBackColor = True
        '
        'btnSaveAndPrint
        '
        Me.btnSaveAndPrint.Location = New System.Drawing.Point(1005, 71)
        Me.btnSaveAndPrint.Name = "btnSaveAndPrint"
        Me.btnSaveAndPrint.Size = New System.Drawing.Size(97, 37)
        Me.btnSaveAndPrint.TabIndex = 50
        Me.btnSaveAndPrint.Text = "Save and Print"
        Me.btnSaveAndPrint.UseVisualStyleBackColor = True
        '
        'gpCheck
        '
        Me.gpCheck.Controls.Add(Me.Label9)
        Me.gpCheck.Controls.Add(Me.dtpCheckDate)
        Me.gpCheck.Controls.Add(Me.GroupBox2)
        Me.gpCheck.Controls.Add(Me.txtBankDetails)
        Me.gpCheck.Controls.Add(Me.Label8)
        Me.gpCheck.Enabled = False
        Me.gpCheck.Location = New System.Drawing.Point(442, 11)
        Me.gpCheck.Name = "gpCheck"
        Me.gpCheck.Size = New System.Drawing.Size(289, 259)
        Me.gpCheck.TabIndex = 49
        Me.gpCheck.TabStop = False
        Me.gpCheck.Text = "Check"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbFloatingYes)
        Me.GroupBox2.Controls.Add(Me.rbFloatingNo)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 195)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(154, 52)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Is floating ?"
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
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(1005, 20)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(97, 37)
        Me.btnSave.TabIndex = 48
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cbLedgerType
        '
        Me.cbLedgerType.FormattingEnabled = True
        Me.cbLedgerType.Location = New System.Drawing.Point(531, 306)
        Me.cbLedgerType.Name = "cbLedgerType"
        Me.cbLedgerType.Size = New System.Drawing.Size(200, 21)
        Me.cbLedgerType.TabIndex = 45
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(439, 312)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 13)
        Me.Label10.TabIndex = 42
        Me.Label10.Text = "Ledger Type"
        '
        'dtpPaid
        '
        Me.dtpPaid.Location = New System.Drawing.Point(124, 303)
        Me.dtpPaid.Name = "dtpPaid"
        Me.dtpPaid.Size = New System.Drawing.Size(200, 20)
        Me.dtpPaid.TabIndex = 41
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(33, 303)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "Date paid"
        '
        'gpPaid
        '
        Me.gpPaid.Controls.Add(Me.rPaidNo)
        Me.gpPaid.Controls.Add(Me.rPaidYes)
        Me.gpPaid.Location = New System.Drawing.Point(36, 239)
        Me.gpPaid.Name = "gpPaid"
        Me.gpPaid.Size = New System.Drawing.Size(154, 52)
        Me.gpPaid.TabIndex = 39
        Me.gpPaid.TabStop = False
        Me.gpPaid.Text = "Is paid ?"
        '
        'cbPaymentType
        '
        Me.cbPaymentType.FormattingEnabled = True
        Me.cbPaymentType.Location = New System.Drawing.Point(124, 202)
        Me.cbPaymentType.Name = "cbPaymentType"
        Me.cbPaymentType.Size = New System.Drawing.Size(200, 21)
        Me.cbPaymentType.TabIndex = 38
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(33, 205)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 13)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "Payment Type"
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(124, 160)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(200, 20)
        Me.txtAmount.TabIndex = 36
        '
        'txtInvoiceNo
        '
        Me.txtInvoiceNo.Location = New System.Drawing.Point(124, 126)
        Me.txtInvoiceNo.MaxLength = 5
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.Size = New System.Drawing.Size(200, 20)
        Me.txtInvoiceNo.TabIndex = 35
        '
        'txtCounterNo
        '
        Me.txtCounterNo.Location = New System.Drawing.Point(124, 92)
        Me.txtCounterNo.MaxLength = 5
        Me.txtCounterNo.Name = "txtCounterNo"
        Me.txtCounterNo.Size = New System.Drawing.Size(200, 20)
        Me.txtCounterNo.TabIndex = 34
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(33, 163)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Amount"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(33, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Invoice Number"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Counter No"
        '
        'dtpDateIssue
        '
        Me.dtpDateIssue.Location = New System.Drawing.Point(124, 54)
        Me.dtpDateIssue.Name = "dtpDateIssue"
        Me.dtpDateIssue.Size = New System.Drawing.Size(200, 20)
        Me.dtpDateIssue.TabIndex = 30
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Date Issue"
        '
        'cbCustomer
        '
        Me.cbCustomer.FormattingEnabled = True
        Me.cbCustomer.Location = New System.Drawing.Point(124, 20)
        Me.cbCustomer.Name = "cbCustomer"
        Me.cbCustomer.Size = New System.Drawing.Size(200, 21)
        Me.cbCustomer.TabIndex = 28
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Customer"
        '
        'dgvProd
        '
        Me.dgvProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.Barcode, Me.quantity, Me.product, Me.brand, Me.unit, Me.price, Me.less, Me.add_less, Me.Column2, Me.sell_price, Me.amount, Me.stock, Me.action})
        Me.dgvProd.Location = New System.Drawing.Point(12, 355)
        Me.dgvProd.Name = "dgvProd"
        Me.dgvProd.Size = New System.Drawing.Size(1347, 271)
        Me.dgvProd.TabIndex = 53
        '
        'id
        '
        Me.id.HeaderText = "ID"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 5
        '
        'Barcode
        '
        Me.Barcode.HeaderText = "Barcode"
        Me.Barcode.Name = "Barcode"
        Me.Barcode.ReadOnly = True
        '
        'quantity
        '
        Me.quantity.HeaderText = "Quantity"
        Me.quantity.Name = "quantity"
        '
        'product
        '
        Me.product.HeaderText = "Product Description"
        Me.product.Name = "product"
        Me.product.ReadOnly = True
        Me.product.Width = 150
        '
        'brand
        '
        Me.brand.HeaderText = "Brand"
        Me.brand.Name = "brand"
        Me.brand.ReadOnly = True
        '
        'unit
        '
        Me.unit.HeaderText = "Unit"
        Me.unit.Name = "unit"
        Me.unit.ReadOnly = True
        '
        'price
        '
        Me.price.HeaderText = "Unit Price"
        Me.price.Name = "price"
        Me.price.ReadOnly = True
        '
        'less
        '
        Me.less.HeaderText = "Less"
        Me.less.Name = "less"
        Me.less.ReadOnly = True
        '
        'add_less
        '
        Me.add_less.HeaderText = "Add less"
        Me.add_less.Name = "add_less"
        Me.add_less.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.add_less.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.add_less.Text = "ADD"
        Me.add_less.Width = 70
        '
        'Column2
        '
        Me.Column2.HeaderText = "Set less to 0"
        Me.Column2.Name = "Column2"
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column2.Width = 80
        '
        'sell_price
        '
        Me.sell_price.HeaderText = "Sell Price"
        Me.sell_price.Name = "sell_price"
        Me.sell_price.ReadOnly = True
        '
        'amount
        '
        Me.amount.HeaderText = "Amount"
        Me.amount.Name = "amount"
        Me.amount.ReadOnly = True
        '
        'stock
        '
        Me.stock.HeaderText = "Stock"
        Me.stock.Name = "stock"
        Me.stock.ReadOnly = True
        '
        'action
        '
        Me.action.HeaderText = "Action"
        Me.action.Name = "action"
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.AutoSize = True
        Me.lblTotalAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAmount.ForeColor = System.Drawing.Color.Red
        Me.lblTotalAmount.Location = New System.Drawing.Point(931, 258)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(88, 39)
        Me.lblTotalAmount.TabIndex = 55
        Me.lblTotalAmount.Text = "0.00"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(805, 265)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(120, 22)
        Me.Label13.TabIndex = 54
        Me.Label13.Text = "Total Amount"
        '
        'LedgerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1114, 543)
        Me.Controls.Add(Me.lblTotalAmount)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.dgvProd)
        Me.Controls.Add(Me.cbDisable)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cbTerms)
        Me.Controls.Add(Me.btnAddCustomer)
        Me.Controls.Add(Me.btnSaveAndPrint)
        Me.Controls.Add(Me.gpCheck)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.cbLedgerType)
        Me.Controls.Add(Me.Label10)
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
        Me.Name = "LedgerForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ledger Form"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gpCheck.ResumeLayout(False)
        Me.gpCheck.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gpPaid.ResumeLayout(False)
        Me.gpPaid.PerformLayout()
        CType(Me.dgvProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rbFloatingNo As RadioButton
    Friend WithEvents Label9 As Label
    Friend WithEvents dtpCheckDate As DateTimePicker
    Friend WithEvents txtBankDetails As TextBox
    Friend WithEvents rPaidNo As RadioButton
    Friend WithEvents rPaidYes As RadioButton
    Friend WithEvents rbFloatingYes As RadioButton
    Friend WithEvents cbDisable As CheckBox
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents cbTerms As ComboBox
    Friend WithEvents btnAddCustomer As Button
    Friend WithEvents btnSaveAndPrint As Button
    Friend WithEvents gpCheck As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents cbLedgerType As ComboBox
    Friend WithEvents Label10 As Label
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
    Friend WithEvents dgvProd As DataGridView
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents Barcode As DataGridViewTextBoxColumn
    Friend WithEvents quantity As DataGridViewTextBoxColumn
    Friend WithEvents product As DataGridViewTextBoxColumn
    Friend WithEvents brand As DataGridViewTextBoxColumn
    Friend WithEvents unit As DataGridViewTextBoxColumn
    Friend WithEvents price As DataGridViewTextBoxColumn
    Friend WithEvents less As DataGridViewTextBoxColumn
    Friend WithEvents add_less As DataGridViewButtonColumn
    Friend WithEvents Column2 As DataGridViewButtonColumn
    Friend WithEvents sell_price As DataGridViewTextBoxColumn
    Friend WithEvents amount As DataGridViewTextBoxColumn
    Friend WithEvents stock As DataGridViewTextBoxColumn
    Friend WithEvents action As DataGridViewButtonColumn
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents Label13 As Label
End Class
