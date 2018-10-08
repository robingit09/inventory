Public Class TopSalesReports
    Public selectedCustomer As Integer = 0
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        btnPrint.Enabled = False
        Dim path As String = Application.StartupPath & "\top_sales_reports.html"
        Dim filter() As String = {"brand", "unit"}

        'Try
        Dim code As String = ""
        If cbPrintMethod.SelectedIndex = 0 Then
            code = generatePrint(filter)
        End If
        If cbPrintMethod.SelectedIndex = 1 Then
            code = generatePrintBarChart()
        End If
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
        Dim total_sold2 As Integer = 0
        Dim grand_total2 As Double = 0

        If selectedCustomer = 0 Then
            customer_name = "All"
        Else
            customer_name = New DatabaseConnect().get_by_id("company", selectedCustomer, "company")
        End If

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
            query = query & " and co.customer_id = " & selectedCustomer
        End If

        If cbMonth.Text <> "All" Then
            query = query & " and MONTH(co.date_issue) = " & monthToNumber(cbMonth.Text)
        End If

        If cbYear.Text <> "All" Then
            query = query & " and YEAR(co.date_issue) = " & cbYear.Text
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
                    Dim percent As String = Val(Val(total_qty) / Val(total_sold2)).ToString("#0.##%")

                    total_sold2 += Val(total_qty)
                    grand_total2 += CDbl(total_amount)

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
			<td style='color:red;'><label>" & total_sold2 & " </label></td>
            <td width='160'><span><strong>Total Amount Sold: </strong></span></td>
			<td style='color:red;'><label>" & Val(grand_total2).ToString("N2") & " </label></td>
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
		<td style='color:red'><strong>" & total_sold2 & "</strong></td>
		<td>100%</td>
        <td style='color:red'><strong>" & Val(grand_total2).ToString("N2") & "</strong></td>
	</tr>
  </tbody>
</table>

</body>
</html>"

        Return result
    End Function

    Private Function generatePrintBarChart()
        Dim result As String = ""
        Dim customer_name As String = ""
        Dim total_sold2 As Integer = 0
        Dim grand_total2 As Double = 0

        If selectedCustomer = 0 Then
            customer_name = "All"
        Else
            customer_name = New DatabaseConnect().get_by_id("company", selectedCustomer, "company")
        End If

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
            query = query & " and co.customer_id = " & selectedCustomer
        End If

        If cbMonth.Text <> "All" Then
            query = query & " and MONTH(co.date_issue) = " & monthToNumber(cbMonth.Text)
        End If

        If cbYear.Text <> "All" Then
            query = query & " and YEAR(co.date_issue) = " & cbYear.Text
        End If
        query = query & " order by total_qty"

        Dim table_content As String = ""
        Dim data_pts As String = ""
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
                    Dim percent As String = Val(Val(total_qty) / Val(total_sold2)).ToString("#0.##%")

                    total_sold2 += Val(total_qty)
                    grand_total2 += CDbl(total_amount)

                    tr = tr & "<td>" & barcode & "</td>"
                    tr = tr & "<td>" & unit & "</td>"
                    tr = tr & "<td>" & brand & "</td>"
                    tr = tr & "<td>" & color & "</td>"
                    tr = tr & "<td>" & desc & "</td>"
                    tr = tr & "<td>" & total_qty & "</td>"
                    tr = tr & "<td>" & percent & "</td>"
                    tr = tr & "<td>" & total_amount & "</td>"

                    tr = tr & "</tr>"
                    data_pts = data_pts & "{ y: " & total_qty & ", label: '" & desc & ",Unit:" & unit & "'},"
                    table_content = table_content & tr
                End While
                data_pts = data_pts.TrimEnd(CChar(","))

            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With

        If customer_name = "All" Then
            customer_name = ""
        Else
            customer_name = " sold by " & customer_name
        End If
        result = "<!DOCTYPE HTML>
<html>
<head>  
<script>
window.onload = function () {
	
var chart = new CanvasJS.Chart('chartContainer', {
	animationEnabled: true,
	
	title:{
		text:'Top sales" & customer_name & " '
	},
	axisX:{
		interval: 1
	},
	axisY2:{
		interlacedColor: 'rgba(1,77,101,.2)',
		gridColor: 'rgba(1,77,101,.1)',
		title: ''
	},
	data: [{
		type: 'bar',
		name: 'companies',
		axisYType: 'secondary',
		color: '#014D65',
		dataPoints: [
			" & data_pts & "
		]
	}]
});
chart.render();

}
</script>
</head>
<body>
<div id='chartContainer' style='height auto; width: 100%;'></div>
<script src='https://canvasjs.com/assets/script/canvasjs.min.js'></script>
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
        getMonth()
        getYear()
        loadPrintMethod()
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

    Private Sub getMonth()
        cbMonth.Items.Clear()
        Dim formatInfo = System.Globalization.DateTimeFormatInfo.CurrentInfo
        cbMonth.Items.Add("All")
        For i As Integer = 1 To 12
            Dim monthName = formatInfo.GetMonthName(i)
            cbMonth.Items.Add(monthName)
        Next
        cbMonth.SelectedIndex = 0
    End Sub

    Private Sub getYear()
        cbYear.Items.Clear()
        cbYear.Items.Add("All")
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("SELECT distinct YEAR(date_issue) FROM customer_orders where delivery_status <> 0 order by YEAR(date_issue) DESC")
            While .dr.Read
                cbYear.Items.Add(.dr.GetValue(0))
            End While
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
            cbYear.SelectedIndex = 0
        End With
    End Sub

    Private Function monthToNumber(ByVal month As String) As String
        Dim result As String = ""
        Select Case month.ToUpper
            Case "JANUARY"
                result = "1"
            Case "FEBRUARY"
                result = "2"
            Case "MARCH"
                result = "3"
            Case "APRIL"
                result = "4"
            Case "MAY"
                result = "5"
            Case "JUNE"
                result = "6"
            Case "JULY"
                result = "7"
            Case "AUGUST"
                result = "8"
            Case "SEPTEMBER"
                result = "9"
            Case "OCTOBER"
                result = "10"
            Case "NOVEMBER"
                result = "11"
            Case "DECEMBER"
                result = "12"
            Case Else
                result = ""
        End Select
        Return result
    End Function

    Private Sub loadPrintMethod()
        cbPrintMethod.Items.Clear()
        cbPrintMethod.Items.Add("Default")
        cbPrintMethod.Items.Add("Bar Chart")
        cbPrintMethod.SelectedIndex = 0
    End Sub
End Class