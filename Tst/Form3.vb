Imports Tst.Game
Public Class Form3
    Public SIZE2 As Integer = 40
    Public TILE_SIZE2 As Integer = 10
    Public speed2 As Integer = 100

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'går tilbake til hovedmenyen
        Form2.Show()
        Me.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click ' skyfter til mode 1
        SIZE2 = 50
        TILE_SIZE2 = 400 / 50
        speed2 = 70
        Form1.Show()
        Me.Visible = False

        My.Computer.Audio.Stop()
    End Sub

    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        PictureBox1.BackgroundImage = Image.FromFile("bg2.png")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click  ' skyfter til mode 2
        SIZE2 = 60
        TILE_SIZE2 = 400 / 60
        speed2 = 50
        Form1.Show()
        Me.Visible = False
        My.Computer.Audio.Stop()
    End Sub

    Private Sub Button3_MouseHover(sender As Object, e As EventArgs) Handles Button3.MouseHover
        PictureBox1.BackgroundImage = Image.FromFile("bg1.png")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click  ' skyfter til mode 3
        SIZE2 = 70
        TILE_SIZE2 = 400 / 70
        speed2 = 40
        Form1.Show()
        Me.Visible = False
        My.Computer.Audio.Stop()
    End Sub

    Private Sub Button4_MouseHover(sender As Object, e As EventArgs) Handles Button4.MouseHover
        PictureBox1.BackgroundImage = Image.FromFile("bg2old.png")
    End Sub

    Private Sub OnApplicationExit(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Closing
        Application.Exit()
    End Sub



    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckStateChanged
        If CheckBox1.Checked = True Then
            My.Computer.Audio.Stop()
        End If

    End Sub

End Class