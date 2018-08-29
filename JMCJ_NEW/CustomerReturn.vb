Public Class CustomerReturn
    Private Sub CustomerReturn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initialize()
    End Sub

    Public Sub initialize()
        getCustomerList("")
        getInvoiceNo("")
    End Sub

    Public Sub getCustomerList(ByVal query As String)

        cbCustomer.DataSource = Nothing
        cbCustomer.Items.Clear()
        Dim db As New DatabaseConnect

        With db
            If query = "" Then
                .selectByQuery("select company,ID from company where status <> 0 order by company")
            Else

            End If

            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "Select Customer")
            While db.dr.Read
                Dim cus As String = db.dr.GetValue(0)
                Dim id As String = db.dr.GetValue(1)
                comboSource.Add(id, cus)
            End While

            cbCustomer.DataSource = New BindingSource(comboSource, Nothing)
            cbCustomer.DisplayMember = "Value"
            cbCustomer.ValueMember = "Key"
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With

    End Sub

    Public Sub getInvoiceNo(ByVal query As String)

        cbInvoiceNo.DataSource = Nothing
        cbInvoiceNo.Items.Clear()
        Dim db As New DatabaseConnect

        With db
            If query = "" Then
                .selectByQuery("select invoice_no,ID from ledger where status <> 0 order by created_at desc")
            Else

            End If

            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "Select Invoice No")
            While db.dr.Read
                Dim cus As String = db.dr.GetValue(0)
                Dim id As String = db.dr.GetValue(1)
                comboSource.Add(id, cus)
            End While

            cbInvoiceNo.DataSource = New BindingSource(comboSource, Nothing)
            cbInvoiceNo.DisplayMember = "Value"
            cbInvoiceNo.ValueMember = "Key"
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With

    End Sub
End Class