<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerOrderForm
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
        Me.cbCustomer = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbProducts = New System.Windows.Forms.ComboBox()
        Me.btnAddProd = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbCat = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.btnSaveAndPrint = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbTermPayment = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpDateIssue = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDeliveredBy = New System.Windows.Forms.TextBox()
        Me.txtReceivedBy = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbPaymentType = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbSubcat = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbBrand = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cbUnit = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        CType(Me.dgvProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbCustomer
        '
        Me.cbCustomer.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustomer.FormattingEnabled = True
        Me.cbCustomer.Location = New System.Drawing.Point(137, 44)
        Me.cbCustomer.Name = "cbCustomer"
        Me.cbCustomer.Size = New System.Drawing.Size(514, 23)
        Me.cbCustomer.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Customer"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 121)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Product Description"
        '
        'cbProducts
        '
        Me.cbProducts.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProducts.FormattingEnabled = True
        Me.cbProducts.Location = New System.Drawing.Point(137, 118)
        Me.cbProducts.Name = "cbProducts"
        Me.cbProducts.Size = New System.Drawing.Size(199, 23)
        Me.cbProducts.TabIndex = 3
        '
        'btnAddProd
        '
        Me.btnAddProd.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddProd.Location = New System.Drawing.Point(740, 78)
        Me.btnAddProd.Name = "btnAddProd"
        Me.btnAddProd.Size = New System.Drawing.Size(133, 63)
        Me.btnAddProd.TabIndex = 5
        Me.btnAddProd.Text = "Add to Cart"
        Me.btnAddProd.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 15)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Category"
        '
        'cbCat
        '
        Me.cbCat.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCat.FormattingEnabled = True
        Me.cbCat.Location = New System.Drawing.Point(137, 78)
        Me.cbCat.Name = "cbCat"
        Me.cbCat.Size = New System.Drawing.Size(199, 23)
        Me.cbCat.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(723, 545)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 22)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Total Amount"
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.AutoSize = True
        Me.lblTotalAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAmount.ForeColor = System.Drawing.Color.Red
        Me.lblTotalAmount.Location = New System.Drawing.Point(849, 532)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(88, 39)
        Me.lblTotalAmount.TabIndex = 10
        Me.lblTotalAmount.Text = "0.00"
        '
        'btnSaveAndPrint
        '
        Me.btnSaveAndPrint.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveAndPrint.Location = New System.Drawing.Point(1231, 527)
        Me.btnSaveAndPrint.Name = "btnSaveAndPrint"
        Me.btnSaveAndPrint.Size = New System.Drawing.Size(127, 62)
        Me.btnSaveAndPrint.TabIndex = 12
        Me.btnSaveAndPrint.Text = "Save and Print"
        Me.btnSaveAndPrint.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 527)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(158, 22)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Terms of Payment"
        '
        'cbTermPayment
        '
        Me.cbTermPayment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTermPayment.FormattingEnabled = True
        Me.cbTermPayment.Items.AddRange(New Object() {"30 days", "60 days", "90 days", "120 days"})
        Me.cbTermPayment.Location = New System.Drawing.Point(210, 525)
        Me.cbTermPayment.Name = "cbTermPayment"
        Me.cbTermPayment.Size = New System.Drawing.Size(291, 28)
        Me.cbTermPayment.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 15)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Date Invoice"
        '
        'dtpDateIssue
        '
        Me.dtpDateIssue.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateIssue.Location = New System.Drawing.Point(137, 10)
        Me.dtpDateIssue.Name = "dtpDateIssue"
        Me.dtpDateIssue.Size = New System.Drawing.Size(249, 22)
        Me.dtpDateIssue.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(932, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 15)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Delivered by:"
        '
        'txtDeliveredBy
        '
        Me.txtDeliveredBy.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeliveredBy.Location = New System.Drawing.Point(1049, 10)
        Me.txtDeliveredBy.Name = "txtDeliveredBy"
        Me.txtDeliveredBy.Size = New System.Drawing.Size(317, 22)
        Me.txtDeliveredBy.TabIndex = 18
        '
        'txtReceivedBy
        '
        Me.txtReceivedBy.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReceivedBy.Location = New System.Drawing.Point(1049, 41)
        Me.txtReceivedBy.Name = "txtReceivedBy"
        Me.txtReceivedBy.Size = New System.Drawing.Size(317, 22)
        Me.txtReceivedBy.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(932, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 15)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Received by:"
        '
        'dgvProd
        '
        Me.dgvProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.Barcode, Me.quantity, Me.product, Me.brand, Me.unit, Me.price, Me.less, Me.add_less, Me.Column2, Me.sell_price, Me.amount, Me.stock, Me.action})
        Me.dgvProd.Location = New System.Drawing.Point(19, 192)
        Me.dgvProd.Name = "dgvProd"
        Me.dgvProd.Size = New System.Drawing.Size(1347, 271)
        Me.dgvProd.TabIndex = 24
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 481)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(126, 22)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Payment Type"
        '
        'cbPaymentType
        '
        Me.cbPaymentType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPaymentType.FormattingEnabled = True
        Me.cbPaymentType.Items.AddRange(New Object() {"30 days", "60 days", "90 days", "120 days"})
        Me.cbPaymentType.Location = New System.Drawing.Point(210, 479)
        Me.cbPaymentType.Name = "cbPaymentType"
        Me.cbPaymentType.Size = New System.Drawing.Size(291, 28)
        Me.cbPaymentType.TabIndex = 26
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(392, 81)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 15)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Sub Category"
        '
        'cbSubcat
        '
        Me.cbSubcat.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSubcat.FormattingEnabled = True
        Me.cbSubcat.Location = New System.Drawing.Point(478, 78)
        Me.cbSubcat.Name = "cbSubcat"
        Me.cbSubcat.Size = New System.Drawing.Size(211, 23)
        Me.cbSubcat.TabIndex = 27
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(342, 121)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 15)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "Brand"
        '
        'cbBrand
        '
        Me.cbBrand.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBrand.FormattingEnabled = True
        Me.cbBrand.Location = New System.Drawing.Point(387, 118)
        Me.cbBrand.Name = "cbBrand"
        Me.cbBrand.Size = New System.Drawing.Size(130, 23)
        Me.cbBrand.TabIndex = 29
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(523, 121)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 15)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "Unit"
        '
        'cbUnit
        '
        Me.cbUnit.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbUnit.FormattingEnabled = True
        Me.cbUnit.Location = New System.Drawing.Point(559, 118)
        Me.cbUnit.Name = "cbUnit"
        Me.cbUnit.Size = New System.Drawing.Size(130, 23)
        Me.cbUnit.TabIndex = 31
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(1084, 525)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(127, 62)
        Me.btnSave.TabIndex = 33
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'CustomerOrderForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1370, 610)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cbUnit)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cbBrand)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cbSubcat)
        Me.Controls.Add(Me.cbPaymentType)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dgvProd)
        Me.Controls.Add(Me.txtReceivedBy)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtDeliveredBy)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dtpDateIssue)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbTermPayment)
        Me.Controls.Add(Me.btnSaveAndPrint)
        Me.Controls.Add(Me.lblTotalAmount)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbCat)
        Me.Controls.Add(Me.btnAddProd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbProducts)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbCustomer)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "CustomerOrderForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Customer Order"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbProducts As System.Windows.Forms.ComboBox
    Friend WithEvents btnAddProd As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbCat As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTotalAmount As System.Windows.Forms.Label
    Friend WithEvents btnSaveAndPrint As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbTermPayment As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpDateIssue As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDeliveredBy As System.Windows.Forms.TextBox
    Friend WithEvents txtReceivedBy As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dgvProd As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbPaymentType As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cbSubcat As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cbBrand As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents cbUnit As ComboBox
    Friend WithEvents btnSave As Button
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
End Class
