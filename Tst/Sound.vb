

Public Class Sound

    Dim retVal As Long

    Dim activeChannels As New Dictionary(Of String, Boolean)

    Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Integer, ByVal hwndCallback As IntPtr) As Integer

    Public Sub init()
        'Setter opp dei ulike kanalane
        activeChannels.Add("soundeffects", False)
        activeChannels.Add("music", False)
        activeChannels.Add("talking", False)
    End Sub

    Public Sub playSound(str As String, channel As String)

        If activeChannels.ContainsKey(channel) Then
            If activeChannels.Item(channel) Then
                retVal = mciSendString("close " & channel, vbNullString, 0, 0)

            End If
        End If

        If String.Compare(channel, "soundeffects") = 0 Then
            My.Computer.Audio.Play(str)


        Else

            Dim add As String = ""
            If String.Compare(channel, "music") = 0 Then
                add = "repeat"
            End If


            retVal = mciSendString("open " & str & " type mpegvideo alias " & channel, vbNullString, 0, 0)
            retVal = mciSendString("play " & channel & " " & add, vbNullString, 0, 0)

            activeChannels.Item(channel) = True
        End If



    End Sub

    Public Sub stopSound(channel As String)
        If activeChannels.ContainsKey(channel) Then
            If activeChannels.Item(channel) Then
                retVal = mciSendString("close " & channel, vbNullString, 0, 0)

            End If
        End If
    End Sub
End Class
