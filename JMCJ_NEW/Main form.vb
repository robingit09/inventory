Public Class Main_form

    Public auth_login As Integer = 1
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
        'CustomerOrder.ShowDialog()
        CustomerOrder.ShowDialog()
    End Sub

    Private Sub Main_form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModelFunction.deleteData()
        lblDate.Text = DateTime.Now.ToLongDateString
        lblTime.Text = DateTime.Now.ToLongTimeString
        PictureBox1.BorderStyle = BorderStyle.None

        Timer1.Start()
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
End Class