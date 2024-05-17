Option Explicit On
Option Strict On

Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D

Module modGetReady
    Public Get_Ready_Fade_To_Transparent As Single
    Public Get_Ready_Fade_Transparent_Speed As Single
    Public Get_Ready_Fade_Transparent_Time As Single
    Public Get_Ready_Fade_Transparent_Milliseconds As Single
    Public Get_Ready_Fade_Transparent_Enabled As Boolean
    Public Get_Ready_Fade_In_Transparent_Enabled As Boolean

    Public Get_Ready_Texture As Texture
    Public Get_Ready_Vertex_List As CustomVertex.TransformedColoredTextured() = New CustomVertex.TransformedColoredTextured(0 To 3) {}
    Public Get_Ready_Position As Vector2D

    Public Tap_Texture As Texture
    Public Tap_Vertex_List As CustomVertex.TransformedColoredTextured() = New CustomVertex.TransformedColoredTextured(0 To 3) {}
    Public Tap_Position As Vector2D

    Public Sub Setup_Get_Ready()
        Get_Ready_Fade_To_Transparent = 0
        Get_Ready_Fade_Transparent_Time = Get_Elapsed_Time()
        Get_Ready_Fade_Transparent_Speed = 255
        Get_Ready_Fade_In_Transparent_Enabled = True
    End Sub

    Public Sub Load_Get_Ready_Texture()
        Get_Ready_Texture = Load_Texture(Application.StartupPath & "\Get Ready.png", Color.FromArgb(255, 0, 255).ToArgb)
    End Sub

    Public Sub Load_Tap_Texture()
        Tap_Texture = Load_Texture(Application.StartupPath & "\Tap.png", Color.FromArgb(255, 0, 255).ToArgb)
    End Sub

    Public Sub Draw_Get_Ready()
        Dim Fade_Color As Integer = CInt(Fade_To_Black)

        Get_Ready_Position = New Vector2D(CSng((Window_Width / 2) - (255 / 2)), 200)

        Device.VertexFormat = CustomVertex.TransformedColoredTextured.Format
        Get_Ready_Vertex_List(0) = Create_Custom_Vertex(Get_Ready_Position.X, Get_Ready_Position.Y, Color.FromArgb(CInt(Get_Ready_Fade_To_Transparent), Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 0)
        Get_Ready_Vertex_List(1) = Create_Custom_Vertex(Get_Ready_Position.X + 255, Get_Ready_Position.Y, Color.FromArgb(CInt(Get_Ready_Fade_To_Transparent), Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 0)
        Get_Ready_Vertex_List(2) = Create_Custom_Vertex(Get_Ready_Position.X, Get_Ready_Position.Y + 60, Color.FromArgb(CInt(Get_Ready_Fade_To_Transparent), Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 1)
        Get_Ready_Vertex_List(3) = Create_Custom_Vertex(Get_Ready_Position.X + 255, Get_Ready_Position.Y + 60, Color.FromArgb(CInt(Get_Ready_Fade_To_Transparent), Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 1)
        Device.SetTexture(0, Get_Ready_Texture)
        Device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, Get_Ready_Vertex_List)

        Tap_Position = New Vector2D(CSng((Window_Width / 2) - (174 / 2)), 300)

        Device.VertexFormat = CustomVertex.TransformedColoredTextured.Format
        Tap_Vertex_List(0) = Create_Custom_Vertex(Tap_Position.X, Tap_Position.Y, Color.FromArgb(CInt(Get_Ready_Fade_To_Transparent), Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 0)
        Tap_Vertex_List(1) = Create_Custom_Vertex(Tap_Position.X + 174, Tap_Position.Y, Color.FromArgb(CInt(Get_Ready_Fade_To_Transparent), Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 0)
        Tap_Vertex_List(2) = Create_Custom_Vertex(Tap_Position.X, Tap_Position.Y + 147, Color.FromArgb(CInt(Get_Ready_Fade_To_Transparent), Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 1)
        Tap_Vertex_List(3) = Create_Custom_Vertex(Tap_Position.X + 174, Tap_Position.Y + 147, Color.FromArgb(CInt(Get_Ready_Fade_To_Transparent), Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 1)
        Device.SetTexture(0, Tap_Texture)
        Device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, Tap_Vertex_List)
    End Sub

    Public Sub Fade_Transparent_Get_Ready()

        If Get_Ready_Fade_Transparent_Enabled = True Then
            Get_Ready_Fade_Transparent_Time = Get_Elapsed_Time() - Get_Ready_Fade_Transparent_Milliseconds
            Get_Ready_Fade_To_Transparent = 255 - (Get_Ready_Fade_Transparent_Speed * Get_Ready_Fade_Transparent_Time)
            If Get_Ready_Fade_To_Transparent <= 0 Then
                Get_Ready_Fade_To_Transparent = 0
                Get_Ready_Fade_Transparent_Enabled = False
            End If
        End If

        If Get_Ready_Fade_In_Transparent_Enabled = True Then
            Get_Ready_Fade_Transparent_Time = Get_Elapsed_Time() - Get_Ready_Fade_Transparent_Milliseconds
            Get_Ready_Fade_To_Transparent = (Get_Ready_Fade_Transparent_Speed * Get_Ready_Fade_Transparent_Time)
            If Get_Ready_Fade_To_Transparent >= 255 Then
                Get_Ready_Fade_To_Transparent = 255
                Get_Ready_Fade_In_Transparent_Enabled = False
            End If
        End If
    End Sub

    Public Sub Unload_Get_Ready_Textures()
        If Get_Ready_Texture IsNot Nothing Then
            Get_Ready_Texture.Dispose() : Get_Ready_Texture = Nothing
        End If

        If Tap_Texture IsNot Nothing Then
            Tap_Texture.Dispose() : Tap_Texture = Nothing
        End If
    End Sub
End Module

