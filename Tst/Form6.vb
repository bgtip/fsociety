Public Class Form6
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebBrowser1.Navigate("http://org.ntnu.no/fsociety27/game/score/scoreForm.php?score=" & Form1.game.getScore)
    End Sub
End Class