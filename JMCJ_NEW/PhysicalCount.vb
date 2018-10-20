Public Class PhysicalCount
    Private Sub PhysicalCount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadList("")
    End Sub

    Public Sub loadList(ByVal query As String)
        dgvPC.Rows.Clear()
        Dim dbPO As New DatabaseConnect
        With dbPO
            If query = "" Then
                .selectByQuery("Select * from physical_count order by id desc")
            Else
                .selectByQuery(query)
            End If

            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr("id")
                    Dim recorded_date As String = Convert.ToDateTime(.dr("recorded_date")).ToString("MM-dd-yy")
                    Dim pc_no As String = .dr("pc_no")
                    Dim issued_by As String = .dr("issued_by")
                    Dim processed_by As String = New DatabaseConnect().get_by_id("users", .dr("user_id"), "first_name") & " " & New DatabaseConnect().get_by_id("users", .dr("user_id"), "surname")
                    Dim status As String = ""

                    Select Case .dr("status")
                        Case "0"
                            status = "Voided"
                        Case "1"
                            status = "Active"


                    End Select
                    Dim row As String() = New String() {id, recorded_date, pc_no, issued_by, processed_by, status}
                    dgvPC.Rows.Add(row)
                End While
                For Each row As DataGridViewRow In dgvPC.Rows
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

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        PhysicalCountForm.clearFields()
        PhysicalCountForm.initialize()
        PhysicalCountForm.freeView(False)
        PhysicalCountForm.ShowDialog()
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If dgvPC.SelectedRows.Count = 0 Then
            MsgBox("Please select record", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim id As Integer = Val(dgvPC.SelectedRows(0).Cells("id").Value)
        PhysicalCountForm.loadInfo(id)
        PhysicalCountForm.freeView(True)
        PhysicalCountForm.ShowDialog()
    End Sub

    Private Sub btnVoid_Click(sender As Object, e As EventArgs) Handles btnVoid.Click
        If dgvPC.SelectedRows.Count = 0 Then
            MsgBox("Please select record", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim pc_id As Integer = dgvPC.SelectedRows(0).Cells(0).Value
        Dim status As String = dgvPC.SelectedRows(0).Cells("status").Value

        If status = "Voided" Then
            MsgBox("This transaction cannot is already voided!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim yn As Integer = MsgBox("Are you sure you want to void this record ? ", MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If yn = MsgBoxResult.Yes Then
            Dim db As New DatabaseConnect
            db.update_where("physical_count", pc_id, "status", 0)
            db.cmd.Dispose()
            db.con.Close()
            MsgBox("Physical Count Successfully Voided.", MsgBoxStyle.Information)
            loadList("")
        End If

    End Sub
End Class