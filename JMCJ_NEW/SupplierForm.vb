Public Class SupplierForm
    Public SelectedSupplier As Integer
    Private Sub SupplierForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'loadstatus()
    End Sub

    Public Sub loadstatus()

        cbStatus.DataSource = Nothing
        cbStatus.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(0, "Select status")
        comboSource.Add(1, "Active")
        comboSource.Add(2, "Inactive")
        cbStatus.DataSource = New BindingSource(comboSource, Nothing)
        cbStatus.DisplayMember = "Value"
        cbStatus.ValueMember = "Key"

    End Sub

    
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If btnSave.Text = "Save" Then
            btnSave.Enabled = False
            saveData()
            btnSave.Enabled = True
        ElseIf btnSave.Text = "Update" Then
            btnSave.Enabled = False
            updateData(SelectedSupplier)
            btnSave.Enabled = True
        End If
    End Sub

    Public Sub clearFields()
        txtSupplier.Clear()
        txtSupCode.Clear()
        txtAddress.Clear()
        txtContactPerson.Clear()
        txtContactNumber.Clear()
        txtContactNumber2.Clear()
        txtFax.Clear()
        txtEmail.Clear()

    End Sub

    Private Sub saveData()
        Dim db As New DatabaseConnect
        With db
            .dbConnect()
            .cmd.CommandType = CommandType.Text
            .cmd.Connection = .con
            .cmd.CommandText = "INSERT INTO suppliers(supplier,supplier_code,address,contact_person,contact_number1,contact_number2,fax_tel,email_address,status,created_at,updated_at) " & _
            "VALUES(?,?,?,?,?,?,?,?,?,?,?)"
            .cmd.Parameters.AddWithValue("@supplier", txtSupplier.Text)
            .cmd.Parameters.AddWithValue("@supplier_code", txtSupCode.Text)
            .cmd.Parameters.AddWithValue("@address", txtAddress.Text)
            .cmd.Parameters.AddWithValue("@contact_person", txtContactPerson.Text)
            .cmd.Parameters.AddWithValue("@contact_number1", txtContactNumber.Text)
            .cmd.Parameters.AddWithValue("@contact_number2", txtContactNumber2.Text)
            .cmd.Parameters.AddWithValue("@fax_tel", txtFax.Text)
            .cmd.Parameters.AddWithValue("@email_address", txtEmail.Text)
            Dim key As String = DirectCast(cbStatus.SelectedItem, KeyValuePair(Of String, String)).Key
            .cmd.Parameters.AddWithValue("@status", key)
            .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
            .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
            .cmd.ExecuteNonQuery()
            .cmd.Dispose()
            .con.Close()

            MsgBox(txtSupplier.Text & " successfully saved.", MsgBoxStyle.Information)
            clearFields()
            SupplierList.loadlist("")
            Me.Close()

        End With

    End Sub

    Private Sub updateData(ByVal id As Integer)
        Dim db As New DatabaseConnect
        With db
            .dbConnect()
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "UPDATE suppliers set [supplier] = ?,[supplier_code]=?,[address]=?,[contact_person]=?,[contact_number1]=?," & _
            "[contact_number2]=?,[fax_tel]=?,[email_address]=?,[status]=?,[updated_at]=? where id = " & id

            .cmd.Parameters.AddWithValue("supplier", txtSupplier.Text)
            .cmd.Parameters.AddWithValue("supplier_code", txtSupCode.Text)
            .cmd.Parameters.AddWithValue("address", txtAddress.Text)
            .cmd.Parameters.AddWithValue("contact_person", txtContactPerson.Text)
            .cmd.Parameters.AddWithValue("contact_number1", txtContactNumber.Text)
            .cmd.Parameters.AddWithValue("contact_number2", txtContactNumber2.Text)
            .cmd.Parameters.AddWithValue("fax_tel", txtFax.Text)
            .cmd.Parameters.AddWithValue("email_address", txtEmail.Text)
            Dim key As String = DirectCast(cbStatus.SelectedItem, KeyValuePair(Of String, String)).Key
            .cmd.Parameters.AddWithValue("status", key)
            .cmd.Parameters.AddWithValue("updated_at", DateTime.Now.ToString)

            .cmd.ExecuteNonQuery()
            .cmd.Dispose()
            .con.Close()

            MsgBox(txtSupplier.Text & " successfully updated", MsgBoxStyle.Information)
            SupplierList.loadlist("")
            Me.Close()

        End With

    End Sub
End Class