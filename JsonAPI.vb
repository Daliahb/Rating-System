Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.IO


Public Class JsonAPI

    Public Sub Maple_tps_get()
        Dim strJson As String = File.ReadAllText("maple_ops_get.json")
        Dim jsonObject As JObject = JObject.Parse(strJson)

        Dim jsonArray As JArray = JArray.Parse(jsonObject.SelectToken("data").ToString)
        Try
            For Each item As JArray In jsonArray
                Console.WriteLine(item(0).ToString & " " & item(1).ToString & " " & item(2).ToString & " " & item(3).ToString & item(4).ToString & " " & item(5).ToString & " " & item(6).ToString & " " & item(7).ToString)
            Next
        Catch ex As Exception

        End Try

    End Sub



    Public Function GetTpPriceListJSON(lTeriffID As Long) As String
        Dim strJSON As String
        strJSON = " {""session_id"":""" & gAPISessionID & """,""data"":{""limit"":""80000"",""is_tp"": true,""actual_prices"": true,""sort_by"":[{""destination"":""""},{""added"":""desc""}],""tariff_id"":""" & lTeriffID & """,""offset"":""0"",""service_id"":""1"",""fields"":[""id"",""tariff_id"",""enabled"",""allowed"",""description"",""destination"",""price"",""connection_price"",""mc"",""ci"",""ft"",""priority"",""date_start"",""date_end"",""time_start"",""time_end"",""added"",""date_for_history"",""min_len"",""max_len"",""week_day"",""country""],""destination"":""""}}"
        Return strJSON
    End Function


    Public Function GetOPTPTariffJSON() As String
        Dim strJSON As String
        strJSON = "{""session_id"":""" & gAPISessionID & """,""data"":{""limit"":80000,""sort_by"":[{""name"":""""}],""offset"":0,""fields"":[""tariff_id"",""name"",""invisible""]}}"
        Return strJSON
    End Function

    Public Function getClientsJSON() As String
        Dim strJSON As String
        strJSON = "{""session_id"":""" & gAPISessionID & """,""data"":{""limit"":80000,""sort_by"":[{""name"":""""}],""offset"":0,""fields"":[""id"",""name"",""email"",""address"",""manager_id"",""phone"",""invisible""]}}"
        Return strJSON
    End Function

    Public Function getManagersJSON() As String
        Dim strJSON As String
        strJSON = "{""session_id"":""" & gAPISessionID & """,""data"":{""limit"":80000,""sort_by"":[{""name"":""""}],""fields"":[""id"",""name""]}}"
        Return strJSON
    End Function

    Public Function getCompaniesPointsJSON() As String
        Dim strJSON As String
        strJSON = "{""session_id"":""" & gAPISessionID & """,""data"":{""limit"":80000,""sort_by"":[{""name"":""""}],""fields"":[""id"",""name"",""client_name"",""client_id"",""enabled"",""tariff_id"",""tariff_name""]}}"
        Return strJSON
    End Function
End Class
