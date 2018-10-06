<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PurchaseReceive
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
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnVoid = New System.Windows.Forms.Button()
        Me.dgvPR = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateIssue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PONumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dr_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SupplierName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.delivery_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.cbDRNo = New System.Windows.Forms.ComboBox()
        Me.cbPRNo = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbYear = New System.Windows.Forms.ComboBox()
        Me.txtSupplier = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbMonth = New System.Windows.Forms.ComboBox()
        Me.gpFilter = New System.Windows.Forms.GroupBox()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.dgvPR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpFilter.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnView
        '
        Me.btnView.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Location = New System.Drawing.Point(119, 26)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(83, 29)
        Me.btnView.TabIndex = 7
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnVoid
        '
        Me.btnVoid.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoid.Location = New System.Drawing.Point(323, 26)
        Me.btnVoid.Name = "btnVoid"
        Me.btnVoid.Size = New System.Drawing.Size(83, 29)
        Me.btnVoid.TabIndex = 6
        Me.btnVoid.Text = "Void"
        Me.btnVoid.UseVisualStyleBackColor = True
        '
        'dgvPR
        '
        Me.dgvPR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.DateIssue, Me.PRNumber, Me.PONumber, Me.dr_no, Me.SupplierName, Me.TotalAmount, Me.ProcessedBy, Me.delivery_status})
        Me.dgvPR.Location = New System.Drawing.Point(12, 211)
        Me.dgvPR.Name = "dgvPR"
        Me.dgvPR.Size = New System.Drawing.Size(1152, 381)
        Me.dgvPR.TabIndex = 5
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
        'PRNumber
        '
        Me.PRNumber.HeaderText = "PR Number"
        Me.PRNumber.Name = "PRNumber"
        Me.PRNumber.ReadOnly = True
        Me.PRNumber.Width = 120
        '
        'PONumber
        '
        Me.PONumber.HeaderText = "PO Number"
        Me.PONumber.Name = "PONumber"
        Me.PONumber.ReadOnly = True
        '
        'dr_no
        '
        Me.dr_no.HeaderText = "DR Number"
        Me.dr_no.Name = "dr_no"
        Me.dr_no.ReadOnly = True
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
        'btnAddNew
        '
        Me.btnAddNew.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddNew.Location = New System.Drawing.Point(12, 26)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(83, 29)
        Me.btnAddNew.TabIndex = 4
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(221, 26)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(83, 29)
        Me.btnPrint.TabIndex = 8
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'cbDRNo
        '
        Me.cbDRNo.FormattingEnabled = True
        Me.cbDRNo.Location = New System.Drawing.Point(273, 22)
        Me.cbDRNo.Name = "cbDRNo"
        Me.cbDRNo.Size = New System.Drawing.Size(121, 21)
        Me.cbDRNo.TabIndex = 9
        '
        'cbPRNo
        '
        Me.cbPRNo.FormattingEnabled = True
        Me.cbPRNo.Location = New System.Drawing.Point(74, 24)
        Me.cbPRNo.Name = "cbPRNo"
        Me.cbPRNo.Size = New System.Drawing.Size(121, 21)
        Me.cbPRNo.TabIndex = 33
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 27)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "PR Number"
        '
        'cbYear
        '
        Me.cbYear.FormattingEnabled = True
        Me.cbYear.Location = New System.Drawing.Point(226, 74)
        Me.cbYear.Name = "cbYear"
        Me.cbYear.Size = New System.Drawing.Size(143, 21)
        Me.cbYear.TabIndex = 30
        '
        'txtSupplier
        '
        Me.txtSupplier.Location = New System.Drawing.Point(457, 22)
        Me.txtSupplier.Name = "txtSupplier"
        Me.txtSupplier.Size = New System.Drawing.Size(214, 20)
        Me.txtSupplier.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(188, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Year:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Month:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(406, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Supplier"
        '
        'cbMonth
        '
        Me.cbMonth.FormattingEnabled = True
        Me.cbMonth.Location = New System.Drawing.Point(52, 74)
        Me.cbMonth.Name = "cbMonth"
        Me.cbMonth.Size = New System.Drawing.Size(121, 21)
        Me.cbMonth.TabIndex = 28
        '
        'gpFilter
        '
        Me.gpFilter.Controls.Add(Me.Label4)
        Me.gpFilter.Controls.Add(Me.cbPRNo)
        Me.gpFilter.Controls.Add(Me.cbDRNo)
        Me.gpFilter.Controls.Add(Me.btnFilter)
        Me.gpFilter.Controls.Add(Me.Label10)
        Me.gpFilter.Controls.Add(Me.cbYear)
        Me.gpFilter.Controls.Add(Me.txtSupplier)
        Me.gpFilter.Controls.Add(Me.Label3)
        Me.gpFilter.Controls.Add(Me.Label2)
        Me.gpFilter.Controls.Add(Me.Label1)
        Me.gpFilter.Controls.Add(Me.cbMonth)
        Me.gpFilter.Location = New System.Drawing.Point(12, 90)
        Me.gpFilter.Name = "gpFilter"
        Me.gpFilter.Size = New System.Drawing.Size(921, 104)
        Me.gpFilter.TabIndex = 10
        Me.gpFilter.TabStop = False
        Me.gpFilter.Text = "Filter"
        '
        'btnFilter
        '
        Me.btnFilter.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFilter.Location = New System.Drawing.Point(832, 68)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(83, 29)
        Me.btnFilter.TabIndex = 6
        Me.btnFilter.Text = "Filter"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(206, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "DR Number"
        '
        'PurchaseReceive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1176, 604)
        Me.Controls.Add(Me.gpFilter)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnVoid)
        Me.Controls.Add(Me.dgvPR)
        Me.Controls.Add(Me.btnAddNew)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "PurchaseReceive"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Receive"
        CType(Me.dgvPR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpFilter.ResumeLayout(False)
        Me.gpFilter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnView As Button
    Friend WithEvents btnVoid As Button
    Friend WithEvents dgvPR As DataGridView
    Friend WithEvents btnAddNew As Button
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents DateIssue As DataGridViewTextBoxColumn
    Friend WithEvents PRNumber As DataGridViewTextBoxColumn
    Friend WithEvents PONumber As DataGridViewTextBoxColumn
    Friend WithEvents dr_no As DataGridViewTextBoxColumn
    Friend WithEvents SupplierName As DataGridViewTextBoxColumn
    Friend WithEvents TotalAmount As DataGridViewTextBoxColumn
    Friend WithEvents ProcessedBy As DataGridViewTextBoxColumn
    Friend WithEvents delivery_status As DataGridViewTextBoxColumn
    Friend WithEvents btnPrint As Button
    Friend WithEvents cbDRNo As ComboBox
    Friend WithEvents cbPRNo As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cbYear As ComboBox
    Friend WithEvents txtSupplier As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cbMonth As ComboBox
    Friend WithEvents gpFilter As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnFilter As Button
End Class
