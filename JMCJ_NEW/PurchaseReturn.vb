Public Class PurchaseReturn
    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        PurchaseReturnForm.initialize()
        PurchaseReturnForm.ShowDialog()
    End Sub
End Class