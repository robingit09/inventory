﻿Public Class CategoryForm
    Public from_module As Integer = 0
    Public selectedParent As Integer
    Public SelectedID As Integer = 0
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If New DatabaseConnect().isExist("categories", "name", txtName.Text) Then
            MsgBox("Already Exist!", MsgBoxStyle.Critical)
            txtName.Focus()
            txtName.SelectAll()
            Exit Sub
        End If

        If btnSave.Text = "Save" Then
            btnSave.Enabled = False
            saveData()
            btnSave.Enabled = True

            If from_module = 1 Then
                ' from product module


                If cbParent.Text = "" Then
                    ProductForm.populateCategory()
                    ProductForm.cbCategory.SelectedIndex = ProductForm.cbCategory.FindString(txtName.Text)
                Else
                    ProductForm.populateSubcategory(ProductForm.selectedSubcategory)
                    ProductForm.cbSubcategory.SelectedIndex = ProductForm.cbSubcategory.FindString(txtName.Text)
                End If

            End If
            txtName.Text = ""

        ElseIf btnSave.Text = "Update" Then
            btnSave.Enabled = False
            UpdateData()
            btnSave.Enabled = True
        End If

    End Sub

    Public Sub toUpdateInfo(ByVal id As Integer)
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("Select id,name,parent_id from categories where status = 1 And id = " & id)

            If .dr.Read Then
                txtName.Text = .dr.GetValue(1)
                'cbParent.Text = getParent(CInt(.dr.GetValue(2)))
            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
    End Sub

    Private Sub saveData()

        Dim database As New DatabaseConnect
        database.cmd.CommandType = CommandType.Text
        database.cmd.CommandText = "INSERT INTO categories([parent_id],[name],[status],[created_at],[updated_at])" &
        "VALUES(@parent_id,@name,@status,@created_at,@updated_at)"

        database.cmd.Parameters.AddWithValue("@parent_id", selectedParent)
        database.cmd.Parameters.AddWithValue("@name", txtName.Text.ToUpper)
        database.cmd.Parameters.AddWithValue("@st", 1)
        database.cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
        database.cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
        database.cmd.Connection = database.con
        database.cmd.ExecuteNonQuery()
        database.con.Close()
        MsgBox("Category Save Successful", MsgBoxStyle.Information)

        CategoryList.loadList("")
        Me.Close()
    End Sub

    Private Sub UpdateData()
        Try
            Dim db As New DatabaseConnect
            db.cmd.CommandType = CommandType.Text

            If SelectedID > 0 Then
                db.cmd.CommandText = "UPDATE categories Set [parent_id] = '" & selectedParent & "',[name] = '" & txtName.Text.ToUpper & "', [updated_at] = '" & DateTime.Now.ToString & "' where ID = " & SelectedID
            Else
                    db.cmd.CommandText = "UPDATE categories set [name] = '" & txtName.Text.ToUpper & "', [updated_at] = '" & DateTime.Now.ToString & "' where ID = " & SelectedID
            End If

            db.cmd.Connection = db.con
            db.cmd.ExecuteNonQuery()
            db.cmd.Dispose()
            db.con.Close()

            MsgBox("Successfully Update", MsgBoxStyle.Information)
            Me.Close()
            CategoryList.loadList("")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub CategoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub populateCategory()
        cbParent.DataSource = Nothing
        cbParent.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(0, "Select Category")
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("Select id,name from CATEGORIES where status = 1 and parent_id = 0 order by name")
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = .dr.GetValue(0)
                    Dim name As String = .dr.GetValue(1)
                    comboSource.Add(id, name)
                End While
                cbParent.DataSource = New BindingSource(comboSource, Nothing)
                cbParent.DisplayMember = "Value"
                cbParent.ValueMember = "Key"
            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Private Sub cbParent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbParent.SelectedIndexChanged

        If cbParent.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbParent.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbParent.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedParent = CInt(key)
        Else
            selectedParent = 0
        End If

    End Sub

    Private Sub txtName_MouseLeave(sender As Object, e As EventArgs) Handles txtName.MouseLeave
        txtName.Text = txtName.Text.ToUpper
    End Sub
End Class