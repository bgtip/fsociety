﻿Imports Tst.Game


Public Class Form1

    Public game As Game



    Private Sub OnApplicationExit(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Closing
        MsgBox("Thanks for playing!")
        Application.Exit()
    End Sub
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
            My.Computer.Audio.Play("game2.wav",
        AudioPlayMode.Background)
            MsgBox("Du tapte!!!")
            Button1.Enabled = True
        End If

        If game.gotApple() Then
            My.Computer.Audio.Play("game1.wav",
        AudioPlayMode.Background)
        End If

        Score.Text = "Poeng: " & game.getScore()

        Ticker.Interval = game.freq
    End Sub

    'Når brukaren klikkar på reset knappen. Resetter spelet
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click ' Knappen er ikkje heilt klar enno
        Button1.Enabled = False
        game = New Game()

        game.init(Canvas, Ticker)

    End Sub

End Class
