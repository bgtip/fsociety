<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Ticker = New System.Windows.Forms.Timer(Me.components)
        Me.Canvas = New System.Windows.Forms.Panel()
        Me.Score = New System.Windows.Forms.Label()
        Me.SoundTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Ticker
        '
        Me.Ticker.Interval = 1
        '
        'Canvas
        '
        Me.Canvas.Location = New System.Drawing.Point(100, 79)
        Me.Canvas.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Canvas.Name = "Canvas"
        Me.Canvas.Size = New System.Drawing.Size(533, 492)
        Me.Canvas.TabIndex = 0
        '
        'Score
        '
        Me.Score.AutoSize = True
        Me.Score.BackColor = System.Drawing.Color.Transparent
        Me.Score.ForeColor = System.Drawing.Color.White
        Me.Score.Location = New System.Drawing.Point(688, 79)
        Me.Score.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Score.Name = "Score"
        Me.Score.Size = New System.Drawing.Size(65, 17)
        Me.Score.TabIndex = 1
        Me.Score.Text = "Poeng: 0"
        '
        'SoundTimer
        '
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Enabled = False
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.Transparent
        Me.Button1.Location = New System.Drawing.Point(691, 535)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(125, 36)
        Me.Button1.TabIndex = 2
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.Enabled = False
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(691, 464)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(153, 41)
        Me.Button2.TabIndex = 3
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Tst.My.Resources.Resources.formOne2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1016, 647)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Score)
        Me.Controls.Add(Me.Canvas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1038, 698)
        Me.MinimumSize = New System.Drawing.Size(1038, 698)
        Me.Name = "Form1"
        Me.Text = "fsociety27.dat - game"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Ticker As Timer
    Friend WithEvents Canvas As Panel
    Friend WithEvents Score As Label
    Friend WithEvents SoundTimer As Timer
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
