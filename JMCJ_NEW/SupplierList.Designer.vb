<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SupplierList
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
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.dgvSupplier = New System.Windows.Forms.DataGridView()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Supplier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SupplierCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Address = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.city = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContactPerson = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContactNumber1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContactNumber2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FaxTel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmailAddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.date_created = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvSupplier, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(18, 26)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(109, 26)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 1
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(202, 26)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'dgvSupplier
        '
        Me.dgvSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSupplier.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Supplier, Me.SupplierCode, Me.Address, Me.city, Me.ContactPerson, Me.ContactNumber1, Me.ContactNumber2, Me.FaxTel, Me.EmailAddress, Me.date_created, Me.Status})
        Me.dgvSupplier.Location = New System.Drawing.Point(18, 110)
        Me.dgvSupplier.Name = "dgvSupplier"
        Me.dgvSupplier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSupplier.Size = New System.Drawing.Size(1248, 290)
        Me.dgvSupplier.TabIndex = 3
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(1001, 84)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(265, 20)
        Me.txtSearch.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(954, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Search"
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.Width = 5
        '
        'Supplier
        '
        Me.Supplier.HeaderText = "Supplier"
        Me.Supplier.Name = "Supplier"
        Me.Supplier.Width = 200
        '
        'SupplierCode
        '
        Me.SupplierCode.HeaderText = "Supplier Code"
        Me.SupplierCode.Name = "SupplierCode"
        '
        'Address
        '
        Me.Address.HeaderText = "Address"
        Me.Address.Name = "Address"
        Me.Address.ReadOnly = True
        '
        'city
        '
        Me.city.HeaderText = "City"
        Me.city.Name = "city"
        Me.city.ReadOnly = True
        '
        'ContactPerson
        '
        Me.ContactPerson.HeaderText = "Contact Person"
        Me.ContactPerson.Name = "ContactPerson"
        Me.ContactPerson.ReadOnly = True
        '
        'ContactNumber1
        '
        Me.ContactNumber1.HeaderText = "Contact Number1"
        Me.ContactNumber1.Name = "ContactNumber1"
        Me.ContactNumber1.ReadOnly = True
        '
        'ContactNumber2
        '
        Me.ContactNumber2.HeaderText = "Contact Number2"
        Me.ContactNumber2.Name = "ContactNumber2"
        Me.ContactNumber2.ReadOnly = True
        '
        'FaxTel
        '
        Me.FaxTel.HeaderText = "Fax/Tel"
        Me.FaxTel.Name = "FaxTel"
        Me.FaxTel.ReadOnly = True
        '
        'EmailAddress
        '
        Me.EmailAddress.HeaderText = "Email Address"
        Me.EmailAddress.Name = "EmailAddress"
        Me.EmailAddress.ReadOnly = True
        '
        'date_created
        '
        Me.date_created.HeaderText = "Date Created"
        Me.date_created.Name = "date_created"
        Me.date_created.ReadOnly = True
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        '
        'SupplierList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1278, 429)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.dgvSupplier)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnAdd)
        Me.Name = "SupplierList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Supplier List"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvSupplier, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents dgvSupplier As System.Windows.Forms.DataGridView
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents Supplier As DataGridViewTextBoxColumn
    Friend WithEvents SupplierCode As DataGridViewTextBoxColumn
    Friend WithEvents Address As DataGridViewTextBoxColumn
    Friend WithEvents city As DataGridViewTextBoxColumn
    Friend WithEvents ContactPerson As DataGridViewTextBoxColumn
    Friend WithEvents ContactNumber1 As DataGridViewTextBoxColumn
    Friend WithEvents ContactNumber2 As DataGridViewTextBoxColumn
    Friend WithEvents FaxTel As DataGridViewTextBoxColumn
    Friend WithEvents EmailAddress As DataGridViewTextBoxColumn
    Friend WithEvents date_created As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
End Class
