Public Class ProductMaster
    Public selectedDesc As Integer = 0
    Public selectedBrand As Integer = 0
    Public selectedUnit As Integer = 0
    Public selectedColor As Integer = 0
    Public selectedCat As Integer = 0
    Public selectedSubCat As Integer = 0

    Private Sub ProductMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        autocompleteDesc()
        loadBrand()
        loadUnit()
        loadColor()
        loadCat()
        loadSubCat()
        loadList("")
    End Sub

    Public Sub loadList(ByVal q As String)
        Dim db As New DatabaseConnect
        With db
            dgvProducts.Rows.Clear()
            If q = "" Then
                .selectByQuery("Select distinct pu.id,pu.barcode, p.description,b.name as brand, u.name as unit,cc.name as color,pu.price,ps.qty as stock,c.name as cat,sub.name as subcat FROM (((((((((products as p 
                INNER JOIN product_unit as pu ON p.id = pu.product_id) 
                LEFT JOIN product_stocks as ps ON ps.product_unit_id = pu.id)
                LEFT JOIN brand as b ON b.id = pu.brand)
                INNER JOIN unit as u ON u.id = pu.unit)
                LEFT JOIN color as cc ON cc.id = pu.color)
                INNER JOIN product_categories as pc ON pc.product_id = p.id) 
                LEFT JOIN product_subcategories as psc ON psc.product_id = p.id)
                LEFT JOIN categories as c ON c.id = pc.category_id)
                LEFT JOIN categories as sub ON sub.id = psc.subcategory_id)  where pu.status <> 0 and p.status <> 0 order by p.description")
            Else
                .selectByQuery(q)
            End If

            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr("id")
                    Dim barcode As String = .dr("barcode")
                    Dim desc As String = .dr("description")
                    Dim brand As String = .dr("brand")
                    Dim unit As String = .dr("unit")
                    Dim color As String = If(IsDBNull(.dr("color")), "", .dr("color"))
                    Dim price As String = Val(.dr("price")).ToString("N2")
                    Dim stock As String = If(IsDBNull(.dr("stock")), "", .dr("stock"))
                    Dim cat As String = If(IsDBNull(.dr("cat")), "", .dr("cat"))
                    Dim subcat As String = If(IsDBNull(.dr("subcat")), "", .dr("subcat"))
                    Dim row As String() = New String() {id, barcode, desc, brand, unit, color, price, stock, cat, subcat}
                    dgvProducts.Rows.Add(row)
                End While
            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If dgvProducts.SelectedRows.Count = 1 Then
            Dim id As Integer = dgvProducts.SelectedRows(0).Cells("id").Value
            ProductMasterForm.toLoadInfo(id)
            ProductMasterForm.ShowDialog()
            ProductMasterForm.TabControl1.SelectedTab = ProductMasterForm.TabPage1
        Else
            MsgBox("Please select one product!", MsgBoxStyle.Critical)
        End If
    End Sub

    Public Sub autocompleteDesc()
        Dim MySource As New AutoCompleteStringCollection()

        With txtProductDesc
            .AutoCompleteCustomSource = MySource
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.CustomSource
        End With

        Dim product As New DatabaseConnect
        With product
            .selectByQuery("Select description from products  where status <> 0  order by description")
            While .dr.Read
                MySource.Add(.dr("description"))
            End While
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
    End Sub

    'Public Sub loadDesc()
    '    cbProductDesc.DataSource = Nothing
    '    cbProductDesc.Items.Clear()
    '    Dim comboSource As New Dictionary(Of String, String)()
    '    comboSource.Add(0, "All")
    '    Dim dbdesc As New DatabaseConnect
    '    With dbdesc
    '        .selectByQuery("Select id,description from products where status <> 0 order by description")
    '        If .dr.HasRows Then
    '            While .dr.Read
    '                Dim id As Integer = .dr.GetValue(0)
    '                Dim name As String = .dr.GetValue(1)
    '                comboSource.Add(id, name)
    '            End While
    '        End If
    '        cbProductDesc.DataSource = New BindingSource(comboSource, Nothing)
    '        cbProductDesc.DisplayMember = "Value"
    '        cbProductDesc.ValueMember = "Key"
    '        .dr.Close()
    '        .cmd.Dispose()
    '        .con.Close()
    '    End With
    'End Sub

    Public Sub loadBrand()
        cbBrand.DataSource = Nothing
        cbBrand.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(0, "All")
        Dim dbdesc As New DatabaseConnect
        With dbdesc
            .selectByQuery("Select id,name from brand where status <> 0 order by name")
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = .dr.GetValue(0)
                    Dim name As String = .dr.GetValue(1)
                    comboSource.Add(id, name)
                End While
            End If
            cbBrand.DataSource = New BindingSource(comboSource, Nothing)
            cbBrand.DisplayMember = "Value"
            cbBrand.ValueMember = "Key"
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Public Sub loadUnit()
        cbUnit.DataSource = Nothing
        cbUnit.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(0, "All")
        Dim dbdesc As New DatabaseConnect
        With dbdesc
            .selectByQuery("Select id,name from unit where status <> 0 order by name")
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = .dr.GetValue(0)
                    Dim name As String = .dr.GetValue(1)
                    comboSource.Add(id, name)
                End While
            End If
            cbUnit.DataSource = New BindingSource(comboSource, Nothing)
            cbUnit.DisplayMember = "Value"
            cbUnit.ValueMember = "Key"
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Public Sub loadColor()
        cbColor.DataSource = Nothing
        cbColor.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(0, "All")
        Dim dbdesc As New DatabaseConnect
        With dbdesc
            .selectByQuery("Select id,name from color where status <> 0 order by name")
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = .dr.GetValue(0)
                    Dim name As String = .dr.GetValue(1)
                    comboSource.Add(id, name)
                End While
            End If
            cbColor.DataSource = New BindingSource(comboSource, Nothing)
            cbColor.DisplayMember = "Value"
            cbColor.ValueMember = "Key"
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Public Sub loadCat()
        cbCat.DataSource = Nothing
        cbCat.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(0, "All")
        Dim dbdesc As New DatabaseConnect
        With dbdesc
            .selectByQuery("Select id,name from categories where status <> 0 and parent_id = 0 order by name")
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = .dr.GetValue(0)
                    Dim name As String = .dr.GetValue(1)
                    comboSource.Add(id, name)
                End While
            End If
            cbCat.DataSource = New BindingSource(comboSource, Nothing)
            cbCat.DisplayMember = "Value"
            cbCat.ValueMember = "Key"
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Public Sub loadSubCat()
        cbSubCat.DataSource = Nothing
        cbSubCat.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(0, "All")
        Dim dbdesc As New DatabaseConnect
        With dbdesc
            .selectByQuery("Select id,name from  categories where status <> 0 and parent_id > 0 order by name")
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = .dr.GetValue(0)
                    Dim name As String = .dr.GetValue(1)
                    comboSource.Add(id, name)
                End While
            End If
            cbSubCat.DataSource = New BindingSource(comboSource, Nothing)
            cbSubCat.DisplayMember = "Value"
            cbSubCat.ValueMember = "Key"
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Private Sub txtProductDesc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductDesc.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtProductDesc.TextLength > 0 Then
                selectedDesc = New DatabaseConnect().get_id("products", "description", txtProductDesc.Text)
            Else
                selectedDesc = 0
            End If
        End If
    End Sub

    Private Sub cbBrand_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBrand.SelectedIndexChanged
        If cbBrand.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbBrand.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbBrand.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedBrand = key
            'populateColor(SelectedProdID, selectedBrand)
        Else
            selectedBrand = 0
            'populateColor(SelectedProdID, selectedBrand)
        End If
    End Sub

    Private Sub cbUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbUnit.SelectedIndexChanged
        If cbUnit.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbUnit.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbUnit.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedUnit = key
        Else
            selectedUnit = 0
        End If
    End Sub

    Private Sub cbColor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbColor.SelectedIndexChanged
        If cbColor.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbColor.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbColor.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedColor = key
            'populateUnit(SelectedProdID, selectedBrand, selectedColor)
        Else
            selectedColor = 0
            'populateUnit(SelectedProdID, selectedBrand, selectedColor)
        End If
    End Sub

    Private Sub cbCat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCat.SelectedIndexChanged
        If cbCat.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbCat.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbCat.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedCat = key
            'populateUnit(SelectedProdID, selectedBrand, selectedColor)
        Else
            selectedCat = 0
            'populateUnit(SelectedProdID, selectedBrand, selectedColor)
        End If
    End Sub

    Private Sub cbSubCat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSubCat.SelectedIndexChanged
        If cbSubCat.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbSubCat.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbSubCat.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedSubCat = key
            'populateUnit(SelectedProdID, selectedBrand, selectedColor)
        Else
            selectedSubCat = 0
            'populateUnit(SelectedProdID, selectedBrand, selectedColor)
        End If
    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        Dim query As String = "Select distinct pu.id,pu.barcode, p.description,b.name as brand, u.name as unit,cc.name as color,pu.price,ps.qty as stock,c.name as cat,sub.name as subcat FROM (((((((((products as p 
                INNER JOIN product_unit as pu ON p.id = pu.product_id) 
                LEFT JOIN product_stocks as ps ON ps.product_unit_id = pu.id)
                LEFT JOIN brand as b ON b.id = pu.brand)
                INNER JOIN unit as u ON u.id = pu.unit)
                LEFT JOIN color as cc ON cc.id = pu.color)
                INNER JOIN product_categories as pc ON pc.product_id = p.id) 
                LEFT JOIN product_subcategories as psc ON psc.product_id = p.id)
                LEFT JOIN categories as c ON c.id = pc.category_id)
                LEFT JOIN categories as sub ON sub.id = psc.subcategory_id)  where pu.status <> 0 and p.status <> 0 "

        If Trim(txtBarcode.Text) <> "" Then
            query = query & " and pu.barcode = '" & txtBarcode.Text & "'"
        End If

        If selectedDesc > 0 And Trim(txtProductDesc.Text) <> "" Then
            query = query & " and p.id = " & selectedDesc
        End If

        If cbBrand.Text <> "All" Then
            query = query & " and b.id = " & selectedBrand
        End If

        If cbUnit.Text <> "All" Then
            query = query & " and u.id = " & selectedUnit
        End If


        If cbColor.Text <> "All" Then
            query = query & " and cc.id = " & selectedColor
        End If

        If cbCat.Text <> "All" Then
            query = query & " and c.id = " & selectedCat
        End If

        If cbSubCat.Text <> "All" Then
            query = query & " and sub.id = " & selectedSubCat
        End If

        query = query & " order by p.description"
        loadList(query)
    End Sub

    Private Sub txtProductDesc_MouseLeave(sender As Object, e As EventArgs) Handles txtProductDesc.MouseLeave
        If txtProductDesc.TextLength > 0 Then
            selectedDesc = New DatabaseConnect().get_id("products", "description", txtProductDesc.Text)
        Else
            selectedDesc = 0
        End If
    End Sub
End Class