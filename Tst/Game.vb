Public Class Game
    'Public Const SIZE As Integer = 30 ' Størrelse på spilleområde. Både vidde og høgde. I tiles
    Dim SIZE = Form3.SIZE2 'Størrelsen på spillområdet, satt ut i fra spillerens valg i options.
    Public Const TILE_SIZE As Integer = 10 'Størrelse på kvar tile, i pikslar

    'Bilda som blir brukt i spelet
    Public Const BG0IMG As String = "bg0.png"
    Public Const BG1IMG As String = "bg1.png"
    Public Const BG2IMG As String = "bg2.png"

    'Kva nummer kvar tile er
    Public Const NO_TILE As Integer = 0
    Public Const SNAKE_TILE As Integer = 1
    Public Const APPLE_TILE As Integer = 2

    'Ein rar måte å vise spelet på. Er standard ikkje i bruk.
    Public Const PICBOXGRAPHICS As Boolean = False

    'Rettningane til slangen
    Public Const RIGHT As Integer = 0
    Public Const LEFT As Integer = 1
    Public Const DOWN As Integer = 2
    Public Const UP As Integer = 3

    'Størrelsen på slangen
    Public snakeSize As Integer = 3
    'Dim snakeSize = Form3.snakeSize2

    'Array på grafikkgreiene, brukar picturebox. Vanlegvis ikkje i bruk.
    Public graphic_map(Size, Size) As PictureBox
    'Array på kva tile er kor. Eit rutenett.
    Public data_map(Size, Size) As Integer

    'Data på bildene.
    Public tiles(3) As String
    Public tilesimg(3) As Bitmap
    Public tilesColor(3) As Color
    Public snakeColors As Color()

    Public Const TRIPPY As Integer = 1

    Public mode As Integer
    Public modeArray As Integer

    'Slangedataen. Eit array av punkt. Både x og y
    Public snake(snakeSize) As Point
    'Kva rettning slangen har.
    Public direction As Integer
    Public ready As Boolean


    'Intervallet som alt blir oppdatert på. I millisekund
    Public speed As Integer = 100
    Public freq As Integer = 100

    'Punktet der 'eplet' er på
    Public applePoint As Point

    Public Canvas As Panel

    'Variabler som blir brukt uttafor.
    Public lost As Boolean
    Private eple As Boolean

    'Sjekkar om brukaren trykker på knappar
    Sub keyUpdate(ByVal sender As Object, ByVal e As KeyEventArgs)

        If ready And direction = RIGHT Or direction = LEFT Then
            Select Case e.KeyCode
                Case Keys.Up
                    direction = UP
                    ready = False
                Case Keys.Down
                    direction = DOWN
                    ready = False
            End Select
        Else
            Select Case e.KeyCode
                Case Keys.Right
                    direction = RIGHT
                    ready = False
                Case Keys.Left
                    direction = LEFT
                    ready = False
            End Select
        End If
    End Sub

    'Startar spelet
    Public Sub init(cnvs As Panel, Ticker As Timer)

        Canvas = cnvs

        lost = False
        eple = False

        'Setter opp referansar til bildet i eit array. Blir brukt i picturebox grafikk greia
        tiles(NO_TILE) = BG0IMG
        tiles(SNAKE_TILE) = BG1IMG
        tiles(APPLE_TILE) = BG2IMG

        mode = 0

        'Setter opp referansar til bildet i eit array
        tilesimg(NO_TILE) = New Bitmap(BG0IMG)
        tilesimg(SNAKE_TILE) = New Bitmap(BG1IMG)
        tilesimg(APPLE_TILE) = New Bitmap(BG2IMG)

        'Setter opp fargar til tilane
        tilesColor(NO_TILE) = Color.Black
        'tilesColor(SNAKE_TILE) = Color.Pink
        tilesColor(APPLE_TILE) = Color.Yellow

        snakeColors = New Color() {Color.White, Color.Red, Color.Blue, Color.Green, Color.Pink, Color.Gray, Color.Yellow}

        'Setter opp til picturebox-greia
        If PICBOXGRAPHICS Then
            Canvas.Visible = False
        End If

        Canvas.Size = New Size(Size * TILE_SIZE, Size * TILE_SIZE)

        'Setter opp spilleområdet.
        For x As Integer = 0 To Size - 1
            For y As Integer = 0 To Size - 1
                data_map(x, y) = 0
            Next
        Next

        'Setter opp slangen
        direction = LEFT
        ready = True
        For i As Integer = 0 To snakeSize - 1
            snake(i) = New Point(Convert.ToInt32(Math.Round(Size / 2)) + i, Convert.ToInt32(Math.Round(Size / 2)))
        Next

        speed = 100

        'Setter opp eplet 
        applePoint = New Point(0, 0)
        setNewApple()

        'Startar spelet
        Ticker.Start()
    End Sub

    'Tømmer speleområdet for alt. Gjer alle posisjonane til 0
    Public Sub ClearMap()
        For x As Integer = 0 To Size - 1
            For y As Integer = 0 To Size - 1
                If data_map(x, y) = SNAKE_TILE Then
                    data_map(x, y) = NO_TILE
                End If
            Next
        Next
    End Sub

    'Oppdater speleområdet. Viser alt som skal visast
    Public Sub UpdateMap()

        data_map(applePoint.X, applePoint.Y) = APPLE_TILE

        If PICBOXGRAPHICS Then
            For x As Integer = 0 To Size - 1
                For y As Integer = 0 To Size - 1
                    graphic_map(x, y).ImageLocation = tiles(data_map(x, y))
                Next
            Next
        Else
            Using g As Graphics = Canvas.CreateGraphics()
                g.Clear(tilesColor(NO_TILE))
                For x As Integer = 0 To Size - 1
                    For y As Integer = 0 To Size - 1
                        'g.DrawImage(tilesimg(data_map(x, y)), New Point(x * TILE_SIZE, y * TILE_SIZE))
                        If data_map(x, y) <> 0 Then
                            Dim rect As Rectangle = New Rectangle(x * TILE_SIZE, y * TILE_SIZE, TILE_SIZE, TILE_SIZE)

                            Dim p As Brush
                            If data_map(x, y) = APPLE_TILE Then
                                p = New SolidBrush(tilesColor(APPLE_TILE))
                            Else
                                p = New SolidBrush(snakeColors(Convert.ToInt16(Rnd() * (snakeColors.Length - 1))))
                            End If

                            g.FillRectangle(p, rect)
                        End If
                    Next
                Next
            End Using
        End If
    End Sub

    'Oppdaterar slangen
    Public Sub UpdateSnake()

        Dim prevp As Point
        Dim temp As Point
        Dim frst As Boolean = True
        For i As Integer = 0 To snakeSize - 1
            temp = New Point(snake(i).X, snake(i).Y)
            If frst = True Then
                If direction = RIGHT Then
                    If snake(i).X < Size - 1 Then
                        snake(i).X += 1
                    Else
                        snake(i).X = 0
                    End If

                ElseIf direction = LEFT Then
                    If snake(i).X > 0 Then
                        snake(i).X -= 1
                    Else
                        snake(i).X = Size - 1
                    End If

                ElseIf direction = DOWN Then
                    If snake(i).Y < Size - 1 Then
                        snake(i).Y += 1
                    Else
                        snake(i).Y = 0
                    End If

                ElseIf direction = UP Then
                    If snake(i).Y > 0 Then
                        snake(i).Y -= 1
                    Else
                        snake(i).Y = Size - 1
                    End If
                Else
                    Exit For

                End If
                frst = False
                'MsgBox("Poo")
            Else
                snake(i).X = prevp.X
                snake(i).Y = prevp.Y
            End If

            prevp = New Point(temp.X, temp.Y)
        Next

        For i As Integer = 0 To snakeSize - 1
            data_map(snake(i).X, snake(i).Y) = SNAKE_TILE
        Next

        'Om snake spiser eple
        If snake(0).Equals(applePoint) Then
            setNewApple()
            Array.Resize(snake, snake.Length + 1)
            snake(snake.Length - 1) = New Point(snake(snake.Length - 2).X, snake(snake.Length - 2).Y)
            snakeSize = snakeSize + 1
            eple = True
        End If
        ready = True
    End Sub

    'Setter eplet på ein ny random plass
    Public Sub setNewApple()
        Dim chance As Double = 0.01
        Dim found As Boolean = False

        'data_map(applePoint.X, applePoint.Y) = NO_TILE

        While found = False
            For x As Integer = 0 To Size - 1
                For y As Integer = 0 To Size - 1
                    If data_map(x, y) = NO_TILE And Rnd() * 1 < chance Then
                        applePoint.X = x
                        applePoint.Y = y
                        found = True
                        data_map(x, y) = APPLE_TILE
                        Exit While
                    End If
                Next
            Next
        End While

    End Sub

    'Spelaren tapar
    Public Sub Lose()

    End Sub

    'Funksjonen som håndterar oppdatering av spelet
    Public Sub Tick(sender As Object, e As EventArgs)
        ClearMap()
        UpdateSnake()
        UpdateMap()

        'Viser poengsummen
        'Score.Text = "Poeng: " & snakeSize - 3

        'Sjekkar om slangen kolliderar med seg sjølv
        For i As Integer = 1 To snakeSize - 1
            If snake(0) = snake(i) Then
                lost = True
            End If
        Next

        freq = speed

        Select Case mode
            Case 0

            Case TRIPPY
                freq = Convert.ToInt16(Rnd() * 200)
        End Select
    End Sub

    Public Function getScore() As Integer
        Return snakeSize - 3
    End Function
    Public Function gotApple() As Boolean
        Dim temp As Boolean = eple

        eple = False

        Return temp
    End Function

End Class
