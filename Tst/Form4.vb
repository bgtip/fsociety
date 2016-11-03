Public Class Form4
    Dim buttonExit = Keys.Escape
    Private Sub OnApplicationExit(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Closing
        Application.Exit()
    End Sub
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


    Sub keyUpdate(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case buttonExit
                Form3.Show()
                Me.Visible = False
        End Select
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Focus()
    End Sub
End Class