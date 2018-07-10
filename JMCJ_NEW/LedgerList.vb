Public Class LedgerList

    Public selectedID As Integer = 0
    Public selectedPaymentType As Integer = 0
    Public filterQuery As String = ""
    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click

        LedgerForm.enableControl(True)
        LedgerForm.loadTerm()
        LedgerForm.loadPaymentType()
        LedgerForm.loadLedgerType()
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
        LedgerForm.cbLedgerType.SelectedIndex = 0
        LedgerForm.txtRemarks.Text = ""
        LedgerForm.txtDeliveredBy.Text = ""
        LedgerForm.txtReceivedBy.Text = ""
        LedgerForm.lblTotalAmount.Text = "0.00"


        LedgerForm.enableControl(True)
        LedgerForm.btnSave.Text = "Save"
        LedgerForm.btnSaveAndPrint.Text = "Save and Print"
        LedgerForm.ShowDialog()

        autocompleteCustomer()

    End Sub

    Public Sub loadLedger(ByVal query As String, ByVal show As String)
        Loading.Show()
        dgvLedger.Rows.Clear()

        Dim db As New DatabaseConnect
        With db
            If query = "" Then
                If show <> "All" Then
                    .selectByQuery("SELECT TOP " & show & " * from ledger order by id desc")
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
            LedgerForm.btnSave.Text = "Update"
            LedgerForm.btnSaveAndPrint.Text = "Update and Print"
            LedgerForm.getCustomerList("")
            LedgerForm.loadPaymentType()
            LedgerForm.loadLedgerType()
            LedgerForm.loadTerm()
            loadToUpdateInfo(selectedID)
            LedgerForm.toloadproductinfo(selectedID)
            LedgerForm.enableControl(False)
            LedgerForm.ShowDialog()
        Else
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
                LedgerForm.cbLedgerType.SelectedIndex = LedgerForm.cbLedgerType.FindStringExact(ledger_type_val)
                LedgerForm.cbLedgerType.Text = ledger_type_val

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
            Dim cr As New COReport
            cr.RecordSelectionFormula = "{ledger.id} = " & id
            ReportViewer.Enabled = True
            ReportViewer.CrystalReportViewer1.ReportSource = cr
            ReportViewer.CrystalReportViewer1.Refresh()
            ReportViewer.CrystalReportViewer1.RefreshReport()
            ReportViewer.ShowDialog()
        Else
            MsgBox("Please select one record before you print.", MsgBoxStyle.Critical)
        End If
        btnPrint.Enabled = True
        btnPrint.Text = "Print"
    End Sub
End Class