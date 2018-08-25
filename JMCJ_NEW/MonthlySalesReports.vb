Public Class MonthlySalesReports

    Private Function generatePrint(ByVal filter As Dictionary(Of String, String))
        Dim result As String = ""

        'get total sales
        Dim query_total_sales As String = "Select SUM(cop.total_amount) as sale from customer_order_products as cop 
        INNER JOIN ledger as l ON l.id = cop.customer_order_ledger_id 
        where cop.total_amount > 0"
        If filter.ContainsKey("month") Then
            Dim month As String = filter.Item("month")
            If month <> "All" Then
                query_total_sales = query_total_sales & " and MONTH(l.date_issue) = " & monthToNumber(month)
            End If
        End If

        If filter.ContainsKey("year") Then
            Dim year As String = filter.Item("year")
            If year <> "All" Then
                query_total_sales = query_total_sales & " and YEAR(l.date_issue) = " & year
            End If
        End If


        Dim total_sales As String
        Dim dbprice As New DatabaseConnect
        With dbprice
            .selectByQuery(query_total_sales)
            If .dr.Read Then
                total_sales = Val(.dr("sale")).ToString("N2")
            Else
                total_sales = 0
            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With

        Dim query As String = "Select Format(cop.created_at,'mm-yyyy') as monthly,count(l.id) as orders, sum(cop.quantity) as qty, sum(cop.total_amount) as total_sales from customer_order_products as cop
                    inner join ledger as l ON l.id = cop.customer_order_ledger_id 
                    where l.status <> 0"

        If filter.ContainsKey("month") Then
            Dim month As String = filter.Item("month")
            If month <> "All" Then
                query = query & " and MONTH(date_issue) = " & monthToNumber(month)
            End If
        End If

        If filter.ContainsKey("year") Then
            Dim year As String = filter.Item("year")
            If year <> "All" Then
                query = query & " and YEAR(date_issue) = " & year
            End If
        End If
        query = query & " group by Format(cop.created_at,'mm-yyyy') order by Format(cop.created_at,'mm-yyyy') desc"

        Dim table_content As String = ""
        Dim dbprod As New DatabaseConnect()
        With dbprod
            .selectByQuery(query)
            If .dr.HasRows Then
                While .dr.Read
                    Dim tr As String = "<tr>"
                    Dim daily As String = .dr("monthly")
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
<div id='header' style='text-align:center;'>
	<img src='header.png' width='180'>
	<p style='font-family:Arial;margin:1px;font-size:8pt;'>42 K Roosevelt Ave, Quezon City </p>
	<p style='font-family:Arial;margin:1px;font-size:8pt;'>Telefax: 411-5274. Globe:0917-132-1241</p>
	<p style='font-family:Arial;margin:1px;font-size:8pt;'>Email:purchasing.jmcj@gmail.com</p>
	<p style='font-family:Arial black;font-weight:bold;margin:1px;font-size:15pt;'>MONTHLY SALES</p>
</div>
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
	<th>Total Customer Order</th>
	<th>Total Quantity Sold</th>
	<th>Total Amount Sold</th>
  </tr>
  </thead>
  <tbody>
	  " & table_content & "
    <tr>
		<td colspan='3' style='text-align:right;'><strong>Total</strong></td>
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

    Private Sub MonthlySalesReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getMonth()
        getYear()
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
            .selectByQuery("SELECT distinct YEAR(date_issue) FROM ledger where status <> 0 order by YEAR(date_issue) DESC")
            While .dr.Read
                cbYear.Items.Add(.dr.GetValue(0))
            End While
            cbYear.SelectedIndex = 0
        End With
    End Sub

    Private Function monthToNumber(ByVal month As String) As String
        Dim result As String = ""

        Select Case month.ToUpper
            Case "JANUARY"
                result = "01"
            Case "FEBRUARY"
                result = "02"
            Case "MARCH"
                result = "03"
            Case "APRIL"
                result = "04"
            Case "MAY"
                result = "05"
            Case "JUNE"
                result = "06"
            Case "JULY"
                result = "07"
            Case "AUGUST"
                result = "08"
            Case "SEPTEMBER"
                result = "09"
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

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        btnPrint.Enabled = False
        Dim path As String = Application.StartupPath & "\monthly_sales_reports.html"
        Dim filter As New Dictionary(Of String, String)
        filter.Add("month", cbMonth.Text)
        filter.Add("year", cbYear.Text)

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
End Class