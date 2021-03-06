﻿Public Class SupplierProductSelection
    Public selectedSupplier As Integer = 0
    Public module_selection As Integer = 0

    Public Sub loadSupplierProducts(ByVal supplier As Integer, ByVal filter_query As String)
        selectedSupplier = supplier
        dgvProducts.Rows.Clear()

        Dim db As New DatabaseConnect
        With db
            Dim query As String = ""

            If filter_query = "" Then
                If module_selection = 5 Then

                    query = "Select p.id,pu.id As p_u_id,pu.barcode,pu.item_code, p.description,b.name As brand, u.name As unit,cc.name As color,pu.price,c.name As cat,Sub.name As subcat FROM ((((((((products As p 
                        INNER JOIN product_unit as pu ON p.id = pu.product_id) 
                        LEFT JOIN brand as b ON b.id = pu.brand)
                  
                        INNER JOIN unit as u ON u.id = pu.unit)
                
                        LEFT JOIN color as cc ON cc.id = pu.color)
                        INNER JOIN product_categories as pc ON pc.product_id = p.id) 
                        LEFT JOIN product_subcategories as psc ON psc.product_id = p.id)
                        LEFT JOIN categories as c ON c.id = pc.category_id)
            
                        LEFT JOIN categories as sub ON sub.id = psc.subcategory_id)  where pu.status <> 0 and p.status <> 0 "

                    selectedSupplier = 0
                    txtSupplier.Text = ""

                Else

                    'query = "Select distinct p.id,pu.id As p_u_id,pu.barcode,pu.item_code, p.description,b.name As brand, u.name As unit,cc.name As color,pu.price,c.name As cat,Sub.name As subcat FROM (((((((((products As p 
                    '    INNER JOIN product_unit as pu ON p.id = pu.product_id) 
                    '    LEFT JOIN brand as b ON b.id = pu.brand)
                    '    INNER JOIN unit as u ON u.id = pu.unit)
                    '    LEFT JOIN color as cc ON cc.id = pu.color)
                    '    INNER JOIN product_categories as pc ON pc.product_id = p.id) 
                    '    LEFT JOIN product_subcategories as psc ON psc.product_id = p.id)
                    '    LEFT JOIN categories as c ON c.id = pc.category_id)
                    '    LEFT JOIN product_suppliers as ps on ps.product_unit_id = pu.id)
                    '    LEFT JOIN categories as sub ON sub.id = psc.subcategory_id)  where pu.status <> 0 and p.status <> 0 and ps.supplier = " & selectedSupplier

                    query = "Select distinct p.id,pu.id As p_u_id,pu.barcode,pu.item_code, p.description,b.name As brand, u.name As unit,cc.name As color,pu.price,c.name As cat,Sub.name As subcat FROM ((((((((products As p 
                        INNER JOIN product_unit as pu ON p.id = pu.product_id) 
                        LEFT JOIN brand as b ON b.id = pu.brand)
                        INNER JOIN unit as u ON u.id = pu.unit)
                        LEFT JOIN color as cc ON cc.id = pu.color)
                        INNER JOIN product_categories as pc ON pc.product_id = p.id) 
                        LEFT JOIN product_subcategories as psc ON psc.product_id = p.id)
                        LEFT JOIN categories as c ON c.id = pc.category_id)
                        LEFT JOIN categories as sub ON sub.id = psc.subcategory_id)  where pu.status <> 0 and p.status <> 0"

                End If


                query = query & " order by p.description"

                .selectByQuery(query)
            Else
                .selectByQuery(filter_query)
            End If


            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr("id")
                    Dim p_u_id As String = .dr("p_u_id")
                    Dim barcode As String = .dr("barcode")
                    Dim desc As String = .dr("description")
                    Dim brand As String = If(IsDBNull(.dr("brand")), "", .dr("brand"))
                    Dim unit As String = .dr("unit")
                    Dim unit_id = New DatabaseConnect().get_id("unit", "name", unit)
                    Dim color As String = If(IsDBNull(.dr("color")), "", .dr("color"))
                    Dim price As String = Val(.dr("price")).ToString("N2")
                    Dim cost As String = Val(getCost(supplier, p_u_id, CInt(unit_id))).ToString("N2")

                    Dim stock As String = ""
                    Try
                        Dim dbstock As New DatabaseConnect
                        With dbstock
                            .selectByQuery("Select qty from product_stocks where product_unit_id = " & p_u_id)
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
                    Dim row As String() = New String() {p_u_id, False, barcode, desc, brand, unit, color, cost, stock, cat, subcat}
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
                            Dim row As String() = New String() {product_unit_id, barcode, "0", "0", desc, brand, unit, color, unitcost, "0.00", stock, "Remove"}
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

                        ' from physical count form
                    Case 5
                        ' check if existing
                        Dim inlist As Boolean = False
                        For Each item2 As DataGridViewRow In PhysicalCountForm.dgvProd.Rows
                            If PhysicalCountForm.dgvProd.Rows(item2.Index).Cells(3).Value <> "" Then
                                Dim p_u_id As String = PhysicalCountForm.dgvProd.Rows(item2.Index).Cells("id").Value
                                If p_u_id = product_unit_id Then
                                    inlist = True
                                    Exit For
                                End If
                            End If
                        Next

                        If inlist = False Then
                            Dim row As String() = New String() {product_unit_id, barcode, desc, brand, unit, color, "", stock, "Remove"}
                            PhysicalCountForm.dgvProd.Rows.Add(row)
                        End If
                End Select


            End If
        Next
        Me.Close()
    End Sub

    Private Function getCost(ByVal supplier As Integer, ByVal p_u_id As Integer, ByVal unit_id As Integer) As Double
        Dim result As Double = 0
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("Select unit_cost from product_suppliers where supplier = " & supplier & " And product_unit_id = " & p_u_id & " and " & unit_id)
            If .dr.Read Then
                result = CDbl(Val(.dr("unit_cost")).ToString("N2"))
            End If
        End With

        Return result
    End Function

    Private Sub btnAddProducts_Click(sender As Object, e As EventArgs) Handles btnAddProducts.Click
        SupplierProducts.initialize()

        SupplierProducts.cbSupplier.SelectedIndex = SupplierProducts.cbSupplier.FindString(txtSupplier.Text)
        SupplierProducts.selectedSupplier = selectedSupplier

        SupplierProducts.cbSupplier.Enabled = False
        SupplierProducts.from_module = 1
        SupplierProducts.ShowDialog()
    End Sub

    Private Sub SupplierProductSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If module_selection = 1 Then
            btnAddToOrder.Text = "Add to Purchase Order"
        End If

        If module_selection = 2 Then
            btnAddToOrder.Text = "Add to Purchase Receive"
        End If

        If module_selection = 5 Then
            btnAddToOrder.Text = "Add to Physical Count"
            gpSupplier.Visible = False
            txtSupplier.Visible = False
            btnAddProducts.Visible = False
            lblSupplier.Visible = False
        Else
            gpSupplier.Visible = True
            txtSupplier.Visible = True
            btnAddProducts.Visible = True
            lblSupplier.Visible = True
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

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If Trim(txtSearch.Text) <> "" Then
            Dim k As String = txtSearch.Text.ToUpper
            Dim query As String = ""

            If module_selection = 5 Then

                query = "Select distinct p.id,pu.id As p_u_id,pu.barcode,pu.item_code, p.description,b.name As brand, u.name As unit,cc.name As color,pu.price,c.name As cat,Sub.name As subcat FROM (((((((((products As p 
                INNER JOIN product_unit as pu ON p.id = pu.product_id) 
                LEFT JOIN brand as b ON b.id = pu.brand)
                INNER JOIN unit as u ON u.id = pu.unit)
                LEFT JOIN color as cc ON cc.id = pu.color)
                INNER JOIN product_categories as pc ON pc.product_id = p.id) 
                LEFT JOIN product_subcategories as psc ON psc.product_id = p.id)
                LEFT JOIN categories as c ON c.id = pc.category_id)
                LEFT JOIN product_suppliers as ps on ps.product_unit_id = pu.id)
                LEFT JOIN categories as sub ON sub.id = psc.subcategory_id)  where pu.status <> 0 and p.status <> 0"

                'selectedSupplier = 0
                'txtSupplier.Text = ""

            Else

                query = "Select distinct p.id,pu.id As p_u_id,pu.barcode,pu.item_code, p.description,b.name As brand, u.name As unit,cc.name As color,pu.price,c.name As cat,Sub.name As subcat FROM (((((((((products As p 
                INNER JOIN product_unit as pu ON p.id = pu.product_id) 
                LEFT JOIN brand as b ON b.id = pu.brand)
                INNER JOIN unit as u ON u.id = pu.unit)
                LEFT JOIN color as cc ON cc.id = pu.color)
                INNER JOIN product_categories as pc ON pc.product_id = p.id) 
                LEFT JOIN product_subcategories as psc ON psc.product_id = p.id)
                LEFT JOIN categories as c ON c.id = pc.category_id)
                LEFT JOIN product_suppliers as ps on ps.product_unit_id = pu.id)
                LEFT JOIN categories as sub ON sub.id = psc.subcategory_id)  where pu.status <> 0 and p.status <> 0 and ps.supplier = " & selectedSupplier

            End If

            'query = query & " or UCASE(p.description) like '%" & k & "%'  or UCASE(pu.item_code) like '%" & k & "%' 
            'or UCASE(c.name) like '%" & k & "%' or UCASE(sub.name) like '%" & k & "%' or UCASE(cc.name) like '%" & k & "%'"
            query = query & " and ( UCASE(p.description) like '%" & k & "%'  or UCASE(pu.item_code) like '%" & k & "%' )"

            query = query & " order by p.description"
            loadSupplierProducts(Me.selectedSupplier, query)
        Else
            'MsgBox("No search")
        End If

    End Sub

End Class