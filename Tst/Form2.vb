Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'Start-knapp. Krevar at brukaren trykkar på knapp merka "Start". Eit trykk i knappen resulterar i at Form1 (spill) visast, Form2 (som brukeren befinner seg i) skjulas
        'Main-musikken (som spilles av i hovedmeny) stoppar, og funksjonane "start()" og "sound.playSound" aktiveres. 
        Form1.Show()
        Me.Visible = False
        My.Computer.Audio.Stop()
        Form1.start()
        Form1.sound.playSound("sound/fx/game-start.wav", "talking")
    End Sub

    'startar musikken når spelet lastast
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.sound.playSound("sound/music/main.wav", "music")
    End Sub

    'Settings-knapp. Eit trykk i knappen resulterer at Form3 (settings-form) visast, og at Form2 (som brukeren befinner seg i) lukkes. 
    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Form3.Show()
        Me.Visible = False
    End Sub

    'Lukkar spillet
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    'Lukker spillet helt når spillet "lukkes"
    Private Sub OnApplicationExit(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Closing
        Application.Exit()
    End Sub

    'Åpner en nettside med scores i default browser
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Process.Start("http://scoreboard.fsociety27.net")
    End Sub
End Class