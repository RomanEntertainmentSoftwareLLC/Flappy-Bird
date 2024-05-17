Option Explicit On
Option Strict On

Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D

Module modScore
    Public Score As Integer
    Public Score_Group_Pipes_Flag(2) As Boolean

    Public Score_Texture(9) As Texture
    Public Score_Vertex_List As CustomVertex.TransformedColoredTextured() = New CustomVertex.TransformedColoredTextured(0 To 3) {}
    Public Score_Position As Vector2D

    Public Sub Load_Score_Textures()
        Score_Texture(0) = Load_Texture(Application.StartupPath & "\0.png", Color.FromArgb(255, 0, 255).ToArgb)
        Score_Texture(1) = Load_Texture(Application.StartupPath & "\1.png", Color.FromArgb(255, 0, 255).ToArgb)
        Score_Texture(2) = Load_Texture(Application.StartupPath & "\2.png", Color.FromArgb(255, 0, 255).ToArgb)
        Score_Texture(3) = Load_Texture(Application.StartupPath & "\3.png", Color.FromArgb(255, 0, 255).ToArgb)
        Score_Texture(4) = Load_Texture(Application.StartupPath & "\4.png", Color.FromArgb(255, 0, 255).ToArgb)
        Score_Texture(5) = Load_Texture(Application.StartupPath & "\5.png", Color.FromArgb(255, 0, 255).ToArgb)
        Score_Texture(6) = Load_Texture(Application.StartupPath & "\6.png", Color.FromArgb(255, 0, 255).ToArgb)
        Score_Texture(7) = Load_Texture(Application.StartupPath & "\7.png", Color.FromArgb(255, 0, 255).ToArgb)
        Score_Texture(8) = Load_Texture(Application.StartupPath & "\8.png", Color.FromArgb(255, 0, 255).ToArgb)
        Score_Texture(9) = Load_Texture(Application.StartupPath & "\9.png", Color.FromArgb(255, 0, 255).ToArgb)
    End Sub

    Public Sub Draw_Score()
        Device.VertexFormat = CustomVertex.TransformedColoredTextured.Format

        Dim Score_String As String = CStr(Score)
        Dim Score_Char() As Char = Score_String.ToCharArray
        Dim I As Integer

        Dim Fade_Color As Integer = CInt(Fade_To_Black)

        For I = 1 To Score_String.Length
            Score_Position = New Vector2D(CSng((Window_Width / 2) - ((Score_String.Length * 35) / 2)), 50)
            Score_Vertex_List(0) = Create_Custom_Vertex(Score_Position.X + ((I - 1) * 35), Score_Position.Y, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 0)
            Score_Vertex_List(1) = Create_Custom_Vertex(Score_Position.X + (35 * I), Score_Position.Y, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 0)
            Score_Vertex_List(2) = Create_Custom_Vertex(Score_Position.X + ((I - 1) * 35), Score_Position.Y + 50, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 1)
            Score_Vertex_List(3) = Create_Custom_Vertex(Score_Position.X + (35 * I), Score_Position.Y + 50, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 1)

            If Score_Char(I - 1) = "0" Then Device.SetTexture(0, Score_Texture(0))
            If Score_Char(I - 1) = "1" Then Device.SetTexture(0, Score_Texture(1))
            If Score_Char(I - 1) = "2" Then Device.SetTexture(0, Score_Texture(2))
            If Score_Char(I - 1) = "3" Then Device.SetTexture(0, Score_Texture(3))
            If Score_Char(I - 1) = "4" Then Device.SetTexture(0, Score_Texture(4))
            If Score_Char(I - 1) = "5" Then Device.SetTexture(0, Score_Texture(5))
            If Score_Char(I - 1) = "6" Then Device.SetTexture(0, Score_Texture(6))
            If Score_Char(I - 1) = "7" Then Device.SetTexture(0, Score_Texture(7))
            If Score_Char(I - 1) = "8" Then Device.SetTexture(0, Score_Texture(8))
            If Score_Char(I - 1) = "9" Then Device.SetTexture(0, Score_Texture(9))

            Device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, Score_Vertex_List)
        Next I
    End Sub

    Public Sub Update_Score()
        If Game_Active = True Then
            If Score_Group_Pipes_Flag(0) = False Then
                If (Pipe_Position(0).X - 38) < Sprite(0).Physics.Position.X Then
                    Score_Group_Pipes_Flag(0) = True
                    Play_Sound(Sound_Buffer(2))
                    Score += 1
                End If
            End If
            If Score_Group_Pipes_Flag(1) = False Then
                If (Pipe_Position(2).X - 38) < Sprite(0).Physics.Position.X Then
                    Score_Group_Pipes_Flag(1) = True
                    Play_Sound(Sound_Buffer(2))
                    Score += 1
                End If
            End If
            If Score_Group_Pipes_Flag(2) = False Then
                If (Pipe_Position(4).X - 38) < Sprite(0).Physics.Position.X Then
                    Score_Group_Pipes_Flag(2) = True
                    Play_Sound(Sound_Buffer(2))
                    Score += 1
                End If
            End If
        End If
    End Sub

    Public Sub Unload_Score_Textures()
        Dim Current_Texture As Integer

        For Current_Texture = 0 To 9
            If Score_Texture(Current_Texture) IsNot Nothing Then
                Score_Texture(Current_Texture).Dispose() : Score_Texture(Current_Texture) = Nothing
            End If
        Next Current_Texture
    End Sub
End Module
