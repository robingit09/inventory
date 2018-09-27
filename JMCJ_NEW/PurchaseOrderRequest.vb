Public Class PurchaseOrderRequest
    Public selectedSupplier As Integer = 0
    Private Sub PurchaseOrderRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadPOR("")
        autocompleteSupplier()
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
        PurchaseOrderRequestForm.ShowDialog()
        btnAddNew.Enabled = True
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If dgvPO.SelectedRows.Count = 0 Then
            MsgBox("Please select one record!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Dim por_id As Integer = dgvPO.SelectedRows(0).Cells(0).Value
        PurchaseOrderRequestForm.initialize()
        PurchaseOrderRequestForm.loadInfo(por_id)
        PurchaseOrderRequestForm.btnSave.Enabled = False
        PurchaseOrderRequestForm.dgvProd.Enabled = False
        PurchaseOrderRequestForm.gpEnterBarcode.Enabled = False
        PurchaseOrderRequestForm.gpEnterProduct.Enabled = False
        PurchaseOrderRequestForm.ShowDialog()
    End Sub

    Private Sub dgvPO_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPO.CellContentClick
        'remove invoice
        If e.ColumnIndex = 7 And dgvPO.Rows.Count > 1 Then
            'dgvInvoiceList.Rows.RemoveAt(e.RowIndex)
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
        If selectedSupplier > 0 Then
            query = query & " and supplier = " & selectedSupplier
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
End Class