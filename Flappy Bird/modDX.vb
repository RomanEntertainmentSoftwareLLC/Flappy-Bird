Option Explicit On
Option Strict On

Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D

Module modDX
    Public Const COLOR_DEPTH_16_BIT As Format = Format.R5G6B5
    Public Const COLOR_DEPTH_24_BIT As Format = Format.A8R8G8B8
    Public Const COLOR_DEPTH_32_BIT As Format = Format.X8R8G8B8

    Public Device As Device
    Public Display_Mode As DisplayMode
    Public Screen As PresentParameters = New PresentParameters

    Public Sub DX_Initialize()
        If Fullscreen_Enabled = True Then
            Display_Mode.Width = Fullscreen_Width
            Display_Mode.Height = Fullscreen_Height
            Display_Mode.Format = COLOR_DEPTH_32_BIT
            'Check to see if fullscreen mode is supported before you use it.
            If Manager.CheckDeviceType(0, DeviceType.Hardware, Display_Mode.Format, Display_Mode.Format, False) Then
                ' Perfect, this is valid
                Screen.Windowed = False
                Screen.BackBufferCount = 1
                Screen.BackBufferWidth = Display_Mode.Width
                Screen.BackBufferHeight = Display_Mode.Height
            Else
                MessageBox.Show("Your video card doesn't support this screen resolution.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            Screen.Windowed = True
        End If

        Screen.SwapEffect = SwapEffect.Copy
        Screen.BackBufferFormat = Display_Mode.Format

        'Create our device
        Device = New Device(0, DeviceType.Hardware, frmMain.Handle, CreateFlags.SoftwareVertexProcessing, Screen)

        Set_Renderstates()
    End Sub

    Public Sub Set_Renderstates()
        'Right here will alphablend the polygon
        Device.SetRenderState(RenderStates.AlphaBlendEnable, True
                              )
        'Needed for alphablending
        '----------------------------------------------------------------------------------------------------
        Device.SetTextureStageState(0, TextureStageStates.ColorOperation, TextureOperation.Modulate)
        Device.SetTextureStageState(0, TextureStageStates.ColorArgument1, TextureArgument.TextureColor)
        Device.SetTextureStageState(0, TextureStageStates.ColorArgument2, TextureArgument.Diffuse)

        Device.SetTextureStageState(0, TextureStageStates.AlphaOperation, TextureOperation.Modulate)
        Device.SetTextureStageState(0, TextureStageStates.AlphaArgument1, TextureArgument.TextureColor)
        Device.SetTextureStageState(0, TextureStageStates.AlphaArgument2, TextureArgument.Diffuse)

        Device.SetRenderState(RenderStates.SourceBlend, Blend.SourceAlpha)
        Device.SetRenderState(RenderStates.DestinationBlend, Blend.InvSourceAlpha)
        'Device.SetRenderState(RenderStates.BlendOperation, TextureOperation.Add)
        '----------------------------------------------------------------------------------------------------

        'These lines are not needed, but it's nice to be able to filter the
        'textures to make them look nicer.

        Device.SetSamplerState(0, SamplerStageStates.MinFilter, TextureFilter.Point)
        Device.SetSamplerState(0, SamplerStageStates.MagFilter, TextureFilter.Point)
    End Sub

    Public Function Create_Custom_Vertex(ByVal X As Single, ByVal Y As Single, ByVal Color As Integer, ByVal TU As Single, ByVal TV As Single) As CustomVertex.TransformedColoredTextured
        Create_Custom_Vertex.Position = New Vector4(X, Y, 0, 1)
        Create_Custom_Vertex.Color = Color
        Create_Custom_Vertex.Tu = TU
        Create_Custom_Vertex.Tv = TV
    End Function

    Public Function Load_Texture(ByVal File_Path As String, ByVal Transparency_Color As Integer) As Texture
        Load_Texture = TextureLoader.FromFile(Device, File_Path, 512, 512, 1, Usage.None, Format.A8B8G8R8, Pool.Managed, Filter.Point, Filter.Point, Transparency_Color)
    End Function

    Public Sub DirectX_Shutdown()
        If Device IsNot Nothing Then
            Device.Dispose() : Device = Nothing
        End If
    End Sub
End Module

