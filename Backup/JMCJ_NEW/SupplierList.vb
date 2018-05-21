Public Class SupplierList
    Private Sub SupplierList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadlist("")

    End Sub
    Public Sub loadlist(ByVal key As String)
        dgvSupplier.Rows.Clear()

        Dim db As New DatabaseConnect
        With db
            .dbConnect()
            .cmd.CommandType = CommandType.Text

            If Trim(key) = "" Then
                .cmd.CommandText = "SELECT * FROM suppliers WHERE status <> 0"
            ElseIf Trim(key).Length > 0 Then
                .cmd.CommandText = "SELECT * FROM suppliers WHERE status <> 0 and supplier like '%" & key & "%' or supplier_code like '%" & key & "%' " & _
                "or address like '%" & key & "%' or contact_person like '%" & key & "%' or  contact_number1 like '%" & key & "%' or contact_number2 like '%" & key & "%'" & _
                "or fax_tel like '%" & key & "%' or email_address like '%" & key & "%'"
            End If
            .cmd.Connection = .con

            .dr = .cmd.ExecuteReader

            While .dr.Read
                Dim id As String = .dr.GetValue(0)
                Dim sup As String = .dr.GetValue(1)
                Dim sup_code As String = .dr.GetValue(2)
                Dim addr As String = .dr.GetValue(3)
                Dim cp As String = .dr.GetValue(4)
                Dim cn1 As String = .dr.GetValue(5)
                Dim cn2 As String = .dr.GetValue(6)
                Dim ft As String = .dr.GetValue(7)
                Dim ea As String = .dr.GetValue(8)
                Dim added As String = .dr.GetValue(10)
                Dim st As String = ""
                Select Case .dr.GetValue(9)
                    Case 1
                        st = "Active"
                    Case 2
                        st = "Inactive"
                    Case Else
                        st = "Deleted"
                End Select
                Dim row As String() = New String() {id, sup, sup_code, addr, cp, cn1, cn2, ft, ea, added, st}
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
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If dgvSupplier.SelectedRows.Count = 1 Then
            Dim id As Integer = CInt(dgvSupplier.SelectedRows(0).Cells(0).Value)
            Dim db As New DatabaseConnect
            With db
                .dbConnect()
                .cmd.Connection = .con
                .cmd.CommandType = CommandType.Text
                .cmd.CommandText = "SELECT * from suppliers where status <> 0 and id = " & id
                .dr = .cmd.ExecuteReader
                If .dr.Read Then
                    Dim sup As String = .dr.GetValue(1)
                    Dim sup_code As String = .dr.GetValue(2)
                    Dim addr As String = .dr.GetValue(3)
                    Dim cp As String = .dr.GetValue(4)
                    Dim cn1 As String = .dr.GetValue(5)
                    Dim cn2 As String = .dr.GetValue(6)
                    Dim ft As String = .dr.GetValue(7)
                    Dim ea As String = .dr.GetValue(8)
                    Dim st As Integer = CInt(.dr.GetValue(9))

                    With SupplierForm
                        .loadstatus()
                        .txtSupplier.Text = sup
                        .txtSupCode.Text = sup_code
                        .txtAddress.Text = addr
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

    Private Sub dgvSupplier_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSupplier.RowEnter
        If dgvSupplier.SelectedRows.Count = 1 Then
            btnEdit.Enabled = True
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
                    .dbConnect()
                    .cmd.Connection = .con
                    .cmd.CommandText = "UPDATE suppliers set [status] = 0 where id = " & id
                    .cmd.ExecuteNonQuery()
                    .cmd.Dispose()
                    .con.Close()
                    MsgBox(sup & " successfully deleted", MsgBoxStyle.Critical)
                    loadlist("")
                    btnAdd.Enabled = True
                    btnEdit.Enabled = False
                    btnDelete.Enabled = False
                End With
            End If
        ElseIf dgvSupplier.SelectedRows.Count > 1 Then
            MsgBox("Please select only 1 supplier to update", MsgBoxStyle.Exclamation)
        Else
            MsgBox("Please select the supplier you want to update", MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        If txtSearch.TextLength > 0 Then
            loadlist(txtSearch.Text)
        Else
            loadlist("")
        End If
    End Sub




































































































































































































































































































































































































































































































































































































































































End Class