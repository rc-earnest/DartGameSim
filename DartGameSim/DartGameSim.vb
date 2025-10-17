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
    'function returns a random number within the bounds of the max x of the picture box
    Public roundNumber As Integer = 1
    Public filePath As String = "DartGame.log"
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



    'subs-------------------------------------------------------------------------------------------------











    'event handlers---------------------------------------------------------------------------------------
    Private Sub StartRoundButton_Click(sender As Object, e As EventArgs) Handles StartRoundButton.Click
        For i = 0 To 4
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
            logMessage = $"Round: {roundNumber} Dart {i} - X: {xBound}, Y: {yBound} Time: {timeStamp}"
            File.AppendAllText(filePath, logMessage & vbCrLf)
            i += 1
        Next
        roundNumber += 1
    End Sub

    Private Sub ReviewButton_Click(sender As Object, e As EventArgs) Handles ReviewButton.Click

    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        File.AppendAllText(filePath, "End of Game" & vbCrLf)
        Me.Close()
    End Sub

    Private Sub DartBoardPictureBox_MouseMove(sender As Object, e As MouseEventArgs) Handles DartBoardPictureBox.MouseMove
        Dim xPosition As Integer
        Dim yPosition As Integer
        xPosition = e.X
        yPosition = e.Y
        Me.Text = $"X: {xPosition} Y: {yPosition}"
    End Sub

    Private Sub DartGameSim_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()
        File.AppendAllText(filePath, "Start of new Game" & vbCrLf)
    End Sub
End Class
