Public Class ColorForm

    Public selectedColor As Integer = 0
    Private Function toCapitalFirst(ByVal str As String) As String
        Dim result As String
        result = str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower
        Return result
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If btnSave.Text = "Save" Then
            If Validation() = False Then
                Exit Sub
            End If
            save()
            For Each form In My.Application.OpenForms
                If (form.name = ProductAddUnitForm.Name) Then
                    'form is loaded so can do work 
                    'if you need to check whether it is actually visible
                    If form.Visible Then
                        'do work when visible
                        ProductAddUnitForm.loadColor()
                        ProductAddUnitForm.cbColor.SelectedIndex = ProductAddUnitForm.cbColor.FindString(Me.txtColor.Text)
                    End If
                End If

                If (form.name = ProductForm.Name) Then
                    'form is loaded so can do work 
                    'if you need to check whether it is actually visible
                    If form.Visible Then
                        'do work when visible
                        ProductForm.loadColor()
                        ProductForm.cbColor.SelectedIndex = ProductForm.cbColor.FindString(Me.txtColor.Text)
                    End If
                End If
            Next
            txtColor.Text = ""
        ElseIf btnSave.Text = "Update" Then
            If Validation() = False Then
                Exit Sub
            End If
            updateData()
        End If
    End Sub

    Private Sub updateData()
        Dim dbupdate As New DatabaseConnect
        With dbupdate
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "UPDATE color set [name] = ? where id = " & selectedColor
            .cmd.Parameters.AddWithValue("@name", toCapitalFirst(txtColor.Text))
            .cmd.ExecuteNonQuery()
            .cmd.Dispose()
            .con.Close()

            MsgBox("Color Successfully Update!", MsgBoxStyle.Information)
            txtColor.Clear()
            Me.Close()
            ColorList.loadList("")
        End With
    End Sub
    Private Sub save()
        txtColor.Text = txtColor.Text.ToUpper
        Dim dbsave As New DatabaseConnect
        With dbsave
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "INSERT INTO color(name,status,created_at,updated_at)VALUES(?,?,?,?)"
            .cmd.Parameters.AddWithValue("@name", toCapitalFirst(txtColor.Text))
            .cmd.Parameters.AddWithValue("@status", 1)
            .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
            .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
            .cmd.ExecuteNonQuery()
            .cmd.Dispose()
            .con.Close()

            MsgBox("Color Successfully Save!", MsgBoxStyle.Information)
            Me.Close()
            ColorList.loadList("")
        End With
    End Sub

    Private Function Validation() As Boolean
        Dim result As Boolean = True

        If Trim(txtColor.Text) = "" Then
            MsgBox("Color field is required!", MsgBoxStyle.Critical)
            result = False
            Return result
        End If

        If New DatabaseConnect().isExist("color", "name", txtColor.Text.ToUpper) Then
            MsgBox("Already Exist!", MsgBoxStyle.Critical)
            result = False
            Return result
        End If
        Return result
    End Function

    Private Sub txtColor_MouseLeave(sender As Object, e As EventArgs) Handles txtColor.MouseLeave
        If Trim(txtColor.Text).Length > 0 Then
            txtColor.Text = txtColor.Text.ToUpper
        End If
    End Sub

    Private Sub ColorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtColor.Focus()
    End Sub

    Public Sub toUpdateInfo(ByVal id As Integer)
        Dim toupdate As New DatabaseConnect
        With toupdate
            .selectByQuery("Select id,name from color where id = " & id)
            If .dr.HasRows Then
                If .dr.Read Then
                    txtColor.Text = .dr("name")
                End If
            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Private Sub txtColor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtColor.KeyDown
        If e.KeyCode = Keys.Enter Then
            If btnSave.Text = "Save" Then
                If Validation() = False Then
                    Exit Sub
                End If
                save()
                For Each form In My.Application.OpenForms
                    If (form.name = ProductAddUnitForm.Name) Then
                        'form is loaded so can do work 
                        'if you need to check whether it is actually visible
                        If form.Visible Then
                            'do work when visible
                            ProductAddUnitForm.loadColor()
                            ProductAddUnitForm.cbColor.SelectedIndex = ProductAddUnitForm.cbColor.FindString(Me.txtColor.Text)
                        End If
                    End If

                    If (form.name = ProductForm.Name) Then
                        'form is loaded so can do work 
                        'if you need to check whether it is actually visible
                        If form.Visible Then
                            'do work when visible
                            ProductForm.loadColor()
                            ProductForm.cbColor.SelectedIndex = ProductForm.cbColor.FindString(Me.txtColor.Text)
                        End If
                    End If
                Next
                txtColor.Text = ""
            ElseIf btnSave.Text = "Update" Then
                If Validation() = False Then
                    Exit Sub
                End If
                updateData()
            End If
        End If
    End Sub
End Class