Imports Newtonsoft.Json.Linq
Imports System.Text


Public Class frmMain


    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        oTCPConnection = New TCPControl
    End Sub


    Private Sub ImportNewRatesNotificationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportNewRatesNotificationsToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmImportTPOffer).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmImportOffer") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmImportTPOffer(Enumerators.OPTP.TP, Enumerators.Rate_Notification_Status.Temperory)
            frm.Show()
        End If
    End Sub

    Private Sub ViewCompanyPointsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewCompanyPointsToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of FrmClientsPoints).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmClientsPoints") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New FrmClientsPoints
            frm.Show()
        End If
    End Sub

    Private Sub AddCompanyPointToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Application.OpenForms().OfType(Of frmAddClientPoint).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmAddClientPoint") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmAddClientPoint(Enumerators.EditAdd.Add)
            frm.Show()
        End If
    End Sub

    Private Sub NotificationReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotificationReportToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmCompare).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmCompare") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmCompare(Enumerators.OPTP.TP)
            frm.Show()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        'Dim oJsonAPI As New JsonAPI
        'oJsonAPI.maple_tps_get()
        'Dim o As New jsonnn
        'o.Main()
        Dim otst As New APIFunctions

        otst.GetTPRates(172)
        ' otst.GetTPTariffs()

    End Sub

    Private Sub GetActualRatesFromMediaCoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GetActualRatesFromMediaCoreToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmGetActualFromMC).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmGetActualFromMC") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmGetActualFromMC(Enumerators.OPTP.TP)
            frm.Show()
        End If
    End Sub

    Private Sub ImportActualRatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportActualRatesToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmImportTPOffer_Actual).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmImportTPOffer_Actual") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmImportTPOffer_Actual(Enumerators.OPTP.TP, Enumerators.Rate_Notification_Status.Current)
            frm.Show()

        End If
    End Sub

    Private Sub ClientsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientsToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmCompanies).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmCompanies") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmCompanies
            frm.Show()
        End If
    End Sub

    Private Sub TypesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TypesToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmCompanyPointsTypes).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmCompanyPointsTypes") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmCompanyPointsTypes
            frm.Show()
        End If
    End Sub

    Private Sub ViewTemperoryNotificationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewTemperoryNotificationsToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmTPRatesNotifications).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmTPRatesNotifications") Then
                    frm.WindowState = FormWindowState.Maximized
                End If
            Next
        Else
            Dim frm As New frmTPRatesNotifications
            frm.Show()
        End If
    End Sub

    Private Sub NewTariffsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewTariffsToolStripMenuItem.Click

        oTCPConnection.Send("SyncTariffs|")
        'Dim oAPIFunctions As New APIFunctions
        'Dim jsonObject As JObject
        'Dim sql As New StringBuilder

        ''1- sync TP Tariffs
        'jsonObject = oAPIFunctions.GetOPTPTariffs(Enumerators.OPTP.TP)

        'If Not jsonObject Is Nothing Then
        '    odbaccess.syncTariffTable(Enumerators.OPTP.TP, jsonObject)
        'End If

        ''2- sync OP Tariffs
        'jsonObject = oAPIFunctions.GetOPTPTariffs(Enumerators.OPTP.OP)

        'If Not jsonObject Is Nothing Then
        '    If odbaccess.syncTariffTable(Enumerators.OPTP.OP, jsonObject) Then
        '        MsgBox("Data was syncronized successfully.")
        '    End If
        'End If
    End Sub

    Private Sub GetNewCompaniesFromToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GetNewCompaniesFromToolStripMenuItem.Click

        oTCPConnection.Send("SyncCompanies|")

        'Dim oAPIFunctions As New APIFunctions
        'Dim jsonObject As JObject

        'jsonObject = oAPIFunctions.GetClients()

        'If Not jsonObject Is Nothing Then
        '    If odbaccess.syncClientsTable(jsonObject) Then
        '        MsgBox("Data was syncronized successfully.")
        '    End If
        'End If
    End Sub

    Private Sub ManagersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManagersToolStripMenuItem.Click
        oTCPConnection.Send("SyncManagers|")

        'Dim oAPIFunctions As New APIFunctions
        'Dim jsonObject As JObject

        'jsonObject = oAPIFunctions.GetManagers()

        'If Not jsonObject Is Nothing Then
        '    If odbaccess.syncManagersTable(jsonObject) Then
        '        MsgBox("Data was syncronized successfully.")
        '    End If
        'End If
    End Sub

    Private Sub NewCompanyPointToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewCompanyPointToolStripMenuItem.Click

        'oTCPConnection.Send("SyncCompaniesPoints|")
        oTCPConnection.Send("SyncCompaniesPoints|")

        'Dim oAPIFunctions As New APIFunctions
        'Dim jsonObject As JObject
        'Dim sql As New StringBuilder

        ''1- sync TP Tariffs
        'jsonObject = oAPIFunctions.GetOPTPCompaniesPoints(Enumerators.OPTP.TP)

        'If Not jsonObject Is Nothing Then
        '    odbaccess.syncCompaniesPointsTable(Enumerators.OPTP.TP, jsonObject)
        'End If

        ''2- sync OP Tariffs
        'jsonObject = oAPIFunctions.GetOPTPCompaniesPoints(Enumerators.OPTP.OP)

        'If Not jsonObject Is Nothing Then
        '    If odbaccess.syncCompaniesPointsTable(Enumerators.OPTP.OP, jsonObject) Then
        '        MsgBox("Data was syncronized successfully.")
        '    End If

        'End If
    End Sub

    Private Sub ConnectToServerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectToServerToolStripMenuItem.Click
        oTCPConnection.ConnectToServer()
        'If oTCPConnection.Then Then
        '    MsgBox("Connected to server sucsessfully.")
        'Else
        '    MsgBox("Cannot connect to server." & vbCrLf & "Please check if the server is running.")
        'End If
    End Sub
End Class
