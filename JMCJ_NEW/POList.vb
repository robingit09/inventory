Public Class POList

    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        PurchaseOrderForm.clearFields()
        PurchaseOrderForm.initialize()
        PurchaseOrderForm.btnSave.Enabled = True
        PurchaseOrderForm.btnSaveAndPrint.Enabled = True
        PurchaseOrderForm.dgvProd.Enabled = True
        PurchaseOrderForm.gpFields.Enabled = True
        PurchaseOrderForm.gpEnterBarcode.Enabled = True
        PurchaseOrderForm.gpEnterProduct.Enabled = True
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
                            delivery_status = "Voided"
                        Case "1"
                            delivery_status = "Pending"
                        Case "2"
                            delivery_status = "Received"

                    End Select
                    Dim row As String() = New String() {id, date_issue, po_no, supplier_name, total_amount, "", delivery_status}
                    dgvPO.Rows.Add(row)
                End While
                For Each row As DataGridViewRow In dgvPO.Rows
                    If row.Cells("delivery_status").Value = "Voided" Then
                        row.DefaultCellStyle.BackColor = Color.OrangeRed
                    End If
                Next
            End If

            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Private Sub POList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadPO("")
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim po_id As Integer = dgvPO.SelectedRows(0).Cells(0).Value
        If dgvPO.SelectedRows.Count = 0 Then
            MsgBox("Please select one record!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        PurchaseOrderForm.initialize()
        PurchaseOrderForm.loadInfo(po_id)
        PurchaseOrderForm.btnSave.Enabled = False
        PurchaseOrderForm.btnSaveAndPrint.Enabled = False
        PurchaseOrderForm.dgvProd.Enabled = False
        PurchaseOrderForm.gpFields.Enabled = False
        PurchaseOrderForm.gpEnterBarcode.Enabled = False
        PurchaseOrderForm.gpEnterProduct.Enabled = False
        PurchaseOrderForm.ShowDialog()
    End Sub

    Private Sub btnVoid_Click(sender As Object, e As EventArgs) Handles btnVoid.Click
        Dim po_id As Integer = dgvPO.SelectedRows(0).Cells(0).Value
        Dim d_status As String = dgvPO.SelectedRows(0).Cells("delivery_status").Value
        If dgvPO.SelectedRows.Count = 0 Then
            MsgBox("Please select one record!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If d_status = "Received" Then
            MsgBox("Already Received.This transaction cannot be voided!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim yn As Integer = MsgBox("Are you sure you want to void this transaction ? ", MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If yn = MsgBoxResult.Yes Then
            Dim db As New DatabaseConnect
            db.update_where("purchase_orders", po_id, "delivery_status", 0)
            db.cmd.Dispose()
            db.con.Close()
            MsgBox("Purchase Order Successfully Void.", MsgBoxStyle.Information)
            loadPO("")
        End If
    End Sub
End Class