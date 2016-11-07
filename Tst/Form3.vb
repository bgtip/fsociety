Imports Tst.Game
Public Class Form3
    Dim buttonExit = Keys.Escape
    Public SIZE2 As Integer = 40
    Public TILE_SIZE2 As Integer = 10
    Public speed2 As Integer = 50
    Public modeChance As Single = 0.4
    Dim Mode1 As Image = Image.FromFile("easy1.png")
    Dim Mode2 As Image = Image.FromFile("hard.png")
    Dim Mode3 As Image = Image.FromFile("insane.png")
    Dim standard As Image = Image.FromFile("cyka.png")

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'går tilbake til hovedmenyen
        Form2.Show()
        Me.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click ' skyfter til mode 1 (normal mode)
        speed2 = 100
        modeChance = 1.1 'Ingen sjanse for eple effektar.
        Form2.Show()
        Me.Visible = False
        My.Computer.Audio.Stop()
        Form1.sound.playSound("sound/fx/hapimil.wav", "talking")

    End Sub

    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        Me.PictureBox1.Image = Mode1
        Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub Button2_Mouseleave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Me.PictureBox1.Image = standard
        Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click  ' skyfter til mode 2
        speed2 = 50
        modeChance = 0.4
        Form2.Show()
        Me.Visible = False
        My.Computer.Audio.Stop()
        Form1.sound.playSound("sound/fx/hard.wav", "talking")
    End Sub

    Private Sub Button3_MouseHover(sender As Object, e As EventArgs) Handles Button3.MouseHover
        Me.PictureBox1.Image = Mode2
        Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub Button3_Mouseleave(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        Me.PictureBox1.Image = standard
        Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub OnApplicationExit(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Closing
        Application.Exit()
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckStateChanged
        If CheckBox1.Checked = True Then
            Form1.sound.musicOn = False
            Form1.sound.stopSound("music")
        Else
            Form1.sound.musicOn = True
            Form1.sound.playSound("sound/music/main.wav", "music")
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form4.Show()
        Me.Visible = False
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            Form1.sound.soundOn = False
        Else
            Form1.sound.soundOn = True
        End If
    End Sub
    Sub keyUpdate(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case buttonExit
                Form2.Show()
                Me.Visible = False
        End Select
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class