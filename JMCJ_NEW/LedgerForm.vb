﻿Public Class LedgerForm

    Public selectedID As Integer = 0
    Public selectedCustomer As Integer = 0
    Public selectedPaymentType As Integer = 0
    Public selectedLedgerType As Integer = 0
    Public term As Integer = 0
    Public isfloating As Boolean = False

    Public Sub loadTerm()
        cbTerms.Items.Clear()
        cbTerms.Items.Add("Select Term")
        cbTerms.Items.Add("30 Days")
        cbTerms.Items.Add("60 Days")
        cbTerms.Items.Add("90 Days")
        cbTerms.Items.Add("120 Days")
        cbTerms.SelectedIndex = 0
    End Sub

    Public Sub getCustomerList(ByVal query As String)

        cbCustomer.DataSource = Nothing
        cbCustomer.Items.Clear()
        Dim db As New DatabaseConnect

        With db
            If query = "" Then
                .selectByQuery("select distinct company,ID from company where status <> 0")
            Else

            End If

            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "Select Customer")
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

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        btnSave.Enabled = False
        If btnSave.Text = "Save" Then
            If (validator()) Then
                btnSave.Enabled = True
                Exit Sub
            End If
            insertData()
            clearfields()
            Ledger.loadLedger("")
            Ledger.loadledgertype()
            Ledger.getPaymentMode()

        ElseIf btnSave.Text = "Update" Then
            'MsgBox(selectedPaymentType)
            'Exit Sub
            If (validator()) Then
                btnSave.Enabled = True
                Exit Sub
            End If
            updateData()
            clearfields()
            Me.Close()
            Ledger.btnFilter.PerformClick()
            Ledger.loadledgertype()
            Ledger.getPaymentMode()

        End If
        btnSave.Enabled = True
    End Sub


    Public Sub clearfields()
        cbCustomer.Text = ""
        txtCounterNo.Text = ""
        'txtInvoiceNo.Text = ""
        txtAmount.Text = ""

        rPaidYes.Checked = False
        rPaidNo.Checked = False
        rbFloatingYes.Checked = False
        rbFloatingNo.Checked = False

        txtBankDetails.Text = ""
        cbLedgerType.SelectedIndex = 0
        cbCustomer.SelectedIndex = 0
        cbPaymentType.SelectedIndex = 0
        cbTerms.SelectedIndex = 0
        txtRemarks.Clear()

    End Sub

    Private Sub insertData()

        Dim db As New DatabaseConnect
        With db
            Try
                .cmd.CommandType = CommandType.Text
                .cmd.Connection = .con
                .cmd.CommandText = "INSERT INTO ledger([customer],[date_issue],[counter_no],[ledger_no],[amount],[payment_type],[date_paid],[paid],[check_date],[bank_details],[floating],[ledger],[status],[created_at],[updated_at],[payment_due_date],[payment_terms],[remarks])" &
                "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
                .cmd.Parameters.AddWithValue("@customer", selectedCustomer)
                .cmd.Parameters.AddWithValue("@date_issue", dtpDateIssue.Value.Date.ToString)

                'Dim ctr_no_result As String = ""
                'If txtCounterNo.Text.Length > 0 Then
                '    ctr_no_result = txtCounterNo.Text
                'Else
                '    ctr_no_result = "0"
                'End If

                If Trim(txtCounterNo.Text).Length = 0 Then
                    txtCounterNo.Text = "N/A"
                End If

                .cmd.Parameters.AddWithValue("@counter_no", txtCounterNo.Text)
                .cmd.Parameters.AddWithValue("@ledger_no", generateLedgerNo())

                Dim format_amount As String = ""
                If txtAmount.Text.Contains(",") Or txtAmount.Text.Contains(".") Then
                    format_amount = txtAmount.Text.Replace(",", "")
                End If

                .cmd.Parameters.AddWithValue("@amount", format_amount)
                .cmd.Parameters.AddWithValue("@payment_type", selectedPaymentType)
                .cmd.Parameters.AddWithValue("@date_paid", dtpPaid.Value.Date.ToString)

                Dim ispaid As Boolean
                If rPaidYes.Checked Then
                    ispaid = True
                End If

                If rPaidNo.Checked Then
                    ispaid = False
                End If
                .cmd.Parameters.AddWithValue("@paid", ispaid)
                .cmd.Parameters.AddWithValue("@check_date", dtpCheckDate.Value.Date.ToString)
                .cmd.Parameters.AddWithValue("@bank_details", txtBankDetails.Text)
                .cmd.Parameters.AddWithValue("@floating", Me.isfloating)

                If Trim(cbLedgerType.Text) = "charge" Then
                    selectedLedgerType = 0
                ElseIf Trim(cbLedgerType.Text) = "delivery" Then
                    selectedLedgerType = 1
                End If
                .cmd.Parameters.AddWithValue("@ledger", selectedLedgerType)
                .cmd.Parameters.AddWithValue("@status", 1)
                .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)

                Dim payment_date As New Date
                payment_date = dtpDateIssue.Value.AddDays(term)
                .cmd.Parameters.AddWithValue("@payment_due_date", payment_date.ToString)
                .cmd.Parameters.AddWithValue("@payment_terms", term)
                .cmd.Parameters.AddWithValue("@remarks", txtRemarks.Text)
                .cmd.ExecuteNonQuery()
                .cmd.Dispose()
                .con.Close()

                MsgBox("Save Successful!", MsgBoxStyle.Information)
                clearfields()
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message & " " & .cmd.CommandText, MsgBoxStyle.Critical)
            End Try
        End With
    End Sub

    Private Sub updateData()

        If Trim(txtCounterNo.Text).Length = 0 Then
            txtCounterNo.Text = "N/A"
        End If

        Dim ispaid As Boolean = False
        If rPaidYes.Checked = True Then
            ispaid = True
        Else
            ispaid = False
        End If

        Dim isfloating As Boolean = False
        If rbFloatingYes.Checked = True Then
            isfloating = True
        Else
            isfloating = False
        End If

        Dim dtp_payment_due As New Date
        dtp_payment_due = dtpDateIssue.Value.AddDays(term)

        Dim format_amount As String = ""
        If txtAmount.Text.Contains(",") Or txtAmount.Text.Contains(".") Then
            format_amount = txtAmount.Text.Replace(",", "")
        Else
            format_amount = txtAmount.Text
        End If

        Dim db As New DatabaseConnect
        With db
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "UPDATE ledger SET [counter_no]='" & txtCounterNo.Text & "',[date_issue]='" & dtpDateIssue.Value.Date.ToString & "',[ledger_no]='" & txtLedgerNo.Text & "',[amount]=" & format_amount & ", " &
            "[paid]=" & ispaid & ",[date_paid]='" & dtpPaid.Value.Date.ToString & "', [floating]=" & isfloating & ",[bank_details]='" & txtBankDetails.Text & "',[check_date]='" & dtpCheckDate.Value.Date.ToString & "',[customer]=" & Me.selectedCustomer & ",[ledger]=" & Me.selectedLedgerType & ",[payment_type]=" & CInt(Me.selectedPaymentType) & ",[updated_at]='" & DateTime.Now.ToString & "'," &
            "[payment_due_date]='" & dtp_payment_due.ToString & "',[payment_terms]= " & Me.term & ",[remarks]='" & txtRemarks.Text & "' WHERE [ID] = " & Ledger.selectedID

            '.cmd.Parameters.AddWithValue("@counter_no", Convert.ToInt32(txtCounterNo.Text))
            '.cmd.Parameters.AddWithValue("@date_issue", dtpDateIssue.Value.Date.ToString)
            '.cmd.Parameters.AddWithValue("@invoice_no", txtInvoiceNo.Text)
            '.cmd.Parameters.AddWithValue("@amount", format_amount)
            '.cmd.Parameters.AddWithValue("@paid", ispaid)
            '.cmd.Parameters.AddWithValue("@date_paid", dtpPaid.Value.Date.ToString)
            '.cmd.Parameters.AddWithValue("@floating", isfloating)
            '.cmd.Parameters.AddWithValue("@bank_details", txtBankDetails.Text)
            '.cmd.Parameters.AddWithValue("@check_date", dtpCheckDate.Value.Date.ToString)
            '.cmd.Parameters.AddWithValue("@customer", Convert.ToInt32(Me.selectedCustomer))
            '.cmd.Parameters.AddWithValue("@ledger", Convert.ToInt32(Me.selectedLedgerType))
            '.cmd.Parameters.AddWithValue("@payment_type", Convert.ToInt32(Me.selectedPaymentType))
            '.cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
            '.cmd.Parameters.AddWithValue("@payment_due_date", dtp_payment_due.ToString)
            '.cmd.Parameters.AddWithValue("@payment_terms", Convert.ToInt32(term))
            '.cmd.Parameters.AddWithValue("@remarks", txtRemarks.Text)
            'MsgBox(.cmd.CommandText)
            'Exit Sub
            .cmd.ExecuteNonQuery()
            .cmd.Dispose()
            .con.Close()
        End With

        '' update the ledger of customer order(invoice list)
        Dim dbcon2 As New DatabaseConnect
        With dbcon2
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "Update customer_orders set ledger_id = 0 where ledger_id = " & Ledger.selectedID
            .cmd.ExecuteNonQuery()
            .cmd.Parameters.Clear()
            For Each item As DataGridViewRow In Me.dgvInvoiceList.Rows
                If dgvInvoiceList.Rows(item.Index).Cells("id").Value <> "" Then
                    Dim co_id As String = dgvInvoiceList.Rows(item.Index).Cells("id").Value
                    .cmd.CommandText = "update customer_orders set ledger_id = " & Ledger.selectedID & " where id = " & co_id
                    .cmd.ExecuteNonQuery()
                    .cmd.Parameters.Clear()
                End If
            Next
            .cmd.Dispose()
            .con.Close()
        End With
        MsgBox("Update Successful!", MsgBoxStyle.Information)
    End Sub

    Private Sub cbCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCustomer.SelectedIndexChanged
        If cbCustomer.SelectedIndex > 0 Then
            cbCustomer.BackColor = Color.White
            Dim key As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedCustomer = key

            Dim dbledger As New DatabaseConnect
            With dbledger
                .selectByQuery("select top 1 ledger from ledger where customer = " & selectedCustomer & " order by created_at desc")
                If .dr.HasRows Then
                    If .dr.Read Then
                        selectedLedgerType = .dr("ledger")
                        Select Case .dr("ledger")
                            Case "0"
                                cbLedgerType.SelectedIndex = cbLedgerType.FindString("Charge")

                            Case "1"
                                cbLedgerType.SelectedIndex = cbLedgerType.FindString("Delivery")
                        End Select
                    End If
                Else
                    .dr.Close()
                    .selectByQuery("Select ledger_type from company where id = " & selectedCustomer)
                    If .dr.HasRows Then
                        If .dr.Read Then
                            selectedLedgerType = .dr("ledger_type")
                            Select Case .dr("ledger_type")
                                Case "0"
                                    cbLedgerType.SelectedIndex = cbLedgerType.FindString("Charge")

                                Case "1"
                                    cbLedgerType.SelectedIndex = cbLedgerType.FindString("Delivery")
                            End Select
                        End If
                    End If
                End If
                .con.Close()
                .dr.Close()
                .cmd.Dispose()
            End With

        Else
            selectedCustomer = 0
            cbCustomer.SelectedIndex = 0
            If cbLedgerType.Items.Count > 0 Then
                selectedLedgerType = -1
                cbLedgerType.SelectedIndex = 0
            End If

        End If
    End Sub

    Public Sub loadLedgerType()
        cbLedgerType.DataSource = Nothing
        cbLedgerType.Items.Clear()

        Dim comboSource As New Dictionary(Of String, String)()

        comboSource.Add(-1, "Select Ledger Type")
        comboSource.Add(0, "Charge")
        comboSource.Add(1, "Delivery")

        cbLedgerType.DataSource = New BindingSource(comboSource, Nothing)
        cbLedgerType.DisplayMember = "Value"
        cbLedgerType.ValueMember = "Key"

        cbLedgerType.SelectedIndex = 0
    End Sub

    Public Sub loadPaymentType()
        cbPaymentType.DataSource = Nothing
        cbPaymentType.Items.Clear()

        Dim comboSource As New Dictionary(Of String, String)()

        comboSource.Add(-1, "Select Payment Type")
        comboSource.Add(0, "Cash")
        comboSource.Add(1, "C.O.D")
        comboSource.Add(2, "Credit")
        comboSource.Add(3, "Post Dated")

        cbPaymentType.DataSource = New BindingSource(comboSource, Nothing)
        cbPaymentType.ValueMember = "Key"
        cbPaymentType.DisplayMember = "Value"

        cbPaymentType.SelectedIndex = 0
    End Sub

    Private Sub cbLedgerType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLedgerType.SelectedIndexChanged
        If cbLedgerType.SelectedIndex > 0 Then
            cbLedgerType.BackColor = Color.White
            Dim key As String = CInt(DirectCast(cbLedgerType.SelectedItem, KeyValuePair(Of String, String)).Key)
            Dim value As String = DirectCast(cbLedgerType.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedLedgerType = key

        End If
    End Sub

    Private Sub cbPaymentType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPaymentType.SelectedIndexChanged
        If cbPaymentType.SelectedIndex > 0 Then
            cbPaymentType.BackColor = Color.White

            Select Case cbPaymentType.Text
                Case "Cash"
                    gpCheck.Enabled = False
                Case "C.O.D"
                    gpCheck.Enabled = False
                Case "Credit"
                    gpCheck.Enabled = True
                Case Else
                    gpCheck.Enabled = False
            End Select

            If Trim(cbPaymentType.Text) = "Credit" Then
                txtCounterNo.Enabled = True
                txtCounterNo.Text = ""
                rPaidNo.Checked = True
                rbFloatingNo.Checked = True
                gpPaid.Enabled = False
                dtpPaid.Enabled = False
                txtBankDetails.Enabled = False
                txtBankDetails.Clear()
                gpCheck.Enabled = False
                cbTerms.Enabled = True

            End If

            If Trim(cbPaymentType.Text) = "C.O.D" Then
                txtCounterNo.Enabled = False
                txtCounterNo.Text = "N/A"
                txtCounterNo.BackColor = Color.White
                rPaidYes.Checked = True
                rbFloatingYes.Checked = True
                gpPaid.Enabled = False
                dtpPaid.Enabled = True
                gpCheck.Enabled = True
                txtBankDetails.Enabled = True
                cbTerms.Enabled = False

            End If

            If Trim(cbPaymentType.Text) = "Cash" Then
                If selectedID = 0 Then
                    txtCounterNo.Enabled = False
                    txtCounterNo.Text = "N/A"
                    txtCounterNo.BackColor = Color.White
                End If

                rPaidYes.Checked = True
                rbFloatingYes.Checked = True
                gpPaid.Enabled = False
                dtpPaid.Enabled = True
                txtBankDetails.Enabled = False
                txtBankDetails.Clear()
                gpCheck.Enabled = False
                cbTerms.Enabled = False

            End If

            If Trim(cbPaymentType.Text) = "Post Dated" Then
                txtCounterNo.Enabled = True

                rPaidYes.Checked = True
                rbFloatingYes.Checked = True
                gpPaid.Enabled = False
                dtpPaid.Enabled = True
                gpCheck.Enabled = True
                txtBankDetails.Enabled = True
                cbTerms.Enabled = False

                If selectedID = 0 Then
                    txtCounterNo.Text = ""
                End If
            End If

            Dim key As Integer = CInt(DirectCast(cbPaymentType.SelectedItem, KeyValuePair(Of String, String)).Key)
            Dim value As String = DirectCast(cbPaymentType.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedPaymentType = key
        End If
    End Sub

    Private Function validator() As Boolean

        Dim err_ As Boolean = False
        If cbCustomer.SelectedIndex <= 0 Then
            MsgBox("Please select customer!", MsgBoxStyle.Critical)
            cbCustomer.BackColor = Color.Red
            cbCustomer.Focus()
            err_ = True
            Return err_
        End If

        If Trim(txtCounterNo.Text).Length = 0 And txtCounterNo.Enabled = True Then
            MsgBox("Please input counter no!", MsgBoxStyle.Critical)
            txtCounterNo.Focus()
            err_ = True
            Return err_
        End If

        'If Trim(txtInvoiceNo.Text).Length = 0 Then
        '    MsgBox("Please input invoice no!", MsgBoxStyle.Critical)
        '    txtCounterNo.Focus()
        '    err_ = True
        '    Return err_
        'End If

        If Trim(txtAmount.Text).Length = 0 Then
            MsgBox("Please input amount no!", MsgBoxStyle.Critical)
            txtCounterNo.Focus()
            err_ = True
            Return err_
        End If

        If cbPaymentType.SelectedIndex <= 0 Then
            MsgBox("Please select payment type!", MsgBoxStyle.Critical)
            cbPaymentType.BackColor = Color.Red
            cbPaymentType.Focus()
            err_ = True
            Return err_
        End If

        If rPaidYes.Checked = False And rPaidNo.Checked = False Then
            MsgBox("Please check if paid!", MsgBoxStyle.Critical)
            gpPaid.BackColor = Color.Red
            gpPaid.Focus()
            err_ = True
            Return err_
        End If

        If Trim(txtBankDetails.Text).Length = 0 And (cbPaymentType.Text = "Post Dated" Or cbPaymentType.Text = "C.O.D") Then
            MsgBox("Please input bank details!", MsgBoxStyle.Critical)
            txtBankDetails.BackColor = Color.Red
            txtBankDetails.Focus()
            err_ = True
            Return err_
        End If

        If gpCheck.Enabled = True And rPaidYes.Checked And (rbFloatingYes.Checked = False And rbFloatingNo.Checked = False) Then
            MsgBox("Please check floating!", MsgBoxStyle.Critical)
            gpCheck.BackColor = Color.Red
            gpCheck.Focus()
            err_ = True
            Return err_
        End If

        If selectedPaymentType = 2 And term = 0 Then
            MsgBox("Please select terms!", MsgBoxStyle.Critical)
            cbTerms.BackColor = Color.Red
            cbTerms.Focus()
            err_ = True
            Return err_
        End If



        If cbLedgerType.SelectedIndex <= 0 Then
            MsgBox("Please select ledger type!", MsgBoxStyle.Critical)
            cbLedgerType.BackColor = Color.Red
            cbLedgerType.Focus()
            err_ = True
            Return err_
        End If

        'input format validation
        If Not IsNumeric(txtAmount.Text) Then
            MsgBox("Invalid input type for amount!", MsgBoxStyle.Critical)
            txtAmount.BackColor = Color.Red
            txtAmount.Focus()
            err_ = True
            Return err_
        End If

        If Not IsNumeric(txtCounterNo.Text) And txtCounterNo.Enabled = True Then
            MsgBox("Invalid input for counter no!", MsgBoxStyle.Critical)
            txtCounterNo.BackColor = Color.Red
            txtCounterNo.Focus()
            err_ = True
            Return err_
        End If

        'If Not IsNumeric(txtInvoiceNo.Text) Then
        '    MsgBox("Invalid input for invoice no!", MsgBoxStyle.Critical)
        '    txtInvoiceNo.BackColor = Color.Red
        '    txtInvoiceNo.Focus()
        '    err_ = True
        '    Return err_
        'End If

        Return err_
    End Function

    Private Sub btnSaveAndPrint_Click(sender As Object, e As EventArgs) Handles btnSaveAndPrint.Click

        If btnSaveAndPrint.Text = "Save and Print" Then

            If (validator()) Then
                Exit Sub
            End If

            insertData()
            clearfields()
            Ledger.loadLedger("")
            Ledger.loadledgertype()
            Ledger.getPaymentMode()
            Me.Close()

            'Dim cr As New crLedgerByCustomer
            'cr.RecordSelectionFormula = "{ledger.ID} = " & getLastID()
            'ReportViewer.Enabled = True
            'ReportViewer.CrystalReportViewer1.ReportSource = cr
            'ReportViewer.CrystalReportViewer1.Refresh()
            'ReportViewer.CrystalReportViewer1.RefreshReport()
            'ReportViewer.ShowDialog()

        ElseIf btnSaveAndPrint.Text = "Update and Print" Then

            If (validator()) Then
                Exit Sub
            End If

            updateData()
            clearfields()
            Ledger.loadLedger("")
            Ledger.loadledgertype()
            Ledger.getPaymentMode()
            Me.Close()

            'Dim cr As New crLedgerByCustomer
            'cr.RecordSelectionFormula = "{ledger.ID} = " & Ledger.selectedID
            'ReportViewer.Enabled = True
            'ReportViewer.CrystalReportViewer1.ReportSource = cr
            'ReportViewer.CrystalReportViewer1.Refresh()
            'ReportViewer.CrystalReportViewer1.RefreshReport()
            'ReportViewer.ShowDialog()

        End If
    End Sub

    Public Function getLastID() As Integer
        Dim id As Integer = 0
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("SELECT ID from ledger where status <> 0 order by ID DESC")
            If .dr.Read Then
                id = .dr.GetValue(0)
            End If
        End With
        Return id
    End Function

    Private Sub rbFloatingYes_CheckedChanged(sender As Object, e As EventArgs) Handles rbFloatingYes.CheckedChanged
        If rbFloatingYes.Checked Then
            Me.isfloating = True
        End If
    End Sub

    Private Sub rbFloatingNo_CheckedChanged(sender As Object, e As EventArgs) Handles rbFloatingNo.CheckedChanged
        If rbFloatingNo.Checked Then
            Me.isfloating = False
        End If
    End Sub

    Private Sub txtCounterNo_TextChanged(sender As Object, e As EventArgs) Handles txtCounterNo.TextChanged
        If txtCounterNo.TextLength > 0 Then
            If Not IsNumeric(txtCounterNo.Text) Then
                txtCounterNo.BackColor = Color.Red
                txtCounterNo.SelectAll()
            Else
                txtCounterNo.BackColor = Color.White
            End If
        End If
    End Sub

    'Private Sub txtInvoiceNo_TextChanged(sender As Object, e As EventArgs)
    '    If txtInvoiceNo.TextLength > 0 Then
    '        If Not IsNumeric(txtInvoiceNo.Text) Then
    '            txtInvoiceNo.BackColor = Color.Red
    '            txtInvoiceNo.SelectAll()
    '        Else
    '            txtInvoiceNo.BackColor = Color.White
    '        End If
    '    End If
    'End Sub

    Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs) Handles txtAmount.TextChanged
        If txtAmount.TextLength > 0 Then
            If Not IsNumeric(txtAmount.Text) Then
                txtAmount.BackColor = Color.Red
                txtAmount.SelectAll()
            Else
                txtAmount.BackColor = Color.White
            End If
        End If
    End Sub

    Private Sub cbPaymentType_Enter(sender As Object, e As EventArgs) Handles cbPaymentType.Enter
        If txtAmount.Text.Length > 0 Then
            txtAmount.Text = FormatCurrency(txtAmount.Text).Replace("$", "")
        End If
    End Sub

    Private Sub cbTerms_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTerms.SelectedIndexChanged
        Select Case cbTerms.Text
            Case "30 Days"
                term = 30
            Case "60 Days"
                term = 60
            Case "90 Days"
                term = 90
            Case "120 Days"
                term = 120
            Case Else
                term = 0
        End Select
        If cbTerms.SelectedIndex > 0 Then
            cbTerms.BackColor = Color.White
        End If
    End Sub

    Private Sub btnAddCustomer_Click(sender As Object, e As EventArgs) Handles btnAddCustomer.Click
        CustomerForm.btnSave.Text = "Save"
        CustomerForm.loadCompanyStatus()
        CustomerForm.loadLedgerType()
        CustomerForm.ShowDialog()
    End Sub

    Private Sub txtAmount_MouseLeave(sender As Object, e As EventArgs) Handles txtAmount.MouseLeave
        If txtAmount.Text.Length > 0 Then
            txtAmount.Text = FormatCurrency(txtAmount.Text).Replace("$", "")
        End If
    End Sub

    Private Sub txtBankDetails_TextChanged(sender As Object, e As EventArgs) Handles txtBankDetails.TextChanged
        If Trim(txtBankDetails.Text).Length > 0 Then
            txtBankDetails.BackColor = Color.White
        End If
    End Sub

    Private Sub cbDisable_CheckedChanged(sender As Object, e As EventArgs) Handles cbDisable.CheckedChanged
        If cbDisable.Checked = True Then
            txtCounterNo.Text = "N/A"
            txtCounterNo.Enabled = False
            txtCounterNo.BackColor = Color.White
        Else
            txtCounterNo.Text = ""
            txtCounterNo.Enabled = True
        End If
    End Sub

    Private Sub dtpPaid_ValueChanged(sender As Object, e As EventArgs) Handles dtpPaid.ValueChanged
        If dtpCheckDate.Value > DateTime.Now Then
            rbFloatingYes.Checked = True
        Else
            rbFloatingNo.Checked = True
        End If
    End Sub

    Private Sub btnAddInvoice_Click(sender As Object, e As EventArgs) Handles btnAddInvoice.Click
        AddInvoiceForm.selectedCustomer = Me.selectedCustomer
        AddInvoiceForm.selectedLedger = Me.selectedID
        AddInvoiceForm.ShowDialog()
    End Sub

    Private Sub dgvInvoiceList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInvoiceList.CellContentClick
        'remove invoice
        If e.ColumnIndex = 5 And dgvInvoiceList.Rows.Count > 1 Then
            dgvInvoiceList.Rows.RemoveAt(e.RowIndex)

        End If
    End Sub



    Public Sub loadInvoice()
        dgvInvoiceList.Rows.Clear()
        Dim query As String = "select * from customer_orders where ledger_id = " & Ledger.selectedID
        query = query & " order by id DESC"

        Dim db As New DatabaseConnect
        With db
            .selectByQuery(query)
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = CInt(.dr("id"))
                    Dim invoice As String = .dr("invoice_no")
                    Dim date_issue As String = Convert.ToDateTime(.dr("date_issue")).ToString("MM-dd-yy")

                    Dim amount As String = Val(.dr("amount")).ToString("N2")
                    Dim amount_paid As String = Val(.dr("amount_paid")).ToString("N2")
                    Dim row As String() = New String() {id, invoice, date_issue, amount, amount_paid, "Remove"}
                    Me.dgvInvoiceList.Rows.Add(row)
                End While
            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Public Function generateLedgerNo() As String
        Dim res As String = ""
        Dim id As Integer = 0

        Dim db As New DatabaseConnect
        With db
            .selectByQuery("Select max(id) from ledger")
            If .dr.HasRows Then
                .dr.Read()
                id = If(IsDBNull(.dr.GetValue(0)), 0, .dr.GetValue(0))
                res = (id + 1).ToString("D7")
            Else
                res = (id + 1).ToString("D7")
            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
        Return "L-" & res
    End Function
End Class