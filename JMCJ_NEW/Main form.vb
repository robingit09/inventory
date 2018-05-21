Public Class Main_form

   

    Private Sub CustomerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerToolStripMenuItem.Click
        frmCustomerList.ShowDialog()

    End Sub

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
        CustomerOrderForm.ShowDialog()
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

    Private Sub PriceListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PriceListToolStripMenuItem.Click
        Pricing.ShowDialog()
    End Sub
End Class