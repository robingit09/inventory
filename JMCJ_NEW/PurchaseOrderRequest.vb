Public Class PurchaseOrderRequest
    Public selectedSupplier As Integer = 0
    Public selectedPOR As Integer = 0
    Private Sub PurchaseOrderRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        autocompleteSupplier()
        loadPORSelection()
        getMonth()
        getYear()
        loadPOR("")

        'check user access
        If ModelFunction.check_access(9, 1) = 1 Then
            btnAddNew.Enabled = True
            btnView.Enabled = True
            btnVoid.Enabled = True
        Else
            btnAddNew.Enabled = False
            btnView.Enabled = False
            btnVoid.Enabled = False
        End If
    End Sub
    Public Sub loadPOR(ByVal query As String)
        dgvPO.Rows.Clear()
        Dim dbPO As New DatabaseConnect
        With dbPO
            If query = "" Then
                .selectByQuery("Select * from purchase_orders_request order by id desc")
            Else
                .selectByQuery(query)
            End If

            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr("id")
                    Dim por_no As String = .dr("por_no")
                    Dim supplier_id As Integer = CInt(.dr("supplier"))
                    Dim supplier_name As String = New DatabaseConnect().get_by_id("suppliers", supplier_id, "supplier_name")
                    Dim recorded_date As String = Convert.ToDateTime(.dr("por_date")).ToString("MM-dd-yy")
                    Dim total_amount As String = Val(.dr("total_amount")).ToString("N2")
                    Dim process_by As String = If(IsDBNull(.dr("processed_by")), "0", .dr("processed_by"))
                    process_by = New DatabaseConnect().get_by_id("users", CInt(process_by), "first_name")
                    Dim status As String = ""

                    Select Case .dr("status")
                        Case "0"
                            status = "Voided"
                        Case "1"
                            status = "Active"
                        Case Else

                            status = ""

                    End Select
                    Dim row As String() = New String() {id, recorded_date, por_no, supplier_name, total_amount, process_by, status, "Create PO+"}
                    dgvPO.Rows.Add(row)
                End While
                For Each row As DataGridViewRow In dgvPO.Rows
                    If row.Cells("status").Value = "Voided" Then
                        row.DefaultCellStyle.BackColor = Color.OrangeRed
                    End If
                Next
            End If

            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        'PurchaseOrderRequestForm.clearFields()
        btnAddNew.Enabled = False
        PurchaseOrderRequestForm.clearFields()
        PurchaseOrderRequestForm.initialize()
        PurchaseOrderRequestForm.btnSave.Enabled = True
        'PurchaseOrderRequestForm.btnSaveAndPrint.Enabled = True
        PurchaseOrderRequestForm.dgvProd.Enabled = True
        'PurchaseOrderRequestForm.gpFields.Enabled = True
        PurchaseOrderRequestForm.gpEnterBarcode.Enabled = True
        PurchaseOrderRequestForm.gpEnterProduct.Enabled = True
        PurchaseOrderRequestForm.btnCreatePO.Visible = False
        PurchaseOrderRequestForm.ShowDialog()
        btnAddNew.Enabled = True
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If dgvPO.SelectedRows.Count = 0 Then
            MsgBox("Please select one record!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        btnView.Enabled = False
        Dim por_id As Integer = dgvPO.SelectedRows(0).Cells(0).Value
        PurchaseOrderRequestForm.initialize()
        PurchaseOrderRequestForm.loadInfo(por_id)
        PurchaseOrderRequestForm.btnSave.Enabled = False
        PurchaseOrderRequestForm.dgvProd.Enabled = False
        PurchaseOrderRequestForm.gpEnterBarcode.Enabled = False
        PurchaseOrderRequestForm.gpEnterProduct.Enabled = False
        PurchaseOrderRequestForm.btnCreatePO.Visible = True
        PurchaseOrderRequestForm.ShowDialog()
        btnView.Enabled = True
    End Sub

    Private Sub dgvPO_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPO.CellContentClick
        'create po
        If e.ColumnIndex = 7 And dgvPO.Rows.Count > 1 Then
            If dgvPO.Rows(e.RowIndex).Cells("id").Value <> "" Then
                Dim id As Integer = dgvPO.Rows(e.RowIndex).Cells("id").Value
                Dim status As String = dgvPO.Rows(e.RowIndex).Cells("status").Value
                If status = "Voided" Then
                    MsgBox("This record has already been voided!", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                PurchaseOrderForm.clearFields()
                PurchaseOrderForm.initialize()
                PurchaseOrderForm.createPO(id)
                PurchaseOrderForm.dgvProd.Visible = True
                PurchaseOrderForm.ShowDialog()

            End If
        End If
    End Sub

    Private Sub btnVoid_Click(sender As Object, e As EventArgs) Handles btnVoid.Click
        If dgvPO.SelectedRows.Count = 0 Then
            MsgBox("Please select one record!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim por_id As Integer = dgvPO.SelectedRows(0).Cells(0).Value
        Dim status As String = dgvPO.SelectedRows(0).Cells("status").Value

        If status = "Voided" Then
            MsgBox("Already voided!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim yn As Integer = MsgBox("Are you sure you want to void this transaction ? ", MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If yn = MsgBoxResult.Yes Then
            Dim db As New DatabaseConnect
            db.update_where("purchase_orders_request", por_id, "status", 0)
            db.cmd.Dispose()
            db.con.Close()
            MsgBox("Purchase Order Request Successfully Void.", MsgBoxStyle.Information)
            loadPOR("")
        End If
    End Sub

    Public Sub autocompleteSupplier()
        Dim MySource As New AutoCompleteStringCollection()

        With txtSupplier
            .AutoCompleteCustomSource = MySource
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.CustomSource
        End With

        Dim product As New DatabaseConnect
        With product
            .selectByQuery("Select supplier_name from suppliers where status <> 0  order by supplier_name")
            While .dr.Read
                MySource.Add(.dr("supplier_name"))
            End While
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
    End Sub

    Private Sub txtSupplier_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSupplier.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Trim(txtSupplier.Text).Length > 0 Then
                selectedSupplier = New DatabaseConnect().get_id("suppliers", "supplier_name", Trim(txtSupplier.Text))
                'txtSupplier.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtSupplier.Text.ToLower())
            Else
                selectedSupplier = 0

            End If
        End If
    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        btnFilter.Enabled = False
        Dim query As String = "Select * from purchase_orders_request where status >= 0"
        If txtSupplier.Text <> "" And selectedSupplier > 0 Then
            query = query & " and supplier = " & selectedSupplier
        End If

        If cbPORNo.SelectedIndex > 0 And selectedPOR > 0 Then
            query = query & " and id = " & selectedPOR
        End If
        If cbMonth.Text <> "All" Then
            query = query & " and MONTH(por_date) = " & monthToNumber(cbMonth.Text)
        End If

        If cbYear.Text <> "All" Then
            query = query & " and YEAR(por_date) = " & cbYear.Text
        End If

        query = query & " order by id desc"
        loadPOR(query)
        btnFilter.Enabled = True

    End Sub

    Private Sub txtSupplier_TextChanged(sender As Object, e As EventArgs) Handles txtSupplier.TextChanged
        If Trim(txtSupplier.Text) = "" Then
            selectedSupplier = 0
        End If
    End Sub

    Private Sub txtSupplier_MouseLeave(sender As Object, e As EventArgs) Handles txtSupplier.MouseLeave
        If Trim(txtSupplier.Text).Length > 0 Then
            selectedSupplier = New DatabaseConnect().get_id("suppliers", "supplier_name", Trim(txtSupplier.Text))
        Else
            selectedSupplier = 0
        End If
    End Sub

    Public Sub loadPORSelection()
        cbPORNo.DataSource = Nothing
        cbPORNo.Items.Clear()
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("SELECT id,por_no from purchase_orders_request where status <> 0 order by por_date desc")
            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "Select POR Number")
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = CInt(.dr("id"))
                    Dim por As String = .dr("por_no")
                    comboSource.Add(id, por)
                End While
            End If
            cbPORNo.DataSource = New BindingSource(comboSource, Nothing)
            cbPORNo.DisplayMember = "Value"
            cbPORNo.ValueMember = "Key"
            .dr.Close()
            .cmd.Dispose()
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

    Public Sub getYear()
        cbYear.Items.Clear()
        cbYear.Items.Add("All")
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("SELECT distinct YEAR(por_date) FROM purchase_orders_request where status <> 0 order by YEAR(por_date) DESC")
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

    Private Sub cbPORNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPORNo.SelectedIndexChanged
        If cbPORNo.SelectedIndex > 0 Then
            cbPORNo.BackColor = Drawing.Color.White
            Dim key As String = DirectCast(cbPORNo.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbPORNo.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedPOR = key

        Else
            selectedPOR = 0
        End If
    End Sub
End Class