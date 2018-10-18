Public Class SearchSupplierProducts
    Public selectedSupplier As Integer = 0
    Private Sub SearchSupplierProducts_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub loadList(ByVal q As String)
        Dim db As New DatabaseConnect
        With db
            dgvProducts.Rows.Clear()
            If q = "" Then

                If q = "" Then
                    .selectByQuery("Select distinct pu.id, pu.barcode,p.description,b.name as brand, u.name as unit,cc.name as color,pu.price,c.name as cat, subc.name as subcat from ((((((((product_unit as pu     
                    LEFT JOIN brand as b on b.id = pu.brand)
                    INNER JOIN unit as u on u.id = pu.unit)
                    LEFT JOIN color as cc ON cc.id = pu.color)
                    INNER JOIN products as p ON p.id = pu.product_id)
                    LEFT JOIN product_categories as pc ON pc.product_id = pu.product_id) 
                    LEFT JOIN product_subcategories as psc ON psc.product_id = pu.product_id)
                    LEFT JOIN categories as c ON c.id = pc.category_id)
                    LEFT JOIN categories as subc ON subc.id = psc.subcategory_id)
                    where pu.status = 1 order by p.description")
                Else
                    .selectByQuery(q)
                End If

            Else

            End If

            If .dr.HasRows Then
                While .dr.Read

                    Dim id As String = .dr("id")
                    Dim barcode As String = .dr("barcode")
                    Dim desc As String = .dr("description")
                    Dim brand As String = If(IsDBNull(.dr("brand")), "", .dr("brand"))
                    Dim unit As String = .dr("unit")
                    Dim color As String = If(IsDBNull(.dr("color")), "", .dr("color"))
                    Dim price As String = Val(.dr("price")).ToString("N2")
                    'Dim sell_price As String = Val(.dr("sell_price")).ToString("N2")
                    Dim cat As String = If(IsDBNull(.dr("cat")), "", .dr("cat"))
                    Dim subcat As String = If(IsDBNull(.dr("subcat")), "", .dr("subcat"))

                    Dim cmd2 As New System.Data.OleDb.OleDbCommand
                    Dim dr2 As System.Data.OleDb.OleDbDataReader
                    cmd2.Connection = .con
                    cmd2.CommandType = CommandType.Text
                    cmd2.CommandText = "Select * from product_suppliers where product_unit_id = " & id & " and supplier = " & selectedSupplier
                    dr2 = cmd2.ExecuteReader

                    If Not dr2.Read Then
                        Dim row As String() = New String() {id, True, barcode, desc, brand, unit, color, price}
                        dgvProducts.Rows.Add(row)
                    End If
                    dr2.Close()
                    cmd2.Dispose()
                End While
            Else
                MsgBox("No product found!", MsgBoxStyle.Critical)
            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Private Sub ckSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles ckSelectAll.CheckedChanged
        If ckSelectAll.Checked Then
            For Each item As DataGridViewRow In Me.dgvProducts.Rows
                If dgvProducts.Rows(item.Index).Cells(3).Value <> "" Then
                    dgvProducts.Rows(item.Index).Cells(1).Value = True
                End If
            Next
        Else
            For Each item As DataGridViewRow In Me.dgvProducts.Rows
                If dgvProducts.Rows(item.Index).Cells(3).Value <> "" Then
                    dgvProducts.Rows(item.Index).Cells(1).Value = False
                End If
            Next
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If dgvProducts.Rows.Count > 0 Then
            For Each item As DataGridViewRow In Me.dgvProducts.Rows

                If dgvProducts.Rows(item.Index).Cells(1).Value = True Then
                    Dim product_unit_id As String = dgvProducts.Rows(item.Index).Cells("column_id").Value
                    Dim barcode As String = dgvProducts.Rows(item.Index).Cells("column_barcode").Value
                    Dim desc As String = dgvProducts.Rows(item.Index).Cells("column_description").Value
                    Dim brand As String = dgvProducts.Rows(item.Index).Cells("column_brand").Value
                    Dim unit As String = dgvProducts.Rows(item.Index).Cells("column_unit").Value
                    Dim color As String = dgvProducts.Rows(item.Index).Cells("column_color").Value
                    Dim price As String = dgvProducts.Rows(item.Index).Cells("column_unit_price").Value

                    ' check if already in list
                    Dim inlist As Boolean = False
                    For Each item2 As DataGridViewRow In SupplierProducts.dgvProd.Rows
                        If SupplierProducts.dgvProd.Rows(item2.Index).Cells(2).Value <> "" Then
                            Dim p_u_id As String = SupplierProducts.dgvProd.Rows(item2.Index).Cells("id").Value
                            If p_u_id = product_unit_id Then
                                inlist = True
                                Exit For
                            End If
                        End If
                    Next

                    If inlist = False Then
                        Dim row As String() = New String() {product_unit_id, barcode, desc, brand, unit, color, "0.00", "Remove"}
                        SupplierProducts.dgvProd.Rows.Add(row)
                    End If
                End If

            Next
        End If
        Me.Close()
    End Sub
End Class