Option Explicit On
Option Strict On

Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D

Public Module modSprite
    Public Enum Angulator_Enum
        POSITIVE = 0
        NEGATIVE = 1
    End Enum

    Public Structure RECT
        Dim Left As Single
        Dim Top As Single
        Dim Right As Single
        Dim Bottom As Single
    End Structure

    Public Structure Animation_Type
        Dim Frame_Size() As RECT
        Dim Number_Of_Frames As Integer
        Dim Number_Of_Textures As Integer
        Dim Current_Frame As Single
        Dim Frame_Counter As Integer
        Dim Speed As Single
        Dim Initial_Frame As Integer
        Dim Mode As Integer 'Single Shot, Loop, etc.
        Dim Offset() As Vector2D
        Dim Texture_Number() As Integer
    End Structure

    Public Structure Sprite_Type
        Dim Physics As clsPhysics
        Dim Ncoll As Vector2D
        Dim Dcoll As Single
        Dim Animation_State As Animation_Type
        Dim Texture_Path() As String
        Dim Texture_List() As Texture
        Dim Total_Number_Of_Textures As Integer
        Dim Vertex_List As CustomVertex.TransformedColoredTextured()
        Dim Scale_Factor As Single
        Dim Angle As Single
    End Structure

    Public Const ANIMATION_MODE_SINGLE_SHOT As Integer = 0
    Public Const ANIMATION_MODE_LOOP As Integer = 1

    Public Sprite(3) As Sprite_Type
    Public Angulator As Angulator_Enum
    Public Sprite_Vertex(3) As Vector2D
    Public Bounce As Single

    Public Random_Sprite As Integer

    Public Sub Setup_Sprite()
        With Sprite(0)
            .Physics = New clsPhysics
            .Scale_Factor = 2.5
            .Vertex_List = New CustomVertex.TransformedColoredTextured(0 To 3) {}

            With .Physics
                .Position.X = 135
                .Position.Y = CSng((Window_Height / 2)) - 40
                .Mass = 10 * clsPhysics.POUNDS_TO_KG
                .One_Over_Mass = 1 / .Mass
                .Velocity.X = 0
                .Velocity.Y = 0
                .Acceleration.X = 0
                .Acceleration.Y = 0
                .Force.X = 0
                .Force.Y = 0
            End With

            With .Animation_State
                .Number_Of_Frames = 4
                .Number_Of_Textures = 3
                .Speed = 0.15
                .Initial_Frame = 0
                .Mode = ANIMATION_MODE_LOOP
                ReDim .Frame_Size(.Number_Of_Frames)
                ReDim .Offset(.Number_Of_Frames)
                ReDim .Texture_Number(.Number_Of_Frames)
                .Frame_Size(0).Left = CSng(-21.25) : .Frame_Size(0).Top = CSng(-15) : .Frame_Size(0).Right = CSng(21.25) : .Frame_Size(0).Bottom = CSng(15)
                .Frame_Size(1).Left = CSng(-21.25) : .Frame_Size(1).Top = CSng(-15) : .Frame_Size(1).Right = CSng(21.25) : .Frame_Size(1).Bottom = CSng(15)
                .Frame_Size(2).Left = CSng(-21.25) : .Frame_Size(2).Top = CSng(-15) : .Frame_Size(2).Right = CSng(21.25) : .Frame_Size(2).Bottom = CSng(15)
                .Frame_Size(3).Left = CSng(-21.25) : .Frame_Size(3).Top = CSng(-15) : .Frame_Size(3).Right = CSng(21.25) : .Frame_Size(3).Bottom = CSng(15)
                Dim I As Integer
                'Were gonna use the center of the sprite for Position X and Y as well as make the sprite bigger using a scale factor
                For I = 0 To UBound(.Frame_Size)
                    With .Frame_Size(I)
                        .Left = (.Left / 2) * Sprite(0).Scale_Factor
                        .Top = (.Top / 2) * Sprite(0).Scale_Factor
                        .Right = (.Right / 2) * Sprite(0).Scale_Factor
                        .Bottom = (.Bottom / 2) * Sprite(0).Scale_Factor
                    End With
                Next I
                .Offset(0).X = 0 : .Offset(0).Y = 0
                .Offset(1).X = 0 : .Offset(1).Y = 0
                .Offset(2).X = 0 : .Offset(2).Y = 0
                .Offset(3).X = 0 : .Offset(3).Y = 0

                .Texture_Number(0) = 1
                .Texture_Number(1) = 0
                .Texture_Number(2) = 2
                .Texture_Number(3) = 0
            End With
        End With
    End Sub

    Public Sub Load_Sprite_Textures()
        Dim Current_Texture As Integer

        With Sprite(0)
            .Total_Number_Of_Textures = 3

            ReDim .Texture_List(.Total_Number_Of_Textures)
            ReDim .Texture_Path(.Total_Number_Of_Textures)

            .Texture_Path(0) = Application.StartupPath & "\Flappy Bird 1 (Yellow).png"
            .Texture_Path(1) = Application.StartupPath & "\Flappy Bird 2 (Yellow).png"
            .Texture_Path(2) = Application.StartupPath & "\Flappy Bird 3 (Yellow).png"

            For Current_Texture = 0 To .Total_Number_Of_Textures - 1
                .Texture_List(Current_Texture) = Load_Texture(.Texture_Path(Current_Texture), Color.FromArgb(255, 0, 255).ToArgb)
            Next Current_Texture
        End With

        With Sprite(1)
            .Total_Number_Of_Textures = 3

            ReDim .Texture_List(.Total_Number_Of_Textures)
            ReDim .Texture_Path(.Total_Number_Of_Textures)

            .Texture_Path(0) = Application.StartupPath & "\Flappy Bird 1 (Red).png"
            .Texture_Path(1) = Application.StartupPath & "\Flappy Bird 2 (Red).png"
            .Texture_Path(2) = Application.StartupPath & "\Flappy Bird 3 (Red).png"

            For Current_Texture = 0 To .Total_Number_Of_Textures - 1
                .Texture_List(Current_Texture) = Load_Texture(.Texture_Path(Current_Texture), Color.FromArgb(255, 0, 255).ToArgb)
            Next Current_Texture
        End With

        With Sprite(2)
            .Total_Number_Of_Textures = 3

            ReDim .Texture_List(.Total_Number_Of_Textures)
            ReDim .Texture_Path(.Total_Number_Of_Textures)

            .Texture_Path(0) = Application.StartupPath & "\Flappy Bird 1 (Blue).png"
            .Texture_Path(1) = Application.StartupPath & "\Flappy Bird 2 (Blue).png"
            .Texture_Path(2) = Application.StartupPath & "\Flappy Bird 3 (Blue).png"

            For Current_Texture = 0 To .Total_Number_Of_Textures - 1
                .Texture_List(Current_Texture) = Load_Texture(.Texture_Path(Current_Texture), Color.FromArgb(255, 0, 255).ToArgb)
            Next Current_Texture
        End With

        With Sprite(3)
            .Total_Number_Of_Textures = 3

            ReDim .Texture_List(.Total_Number_Of_Textures)
            ReDim .Texture_Path(.Total_Number_Of_Textures)

            .Texture_Path(0) = Application.StartupPath & "\Flappy Bird 1 (Black).png"
            .Texture_Path(1) = Application.StartupPath & "\Flappy Bird 2 (Black).png"
            .Texture_Path(2) = Application.StartupPath & "\Flappy Bird 3 (Black).png"

            For Current_Texture = 0 To .Total_Number_Of_Textures - 1
                .Texture_List(Current_Texture) = Load_Texture(.Texture_Path(Current_Texture), Color.FromArgb(255, 0, 255).ToArgb)
            Next Current_Texture
        End With
    End Sub

    Public Sub Animate_Sprite()
        Dim Fade_Color As Integer = CInt(Fade_To_Black)
        Dim Frame As RECT

        Device.VertexFormat = CustomVertex.TransformedColoredTextured.Format

        With Sprite(0)
            If Game_Active = False And Death = False Then
                Bounce = CSng(Bounce + 0.125)
                Sprite(0).Physics.Velocity.Y = CSng(0.25 * Math.Sin(Bounce))
            End If

            With .Animation_State

                If .Number_Of_Frames <> 0 Then
                    If .Current_Frame <= 0 Then .Current_Frame = 0
                    Select Case .Mode
                        Case ANIMATION_MODE_SINGLE_SHOT
                            If .Number_Of_Frames = 1 Then
                                .Current_Frame = 0
                            ElseIf .Number_Of_Frames > 1 Then
                                If .Current_Frame >= (.Number_Of_Frames - 1) Then
                                    .Current_Frame = (.Number_Of_Frames - 1)
                                End If
                            End If
                        Case ANIMATION_MODE_LOOP
                            If .Current_Frame > (.Number_Of_Frames - 1) Then
                                .Current_Frame = 0
                            End If
                    End Select
                End If


                Frame.Left = (.Frame_Size(CInt(.Current_Frame)).Left)
                Frame.Top = (.Frame_Size(CInt(.Current_Frame)).Top)
                Frame.Right = (.Frame_Size(CInt(.Current_Frame)).Right)
                Frame.Bottom = (.Frame_Size(CInt(.Current_Frame)).Bottom)

                Sprite_Vertex(0).X = CSng((Frame.Left * Math.Cos(Sprite(0).Angle * (Math.PI / 180)) - Frame.Top * Math.Sin(Sprite(0).Angle * (Math.PI / 180))))
                Sprite_Vertex(0).Y = CSng((Frame.Left * Math.Sin(Sprite(0).Angle * (Math.PI / 180)) + Frame.Top * Math.Cos(Sprite(0).Angle * (Math.PI / 180))))

                Sprite_Vertex(1).X = CSng((Frame.Right * Math.Cos(Sprite(0).Angle * (Math.PI / 180)) - Frame.Top * Math.Sin(Sprite(0).Angle * (Math.PI / 180))))
                Sprite_Vertex(1).Y = CSng((Frame.Right * Math.Sin(Sprite(0).Angle * (Math.PI / 180)) + Frame.Top * Math.Cos(Sprite(0).Angle * (Math.PI / 180))))

                Sprite_Vertex(2).X = CSng((Frame.Left * Math.Cos(Sprite(0).Angle * (Math.PI / 180)) - Frame.Bottom * Math.Sin(Sprite(0).Angle * (Math.PI / 180))))
                Sprite_Vertex(2).Y = CSng((Frame.Left * Math.Sin(Sprite(0).Angle * (Math.PI / 180)) + Frame.Bottom * Math.Cos(Sprite(0).Angle * (Math.PI / 180))))

                Sprite_Vertex(3).X = CSng((Frame.Right * Math.Cos(Sprite(0).Angle * (Math.PI / 180)) - Frame.Bottom * Math.Sin(Sprite(0).Angle * (Math.PI / 180))))
                Sprite_Vertex(3).Y = CSng((Frame.Right * Math.Sin(Sprite(0).Angle * (Math.PI / 180)) + Frame.Bottom * Math.Cos(Sprite(0).Angle * (Math.PI / 180))))

                Sprite(0).Vertex_List(0) = Create_Custom_Vertex(Sprite(0).Physics.Position.X + Sprite_Vertex(0).X, Sprite(0).Physics.Position.Y + Sprite_Vertex(0).Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 0)
                Sprite(0).Vertex_List(1) = Create_Custom_Vertex(Sprite(0).Physics.Position.X + Sprite_Vertex(1).X, Sprite(0).Physics.Position.Y + Sprite_Vertex(1).Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 0)
                Sprite(0).Vertex_List(2) = Create_Custom_Vertex(Sprite(0).Physics.Position.X + Sprite_Vertex(2).X, Sprite(0).Physics.Position.Y + Sprite_Vertex(2).Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 0, 1)
                Sprite(0).Vertex_List(3) = Create_Custom_Vertex(Sprite(0).Physics.Position.X + Sprite_Vertex(3).X, Sprite(0).Physics.Position.Y + Sprite_Vertex(3).Y, Color.FromArgb(Fade_Color, Fade_Color, Fade_Color).ToArgb, 1, 1)

                'Device.SetTexture(0, Nothing)
                Device.SetTexture(0, Sprite(Random_Sprite).Texture_List(.Texture_Number(CInt(.Current_Frame))))
                If Running = True And Death = False Then .Current_Frame += .Speed
            End With
            'Device.SetRenderState(RenderStates.FillMode, FillMode.WireFrame)
            Device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, .Vertex_List)
            'Device.SetRenderState(RenderStates.FillMode, FillMode.Solid)
        End With
    End Sub

    Public Sub Angulate_Sprite()
        If Sprite(0).Physics.Position.Y <= 0 Then
            Sprite(0).Physics.Position.Y = 0
        End If

        If Game_Active = True Or Death = True Then
            If Angulator = Angulator_Enum.NEGATIVE Then
                Sprite(0).Angle = Sprite(0).Angle - 6
            ElseIf Angulator = Angulator_Enum.POSITIVE Then
                Sprite(0).Angle = Sprite(0).Angle + 3
            End If
        End If
        If Sprite(0).Physics.Velocity.Y >= 0 Then Angulator = Angulator_Enum.POSITIVE
        If Sprite(0).Angle <= -20 Then Sprite(0).Angle = -20
        If Sprite(0).Angle >= 90 Then Sprite(0).Angle = 90
    End Sub

    Public Sub Unload_Sprite_Textures()
        Dim Current_Texture As Integer
        Dim Current_Sprite As Integer

        For Current_Sprite = 0 To 3
            For Current_Texture = 0 To Sprite(0).Total_Number_Of_Textures - 1
                If Sprite(Current_Sprite).Texture_List(Current_Texture) IsNot Nothing Then
                    Sprite(Current_Sprite).Texture_List(Current_Texture).Dispose() : Sprite(Current_Sprite).Texture_List(Current_Texture) = Nothing
                End If
            Next Current_Texture
        Next Current_Sprite
    End Sub
End Module
