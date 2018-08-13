Public Class LedgerList

    Public selectedID As Integer = 0
    Public selectedPaymentType As Integer = 0
    Public filterQuery As String = ""
    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        LedgerForm.selectedID = 0
        LedgerForm.enableControl(True)
        LedgerForm.loadTerm()
        LedgerForm.loadPaymentType()
        LedgerForm.getCustomerList("")
        LedgerForm.txtInvoiceNo.Text = LedgerForm.generateInvoice
        LedgerForm.dgvProd.Rows.Clear()

        'reset this fields
        LedgerForm.dtpDateIssue.Value = DateTime.Now
        LedgerForm.txtCounterNo.Text = ""
        LedgerForm.cbDisable.Checked = False
        LedgerForm.txtAmount.Text = "0.00"
        LedgerForm.cbPaymentType.SelectedIndex = 0
        LedgerForm.selectedPaymentType = 0
        LedgerForm.rPaidYes.Checked = False
        LedgerForm.rPaidNo.Checked = False
        LedgerForm.dtpPaid.Value = DateTime.Now
        LedgerForm.txtBankDetails.Text = ""
        LedgerForm.dtpCheckDate.Value = DateTime.Now
        LedgerForm.rbFloatingYes.Checked = False
        LedgerForm.rbFloatingNo.Checked = False
        LedgerForm.cbTerms.SelectedIndex = 0
        LedgerForm.txtRemarks.Text = ""
        LedgerForm.txtDeliveredBy.Text = ""
        LedgerForm.txtReceivedBy.Text = ""
        LedgerForm.lblTotalAmount.Text = "0.00"


        LedgerForm.enableControl(True)
        LedgerForm.btnSave.Text = "Save"
        LedgerForm.btnSaveAndPrint.Text = "Save and Print"
        LedgerForm.dgvProd.Visible = True
        LedgerForm.gpFields.Enabled = True
        LedgerForm.btnSave.Visible = True
        LedgerForm.btnSaveAndPrint.Visible = True
        LedgerForm.btnCheck.Visible = False
        LedgerForm.btnApprove.Visible = False
        LedgerForm.ShowDialog()

        autocompleteCustomer()

    End Sub

    Public Sub loadLedger(ByVal query As String, ByVal show As String)
        Loading.Show()
        dgvLedger.Rows.Clear()

        If show <> "" And IsNumeric(show) Then
            show = "TOP " & show
        Else
            show = ""
        End If

        Dim db As New DatabaseConnect
        With db
            If query = "" Then
                If show <> "All" Then
                    .selectByQuery("SELECT " & show & " * from ledger order by id desc")
                Else
                    .selectByQuery("SELECT * from ledger order by id desc")
                End If
            Else
                .selectByQuery(query)
            End If

            If .dr.HasRows = False Then
                .cmd.Dispose()
                .dr.Close()
                .con.Close()
                MsgBox("No record found!", MsgBoxStyle.Critical)
                Loading.Hide()
                Exit Sub
            End If
            While .dr.Read
                Dim ID As Integer = CInt(.dr.GetValue(0))
                Dim counter_no As String = .dr.GetValue(1)
                Dim date_issue As String = Convert.ToDateTime(.dr("date_issue")).ToString("MM-dd-yy")
                Dim invoice_no As String = .dr.GetValue(3)
                Dim amount As String = .dr.GetValue(4)
                Dim paid As Boolean = CBool(.dr.GetValue(5))
                Dim paid_val As String = If(paid, "Yes", "No")

                Dim date_paid As String = .dr.GetValue(6)

                Dim floating As Boolean = CBool(.dr.GetValue(7))
                Dim floating_val As String = If(floating, "Yes", "No")

                Dim bank_details As String = .dr.GetValue(8)
                Dim check_date As String = .dr.GetValue(9)
                Dim status As Integer = CInt(.dr.GetValue(10))
                Dim status_val As String = ""
                Select Case status
                    Case 0
                        status_val = "Voided"
                    Case 1
                        status_val = "Active"
                    Case 2
                        status_val = "Inactive"
                End Select

                Dim customer As Integer = CInt(.dr.GetValue(11))
                Dim customer_val As String = ""
                Dim db2 As New DatabaseConnect
                With db2
                    .selectByQuery("Select company from company where ID = " & customer)
                    If .dr.Read Then
                        customer_val = .dr.GetValue(0)
                    End If
                    .cmd.Dispose()
                    .dr.Close()
                    .con.Close()

                End With

                Dim ledger_type As Integer = CInt(.dr.GetValue(12))
                Dim ledger_type_val As String = ""
                Select Case ledger_type
                    Case 0
                        ledger_type_val = "Charge"
                    Case 1
                        ledger_type_val = "Delivery"
                End Select


                Dim term_ As Integer = CInt(.dr.GetValue(17))
                Dim term_val As String
                If term_ = 0 Then
                    term_val = "N/A"
                Else
                    term_val = CStr(term_) & " Days"
                End If

                Dim payment_type As Integer = CInt(.dr.GetValue(13))
                Dim payment_type_val As String = ""
                Select Case payment_type
                    Case 0
                        payment_type_val = "Cash"
                        bank_details = "N/A"
                        check_date = "N/A"
                        counter_no = "N/A"
                        floating_val = "N/A"
                        term_val = "N/A"


                    Case 1
                        payment_type_val = "C.O.D"
                        counter_no = "N/A"
                        term_val = "N/A"
                    Case 2
                        payment_type_val = "Credit"
                        date_paid = "N/A"
                        bank_details = "N/A"
                        check_date = "N/A"
                        floating_val = "N/A"
                    Case 3
                        payment_type_val = "Post Dated"
                        term_val = "N/A"

                End Select

                Dim row As String() = New String() {ID, date_issue, customer_val, invoice_no, FormatCurrency(amount).Replace("$", ""), paid_val, date_paid, floating_val, bank_details, check_date, counter_no, term_val, payment_type_val, ledger_type_val, status_val}
                dgvLedger.Rows.Add(row)

            End While
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
            For Each row As DataGridViewRow In dgvLedger.Rows
                If row.Cells("status").Value = "Voided" Then
                    row.DefaultCellStyle.BackColor = Color.OrangeRed
                End If
            Next

        End With
        Loading.Hide()
    End Sub


    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If dgvLedger.SelectedRows.Count = 1 Then
            selectedID = CInt(dgvLedger.SelectedRows(0).Cells(0).Value)
            LedgerForm.selectedID = CInt(dgvLedger.SelectedRows(0).Cells(0).Value)
            LedgerForm.btnSave.Text = "Update"
            LedgerForm.btnSaveAndPrint.Text = "Update and Print"
            LedgerForm.getCustomerList("")
            LedgerForm.loadPaymentType()
            LedgerForm.loadTerm()
            loadToUpdateInfo(selectedID)
            LedgerForm.toloadproductinfo(selectedID)
            LedgerForm.enableControl(False)
            'LedgerForm.gpFields.Enabled = False
            LedgerForm.btnSave.Visible = False
            LedgerForm.btnSaveAndPrint.Visible = False
            LedgerForm.btnCheck.Visible = True
            LedgerForm.btnApprove.Visible = True
            LedgerForm.ShowDialog()
        Else
            selectedID = 0
            LedgerForm.selectedID = 0
            MsgBox("Please select ledger!", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        If dgvLedger.SelectedRows.Count = 1 Then
            Dim id As String = dgvLedger.SelectedRows(0).Cells(0).Value
            Dim customer As String = dgvLedger.SelectedRows(0).Cells(2).Value
            Dim invoice As String = dgvLedger.SelectedRows(0).Cells("InvoiceNo").Value

            Dim yesno As Integer = MsgBox("Are you sure you want to void this transaction ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
            If yesno = MsgBoxResult.Yes Then
                Dim dbdelete As New DatabaseConnect
                With dbdelete
                    .update_where("ledger", id, "status", 0)
                    .update_where("ledger", id, "updated_at", "'" & DateTime.Now.ToString & "'")
                    .cmd.Dispose()
                    .con.Close()
                End With
                MsgBox(invoice & " has been deleted!", MsgBoxStyle.Critical)
                Me.loadLedger("", cbShow.SelectedItem)
            End If

        End If
    End Sub

    Private Sub LedgerList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbShow.SelectedIndex = cbShow.FindString("100")
        cbShowFilter.SelectedIndex = cbShowFilter.FindString("All")
        Loading.Show()
        loadLedger("", cbShow.Text)
        loadledgertype()
        getPaymentMode()
        getMonth()
        getYear()
        autocompleteCustomer()
        Loading.Hide()
    End Sub

    Private Sub dgvLedger_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLedger.CellContentClick
        If dgvLedger.SelectedRows.Count = 1 Then
            selectedID = CInt(dgvLedger.SelectedRows(0).Cells(0).Value)
        End If
    End Sub

    Public Sub loadToUpdateInfo(ByVal ledgerID As Integer)
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("Select * from ledger where status <> 0 and ID = " & ledgerID & " order by id desc")
            If .dr.Read Then
                Dim counter_no As String = .dr.GetValue(1)
                Dim date_issue As String = .dr.GetValue(2)
                Dim invoice_no As String = .dr.GetValue(3)
                Dim amount As String = .dr.GetValue(4)
                Dim paid As Boolean = CBool(.dr.GetValue(5))
                Dim date_paid As String = .dr.GetValue(6)
                Dim floating As Boolean = CBool(.dr.GetValue(7))
                Dim bank_details As String = .dr.GetValue(8)
                Dim check_date As String = .dr.GetValue(9)
                Dim status As Integer = CInt(.dr.GetValue(10))
                Dim status_val As String = ""
                Select Case status
                    Case 1
                        status_val = "Active"
                    Case 2
                        status_val = "Inactive"
                End Select

                Dim customer As Integer = CInt(.dr.GetValue(11))
                Dim customer_val As String = ""
                Dim db2 As New DatabaseConnect
                With db2
                    .selectByQuery("Select company from company where ID = " & customer)
                    If .dr.Read Then
                        customer_val = .dr.GetValue(0)
                        LedgerForm.cbCustomer.SelectedIndex = LedgerForm.cbCustomer.FindStringExact(customer_val)
                        LedgerForm.cbCustomer.Text = customer_val
                    End If
                    .cmd.Dispose()
                    .dr.Close()
                    .con.Close()
                End With

                Dim ledger_type As Integer = CInt(.dr.GetValue(12))
                Dim ledger_type_val As String = ""
                Select Case ledger_type
                    Case 0
                        ledger_type_val = "Charge"
                    Case 1
                        ledger_type_val = "Delivery"
                End Select


                Dim payment_type As Integer = CInt(.dr.GetValue(13))
                Dim payment_type_val As String = ""
                Select Case payment_type
                    Case 0
                        payment_type_val = "Cash"
                    Case 1
                        payment_type_val = "C.O.D"
                    Case 2
                        payment_type_val = "Credit"
                    Case 3
                        payment_type_val = "Post Dated"
                End Select

                Dim term_ As Integer = CInt(.dr.GetValue(17))
                Select Case term_
                    Case 30
                        LedgerForm.cbTerms.SelectedIndex = 1
                    Case 60
                        LedgerForm.cbTerms.SelectedIndex = 2
                    Case 90
                        LedgerForm.cbTerms.SelectedIndex = 3
                    Case 120
                        LedgerForm.cbTerms.SelectedIndex = 4
                    Case Else
                        LedgerForm.cbTerms.SelectedIndex = 0
                End Select
                Dim remarks As String = .dr.GetValue(18)

                LedgerForm.cbPaymentType.SelectedIndex = LedgerForm.cbPaymentType.FindStringExact(ledger_type_val)
                LedgerForm.cbPaymentType.Text = payment_type_val
                LedgerForm.dtpDateIssue.Value = date_issue
                LedgerForm.txtCounterNo.Text = counter_no
                LedgerForm.txtInvoiceNo.Text = invoice_no
                LedgerForm.txtAmount.Text = amount
                LedgerForm.lblTotalAmount.Text = Val(amount).ToString("N2")

                If paid = True Then
                    LedgerForm.rPaidYes.Checked = True
                Else
                    LedgerForm.rPaidYes.Checked = False
                End If

                If paid = False Then
                    LedgerForm.rPaidNo.Checked = True
                Else
                    LedgerForm.rPaidNo.Checked = False
                End If

                LedgerForm.dtpPaid.Value = date_paid
                LedgerForm.txtBankDetails.Text = bank_details
                LedgerForm.dtpCheckDate.Value = check_date

                If floating = True Then
                    LedgerForm.rbFloatingYes.Checked = True
                Else
                    LedgerForm.rbFloatingYes.Checked = False
                End If

                If floating = False Then
                    LedgerForm.rbFloatingNo.Checked = True
                Else
                    LedgerForm.rbFloatingNo.Checked = False
                End If
                LedgerForm.txtRemarks.Text = remarks

                LedgerForm.txtDeliveredBy.Text = .dr("delivered_by")
                LedgerForm.txtReceivedBy.Text = .dr("received_by")

            End If
        End With

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

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        btnFilter.Enabled = False
        Dim ledgertype_val As Integer = 0
        Select Case Trim(cbLedgerType.Text)
            Case "Charge"
                ledgertype_val = 0
            Case "Delivery"
                ledgertype_val = 1
            Case Else
                ledgertype_val = -1
        End Select

        Dim top As String = ""
        If cbShowFilter.Text <> "All" Then
            top = " TOP " & cbShowFilter.Text
        Else
            top = ""
        End If
        filterQuery = "SELECT " & top & " * FROM ledger l inner join company c on c.id = l.customer WHERE l.status <> 0"

        If txtCustomer.Text.Length > 0 Then
            'cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND {ledger.customer} = " & selectedCustomer
            filterQuery = filterQuery & " and c.company = '" & txtCustomer.Text & "'"
        End If

        If cbLedgerType.Text <> "All" Then
            'cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND {ledger.payment_type} = " & selectedModeOfPayment
            filterQuery = filterQuery & " and l.ledger = " & ledgertype_val
        End If

        If cbpayment_mode.Text <> "All" Then
            'cr.RecordSelectionFormula = cr.RecordSelectionFormula & " AND {ledger.payment_type} = " & selectedModeOfPayment
            filterQuery = filterQuery & " and l.payment_type = " & selectedPaymentType
        End If

        If cbMonth.Text <> "All" Then
            filterQuery = filterQuery & " and MONTH(l.date_issue) = " & monthToNumber(cbMonth.Text)
        End If

        If cbYear.Text <> "All" Then
            filterQuery = filterQuery & " and YEAR(l.date_issue) = " & cbYear.Text
        End If


        loadLedger(filterQuery, "")

    End Sub

    Private Sub txtCustomer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomer.TextChanged

        If txtCustomer.Text.Length > 0 Then
            btnFilter.Enabled = True
        End If
    End Sub

    Public Sub autocompleteCustomer()
        Dim MySource As New AutoCompleteStringCollection()

        With txtCustomer
            .AutoCompleteCustomSource = MySource
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.CustomSource
        End With

        Dim customer As New DatabaseConnect
        With customer
            .selectByQuery("Select distinct company from company  where status <> 0")
            While .dr.Read
                MySource.Add(.dr.GetValue(0))
            End While
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


    Private Sub cbpayment_mode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbpayment_mode.SelectedIndexChanged
        If cbpayment_mode.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbpayment_mode.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbpayment_mode.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedPaymentType = key
        End If
        btnFilter.Enabled = True
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

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        btnLoad.Enabled = False
        Me.loadLedger("", cbShow.Text)
        btnLoad.Enabled = True
    End Sub

    Private Sub cbLedgerType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLedgerType.SelectedIndexChanged
        btnFilter.Enabled = True
    End Sub


    Private Sub txtCustomer_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCustomer.KeyUp
        If txtCustomer.Text.Length > 0 And e.KeyCode = Keys.Enter Then
            txtCustomer.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtCustomer.Text.ToLower())
        End If
    End Sub

    Private Sub dgvLedger_CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvLedger.CellMouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            dgvLedger.ClearSelection()
            dgvLedger.Rows(e.RowIndex).Selected = True
            View.Show(Cursor.Position)
        End If
    End Sub

    Private Sub View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles View.Click
        btnUpdate.PerformClick()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If Trim(txtSearch.Text).Length > 0 Then
            Dim top As String = ""
            If cbShow.Text <> "All" Then
                top = " TOP " & cbShow.Text
            Else
                top = ""
            End If
            loadLedger("select " & top & " * from ledger where counter_no like '%" & txtSearch.Text & "%' 
            or date_issue like '%" & txtSearch.Text & "%' 
            or invoice_no like '%" & txtSearch.Text & "%' 
            or amount like '%" & txtSearch.Text & "%' or date_paid like '%" & txtSearch.Text & "%' or bank_details like '%" & txtSearch.Text & "%' 
            or date_issue like '%" & txtSearch.Text & "%' and status <> 0", "")
        End If
    End Sub

    Private Sub txtSearch_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyUp
        If e.KeyCode = Keys.Enter Then
            If Trim(txtSearch.Text).Length > 0 Then
                If cbShow.Text <> "All" Then
                    Top = " TOP " & cbShow.Text
                Else
                    Top = ""
                End If
                loadLedger("select " & Top & " * from ledger where counter_no like '%" & txtSearch.Text & "%' 
            or date_issue like '%" & txtSearch.Text & "%' 
            or invoice_no like '%" & txtSearch.Text & "%' 
            or amount like '%" & txtSearch.Text & "%' or date_paid like '%" & txtSearch.Text & "%' or bank_details like '%" & txtSearch.Text & "%' 
            or date_issue like '%" & txtSearch.Text & "%' and status <> 0", "")
            End If
        End If
    End Sub

    Private Sub cbShow_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbShow.SelectedIndexChanged
        loadLedger("", cbShow.Text)

    End Sub

    Private Sub cbShowFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbShowFilter.SelectedIndexChanged
        btnFilter.Enabled = True
    End Sub

    Private Sub cbMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMonth.SelectedIndexChanged
        btnFilter.Enabled = True
    End Sub

    Private Sub cbYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbYear.SelectedIndexChanged
        btnFilter.Enabled = True
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        btnPrint.Enabled = False
        btnPrint.Text = "loading.."
        If dgvLedger.SelectedRows.Count = 1 Then
            Dim id As Integer = dgvLedger.SelectedRows(0).Cells("id").Value
            'Dim cr As New COReport
            'cr.RecordSelectionFormula = "{ledger.id} = " & id
            'ReportViewer.Enabled = True
            'ReportViewer.CrystalReportViewer1.ReportSource = cr
            'ReportViewer.CrystalReportViewer1.Refresh()
            'ReportViewer.CrystalReportViewer1.RefreshReport()
            'ReportViewer.ShowDialog()
            Dim path As String = Application.StartupPath & "\co.html"
            'Dim filter() As String = {"sample1", "sample2"}
            Try
                Dim code As String = generatePrint(id)
                Dim myWrite As System.IO.StreamWriter
                myWrite = IO.File.CreateText(path)
                myWrite.WriteLine(code)
                myWrite.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Dim proc As New System.Diagnostics.Process()
            proc = Process.Start(path, "")

        Else
            MsgBox("Please select one record before you print.", MsgBoxStyle.Critical)
        End If
        btnPrint.Enabled = True
        btnPrint.Text = "Print"
    End Sub

    Public Function generatePrint(ByVal id As Integer)
        Dim checked_by As Integer = New DatabaseConnect().get_by_id("ledger", id, "checked_by")
        Dim checked_by_val As String = ""
        If checked_by > 0 Then
            checked_by_val = New DatabaseConnect().get_by_id("users", checked_by, "first_name") & " " & New DatabaseConnect().get_by_id("users", checked_by, "middle_initial") &
        " " & New DatabaseConnect().get_by_id("users", checked_by, "surname")
        Else
            checked_by_val = ""
        End If

        Dim approve_by As Integer = New DatabaseConnect().get_by_id("ledger", id, "approved_by")
        Dim approve_by_val As String = ""
        If approve_by > 0 Then
            approve_by_val = New DatabaseConnect().get_by_id("users", approve_by, "first_name") & " " & New DatabaseConnect().get_by_id("users", approve_by, "middle_initial") &
        " " & New DatabaseConnect().get_by_id("users", approve_by, "surname")
        Else
            approve_by_val = ""
        End If

        Dim result As String = ""
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("Select * from ledger where ID = " & id & " order by id desc")
            If .dr.Read Then
                Dim counter_no As String = .dr.GetValue(1)
                Dim date_issue As String = .dr.GetValue(2)
                Dim invoice_no As String = .dr.GetValue(3)
                Dim amount As String = .dr.GetValue(4)
                Dim paid As Boolean = CBool(.dr.GetValue(5))
                Dim date_paid As String = .dr.GetValue(6)
                Dim floating As Boolean = CBool(.dr.GetValue(7))
                Dim bank_details As String = .dr.GetValue(8)
                Dim check_date As String = .dr.GetValue(9)
                Dim status As Integer = CInt(.dr.GetValue(10))
                Dim status_val As String = ""
                Select Case status
                    Case 1
                        status_val = "Active"
                    Case 2
                        status_val = "Inactive"
                End Select

                Dim customer As Integer = CInt(.dr.GetValue(11))
                Dim customer_val As String = ""
                Dim customer_address As String = ""
                Dim customer_city As String = ""
                Dim fax_tel As String = ""
                Dim db2 As New DatabaseConnect
                With db2
                    .selectByQuery("Select company,address,city,fax_tel from company where ID = " & customer)
                    If .dr.Read Then
                        customer_val = .dr.GetValue(0)
                        customer_address = .dr.GetValue(1)
                        customer_city = .dr.GetValue(2)
                        fax_tel = .dr.GetValue(3)
                        'LedgerForm.cbCustomer.SelectedIndex = LedgerForm.cbCustomer.FindStringExact(customer_val)
                        'LedgerForm.cbCustomer.Text = customer_val
                    End If
                    .cmd.Dispose()
                    .dr.Close()
                    .con.Close()
                End With

                Dim ledger_type As Integer = CInt(.dr.GetValue(12))
                Dim ledger_type_val As String = ""
                Select Case ledger_type
                    Case 0
                        ledger_type_val = "Charge"
                    Case 1
                        ledger_type_val = "Delivery"
                End Select


                Dim payment_type As Integer = CInt(.dr.GetValue(13))
                Dim payment_type_val As String = ""
                Select Case payment_type
                    Case 0
                        payment_type_val = "Cash"
                    Case 1
                        payment_type_val = "C.O.D"
                    Case 2
                        payment_type_val = "Credit"
                    Case 3
                        payment_type_val = "Post Dated"
                End Select

                Dim term_ As Integer = CInt(.dr.GetValue(17))
                'Select Case term_
                '    Case 30
                '        LedgerForm.cbTerms.SelectedIndex = 1
                '    Case 60
                '        LedgerForm.cbTerms.SelectedIndex = 2
                '    Case 90
                '        LedgerForm.cbTerms.SelectedIndex = 3
                '    Case 120
                '        LedgerForm.cbTerms.SelectedIndex = 4
                '    Case Else
                '        LedgerForm.cbTerms.SelectedIndex = 0
                'End Select
                Dim remarks As String = .dr.GetValue(18)

                'LedgerForm.cbPaymentType.SelectedIndex = LedgerForm.cbPaymentType.FindStringExact(ledger_type_val)
                'LedgerForm.cbPaymentType.Text = payment_type_val
                'LedgerForm.dtpDateIssue.Value = date_issue
                'LedgerForm.txtCounterNo.Text = counter_no
                'LedgerForm.txtInvoiceNo.Text = invoice_no
                'LedgerForm.txtAmount.Text = amount
                'LedgerForm.lblTotalAmount.Text = Val(amount).ToString("N2")

                Dim paid_val As String = ""
                If paid = True Then
                    paid_val = "Yes"
                Else
                    paid_val = "No"
                End If

                'LedgerForm.dtpPaid.Value = date_paid
                'LedgerForm.txtBankDetails.Text = bank_details
                'LedgerForm.dtpCheckDate.Value = check_date

                Dim floating_val As String
                If floating = True Then
                    floating_val = "Yes"
                Else
                    floating_val = "No"
                End If
                'LedgerForm.txtRemarks.Text = remarks
                'LedgerForm.txtDeliveredBy.Text = .dr("delivered_by")
                'LedgerForm.txtReceivedBy.Text = .dr("received_by")
                Dim grand_total As Double = 0
                Dim table_content As String = ""
                Dim dbprod As New DatabaseConnect()
                With dbprod
                    .selectByQuery("Select distinct pu.id,pu.barcode,p.description,cop.quantity,b.name as brand, u.name as unit,c.name as color,pu.price,cop.less,cop.sell_price,cop.total_amount,ps.qty as stock from ((((((customer_order_products as cop
                    Left Join product_unit as pu ON pu.id = cop.product_unit_id)
                    Left Join products as p on p.id = pu.product_id)
                    Left Join brand as b on b.id = pu.brand)
                    Left Join unit as u on u.id = pu.unit)
                    Left Join color as c on c.id = pu.color)
                    Left Join product_stocks as ps on ps.product_unit_id = pu.id)
                    where cop.customer_order_ledger_id = " & id)
                    If .dr.HasRows Then
                        While .dr.Read
                            Dim tr As String = "<tr>"
                            Dim p_id As String = .dr("id")
                            Dim barcode As String = .dr("barcode")
                            Dim qty As String = .dr("quantity")
                            Dim desc As String = .dr("description")
                            Dim brand As String = .dr("brand")
                            Dim unit As String = .dr("unit")
                            Dim color As String = If(IsDBNull(.dr("color")), "", .dr("color"))
                            Dim price As String = Math.Round(Val(.dr("price")), 2).ToString("N2")
                            Dim less As String = .dr("less")
                            Dim sell_price As String = Math.Round(Val(.dr("sell_price")), 2).ToString("N2")
                            Dim total_amount As String = Math.Round(Val(.dr("total_amount")), 2).ToString("N2")
                            Dim stock As String = Val(.dr("stock"))

                            grand_total += CDbl(total_amount)
                            tr = tr & "<td>" & barcode & "</td>"
                            tr = tr & "<td>" & qty & "</td>"
                            tr = tr & "<td>" & unit & "</td>"
                            tr = tr & "<td>" & brand & "</td>"
                            tr = tr & "<td>" & color & "</td>"
                            tr = tr & "<td>" & desc & "</td>"
                            tr = tr & "<td>" & sell_price & "</td>"
                            tr = tr & "<td>" & total_amount & "</td>"
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
<div id='header' style='text-align:center;'>
	<br>
	<h3	 style='color:blue;margin:1px;'><strong>JMCJ</strong></h3>
	<p style='color:red;;margin:1px;'>Perfect Colors Solution Inc.</p>
	<p style='margin:1px;font-size:10pt;'>42 K Roosevelt Ave, Brgy. Sta. Cruz, Lungsod Quezon, 1104 Kalakhang Maynila</p>
	<p style='margin:1px;font-size:10pt;'>Fax: 411-5274 Tel: 371-5448</p>
