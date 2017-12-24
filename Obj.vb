Public Class Obj
    Private lValue As Long
    Private strName As String
    Private lID As Long


    Public Property ID() As Long
        Get
            Return lID
        End Get
        Set(ByVal value As Long)
            lID = value
        End Set
    End Property

    Public Property Value() As Long
        Get
            Return lValue
        End Get
        Set(ByVal value As Long)
            lValue = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return strName
        End Get
        Set(ByVal value As String)
            strName = value
        End Set
    End Property

    Public Sub New(ByVal strName As String, ByVal lValue As Long)
        Value = lValue
        Name = strName
    End Sub

    Public Sub New()

    End Sub

End Class

Public Class ColObjects
    Inherits CollectionBase

    Public Sub Add(ByVal oObj As obj)
        List.Add(oObj)
    End Sub

    Public Sub remove(ByVal oObj As obj)
        List.Remove(oObj)
    End Sub

    Public Sub Insert(ByVal oObj As obj, ByVal index As Integer)
        List.Insert(index, oObj)
    End Sub

End Class
