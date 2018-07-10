<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LedgerList
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
        Me.components = New System.ComponentModel.Container()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.cbpayment_mode = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.cbLedgerType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbShowFilter = New System.Windows.Forms.ComboBox()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.dgvLedger = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateIssue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Customer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvoiceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsPaid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DatePaid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsFloating = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BankDetails = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CounterNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Terms = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaymentType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ledger = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.View = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cbShow = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbMonth = New System.Windows.Forms.ComboBox()
        Me.cbYear = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvLedger, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.View.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(220, 12)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "Void"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(120, 12)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 4
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(24, 12)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(75, 23)
        Me.btnAddNew.TabIndex = 3
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'cbpayment_mode
        '
        Me.cbpayment_mode.FormattingEnabled = True
        Me.cbpayment_mode.Location = New System.Drawing.Point(95, 86)
        Me.cbpayment_mode.Name = "cbpayment_mode"
        Me.cbpayment_mode.Size = New System.Drawing.Size(189, 21)
        Me.cbpayment_mode.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Payment Type"
        '
        'txtCustomer
        '
        Me.txtCustomer.Location = New System.Drawing.Point(94, 19)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.Size = New System.Drawing.Size(190, 20)
        Me.txtCustomer.TabIndex = 9
        '
        'cbLedgerType
        '
        Me.cbLedgerType.FormattingEnabled = True
        Me.cbLedgerType.Location = New System.Drawing.Point(94, 52)
        Me.cbLedgerType.Name = "cbLedgerType"
        Me.cbLedgerType.Size = New System.Drawing.Size(190, 21)
        Me.cbLedgerType.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Ledger Type"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Customer"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cbYear)
        Me.GroupBox1.Controls.Add(Me.cbMonth)
        Me.GroupBox1.Controls.Add(Me.cbShowFilter)
        Me.GroupBox1.Controls.Add(Me.cbpayment_mode)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtCustomer)
        Me.GroupBox1.Controls.Add(Me.cbLedgerType)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnFilter)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.GroupBox1.Location = New System.Drawing.Point(25, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(719, 125)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "FILTER"
        '
        'cbShowFilter
        '
        Me.cbShowFilter.FormattingEnabled = True
        Me.cbShowFilter.Items.AddRange(New Object() {"20", "50", "100", "1000", "All"})
        Me.cbShowFilter.Location = New System.Drawing.Point(563, 86)
        Me.cbShowFilter.Name = "cbShowFilter"
        Me.cbShowFilter.Size = New System.Drawing.Size(59, 21)
        Me.cbShowFilter.TabIndex = 14
        '
        'btnFilter
        '
        Me.btnFilter.BackColor = System.Drawing.Color.Transparent
        Me.btnFilter.Location = New System.Drawing.Point(628, 84)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(75, 23)
        Me.btnFilter.TabIndex = 4
        Me.btnFilter.Text = "Filter"
        Me.btnFilter.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSearch)
        Me.GroupBox2.Controls.Add(Me.txtSearch)
        Me.GroupBox2.Location = New System.Drawing.Point(813, 66)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(356, 100)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Search Information"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(221, 61)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(118, 23)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(24, 26)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(315, 20)
        Me.txtSearch.TabIndex = 0
        '
        'btnLoad
        '
        Me.btnLoad.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoad.Location = New System.Drawing.Point(1363, 10)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(92, 35)
        Me.btnLoad.TabIndex = 10
        Me.btnLoad.Text = "Show All"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'dgvLedger
        '
        Me.dgvLedger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLedger.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.DateIssue, Me.Customer, Me.InvoiceNo, Me.Amount, Me.IsPaid, Me.DatePaid, Me.IsFloating, Me.BankDetails, Me.CheckDate, Me.CounterNo, Me.Terms, Me.PaymentType, Me.Ledger, Me.Status})
        Me.dgvLedger.Location = New System.Drawing.Point(24, 181)
        Me.dgvLedger.Name = "dgvLedger"
        Me.dgvLedger.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLedger.Size = New System.Drawing.Size(1431, 502)
        Me.dgvLedger.TabIndex = 13
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Width = 5
        '
        'DateIssue
        '
        Me.DateIssue.HeaderText = "Date Invoice"
        Me.DateIssue.Name = "DateIssue"
        Me.DateIssue.ReadOnly = True
        '
        'Customer
        '
        Me.Customer.HeaderText = "Customer"
        Me.Customer.Name = "Customer"
        Me.Customer.ReadOnly = True
        Me.Customer.Width = 140
        '
        'InvoiceNo
        '
        Me.InvoiceNo.HeaderText = "Invoice No"
        Me.InvoiceNo.Name = "InvoiceNo"
        Me.InvoiceNo.ReadOnly = True
        '
        'Amount
        '
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        Me.Amount.ReadOnly = True
        '
        'IsPaid
        '
        Me.IsPaid.HeaderText = "Is Paid?"
        Me.IsPaid.Name = "IsPaid"
        Me.IsPaid.ReadOnly = True
        Me.IsPaid.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IsPaid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DatePaid
        '
        Me.DatePaid.HeaderText = "Date Paid"
        Me.DatePaid.Name = "DatePaid"
        Me.DatePaid.ReadOnly = True
        Me.DatePaid.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DatePaid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'IsFloating
        '
        Me.IsFloating.HeaderText = "Is Floating?"
        Me.IsFloating.Name = "IsFloating"
        Me.IsFloating.ReadOnly = True
        Me.IsFloating.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IsFloating.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'BankDetails
        '
        Me.BankDetails.HeaderText = "Bank Details"
        Me.BankDetails.Name = "BankDetails"
        Me.BankDetails.ReadOnly = True
        Me.BankDetails.Width = 170
        '
        'CheckDate
        '
        Me.CheckDate.HeaderText = "Check Date"
        Me.CheckDate.Name = "CheckDate"
        Me.CheckDate.ReadOnly = True
        '
        'CounterNo
        '
        Me.CounterNo.HeaderText = "Counter No"
        Me.CounterNo.Name = "CounterNo"
        Me.CounterNo.ReadOnly = True
        '
        'Terms
        '
        Me.Terms.HeaderText = "Terms"
        Me.Terms.Name = "Terms"
        Me.Terms.ReadOnly = True
        '
        'PaymentType
        '
        Me.PaymentType.HeaderText = "Payment Type"
        Me.PaymentType.Name = "PaymentType"
        Me.PaymentType.ReadOnly = True
        Me.PaymentType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PaymentType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Ledger
        '
        Me.Ledger.HeaderText = "Ledger Type"
        Me.Ledger.Name = "Ledger"
        Me.Ledger.ReadOnly = True
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        '
        'View
        '
        Me.View.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewToolStripMenuItem})
        Me.View.Name = "View"
        Me.View.Size = New System.Drawing.Size(155, 26)
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.ViewToolStripMenuItem.Text = "View or Update"
        '
        'cbShow
        '
        Me.cbShow.FormattingEnabled = True
        Me.cbShow.Items.AddRange(New Object() {"20", "50", "100", "1000", "All"})
        Me.cbShow.Location = New System.Drawing.Point(1083, 39)
        Me.cbShow.Name = "cbShow"
        Me.cbShow.Size = New System.Drawing.Size(86, 21)
        Me.cbShow.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1040, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Show:"
        '
        'cbMonth
        '
        Me.cbMonth.FormattingEnabled = True
        Me.cbMonth.Location = New System.Drawing.Point(563, 18)
        Me.cbMonth.Name = "cbMonth"
        Me.cbMonth.Size = New System.Drawing.Size(140, 21)
        Me.cbMonth.TabIndex = 15
        '
        'cbYear
        '
        Me.cbYear.FormattingEnabled = True
        Me.cbYear.Location = New System.Drawing.Point(563, 50)
        Me.cbYear.Name = "cbYear"
        Me.cbYear.Size = New System.Drawing.Size(140, 21)
        Me.cbYear.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(509, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Month"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(509, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Year"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(509, 89)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Show"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(321, 12)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(84, 23)
        Me.btnPrint.TabIndex = 2
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'LedgerList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1198, 569)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbShow)
        Me.Controls.Add(Me.dgvLedger)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnAddNew)
        Me.Name = "LedgerList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Customer Order List (Ledger)"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvLedger, System.ComponentModel.ISupportInitialize).EndInit()
        Me.View.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents cbpayment_mode As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCustomer As TextBox
    Friend WithEvents cbLedgerType As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnFilter As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnLoad As Button
    Friend WithEvents dgvLedger As DataGridView
    Friend WithEvents View As ContextMenuStrip
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents DateIssue As DataGridViewTextBoxColumn
    Friend WithEvents Customer As DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNo As DataGridViewTextBoxColumn
    Friend WithEvents Amount As DataGridViewTextBoxColumn
    Friend WithEvents IsPaid As DataGridViewTextBoxColumn
    Friend WithEvents DatePaid As DataGridViewTextBoxColumn
    Friend WithEvents IsFloating As DataGridViewTextBoxColumn
    Friend WithEvents BankDetails As DataGridViewTextBoxColumn
    Friend WithEvents CheckDate As DataGridViewTextBoxColumn
    Friend WithEvents CounterNo As DataGridViewTextBoxColumn
    Friend WithEvents Terms As DataGridViewTextBoxColumn
    Friend WithEvents PaymentType As DataGridViewTextBoxColumn
    Friend WithEvents Ledger As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents cbShow As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cbShowFilter As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cbYear As ComboBox
    Friend WithEvents cbMonth As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnPrint As Button
End Class
