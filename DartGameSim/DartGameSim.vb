'Rudy Earnest
'RCET 3371
'Fall 2025
'Dart Game Simulator
Option Strict On
Option Explicit On
Option Compare Text
Imports System.IO
Public Class DartGameSim
    'functions--------------------------------------------------------------------------------------------
    'dimming variables that need to persist throughtout the form
    Public roundNumber As Integer = 1
    Public dartThrowCount As Integer = 0
    Public filePath As String = "DartGame.log"
    'random coordinate generators for within the bounds of the picture box of x and y
    Function RandomXCoordinate() As Integer
        Dim xRandom As Integer
        xRandom = CInt(DartBoardPictureBox.Width * Rnd())
        Return xRandom
    End Function

    Function RandomYCoordinate() As Integer
        Dim yRandom As Integer
        yRandom = CInt(DartBoardPictureBox.Height * Rnd())
        Return yRandom
    End Function



    'event handlers---------------------------------------------------------------------------------------
    'gets random coordinates draws the dart and logs the coordinates to a sequential file
    Private Sub StartRoundButton_Click(sender As Object, e As EventArgs) Handles StartRoundButton.Click
        ReviewButton.Enabled = False
        DartBoardPictureBox.Refresh()
        For i = 1 To 3
            Dim timeStamp As String = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")
            Dim logMessage As String
            Dim radius As Integer = 30
            Dim xBound As Integer
            Dim yBound As Integer
            Dim g As Graphics = DartBoardPictureBox.CreateGraphics()
            Dim pen As New Pen(Color.Black)
            Dim pen1 As New Pen(Color.Red)
            xBound = RandomXCoordinate()
            yBound = RandomYCoordinate()

            g.DrawEllipse(pen, CInt(xBound - (radius / 2)), CInt(yBound - CInt(radius / 2)), radius, radius)
            g.DrawLine(pen1, xBound - 3, yBound, xBound + 3, yBound)
            g.DrawLine(pen1, xBound, yBound - 3, xBound, yBound + 3)
            pen.Dispose()
            pen1.Dispose()
            g.Dispose()
            'log the coordinates in a sequential file
            logMessage = $"Round: {roundNumber} X: {xBound}, Y: {yBound} - Dart: {i} Time: {timeStamp}"
            Try
                File.AppendAllText(filePath, logMessage & vbCrLf)
            Catch ex As Exception
                MessageBox.Show($"Error writing to log file: {ex.Message} ")
            End Try
        Next
        RoundLabel.Text = $"Round: {roundNumber}"
        roundNumber += 1
        dartThrowCount += 3
        DartCountLabel.Text = $"Darts Thrown: {dartThrowCount}"
        ReviewButton.Enabled = True
    End Sub

    'opens the review form as a dialog disabling the start round button while open
    Private Sub ReviewButton_Click(sender As Object, e As EventArgs) Handles ReviewButton.Click
        StartRoundButton.Enabled = False
        ReviewForm.ShowDialog()
        StartRoundButton.Enabled = True
    End Sub

    'logs the end of a game and closes the form
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        File.AppendAllText(filePath, "End of Game" & vbCrLf)
        Me.Close()
    End Sub
    'displays the mouse coordinates in the form title bar as the mouse moves over the picture box
    'Private Sub DartBoardPictureBox_MouseMove(sender As Object, e As MouseEventArgs) Handles DartBoardPictureBox.MouseMove
    '    Dim xPosition As Integer
    '    Dim yPosition As Integer
    '    xPosition = e.X
    '    yPosition = e.Y
    '    Me.Text = $"X: {xPosition} Y: {yPosition}"
    'End Sub

    'initializes random number generator and logs the start of a new game
    Private Sub DartGameSim_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()
        File.AppendAllText(filePath, "Start of new Game" & vbCrLf)
    End Sub
End Class
