
Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json.Linq


Public Class DBAccess
    Dim oSelectCommand As New MySqlCommand
    Dim oParam As New MySqlParameter
    Dim oDataAdapter As New MySqlDataAdapter
    Public oConnection As New MySqlConnection
    ' Public oTrans As SqlClient.SqlTransaction
    Public oTrans As MySqlTransaction


    Public ds As DataSet
    Public sql As String

    Public Sub New()
        'Real Online  DB
        '  oConnection.ConnectionString = "server=mapleteletech-tools.cyhrjka02xij.eu-west-1.rds.amazonaws.com;port=3337;User Id=maple_db_user;Password=5skqi5ygv3ciiBF9LDf362uW;Persist Security Info=True;database=voip_billing_system"

        'Test  DB
        oConnection.ConnectionString = "server=mapleteletech-tools.cyhrjka02xij.eu-west-1.rds.amazonaws.com;port=3337;User Id=maple_db_user_dev;Password=xee1lahnaeyoa0iethaeJoo7;Persist Security Info=True;database=voip_billing_system_dev"


    End Sub

#Region "import"

    Public Function GetTPRateNotificationID(lClientID As Integer, lClientPointID As Integer, lTariffID As Integer, enumFullPartial As Integer, dDate As DateTime, isItConfirmation As Boolean, enumStatus As Enumerators.Rate_Notification_Status) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand With {
                .CommandType = System.Data.CommandType.StoredProcedure,
                .CommandText = "r_get_TP_RateNotification_ID"
            }

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lClientID"
                .Value = lClientID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lClientPointID"
                .Value = lClientPointID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lTariffID"
                .Value = lTariffID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "enumFullPartial"
                .Value = enumFullPartial
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dDate"
                .Value = dDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "isItConfirmation"
                .Value = isItConfirmation
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "intStatus"
                .Value = enumStatus
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function ExecuteQuery(strSQL As String) As Boolean
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand With {
                .CommandType = System.Data.CommandType.Text,
                .CommandText = strSQL,
                .Connection = oConnection
            }

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try

    End Function

    Public Function syncTariffTable(enumOPTP As Enumerators.OPTP, jsonObject As JObject) As Boolean
        Dim sql As New System.Text.StringBuilder
        Dim lId As Long
        Dim strTariffName As String
        Dim boolError, isEnabled As Boolean

        sql = New System.Text.StringBuilder
        sql.Append("insert into r_tariffs_dummy(`id`,`TariffName`,`enumOPTP`,`Enabled`) values ")

        Dim jsonArray As JArray = JArray.Parse(jsonObject.SelectToken("data").ToString)
        For Each item As JArray In jsonArray
            lId = CLng(item(0))
            strTariffName = item(1).ToString
            enumOPTP = enumOPTP
            isEnabled = Not CBool(item(2))
            sql.Append("(" & lId & ",'" & strTariffName & "','" & enumOPTP & "','" & isEnabled & "'),")

        Next
        boolError = odbaccess.ExecuteQuery(sql.ToString.Substring(0, sql.ToString.Length - 1))

        If boolError = False Then

            MsgBox("An error occured!")
            Return False
        End If

        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand With {
                .CommandType = CommandType.StoredProcedure,
                .CommandText = "r_syncTariffTable",
                .Connection = oConnection
            }

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "intOPTP"
                .Value = enumOPTP
            End With
            oSelectCommand.Parameters.Add(oParam)

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False
        End Try

    End Function

    Public Function syncClientsTable(jsonObject As JObject) As Boolean
        Dim sql As New System.Text.StringBuilder
        Dim lId As Long
        Dim intManagerID As Integer
        Dim strName, strEmail, strPhone, strAddress As String
        Dim boolError, isEnabled As Boolean

        sql = New System.Text.StringBuilder
        sql.Append("insert into r_clients_dummy(`ID`,`Name`,`Email`,`Address`,`Manager_id`,`Phone`,`Enabled`) values ")

        Dim jsonArray As JArray = JArray.Parse(jsonObject.SelectToken("data").ToString)
        For Each item As JArray In jsonArray
            lId = CLng(item(0))
            strName = item(1).ToString
            strEmail = item(2).ToString
            intManagerID = CInt(item(4))
            strPhone = item(5).ToString
            strAddress = item(3).ToString
            isEnabled = Not CBool(item(6))
            sql.Append("(" & lId & ",'" & strName & "','" & strEmail & "','" & strAddress & "','" & intManagerID & "','" & strPhone & "','" & isEnabled & "'),")

        Next
        boolError = odbaccess.ExecuteQuery(sql.ToString.Substring(0, sql.ToString.Length - 1))

        If boolError = False Then

            MsgBox("An error occured!")
            Return False
        End If

        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand With {
                .CommandType = CommandType.StoredProcedure,
                .CommandText = "r_syncClientTable",
                .Connection = oConnection
            }

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False
        End Try

    End Function

    Public Function syncManagersTable(jsonObject As JObject) As Boolean
        Dim sql As New System.Text.StringBuilder
        Dim lId As Long
        Dim strName As String
        Dim boolError As Boolean

        sql = New System.Text.StringBuilder
        sql.Append("truncate table r_managers; insert into r_managers(`ID`,`Name`) values ")

        Dim jsonArray As JArray = JArray.Parse(jsonObject.SelectToken("data").ToString)
        For Each item As JArray In jsonArray
            lId = CLng(item(0))
            strName = item(1).ToString

            sql.Append("(" & lId & ",'" & strName & "'),")

        Next
        boolError = odbaccess.ExecuteQuery(sql.ToString.Substring(0, sql.ToString.Length - 1))

        If boolError = False Then

            MsgBox("An error occured!")
            Return False
        End If

        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand With {
                .CommandType = CommandType.StoredProcedure,
                .CommandText = "r_syncManagersTable",
                .Connection = oConnection
            }

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False
        End Try

    End Function


    Public Function syncCompaniesPointsTable(enumOPTP As Enumerators.OPTP, jsonObject As JObject) As Boolean
        Dim sql As New System.Text.StringBuilder
        Dim lId, lTariffID, lClientId As Long
        Dim strCompanyPoint, strCompanyCode, strTariffName As String
        Dim boolError, isEnabled As Boolean

        sql = New System.Text.StringBuilder
        sql.Append("insert into r_companies_points_dummy(`ID`,`CompanyPoint`,`CompanyCode`,`FK_Client`,`Enabled`,`FK_Tariff`,`TariffName`,`FK_PointType`,`enumOpTp`) values ")

        Dim jsonArray As JArray = JArray.Parse(jsonObject.SelectToken("data").ToString)
        For Each item As JArray In jsonArray
            lId = CLng(item(0))
            strCompanyPoint = item(1).ToString
            strCompanyCode = item(2).ToString
            lClientId = CLng(item(3))
            isEnabled = Not CBool(item(4))
            Try
                lTariffID = CLng(item(5))
                strTariffName = item(6).ToString
            Catch ex As Exception

            End Try

            sql.Append("(" & lId & ",'" & strCompanyPoint & "','" & strCompanyCode & "'," & lClientId & ",'" & isEnabled & "'," & lTariffID & ",'" & strTariffName & "',0," & enumOPTP & "),")

        Next
        boolError = odbaccess.ExecuteQuery(sql.ToString.Substring(0, sql.ToString.Length - 1))

        If boolError = False Then

            MsgBox("An error occured!")
            Return False
        End If

        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand With {
                .CommandType = CommandType.StoredProcedure,
                .CommandText = "r_syncCompaniesPointsTable",
                .Connection = oConnection
            }

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "intOPTP"
                .Value = enumOPTP
            End With
            oSelectCommand.Parameters.Add(oParam)

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False
        End Try

    End Function

    Public Function FillCountryCode(lNotificationID As Long, enumOPTP As Enumerators.OPTP) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand With {
                .CommandType = CommandType.StoredProcedure,
                .CommandText = "r_FillCountryCode",
                .Connection = oConnection
            }

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lNotificationID"
                .Value = lNotificationID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "OPTP"
                .Value = enumOPTP
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False
        End Try
    End Function

    Public Function SaveProviderDefaults(oProviderDetails As ProviderDefaults) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand With {
                .CommandType = CommandType.StoredProcedure,
                .CommandText = "r_SaveProviderDefaults",
                .Connection = oConnection
            }

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lClientID"
                .Value = oProviderDetails.lClientID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strIncrease"
                .Value = oProviderDetails.strIncrease
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strDecrease"
                .Value = oProviderDetails.strDecrease
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strDelete"
                .Value = oProviderDetails.strDelete
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strSame"
                .Value = oProviderDetails.strSame
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strNew"
                .Value = oProviderDetails.strNew
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strDateFormat"
                .Value = oProviderDetails.strDateFormat
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strCodeCol"
                .Value = oProviderDetails.strCodeCol
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strOperatorCol"
                .Value = oProviderDetails.strOperatorCol
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strRateCol"
                .Value = oProviderDetails.strRateCol
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strStatusCol"
                .Value = oProviderDetails.strStatusCol
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strDateCol"
                .Value = oProviderDetails.strDateCol
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strMC"
                .Value = oProviderDetails.strMCCol
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strCI"
                .Value = oProviderDetails.strCICol
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "intRowNo"
                .Value = oProviderDetails.intRowNo
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function
#End Region

