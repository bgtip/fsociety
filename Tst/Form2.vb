Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'Starter spillet
        'Start-knapp. Krever at brukeren trykker på knapp merket "Start". Et trykk i knappen resulterer i at Form1 (spill) vises, Form2 (som brukeren befinner seg i) skjules
        'Main-musikken (som spilles av i hovedmeny) stopper, og funksjonene "start()" og "sound.playSound" aktiveres. 
        Form1.Show()
        Me.Visible = False
        My.Computer.Audio.Stop()
        Form1.start()
        Form1.sound.playSound("sound/fx/game-start.wav", "talking")
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Settings-knapp. Et trykk i knappen resulterer at Form3 (settings-form) vises, og at Form2 (som brukeren befinner seg i) lukkes. 
        'Main-musikken fortsetter å bli spilt av med funksjonen "sound.playSound"
        Form1.sound.playSound("sound/music/main.wav", "music")

        'Her leses av valg som er satt i fila "config.txt". Disse valgene lastes så inn. 
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
        'My.Computer.Audio.Stop()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click 'Lukker spillet
        Me.Close()
    End Sub

    Private Sub OnApplicationExit(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Closing 'Lukker spillet helt når spillet "lukkes"
        Application.Exit()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click 'Åpner en nettside med scores i default browser
        Process.Start("http://org.ntnu.no/fsociety27/game/score/score.php")
    End Sub
End Class