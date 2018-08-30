Public Class UnitList


    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click

        UnitForm.txtUnit.Text = ""
        UnitForm.btnSave.Text = "Save"
        UnitForm.txtUnit.Focus()
        UnitForm.ShowDialog()
    End Sub

    Private Sub UnitList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadList("")
    End Sub

    Public Sub loadList(ByVal q As String)
        dgvUnit.Rows.Clear()
        Dim db As New DatabaseConnect
        With db
            If q = "" Then
                .selectByQuery("Select id,name,created_at from unit where status = 1 order by name")
            Else
                .selectByQuery(q)
            End If

            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = .dr.GetValue(0)
                    Dim name As String = .dr.GetValue(1)
                    Dim created_at As String = Convert.ToDateTime(.dr("created_at")).ToString("MM-dd-yy")
                    Dim row As String() = New String() {id, name, created_at}
                    dgvUnit.Rows.Add(row)
                End While
            End If
        End With
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        If dgvUnit.SelectedRows.Count = 1 Then
            Dim id As Integer = CInt(dgvUnit.SelectedRows(0).Cells(0).Value)
            UnitForm.selectedUnit = id
            UnitForm.toUpdateInfo(id)
            UnitForm.btnSave.Text = "Update"
            UnitForm.ShowDialog()
        Else
            MsgBox("Please select atleast one record", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Sub btnAll_Click(sender As Object, e As EventArgs) Handles btnAll.Click
        loadList("")
    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        If txtSearch.Text.Length > 0 Then
            loadList("Select id, name from unit where name like '%" & txtSearch.Text & "%' and status = 1")
        End If
    End Sub

    Private Sub txtSearch_KeyUp(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyUp
        If e.KeyCode = Keys.Enter Then
            If txtSearch.Text.Length > 0 Then
                loadList("Select id, name from unit where name like '%" & txtSearch.Text & "%' and status = 1")
            End If
        End If
    End Sub
End Class