#Region "get"
    Public Function GetClientsDS() As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand With {
                .CommandType = System.Data.CommandType.StoredProcedure,
                .CommandText = "r_GetClientsDS"
            }

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetCompaniesPointsTypes() As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand With {
                .CommandType = System.Data.CommandType.StoredProcedure,
                .CommandText = "r_getPointsTypes"
            }

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetProviderDefaults(lClientID As Long) As ProviderDefaults
        ds = New DataSet
        Dim oProviderDefaults As ProviderDefaults
        Try
            oSelectCommand = New MySqlCommand With {
                .CommandType = System.Data.CommandType.StoredProcedure,
                .CommandText = "r_GetProviderDefaults"
            }

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lClientID"
                .Value = lClientID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                oProviderDefaults = New ProviderDefaults
                oProviderDefaults.FillProperties(ds.Tables(0).Rows(0))
                Return oProviderDefaults
            Else
                Return Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetCompanyPoints(enumOPTP As Enumerators.OPTP, lClientID As Long) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand With {
                .CommandType = System.Data.CommandType.StoredProcedure,
                .CommandText = "r_getCompanyPoints"
            }

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "OPTP"
                .Value = enumOPTP
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lClientID"
                .Value = lClientID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public ReadOnly Property PointsTypes As DataSet
        Get
            ds = New DataSet
            Try
                oSelectCommand = New MySqlCommand With {
                    .CommandType = System.Data.CommandType.StoredProcedure,
                    .CommandText = "r_getPointsTypes"
                }

                oDataAdapter.SelectCommand = oSelectCommand
                oSelectCommand.Connection = oConnection
                oDataAdapter.Fill(ds)
                Return ds
            Catch ex As Exception
                MsgBox(ex.Message & ex.StackTrace)
                Return Nothing
            End Try
        End Get
    End Property

    Public Function GetNotificatonRepot(lClientId As Long, lCompanyPoint As Long, enumOPTP As Enumerators.OPTP) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand With {
                .CommandType = System.Data.CommandType.StoredProcedure
            }

            If enumOPTP = Enumerators.OPTP.OP Then
                oSelectCommand.CommandText = "r_OP_CompareRates"
            Else
                oSelectCommand.CommandText = "r_TP_CompareRates"
            End If


            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lClientId"
                .Value = lClientId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lClientPointId"
                .Value = lCompanyPoint
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetCompaniesPoints(enumOPTP As Enumerators.OPTP, lClientID As Long, lTypeID As Long) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand With {
                .CommandType = System.Data.CommandType.StoredProcedure,
                .CommandText = "r_GetClientsPoints"
            }

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "OPTP"
                .Value = enumOPTP
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lClientID"
                .Value = lClientID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lTypeID"
                .Value = lTypeID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetCompanies(boolCheckStatus As Boolean, boolActive As Boolean) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand With {
                .CommandType = System.Data.CommandType.StoredProcedure,
                .CommandText = "r_GetCompanies"
            }

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "CheckActive"
                .Value = boolCheckStatus
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolActive"
                .Value = boolActive
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetTPRateNotifications(lTariffID As Long, intStatus As Integer, boolDate As Boolean, dFromDate As Date, dToDate As Date) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand With {
                .CommandType = System.Data.CommandType.StoredProcedure,
                .CommandText = "r_GetTPRateNotifications"
            }

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lTariffID"
                .Value = lTariffID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "intStatus"
                .Value = intStatus
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolDate"
                .Value = boolDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dFromDate"
                .Value = dFromDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "dToDate"
                .Value = dToDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetTariffs(enumOPTP As Enumerators.OPTP) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand With {
                .CommandType = System.Data.CommandType.StoredProcedure,
                .CommandText = "r_GetTariffs"
            }

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "intOPTP"
                .Value = enumOPTP
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetTPRatesNotificationDetails(lNotiRateID As Long) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand With {
                .CommandType = System.Data.CommandType.StoredProcedure,
                .CommandText = "r_GetTPRatesDetails"
            }

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lNotiRateID"
                .Value = lNotiRateID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function
