Imports Tst.Game
Imports WMPLib

Public Class Form1

    Public game As Game
    Public sound As Sound


    Public Sub start()


        sound = New Sound()
        game = New Game()

        'sound.playSound("fsoc-trippy.wav", "music")
        game.init(Canvas, Ticker, SoundTimer, sound)
    End Sub


    Private Sub OnApplicationExit(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Closing
        MsgBox("Thanks for playing!")
        Application.Exit()
    End Sub
    'Funskjonen som køyrer da spelet startar
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    'Sjekkar om brukaren trykker på knappar
    Sub Form1_KeyPress(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        game.keyUpdate(sender, e)



    End Sub


    'Funksjonen som håndterar oppdatering av spelet
    Private Sub Tick(sender As Object, e As EventArgs) Handles Ticker.Tick
        game.Tick(sender, e)

        If game.lost Then
            Ticker.Enabled = False
            sound.playSound("sound/fx/oneshot/lose.wav", "soundeffects")
            MsgBox("Du tapte!!!")
            Button1.Enabled = True
        End If

        If game.closing Then
            Form2.Show()
            sound.playSound("sound/music/main.wav", "music")
            Me.Visible = False
            start()
        End If

        If game.gotApple() Then
            sound.playSound("sound/fx/oneshot/eat.wav", "soundeffects")
        End If

        Score.Text = "Poeng: " & game.getScore()

        Ticker.Interval = game.freq
    End Sub

    'Når brukaren klikkar på reset knappen. Resetter spelet
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click ' Knappen er ikkje heilt klar enno
        Button1.Enabled = False
        start()

    End Sub

    Private Sub SoundTimer_Tick(sender As Object, e As EventArgs) Handles SoundTimer.Tick
        game.stTick()
    End Sub
End Class
