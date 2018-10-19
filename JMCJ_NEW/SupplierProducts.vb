Public Class SupplierProducts
    Public selectedSupplier As Integer = 0
    Public from_module As Integer = 0
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If cbSupplier.SelectedIndex = 0 Then
            MsgBox("Please select supplier!", MsgBoxStyle.Critical)
            cbSupplier.Focus()
            Exit Sub
        End If
        SearchSupplierProducts.selectedSupplier = Me.selectedSupplier
        SearchSupplierProducts.loadList("")
        SearchSupplierProducts.ShowDialog()
    End Sub

    Private Sub SupplierProducts_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub loadProducts(ByVal query As String)
        dgvProd.Rows.Clear()
        Dim db As New DatabaseConnect
        With db
            If query = "" Then
                .selectByQuery("Select distinct pu.id,pu.barcode,p.description,b.name as brand, u.name as unit,cc.name as color,pu.price,cpp.unit_cost,c.name as cat, subc.name as subcat from (((((((((product_unit as pu
                INNER JOIN product_suppliers as cpp ON cpp.product_unit_id = pu.id)
                LEFT JOIN brand as b on b.id = pu.brand)
                INNER JOIN unit as u on u.id = pu.unit)
                LEFT JOIN color as cc ON cc.id = pu.color)
                INNER JOIN products as p ON p.id = pu.product_id)
                LEFT JOIN product_categories as pc ON pc.product_id = pu.product_id) 
                LEFT JOIN product_subcategories as psc ON psc.product_id = pu.product_id)
                LEFT JOIN categories as c ON c.id = pc.category_id)
                LEFT JOIN categories as subc ON subc.id = psc.subcategory_id)
                where cpp.supplier = " & selectedSupplier & " order by p.description")
            Else
                .selectByQuery(query)

            End If

            Dim recordfound As Boolean = False
            If .dr.HasRows Then
                recordfound = True
                While .dr.Read
                    Dim id As String = .dr("id")
                    Dim barcode As String = .dr("barcode")
                    Dim desc As String = .dr("description")
                    Dim brand As String = If(IsDBNull(.dr("brand")), "", .dr("brand"))
                    Dim unit As String = .dr("unit")
                    Dim color As String = If(IsDBNull(.dr("color")), "", .dr("color"))
                    Dim cost As String = Val(.dr("unit_cost")).ToString("N2")
                    'Dim sell_price As String = Val(.dr("sell_price")).ToString("N2")
                    'Dim cat As String = If(IsDBNull(.dr("cat")), "", .dr("cat"))
                    'Dim subcat As String = If(IsDBNull(.dr("subcat")), "", .dr("subcat"))


                    Dim row As String() = New String() {id, barcode, desc, brand, unit, color, cost, "Remove"}
                    dgvProd.Rows.Add(row)
                End While
            Else
                recordfound = False
                MsgBox("No record products found!", MsgBoxStyle.Critical)
            End If

            .dr.Close()
            .cmd.Dispose()
            .con.Close()

            'If recordfound = False Then
            '    Dim d As Integer = MsgBox("Do you want to add product for " & cbCustomer.Text & "?", MsgBoxStyle.Information + MsgBoxStyle.YesNo)
            '    If d = MsgBoxResult.Yes Then
            '        btnAdd.PerformClick()
            '    End If
            'End If
        End With
    End Sub

    Public Sub initialize()
        loadSupplier()
    End Sub

    Public Sub loadSupplier()
        cbSupplier.DataSource = Nothing
        cbSupplier.Items.Clear()
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("SELECT id,supplier_name from suppliers where status <> 0 order by supplier_name")
            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "Select Supplier")

            While .dr.Read
                Dim id As Integer = CInt(.dr.GetValue(0))
                Dim sup As String = .dr.GetValue(1)
                comboSource.Add(id, sup)
            End While

            cbSupplier.DataSource = New BindingSource(comboSource, Nothing)
            cbSupplier.DisplayMember = "Value"
            cbSupplier.ValueMember = "Key"

            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Private Sub cbSupplier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSupplier.SelectedIndexChanged
        If cbSupplier.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbSupplier.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbSupplier.SelectedItem, KeyValuePair(Of String, String)).Value
            Me.selectedSupplier = key
            cbSupplier.BackColor = Drawing.Color.White
            loadProducts("")

        Else
            selectedSupplier = 0
            cbSupplier.SelectedIndex = 0
            dgvProd.Rows.Clear()

        End If

    End Sub

    Private Sub dgvProd_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProd.CellContentClick
        'remove product
        If dgvProd.Rows(e.RowIndex).Cells(7).Value <> "" Then
            If e.ColumnIndex = 7 And dgvProd.Rows.Count > 1 Then

                dgvProd.Rows.RemoveAt(e.RowIndex)
            End If
        End If

    End Sub

    Private Sub dgvProd_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProd.CellValueChanged
        ' if cost if edit
        If e.ColumnIndex = 6 And dgvProd.Rows.Count > 1 Then
            Dim cost As Double = 0
            If IsNumeric(dgvProd.Rows(e.RowIndex).Cells("cost").Value) Then
                cost = CDbl(dgvProd.Rows(e.RowIndex).Cells("cost").Value.ToString.Replace(",", ""))
            Else
                cost = 0
            End If

            'change color
            If cost > 0 Then
                dgvProd.Rows(e.RowIndex).Cells("cost").Style.BackColor = Drawing.Color.White
            Else
                dgvProd.Rows(e.RowIndex).Cells("cost").Style.BackColor = Drawing.Color.Red
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cbSupplier.SelectedIndex = 0 Then
            MsgBox("Please select supplier!", MsgBoxStyle.Critical)
            cbSupplier.Focus()
            Exit Sub
        End If

        If dgvProd.Rows.Count = 1 Or dgvProd.Rows.Count = 0 Then
            MsgBox("Please add products!", MsgBoxStyle.Critical)
            dgvProd.Focus()
            Exit Sub
        End If
        'insert supplier and their cost
        Dim dbdelete As New DatabaseConnect
        dbdelete.delete_permanent("product_suppliers", "supplier", Me.selectedSupplier)
        dbdelete.cmd.Dispose()
        dbdelete.con.Close()

        ' validation
        Dim wrong_cost As Boolean = False
        For Each item As DataGridViewRow In dgvProd.Rows
            If item.Cells("column_description").Value <> "" Then

                Dim cost As String = item.Cells("cost").Value
                If Not IsNumeric(cost.Replace(",", "")) Then
                    item.Cells("cost").Style.BackColor = Drawing.Color.Red
                    wrong_cost = True
                End If
            End If
        Next

        If wrong_cost = True Then
            MsgBox("Invalid input for cost. Please check the value you have entered.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim saveCost As New DatabaseConnect
        With saveCost
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text

            For Each item As DataGridViewRow In dgvProd.Rows
                If item.Cells("column_description").Value <> "" Then
                    'MsgBox(item.Cells("column_description").Value)
                    Dim p_u_id As String = item.Cells("id").Value
                    Dim supplier As String = Me.selectedSupplier
                    Dim cost As Double = Val(item.Cells("cost").Value)

                    .cmd.CommandText = "INSERT INTO product_suppliers (product_unit_id,supplier,unit_cost,created_at,updated_at)
            VALUES(?,?,?,?,?)"
                    .cmd.Parameters.AddWithValue("@product_unit_id", p_u_id)
                    .cmd.Parameters.AddWithValue("@supplier", supplier)
                    .cmd.Parameters.AddWithValue("@unit_cost", cost)
                    .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                    .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                    .cmd.ExecuteNonQuery()
                    .cmd.Parameters.Clear()
                End If
            Next
            .cmd.Dispose()
            .con.Close()
            MsgBox("Products Successfully Saved.", MsgBoxStyle.Information)

            If from_module = 1 Then
                SupplierProductSelection.loadSupplierProducts(Me.selectedSupplier)
            End If
        End With

    End Sub
End Class