Public Class Form4
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form3.Show()
        Me.Visible = False
    End Sub

    'Private Sub Form4_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
    '    Dim buttonBack = Keys.Escape
    '    Select Case e.KeyCode
    '        Case buttonBack
    '            MsgBox("cyka blyt")
    '            Form3.Show()
    '            Me.Visible = False
    '    End Select
    'End Sub

    'meh...funker ikke.

End Class