<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReviewForm
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
        Me.ReviewFormPictureBox = New System.Windows.Forms.PictureBox()
        Me.ReviewFormListBox = New System.Windows.Forms.ListBox()
        Me.ExitReviewButton = New System.Windows.Forms.Button()
        Me.ProcessReviewButton = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.ReviewFormPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReviewFormPictureBox
        '
        Me.ReviewFormPictureBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReviewFormPictureBox.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ReviewFormPictureBox.Location = New System.Drawing.Point(12, 12)
        Me.ReviewFormPictureBox.Name = "ReviewFormPictureBox"
        Me.ReviewFormPictureBox.Size = New System.Drawing.Size(1180, 607)
        Me.ReviewFormPictureBox.TabIndex = 0
        Me.ReviewFormPictureBox.TabStop = False
        Me.ToolTip1.SetToolTip(Me.ReviewFormPictureBox, "Will show darts from round selected in list box")
        '
        'ReviewFormListBox
        '
        Me.ReviewFormListBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReviewFormListBox.FormattingEnabled = True
        Me.ReviewFormListBox.ItemHeight = 16
        Me.ReviewFormListBox.Location = New System.Drawing.Point(12, 627)
        Me.ReviewFormListBox.Name = "ReviewFormListBox"
        Me.ReviewFormListBox.Size = New System.Drawing.Size(891, 68)
        Me.ReviewFormListBox.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.ReviewFormListBox, "Click on round to display darts")
        '
        'ExitReviewButton
        '
        Me.ExitReviewButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExitReviewButton.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ExitReviewButton.Location = New System.Drawing.Point(1071, 646)
        Me.ExitReviewButton.Name = "ExitReviewButton"
        Me.ExitReviewButton.Size = New System.Drawing.Size(121, 49)
        Me.ExitReviewButton.TabIndex = 2
        Me.ExitReviewButton.Text = "E&xit Review"
        Me.ToolTip1.SetToolTip(Me.ExitReviewButton, "click to exit review mode")
        Me.ExitReviewButton.UseVisualStyleBackColor = False
        '
        'ProcessReviewButton
        '
        Me.ProcessReviewButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProcessReviewButton.Location = New System.Drawing.Point(944, 648)
        Me.ProcessReviewButton.Name = "ProcessReviewButton"
        Me.ProcessReviewButton.Size = New System.Drawing.Size(121, 47)
        Me.ProcessReviewButton.TabIndex = 3
        Me.ProcessReviewButton.Text = "&Process Review"
        Me.ToolTip1.SetToolTip(Me.ProcessReviewButton, "Click to process review of all previous rounds")
        Me.ProcessReviewButton.UseVisualStyleBackColor = True
        '
        'ReviewForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1208, 707)
        Me.Controls.Add(Me.ProcessReviewButton)
        Me.Controls.Add(Me.ExitReviewButton)
        Me.Controls.Add(Me.ReviewFormListBox)
        Me.Controls.Add(Me.ReviewFormPictureBox)
        Me.Name = "ReviewForm"
        Me.Text = "ReviewForm"
        CType(Me.ReviewFormPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReviewFormPictureBox As PictureBox
    Friend WithEvents ReviewFormListBox As ListBox
    Friend WithEvents ExitReviewButton As Button
    Friend WithEvents ProcessReviewButton As Button
    Friend WithEvents ToolTip1 As ToolTip
End Class
