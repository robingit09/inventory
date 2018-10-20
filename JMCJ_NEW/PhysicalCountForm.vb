Public Class PhysicalCountForm

    Public selectedPC As Integer = 0
    Private Sub btnSelectProduct_Click(sender As Object, e As EventArgs) Handles btnSelectProduct.Click
        SupplierProductSelection.module_selection = 5
        SupplierProductSelection.loadSupplierProducts(0)
        SupplierProductSelection.ShowDialog()
    End Sub

    Private Sub dgvProd_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProd.CellContentClick
        'remove product
        If dgvProd.Rows(e.RowIndex).Cells(8).Value <> "" Then
            If e.ColumnIndex = 8 And dgvProd.Rows.Count > 1 Then
                dgvProd.Rows.RemoveAt(e.RowIndex)

            End If
        End If
    End Sub

    Public Sub initialize()
        txtPCNO.Text = generatePCNO()
        txtIssuedBy.Text = New DatabaseConnect().get_by_id("users", Main_form.auth_login, "first_name") & " " & New DatabaseConnect().get_by_id("users", Main_form.auth_login, "surname")
        dtp_r_date.Value = DateTime.Now
    End Sub

    Private Sub PhysicalCountForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub



    Private Function generatePCNO()
        Dim result As String = ""
        Try
            Dim db As New DatabaseConnect
            With db
                .selectByQuery("SELECT COUNT(id) from physical_count")
                If .dr.Read Then
                    Dim count_supplier As Integer = CInt(.dr.GetValue(0))
                    'result = "PO-" & getSupplierCode(selectedSupplier) & "-" & (count_supplier + 1).ToString("D6")
                    result = "PC-" & (count_supplier + 1).ToString("D6")
                End If

                .dr.Close()
                .cmd.Dispose()
                .con.Close()
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return result
    End Function

    Private Sub dgvProd_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProd.CellValueChanged
        If dgvProd.Rows.Count > 1 Then
            'change if edit the actual_count
            If e.ColumnIndex = 6 And dgvProd.Rows(e.RowIndex).Cells("product").Value <> "" Then
                Dim actual_count As Integer = 0
                If IsNumeric(dgvProd.Rows(e.RowIndex).Cells("actual_count").Value.ToString().Replace(",", "")) Then
                    actual_count = CInt(dgvProd.Rows(e.RowIndex).Cells("actual_count").Value.ToString().Replace(",", ""))
                Else
                    actual_count = 0
                End If

                'change color
                If actual_count > 0 Then
                    dgvProd.Rows(e.RowIndex).Cells("actual_count").Style.BackColor = Drawing.Color.White
                Else
                    dgvProd.Rows(e.RowIndex).Cells("actual_count").Style.BackColor = Drawing.Color.Red
                End If
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.Text = "Save" Then

            If validation() = False Then
                Exit Sub
            End If
            insertData()
            clearFields()
            PhysicalCount.loadList("")
            Me.Close()
        End If
    End Sub

    Private Function validation() As Boolean

        If Trim(txtIssuedBy.Text) = "" Then
            MsgBox("Issue By field is required!", MsgBoxStyle.Critical)
            txtIssuedBy.Focus()
            Return False
        End If

        If dgvProd.Rows.Count <= 1 Then
            MsgBox("Please add product!", MsgBoxStyle.Critical)
            dgvProd.Focus()
            Return False
        End If

        'actual count validation
        Dim validate As Boolean = False
        For Each item As DataGridViewRow In Me.dgvProd.Rows
            Dim actual_count As String = dgvProd.Rows(item.Index).Cells("actual_count").Value
            Dim prod As String = dgvProd.Rows(item.Index).Cells("product").Value
            If prod <> "" Then
                If actual_count = "" Then
                    dgvProd.Rows(item.Index).Cells("actual_count").Style.BackColor = Drawing.Color.Red
                    validate = True
                End If

                If IsNumeric(actual_count) And Val(actual_count) <= 0 Then
                    dgvProd.Rows(item.Index).Cells("actual_count").Style.BackColor = Drawing.Color.Red
                    validate = True
                End If
            End If

        Next

        If validate = True Then
            Return False
        End If
        Return True
    End Function


    Private Sub insertData()
        Dim insertPC As New DatabaseConnect
        With insertPC
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "INSERT INTO physical_count (pc_no,issued_by,user_id,recorded_date,status,created_at,updated_at)
                VALUES(?,?,?,?,?,?,?)"
            .cmd.Parameters.AddWithValue("@pc_no", generatePCNO())
            .cmd.Parameters.AddWithValue("@issued_by", Trim(txtIssuedBy.Text))
            .cmd.Parameters.AddWithValue("@user_id", Main_form.auth_login)
            .cmd.Parameters.AddWithValue("@recorded_date", dtp_r_date.Value.Date.ToString)
            .cmd.Parameters.AddWithValue("@status", 1)
            .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
            .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)

            .cmd.ExecuteNonQuery()
            .cmd.Dispose()
            .con.Close()

        End With

        Dim insertProduct As New DatabaseConnect
        With insertProduct
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            For Each item As DataGridViewRow In Me.dgvProd.Rows

                Dim product_unit_id As String = dgvProd.Rows(item.Index).Cells("id").Value
                Dim actual_count As String = dgvProd.Rows(item.Index).Cells("actual_count").Value
                Dim system_count As String = dgvProd.Rows(item.Index).Cells("system_count").Value


                If (Not String.IsNullOrEmpty(dgvProd.Rows(item.Index).Cells("product").Value)) Then
                    .cmd.CommandText = "INSERT INTO physical_count_products(physical_count_id,product_unit_id,actual_count,system_count,created_at,updated_at)
                        VALUES(?,?,?,?,?,?)"

                    .cmd.Parameters.AddWithValue("@physical_count_id", getLastID("physical_count"))
                    .cmd.Parameters.AddWithValue("@product_unit_id", product_unit_id)
                    .cmd.Parameters.AddWithValue("@actual_count", actual_count)
                    .cmd.Parameters.AddWithValue("@system_count", system_count)
                    .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                    .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                    .cmd.ExecuteNonQuery()
                    .cmd.Parameters.Clear()
                    ModelFunction.adjuststock(product_unit_id, actual_count)

                End If


            Next
            .cmd.Dispose()
            .con.Close()
        End With
        MsgBox("Physical Count Successfully Save.", MsgBoxStyle.Information)
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

    Public Sub clearFields()
        selectedPC = 0
        txtPCNO.Text = ""
        txtIssuedBy.Text = ""
        dtp_r_date.Value = DateTime.Now
        dgvProd.Rows.Clear()
    End Sub

    Public Sub loadInfo(ByVal id As Integer)
        Me.selectedPC = id
        txtPCNO.Text = New DatabaseConnect().get_by_id("physical_count", id, "pc_no")
        Dim recorded_date As String = New DatabaseConnect().get_by_id("physical_count", id, "recorded_date")
        dtp_r_date.Value = recorded_date
        txtIssuedBy.Text = New DatabaseConnect().get_by_id("physical_count", id, "issued_by")

        Dim dbprod As New DatabaseConnect()
        dgvProd.Rows.Clear()
        With dbprod
            .selectByQuery("select distinct pu.id,pu.barcode,p.description,b.name as brand,u.name as unit,c.name as color,pop.actual_count,pop.system_count
                        FROM ((((((physical_count_products as pop
                        INNER JOIN product_unit as pu ON pu.id = pop.product_unit_id)
                        LEFT JOIN brand as b ON b.id = pu.brand)
                        INNER JOIN unit as u ON u.id = pu.unit)
                        LEFT JOIN color as c ON c.id = pu.color)
                        INNER JOIN products as p ON p.id = pu.product_id)
                        LEFT join product_stocks as ps on ps.product_unit_id = pu.id)
                        where pop.physical_count_id = " & id)
            If .dr.HasRows Then
                While .dr.Read
                    Dim p_u_id As Integer = .dr("id")
                    Dim barcode As String = .dr("barcode")
                    Dim desc As String = .dr("description")
                    Dim brand As String = If(IsDBNull(.dr("brand")), "", .dr("brand"))
                    Dim unit As String = .dr("unit")
                    Dim color As String = If(IsDBNull(.dr("color")), "", .dr("color"))
                    Dim actual_count As String = .dr("actual_count")
                    Dim system_count As String = .dr("system_count")
                    Dim row As String() = New String() {p_u_id, barcode, desc, brand, unit, color, actual_count, system_count, "Remove"}
                    dgvProd.Rows.Add(row)
                End While
            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
    End Sub

    Public Sub freeView(ByVal flag As Boolean)

        If flag = True Then
            txtPCNO.Enabled = False
            txtIssuedBy.Enabled = False
            dtp_r_date.Enabled = False
            gpEnterBarcode.Enabled = False
            gpEnterProduct.Enabled = False
            dgvProd.Enabled = False

            btnSelectProduct.Enabled = False
            btnSave.Enabled = False
        Else
            txtPCNO.Enabled = True
            txtIssuedBy.Enabled = True
            dtp_r_date.Enabled = True
            gpEnterBarcode.Enabled = True
            gpEnterProduct.Enabled = True
            dgvProd.Enabled = True

            btnSelectProduct.Enabled = True
            btnSave.Enabled = True
        End If

    End Sub
End Class
