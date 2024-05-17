Option Explicit On
Option Strict On

Imports Microsoft.DirectX
Imports Microsoft.DirectX.DirectSound

Module modDSound
    Public Const MAX_VOLUME As Integer = 100

    Public Sound_Device As New Device
    Public Sound_Buffer(2) As SecondaryBuffer
    Public Sound_Buffer_Description As New BufferDescription()
    Public Sound_Buffer_Wave_Format As New WaveFormat()

    Public Sub DirectSound_Initialize()
        Sound_Buffer_Description = New BufferDescription
        Sound_Buffer_Description.ControlPan = True
        Sound_Buffer_Description.ControlVolume = True
        Sound_Buffer_Description.ControlFrequency = True
        Sound_Buffer_Description.ControlEffects = True

        Sound_Device.SetCooperativeLevel(frmMain.Handle, CooperativeLevel.Priority)
    End Sub

    Public Sub Load_Sound(File_Path As String, ByRef Buffer As SecondaryBuffer)
        Buffer = New SecondaryBuffer(File_Path, Sound_Buffer_Description, Sound_Device)
    End Sub

    Public Sub Play_Sound(ByVal Sound_Buffer As SecondaryBuffer)
        If Sound_Buffer IsNot Nothing Then Sound_Buffer.Play(0, BufferPlayFlags.Default)
    End Sub

    Public Sub Play_Sound_Loop(ByVal Sound_Buffer As SecondaryBuffer)
        Sound_Buffer.Play(0, BufferPlayFlags.Looping)
    End Sub

    Public Sub Pause_Sound(ByVal Sound_Buffer As SecondaryBuffer)
        Sound_Buffer.Stop()
    End Sub

    Public Sub Set_Sound_Volume(ByVal Buffer As SecondaryBuffer, ByVal Volume As Long)
        If Volume >= MAX_VOLUME Then Volume = MAX_VOLUME
        If Volume <= 0 Then Volume = 0
        Buffer.Volume = CInt(((Volume / MAX_VOLUME) * 10000) + -10000)
    End Sub

    Public Sub DirectSound_Shutdown()
        If Sound_Buffer(0) IsNot Nothing Then Sound_Buffer(0) = Nothing
        If Sound_Buffer(1) IsNot Nothing Then Sound_Buffer(1) = Nothing
        If Sound_Buffer(2) IsNot Nothing Then Sound_Buffer(2) = Nothing
        If Sound_Device IsNot Nothing Then
            Sound_Device.Dispose() : Sound_Device = Nothing
        End If
    End Sub
End Module
