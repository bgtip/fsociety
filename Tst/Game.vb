﻿Public Class Game
    Dim SIZE = Form3.SIZE2 'Størrelsen på spillområdet, satt ut i fra spillerens valg i options.
    Dim TILE_SIZE = 0
    'Oppdateringsfrekvensen til spelet.
    Dim speed = Form3.speed2

    'Bilda som blir brukt i spelet
    Public Const BG0IMG As String = "img/game/chip.png"

    'Kva nummer kvar tile er
    Public Const NO_TILE As Integer = 0
    Public Const SNAKE_TILE As Integer = 1
    Public Const APPLE_TILE As Integer = 2
    Public Const STONE_TILE As Integer = 3

    'Rettningane til slangen
    Public Const RIGHT As Integer = 0
    Public Const LEFT As Integer = 1
    Public Const DOWN As Integer = 2
    Public Const UP As Integer = 3

    'Størrelsen på slangen
    Public snakeSize As Integer = 10

    'Scoren etter lengde på slangen
    Public score As Integer = 0

    'Array på grafikkgreiene, brukar picturebox. Vanlegvis ikkje i bruk.
    Public graphic_map(Size, Size) As PictureBox
    'Array på kva tile er kor. Eit rutenett.
    Public data_map(Size, Size) As Integer

    'Data på bildene og fargane som høyrer til slangen og tile'ane.
    Public tiles(4) As String
    Public tilesimg(4) As Bitmap
    Public tilesColor(4) As Color
    Public snakeColors As Color()
    Public normalColors As Color()
    Public discoColors As Color()

    'Slangedataen. Eit array av punkt. Både x og y
    Public snake(snakeSize) As Point

    'Kva rettning slangen har.
    Public direction As Integer
    'Om slangen er klar til å endre rettning.
    Public ready As Boolean
    'Om slangen skal teiknast på skjermen.
    Public drawSnake As Boolean


    'Intervallet som alt blir oppdatert på. I millisekund
    Public freq As Integer = speed

    'Liste over punkta steinane er på.
    Public stonePoint As List(Of Point) = New List(Of Point)

    'Punktet der 'eplet' er på
    Public applePoint As Point

    'Array av epleeffektar
    Public appleEffects As Action()
    'Array av bilda som vises på ein effekt.
    Public effectImages As Image()
    'Array av lydane som blir brukt på kvar effekt.
    Public effectSounds As String()
    Public playSound As Boolean
    'Den aktive effekten
    Public activeEffect As Integer = -1
    'Sjansen på å få ein effekt.
    Public effectChance As Single = Form3.modeChance
    'Effektvariabler.
    Public trippyImg As Image
    Public invevrysec As Integer = 5000
    Public invi As Integer = 0
    Public invit As Integer = 0

    'Tilfeldige lydar
    Public soundTimer As Timer
    Public stmin As Integer = 5000
    Public stmax As Integer = 20000
    Public stsounds As String()

    'Lydobjektet
    Public sound As Sound

    Public screenImgPoint As Point = New Point(0, 0)

    'Panelet som spelet blir teikna på.
    Public Canvas As Panel
    'Oppdateringstimeren.
    Public timer As Timer

    'Variabler som blir brukt uttafor.
    Public lost As Boolean
    Private eple As Boolean
    Public closing As Boolean

    'Knapper, kva kontrollar som kontrollerar kva.
    Dim buttonUp = Keys.Up
    Dim buttonDown = Keys.Down
    Dim buttonRight = Keys.Right
    Dim buttonLeft = Keys.Left
    Dim buttonPause = Keys.P
    Dim buttonExit = Keys.Escape
    'Brukes for å forhindre at to knappar trykkast samtidig (aka krasj)
    Dim ko As Queue = New Queue()

    Dim keyState

    'Sjekkar om brukaren trykker på knappar
    Sub keyUpdate(ByVal sender As Object, ByVal e As KeyEventArgs)

        If ready And direction = RIGHT Or direction = LEFT Then
            Select Case e.KeyCode
                Case buttonUp
                    ready = False
                    keyState = e.KeyCode
                Case buttonDown
                    ready = False
                    keyState = e.KeyCode
            End Select
        ElseIf ready And direction = UP Or direction = DOWN Then
            Select Case e.KeyCode
                Case buttonRight
                    ready = False
                    keyState = e.KeyCode
                Case buttonLeft
                    ready = False
                    keyState = e.KeyCode
            End Select
        End If

        'Sjekkar om pause
        Select Case e.KeyCode
            Case buttonPause
                pause()
            Case buttonExit
                If Not lost Then
                    pause()
                End If
                Dim msg = MsgBox("Do you want to exit to the menu?", vbYesNo, "fsociety27.dat")

                pause()


                If msg = vbYes Then
                    sound.stopSound("music")
                    closing = True
                End If

        End Select
    End Sub

    'Startar spelet
    Public Sub init(cnvs As Panel, Ticker As Timer, st As Timer, snd As Sound)
        Canvas = cnvs
        soundTimer = st
        stsounds = New String() {"sound/fx/control.wav", "sound/fx/owned.wav"}
        sound = snd

        lost = False
        eple = False
        closing = False

        'Setter opp referansar til bildet i eit array. Blir brukt i picturebox grafikk greia
        tiles(APPLE_TILE) = BG0IMG

        'MsgBox(SIZE)
        TILE_SIZE = Convert.ToInt32(Canvas.Width / SIZE)

        'Setter opp referansar til bildet i eit array
        tilesimg(APPLE_TILE) = New Bitmap(BG0IMG)

        'Setter opp fargar til tilane
        tilesColor(NO_TILE) = Color.Black
        tilesColor(APPLE_TILE) = Color.Yellow
        tilesColor(STONE_TILE) = Color.Gray

        'Setter opp fargane til snake.
        normalColors = New Color() {Color.White, Color.Gray, Color.FromArgb(255, 200, 200, 200), Color.FromArgb(255, 180, 180, 180), Color.FromArgb(255, 160, 160, 160), Color.FromArgb(255, 140, 140, 140), Color.FromArgb(255, 120, 120, 120), Color.FromArgb(255, 100, 100, 100)}
        discoColors = New Color() {Color.Blue, Color.Red, Color.Pink, Color.Yellow, Color.White, Color.Green}
        snakeColors = normalColors

        'Setter opp epleeffaktar
        appleEffects = New Action() {AddressOf modeTrippy, AddressOf modeSuperspeed, AddressOf modeInvisible, AddressOf modeMsgBox}
        effectImages = New Image() {New Bitmap("img/game/trippy.png"), New Bitmap("img/game/superspeed.png"), New Bitmap("img/game/glitchy.png"), Nothing}
        effectSounds = New String() {"sound/music/trippy.wav", "sound/music/speed.wav", "sound/music/glitch.wav", ""}
        playSound = False

        Canvas.Size = New Size(SIZE * TILE_SIZE, SIZE * TILE_SIZE)

        'Setter opp spilleområdet.
        For x As Integer = 0 To SIZE - 1
            For y As Integer = 0 To SIZE - 1
                data_map(x, y) = 0
            Next
        Next

        'Setter opp slangen
        direction = LEFT
        ready = True
        For i As Integer = 0 To snakeSize - 1
            snake(i) = New Point(Convert.ToInt32(Math.Round(SIZE / 2)) + i, Convert.ToInt32(Math.Round(SIZE / 2)))
        Next
        drawSnake = True
        speed = Form3.speed2

        'Setter opp eplet 
        applePoint = New Point(0, 0)
        setNewApple()

        'Startar spelet
        timer = Ticker
        Ticker.Start()
    End Sub

    'Tømmer speleområdet for alt. Gjer alle posisjonane til 0
    Public Sub ClearMap()
        For x As Integer = 0 To SIZE - 1
            For y As Integer = 0 To SIZE - 1
                If data_map(x, y) = SNAKE_TILE Then
                    data_map(x, y) = NO_TILE
                End If
            Next
        Next
    End Sub

    'Oppdater speleområdet. Viser alt som skal visast
    Public Sub UpdateMap()

        For Each o In stonePoint
            data_map(o.X, o.Y) = STONE_TILE
            Console.WriteLine("Stones")
        Next

        data_map(applePoint.X, applePoint.Y) = APPLE_TILE
        Using g As Graphics = Canvas.CreateGraphics()
            g.Clear(tilesColor(NO_TILE))
            For x As Integer = 0 To SIZE - 1
                For y As Integer = 0 To SIZE - 1
                    If data_map(x, y) <> 0 Then

                        'Om det er definert eit bilde, blir det brukt.
                        If tilesimg(data_map(x, y)) IsNot Nothing Then
                            g.DrawImage(tilesimg(data_map(x, y)), x * TILE_SIZE, y * TILE_SIZE, TILE_SIZE, TILE_SIZE)
                        ElseIf data_map(x, y) = SNAKE_TILE Then
                            Dim rect As Rectangle = New Rectangle(x * TILE_SIZE, y * TILE_SIZE, TILE_SIZE, TILE_SIZE)

                            Dim p As Brush
                            If data_map(x, y) = APPLE_TILE Then
                                p = New SolidBrush(tilesColor(APPLE_TILE))
                            ElseIf data_map(x, y) = SNAKE_TILE And drawSnake Then
                                p = New SolidBrush(snakeColors(Convert.ToInt16(Rnd() * (snakeColors.Length - 1))))
                            Else
                                p = New SolidBrush(Color.Black)
                            End If

                            g.FillRectangle(p, rect)
                        Else
                            Dim rect As Rectangle = New Rectangle(x * TILE_SIZE, y * TILE_SIZE, TILE_SIZE, TILE_SIZE)
                            Dim p As Brush = New SolidBrush(tilesColor(data_map(x, y)))
                            g.FillRectangle(p, rect)
                        End If
                    End If
                Next
            Next
        End Using
    End Sub

    'Oppdaterar slangen
    Public Sub UpdateSnake()

        'Håndterer bevegelsen av slangen.
        Dim prevp As Point
        Dim temp As Point
        Dim frst As Boolean = True
        For i As Integer = 0 To snakeSize - 1
            temp = New Point(snake(i).X, snake(i).Y)
            If frst = True Then
                If direction = RIGHT Then
                    If snake(i).X < SIZE - 1 Then
                        snake(i).X += 1
                    Else
                        snake(i).X = 0
                    End If

                ElseIf direction = LEFT Then
                    If snake(i).X > 0 Then
                        snake(i).X -= 1
                    Else
                        snake(i).X = SIZE - 1
                    End If

                ElseIf direction = DOWN Then
                    If snake(i).Y < SIZE - 1 Then
                        snake(i).Y += 1
                    Else
                        snake(i).Y = 0
                    End If

                ElseIf direction = UP Then
                    If snake(i).Y > 0 Then
                        snake(i).Y -= 1
                    Else
                        snake(i).Y = SIZE - 1
                    End If
                Else
                    Exit For

                End If
                frst = False
            Else
                snake(i).X = prevp.X
                snake(i).Y = prevp.Y
            End If

            prevp = New Point(temp.X, temp.Y)
        Next

        'Setter inn punkta der slangen er i på kartet.
        For i As Integer = 0 To snakeSize - 1
            data_map(snake(i).X, snake(i).Y) = SNAKE_TILE
        Next

        'Om hodet til slangen rørar ein plass på spelet som allereie er oppteken (stein, seg sjøl) tapar brukaren
        For Each o In stonePoint
            If snake(0).Equals(o) Then
                Lose()
            End If
        Next


        'Om snake spiser eple
        If snake(0).Equals(applePoint) Then
            'Finner ny posisjon til eplet
            setNewApple()
            If effectChance < 1 Then
                modeNewStone()
            End If

            'Random effect
            Dim vrnd As Single = Rnd()
                If vrnd > effectChance Then
                    playSound = True
                    activeEffect = Convert.ToInt32((appleEffects.Length - 1) * Rnd())
                Else
                    playSound = True
                    activeEffect = -1
                End If

                Array.Resize(snake, snake.Length + 1)
                snake(snake.Length - 1) = New Point(snake(snake.Length - 2).X, snake(snake.Length - 2).Y)
                snakeSize = snakeSize + 1
                score += 1
                eple = True
            End If
            ready = True
    End Sub

    'Setter eplet på ein ny random plass
    Public Sub setNewApple()
        Dim chance As Double = 0.01
        Dim found As Boolean = False

        Dim x = 0
        Dim y = 0

        While True
            x = ((SIZE - 1) * Rnd())
            y = ((SIZE - 1) * Rnd())

            If data_map(x, y) <> SNAKE_TILE And data_map(x, y) <> STONE_TILE Then
                Exit While
            End If

        End While
        applePoint.X = x
        applePoint.Y = y
        Console.WriteLine(x, y)
        found = True
        data_map(x, y) = APPLE_TILE
    End Sub

    'Spelaren tapar
    Public Sub Lose()
        drawSnake = True
        UpdateMap()
        lost = True
        sound.stopSound("music")
    End Sub

    'Funksjonen som håndterar oppdatering av spelet
    Public Sub Tick(sender As Object, e As EventArgs)
        ClearMap()
        UpdateSnake()
        UpdateMap()

        'Håndterer kontrollen av slangen.
        If direction = RIGHT Or direction = LEFT Then
            Select Case keyState
                Case Keys.Up
                    direction = UP
                Case Keys.Down
                    direction = DOWN

            End Select
        ElseIf direction = UP Or direction = DOWN Then
            Select Case keyState
                Case Keys.Right
                    direction = RIGHT
                Case Keys.Left
                    direction = LEFT
            End Select
        End If

        ko.Clear()

        'Sjekkar om slangen kolliderar med seg sjølv. Om den gjer, tapar spelaren.
        For i As Integer = 1 To snakeSize - 1
            If snake(0) = snake(i) Then
                Lose()
            End If
        Next

        'Setter inn oppdateringsfrekvensen.
        freq = speed

        'Tilfeldige lyder
        If soundTimer.Enabled Then

        Else
            soundTimer.Interval = Convert.ToInt32(stmin + Rnd() * (stmax - stmin))
            soundTimer.Enabled = True
        End If

        'setter at slangen skal visast på skjermen.
        drawSnake = True

        snakeColors = normalColors

        'Sjekkar for aktive effektar og kjøyrer dei.
        If activeEffect > -1 Then


            If effectImages(activeEffect) Is Nothing Then
            Else

                drawScreenImage(effectImages(activeEffect))
            End If
            If playSound And effectSounds(activeEffect).Length > 0 Then
                sound.playSound(effectSounds(activeEffect), "music")
                playSound = False
            End If

            appleEffects(activeEffect)()
        Else
            sound.stopSound("music")
        End If

    End Sub

    'Når Spillet bestemmer seg å spille av ein tilfeldig lyd.
    Public Sub stTick()

        sound.playSound(stsounds(Rnd() * (stsounds.Length - 1)), "talking")
        soundTimer.Enabled = False
    End Sub

    'Får poengsummen til spelet.
    Public Function getScore() As Integer
        Return score
    End Function

    'Returnerer True da slangen nettop har ete eit eple.
    Public Function gotApple() As Boolean
        Dim temp As Boolean = eple
        eple = False
        Return temp
    End Function

    'Pauser spelet. Eller setter spelet til ikkje pause.
    Public Function pause() As Boolean
        timer.Enabled = Not timer.Enabled()
        If timer.Enabled <> True Then
            Using g As Graphics = Canvas.CreateGraphics()

                'Teiknar pausesymbol
                Dim b As Brush = New SolidBrush(Color.White)

                g.FillRectangle(b, Convert.ToInt32((SIZE * TILE_SIZE) / 2 - (SIZE * TILE_SIZE) / 4), Convert.ToInt32((SIZE * TILE_SIZE) / 2 - (SIZE * TILE_SIZE) / 4), Convert.ToInt32((SIZE * TILE_SIZE) / 6), Convert.ToInt32((SIZE * TILE_SIZE) / 2))
                g.FillRectangle(b, Convert.ToInt32((SIZE * TILE_SIZE) / 2 - (SIZE * TILE_SIZE) / 4) * 2, Convert.ToInt32((SIZE * TILE_SIZE) / 2 - (SIZE * TILE_SIZE) / 4), Convert.ToInt32((SIZE * TILE_SIZE) / 6), Convert.ToInt32((SIZE * TILE_SIZE) / 2))
            End Using
        End If

        Return timer.Enabled
    End Function

    'Viser bilde på skjermen. Brukt til å vise kva mode som er aktiv.
    Public Sub drawScreenImage(img As Image)
        Using g As Graphics = Canvas.CreateGraphics()
            screenImgPoint.X = (SIZE * TILE_SIZE) / 2 - 100

            g.DrawImage(img, screenImgPoint.X, screenImgPoint.Y, 200, 200)
        End Using
    End Sub

    'Funskjonen som blir brukt i trippy mode.
    Public Sub modeTrippy()
        snakeColors = discoColors
        freq = Convert.ToInt16(Rnd() * 200) + 1
    End Sub

    'Funksjonen som blir brukt i superspeed mode.
    Public Sub modeSuperspeed()
        freq = 25
    End Sub

    'Funksjonen som blir brukt i glitch-mode
    Public Sub modeInvisible()
        drawSnake = False
        invi = invi + 1

        If invi > 10 Then
            drawSnake = True
            invi = 0
        End If

    End Sub

    'Stein modus, legger ut steiner på tilfeldige plasser på spillebrettet
    Public Sub modeNewStone()
        Dim chance As Double = 0.01

        Dim x = 0
        Dim y = 0

        While True
            x = ((SIZE - 1) * Rnd())
            y = ((SIZE - 1) * Rnd())

            If data_map(x, y) <> SNAKE_TILE And data_map(x, y) <> APPLE_TILE And data_map(x, y) <> STONE_TILE Then
                Exit While
            End If

        End While
        stonePoint.Add(New Point(x, y))
        Console.WriteLine(x, y)
        data_map(x, y) = STONE_TILE
        activeEffect = -1
    End Sub

    'Troll message box
    Public Sub modeMsgBox()

        Dim msg As String() = New String() {"Heisann!", "You suck!", "I am the best!", "Snake!", "Get rekt!", "Peek-a-boo!", "Shoutout til Hytt&Pine!", "Psyched!", "Control is an illusion.", "Aldri gå i deg sjølv", "Harambe did nothing wrong!"}
        activeEffect = -1
        MsgBox(msg(Convert.ToInt32(Rnd() * (msg.Length - 1))), vbOKOnly, "HURRY")
    End Sub
End Class
