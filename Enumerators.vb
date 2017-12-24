Public Class Enumerators

    Public Enum EditAdd
        Edit
        Add
    End Enum

    Public Enum CodeType
        TDM = 1
        CLI = 2
        Non_CLI = 3
    End Enum

    Public Enum FullPartial
        Full = 1
        Partially = 2
    End Enum

    Public Enum Rate_Notification_Status
        Temperory = 1
        Current = 2
        Temp_To_History = 3
        Current_To_History = 4
    End Enum

    Public Enum OPTP
        OP = 1
        TP = 2
    End Enum

    Public Enum IncreaseDecrease
        Increase = 1
        Decrease = 2
    End Enum

    Public Enum CodeStatus
        NoChange = 100
        Added_New = 101
        Deleted = 102
        Blocked = 103
        Increased = 104
        Decreased = 105
    End Enum
End Class
