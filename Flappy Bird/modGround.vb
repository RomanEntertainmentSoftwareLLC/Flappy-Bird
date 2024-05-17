Option Explicit On
Option Strict On

Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D

Module modGround
    Public Ground_Texture As Texture
    Public Ground_Vertex_List As CustomVertex.TransformedColoredTextured() = New CustomVertex.TransformedColoredTextured(0 To 3) {}
    Public Ground_Position(1) As Vector2D

    Public Sub Setup_Ground()
        Ground_Position(0) = New Vector2D(0, 600)
        Ground_Position(1) = New Vector2D(462, 600)
    End Sub

    Public Sub Load_Ground_Texture()
        Ground_Texture = Load_Texture(Application.StartupPath & "\Ground.png", Color.FromArgb(0, 0, 0, 0).ToArgb)
    End Sub

    Public Sub Draw_Ground()
        Dim Fade_Color As Integer = CInt(Fade_To_Black)

        If Death = False Then
            Ground_Position(0).X -= GAME_SPEED
            Ground_Position(1).X -= GAME_SPEED
        End If

        If Ground_Position(0).X <= -462 Then Ground_Position(0).X = 0
        If Ground_Position(1).X <= 0 Then Ground_Position(1).X = 462

        Device.VertexFormat = CustomVertex.TransformedColoredTextured.Format
        Ground_Vertex_List(0) = Create_Custom_Vertex(Ground_Position(0).X + 0, Ground_Position(0).Y + 0, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 0)
        Ground_Vertex_List(1) = Create_Custom_Vertex(Ground_Position(0).X + 462, Ground_Position(0).Y + 0, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 0)
        Ground_Vertex_List(2) = Create_Custom_Vertex(Ground_Position(0).X + 0, Ground_Position(0).Y + 168, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 1)
        Ground_Vertex_List(3) = Create_Custom_Vertex(Ground_Position(0).X + 462, Ground_Position(0).Y + 168, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 1)
        Device.SetTexture(0, Ground_Texture)
        Device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, Ground_Vertex_List)


        Ground_Vertex_List(0) = Create_Custom_Vertex(Ground_Position(1).X + 0, Ground_Position(1).Y + 0, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 0)
        Ground_Vertex_List(1) = Create_Custom_Vertex(Ground_Position(1).X + 462, Ground_Position(1).Y + 0, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 0)
        Ground_Vertex_List(2) = Create_Custom_Vertex(Ground_Position(1).X + 0, Ground_Position(1).Y + 168, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 1)
        Ground_Vertex_List(3) = Create_Custom_Vertex(Ground_Position(1).X + 462, Ground_Position(1).Y + 168, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 1)

        Device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, Ground_Vertex_List)
    End Sub

    Public Sub Unload_Ground_Textures()
        If Ground_Texture IsNot Nothing Then
            Ground_Texture.Dispose() : Ground_Texture = Nothing
        End If
    End Sub
End Module
