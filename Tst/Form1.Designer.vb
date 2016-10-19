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
        Me.SuspendLayout()
        '
        'Ticker
        '
        Me.Ticker.Interval = 1
        '
        'Canvas
        '
        Me.Canvas.Location = New System.Drawing.Point(16, 15)
        Me.Canvas.Margin = New System.Windows.Forms.Padding(4)
        Me.Canvas.Name = "Canvas"
        Me.Canvas.Size = New System.Drawing.Size(635, 503)
        Me.Canvas.TabIndex = 0
        '
        'Score
        '
        Me.Score.AutoSize = True
        Me.Score.Location = New System.Drawing.Point(659, 15)
        Me.Score.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Score.Name = "Score"
        Me.Score.Size = New System.Drawing.Size(65, 17)
        Me.Score.TabIndex = 1
        Me.Score.Text = "Poeng: 0"
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(663, 490)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 28)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Reset"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 534)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Score)
        Me.Controls.Add(Me.Canvas)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Ticker As Timer
    Friend WithEvents Canvas As Panel
    Friend WithEvents Score As Label
    Friend WithEvents Button1 As Button
End Class
