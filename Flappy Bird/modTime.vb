Option Explicit On
Option Strict On

Module modTime
    Private Declare Function QueryPerformanceCounter Lib "kernel32" (ByRef lpPerformanceCount As Long) As Integer
    Private Declare Function QueryPerformanceFrequency Lib "kernel32" (ByRef lpFrequency As Long) As Integer

    Public Ticks_Per_Second As Long

    Public Sub Hi_Res_Timer_Initialize()
        QueryPerformanceFrequency(Ticks_Per_Second)
    End Sub

    Public Function Get_Elapsed_Time_Per_Frame() As Single
        Static Last_Time As Long
        Static Current_Time As Long

        QueryPerformanceCounter(Current_Time)
        Get_Elapsed_Time_Per_Frame = CSng((Current_Time - Last_Time) / Ticks_Per_Second)
        QueryPerformanceCounter(Last_Time)
    End Function

    Public Function Get_Elapsed_Time() As Single
        Dim Last_Time As Long
        Dim Current_Time As Long

        QueryPerformanceCounter(Current_Time)
        Get_Elapsed_Time = CSng((Current_Time - Last_Time) / Ticks_Per_Second)
        QueryPerformanceCounter(Last_Time)
    End Function
End Module
