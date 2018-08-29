Module ModelFunction
    Public Sub update_stock(ByVal p_unit_id As Integer, ByVal qty As Integer, ByVal oper As String)

        Dim dbstock As New DatabaseConnect
        With dbstock
            Dim temp As String = New DatabaseConnect().get_by_val("product_stocks", p_unit_id, "product_unit_id", "qty")
            Dim cur_stock As Integer = Val(temp)
            If oper = "+" Then
                cur_stock = cur_stock + Val(qty)
            End If

            If oper = "-" Then
                cur_stock = cur_stock - Val(qty)
            End If
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "UPDATE product_stocks set [qty] = " & cur_stock & " where product_unit_id = " & p_unit_id
            .cmd.ExecuteNonQuery()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub
End Module
