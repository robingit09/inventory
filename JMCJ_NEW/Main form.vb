﻿Public Class Main_form

    Public current_user_id As Integer = 1
    Private Sub ProductToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ProductList.ShowDialog()
    End Sub

    Private Sub CategoriesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CategoryList.ShowDialog()
    End Sub

    Private Sub UnitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        UnitList.ShowDialog()
    End Sub

    Private Sub CustomerOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        CustomerOrder.ShowDialog()
    End Sub

    Private Sub Main_form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModelFunction.deleteData()

        If ModuleSettings.forTest = 1 Then
            MsgBox("You are in a Test Mode", MsgBoxStyle.Exclamation, "System Mode")
        Else

        End If



        lblDate.Text = DateTime.Now.ToLongDateString
        lblTime.Text = DateTime.Now.ToLongTimeString


        Timer1.Start()

        If ModuleSettings.forTest = 1 Then
            lblTest.Text = "For testing"
            lblTest.ForeColor = Drawing.Color.Red
        Else
            lblTest.Text = "Live"
            lblTest.ForeColor = Drawing.Color.Green
        End If



        ' check user access
        Dim user_group_id As Integer = CInt(New DatabaseConnect().get_by_val("users", Me.current_user_id, "id", "user_group"))
        If user_group_id = 1 Then
            SystemToolStripMenuItem.Visible = True
        Else
            SystemToolStripMenuItem.Visible = False
        End If

        'check user view access
        'product
        If ModelFunction.check_access(1, 2) = 1 Then
            ProductsToolStripMenuItem.Visible = True
        Else
            ProductsToolStripMenuItem.Visible = False
        End If

        'product master info
        If ModelFunction.check_access(2, 2) = 1 Then
            ProductMasterInformationToolStripMenuItem.Visible = True
        Else
            ProductMasterInformationToolStripMenuItem.Visible = False
        End If

        'brand  info
        If ModelFunction.check_access(3, 2) = 1 Then
            BrandToolStripMenuItem1.Visible = True
        Else
            BrandToolStripMenuItem1.Visible = False
        End If

        'unit  info
        If ModelFunction.check_access(4, 2) = 1 Then
            UnitToolStripMenuItem1.Visible = True
        Else
            UnitToolStripMenuItem1.Visible = False
        End If

        'color  info
        If ModelFunction.check_access(5, 2) = 1 Then
            ColorToolStripMenuItem1.Visible = True
        Else
            ColorToolStripMenuItem1.Visible = False
        End If


        'categories  info
        If ModelFunction.check_access(6, 2) = 1 Then
            CategoriesToolStripMenuItem1.Visible = True
        Else
            CategoriesToolStripMenuItem1.Visible = False
        End If

        If ModelFunction.check_access(1, 2) <> 1 And ModelFunction.check_access(2, 2) <> 1 And ModelFunction.check_access(3, 2) <> 1 And ModelFunction.check_access(4, 2) <> 1 And ModelFunction.check_access(5, 2) <> 1 And ModelFunction.check_access(6, 2) <> 1 Then
            InventoryToolStripMenuItem.Visible = False

        End If

        'physical count info
        If ModelFunction.check_access(7, 2) = 1 Then
            PhysicalCountToolStripMenuItem.Visible = True
        Else
            PhysicalCountToolStripMenuItem.Visible = False
        End If

        'po  info
        If ModelFunction.check_access(8, 2) = 1 Then
            PurchaseOrderToolStripMenuItem2.Visible = True
        Else
            PurchaseOrderToolStripMenuItem2.Visible = False
        End If

        'por  info
        If ModelFunction.check_access(9, 2) = 1 Then
            PurchaseOrderRequestToolStripMenuItem.Visible = True
        Else
            PurchaseOrderRequestToolStripMenuItem.Visible = False
        End If


        'preceive  info
        If ModelFunction.check_access(10, 2) = 1 Then
            PurchaseReceiveToolStripMenuItem1.Visible = True
        Else
            PurchaseReceiveToolStripMenuItem1.Visible = False
        End If

        'suppliers  info
        If ModelFunction.check_access(11, 2) = 1 Then
            SupplierToolStripMenuItem1.Visible = True
        Else
            SupplierToolStripMenuItem1.Visible = False
        End If

        'supplier products info
        If ModelFunction.check_access(12, 2) = 1 Then
            SupplierProductsToolStripMenuItem.Visible = True
        Else
            SupplierProductsToolStripMenuItem.Visible = False
        End If

        'preturn info
        If ModelFunction.check_access(13, 2) = 1 Then
            PurchaseReturnToolStripMenuItem.Visible = True
        Else
            PurchaseReturnToolStripMenuItem.Visible = False
        End If

        'customer orders info
        If ModelFunction.check_access(14, 2) = 1 Then
            CustomerToolStripMenuItem1.Visible = True
        Else
            CustomerToolStripMenuItem1.Visible = False
        End If

        'pricing info
        If ModelFunction.check_access(15, 2) = 1 Then
            PricingToolStripMenuItem.Visible = True
        Else
            PricingToolStripMenuItem.Visible = False
        End If

        'customers info
        If ModelFunction.check_access(16, 2) = 1 Then
            CustomerToolStripMenuItem2.Visible = True
        Else
            CustomerToolStripMenuItem2.Visible = False
        End If

        'customer return info
        If ModelFunction.check_access(17, 2) = 1 Then
            CustomerReturnToolStripMenuItem.Visible = True
        Else
            CustomerReturnToolStripMenuItem.Visible = False
        End If

        'ledger info
        If ModelFunction.check_access(18, 2) = 1 Then
            LedgerToolStripMenuItem.Visible = True
        Else
            LedgerToolStripMenuItem.Visible = False
        End If


        'reports info
        If ModelFunction.check_access(19, 2) = 1 Then
            ReportsToolStripMenuItem.Visible = True
        Else
            ReportsToolStripMenuItem.Visible = False
        End If


        'remove access
        ProductMasterInformationToolStripMenuItem.Visible = False
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblDate.Text = DateTime.Now.ToLongDateString
        lblTime.Text = DateTime.Now.ToLongTimeString
    End Sub

    Private Sub SupplierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SupplierList.ShowDialog()
    End Sub

    Private Sub PurchaseOrderToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        POList.btnAddNew.Enabled = True
        POList.ShowDialog()

    End Sub

    Private Sub BrandToolStripMenuItem_Click(sender As Object, e As EventArgs)
        BrandList.ShowDialog()
    End Sub

    Private Sub CustomerToolStripMenuItem_Click(sender As Object, e As EventArgs)
        CustomerList.ShowDialog()
    End Sub

    Private Sub PriceListToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim cp As New CustomerPriceList
        CustomerPriceList.dgvPriceList.Rows.Clear()
        CustomerPriceList.selectedCustomer = 0
        CustomerPriceList.ShowDialog()
        CustomerPriceList.cbCustomer.SelectedIndex = 0
    End Sub

    Private Sub ColorToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ColorList.ShowDialog()
    End Sub

    Private Sub PurchaseReceiveToolStripMenuItem_Click(sender As Object, e As EventArgs)
        PurchaseReceiveForm.ShowDialog()
    End Sub

    Private Sub ProductMasterInformationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductMasterInformationToolStripMenuItem.Click
        ProductMaster.ShowDialog()
    End Sub

    Private Sub ProductsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductsToolStripMenuItem.Click
        ProductList.ShowDialog()
    End Sub

    Private Sub BrandToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BrandToolStripMenuItem1.Click
        BrandList.ShowDialog()
    End Sub

    Private Sub UnitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UnitToolStripMenuItem1.Click
        UnitList.ShowDialog()
    End Sub

    Private Sub ColorToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ColorToolStripMenuItem1.Click
        ColorList.ShowDialog()
    End Sub

    Private Sub PurchaseOrderToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles PurchaseOrderToolStripMenuItem2.Click
        POList.ShowDialog()
    End Sub

    Private Sub PurchaseReceiveToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PurchaseReceiveToolStripMenuItem1.Click
        PurchaseReceive.ShowDialog()
    End Sub

    Private Sub SupplierToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SupplierToolStripMenuItem1.Click
        SupplierList.ShowDialog()
    End Sub

    Private Sub CustomerToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CustomerToolStripMenuItem1.Click
        CustomerOrder.ShowDialog()
    End Sub

    Private Sub CustomerToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles CustomerToolStripMenuItem2.Click
        CustomerList.ShowDialog()
    End Sub

    Private Sub PricingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PricingToolStripMenuItem.Click
        CustomerPriceList.dgvPriceList.Rows.Clear()
        CustomerPriceList.ShowDialog()
    End Sub

    Private Sub CategoriesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CategoriesToolStripMenuItem1.Click
        CategoryList.ShowDialog()
    End Sub

    Private Sub InventoryReportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InventoryReportsToolStripMenuItem.Click
        InventoryReport.ShowDialog()
    End Sub

    Private Sub DailyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DailyToolStripMenuItem.Click
        DailySalesReports.ShowDialog()
    End Sub

    Private Sub TopSalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TopSalesToolStripMenuItem.Click
        TopSalesReports.ShowDialog()
    End Sub

    Private Sub CustomerOrderToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles CustomerOrderToolStripMenuItem.Click
        COMasterList.ShowDialog()
    End Sub

    Private Sub ProductsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ProductsToolStripMenuItem1.Click
        ProductReports.ShowDialog()
    End Sub

    Private Sub PurchaseReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurchaseReturnToolStripMenuItem.Click
        PurchaseReturn.ShowDialog()
    End Sub

    Private Sub MonthlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MonthlyToolStripMenuItem.Click
        MonthlySalesReports.ShowDialog()
    End Sub

    Private Sub CustomerReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerReturnToolStripMenuItem.Click
        CustomerReturn.ShowDialog()
    End Sub

    Private Sub LedgerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LedgerToolStripMenuItem.Click
        Ledger.ShowDialog()
    End Sub

    Private Sub LedgerToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LedgerToolStripMenuItem1.Click
        LedgerReports.ShowDialog()
    End Sub

    Private Sub PurchaseOrderRequestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurchaseOrderRequestToolStripMenuItem.Click
        PurchaseOrderRequest.ShowDialog()
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Settings.ShowDialog()
    End Sub

    Private Sub TopCustomersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TopCustomersToolStripMenuItem.Click
        TopCustomerReports.ShowDialog()
    End Sub

    Private Sub SupplierProductsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupplierProductsToolStripMenuItem.Click
        SupplierProducts.from_module = 0
        SupplierProducts.initialize()
        SupplierProducts.cbSupplier.Enabled = True
        SupplierProducts.ShowDialog()
    End Sub

    Private Sub PhysicalCountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PhysicalCountToolStripMenuItem.Click

        PhysicalCount.ShowDialog()

    End Sub

    Private Sub UsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsersToolStripMenuItem.Click
        Users.ShowDialog()
    End Sub

    Private Sub UserGroupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserGroupToolStripMenuItem.Click
        UserGroups.ShowDialog()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click

        Me.Close()

    End Sub
End Class