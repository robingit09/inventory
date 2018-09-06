Module ModelFunction
    Public Sub update_stock(ByVal p_unit_id As Integer, ByVal qty As Integer, ByVal oper As String)
        Dim dbcheck As String = New DatabaseConnect().get_by_val("product_stocks", p_unit_id, "product_unit_id", "qty")

        If dbcheck = "" Then
            Dim dbinsertstock As New DatabaseConnect
            With dbinsertstock
                .cmd.Connection = .con
                .cmd.CommandType = CommandType.Text
                .cmd.CommandText = "INSERT INTO product_stocks(product_unit_id,qty,created_at,updated_at)
                VALUES(?,?,?,?)"
                .cmd.Parameters.AddWithValue("@product_unit_id", p_unit_id)
                .cmd.Parameters.AddWithValue("@qty", 0)
                .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                .cmd.ExecuteNonQuery()
                .cmd.Dispose()
                .con.Close()
            End With
        End If
        'update stock
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

    Public Sub save_price_history(ByVal p_u_id As Integer, ByVal price As String, ByVal d As String)
        'check if exist and if is already in date of history
        Dim dbcheck As New DatabaseConnect
        With dbcheck
            .selectByQuery("Select TOP 1 unit_price from price_history where product_unit_id = " & p_u_id & " ORDER BY created_at DESC")
            If .dr.HasRows Then
                If .dr.Read Then
                    Dim price2 As String = Val(.dr("unit_price")).ToString("N2")
                    If price2 <> price Then
                        Dim dbsave As New DatabaseConnect
                        With dbsave
                            .cmd.Connection = .con
                            .cmd.CommandType = CommandType.Text
                            .cmd.CommandText = "INSERT INTO price_history (product_unit_id,unit_price,created_at,updated_at)
                    VALUES(?,?,?,?)"
                            .cmd.Parameters.AddWithValue("@product_unit_id", p_u_id)
                            .cmd.Parameters.AddWithValue("@unit_price", price)
                            .cmd.Parameters.AddWithValue("@created_at", d)
                            .cmd.Parameters.AddWithValue("@updated_at", d)
                            .cmd.ExecuteNonQuery()
                            .cmd.Dispose()
                            .con.Close()
                        End With
                    End If
                End If
            Else
                Dim dbsave As New DatabaseConnect
                With dbsave
                    .cmd.Connection = .con
                    .cmd.CommandType = CommandType.Text
                    .cmd.CommandText = "INSERT INTO price_history (product_unit_id,unit_price,created_at,updated_at)
                    VALUES(?,?,?,?)"
                    .cmd.Parameters.AddWithValue("@product_unit_id", p_u_id)
                    .cmd.Parameters.AddWithValue("@unit_price", price)
                    .cmd.Parameters.AddWithValue("@created_at", d)
                    .cmd.Parameters.AddWithValue("@updated_at", d)
                    .cmd.ExecuteNonQuery()
                    .cmd.Dispose()
                    .con.Close()
                End With
            End If
        End With
    End Sub

    Public Sub save_cost_history(ByVal p_u_id As Integer, ByVal cost As String, ByVal d As String)
        'check if exist and if is already in date of history
        Dim dbcheck As New DatabaseConnect
        With dbcheck
            .selectByQuery("Select TOP 1 unit_cost from cost_history where product_unit_id = " & p_u_id & " ORDER BY created_at DESC")
            If .dr.HasRows Then
                If .dr.Read Then
                    Dim cost2 As String = Val(.dr("unit_cost")).ToString("N2")
                    If cost2 <> cost Then
                        Dim dbsave As New DatabaseConnect
                        With dbsave
                            .cmd.Connection = .con
                            .cmd.CommandType = CommandType.Text
                            .cmd.CommandText = "INSERT INTO cost_history (product_unit_id,unit_cost,created_at,updated_at)
                    VALUES(?,?,?,?)"
                            .cmd.Parameters.AddWithValue("@product_unit_id", p_u_id)
                            .cmd.Parameters.AddWithValue("@unit_cost", cost)
                            .cmd.Parameters.AddWithValue("@created_at", d)
                            .cmd.Parameters.AddWithValue("@updated_at", d)
                            .cmd.ExecuteNonQuery()
                            .cmd.Dispose()
                            .con.Close()
                        End With
                    End If
                End If
            Else
                Dim dbsave As New DatabaseConnect
                With dbsave
                    .cmd.Connection = .con
                    .cmd.CommandType = CommandType.Text
                    .cmd.CommandText = "INSERT INTO cost_history (product_unit_id,unit_cost,created_at,updated_at)
                    VALUES(?,?,?,?)"
                    .cmd.Parameters.AddWithValue("@product_unit_id", p_u_id)
                    .cmd.Parameters.AddWithValue("@unit_cost", cost)
                    .cmd.Parameters.AddWithValue("@created_at", d)
                    .cmd.Parameters.AddWithValue("@updated_at", d)
                    .cmd.ExecuteNonQuery()
                    .cmd.Dispose()
                    .con.Close()
                End With
            End If
        End With
    End Sub
End Module
