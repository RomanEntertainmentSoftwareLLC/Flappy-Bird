Option Explicit On
Option Strict On

Public Module modMath
    Public Structure Vector2D
        Dim X As Single
        Dim Y As Single

        Public Sub New(ByVal X As Single, ByVal Y As Single)
            Me.X = X
            Me.Y = Y
        End Sub

        Public Shared Operator -(ByVal A As Vector2D, ByVal B As Vector2D) As Vector2D
            Return New Vector2D(A.X - B.X, A.Y - B.Y)
        End Operator

        Public Overloads Shared Operator *(ByVal A As Vector2D, ByVal B As Vector2D) As Single
            Return A.X * B.X + A.Y * B.Y
        End Operator

        Public Overloads Shared Operator *(ByVal A As Vector2D, ByVal Value As Single) As Vector2D
            Return New Vector2D(A.X * Value, A.Y * Value)
        End Operator
    End Structure
End Module
