<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class POList
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
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.dgvPO = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateIssue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PONumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SupplierName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.delivery_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnVoid = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.gpFilter = New System.Windows.Forms.GroupBox()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.cbYear = New System.Windows.Forms.ComboBox()
        Me.txtSupplier = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbMonth = New System.Windows.Forms.ComboBox()
        CType(Me.dgvPO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpFilter.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAddNew
        '
        Me.btnAddNew.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddNew.Location = New System.Drawing.Point(26, 29)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(83, 29)
        Me.btnAddNew.TabIndex = 0
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'dgvPO
        '
        Me.dgvPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPO.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.DateIssue, Me.PONumber, Me.SupplierName, Me.TotalAmount, Me.ProcessedBy, Me.delivery_status})
        Me.dgvPO.Location = New System.Drawing.Point(26, 203)
        Me.dgvPO.Name = "dgvPO"
        Me.dgvPO.Size = New System.Drawing.Size(921, 408)
        Me.dgvPO.TabIndex = 1
        '
        'id
        '
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 5
        '
        'DateIssue
        '
        Me.DateIssue.HeaderText = "Date Issue"
        Me.DateIssue.Name = "DateIssue"
        Me.DateIssue.ReadOnly = True
        Me.DateIssue.Width = 200
        '
        'PONumber
        '
        Me.PONumber.HeaderText = "PO Number"
        Me.PONumber.Name = "PONumber"
        Me.PONumber.ReadOnly = True
        Me.PONumber.Width = 120
        '
        'SupplierName
        '
        Me.SupplierName.HeaderText = "Supplier Name"
        Me.SupplierName.Name = "SupplierName"
        Me.SupplierName.ReadOnly = True
        Me.SupplierName.Width = 250
        '
        'TotalAmount
        '
        Me.TotalAmount.HeaderText = "Total Amount"
        Me.TotalAmount.Name = "TotalAmount"
        Me.TotalAmount.ReadOnly = True
        '
        'ProcessedBy
        '
        Me.ProcessedBy.HeaderText = "Processed By"
        Me.ProcessedBy.Name = "ProcessedBy"
        Me.ProcessedBy.ReadOnly = True
        '
        'delivery_status
        '
        Me.delivery_status.HeaderText = "Delivery Status"
        Me.delivery_status.Name = "delivery_status"
        Me.delivery_status.ReadOnly = True
        '
        'btnVoid
        '
        Me.btnVoid.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoid.Location = New System.Drawing.Point(341, 29)
        Me.btnVoid.Name = "btnVoid"
        Me.btnVoid.Size = New System.Drawing.Size(83, 29)
        Me.btnVoid.TabIndex = 2
        Me.btnVoid.Text = "Void"
        Me.btnVoid.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Location = New System.Drawing.Point(133, 29)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(83, 29)
        Me.btnView.TabIndex = 3
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(235, 29)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(83, 29)
        Me.btnPrint.TabIndex = 4
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'gpFilter
        '
        Me.gpFilter.Controls.Add(Me.btnFilter)
        Me.gpFilter.Controls.Add(Me.cbYear)
        Me.gpFilter.Controls.Add(Me.txtSupplier)
        Me.gpFilter.Controls.Add(Me.Label3)
        Me.gpFilter.Controls.Add(Me.Label2)
        Me.gpFilter.Controls.Add(Me.Label1)
        Me.gpFilter.Controls.Add(Me.cbMonth)
        Me.gpFilter.Location = New System.Drawing.Point(26, 93)
        Me.gpFilter.Name = "gpFilter"
        Me.gpFilter.Size = New System.Drawing.Size(921, 91)
        Me.gpFilter.TabIndex = 5
        Me.gpFilter.TabStop = False
        Me.gpFilter.Text = "Filter"
        '
        'btnFilter
        '
        Me.btnFilter.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFilter.Location = New System.Drawing.Point(832, 49)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(83, 29)
        Me.btnFilter.TabIndex = 6
        Me.btnFilter.Text = "Filter"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'cbYear
        '
        Me.cbYear.FormattingEnabled = True
        Me.cbYear.Location = New System.Drawing.Point(323, 53)
        Me.cbYear.Name = "cbYear"
        Me.cbYear.Size = New System.Drawing.Size(204, 21)
        Me.cbYear.TabIndex = 30
        '
        'txtSupplier
        '
        Me.txtSupplier.Location = New System.Drawing.Point(67, 28)
        Me.txtSupplier.Name = "txtSupplier"
        Me.txtSupplier.Size = New System.Drawing.Size(212, 20)
        Me.txtSupplier.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(285, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Year:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Month:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Supplier"
        '
        'cbMonth
        '
        Me.cbMonth.FormattingEnabled = True
        Me.cbMonth.Location = New System.Drawing.Point(67, 55)
        Me.cbMonth.Name = "cbMonth"
        Me.cbMonth.Size = New System.Drawing.Size(212, 21)
        Me.cbMonth.TabIndex = 28
        '
        'POList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(983, 635)
        Me.Controls.Add(Me.gpFilter)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnVoid)
        Me.Controls.Add(Me.dgvPO)
        Me.Controls.Add(Me.btnAddNew)
        Me.Name = "POList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Order"
        CType(Me.dgvPO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpFilter.ResumeLayout(False)
        Me.gpFilter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents dgvPO As System.Windows.Forms.DataGridView
    Friend WithEvents btnVoid As Button
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents DateIssue As DataGridViewTextBoxColumn
    Friend WithEvents PONumber As DataGridViewTextBoxColumn
    Friend WithEvents SupplierName As DataGridViewTextBoxColumn
    Friend WithEvents TotalAmount As DataGridViewTextBoxColumn
    Friend WithEvents ProcessedBy As DataGridViewTextBoxColumn
    Friend WithEvents delivery_status As DataGridViewTextBoxColumn
    Friend WithEvents btnView As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents gpFilter As GroupBox
    Friend WithEvents btnFilter As Button
    Friend WithEvents cbYear As ComboBox
    Friend WithEvents txtSupplier As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cbMonth As ComboBox
End Class
