Public Class Main_form



    Private Sub ProductToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductToolStripMenuItem.Click
        ProductList.ShowDialog()
    End Sub

    Private Sub CategoriesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoriesToolStripMenuItem.Click
        CategoryList.ShowDialog()
    End Sub

    Private Sub UnitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnitToolStripMenuItem.Click
        UnitList.ShowDialog()
    End Sub

    Private Sub CustomerOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerOrderToolStripMenuItem.Click
        'CustomerOrder.ShowDialog()
        LedgerList.ShowDialog()
    End Sub

    Private Sub Main_form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblDate.Text = DateTime.Now.ToLongDateString
        lblTime.Text = DateTime.Now.ToLongTimeString
        PictureBox1.BorderStyle = BorderStyle.None

        Timer1.Start()
    End Sub

    Private Sub lblDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDate.Click

    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblDate.Text = DateTime.Now.ToLongDateString
        lblTime.Text = DateTime.Now.ToLongTimeString
    End Sub

    Private Sub SupplierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierToolStripMenuItem.Click
        SupplierList.ShowDialog()
    End Sub

    Private Sub PurchaseOrderToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseOrderToolStripMenuItem1.Click
        POList.btnAddNew.Enabled = True
        POList.ShowDialog()

    End Sub

    Private Sub BrandToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BrandToolStripMenuItem.Click
        BrandList.ShowDialog()
    End Sub

    Private Sub CustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerToolStripMenuItem.Click
        CustomerList.ShowDialog()
    End Sub

    Private Sub PriceListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PriceListToolStripMenuItem.Click
        Dim cp As New CustomerPriceList
        CustomerPriceList.dgvPriceList.Rows.Clear()
        CustomerPriceList.selectedCustomer = 0
        CustomerPriceList.ShowDialog()
        CustomerPriceList.cbCustomer.SelectedIndex = 0
    End Sub

    Private Sub ColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColorToolStripMenuItem.Click
        ColorList.ShowDialog()
    End Sub
End Class