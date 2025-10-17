'Rudy Earnest
'RCET 3371
'Fall 2025
'Dart Game Simulator
Option Strict On
Option Explicit On
Option Compare Text
Public Class DartGameSim
    'functions--------------------------------------------------------------------------------------------
    'function returns a random number within the bounds of the max x of the picture box
    Function RandomXCoordinate() As Integer
        Randomize()
        Dim xRandom As Integer
        xRandom = CInt(DartBoardPictureBox.Width * Rnd())
        Return xRandom
    End Function

    Function RandomYCoordinate() As Integer
        Randomize()
        Dim yRandom As Integer
        yRandom = CInt(DartBoardPictureBox.Height * Rnd())
        Return yRandom
    End Function



    'subs-------------------------------------------------------------------------------------------------











    'event handlers---------------------------------------------------------------------------------------
    Private Sub StartRoundButton_Click(sender As Object, e As EventArgs) Handles StartRoundButton.Click
        Dim xBound As Integer
        Dim yBound As Integer
        xBound = RandomXCoordinate()
        yBound = RandomYCoordinate()
        Console.WriteLine($"X Coordinate: {xBound} Y Coordinate: {yBound}")
    End Sub

    Private Sub ReviewButton_Click(sender As Object, e As EventArgs) Handles ReviewButton.Click

    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub DartBoardPictureBox_MouseMove(sender As Object, e As MouseEventArgs) Handles DartBoardPictureBox.MouseMove
        Dim xPosition As Integer
        Dim yPosition As Integer
        xPosition = e.X
        yPosition = e.Y
        Me.Text = $"X: {xPosition} Y: {yPosition}"
    End Sub
End Class
