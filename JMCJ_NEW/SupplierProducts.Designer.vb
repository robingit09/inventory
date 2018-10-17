<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SupplierProducts
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
        Me.cbSupplier = New System.Windows.Forms.ComboBox()
        Me.dgvProducts = New System.Windows.Forms.DataGridView()
        Me.column_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_barcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_brand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unit_cost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Action = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Supplier:"
        '
        'cbSupplier
        '
        Me.cbSupplier.FormattingEnabled = True
        Me.cbSupplier.Location = New System.Drawing.Point(63, 13)
        Me.cbSupplier.Name = "cbSupplier"
        Me.cbSupplier.Size = New System.Drawing.Size(240, 21)
        Me.cbSupplier.TabIndex = 1
        '
        'dgvProducts
        '
        Me.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.column_id, Me.column_barcode, Me.column_description, Me.column_brand, Me.column_unit, Me.column_color, Me.unit_cost, Me.Action})
        Me.dgvProducts.Location = New System.Drawing.Point(12, 53)
        Me.dgvProducts.Name = "dgvProducts"
        Me.dgvProducts.Size = New System.Drawing.Size(914, 454)
        Me.dgvProducts.TabIndex = 25
        '
        'column_id
        '
        Me.column_id.HeaderText = "id"
        Me.column_id.Name = "column_id"
        Me.column_id.ReadOnly = True
        Me.column_id.Width = 5
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
        'unit_cost
        '
        Me.unit_cost.HeaderText = "Unit Cost"
        Me.unit_cost.Name = "unit_cost"
        Me.unit_cost.ReadOnly = True
        Me.unit_cost.Width = 120
        '
        'Action
        '
        Me.Action.HeaderText = "Remove"
        Me.Action.Name = "Action"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(693, 11)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(109, 23)
        Me.btnSearch.TabIndex = 26
        Me.btnSearch.Text = "Search Products"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(817, 11)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(109, 23)
        Me.btnSave.TabIndex = 27
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'SupplierProducts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(941, 519)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.dgvProducts)
        Me.Controls.Add(Me.cbSupplier)
        Me.Controls.Add(Me.Label1)
        Me.Name = "SupplierProducts"
        Me.Text = "Supplier Products"
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cbSupplier As ComboBox
    Friend WithEvents dgvProducts As DataGridView
    Friend WithEvents column_id As DataGridViewTextBoxColumn
    Friend WithEvents column_barcode As DataGridViewTextBoxColumn
    Friend WithEvents column_description As DataGridViewTextBoxColumn
    Friend WithEvents column_brand As DataGridViewTextBoxColumn
    Friend WithEvents column_unit As DataGridViewTextBoxColumn
    Friend WithEvents column_color As DataGridViewTextBoxColumn
    Friend WithEvents unit_cost As DataGridViewTextBoxColumn
    Friend WithEvents Action As DataGridViewButtonColumn
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnSave As Button
End Class
