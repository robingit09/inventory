Public Class Settings
    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If ModuleSettings.getDBSetup = 1 Then
            testYes.Checked = True
        Else
            testNo.Checked = True
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        insertForTesting()
        If ModuleSettings.getDBSetup = 1 Then
            Main_form.lblTest.Visible = True
        Else
            Main_form.lblTest.Visible = False
        End If
        MsgBox("Settings sucessfully update.", MsgBoxStyle.Information)
    End Sub

    Private Sub insertForTesting()
        Dim y As Integer = 0

        If testYes.Checked = True Then
            y = 1
        Else
            y = 0
        End If
        doQuery("UPDATE settings set for_testing = " & y)


    End Sub
End Class