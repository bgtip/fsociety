Imports Tst.Game
Public Class Form3
    Public snakeSize As Integer


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
        Me.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        snakeSize = 10
        Form1.Show()
        Me.Visible = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        snakeSize = 20
        Form1.Show()
        Me.Visible = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        snakeSize = 30
        Form1.Show()
        Me.Visible = False
    End Sub
End Class