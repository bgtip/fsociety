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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SoundTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Ticker
        '
        Me.Ticker.Interval = 1
        '
        'Canvas
        '
        Me.Canvas.Location = New System.Drawing.Point(12, 12)
        Me.Canvas.Name = "Canvas"
        Me.Canvas.Size = New System.Drawing.Size(476, 409)
        Me.Canvas.TabIndex = 0
        '
        'Score
        '
        Me.Score.AutoSize = True
        Me.Score.Location = New System.Drawing.Point(494, 12)
        Me.Score.Name = "Score"
        Me.Score.Size = New System.Drawing.Size(50, 13)
        Me.Score.TabIndex = 1
        Me.Score.Text = "Poeng: 0"
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(497, 398)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Reset"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'SoundTimer
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(586, 434)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Score)
        Me.Controls.Add(Me.Canvas)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Ticker As Timer
    Friend WithEvents Canvas As Panel
    Friend WithEvents Score As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents SoundTimer As Timer
End Class
