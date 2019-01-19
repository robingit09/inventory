Public Class SupplierForm

    Public from_module As Integer = 0
    Public SelectedSupplier As Integer
    Private Sub SupplierForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadstatus()
        autocompleteCity()
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
        cbStatus.SelectedIndex = 1

    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If btnSave.Text = "Save" Then
            If validation() = False Then
                Exit Sub
            End If
            If New DatabaseConnect().isExist("suppliers", "supplier_name", txtSupplier.Text) Then
                MsgBox(txtSupplier.Text & " is already exist!", MsgBoxStyle.Critical)
                txtSupplier.Focus()
                txtSupplier.SelectAll()
                Exit Sub
            End If

            btnSave.Enabled = False
            saveData()

            ' from PO form
            If from_module = 2 Then
                PurchaseOrderForm.loadSupplier()
                PurchaseOrderForm.cbSupplier.SelectedIndex = PurchaseOrderForm.cbSupplier.FindString(txtSupplier.Text)
                PurchaseOrderForm.selectedSupplier = New DatabaseConnect().getLastID("suppliers")
            End If

            ' from PR form
            If from_module = 3 Then
                PurchaseReceiveForm.loadSupplier()
                PurchaseReceiveForm.cbSupplier.SelectedIndex = PurchaseReceiveForm.cbSupplier.FindString(txtSupplier.Text)
                PurchaseReceiveForm.selectedSupplier = New DatabaseConnect().getLastID("suppliers")
            End If

            ' from POR form
            If from_module = 4 Then
                PurchaseOrderRequestForm.loadSupplier()
                PurchaseOrderRequestForm.cbSupplier.SelectedIndex = PurchaseOrderRequestForm.cbSupplier.FindString(txtSupplier.Text)
                PurchaseOrderRequestForm.selectedSupplier = New DatabaseConnect().getLastID("suppliers")
            End If

            ' from Add Cost/Supplier form
            If from_module = 5 Then
                AddCostForm.loadSupplier()
                AddCostForm.cbSupplier.SelectedIndex = AddCostForm.cbSupplier.FindString(txtSupplier.Text)
                AddCostForm.selectedSupplier = New DatabaseConnect().getLastID("suppliers")
            End If

            clearFields()
            btnSave.Enabled = True

        End If

        If btnSave.Text = "Update" Then
            If validation() = False Then
                Exit Sub
            End If

            If New DatabaseConnect().isExist("suppliers", "supplier_name", txtSupplier.Text, SelectedSupplier) Then
                MsgBox(txtSupplier.Text & " is already exist!", MsgBoxStyle.Critical)
                txtSupplier.Focus()
                txtSupplier.SelectAll()
                Exit Sub
            End If
            btnSave.Enabled = False
            updateData(SelectedSupplier)
            btnSave.Enabled = True
        End If
    End Sub

    Private Function validation() As Boolean

        If Trim(txtSupplier.Text) = "" Then
            MsgBox("Supplier field is required!", MsgBoxStyle.Critical)
            txtSupplier.Focus()
            Return False
        End If

        If Trim(txtSupCode.Text) = "" Then
            MsgBox("Supplier Code field is required!", MsgBoxStyle.Critical)
            txtSupCode.Focus()
            Return False
        End If

        If Trim(txtAddress.Text) = "" Then
            MsgBox("Address field is required!", MsgBoxStyle.Critical)
            Return False
        End If

        If cbStatus.SelectedIndex = 0 Or cbStatus.Text = "Select Status" Then
            MsgBox("Status field is required!", MsgBoxStyle.Critical)
            cbStatus.Focus()
            Return False
        End If
        Return True
    End Function

    Public Sub clearFields()
        txtSupplier.Clear()
        txtSupCode.Clear()
        txtAddress.Clear()
        txtCity.Clear()
        txtContactPerson.Clear()
        txtContactNumber.Clear()
        txtContactNumber2.Clear()
        txtFax.Clear()
        txtEmail.Clear()

    End Sub

    Private Sub saveData()
        Dim db As New DatabaseConnect
        With db
            .cmd.CommandType = CommandType.Text
            .cmd.Connection = .con
            .cmd.CommandText = "INSERT INTO suppliers(supplier_name,supplier_code,address,city,contact_person,contact_number1,contact_number2,fax_tel,email,status,created_at,updated_at) " &
            "VALUES(?,?,?,?,?,?,?,?,?,?,?,?)"
            .cmd.Parameters.AddWithValue("@supplier_name", txtSupplier.Text)
            .cmd.Parameters.AddWithValue("@supplier_code", txtSupCode.Text)
            .cmd.Parameters.AddWithValue("@address", txtAddress.Text)
            .cmd.Parameters.AddWithValue("@city", txtCity.Text)
            .cmd.Parameters.AddWithValue("@contact_person", txtContactPerson.Text)
            .cmd.Parameters.AddWithValue("@contact_number1", txtContactNumber.Text)
            .cmd.Parameters.AddWithValue("@contact_number2", txtContactNumber2.Text)
            .cmd.Parameters.AddWithValue("@fax_tel", txtFax.Text)
            .cmd.Parameters.AddWithValue("@email", txtEmail.Text)
            Dim key As String = DirectCast(cbStatus.SelectedItem, KeyValuePair(Of String, String)).Key
            .cmd.Parameters.AddWithValue("@status", key)
            .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
            .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
            .cmd.ExecuteNonQuery()
            .cmd.Dispose()
            .con.Close()

            MsgBox(txtSupplier.Text & " successfully saved.", MsgBoxStyle.Information)

            SupplierList.loadlist("")
            Me.Close()

        End With

    End Sub

    Private Sub updateData(ByVal id As Integer)
        Dim db As New DatabaseConnect
        With db
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "UPDATE suppliers set [supplier_name] = ?,[supplier_code]=?,[address]=?,[city]=?,[contact_person]=?,[contact_number1]=?," &
            "[contact_number2]=?,[fax_tel]=?,[email]=?,[status]=?,[updated_at]=? where id = " & id

            .cmd.Parameters.AddWithValue("supplier", txtSupplier.Text)
            .cmd.Parameters.AddWithValue("supplier_code", txtSupCode.Text)
            .cmd.Parameters.AddWithValue("address", txtAddress.Text)
            .cmd.Parameters.AddWithValue("city", txtCity.Text)
            .cmd.Parameters.AddWithValue("contact_person", txtContactPerson.Text)
            .cmd.Parameters.AddWithValue("contact_number1", txtContactNumber.Text)
            .cmd.Parameters.AddWithValue("contact_number2", txtContactNumber2.Text)
            .cmd.Parameters.AddWithValue("fax_tel", txtFax.Text)
            .cmd.Parameters.AddWithValue("email", txtEmail.Text)
            Dim key As String = DirectCast(cbStatus.SelectedItem, KeyValuePair(Of String, String)).Key
            .cmd.Parameters.AddWithValue("status", key)
            .cmd.Parameters.AddWithValue("updated_at", DateTime.Now.ToString)

            .cmd.ExecuteNonQuery()
            .cmd.Dispose()
            .con.Close()

            MsgBox("Supplier updated successfully", MsgBoxStyle.Information)
            SupplierList.loadlist("")
            Me.Close()

        End With

    End Sub

    Public Sub autocompleteCity()
        Dim MySource As New AutoCompleteStringCollection()

        With txtCity
            .AutoCompleteCustomSource = MySource
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.CustomSource
        End With

        MySource.Add("Alaminos")
        MySource.Add("Angeles")
        MySource.Add("Antipolo")
        MySource.Add("Bacolod")
        MySource.Add("Bacoor")
        MySource.Add("Bago")
        MySource.Add("Baguio")
        MySource.Add("Bais")
        MySource.Add("Balanga")
        MySource.Add("Batac")
        MySource.Add("Batangas City")
        MySource.Add("Bayawan")
        MySource.Add("Baybay")
        MySource.Add("Bayugan")
        MySource.Add("Biñan")
        MySource.Add("Bislig")
        MySource.Add("Bogo")
        MySource.Add("Borongan")
        MySource.Add("Butuan")
        MySource.Add("Cabadbaran")
        MySource.Add("Cabanatuan")
        MySource.Add("Cabuyao")
        MySource.Add("Cadiz")
        MySource.Add("Cagayan de Oro")
        MySource.Add("Calamba")
        MySource.Add("Calapan")
        MySource.Add("Calbayog")
        MySource.Add("Caloocan")
        MySource.Add("Candon")
        MySource.Add("Canlaon")
        MySource.Add("Carcar")
        MySource.Add("Catbalogan")
        MySource.Add("Cavite City")
        MySource.Add("Cebu City")
        MySource.Add("Cotabato City")
        MySource.Add("Dagupan")
        MySource.Add("Danao")
        MySource.Add("Dapitan")
        MySource.Add("Dasmariñas")
        MySource.Add("Davao City")
        MySource.Add("Digos")
        MySource.Add("Dipolog")
        MySource.Add("Dumaguete")
        MySource.Add("El Salvador")
        MySource.Add("Escalante")
        MySource.Add("Gapan")
        MySource.Add("General Santos")
        MySource.Add("General Trias")
        MySource.Add("Gingoog")
        MySource.Add("Guihulngan")
        MySource.Add("Himamaylan")
        MySource.Add("Ilagan")
        MySource.Add("Iligan")
        MySource.Add("Iloilo City")
        MySource.Add("Imus")
        MySource.Add("Iriga")
        MySource.Add("Isabela")
        MySource.Add("Kabankalan")
        MySource.Add("Kidapawan")
        MySource.Add("Koronadal")
        MySource.Add("La Carlota")
        MySource.Add("Lamitan")
        MySource.Add("Laoag")
        MySource.Add("Lapu‑Lapu")
        MySource.Add("Las Piñas")
        MySource.Add("Legazpi")
        MySource.Add("Ligao")
        MySource.Add("Lipa")
        MySource.Add("Lucena")
        MySource.Add("Maasin")
        MySource.Add("Mabalacat")
        MySource.Add("Makati")
        MySource.Add("Malabon")
        MySource.Add("Malaybalay")
        MySource.Add("Malolos")
        MySource.Add("Mandaluyong")
        MySource.Add("Mandaue")
        MySource.Add("Manila")
        MySource.Add("Marawi")
        MySource.Add("Marikina")
        MySource.Add("Masbate City")
        MySource.Add("Mati")
        MySource.Add("Meycauayan")
        MySource.Add("Muñoz")
        MySource.Add("Muntinlupa")
        MySource.Add("Naga")
        MySource.Add("Navotas")
        MySource.Add("Olongapo")
        MySource.Add("Ormoc")
        MySource.Add("Oroquieta")
        MySource.Add("Ozamiz")
        MySource.Add("Pagadian")
        MySource.Add("Palayan")
        MySource.Add("Panabo")
        MySource.Add("Parañaque")
        MySource.Add("Pasay")
        MySource.Add("Pasig")
        MySource.Add("Passi")
        MySource.Add("Puerto Princesa")
        MySource.Add("Quezon City")
        MySource.Add("Roxas")
        MySource.Add("Sagay")
        MySource.Add("Samal")
        MySource.Add("San Carlos")
        MySource.Add("San Fernando")
        MySource.Add("San Jose")
        MySource.Add("San Jose del Monte")
        MySource.Add("San Juan")
        MySource.Add("San Pablo")
        MySource.Add("San Pedro")
        MySource.Add("Santa Rosa")
        MySource.Add("Santiago")
        MySource.Add("Silay")
        MySource.Add("Sipalay")
        MySource.Add("Sorsogon City")
        MySource.Add("Surigao City")
        MySource.Add("Tabaco")
        MySource.Add("Tabuk")
        MySource.Add("Tacloban")
        MySource.Add("Tacurong")
        MySource.Add("Tagaytay")
        MySource.Add("Tagbilaran")
        MySource.Add("Taguig")
        MySource.Add("Tagum")
        MySource.Add("Talisay")
        MySource.Add("Tanauan")
        MySource.Add("Tandag")
        MySource.Add("Tangub")
        MySource.Add("Tanjay")
        MySource.Add("Tarlac City")
        MySource.Add("Tayabas")
        MySource.Add("Toledo")
        MySource.Add("Trece Martires")
        MySource.Add("Tuguegarao")
        MySource.Add("Urdaneta")
        MySource.Add("Valencia")
        MySource.Add("Valenzuela")
        MySource.Add("Victorias")
        MySource.Add("Vigan")
        MySource.Add("Zamboanga City")
    End Sub

    Private Sub txtCity_Leave(sender As Object, e As EventArgs) Handles txtCity.Leave
        If txtCity.Text.Length > 0 Then
            txtCity.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtCity.Text.ToLower())
        End If
    End Sub

    Private Sub txtSupplier_Leave(sender As Object, e As EventArgs) Handles txtSupplier.Leave
        If txtSupplier.Text.Length > 0 Then
            txtSupplier.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtSupplier.Text.ToLower())
        End If
    End Sub
End Class