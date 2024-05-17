Option Explicit On
Option Strict On

Public Class clsPhysics
    Public Const EARTH_GRAVITY As Single = 9.80665
    Public Const MOON_GRAVITY As Single = 1.6249
    Public Const POUNDS_TO_KG As Single = 0.45359237
    Public Const Time_Step As Single = 1 / 60

    Public Position As Vector2D
    Public Velocity As Vector2D
    Public Acceleration As Vector2D
    Public Force As Vector2D
    Public Mass As Single
    Public One_Over_Mass As Single

    Public Time As Single
    Public Delta_Time As Single
    Public Accumulator As Single

    Public Collided As Boolean

    Public Sub Integrate(ByRef Sprite As Sprite_Type, ByRef dt As Single)
        Dim k1 As Vector2D, k2 As Vector2D, k3 As Vector2D, k4 As Vector2D
        Dim l1 As Vector2D, l2 As Vector2D, l3 As Vector2D, l4 As Vector2D

        Dim Temp As Vector2D

        With Sprite.Physics
            .Acceleration.X = .Force.X * .One_Over_Mass
            .Acceleration.Y = .Force.Y * .One_Over_Mass

            Temp.X = dt * .Acceleration.X
            Temp.Y = dt * .Acceleration.Y

            k1.X = dt * .Velocity.X
            k1.Y = dt * .Velocity.Y
            l1.X = Temp.X
            l1.Y = Temp.Y

            k2.X = dt * (.Velocity.X + k1.X / 2)
            k2.Y = dt * (.Velocity.Y + k1.Y / 2)
            l2.X = Temp.X
            l2.Y = Temp.Y

            k3.X = dt * (.Velocity.X + k2.X / 2)
            k3.Y = dt * (.Velocity.Y + k2.Y / 2)
            l3.X = Temp.X
            l3.Y = Temp.Y

            k4.X = dt * (.Velocity.X + k3.X)
            k4.Y = dt * (.Velocity.Y + k3.Y)
            l4.X = Temp.X
            l4.Y = Temp.Y

            .Position.X = .Position.X + (k1.X / 6 + k2.X / 3 + k3.X / 3 + k4.X / 6) * Scalar
            .Position.Y = .Position.Y + (k1.Y / 6 + k2.Y / 3 + k3.Y / 3 + k4.Y / 6) * Scalar
            .Velocity.X = .Velocity.X + (l1.X / 6 + l2.X / 3 + l3.X / 3 + l4.X / 6)
            .Velocity.Y = .Velocity.Y + (l1.Y / 6 + l2.Y / 3 + l3.Y / 3 + l4.Y / 6)
        End With
    End Sub

    Public Function Calculate_Gravitational_Force(ByRef m As Single, ByRef g As Single) As Single
        Return m * g
    End Function

    Public Sub Update()
        If Game_Active = True Or Death = True Then
            Force.Y = Calculate_Gravitational_Force(Mass, Gravity)
        ElseIf Game_Active = False And Death = False Then
            Force.Y = 0
        End If

        Delta_Time = Get_Elapsed_Time_Per_Frame()
        If Delta_Time > 0.25 Then Delta_Time = 0.25
        Accumulator = Accumulator + Delta_Time

        While (Accumulator >= Time_Step)
            Accumulator = Accumulator - Time_Step
            Sprite(0).Physics.Integrate(Sprite(0), Time_Step)
            Time = Time + Time_Step
        End While
    End Sub
End Class
