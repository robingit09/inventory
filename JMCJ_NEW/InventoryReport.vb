Public Class InventoryReport

    Public selectedDesc As Integer = 0
    Public selectedBrand As Integer = 0
    Public selectedUnit As Integer = 0
    Public selectedColor As Integer = 0
    Public selectedCat As Integer = 0
    Public selectedSubCat As Integer = 0
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        btnPrint.Enabled = False
        Dim path As String = Application.StartupPath & "\inventory_report.html"
        Dim filter() As String = {"brand", "unit"}
        Try
            Dim code As String = generatePrint(filter)
            Dim myWrite As System.IO.StreamWriter
            myWrite = IO.File.CreateText(path)
            myWrite.WriteLine(code)
            myWrite.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim proc As New System.Diagnostics.Process()
        proc = Process.Start(path, "")
        btnPrint.Enabled = True
    End Sub

    Private Function generatePrint(ByVal filter() As String)
        Dim result As String = ""

        'get total stock
        Dim total_stock As Integer = 0
        'Dim dbstock As New DatabaseConnect
        'With dbstock
        '    .selectByQuery("Select SUM(qty) as qty from product_stocks as ps
        '            inner join product_unit as pu ON pu.id = ps.product_unit_id
        '            where pu.status = 1")
        '    If .dr.Read Then
        '        total_stock = CInt(.dr("qty"))
        '    Else
        '        total_stock = 0
        '    End If
        '    .cmd.Dispose()
        '    .dr.Close()
        '    .con.Close()
        'End With

        'get total price
        Dim total_price As Double = 0
        'Dim dbprice As New DatabaseConnect
        'With dbprice
        '    .selectByQuery("Select SUM(price) as price from product_unit where status = 1")
        '    If .dr.Read Then
        '        total_price = Val(.dr("price")).ToString("N2")
        '    Else
        '        total_price = 0
        '    End If
        '    .cmd.Dispose()
        '    .dr.Close()
        '    .con.Close()
        'End With

        Dim table_content As String = ""

        Dim query As String = "Select distinct pu.id, pu.barcode,p.description,b.name as brand, u.name as unit,cc.name as color,pu.price,ps.qty as stock,c.name as cat, subc.name as subcat from (((((((((product_unit as pu     
                LEFT JOIN brand as b on b.id = pu.brand)
                INNER JOIN unit as u on u.id = pu.unit)
                LEFT JOIN color as cc ON cc.id = pu.color)
                INNER JOIN product_stocks as ps ON ps.product_unit_id = pu.id)
                INNER JOIN products as p ON p.id = pu.product_id)
                LEFT JOIN product_categories as pc ON pc.product_id = pu.product_id) 
                LEFT JOIN product_subcategories as psc ON psc.product_id = pu.product_id)
                LEFT JOIN categories as c ON c.id = pc.category_id)
                LEFT JOIN categories as subc ON subc.id = psc.subcategory_id)
                where pu.status <> 0 and p.status <> 0"

        If Trim(txtBarcode.Text) <> "" Then
            query = query & " and pu.barcode = '" & Trim(txtBarcode.Text) & "'"
        End If

        If selectedDesc > 0 And Trim(txtProductDesc.Text) <> "" Then
            query = query & " and p.id = " & selectedDesc
        End If

        If selectedBrand > 0 Then
            query = query & " and b.id = " & selectedBrand
        End If

        If selectedUnit > 0 Then
            query = query & " and u.id = " & selectedUnit
        End If

        If selectedColor > 0 Then
            query = query & " and cc.id = " & selectedColor
        End If

        If selectedCat > 0 Then
            query = query & " and c.id = " & selectedCat
        End If

        If selectedSubCat > 0 Then
            query = query & " and subc.id = " & selectedSubCat
        End If

        query = query & " order by p.description"

        Dim dbprod As New DatabaseConnect()
        With dbprod
            .selectByQuery(query)

            If .dr.HasRows Then
                While .dr.Read
                    Dim tr As String = "<tr>"
                    Dim id As Integer = .dr("id")
                    Dim barcode As String = .dr("barcode")
                    Dim desc As String = .dr("description")
                    Dim brand As String = If(IsDBNull(.dr("brand")), "", .dr("brand"))
                    Dim unit As String = .dr("unit")
                    Dim color As String = If(IsDBNull(.dr("color")), "", .dr("color"))
                    Dim price As String = Val(.dr("price")).ToString("N2")
                    Dim stock As Integer = Val(.dr("stock"))

                    tr = tr & "<td>" & barcode & "</td>"
                    tr = tr & "<td>" & unit & "</td>"
                    tr = tr & "<td>" & brand & "</td>"
                    tr = tr & "<td>" & color & "</td>"
                    tr = tr & "<td>" & desc & "</td>"
                    tr = tr & "<td>" & price & "</td>"
                    tr = tr & "<td>" & stock & "</td>"
                    tr = tr & "</tr>"
                    total_stock += stock
                    total_price += Val(.dr("price"))
                    table_content = table_content & tr
                End While
            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With

        result = "<!DOCTYPE html>
<html>
<head>
<style>
table {
	font-family:serif;
	border-collapse: collapse;
	width: 100%;
}

td, th {
	border: 1px solid #dddddd;
	text-align: left;
	padding: 8px;
}

tr:nth-child(even) {

}
</style>
</head>
<body>
<div id='header' style='text-align:center;'>
	<br>
	<h3	 style='color:blue;margin:1px;'><strong>JMCJ</strong></h3>
	<p style='color:red;;margin:1px;'>Perfect Colors Solution Inc.</p>
	<p style='margin:1px;font-size:10pt;'>42 K Roosevelt Ave, Brgy. Sta. Cruz, Lungsod Quezon, 1104 Kalakhang Maynila</p>
	<p style='margin:1px;font-size:10pt;'>Fax: 411-5274 Tel: 371-5448</p>
</div>
<h4 style='text-align:center;'>Inventory Report</h4>
<div id='fieldset'>
	<table>
		<tr>
			<td width='150'><label><strong>Total Quantity: </strong></label></td>
			<td style='color:red;'><label>" & Val(total_stock).ToString("N0") & "</label></td>
			<td width='150'><label><strong>Total Price: </strong></label></td>
			<td style='color:red;'><label>" & Val(total_price).ToString("N2") & "</label></td>
		</tr>
	
	<table>
</div>
<br>
<table>
  <thead>
  <tr>
	<th>Barcode</th>
	<th>Unit</th>
	<th>Brand</th>
	<th>Color</th>
	<th>Description</th>
	<th>Unit Price</th>
	<th>Quantity</th>
  </tr>
  </thead>
  <tbody>
    " & table_content & "
    <tr>
		<td colspan='5' style='text-align:right;'><strong>Total</strong></td>
		<td style='color:red'><strong>" & Val(total_price).ToString("N2") & "</strong></td>
		<td style='color:red'><strong>" & Val(total_stock).ToString("N0") & "</strong></td>
	</tr>
  </tbody>
</table>

</body>
</html>
"
        Return result
    End Function


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

    Private Sub InventoryReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        autocompleteDesc()
        loadBrand()
        loadUnit()
        loadColor()
        loadCat()
        loadSubCat()
    End Sub
End Class