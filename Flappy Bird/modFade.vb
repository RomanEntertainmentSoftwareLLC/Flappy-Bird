Option Explicit On
Option Strict On

Module modFade
    Public Fade_To_Black As Single
    Public Fade_Out_To_Black_Time As Single
    Public Fade_Out_To_Black_Milliseconds As Single
    Public Fade_Out_To_Black_Speed As Single
    Public Fade_Out_To_Black_Enabled As Boolean
    Public Fade_In_From_Black_Time As Single
    Public Fade_In_From_Black_Milliseconds As Single
    Public Fade_In_From_Black_Speed As Single
    Public Fade_In_From_Black_Enabled As Boolean

    Public Sub Setup_Fade_To_Black()
        Fade_To_Black = 0
        Fade_In_From_Black_Milliseconds = Get_Elapsed_Time()
        Fade_In_From_Black_Enabled = True
        Fade_In_From_Black_Speed = 255
        Fade_Out_To_Black_Speed = 255
    End Sub

    Public Sub Fade_Out_To_Black()
        If Fade_Out_To_Black_Enabled = True And Game_Active = False Then
            Fade_Out_To_Black_Time = Get_Elapsed_Time() - Fade_Out_To_Black_Milliseconds
            Fade_To_Black = 255 - (Fade_Out_To_Black_Speed * Fade_Out_To_Black_Time)
            If Fade_To_Black <= 0 Then
                Fade_To_Black = 0
                Fade_In_From_Black_Milliseconds = Get_Elapsed_Time()
                Get_Ready_Fade_Transparent_Time = Get_Elapsed_Time()
                Fade_Out_To_Black_Enabled = False
                Fade_In_From_Black_Enabled = True
                Get_Ready_Fade_In_Transparent_Enabled = True
                Setup_Sprite()
                Setup_Pipes()
                Setup_Ground()
                Score = 0
                Bounce = 0
                Death = False
                Sprite(0).Angle = 0
                Random_Background = CInt(Rnd() * 1)
                Random_Sprite = CInt(Rnd() * 3)
                Game_Over_Fade_To_Transparent = 0
                Score_Group_Pipes_Flag(0) = False
                Score_Group_Pipes_Flag(1) = False
                Score_Group_Pipes_Flag(2) = False
            End If
        End If

        If Fade_In_From_Black_Enabled = True And Game_Active = False Then
            Fade_In_From_Black_Time = Get_Elapsed_Time() - Fade_In_From_Black_Milliseconds
            Fade_To_Black = (Fade_Out_To_Black_Speed * Fade_In_From_Black_Time)
            If Fade_To_Black >= 255 Then
                Fade_To_Black = 255
                Fade_In_From_Black_Enabled = False
            End If
        End If
    End Sub
End Module
