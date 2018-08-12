Public Class DailySalesReports
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        btnPrint.Enabled = False
        Dim path As String = Application.StartupPath & "\daily_sales_reports.html"
        Dim filter() As String = {"brand", "unit"}
        Try
            Dim code As String = generatePrint(filter)
            Dim myWrite As System.IO.StreamWriter
            myWrite = IO.File.CreateText(path)
            myWrite.WriteLine(code)
            myWrite.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        Dim proc As New System.Diagnostics.Process()
        proc = Process.Start(path, "")
        btnPrint.Enabled = True
    End Sub

    Private Function generatePrint(ByVal filter() As String)
        Dim result As String = ""


        'get total sales
        Dim total_sales As String
        Dim dbprice As New DatabaseConnect
        With dbprice
            .selectByQuery("Select SUM(total_amount) as sale from customer_order_products")
            If .dr.Read Then
                total_sales = Val(.dr("sale")).ToString("N2")
            Else
                total_sales = 0
            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With

        Dim table_content As String = ""
        Dim dbprod As New DatabaseConnect()
        With dbprod
            .selectByQuery("Select Format(cop.created_at,'mm-dd-yyyy') as daily,count(l.id) as orders, sum(cop.quantity) as qty, sum(cop.total_amount) as total_sales from customer_order_products as cop
                    inner join ledger as l ON l.id = cop.customer_order_ledger_id where l.status <> 0 group by Format(cop.created_at,'mm-dd-yyyy') order by Format(cop.created_at,'mm-dd-yyyy') desc")
            If .dr.HasRows Then
                While .dr.Read
                    Dim tr As String = "<tr>"
                    Dim daily As String = .dr("daily")
                    Dim orders As String = .dr("orders")
                    Dim qty As String = .dr("qty")
                    Dim total As String = .dr("total_sales")
                    tr = tr & "<td>" & daily & "</td>"
                    tr = tr & "<td>" & orders & "</td>"
                    tr = tr & "<td>" & qty & "</td>"
                    tr = tr & "<td>" & total & "</td>"
                    tr = tr & "</tr>"
                    table_content = table_content & tr
                End While
            End If
            '.selectByQuery("Select distinct pu.id, pu.barcode,p.description,b.name as brand, u.name as unit,cc.name as color,pu.price,ps.qty as stock,c.name as cat, subc.name as subcat from (((((((((product_unit as pu     
            '    LEFT JOIN brand as b on b.id = pu.brand)
            '    INNER JOIN unit as u on u.id = pu.unit)
            '    LEFT JOIN color as cc ON cc.id = pu.color)
            '    INNER JOIN product_stocks as ps ON ps.product_unit_id = pu.id)
            '    INNER JOIN products as p ON p.id = pu.product_id)
            '    LEFT JOIN product_categories as pc ON pc.product_id = pu.product_id) 
            '    LEFT JOIN product_subcategories as psc ON psc.product_id = pu.product_id)
            '    LEFT JOIN categories as c ON c.id = pc.category_id)
            '    LEFT JOIN categories as subc ON subc.id = psc.subcategory_id)
            '    where pu.status = 1 order by p.description")
            'If .dr.HasRows Then
            '    While .dr.Read
            '        Dim tr As String = "<tr>"
            '        Dim id As Integer = .dr("id")
            '        Dim barcode As String = .dr("barcode")
            '        Dim desc As String = .dr("description")
            '        Dim brand As String = If(IsDBNull(.dr("brand")), "", .dr("brand"))
            '        Dim unit As String = .dr("unit")
            '        Dim color As String = If(IsDBNull(.dr("color")), "", .dr("color"))
            '        Dim price As String = Val(.dr("price")).ToString("N2")
            '        Dim stock As Integer = Val(.dr("stock"))

            '        tr = tr & "<td>" & barcode & "</td>"
            '        tr = tr & "<td>" & unit & "</td>"
            '        tr = tr & "<td>" & brand & "</td>"
            '        tr = tr & "<td>" & color & "</td>"
            '        tr = tr & "<td>" & desc & "</td>"
            '        tr = tr & "<td>" & price & "</td>"
            '        tr = tr & "<td>" & stock & "</td>"
            '        tr = tr & "</tr>"
            '        table_content = table_content & tr

            '    End While
            'End If
            '.cmd.Dispose()
            '.dr.Close()
            '.con.Close()
        End With

        result = "
<!DOCTYPE html>
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

<h2>Daily Sales Reports</h2>
<div id='fieldset'>
	<table>
		<tr>
			<td style='text-align:right;'><strong><span>Total Sales: </span></strong></td>
			<td width='80' style='color:red'><strong><span>" & total_sales & "</span></strong></td>
		</tr>
	<table>
	<br>
	
</div>
<br>
<table>
  <thead>
  <tr>
	<th>Date</th>
	<th>Total Orders</th>
	<th>Total Quantity</th>
	<th>Total Sales</th>
  </tr>
  </thead>
  <tbody>
	  " & table_content & "
    <tr>
		<td colspan='3' style='text-align:right;'><strong>Total Sales</strong></td>
		<td style='color:red'><strong>" & total_sales & " </strong></td>
	</tr>
  </tbody>
</table>
<br><br>

</body>
</html>
"

        Return result
    End Function
End Class