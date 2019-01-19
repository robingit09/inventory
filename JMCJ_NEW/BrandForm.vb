Public Class BrandForm
    Public selectedBrand As Integer = 0
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If btnSave.Text = "Save" Then
            If validation() = False Then
                Exit Sub
            End If
            saveData()

            For Each form In My.Application.OpenForms
                If (form.name = ProductAddUnitForm.Name) Then
                    'form is loaded so can do work 
                    'if you need to check whether it is actually visible
                    If form.Visible Then
                        'do work when visible
                        ProductAddUnitForm.loadBrand()
                        ProductAddUnitForm.cbBrand.SelectedIndex = ProductAddUnitForm.cbBrand.FindString(Me.txtBrand.Text)
                    End If
                End If

                If (form.name = ProductForm.Name) Then
                    'form is loaded so can do work 
                    'if you need to check whether it is actually visible
                    If form.Visible Then
                        'do work when visible
                        ProductForm.loadBrand()
                        ProductForm.cbBrand.SelectedIndex = ProductForm.cbBrand.FindString(Me.txtBrand.Text)
                    End If
                End If
            Next


        ElseIf btnSave.Text = "Update" Then
            If validation() = False Then
                Exit Sub
            End If
            updateData()
        End If
    End Sub

    Private Function validation() As Boolean
        Dim res As Boolean = True

        If Trim(txtBrand.Text) = "" Then
            res = False
            MsgBox("Brand name field is required!", MsgBoxStyle.Critical)
            txtBrand.Focus()
        End If

        If New DatabaseConnect().isExist("brand", "name", txtBrand.Text.ToUpper) Then
            res = False
            MsgBox("Brand name is already exist!", MsgBoxStyle.Critical)
            txtBrand.Focus()
            txtBrand.SelectAll()
        End If

        Return res
    End Function

    Private Sub saveData()
        Dim save As New DatabaseConnect
        With save
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "INSERT INTO brand (name,status,created_at,updated_at)VALUES('" & toCapital(txtBrand.Text) & "',1,'" & DateTime.Now.ToString & "','" & DateTime.Now.ToString & "')"
            .cmd.ExecuteNonQuery()
            .cmd.Dispose()
            .con.Close()
            MsgBox("Save Successfully", MsgBoxStyle.Information)
            BrandList.loadBrand("")
            Me.Close()
        End With
    End Sub

    Private Sub updateData()
        Dim update As New DatabaseConnect
        With update
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "UPDATE brand set name =?, updated_at = '" & DateTime.Now.ToString & "' where id = " & selectedBrand
            .cmd.Parameters.AddWithValue("@name", toCapital(txtBrand.Text))
            .cmd.ExecuteNonQuery()
            .cmd.Dispose()
            .con.Close()
            MsgBox("Update Successfully", MsgBoxStyle.Information)
            BrandList.loadBrand("")
            Me.Close()
        End With
    End Sub

    Private Sub BrandForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtBrand.Focus()
    End Sub

    Public Sub toUpdateInfo(ByVal id As Integer)
        If id > 0 Then
            Me.selectedBrand = id
            Dim s As New DatabaseConnect
            With s
                .selectByQuery("SELECT id,name from Brand where status = 1 and id = " & id)
                If .dr.Read Then
                    txtBrand.Text = .dr.GetValue(1)
                End If
                .cmd.Dispose()
                .dr.Close()
                .con.Close()
            End With

        End If
    End Sub

    Private Sub txtBrand_MouseLeave(sender As Object, e As EventArgs) Handles txtBrand.MouseLeave
        If Trim(txtBrand.Text).Length > 0 Then
            txtBrand.Text = toCapital(txtBrand.Text)
        End If
    End Sub

    Private Function toCapital(ByVal str As String) As String
        Dim result As String
        result = str.ToUpper
        Return result
    End Function
End Class