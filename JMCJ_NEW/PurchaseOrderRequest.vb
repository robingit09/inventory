Public Class PurchaseOrderRequest
    Private Sub PurchaseOrderRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadPOR("")
    End Sub
    Public Sub loadPOR(ByVal query As String)
        dgvPO.Rows.Clear()
        Dim dbPO As New DatabaseConnect
        With dbPO
            If query = "" Then
                .selectByQuery("Select * from purchase_orders_request order by id desc")
            Else
                .selectByQuery(query)
            End If

            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr("id")
                    Dim por_no As String = .dr("por_no")
                    Dim supplier_id As Integer = CInt(.dr("supplier"))
                    Dim supplier_name As String = New DatabaseConnect().get_by_id("suppliers", supplier_id, "supplier_name")
                    Dim recorded_date As String = Convert.ToDateTime(.dr("por_date")).ToString("MM-dd-yy")
                    Dim total_amount As String = Val(.dr("total_amount")).ToString("N2")
                    Dim process_by As String = If(IsDBNull(.dr("processed_by")), "0", .dr("processed_by"))
                    process_by = New DatabaseConnect().get_by_id("users", CInt(process_by), "first_name")
                    Dim status As String = ""

                    Select Case .dr("status")
                        Case "0"
                            status = "Voided"
                        Case "1"
                            status = "Active"
                        Case Else

                            status = ""

                    End Select
                    Dim row As String() = New String() {id, recorded_date, por_no, supplier_name, total_amount, process_by, status}
                    dgvPO.Rows.Add(row)
                End While
                For Each row As DataGridViewRow In dgvPO.Rows
                    If row.Cells("status").Value = "Deleted" Then
                        row.DefaultCellStyle.BackColor = Color.OrangeRed
                    End If
                Next
            End If

            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        'PurchaseOrderRequestForm.clearFields()
        btnAddNew.Enabled = False
        PurchaseOrderRequestForm.clearFields()
        PurchaseOrderRequestForm.initialize()
        PurchaseOrderRequestForm.btnSave.Enabled = True
        'PurchaseOrderRequestForm.btnSaveAndPrint.Enabled = True
        PurchaseOrderRequestForm.dgvProd.Enabled = True
        'PurchaseOrderRequestForm.gpFields.Enabled = True
        PurchaseOrderRequestForm.gpEnterBarcode.Enabled = True
        PurchaseOrderRequestForm.gpEnterProduct.Enabled = True
        PurchaseOrderRequestForm.ShowDialog()
        btnAddNew.Enabled = True
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If dgvPO.SelectedRows.Count = 0 Then
            MsgBox("Please select one record!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Dim por_id As Integer = dgvPO.SelectedRows(0).Cells(0).Value
        PurchaseOrderRequestForm.initialize()
        PurchaseOrderRequestForm.loadInfo(por_id)
        PurchaseOrderRequestForm.btnSave.Enabled = False
        PurchaseOrderRequestForm.dgvProd.Enabled = False
        PurchaseOrderRequestForm.gpEnterBarcode.Enabled = False
        PurchaseOrderRequestForm.gpEnterProduct.Enabled = False
        PurchaseOrderRequestForm.ShowDialog()
    End Sub
End Class