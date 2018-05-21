Public Class POList

    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click

        PurchaseOrderForm.ShowDialog()
    End Sub

    Private Sub POList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class