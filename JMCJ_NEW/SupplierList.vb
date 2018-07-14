Public Class SupplierList
    Private Sub SupplierList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadlist("")

    End Sub
    Public Sub loadlist(ByVal key As String)
        dgvSupplier.Rows.Clear()

        Dim db As New DatabaseConnect
        With db
            .cmd.CommandType = CommandType.Text

            If Trim(key) = "" Then
                .cmd.CommandText = "SELECT * FROM suppliers WHERE status <> 0"
            ElseIf Trim(key).Length > 0 Then
                .cmd.CommandText = "SELECT * FROM suppliers WHERE status <> 0 and supplier_name like '%" & key & "%' or supplier_code like '%" & key & "%' " &
                "or address like '%" & key & "%' or contact_person like '%" & key & "%' or  contact_number1 like '%" & key & "%' or contact_number2 like '%" & key & "%'" &
                "or fax_tel like '%" & key & "%' or email like '%" & key & "%'"
            End If
            .cmd.Connection = .con

            .dr = .cmd.ExecuteReader

            While .dr.Read
                Dim id As String = .dr("id")
                Dim sup As String = .dr("supplier_name")
                Dim sup_code As String = .dr("supplier_code")
                Dim addr As String = .dr("address")
                Dim city As String = .dr("city")
                Dim cp As String = .dr("contact_person")
                Dim cn1 As String = .dr("contact_number1")
                Dim cn2 As String = .dr("contact_number2")
                Dim ft As String = .dr("fax_tel")
                Dim ea As String = .dr("email")
                Dim added As String = Convert.ToDateTime(.dr("created_at")).ToString("MM-dd-yy")
                Dim st As String = ""
                Select Case .dr("status")
                    Case 1
                        st = "Active"
                    Case 2
                        st = "Inactive"
                    Case Else
                        st = "Deleted"
                End Select
                Dim row As String() = New String() {id, sup, sup_code, addr, city, cp, cn1, cn2, ft, ea, added, st}
                dgvSupplier.Rows.Add(row)
            End While
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        SupplierForm.loadstatus()
        SupplierForm.SelectedSupplier = 0
        SupplierForm.clearFields()
        SupplierForm.btnSave.Text = "Save"
        SupplierForm.ShowDialog()
    End Sub

    Private Sub dgvSupplier_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSupplier.RowEnter
        If dgvSupplier.SelectedRows.Count = 1 Then
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
        End If
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If dgvSupplier.SelectedRows.Count = 1 Then
            Dim id As Integer = CInt(dgvSupplier.SelectedRows(0).Cells(0).Value)
            Dim sup As String = dgvSupplier.SelectedRows(0).Cells(1).Value
            Dim yesno = MsgBox("Are you sure you want to delete " & sup & " ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo)
            If yesno = MsgBoxResult.Yes Then
                Dim db As New DatabaseConnect
                With db
                    .cmd.Connection = .con
                    .cmd.CommandText = "UPDATE suppliers set [status] = 0 where id = " & id
                    .cmd.ExecuteNonQuery()
                    .cmd.Dispose()
                    .con.Close()
                    MsgBox(sup & " successfully deleted!", MsgBoxStyle.Critical)
                    loadlist("")

                End With
            End If
        ElseIf dgvSupplier.SelectedRows.Count > 1 Then
            MsgBox("Please select only 1 supplier to delete", MsgBoxStyle.Critical)
        Else
            MsgBox("Please select the supplier you want to delete", MsgBoxStyle.Critical)
        End If
    End Sub
    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        If txtSearch.TextLength > 0 Then
            loadlist(txtSearch.Text)
        Else
            loadlist("")
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        If dgvSupplier.SelectedRows.Count = 1 Then
            Dim id As Integer = CInt(dgvSupplier.SelectedRows(0).Cells(0).Value)
            Dim db As New DatabaseConnect
            With db
                .cmd.Connection = .con
                .cmd.CommandType = CommandType.Text
                .cmd.CommandText = "SELECT * from suppliers where status <> 0 and id = " & id
                .dr = .cmd.ExecuteReader
                If .dr.Read Then
                    Dim sup As String = .dr("supplier_name")
                    Dim sup_code As String = .dr("supplier_code")
                    Dim addr As String = .dr("address")
                    Dim city As String = .dr("city")
                    Dim cp As String = .dr("contact_person")
                    Dim cn1 As String = .dr("contact_number1")
                    Dim cn2 As String = .dr("contact_number2")
                    Dim ft As String = .dr("fax_tel")
                    Dim ea As String = .dr("email")
                    Dim st As Integer = CInt(.dr("status"))

                    With SupplierForm
                        .loadstatus()
                        .txtSupplier.Text = sup
                        .txtSupCode.Text = sup_code
                        .txtAddress.Text = addr
                        .txtCity.Text = city
                        .txtContactPerson.Text = cp
                        .txtContactNumber.Text = cn1
                        .txtContactNumber2.Text = cn2
                        .txtFax.Text = ft
                        .txtEmail.Text = ea
                        Select Case st
                            Case 1
                                .cbStatus.SelectedIndex = 1

                            Case 2
                                .cbStatus.SelectedIndex = 2

                        End Select
                    End With
                End If
            End With
            SupplierForm.SelectedSupplier = id
            SupplierForm.btnSave.Text = "Update"
            SupplierForm.ShowDialog()

        Else
            MsgBox("Please select the supplier you want to update", MsgBoxStyle.Exclamation)
        End If
    End Sub
End Class