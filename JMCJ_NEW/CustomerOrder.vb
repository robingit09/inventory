Public Class CustomerOrder
    Private Sub CustomerOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadCustomer("")
    End Sub

    Public Sub loadCustomer(ByVal fQuery As String)
        dgvCO.Rows.Clear()
        Try
            Dim db As New DatabaseConnect
            With db
                .selectByQuery("SELECT co.id,co.invoice_no,co.received_by,co.delivered_by,co.net_amount,co.total_amount,co.payment_method,co.terms,co.date_issue,c.company as customer,co.status FROM customer_orders as co 
                left join company as c on c.id = co.customer where co.status <> 0")

                If .dr.HasRows Then
                    While .dr.Read
                        Dim id As String = .dr("id").ToString
                        Dim date_issue As String = .dr("date_issue").ToShortDateString
                        Dim invoice_no As String = .dr("invoice_no").ToString
                        Dim customer As String = .dr("customer").ToString
                        Dim received_by As String = .dr("received_by").ToString
                        Dim delivered_by As String = .dr("delivered_by").ToString
                        Dim total_amount As String = .dr("total_amount").ToString
                        Dim payment_method As String = .dr("payment_method").ToString

                        Select Case payment_method
                            Case "0"
                                payment_method = "Cash"
                            Case "1"
                                payment_method = "C.O.D"
                            Case "2"
                                payment_method = "Credit"
                            Case "3"
                                payment_method = "Post Dated"
                        End Select

                        Dim terms As String = .dr("terms").ToString
                        Dim status As String = .dr("status").ToString

                        Select Case status
                            Case "0"
                                status = "Deleted"
                            Case "1"
                                status = "Active"
                            Case "2"
                                status = "Inactive"
                        End Select

                        Dim row As String() = New String() {id, date_issue, invoice_no, customer, received_by, delivered_by, total_amount, payment_method, terms & " Days", status}
                        dgvCO.Rows.Add(row)
                    End While
                End If
                .dr.Close()
                .cmd.Dispose()
                .con.Close()
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click

        CustomerOrderForm.populateCustomer()
        CustomerOrderForm.populateCategory()
        CustomerOrderForm.dgvProd.Rows.Clear()
        CustomerOrderForm.clearSelection()
        CustomerOrderForm.ShowDialog()

    End Sub
End Class