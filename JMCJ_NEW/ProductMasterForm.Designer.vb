<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductMasterForm
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnAddCost = New System.Windows.Forms.Button()
        Me.dgvCost = New System.Windows.Forms.DataGridView()
        Me.Supplier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Action = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBrand = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtColor = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtUnit = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvCost, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(23, 164)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(695, 214)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnAddCost)
        Me.TabPage1.Controls.Add(Me.dgvCost)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(687, 187)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Cost"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnAddCost
        '
        Me.btnAddCost.Location = New System.Drawing.Point(606, 11)
        Me.btnAddCost.Name = "btnAddCost"
        Me.btnAddCost.Size = New System.Drawing.Size(75, 23)
        Me.btnAddCost.TabIndex = 1
        Me.btnAddCost.Text = "Add"
        Me.btnAddCost.UseVisualStyleBackColor = True
        '
        'dgvCost
        '
        Me.dgvCost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCost.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Supplier, Me.Cost, Me.Action})
        Me.dgvCost.Location = New System.Drawing.Point(6, 40)
        Me.dgvCost.Name = "dgvCost"
        Me.dgvCost.Size = New System.Drawing.Size(675, 142)
        Me.dgvCost.TabIndex = 0
        '
        'Supplier
        '
        Me.Supplier.HeaderText = "Supplier"
        Me.Supplier.Name = "Supplier"
        Me.Supplier.ReadOnly = True
        Me.Supplier.Width = 300
        '
        'Cost
        '
        Me.Cost.HeaderText = "Unit Cost"
        Me.Cost.Name = "Cost"
        Me.Cost.ReadOnly = True
        '
        'Action
        '
        Me.Action.HeaderText = "Action"
        Me.Action.Name = "Action"
        Me.Action.ReadOnly = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(687, 187)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Barcode"
        '
        'txtBarcode
        '
        Me.txtBarcode.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(84, 22)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.ReadOnly = True
        Me.txtBarcode.Size = New System.Drawing.Size(204, 20)
        Me.txtBarcode.TabIndex = 2
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(84, 48)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.Size = New System.Drawing.Size(204, 20)
        Me.txtDescription.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Description"
        '
        'txtBrand
        '
        Me.txtBrand.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrand.Location = New System.Drawing.Point(84, 74)
        Me.txtBrand.Name = "txtBrand"
        Me.txtBrand.ReadOnly = True
        Me.txtBrand.Size = New System.Drawing.Size(204, 20)
        Me.txtBrand.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 14)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Brand"
        '
        'txtColor
        '
        Me.txtColor.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColor.Location = New System.Drawing.Point(84, 100)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.ReadOnly = True
        Me.txtColor.Size = New System.Drawing.Size(204, 20)
        Me.txtColor.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 14)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Color"
        '
        'txtUnit
        '
        Me.txtUnit.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnit.Location = New System.Drawing.Point(84, 124)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.ReadOnly = True
        Me.txtUnit.Size = New System.Drawing.Size(204, 20)
        Me.txtUnit.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(20, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 14)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Unit"
        '
        'txtPrice
        '
        Me.txtPrice.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice.Location = New System.Drawing.Point(406, 21)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.ReadOnly = True
        Me.txtPrice.Size = New System.Drawing.Size(109, 20)
        Me.txtPrice.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(345, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 14)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Unit Price"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(639, 20)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'ProductMasterForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(730, 390)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtPrice)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtUnit)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtColor)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtBrand)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBarcode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "ProductMasterForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Product Master Form"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvCost, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtBrand As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtColor As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtUnit As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnAddCost As Button
    Friend WithEvents dgvCost As DataGridView
    Friend WithEvents btnSave As Button
    Friend WithEvents Supplier As DataGridViewTextBoxColumn
    Friend WithEvents Cost As DataGridViewTextBoxColumn
    Friend WithEvents Action As DataGridViewButtonColumn
End Class
