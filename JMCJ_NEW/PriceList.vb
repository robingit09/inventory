Public Class CustomerPriceList

    Public selectedCustomer As Integer = 0

    Private Sub getCustomer()
        cbCustomer.DataSource = Nothing
        cbCustomer.Items.Clear()

        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(0, "Select Customer")
        Dim dbcustomer As New DatabaseConnect
        With dbcustomer
            .selectByQuery("Select id,company from company where status = 1 order by company")
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr.GetValue(0)
                    Dim customer As String = .dr.GetValue(1)
                    comboSource.Add(id, customer)
                End While

                cbCustomer.DataSource = New BindingSource(comboSource, Nothing)
                cbCustomer.DisplayMember = "Value"
                cbCustomer.ValueMember = "Key"
            End If

            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
    End Sub

    Private Sub loadproduct(ByVal category As String)
        'cbProduct.DataSource = Nothing
        'cbProduct.Items.Clear()

        'Dim db As New DatabaseConnect
        'With db
        '    .dbConnect()
        '    .cmd.Connection = .con
        '    .cmd.CommandType = CommandType.Text
        '    .cmd.CommandText = "SELECT distinct id,name from products where status <> 0 and category like '%" & category & "%'"
        '    .dr = .cmd.ExecuteReader

        '    Dim comboSource As New Dictionary(Of String, String)()
        '    comboSource.Add(0, "Select Product")
        '    While .dr.Read
        '        Dim id As Integer = CInt(.dr.GetValue(0))
        '        Dim prod As String = .dr.GetValue(1)
        '        comboSource.Add(id, prod)
        '    End While
        '    cbProduct.DataSource = New BindingSource(comboSource, Nothing)
        '    cbProduct.DisplayMember = "Value"
        '    cbProduct.ValueMember = "Key"

        '    .dr.Close()
        '    .cmd.Dispose()
        '    .con.Close()

        'End With
    End Sub



    Private Sub Pricing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getCustomer()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If cbCustomer.SelectedIndex > 0 Then
            AddProductForm.selectedCustomer = Me.selectedCustomer
            AddProductForm.ShowDialog()
        Else
            selectedCustomer = 0
            AddProductForm.selectedCustomer = 0
            MsgBox("Please select customer", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub cbCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCustomer.SelectedIndexChanged
        If cbCustomer.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedCustomer = key
        End If
    End Sub
End Class



