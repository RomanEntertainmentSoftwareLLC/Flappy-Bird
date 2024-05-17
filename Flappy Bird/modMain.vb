Option Explicit On
Option Strict On

Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D

Public Module modMain
    Public GAME_SPEED As Single

    Public GAP_X As Single
    Public GAP_Y As Single

    Public Fullscreen_Enabled As Boolean
    Public Fullscreen_Width As Integer
    Public Fullscreen_Height As Integer
    Public Window_Width As Integer
    Public Window_Height As Integer
    Public Running As Boolean = True

    Public Game_Active As Boolean
    Public Death As Boolean

    Public Gravity As Single
    Public Flap_Velocity As Single
    Public Scalar As Single
    Public Collision_Disabled As Boolean

    Public Sub Load_Textures_From_File()
        Load_Background_Textures()
        Load_Score_Textures()
        Load_Pipe_Textures()
        Load_Sprite_Textures()
        Load_Game_Over_Texture()
        Load_Get_Ready_Texture()
        Load_Ground_Texture()
        Load_Tap_Texture()
    End Sub

    Public Sub Set_Default_Settings()
        Collision_Disabled = False
        frmMain.mnuNoCollision.Checked = Collision_Disabled

        Scalar = 150
        frmMain.mnuScalar150.Checked = True

        Flap_Velocity = -3.5
        frmMain.mnuFlapVelocity35.Checked = True

        GAME_SPEED = 3
        frmMain.mnuGameSpeed3.Checked = True

        GAP_X = 250
        frmMain.mnuGapDistance250.Checked = True

        GAP_Y = 175
        frmMain.mnuMouthGap175.Checked = True

        Gravity = clsPhysics.EARTH_GRAVITY
        frmMain.mnuGravityEarth.Checked = True
    End Sub

    Public Sub Render()
        Device.Clear(ClearFlags.Target, Color.FromArgb(0, 0, 0).ToArgb, 1.0, 0)
        Device.BeginScene()
        Draw_Background()
        Draw_Pipes()
        'Draw_Boundry()
        Draw_Ground()
        Animate_Sprite()
        Draw_Score()
        Draw_Game_Over()
        Draw_Get_Ready()
        Fade_Out_To_Black()
        Fade_Transparent_Get_Ready()
        Fade_Transparent_Game_Over()
        Device.EndScene()
        Device.Present()
    End Sub

    Public Sub Game_Loop()
        Do While Running = True
            Sprite(0).Physics.Update()
            Angulate_Sprite()
            Collision_Detection()
            Update_Score()
            Render()
            Application.DoEvents()
        Loop
    End Sub

    Public Sub Main()
        'If MessageBox.Show("Click Yes to go to full screen (Recommended)", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
        'Fullscreen_Enabled = True
        'End If

        Randomize()
        Fullscreen_Width = 1920
        Fullscreen_Height = 1080
        Window_Width = 432
        Window_Height = 768

        With frmMain
            .Show()
            .Text = "Flappy Bird - By Jacob Roman"
            .Width = Window_Width
            .Height = Window_Height
            If Fullscreen_Enabled = True Then .FormBorderStyle = Windows.Forms.FormBorderStyle.None
        End With

        Random_Background = CInt(Rnd() * 1)
        Random_Sprite = CInt(Rnd() * 3)

        Hi_Res_Timer_Initialize()
        DX_Initialize()

        Load_Textures_From_File()

        Set_Default_Settings()
        Setup_Pipes()
        Setup_Ground()
        Setup_Sprite()
        Setup_Get_Ready()
        Setup_Fade_To_Black()

        Game_Over_Fade_Transparent_Speed = 255

        DirectSound_Initialize()
        Load_Sound(Application.StartupPath & "\Flap.wav", Sound_Buffer(0))
        Load_Sound(Application.StartupPath & "\Smashed.wav", Sound_Buffer(1))
        Load_Sound(Application.StartupPath & "\Coin.wav", Sound_Buffer(2))
        Game_Active = False
        Running = True
        Game_Loop()
    End Sub

    Public Sub Shutdown()
        Running = False

        Unload_Sprite_Textures()
        Unload_Score_Textures()
        Unload_Ground_Textures()
        Unload_Background_Textures()
        Unload_Boundry_Texture()
        Unload_Pipe_Textures()
        Unload_Get_Ready_Textures()
        Unload_Game_Over_Textures()

        DirectSound_Shutdown()
        DirectX_Shutdown()

        Application.Exit()
    End Sub

End Module
