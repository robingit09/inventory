Public Class AddCustomerPrices
    Private Sub AddCustomerPrices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadCustomer()
    End Sub


    Public Sub loadCustomer()
        cbCustomer.DataSource = Nothing
        cbCustomer.Items.Clear()
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("SELECT id,company from company where status <> 0 order by company")
            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "Select Customer")

            While .dr.Read
                Dim id As Integer = CInt(.dr.GetValue(0))
                Dim c As String = .dr.GetValue(1)
                comboSource.Add(id, c)
            End While

            cbCustomer.DataSource = New BindingSource(comboSource, Nothing)
            cbCustomer.DisplayMember = "Value"
            cbCustomer.ValueMember = "Key"

            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'validation
        If cbCustomer.SelectedIndex = 0 Then
            MsgBox("Please select customer!", MsgBoxStyle.Critical)
            cbCustomer.Focus()
            Exit Sub
        End If

        If btnAdd.Text = "Add(+)" Then
            ' check if exist
            For Each item As DataGridViewRow In ProductMasterForm.dgvCPrices.Rows
                If item.Cells("customer").Value <> "" Then
                    Dim supplier As String = item.Cells("customer").Value.ToString.ToUpper
                    If supplier = cbCustomer.Text.ToUpper Then
                        MsgBox("Customer is already added!", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                End If
            Next
        End If

        If Trim(txtPrice.Text) = "" Then
            MsgBox("Please input unit price!", MsgBoxStyle.Critical)
            txtPrice.Focus()
            Exit Sub
        End If

        If Not IsNumeric(txtPrice.Text) Then
            MsgBox("Invalid number format for unit cost!", MsgBoxStyle.Critical)
            txtPrice.Focus()
            txtPrice.SelectAll()
            Exit Sub
        End If

        Dim row As String() = New String() {cbCustomer.Text, Val(txtPrice.Text).ToString("N2"), "Remove"}
        ProductMasterForm.dgvCPrices.Rows.Add(row)
        cbCustomer.SelectedIndex = 0
        txtPrice.Text = ""
        cbCustomer.Focus()
        Me.Close()
    End Sub
End Class