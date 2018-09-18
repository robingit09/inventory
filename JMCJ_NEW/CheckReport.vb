Public Class CheckReport

    Private invoice_customer As Integer = 0
    Dim invoice_remaining_val As String = ""
    Dim invoice_remaining_query As String = ""
    Private invoice_LedgerType As Integer = -1

    Private check_customer As Integer = 0
    Dim check_remaining_val As String = ""
    Dim check_remaining_query As String = ""
    Private check_LedgerType As Integer = -1
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintCheckDate.Click
        '** beginning of check if filter record exist
        Dim queryValidator As String = "select ID,customer from ledger where status <> 0 and (payment_type = 1 or payment_type = 3)"

        If Trim(cbCustomer2.Text) <> "All" Then
            queryValidator = queryValidator & " and customer = " & check_customer
        End If

        If Trim(cbRemaining2.Text) <> "All" Then
            queryValidator = queryValidator & " and DateDiff('d',NOW(),[check_date]) " & check_remaining_query
        End If

        If Trim(cbLedgerType2.Text) <> "All" Then
            queryValidator = queryValidator & " and ledger = " & check_LedgerType
        End If

        If cbCheckFloating.Text <> "All" Then
            If cbCheckFloating.Text = "Yes" Then
                queryValidator = queryValidator & " and floating = True"
            End If

            If cbCheckFloating.Text = "No" Then
                queryValidator = queryValidator & " and floating = False"
            End If
        End If

        If cbCheckMonth.Text <> "All" Then
            queryValidator = queryValidator & " and MONTH(check_date) = " & monthToNumber(cbCheckMonth.Text)
        End If

        If cbCheckYear.Text <> "All" Then
            queryValidator = queryValidator & " and YEAR(check_date) = " & cbCheckYear.Text
        End If

        Dim db As New DatabaseConnect
        With db
            .selectByQuery(queryValidator)
            If .dr.Read Then

            Else
                MsgBox("No record found!", MsgBoxStyle.Critical)
                .dr.Close()
                .cmd.Dispose()
                .con.Close()
                Exit Sub
            End If
        End With
        '*** end - check if filter record exist****'

        'Dim cr As New crLedgerAllCustomer
        'cr.RecordSelectionFormula = "{ledger.status} <> 0 and ({ledger.payment_type} = 1 or {ledger.payment_type} = 3)"

        'If cbCustomer2.Text <> "All" Then
        '    cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND ({ledger.customer}) = " & check_customer
        'End If

        'If cbRemaining2.Text <> "All" Then
        '    cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND datediff('d',CurrentDate,{ledger.check_date}) " & check_remaining_val
        'End If

        'If cbLedgerType2.Text <> "All" Then
        '    cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND {ledger.ledger} = " & check_LedgerType
        'End If

        'If cbCheckFloating.Text <> "All" Then
        '    If cbCheckFloating.Text = "Yes" Then
        '        cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND {ledger.floating} = True"
        '    End If
        '    If cbCheckFloating.Text = "No" Then
        '        cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND {ledger.floating} = False"
        '    End If
        'End If

        'If cbCheckMonth.Text <> "All" Then
        '    cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND MONTH({ledger.check_date}) = " & monthToNumber(cbCheckMonth.Text)
        'End If

        'If cbCheckYear.Text <> "All" Then
        '    cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND YEAR({ledger.check_date}) = " & cbCheckYear.Text
        'End If

        'ReportViewer.Enabled = True
        'ReportViewer.CrystalReportViewer1.ReportSource = cr
        'ReportViewer.CrystalReportViewer1.Refresh()
        'ReportViewer.CrystalReportViewer1.RefreshReport()
        'ReportViewer.ShowDialog()

        btnPrintCheckDate.Enabled = False
        Dim path As String = Application.StartupPath & "\check.html"
        Try
            Dim code As String = ""
            code = generatePrintByCheckDate()
            Dim myWrite As System.IO.StreamWriter
            myWrite = IO.File.CreateText(path)
            myWrite.WriteLine(code)
            myWrite.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Dim proc As New System.Diagnostics.Process()
        proc = Process.Start(path, "")
        btnPrintCheckDate.Enabled = True
    End Sub

    Private Sub getMonth()
        cbCheckMonth.Items.Clear()
        cbInvoiceMonth.Items.Clear()
        Dim formatInfo = System.Globalization.DateTimeFormatInfo.CurrentInfo
        cbCheckMonth.Items.Add("All")
        cbInvoiceMonth.Items.Add("All")
        For i As Integer = 1 To 12
            Dim monthName = formatInfo.GetMonthName(i)
            cbCheckMonth.Items.Add(monthName)
            cbInvoiceMonth.Items.Add(monthName)
        Next
        cbCheckMonth.SelectedIndex = 0
        cbInvoiceMonth.SelectedIndex = 0
    End Sub

    Private Sub getYear()
        cbCheckYear.Items.Clear()
        cbCheckYear.Items.Add("All")
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("SELECT distinct YEAR(date_issue) FROM ledger where status <> 0 order by YEAR(date_issue) DESC")
            While .dr.Read
                cbCheckYear.Items.Add(.dr.GetValue(0))
            End While
            cbCheckYear.SelectedIndex = 0
        End With
    End Sub


    Private Sub getCheckYear()
        cbInvoiceYear.Items.Clear()
        cbInvoiceYear.Items.Add("All")
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("SELECT distinct YEAR(check_date) FROM ledger where status <> 0 order by YEAR(check_date) DESC")
            While .dr.Read
                cbInvoiceYear.Items.Add(.dr.GetValue(0))
            End While
            cbInvoiceYear.SelectedIndex = 0
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

    Private Sub FilterCheckReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getCustomerList("")
        loadRemaining()
        loadledgertype()
        loadCheckFloating()

        getMonth()
        getYear()
        getCheckYear()
    End Sub

    Public Sub loadCheckFloating()
        cbCheckFloating.Items.Clear()
        cbCheckFloating.Items.Add("All")
        cbCheckFloating.Items.Add("Yes")
        cbCheckFloating.Items.Add("No")
        cbCheckFloating.SelectedIndex = 0
    End Sub

    Public Sub getCustomerList(ByVal query As String)

        cbCustomer.DataSource = Nothing
        cbCustomer.Items.Clear()

        cbCustomer2.DataSource = Nothing
        cbCustomer2.Items.Clear()

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

            cbCustomer2.DataSource = New BindingSource(comboSource, Nothing)
            cbCustomer2.DisplayMember = "Value"
            cbCustomer2.ValueMember = "Key"
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With

    End Sub

    Private Sub loadRemaining()
        cbRemaining.Items.Clear()
        cbRemaining.Items.Add("All")
        cbRemaining.Items.Add("Over Due")
        cbRemaining.Items.Add("Due Date")
        cbRemaining.Items.Add("3 to 1 Days")
        cbRemaining.Items.Add("5 to 4 Days")
        cbRemaining.Items.Add("7 to 6 Days")
        cbRemaining.SelectedIndex = 0

        cbRemaining2.Items.Clear()
        cbRemaining2.Items.Add("All")
        cbRemaining2.Items.Add("Over Due")
        cbRemaining2.Items.Add("Due Date")
        cbRemaining2.Items.Add("3 to 1 Days")
        cbRemaining2.Items.Add("5 to 4 Days")
        cbRemaining2.Items.Add("7 to 6 Days")
        cbRemaining2.SelectedIndex = 0
    End Sub

    Public Sub loadledgertype()
        cbLedgerType.DataSource = Nothing
        cbLedgerType.Items.Clear()

        cbLedgerType2.DataSource = Nothing
        cbLedgerType2.Items.Clear()


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

            cbLedgerType2.DataSource = New BindingSource(comboSource, Nothing)
            cbLedgerType2.DisplayMember = "Value"
            cbLedgerType2.ValueMember = "Key"
        End With
    End Sub

    Private Sub btnPrintDateInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintDateInvoice.Click
        '** beginning of check if filter record exist
        Dim queryValidator As String = "select ID,customer from ledger where status <> 0 and (payment_type = 1 or payment_type = 3)"

        If Trim(cbCustomer.Text) <> "All" Then
            queryValidator = queryValidator & " and customer = " & invoice_customer
        End If

        If Trim(cbRemaining.Text) <> "All" Then
            queryValidator = queryValidator & " and DateDiff('d',NOW(),[payment_due_date]) " & invoice_remaining_query
        End If

        If Trim(cbLedgerType.Text) <> "All" Then
            queryValidator = queryValidator & " and ledger = " & invoice_LedgerType
        End If

        If cbInvoiceMonth.Text <> "All" Then
            queryValidator = queryValidator & " and MONTH(date_issue) = " & monthToNumber(cbInvoiceMonth.Text)
        End If

        If cbCheckYear.Text <> "All" Then
            queryValidator = queryValidator & " and YEAR(date_issue) = " & cbInvoiceYear.Text
        End If

        Dim db As New DatabaseConnect
        With db
            .selectByQuery(queryValidator)
            If .dr.Read Then

            Else
                MsgBox("No record found!", MsgBoxStyle.Critical)
                .dr.Close()
                .cmd.Dispose()
                .con.Close()
                Exit Sub
            End If
        End With
        '*** end - check if filter record exist****'

        'Dim cr As New crLedgerAllCustomer
        'cr.RecordSelectionFormula = "{ledger.status} <> 0 and ({ledger.payment_type} = 1 or {ledger.payment_type} = 3)"

        'If cbCustomer.Text <> "All" Then
        '    cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND ({ledger.customer}) = " & invoice_customer
        'End If

        'If cbRemaining.Text <> "All" Then
        '    cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND datediff('d',CurrentDate,{ledger.payment_due_date}) " & invoice_remaining_val
        'End If

        'If cbLedgerType.Text <> "All" Then
        '    cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND {ledger.ledger} = " & invoice_LedgerType
        'End If

        'If cbInvoiceMonth.Text <> "All" Then
        '    cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND MONTH({ledger.date_issue}) = " & monthToNumber(cbInvoiceMonth.Text)
        'End If

        'If cbInvoiceYear.Text <> "All" Then
        '    cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND YEAR({ledger.date_issue}) = " & cbInvoiceYear.Text
        'End If

        'ReportViewer.Enabled = True
        'ReportViewer.CrystalReportViewer1.ReportSource = cr
        'ReportViewer.CrystalReportViewer1.Refresh()
        'ReportViewer.CrystalReportViewer1.RefreshReport()
        'ReportViewer.ShowDialog()
        btnPrintDateInvoice.Enabled = False
        Dim path As String = Application.StartupPath & "\check.html"
        Try
            Dim code As String = ""
            code = generatePrintByInvoiceDate()
            Dim myWrite As System.IO.StreamWriter
            myWrite = IO.File.CreateText(path)
            myWrite.WriteLine(code)
            myWrite.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Dim proc As New System.Diagnostics.Process()
        proc = Process.Start(path, "")
        btnPrintDateInvoice.Enabled = True
    End Sub

    Private Sub cbCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCustomer.SelectedIndexChanged
        If cbCustomer.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Value
            invoice_customer = CInt(key)
        End If
    End Sub

    Private Sub cbRemaining_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRemaining.SelectedIndexChanged
        If (cbRemaining.SelectedIndex > 0) Then
            Select Case cbRemaining.SelectedIndex
                Case 1
                    invoice_remaining_val = "< 0"
                    invoice_remaining_query = "< 0"
                Case 2
                    invoice_remaining_val = " = 0"
                    invoice_remaining_query = " = 0"
                Case 3
                    invoice_remaining_val = " in 1 to 3"
                    invoice_remaining_query = " between 1 and 3"
                Case 4
                    invoice_remaining_val = " in 4 to 5"
                    invoice_remaining_query = " between 4 and 5"
                Case 5
                    invoice_remaining_val = " in 6 to 7"
                    invoice_remaining_query = " between 6 and 7"
            End Select
        End If
    End Sub

    Private Sub cbLedgerType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLedgerType.SelectedIndexChanged
        If cbLedgerType.SelectedIndex > 0 Then
            Select Case Trim(cbLedgerType.Text).ToLower
                Case "charge"
                    invoice_LedgerType = 0
                Case "delivery"
                    invoice_LedgerType = 1
                Case Else
                    invoice_LedgerType = -1
            End Select
        End If
    End Sub


    Private Sub cbCustomer2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCustomer2.SelectedIndexChanged
        If cbCustomer2.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbCustomer2.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbCustomer2.SelectedItem, KeyValuePair(Of String, String)).Value
            check_customer = CInt(key)
        End If
    End Sub

    Private Sub cbRemaining2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRemaining2.SelectedIndexChanged
        If (cbRemaining2.SelectedIndex > 0) Then
            Select Case cbRemaining2.SelectedIndex
                Case 1
                    check_remaining_val = "< 0"
                    check_remaining_query = "< 0"
                Case 2
                    check_remaining_val = " = 0"
                    check_remaining_query = " = 0"
                Case 3
                    check_remaining_val = " in 1 to 3"
                    check_remaining_query = " between 1 and 3"
                Case 4
                    check_remaining_val = " in 4 to 5"
                    check_remaining_query = " between 4 and 5"
                Case 5
                    check_remaining_val = " in 6 to 7"
                    check_remaining_query = " between 6 and 7"
            End Select
        End If
    End Sub

    Private Sub cbLedgerType2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLedgerType2.SelectedIndexChanged
        If cbLedgerType2.SelectedIndex > 0 Then
            Select Case Trim(cbLedgerType2.Text).ToLower
                Case "charge"
                    check_LedgerType = 0
                Case "delivery"
                    check_LedgerType = 1
                Case Else
                    check_LedgerType = -1
            End Select
        End If
    End Sub

    Private Function generatePrintByInvoiceDate()
        Dim total_amount As Double = 0
        Dim query As String = "Select l.*,c.company, DateDiff('d',NOW(),l.payment_due_date) as r from ledger as l 
                    inner join company as c on c.id = l.customer  where l.status <> 0 and (l.payment_type = 1 or l.payment_type = 3)"

        If invoice_customer > 0 And cbCustomer.Text <> "All" Then
            query = query & " and c.id = " & invoice_customer
        End If

        If cbRemaining.Text <> "All" Then
            query = query & " and DateDiff('d',NOW(),l.payment_due_date) " & invoice_remaining_query
        End If

        If cbLedgerType.Text <> "All" Then
            query = query & " and l.ledger = " & invoice_LedgerType
        End If

        If cbInvoiceMonth.Text <> "All" Then
            query = query & " and MONTH(l.date_issue) = " & monthToNumber(cbInvoiceMonth.Text)
        End If

        If cbInvoiceYear.Text <> "All" Then
            query = query & " and YEAR(l.date_issue) = " & cbInvoiceYear.Text
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
                    Dim date_issue As String = .dr("date_issue")
                    Dim amount As String = .dr("amount")
                    Dim remaining As String = .dr("r")
                    Dim paid As Boolean = CBool(.dr("paid"))
                    Dim floating As Boolean = CBool(.dr("floating"))
                    Dim invoice_no As String = .dr("invoice_no")
                    Dim date_paid As String = .dr("date_paid")
                    Dim bank_details As String = .dr("bank_details")
                    Dim check_date As String = .dr("check_date")
                    Dim payment_type As String = .dr("payment_type")

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
                    Select Case payment_type
                        Case "0"
                            payment_type = "Cash"
                        Case "1"
                            payment_type = "C.O.D"
                        Case "2"
                            payment_type = "Credit"
                        Case "3"
                            payment_type = "Post Dated"
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
                    'tr = tr & "<td " & color_remaining & ">" & remaining_val & "</td>"
                    tr = tr & "<td>" & If(paid, "Yes", "No") & "</td>"
                    tr = tr & "<td>" & If(floating, "Yes", "No") & "</td>"
                    tr = tr & "<td>" & date_paid & "</td>"
                    tr = tr & "<td>" & bank_details & "</td>"
                    tr = tr & "<td>" & check_date & "</td>"
                    tr = tr & "<td>" & payment_type & "</td>"
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
    <h3><center>Check Reports</center></h3>
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

    Private Function generatePrintByCheckDate()
        Dim total_amount As Double = 0
        Dim query As String = "Select l.*,c.company, DateDiff('d',NOW(),l.check_date) as r from ledger as l 
                    inner join company as c on c.id = l.customer  where l.status <> 0 and (l.payment_type = 1 or l.payment_type = 3)"

        If check_customer > 0 And cbCustomer2.Text <> "All" Then
            query = query & " and c.id = " & check_customer
        End If

        If cbRemaining2.Text <> "All" Then
            query = query & " and DateDiff('d',NOW(),l.check_date) " & check_remaining_query
        End If

        If cbLedgerType2.Text <> "All" Then
            query = query & " and l.ledger = " & check_LedgerType
        End If

        If cbCheckFloating.Text <> "All" Then
            If cbCheckFloating.Text = "Yes" Then
                query = query & " and l.floating = True"
            End If
            If cbCheckFloating.Text = "No" Then
                query = query & " and l.floating = False"
            End If
        End If

        If cbCheckMonth.Text <> "All" Then
            query = query & " and MONTH(l.check_date) = " & monthToNumber(cbCheckMonth.Text)
        End If

        If cbCheckYear.Text <> "All" Then
            query = query & " and YEAR(l.check_date) = " & cbCheckYear.Text
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
                    Dim date_issue As String = .dr("date_issue")
                    Dim amount As String = .dr("amount")
                    Dim remaining As String = .dr("r")
                    Dim paid As Boolean = CBool(.dr("paid"))
                    Dim floating As Boolean = CBool(.dr("floating"))
                    Dim invoice_no As String = .dr("invoice_no")
                    Dim date_paid As String = .dr("date_paid")
                    Dim bank_details As String = .dr("bank_details")
                    Dim check_date As String = .dr("check_date")
                    Dim payment_type As String = .dr("payment_type")

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
                    Select Case payment_type
                        Case "0"
                            payment_type = "Cash"
                        Case "1"
                            payment_type = "C.O.D"
                        Case "2"
                            payment_type = "Credit"
                        Case "3"
                            payment_type = "Post Dated"
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
                    'tr = tr & "<td " & color_remaining & ">" & remaining_val & "</td>"
                    tr = tr & "<td>" & If(paid, "Yes", "No") & "</td>"
                    tr = tr & "<td>" & If(floating, "Yes", "No") & "</td>"
                    tr = tr & "<td>" & date_paid & "</td>"
                    tr = tr & "<td>" & bank_details & "</td>"
                    tr = tr & "<td>" & check_date & "</td>"
                    tr = tr & "<td>" & payment_type & "</td>"
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
    <h3><center>Check Reports</center></h3>
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


End Class