<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pricing
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbCustomer = New System.Windows.Forms.ComboBox
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Barcode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductDescription = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Brand = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Unit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SellPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Category = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Subcategory = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnAdd = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.Barcode, Me.ProductDescription, Me.Brand, Me.Unit, Me.UnitPrice, Me.SellPrice, Me.Category, Me.Subcategory})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 118)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1013, 398)
        Me.DataGridView1.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Customer"
        '
        'cbCustomer
        '
        Me.cbCustomer.FormattingEnabled = True
        Me.cbCustomer.Location = New System.Drawing.Point(90, 30)
        Me.cbCustomer.Name = "cbCustomer"
        Me.cbCustomer.Size = New System.Drawing.Size(223, 21)
        Me.cbCustomer.TabIndex = 23
        '
        'id
        '
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 5
        '
        'Barcode
        '
        Me.Barcode.HeaderText = "Barcode"
        Me.Barcode.Name = "Barcode"
        Me.Barcode.ReadOnly = True
        Me.Barcode.Width = 150
        '
        'ProductDescription
        '
        Me.ProductDescription.HeaderText = "Product Description"
        Me.ProductDescription.Name = "ProductDescription"
        Me.ProductDescription.ReadOnly = True
        Me.ProductDescription.Width = 200
        '
        'Brand
        '
        Me.Brand.HeaderText = "Brand"
        Me.Brand.Name = "Brand"
        Me.Brand.ReadOnly = True
        Me.Brand.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Brand.Width = 110
        '
        'Unit
        '
        Me.Unit.HeaderText = "Unit"
        Me.Unit.Name = "Unit"
        Me.Unit.ReadOnly = True
        Me.Unit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'UnitPrice
        '
        Me.UnitPrice.HeaderText = "Unit Price"
        Me.UnitPrice.Name = "UnitPrice"
        Me.UnitPrice.ReadOnly = True
        '
        'SellPrice
        '
        Me.SellPrice.HeaderText = "Sell Price"
        Me.SellPrice.Name = "SellPrice"
        '
        'Category
        '
        Me.Category.HeaderText = "Category"
        Me.Category.Name = "Category"
        Me.Category.ReadOnly = True
        '
        'Subcategory
        '
        Me.Subcategory.HeaderText = "Subcategory"
        Me.Subcategory.Name = "Subcategory"
        Me.Subcategory.ReadOnly = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(12, 79)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(80, 23)
        Me.btnAdd.TabIndex = 24
        Me.btnAdd.Text = "Add Product"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(113, 79)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 23)
        Me.Button1.TabIndex = 25
        Me.Button1.Text = "Update Price"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(216, 79)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(97, 23)
        Me.Button2.TabIndex = 26
        Me.Button2.Text = "Delete Product"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Pricing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1213, 551)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.cbCustomer)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Pricing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pricing"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Barcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Brand As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SellPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Category As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Subcategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
