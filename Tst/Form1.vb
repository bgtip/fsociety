Imports Tst.Game
Imports WMPLib

Public Class Form1

    'Variablar for spill og lyd objeckta. Kontrollerer lyd og spellogikken.
    Public game As Game
    Public sound As Sound = New Sound()

    'Når funksjonen kalles vil spillet starte. Spillet initialiseres
    Public Sub start()
        game = New Game()

        game.init(Canvas, Ticker, SoundTimer, sound)
    End Sub

    'Viser melding når spelet avsluttast
    Private Sub OnApplicationExit(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Closing
        MsgBox("Thanks for playing!")
        Application.Exit()
    End Sub

    'Sjekkar om brukaren trykker på knappar
    Sub Form1_KeyPress(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        game.keyUpdate(sender, e)
    End Sub

    'Funksjonen som håndterar oppdatering av spelet
    Private Sub Tick(sender As Object, e As EventArgs) Handles Ticker.Tick
        'Oppdaterer spel-objektet.
        game.Tick(sender, e)


        'Lukkar spel-vindauget, speler av main-musikken og åpnar hoved-meny. 
        If game.closing Then
            Form2.Show()
            sound.playSound("sound/music/main.wav", "music")
            Me.Visible = False
            start()
            Button1.Enabled = False
            Button2.Enabled = False
        End If

        'Hvis brukaren tapar vil ein lyd speles av, samtidig som ei melding kjem opp. 
        'Submit-og reset- knappane blir så aktive. 
        If game.lost Then
            Ticker.Enabled = False
            sound.playSound("sound/fx/oneshot/lose.wav", "soundeffects")
            MsgBox("Du tapte!!!")
            Button1.Enabled = True
            Button2.Enabled = True
        End If


        'Speler av lyd når slangen eter eit eple
        If game.gotApple() Then
            sound.playSound("sound/fx/oneshot/eat.wav", "soundeffects")
        End If

        'Oppdaterar scoren som visast for brukaren
        Score.Text = "Poeng: " & game.getScore()

        'Ekstern variabel som styrar kor fort spelet går
        Ticker.Interval = game.freq
    End Sub

    'Når brukaren klikkar på reset knappen. Resetter spelet
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click  ' Knappen er ikkje heilt klar enno
        Button1.Enabled = False
        Button2.Enabled = False
        Form6.Hide()
        start()
    End Sub

    'Tick for lyd-avspelinga
    Private Sub SoundTimer_Tick(sender As Object, e As EventArgs) Handles SoundTimer.Tick
        game.stTick()
    End Sub

    'Gjer at brukaren ikkje kan submitte score i "easy"-mode. Gir melding til brukaren om ein forsøker. 
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If game.effectChance < 1 Then
            Form6.Show()
        Else
            MsgBox("You cannot submit your highscore in easy mode!")
        End If
    End Sub
End Class
