Public Class InventoryReport
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
        Dim dbstock As New DatabaseConnect
        With dbstock
            .selectByQuery("Select SUM(qty) as qty from product_stocks as ps
                    inner join product_unit as pu ON pu.id = ps.product_unit_id
                    where pu.status = 1")
            If .dr.Read Then
                total_stock = CInt(.dr("qty"))
            Else
                total_stock = 0
            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With

        'get total price
        Dim total_price As String
        Dim dbprice As New DatabaseConnect
        With dbprice
            .selectByQuery("Select SUM(price) as price from product_unit where status = 1")
            If .dr.Read Then
                total_price = Val(.dr("price")).ToString("N2")
            Else
                total_price = 0
            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With

        Dim table_content As String = ""
        Dim dbprod As New DatabaseConnect()
        With dbprod
            .selectByQuery("Select distinct pu.id, pu.barcode,p.description,b.name as brand, u.name as unit,cc.name as color,pu.price,ps.qty as stock,c.name as cat, subc.name as subcat from (((((((((product_unit as pu     
                LEFT JOIN brand as b on b.id = pu.brand)
                INNER JOIN unit as u on u.id = pu.unit)
                LEFT JOIN color as cc ON cc.id = pu.color)
                INNER JOIN product_stocks as ps ON ps.product_unit_id = pu.id)
                INNER JOIN products as p ON p.id = pu.product_id)
                LEFT JOIN product_categories as pc ON pc.product_id = pu.product_id) 
                LEFT JOIN product_subcategories as psc ON psc.product_id = pu.product_id)
                LEFT JOIN categories as c ON c.id = pc.category_id)
                LEFT JOIN categories as subc ON subc.id = psc.subcategory_id)
                where pu.status = 1 order by p.description")
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

<h2>Inventory Report</h2>
<div id='fieldset'>
	<table>
		<tr>
			<td width='150'><label><strong>Total Quantity: </strong></label></td>
			<td style='color:red;'><label>" & total_stock & "</label></td>
			
			<td width='150'><label><strong>Total Price: </strong></label></td>
			<td style='color:red;'><label>" & total_price & "</label></td>
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
		<td style='color:red'><strong>" & total_price & "</strong></td>
		<td style='color:red'><strong>" & total_stock & "</strong></td>
	</tr>
  </tbody>
</table>

</body>
</html>
"

        Return result
    End Function
End Class