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
End Class