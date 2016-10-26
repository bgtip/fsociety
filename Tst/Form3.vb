Imports Tst.Game
Public Class Form3
    Public SIZE2 As Integer = 40
    Public TILE_SIZE2 As Integer = 10
    Public speed2 As Integer = 100
    Public modeChance As Single = 0.6
    Dim Mode1 As Image = Image.FromFile("easy1.png")
    Dim Mode2 As Image = Image.FromFile("hard.png")
    Dim Mode3 As Image = Image.FromFile("insane.png")
    Dim standard As Image = Image.FromFile("none.png")

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'går tilbake til hovedmenyen
        Form2.Show()
        Me.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click ' skyfter til mode 1 (normal mode)
        SIZE2 = 40
        TILE_SIZE2 = 10
        speed2 = 100
        modeChance = 1.1 'Ingen sjanse for eple effektar.
        Form1.Show()
        Form1.start()
        Me.Visible = False
        My.Computer.Audio.Stop()
    End Sub

    Private Sub Button2_Mouseover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        Me.PictureBox1.Image = Mode1
        Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub Button2_Mouseleave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Me.PictureBox1.Image = standard
        Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click  ' skyfter til mode 2
        SIZE2 = 60
        TILE_SIZE2 = 400 / 60
        speed2 = 50
        Form1.Show()
        Form1.start()
        Me.Visible = False
        My.Computer.Audio.Stop()
    End Sub

    Private Sub Button3_Mousehover(sender As Object, e As EventArgs) Handles Button3.MouseHover
        Me.PictureBox1.Image = Mode2
        Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub
    Private Sub Button3_Mouseleave(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        Me.PictureBox1.Image = standard
        Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click  ' skyfter til mode 3
        SIZE2 = 70
        TILE_SIZE2 = 400 / 70
        speed2 = 40
        Form1.Show()
        Form1.start()
        Me.Visible = False
        My.Computer.Audio.Stop()
    End Sub

    Private Sub Button4_Mouseover(sender As Object, e As EventArgs) Handles Button4.MouseHover
        Me.PictureBox1.Image = Mode3
        Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub
    Private Sub Button4_Mouseleave(sender As Object, e As EventArgs) Handles Button4.MouseLeave
        Me.PictureBox1.Image = standard
        Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub OnApplicationExit(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Closing
        Application.Exit()
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckStateChanged
        If CheckBox1.Checked = True Then
            My.Computer.Audio.Stop()
        Else
            My.Computer.Audio.Play("game-menu.wav",
        AudioPlayMode.BackgroundLoop)
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form4.Show()
        Me.Visible = False
    End Sub


End Class