<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BD
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.tbDescription = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbSymbol = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbProgramName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbKeyWords = New System.Windows.Forms.TextBox()
        Me.cbKeyWords = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'tbDescription
        '
        Me.tbDescription.ForeColor = System.Drawing.Color.Turquoise
        Me.tbDescription.Location = New System.Drawing.Point(195, 123)
        Me.tbDescription.Multiline = True
        Me.tbDescription.Name = "tbDescription"
        Me.tbDescription.Size = New System.Drawing.Size(539, 59)
        Me.tbDescription.TabIndex = 38
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(37, 135)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 13)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "Description"
        '
        'tbSymbol
        '
        Me.tbSymbol.Location = New System.Drawing.Point(195, 82)
        Me.tbSymbol.Name = "tbSymbol"
        Me.tbSymbol.Size = New System.Drawing.Size(390, 20)
        Me.tbSymbol.TabIndex = 36
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(37, 82)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Symbol:"
        '
        'tbProgramName
        '
        Me.tbProgramName.Location = New System.Drawing.Point(195, 42)
        Me.tbProgramName.Name = "tbProgramName"
        Me.tbProgramName.Size = New System.Drawing.Size(390, 20)
        Me.tbProgramName.TabIndex = 34
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Name:"
        '
        'tbKeyWords
        '
        Me.tbKeyWords.Enabled = False
        Me.tbKeyWords.Location = New System.Drawing.Point(195, 250)
        Me.tbKeyWords.Multiline = True
        Me.tbKeyWords.Name = "tbKeyWords"
        Me.tbKeyWords.Size = New System.Drawing.Size(539, 76)
        Me.tbKeyWords.TabIndex = 41
        '
        'cbKeyWords
        '
        Me.cbKeyWords.FormattingEnabled = True
        Me.cbKeyWords.Location = New System.Drawing.Point(195, 203)
        Me.cbKeyWords.Name = "cbKeyWords"
        Me.cbKeyWords.Size = New System.Drawing.Size(302, 21)
        Me.cbKeyWords.TabIndex = 40
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(41, 206)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "KeyWords:"
        '
        'BD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tbKeyWords)
        Me.Controls.Add(Me.cbKeyWords)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tbDescription)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tbSymbol)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tbProgramName)
        Me.Controls.Add(Me.Label1)
        Me.Name = "BD"
        Me.Size = New System.Drawing.Size(782, 446)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbDescription As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents tbSymbol As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents tbProgramName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tbKeyWords As TextBox
    Friend WithEvents cbKeyWords As ComboBox
    Friend WithEvents Label4 As Label
End Class
