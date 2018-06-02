Public Class ProductForm
    Public selectedProduct As Integer = 0
    Private selectedCategory As Integer = 0
    Private selectedSubcategory As Integer = 0
    Private Sub saveData()

        Dim prod_id = 0
        Dim db As New DatabaseConnect
        With db
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "INSERT INTO PRODUCTS (barcode,description,status,created_at,updated_at)
        VALUES ('" & txtBarcode.Text & "','" & txtProduct.Text & "',1,'" & DateTime.Now.ToString & "','" & DateTime.Now.ToString & "')"
            .cmd.ExecuteNonQuery()
            .cmd.Dispose()
            .con.Close()
            prod_id = getLatestID("products")

            Dim dbinsertcategory As New DatabaseConnect
            With dbinsertcategory
                .cmd.Connection = .con
                .cmd.CommandType = CommandType.Text
                .cmd.CommandText = "INSERT INTO product_categories (product_id,category_id) VALUES(" & prod_id & "," & selectedCategory & ")"
                .cmd.ExecuteNonQuery()

                .cmd.CommandText = "INSERT INTO product_subcategories (product_id,subcategory_id) VALUES(" & prod_id & "," & selectedSubcategory & ")"
                .cmd.ExecuteNonQuery()
                .cmd.Dispose()
                .con.Close()
            End With

            Dim dbdelete As New DatabaseConnect
            With dbdelete
                .delete_permanent("product_unit", "product_id", prod_id)
                .cmd.Dispose()
                .con.Close()
            End With

            If dgvMeasurement.Rows.Count > 0 Then
                For Each row As DataGridViewRow In dgvMeasurement.Rows
                    Dim barcode As String = row.Cells("barcode").Value
                    Dim brand As String = row.Cells("brand").Value
                    Dim unit As String = row.Cells("unit").Value
                    Dim price As String = row.Cells("price").Value

                    If brand = "" And unit = "" Then
                        Continue For
                    Else
                        Dim dbinsertUnit As New DatabaseConnect
                        With dbinsertUnit
                            dbinsertUnit.cmd.Connection = dbinsertUnit.con
                            dbinsertUnit.cmd.CommandType = CommandType.Text
                            dbinsertUnit.cmd.CommandText = "INSERT INTO product_unit (product_id,brand,unit,barcode,price,created_at,updated_at)VALUES(?,?,?,?,?,?,?)"
                            dbinsertUnit.cmd.Parameters.AddWithValue("@product_id", prod_id)
                            dbinsertUnit.cmd.Parameters.AddWithValue("@brand", brand)
                            dbinsertUnit.cmd.Parameters.AddWithValue("@unit", unit)
                            dbinsertUnit.cmd.Parameters.AddWithValue("@barcode", barcode)
                            dbinsertUnit.cmd.Parameters.AddWithValue("@price", price)
                            dbinsertUnit.cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                            dbinsertUnit.cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                            dbinsertUnit.cmd.ExecuteNonQuery()
                            dbinsertUnit.cmd.Dispose()
                            dbinsertUnit.con.Close()
                        End With
                    End If
                Next
            End If
            MsgBox("Save Successfully!", MsgBoxStyle.Information)
            Me.Close()
        End With

    End Sub

    Private Function getLatestID(ByVal table As String) As Integer
        Dim result As Integer = 0
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("Select MAX(id) from " & table)
            If .dr.HasRows Then
                If .dr.Read Then
                    result = If(IsDBNull(.dr.GetValue(0)), 0, .dr.GetValue(0))
                Else
                    result = 0
                End If
            End If

            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
        Return result
    End Function

    Private Sub updateData()

        '        Dim database As New DatabaseConnect
        '        database.dbConnect()
        '        database.cmd.CommandType = CommandType.Text
        '        database.cmd.CommandText = "UPDATE products SET [name]='" & txtProduct.Text & "',[category]='" & cbCat.Text & "',[brand]='" & txtBrand.Text & "',[unit]='" & cbUnit.Text & "', " & _
        '"[quantity]='" & txtQty.Text & "',[price]='" & txtPrice.Text & "', [updated_at]='" & DateTime.Now.Date & "' WHERE [ID] = " & ProductList.selectedID


        '        database.cmd.Connection = database.con

        '        Try
        '            database.cmd.ExecuteNonQuery()
        '            database.con.Close()
        '            MsgBox("Update Successfully", MsgBoxStyle.Information)
        '        Catch ex As Exception
        '            MsgBox(ex.Message & vbNewLine & database.cmd.CommandText, MsgBoxStyle.Critical)
        '        End Try

        '        'frmCustomerList.populateComboLocation()
        '        ProductList.loadList("")
        '        Me.Close()

    End Sub

    Public Sub populateCategory()
        cbCategory.DataSource = Nothing
        cbCategory.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(0, "Select Category")
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("Select id,name from CATEGORIES where status = 1 and parent_id = 0")
            If .dr.Read Then
                While .dr.Read
                    Dim id As Integer = .dr.GetValue(0)
                    Dim name As String = .dr.GetValue(1)
                    comboSource.Add(id, name)
                End While
                cbCategory.DataSource = New BindingSource(comboSource, Nothing)
                cbCategory.DisplayMember = "Value"
                cbCategory.ValueMember = "Key"
            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Public Sub populateSubcategory(ByVal category As Integer)
        cbSubcategory.DataSource = Nothing
        cbSubcategory.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(0, "Select Subcategory")
        Dim db As New DatabaseConnect
        With db
            If category > 0 Then
                .selectByQuery("Select id,name from CATEGORIES where status = 1 and parent_id = " & category)
            ElseIf category = 0 Then
                .selectByQuery("Select id,name from CATEGORIES where status = 1 and parent_id <> 0 ")
            End If

            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = .dr.GetValue(0)
                    Dim name As String = .dr.GetValue(1)
                    comboSource.Add(id, name)
                End While
            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()

            cbSubcategory.DataSource = New BindingSource(comboSource, Nothing)
            cbSubcategory.DisplayMember = "Value"
            cbSubcategory.ValueMember = "Key"
        End With
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If btnSave.Text = "Save" Then
            If validation() = False Then

                Exit Sub
            End If
            saveData()
            ProductList.loadList("")
        ElseIf btnSave.Text = "Update" Then
            updateData()
        End If

    End Sub

    Function validation() As Boolean
        Dim res As Boolean = False

        Dim dbvalidate As New DatabaseConnect
        With dbvalidate
            If (.isExist("products", "description", txtProduct.Text)) Then
                res = False
                MsgBox("Product description already exist!", MsgBoxStyle.Critical)
            Else
                res = True
            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With

        Return res
    End Function

    Private Sub ProductForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub

    Public Sub initializeMeasure()

        If dgvMeasurement.Rows.Count = 1 Then
            Try
                Dim dtgCol As DataGridViewComboBoxCell
                dgvMeasurement.Rows(0).Cells(0).Value = ""
                dtgCol = dgvMeasurement.Rows(0).Cells(1)

                Dim comboSource As New Dictionary(Of String, String)()
                'comboSource.Add(0, "Select Brand")
                Dim dbbrand As New DatabaseConnect
                With dbbrand
                    .selectByQuery("Select id,name from brand where status = 1")
                    If .dr.HasRows Then
                        While .dr.Read
                            comboSource.Add(.dr.GetValue(0), .dr.GetValue(1))
                        End While
                    End If
                    .cmd.Dispose()
                    .dr.Close()
                    .con.Close()
                    dtgCol.DataSource = New BindingSource(comboSource, Nothing)
                    dtgCol.DisplayMember = "Value"
                    dtgCol.ValueMember = "Key"
                End With

                Dim comboSourceUnit As New Dictionary(Of String, String)()
                dtgCol = dgvMeasurement.Rows(0).Cells(2)

                Dim dbUnit As New DatabaseConnect
                With dbUnit
                    .selectByQuery("Select id,name from unit where status = 1")
                    If .dr.HasRows Then
                        While .dr.Read
                            comboSourceUnit.Add(.dr.GetValue(0), .dr.GetValue(1))

                        End While
                    End If
                    dtgCol.DataSource = New BindingSource(comboSourceUnit, Nothing)
                    dtgCol.DisplayMember = "Value"
                    dtgCol.ValueMember = "Key"
                End With

                dgvMeasurement.Rows(0).Cells(3).Value = "0.00"
                dgvMeasurement.Rows(0).Cells(4).Value = "Remove -"
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub cbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCategory.SelectedIndexChanged

        If cbCategory.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbCategory.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbCategory.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedCategory = CInt(key)
            populateSubcategory(selectedCategory)

        ElseIf cbCategory.SelectedIndex = 0 Then
            populateSubcategory(0)
        End If

    End Sub

    Private Sub cbSubcategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSubcategory.SelectedIndexChanged
        If cbSubcategory.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbSubcategory.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbSubcategory.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedSubcategory = CInt(key)
        End If
    End Sub

    Private Sub btnAddMoreUnit_Click(sxxender As Object, e As EventArgs) Handles btnAddMoreUnit.Click
        dgvMeasurement.Rows.Add(1)
    End Sub

    Private Sub dgvMeasurement_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMeasurement.CellClick
        '// **  remove column function ** //
        If (e.RowIndex = dgvMeasurement.NewRowIndex Or e.RowIndex < 0) Then
            Exit Sub
        End If

        'Check if click Is on specific column 
        If (e.ColumnIndex = dgvMeasurement.Columns("remove_column").Index) Then
            dgvMeasurement.Rows.RemoveAt(e.RowIndex)
        End If

    End Sub

    Private Sub dgvMeasurement_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvMeasurement.RowsAdded


        If dgvMeasurement.Rows.Count <> 1 Then
            Try
                Dim dtgCol As DataGridViewComboBoxCell
                Dim comboColumn As New DataGridViewComboBoxColumn

                dgvMeasurement.Rows(e.RowIndex).Cells(0).Value = ""
                dtgCol = dgvMeasurement.Rows(e.RowIndex).Cells(1)

                comboColumn = dgvMeasurement.Columns("brand")
                Dim comboSource As New Dictionary(Of String, String)()

                Dim dbbrand As New DatabaseConnect
                With dbbrand
                    .selectByQuery("Select id,name from brand where status = 1")
                    If .dr.HasRows Then
                        While .dr.Read
                            comboSource.Add(.dr.GetValue(0), .dr.GetValue(1))

                        End While
                    End If
                    .cmd.Dispose()
                    .dr.Close()
                    .con.Close()
                    'dtgCol.DataSource = New BindingSource(comboSource, Nothing)
                    'dtgCol.DisplayMember = "Value"
                    'dtgCol.ValueMember = "Key"
                    comboColumn.DataSource = New BindingSource(comboSource, Nothing)
                    comboColumn.DisplayMember = "Value"
                    comboColumn.ValueMember = "Key"


                End With

                Dim comboSourceUnit As New Dictionary(Of String, String)()
                dtgCol = dgvMeasurement.Rows(e.RowIndex).Cells(2)
                Dim dbUnit As New DatabaseConnect
                With dbUnit
                    .selectByQuery("Select id,name from unit where status = 1")
                    If .dr.HasRows Then
                        While .dr.Read
                            comboSourceUnit.Add(.dr.GetValue(0), .dr.GetValue(1))
                        End While
                    End If
                    dtgCol.DataSource = New BindingSource(comboSourceUnit, Nothing)
                    dtgCol.DisplayMember = "Value"
                    dtgCol.ValueMember = "Key"
                End With
                dgvMeasurement.Rows(e.RowIndex).Cells(4).Value = "Remove -"
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Public Sub toUpdateInfo(ByVal id As Integer)
        If id > 0 Then
            selectedProduct = id
            Dim dbproduct As New DatabaseConnect
            With dbproduct
                .selectByQuery("Select id,barcode,description from products where status = 1 and id = " & id)
                If .dr.HasRows Then
                    If .dr.Read Then
                        txtBarcode.Text = .dr.GetValue(1)
                        txtProduct.Text = .dr.GetValue(2)

                        Dim dbcategory As New DatabaseConnect
                        With dbcategory
                            .selectByQuery("SELECT c.id,c.name from product_categories as pc INNER JOIN categories as c on c.id = pc.category_id where pc.product_id = " & id)
                            If .dr.HasRows Then
                                If .dr.Read Then
                                    Dim catid As String = .dr.GetValue(0)
                                    Dim name As String = .dr.GetValue(1)
                                    cbCategory.SelectedIndex = cbCategory.FindStringExact(name)
                                End If
                            End If
                            .cmd.Dispose()
                            .dr.Close()
                            .con.Close()
                        End With

                        Dim dbsub As New DatabaseConnect
                        With dbsub
                            .selectByQuery("SELECT c.id,c.name from product_subcategories as pc INNER JOIN categories as c on c.id = pc.subcategory_id where pc.product_id = " & id)
                            If .dr.HasRows Then
                                If .dr.Read Then
                                    Dim catid As String = .dr.GetValue(0)
                                    Dim name As String = .dr.GetValue(1)
                                    cbSubcategory.SelectedIndex = cbSubcategory.FindStringExact(name)
                                End If
                            End If
                            .cmd.Dispose()
                            .dr.Close()
                            .con.Close()
                        End With
                    End If
                End If
                .cmd.Dispose()
                .dr.Close()
                .con.Close()
            End With

            Dim measure As New DatabaseConnect
            With measure
                dgvMeasurement.Rows.Clear()
                .selectByQuery("select pu.barcode,b.name as brand, u.name as unit, pu.price from ((product_unit as pu 
                                INNER JOIN brand as b ON b.id = pu.brand) 
                                INNER JOIN unit as u ON u.id = pu.unit)
                                where pu.product_id = " & id)
                If .dr.HasRows Then
                    While .dr.Read
                        Dim barcode As String = .dr.GetValue(0)
                        Dim brand As String = .dr.GetValue(1)
                        Dim unit As String = .dr.GetValue(2)
                        Dim price As String = .dr.GetValue(3)

                        dgvMeasurement.Rows.Add(1)
                        dgvMeasurement.Rows(dgvMeasurement.Rows.Count - 2).Cells(0).Value = barcode

                        Dim dtgCol As DataGridViewComboBoxCell
                        dtgCol = dgvMeasurement.Rows(dgvMeasurement.Rows.Count - 2).Cells(1)

                        'Dim comboSource As New Dictionary(Of String, String)()
                        ''comboSource.Add(0, "Select Brand")
                        'Dim dbbrand As New DatabaseConnect
                        'With dbbrand
                        '    .selectByQuery("Select id,name from brand where status = 1")
                        '    If .dr.HasRows Then
                        '        While .dr.Read
                        '            comboSource.Add(.dr.GetValue(0), .dr.GetValue(1))
                        '        End While
                        '    End If
                        '    .cmd.Dispose()
                        '    .dr.Close()
                        '    .con.Close()
                        '    dtgCol.DataSource = New BindingSource(comboSource, Nothing)
                        '    dtgCol.DisplayMember = "Value"
                        '    dtgCol.ValueMember = "Key"
                        'End With
                        dgvMeasurement.Rows(dgvMeasurement.Rows.Count - 2).Cells(3).Value = price
                    End While
                End If
                .cmd.Dispose()
                .dr.Close()
                .con.Close()
            End With


        End If
    End Sub

End Class