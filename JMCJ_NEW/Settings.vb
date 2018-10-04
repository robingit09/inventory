Public Class Settings
    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If ModuleSettings.getDBSetup = 1 Then
            'test mode
            testYes.Checked = True
        Else
            'ready mode
            testNo.Checked = True
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        insertForTesting()
        If ModuleSettings.getDBSetup = 1 Then
            'test mode
            Main_form.lblTest.Visible = True
        Else
            'ready mode
            Main_form.lblTest.Visible = False
        End If
        MsgBox("Settings sucessfully update.", MsgBoxStyle.Information)
    End Sub

    Private Sub insertForTesting()
        Dim y As Integer = 0
        If testYes.Checked = True Then
            y = 1
            My.Computer.FileSystem.CopyFile(
                  Application.StartupPath & "\inventory.mdb",
                   Application.StartupPath & "\inventory_dev.mdb",
                  Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                  Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        Else
            y = 0
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\inventory_dev.mdb")
        End If
        doQuery("UPDATE settings set for_testing = " & y)


    End Sub

    Private Sub btnTruncate_Click(sender As Object, e As EventArgs) Handles btnTruncate.Click
        MsgBox("Warning! All your data will wipeout or reset.", MsgBoxStyle.Exclamation)
        Dim yesno As Integer = MsgBox("Are you sure you want to truncate database ?", MsgBoxStyle.Information + MsgBoxStyle.YesNo)
        If yesno = MsgBoxResult.Yes Then
            ModelFunction.truncateDatabase()
            MsgBox("Database Successfully Truncate.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click

        Dim yesno As Integer = MsgBox("Are you sure you want to backup database ?", MsgBoxStyle.Information + MsgBoxStyle.YesNo)
        If yesno = MsgBoxResult.Yes Then
            If ModuleSettings.getDBSetup = 1 Then
                My.Computer.FileSystem.CopyFile(
                    Application.StartupPath & "\inventory_dev.mdb",
                    "C:\users\inventory_db\inventory_dev_backup.mdb",
                    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
                MsgBox("Database Successfully Backup.", MsgBoxStyle.Information)
            Else
                My.Computer.FileSystem.CopyFile(
                  Application.StartupPath & "\inventory.mdb",
                  "C:\users\inventory_db\inventory_backup.mdb",
                  Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                  Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
                MsgBox("Database Successfully Backup.", MsgBoxStyle.Information)
            End If

        End If

    End Sub
End Class