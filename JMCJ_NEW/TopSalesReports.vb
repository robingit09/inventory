Public Class TopSalesReports
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        btnPrint.Enabled = False
        Dim path As String = Application.StartupPath & "\top_sales_reports.html"
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

        'get total sold
        Dim total_sold As String
        Dim dbprice As New DatabaseConnect
        With dbprice
            .selectByQuery("Select SUM(quantity) as qty from customer_order_products")
            If .dr.Read Then
                total_sold = Val(.dr("qty")).ToString("N0")
            Else
                total_sold = 0
            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With

        Dim table_content As String = ""
        Dim dbprod As New DatabaseConnect()
        With dbprod
            .selectByQuery("Select distinct pu.id, pu.barcode, p.description,b.name as brand, u.name as unit,c.name as color, (select sum(quantity) from customer_order_products where product_unit_id = pu.id) as [total_qty] from (((((customer_order_products as cop
                    Left Join product_unit as pu ON pu.id = cop.product_unit_id)
                    Left Join products as p on p.id = pu.product_id)
                    Left Join brand as b on b.id = pu.brand)
                    Left Join unit as u on u.id = pu.unit)
                    Left Join color as c on c.id = pu.color)")
            If .dr.HasRows Then
                Dim dict = New Dictionary(Of String, String)
                While .dr.Read
                    Dim tr As String = "<tr>"
                    Dim p_id As String = .dr("id")
                    Dim barcode As String = .dr("barcode")
                    Dim desc As String = .dr("description")
                    Dim brand As String = .dr("brand")
                    Dim unit As String = .dr("unit")
                    Dim color As String = If(IsDBNull(.dr("color")), "", .dr("color"))
                    Dim total_qty As String = .dr("total_qty")
                    Dim percent As String = Val(Val(total_qty) / Val(total_sold)).ToString("#0.##%")


                    tr = tr & "<td>" & barcode & "</td>"
                    tr = tr & "<td>" & unit & "</td>"
                    tr = tr & "<td>" & brand & "</td>"
                    tr = tr & "<td>" & color & "</td>"
                    tr = tr & "<td>" & desc & "</td>"
                    tr = tr & "<td>" & total_qty & "</td>"
                    tr = tr & "<td>" & percent & "</td>"
                    tr = tr & "</tr>"
                    table_content = table_content & tr
                End While
            End If
            .dr.Close()
            .cmd.Dispose()
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

<h2>Top Sales</h2>
<div id='fieldset'>
	<table>
		<tr>
			<td width='160'><span><strong>Total Quantity (Sold): </strong></span></td>
			<td style='color:red;'><label>" & total_sold & " </label></td>
		
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
	<th>Total Quantity (Sold)</th>
	<th>Percentage</th>
  </tr>
  </thead>
  <tbody>
    " & table_content & "
    <tr>
		<td colspan='5' style='text-align:right;'><strong>Total</strong></td>
		<td style='color:red'><strong>" & total_sold & "</strong></td>
		<td>100%</td>
	</tr>
  </tbody>
</table>

</body>
</html>"

        Return result
    End Function
End Class