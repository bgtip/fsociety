

Public Class Sound

    'Variabel brukt i å kalle frå lydbibloteket.
    Dim retVal As Long

    'Holder styr på kva lydkanalar som er aktive.
    Dim activeChannels As New Dictionary(Of String, Boolean)

    'Deklarerer lydbibloteket.
    Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Integer, ByVal hwndCallback As IntPtr) As Integer

    Public Sub init()
        'Setter opp dei ulike kanalane og setter dei opp som uaktive.
        activeChannels.Add("soundeffects", False)
        activeChannels.Add("music", False)
        activeChannels.Add("talking", False)
    End Sub

    'Spiller av ein lyd på ein gitt kanal.
    Public Sub playSound(str As String, channel As String)

        'Sjekkar om lyden spiller frå før av. Og stoppar den om det er tilfellet.
        If activeChannels.ContainsKey(channel) Then
            If activeChannels.Item(channel) Then
                retVal = mciSendString("close " & channel, vbNullString, 0, 0)

            End If
        End If

        'Om lyden er av type musikk så loopar den.
        Dim add As String = ""
        If String.Compare(channel, "music") = 0 Then
            add = "repeat"
        End If

        'Opnar og spelar av lyden.
        retVal = mciSendString("open " & str & " type mpegvideo alias " & channel, vbNullString, 0, 0)
        retVal = mciSendString("play " & channel & " " & add, vbNullString, 0, 0)

        'Setter at den brukte kanalen er aktiv.
        activeChannels.Item(channel) = True

    End Sub

    'Stoppar lyden på den gitte kanalen.
    Public Sub stopSound(channel As String)
        If activeChannels.ContainsKey(channel) Then
            If activeChannels.Item(channel) Then
                retVal = mciSendString("close " & channel, vbNullString, 0, 0)

            End If
        End If
    End Sub
End Class
