Option Explicit On
Option Strict On
Option Compare Text
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class ReviewForm

    ' parsed rounds: round number -> array of up to 3 nullable Points (indices 0..2 => Dart 1..3)
    Private rounds As Dictionary(Of Integer, System.Nullable(Of System.Drawing.Point)()) = New Dictionary(Of Integer, System.Nullable(Of System.Drawing.Point)())()
    Private roundTimes As Dictionary(Of Integer, DateTime) = New Dictionary(Of Integer, DateTime)()
    Private currentPoints As System.Nullable(Of System.Drawing.Point)() = Nothing

    Private Sub ExitReviewButton_Click(sender As Object, e As EventArgs) Handles ExitReviewButton.Click
        Me.Close()
    End Sub

    Private Sub ProcessReviewButton_Click(sender As Object, e As EventArgs) Handles ProcessReviewButton.Click
        Dim filePath As String = "DartGame.log"
        ReviewFormListBox.Items.Clear()
        rounds.Clear()
        roundTimes.Clear()
        currentPoints = Nothing
        ReviewFormPictureBox.Invalidate()

        If Not File.Exists(filePath) Then
            MessageBox.Show("Log file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim allLines As String() = File.ReadAllLines(filePath)

        ' Find the last "Start of new Game" marker and limit parsing to that session only.
        Dim lastStartIndex As Integer = -1
        For i As Integer = 0 To allLines.Length - 1
            If allLines(i).StartsWith("Start of new Game") Then
                lastStartIndex = i
            End If
        Next

        ' Build sessionLines without LINQ
        Dim sessionLinesList As New List(Of String)()
        If lastStartIndex >= 0 AndAlso lastStartIndex < allLines.Length - 1 Then
            For i As Integer = lastStartIndex + 1 To allLines.Length - 1
                sessionLinesList.Add(allLines(i))
            Next
        Else
            For i As Integer = 0 To allLines.Length - 1
                sessionLinesList.Add(allLines(i))
            Next
        End If

        ' Regex captures: Round, X, Y, Dart, Time (time may contain spaces)
        Dim rx As New Regex("Round:\s*(\d+)\s+X:\s*(\d+),\s*Y:\s*(\d+)\s*-\s*Dart:\s*(\d+)\s*Time:\s*(.+)$", RegexOptions.Compiled)

        For Each line As String In sessionLinesList
            Dim m As Match = rx.Match(line)
            If m.Success Then
                Dim roundNum As Integer = Integer.Parse(m.Groups(1).Value)
                Dim x As Integer = Integer.Parse(m.Groups(2).Value)
                Dim y As Integer = Integer.Parse(m.Groups(3).Value)
                Dim dartNum As Integer = Integer.Parse(m.Groups(4).Value)
                Dim timeStr As String = m.Groups(5).Value.Trim()
                Dim parsedTime As DateTime
                If DateTime.TryParse(timeStr, parsedTime) = False Then
                    parsedTime = DateTime.MinValue
                End If

                Dim pts As System.Nullable(Of System.Drawing.Point)()
                If Not rounds.ContainsKey(roundNum) Then
                    pts = New System.Nullable(Of System.Drawing.Point)(2) {}
                    rounds.Add(roundNum, pts)
                Else
                    pts = rounds(roundNum)
                End If

                If dartNum >= 1 AndAlso dartNum <= 3 Then
                    pts(dartNum - 1) = New System.Drawing.Point(x, y)
                End If

                ' keep the latest timestamp for the round
                If parsedTime <> DateTime.MinValue Then
                    If Not roundTimes.ContainsKey(roundNum) OrElse parsedTime > roundTimes(roundNum) Then
                        roundTimes(roundNum) = parsedTime
                    End If
                Else
                    If Not roundTimes.ContainsKey(roundNum) Then
                        roundTimes(roundNum) = DateTime.MinValue
                    End If
                End If
            End If
        Next

        ' populate the ListBox with parsed rounds in ascending order (no LINQ)
        Dim keyList As New List(Of Integer)()
        For Each k As Integer In rounds.Keys
            keyList.Add(k)
        Next
        keyList.Sort() ' ascending

        For Each rnd As Integer In keyList
            Dim display As String
            If roundTimes.ContainsKey(rnd) AndAlso roundTimes(rnd) <> DateTime.MinValue Then
                display = $"Round {rnd} - {roundTimes(rnd):MM/dd/yyyy HH:mm:ss}"
            Else
                display = $"Round {rnd}"
            End If
            ReviewFormListBox.Items.Add(New RoundItem(rnd, display))
        Next

        ' select the last round (latest round number) if present
        If ReviewFormListBox.Items.Count > 0 Then
            ReviewFormListBox.SelectedIndex = ReviewFormListBox.Items.Count - 1
        End If
    End Sub

    ' When a round is selected, set currentPoints and invalidate the PictureBox so Paint will draw them
    Private Sub ReviewFormListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ReviewFormListBox.SelectedIndexChanged
        Dim item As RoundItem = TryCast(ReviewFormListBox.SelectedItem, RoundItem)
        If item Is Nothing Then
            currentPoints = Nothing
            ReviewFormPictureBox.Invalidate()
            Return
        End If

        If rounds.ContainsKey(item.RoundNumber) Then
            currentPoints = rounds(item.RoundNumber)
        Else
            currentPoints = Nothing
        End If

        ReviewFormPictureBox.Invalidate()
    End Sub

    ' Draw darts for the selected round. Drawing is performed in Paint to persist visual state.
    Private Sub ReviewFormPictureBox_Paint(sender As Object, e As PaintEventArgs) Handles ReviewFormPictureBox.Paint
        If currentPoints Is Nothing Then
            Return
        End If

        Dim radius As Integer = 30
        Using penBlack As New System.Drawing.Pen(System.Drawing.Color.Black)
            Using penRed As New System.Drawing.Pen(System.Drawing.Color.Red)
                For Each pNullable As System.Nullable(Of System.Drawing.Point) In currentPoints
                    If pNullable.HasValue Then
                        Dim p As System.Drawing.Point = pNullable.Value
                        ' ensure coordinates are within PictureBox bounds before drawing
                        Dim xDraw As Integer = Math.Max(0, Math.Min(ReviewFormPictureBox.Width - 1, p.X))
                        Dim yDraw As Integer = Math.Max(0, Math.Min(ReviewFormPictureBox.Height - 1, p.Y))

                        e.Graphics.DrawEllipse(penBlack, CInt(xDraw - (radius \ 2)), CInt(yDraw - (radius \ 2)), radius, radius)
                        e.Graphics.DrawLine(penRed, xDraw - 3, yDraw, xDraw + 3, yDraw)
                        e.Graphics.DrawLine(penRed, xDraw, yDraw - 3, xDraw, yDraw + 3)
                    End If
                Next
            End Using
        End Using
    End Sub

    ' Backwards-compatible overload (keeps existing callers that pass file + line index).
    Function XCoordinate(filePath As String, lineNumber As Integer) As Integer
        Try
            Dim allLines As String() = File.ReadAllLines(filePath)
            If lineNumber >= 0 AndAlso lineNumber < allLines.Length Then
                Return XCoordinate(allLines(lineNumber))
            End If
        Catch ex As Exception
            MessageBox.Show("Error reading log file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return 0
    End Function

    ' Parse X from a single log line using regex: "X: 653"
    Function XCoordinate(line As String) As Integer
        Dim fileX As Integer = 0
        Try
            Dim m As Match = Regex.Match(line, "X:\s*(\d+)")
            If m.Success Then
                Integer.TryParse(m.Groups(1).Value, fileX)
            End If
        Catch ex As Exception
            MessageBox.Show("Error parsing X coordinate: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return fileX
    End Function

    Function YCoordinate(filePath As String, lineNumber As Integer) As Integer
        Try
            Dim allLines As String() = File.ReadAllLines(filePath)
            If lineNumber >= 0 AndAlso lineNumber < allLines.Length Then
                Return YCoordinate(allLines(lineNumber))
            End If
        Catch ex As Exception
            MessageBox.Show("Error reading log file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return 0
    End Function

    ' Parse Y from a single log line using regex: "Y: 393"
    Function YCoordinate(line As String) As Integer
        Dim fileY As Integer = 0
        Try
            Dim m As Match = Regex.Match(line, "Y:\s*(\d+)")
            If m.Success Then
                Integer.TryParse(m.Groups(1).Value, fileY)
            End If
        Catch ex As Exception
            MessageBox.Show("Error parsing Y coordinate: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return fileY
    End Function

    Private Sub ReviewForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Make ReviewForm match the DartGameSim form size and prevent resizing.
        Try
            Dim parentSize As System.Drawing.Size = My.Forms.DartGameSim.Size
            Me.Size = parentSize

            Me.FormBorderStyle = FormBorderStyle.FixedSingle
            Me.MaximizeBox = False

            Me.MinimumSize = parentSize
            Me.MaximumSize = parentSize

            ReviewFormPictureBox.Size = My.Forms.DartGameSim.DartBoardPictureBox.Size
        Catch ex As Exception
            Me.FormBorderStyle = FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
        End Try
    End Sub

    ' Helper class to store ListBox items while keeping a friendly display text.
    Private Class RoundItem
        Public ReadOnly RoundNumber As Integer
        Private ReadOnly _display As String
        Public Sub New(roundNumber As Integer, display As String)
            Me.RoundNumber = roundNumber
            Me._display = display
        End Sub
        Public Overrides Function ToString() As String
            Return _display
        End Function
    End Class

End Class