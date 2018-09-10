Public Class LedgerForm

    Public selectedID As Integer = 0
    Public selectedCustomer As Integer = 0
    Public selectedPaymentType As Integer = 0
    Public term As Integer = 0
    Public isfloating As Boolean = False

    Public SelectedProdID As Integer = 0
    Public SelectedBrand As Integer = 0
    Public SelectedUnit As Integer = 0
    Public SelectedColor As Integer = 0

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

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If btnSave.Text = "Save" Then
            If (validator()) Then
                Exit Sub
            End If
            insertData()
            clearfields()
            LedgerList.loadLedger("", LedgerList.cbShow.SelectedItem)
            LedgerList.loadledgertype()
            LedgerList.getPaymentMode()

        ElseIf btnSave.Text = "Update" Then
            'MsgBox(selectedPaymentType)
            'Exit Sub
            If (validator()) Then
                Exit Sub
            End If
            updateData()
            clearfields()
            LedgerList.loadLedger("", LedgerList.cbShow.SelectedItem)
            LedgerList.loadledgertype()
            LedgerList.getPaymentMode()
            Me.Close()

        End If
    End Sub

    Public Sub clearfields()

        txtInvoiceNo.Text = ""
        txtAmount.Text = ""

        rPaidYes.Checked = False
        rPaidNo.Checked = False



        cbCustomer.SelectedIndex = 0
        cbPaymentType.SelectedIndex = 0
        cbTerms.SelectedIndex = 0
        txtRemarks.Clear()

        '** product clearing **'
        dgvProd.Rows.Clear()

    End Sub

    Private Sub insertData()

        Dim db As New DatabaseConnect
        With db
            Try
                .cmd.CommandType = CommandType.Text
                .cmd.Connection = .con
                .cmd.CommandText = "INSERT INTO customer_orders(invoice_no,customer_id,customer_address,date_issue,amount,amount_paid,payment_status,delivery_status,payment_due_date,payment_terms,remarks,paid,delivered_by,received_by,created_at,updated_at)
                    VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

                .cmd.Parameters.AddWithValue("@invoice_no", txtInvoiceNo.Text)
                .cmd.Parameters.AddWithValue("@customer_id", selectedCustomer)
                .cmd.Parameters.AddWithValue("@customer_address", txtAddress.Text)
                .cmd.Parameters.AddWithValue("@date_issue", dtpDateIssue.Value.Date.ToString)

                Dim format_amount As String = ""
                If txtAmount.Text.Contains(",") Or txtAmount.Text.Contains(".") Then
                    format_amount = txtAmount.Text.Replace(",", "")
                End If

                Dim format_amount_paid As String = ""
                If txtTotalAmountPaid.Text.Contains(",") Or txtTotalAmountPaid.Text.Contains(".") Then
                    format_amount_paid = txtTotalAmountPaid.Text.Replace(",", "")
                End If

                .cmd.Parameters.AddWithValue("@amount", format_amount)
                .cmd.Parameters.AddWithValue("@amount_paid", format_amount_paid)
                .cmd.Parameters.AddWithValue("@payment_status", 1)
                .cmd.Parameters.AddWithValue("@delivery_status", 1)
                Dim payment_date As New Date
                payment_date = dtpDateIssue.Value.AddDays(term)
                .cmd.Parameters.AddWithValue("@payment_due_date", payment_date.ToString)
                .cmd.Parameters.AddWithValue("@payment_terms", term)

                .cmd.Parameters.AddWithValue("@remarks", txtRemarks.Text)
                .cmd.Parameters.AddWithValue("@delivered_by", Trim(txtDeliveredBy.Text))
                .cmd.Parameters.AddWithValue("@received_by", Trim(txtReceivedBy.Text))


                Dim ispaid As Boolean
                If rPaidYes.Checked Then
                    ispaid = True
                End If

                If rPaidNo.Checked Then
                    ispaid = False
                End If
                .cmd.Parameters.AddWithValue("@paid", ispaid)
                .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)


                .cmd.ExecuteNonQuery()
                .cmd.Dispose()
                .con.Close()

                Dim saveproduct As New DatabaseConnect
                Dim cmd2 As New System.Data.OleDb.OleDbCommand
                cmd2.Connection = saveproduct.con
                cmd2.CommandType = CommandType.Text
                For Each item As DataGridViewRow In Me.dgvProd.Rows
                    Dim ledger_id As Integer = getLastID("ledger")
                    Dim product_unit_id As Integer = dgvProd.Rows(item.Index).Cells("id").Value

                    Dim qty As Integer = dgvProd.Rows(item.Index).Cells("quantity").Value
                    Dim price As String = dgvProd.Rows(item.Index).Cells("price").Value
                    Dim sell_price As String = dgvProd.Rows(item.Index).Cells("sell_price").Value
                    Dim less As String = dgvProd.Rows(item.Index).Cells("less").Value
                    Dim total_amount As String = dgvProd.Rows(item.Index).Cells("amount").Value



                    ' check if not blank
                    If (Not String.IsNullOrEmpty(dgvProd.Rows(item.Index).Cells("product").Value)) Then
                        cmd2.CommandText = "insert into customer_order_products (customer_order_ledger_id,product_unit_id,quantity,unit_price,sell_price,less,
                total_amount,created_at,updated_at)VALUES(?,?,?,?,?,?,?,?,?)"
                        cmd2.Parameters.AddWithValue("@customer_order_ledger_id", ledger_id)
                        cmd2.Parameters.AddWithValue("@product_unit_id", product_unit_id)
                        cmd2.Parameters.AddWithValue("@quantity", qty)
                        cmd2.Parameters.AddWithValue("@unit_price", price)
                        cmd2.Parameters.AddWithValue("@sell_price", sell_price)
                        cmd2.Parameters.AddWithValue("@less", less)
                        cmd2.Parameters.AddWithValue("@total_amount", total_amount)
                        cmd2.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                        cmd2.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                        cmd2.ExecuteNonQuery()
                        cmd2.Parameters.Clear()

                        'decrease stock
                        'Dim decreasestock As New DatabaseConnect
                        'With decreasestock
                        '    Dim temp As String = New DatabaseConnect().get_by_val("product_stocks", product_unit_id, "product_unit_id", "qty")
                        '    Dim cur_stock As Integer = Val(temp)
                        '    cur_stock = cur_stock - Val(qty)

                        '    .cmd.Connection = .con
                        '    .cmd.CommandType = CommandType.Text
                        '    .cmd.CommandText = "UPDATE product_stocks set [qty] = " & cur_stock & " where product_unit_id = " & product_unit_id
                        '    .cmd.ExecuteNonQuery()
                        '    .cmd.Dispose()
                        '    .con.Close()
                        'End With

                        ModelFunction.update_stock(product_unit_id, qty, "-")
                        ModelFunction.save_price_history(product_unit_id, price, dtpDateIssue.Value.ToString)

                    End If
                Next
                cmd2.Dispose()
                saveproduct.con.Close()

                MsgBox("Customer Order Save Successfully", MsgBoxStyle.Information)
                clearfields()
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message & " " & .cmd.CommandText, MsgBoxStyle.Critical)
            End Try
        End With
    End Sub

    Private Sub updateData()

        'If Trim(txtCounterNo.Text).Length = 0 Then
        '    txtCounterNo.Text = "N/A"
        'End If


        Dim ispaid As Boolean = False
        If rPaidYes.Checked = True Then
            ispaid = True
        Else
            ispaid = False
        End If

        'Dim isfloating As Boolean = False
        'If rbFloatingYes.Checked = True Then
        '    isfloating = True
        'Else
        '    isfloating = False
        'End If

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
            .cmd.CommandText = "UPDATE ledger SET [date_issue]='" & dtpDateIssue.Value.Date.ToString & "',[invoice_no]='" & txtInvoiceNo.Text & "',[amount]=" & format_amount & ", " &
            "[paid]=" & ispaid & ",[date_paid]='" & dtpPaid.Value.Date.ToString & "', [floating]=" & isfloating & ",[customer]=" & Me.selectedCustomer & ",[ledger]=" & getLedgerType(selectedCustomer) & ",[payment_type]=" & CInt(Me.selectedPaymentType) & ",[updated_at]='" & DateTime.Now.ToString & "'," &
            "[payment_due_date]='" & dtp_payment_due.ToString & "',[payment_terms]= " & Me.term & ",[remarks]='" & txtRemarks.Text & "' WHERE [ID] = " & LedgerList.selectedID

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
            MsgBox("Update Successful!", MsgBoxStyle.Information)

        End With
    End Sub


    Private Sub cbCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCustomer.SelectedIndexChanged
        If cbCustomer.SelectedIndex > 0 Then
            cbCustomer.BackColor = Drawing.Color.White
            Dim key As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedCustomer = key
        Else
            selectedCustomer = 0
        End If
    End Sub

    Public Sub loadPaymentType()
        cbPaymentType.DataSource = Nothing
        cbPaymentType.Items.Clear()

        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(-1, "Select Payment Type")
        comboSource.Add(0, "Cash")
        comboSource.Add(1, "C.O.D")
        comboSource.Add(2, "Credit")

        cbPaymentType.DataSource = New BindingSource(comboSource, Nothing)
        cbPaymentType.DisplayMember = "Value"
        cbPaymentType.ValueMember = "Key"

        cbPaymentType.SelectedIndex = 0
    End Sub

    Private Sub cbPaymentType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPaymentType.SelectedIndexChanged
        If cbPaymentType.SelectedIndex > 0 Then
            cbPaymentType.BackColor = Drawing.Color.White

            'Select Case cbPaymentType.Text
            '    Case "Cash"
            '        gpCheck.Enabled = False
            '    Case "C.O.D"
            '        gpCheck.Enabled = False
            '    Case "Credit"
            '        gpCheck.Enabled = True
            '    Case Else
            '        gpCheck.Enabled = False
            'End Select

            If Trim(cbPaymentType.Text) = "Credit" Then
                'txtCounterNo.Enabled = True
                'txtCounterNo.Text = ""
                rPaidNo.Checked = True
                'rbFloatingNo.Checked = True
                gpPaid.Enabled = False
                dtpPaid.Enabled = False
                'txtBankDetails.Enabled = False
                'txtBankDetails.Clear()
                'gpCheck.Enabled = False
                cbTerms.Enabled = True

            End If

            If Trim(cbPaymentType.Text) = "C.O.D" Then
                'txtCounterNo.Enabled = False
                'txtCounterNo.Text = "N/A"
                'txtCounterNo.BackColor = Drawing.Color.White
                rPaidYes.Checked = True
                'rbFloatingYes.Checked = True
                gpPaid.Enabled = False
                dtpPaid.Enabled = True
                'gpCheck.Enabled = True
                'txtBankDetails.Enabled = True
                cbTerms.Enabled = False

            End If

            If Trim(cbPaymentType.Text) = "Cash" Then
                'txtCounterNo.Enabled = False
                'txtCounterNo.Text = "N/A"
                'txtCounterNo.BackColor = Drawing.Color.White
                rPaidYes.Checked = True
                'rbFloatingYes.Checked = True
                gpPaid.Enabled = False
                dtpPaid.Enabled = True
                'txtBankDetails.Enabled = False
                'txtBankDetails.Clear()
                'gpCheck.Enabled = False
                cbTerms.Enabled = False

            End If

            If Trim(cbPaymentType.Text) = "Post Dated" Then
                'txtCounterNo.Enabled = True
                'txtCounterNo.Text = ""
                rPaidYes.Checked = True
                'rbFloatingYes.Checked = True
                gpPaid.Enabled = False
                dtpPaid.Enabled = True
                'gpCheck.Enabled = True
                'txtBankDetails.Enabled = True
                cbTerms.Enabled = False

            End If

            Dim key As Integer = CInt(DirectCast(cbPaymentType.SelectedItem, KeyValuePair(Of String, String)).Key)
            Dim value As String = DirectCast(cbPaymentType.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedPaymentType = key
        End If
    End Sub
    Private Function validator() As Boolean

        Dim err_ As Boolean = False
        If selectedCustomer <= 0 Then
            MsgBox("Please select customer!", MsgBoxStyle.Critical)
            cbCustomer.BackColor = Drawing.Color.Red
            cbCustomer.Focus()
            err_ = True
            Return err_
        End If

        'If Trim(txtCounterNo.Text).Length = 0 And txtCounterNo.Enabled = True Then
        '    MsgBox("Please input counter no!", MsgBoxStyle.Critical)
        '    txtCounterNo.Focus()
        '    err_ = True
        '    Return err_
        'End If

        'If Trim(txtInvoiceNo.Text).Length = 0 Then
        '    MsgBox("Please input invoice no!", MsgBoxStyle.Critical)
        '    txtCounterNo.Focus()
        '    err_ = True
        '    Return err_
        'End If

        'If Trim(txtAmount.Text).Length = 0 Then
        '    MsgBox("Please input amount no!", MsgBoxStyle.Critical)
        '    txtCounterNo.Focus()
        '    err_ = True
        '    Return err_
        'End If

        If cbPaymentType.SelectedIndex <= 0 Then
            MsgBox("Please select payment type!", MsgBoxStyle.Critical)
            cbPaymentType.BackColor = Drawing.Color.Red
            cbPaymentType.Focus()
            err_ = True
            Return err_
        End If

        If rPaidYes.Checked = False And rPaidNo.Checked = False Then
            MsgBox("Please check if paid!", MsgBoxStyle.Critical)
            gpPaid.BackColor = Drawing.Color.Red
            gpPaid.Focus()
            err_ = True
            Return err_
        End If

        'If Trim(txtBankDetails.Text).Length = 0 And (cbPaymentType.Text = "Post Dated" Or cbPaymentType.Text = "C.O.D") Then
        '    MsgBox("Please input bank details!", MsgBoxStyle.Critical)
        '    txtBankDetails.BackColor = Drawing.Color.Red
        '    txtBankDetails.Focus()
        '    err_ = True
        '    Return err_
        'End If

        'If gpCheck.Enabled = True And rPaidYes.Checked And (rbFloatingYes.Checked = False And rbFloatingNo.Checked = False) Then
        '    MsgBox("Please check floating!", MsgBoxStyle.Critical)
        '    gpCheck.BackColor = Drawing.Color.Red
        '    gpCheck.Focus()
        '    err_ = True
        '    Return err_
        'End If

        If selectedPaymentType = 2 And term = 0 Then
            MsgBox("Please select terms!", MsgBoxStyle.Critical)
            cbTerms.BackColor = Drawing.Color.Red
            cbTerms.Focus()
            err_ = True
            Return err_
        End If

        If Trim(txtDeliveredBy.Text).Length = 0 Then
            MsgBox("Please input delivered by!", MsgBoxStyle.Critical)
            txtDeliveredBy.Focus()
            err_ = True
            Return err_
        End If

        If Trim(txtReceivedBy.Text).Length = 0 Then
            MsgBox("Please input received by!", MsgBoxStyle.Critical)
            txtReceivedBy.Focus()
            err_ = True
            Return err_
        End If

        'input format validation
        If Not IsNumeric(txtAmount.Text) Then
            MsgBox("Invalid input type for amount!", MsgBoxStyle.Critical)
            txtAmount.BackColor = Drawing.Color.Red
            txtAmount.Focus()
            err_ = True
            Return err_
        End If

        'If Not IsNumeric(txtCounterNo.Text) And txtCounterNo.Enabled = True Then
        '    MsgBox("Invalid input for counter no!", MsgBoxStyle.Critical)
        '    txtCounterNo.BackColor = Drawing.Color.Red
        '    txtCounterNo.Focus()
        '    err_ = True
        '    Return err_
        'End If

        If Not IsNumeric(txtInvoiceNo.Text) Then
            MsgBox("Invalid input for invoice no!", MsgBoxStyle.Critical)
            txtInvoiceNo.BackColor = Drawing.Color.Red
            txtInvoiceNo.Focus()
            err_ = True
            Return err_
        End If

        ' ** product validation ** 

        If dgvProd.Rows.Count = 0 Or dgvProd.Rows.Count = 1 Then
            err_ = True
            MsgBox("Please add a product!", MsgBoxStyle.Critical)
            dgvProd.BackgroundColor = Drawing.Color.Red
            dgvProd.Focus()
            Return err_
        End If

        Dim validate As Boolean = False
        For Each item As DataGridViewRow In Me.dgvProd.Rows
            Dim qty As Integer = dgvProd.Rows(item.Index).Cells("quantity").Value
            Dim prod As String = dgvProd.Rows(item.Index).Cells("product").Value
            If qty <= 0 And prod <> "" Then
                dgvProd.Rows(item.Index).Cells("quantity").Style.BackColor = Drawing.Color.Red
                validate = True
            End If
        Next

        For Each item As DataGridViewRow In Me.dgvProd.Rows
            Dim sell_price As Double = dgvProd.Rows(item.Index).Cells("sell_price").Value
            Dim prod As String = dgvProd.Rows(item.Index).Cells("product").Value
            If sell_price <= 0.00 And prod <> "" Then
                dgvProd.Rows(item.Index).Cells("sell_price").Style.BackColor = Drawing.Color.Red
                validate = True
            End If
        Next

        If validate = True Then
            err_ = True
            Return err_
        End If

        Return err_
    End Function

    Private Sub btnSaveAndPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAndPrint.Click

        If btnSaveAndPrint.Text = "Save and Print" Then

            If (validator()) Then
                Exit Sub
            End If

            insertData()
            clearfields()

            'Dim cr As New COReport
            'cr.RecordSelectionFormula = "{customer_order_products.customer_order_ledger_id} = " & (getLastID("ledger"))
            'ReportViewer.Enabled = True
            'ReportViewer.CrystalReportViewer1.ReportSource = cr
            'ReportViewer.CrystalReportViewer1.Refresh()
            'ReportViewer.CrystalReportViewer1.RefreshReport()
            'ReportViewer.ShowDialog()
            Dim path As String = Application.StartupPath & "\co.html"
            'Dim filter() As String = {"sample1", "sample2"}
            Try
                Dim code As String = LedgerList.generatePrint(getLastID("ledger"))
                Dim myWrite As System.IO.StreamWriter
                myWrite = IO.File.CreateText(path)
                myWrite.WriteLine(code)
                myWrite.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try

            Dim proc As New System.Diagnostics.Process()
            proc = Process.Start(path, "")
            LedgerList.loadLedger("", LedgerList.cbShow.SelectedItem)
            LedgerList.loadledgertype()
            LedgerList.getPaymentMode()
        ElseIf btnSaveAndPrint.Text = "Update and Print" Then

            If (validator()) Then
                Exit Sub
            End If

            updateData()
            clearfields()
            LedgerList.loadLedger("", LedgerList.cbShow.SelectedItem)
            LedgerList.loadledgertype()
            LedgerList.getPaymentMode()
            Me.Close()

            'Dim cr As New crLedgerByCustomer
            'cr.RecordSelectionFormula = "{ledger.ID} = " & LedgerList.selectedID
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

    'Private Sub rbFloatingYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If rbFloatingYes.Checked Then
    '        Me.isfloating = True
    '    End If
    'End Sub

    'Private Sub rbFloatingNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If rbFloatingNo.Checked Then
    '        Me.isfloating = False
    '    End If
    'End Sub

    'Private Sub txtCounterNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If txtCounterNo.TextLength > 0 Then
    '        If Not IsNumeric(txtCounterNo.Text) Then
    '            txtCounterNo.BackColor = Drawing.Color.Red
    '            txtCounterNo.SelectAll()
    '        Else
    '            txtCounterNo.BackColor = Drawing.Color.White
    '        End If
    '    End If
    'End Sub

    Private Sub txtInvoiceNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvoiceNo.TextChanged
        If txtInvoiceNo.TextLength > 0 Then
            If Not IsNumeric(txtInvoiceNo.Text) Then
                txtInvoiceNo.BackColor = Drawing.Color.Red
                txtInvoiceNo.SelectAll()
            Else
                txtInvoiceNo.BackColor = Drawing.Color.White
            End If
        End If
    End Sub

    Private Sub txtAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmount.TextChanged
        If txtAmount.TextLength > 0 Then
            If Not IsNumeric(txtAmount.Text) Then
                txtAmount.BackColor = Drawing.Color.Red
                txtAmount.SelectAll()
            Else
                txtAmount.BackColor = Drawing.Color.White
            End If
        End If
    End Sub

    Private Sub cbPaymentType_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPaymentType.Enter
        If txtAmount.Text.Length > 0 Then
            txtAmount.Text = FormatCurrency(txtAmount.Text).Replace("$", "")
        End If
    End Sub

    Private Sub cbTerms_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTerms.SelectedIndexChanged
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
            cbTerms.BackColor = Drawing.Color.White
        End If
    End Sub

    Private Sub btnAddCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCustomer.Click
        CustomerForm.btnSave.Text = "Save"
        CustomerForm.loadCompanyStatus()
        CustomerForm.ShowDialog()
    End Sub

    Private Sub txtAmount_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmount.Leave
        If txtAmount.Text.Length > 0 Then
            txtAmount.Text = FormatCurrency(txtAmount.Text).Replace("$", "")
        End If
    End Sub

    'Private Sub txtBankDetails_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Trim(txtBankDetails.Text).Length > 0 Then
    '        txtBankDetails.BackColor = Drawing.Color.White
    '    End If
    'End Sub

    Private Sub LedgerForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        autocompleteProduct()
        populateBrand(0)
        populateColor(0, 0)
        populateUnit(0, 0, 0)
        Dim checked_by As Integer = New DatabaseConnect().get_by_id("ledger", selectedID, "checked_by")
        Dim approved_by As Integer = New DatabaseConnect().get_by_id("ledger", selectedID, "approved_by")

        If checked_by > 0 Then
            btnCheck.Enabled = False
        End If
        If approved_by > 0 Then
            btnApprove.Enabled = False
        End If
    End Sub

    Private Sub cbDisable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If cbDisable.Checked = True Then
        '    txtCounterNo.Text = "N/A"
        '    txtCounterNo.Enabled = False
        '    txtCounterNo.BackColor = Drawing.Color.White
        'Else
        '    txtCounterNo.Text = ""
        '    txtCounterNo.Enabled = True
        'End If
    End Sub

    Private Sub dgvProd_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProd.CellContentClick
        ' clicking add less
        If e.ColumnIndex = 9 Then
            Dim less As String = ""
            less = InputBox("Add less", "Enter the additional less(Numbers Only)", "0")

            ' validation
            If Not IsNumeric(less) Then
                MsgBox("Please insert number for less!", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If Trim(less).Length > 0 Then
                Dim less_string As String = dgvProd.Rows(e.RowIndex).Cells("less").Value
                If less_string.Length > 0 Then
                    If less_string.Contains(",") Then
                        dgvProd.Rows(e.RowIndex).Cells("less").Value = less_string & "," & less
                    ElseIf less_string.Length > 0 Then
                        dgvProd.Rows(e.RowIndex).Cells("less").Value = less_string & "," & less
                    End If
                Else
                    dgvProd.Rows(e.RowIndex).Cells("less").Value = less
                End If
            End If
        End If
        'reset less
        If e.ColumnIndex = 10 Then
            dgvProd.Rows(e.RowIndex).Cells("less").Value = "0"
        End If

        'remove product
        If e.ColumnIndex = 14 And dgvProd.Rows.Count > 1 Then
            dgvProd.Rows.RemoveAt(e.RowIndex)
            computeTotalAmount()
        End If
    End Sub

    Private Sub dgvProd_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProd.CellValueChanged
        If dgvProd.Rows.Count > 1 Then
            'change if edit the qty
            If e.ColumnIndex = 2 Then
                Dim amount As Double = 0
                Dim qty As Integer = CInt(dgvProd.Rows(e.RowIndex).Cells("quantity").Value)
                Dim price As Double = Val(dgvProd.Rows(e.RowIndex).Cells("price").Value)
                Dim less As String = CStr(dgvProd.Rows(e.RowIndex).Cells("less").Value)
                Dim sellprice As Double = CDbl(dgvProd.Rows(e.RowIndex).Cells("sell_price").Value.ToString.Replace(",", ""))

                amount = qty * CDbl(sellprice)

                If less.Contains(",") Then
                    Dim split = less.Split(",")
                    Try
                        Dim temp As Double = amount
                        Dim res As Double = 0
                        Dim x As Double = 0
                        For i As Integer = 0 To split.Length - 1
                            temp = temp * (1.0 - (Val(split(i)) / 100))
                        Next
                        dgvProd.Rows(e.RowIndex).Cells("amount").Value = temp
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Else
                    dgvProd.Rows(e.RowIndex).Cells("amount").Value = (amount * (1.0 - (Val(less) / 100))).ToString("N2")
                End If

                'change color
                If qty > 0 Then
                    dgvProd.Rows(e.RowIndex).Cells("quantity").Style.BackColor = Drawing.Color.White
                Else
                    dgvProd.Rows(e.RowIndex).Cells("quantity").Style.BackColor = Drawing.Color.Red
                End If
            End If

            If e.ColumnIndex = 7 Then
                Dim amount As Double = 0
                Dim qty As Integer = CInt(dgvProd.Rows(e.RowIndex).Cells("quantity").Value)
                Dim price As Double = Val(dgvProd.Rows(e.RowIndex).Cells("price").Value)
                Dim less As String = CStr(dgvProd.Rows(e.RowIndex).Cells("less").Value)
                Dim sellprice As Double = Val(dgvProd.Rows(e.RowIndex).Cells("sell_price").Value.ToString.Replace(",", ""))
                amount = qty * Val(sellprice)

                If less.Contains(",") Then
                    Dim split = less.Split(",")
                    Try
                        Dim temp As Double = amount
                        Dim res As Double = 0
                        Dim x As Double = 0
                        For i As Integer = 0 To split.Length - 1
                            temp = temp * (1.0 - (Val(split(i)) / 100))
                        Next
                        dgvProd.Rows(e.RowIndex).Cells("amount").Value = temp
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Else
                    dgvProd.Rows(e.RowIndex).Cells("amount").Value = (amount * (1.0 - (Val(less) / 100))).ToString("N2")
                End If
            End If

            'change if edit the sell price
            If e.ColumnIndex = 11 Then
                Dim amount As Double = 0
                Dim qty As Integer = CInt(dgvProd.Rows(e.RowIndex).Cells("quantity").Value)
                Dim price As Double = Val(dgvProd.Rows(e.RowIndex).Cells("price").Value)
                Dim less As String = CStr(dgvProd.Rows(e.RowIndex).Cells("less").Value)
                Dim sellprice As Double = CDbl(dgvProd.Rows(e.RowIndex).Cells("sell_price").Value.ToString.Replace(",", ""))

                amount = qty * CDbl(sellprice)

                If less.Contains(",") Then
                    Dim split = less.Split(",")
                    Try
                        Dim temp As Double = amount
                        Dim res As Double = 0
                        Dim x As Double = 0
                        For i As Integer = 0 To split.Length - 1
                            temp = temp * (1.0 - (Val(split(i)) / 100))
                        Next
                        dgvProd.Rows(e.RowIndex).Cells("amount").Value = temp
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Else
                    dgvProd.Rows(e.RowIndex).Cells("amount").Value = (amount * (1.0 - (Val(less) / 100))).ToString("N2")
                End If

                'change color
                If qty > 0 Then
                    dgvProd.Rows(e.RowIndex).Cells("sell_price").Style.BackColor = Drawing.Color.White
                Else
                    dgvProd.Rows(e.RowIndex).Cells("sell_price").Style.BackColor = Drawing.Color.Red
                End If
            End If
            computeTotalAmount()
        End If
    End Sub

    Public Sub computeTotalAmount()
        Dim totalamount As Double = 0.0
        If dgvProd.Rows.Count > 1 Then
            For Each item As DataGridViewRow In Me.dgvProd.Rows
                Dim amount As Double = dgvProd.Rows(item.Index).Cells("amount").Value
                totalamount += amount
            Next
        End If
        lblTotalAmount.Text = totalamount.ToString("N2")
        txtAmount.Text = totalamount.ToString("N2")
    End Sub

    'Public Sub populateProducts(ByVal catid As Integer, ByVal subcatid As Integer)
    '    Dim dbproduct As New DatabaseConnect
    '    With dbproduct
    '        cbProducts.DataSource = Nothing
    '        cbProducts.Items.Clear()
    '        Dim comboSource As New Dictionary(Of String, String)()
    '        comboSource.Add(0, "Select Product")
    '        Dim query As String = ""
    '        query = "Select distinct p.id, p.description,c.name,sub.name FROM ((((products As p 
    '            INNER JOIN product_categories as pc ON pc.product_id = p.id) 
    '            LEFT JOIN product_subcategories as psc ON psc.product_id = p.id)
    '            LEFT JOIN categories as c ON c.id = pc.category_id)
    '            LEFT JOIN categories as sub ON sub.id = psc.subcategory_id)  where p.status = 1"
    '        ' if filter by category
    '        If catid > 0 Then
    '            query = query & " And c.id = " & catid
    '        End If
    '        If subcatid > 0 Then
    '            query = query & " And Sub() .id = " & subcatid
    '        End If
    '        .selectByQuery(query)
    '        If .dr.HasRows Then
    '            While .dr.Read
    '                Dim id As String = .dr.GetValue(0)
    '                Dim product_desc As String = .dr.GetValue(1)
    '                comboSource.Add(id, product_desc)
    '            End While
    '        End If
    '        cbProducts.DataSource = New BindingSource(comboSource, Nothing)
    '        cbProducts.DisplayMember = "Value"
    '        cbProducts.ValueMember = "Key"
    '        .dr.Close()
    '        .cmd.Dispose()
    '        .con.Close()
    '    End With
    'End Sub

    Public Sub populateBrand(ByVal prodid As Integer)
        Dim dbbrand As New DatabaseConnect
        With dbbrand
            cbBrand.DataSource = Nothing
            cbBrand.Items.Clear()
            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "Select Brand")
            Dim query As String = "Select distinct b.id, b.name from (product_unit as pu LEFT JOIN brand as b on b.id = pu.brand) 
            where pu.product_id = " & prodid
            .selectByQuery(query)
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr.GetValue(0)
                    Dim brand As String = .dr.GetValue(1)
                    comboSource.Add(id, brand)
                End While
            End If
            cbBrand.DataSource = New BindingSource(comboSource, Nothing)
            cbBrand.DisplayMember = "Value"
            cbBrand.ValueMember = "Key"
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Public Sub populateUnit(ByVal prodid As Integer, ByVal brandid As Integer, ByVal colorid As Integer)
        Dim dbunit As New DatabaseConnect
        With dbunit
            cbUnit.DataSource = Nothing
            cbUnit.Items.Clear()
            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "Select Unit")
            Dim query As String = "Select distinct u.id, u.name from (product_unit as pu LEFT JOIN unit as u on u.id = pu.unit) 
            where pu.product_id = " & prodid & " and pu.brand = " & brandid & " and pu.color = " & colorid
            .selectByQuery(query)
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr.GetValue(0)
                    Dim unit As String = .dr.GetValue(1)
                    comboSource.Add(id, unit)
                End While
            End If
            cbUnit.DataSource = New BindingSource(comboSource, Nothing)
            cbUnit.DisplayMember = "Value"
            cbUnit.ValueMember = "Key"
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Public Sub populateColor(ByVal prodid As Integer, ByVal brandid As Integer)
        Dim dbunit As New DatabaseConnect
        With dbunit
            cbColor.DataSource = Nothing
            cbColor.Items.Clear()
            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "No Color")
            Dim query As String = "Select distinct c.id, c.name from (product_unit as pu LEFT JOIN color as c on c.id = pu.color) 
            where pu.product_id = " & prodid & " and pu.brand = " & brandid
            .selectByQuery(query)
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr.GetValue(0)
                    Dim unit As String = .dr.GetValue(1)
                    comboSource.Add(id, unit)
                End While
            End If
            cbColor.DataSource = New BindingSource(comboSource, Nothing)
            cbColor.DisplayMember = "Value"
            cbColor.ValueMember = "Key"
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Private Sub btnAddToCart_Click(sender As Object, e As EventArgs) Handles btnAddToCart.Click
        If selectedCustomer = 0 Then
            MsgBox("Please select customer before adding product!", MsgBoxStyle.Critical)
            cbCustomer.Focus()
            cbCustomer.BackColor = Drawing.Color.Red
            Exit Sub
        End If
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("SELECT pu.barcode,p.id,p.description,b.name as brand, u.name as unit,cc.name as color,pu.price, ps.qty as stock from (((((products as p 
                left join product_unit as pu on pu.product_id = p.id)
                left join brand as b on b.id = pu.brand)
                left join unit as u on u.id = pu.unit)
                left join color as cc on cc.id = pu.color)
                left join product_stocks as ps ON ps.product_unit_id = pu.id)
                where pu.brand = " & SelectedBrand & " and pu.product_id = " & SelectedProdID & " and pu.unit = " & SelectedUnit & " and color = " & SelectedColor)

            If .dr.HasRows Then
                If .dr.Read Then
                    Dim product_id As String = .dr("id").ToString
                    Dim barcode As String = .dr("barcode").ToString
                    Dim desc As String = .dr("description").ToString
                    Dim brand As String = .dr("brand").ToString
                    Dim unit As String = .dr("unit").ToString
                    Dim color As String = .dr("color").ToString
                    Dim unitprice As String = Val(.dr("price")).ToString("N2")
                    Dim sellprice As String = unitprice
                    'get sell price
                    Dim dbsellprice As New DatabaseConnect
                    With dbsellprice
                        .selectByQuery("Select sell_price from customer_product_prices where customer_id = " & selectedCustomer & " and product_id = " & SelectedProdID & " and brand = " & SelectedBrand & " and unit = " & SelectedUnit & " and color = " & SelectedColor)
                        If .dr.HasRows Then
                            If .dr.Read Then
                                If (Val(.dr("sell_price") > 0)) Then
                                    sellprice = Val(.dr("sell_price")).ToString("N2")
                                Else
                                    sellprice = unitprice
                                End If
                            End If
                        End If
                        .con.Close()
                        .dr.Close()
                        .cmd.Dispose()
                    End With

                    Dim stock As Integer = Val(.dr("stock"))

                    Dim row As String() = New String() {product_id, barcode, "0", desc, brand, unit, color, unitprice, "", "Add less", "Reset", sellprice, "0.00", stock, "Remove"}
                    dgvProd.Rows.Add(row)

                End If
            Else
                MsgBox("No Product Found!", MsgBoxStyle.Critical)
            End If
        End With
        computeTotalAmount()
    End Sub

    'Private Sub cbProducts_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    If cbProducts.SelectedIndex > 0 Then
    '        Dim key As String = DirectCast(cbProducts.SelectedItem, KeyValuePair(Of String, String)).Key
    '        Dim value As String = DirectCast(cbProducts.SelectedItem, KeyValuePair(Of String, String)).Value
    '        SelectedProdID = key
    '        populateBrand(SelectedProdID)
    '        populateUnit(SelectedProdID)
    '    End If
    'End Sub

    Private Sub cbBrand_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBrand.SelectedIndexChanged
        If cbBrand.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbBrand.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbBrand.SelectedItem, KeyValuePair(Of String, String)).Value
            SelectedBrand = key
            populateColor(SelectedProdID, SelectedBrand)
        Else
            SelectedBrand = 0
            populateColor(SelectedProdID, SelectedBrand)
        End If
    End Sub

    Private Sub cbColor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbColor.SelectedIndexChanged
        If cbColor.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbColor.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbColor.SelectedItem, KeyValuePair(Of String, String)).Value
            SelectedColor = key
            populateUnit(SelectedProdID, SelectedBrand, SelectedColor)
        Else
            SelectedColor = 0
            populateUnit(SelectedProdID, SelectedBrand, SelectedColor)
        End If
    End Sub

    Private Sub cbUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbUnit.SelectedIndexChanged
        If cbUnit.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbUnit.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbUnit.SelectedItem, KeyValuePair(Of String, String)).Value
            SelectedUnit = key
        Else
            SelectedUnit = 0
        End If
    End Sub

    Private Function getLastID(ByVal table As String) As Integer
        Dim id As Integer = 0
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("SELECT MAX(ID) from " & table)
            If .dr.HasRows Then
                .dr.Read()
                id = If(IsDBNull(.dr.GetValue(0)), 1, .dr.GetValue(0))
            Else
                id = 1
            End If
        End With
        Return id
    End Function

    Public Function generateInvoice() As String
        Dim res As String = ""
        Dim id As Integer = 0

        Dim db As New DatabaseConnect
        With db
            .selectByQuery("Select max(id) from ledger")
            If .dr.HasRows Then
                .dr.Read()
                id = If(IsDBNull(.dr.GetValue(0)), 0, .dr.GetValue(0))
                res = (id + 1).ToString("D5")
            Else
                res = (id + 1).ToString("D5")
            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With

        Return res
    End Function

    Public Sub toloadproductinfo(ByVal id As Integer)

        Dim dbOrderProduct As New DatabaseConnect
        With dbOrderProduct
            '.selectByQuery("Select distinct pu.id,pu.barcode,p.description,cop.quantity,b.name as brand, u.name as unit,c.name as color,pu.price,cop.less,cop.sell_price,cop.total_amount,ps.qty as stock from ((((((customer_order_products as cop
            '    left join products as p on p.id = cop.product_id)
            '    left join brand as b on b.id = cop.brand)
            '    left join unit as u on u.id = cop.unit)
            '    left join color as c on c.id = cop.color)
            '    left join product_unit as pu on pu.product_id = cop.product_id and pu.brand = cop.brand and pu.unit = cop.unit and pu.color = cop.color)
            '    left join product_stocks as ps on ps.product_unit_id = pu.id)
            '    where cop.customer_order_ledger_id = " & id)
            .selectByQuery("Select distinct pu.id,pu.barcode,p.description,cop.quantity,b.name as brand, u.name as unit,c.name as color,pu.price,cop.less,cop.sell_price,cop.total_amount,ps.qty as stock from ((((((customer_order_products as cop
                left join product_unit as pu ON pu.id = cop.product_unit_id)
                left join products as p on p.id = pu.product_id)
                left join brand as b on b.id = pu.brand)
                left join unit as u on u.id = pu.unit)
                left join color as c on c.id = pu.color)
                left join product_stocks as ps on ps.product_unit_id = pu.id)
                where cop.customer_order_ledger_id = " & id)

            dgvProd.Rows.Clear()
            If .dr.HasRows Then
                While .dr.Read
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

                    Dim row As String() = New String() {p_id, barcode, qty, desc, brand, unit, color, price, less, "Add less", "Reset", sell_price, total_amount, stock, "Remove"}
                    Me.dgvProd.Rows.Add(row)
                End While
            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Public Sub autocompleteProduct()
        Dim MySource As New AutoCompleteStringCollection()

        With txtProductDesc
            .AutoCompleteCustomSource = MySource
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.CustomSource
        End With

        Dim product As New DatabaseConnect
        With product
            .selectByQuery("Select description from products  where status <> 0  order by description")
            While .dr.Read
                MySource.Add(.dr("description"))
            End While
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
    End Sub

    Public Sub enableControl(ByVal flag As Boolean)
        btnAddToCart.Enabled = flag
        dgvProd.Enabled = flag
        gpEnterBarcode.Enabled = flag
        gpEnterProduct.Enabled = flag

        cbCustomer.Enabled = flag
        btnAddCustomer.Enabled = flag
        dtpDateIssue.Enabled = flag
        'txtCounterNo.Enabled = flag
        'cbDisable.Enabled = flag
        'txtInvoiceNo.Enabled = flag
        'txtAmount.Enabled = flag
        cbPaymentType.Enabled = flag
        gpPaid.Enabled = flag
        dtpPaid.Enabled = flag
        cbTerms.Enabled = flag
        txtRemarks.Enabled = flag
        txtDeliveredBy.Enabled = flag
        txtReceivedBy.Enabled = flag
    End Sub

    Private Sub txtProductDesc_TextChanged(sender As Object, e As EventArgs) Handles txtProductDesc.TextChanged
        If Trim(txtProductDesc.Text).Length > 0 Then
            SelectedProdID = New DatabaseConnect().get_id("products", "description", Trim(txtProductDesc.Text))
            populateBrand(SelectedProdID)
        Else
            SelectedProdID = 0
            populateBrand(SelectedProdID)
        End If
    End Sub

    Private Sub txtEnterBarcode_KeyUp(sender As Object, e As KeyEventArgs) Handles txtEnterBarcode.KeyUp
        If e.KeyCode = Keys.Enter Then
            If Trim(txtEnterBarcode.Text).Length > 0 Then
                'validation
                ' check if exist
                For Each item As DataGridViewRow In dgvProd.Rows
                    If item.Cells("product").Value <> "" Then
                        Dim barcode As String = item.Cells("barcode").Value

                        If barcode = Trim(txtEnterBarcode.Text) Then
                            MsgBox("Product (" & txtEnterBarcode.Text & ") already added!", MsgBoxStyle.Critical)
                            txtEnterBarcode.Text = ""
                            Exit Sub
                        End If
                    End If
                Next

                Dim db As New DatabaseConnect
                With db
                    .selectByQuery("Select distinct pu.product_id, pu.id, pu.barcode, p.description, b.name As brand, u.name As unit, cc.name As color,pu.price as price,
                        pu.brand as brand_id,pu.unit as unit_id,pu.color as color_id,ps.qty as stock, c.name As cat,sub.name as subcat FROM (((((((((products as p 
                    INNER Join product_unit as pu ON p.id = pu.product_id) 
                    Left Join brand as b ON b.id = pu.brand)
                    INNER Join unit as u ON u.id = pu.unit)
                    Left Join color as cc ON cc.id = pu.color)
                    LEFT JOIN product_stocks as ps on ps.product_unit_id = pu.id)
                    INNER Join product_categories as pc ON pc.product_id = p.id) 
                    Left Join product_subcategories as psc ON psc.product_id = p.id)
                    Left Join categories as c ON c.id = pc.category_id)
                    Left Join categories as sub ON sub.id = psc.subcategory_id)  where pu.status <> 0 and p.status <> 0 and pu.barcode = '" & Trim(txtEnterBarcode.Text) & "'")

                    If .dr.Read Then
                        Dim p_u_id As Integer = CInt(.dr("id"))
                        Dim brand_id As Integer = CInt(.dr("brand_id"))
                        Dim unit_id As Integer = CInt(.dr("unit_id"))
                        Dim color_id As Integer = CInt(.dr("color_id"))

                        Dim id As Integer = CInt(.dr("id"))
                        Dim barcode As String = .dr("barcode")
                        Dim desc As String = .dr("description")
                        Dim brand As String = If(IsDBNull(.dr("brand")), "", .dr("brand"))
                        Dim unit As String = .dr("unit")
                        Dim color As String = If(IsDBNull(.dr("color")), "", .dr("color"))
                        Dim price As String = Val(.dr("price")).ToString("N2")
                        Dim sell_price As String = Val(getSellPrice(selectedCustomer, p_u_id)).ToString("N2")
                        Dim stock As Integer = Val(.dr("stock"))
                        Dim row As String() = New String() {id, barcode, "", desc, brand, unit, color, price, "", "Add less", "Reset", sell_price, "0.00", stock, "Remove"}
                        dgvProd.Rows.Add(row)
                        txtEnterBarcode.Text = ""
                    End If

                    .dr.Close()
                    .cmd.Dispose()
                    .con.Close()
                End With
            End If

        End If
    End Sub

    Private Function getSellPrice(ByVal customer As Integer, ByVal p_u_id As Integer)
        Dim res As String = ""
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("Select sell_price from customer_product_prices where customer_id = " & customer & " and product_unit_id = " & p_u_id)
            If .dr.Read Then
                res = Val(.dr("sell_price")).ToString("N2")
            Else
                res = "0.00"
            End If
        End With
        Return res
    End Function

    Private Function getLedgerType(ByVal customer As Integer)
        Dim result As String = "0"
        result = CInt(New DatabaseConnect().get_by_id("company", customer, "ledger_type"))
        Return result
    End Function

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Dim yesno As Integer = MsgBox("Are you sure you want this transaction as checked ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Ledger")
        If yesno = MsgBoxResult.Yes Then
            'update to checked
            Dim dbupdate As New DatabaseConnect
            dbupdate.update_where("ledger", selectedID, "checked_by", Main_form.auth_login)
            dbupdate.cmd.Dispose()
            dbupdate.con.Close()
            btnCheck.Enabled = False
            MsgBox("Ledger has been successfully checked.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Dim yesno As Integer = MsgBox("Are you sure you want to approve this transaction ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Ledger")
        If yesno = MsgBoxResult.Yes Then
            'update to approved
            Dim dbupdate As New DatabaseConnect
            dbupdate.update_where("ledger", selectedID, "approved_by", Main_form.auth_login)
            dbupdate.cmd.Dispose()
            dbupdate.con.Close()
            btnApprove.Enabled = False
            MsgBox("Ledger has been successfully approved.", MsgBoxStyle.Information)
        End If
    End Sub


End Class
