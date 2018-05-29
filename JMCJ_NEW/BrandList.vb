Public Class BrandList
    Private Sub BrandList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadBrand("")
    End Sub

    Public Sub loadBrand(ByVal q As String)
        dgvBrand.Rows.Clear()
        Dim db As New DatabaseConnect
        With db
            If q = "" Then
                .selectByQuery("select id,name from brand where status = 1")
            End If

            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = .dr.GetValue(0)
                    Dim name As String = .dr.GetValue(1)
                    Dim row As String() = New String() {id, name}
                    dgvBrand.Rows.Add(row)
                End While
            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        BrandForm.btnSave.Text = "Save"
        BrandForm.txtBrand.Text = ""
        BrandForm.ShowDialog()

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvBrand.SelectedRows.Count = 1 Then
            Dim id As Integer = CInt(dgvBrand.SelectedRows(0).Cells(0).Value)
            BrandForm.btnSave.Text = "Update"
            BrandForm.toUpdateInfo(id)
            BrandForm.ShowDialog()
        Else
            MsgBox("Please select record", MsgBoxStyle.Critical)
        End If
    End Sub
End Class