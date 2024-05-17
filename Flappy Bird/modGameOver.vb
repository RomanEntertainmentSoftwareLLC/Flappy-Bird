Option Explicit On
Option Strict On

Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D

Module modGameOver
    Public Game_Over_Fade_To_Transparent As Single
    Public Game_Over_Fade_Transparent_Speed As Single
    Public Game_Over_Fade_Transparent_Time As Single
    Public Game_Over_Fade_Transparent_Milliseconds As Single
    Public Game_Over_Fade_Transparent_Enabled As Boolean

    Public Game_Over_Texture As Texture
    Public Game_Over_Vertex_List As CustomVertex.TransformedColoredTextured() = New CustomVertex.TransformedColoredTextured(0 To 3) {}
    Public Game_Over_Position As Vector2D

    Public Sub Load_Game_Over_Texture()
        Game_Over_Texture = Load_Texture(Application.StartupPath & "\Game Over.png", Color.FromArgb(255, 0, 255).ToArgb)
    End Sub

    Public Sub Draw_Game_Over()
        Dim Fade_Color As Integer = CInt(Fade_To_Black)

        Game_Over_Position = New Vector2D(CSng((Window_Width / 2) - (276 / 2)), 200)

        Device.VertexFormat = CustomVertex.TransformedColoredTextured.Format
        Game_Over_Vertex_List(0) = Create_Custom_Vertex(Game_Over_Position.X, Game_Over_Position.Y, Color.FromArgb(CInt(Game_Over_Fade_To_Transparent), Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 0)
        Game_Over_Vertex_List(1) = Create_Custom_Vertex(Game_Over_Position.X + 276, Game_Over_Position.Y, Color.FromArgb(CInt(Game_Over_Fade_To_Transparent), Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 0)
        Game_Over_Vertex_List(2) = Create_Custom_Vertex(Game_Over_Position.X, Game_Over_Position.Y + 51, Color.FromArgb(CInt(Game_Over_Fade_To_Transparent), Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 1)
        Game_Over_Vertex_List(3) = Create_Custom_Vertex(Game_Over_Position.X + 276, Game_Over_Position.Y + 51, Color.FromArgb(CInt(Game_Over_Fade_To_Transparent), Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 1)
        Device.SetTexture(0, Game_Over_Texture)
        Device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, Game_Over_Vertex_List)
    End Sub

    Public Sub Fade_Transparent_Game_Over()
        If Game_Over_Fade_Transparent_Enabled = True And Game_Active = False Then
            Game_Over_Fade_Transparent_Time = Get_Elapsed_Time() - Game_Over_Fade_Transparent_Milliseconds
            Game_Over_Fade_To_Transparent = (Game_Over_Fade_Transparent_Speed * Game_Over_Fade_Transparent_Time)
            If Game_Over_Fade_To_Transparent >= 255 Then
                Game_Over_Fade_To_Transparent = 255
                Game_Over_Fade_Transparent_Enabled = False
            End If
        End If
    End Sub

    Public Sub Unload_Game_Over_Textures()
        If Game_Over_Texture IsNot Nothing Then
            Game_Over_Texture.Dispose() : Game_Over_Texture = Nothing
        End If
    End Sub
End Module
