<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventoryReport
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
        Me.txtProductDesc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.cbBrand = New System.Windows.Forms.ComboBox()
        Me.cbSubCat = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbUnit = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbColor = New System.Windows.Forms.ComboBox()
        Me.cbCat = New System.Windows.Forms.ComboBox()
        Me.gpFilter.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(1034, 172)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 0
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'gpFilter
        '
        Me.gpFilter.Controls.Add(Me.txtProductDesc)
        Me.gpFilter.Controls.Add(Me.Label4)
        Me.gpFilter.Controls.Add(Me.txtBarcode)
        Me.gpFilter.Controls.Add(Me.cbBrand)
        Me.gpFilter.Controls.Add(Me.cbSubCat)
        Me.gpFilter.Controls.Add(Me.Label5)
        Me.gpFilter.Controls.Add(Me.Label1)
        Me.gpFilter.Controls.Add(Me.cbUnit)
        Me.gpFilter.Controls.Add(Me.Label7)
        Me.gpFilter.Controls.Add(Me.Label3)
        Me.gpFilter.Controls.Add(Me.Label2)
        Me.gpFilter.Controls.Add(Me.Label6)
        Me.gpFilter.Controls.Add(Me.cbColor)
        Me.gpFilter.Controls.Add(Me.cbCat)
        Me.gpFilter.Location = New System.Drawing.Point(12, 25)
        Me.gpFilter.Name = "gpFilter"
        Me.gpFilter.Size = New System.Drawing.Size(1097, 132)
        Me.gpFilter.TabIndex = 1
        Me.gpFilter.TabStop = False
        Me.gpFilter.Text = "Filter"
        '
        'txtProductDesc
        '
        Me.txtProductDesc.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductDesc.Location = New System.Drawing.Point(345, 31)
        Me.txtProductDesc.Name = "txtProductDesc"
        Me.txtProductDesc.Size = New System.Drawing.Size(190, 21)
        Me.txtProductDesc.TabIndex = 45
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 15)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "Barcode"
        '
        'txtBarcode
        '
        Me.txtBarcode.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(83, 31)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(145, 21)
        Me.txtBarcode.TabIndex = 36
        '
        'cbBrand
        '
        Me.cbBrand.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBrand.FormattingEnabled = True
        Me.cbBrand.Location = New System.Drawing.Point(601, 31)
        Me.cbBrand.Name = "cbBrand"
        Me.cbBrand.Size = New System.Drawing.Size(132, 23)
        Me.cbBrand.TabIndex = 38
        '
        'cbSubCat
        '
        Me.cbSubCat.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSubCat.FormattingEnabled = True
        Me.cbSubCat.Location = New System.Drawing.Point(345, 66)
        Me.cbSubCat.Name = "cbSubCat"
        Me.cbSubCat.Size = New System.Drawing.Size(190, 23)
        Me.cbSubCat.TabIndex = 44
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(750, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 15)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Unit"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(234, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 15)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Product Description"
        '
        'cbUnit
        '
        Me.cbUnit.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbUnit.FormattingEnabled = True
        Me.cbUnit.Location = New System.Drawing.Point(792, 31)
        Me.cbUnit.Name = "cbUnit"
        Me.cbUnit.Size = New System.Drawing.Size(117, 23)
        Me.cbUnit.TabIndex = 40
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(237, 69)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 15)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "Sub Category"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(559, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 15)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Brand"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 15)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Category"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(916, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 15)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "Color"
        '
        'cbColor
        '
        Me.cbColor.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbColor.FormattingEnabled = True
        Me.cbColor.Location = New System.Drawing.Point(958, 31)
        Me.cbColor.Name = "cbColor"
        Me.cbColor.Size = New System.Drawing.Size(117, 23)
        Me.cbColor.TabIndex = 42
        '
        'cbCat
        '
        Me.cbCat.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCat.FormattingEnabled = True
        Me.cbCat.Location = New System.Drawing.Point(83, 66)
        Me.cbCat.Name = "cbCat"
        Me.cbCat.Size = New System.Drawing.Size(145, 23)
        Me.cbCat.TabIndex = 34
        '
        'InventoryReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1121, 215)
        Me.Controls.Add(Me.gpFilter)
        Me.Controls.Add(Me.btnPrint)
        Me.Name = "InventoryReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventory Report"
        Me.gpFilter.ResumeLayout(False)
        Me.gpFilter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnPrint As Button
    Friend WithEvents gpFilter As GroupBox
    Friend WithEvents txtProductDesc As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents cbBrand As ComboBox
    Friend WithEvents cbSubCat As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cbUnit As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cbColor As ComboBox
    Friend WithEvents cbCat As ComboBox
End Class
