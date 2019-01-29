Public Class CustomerSelection
    Private Sub CustomerSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getCustomerList("")
    End Sub

    Public Sub getCustomerList(ByVal query As String)
        cbCustomer.DataSource = Nothing
        cbCustomer.Items.Clear()
        Dim db As New DatabaseConnect
        With db
            If query = "" Then
                .selectByQuery("select distinct company,ID from company where status <> 0 order by company")
            Else

            End If
            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "Select Customer")
            While db.dr.Read
                Dim cus As String = db.dr.GetValue(0)
                Dim id As String = db.dr.GetValue(1)
                comboSource.Add(id, cus)
            End While

            cbCustomer.DataSource = New BindingSource(comboSource, Nothing)
            cbCustomer.DisplayMember = "Value"
            cbCustomer.ValueMember = "Key"
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click

        If Trim(cbCustomer.Text) = "" Then
            Exit Sub
        End If

        ' check if exist
        For Each item As DataGridViewRow In ProductForm.dgvSellPrice.Rows
            If item.Cells("spCustomer").Value <> "Select" Then
                Dim customer As String = item.Cells("spCustomer").Value.ToString.ToUpper


                If customer = (cbCustomer.Text.ToUpper) Then
                    MsgBox("The customer you input is already in list", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If
        Next

        Dim cur_index As Integer = ProductForm.dgvSellPrice.CurrentCell.RowIndex
        ProductForm.dgvSellPrice.Rows(cur_index).Cells("spCustomer").Value = cbCustomer.Text
        Me.Close()

    End Sub
End Class