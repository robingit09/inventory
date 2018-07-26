Public Class PurchaseReceive
    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        PurchaseReceiveForm.clearFields()
        PurchaseReceiveForm.ShowDialog()
    End Sub

    Public Sub loadPR(ByVal query As String)
        dgvPR.Rows.Clear()
        Dim dbPO As New DatabaseConnect
        With dbPO
            .selectByQuery("Select * from purchase_receive order by pr_date desc")
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr("id")
                    Dim date_issue As String = .dr("pr_date")
                    Dim pr_no As String = .dr("pr_no")
                    Dim po_no As String = New DatabaseConnect().get_by_id("purchase_orders", Val(.dr("purchase_order_id")), "po_no")
                    Dim supplier_id As Integer = CInt(.dr("supplier"))
                    Dim supplier_name As String = New DatabaseConnect().get_by_id("suppliers", supplier_id, "supplier_name")
                    Dim total_amount As String = Val(.dr("total_amount")).ToString("N2")
                    Dim delivery_status As String = ""

                    Select Case .dr("delivery_status")
                        Case "0"
                            delivery_status = "Void"
                        Case "1"
                            delivery_status = "Pending"
                        Case "2"
                            delivery_status = "Received"

                    End Select
                    Dim row As String() = New String() {id, date_issue, pr_no, po_no, supplier_name, total_amount, "", delivery_status}
                    dgvPR.Rows.Add(row)
                End While
            End If

            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Private Sub PurchaseReceive_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadPR("")

    End Sub
End Class