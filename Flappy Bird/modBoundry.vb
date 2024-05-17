Option Explicit On
Option Strict On

Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D

Module modBoundry
    Public Boundry_Texture As Texture
    Public Boundry_Vertex_List As CustomVertex.TransformedColoredTextured() = New CustomVertex.TransformedColoredTextured(0 To 3) {}

    Public Sub Draw_Boundry()
        Dim Fade_Color As Integer = CInt(Fade_To_Black)

        Device.VertexFormat = CustomVertex.TransformedColoredTextured.Format

        Boundry_Vertex_List(0) = Create_Custom_Vertex(Pipe_Position(0).X + Pipe_Boundry1(0).X, Pipe_Position(0).Y + Pipe_Boundry1(0).Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 0)
        Boundry_Vertex_List(1) = Create_Custom_Vertex(Pipe_Position(0).X + Pipe_Boundry1(1).X, Pipe_Position(0).Y + Pipe_Boundry1(1).Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 0)
        Boundry_Vertex_List(2) = Create_Custom_Vertex(Pipe_Position(0).X + Pipe_Boundry1(2).X, Pipe_Position(0).Y + Pipe_Boundry1(2).Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 1)
        Boundry_Vertex_List(3) = Create_Custom_Vertex(Pipe_Position(0).X + Pipe_Boundry1(3).X, Pipe_Position(0).Y + Pipe_Boundry1(3).Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 1)

        Device.SetTexture(0, Nothing)
        Device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, Boundry_Vertex_List)

        Device.VertexFormat = CustomVertex.TransformedColoredTextured.Format

        Boundry_Vertex_List(0) = Create_Custom_Vertex(Pipe_Position(1).X + Pipe_Boundry2(0).X, Pipe_Position(1).Y + Pipe_Boundry2(0).Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 0)
        Boundry_Vertex_List(1) = Create_Custom_Vertex(Pipe_Position(1).X + Pipe_Boundry2(1).X, Pipe_Position(1).Y + Pipe_Boundry2(1).Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 0)
        Boundry_Vertex_List(2) = Create_Custom_Vertex(Pipe_Position(1).X + Pipe_Boundry2(2).X, Pipe_Position(1).Y + Pipe_Boundry2(2).Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 1)
        Boundry_Vertex_List(3) = Create_Custom_Vertex(Pipe_Position(1).X + Pipe_Boundry2(3).X, Pipe_Position(1).Y + Pipe_Boundry2(3).Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 1)

        Device.SetTexture(0, Nothing)
        Device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, Boundry_Vertex_List)

        Device.VertexFormat = CustomVertex.TransformedColoredTextured.Format

        Boundry_Vertex_List(0) = Create_Custom_Vertex(Pipe_Position(2).X + Pipe_Boundry3(0).X, Pipe_Position(2).Y + Pipe_Boundry3(0).Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 0)
        Boundry_Vertex_List(1) = Create_Custom_Vertex(Pipe_Position(2).X + Pipe_Boundry3(1).X, Pipe_Position(2).Y + Pipe_Boundry3(1).Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 0)
        Boundry_Vertex_List(2) = Create_Custom_Vertex(Pipe_Position(2).X + Pipe_Boundry3(2).X, Pipe_Position(2).Y + Pipe_Boundry3(2).Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 1)
        Boundry_Vertex_List(3) = Create_Custom_Vertex(Pipe_Position(2).X + Pipe_Boundry3(3).X, Pipe_Position(2).Y + Pipe_Boundry3(3).Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 1)

        Device.SetTexture(0, Nothing)
        Device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, Boundry_Vertex_List)

        Device.VertexFormat = CustomVertex.TransformedColoredTextured.Format

        Boundry_Vertex_List(0) = Create_Custom_Vertex(Pipe_Position(3).X + Pipe_Boundry4(0).X, Pipe_Position(3).Y + Pipe_Boundry4(0).Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 0)
        Boundry_Vertex_List(1) = Create_Custom_Vertex(Pipe_Position(3).X + Pipe_Boundry4(1).X, Pipe_Position(3).Y + Pipe_Boundry4(1).Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 0)
        Boundry_Vertex_List(2) = Create_Custom_Vertex(Pipe_Position(3).X + Pipe_Boundry4(2).X, Pipe_Position(3).Y + Pipe_Boundry4(2).Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 1)
        Boundry_Vertex_List(3) = Create_Custom_Vertex(Pipe_Position(3).X + Pipe_Boundry4(3).X, Pipe_Position(3).Y + Pipe_Boundry4(3).Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 1)

        Device.SetTexture(0, Nothing)
        Device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, Boundry_Vertex_List)

        Device.VertexFormat = CustomVertex.TransformedColoredTextured.Format

        Boundry_Vertex_List(0) = Create_Custom_Vertex(Pipe_Position(4).X + Pipe_Boundry5(0).X, Pipe_Position(4).Y + Pipe_Boundry5(0).Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 0)
        Boundry_Vertex_List(1) = Create_Custom_Vertex(Pipe_Position(4).X + Pipe_Boundry5(1).X, Pipe_Position(4).Y + Pipe_Boundry5(1).Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 0)
        Boundry_Vertex_List(2) = Create_Custom_Vertex(Pipe_Position(4).X + Pipe_Boundry5(2).X, Pipe_Position(4).Y + Pipe_Boundry5(2).Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 1)
        Boundry_Vertex_List(3) = Create_Custom_Vertex(Pipe_Position(4).X + Pipe_Boundry5(3).X, Pipe_Position(4).Y + Pipe_Boundry5(3).Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 1)

        Device.SetTexture(0, Nothing)
        Device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, Boundry_Vertex_List)

        Device.VertexFormat = CustomVertex.TransformedColoredTextured.Format

        Boundry_Vertex_List(0) = Create_Custom_Vertex(Pipe_Position(5).X + Pipe_Boundry6(0).X, Pipe_Position(5).Y + Pipe_Boundry6(0).Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 0)
        Boundry_Vertex_List(1) = Create_Custom_Vertex(Pipe_Position(5).X + Pipe_Boundry6(1).X, Pipe_Position(5).Y + Pipe_Boundry6(1).Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 0)
        Boundry_Vertex_List(2) = Create_Custom_Vertex(Pipe_Position(5).X + Pipe_Boundry6(2).X, Pipe_Position(5).Y + Pipe_Boundry6(2).Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 1)
        Boundry_Vertex_List(3) = Create_Custom_Vertex(Pipe_Position(5).X + Pipe_Boundry6(3).X, Pipe_Position(5).Y + Pipe_Boundry6(3).Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 1)

        Device.SetTexture(0, Nothing)
        Device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, Boundry_Vertex_List)
    End Sub

    Public Sub Unload_Boundry_Texture()
        If Boundry_Texture IsNot Nothing Then
            Boundry_Texture.Dispose() : Boundry_Texture = Nothing
        End If
    End Sub
End Module
