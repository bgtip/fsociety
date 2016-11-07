Imports Tst.Game
Imports WMPLib

Public Class Form1

    Public game As Game
    Public sound As Sound = New Sound()


    Public Sub start()
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
            Button2.Enabled = True
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click  ' Knappen er ikkje heilt klar enno
        Button1.Enabled = False
        Button2.Enabled = False
        Form6.Hide()
        start()

    End Sub

    Private Sub SoundTimer_Tick(sender As Object, e As EventArgs) Handles SoundTimer.Tick
        game.stTick()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If game.effectChance < 1 Then
            Form6.Show()
        Else
            MsgBox("You cannot submit your highscore in easy mode!")
        End If
    End Sub
End Class
