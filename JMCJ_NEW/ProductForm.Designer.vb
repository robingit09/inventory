<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProduct = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbCategory = New System.Windows.Forms.ComboBox()
        Me.cbSubcategory = New System.Windows.Forms.ComboBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbMeasurement = New System.Windows.Forms.TabPage()
        Me.btnAddMoreUnit = New System.Windows.Forms.Button()
        Me.dgvMeasurement = New System.Windows.Forms.DataGridView()
        Me.Barcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Brand = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Unit = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remove_column = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.TabControl1.SuspendLayout()
        Me.tbMeasurement.SuspendLayout()
        CType(Me.dgvMeasurement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(35, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Product Description"
        '
        'txtProduct
        '
        Me.txtProduct.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProduct.ForeColor = System.Drawing.Color.Black
        Me.txtProduct.Location = New System.Drawing.Point(182, 127)
        Me.txtProduct.Name = "txtProduct"
        Me.txtProduct.Size = New System.Drawing.Size(541, 26)
        Me.txtProduct.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(35, 180)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 19)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Category"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.Location = New System.Drawing.Point(800, 12)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(94, 37)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(35, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 19)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Barcode"
        '
        'txtBarcode
        '
        Me.txtBarcode.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.ForeColor = System.Drawing.Color.Black
        Me.txtBarcode.Location = New System.Drawing.Point(182, 77)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(329, 26)
        Me.txtBarcode.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(35, 229)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 19)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Subcategory"
        '
        'cbCategory
        '
        Me.cbCategory.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCategory.FormattingEnabled = True
        Me.cbCategory.Location = New System.Drawing.Point(182, 177)
        Me.cbCategory.Name = "cbCategory"
        Me.cbCategory.Size = New System.Drawing.Size(449, 27)
        Me.cbCategory.TabIndex = 3
        '
        'cbSubcategory
        '
        Me.cbSubcategory.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSubcategory.FormattingEnabled = True
        Me.cbSubcategory.Location = New System.Drawing.Point(182, 226)
        Me.cbSubcategory.Name = "cbSubcategory"
        Me.cbSubcategory.Size = New System.Drawing.Size(449, 27)
        Me.cbSubcategory.TabIndex = 4
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbMeasurement)
        Me.TabControl1.Location = New System.Drawing.Point(39, 290)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(859, 247)
        Me.TabControl1.TabIndex = 20
        '
        'tbMeasurement
        '
        Me.tbMeasurement.Controls.Add(Me.btnAddMoreUnit)
        Me.tbMeasurement.Controls.Add(Me.dgvMeasurement)
        Me.tbMeasurement.Location = New System.Drawing.Point(4, 22)
        Me.tbMeasurement.Name = "tbMeasurement"
        Me.tbMeasurement.Padding = New System.Windows.Forms.Padding(3)
        Me.tbMeasurement.Size = New System.Drawing.Size(851, 221)
        Me.tbMeasurement.TabIndex = 0
        Me.tbMeasurement.Text = "Measurement"
        Me.tbMeasurement.UseVisualStyleBackColor = True
        '
        'btnAddMoreUnit
        '
        Me.btnAddMoreUnit.Location = New System.Drawing.Point(757, 7)
        Me.btnAddMoreUnit.Name = "btnAddMoreUnit"
        Me.btnAddMoreUnit.Size = New System.Drawing.Size(88, 23)
        Me.btnAddMoreUnit.TabIndex = 1
        Me.btnAddMoreUnit.Text = "Add More +"
        Me.btnAddMoreUnit.UseVisualStyleBackColor = True
        '
        'dgvMeasurement
        '
        Me.dgvMeasurement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMeasurement.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Barcode, Me.Brand, Me.Unit, Me.price, Me.remove_column})
        Me.dgvMeasurement.Location = New System.Drawing.Point(6, 45)
        Me.dgvMeasurement.Name = "dgvMeasurement"
        Me.dgvMeasurement.Size = New System.Drawing.Size(839, 163)
        Me.dgvMeasurement.TabIndex = 0
        '
        'Barcode
        '
        Me.Barcode.HeaderText = "Barcode"
        Me.Barcode.Name = "Barcode"
        Me.Barcode.Width = 200
        '
        'Brand
        '
        Me.Brand.HeaderText = "Brand"
        Me.Brand.Name = "Brand"
        Me.Brand.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Brand.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Brand.Width = 150
        '
        'Unit
        '
        Me.Unit.HeaderText = "Unit"
        Me.Unit.Name = "Unit"
        Me.Unit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'price
        '
        Me.price.HeaderText = "Price"
        Me.price.Name = "price"
        '
        'remove_column
        '
        Me.remove_column.HeaderText = "Action"
        Me.remove_column.Name = "remove_column"
        '
        'ProductForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(910, 566)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.cbSubcategory)
        Me.Controls.Add(Me.cbCategory)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBarcode)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtProduct)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ProductForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabControl1.ResumeLayout(False)
        Me.tbMeasurement.ResumeLayout(False)
        CType(Me.dgvMeasurement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtProduct As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents cbSubcategory As System.Windows.Forms.ComboBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tbMeasurement As System.Windows.Forms.TabPage
    Friend WithEvents dgvMeasurement As System.Windows.Forms.DataGridView
    Friend WithEvents btnAddMoreUnit As Button
    Friend WithEvents Barcode As DataGridViewTextBoxColumn
    Friend WithEvents Brand As DataGridViewComboBoxColumn
    Friend WithEvents Unit As DataGridViewComboBoxColumn
    Friend WithEvents price As DataGridViewTextBoxColumn
    Friend WithEvents remove_column As DataGridViewButtonColumn
End Class
