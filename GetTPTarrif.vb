Public Class GetTPTarrif

    Public Function GetTPTarrifJSON(lTeriffID As Long) As String

        Return "{""session_id"":" & gAPISessionID & ", ""data"":{""limit"":17,            	 ""sort_by"":[{""destination"":""""},{""added"":""desc""}],                     
	 ""tariff_id"":" & lTeriffID & ",                     
	 ""offset"":0,                     
	 ""service_id"":1,                     
	 ""fields"":[""id"",""tariff_id"",""enabled"",""allowed"",""description"",""destination"",""price"",""connection_price"",""mc"",""ci"",""ft"",""priority"",                               ""date_start"",""date_end"",""time_start"",""time_end"",""added"",""date_for_history"",""min_len"",""max_len"",""week_day"",""country""],""destination"":""""}
 } "
    End Function


End Class
