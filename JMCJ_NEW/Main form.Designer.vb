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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.lblTest = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.InventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductMasterInformationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BrandToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColorToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CategoriesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StockControlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PhysicalCountToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchaseOrderToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchaseOrderRequestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchaseReceiveToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupplierToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupplierProductsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.TopCustomersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SystemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserGroupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblFullname = New System.Windows.Forms.Label()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InventoryToolStripMenuItem, Me.StockControlToolStripMenuItem, Me.PurchaseToolStripMenuItem, Me.SalesToolStripMenuItem, Me.LedgerToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.SystemToolStripMenuItem, Me.LogoutToolStripMenuItem})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(926, 29)
        Me.MenuStrip2.TabIndex = 4
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'lblTest
        '
        Me.lblTest.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTest.AutoSize = True
        Me.lblTest.BackColor = System.Drawing.Color.White
        Me.lblTest.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTest.ForeColor = System.Drawing.Color.Black
        Me.lblTest.Location = New System.Drawing.Point(83, 402)
        Me.lblTest.Name = "lblTest"
        Me.lblTest.Size = New System.Drawing.Size(79, 18)
        Me.lblTest.TabIndex = 5
        Me.lblTest.Text = "Test mode"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(14, 402)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 18)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Status:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(209, 69)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(705, 278)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'InventoryToolStripMenuItem
        '
        Me.InventoryToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProductsToolStripMenuItem, Me.ProductMasterInformationToolStripMenuItem, Me.BrandToolStripMenuItem1, Me.UnitToolStripMenuItem1, Me.ColorToolStripMenuItem1, Me.CategoriesToolStripMenuItem1})
        Me.InventoryToolStripMenuItem.Image = Global.JMCJ_NEW.My.Resources.Resources.inventory
        Me.InventoryToolStripMenuItem.Name = "InventoryToolStripMenuItem"
        Me.InventoryToolStripMenuItem.Size = New System.Drawing.Size(113, 25)
        Me.InventoryToolStripMenuItem.Text = "Inventory"
        '
        'ProductsToolStripMenuItem
        '
        Me.ProductsToolStripMenuItem.Image = Global.JMCJ_NEW.My.Resources.Resources.product
        Me.ProductsToolStripMenuItem.Name = "ProductsToolStripMenuItem"
        Me.ProductsToolStripMenuItem.Size = New System.Drawing.Size(292, 26)
        Me.ProductsToolStripMenuItem.Text = "Products"
        '
        'ProductMasterInformationToolStripMenuItem
        '
        Me.ProductMasterInformationToolStripMenuItem.Image = Global.JMCJ_NEW.My.Resources.Resources.product
        Me.ProductMasterInformationToolStripMenuItem.Name = "ProductMasterInformationToolStripMenuItem"
        Me.ProductMasterInformationToolStripMenuItem.Size = New System.Drawing.Size(292, 26)
        Me.ProductMasterInformationToolStripMenuItem.Text = "Product Master Information"
        '
        'BrandToolStripMenuItem1
        '
        Me.BrandToolStripMenuItem1.Image = Global.JMCJ_NEW.My.Resources.Resources.brand
        Me.BrandToolStripMenuItem1.Name = "BrandToolStripMenuItem1"
        Me.BrandToolStripMenuItem1.Size = New System.Drawing.Size(292, 26)
        Me.BrandToolStripMenuItem1.Text = "Brand"
        '
        'UnitToolStripMenuItem1
        '
        Me.UnitToolStripMenuItem1.Image = Global.JMCJ_NEW.My.Resources.Resources.unit
        Me.UnitToolStripMenuItem1.Name = "UnitToolStripMenuItem1"
        Me.UnitToolStripMenuItem1.Size = New System.Drawing.Size(292, 26)
        Me.UnitToolStripMenuItem1.Text = "Unit"
        '
        'ColorToolStripMenuItem1
        '
        Me.ColorToolStripMenuItem1.Image = Global.JMCJ_NEW.My.Resources.Resources.color
        Me.ColorToolStripMenuItem1.Name = "ColorToolStripMenuItem1"
        Me.ColorToolStripMenuItem1.Size = New System.Drawing.Size(292, 26)
        Me.ColorToolStripMenuItem1.Text = "Color"
        '
        'CategoriesToolStripMenuItem1
        '
        Me.CategoriesToolStripMenuItem1.Image = Global.JMCJ_NEW.My.Resources.Resources.categories
        Me.CategoriesToolStripMenuItem1.Name = "CategoriesToolStripMenuItem1"
        Me.CategoriesToolStripMenuItem1.Size = New System.Drawing.Size(292, 26)
        Me.CategoriesToolStripMenuItem1.Text = "Categories"
        '
        'StockControlToolStripMenuItem
        '
        Me.StockControlToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PhysicalCountToolStripMenuItem})
        Me.StockControlToolStripMenuItem.Image = Global.JMCJ_NEW.My.Resources.Resources.stock
        Me.StockControlToolStripMenuItem.Name = "StockControlToolStripMenuItem"
        Me.StockControlToolStripMenuItem.Size = New System.Drawing.Size(141, 25)
        Me.StockControlToolStripMenuItem.Text = "Stock Control"
        '
        'PhysicalCountToolStripMenuItem
        '
        Me.PhysicalCountToolStripMenuItem.Image = Global.JMCJ_NEW.My.Resources.Resources.physical_count
        Me.PhysicalCountToolStripMenuItem.Name = "PhysicalCountToolStripMenuItem"
        Me.PhysicalCountToolStripMenuItem.Size = New System.Drawing.Size(193, 26)
        Me.PhysicalCountToolStripMenuItem.Text = "Physical Count"
        '
        'PurchaseToolStripMenuItem
        '
        Me.PurchaseToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PurchaseOrderToolStripMenuItem2, Me.PurchaseOrderRequestToolStripMenuItem, Me.PurchaseReceiveToolStripMenuItem1, Me.SupplierToolStripMenuItem1, Me.SupplierProductsToolStripMenuItem, Me.PurchaseReturnToolStripMenuItem})
        Me.PurchaseToolStripMenuItem.Image = Global.JMCJ_NEW.My.Resources.Resources.purchase
        Me.PurchaseToolStripMenuItem.Name = "PurchaseToolStripMenuItem"
        Me.PurchaseToolStripMenuItem.Size = New System.Drawing.Size(107, 25)
        Me.PurchaseToolStripMenuItem.Text = "Purchase"
        '
        'PurchaseOrderToolStripMenuItem2
        '
        Me.PurchaseOrderToolStripMenuItem2.Image = Global.JMCJ_NEW.My.Resources.Resources.p_o
        Me.PurchaseOrderToolStripMenuItem2.Name = "PurchaseOrderToolStripMenuItem2"
        Me.PurchaseOrderToolStripMenuItem2.Size = New System.Drawing.Size(261, 26)
        Me.PurchaseOrderToolStripMenuItem2.Text = "Purchase Order"
        '
        'PurchaseOrderRequestToolStripMenuItem
        '
        Me.PurchaseOrderRequestToolStripMenuItem.Image = Global.JMCJ_NEW.My.Resources.Resources.p_o
        Me.PurchaseOrderRequestToolStripMenuItem.Name = "PurchaseOrderRequestToolStripMenuItem"
        Me.PurchaseOrderRequestToolStripMenuItem.Size = New System.Drawing.Size(261, 26)
        Me.PurchaseOrderRequestToolStripMenuItem.Text = "Purchase Order Request"
        '
        'PurchaseReceiveToolStripMenuItem1
        '
        Me.PurchaseReceiveToolStripMenuItem1.Image = Global.JMCJ_NEW.My.Resources.Resources.purchase_receive
        Me.PurchaseReceiveToolStripMenuItem1.Name = "PurchaseReceiveToolStripMenuItem1"
        Me.PurchaseReceiveToolStripMenuItem1.Size = New System.Drawing.Size(261, 26)
        Me.PurchaseReceiveToolStripMenuItem1.Text = "Purchase Receive"
        '
        'SupplierToolStripMenuItem1
        '
        Me.SupplierToolStripMenuItem1.Image = Global.JMCJ_NEW.My.Resources.Resources.supplier
        Me.SupplierToolStripMenuItem1.Name = "SupplierToolStripMenuItem1"
        Me.SupplierToolStripMenuItem1.Size = New System.Drawing.Size(261, 26)
        Me.SupplierToolStripMenuItem1.Text = "Suppliers"
        '
        'SupplierProductsToolStripMenuItem
        '
        Me.SupplierProductsToolStripMenuItem.Image = Global.JMCJ_NEW.My.Resources.Resources.product
        Me.SupplierProductsToolStripMenuItem.Name = "SupplierProductsToolStripMenuItem"
        Me.SupplierProductsToolStripMenuItem.Size = New System.Drawing.Size(261, 26)
        Me.SupplierProductsToolStripMenuItem.Text = "Supplier Products"
        '
        'PurchaseReturnToolStripMenuItem
        '
        Me.PurchaseReturnToolStripMenuItem.Image = Global.JMCJ_NEW.My.Resources.Resources.purchase_return
        Me.PurchaseReturnToolStripMenuItem.Name = "PurchaseReturnToolStripMenuItem"
        Me.PurchaseReturnToolStripMenuItem.Size = New System.Drawing.Size(261, 26)
        Me.PurchaseReturnToolStripMenuItem.Text = "Purchase Return"
        '
        'SalesToolStripMenuItem
        '
        Me.SalesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CustomerToolStripMenuItem1, Me.PricingToolStripMenuItem, Me.CustomerToolStripMenuItem2, Me.CustomerReturnToolStripMenuItem})
        Me.SalesToolStripMenuItem.Image = Global.JMCJ_NEW.My.Resources.Resources.sales
        Me.SalesToolStripMenuItem.Name = "SalesToolStripMenuItem"
        Me.SalesToolStripMenuItem.Size = New System.Drawing.Size(77, 25)
        Me.SalesToolStripMenuItem.Text = "Sales"
        '
        'CustomerToolStripMenuItem1
        '
        Me.CustomerToolStripMenuItem1.Image = Global.JMCJ_NEW.My.Resources.Resources.c_o
        Me.CustomerToolStripMenuItem1.Name = "CustomerToolStripMenuItem1"
        Me.CustomerToolStripMenuItem1.Size = New System.Drawing.Size(208, 26)
        Me.CustomerToolStripMenuItem1.Text = "Customer Orders"
        '
        'PricingToolStripMenuItem
        '
        Me.PricingToolStripMenuItem.Image = Global.JMCJ_NEW.My.Resources.Resources.pricing
        Me.PricingToolStripMenuItem.Name = "PricingToolStripMenuItem"
        Me.PricingToolStripMenuItem.Size = New System.Drawing.Size(208, 26)
        Me.PricingToolStripMenuItem.Text = "Pricing"
        '
        'CustomerToolStripMenuItem2
        '
        Me.CustomerToolStripMenuItem2.Image = Global.JMCJ_NEW.My.Resources.Resources.customer
        Me.CustomerToolStripMenuItem2.Name = "CustomerToolStripMenuItem2"
        Me.CustomerToolStripMenuItem2.Size = New System.Drawing.Size(208, 26)
        Me.CustomerToolStripMenuItem2.Text = "Customers"
        '
        'CustomerReturnToolStripMenuItem
        '
        Me.CustomerReturnToolStripMenuItem.Image = Global.JMCJ_NEW.My.Resources.Resources.customer_return
        Me.CustomerReturnToolStripMenuItem.Name = "CustomerReturnToolStripMenuItem"
        Me.CustomerReturnToolStripMenuItem.Size = New System.Drawing.Size(208, 26)
        Me.CustomerReturnToolStripMenuItem.Text = "Customer Return"
        '
        'LedgerToolStripMenuItem
        '
        Me.LedgerToolStripMenuItem.Image = Global.JMCJ_NEW.My.Resources.Resources.ledger
        Me.LedgerToolStripMenuItem.Name = "LedgerToolStripMenuItem"
        Me.LedgerToolStripMenuItem.Size = New System.Drawing.Size(90, 25)
        Me.LedgerToolStripMenuItem.Text = "Ledger"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MasterListToolStripMenuItem, Me.InventoryReportsToolStripMenuItem, Me.SalesReportToolStripMenuItem, Me.TopCustomersToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Image = Global.JMCJ_NEW.My.Resources.Resources.report
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(96, 25)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'MasterListToolStripMenuItem
        '
        Me.MasterListToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProductsToolStripMenuItem1, Me.LedgerToolStripMenuItem1, Me.CustomerOrderToolStripMenuItem})
        Me.MasterListToolStripMenuItem.Image = Global.JMCJ_NEW.My.Resources.Resources.list
        Me.MasterListToolStripMenuItem.Name = "MasterListToolStripMenuItem"
        Me.MasterListToolStripMenuItem.Size = New System.Drawing.Size(210, 26)
        Me.MasterListToolStripMenuItem.Text = "Master List"
        '
        'ProductsToolStripMenuItem1
        '
        Me.ProductsToolStripMenuItem1.Image = Global.JMCJ_NEW.My.Resources.Resources.product
        Me.ProductsToolStripMenuItem1.Name = "ProductsToolStripMenuItem1"
        Me.ProductsToolStripMenuItem1.Size = New System.Drawing.Size(200, 26)
        Me.ProductsToolStripMenuItem1.Text = "Products"
        '
        'LedgerToolStripMenuItem1
        '
        Me.LedgerToolStripMenuItem1.Image = Global.JMCJ_NEW.My.Resources.Resources.ledger
        Me.LedgerToolStripMenuItem1.Name = "LedgerToolStripMenuItem1"
        Me.LedgerToolStripMenuItem1.Size = New System.Drawing.Size(200, 26)
        Me.LedgerToolStripMenuItem1.Text = "Ledger"
        '
        'CustomerOrderToolStripMenuItem
        '
        Me.CustomerOrderToolStripMenuItem.Image = Global.JMCJ_NEW.My.Resources.Resources.c_o
        Me.CustomerOrderToolStripMenuItem.Name = "CustomerOrderToolStripMenuItem"
        Me.CustomerOrderToolStripMenuItem.Size = New System.Drawing.Size(200, 26)
        Me.CustomerOrderToolStripMenuItem.Text = "Customer Order"
        '
        'InventoryReportsToolStripMenuItem
        '
        Me.InventoryReportsToolStripMenuItem.Image = Global.JMCJ_NEW.My.Resources.Resources.inventory
        Me.InventoryReportsToolStripMenuItem.Name = "InventoryReportsToolStripMenuItem"
        Me.InventoryReportsToolStripMenuItem.Size = New System.Drawing.Size(210, 26)
        Me.InventoryReportsToolStripMenuItem.Text = "Inventory Report"
        '
        'SalesReportToolStripMenuItem
        '
        Me.SalesReportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DailyToolStripMenuItem, Me.MonthlyToolStripMenuItem, Me.TopSalesToolStripMenuItem})
        Me.SalesReportToolStripMenuItem.Image = Global.JMCJ_NEW.My.Resources.Resources.sales
        Me.SalesReportToolStripMenuItem.Name = "SalesReportToolStripMenuItem"
        Me.SalesReportToolStripMenuItem.Size = New System.Drawing.Size(210, 26)
        Me.SalesReportToolStripMenuItem.Text = "Sales Report"
        '
        'DailyToolStripMenuItem
        '
        Me.DailyToolStripMenuItem.Image = Global.JMCJ_NEW.My.Resources.Resources.dailysales
        Me.DailyToolStripMenuItem.Name = "DailyToolStripMenuItem"
        Me.DailyToolStripMenuItem.Size = New System.Drawing.Size(152, 26)
        Me.DailyToolStripMenuItem.Text = "Daily"
        '
        'MonthlyToolStripMenuItem
        '
        Me.MonthlyToolStripMenuItem.Image = Global.JMCJ_NEW.My.Resources.Resources.monthlysales
        Me.MonthlyToolStripMenuItem.Name = "MonthlyToolStripMenuItem"
        Me.MonthlyToolStripMenuItem.Size = New System.Drawing.Size(152, 26)
        Me.MonthlyToolStripMenuItem.Text = "Monthly"
        '
        'TopSalesToolStripMenuItem
        '
        Me.TopSalesToolStripMenuItem.Image = Global.JMCJ_NEW.My.Resources.Resources.topsales
        Me.TopSalesToolStripMenuItem.Name = "TopSalesToolStripMenuItem"
        Me.TopSalesToolStripMenuItem.Size = New System.Drawing.Size(152, 26)
        Me.TopSalesToolStripMenuItem.Text = "Top Sales"
        '
        'TopCustomersToolStripMenuItem
        '
        Me.TopCustomersToolStripMenuItem.Image = Global.JMCJ_NEW.My.Resources.Resources.topcustomer
        Me.TopCustomersToolStripMenuItem.Name = "TopCustomersToolStripMenuItem"
        Me.TopCustomersToolStripMenuItem.Size = New System.Drawing.Size(210, 26)
        Me.TopCustomersToolStripMenuItem.Text = "Top Customers"
        '
        'SystemToolStripMenuItem
        '
        Me.SystemToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem, Me.UserToolStripMenuItem})
        Me.SystemToolStripMenuItem.Image = Global.JMCJ_NEW.My.Resources.Resources.system
        Me.SystemToolStripMenuItem.Name = "SystemToolStripMenuItem"
        Me.SystemToolStripMenuItem.Size = New System.Drawing.Size(93, 25)
        Me.SystemToolStripMenuItem.Text = "System"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Image = Global.JMCJ_NEW.My.Resources.Resources.settings
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(142, 26)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'UserToolStripMenuItem
        '
        Me.UserToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UsersToolStripMenuItem, Me.UserGroupToolStripMenuItem})
        Me.UserToolStripMenuItem.Image = Global.JMCJ_NEW.My.Resources.Resources.users
        Me.UserToolStripMenuItem.Name = "UserToolStripMenuItem"
        Me.UserToolStripMenuItem.Size = New System.Drawing.Size(142, 26)
        Me.UserToolStripMenuItem.Text = "User"
        '
        'UsersToolStripMenuItem
        '
        Me.UsersToolStripMenuItem.Image = Global.JMCJ_NEW.My.Resources.Resources.users
        Me.UsersToolStripMenuItem.Name = "UsersToolStripMenuItem"
        Me.UsersToolStripMenuItem.Size = New System.Drawing.Size(172, 26)
        Me.UsersToolStripMenuItem.Text = "Users"
        '
        'UserGroupToolStripMenuItem
        '
        Me.UserGroupToolStripMenuItem.Image = Global.JMCJ_NEW.My.Resources.Resources.user_group
        Me.UserGroupToolStripMenuItem.Name = "UserGroupToolStripMenuItem"
        Me.UserGroupToolStripMenuItem.Size = New System.Drawing.Size(172, 26)
        Me.UserGroupToolStripMenuItem.Text = "User Groups"
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Image = Global.JMCJ_NEW.My.Resources.Resources.logout
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(92, 25)
        Me.LogoutToolStripMenuItem.Text = "Logout"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(9, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 19)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Current User:"
        '
        'lblFullname
        '
        Me.lblFullname.AutoSize = True
        Me.lblFullname.BackColor = System.Drawing.Color.White
        Me.lblFullname.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFullname.ForeColor = System.Drawing.Color.Black
        Me.lblFullname.Location = New System.Drawing.Point(117, 113)
        Me.lblFullname.Name = "lblFullname"
        Me.lblFullname.Size = New System.Drawing.Size(70, 19)
        Me.lblFullname.TabIndex = 8
        Me.lblFullname.Text = "Fullname"
        '
        'Main_form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(926, 429)
        Me.Controls.Add(Me.lblFullname)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTest)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.MenuStrip2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Name = "Main_form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main Form"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents TopCustomersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SupplierProductsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StockControlToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PhysicalCountToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UsersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UserGroupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogoutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblFullname As Label
End Class
