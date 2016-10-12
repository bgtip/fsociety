Imports Tst.Game


Public Class Form1

    Public game As Game

    'Funskjonen som køyrer da spelet startar
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        game = New Game()

        game.init(Canvas, Ticker)

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
            MsgBox("Du tapte!!!")
        End If

        Score.Text = "Poeng: " & game.getScore()

        Ticker.Interval = game.freq
    End Sub

    'Når brukaren klikkar på reset knappen. Resetter spelet
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click ' Knappen er ikkje heilt klar enno
        Button1.Enabled = False
        'init(Canvas)

    End Sub
End Class
