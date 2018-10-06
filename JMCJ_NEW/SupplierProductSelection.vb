Public Class SupplierProductSelection
    Public module_selection As Integer = 0
    Private Sub SupplierProductSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub loadSupplierProducts(ByVal supplier As Integer)
        dgvProducts.Rows.Clear()
        Dim db As New DatabaseConnect
        With db
            Dim query As String = "Select distinct p.id,pu.id as p_u_id,pu.barcode, p.description,b.name as brand, u.name as unit,cc.name as color,pu.price,c.name as cat,sub.name as subcat FROM (((((((((products as p 
                INNER JOIN product_unit as pu ON p.id = pu.product_id) 
                LEFT JOIN brand as b ON b.id = pu.brand)
                INNER JOIN unit as u ON u.id = pu.unit)
                LEFT JOIN color as cc ON cc.id = pu.color)
                INNER JOIN product_categories as pc ON pc.product_id = p.id) 
                LEFT JOIN product_subcategories as psc ON psc.product_id = p.id)
                LEFT JOIN categories as c ON c.id = pc.category_id)
                LEFT JOIN product_suppliers as ps on ps.product_unit_id = pu.id)
                LEFT JOIN categories as sub ON sub.id = psc.subcategory_id)  where pu.status <> 0 and p.status <> 0 and ps.supplier = " & supplier & " order by p.description"


            .selectByQuery(query)

            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr("id")
                    Dim p_u_id As String = .dr("p_u_id")
                    Dim barcode As String = .dr("barcode")
                    Dim desc As String = .dr("description")
                    Dim brand As String = .dr("brand")
                    Dim unit As String = .dr("unit")
                    Dim color As String = If(IsDBNull(.dr("color")), "", .dr("color"))
                    Dim price As String = Val(.dr("price")).ToString("N2")
                    Dim cost As String = Val(getCost(supplier, p_u_id)).ToString("N2")

                    Dim stock As String = ""
                    Try
                        Dim dbstock As New DatabaseConnect
                        With dbstock
                            .selectByQuery("select qty from product_stocks where product_unit_id = " & p_u_id)
                            If .dr.Read Then
                                stock = Val(.dr("qty")).ToString
                            Else
                                stock = ""
                            End If
                            .cmd.Dispose()
                            .dr.Close()
                            .con.Close()
                        End With
                    Catch ex As Exception
                        stock = ""
                    End Try

                    Dim cat As String = If(IsDBNull(.dr("cat")), "", .dr("cat"))
                    Dim subcat As String = If(IsDBNull(.dr("subcat")), "", .dr("subcat"))
                    Dim row As String() = New String() {p_u_id, True, barcode, desc, brand, unit, color, cost, stock, cat, subcat}
                    dgvProducts.Rows.Add(row)
                End While
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

    Private Sub btnAddToOrder_Click(sender As Object, e As EventArgs) Handles btnAddToOrder.Click
        For Each item As DataGridViewRow In Me.dgvProducts.Rows
            If dgvProducts.Rows(item.Index).Cells(3).Value <> "" And dgvProducts.Rows(item.Index).Cells(1).Value = True Then
                Dim product_unit_id As String = dgvProducts.Rows(item.Index).Cells("column_id").Value
                Dim barcode As String = dgvProducts.Rows(item.Index).Cells("column_barcode").Value
                Dim desc As String = dgvProducts.Rows(item.Index).Cells("column_description").Value
                Dim brand As String = dgvProducts.Rows(item.Index).Cells("column_brand").Value
                Dim unit As String = dgvProducts.Rows(item.Index).Cells("column_unit").Value
                Dim color As String = dgvProducts.Rows(item.Index).Cells("column_color").Value
                Dim unitcost As String = dgvProducts.Rows(item.Index).Cells("column_cost").Value
                Dim stock As String = dgvProducts.Rows(item.Index).Cells("column_stock").Value


                Select Case module_selection
                    ' from purchase Order
                    Case 1
                        ' check if existing
                        Dim inlist As Boolean = False
                        For Each item2 As DataGridViewRow In PurchaseOrderForm.dgvProd.Rows
                            If PurchaseOrderForm.dgvProd.Rows(item2.Index).Cells(3).Value <> "" Then
                                Dim p_u_id As String = PurchaseOrderForm.dgvProd.Rows(item2.Index).Cells("id").Value
                                If p_u_id = product_unit_id Then
                                    inlist = True
                                    Exit For
                                End If
                            End If
                        Next

                        If inlist = False Then
                            Dim row As String() = New String() {product_unit_id, barcode, "0", desc, brand, unit, color, unitcost, "0.00", stock, "Remove"}
                            PurchaseOrderForm.dgvProd.Rows.Add(row)
                        End If
                    ' from purchase receive
                    Case 2
                        ' check if existing
                        Dim inlist As Boolean = False
                        For Each item2 As DataGridViewRow In PurchaseReceiveForm.dgvProd.Rows
                            If PurchaseReceiveForm.dgvProd.Rows(item2.Index).Cells(3).Value <> "" Then
                                Dim p_u_id As String = PurchaseReceiveForm.dgvProd.Rows(item2.Index).Cells("id").Value
                                If p_u_id = product_unit_id Then
                                    inlist = True
                                    Exit For
                                End If
                            End If
                        Next

                        If inlist = False Then
                            Dim row As String() = New String() {product_unit_id, barcode, "0", desc, brand, unit, color, unitcost, "0.00", stock, "Remove"}
                            PurchaseReceiveForm.dgvProd.Rows.Add(row)
                        End If
                     ' from purchase return
                    Case 3
                        ' check if existing
                        Dim inlist As Boolean = False
                        For Each item2 As DataGridViewRow In PurchaseReturnForm.dgvProd.Rows
                            If PurchaseReturnForm.dgvProd.Rows(item2.Index).Cells(3).Value <> "" Then
                                Dim p_u_id As String = PurchaseReturnForm.dgvProd.Rows(item2.Index).Cells("id").Value
                                If p_u_id = product_unit_id Then
                                    inlist = True
                                    Exit For
                                End If
                            End If
                        Next

                        If inlist = False Then
                            Dim row As String() = New String() {product_unit_id, barcode, "0", desc, brand, unit, color, unitcost, "0.00", stock, "Remove"}
                            PurchaseReturnForm.dgvProd.Rows.Add(row)
                        End If
                        'from purchase order request form
                    Case 4
                        ' check if existing
                        Dim inlist As Boolean = False
                        For Each item2 As DataGridViewRow In PurchaseOrderRequestForm.dgvProd.Rows
                            If PurchaseOrderRequestForm.dgvProd.Rows(item2.Index).Cells(3).Value <> "" Then
                                Dim p_u_id As String = PurchaseOrderRequestForm.dgvProd.Rows(item2.Index).Cells("id").Value
                                If p_u_id = product_unit_id Then
                                    inlist = True
                                    Exit For
                                End If
                            End If
                        Next

                        If inlist = False Then
                            Dim row As String() = New String() {product_unit_id, barcode, "0", desc, brand, unit, color, unitcost, "0.00", stock, "Remove"}
                            PurchaseOrderRequestForm.dgvProd.Rows.Add(row)
                        End If
                End Select


            End If
        Next
        Me.Close()
    End Sub

    Private Function getCost(ByVal supplier As Integer, ByVal p_u_id As Integer) As Double
        Dim result As Double = 0
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("select unit_cost from product_suppliers where supplier = " & supplier & " and product_unit_id = " & p_u_id)
            If .dr.Read Then
                result = CDbl(Val(.dr("unit_cost")).ToString("N2"))
            End If
        End With

        Return result
    End Function
End Class