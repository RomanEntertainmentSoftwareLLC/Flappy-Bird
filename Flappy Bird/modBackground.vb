Option Explicit On
Option Strict On

Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D

Module modBackground
    Public Background_Texture(1) As Texture
    Public Background_Vertex_List As CustomVertex.TransformedColoredTextured() = New CustomVertex.TransformedColoredTextured(0 To 3) {}
    Public Background_Position As Vector2D
    Public Random_Background As Integer

    Public Sub Load_Background_Textures()
        Background_Texture(0) = Load_Texture(Application.StartupPath & "\Background.png", Color.FromArgb(0, 0, 0, 0).ToArgb)
        Background_Texture(1) = Load_Texture(Application.StartupPath & "\Background Night.png", Color.FromArgb(0, 0, 0, 0).ToArgb)
    End Sub

    Public Sub Draw_Background()
        Dim Fade_Color As Integer = CInt(Fade_To_Black)

        Device.VertexFormat = CustomVertex.TransformedColoredTextured.Format

        If Fullscreen_Enabled = False Then
            Background_Position = New Vector2D(0, 0)

            Background_Vertex_List(0) = Create_Custom_Vertex(Background_Position.X, Background_Position.Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 0)
            Background_Vertex_List(1) = Create_Custom_Vertex(Background_Position.X + Window_Width, Background_Position.Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 0)
            Background_Vertex_List(2) = Create_Custom_Vertex(Background_Position.X, Background_Position.Y + Window_Height, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 1)
            Background_Vertex_List(3) = Create_Custom_Vertex(Background_Position.X + Window_Width, Background_Position.Y + Window_Height, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 1)
        Else
            Background_Position = New Vector2D(0, 0)

            Background_Vertex_List(0) = Create_Custom_Vertex(Background_Position.X, Background_Position.Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 0)
            Background_Vertex_List(1) = Create_Custom_Vertex(CSng(Background_Position.X + 607.5), Background_Position.Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 0)
            Background_Vertex_List(2) = Create_Custom_Vertex(Background_Position.X, Background_Position.Y + 1080, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 1)
            Background_Vertex_List(3) = Create_Custom_Vertex(CSng(Background_Position.X + 607.5), Background_Position.Y + 1080, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 1)
        End If

        Device.SetTexture(0, Background_Texture(Random_Background))

        Device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, Background_Vertex_List)
    End Sub

    Public Sub Unload_Background_Textures()
        Dim Current_Texture As Integer

        For Current_Texture = 0 To 1
            If Background_Texture(Current_Texture) IsNot Nothing Then
                Background_Texture(Current_Texture).Dispose() : Background_Texture(Current_Texture) = Nothing
            End If
        Next Current_Texture
    End Sub
End Module

