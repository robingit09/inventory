Public Class TopSalesReports
    Public selectedCustomer As Integer = 0
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        btnPrint.Enabled = False
        Dim path As String = Application.StartupPath & "\top_sales_reports.html"
        Dim filter() As String = {"brand", "unit"}

        'Try
        Dim code As String = generatePrint(filter)
        Dim myWrite As System.IO.StreamWriter
        myWrite = IO.File.CreateText(path)
        myWrite.WriteLine(code)
        myWrite.Close()
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical)
        '    Exit Sub
        'End Try

        Dim proc As New System.Diagnostics.Process()
        proc = Process.Start(path, "")
        btnPrint.Enabled = True
    End Sub

    Private Function generatePrint(ByVal filter() As String)
        Dim result As String = ""
        Dim customer_name As String = ""
        If selectedCustomer = 0 Then
            customer_name = "All"
        Else
            customer_name = New DatabaseConnect().get_by_id("company", selectedCustomer, "company")
        End If

        'get total sold
        Dim query_sold As String = "Select SUM(quantity) as qty from customer_order_products as cop
                inner join customer_orders as co on co.id = cop.customer_order_id
                where co.delivery_status <> 0"
        If cbCustomer.SelectedIndex > 0 Then
            query_sold = query_sold & " and co.customer = " & selectedCustomer
        End If

        Dim total_sold As String = "0"
        Dim dbsold As New DatabaseConnect
        With dbsold
            .selectByQuery(query_sold)
            If .dr.HasRows Then
                If .dr.Read Then
                    If Not IsDBNull(.dr("qty")) Then
                        total_sold = Val(.dr("qty")).ToString("N0")
                    End If

                Else
                    total_sold = 0
                End If
            Else
                total_sold = 0
            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With


        'get total amount
        Dim query_amount As String = "Select SUM(cop.total_amount) as amount from customer_order_products as cop
                inner join customer_orders as co on co.id = cop.customer_order_id where co.delivery_status <> 0 "
        If cbCustomer.SelectedIndex > 0 Then
            query_amount = query_amount & " and co.customer = " & selectedCustomer
        End If

        Dim grand_total As String = "0"
        Dim dbamount As New DatabaseConnect
        With dbamount
            .selectByQuery(query_amount)
            If .dr.HasRows Then
                If .dr.Read Then
                    If Not IsDBNull(.dr("amount")) Then
                        grand_total = Val(.dr("amount")).ToString("N2")
                    End If
                Else
                        grand_total = 0
                End If
            Else
                grand_total = 0
            End If

            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With

        Dim query As String = "Select distinct pu.id, pu.barcode, p.description,b.name as brand, u.name as unit,c.name as color,total_qty,total_amount from (((((((customer_order_products as cop
                    Left Join product_unit as pu ON pu.id = cop.product_unit_id)
                    INNER JOIN customer_orders as co on co.id = cop.customer_order_id)
                    Left Join products as p on p.id = pu.product_id)
                    Left Join brand as b on b.id = pu.brand)
                    Left Join unit as u on u.id = pu.unit)
                    Left Join color as c on c.id = pu.color)
                    Left Join (Select product_unit_id,SUM(quantity) as total_qty,SUM(total_amount) as total_amount from customer_order_products group by product_unit_id) as total ON  pu.id = total.product_unit_id)
                    where co.delivery_status <> 0 "

        If cbCustomer.SelectedIndex > 0 Then
            query = query & " and co.customer = " & selectedCustomer
        End If
        query = query & " order by total_qty desc"

        Dim table_content As String = ""
        Dim dbprod As New DatabaseConnect()
        With dbprod
            .selectByQuery(query)

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
                    Dim total_amount As String = Val(.dr("total_amount")).ToString("N2")
                    Dim percent As String = Val(Val(total_qty) / Val(total_sold)).ToString("#0.##%")

                    tr = tr & "<td>" & barcode & "</td>"
                    tr = tr & "<td>" & unit & "</td>"
                    tr = tr & "<td>" & brand & "</td>"
                    tr = tr & "<td>" & color & "</td>"
                    tr = tr & "<td>" & desc & "</td>"
                    tr = tr & "<td>" & total_qty & "</td>"
                    tr = tr & "<td>" & percent & "</td>"
                    tr = tr & "<td>" & total_amount & "</td>"

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
<div id='header' style='text-align:center;'>
	<img src='header.png' width='180'>
	<p style='font-family:Arial;margin:1px;font-size:8pt;'>42 K Roosevelt Ave, Quezon City </p>
	<p style='font-family:Arial;margin:1px;font-size:8pt;'>Telefax: 411-5274. Globe:0917-132-1241</p>
	<p style='font-family:Arial;margin:1px;font-size:8pt;'>Email:purchasing.jmcj@gmail.com</p>
	<p style='font-family:Arial black;font-weight:bold;margin:1px;font-size:15pt;'>TOP SALES PRODUCT</p>
</div>
<div id='fieldset'>
	<table>
		<tr>
            <td width='160'><span><strong>Customer: </strong></span></td>
			<td><label>" & customer_name & " </label></td>
			<td width='160'><span><strong>Total Quantity Sold: </strong></span></td>
			<td style='color:red;'><label>" & total_sold & " </label></td>
            <td width='160'><span><strong>Total Amount Sold: </strong></span></td>
			<td style='color:red;'><label>" & grand_total & " </label></td>
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
	<th>Total Quantity Sold</th>
    <th>Percentage</th>
    <th>Total Amount Sold</th>
	
  </tr>
  </thead>
  <tbody>
    " & table_content & "
    <tr>
		<td colspan='5' style='text-align:right;'><strong>Total</strong></td>
		<td style='color:red'><strong>" & total_sold & "</strong></td>
		<td>100%</td>
        <td style='color:red'><strong>" & grand_total & "</strong></td>
	</tr>
  </tbody>
</table>

</body>
</html>"

        Return result
    End Function

    Public Sub loadCustomer()
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

    Private Sub TopSalesReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadCustomer()
    End Sub

    Private Sub cbCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCustomer.SelectedIndexChanged
        If cbCustomer.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedCustomer = key
        Else
            selectedCustomer = 0
        End If
    End Sub
End Class