</div>
<h4 style='text-align:center;'>Customer Order</h4>
<div id='fieldset'>
	<table>
		<tr>
			<td width='120'><label><strong>Date Invoice: </strong></label></td>
			<td><label> " & date_issue & " </label></td>
			
			<td width='80'><label><strong>Invoice No: </strong></label></td>
			<td><label>" & invoice_no & "</label></td>
		</tr>
	<table>
	<br>
	<table>
		<tr>
			<th colspan='2' style='background-color:blue;color:white;'>Payment Details</th>
			<th colspan='4' style='background-color:blue;color:white;'>Ship To</th>
		</tr>
		<tr>
			<td width='120'><label><strong>Payment type: </strong></label></td>
			<td><label> " & payment_type_val & " </label></td>
			
			<td width='120'><label><strong>Customer: </strong></label></td>
			<td colspan='3'><label>" & customer_val & " </label></td>
		</tr>
		
		<tr>
			<td width='80'><label><strong>Bank details: </strong></label></td>
			<td><label>" & bank_details & "</label></td>
			
			<td width='120'><label><strong>Address: </strong></label></td>
			<td colspan='3'><label> " & customer_address & " " & customer_city & " </label></td>
		</tr>
		
		<tr>
			<td width='120'><label><strong>Check Date: </strong></label></td>
			<td><label>" & check_date & " </label></td>
			
			<td width='120'><label><strong>Fax/Tel: </strong></label></td>
			<td colspan='3'><label>" & fax_tel & "</label></td>
		</tr>
		
		<tr>
			<td width='80'><label><strong>Due Date: </strong></label></td>
			<td><label>" & New DatabaseConnect().get_by_val("ledger", id, "id", "payment_due_date") & "</label></td>
			
			<td width='120'><label><strong>Delivery By: </strong></label></td>
			<td><label>" & .dr("delivered_by") & "</label></td>
			<td width='120'><label><strong>Received By: </strong></label></td>
			<td><label>" & .dr("received_by") & "</label></td>
		</tr>
	<table>
</div>
<br>
<table>
  <thead>
  <tr>
	<th>Barcode</th>
	<th>Qty</th>
	<th>Unit</th>
	<th>Brand</th>
	<th>Color</th>
	<th>Description</th>
	<th>Unit Price</th>
	<th>Amount</th>
  </tr>
  </thead>
  <tbody>
    " & table_content & "
    <tr>
		<td colspan='7' style='text-align:right;'><strong>Total Amount</strong></td>
		<td style='color:red'><strong>" & Val(grand_total).ToString("N2") & "</strong></td>
	</tr>
  </tbody>
</table>
<br><br>
<table>
	<tr>
		<td style='text-align:right;' valign='bottom'><strong>Checked by:</strong></td>
		<td height='40' valign='bottom'>" & checked_by_val & "</td>
	</tr>
	<tr>
		<td style='text-align:right;' valign='bottom'><strong>Approved by:</strong></td>
		<td height='40' valign='bottom'>" & approve_by_val & "</td>
	</tr>
</table>

</body>
</html>

"
                Return result
            End If
        End With
        Return result
    End Function
End Class