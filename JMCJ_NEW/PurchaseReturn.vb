Public Class PurchaseReturn
    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        btnAddNew.Enabled = False
        PurchaseReturnForm.initialize()
        PurchaseReturnForm.ShowDialog()
        btnAddNew.Enabled = True
    End Sub

    Public Sub loadPO(ByVal query As String)
        dgvPO.Rows.Clear()
        Dim dbPO As New DatabaseConnect
        With dbPO
            .selectByQuery("Select * from purchase_return order by id desc")
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr("id")
                    Dim date_issue As String = .dr("pr_date")
                    Dim pr_no As String = .dr("pr_no")
                    Dim supplier_id As Integer = CInt(.dr("supplier_id"))
                    Dim supplier_name As String = New DatabaseConnect().get_by_id("suppliers", supplier_id, "supplier_name")
                    Dim total_amount As String = Val(.dr("total_amount")).ToString("N2")
                    Dim delivery_status As String = ""

                    Select Case .dr("status")
                        Case "0"
                            delivery_status = "Deleted"
                        Case "1"
                            delivery_status = "Active"
                        Case "2"
                            delivery_status = "Voided"

                    End Select
                    Dim row As String() = New String() {id, date_issue, pr_no, supplier_name, total_amount, "", delivery_status}
                    dgvPO.Rows.Add(row)
                End While
                For Each row As DataGridViewRow In dgvPO.Rows
                    If row.Cells("status").Value = "Voided" Then
                        row.DefaultCellStyle.BackColor = Color.OrangeRed
                    End If
                Next
            End If

            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub
End Class