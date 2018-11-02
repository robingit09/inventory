Public Class PhysicalCount
    Private Sub PhysicalCount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadList("")


        'check user access
        If ModelFunction.check_access(7, 1) = 1 Then
            btnAddNew.Enabled = True
            btnView.Enabled = True
            btnVoid.Enabled = True
        Else
            btnAddNew.Enabled = False
            btnView.Enabled = False
            btnVoid.Enabled = False
        End If
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
        PhysicalCountForm.initialize()
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

            Dim stock_type As Integer = CInt(New DatabaseConnect().get_by_id("physical_count", pc_id, "stock_type"))

            'void decrease stock
            Dim dbprod As New DatabaseConnect()
            With dbprod
                .selectByQuery("Select product_unit_id,system_count from physical_count_products where physical_count_id = " & pc_id)
                If .dr.HasRows Then
                    While .dr.Read
                        Dim product_unit_id As Integer = .dr("product_unit_id")
                        Dim system_count As Integer = .dr("system_count")
                        If stock_type = 1 Then
                            'decrease stock
                            Dim editstock As New DatabaseConnect
                            With editstock
                                .cmd.Connection = .con
                                .cmd.CommandType = CommandType.Text
                                .cmd.CommandText = "UPDATE product_stocks set [qty] = " & system_count & " where product_unit_id = " & product_unit_id
                                .cmd.ExecuteNonQuery()
                                .cmd.Dispose()
                                .con.Close()
                            End With
                        End If

                        If stock_type = 2 Then
                            'decrease stock
                            Dim decreasestock As New DatabaseConnect
                            With decreasestock
                                Dim temp As String = New DatabaseConnect().get_by_val("product_stocks", product_unit_id, "product_unit_id", "qty")
                                Dim cur_stock As Integer = Val(temp)
                                Dim qty As Integer = New DatabaseConnect().get_by_val("physical_count_products", product_unit_id, "product_unit_id", "actual_count")
                                cur_stock = cur_stock - Val(qty)

                                .cmd.Connection = .con
                                .cmd.CommandType = CommandType.Text
                                .cmd.CommandText = "UPDATE product_stocks set [qty] = " & cur_stock & " where product_unit_id = " & product_unit_id
                                .cmd.ExecuteNonQuery()
                                .cmd.Dispose()
                                .con.Close()
                            End With
                        End If

                    End While
                End If
                .cmd.Dispose()
                .dr.Close()
                .con.Close()
            End With
            MsgBox("Physical Count Successfully Voided.", MsgBoxStyle.Information)
            loadList("")
        End If

    End Sub
End Class