Public Class User

    Private lId As Long
    Private strUserName As String
    Private strPassword As String
    Public IsAccountManager As Boolean
    Public lAccountManager As Integer
    'Public oColRoles As New ColRole



    Public Property Id() As Long
        Get
            Return lId
        End Get
        Set(ByVal value As Long)
            lId = value
        End Set
    End Property

    Public Property UserName() As String
        Get
            Return strUserName
        End Get
        Set(ByVal value As String)
            strUserName = value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return strPassword
        End Get
        Set(ByVal value As String)
            strPassword = value
        End Set
    End Property

    Public Property AccountManager() As Integer
        Get
            Return lAccountManager
        End Get
        Set(ByVal value As Integer)
            lAccountManager = value
        End Set
    End Property

    Public Sub setProperties(ByVal dr As DataRow, ByVal dt As DataTable)
        ' Dim oRol As Role

        Try
            '  Me.oColRoles.Clear()
            Id = CLng(dr.Item("id"))
            If Not dr.Item("UserName") Is DBNull.Value Then
                UserName = dr.Item("UserName").ToString
            End If
            If Not dr.Item("Password") Is DBNull.Value Then
                Password = dr.Item("Password").ToString
            End If
            If Not dr.Item("isAccountManager") Is DBNull.Value Then
                IsAccountManager = CBool(dr.Item("isAccountManager"))
            End If
            If Not dr.Item("FK_AccountManager") Is DBNull.Value Then
                lAccountManager = CInt(dr.Item("FK_AccountManager"))
            End If

            'fill roles
            'If dt.Rows.Count > 0 Then
            '    For Each dr2 As DataRow In dt.Rows
            '        If CLng(dr2.Item("fk_User")) = Me.Id Then
            '            oRol = New Role
            '            oRol.ID = CLng(dr2.Item("fk_role"))
            '            Me.oColRoles.Add(oRol)
            '        End If
            '    Next
            'End If
        Catch ex As Exception

        End Try

    End Sub
    '    Public Sub setProperties(ByVal dr As DataRow)
    '        Try
    '            For Each dr In ds.Tables(0).Rows
    '                Me.Id = CLng(dr.Item("id"))
    '                If Not dr.Item("UserName") Is DBNull.Value Then
    '                    Me.UserName = dr.Item("UserName").ToString
    '                End If
    '                If Not dr.Item("Password") Is DBNull.Value Then
    '                    Me.Password = dr.Item("Password").ToString
    '                End If

    '                fill(roles)
    '                If ds.Tables.Count = 2 AndAlso ds.Tables(1).Rows.Count > 0 Then
    '                    For Each dr2 In ds.Tables(1).Rows
    '                        If CLng(dr2.Item("fk_User")) = Me.Id Then
    '                            oRol = New Role
    '                            oRol.ID = CLng(dr2.Item("fk_role"))
    '                            Me.oColRoles.Add(oRol)
    '                        End If
    '                    Next
    '                End If
    '            Next

    '        Catch ex As Exception

    '        End Try
    '    End Sub

End Class

Public Class ColUser
    Inherits CollectionBase

    Public Sub Add(ByVal oUser As User)
        List.Add(oUser)
    End Sub

    Public Sub SetProperties(ByVal ds As DataSet)
        Dim dr As DataRow
        Dim oUser As User
        Try
            For Each dr In ds.Tables(0).Rows
                oUser = New User
                oUser.setProperties(dr, ds.Tables(1))
                Add(oUser)
            Next
        Catch ex As Exception

        End Try
    End Sub

End Class