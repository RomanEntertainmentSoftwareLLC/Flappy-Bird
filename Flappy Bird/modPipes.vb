Option Explicit On
Option Strict On

Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D

Module modPipes
    Public Pipe_Head_Texture As Texture
    Public Pipe_Tail_Texture As Texture
    Public Pipe_Head_Vertex_List As CustomVertex.TransformedColoredTextured() = New CustomVertex.TransformedColoredTextured(0 To 3) {}
    Public Pipe_Tail_Vertex_List As CustomVertex.TransformedColoredTextured() = New CustomVertex.TransformedColoredTextured(0 To 3) {}
    Public Pipe_Position(5) As Vector2D
    Public Pipe_Length(2) As Single

    Public Pipe_Boundry1(3) As Vector2D
    Public Pipe_Boundry2(3) As Vector2D
    Public Pipe_Boundry3(3) As Vector2D
    Public Pipe_Boundry4(3) As Vector2D
    Public Pipe_Boundry5(3) As Vector2D
    Public Pipe_Boundry6(3) As Vector2D

    Public Sub Setup_Pipes()
        Dim Left_Over_Length As Single

        Pipe_Position(0).X = 500
        Pipe_Position(1).X = 500
        Pipe_Position(2).X = Pipe_Position(0).X + GAP_X
        Pipe_Position(3).X = Pipe_Position(1).X + GAP_X
        Pipe_Position(4).X = Pipe_Position(2).X + GAP_X
        Pipe_Position(5).X = Pipe_Position(3).X + GAP_X

        Pipe_Length(0) = (Rnd() * 350)
        Pipe_Length(1) = (Rnd() * 350)
        Pipe_Length(2) = (Rnd() * 350)

        If Pipe_Length(0) <= 25 Then Pipe_Length(0) = 25
        If Pipe_Length(1) <= 25 Then Pipe_Length(1) = 25
        If Pipe_Length(2) <= 25 Then Pipe_Length(2) = 25

        If Pipe_Length(0) >= 350 Then Pipe_Length(0) = 350
        If Pipe_Length(1) >= 350 Then Pipe_Length(1) = 350
        If Pipe_Length(2) >= 350 Then Pipe_Length(2) = 350

        'Pipe 1 (Top Pipe)
        Pipe_Boundry1(0) = New Vector2D(-35, 0)
        Pipe_Boundry1(1) = New Vector2D(35, 0)
        Pipe_Boundry1(2) = New Vector2D(-35, Pipe_Length(0) + 18)
        Pipe_Boundry1(3) = New Vector2D(35, Pipe_Length(0) + 18)

        'Pipe 2 (Bottom Pipe)
        Left_Over_Length = 600 - (GAP_Y + (Pipe_Length(0) + 18)) + 18

        Pipe_Boundry2(0) = New Vector2D(-35, 0)
        Pipe_Boundry2(1) = New Vector2D(35, 0)
        Pipe_Boundry2(2) = New Vector2D(-35, Left_Over_Length)
        Pipe_Boundry2(3) = New Vector2D(35, Left_Over_Length)

        'Pipe 3 (Top Pipe)
        Pipe_Boundry3(0) = New Vector2D(-35, 0)
        Pipe_Boundry3(1) = New Vector2D(35, 0)
        Pipe_Boundry3(2) = New Vector2D(-35, Pipe_Length(1) + 18)
        Pipe_Boundry3(3) = New Vector2D(35, Pipe_Length(1) + 18)

        'Pipe 4 (Bottom Pipe)
        Left_Over_Length = 600 - (GAP_Y + (Pipe_Length(1) + 18)) + 18

        Pipe_Boundry4(0) = New Vector2D(-35, 0)
        Pipe_Boundry4(1) = New Vector2D(35, 0)
        Pipe_Boundry4(2) = New Vector2D(-35, Left_Over_Length)
        Pipe_Boundry4(3) = New Vector2D(35, Left_Over_Length)

        'Pipe 5 (Top Pipe)
        Pipe_Boundry5(0) = New Vector2D(-35, 0)
        Pipe_Boundry5(1) = New Vector2D(35, 0)
        Pipe_Boundry5(2) = New Vector2D(-35, Pipe_Length(2) + 18)
        Pipe_Boundry5(3) = New Vector2D(35, Pipe_Length(2) + 18)

        'Pipe 6 (Bottom Pipe)
        Left_Over_Length = 600 - (GAP_Y + (Pipe_Length(2) + 18)) + 18

        Pipe_Boundry6(0) = New Vector2D(-35, 0)
        Pipe_Boundry6(1) = New Vector2D(35, 0)
        Pipe_Boundry6(2) = New Vector2D(-35, Left_Over_Length)
        Pipe_Boundry6(3) = New Vector2D(35, Left_Over_Length)
    End Sub

    Public Sub Load_Pipe_Textures()
        Pipe_Head_Texture = Load_Texture(Application.StartupPath & "\Pipehead.png", Color.FromArgb(0, 0, 0).ToArgb)
        Pipe_Tail_Texture = Load_Texture(Application.StartupPath & "\Pipetail.png", Color.FromArgb(0, 0, 0).ToArgb)
    End Sub

    Public Sub Draw_Pipes()
        Dim Fade_Color As Integer = CInt(Fade_To_Black)
        Dim I As Single 'Temp variable
        Dim Left_Over_Length As Single

        If Game_Active = True Then
            Pipe_Position(0).X -= GAME_SPEED
            Pipe_Position(1).X -= GAME_SPEED
            Pipe_Position(2).X -= GAME_SPEED
            Pipe_Position(3).X -= GAME_SPEED
            Pipe_Position(4).X -= GAME_SPEED
            Pipe_Position(5).X -= GAME_SPEED
        End If

        If Pipe_Position(0).X <= -78 Then
            Pipe_Position(0).X = Pipe_Position(4).X + GAP_X
            Pipe_Position(1).X = Pipe_Position(5).X + GAP_X

            Pipe_Length(0) = Rnd() * 350

            If Pipe_Length(0) <= 25 Then Pipe_Length(0) = 25
            If Pipe_Length(0) >= 350 Then Pipe_Length(0) = 350

            Pipe_Boundry1(0) = New Vector2D(-35, 0)
            Pipe_Boundry1(1) = New Vector2D(35, 0)
            Pipe_Boundry1(2) = New Vector2D(-35, Pipe_Length(0) + 18)
            Pipe_Boundry1(3) = New Vector2D(35, Pipe_Length(0) + 18)

            Left_Over_Length = 600 - (GAP_Y + Pipe_Length(0)) + 18

            Pipe_Boundry2(0) = New Vector2D(-35, 0)
            Pipe_Boundry2(1) = New Vector2D(35, 0)
            Pipe_Boundry2(2) = New Vector2D(-35, Left_Over_Length)
            Pipe_Boundry2(3) = New Vector2D(35, Left_Over_Length)

            Score_Group_Pipes_Flag(0) = False
        End If

        'Pipe 1
        '--------------------------------------------------------------------------
        Pipe_Position(0).Y = 0

        Pipe_Tail_Vertex_List(0) = Create_Custom_Vertex(Pipe_Position(0).X + -37, Pipe_Position(0).Y + 0, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 0)
        Pipe_Tail_Vertex_List(1) = Create_Custom_Vertex(Pipe_Position(0).X + 37, Pipe_Position(0).Y + 0, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 0)
        Pipe_Tail_Vertex_List(2) = Create_Custom_Vertex(Pipe_Position(0).X + -37, Pipe_Position(0).Y + Pipe_Length(0), Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 1)
        Pipe_Tail_Vertex_List(3) = Create_Custom_Vertex(Pipe_Position(0).X + 37, Pipe_Position(0).Y + Pipe_Length(0), Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 1)

        Device.VertexFormat = CustomVertex.TransformedColoredTextured.Format
        Device.SetTexture(0, Pipe_Tail_Texture)
        Device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, Pipe_Tail_Vertex_List)

        I = Pipe_Tail_Vertex_List(2).Y - Pipe_Tail_Vertex_List(0).Y

        Pipe_Head_Vertex_List(0) = Create_Custom_Vertex(Pipe_Position(0).X + -39, Pipe_Position(0).Y + I + 0, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 0)
        Pipe_Head_Vertex_List(1) = Create_Custom_Vertex(Pipe_Position(0).X + 39, Pipe_Position(0).Y + I + 0, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 0)
        Pipe_Head_Vertex_List(2) = Create_Custom_Vertex(Pipe_Position(0).X + -39, Pipe_Position(0).Y + I + 18, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 1)
        Pipe_Head_Vertex_List(3) = Create_Custom_Vertex(Pipe_Position(0).X + 39, Pipe_Position(0).Y + I + 18, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 1)

        Device.VertexFormat = CustomVertex.TransformedColoredTextured.Format
        Device.SetTexture(0, Pipe_Head_Texture)
        Device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, Pipe_Head_Vertex_List)
        '--------------------------------------------------------------------------

        'Pipe 2
        '--------------------------------------------------------------------------
        Pipe_Position(1).Y = GAP_Y + I

        Pipe_Head_Vertex_List(0) = Create_Custom_Vertex(Pipe_Position(1).X + -39, Pipe_Position(1).Y + 0, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 0)
        Pipe_Head_Vertex_List(1) = Create_Custom_Vertex(Pipe_Position(1).X + 39, Pipe_Position(1).Y + 0, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 0)
        Pipe_Head_Vertex_List(2) = Create_Custom_Vertex(Pipe_Position(1).X + -39, Pipe_Position(1).Y + 18, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 1)
        Pipe_Head_Vertex_List(3) = Create_Custom_Vertex(Pipe_Position(1).X + 39, Pipe_Position(1).Y + 18, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 1)

        Device.VertexFormat = CustomVertex.TransformedColoredTextured.Format
        Device.SetTexture(0, Pipe_Head_Texture)
        Device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, Pipe_Head_Vertex_List)

        Pipe_Tail_Vertex_List(0) = Create_Custom_Vertex(Pipe_Position(1).X + -37, Pipe_Position(1).Y + 18, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 0)
        Pipe_Tail_Vertex_List(1) = Create_Custom_Vertex(Pipe_Position(1).X + 37, Pipe_Position(1).Y + 18, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 0)
        Pipe_Tail_Vertex_List(2) = Create_Custom_Vertex(Pipe_Position(1).X + -37, Pipe_Position(1).Y + (600 - Pipe_Position(1).Y), Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 1)
        Pipe_Tail_Vertex_List(3) = Create_Custom_Vertex(Pipe_Position(1).X + 37, Pipe_Position(1).Y + (600 - Pipe_Position(1).Y), Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 1)

        Device.VertexFormat = CustomVertex.TransformedColoredTextured.Format
        Device.SetTexture(0, Pipe_Tail_Texture)
        Device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, Pipe_Tail_Vertex_List)
        '--------------------------------------------------------------------------

        'Pipe 3
        '--------------------------------------------------------------------------
        If Pipe_Position(2).X <= -78 Then
            Pipe_Position(2).X = Pipe_Position(0).X + GAP_X
            Pipe_Position(3).X = Pipe_Position(1).X + GAP_X

            Pipe_Length(1) = Rnd() * 350
            If Pipe_Length(1) <= 25 Then Pipe_Length(1) = 25
            If Pipe_Length(1) >= 350 Then Pipe_Length(1) = 350

            Pipe_Boundry3(0) = New Vector2D(-35, 0)
            Pipe_Boundry3(1) = New Vector2D(35, 0)
            Pipe_Boundry3(2) = New Vector2D(-35, Pipe_Length(1) + 18)
            Pipe_Boundry3(3) = New Vector2D(35, Pipe_Length(1) + 18)

            Left_Over_Length = 600 - (GAP_Y + Pipe_Length(1)) + 18

            Pipe_Boundry4(0) = New Vector2D(-35, 0)
            Pipe_Boundry4(1) = New Vector2D(35, 0)
            Pipe_Boundry4(2) = New Vector2D(-35, Left_Over_Length)
            Pipe_Boundry4(3) = New Vector2D(35, Left_Over_Length)

            Score_Group_Pipes_Flag(1) = False
        End If

        Pipe_Position(2).Y = 0

        Pipe_Tail_Vertex_List(0) = Create_Custom_Vertex(Pipe_Position(2).X + -37, Pipe_Position(2).Y + 0, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 0)
        Pipe_Tail_Vertex_List(1) = Create_Custom_Vertex(Pipe_Position(2).X + 37, Pipe_Position(2).Y + 0, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 0)
        Pipe_Tail_Vertex_List(2) = Create_Custom_Vertex(Pipe_Position(2).X + -37, Pipe_Position(2).Y + Pipe_Length(1), Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 1)
        Pipe_Tail_Vertex_List(3) = Create_Custom_Vertex(Pipe_Position(2).X + 37, Pipe_Position(2).Y + Pipe_Length(1), Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 1)

        Device.VertexFormat = CustomVertex.TransformedColoredTextured.Format
        Device.SetTexture(0, Pipe_Tail_Texture)
        Device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, Pipe_Tail_Vertex_List)

        I = Pipe_Tail_Vertex_List(2).Y - Pipe_Tail_Vertex_List(0).Y

        Pipe_Head_Vertex_List(0) = Create_Custom_Vertex(Pipe_Position(2).X + -39, Pipe_Position(2).Y + I + 0, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 0)
        Pipe_Head_Vertex_List(1) = Create_Custom_Vertex(Pipe_Position(2).X + 39, Pipe_Position(2).Y + I + 0, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 0)
        Pipe_Head_Vertex_List(2) = Create_Custom_Vertex(Pipe_Position(2).X + -39, Pipe_Position(2).Y + I + 18, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 1)
        Pipe_Head_Vertex_List(3) = Create_Custom_Vertex(Pipe_Position(2).X + 39, Pipe_Position(2).Y + I + 18, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 1)

        Device.VertexFormat = CustomVertex.TransformedColoredTextured.Format
        Device.SetTexture(0, Pipe_Head_Texture)
        Device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, Pipe_Head_Vertex_List)
        '--------------------------------------------------------------------------

        'Pipe 4
        '--------------------------------------------------------------------------
        Pipe_Position(3).Y = I + GAP_Y

        Pipe_Head_Vertex_List(0) = Create_Custom_Vertex(Pipe_Position(3).X + -39, Pipe_Position(3).Y + 0, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 0)
        Pipe_Head_Vertex_List(1) = Create_Custom_Vertex(Pipe_Position(3).X + 39, Pipe_Position(3).Y + 0, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 0)
        Pipe_Head_Vertex_List(2) = Create_Custom_Vertex(Pipe_Position(3).X + -39, Pipe_Position(3).Y + 18, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 1)
        Pipe_Head_Vertex_List(3) = Create_Custom_Vertex(Pipe_Position(3).X + 39, Pipe_Position(3).Y + 18, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 1)

        Device.VertexFormat = CustomVertex.TransformedColoredTextured.Format
        Device.SetTexture(0, Pipe_Head_Texture)
        Device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, Pipe_Head_Vertex_List)

        Pipe_Tail_Vertex_List(0) = Create_Custom_Vertex(Pipe_Position(3).X + -37, Pipe_Position(3).Y + 18, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 0)
        Pipe_Tail_Vertex_List(1) = Create_Custom_Vertex(Pipe_Position(3).X + 37, Pipe_Position(3).Y + 18, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 0)
        Pipe_Tail_Vertex_List(2) = Create_Custom_Vertex(Pipe_Position(3).X + -37, Pipe_Position(3).Y + (600 - Pipe_Position(3).Y), Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 1)
        Pipe_Tail_Vertex_List(3) = Create_Custom_Vertex(Pipe_Position(3).X + 37, Pipe_Position(3).Y + (600 - Pipe_Position(3).Y), Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 1)

        Device.VertexFormat = CustomVertex.TransformedColoredTextured.Format
        Device.SetTexture(0, Pipe_Tail_Texture)
        Device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, Pipe_Tail_Vertex_List)
        '--------------------------------------------------------------------------


        'Pipe 5
        '--------------------------------------------------------------------------
        If Pipe_Position(4).X <= -78 Then
            Pipe_Position(4).X = Pipe_Position(2).X + GAP_X
            Pipe_Position(5).X = Pipe_Position(3).X + GAP_X

            Pipe_Length(2) = Rnd() * 350
            If Pipe_Length(2) <= 25 Then Pipe_Length(2) = 25
            If Pipe_Length(2) >= 350 Then Pipe_Length(2) = 350

            Pipe_Boundry5(0) = New Vector2D(-35, 0)
            Pipe_Boundry5(1) = New Vector2D(35, 0)
            Pipe_Boundry5(2) = New Vector2D(-35, Pipe_Length(2) + 18)
            Pipe_Boundry5(3) = New Vector2D(35, Pipe_Length(2) + 18)

            Left_Over_Length = 600 - (GAP_Y + Pipe_Length(2)) + 18

            Pipe_Boundry6(0) = New Vector2D(-35, 0)
            Pipe_Boundry6(1) = New Vector2D(35, 0)
            Pipe_Boundry6(2) = New Vector2D(-35, Left_Over_Length)
            Pipe_Boundry6(3) = New Vector2D(35, Left_Over_Length)

            Score_Group_Pipes_Flag(2) = False
        End If

        Pipe_Position(4).Y = 0

        Pipe_Tail_Vertex_List(0) = Create_Custom_Vertex(Pipe_Position(4).X + -37, Pipe_Position(4).Y + 0, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 0)
        Pipe_Tail_Vertex_List(1) = Create_Custom_Vertex(Pipe_Position(4).X + 37, Pipe_Position(4).Y + 0, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 0)
        Pipe_Tail_Vertex_List(2) = Create_Custom_Vertex(Pipe_Position(4).X + -37, Pipe_Position(4).Y + Pipe_Length(2), Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 1)
        Pipe_Tail_Vertex_List(3) = Create_Custom_Vertex(Pipe_Position(4).X + 37, Pipe_Position(4).Y + Pipe_Length(2), Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 1)

        Device.VertexFormat = CustomVertex.TransformedColoredTextured.Format
        Device.SetTexture(0, Pipe_Tail_Texture)
        Device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, Pipe_Tail_Vertex_List)

        I = Pipe_Tail_Vertex_List(2).Y - Pipe_Tail_Vertex_List(0).Y

        Pipe_Head_Vertex_List(0) = Create_Custom_Vertex(Pipe_Position(4).X + -39, Pipe_Position(4).Y + I, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 0)
        Pipe_Head_Vertex_List(1) = Create_Custom_Vertex(Pipe_Position(4).X + 39, Pipe_Position(4).Y + I, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 0)
        Pipe_Head_Vertex_List(2) = Create_Custom_Vertex(Pipe_Position(4).X + -39, Pipe_Position(4).Y + I + 18, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 1)
        Pipe_Head_Vertex_List(3) = Create_Custom_Vertex(Pipe_Position(4).X + 39, Pipe_Position(4).Y + I + 18, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 1)

        Device.VertexFormat = CustomVertex.TransformedColoredTextured.Format
        Device.SetTexture(0, Pipe_Head_Texture)
        Device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, Pipe_Head_Vertex_List)
        '--------------------------------------------------------------------------

        'Pipe 6
        '--------------------------------------------------------------------------
        Pipe_Position(5).Y = I + GAP_Y

        Pipe_Head_Vertex_List(0) = Create_Custom_Vertex(Pipe_Position(5).X + -39, Pipe_Position(5).Y + 0, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 0)
        Pipe_Head_Vertex_List(1) = Create_Custom_Vertex(Pipe_Position(5).X + 39, Pipe_Position(5).Y + 0, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 0)
        Pipe_Head_Vertex_List(2) = Create_Custom_Vertex(Pipe_Position(5).X + -39, Pipe_Position(5).Y + 18, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 1)
        Pipe_Head_Vertex_List(3) = Create_Custom_Vertex(Pipe_Position(5).X + 39, Pipe_Position(5).Y + 18, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 1)

        Device.VertexFormat = CustomVertex.TransformedColoredTextured.Format
        Device.SetTexture(0, Pipe_Head_Texture)
        Device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, Pipe_Head_Vertex_List)

        Pipe_Tail_Vertex_List(0) = Create_Custom_Vertex(Pipe_Position(5).X + -37, Pipe_Position(5).Y + 18, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 0)
        Pipe_Tail_Vertex_List(1) = Create_Custom_Vertex(Pipe_Position(5).X + 37, Pipe_Position(5).Y + 18, Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 0)
        Pipe_Tail_Vertex_List(2) = Create_Custom_Vertex(Pipe_Position(5).X + -37, Pipe_Position(5).Y + (600 - Pipe_Position(5).Y), Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 1)
        Pipe_Tail_Vertex_List(3) = Create_Custom_Vertex(Pipe_Position(5).X + 37, Pipe_Position(5).Y + (600 - Pipe_Position(5).Y), Color.FromArgb(255, Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 1)

        Device.VertexFormat = CustomVertex.TransformedColoredTextured.Format
        Device.SetTexture(0, Pipe_Tail_Texture)
        Device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, Pipe_Tail_Vertex_List)
        '--------------------------------------------------------------------------
    End Sub

    Public Sub Unload_Pipe_Textures()
        If Pipe_Head_Texture IsNot Nothing Then
            Pipe_Head_Texture.Dispose() : Pipe_Head_Texture = Nothing
        End If

        If Pipe_Tail_Texture IsNot Nothing Then
            Pipe_Tail_Texture.Dispose() : Pipe_Tail_Texture = Nothing
        End If
    End Sub
End Module
