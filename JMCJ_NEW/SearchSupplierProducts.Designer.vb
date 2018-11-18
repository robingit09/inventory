<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchSupplierProducts
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
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.dgvProducts = New System.Windows.Forms.DataGridView()
        Me.column_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.selectp = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.column_barcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_brand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_unit_price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.linkSelectAll = New System.Windows.Forms.LinkLabel()
        Me.linkUnselectAll = New System.Windows.Forms.LinkLabel()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(677, 37)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(776, 37)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "Add "
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(488, 39)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(183, 20)
        Me.txtSearch.TabIndex = 3
        '
        'dgvProducts
        '
        Me.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.column_id, Me.selectp, Me.column_barcode, Me.column_description, Me.column_brand, Me.column_unit, Me.column_color, Me.column_unit_price})
        Me.dgvProducts.Location = New System.Drawing.Point(12, 66)
        Me.dgvProducts.Name = "dgvProducts"
        Me.dgvProducts.Size = New System.Drawing.Size(839, 429)
        Me.dgvProducts.TabIndex = 25
        '
        'column_id
        '
        Me.column_id.HeaderText = "id"
        Me.column_id.Name = "column_id"
        Me.column_id.ReadOnly = True
        Me.column_id.Width = 5
        '
        'selectp
        '
        Me.selectp.HeaderText = ""
        Me.selectp.Name = "selectp"
        Me.selectp.Width = 30
        '
        'column_barcode
        '
        Me.column_barcode.HeaderText = "Barcode"
        Me.column_barcode.Name = "column_barcode"
        Me.column_barcode.ReadOnly = True
        Me.column_barcode.Width = 140
        '
        'column_description
        '
        Me.column_description.HeaderText = "Product Description"
        Me.column_description.Name = "column_description"
        Me.column_description.ReadOnly = True
        Me.column_description.Width = 190
        '
        'column_brand
        '
        Me.column_brand.HeaderText = "Brand"
        Me.column_brand.Name = "column_brand"
        Me.column_brand.ReadOnly = True
        Me.column_brand.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.column_brand.Width = 110
        '
        'column_unit
        '
        Me.column_unit.HeaderText = "Unit"
        Me.column_unit.Name = "column_unit"
        Me.column_unit.ReadOnly = True
        Me.column_unit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'column_color
        '
        Me.column_color.HeaderText = "Color"
        Me.column_color.Name = "column_color"
        Me.column_color.ReadOnly = True
        '
        'column_unit_price
        '
        Me.column_unit_price.HeaderText = "Unit Price"
        Me.column_unit_price.Name = "column_unit_price"
        Me.column_unit_price.ReadOnly = True
        Me.column_unit_price.Width = 120
        '
        'linkSelectAll
        '
        Me.linkSelectAll.AutoSize = True
        Me.linkSelectAll.Location = New System.Drawing.Point(85, 42)
        Me.linkSelectAll.Name = "linkSelectAll"
        Me.linkSelectAll.Size = New System.Drawing.Size(51, 13)
        Me.linkSelectAll.TabIndex = 42
        Me.linkSelectAll.TabStop = True
        Me.linkSelectAll.Text = "Select All"
        '
        'linkUnselectAll
        '
        Me.linkUnselectAll.AutoSize = True
        Me.linkUnselectAll.Location = New System.Drawing.Point(9, 42)
        Me.linkUnselectAll.Name = "linkUnselectAll"
        Me.linkUnselectAll.Size = New System.Drawing.Size(63, 13)
        Me.linkUnselectAll.TabIndex = 41
        Me.linkUnselectAll.TabStop = True
        Me.linkUnselectAll.Text = "Unselect All"
        '
        'SearchSupplierProducts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(871, 531)
        Me.Controls.Add(Me.linkSelectAll)
        Me.Controls.Add(Me.linkUnselectAll)
        Me.Controls.Add(Me.dgvProducts)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnSearch)
        Me.Name = "SearchSupplierProducts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search Supplier Products"
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents dgvProducts As DataGridView
    Friend WithEvents column_id As DataGridViewTextBoxColumn
    Friend WithEvents selectp As DataGridViewCheckBoxColumn
    Friend WithEvents column_barcode As DataGridViewTextBoxColumn
    Friend WithEvents column_description As DataGridViewTextBoxColumn
    Friend WithEvents column_brand As DataGridViewTextBoxColumn
    Friend WithEvents column_unit As DataGridViewTextBoxColumn
    Friend WithEvents column_color As DataGridViewTextBoxColumn
    Friend WithEvents column_unit_price As DataGridViewTextBoxColumn
    Friend WithEvents linkSelectAll As LinkLabel
    Friend WithEvents linkUnselectAll As LinkLabel
End Class
