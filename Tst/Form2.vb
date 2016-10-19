Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'Starter spillet
        Form1.Show()
        Me.Visible = False
        My.Computer.Audio.Stop()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.Audio.Play("game-menu.wav",
        AudioPlayMode.BackgroundLoop)

        Dim conf As String
        conf = My.Computer.FileSystem.ReadAllText("config.txt")
        Dim l = conf.IndexOf("speed=")
        Dim speed = conf.Substring(l + 6, 3)
        l = conf.IndexOf("tile_size=")
        Dim tl = conf.Substring(l + 10, 2)
        l = conf.IndexOf("map_size=")
        Dim sz = conf.Substring(l + 9, 2)
        Form3.SIZE2 = sz
        Form3.TILE_SIZE2 = tl
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click 'Går til Options menyen
        Form3.Show()
        Me.Visible = False
        My.Computer.Audio.Stop()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click 'Lukker spillet
        Me.Close()
    End Sub

    Private Sub OnApplicationExit(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Closing
        Application.Exit()
    End Sub
End Class