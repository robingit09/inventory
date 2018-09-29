<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main_form
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main_form))
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.InventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductMasterInformationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BrandToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColorToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CategoriesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchaseOrderToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchaseReceiveToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchaseOrderRequestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupplierToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchaseReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PricingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LedgerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MasterListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LedgerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InventoryReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalesReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DailyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MonthlyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TopSalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SystemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblTest = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.Black
        Me.lblDate.Location = New System.Drawing.Point(12, 43)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(60, 26)
        Me.lblDate.TabIndex = 1
        Me.lblDate.Text = "Date"
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.ForeColor = System.Drawing.Color.Black
        Me.lblTime.Location = New System.Drawing.Point(12, 78)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(64, 26)
        Me.lblTime.TabIndex = 2
        Me.lblTime.Text = "Time"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(243, 106)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(648, 266)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InventoryToolStripMenuItem, Me.PurchaseToolStripMenuItem, Me.SalesToolStripMenuItem, Me.LedgerToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.SystemToolStripMenuItem})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(926, 29)
        Me.MenuStrip2.TabIndex = 4
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'InventoryToolStripMenuItem
        '
        Me.InventoryToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProductsToolStripMenuItem, Me.ProductMasterInformationToolStripMenuItem, Me.BrandToolStripMenuItem1, Me.UnitToolStripMenuItem1, Me.ColorToolStripMenuItem1, Me.CategoriesToolStripMenuItem1})
        Me.InventoryToolStripMenuItem.Name = "InventoryToolStripMenuItem"
        Me.InventoryToolStripMenuItem.Size = New System.Drawing.Size(97, 25)
        Me.InventoryToolStripMenuItem.Text = "Inventory"
        '
        'ProductsToolStripMenuItem
        '
        Me.ProductsToolStripMenuItem.Name = "ProductsToolStripMenuItem"
        Me.ProductsToolStripMenuItem.Size = New System.Drawing.Size(292, 26)
        Me.ProductsToolStripMenuItem.Text = "Products"
        '
        'ProductMasterInformationToolStripMenuItem
        '
        Me.ProductMasterInformationToolStripMenuItem.Name = "ProductMasterInformationToolStripMenuItem"
        Me.ProductMasterInformationToolStripMenuItem.Size = New System.Drawing.Size(292, 26)
        Me.ProductMasterInformationToolStripMenuItem.Text = "Product Master Information"
        '
        'BrandToolStripMenuItem1
        '
        Me.BrandToolStripMenuItem1.Name = "BrandToolStripMenuItem1"
        Me.BrandToolStripMenuItem1.Size = New System.Drawing.Size(292, 26)
        Me.BrandToolStripMenuItem1.Text = "Brand"
        '
        'UnitToolStripMenuItem1
        '
        Me.UnitToolStripMenuItem1.Name = "UnitToolStripMenuItem1"
        Me.UnitToolStripMenuItem1.Size = New System.Drawing.Size(292, 26)
        Me.UnitToolStripMenuItem1.Text = "Unit"
        '
        'ColorToolStripMenuItem1
        '
        Me.ColorToolStripMenuItem1.Name = "ColorToolStripMenuItem1"
        Me.ColorToolStripMenuItem1.Size = New System.Drawing.Size(292, 26)
        Me.ColorToolStripMenuItem1.Text = "Color"
        '
        'CategoriesToolStripMenuItem1
        '
        Me.CategoriesToolStripMenuItem1.Name = "CategoriesToolStripMenuItem1"
        Me.CategoriesToolStripMenuItem1.Size = New System.Drawing.Size(292, 26)
        Me.CategoriesToolStripMenuItem1.Text = "Categories"
        '
        'PurchaseToolStripMenuItem
        '
        Me.PurchaseToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PurchaseOrderToolStripMenuItem2, Me.PurchaseReceiveToolStripMenuItem1, Me.PurchaseOrderRequestToolStripMenuItem, Me.SupplierToolStripMenuItem1, Me.PurchaseReturnToolStripMenuItem})
        Me.PurchaseToolStripMenuItem.Name = "PurchaseToolStripMenuItem"
        Me.PurchaseToolStripMenuItem.Size = New System.Drawing.Size(91, 25)
        Me.PurchaseToolStripMenuItem.Text = "Purchase"
        '
        'PurchaseOrderToolStripMenuItem2
        '
        Me.PurchaseOrderToolStripMenuItem2.Name = "PurchaseOrderToolStripMenuItem2"
        Me.PurchaseOrderToolStripMenuItem2.Size = New System.Drawing.Size(261, 26)
        Me.PurchaseOrderToolStripMenuItem2.Text = "Purchase Order"
        '
        'PurchaseReceiveToolStripMenuItem1
        '
        Me.PurchaseReceiveToolStripMenuItem1.Name = "PurchaseReceiveToolStripMenuItem1"
        Me.PurchaseReceiveToolStripMenuItem1.Size = New System.Drawing.Size(261, 26)
        Me.PurchaseReceiveToolStripMenuItem1.Text = "Purchase Receive"
        '
        'PurchaseOrderRequestToolStripMenuItem
        '
        Me.PurchaseOrderRequestToolStripMenuItem.Name = "PurchaseOrderRequestToolStripMenuItem"
        Me.PurchaseOrderRequestToolStripMenuItem.Size = New System.Drawing.Size(261, 26)
        Me.PurchaseOrderRequestToolStripMenuItem.Text = "Purchase Order Request"
        '
        'SupplierToolStripMenuItem1
        '
        Me.SupplierToolStripMenuItem1.Name = "SupplierToolStripMenuItem1"
        Me.SupplierToolStripMenuItem1.Size = New System.Drawing.Size(261, 26)
        Me.SupplierToolStripMenuItem1.Text = "Suppliers"
        '
        'PurchaseReturnToolStripMenuItem
        '
        Me.PurchaseReturnToolStripMenuItem.Name = "PurchaseReturnToolStripMenuItem"
        Me.PurchaseReturnToolStripMenuItem.Size = New System.Drawing.Size(261, 26)
        Me.PurchaseReturnToolStripMenuItem.Text = "Purchase Return"
        '
        'SalesToolStripMenuItem
        '
        Me.SalesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CustomerToolStripMenuItem1, Me.PricingToolStripMenuItem, Me.CustomerToolStripMenuItem2, Me.CustomerReturnToolStripMenuItem})
        Me.SalesToolStripMenuItem.Name = "SalesToolStripMenuItem"
        Me.SalesToolStripMenuItem.Size = New System.Drawing.Size(61, 25)
        Me.SalesToolStripMenuItem.Text = "Sales"
        '
        'CustomerToolStripMenuItem1
        '
        Me.CustomerToolStripMenuItem1.Name = "CustomerToolStripMenuItem1"
        Me.CustomerToolStripMenuItem1.Size = New System.Drawing.Size(208, 26)
        Me.CustomerToolStripMenuItem1.Text = "Customer Orders"
        '
        'PricingToolStripMenuItem
        '
        Me.PricingToolStripMenuItem.Name = "PricingToolStripMenuItem"
        Me.PricingToolStripMenuItem.Size = New System.Drawing.Size(208, 26)
        Me.PricingToolStripMenuItem.Text = "Pricing"
        '
        'CustomerToolStripMenuItem2
        '
        Me.CustomerToolStripMenuItem2.Name = "CustomerToolStripMenuItem2"
        Me.CustomerToolStripMenuItem2.Size = New System.Drawing.Size(208, 26)
        Me.CustomerToolStripMenuItem2.Text = "Customers"
        '
        'CustomerReturnToolStripMenuItem
        '
        Me.CustomerReturnToolStripMenuItem.Name = "CustomerReturnToolStripMenuItem"
        Me.CustomerReturnToolStripMenuItem.Size = New System.Drawing.Size(208, 26)
        Me.CustomerReturnToolStripMenuItem.Text = "Customer Return"
        '
        'LedgerToolStripMenuItem
        '
        Me.LedgerToolStripMenuItem.Name = "LedgerToolStripMenuItem"
        Me.LedgerToolStripMenuItem.Size = New System.Drawing.Size(74, 25)
        Me.LedgerToolStripMenuItem.Text = "Ledger"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MasterListToolStripMenuItem, Me.InventoryReportsToolStripMenuItem, Me.SalesReportToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(80, 25)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'MasterListToolStripMenuItem
        '
        Me.MasterListToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProductsToolStripMenuItem1, Me.LedgerToolStripMenuItem1, Me.CustomerOrderToolStripMenuItem})
        Me.MasterListToolStripMenuItem.Name = "MasterListToolStripMenuItem"
        Me.MasterListToolStripMenuItem.Size = New System.Drawing.Size(210, 26)
        Me.MasterListToolStripMenuItem.Text = "Master List"
        '
        'ProductsToolStripMenuItem1
        '
        Me.ProductsToolStripMenuItem1.Name = "ProductsToolStripMenuItem1"
        Me.ProductsToolStripMenuItem1.Size = New System.Drawing.Size(200, 26)
        Me.ProductsToolStripMenuItem1.Text = "Products"
        '
        'LedgerToolStripMenuItem1
        '
        Me.LedgerToolStripMenuItem1.Name = "LedgerToolStripMenuItem1"
        Me.LedgerToolStripMenuItem1.Size = New System.Drawing.Size(200, 26)
        Me.LedgerToolStripMenuItem1.Text = "Ledger"
        '
        'CustomerOrderToolStripMenuItem
        '
        Me.CustomerOrderToolStripMenuItem.Name = "CustomerOrderToolStripMenuItem"
        Me.CustomerOrderToolStripMenuItem.Size = New System.Drawing.Size(200, 26)
        Me.CustomerOrderToolStripMenuItem.Text = "Customer Order"
        '
        'InventoryReportsToolStripMenuItem
        '
        Me.InventoryReportsToolStripMenuItem.Name = "InventoryReportsToolStripMenuItem"
        Me.InventoryReportsToolStripMenuItem.Size = New System.Drawing.Size(210, 26)
        Me.InventoryReportsToolStripMenuItem.Text = "Inventory Report"
        '
        'SalesReportToolStripMenuItem
        '
        Me.SalesReportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DailyToolStripMenuItem, Me.MonthlyToolStripMenuItem, Me.TopSalesToolStripMenuItem})
        Me.SalesReportToolStripMenuItem.Name = "SalesReportToolStripMenuItem"
        Me.SalesReportToolStripMenuItem.Size = New System.Drawing.Size(210, 26)
        Me.SalesReportToolStripMenuItem.Text = "Sales Report"
        '
        'DailyToolStripMenuItem
        '
        Me.DailyToolStripMenuItem.Name = "DailyToolStripMenuItem"
        Me.DailyToolStripMenuItem.Size = New System.Drawing.Size(151, 26)
        Me.DailyToolStripMenuItem.Text = "Daily"
        '
        'MonthlyToolStripMenuItem
        '
        Me.MonthlyToolStripMenuItem.Name = "MonthlyToolStripMenuItem"
        Me.MonthlyToolStripMenuItem.Size = New System.Drawing.Size(151, 26)
        Me.MonthlyToolStripMenuItem.Text = "Monthly"
        '
        'TopSalesToolStripMenuItem
        '
        Me.TopSalesToolStripMenuItem.Name = "TopSalesToolStripMenuItem"
        Me.TopSalesToolStripMenuItem.Size = New System.Drawing.Size(151, 26)
        Me.TopSalesToolStripMenuItem.Text = "Top Sales"
        '
        'SystemToolStripMenuItem
        '
        Me.SystemToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem})
        Me.SystemToolStripMenuItem.Name = "SystemToolStripMenuItem"
        Me.SystemToolStripMenuItem.Size = New System.Drawing.Size(77, 25)
        Me.SystemToolStripMenuItem.Text = "System"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(152, 26)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'lblTest
        '
        Me.lblTest.AutoSize = True
        Me.lblTest.BackColor = System.Drawing.Color.Maroon
        Me.lblTest.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTest.ForeColor = System.Drawing.Color.White
        Me.lblTest.Location = New System.Drawing.Point(12, 193)
        Me.lblTest.Name = "lblTest"
        Me.lblTest.Size = New System.Drawing.Size(114, 25)
        Me.lblTest.TabIndex = 5
        Me.lblTest.Text = "Test Mode"
        '
        'Main_form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(926, 429)
        Me.Controls.Add(Me.lblTest)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Name = "Main_form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main Form"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents InventoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductMasterInformationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BrandToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents UnitToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ColorToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents PurchaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PurchaseOrderToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents PurchaseReceiveToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SupplierToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SalesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CustomerToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents PricingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CustomerToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents CategoriesToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SystemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InventoryReportsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalesReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DailyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TopSalesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MasterListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CustomerOrderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductsToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents PurchaseReturnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MonthlyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CustomerReturnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LedgerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LedgerToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents PurchaseOrderRequestToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblTest As Label
End Class
