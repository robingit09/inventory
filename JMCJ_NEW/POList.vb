Public Class POList

    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        PurchaseOrderForm.clearFields()
        PurchaseOrderForm.ShowDialog()
    End Sub

    Public Sub loadPO(ByVal query As String)
        dgvPO.Rows.Clear()
        Dim dbPO As New DatabaseConnect
        With dbPO
            .selectByQuery("Select * from purchase_orders order by id desc")
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr("id")
                    Dim date_issue As String = .dr("po_date")
                    Dim po_no As String = .dr("po_no")
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
                    Dim row As String() = New String() {id, date_issue, po_no, supplier_name, total_amount, "", delivery_status}
                    dgvPO.Rows.Add(row)
                End While
            End If

            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Private Sub POList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadPO("")
    End Sub
End Class