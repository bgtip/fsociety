﻿Imports Tst.Game
Public Class Form3
    Public SIZE2 As Integer = 40
    Public TILE_SIZE2 As Integer = 10
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'går tilbake til hovedmenyen
        Form2.Show()
        Me.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click ' skyfter til mode 1
        SIZE2 = 50
        TILE_SIZE2 = 400 / 50
        Form1.Show()
        Me.Visible = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click ' skyfter til mode 2
        SIZE2 = 60
        TILE_SIZE2 = 400 / 60
        Form1.Show()
        Me.Visible = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click ' skyfter til mode 3
        SIZE2 = 70
        TILE_SIZE2 = 400 / 70
        Form1.Show()
        Me.Visible = False
    End Sub
End Class