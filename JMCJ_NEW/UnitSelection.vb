Public Class UnitSelection
    Public prod_id As Integer = 0
    Public supplier_id As Integer = 0
    Public selectedUnit As Integer = 0
    Public from_module As Integer = 0
    '<<<<<<< HEAD

    '=======
    '>>>>>>> dev
    Private Sub UnitSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadUnit()
    End Sub

    Public Sub loadUnit()
        cbUnit.DataSource = Nothing
        cbUnit.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()

        Dim query As String = ""
        If prod_id > 0 And from_module = 9 Then
            query = "Select distinct u.id,u.name from unit as u inner join product_suppliers pm on pm.unit_id = u.id  where u.status = 1 and pm.product_unit_id = " & prod_id & " order by u.name"
        Else
            query = "select id,name from unit where status = 1 order by name"
        End If

        Dim dbbrand As New DatabaseConnect
        With dbbrand
            .selectByQuery(query)
            If .dr.HasRows Then
                While .dr.Read
                    comboSource.Add(.dr.GetValue(0), .dr.GetValue(1))

                End While
                cbUnit.DataSource = New BindingSource(comboSource, Nothing)
                cbUnit.DisplayMember = "Value"
                cbUnit.ValueMember = "Key"
            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()

        End With
    End Sub

    Private Sub cbUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbUnit.SelectedIndexChanged
        If cbUnit.Text <> "" Then
            Dim key As String = DirectCast(cbUnit.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbUnit.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedUnit = CInt(key)
        Else
            selectedUnit = 0
        End If
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        If Trim(cbUnit.Text) = "" Then
            Exit Sub
        End If

        ' check if exist
        If from_module = 1 Then
            For Each item As DataGridViewRow In ProductForm.dgvMeasure2.Rows
                If item.Cells("mUnit").Value <> "Select" Then

                    Dim unit As String = item.Cells("mUnit").Value.ToString.ToUpper
                    Dim price As Double = CDbl(item.Cells("mPrice").Value)

                    If unit = (cbUnit.Text.ToUpper) Then
                        MsgBox("The fields of measurement you input is already in list", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                End If
            Next
        End If

        If from_module = 2 Then
            'For Each item As DataGridViewRow In ProductForm.dgvCost.Rows
            '    If item.Cells("sUnit").Value <> "Select" Then
            '        Dim supplier As String = item.Cells("Supplier").Value.ToString.ToUpper
            '        Dim unit As String = item.Cells("sUnit").Value.ToString.ToUpper
            '        Dim cost As Double = CDbl(item.Cells("Cost").Value)

            '        If unit = (cbUnit.Text.ToUpper) Then
            '            MsgBox("The fields of measurement you input is already in list", MsgBoxStyle.Critical)
            '            Exit Sub
            '        End If
            '    End If
            'Next
        End If

        If from_module = 3 Then
            'For Each item As DataGridViewRow In ProductForm.dgvSellPrice.Rows
            '    If item.Cells("spUnit").Value <> "Select" Then

            '        Dim unit As String = item.Cells("spUnit").Value.ToString.ToUpper
            '        Dim sp As Double = CDbl(item.Cells("spSellPrice").Value)

            '        If unit = (cbUnit.Text.ToUpper) Then
            '            MsgBox("The fields of measurement you input is already in list", MsgBoxStyle.Critical)
            '            Exit Sub
            '        End If
            '    End If
            'Next
        End If


        'MsgBox(ProductForm.dgvMeasure2.CurrentCell.RowIndex)


        If from_module = 9 Then
            Dim cur_index As Integer = PurchaseOrderForm.dgvProd.CurrentCell.RowIndex

            Dim unit_id As String = New DatabaseConnect().get_id("unit", "name", cbUnit.Text)
            Dim cost As Double = 0

            'MsgBox(prod_id & " " & unit_id & " " & supplier_id)

            'get cost
            Dim dbgetcost As New DatabaseConnect()
            With dbgetcost
                .selectByQuery("select unit_cost from product_suppliers where product_unit_id = " & prod_id & " and unit_id =" & unit_id & " and supplier = " & supplier_id)
                If .dr.Read Then
                    cost = If(IsDBNull(.dr("unit_cost")), 0, .dr("unit_cost"))
                End If
                .dr.Close()
                .con.Close()
            End With

            PurchaseOrderForm.dgvProd.Rows(cur_index).Cells("unit").Value = cbUnit.Text
            PurchaseOrderForm.dgvProd.Rows(cur_index).Cells("cost").Value = Val(cost).ToString("N2")


        ElseIf from_module = 10 Then
            Dim cur_index As Integer = PurchaseReceiveForm.dgvProd.CurrentCell.RowIndex

            Dim unit_id As String = New DatabaseConnect().get_id("unit", "name", cbUnit.Text)
            Dim cost As Double = 0

            'get cost
            Dim dbgetcost As New DatabaseConnect()
            With dbgetcost
                .selectByQuery("select unit_cost from product_suppliers where product_unit_id = " & prod_id & " and unit_id =" & unit_id & " and supplier = " & supplier_id)
                If .dr.Read Then
                    cost = If(IsDBNull(.dr("unit_cost")), 0, .dr("unit_cost"))
                End If
                .dr.Close()
                .con.Close()
            End With

            PurchaseReceiveForm.dgvProd.Rows(cur_index).Cells("unit").Value = cbUnit.Text
            PurchaseReceiveForm.dgvProd.Rows(cur_index).Cells("cost").Value = Val(cost).ToString("N2")


        ElseIf from_module = 11 Then
            Dim cur_index As Integer = PurchaseOrderRequestForm.dgvProd.CurrentCell.RowIndex

            Dim unit_id As String = New DatabaseConnect().get_id("unit", "name", cbUnit.Text)
            Dim cost As Double = 0

            'get cost
            Dim dbgetcost As New DatabaseConnect()
            With dbgetcost
                .selectByQuery("select unit_cost from product_suppliers where product_unit_id = " & prod_id & " and unit_id =" & unit_id & " and supplier = " & supplier_id)
                If .dr.Read Then
                    cost = If(IsDBNull(.dr("unit_cost")), 0, .dr("unit_cost"))
                End If
                .dr.Close()
                .con.Close()
            End With

            PurchaseOrderRequestForm.dgvProd.Rows(cur_index).Cells("unit").Value = cbUnit.Text
            PurchaseOrderRequestForm.dgvProd.Rows(cur_index).Cells("cost").Value = Val(cost).ToString("N2")

        ElseIf from_module = 12 Then
            Dim cur_index As Integer = PurchaseReturnForm.dgvProd.CurrentCell.RowIndex

            Dim unit_id As String = New DatabaseConnect().get_id("unit", "name", cbUnit.Text)
            Dim cost As Double = 0

            'get cost
            Dim dbgetcost As New DatabaseConnect()
            With dbgetcost
                .selectByQuery("select unit_cost from product_suppliers where product_unit_id = " & prod_id & " and unit_id =" & unit_id & " and supplier = " & supplier_id)
                If .dr.Read Then
                    cost = If(IsDBNull(.dr("unit_cost")), 0, .dr("unit_cost"))
                End If
                .dr.Close()
                .con.Close()
            End With

            PurchaseReturnForm.dgvProd.Rows(cur_index).Cells("unit").Value = cbUnit.Text
            PurchaseReturnForm.dgvProd.Rows(cur_index).Cells("cost").Value = Val(cost).ToString("N2")


        Else
            'Dim cur_index As Integer = ProductForm.dgvMeasure2.CurrentCell.RowIndex
            'ProductForm.dgvMeasure2.Rows(cur_index).Cells("mUnit").Value = cbUnit.Text



            If from_module = 1 Then
                Dim cur_index As Integer = ProductForm.dgvMeasure2.CurrentCell.RowIndex
                ProductForm.dgvMeasure2.Rows(cur_index).Cells("mUnit").Value = cbUnit.Text
            End If

            If from_module = 2 Then
                Dim cur_index As Integer = ProductForm.dgvCost.CurrentCell.RowIndex
                ProductForm.dgvCost.Rows(cur_index).Cells("sUnit").Value = cbUnit.Text
            End If


            If from_module = 3 Then
                Dim cur_index As Integer = ProductForm.dgvSellPrice.CurrentCell.RowIndex
                ProductForm.dgvSellPrice.Rows(cur_index).Cells("spUnit").Value = cbUnit.Text

            End If
        End If
        Me.Close()

        'cbUnit.SelectedIndex = 0
        'selectedUnit = 0

        'txtPrice.Clear()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        UnitForm.selectedUnit = 0
        UnitForm.ShowDialog()
    End Sub
End Class