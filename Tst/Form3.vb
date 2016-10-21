Imports Tst.Game
Public Class Form3
    Public SIZE2 As Integer = 40
    Public TILE_SIZE2 As Integer = 10

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'My.Computer.Audio.Play("game-menu.wav",
        'AudioPlayMode.BackgroundLoop)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'går tilbake til hovedmenyen
        Form2.Show()
        Me.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)  ' skyfter til mode 1
        SIZE2 = 50
        TILE_SIZE2 = 400 / 30
        Form1.Show()
        Me.Visible = False
        My.Computer.Audio.Stop()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)  ' skyfter til mode 2
        SIZE2 = 60
        TILE_SIZE2 = 400 / 60
        Form1.Show()
        Me.Visible = False
        My.Computer.Audio.Stop()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)  ' skyfter til mode 3
        SIZE2 = 70
        TILE_SIZE2 = 400 / 70
        Form1.Show()
        Me.Visible = False
        My.Computer.Audio.Stop()
    End Sub


    Private Sub OnApplicationExit(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Closing
        Application.Exit()
    End Sub
End Class