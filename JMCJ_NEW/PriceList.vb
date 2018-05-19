Public Class Pricing
    Public isSupplierLoaded As Boolean = False
    Private Sub PriceList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadSupplier()
        loadCategory()
    End Sub

    Public Sub loadSupplier()
        'cbSupplier.DataSource = Nothing
        'cbSupplier.Items.Clear()

        'Dim db As New DatabaseConnect
        'With db
        '    .dbConnect()
        '    .cmd.Connection = .con
        '    .cmd.CommandType = CommandType.Text
        '    .cmd.CommandText = "SELECT id,supplier from suppliers where status <> 0"
        '    .dr = .cmd.ExecuteReader
        '    Dim comboSource As New Dictionary(Of String, String)()
        '    comboSource.Add(0, "Select Supplier")

        '    While .dr.Read
        '        Dim id As Integer = CInt(.dr.GetValue(0))
        '        Dim sup As String = .dr.GetValue(1)
        '        comboSource.Add(id, sup)
        '    End While

        '    cbSupplier.DataSource = New BindingSource(comboSource, Nothing)
        '    cbSupplier.DisplayMember = "Value"
        '    cbSupplier.ValueMember = "Key"

        '    If .dr.HasRows Then
        '        isSupplierLoaded = True
        '    Else
        '        isSupplierLoaded = False
        '    End If

        '    .dr.Close()
        '    .cmd.Dispose()
        '    .con.Close()
        'End With

    End Sub

    Private Sub loadCategory()
        'cbCategory.Items.Clear()

        'Dim db As New DatabaseConnect
        'With db
        '    .dbConnect()
        '    .cmd.Connection = .con
        '    .cmd.CommandType = CommandType.Text
        '    .cmd.CommandText = "SELECT distinct category from products where status <> 0"
        '    .dr = .cmd.ExecuteReader

        '    cbCategory.Items.Add("Select Category")
        '    cbCategory.Items.Add("All")
        '    cbCategory.SelectedIndex = 0

        '    While .dr.Read
        '        cbCategory.Items.Add(.dr.GetValue(0))
        '    End While
        '    .dr.Close()
        '    .cmd.Dispose()
        '    .con.Close()

        'End With
    End Sub

    Private Sub loadproduct(ByVal category As String)
        'cbProduct.DataSource = Nothing
        'cbProduct.Items.Clear()

        'Dim db As New DatabaseConnect
        'With db
        '    .dbConnect()
        '    .cmd.Connection = .con
        '    .cmd.CommandType = CommandType.Text
        '    .cmd.CommandText = "SELECT distinct id,name from products where status <> 0 and category like '%" & category & "%'"
        '    .dr = .cmd.ExecuteReader

        '    Dim comboSource As New Dictionary(Of String, String)()
        '    comboSource.Add(0, "Select Product")
        '    While .dr.Read
        '        Dim id As Integer = CInt(.dr.GetValue(0))
        '        Dim prod As String = .dr.GetValue(1)
        '        comboSource.Add(id, prod)
        '    End While
        '    cbProduct.DataSource = New BindingSource(comboSource, Nothing)
        '    cbProduct.DisplayMember = "Value"
        '    cbProduct.ValueMember = "Key"

        '    .dr.Close()
        '    .cmd.Dispose()
        '    .con.Close()

        'End With
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        PricingProductForm.ShowDialog()
    End Sub
End Class



