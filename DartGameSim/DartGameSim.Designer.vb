<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DartGameSim
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.DartBoardPictureBox = New System.Windows.Forms.PictureBox()
        Me.ReviewButton = New System.Windows.Forms.Button()
        Me.StartRoundButton = New System.Windows.Forms.Button()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.RoundLabel = New System.Windows.Forms.Label()
        Me.DartCountLabel = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.DartBoardPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DartBoardPictureBox
        '
        Me.DartBoardPictureBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DartBoardPictureBox.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.DartBoardPictureBox.Location = New System.Drawing.Point(12, 12)
        Me.DartBoardPictureBox.Name = "DartBoardPictureBox"
        Me.DartBoardPictureBox.Size = New System.Drawing.Size(1180, 607)
        Me.DartBoardPictureBox.TabIndex = 0
        Me.DartBoardPictureBox.TabStop = False
        Me.ToolTip1.SetToolTip(Me.DartBoardPictureBox, "Dart Board for displaying thrown darts")
        '
        'ReviewButton
        '
        Me.ReviewButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ReviewButton.BackColor = System.Drawing.SystemColors.Info
        Me.ReviewButton.Location = New System.Drawing.Point(12, 644)
        Me.ReviewButton.Name = "ReviewButton"
        Me.ReviewButton.Size = New System.Drawing.Size(112, 42)
        Me.ReviewButton.TabIndex = 1
        Me.ReviewButton.Text = "&Review"
        Me.ToolTip1.SetToolTip(Me.ReviewButton, "click to open review mode")
        Me.ReviewButton.UseVisualStyleBackColor = False
        '
        'StartRoundButton
        '
        Me.StartRoundButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.StartRoundButton.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.StartRoundButton.Location = New System.Drawing.Point(546, 644)
        Me.StartRoundButton.Name = "StartRoundButton"
        Me.StartRoundButton.Size = New System.Drawing.Size(112, 42)
        Me.StartRoundButton.TabIndex = 2
        Me.StartRoundButton.Text = "Start& Round"
        Me.ToolTip1.SetToolTip(Me.StartRoundButton, "Click to start the next round")
        Me.StartRoundButton.UseVisualStyleBackColor = False
        '
        'ExitButton
        '
        Me.ExitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExitButton.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ExitButton.Location = New System.Drawing.Point(1080, 644)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(112, 42)
        Me.ExitButton.TabIndex = 3
        Me.ExitButton.Text = "E&xit"
        Me.ToolTip1.SetToolTip(Me.ExitButton, "click to exit the simulator")
        Me.ExitButton.UseVisualStyleBackColor = False
        '
        'RoundLabel
        '
        Me.RoundLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.RoundLabel.AutoSize = True
        Me.RoundLabel.Location = New System.Drawing.Point(693, 644)
        Me.RoundLabel.Name = "RoundLabel"
        Me.RoundLabel.Size = New System.Drawing.Size(53, 16)
        Me.RoundLabel.TabIndex = 4
        Me.RoundLabel.Text = "Round: "
        '
        'DartCountLabel
        '
        Me.DartCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.DartCountLabel.AutoSize = True
        Me.DartCountLabel.Location = New System.Drawing.Point(693, 670)
        Me.DartCountLabel.Name = "DartCountLabel"
        Me.DartCountLabel.Size = New System.Drawing.Size(89, 16)
        Me.DartCountLabel.TabIndex = 5
        Me.DartCountLabel.Text = "Darts Thrown:"
        '
        'DartGameSim
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1204, 698)
        Me.Controls.Add(Me.DartCountLabel)
        Me.Controls.Add(Me.RoundLabel)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.StartRoundButton)
        Me.Controls.Add(Me.ReviewButton)
        Me.Controls.Add(Me.DartBoardPictureBox)
        Me.Name = "DartGameSim"
        Me.Text = "DartGameSim"
        CType(Me.DartBoardPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DartBoardPictureBox As PictureBox
    Friend WithEvents ReviewButton As Button
    Friend WithEvents StartRoundButton As Button
    Friend WithEvents ExitButton As Button
    Friend WithEvents RoundLabel As Label
    Friend WithEvents DartCountLabel As Label
    Friend WithEvents ToolTip1 As ToolTip
End Class
