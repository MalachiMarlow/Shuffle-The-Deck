'Malachi Marlow
'Spring 2025
'RCET2265
'ShuffleTheDeck
'https://github.com/MalachiMarlow/Shuffle-The-Deck.git

Option Compare Text
Option Explicit On
Option Strict On

Module ShuffleTheDeck

    Sub Main()
        Dim userInput As String

        Do
            Console.Clear()
            DisplayBoard()
            Console.WriteLine()
            'prompt
            Console.WriteLine("Enter D to draw a Card, C to Shuffle the deck, or Q to quit.")
            userInput = Console.ReadLine()
            Select Case userInput
                Case "D"
                    drawCard()
                Case "C"
                    DeckTracker(0, 0,, True)
                    drawCard(True)
                Case Else
                    Console.WriteLine("Wrong.")
            End Select

            Console.Clear()
        Loop Until userInput = "Q"


        Console.WriteLine("Have a great day!")
    End Sub
    Function formatCardLetter(CardLetter As Integer) As String
        Dim _CardLetter As String
        Select Case CardLetter
            Case 0
                _CardLetter = "B"
            Case 1
                _CardLetter = "I"
            Case 2
                _CardLetter = "N"
            Case 3
                _CardLetter = "G"
            Case 4
                _CardLetter = "O"
                Return _CardLetter
        End Select
    End Function

    Sub drawCard(Optional clearCount As Boolean = False)
        Dim temp(,) As Boolean = DeckTracker(0, 0)
        Dim currentSuit As Integer
        Dim currentType As Integer
        Static cardCounter As Integer

        If clearCount Then
            cardCounter = 0
        Else


            Do
                currentSuit = randomNumberBetween(0, 14)

                currentType = randomNumberBetween(0, 4)

            Loop Until temp(currentSuit, currentType) = False Or cardCounter >= 75

            DeckTracker(currentSuit, currentType, True)
            cardCounter += 1

            Console.WriteLine($"The current row is {currentSuit} and column is {currentType}")
        End If
    End Sub

    Function cardTracker(cardSuit As Integer, cardNumber As Integer, Optional clear As Boolean = False, Optional update As Boolean = False) As Boolean(,)
        Static _cardTracker(12, 3) As Boolean

        If update Then
            _cardTracker(cardNumber, cardSuit) = True
        End If
        If clear Then
            ReDim _cardTracker(12, 3)
        End If
        Return _cardTracker
    End Function

    Function DeckTracker(cardSuit As Integer, cardType As Integer, Optional update As Boolean = False, Optional clear As Boolean = False) As Boolean(,)
        Static _deckTracker(12, 3) As Boolean

        If update Then
            _deckTracker(cardSuit, cardType) = True
        End If

        If clear Then
            ReDim _deckTracker(12, 3)
        End If

        Return _deckTracker
    End Function

    Sub DisplayBoard()
        Dim displayString As String = "X |"
        Dim heading() As String = {"Club", "Heart", "Spade", "Diamond"}
        Dim tracker(,) As Boolean = DeckTracker(0, 0)
        Dim columnWidth As Integer = 11

        For Each Suit In heading
            Console.Write(Suit.PadLeft(CInt(Math.Ceiling(columnWidth \ 2))).PadRight(columnWidth))
        Next

        Console.WriteLine()
        Console.WriteLine(StrDup(columnWidth * 4, "_"))

        For currentNumber = 0 To 12
            For currentSuit = 0 To 3
                If tracker(currentNumber, currentSuit) Then
                    displayString = $"{TypeofCard(currentNumber, currentSuit)} |"
                Else
                    displayString = " |"
                End If

                displayString = displayString.PadLeft(columnWidth)
                Console.Write(displayString)

            Next
            Console.WriteLine()
        Next

    End Sub

    Function TypeofCard(CardNumber As Integer, CardLetter As Integer) As String
        Dim _TypeofCard As String
        Select Case CardNumber
            Case 0
                _TypeofCard = "A"
            Case 1 To 9
                _TypeofCard = CStr(CardNumber + 1)
            Case 10 To 12
                If CardNumber = 10 Then
                    _TypeofCard = "J"
                ElseIf CardNumber = 11 Then
                    _TypeofCard = "Q"
                ElseIf CardNumber = 12 Then
                    _TypeofCard = "K"
                End If
        End Select

        Return _TypeofCard
    End Function

    Function randomNumberBetween(min As Integer, max As Integer) As Integer
        Randomize()
        Return CInt(Math.Ceiling(max - min) * Rnd() + min)
    End Function

End Module