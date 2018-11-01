Public Class BrandList
    Private Sub BrandList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadBrand("")

        'check user access
        If ModelFunction.check_access(3, 1) = 1 Then
            btnAdd.Enabled = True
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
        Else
            btnAdd.Enabled = False
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
        End If
    End Sub

    Public Sub loadBrand(ByVal q As String)
        dgvBrand.Rows.Clear()
        Dim db As New DatabaseConnect
        With db
            If q = "" Then
                .selectByQuery("select id,name,created_at from brand where status = 1 order by name")
            Else
                .selectByQuery(q)
            End If

            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = .dr.GetValue(0)
                    Dim name As String = .dr.GetValue(1)
                    Dim created_at As String = Convert.ToDateTime(.dr("created_at")).ToString("MM-dd-yy")
                    Dim row As String() = New String() {id, name,created_at}
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

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        btnSearch.Enabled = False
        Dim query As String = "select id,name,created_at from brand where status = 1"
        If Trim(txtSearch.Text) <> "" Then
            query = query & " and name like '%" & txtSearch.Text & "%'"
        End If
        query = query & "  order by name"
        loadBrand(query)
        btnSearch.Enabled = True
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvBrand.SelectedRows.Count = 1 Then
            Dim yesno As Integer = MsgBox("Are you sure you want to delete brand(" & dgvBrand.SelectedRows(0).Cells(1).Value & ") ? ", MsgBoxStyle.Information + MsgBoxStyle.YesNo)

            If yesno = MsgBoxResult.Yes Then
                Dim id As String = dgvBrand.SelectedRows(0).Cells(0).Value
                Dim dbdelete As New DatabaseConnect()
                With dbdelete
                    .update_where("brand", id, "status", 0)
                End With
                loadBrand("")
            End If

        Else
            MsgBox("Select a brand!", MsgBoxStyle.Critical)
        End If
    End Sub
End Class