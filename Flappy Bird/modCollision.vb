Option Explicit On
Option Strict On

Module modCollision
    Public Function Collide(ByRef A() As Vector2D, ByRef B() As Vector2D, ByRef Number_Of_VerticesA As Integer, ByRef Number_Of_VerticesB As Integer, ByRef Offset As Vector2D, ByRef N As Vector2D, ByRef T As Single) As Boolean
        Dim Axis(64) As Vector2D
        Dim TAxis(64) As Single
        Dim Number_Of_Axes As Integer
        Dim I As Integer, J As Integer
        Dim E0 As Vector2D
        Dim E1 As Vector2D
        Dim E As Vector2D

        J = Number_Of_VerticesA - 1

        For I = 0 To J
            E0 = A(J)
            E1 = A(I)
            E = E1 - E0

            Axis(Number_Of_Axes).X = -E.Y
            Axis(Number_Of_Axes).Y = E.X

            If (Interval_Intersect(A, B, Number_Of_VerticesA, Number_Of_VerticesB, Axis(Number_Of_Axes), Offset, TAxis(Number_Of_Axes))) = False Then Return False

            Number_Of_Axes = Number_Of_Axes + 1
            J = I
        Next I

        J = Number_Of_VerticesB - 1

        For I = 0 To J
            E0 = B(J)
            E1 = B(I)
            E = E1 - E0

            Axis(Number_Of_Axes).X = -E.Y
            Axis(Number_Of_Axes).Y = E.X

            If (Interval_Intersect(A, B, Number_Of_VerticesA, Number_Of_VerticesB, Axis(Number_Of_Axes), Offset, TAxis(Number_Of_Axes))) = False Then Return False

            Number_Of_Axes = Number_Of_Axes + 1
            J = I
        Next I

        If (Find_Minimum_Translation_Distance(Axis, TAxis, Number_Of_Axes, N, T)) = False Then Return False

        If N * Offset < 0 Then
            N.X = -N.X
            N.Y = -N.Y
        End If

        Return True
    End Function

    Public Sub Get_Interval(ByRef Vertex_List() As Vector2D, ByRef Number_Of_Vertices As Integer, ByRef Axis As Vector2D, ByRef Min As Single, ByRef Max As Single)
        Min = Vertex_List(0) * Axis
        Max = Vertex_List(0) * Axis

        Dim I As Integer

        For I = 1 To Number_Of_Vertices - 1
            Dim D As Single = Vertex_List(I) * Axis

            If (D < Min) Then
                Min = D
            ElseIf (D > Max) Then
                Max = D
            End If
        Next I
    End Sub

    Public Function Interval_Intersect(ByRef A() As Vector2D, ByRef B() As Vector2D, ByRef Number_Of_VerticesA As Integer, ByRef Number_Of_VerticesB As Integer, ByRef Axis As Vector2D, ByRef Offset As Vector2D, ByRef TAxis As Single) As Boolean
        Dim Min(1) As Single, Max(1) As Single

        Get_Interval(A, Number_Of_VerticesA, Axis, Min(0), Max(0))
        Get_Interval(B, Number_Of_VerticesB, Axis, Min(1), Max(1))

        Dim h As Single : h = Offset * Axis

        Min(0) = Min(0) + h
        Max(0) = Max(0) + h

        Dim D0 As Single : D0 = Min(0) - Max(1)
        Dim D1 As Single : D1 = Min(1) - Max(0)

        If ((D0 > 0) Or (D1 > 0)) Then
            Return False
        Else
            If D0 > D1 Then
                TAxis = D0
            Else
                TAxis = D1
            End If

            Return True
        End If
    End Function

    Public Function Normalize(ByRef A As Vector2D) As Single
        Dim Length As Single = CSng(Math.Sqrt(A.X * A.X + A.Y * A.Y))

        If (Length = 0) Then
            Return 0
        End If

        A = A * (1 / Length)
        Return Length
    End Function

    Public Function Find_Minimum_Translation_Distance(ByRef Axis() As Vector2D, ByRef TAxis() As Single, ByRef Number_Of_Axes As Integer, ByRef N As Vector2D, ByRef T As Single) As Boolean
        Dim Mini As Integer : Mini = -1

        T = 0
        N = New Vector2D(0, 0)

        Dim I As Integer

        For I = 0 To Number_Of_Axes - 1
            Dim N2 As Single = Normalize(Axis(I))

            TAxis(I) = TAxis(I) / N2

            If TAxis(I) > T Or Mini = -1 Then
                Mini = I
                T = TAxis(I)
                N = Axis(I)
            End If
        Next I

        Return (Mini <> -1)
    End Function

    Public Sub Collision_Detection()
        'Used to hold boundries
        Dim Vertex_List(3) As Vector2D
        Dim Vertex_List2(3) As Vector2D

        Dim Position As Vector2D

        If Collision_Disabled = False Then
            'Sprite boundry
            Vertex_List(0) = Sprite_Vertex(0)
            Vertex_List(1) = Sprite_Vertex(1)
            Vertex_List(2) = Sprite_Vertex(3)
            Vertex_List(3) = Sprite_Vertex(2)

            'Pipe boundry
            Vertex_List2(0) = Pipe_Boundry1(0)
            Vertex_List2(1) = Pipe_Boundry1(1)
            Vertex_List2(2) = Pipe_Boundry1(3)
            Vertex_List2(3) = Pipe_Boundry1(2)

            'Check for sprite to ground collision between the two boundries obtained
            Sprite(0).Physics.Collided = Collide(Vertex_List, Vertex_List2, 4, 4, Sprite(0).Physics.Position - Pipe_Position(0), Sprite(0).Ncoll, Sprite(0).Dcoll)

            'If a collision occured with a sprite, do a collision response
            If Sprite(0).Physics.Collided = True Then
                Collision_Response()
                Exit Sub
            End If

            'Sprite boundry
            Vertex_List(0) = Sprite_Vertex(0)
            Vertex_List(1) = Sprite_Vertex(1)
            Vertex_List(2) = Sprite_Vertex(3)
            Vertex_List(3) = Sprite_Vertex(2)

            'Pipe boundry
            Vertex_List2(0) = Pipe_Boundry2(0)
            Vertex_List2(1) = Pipe_Boundry2(1)
            Vertex_List2(2) = Pipe_Boundry2(3)
            Vertex_List2(3) = Pipe_Boundry2(2)

            'Check for sprite to ground collision between the two boundries obtained
            Sprite(0).Physics.Collided = Collide(Vertex_List, Vertex_List2, 4, 4, Sprite(0).Physics.Position - Pipe_Position(1), Sprite(0).Ncoll, Sprite(0).Dcoll)

            'If a collision occured with a sprite, do a collision response
            If Sprite(0).Physics.Collided = True Then
                Collision_Response()
                Exit Sub
            End If

            'Sprite boundry
            Vertex_List(0) = Sprite_Vertex(0)
            Vertex_List(1) = Sprite_Vertex(1)
            Vertex_List(2) = Sprite_Vertex(3)
            Vertex_List(3) = Sprite_Vertex(2)

            'Pipe boundry
            Vertex_List2(0) = Pipe_Boundry3(0)
            Vertex_List2(1) = Pipe_Boundry3(1)
            Vertex_List2(2) = Pipe_Boundry3(3)
            Vertex_List2(3) = Pipe_Boundry3(2)

            'Check for sprite to ground collision between the two boundries obtained
            Sprite(0).Physics.Collided = Collide(Vertex_List, Vertex_List2, 4, 4, Sprite(0).Physics.Position - Pipe_Position(2), Sprite(0).Ncoll, Sprite(0).Dcoll)

            'If a collision occured with a sprite, do a collision response
            If Sprite(0).Physics.Collided = True Then
                Collision_Response()
                Exit Sub
            End If


            'Sprite boundry
            Vertex_List(0) = Sprite_Vertex(0)
            Vertex_List(1) = Sprite_Vertex(1)
            Vertex_List(2) = Sprite_Vertex(3)
            Vertex_List(3) = Sprite_Vertex(2)

            'Pipe boundry
            Vertex_List2(0) = Pipe_Boundry4(0)
            Vertex_List2(1) = Pipe_Boundry4(1)
            Vertex_List2(2) = Pipe_Boundry4(3)
            Vertex_List2(3) = Pipe_Boundry4(2)

            'Check for sprite to ground collision between the two boundries obtained
            Sprite(0).Physics.Collided = Collide(Vertex_List, Vertex_List2, 4, 4, Sprite(0).Physics.Position - Pipe_Position(3), Sprite(0).Ncoll, Sprite(0).Dcoll)

            'If a collision occured with a sprite, do a collision response
            If Sprite(0).Physics.Collided = True Then
                Collision_Response()
                Exit Sub
            End If

            'Sprite boundry
            Vertex_List(0) = Sprite_Vertex(0)
            Vertex_List(1) = Sprite_Vertex(1)
            Vertex_List(2) = Sprite_Vertex(3)
            Vertex_List(3) = Sprite_Vertex(2)

            'Pipe boundry
            Vertex_List2(0) = Pipe_Boundry5(0)
            Vertex_List2(1) = Pipe_Boundry5(1)
            Vertex_List2(2) = Pipe_Boundry5(3)
            Vertex_List2(3) = Pipe_Boundry5(2)

            'Check for sprite to ground collision between the two boundries obtained
            Sprite(0).Physics.Collided = Collide(Vertex_List, Vertex_List2, 4, 4, Sprite(0).Physics.Position - Pipe_Position(4), Sprite(0).Ncoll, Sprite(0).Dcoll)

            'If a collision occured with a sprite, do a collision response
            If Sprite(0).Physics.Collided = True Then
                Collision_Response()
                Exit Sub
            End If

            'Sprite boundry
            Vertex_List(0) = Sprite_Vertex(0)
            Vertex_List(1) = Sprite_Vertex(1)
            Vertex_List(2) = Sprite_Vertex(3)
            Vertex_List(3) = Sprite_Vertex(2)

            'Pipe boundry
            Vertex_List2(0) = Pipe_Boundry6(0)
            Vertex_List2(1) = Pipe_Boundry6(1)
            Vertex_List2(2) = Pipe_Boundry6(3)
            Vertex_List2(3) = Pipe_Boundry6(2)

            'Check for sprite to ground collision between the two boundries obtained
            Sprite(0).Physics.Collided = Collide(Vertex_List, Vertex_List2, 4, 4, Sprite(0).Physics.Position - Pipe_Position(5), Sprite(0).Ncoll, Sprite(0).Dcoll)

            'If a collision occured with a sprite, do a collision response
            If Sprite(0).Physics.Collided = True Then
                Collision_Response()
                Exit Sub
            End If
        End If

        Position = New Vector2D(0, 600)

        'Sprite boundry
        Vertex_List(0) = Sprite_Vertex(0)
        Vertex_List(1) = Sprite_Vertex(1)
        Vertex_List(2) = Sprite_Vertex(3)
        Vertex_List(3) = Sprite_Vertex(2)

        'Ground boundry
        Vertex_List2(0) = New Vector2D(0, 0)
        Vertex_List2(1) = New Vector2D(462, 0)
        Vertex_List2(2) = New Vector2D(462, 168)
        Vertex_List2(3) = New Vector2D(0, 168)

        'Check for sprite to ground collision between the two boundries obtained
        Sprite(0).Physics.Collided = Collide(Vertex_List, Vertex_List2, 4, 4, Sprite(0).Physics.Position - Position, Sprite(0).Ncoll, Sprite(0).Dcoll)

        If Sprite(0).Physics.Collided = True Then
            Collision_Response()
            Exit Sub
        End If

        'Fail safe so the sprite never passes the ground no matter how fast the sprite is
        If Sprite(0).Physics.Position.Y >= 575 Then
            Sprite(0).Physics.Velocity.Y = 0
            Sprite(0).Physics.Position.Y = 575
            Game_Active = False
        End If

    End Sub

    Public Sub Collision_Response()
        Game_Active = False
        Sprite(0).Physics.Position = (Sprite(0).Physics.Position - (Sprite(0).Ncoll * CSng(Sprite(0).Dcoll * 1.01)))
        Sprite(0).Physics.Velocity = New Vector2D(0, 0)
        If Death = False Then
            Death = True
            Play_Sound(Sound_Buffer(1))
            If Sprite(0).Physics.Velocity.Y <= 1 Then
                Game_Over_Fade_Transparent_Enabled = True
                Game_Over_Fade_Transparent_Milliseconds = Get_Elapsed_Time()
            End If
        End If
    End Sub
End Module
