Public Class ProductList

    Public selectedID As String

    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ProductForm.ShowDialog()
    End Sub

    Private Sub ProductList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadList("")
        populateCategory()

    End Sub

    Public Sub populateCategory()

        'Dim database As New DatabaseConnect
        'database.dbConnect()
        'database.cmd.CommandType = CommandType.Text
        'database.cmd.CommandText = "SELECT category FROM products where status = 1"
        'database.cmd.Connection = database.con

        'Try
        '    database.dr = database.cmd.ExecuteReader

        '    If database.dr.HasRows Then
        '        cbCat.Items.Clear()
        '        cbCat.Items.Add("All")
        '        While database.dr.Read
        '            Dim arr(1) As String
        '            Dim category As String = database.dr.GetValue(0)

        '            arr(0) = category
        '            cbCat.Items.Add(category)

        '        End While

        '    End If

        '    database.con.Close()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Public Sub loadList(ByVal q As String)
        Dim db As New DatabaseConnect
        With db
            dgvProducts.Rows.Clear()
            If q = "" Then
                .selectByQuery("Select distinct p.id,pu.barcode, p.description,b.name as brand, u.name as unit,pu.price,c.name,sub.name FROM (((((((products as p 
                INNER JOIN product_unit as pu ON p.id = pu.product_id) 
                LEFT JOIN brand as b ON b.id = pu.brand)
                INNER JOIN unit as u ON u.id = pu.unit)
                INNER JOIN product_categories as pc ON pc.product_id = p.id) 
                LEFT JOIN product_subcategories as psc ON psc.product_id = p.id)
                LEFT JOIN categories as c ON c.id = pc.category_id)
                LEFT JOIN categories as sub ON sub.id = psc.subcategory_id)  where p.status = 1")

            End If

            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr.GetValue(0)
                    Dim barcode As String = .dr.GetValue(1)
                    Dim desc As String = .dr.GetValue(2)
                    Dim brand As String = .dr.GetValue(3)
                    Dim unit As String = .dr.GetValue(4)
                    Dim price As String = .dr.GetValue(5)
                    Dim cat As String = .dr.GetValue(6)
                    Dim subcat As String = If(IsDBNull(.dr.GetValue(7)), "", .dr.GetValue(7))
                    Dim row As String() = New String() {id, barcode, desc, brand, unit, price, "", cat, subcat}
                    dgvProducts.Rows.Add(row)
                End While
            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub


    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)




    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        ProductForm.btnSave.Text = "Save"
        ProductForm.initializeMeasure()
        ProductForm.selectedProduct = 0
        ProductForm.populateCategory()
        ProductForm.populateSubcategory(0)
        ProductForm.ShowDialog()

    End Sub

    Private Sub dgvProducts_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProducts.CellValueChanged

        If dgvProducts.Rows.Count > 1 Then
            Dim product_id As String = dgvProducts.Rows(e.RowIndex).Cells(0).Value
            If e.ColumnIndex = 3 Then
                Dim brand As String = If(dgvProducts.Rows(e.RowIndex).Cells(3).Value = "", "0", dgvProducts.Rows(e.RowIndex).Cells(3).Value)
                Dim unit As String = If(dgvProducts.Rows(e.RowIndex).Cells(4).Value = "", "0", dgvProducts.Rows(e.RowIndex).Cells(4).Value)

                Dim dbPrice As New DatabaseConnect
                With dbPrice
                    .selectByQuery("Select price from product_unit where product_id = " & product_id & " and brand =" & brand & " and unit = " & unit)
                    If .dr.HasRows Then
                        If .dr.Read Then
                            dgvProducts.Rows(e.RowIndex).Cells(5).Value = .dr.GetValue(0)
                        End If
                    End If
                    .dr.Close()
                    .cmd.Dispose()
                    .con.Close()
                End With
            End If

            If e.ColumnIndex = 4 Then
                Dim brand As String = If(dgvProducts.Rows(e.RowIndex).Cells(3).Value = "", "0", dgvProducts.Rows(e.RowIndex).Cells(3).Value)
                Dim unit As String = If(dgvProducts.Rows(e.RowIndex).Cells(4).Value = "", "0", dgvProducts.Rows(e.RowIndex).Cells(4).Value)

                Dim dbPrice As New DatabaseConnect
                With dbPrice
                    .selectByQuery("Select price from product_unit where product_id = " & product_id & " and brand =" & brand & " and unit = " & unit)

                    If .dr.HasRows Then
                        If .dr.Read Then
                            dgvProducts.Rows(e.RowIndex).Cells(5).Value = .dr.GetValue(0)
                        End If
                    End If

                    .dr.Close()
                    .cmd.Dispose()
                    .con.Close()
                End With
            End If
        End If

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvProducts.SelectedRows.Count = 1 Then
            Dim product_id As Integer = CInt(dgvProducts.SelectedRows(0).Cells(0).Value)
            ProductForm.btnSave.Text = "Update"
            ProductForm.populateCategory()
            ProductForm.populateSubcategory(0)
            ProductForm.toUpdateInfo(product_id)
            ProductForm.ShowDialog()
        Else
            MsgBox("Please select one record!", MsgBoxStyle.Critical)
        End If
    End Sub
End Class