Option Explicit On
Option Strict On

Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D

Public Class frmMain
    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Shutdown()
    End Sub

    Private Sub frmMain_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Shutdown()
        End If
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Main()
    End Sub

    Private Sub frmMain_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If Game_Active = True Then
            Angulator = Angulator_Enum.NEGATIVE
            Sprite(0).Physics.Velocity.Y = Flap_Velocity
            Play_Sound(Sound_Buffer(0))
        Else
            If Fade_In_From_Black_Enabled = False Then
                If Death = False Then
                    Game_Active = True
                    Angulator = Angulator_Enum.NEGATIVE
                    Sprite(0).Physics.Velocity.Y = Flap_Velocity
                    Get_Ready_Fade_Transparent_Milliseconds = Get_Elapsed_Time()
                    Get_Ready_Fade_Transparent_Enabled = True
                    Play_Sound(Sound_Buffer(0))
                Else
                    If Game_Over_Fade_Transparent_Enabled = False Then
                        If Sprite(0).Physics.Velocity.Y <= 1 Then
                            If Fade_Out_To_Black_Enabled = False Then
                                Fade_Out_To_Black_Milliseconds = Get_Elapsed_Time()
                                Fade_Out_To_Black_Enabled = True
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        Shutdown()
    End Sub

    Private Sub mnuMouthGap100_Click(sender As Object, e As EventArgs) Handles mnuMouthGap100.Click
        GAP_Y = 100
        mnuMouthGap100.Checked = True
        mnuMouthGap125.Checked = False
        mnuMouthGap150.Checked = False
        mnuMouthGap175.Checked = False
        mnuMouthGap200.Checked = False
        mnuMouthGap225.Checked = False
    End Sub

    Private Sub mnuMouthGap125_Click(sender As Object, e As EventArgs) Handles mnuMouthGap125.Click
        GAP_Y = 125
        mnuMouthGap100.Checked = False
        mnuMouthGap125.Checked = True
        mnuMouthGap150.Checked = False
        mnuMouthGap175.Checked = False
        mnuMouthGap200.Checked = False
        mnuMouthGap225.Checked = False
    End Sub

    Private Sub mnuMouthGap150_Click(sender As Object, e As EventArgs) Handles mnuMouthGap150.Click
        GAP_Y = 150
        mnuMouthGap100.Checked = False
        mnuMouthGap125.Checked = False
        mnuMouthGap150.Checked = True
        mnuMouthGap175.Checked = False
        mnuMouthGap200.Checked = False
        mnuMouthGap225.Checked = False
    End Sub

    Private Sub mnuMouthGap175_Click(sender As Object, e As EventArgs) Handles mnuMouthGap175.Click
        GAP_Y = 175
        mnuMouthGap100.Checked = False
        mnuMouthGap125.Checked = False
        mnuMouthGap150.Checked = False
        mnuMouthGap175.Checked = True
        mnuMouthGap200.Checked = False
        mnuMouthGap225.Checked = False
    End Sub

    Private Sub mnuMouthGap200_Click(sender As Object, e As EventArgs) Handles mnuMouthGap200.Click
        GAP_Y = 200
        mnuMouthGap100.Checked = False
        mnuMouthGap125.Checked = False
        mnuMouthGap150.Checked = False
        mnuMouthGap175.Checked = False
        mnuMouthGap200.Checked = True
        mnuMouthGap225.Checked = False
    End Sub

    Private Sub mnuMouthGap225_Click(sender As Object, e As EventArgs) Handles mnuMouthGap225.Click
        GAP_Y = 225
        mnuMouthGap100.Checked = False
        mnuMouthGap125.Checked = False
        mnuMouthGap150.Checked = False
        mnuMouthGap175.Checked = False
        mnuMouthGap200.Checked = False
        mnuMouthGap225.Checked = True
    End Sub

    Private Sub mnuGravityEarth_Click(sender As Object, e As EventArgs) Handles mnuGravityEarth.Click
        Gravity = clsPhysics.EARTH_GRAVITY
        mnuGravityEarth.Checked = True
        mnuGravityMoon.Checked = False
        mnuGravity0.Checked = False
        mnuGravity05.Checked = False
        mnuGravity1.Checked = False
        mnuGravity15.Checked = False
        mnuGravity2.Checked = False
        mnuGravity25.Checked = False
        mnuGravity3.Checked = False
        mnuGravity35.Checked = False
        mnuGravity4.Checked = False
        mnuGravity45.Checked = False
        mnuGravity5.Checked = False
        mnuGravity55.Checked = False
        mnuGravity6.Checked = False
        mnuGravity65.Checked = False
        mnuGravity7.Checked = False
        mnugravity75.checked = False
        mnuGravity8.Checked = False
        mnuGravity85.Checked = False
        mnuGravity9.Checked = False
    End Sub

    Private Sub mnuGravity0_Click(sender As Object, e As EventArgs) Handles mnuGravity0.Click
        Gravity = 0
        mnuGravityEarth.Checked = False
        mnuGravityMoon.Checked = False
        mnuGravity0.Checked = True
        mnuGravity05.Checked = False
        mnuGravity1.Checked = False
        mnuGravity15.Checked = False
        mnuGravity2.Checked = False
        mnuGravity25.Checked = False
        mnuGravity3.Checked = False
        mnuGravity35.Checked = False
        mnuGravity4.Checked = False
        mnuGravity45.Checked = False
        mnuGravity5.Checked = False
        mnuGravity55.Checked = False
        mnuGravity6.Checked = False
        mnuGravity65.Checked = False
        mnuGravity7.Checked = False
        mnuGravity75.Checked = False
        mnuGravity8.Checked = False
        mnuGravity85.Checked = False
        mnuGravity9.Checked = False
    End Sub

    Private Sub mnuGravity05_Click(sender As Object, e As EventArgs) Handles mnuGravity05.Click
        Gravity = 0.5
        mnuGravityEarth.Checked = False
        mnuGravityMoon.Checked = False
        mnuGravity0.Checked = False
        mnuGravity05.Checked = True
        mnuGravity1.Checked = False
        mnuGravity15.Checked = False
        mnuGravity2.Checked = False
        mnuGravity25.Checked = False
        mnuGravity3.Checked = False
        mnuGravity35.Checked = False
        mnuGravity4.Checked = False
        mnuGravity45.Checked = False
        mnuGravity5.Checked = False
        mnuGravity55.Checked = False
        mnuGravity6.Checked = False
        mnuGravity65.Checked = False
        mnuGravity7.Checked = False
        mnuGravity75.Checked = False
        mnuGravity8.Checked = False
        mnuGravity85.Checked = False
        mnuGravity9.Checked = False
    End Sub

    Private Sub mnuGravity1_Click(sender As Object, e As EventArgs) Handles mnuGravity1.Click
        Gravity = 1
        mnuGravityEarth.Checked = False
        mnuGravityMoon.Checked = False
        mnuGravity0.Checked = False
        mnuGravity05.Checked = False
        mnuGravity1.Checked = True
        mnuGravity15.Checked = False
        mnuGravity2.Checked = False
        mnuGravity25.Checked = False
        mnuGravity3.Checked = False
        mnuGravity35.Checked = False
        mnuGravity4.Checked = False
        mnuGravity45.Checked = False
        mnuGravity5.Checked = False
        mnuGravity55.Checked = False
        mnuGravity6.Checked = False
        mnuGravity65.Checked = False
        mnuGravity7.Checked = False
        mnuGravity75.Checked = False
        mnuGravity8.Checked = False
        mnuGravity85.Checked = False
        mnuGravity9.Checked = False
    End Sub

    Private Sub mnuGravity15_Click(sender As Object, e As EventArgs) Handles mnuGravity15.Click
        Gravity = 1.5
        mnuGravityEarth.Checked = False
        mnuGravityMoon.Checked = False
        mnuGravity0.Checked = False
        mnuGravity05.Checked = False
        mnuGravity1.Checked = False
        mnuGravity15.Checked = True
        mnuGravity2.Checked = False
        mnuGravity25.Checked = False
        mnuGravity3.Checked = False
        mnuGravity35.Checked = False
        mnuGravity4.Checked = False
        mnuGravity45.Checked = False
        mnuGravity5.Checked = False
        mnuGravity55.Checked = False
        mnuGravity6.Checked = False
        mnuGravity65.Checked = False
        mnuGravity7.Checked = False
        mnuGravity75.Checked = False
        mnuGravity8.Checked = False
        mnuGravity85.Checked = False
        mnuGravity9.Checked = False
    End Sub

    Private Sub mnuGravity2_Click(sender As Object, e As EventArgs) Handles mnuGravity2.Click
        Gravity = 2
        mnuGravityEarth.Checked = False
        mnuGravityMoon.Checked = False
        mnuGravity0.Checked = False
        mnuGravity05.Checked = False
        mnuGravity1.Checked = False
        mnuGravity15.Checked = False
        mnuGravity2.Checked = True
        mnuGravity25.Checked = False
        mnuGravity3.Checked = False
        mnuGravity35.Checked = False
        mnuGravity4.Checked = False
        mnuGravity45.Checked = False
        mnuGravity5.Checked = False
        mnuGravity55.Checked = False
        mnuGravity6.Checked = False
        mnuGravity65.Checked = False
        mnuGravity7.Checked = False
        mnuGravity75.Checked = False
        mnuGravity8.Checked = False
        mnuGravity85.Checked = False
        mnuGravity9.Checked = False
    End Sub

    Private Sub mnuGravity25_Click(sender As Object, e As EventArgs) Handles mnuGravity25.Click
        Gravity = 2.5
        mnuGravityEarth.Checked = False
        mnuGravityMoon.Checked = False
        mnuGravity0.Checked = False
        mnuGravity05.Checked = False
        mnuGravity1.Checked = False
        mnuGravity15.Checked = False
        mnuGravity2.Checked = False
        mnuGravity25.Checked = True
        mnuGravity3.Checked = False
        mnuGravity35.Checked = False
        mnuGravity4.Checked = False
        mnuGravity45.Checked = False
        mnuGravity5.Checked = False
        mnuGravity55.Checked = False
        mnuGravity6.Checked = False
        mnuGravity65.Checked = False
        mnuGravity7.Checked = False
        mnuGravity75.Checked = False
        mnuGravity8.Checked = False
        mnuGravity85.Checked = False
        mnuGravity9.Checked = False
    End Sub

    Private Sub mnuGravity3_Click(sender As Object, e As EventArgs) Handles mnuGravity3.Click
        Gravity = 3
        mnuGravityEarth.Checked = False
        mnuGravityMoon.Checked = False
        mnuGravity0.Checked = False
        mnuGravity05.Checked = False
        mnuGravity1.Checked = False
        mnuGravity15.Checked = False
        mnuGravity2.Checked = False
        mnuGravity25.Checked = False
        mnuGravity3.Checked = True
        mnuGravity35.Checked = False
        mnuGravity4.Checked = False
        mnuGravity45.Checked = False
        mnuGravity5.Checked = False
        mnuGravity55.Checked = False
        mnuGravity6.Checked = False
        mnuGravity65.Checked = False
        mnuGravity7.Checked = False
        mnuGravity75.Checked = False
        mnuGravity8.Checked = False
        mnuGravity85.Checked = False
        mnuGravity9.Checked = False
    End Sub

    Private Sub mnuGravity35_Click(sender As Object, e As EventArgs) Handles mnuGravity35.Click
        Gravity = 3.5
        mnuGravityEarth.Checked = True
        mnuGravityMoon.Checked = False
        mnuGravity0.Checked = False
        mnuGravity05.Checked = False
        mnuGravity1.Checked = False
        mnuGravity15.Checked = False
        mnuGravity2.Checked = False
        mnuGravity25.Checked = False
        mnuGravity3.Checked = False
        mnuGravity35.Checked = True
        mnuGravity4.Checked = False
        mnuGravity45.Checked = False
        mnuGravity5.Checked = False
        mnuGravity55.Checked = False
        mnuGravity6.Checked = False
        mnuGravity65.Checked = False
        mnuGravity7.Checked = False
        mnuGravity75.Checked = False
        mnuGravity8.Checked = False
        mnuGravity85.Checked = False
        mnuGravity9.Checked = False
    End Sub

    Private Sub mnuGravity4_Click(sender As Object, e As EventArgs) Handles mnuGravity4.Click
        Gravity = 4
        mnuGravityEarth.Checked = False
        mnuGravityMoon.Checked = False
        mnuGravity0.Checked = False
        mnuGravity05.Checked = False
        mnuGravity1.Checked = False
        mnuGravity15.Checked = False
        mnuGravity2.Checked = False
        mnuGravity25.Checked = False
        mnuGravity3.Checked = False
        mnuGravity35.Checked = False
        mnuGravity4.Checked = True
        mnuGravity45.Checked = False
        mnuGravity5.Checked = False
        mnuGravity55.Checked = False
        mnuGravity6.Checked = False
        mnuGravity65.Checked = False
        mnuGravity7.Checked = False
        mnuGravity75.Checked = False
        mnuGravity8.Checked = False
        mnuGravity85.Checked = False
        mnuGravity9.Checked = False
    End Sub

    Private Sub mnuGravity45_Click(sender As Object, e As EventArgs) Handles mnuGravity45.Click
        Gravity = 4.5
        mnuGravityEarth.Checked = False
        mnuGravityMoon.Checked = False
        mnuGravity0.Checked = False
        mnuGravity05.Checked = False
        mnuGravity1.Checked = False
        mnuGravity15.Checked = False
        mnuGravity2.Checked = False
        mnuGravity25.Checked = False
        mnuGravity3.Checked = False
        mnuGravity35.Checked = False
        mnuGravity4.Checked = False
        mnuGravity45.Checked = True
        mnuGravity5.Checked = False
        mnuGravity55.Checked = False
        mnuGravity6.Checked = False
        mnuGravity65.Checked = False
        mnuGravity7.Checked = False
        mnuGravity75.Checked = False
        mnuGravity8.Checked = False
        mnuGravity85.Checked = False
        mnuGravity9.Checked = False
    End Sub

    Private Sub mnuGravity5_Click(sender As Object, e As EventArgs) Handles mnuGravity5.Click
        Gravity = 5
        mnuGravityEarth.Checked = False
        mnuGravityMoon.Checked = False
        mnuGravity0.Checked = False
        mnuGravity05.Checked = False
        mnuGravity1.Checked = False
        mnuGravity15.Checked = False
        mnuGravity2.Checked = False
        mnuGravity25.Checked = False
        mnuGravity3.Checked = False
        mnuGravity35.Checked = False
        mnuGravity4.Checked = False
        mnuGravity45.Checked = False
        mnuGravity5.Checked = True
        mnuGravity55.Checked = False
        mnuGravity6.Checked = False
        mnuGravity65.Checked = False
        mnuGravity7.Checked = False
        mnuGravity75.Checked = False
        mnuGravity8.Checked = False
        mnuGravity85.Checked = False
        mnuGravity9.Checked = False
    End Sub

    Private Sub mnuGravity55_Click(sender As Object, e As EventArgs) Handles mnuGravity55.Click
        Gravity = 5.5
        mnuGravityEarth.Checked = False
        mnuGravityMoon.Checked = False
        mnuGravity0.Checked = False
        mnuGravity05.Checked = False
        mnuGravity1.Checked = False
        mnuGravity15.Checked = False
        mnuGravity2.Checked = False
        mnuGravity25.Checked = False
        mnuGravity3.Checked = False
        mnuGravity35.Checked = False
        mnuGravity4.Checked = False
        mnuGravity45.Checked = False
        mnuGravity5.Checked = False
        mnuGravity55.Checked = True
        mnuGravity6.Checked = False
        mnuGravity65.Checked = False
        mnuGravity7.Checked = False
        mnuGravity75.Checked = False
        mnuGravity8.Checked = False
        mnuGravity85.Checked = False
        mnuGravity9.Checked = False
    End Sub

    Private Sub mnuGravity6_Click(sender As Object, e As EventArgs) Handles mnuGravity6.Click
        Gravity = 6
        mnuGravityEarth.Checked = False
        mnuGravityMoon.Checked = False
        mnuGravity0.Checked = False
        mnuGravity05.Checked = False
        mnuGravity1.Checked = False
        mnuGravity15.Checked = False
        mnuGravity2.Checked = False
        mnuGravity25.Checked = False
        mnuGravity3.Checked = False
        mnuGravity35.Checked = False
        mnuGravity4.Checked = False
        mnuGravity45.Checked = False
        mnuGravity5.Checked = False
        mnuGravity55.Checked = False
        mnuGravity6.Checked = True
        mnuGravity65.Checked = False
        mnuGravity7.Checked = False
        mnuGravity75.Checked = False
        mnuGravity8.Checked = False
        mnuGravity85.Checked = False
        mnuGravity9.Checked = False
    End Sub

    Private Sub mnuGravity65_Click(sender As Object, e As EventArgs) Handles mnuGravity65.Click
        Gravity = 6.5
        mnuGravityEarth.Checked = False
        mnuGravityMoon.Checked = False
        mnuGravity0.Checked = False
        mnuGravity05.Checked = False
        mnuGravity1.Checked = False
        mnuGravity15.Checked = False
        mnuGravity2.Checked = False
        mnuGravity25.Checked = False
        mnuGravity3.Checked = False
        mnuGravity35.Checked = False
        mnuGravity4.Checked = False
        mnuGravity45.Checked = False
        mnuGravity5.Checked = False
        mnuGravity55.Checked = False
        mnuGravity6.Checked = False
        mnuGravity65.Checked = True
        mnuGravity7.Checked = False
        mnuGravity75.Checked = False
        mnuGravity8.Checked = False
        mnuGravity85.Checked = False
        mnuGravity9.Checked = False
    End Sub

    Private Sub mnuGravity7_Click(sender As Object, e As EventArgs) Handles mnuGravity7.Click
        Gravity = 7
        mnuGravityEarth.Checked = False
        mnuGravityMoon.Checked = False
        mnuGravity0.Checked = False
        mnuGravity05.Checked = False
        mnuGravity1.Checked = False
        mnuGravity15.Checked = False
        mnuGravity2.Checked = False
        mnuGravity25.Checked = False
        mnuGravity3.Checked = False
        mnuGravity35.Checked = False
        mnuGravity4.Checked = False
        mnuGravity45.Checked = False
        mnuGravity5.Checked = False
        mnuGravity55.Checked = False
        mnuGravity6.Checked = False
        mnuGravity65.Checked = False
        mnuGravity7.Checked = True
        mnuGravity75.Checked = False
        mnuGravity8.Checked = False
        mnuGravity85.Checked = False
        mnuGravity9.Checked = False
    End Sub

    Private Sub mnuGravity75_Click(sender As Object, e As EventArgs) Handles mnuGravity75.Click
        Gravity = 7.5
        mnuGravityEarth.Checked = False
        mnuGravityMoon.Checked = False
        mnuGravity0.Checked = False
        mnuGravity05.Checked = False
        mnuGravity1.Checked = False
        mnuGravity15.Checked = False
        mnuGravity2.Checked = False
        mnuGravity25.Checked = False
        mnuGravity3.Checked = False
        mnuGravity35.Checked = False
        mnuGravity4.Checked = False
        mnuGravity45.Checked = False
        mnuGravity5.Checked = False
        mnuGravity55.Checked = False
        mnuGravity6.Checked = False
        mnuGravity65.Checked = False
        mnuGravity7.Checked = False
        mnuGravity75.Checked = True
        mnuGravity8.Checked = False
        mnuGravity85.Checked = False
        mnuGravity9.Checked = False
    End Sub

    Private Sub mnuGravity8_Click(sender As Object, e As EventArgs) Handles mnuGravity8.Click
        Gravity = 8
        mnuGravityEarth.Checked = False
        mnuGravityMoon.Checked = False
        mnuGravity0.Checked = False
        mnuGravity05.Checked = False
        mnuGravity1.Checked = False
        mnuGravity15.Checked = False
        mnuGravity2.Checked = False
        mnuGravity25.Checked = False
        mnuGravity3.Checked = False
        mnuGravity35.Checked = False
        mnuGravity4.Checked = False
        mnuGravity45.Checked = False
        mnuGravity5.Checked = False
        mnuGravity55.Checked = False
        mnuGravity6.Checked = False
        mnuGravity65.Checked = False
        mnuGravity7.Checked = False
        mnuGravity75.Checked = False
        mnuGravity8.Checked = True
        mnuGravity85.Checked = False
        mnuGravity9.Checked = False
    End Sub

    Private Sub mnuGravity85_Click(sender As Object, e As EventArgs) Handles mnuGravity85.Click
        Gravity = 8.5
        mnuGravityEarth.Checked = False
        mnuGravityMoon.Checked = False
        mnuGravity0.Checked = False
        mnuGravity05.Checked = False
        mnuGravity1.Checked = False
        mnuGravity15.Checked = False
        mnuGravity2.Checked = False
        mnuGravity25.Checked = False
        mnuGravity3.Checked = False
        mnuGravity35.Checked = False
        mnuGravity4.Checked = False
        mnuGravity45.Checked = False
        mnuGravity5.Checked = False
        mnuGravity55.Checked = False
        mnuGravity6.Checked = False
        mnuGravity65.Checked = False
        mnuGravity7.Checked = False
        mnuGravity75.Checked = False
        mnuGravity8.Checked = False
        mnuGravity85.Checked = True
        mnuGravity9.Checked = False
    End Sub

    Private Sub mnuGravity9_Click(sender As Object, e As EventArgs) Handles mnuGravity9.Click
        Gravity = 9
        mnuGravityEarth.Checked = False
        mnuGravityMoon.Checked = False
        mnuGravity0.Checked = False
        mnuGravity05.Checked = False
        mnuGravity1.Checked = False
        mnuGravity15.Checked = False
        mnuGravity2.Checked = False
        mnuGravity25.Checked = False
        mnuGravity3.Checked = False
        mnuGravity35.Checked = False
        mnuGravity4.Checked = False
        mnuGravity45.Checked = False
        mnuGravity5.Checked = False
        mnuGravity55.Checked = False
        mnuGravity6.Checked = False
        mnuGravity65.Checked = False
        mnuGravity7.Checked = False
        mnuGravity75.Checked = False
        mnuGravity8.Checked = False
        mnuGravity85.Checked = False
        mnuGravity9.Checked = True
    End Sub

    Private Sub mnuGravityMoon_Click(sender As Object, e As EventArgs) Handles mnuGravityMoon.Click
        Gravity = clsPhysics.MOON_GRAVITY
        mnuGravityEarth.Checked = False
        mnuGravityMoon.Checked = True
        mnuGravity0.Checked = False
        mnuGravity05.Checked = False
        mnuGravity1.Checked = False
        mnuGravity15.Checked = False
        mnuGravity2.Checked = False
        mnuGravity25.Checked = False
        mnuGravity3.Checked = False
        mnuGravity35.Checked = False
        mnuGravity4.Checked = False
        mnuGravity45.Checked = False
        mnuGravity5.Checked = False
        mnuGravity55.Checked = False
        mnuGravity6.Checked = False
        mnuGravity65.Checked = False
        mnuGravity7.Checked = False
        mnuGravity75.Checked = False
        mnuGravity8.Checked = False
        mnuGravity85.Checked = False
        mnuGravity9.Checked = False
    End Sub

    Private Sub mnuFlapVelocity1_Click(sender As Object, e As EventArgs) Handles mnuFlapVelocity1.Click
        Flap_Velocity = -1
        mnuFlapVelocity1.Checked = True
        mnuFlapVelocity15.Checked = False
        mnuFlapVelocity2.Checked = False
        mnuFlapVelocity25.Checked = False
        mnuFlapVelocity3.Checked = False
        mnuFlapVelocity35.Checked = False
        mnuFlapVelocity4.Checked = False
        mnuFlapVelocity45.Checked = False
        mnuFlapVelocity5.Checked = False
    End Sub

    Private Sub mnuFlapVelocity15_Click(sender As Object, e As EventArgs) Handles mnuFlapVelocity15.Click
        Flap_Velocity = -1.5
        mnuFlapVelocity1.Checked = False
        mnuFlapVelocity15.Checked = True
        mnuFlapVelocity2.Checked = False
        mnuFlapVelocity25.Checked = False
        mnuFlapVelocity3.Checked = False
        mnuFlapVelocity35.Checked = False
        mnuFlapVelocity4.Checked = False
        mnuFlapVelocity45.Checked = False
        mnuFlapVelocity5.Checked = False
    End Sub

    Private Sub mnuFlapVelocity2_Click(sender As Object, e As EventArgs) Handles mnuFlapVelocity2.Click
        Flap_Velocity = -2
        mnuFlapVelocity1.Checked = False
        mnuFlapVelocity15.Checked = False
        mnuFlapVelocity2.Checked = True
        mnuFlapVelocity25.Checked = False
        mnuFlapVelocity3.Checked = False
        mnuFlapVelocity35.Checked = False
        mnuFlapVelocity4.Checked = False
        mnuFlapVelocity45.Checked = False
        mnuFlapVelocity5.Checked = False
    End Sub

    Private Sub mnuFlapVelocity25_Click(sender As Object, e As EventArgs) Handles mnuFlapVelocity25.Click
        Flap_Velocity = -2.5
        mnuFlapVelocity1.Checked = False
        mnuFlapVelocity15.Checked = False
        mnuFlapVelocity2.Checked = False
        mnuFlapVelocity25.Checked = True
        mnuFlapVelocity3.Checked = False
        mnuFlapVelocity35.Checked = False
        mnuFlapVelocity4.Checked = False
        mnuFlapVelocity45.Checked = False
        mnuFlapVelocity5.Checked = False
    End Sub

    Private Sub mnuFlapVelocity3_Click(sender As Object, e As EventArgs) Handles mnuFlapVelocity3.Click
        Flap_Velocity = -3
        mnuFlapVelocity1.Checked = False
        mnuFlapVelocity15.Checked = False
        mnuFlapVelocity2.Checked = False
        mnuFlapVelocity25.Checked = False
        mnuFlapVelocity3.Checked = True
        mnuFlapVelocity35.Checked = False
        mnuFlapVelocity4.Checked = False
        mnuFlapVelocity45.Checked = False
        mnuFlapVelocity5.Checked = False
    End Sub

    Private Sub mnuFlapVelocity35_Click(sender As Object, e As EventArgs) Handles mnuFlapVelocity35.Click
        Flap_Velocity = -3.5
        mnuFlapVelocity1.Checked = False
        mnuFlapVelocity15.Checked = False
        mnuFlapVelocity2.Checked = False
        mnuFlapVelocity25.Checked = False
        mnuFlapVelocity3.Checked = False
        mnuFlapVelocity35.Checked = True
        mnuFlapVelocity4.Checked = False
        mnuFlapVelocity45.Checked = False
        mnuFlapVelocity5.Checked = False
    End Sub

    Private Sub mnuFlapVelocity4_Click(sender As Object, e As EventArgs) Handles mnuFlapVelocity4.Click
        Flap_Velocity = -4
        mnuFlapVelocity1.Checked = False
        mnuFlapVelocity15.Checked = False
        mnuFlapVelocity2.Checked = False
        mnuFlapVelocity25.Checked = False
        mnuFlapVelocity3.Checked = False
        mnuFlapVelocity35.Checked = False
        mnuFlapVelocity4.Checked = True
        mnuFlapVelocity45.Checked = False
        mnuFlapVelocity5.Checked = False
    End Sub

    Private Sub mnuFlapVelocity45_Click(sender As Object, e As EventArgs) Handles mnuFlapVelocity45.Click
        Flap_Velocity = -4.5
        mnuFlapVelocity1.Checked = False
        mnuFlapVelocity15.Checked = False
        mnuFlapVelocity2.Checked = False
        mnuFlapVelocity25.Checked = False
        mnuFlapVelocity3.Checked = False
        mnuFlapVelocity35.Checked = False
        mnuFlapVelocity4.Checked = False
        mnuFlapVelocity45.Checked = True
        mnuFlapVelocity5.Checked = False
    End Sub

    Private Sub mnuFlapVelocity5_Click(sender As Object, e As EventArgs) Handles mnuFlapVelocity5.Click
        Flap_Velocity = -5
        mnuFlapVelocity1.Checked = False
        mnuFlapVelocity15.Checked = False
        mnuFlapVelocity2.Checked = False
        mnuFlapVelocity25.Checked = False
        mnuFlapVelocity3.Checked = False
        mnuFlapVelocity35.Checked = False
        mnuFlapVelocity4.Checked = False
        mnuFlapVelocity45.Checked = False
        mnuFlapVelocity5.Checked = True
    End Sub

    Private Sub mnuScalar50_Click(sender As Object, e As EventArgs) Handles mnuScalar50.Click
        Scalar = 50
        mnuScalar50.Checked = True
        mnuScalar100.Checked = False
        mnuScalar150.Checked = False
        mnuScalar200.Checked = False
    End Sub

    Private Sub mnuScalar100_Click(sender As Object, e As EventArgs) Handles mnuScalar100.Click
        Scalar = 100
        mnuScalar50.Checked = False
        mnuScalar100.Checked = True
        mnuScalar150.Checked = False
        mnuScalar200.Checked = False
    End Sub

    Private Sub mnuScalar150_Click(sender As Object, e As EventArgs) Handles mnuScalar150.Click
        Scalar = 150
        mnuScalar50.Checked = False
        mnuScalar100.Checked = False
        mnuScalar150.Checked = True
        mnuScalar200.Checked = False
    End Sub

    Private Sub mnuScalar200_Click(sender As Object, e As EventArgs) Handles mnuScalar200.Click
        Scalar = 200
        mnuScalar50.Checked = False
        mnuScalar100.Checked = False
        mnuScalar150.Checked = False
        mnuScalar200.Checked = True
    End Sub

    Private Sub mnuNoCollision_Click(sender As Object, e As EventArgs) Handles mnuNoCollision.Click
        If Collision_Disabled = False Then
            Collision_Disabled = True
            mnuNoCollision.Checked = Collision_Disabled
        Else
            Collision_Disabled = False
            mnuNoCollision.Checked = Collision_Disabled
        End If
    End Sub

    Private Sub mnuGapDistance150_Click(sender As Object, e As EventArgs) Handles mnuGapDistance150.Click
        GAP_X = 150
        mnuGapDistance150.Checked = True
        mnuGapDistance200.Checked = False
        mnuGapDistance250.Checked = False
        mnuGapDistance300.Checked = False
    End Sub

    Private Sub mnuGapDistance200_Click(sender As Object, e As EventArgs) Handles mnuGapDistance200.Click
        GAP_X = 200
        mnuGapDistance150.Checked = False
        mnuGapDistance200.Checked = True
        mnuGapDistance250.Checked = False
        mnuGapDistance300.Checked = False
    End Sub

    Private Sub mnuGapDistance250_Click(sender As Object, e As EventArgs) Handles mnuGapDistance250.Click
        GAP_X = 250
        mnuGapDistance150.Checked = False
        mnuGapDistance200.Checked = False
        mnuGapDistance250.Checked = True
        mnuGapDistance300.Checked = False
    End Sub

    Private Sub mnuGapDistance300_Click(sender As Object, e As EventArgs) Handles mnuGapDistance300.Click
        GAP_X = 300
        mnuGapDistance150.Checked = False
        mnuGapDistance200.Checked = False
        mnuGapDistance250.Checked = False
        mnuGapDistance300.Checked = True
    End Sub

    Private Sub mnuGameSpeed1_Click(sender As Object, e As EventArgs) Handles mnuGameSpeed1.Click
        GAME_SPEED = 1
        mnuGameSpeed1.Checked = True
        mnuGameSpeed2.Checked = False
        mnuGameSpeed3.Checked = False
        mnuGameSpeed4.Checked = False
        mnuGameSpeed5.Checked = False
    End Sub

    Private Sub mnuGameSpeed2_Click(sender As Object, e As EventArgs) Handles mnuGameSpeed2.Click
        GAME_SPEED = 2
        mnuGameSpeed1.Checked = False
        mnuGameSpeed2.Checked = True
        mnuGameSpeed3.Checked = False
        mnuGameSpeed4.Checked = False
        mnuGameSpeed5.Checked = False
    End Sub

    Private Sub mnuGameSpeed3_Click(sender As Object, e As EventArgs) Handles mnuGameSpeed3.Click
        GAME_SPEED = 3
        mnuGameSpeed1.Checked = False
        mnuGameSpeed2.Checked = False
        mnuGameSpeed3.Checked = True
        mnuGameSpeed4.Checked = False
        mnuGameSpeed5.Checked = False
    End Sub

    Private Sub mnuGameSpeed4_Click(sender As Object, e As EventArgs) Handles mnuGameSpeed4.Click
        GAME_SPEED = 4
        mnuGameSpeed1.Checked = False
        mnuGameSpeed2.Checked = False
        mnuGameSpeed3.Checked = False
        mnuGameSpeed4.Checked = True
        mnuGameSpeed5.Checked = False
    End Sub

    Private Sub mnuGameSpeed5_Click(sender As Object, e As EventArgs) Handles mnuGameSpeed5.Click
        GAME_SPEED = 5
        mnuGameSpeed1.Checked = False
        mnuGameSpeed2.Checked = False
        mnuGameSpeed3.Checked = False
        mnuGameSpeed4.Checked = False
        mnuGameSpeed5.Checked = True
    End Sub

    Private Sub mnuSetDefaults_Click(sender As Object, e As EventArgs) Handles mnuSetDefaults.Click
        Set_Default_Settings()
    End Sub

    Private Sub mnuAbout_Click(sender As Object, e As EventArgs) Handles mnuAbout.Click
        frmAbout.Show()
    End Sub
End Class
