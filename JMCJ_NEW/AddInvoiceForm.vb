Public Class AddInvoiceForm
    Public selectedCustomer As Integer = 0
    Public selectedLedger As Integer = 0
    Private Sub AddInvoiceForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCustomer.Text = New DatabaseConnect().get_by_id("company", selectedCustomer, "company")
        loadList("select * from customer_orders where customer_id = " & selectedCustomer & " and ledger_id <> " & selectedLedger)
    End Sub

    Public Sub loadList(ByVal query As String)
        dgvProd.Rows.Clear()
        Dim db As New DatabaseConnect
        With db
            If query = "" Then
                .selectByQuery("Select * from customer_orders order by id desc")
            Else
                .selectByQuery(query)
            End If

            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr("id")

                    Dim date_issue As String = Convert.ToDateTime(.dr("date_issue")).ToString("MM-dd-yy")
                    Dim customer As String = New DatabaseConnect().get_by_id("company", .dr("customer_id"), "company")
                    Dim invoice As String = .dr("invoice_no")
                    Dim amount As String = Val(.dr("amount")).ToString("N2")
                    Dim amount_paid As String = Val(.dr("amount_paid")).ToString("N2")
                    Dim payment_status As String = .dr("payment_status")
                    Dim delivery_status As String = .dr("delivery_status")


                    Select Case delivery_status
                        Case "0"
                            delivery_status = "Voided"
                        Case "1"
                            delivery_status = "Delivered"
                    End Select


                    Dim row As String() = New String() {id, True, date_issue, customer, invoice, amount, amount_paid, payment_status, delivery_status}
                    dgvProd.Rows.Add(row)
                End While
                For Each row As DataGridViewRow In dgvProd.Rows
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

    Private Sub ckSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles ckSelectAll.CheckedChanged
        If dgvProd.Rows.Count > 0 Then
            If ckSelectAll.Checked = True Then
                For Each item As DataGridViewRow In Me.dgvProd.Rows
                    If dgvProd.Rows(item.Index).Cells(3).Value <> "" Then
                        dgvProd.Rows(item.Index).Cells(1).Value = True
                    End If
                Next
            Else
                For Each item As DataGridViewRow In Me.dgvProd.Rows
                    If dgvProd.Rows(item.Index).Cells(3).Value <> "" Then
                        dgvProd.Rows(item.Index).Cells(1).Value = False
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub btnAddToList_Click(sender As Object, e As EventArgs) Handles btnAddToList.Click
        Dim has_selected As Boolean = False
        If dgvProd.Rows.Count > 0 Then
            For Each item As DataGridViewRow In Me.dgvProd.Rows
                If dgvProd.Rows(item.Index).Cells(1).Value = True Then
                    has_selected = True
                    Exit For
                End If
            Next
        End If

        If (has_selected) Then
            For Each item As DataGridViewRow In Me.dgvProd.Rows
                If dgvProd.Rows(item.Index).Cells(1).Value = True Then
                    Dim co_id As String = dgvProd.Rows(item.Index).Cells("id").Value

                    '// **validate
                    Dim isInList As Boolean = False
                    For Each item2 As DataGridViewRow In LedgerForm.dgvInvoiceList.Rows
                        If LedgerForm.dgvInvoiceList.Rows(item.Index).Cells("id").Value = co_id Then
                            isInList = True
                        End If
                    Next

                    If isInList = False Then
                        Dim dbco As New DatabaseConnect
                        With dbco
                            .selectByQuery("Select * from customer_orders where id = " & co_id)
                            If .dr.Read Then
                                Dim invoice As String = .dr("invoice_no")
                                Dim date_issue As String = .dr("date_issue")
                                Dim amount As String = Val(.dr("amount")).ToString("N2")
                                Dim amount_paid As String = Val(.dr("amount_paid")).ToString("N2")
                                Dim row As String() = New String() {co_id, invoice, date_issue, amount, amount_paid, "Remove"}
                                LedgerForm.dgvInvoiceList.Rows.Add(row)
                            End If
                            .dr.Close()
                            .cmd.Dispose()
                            .con.Close()
                        End With
                    End If
                End If
            Next
            Me.Close()
        Else
            MsgBox("Please select invoice!", MsgBoxStyle.Critical)
        End If
    End Sub
End Class