#End Region

    Public Function InsertClientPoint(lClientID As Long, intType As Integer, strCompanyPoint As String, enumOPTP As Enumerators.OPTP) As Integer
        Dim intResult As Integer
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand With {
                .CommandType = System.Data.CommandType.StoredProcedure,
                .CommandText = "r_InsertClientPoint",
                .Connection = oConnection
            }

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lClientID"
                .Value = lClientID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "intType"
                .Value = intType
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strCompanyPoint"
                .Value = strCompanyPoint
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "OPTP"
                .Value = enumOPTP
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            intResult = CInt(oSelectCommand.ExecuteScalar)
            oConnection.Close()

            Return intResult
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return 0
        End Try
    End Function

    Public Function EditClientPoint(lID As Long, lClientID As Long, intType As Integer, strCompanyPoint As String, enumOPTP As Enumerators.OPTP) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand With {
                .CommandType = System.Data.CommandType.StoredProcedure,
                .CommandText = "r_EditClientPoint",
                .Connection = oConnection
            }

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lID"
                .Value = lID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lClientID"
                .Value = lClientID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "intType"
                .Value = intType
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strCompanyPoint"
                .Value = strCompanyPoint
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "OPTP"
                .Value = enumOPTP
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return False
        End Try
    End Function

    Public Function ChangeApprovalStatus(lID As Long, boolStatus As Boolean, enumOPTP As Enumerators.OPTP, lNotificationID As Long) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand With {
                .CommandType = System.Data.CommandType.StoredProcedure,
                .CommandText = "r_ChangeMessageApprovalStatus",
                .Connection = oConnection
            }

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lID"
                .Value = lID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "boolStatus"
                .Value = boolStatus
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "OPTP"
                .Value = enumOPTP
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lNotificationID"
                .Value = lNotificationID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return False
        End Try
    End Function

    Public Function EditMCCI(lNotiID As Long, strCode As String, intMC As Integer, intCI As Integer, enumOPTP As Enumerators.OPTP) As Boolean
        Try
            oSelectCommand = New MySql.Data.MySqlClient.MySqlCommand With {
                .CommandType = System.Data.CommandType.StoredProcedure,
                .CommandText = "r_EditMCCI",
                .Connection = oConnection
            }

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lNotiID"
                .Value = lNotiID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "strCode"
                .Value = strCode
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "intMC"
                .Value = intMC
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "intCI"
                .Value = intCI
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "intOPTP"
                .Value = enumOPTP
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySql.Data.MySqlClient.MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return False
        End Try
    End Function


End Class
