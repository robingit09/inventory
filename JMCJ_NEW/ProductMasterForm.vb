Public Class ProductMasterForm
    Public selected_prod_unit As Integer = 0
    Private Sub ProductMasterForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub toLoadInfo(ByVal p_unit_id As Integer)
        Me.selected_prod_unit = p_unit_id
        Dim db As New DatabaseConnect
        With db

            .selectByQuery("Select distinct pu.id,pu.barcode, p.description,b.name as brand, u.name as unit,cc.name as color,pu.price,c.name as cat,sub.name as subcat FROM ((((((((products as p 
                INNER JOIN product_unit as pu ON p.id = pu.product_id) 
                LEFT JOIN brand as b ON b.id = pu.brand)
                INNER JOIN unit as u ON u.id = pu.unit)
                LEFT JOIN color as cc ON cc.id = pu.color)
                INNER JOIN product_categories as pc ON pc.product_id = p.id) 
                LEFT JOIN product_subcategories as psc ON psc.product_id = p.id)
                LEFT JOIN categories as c ON c.id = pc.category_id)
                LEFT JOIN categories as sub ON sub.id = psc.subcategory_id)  where pu.status <> 0 and p.status <> 0 and pu.id = " & p_unit_id)

            If .dr.Read Then
                txtBarcode.Text = .dr("barcode")
                txtDescription.Text = .dr("description")
                txtBrand.Text = .dr("brand")
                txtUnit.Text = .dr("unit")
                txtColor.Text = If(IsDBNull(.dr("color")), "", .dr("color"))
                txtPrice.Text = Val(.dr("price")).ToString("N2")
                'Dim cat As String = If(IsDBNull(.dr("cat")), "", .dr("cat"))
                'Dim subcat As String = If(IsDBNull(.dr("subcat")), "", .dr("subcat")

            End If

            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Private Sub btnAddCost_Click(sender As Object, e As EventArgs) Handles btnAddCost.Click
        AddCostForm.ShowDialog()
    End Sub
End Class