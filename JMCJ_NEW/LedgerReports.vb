﻿Public Class LedgerReports
    Public selectedCustomer As Integer = 0
    Public selectedModeOfPayment As Integer = -1
    Public selectedLedgerType As Integer = -1

    Private Sub LedgerReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getCustomerList()
        getMonth()
        getYear()
        getPaymentMode()
        getLedgerType()
    End Sub

    Public Sub getCustomerList()
        cbCustomer.DataSource = Nothing
        cbCustomer.Items.Clear()
        Dim db As New DatabaseConnect

        With db
            .selectByQuery("select distinct c.company,c.ID from company c inner join ledger l on l.customer = c.ID where l.status <> 0 order by c.company")
            Dim comboSource As New Dictionary(Of String, String)()

            comboSource.Add(0, "All")
            While db.dr.Read
                Dim cus As String = db.dr.GetValue(0)
                Dim id As String = db.dr.GetValue(1)
                comboSource.Add(id, cus)

            End While

            cbCustomer.DataSource = New BindingSource(comboSource, Nothing)
            cbCustomer.DisplayMember = "Value"
            cbCustomer.ValueMember = "Key"
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With

    End Sub

    Public Sub getPaymentMode()
        cbpayment_mode.DataSource = Nothing
        cbpayment_mode.Items.Clear()

        Dim comboSource As New Dictionary(Of String, String)()

        Dim db As New DatabaseConnect
        With db
            comboSource.Add(-1, "All")
            .selectByQuery("SELECT distinct payment_type from ledger where status <> 0 order by payment_type")
            While .dr.Read
                Select Case .dr.GetValue(0)
                    Case 0
                        comboSource.Add(0, "Cash")
                    Case 1
                        comboSource.Add(1, "C.O.D")
                    Case 2
                        comboSource.Add(2, "Credit")
                    Case 3
                        comboSource.Add(3, "Post Dated")
                End Select
            End While
        End With

        cbpayment_mode.DataSource = New BindingSource(comboSource, Nothing)
        cbpayment_mode.DisplayMember = "Value"
        cbpayment_mode.ValueMember = "Key"

    End Sub

    Private Sub getLedgerType()
        cbLedgerType.DataSource = Nothing
        cbLedgerType.Items.Clear()

        Dim comboSource As New Dictionary(Of String, String)()

        Dim db As New DatabaseConnect
        With db
            comboSource.Add(-1, "All")
            .selectByQuery("SELECT distinct ledger from ledger where status <> 0 order by ledger")
            While .dr.Read
                Select Case .dr.GetValue(0)
                    Case 0
                        comboSource.Add(0, "Charge")
                    Case 1
                        comboSource.Add(1, "Delivery")
                End Select
            End While
        End With

        cbLedgerType.DataSource = New BindingSource(comboSource, Nothing)
        cbLedgerType.DisplayMember = "Value"
        cbLedgerType.ValueMember = "Key"

    End Sub

    Private Sub cbCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCustomer.SelectedIndexChanged
        If cbCustomer.SelectedIndex >= 0 Then

            Dim key As String = CInt(DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Key)
            Dim value As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedCustomer = key

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

    Private Sub cbpayment_mode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbpayment_mode.SelectedIndexChanged
        If cbpayment_mode.SelectedIndex >= 0 Then
            Dim key As String = CInt(DirectCast(cbpayment_mode.SelectedItem, KeyValuePair(Of String, String)).Key)
            Dim value As String = DirectCast(cbpayment_mode.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedModeOfPayment = key
        End If
    End Sub

    Private Sub cbLedgerType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLedgerType.SelectedIndexChanged
        If cbLedgerType.SelectedIndex >= 0 Then
            Dim key As String = CInt(DirectCast(cbLedgerType.SelectedItem, KeyValuePair(Of String, String)).Key)
            Dim value As String = DirectCast(cbLedgerType.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedLedgerType = key
        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        btnPrint.Enabled = False
        Dim path As String = Application.StartupPath & "\ledger.html"
        Try
            Dim code As String = ""
            Select Case cbpayment_mode.Text
                Case "Cash"
                    code = generatePrintCash()
                Case "Credit"
                    code = generatePrintCredit()
                Case Else
                    code = generatePrint()
            End Select

            Dim myWrite As System.IO.StreamWriter
            myWrite = IO.File.CreateText(path)
            myWrite.WriteLine(code)
            myWrite.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Dim proc As New System.Diagnostics.Process()
        proc = Process.Start(path, "")
        btnPrint.Enabled = True
    End Sub

    Private Function generatePrint()
        Dim total_amount As Double = 0
        Dim query As String = "Select l.*,c.company from ledger as l 
                    inner join company as c on c.id = l.customer  where l.status <> 0"

        If cbCustomer.Text <> "All" Then
            query = query & " and c.id = " & selectedCustomer
        End If

        If cbpayment_mode.Text <> "All" Then
            query = query & " and l.payment_type = " & selectedModeOfPayment
        End If

        If cbLedgerType.Text <> "All" Then
            query = query & " and l.ledger = " & selectedLedgerType
        End If

        If cbMonth.Text <> "All" Then
            query = query & " and MONTH(l.date_issue) = " & monthToNumber(cbMonth.Text)
        End If

        If cbYear.Text <> "All" Then
            query = query & " and YEAR(l.date_issue) = " & cbYear.Text
        End If

        query = query & " order by c.company"
        Dim result As String = ""
        Dim table_content As String = ""
        Dim dbprod As New DatabaseConnect
        With dbprod
            .selectByQuery(query)
            If .dr.HasRows Then
                While .dr.Read

                    Dim tr As String = "<tr>"
                    Dim id As Integer = .dr("id")
                    Dim customer As String = .dr("company")
                    Dim date_issue As String = .dr("date_issue")
                    Dim amount As String = .dr("amount")
                    Dim paid As String = .dr("paid")
                    Dim floating As String = .dr("floating")
                    Dim date_paid As String = .dr("date_paid")
                    Dim bank_details As String = .dr("bank_details")
                    Dim check_date As String = .dr("check_date")
                    Dim payment As String = .dr("payment_type")
                    Dim ledger_type As String = .dr("ledger")

                    total_amount += Val(amount)

                    paid = If(paid = True, "Yes", "No")
                    floating = If(floating = True, "Yes", "No")

                    Select Case payment
                        Case "0"
                            payment = "Cash"
                        Case "1"
                            payment = "C.O.D"
                        Case "2"
                            payment = "Credit"
                        Case "3"
                            payment = "Post Dated"
                    End Select
                    Select Case ledger_type
                        Case "0"
                            ledger_type = "Charge"
                        Case "1"
                            ledger_type = "Delivery"
                    End Select

                    tr = tr & "<td>" & customer & "</td>"
                    tr = tr & "<td>" & date_issue & "</td>"
                    tr = tr & "<td style='color:red;'>" & Val(amount).ToString("N2") & "</td>"
                    tr = tr & "<td>" & paid & "</td>"
                    tr = tr & "<td>" & floating & "</td>"
                    tr = tr & "<td>" & date_paid & "</td>"
                    tr = tr & "<td>" & bank_details & "</td>"
                    tr = tr & "<td>" & check_date & "</td>"
                    tr = tr & "<td>" & payment & "</td>"
                    tr = tr & "<td>" & ledger_type & "</td>"
                    tr = tr & "</tr>"
                    table_content = table_content & tr

                End While
            Else
                MsgBox("No Record found!", MsgBoxStyle.Critical)
            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
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
        font-size:8pt;
    }

    td, th {
    	border: 1px solid #dddddd;
    	text-align: left;
    	padding: 5px;
    }

    tr:nth-child(even) {

    }
    </style>
    </head>
    <body>
    <h3><center>Ledger Reports</center></h3>
    <table>
      <thead>
      <tr>
    	<th>Customer</th>
    	<th>Date Invoice</th>
    	<th>Amount</th>
    	<th>Paid</th>
    	<th>Floating</th>
    	<th>Date Paid</th>
    	<th>Bank Details</th>
    	<th>Check Date</th>
    	<th>Payment Type</th>
    	<th>Ledger Type</th>
      </tr>
      </thead>
      <tbody>
        " & table_content & "
        <tr>
            <td colspan='2'><strong>TOTAL AMOUNT</strong></td><td style='color:red;''><strong>" & Val(total_amount).ToString("N2") & "</strong></td>
        </tr>
      </tbody>
    </table>
    </body>
    </html>
    "
        Return result
    End Function

    Private Function generatePrintCash()
        Dim total_amount As Double = 0

        Dim query As String = "Select l.*,c.company from ledger as l 
                    inner join company as c on c.id = l.customer  where l.status <> 0"

        If cbCustomer.Text <> "All" Then
            query = query & " and c.id = " & selectedCustomer
        End If

        If cbpayment_mode.Text <> "All" Then
            query = query & " and l.payment_type = " & selectedModeOfPayment
        End If

        If cbLedgerType.Text <> "All" Then
            query = query & " and l.ledger = " & selectedLedgerType
        End If

        If cbMonth.Text <> "All" Then
            query = query & " and MONTH(l.date_issue) = " & monthToNumber(cbMonth.Text)
        End If

        If cbYear.Text <> "All" Then
            query = query & " and YEAR(l.date_issue) = " & cbYear.Text
        End If

        query = query & " order by c.company"

        Dim result As String = ""
        Dim table_content As String = ""
        Dim dbprod As New DatabaseConnect
        With dbprod
            .selectByQuery(query)
            If .dr.HasRows Then
                While .dr.Read
                    Dim tr As String = " <tr> "

                    Dim id As Integer = .dr("id")
                    Dim customer As String = .dr("company")
                    Dim date_issue As String = .dr("date_issue")
                    Dim amount As String = .dr("amount")
                    Dim date_paid As String = .dr("date_paid")
                    Dim ledger_type As String = .dr("ledger")

                    total_amount += Val(amount)

                    Select Case ledger_type
                        Case "0"
                            ledger_type = "Charge"
                        Case "1"
                            ledger_type = "Delivery"
                    End Select


                    tr = tr & "<td>" & customer & "</td>"
                    tr = tr & "<td>" & date_issue & "</td>"
                    tr = tr & "<td style='color:red;'>" & Val(amount).ToString("N2") & "</td>"
                    tr = tr & "<td>" & date_paid & "</td>"
                    tr = tr & "<td>" & ledger_type & "</td>"
                    tr = tr & "</tr>"
                    table_content = table_content & tr

                End While
            Else
                MsgBox("No Record found!", MsgBoxStyle.Critical)
            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
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
        font-size:8pt;
    }

    td, th {
    	border: 1px solid #dddddd;
    	text-align: left;
    	padding: 5px;
    }

    tr:nth-child(even) {

    }
    </style>
    </head>
    <body>

    <h3><center>Ledger Reports</center></h3>

    <table>
      <thead>
      <tr>
    	<th>Customer</th>
    	<th>Date Invoice</th>
    	<th>Amount</th>
    	<th>Date Paid</th>
    	<th>Ledger Type</th>
      </tr>
      </thead>
      <tbody>
        " & table_content & "
        <tr>
            <td colspan='2' style='color:red;'><strong>TOTAL AMOUNT</strong></td><td style='color:red;'><strong>" & Val(total_amount).ToString("N2") & "</strong></td>
        </tr>
      </tbody>
    </table>

    </body>
    </html>

    "
        Return result
    End Function


    Private Function generatePrintCredit()
        Dim total_amount As Double = 0
        Dim query As String = "Select l.*,c.company from ledger as l 
                    inner join company as c on c.id = l.customer  where l.status <> 0"

        If cbCustomer.Text <> "All" Then
            query = query & " and c.id = " & selectedCustomer
        End If

        If cbpayment_mode.Text <> "All" Then
            query = query & " and l.payment_type = " & selectedModeOfPayment
        End If

        If cbLedgerType.Text <> "All" Then
            query = query & " and l.ledger = " & selectedLedgerType
        End If

        If cbMonth.Text <> "All" Then
            query = query & " and MONTH(l.date_issue) = " & monthToNumber(cbMonth.Text)
        End If

        If cbYear.Text <> "All" Then
            query = query & " and YEAR(l.date_issue) = " & cbYear.Text
        End If

        query = query & " order by c.company"
        Dim result As String = ""
        Dim table_content As String = ""
        Dim dbprod As New DatabaseConnect
        With dbprod
            .selectByQuery(query)
            If .dr.HasRows Then
                While .dr.Read
                    Dim tr As String = "<tr>"
                    Dim id As Integer = .dr("id")
                    Dim customer As String = .dr("company")
                    Dim date_issue As String = .dr("date_issue")
                    Dim amount As String = .dr("amount")
                    Dim paid As String = .dr("paid")
                    'Dim floating As String = .dr("floating")
                    'Dim date_paid As String = .dr("date_paid")
                    'Dim bank_details As String = .dr("bank_details")
                    'Dim check_date As String = .dr("check_date")
                    Dim payment As String = .dr("payment_type")
                    Dim ledger_type As String = .dr("ledger")

                    paid = If(paid = True, "Yes", "No")

                    total_amount += Val(amount)
                    'floating = If(floating = True, "Yes", "No")

                    Select Case payment
                        Case "0"
                            payment = "Cash"
                        Case "1"
                            payment = "C.O.D"
                        Case "2"
                            payment = "Credit"
                        Case "3"
                            payment = "Post Dated"
                    End Select
                    Select Case ledger_type
                        Case "0"
                            ledger_type = "Charge"
                        Case "1"
                            ledger_type = "Delivery"
                    End Select


                    tr = tr & "<td>" & customer & "</td>"
                    tr = tr & "<td>" & date_issue & "</td>"
                    tr = tr & "<td style='color:red;'>" & Val(amount).ToString("N2") & "</td>"
                    tr = tr & "<td>" & paid & "</td>"
                    'tr = tr & "<td>" & floating & "</td>"
                    'tr = tr & "<td>" & date_paid & "</td>"
                    'tr = tr & "<td>" & bank_details & "</td>"
                    'tr = tr & "<td>" & check_date & "</td>"
                    tr = tr & "<td>" & payment & "</td>"
                    tr = tr & "<td>" & ledger_type & "</td>"
                    tr = tr & "</tr>"
                    table_content = table_content & tr

                End While
            Else
                MsgBox("No Record found!", MsgBoxStyle.Critical)
            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
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
        font-size:8pt;
    }

    td, th {
    	border: 1px solid #dddddd;
    	text-align: left;
    	padding: 5px;
    }

    tr:nth-child(even) {

    }
    </style>
    </head>
    <body>

    <h3><center>Ledger Reports</center></h3>

    <table>
      <thead>
      <tr>
    	<th>Customer</th>
    	<th>Date Invoice</th>
    	<th>Amount</th>
    	<th>Paid</th>
    	<th>Payment Type</th>
    	<th>Ledger Type</th>
      </tr>
      </thead>
      <tbody>
        " & table_content & "
        <tr>
            <td colspan='2'><strong>TOTAL AMOUNT</strong></td><td style='color:red;'>" & Val(total_amount).ToString("N2") & "</td>
        </tr>
      </tbody>
    </table>
    </body>
    </html>
    "
        Return result
    End Function
End Class