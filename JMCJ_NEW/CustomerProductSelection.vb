Public Class CustomerProductSelection
    Public module_selection As Integer = 0
    Public selectedCustomer As Integer = 0

    Private Sub CustomerProductSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub loadCustomerProducts(ByVal customer As Integer)
        dgvProducts.Rows.Clear()
        Dim db As New DatabaseConnect
        With db
            Dim query As String = "Select distinct pu.id,pu.barcode,p.description,b.name as brand, u.name as unit,cc.name as color,pu.price,cpp.sell_price,c.name as cat, subc.name as subcat from (((((((((product_unit as pu
                INNER JOIN customer_product_prices as cpp ON cpp.product_unit_id = pu.id)
                LEFT JOIN brand as b on b.id = pu.brand)
                INNER JOIN unit as u on u.id = pu.unit)
                LEFT JOIN color as cc ON cc.id = pu.color)
                INNER JOIN products as p ON p.id = pu.product_id)
                LEFT JOIN product_categories as pc ON pc.product_id = pu.product_id) 
                LEFT JOIN product_subcategories as psc ON psc.product_id = pu.product_id)
                LEFT JOIN categories as c ON c.id = pc.category_id)
                LEFT JOIN categories as subc ON subc.id = psc.subcategory_id)
                where cpp.customer_id = " & customer & " order by p.description"


            .selectByQuery(query)

            If .dr.HasRows Then
                While .dr.Read

                    Dim p_u_id As String = .dr("id")
                    Dim barcode As String = .dr("barcode")
                    Dim desc As String = .dr("description")
                    Dim brand As String = If(IsDBNull(.dr("brand")), "", .dr("brand"))
                    Dim unit As String = .dr("unit")
                    Dim color As String = If(IsDBNull(.dr("color")), "", .dr("color"))
                    Dim price As String = Val(.dr("price")).ToString("N2")
                    Dim sell_price As String = Val(.dr("sell_price")).ToString("N2")
                    'Dim cost As String = Val(getCost(supplier, p_u_id)).ToString("N2")

                    If Val(sell_price) = 0 Then
                        sell_price = price
                    End If

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
                    Dim row As String() = New String() {p_u_id, False, barcode, desc, brand, unit, color, price, sell_price, stock, cat, subcat}
                    dgvProducts.Rows.Add(row)
                End While
            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With

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
                Dim price As String = dgvProducts.Rows(item.Index).Cells("column_price").Value
                Dim sell_price As String = dgvProducts.Rows(item.Index).Cells("column_sell_price").Value
                Dim stock As String = dgvProducts.Rows(item.Index).Cells("column_stock").Value

                'module selection
                Select Case module_selection
                    ' from customer orders
                    Case 1
                        ' check if existing
                        Dim inlist As Boolean = False
                        For Each item2 As DataGridViewRow In CustomerOrderForm.dgvProd.Rows
                            If CustomerOrderForm.dgvProd.Rows(item2.Index).Cells(3).Value <> "" Then
                                Dim p_u_id As String = CustomerOrderForm.dgvProd.Rows(item2.Index).Cells("id").Value
                                If p_u_id = product_unit_id Then
                                    inlist = True
                                    Exit For
                                End If
                            End If
                        Next

                        If inlist = False Then
                            Dim row As String() = New String() {product_unit_id, barcode, "", desc, brand, unit, color, price, "", "Add less", "Reset", sell_price, "0.00", stock, "Remove"}
                            CustomerOrderForm.dgvProd.Rows.Add(row)
                            Dim rowcount As Integer = CustomerOrderForm.dgvProd.Rows.Count
                            If Val(stock) <= 0 Then
                                CustomerOrderForm.dgvProd.Rows(rowcount - 2).Cells("stock").Style.ForeColor = Drawing.Color.Red
                            End If

                        End If
                   ' from customer return
                    Case 2
                        ' check if existing
                        Dim inlist As Boolean = False
                        For Each item2 As DataGridViewRow In CustomerReturnForm.dgvProd.Rows
                            If CustomerReturnForm.dgvProd.Rows(item2.Index).Cells(3).Value <> "" Then
                                Dim p_u_id As String = CustomerReturnForm.dgvProd.Rows(item2.Index).Cells("id").Value
                                If p_u_id = product_unit_id Then
                                    inlist = True
                                    Exit For
                                End If
                            End If
                        Next

                        If inlist = False Then
                            Dim row As String() = New String() {product_unit_id, barcode, "", desc, brand, unit, color, price, sell_price, "0.00", stock, "Remove"}
                            CustomerReturnForm.dgvProd.Rows.Add(row)
                        End If
                End Select


            End If
        Next
        Me.Close()
    End Sub

    Private Sub btnAddProduct_Click(sender As Object, e As EventArgs) Handles btnAddProduct.Click
        If txtCustomer.Text.Length > 0 Then
            AddProductForm.selectedCustomer = Me.selectedCustomer
            AddProductForm.initialize()
            AddProductForm.from_module = 1
            AddProductForm.ShowDialog()
        Else
            'selectedCustomer = 0
            'AddProductForm.selectedCustomer = 0
            'cbCustomer.Focus()
            'MsgBox("Please select customer", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub linkUnselectAll_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkUnselectAll.LinkClicked
        For Each item As DataGridViewRow In Me.dgvProducts.Rows
            If dgvProducts.Rows(item.Index).Cells(3).Value <> "" Then
                dgvProducts.Rows(item.Index).Cells(1).Value = False
            End If
        Next
    End Sub

    Private Sub linkSelectAll_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkSelectAll.LinkClicked
        For Each item As DataGridViewRow In Me.dgvProducts.Rows
            If dgvProducts.Rows(item.Index).Cells(3).Value <> "" Then
                dgvProducts.Rows(item.Index).Cells(1).Value = True
            End If
        Next
    End Sub
End Class