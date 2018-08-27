Public Class PurchaseReturn

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        btnAddNew.Enabled = False
        PurchaseReturnForm.initialize()
        PurchaseReturnForm.ShowDialog()
        btnAddNew.Enabled = True
    End Sub

    Public Sub loadList(ByVal query As String)
        dgvPReturn.Rows.Clear()
        Dim dbPR As New DatabaseConnect
        With dbPR
            .selectByQuery("Select * from purchase_return where status <> 0 order by id desc")
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr("id")
                    Dim date_issue As String = Convert.ToDateTime(.dr("pr_date")).ToString("MM-dd-yy")
                    Dim pr_no As String = .dr("pr_no")
                    Dim supplier_id As Integer = CInt(.dr("supplier_id"))
                    Dim supplier_name As String = New DatabaseConnect().get_by_id("suppliers", supplier_id, "supplier_name")
                    Dim total_amount As String = Val(.dr("total_amount")).ToString("N2")
                    Dim issue_by As String = .dr("issued_by")
                    issue_by = New DatabaseConnect().get_by_id("users", issue_by, "first_name") & " " & New DatabaseConnect().get_by_id("users", issue_by, "surname")

                    Dim status As String = ""
                    Select Case .dr("status")
                        Case "0"
                            status = "Deleted"
                        Case "1"
                            status = "Active"
                        Case "2"
                            status = "Voided"
                    End Select
                    Dim row As String() = New String() {id, date_issue, pr_no, supplier_name, total_amount, issue_by, status}
                    dgvPReturn.Rows.Add(row)
                End While
                For Each row As DataGridViewRow In dgvPReturn.Rows
                    If row.Cells("status").Value = "Voided" Then
                        row.DefaultCellStyle.BackColor = Color.OrangeRed
                    End If
                Next
            End If

            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Private Sub PurchaseReturn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadList("")
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If dgvPReturn.SelectedRows.Count = 1 Then
            Dim id As Integer = dgvPReturn.SelectedRows(0).Cells("id").Value
            PurchaseReturnForm.initialize()
            PurchaseReturnForm.toLoadInfo(id)
            PurchaseReturnForm.enableControl(False)
            PurchaseReturnForm.ShowDialog()
        Else
            MsgBox("Please select one record to view!", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnVoid_Click(sender As Object, e As EventArgs) Handles btnVoid.Click
        If dgvPReturn.SelectedRows.Count = 1 Then
            Dim id As Integer = dgvPReturn.SelectedRows(0).Cells("id").Value

            Dim status As String = dgvPReturn.SelectedRows(0).Cells("status").Value
            If status = "Voided" Then
                MsgBox("The selected transaction is already voided!", MsgBoxStyle.Critical)
                Exit Sub
            End If
            Dim yesno As Integer = MsgBox("Are you sure you want to void this transaction ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information)
            If yesno = MsgBoxResult.Yes Then
                Dim dbvoid As New DatabaseConnect
                With dbvoid
                    .update_where("purchase_return", id, "status", 2)
                    .cmd.Dispose()
                    .con.Close()
                    MsgBox("Purchase Return Successfully Voided.", MsgBoxStyle.Information)
                    loadList("")
                End With
            End If
        Else
            MsgBox("Please select one record to void!", MsgBoxStyle.Critical)
        End If
    End Sub
End Class