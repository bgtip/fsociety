Public Class Form6
    'Navigerar nettlesaren i Form6 til scoreForm på nettsiden
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebBrowser1.Navigate("http://org.ntnu.no/fsociety27/game/score/scoreForm.php?score=" & Form1.game.getScore) 'leser av scoren til spelet
    End Sub
End Class