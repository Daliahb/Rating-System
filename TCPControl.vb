Imports System.Net, System.Net.Sockets

Public Class TCPControl

    Public Event ActualRatesMsg(sender As TCPControl, Data As String)

    Dim clientSocket As Socket
    Dim byteData(1023) As Byte

    Public Sub New()
        Try
            ConnectToServer()
        Catch ex As Exception

        End Try

    End Sub

    Public Function ConnectToServer() As Boolean
        Try
            clientSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            Dim ipAddress As IPAddress = IPAddress.Parse(My.Settings.APIServerIP)
            Dim ipEndPoint As IPEndPoint = New IPEndPoint(ipAddress, 8800)
            clientSocket.BeginConnect(ipEndPoint, New AsyncCallback(AddressOf OnConnect), Nothing)

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Sub OnConnect(ByVal ar As IAsyncResult)
        Try
            If Not clientSocket.Connected Then
                clientSocket.EndConnect(ar)
                clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None,
                                          New AsyncCallback(AddressOf OnRecieve), clientSocket)
            End If
        Catch ex As Exception
            MsgBox("API server is not connected!")
        End Try

    End Sub

    Private Sub OnRecieve(ByVal ar As IAsyncResult)
        Dim client As Socket = ar.AsyncState
        Try
            client.EndReceive(ar)
            Dim bytesRec As Byte() = byteData
            Dim message As String = System.Text.ASCIIEncoding.ASCII.GetString(bytesRec)
            Read(message)
            clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None,
                                      New AsyncCallback(AddressOf OnRecieve), clientSocket)
        Catch ex As Exception
            MsgBox("API server is not connected!")
        End Try

    End Sub
    Delegate Sub _Read(ByVal msg As String)
    Private Sub Read(ByVal msg As String)
        'If InvokeRequired Then
        '    Invoke(New _Read(AddressOf Read), msg)
        '    Exit Sub
        'End If
        '  RichTextBox1.Text &= msg
        Dim arMSG As Array = msg.Split("|")
        If Not arMSG.Length = 0 Then
            Select Case arMSG(0)
                Case "GetActualRates" ' Get TP Rates
                    'MsgBox(msg)
                    RaiseEvent ActualRatesMsg(Me, arMSG(1))
                Case "" 'Get OP RAtes

                Case "SyncCompanies" 'Sync Companies
                    MsgBox("Data was syncronized successfully.")

                Case "SyncCompaniesPoints" 'Sync Companies
                    MsgBox("Data was syncronized successfully.")

                Case "SyncTariffs" 'Sync Companies
                    MsgBox("Data was syncronized successfully.")

                Case "SyncCompaniesPoints" 'Sync Companies
                    MsgBox("Data was syncronized successfully.")

                Case "SyncManagers" 'Sync Companies
                    MsgBox("Data was syncronized successfully.")
            End Select
        End If

    End Sub

    Public Sub Send(ByVal msg As String)
        Try
            If clientSocket.Connected Then
                Dim sendBytes As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(msg)
                clientSocket.BeginSend(sendBytes, 0, sendBytes.Length, SocketFlags.None, New AsyncCallback(AddressOf OnSend), clientSocket)
                'Else
                '    ConnectToServer()
                '    Send(msg)
            Else
                MsgBox("API server is not connected!")
            End If

        Catch ex As Exception
            MsgBox("API server is not connected!")
        End Try

    End Sub
    Private Sub OnSend(ByVal ar As IAsyncResult)
        Dim client As Socket = ar.AsyncState
        client.EndSend(ar)
        ' client.sendDone.Set()
    End Sub
End Class
