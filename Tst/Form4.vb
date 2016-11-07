Public Class Form4
    Dim buttonExit = Keys.Escape

    'Sørger for at spelet ikkje kjøyrar i bakgrunnen når det avsluttast
    Private Sub OnApplicationExit(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Closing
        Application.Exit()
    End Sub

    'Lukkar controls-vindet
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form3.Show()
        Me.Visible = False
    End Sub

    'Går tilbake til options-menyen
    Sub keyUpdate(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case buttonExit
                Form3.Show()
                Me.Visible = False
        End Select
    End Sub
    'Gir fokus til controls-vinduet slik at brukaren kan lukke vindauget
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Focus()
    End Sub
End Class