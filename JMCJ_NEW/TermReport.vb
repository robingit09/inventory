﻿Public Class TermReport

    Private selectedCustomer As Integer = 0
    Dim remaining_val As String = ""
    Dim remaining_query As String = ""
    Private selectedLedgerType As Integer = -1

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        '** beginning of check if filter record exist
        'Dim queryValidator As String = "select ID from ledger where status <> 0 and payment_type = 2"

        'If Trim(cbCustomer.Text) <> "All" Then
        '    queryValidator = queryValidator & " and customer = " & selectedCustomer
        'End If

        'If Trim(cbRemaining.Text) <> "All" Then
        '    queryValidator = queryValidator & " and DateDiff('d',NOW(),[payment_due_date]) " & remaining_query
        'End If

        'If Trim(cbLedgerType.Text) <> "All" Then
        '    queryValidator = queryValidator & " and ledger = " & selectedLedgerType
        'End If

        'If cbMonth.Text <> "All" Then
        '    queryValidator = queryValidator & " and MONTH(date_issue) = " & monthToNumber(cbMonth.Text)
        'End If

        'If cbYear.Text <> "All" Then
        '    queryValidator = queryValidator & " and YEAR(date_issue) = " & cbYear.Text
        'End If

        'Dim db As New DatabaseConnect
        'With db
        '    .selectByQuery(queryValidator)
        '    If .dr.Read Then

        '    Else
        '        MsgBox("No record found!", MsgBoxStyle.Critical)
        '        .dr.Close()
        '        .cmd.Dispose()
        '        .con.Close()
        '        Exit Sub
        '    End If
        'End With
        '*** end - check if filter record exist****'

        'Dim cr As New crTermReports
        'cr.RecordSelectionFormula = "{ledger.status} <> 0 and {ledger.payment_type} = 2"

        'If cbCustomer.Text <> "All" Then
        '    cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND ({ledger.customer}) = " & selectedCustomer
        'End If

        'If cbRemaining.Text <> "All" Then
        '    cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND datediff('d',CurrentDate,{ledger.payment_due_date}) " & remaining_val
        'End If

        'If cbLedgerType.Text <> "All" Then
        '    cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND {ledger.ledger} = " & selectedLedgerType
        'End If

        'If cbMonth.Text <> "All" Then
        '    cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND MONTH({ledger.date_issue}) = " & monthToNumber(cbMonth.Text)
        'End If

        'If cbYear.Text <> "All" Then
        '    cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND YEAR({ledger.date_issue}) = " & cbYear.Text
        'End If

        'ReportViewer.Enabled = True
        'ReportViewer.CrystalReportViewer1.ReportSource = cr
        'ReportViewer.CrystalReportViewer1.Refresh()
        'ReportViewer.CrystalReportViewer1.RefreshReport()
        'ReportViewer.ShowDialog()
        btnPrint.Enabled = False
        Dim path As String = Application.StartupPath & "\term.html"
        Try
            Dim code As String = ""
            code = generatePrint()
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

    Private Sub FilterTermReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getCustomerList("")
        loadRemaining()
        loadledgertype()
        getMonth()
        getYear()
    End Sub

    Public Sub getCustomerList(ByVal query As String)

        cbCustomer.DataSource = Nothing
        cbCustomer.Items.Clear()
        Dim db As New DatabaseConnect

        With db
            If query = "" Then
                .selectByQuery("select distinct company,ID from company where status <> 0 order by company")
            Else

            End If

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

    Private Sub loadRemaining()
        cbRemaining.Items.Clear()
        cbRemaining.Items.Add("All")
        cbRemaining.Items.Add("Over Due")
        cbRemaining.Items.Add("Due Date")
        cbRemaining.Items.Add("3 to 1 Days")
        cbRemaining.Items.Add("5 to 4 Days")
        cbRemaining.Items.Add("7 to 6 Days")
        cbRemaining.SelectedIndex = 0
    End Sub

    Private Sub cbCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCustomer.SelectedIndexChanged
        If cbCustomer.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedCustomer = CInt(key)
        End If
    End Sub

    Private Sub cbRemaining_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRemaining.SelectedIndexChanged
        If (cbRemaining.SelectedIndex > 0) Then
            Select Case cbRemaining.SelectedIndex
                Case 1
                    remaining_val = "< 0"
                    remaining_query = "< 0"
                Case 2
                    remaining_val = " = 0"
                    remaining_query = " = 0"
                Case 3
                    remaining_val = " in 1 to 3"
                    remaining_query = " between 1 and 3"
                Case 4
                    remaining_val = " in 4 to 5"
                    remaining_query = " between 4 and 5"
                Case 5
                    remaining_val = " in 6 to 7"
                    remaining_query = " between 6 and 7"
            End Select
        End If
    End Sub

    Public Sub loadledgertype()
        cbLedgerType.DataSource = Nothing
        cbLedgerType.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(-1, "All")

        Dim tableledger As New DatabaseConnect
        With tableledger
            .selectByQuery("SELECT distinct ledger from ledger where status <> 0")
            While .dr.Read
                Dim id As String = .dr.GetValue(0)
                Select Case id
                    Case 0
                        comboSource.Add(id, "Charge")
                    Case 1
                        comboSource.Add(id, "Delivery")
                End Select
            End While
            cbLedgerType.DataSource = New BindingSource(comboSource, Nothing)
            cbLedgerType.DisplayMember = "Value"
            cbLedgerType.ValueMember = "Key"
        End With
    End Sub

    Private Sub cbLedgerType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLedgerType.SelectedIndexChanged
        If cbLedgerType.SelectedIndex > 0 Then
            Select Case Trim(cbLedgerType.Text).ToLower
                Case "charge"
                    selectedLedgerType = 0
                Case "delivery"
                    selectedLedgerType = 1
                Case Else
                    selectedLedgerType = -1
            End Select
        End If
    End Sub

    Private Function generatePrint()
        Dim total_amount As Double = 0
        Dim query As String = "Select l.*,c.company, DateDiff('d',NOW(),l.payment_due_date) as r from ledger as l 
                    inner join company as c on c.id = l.customer  where l.status <> 0 and l.payment_type = 2"

        If selectedCustomer > 0 And cbCustomer.Text <> "All" Then
            query = query & " and c.id = " & selectedCustomer
        End If

        If cbRemaining.Text <> "All" Then
            query = query & " and DateDiff('d',NOW(),l.payment_due_date) " & remaining_query
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
                    Dim color_remaining As String = ""
                    Dim tr As String = "<tr>"
                    Dim id As Integer = .dr("id")
                    Dim customer As String = .dr("company")
                    Dim remaining As String = .dr("r")
                    Dim date_issue As String = .dr("date_issue")
                    Dim invoice_no As String = .dr("invoice_no")
                    Dim amount As String = .dr("amount")
                    Dim counter_no As String = .dr("counter_no")
                    Dim terms As String = .dr("payment_terms")
                    Dim due_date As String = .dr("payment_due_date")
                    Dim ledger_type As String = .dr("ledger")
                    total_amount += Val(amount)

                    'Dim edate = due_date
                    'Dim pdate As DateTime = Convert.ToDateTime(edate)
                    'edate = pdate.ToString("MM-dd-yyyy", System.Globalization.CultureInfo.InvariantCulture)


                    'remaining = pdate.Subtract(DateTime.Now).Days
                    Dim remaining_val As String = remaining
                    If CInt(remaining) < 0 Then
                        remaining_val = "Over Due"
                        color_remaining = "style='color:red;'"
                    End If
                    If CInt(remaining) = 0 Then
                        remaining_val = "Due Date"
                        color_remaining = "style='color:red;'"
                    End If

                    Select Case ledger_type
                        Case "0"
                            ledger_type = "Charge"
                        Case "1"
                            ledger_type = "Delivery"
                    End Select

                    tr = tr & "<td>" & customer & "</td>"
                    tr = tr & "<td " & color_remaining & ">" & remaining_val & "</td>"
                    tr = tr & "<td>" & date_issue & "</td>"
                    tr = tr & "<td>" & invoice_no & "</td>"
                    tr = tr & "<td style='color:red;'>" & Val(amount).ToString("N2") & "</td>"
                    tr = tr & "<td>" & counter_no & "</td>"
                    tr = tr & "<td>" & terms & "</td>"
                    tr = tr & "<td>" & due_date & "</td>"
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
    <h3><center>Terms Reports</center></h3>
    <table>
      <thead>
      <tr>
    	<th>Customer</th>
    	<th>Remaining</th>
	    <th>Date Invoice</th>
    	<th>Invoice No</th>
	    <th>Amount</th>
    	<th>Counter no </th>
    	<th>Terms</th>
    	<th>Due Date</th>
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

End Class