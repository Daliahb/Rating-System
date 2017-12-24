
''Code to Send Http JSON POST request
''Get the response from the server

Imports System.Net
Imports Newtonsoft.Json.Linq
Imports System.IO


Public Class APIFunctions

    Private Function PostJSON(ByVal JsonData As String, strAPIFunction As String) As HttpWebRequest
        Dim objhttpWebRequest As HttpWebRequest
        Try
            Dim httpWebRequest = DirectCast(WebRequest.Create("http://88.198.187.146:8070/api/" & strAPIFunction & "/"), HttpWebRequest)
            httpWebRequest.ContentType = "text/json"
            httpWebRequest.Method = "POST"

            System.Net.ServicePointManager.Expect100Continue = False

            Using streamWriter = New StreamWriter(httpWebRequest.GetRequestStream())
                streamWriter.Write(JsonData)
                streamWriter.Flush()
                streamWriter.Close()
            End Using

            objhttpWebRequest = httpWebRequest

        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & ex.StackTrace)

            Return Nothing
        End Try

        Return objhttpWebRequest
    End Function

    Private Function GetResponse(ByVal httpWebRequest As HttpWebRequest) As String
        Dim strResponse As String = "Bad Request:400"
        Try
            Dim httpResponse = DirectCast(httpWebRequest.GetResponse(), HttpWebResponse)
            Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                Dim result = streamReader.ReadToEnd()

                strResponse = result.ToString()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Return strResponse

    End Function

    Sub getSessionID()
        Dim JsonData As String = "{""login"":""dalia"",""password"":""12345678"",""ip"":""79.134.147.175""}"
        Dim strAPIFunction As String = "login"
        Dim myRequest As HttpWebRequest = PostJSON(JsonData, strAPIFunction)

        '   Console.WriteLine("Response of Request:{0}", GetResponse(myRequest))
        Dim strResponseJSON As String = GetResponse(myRequest)
        '  Dim strJson As String = File.ReadAllText("maple_ops_get.json")
        Dim jsonObject As JObject = JObject.Parse(strResponseJSON)

        If Not jsonObject.SelectToken("session_id") Is Nothing Then
            gAPISessionID = jsonObject.SelectToken("session_id").ToString
        End If

        '  MsgBox(gAPISessionID)

    End Sub

    Sub actual_session_get()

        Dim JsonData As String = "{""login"":""dalia"",""password"":""12345678"",""ip"":""79.134.147.175"",""session_id"":" & gAPISessionID & "}"
        Dim strAPIFunction As String = "actual_session_get"
        Dim myRequest As HttpWebRequest = PostJSON(JsonData, strAPIFunction)

        Dim strResponseJSON As String = GetResponse(myRequest)

        Dim jsonObject As JObject = JObject.Parse(strResponseJSON)

        If Not jsonObject.SelectToken("session_id") Is Nothing Then
            gAPISessionID = jsonObject.SelectToken("session_id").ToString
        End If

        MsgBox(gAPISessionID)

    End Sub

    Function GetTPRates(lTariffID As Long) As JObject
        If gAPISessionID = Nothing Then
            getSessionID()
        End If

        Dim oJsonAPI As New JsonAPI
        Dim JsonData As String = oJsonAPI.GetTpPriceListJSON(lTariffID)
        Dim strAPIFunction As String = "prices_list_get"
        Dim myRequest As HttpWebRequest = PostJSON(JsonData, strAPIFunction)

        Dim strResponseJSON As String = GetResponse(myRequest)

        Dim jsonObject As JObject = JObject.Parse(strResponseJSON)

        If Not jsonObject.SelectToken("status") Is Nothing Then
            If jsonObject.SelectToken("status").ToString = "401" Then
                gAPISessionID = Nothing
                GetTPRates(lTariffID)
            ElseIf jsonObject.SelectToken("status").ToString = "200" Then
                Return jsonObject
            Else
                MsgBox(jsonObject.ToString)
            End If
        End If
        Return Nothing
        ''MsgBox(jsonObject.ToString)
    End Function

    Function GetOPTPTariffs(enumOPTP As Enumerators.OPTP) As JObject
        If gAPISessionID = Nothing Then
            getSessionID()
        End If
        Dim strAPIFunction As String
        Dim oJsonAPI As New JsonAPI
        Dim JsonData As String = oJsonAPI.GetOPTPTariffJSON()
        If enumOPTP = Enumerators.OPTP.OP Then
            strAPIFunction = "tariffs_op_get"
        Else
            strAPIFunction = "tariffs_tp_get"
        End If

        Dim myRequest As HttpWebRequest = PostJSON(JsonData, strAPIFunction)

        ' strAPIFunction = GetResponse(myRequest)

        Dim strResponseJSON As String = GetResponse(myRequest)

        Dim jsonObject As JObject = JObject.Parse(strResponseJSON)

        If Not jsonObject.SelectToken("status") Is Nothing Then
            If jsonObject.SelectToken("status").ToString = "401" Then
                gAPISessionID = Nothing
                GetOPTPTariffs(enumOPTP)
            ElseIf jsonObject.SelectToken("status").ToString = "200" Then
                Return jsonObject
            Else
                MsgBox(jsonObject.ToString)
            End If
        End If
        Return Nothing
        ''MsgBox(jsonObject.ToString)
    End Function

    Function GetClients() As JObject
        If gAPISessionID = Nothing Then
            getSessionID()
        End If

        Dim oJsonAPI As New JsonAPI
        Dim JsonData As String = oJsonAPI.getClientsJSON()

        Dim myRequest As HttpWebRequest = PostJSON(JsonData, "client_get")

        Dim strResponseJSON As String = GetResponse(myRequest)

        Dim jsonObject As JObject = JObject.Parse(strResponseJSON)

        If Not jsonObject.SelectToken("status") Is Nothing Then
            If jsonObject.SelectToken("status").ToString = "401" Then
                gAPISessionID = Nothing
                GetClients()
            ElseIf jsonObject.SelectToken("status").ToString = "200" Then
                Return jsonObject
            Else
                MsgBox(jsonObject.ToString)
            End If
        End If
        Return Nothing

    End Function

    Function GetManagers() As JObject
        If gAPISessionID = Nothing Then
            getSessionID()
        End If

        Dim oJsonAPI As New JsonAPI
        Dim JsonData As String = oJsonAPI.getManagersJSON()

        Dim myRequest As HttpWebRequest = PostJSON(JsonData, "manager_get")

        Dim strResponseJSON As String = GetResponse(myRequest)

        Dim jsonObject As JObject = JObject.Parse(strResponseJSON)

        If Not jsonObject.SelectToken("status") Is Nothing Then
            If jsonObject.SelectToken("status").ToString = "401" Then
                gAPISessionID = Nothing
                GetManagers()
            ElseIf jsonObject.SelectToken("status").ToString = "200" Then
                Return jsonObject
            Else
                MsgBox(jsonObject.ToString)
            End If
        End If
        Return Nothing

    End Function

    Function GetOPTPCompaniesPoints(enumOPTP As Enumerators.OPTP) As JObject
        If gAPISessionID = Nothing Then
            getSessionID()
        End If
        Dim strAPIFunction As String
        Dim oJsonAPI As New JsonAPI
        Dim JsonData As String = oJsonAPI.getCompaniesPointsJSON()
        If enumOPTP = Enumerators.OPTP.OP Then
            strAPIFunction = "ops_get"
        Else
            strAPIFunction = "tps_get"
        End If

        Dim myRequest As HttpWebRequest = PostJSON(JsonData, strAPIFunction)

        ' strAPIFunction = GetResponse(myRequest)

        Dim strResponseJSON As String = GetResponse(myRequest)

        Dim jsonObject As JObject = JObject.Parse(strResponseJSON)

        If Not jsonObject.SelectToken("status") Is Nothing Then
            If jsonObject.SelectToken("status").ToString = "401" Then
                gAPISessionID = Nothing
                GetOPTPTariffs(enumOPTP)
            ElseIf jsonObject.SelectToken("status").ToString = "200" Then
                Return jsonObject
            Else
                MsgBox(jsonObject.ToString)
            End If
        End If
        Return Nothing
        ''MsgBox(jsonObject.ToString)
    End Function

End Class
