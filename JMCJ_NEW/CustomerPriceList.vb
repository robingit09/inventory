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
            getList("", selectedCustomer)
        End If
    End Sub

    Public Sub getList(ByVal query As String, ByVal customer_id As Integer)
        dgvPriceList.Rows.Clear()
        Dim db As New DatabaseConnect
        With db
            If query = "" Then
                .selectByQuery("Select distinct pu.product_id,pu.barcode,p.description,b.name as brand, u.name as unit,pu.price as price,cpp.sell_price, c.name, sub.name
                from ((((((((product_unit as pu
                INNER JOIN products as p on p.id = pu.product_id)
                INNER JOIN customer_product_prices as cpp on cpp.product_id = p.id)
                INNER JOIN brand as b on b.id = cpp.brand)
                INNER JOIN unit as u on u.id = cpp.unit)
                INNER JOIN product_categories as pc ON pc.product_id = cpp.product_id) 
                INNER JOIN product_subcategories as psc ON psc.product_id = cpp.product_id)
                INNER JOIN categories as c ON c.id = pc.category_id)
                INNER JOIN categories as sub ON sub.id = psc.subcategory_id) 
                where cpp.customer_id = " & customer_id)
            End If

            Dim recordfound As Boolean = False
            If .dr.HasRows Then
                recordfound = True
                While .dr.Read
                    Dim id As String = .dr.GetValue(0)
                    Dim barcode As String = .dr.GetValue(1)
                    Dim desc As String = .dr.GetValue(2)
                    Dim brand As String = .dr.GetValue(3)
                    Dim unit As String = .dr.GetValue(4)
                    Dim price As String = .dr.GetValue(5)
                    Dim sell_price As String = .dr.GetValue(6)
                    Dim cat As String = .dr.GetValue(7)
                    Dim subcat As String = .dr.GetValue(8)
                    Dim row As String() = New String() {id, True, barcode, desc, brand, unit, price, sell_price, cat, subcat}
                    dgvPriceList.Rows.Add(row)
                End While
            Else
                recordfound = False
                MsgBox("No record products found!", MsgBoxStyle.Critical)
            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()

            If recordfound = False Then
                Dim d As Integer = MsgBox("Do you want to add product for " & cbCustomer.Text & "?", MsgBoxStyle.Information + MsgBoxStyle.YesNo)
                If d = MsgBoxResult.Yes Then
                    btnAdd.PerformClick()
                End If
            End If
        End With
    End Sub
End Class



