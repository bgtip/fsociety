Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'Starter spillet
        Form1.Show()
        Me.Visible = False
        My.Computer.Audio.Stop()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.Audio.Play("game-menu.wav",
        AudioPlayMode.BackgroundLoop)
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click 'Går til Options menyen
        Form3.Show()
        Me.Visible = False
        My.Computer.Audio.Stop()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click 'Lukker spillet
        Me.Close()
    End Sub
End Class