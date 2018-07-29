Public Class ProductForm
    Public selectedProduct As Integer = 0
    Public selectedCategory As Integer = 0
    Public selectedSubcategory As Integer = 0
    Public selectedColor As Integer = 0
    Private Sub saveData()
        Dim prod_id = 0
        Dim db As New DatabaseConnect
        With db
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "INSERT INTO PRODUCTS (description,status,created_at,updated_at)
        VALUES ('" & txtProduct.Text & "',1,'" & DateTime.Now.ToString & "','" & DateTime.Now.ToString & "')"
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

            'Dim dbdelete As New DatabaseConnect
            'With dbdelete
            '    .delete_permanent("product_unit", "product_id", prod_id)
            '    .cmd.Dispose()
            '    .con.Close()
            'End With

            If dgvMeasure.Rows.Count > 0 Then
                For Each row As DataGridViewRow In dgvMeasure.Rows
                    If row.Cells("unit").Value <> "" Then
                        Dim barcode As String = row.Cells("barcode").Value
                        Dim brand As Integer = If(row.Cells("brand").Value = "No Brand", 0, New DatabaseConnect().get_id("brand", "name", row.Cells("brand").Value))
                        Dim unit As Integer = New DatabaseConnect().get_id("unit", "name", row.Cells("unit").Value)
                        Dim color As Integer = If(row.Cells("color").Value = "No Color", 0, New DatabaseConnect().get_id("color", "name", row.Cells("color").Value))
                        Dim price As String = row.Cells("price").Value
                        Dim dbinsertUnit As New DatabaseConnect
                        With dbinsertUnit
                            dbinsertUnit.cmd.Connection = dbinsertUnit.con
                            dbinsertUnit.cmd.CommandType = CommandType.Text
                            dbinsertUnit.cmd.CommandText = "INSERT INTO product_unit (product_id,brand,unit,color,barcode,price,status,created_at,updated_at)VALUES(?,?,?,?,?,?,?,?,?)"
                            dbinsertUnit.cmd.Parameters.AddWithValue("@product_id", prod_id)
                            dbinsertUnit.cmd.Parameters.AddWithValue("@brand", brand)
                            dbinsertUnit.cmd.Parameters.AddWithValue("@unit", unit)
                            dbinsertUnit.cmd.Parameters.AddWithValue("@color", color)
                            dbinsertUnit.cmd.Parameters.AddWithValue("@barcode", barcode)
                            dbinsertUnit.cmd.Parameters.AddWithValue("@price", price)
                            dbinsertUnit.cmd.Parameters.AddWithValue("@status", 1)
                            dbinsertUnit.cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                            dbinsertUnit.cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                            dbinsertUnit.cmd.ExecuteNonQuery()
                            dbinsertUnit.cmd.Dispose()
                            dbinsertUnit.con.Close()
                        End With

                        'insert stock
                        Dim p_u_id As Integer = New DatabaseConnect().getLastID("product_unit")
                        Dim insertstock As New DatabaseConnect
                        With insertstock
                            .cmd.Connection = .con
                            .cmd.CommandType = CommandType.Text
                            .cmd.CommandText = "INSERT INTO product_stocks (product_unit_id,qty,created_at,updated_at)VALUES(?,?,?,?)"
                            .cmd.Parameters.AddWithValue("@product_unit_id", p_u_id)
                            .cmd.Parameters.AddWithValue("@qty", 0)
                            .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                            .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                            .cmd.ExecuteNonQuery()
                            .cmd.Dispose()
                            .con.Close()

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
        Dim dbupdate As New DatabaseConnect
        With dbupdate
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "Update products set description=?,updated_at=? where id = " & selectedProduct
            .cmd.Parameters.AddWithValue("@description", txtProduct.Text)
            .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
            .cmd.ExecuteNonQuery()

            .update_where("product_unit", "product_id", selectedProduct, "status", 0)
            Dim cmd2 As New System.Data.OleDb.OleDbCommand
            cmd2.Connection = .con
            cmd2.CommandType = CommandType.Text
            For Each item As DataGridViewRow In Me.dgvMeasure.Rows
                Dim id As String = dgvMeasure.Rows(item.Index).Cells("id").Value
                Dim barcode As String = dgvMeasure.Rows(item.Index).Cells("barcode").Value
                Dim brand As Integer = New DatabaseConnect().get_id("brand", "name", dgvMeasure.Rows(item.Index).Cells("brand").Value)
                Dim unit As Integer = New DatabaseConnect().get_id("unit", "name", dgvMeasure.Rows(item.Index).Cells("unit").Value)
                Dim color As Integer = New DatabaseConnect().get_id("color", "name", dgvMeasure.Rows(item.Index).Cells("color").Value)
                Dim price As String = dgvMeasure.Rows(item.Index).Cells("price").Value

                If (Not String.IsNullOrEmpty(dgvMeasure.Rows(item.Index).Cells("unit").Value)) Then
                    cmd2.CommandText = "UPDATE product_unit set brand = ?, unit = ? , color= ?, barcode = ? , price = ?,status = ?, updated_at = ?
                    where id = " & id
                    cmd2.Parameters.AddWithValue("@brand", brand)
                    cmd2.Parameters.AddWithValue("@unit", unit)
                    cmd2.Parameters.AddWithValue("@color", color)
                    cmd2.Parameters.AddWithValue("@barcode", barcode)
                    cmd2.Parameters.AddWithValue("@price", price)
                    cmd2.Parameters.AddWithValue("@status", 1)

                    cmd2.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                    cmd2.ExecuteNonQuery()
                    cmd2.Parameters.Clear()
                End If
            Next
            cmd2.Dispose()
            .cmd.Dispose()
            .con.Close()
            MsgBox("Product Successfully Update.", MsgBoxStyle.Information)
            clearFields()
            Me.Close()
            ProductList.loadList("")
        End With

        '        Dim database As New DatabaseConnect
        '        database.dbConnect()
        '        database.cmd.CommandType = CommandType.Text
        '        database.cmd.CommandText = "UPDATE products Set [name]='" & txtProduct.Text & "',[category]='" & cbCat.Text & "',[brand]='" & txtBrand.Text & "',[unit]='" & cbUnit.Text & "', " & _
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
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = .dr.GetValue(0)
                    Dim name As String = .dr.GetValue(1)
                    comboSource.Add(id, name)
                End While
            End If
            cbCategory.DataSource = New BindingSource(comboSource, Nothing)
            cbCategory.DisplayMember = "Value"
            cbCategory.ValueMember = "Key"
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
            Dim dbvalidate As New DatabaseConnect
            With dbvalidate
                If (.isExist("products", "description", txtProduct.Text)) Then

                    MsgBox("Product description already exist!", MsgBoxStyle.Critical)
                    txtProduct.Focus()
                    Exit Sub
                End If
                .dr.Close()
                .cmd.Dispose()
                .con.Close()
            End With
            If validation() = False Then
                Exit Sub
            End If
            saveData()
            ProductList.loadList("")
        ElseIf btnSave.Text = "Update" Then
            If validation() = False Then
                Exit Sub
            End If
            updateData()
        End If

    End Sub

    Function validation() As Boolean
        Dim res As Boolean = True

        If Trim(txtProduct.Text) = "" Then
            res = False
            MsgBox("Product description field is required!", MsgBoxStyle.Critical)
            txtProduct.Focus()
            Return res
        End If

        'If selectedCategory = 0 Then
        '    res = False
        '    MsgBox("Category field is required!", MsgBoxStyle.Critical)
        '    cbCategory.Focus()
        '    Return res
        'End If

        'If selectedSubcategory = 0 Then
        '    res = False
        '    MsgBox("Sub Category field is required!", MsgBoxStyle.Critical)
        '    cbCategory.Focus()
        '    Return res
        'End If

        If dgvMeasure.Rows.Count = 0 Or dgvMeasure.Rows.Count = 1 Then
            res = False
            MsgBox("Please add measurement for this product!", MsgBoxStyle.Critical)
            dgvMeasure.Focus()
            Return res
        End If
        Return res
    End Function

    Private Sub cbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCategory.SelectedIndexChanged
        If cbCategory.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbCategory.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbCategory.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedCategory = CInt(key)
            populateSubcategory(selectedCategory)

        ElseIf cbCategory.SelectedIndex = 0 Then
            selectedCategory = 0
            populateSubcategory(0)
        End If
    End Sub

    Private Sub cbSubcategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSubcategory.SelectedIndexChanged
        If cbSubcategory.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbSubcategory.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbSubcategory.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedSubcategory = CInt(key)
        Else
            selectedSubcategory = 0
        End If
    End Sub

    Private Sub btnAddMoreUnit_Click(sender As Object, e As EventArgs) Handles btnAddMoreUnit.Click
        ProductAddUnitForm.btnAdd.Text = "Add(+)"
        ProductAddUnitForm.loadBrand()
        ProductAddUnitForm.loadUnit()
        ProductAddUnitForm.loadColor()
        ProductAddUnitForm.resetFields()
        ProductAddUnitForm.ShowDialog()
    End Sub

    Public Sub toUpdateInfo(ByVal id As Integer)
        If id > 0 Then
            selectedProduct = id
            Dim dbproduct As New DatabaseConnect
            With dbproduct
                .selectByQuery("Select id,description from products where status = 1 and id = " & id)
                If .dr.HasRows Then
                    If .dr.Read Then
                        txtProduct.Text = .dr("description")

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
                dgvMeasure.Rows.Clear()
                .selectByQuery("select pu.id,pu.barcode,b.name as brand, u.name as unit,c.name as color, pu.price from (((product_unit as pu 
                                INNER JOIN brand as b ON b.id = pu.brand) 
                                INNER JOIN unit as u ON u.id = pu.unit)
                                INNER JOIN color as c ON c.id = pu.color)
                                where pu.product_id = " & id & " and pu.status <> 0")
                If .dr.HasRows Then
                    While .dr.Read
                        Dim pu_id As String = .dr("id")
                        Dim barcode As String = .dr("barcode")
                        Dim brand As String = .dr("brand")
                        Dim unit As String = .dr("unit")
                        Dim color As String = .dr("color")
                        Dim price As String = .dr("price")

                        dgvMeasure.Rows.Add(1)
                        dgvMeasure.Rows(dgvMeasure.Rows.Count - 2).Cells(0).Value = pu_id
                        dgvMeasure.Rows(dgvMeasure.Rows.Count - 2).Cells(1).Value = barcode
                        dgvMeasure.Rows(dgvMeasure.Rows.Count - 2).Cells(2).Value = brand
                        dgvMeasure.Rows(dgvMeasure.Rows.Count - 2).Cells(3).Value = unit
                        dgvMeasure.Rows(dgvMeasure.Rows.Count - 2).Cells(4).Value = color
                        dgvMeasure.Rows(dgvMeasure.Rows.Count - 2).Cells(5).Value = Val(price).ToString("N2")
                        dgvMeasure.Rows(dgvMeasure.Rows.Count - 2).Cells(6).Value = "Remove"
                    End While
                End If
                .cmd.Dispose()
                .dr.Close()
                .con.Close()
            End With

        End If
    End Sub

    Private Sub btnEditUnit_Click(sender As Object, e As EventArgs) Handles btnEditUnit.Click
        If dgvMeasure.Rows.Count = 1 Then
            MsgBox("No measurement list found", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If dgvMeasure.SelectedRows.Count = 1 Then

            ProductAddUnitForm.loadBrand()
            ProductAddUnitForm.loadUnit()
            ProductAddUnitForm.btnAdd.Text = "Edit(->)"
            ProductAddUnitForm.txtBarcode.Text = dgvMeasure.SelectedRows(0).Cells("barcode").Value
            ProductAddUnitForm.cbBrand.SelectedIndex = ProductAddUnitForm.cbBrand.FindString(dgvMeasure.SelectedRows(0).Cells("brand").Value)
            ProductAddUnitForm.cbUnit.SelectedIndex = ProductAddUnitForm.cbUnit.FindString(dgvMeasure.SelectedRows(0).Cells("unit").Value)
            ProductAddUnitForm.txtPrice.Text = dgvMeasure.SelectedRows(0).Cells("price").Value
            ProductAddUnitForm.ShowDialog()
        Else
            MsgBox("Please select unit of measurement!", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub dgvMeasure_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMeasure.CellContentClick
        '// **  remove column function ** //
        If (e.RowIndex = dgvMeasure.NewRowIndex Or e.RowIndex < 0) Then
            Exit Sub
        End If

        'Check if click Is on specific column 
        If (e.ColumnIndex = dgvMeasure.Columns("col_remove").Index) Then
            dgvMeasure.Rows.RemoveAt(e.RowIndex)
        End If
    End Sub

    Private Sub txtProduct_MouseLeave(sender As Object, e As EventArgs) Handles txtProduct.MouseLeave
        If Trim(txtProduct.Text).Length > 0 Then
            txtProduct.Text = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtProduct.Text.ToLower)
        End If
    End Sub

    Public Sub clearFields()
        txtProduct.Clear()

        selectedCategory = 0
        If cbCategory.Items.Count > 0 Then
            cbCategory.SelectedIndex = 0
        End If

        selectedSubcategory = 0
        If cbSubcategory.Items.Count > 0 Then
            cbSubcategory.SelectedIndex = 0
        End If

        dgvMeasure.Rows.Clear()
    End Sub

    Private Sub btnAddCategory_Click(sender As Object, e As EventArgs) Handles btnAddCategory.Click
        CategoryForm.selectedParent = 0
        CategoryForm.txtName.Text = ""
        CategoryForm.cbParent.Enabled = False
        CategoryForm.btnSave.Text = "Save"
        CategoryForm.ShowDialog()
    End Sub

    Private Sub btnSubCat_Click(sender As Object, e As EventArgs) Handles btnSubCat.Click
        'validation
        If selectedCategory <= 0 Then
            MsgBox("Please select Category before you add Sub Category", MsgBoxStyle.Critical)
            cbCategory.Focus()
            Exit Sub
        End If

        CategoryForm.selectedParent = selectedCategory
        CategoryForm.SelectedID = 0
        CategoryForm.populateCategory()
        CategoryForm.cbParent.SelectedIndex = CategoryForm.cbParent.FindString(cbCategory.Text)
        CategoryForm.txtName.Text = ""
        CategoryForm.cbParent.Enabled = False
        CategoryForm.btnSave.Text = "Save"
        CategoryForm.ShowDialog()
    End Sub



    Private Sub btnAddColor_Click(sender As Object, e As EventArgs)
        ColorForm.selectedColor = 0
        ColorForm.ShowDialog()
    End Sub
End Class