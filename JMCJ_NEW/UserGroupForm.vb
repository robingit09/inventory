Public Class UserGroupForm

    Public selectedUserGroup As Integer = 0
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        btnSave.Text = "Saving..."
        btnSave.Enabled = False
        If btnSave.Text = "Save" Then

            If validation() = False Then
                Exit Sub
            End If
            insertData()
            clearFields()
            checkAll(False)
            UserGroups.loadList("")
            btnSave.Text = "Save"
            Me.Close()

        ElseIf btnSave.Text = "Update" Then

            If validation() = False Then
                Exit Sub
            End If
            updateData()
            btnSave.Text = "Update"
        End If

        btnSave.Enabled = True
    End Sub

    Private Function validation() As Boolean

        If Trim(txtPosition.Text) = "" Then
            MsgBox("Position field is required!", MsgBoxStyle.Critical)
            Return False
        End If

        Return True
    End Function

    Public Sub loadInfo(ByVal id As Integer)
        selectedUserGroup = id

        'select user position
        txtPosition.Text = New DatabaseConnect().get_by_id("user_groups", id, "user_group").ToString().ToUpper

        ' product access
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("select access from user_module_access where user_group_id = " & id & " and module_id = 1")
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    productEnable.Checked = True
                Else
                    productEnable.Checked = False
                End If
            End If
            .cmd.Parameters.Clear()
            .dr.Close()

            'modify
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 1 and ma.module_id = 1 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    productModify.Checked = True
                Else
                    productModify.Checked = False
                End If
            End If

            .cmd.Parameters.Clear()
            .dr.Close()

            'view
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 2 and ma.module_id = 1 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    productView.Checked = True
                Else
                    productView.Checked = False
                End If
            End If

            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
        'end product access


        'product master access
        Dim db1 As New DatabaseConnect
        With db1
            .selectByQuery("select access from user_module_access where user_group_id = " & id & " and module_id = 2")
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    pMasterEnable.Checked = True
                Else
                    pMasterEnable.Checked = False
                End If
            End If
            .cmd.Parameters.Clear()
            .dr.Close()

            'modify
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 1 and ma.module_id = 2 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    pMasterModify.Checked = True
                Else
                    pMasterModify.Checked = False
                End If
            End If

            .cmd.Parameters.Clear()
            .dr.Close()

            'view
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 2 and ma.module_id = 2 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    pMasterView.Checked = True
                Else
                    pMasterView.Checked = False
                End If
            End If

            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
        ' end product master access

        'brand access
        Dim db2 As New DatabaseConnect
        With db2
            .selectByQuery("select access from user_module_access where user_group_id = " & id & " and module_id = 3")
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    brandEnable.Checked = True
                Else
                    brandEnable.Checked = False
                End If
            End If
            .cmd.Parameters.Clear()
            .dr.Close()

            'modify
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 1 and ma.module_id = 3 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    brandModify.Checked = True
                Else
                    brandModify.Checked = False
                End If
            End If

            .cmd.Parameters.Clear()
            .dr.Close()

            'view
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 2 and ma.module_id = 3 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    brandView.Checked = True
                Else
                    brandView.Checked = False
                End If
            End If

            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
        ' end brand access


        'unit access
        Dim db3 As New DatabaseConnect
        With db3
            .selectByQuery("select access from user_module_access where user_group_id = " & id & " and module_id = 4")
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    unitEnable.Checked = True
                Else
                    unitEnable.Checked = False
                End If
            End If
            .cmd.Parameters.Clear()
            .dr.Close()

            'modify
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 1 and ma.module_id = 4 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    unitModify.Checked = True
                Else
                    unitModify.Checked = False
                End If
            End If

            .cmd.Parameters.Clear()
            .dr.Close()

            'view
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 2 and ma.module_id = 4 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    unitView.Checked = True
                Else
                    unitView.Checked = False
                End If
            End If

            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
        ' end unit access

        'color access
        Dim db4 As New DatabaseConnect
        With db4
            .selectByQuery("select access from user_module_access where user_group_id = " & id & " and module_id = 5")
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    colorEnable.Checked = True
                Else
                    colorEnable.Checked = False
                End If
            End If
            .cmd.Parameters.Clear()
            .dr.Close()

            'modify
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 1 and ma.module_id = 5 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    colorModify.Checked = True
                Else
                    colorModify.Checked = False
                End If
            End If

            .cmd.Parameters.Clear()
            .dr.Close()

            'view
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 2 and ma.module_id = 5 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    colorView.Checked = True
                Else
                    colorView.Checked = False
                End If
            End If

            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
        ' end color access

        'categories access
        Dim db5 As New DatabaseConnect
        With db5
            .selectByQuery("select access from user_module_access where user_group_id = " & id & " and module_id = 6")
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    categoryEnable.Checked = True
                Else
                    categoryEnable.Checked = False
                End If
            End If
            .cmd.Parameters.Clear()
            .dr.Close()

            'modify
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 1 and ma.module_id = 6 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    categoryModify.Checked = True
                Else
                    categoryModify.Checked = False
                End If
            End If

            .cmd.Parameters.Clear()
            .dr.Close()

            'view
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 2 and ma.module_id = 6 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    categoryView.Checked = True
                Else
                    categoryView.Checked = False
                End If
            End If

            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
        ' end categories access

        'physical access
        Dim db6 As New DatabaseConnect
        With db6
            .selectByQuery("select access from user_module_access where user_group_id = " & id & " and module_id = 7")
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    pcEnable.Checked = True
                Else
                    pcEnable.Checked = False
                End If
            End If
            .cmd.Parameters.Clear()
            .dr.Close()

            'modify
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 1 and ma.module_id = 7 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    pcModify.Checked = True
                Else
                    pcModify.Checked = False
                End If
            End If

            .cmd.Parameters.Clear()
            .dr.Close()

            'view
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 2 and ma.module_id = 7 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    pcView.Checked = True
                Else
                    pcView.Checked = False
                End If
            End If

            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
        ' end physical access

        'po access
        Dim db7 As New DatabaseConnect
        With db7
            .selectByQuery("select access from user_module_access where user_group_id = " & id & " and module_id = 8")
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    poEnable.Checked = True
                Else
                    poEnable.Checked = False
                End If
            End If
            .cmd.Parameters.Clear()
            .dr.Close()

            'modify
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 1 and ma.module_id = 8 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    poModify.Checked = True
                Else
                    poModify.Checked = False
                End If
            End If

            .cmd.Parameters.Clear()
            .dr.Close()

            'view
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 2 and ma.module_id = 8 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    poView.Checked = True
                Else
                    poView.Checked = False
                End If
            End If

            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
        ' end po access

        'por access
        Dim db8 As New DatabaseConnect
        With db8
            .selectByQuery("select access from user_module_access where user_group_id = " & id & " and module_id = 9")
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    porEnable.Checked = True
                Else
                    porEnable.Checked = False
                End If
            End If
            .cmd.Parameters.Clear()
            .dr.Close()

            'modify
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 1 and ma.module_id = 9 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    porModify.Checked = True
                Else
                    porModify.Checked = False
                End If
            End If

            .cmd.Parameters.Clear()
            .dr.Close()

            'view
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 2 and ma.module_id = 9 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    porView.Checked = True
                Else
                    porView.Checked = False
                End If
            End If

            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
        ' end por access

        'pr access
        Dim db9 As New DatabaseConnect
        With db9
            .selectByQuery("select access from user_module_access where user_group_id = " & id & " and module_id = 10")
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    prEnable.Checked = True
                Else
                    prEnable.Checked = False
                End If
            End If
            .cmd.Parameters.Clear()
            .dr.Close()

            'modify
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 1 and ma.module_id = 10 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    prModify.Checked = True
                Else
                    prModify.Checked = False
                End If
            End If

            .cmd.Parameters.Clear()
            .dr.Close()

            'view
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 2 and ma.module_id = 10 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    prView.Checked = True
                Else
                    prView.Checked = False
                End If
            End If

            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
        ' end pr access

        'supplier access
        Dim db10 As New DatabaseConnect
        With db10
            .selectByQuery("select access from user_module_access where user_group_id = " & id & " and module_id = 11")
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    supplierEnable.Checked = True
                Else
                    supplierEnable.Checked = False
                End If
            End If
            .cmd.Parameters.Clear()
            .dr.Close()

            'modify
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 1 and ma.module_id = 11 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    supplierModify.Checked = True
                Else
                    supplierModify.Checked = False
                End If
            End If

            .cmd.Parameters.Clear()
            .dr.Close()

            'view
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 2 and ma.module_id = 11 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    supplierView.Checked = True
                Else
                    supplierView.Checked = False
                End If
            End If

            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
        ' end supplier access

        'supplier products access
        Dim db11 As New DatabaseConnect
        With db11
            .selectByQuery("select access from user_module_access where user_group_id = " & id & " and module_id = 12")
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    supplierproductEnable.Checked = True
                Else
                    supplierproductEnable.Checked = False
                End If
            End If
            .cmd.Parameters.Clear()
            .dr.Close()

            'modify
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 1 and ma.module_id = 12 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    supplierproductModify.Checked = True
                Else
                    supplierproductModify.Checked = False
                End If
            End If

            .cmd.Parameters.Clear()
            .dr.Close()

            'view
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 2 and ma.module_id = 12 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    supplierproductView.Checked = True
                Else
                    supplierproductView.Checked = False
                End If
            End If

            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
        ' end supplier products access


        'purchase return access
        Dim db12 As New DatabaseConnect
        With db12
            .selectByQuery("select access from user_module_access where user_group_id = " & id & " and module_id = 13")
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    preturnEnable.Checked = True
                Else
                    preturnEnable.Checked = False
                End If
            End If
            .cmd.Parameters.Clear()
            .dr.Close()

            'modify
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 1 and ma.module_id = 13 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    preturnModify.Checked = True
                Else
                    preturnModify.Checked = False
                End If
            End If

            .cmd.Parameters.Clear()
            .dr.Close()

            'view
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 2 and ma.module_id = 13 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    preturnView.Checked = True
                Else
                    preturnView.Checked = False
                End If
            End If

            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
        ' end purchase return access

        'customer order access
        Dim db13 As New DatabaseConnect
        With db13
            .selectByQuery("select access from user_module_access where user_group_id = " & id & " and module_id = 14")
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    coEnable.Checked = True
                Else
                    coEnable.Checked = False
                End If
            End If
            .cmd.Parameters.Clear()
            .dr.Close()

            'modify
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 1 and ma.module_id = 14 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    coModify.Checked = True
                Else
                    coModify.Checked = False
                End If
            End If

            .cmd.Parameters.Clear()
            .dr.Close()

            'view
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 2 and ma.module_id = 14 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    coView.Checked = True
                Else
                    coView.Checked = False
                End If
            End If

            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
        ' end customer order access

        'pricing access
        Dim db14 As New DatabaseConnect
        With db14
            .selectByQuery("select access from user_module_access where user_group_id = " & id & " and module_id = 15")
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    pricingEnable.Checked = True
                Else
                    pricingEnable.Checked = False
                End If
            End If
            .cmd.Parameters.Clear()
            .dr.Close()

            'modify
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 1 and ma.module_id = 15 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    pricingModify.Checked = True
                Else
                    pricingModify.Checked = False
                End If
            End If

            .cmd.Parameters.Clear()
            .dr.Close()

            'view
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 2 and ma.module_id = 15 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    pricingView.Checked = True
                Else
                    pricingView.Checked = False
                End If
            End If

            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
        ' end pricing access

        'customer access
        Dim db15 As New DatabaseConnect
        With db15
            .selectByQuery("select access from user_module_access where user_group_id = " & id & " and module_id = 16")
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    cEnable.Checked = True
                Else
                    cEnable.Checked = False
                End If
            End If
            .cmd.Parameters.Clear()
            .dr.Close()

            'modify
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 1 and ma.module_id = 16 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    cModify.Checked = True
                Else
                    cModify.Checked = False
                End If
            End If

            .cmd.Parameters.Clear()
            .dr.Close()

            'view
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 2 and ma.module_id = 16 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    cView.Checked = True
                Else
                    cView.Checked = False
                End If
            End If

            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
        ' end customer access

        'customer return access
        Dim db16 As New DatabaseConnect
        With db16
            .selectByQuery("select access from user_module_access where user_group_id = " & id & " and module_id = 17")
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    crEnable.Checked = True
                Else
                    crEnable.Checked = False
                End If
            End If
            .cmd.Parameters.Clear()
            .dr.Close()

            'modify
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 1 and ma.module_id = 17 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    crModify.Checked = True
                Else
                    crModify.Checked = False
                End If
            End If

            .cmd.Parameters.Clear()
            .dr.Close()

            'view
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 2 and ma.module_id = 17 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    crView.Checked = True
                Else
                    crView.Checked = False
                End If
            End If

            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
        ' end customer return access


        'ledger access
        Dim db17 As New DatabaseConnect
        With db17
            .selectByQuery("select access from user_module_access where user_group_id = " & id & " and module_id = 18")
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    ledgerEnable.Checked = True
                Else
                    ledgerEnable.Checked = False
                End If
            End If
            .cmd.Parameters.Clear()
            .dr.Close()

            'modify
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 1 and ma.module_id = 18 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    ledgerModify.Checked = True
                Else
                    ledgerModify.Checked = False
                End If
            End If

            .cmd.Parameters.Clear()
            .dr.Close()

            'view
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 2 and ma.module_id = 18 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    ledgerView.Checked = True
                Else
                    ledgerView.Checked = False
                End If
            End If

            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
        ' end ledger access

        'reports access
        Dim db18 As New DatabaseConnect
        With db18
            .selectByQuery("select access from user_module_access where user_group_id = " & id & " and module_id = 19")
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    reportEnable.Checked = True
                Else
                    reportEnable.Checked = False
                End If
            End If
            .cmd.Parameters.Clear()
            .dr.Close()

            'modify
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 1 and ma.module_id = 19 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    reportModify.Checked = True
                Else
                    reportModify.Checked = False
                End If
            End If

            .cmd.Parameters.Clear()
            .dr.Close()

            'view
            .selectByQuery("select uaa.access from user_action_access uaa 
                inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 2 and ma.module_id = 19 and uaa.user_group_id = " & id)
            If .dr.Read Then
                If CInt(.dr("access")) = 1 Then
                    reportView.Checked = True
                Else
                    reportView.Checked = False
                End If
            End If

            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
        ' end reports access

    End Sub

    Public Sub CheckAccess(ByVal user_group_id As Integer, ByVal module_id As Integer, ByVal action_id As Integer)
        'Dim db As New DatabaseConnect
        'With db
        '    .selectByQuery("select access from user_module_access where user_group_id = " & user_group_id & " and module_id = " & module_id)
        '    If .dr.Read Then
        '        If CInt(.dr("access")) = 1 Then
        '            productEnable.Checked = True
        '        Else
        '            productEnable.Checked = False
        '        End If
        '    End If
        '    .cmd.Parameters.Clear()
        '    .dr.Close()

        '    'modify
        '    .selectByQuery("select uaa.access from user_action_access uaa 
        '        inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 1 and ma.module_id = " & module_id & " and uaa.user_group_id = " & user_group_id)
        '    If .dr.Read Then
        '        If CInt(.dr("access")) = 1 Then
        '            productModify.Checked = True
        '        Else
        '            productModify.Checked = False
        '        End If
        '    End If

        '    .cmd.Parameters.Clear()
        '    .dr.Close()

        '    'view
        '    .selectByQuery("select uaa.access from user_action_access uaa 
        '        inner join module_action ma on ma.id = uaa.module_action_id where ma.action_id = 2 and ma.module_id = " & module_id & " and uaa.user_group_id = " & user_group_id)
        '    If .dr.Read Then
        '        If CInt(.dr("access")) = 1 Then
        '            productView.Checked = True
        '        Else
        '            productView.Checked = False
        '        End If
        '    End If

        '    .cmd.Dispose()
        '    .dr.Close()
        '    .con.Close()
        'End With
    End Sub

    Public Sub clearFields()
        selectedUserGroup = 0
        txtPosition.Clear()

    End Sub

    Private Sub insertData()

        'insert user group
        Dim dbinsert As New DatabaseConnect
        With dbinsert
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "INSERT INTO user_groups(user_group,status,created_at,updated_at)VALUES(?,?,?,?)"
            .cmd.Parameters.AddWithValue("@user_group", Trim(txtPosition.Text))
            .cmd.Parameters.AddWithValue("@status", 1)
            .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
            .cmd.Parameters.AddWithValue("@user_group", DateTime.Now.ToString)
            .cmd.ExecuteNonQuery()
            .con.Close()
        End With
        'end insert user group


        Dim get_user_group_id As Integer = CInt(getLastID("user_groups"))

        'insert module access
        Dim dbmodule As New DatabaseConnect
        With dbmodule
            .selectByQuery("select * from modules where status = 1")

            If .dr.HasRows Then
                While .dr.Read
                    Dim module_id As String = .dr("id")

                    Dim access As Integer = 0

                    Select Case module_id
                        Case "1"
                            If productEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "2"
                            If pMasterEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "3"
                            If brandEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If

                        Case "4"
                            If unitEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "5"
                            If colorEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "6"
                            If categoryEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "7"
                            If pcEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "8"
                            If poEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "9"
                            If porEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "10"
                            If prEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "11"
                            If supplierEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "12"
                            If supplierproductEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "13"
                            If preturnEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "14"
                            If coEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "15"
                            If pricingEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "16"
                            If cEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "17"
                            If crEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "18"
                            If ledgerEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "19"
                            If reportEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If

                    End Select

                    Dim dbinsertmoduleaccess As New DatabaseConnect
                    With dbinsertmoduleaccess
                        .cmd.Connection = .con
                        .cmd.CommandType = CommandType.Text
                        .cmd.CommandText = "INSERT INTO user_module_access(user_group_id,module_id,access,created_at,updated_at)VALUES(?,?,?,?,?)"
                        .cmd.Parameters.AddWithValue("@user_group_id", get_user_group_id)
                        .cmd.Parameters.AddWithValue("@module_id", module_id)
                        .cmd.Parameters.AddWithValue("@access", access)
                        .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                        .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                        .cmd.ExecuteNonQuery()
                        .cmd.Dispose()
                        .con.Close()

                    End With

                End While
            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
        'end insert module access

        'insert user action access
        Dim dbmoduleaction As New DatabaseConnect
        With dbmoduleaction
            .selectByQuery("select *  from module_action")
            If .dr.HasRows Then
                While .dr.Read
                    Dim module_action_id As String = .dr("id")
                    Dim module_id As String = .dr("module_id")
                    Dim action_id As String = .dr("action_id")

                    Dim access As Integer = 0
                    Select Case module_id
                        Case "1"
                            If action_id = "1" Then
                                If productModify.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                            If action_id = "2" Then
                                If productView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "2"
                            If action_id = "1" Then
                                If pMasterModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If pMasterView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "3"
                            If action_id = "1" Then
                                If brandModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If brandView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "4"
                            If action_id = "1" Then
                                If unitModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If unitView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "5"
                            If action_id = "1" Then
                                If colorModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If colorView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "6"
                            If action_id = "1" Then
                                If categoryModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If categoryView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "7"
                            If action_id = "1" Then
                                If pcModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If pcView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "8"
                            If action_id = "1" Then
                                If poModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If poView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "9"
                            If action_id = "1" Then
                                If porModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If porView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "10"
                            If action_id = "1" Then
                                If prModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If prView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "11"
                            If action_id = "1" Then
                                If supplierModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If supplierView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "12"
                            If action_id = "1" Then
                                If supplierproductModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If supplierproductView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "13"
                            If action_id = "1" Then
                                If preturnModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If preturnView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "14"
                            If action_id = "1" Then
                                If coModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If coView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "15"
                            If action_id = "1" Then
                                If pricingModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If pricingView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "16"
                            If action_id = "1" Then
                                If cModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If cView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "17"
                            If action_id = "1" Then
                                If crModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If crView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "18"
                            If action_id = "1" Then
                                If ledgerModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If ledgerView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "19"
                            If action_id = "1" Then
                                If reportModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If reportView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                    End Select

                    Dim insert_user_action_access As New DatabaseConnect
                    With insert_user_action_access
                        .cmd.Connection = .con
                        .cmd.CommandType = CommandType.Text
                        .cmd.CommandText = "INSERT INTO user_action_access (user_group_id,module_action_id,access,created_at,updated_at)
                            VALUES(?,?,?,?,?)"
                        .cmd.Parameters.AddWithValue("@user_group_id", get_user_group_id)
                        .cmd.Parameters.AddWithValue("@module_action_id", module_action_id)
                        .cmd.Parameters.AddWithValue("@access", access)
                        .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                        .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                        .cmd.ExecuteNonQuery()
                        .cmd.Dispose()
                        .con.Close()
                    End With
                End While
            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
        'end insert user action access
        MsgBox("Position Successfully Save.", MsgBoxStyle.Information)

    End Sub

    Private Sub updateData()

        'update user group
        Dim dbinsert As New DatabaseConnect
        With dbinsert
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "UPDATE user_groups set user_group = @user_group, updated_at = @updated_at where id = @id"
            .cmd.Parameters.AddWithValue("@user_group", Trim(txtPosition.Text))
            .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
            .cmd.Parameters.AddWithValue("@id", selectedUserGroup)
            .cmd.ExecuteNonQuery()
            .con.Close()
        End With
        'end update user group


        Dim get_user_group_id As Integer = CInt(getLastID("user_groups"))

        'update module access
        Dim dbmodule As New DatabaseConnect
        With dbmodule
            .selectByQuery("select * from modules where status = 1")

            If .dr.HasRows Then
                While .dr.Read
                    Dim module_id As String = .dr("id")

                    Dim access As Integer = 0

                    Select Case module_id
                        Case "1"
                            If productEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "2"
                            If pMasterEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "3"
                            If brandEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If

                        Case "4"
                            If unitEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "5"
                            If colorEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "6"
                            If categoryEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "7"
                            If pcEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "8"
                            If poEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "9"
                            If porEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "10"
                            If prEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "11"
                            If supplierEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "12"
                            If supplierproductEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "13"
                            If preturnEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "14"
                            If coEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "15"
                            If pricingEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "16"
                            If cEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "17"
                            If crEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "18"
                            If ledgerEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If
                        Case "19"
                            If reportEnable.Checked = True Then
                                access = 1
                            Else
                                access = 0
                            End If

                    End Select

                    'Dim dbinsertmoduleaccess As New DatabaseConnect
                    'With dbinsertmoduleaccess
                    '    .cmd.Connection = .con
                    '    .cmd.CommandType = CommandType.Text
                    '    .cmd.CommandText = "INSERT INTO user_module_access(user_group_id,module_id,access,created_at,updated_at)VALUES(?,?,?,?,?)"
                    '    .cmd.Parameters.AddWithValue("@user_group_id", get_user_group_id)
                    '    .cmd.Parameters.AddWithValue("@module_id", module_id)
                    '    .cmd.Parameters.AddWithValue("@access", access)
                    '    .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                    '    .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                    '    .cmd.ExecuteNonQuery()
                    '    .cmd.Dispose()
                    '    .con.Close()

                    'End With
                    Dim dbupdatemoduleaccess As New DatabaseConnect
                    With dbupdatemoduleaccess
                        .cmd.Connection = .con
                        .cmd.CommandType = CommandType.Text
                        .cmd.CommandText = "UPDATE user_module_access set access = @access, updated_at = @updated_at where user_group_id = @user_group_id and module_id=@module_id"
                        .cmd.Parameters.AddWithValue("@access", access)
                        .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                        .cmd.Parameters.AddWithValue("@user_group_id", selectedUserGroup)
                        .cmd.Parameters.AddWithValue("@module_id", module_id)
                        .cmd.ExecuteNonQuery()
                        .cmd.Dispose()
                        .con.Close()
                    End With

                End While
            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
        'end update module access


        'update user action access
        Dim dbmoduleaction As New DatabaseConnect
        With dbmoduleaction
            .selectByQuery("select *  from module_action")
            If .dr.HasRows Then
                While .dr.Read
                    Dim module_action_id As String = .dr("id")
                    Dim module_id As String = .dr("module_id")
                    Dim action_id As String = .dr("action_id")

                    Dim access As Integer = 0
                    Select Case module_id
                        Case "1"
                            If action_id = "1" Then
                                If productModify.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                            If action_id = "2" Then
                                If productView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "2"
                            If action_id = "1" Then
                                If pMasterModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If pMasterView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "3"
                            If action_id = "1" Then
                                If brandModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If brandView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "4"
                            If action_id = "1" Then
                                If unitModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If unitView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "5"
                            If action_id = "1" Then
                                If colorModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If colorView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "6"
                            If action_id = "1" Then
                                If categoryModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If categoryView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "7"
                            If action_id = "1" Then
                                If pcModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If pcView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "8"
                            If action_id = "1" Then
                                If poModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If poView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "9"
                            If action_id = "1" Then
                                If porModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If porView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "10"
                            If action_id = "1" Then
                                If prModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If prView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "11"
                            If action_id = "1" Then
                                If supplierModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If supplierView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "12"
                            If action_id = "1" Then
                                If supplierproductModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If supplierproductView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "13"
                            If action_id = "1" Then
                                If preturnModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If preturnView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "14"
                            If action_id = "1" Then
                                If coModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If coView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "15"
                            If action_id = "1" Then
                                If pricingModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If pricingView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "16"
                            If action_id = "1" Then
                                If cModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If cView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "17"
                            If action_id = "1" Then
                                If crModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If crView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "18"
                            If action_id = "1" Then
                                If ledgerModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If ledgerView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                        Case "19"
                            If action_id = "1" Then
                                If reportModify.Checked = True Then

                                    access = 1
                                Else
                                    access = 0

                                End If
                            End If
                            If action_id = "2" Then
                                If reportView.Checked = True Then
                                    access = 1
                                Else
                                    access = 0
                                End If
                            End If
                    End Select

                    'Dim insert_user_action_access As New DatabaseConnect
                    'With insert_user_action_access
                    '    .cmd.Connection = .con
                    '    .cmd.CommandType = CommandType.Text
                    '    .cmd.CommandText = "INSERT INTO user_action_access (user_group_id,module_action_id,access,created_at,updated_at)
                    '        VALUES(?,?,?,?,?)"
                    '    .cmd.Parameters.AddWithValue("@user_group_id", get_user_group_id)
                    '    .cmd.Parameters.AddWithValue("@module_action_id", module_action_id)
                    '    .cmd.Parameters.AddWithValue("@access", access)
                    '    .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                    '    .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                    '    .cmd.ExecuteNonQuery()
                    '    .cmd.Dispose()
                    '    .con.Close()
                    'End With
                    Dim update_user_action_access As New DatabaseConnect
                    With update_user_action_access
                        .cmd.Connection = .con
                        .cmd.CommandType = CommandType.Text
                        .cmd.CommandText = "UPDATE user_action_access SET access=@access,updated_at=@updated_at where user_group_id=@user_group_id and module_action_id=@module_action_id"
                        .cmd.Parameters.AddWithValue("@access", access)
                        .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                        .cmd.Parameters.AddWithValue("@user_group_id", selectedUserGroup)
                        .cmd.Parameters.AddWithValue("@module_action_id", module_action_id)
                        .cmd.ExecuteNonQuery()
                        .cmd.Dispose()
                        .con.Close()
                    End With

                End While
            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
        'end update user action access
        MsgBox("Position and user access Successfully update.", MsgBoxStyle.Information)


    End Sub

    Private Function getLastID(ByVal table As String) As Integer
        Dim id As Integer = 0
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("SELECT MAX(ID) from " & table)
            If .dr.HasRows Then
                .dr.Read()
                id = If(IsDBNull(.dr.GetValue(0)), 1, .dr.GetValue(0))
            Else
                id = 1
            End If
        End With
        Return id
    End Function

    Private Sub linkUnselectAll_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkUnselectAll.LinkClicked
        checkAll(False)
    End Sub

    Private Sub linkSelectAll_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkSelectAll.LinkClicked

        checkAll(True)
    End Sub

    Public Sub checkAll(ByVal flag As Boolean)
        productEnable.Checked = flag
        productView.Checked = flag
        productModify.Checked = flag

        pMasterEnable.Checked = flag
        pMasterView.Checked = flag
        pMasterModify.Checked = flag

        brandEnable.Checked = flag
        brandView.Checked = flag
        brandModify.Checked = flag

        unitEnable.Checked = flag
        unitView.Checked = flag
        unitModify.Checked = flag

        colorEnable.Checked = flag
        colorView.Checked = flag
        colorModify.Checked = flag

        categoryEnable.Checked = flag
        categoryView.Checked = flag
        categoryModify.Checked = flag

        pcEnable.Checked = flag
        pcView.Checked = flag
        pcModify.Checked = flag

        poEnable.Checked = flag
        poView.Checked = flag
        poModify.Checked = flag

        porEnable.Checked = flag
        porView.Checked = flag
        porModify.Checked = flag

        prEnable.Checked = flag
        prView.Checked = flag
        prModify.Checked = flag

        preturnEnable.Checked = flag
        preturnView.Checked = flag
        preturnModify.Checked = flag

        supplierEnable.Checked = flag
        supplierView.Checked = flag
        supplierModify.Checked = flag

        supplierproductEnable.Checked = flag
        supplierproductView.Checked = flag
        supplierproductModify.Checked = flag

        coEnable.Checked = flag
        coView.Checked = flag
        coModify.Checked = flag

        pricingEnable.Checked = flag
        pricingView.Checked = flag
        pricingModify.Checked = flag

        cEnable.Checked = flag
        cView.Checked = flag
        cModify.Checked = flag

        crEnable.Checked = flag
        crView.Checked = flag
        crModify.Checked = flag

        ledgerEnable.Checked = flag
        ledgerView.Checked = flag
        ledgerModify.Checked = flag

        reportEnable.Checked = flag
        reportView.Checked = flag
        reportModify.Checked = flag
    End Sub

    Private Sub UserGroupForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        reportModify.Visible = False
    End Sub

    Private Sub productEnable_CheckedChanged(sender As Object, e As EventArgs) Handles productEnable.CheckedChanged
        If productEnable.Checked = True Then
            productModify.Checked = True
            productView.Checked = True
        Else
            productModify.Checked = False
            productView.Checked = False
        End If
    End Sub

    Private Sub pMasterEnable_CheckedChanged(sender As Object, e As EventArgs) Handles pMasterEnable.CheckedChanged
        If pMasterEnable.Checked = True Then
            pMasterModify.Checked = True
            pMasterView.Checked = True
        Else
            pMasterModify.Checked = False
            pMasterView.Checked = False
        End If
    End Sub

    Private Sub brandEnable_CheckedChanged(sender As Object, e As EventArgs) Handles brandEnable.CheckedChanged
        If brandEnable.Checked = True Then
            brandModify.Checked = True
            brandView.Checked = True
        Else
            brandModify.Checked = False
            brandView.Checked = False
        End If
    End Sub

    Private Sub unitEnable_CheckedChanged(sender As Object, e As EventArgs) Handles unitEnable.CheckedChanged
        If unitEnable.Checked = True Then
            unitModify.Checked = True
            unitView.Checked = True
        Else
            unitModify.Checked = False
            unitView.Checked = False
        End If
    End Sub

    Private Sub colorEnable_CheckedChanged(sender As Object, e As EventArgs) Handles colorEnable.CheckedChanged
        If colorEnable.Checked = True Then
            colorModify.Checked = True
            colorView.Checked = True
        Else
            colorModify.Checked = False
            colorView.Checked = False
        End If
    End Sub

    Private Sub categoryEnable_CheckedChanged(sender As Object, e As EventArgs) Handles categoryEnable.CheckedChanged
        If categoryEnable.Checked = True Then
            categoryModify.Checked = True
            categoryView.Checked = True
        Else
            categoryModify.Checked = False
            categoryView.Checked = False
        End If
    End Sub

    Private Sub pcEnable_CheckedChanged(sender As Object, e As EventArgs) Handles pcEnable.CheckedChanged
        If pcEnable.Checked = True Then
            pcModify.Checked = True
            pcView.Checked = True
        Else
            pcModify.Checked = False
            pcView.Checked = False
        End If
    End Sub

    Private Sub poEnable_CheckedChanged(sender As Object, e As EventArgs) Handles poEnable.CheckedChanged
        If poEnable.Checked = True Then
            poModify.Checked = True
            poView.Checked = True
        Else
            poModify.Checked = False
            poView.Checked = False
        End If
    End Sub

    Private Sub porEnable_CheckedChanged(sender As Object, e As EventArgs) Handles porEnable.CheckedChanged
        If porEnable.Checked = True Then
            porModify.Checked = True
            porView.Checked = True
        Else
            porModify.Checked = False
            porView.Checked = False
        End If
    End Sub

    Private Sub prEnable_CheckedChanged(sender As Object, e As EventArgs) Handles prEnable.CheckedChanged
        If prEnable.Checked = True Then
            prModify.Checked = True
            prView.Checked = True
        Else
            prModify.Checked = False
            prView.Checked = False
        End If
    End Sub

    Private Sub preturnEnable_CheckedChanged(sender As Object, e As EventArgs) Handles preturnEnable.CheckedChanged
        If preturnEnable.Checked = True Then
            preturnModify.Checked = True
            preturnView.Checked = True
        Else
            preturnModify.Checked = False
            preturnView.Checked = False
        End If
    End Sub

    Private Sub supplierEnable_CheckedChanged(sender As Object, e As EventArgs) Handles supplierEnable.CheckedChanged
        If supplierEnable.Checked = True Then
            supplierModify.Checked = True
            supplierView.Checked = True
        Else
            supplierModify.Checked = False
            supplierView.Checked = False
        End If
    End Sub

    Private Sub supplierproductEnable_CheckedChanged(sender As Object, e As EventArgs) Handles supplierproductEnable.CheckedChanged
        If supplierproductEnable.Checked = True Then
            supplierproductModify.Checked = True
            supplierproductView.Checked = True
        Else
            supplierproductModify.Checked = False
            supplierproductView.Checked = False
        End If
    End Sub

    Private Sub coEnable_CheckedChanged(sender As Object, e As EventArgs) Handles coEnable.CheckedChanged
        If coEnable.Checked = True Then
            coModify.Checked = True
            coView.Checked = True
        Else
            coModify.Checked = False
            coView.Checked = False
        End If
    End Sub

    Private Sub pricingEnable_CheckedChanged(sender As Object, e As EventArgs) Handles pricingEnable.CheckedChanged
        If pricingEnable.Checked = True Then
            pricingModify.Checked = True
            pricingView.Checked = True
        Else
            pricingModify.Checked = False
            pricingView.Checked = False
        End If
    End Sub

    Private Sub cEnable_CheckedChanged(sender As Object, e As EventArgs) Handles cEnable.CheckedChanged
        If cEnable.Checked = True Then
            cModify.Checked = True
            cView.Checked = True
        Else
            cModify.Checked = False
            cView.Checked = False
        End If
    End Sub

    Private Sub crEnable_CheckedChanged(sender As Object, e As EventArgs) Handles crEnable.CheckedChanged
        If crEnable.Checked = True Then
            crModify.Checked = True
            crView.Checked = True
        Else
            crModify.Checked = False
            crView.Checked = False
        End If
    End Sub

    Private Sub ledgerEnable_CheckedChanged(sender As Object, e As EventArgs) Handles ledgerEnable.CheckedChanged
        If reportEnable.Checked = True Then
            reportModify.Checked = True
            reportView.Checked = True
        Else
            reportModify.Checked = False
            reportView.Checked = False
        End If
    End Sub
End Class