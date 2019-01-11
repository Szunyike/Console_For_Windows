<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewProgram
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
        Me.tbKeyWords = New System.Windows.Forms.TextBox()
        Me.cbKeyWords = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbDescription = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbProgramType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbProgramName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbLocation = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'tbKeyWords
        '
        Me.tbKeyWords.Location = New System.Drawing.Point(210, 286)
        Me.tbKeyWords.Multiline = True
        Me.tbKeyWords.Name = "tbKeyWords"
        Me.tbKeyWords.Size = New System.Drawing.Size(539, 76)
        Me.tbKeyWords.TabIndex = 22
        '
        'cbKeyWords
        '
        Me.cbKeyWords.FormattingEnabled = True
        Me.cbKeyWords.Location = New System.Drawing.Point(210, 239)
        Me.cbKeyWords.Name = "cbKeyWords"
        Me.cbKeyWords.Size = New System.Drawing.Size(302, 21)
        Me.cbKeyWords.TabIndex = 21
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(352, 480)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(214, 480)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "Ok"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(56, 242)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "KeyWords:"
        '
        'tbDescription
        '
        Me.tbDescription.Location = New System.Drawing.Point(214, 153)
        Me.tbDescription.Multiline = True
        Me.tbDescription.Name = "tbDescription"
        Me.tbDescription.Size = New System.Drawing.Size(535, 53)
        Me.tbDescription.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(56, 172)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Descriptiom:"
        '
        'cbProgramType
        '
        Me.cbProgramType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbProgramType.FormattingEnabled = True
        Me.cbProgramType.Location = New System.Drawing.Point(210, 89)
        Me.cbProgramType.Name = "cbProgramType"
        Me.cbProgramType.Size = New System.Drawing.Size(302, 21)
        Me.cbProgramType.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(56, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Program Type:"
        '
        'tbProgramName
        '
        Me.tbProgramName.Location = New System.Drawing.Point(210, 32)
        Me.tbProgramName.Name = "tbProgramName"
        Me.tbProgramName.Size = New System.Drawing.Size(390, 20)
        Me.tbProgramName.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(52, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Program Name:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(62, 400)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Location"
        '
        'tbLocation
        '
        Me.tbLocation.Enabled = False
        Me.tbLocation.Location = New System.Drawing.Point(210, 397)
        Me.tbLocation.Name = "tbLocation"
        Me.tbLocation.Size = New System.Drawing.Size(539, 20)
        Me.tbLocation.TabIndex = 24
        '
        'NewProgram
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 598)
        Me.Controls.Add(Me.tbLocation)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbKeyWords)
        Me.Controls.Add(Me.cbKeyWords)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tbDescription)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbProgramType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbProgramName)
        Me.Controls.Add(Me.Label1)
        Me.Name = "NewProgram"
        Me.Text = "NewProgram"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbKeyWords As TextBox
    Friend WithEvents cbKeyWords As ComboBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents tbDescription As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cbProgramType As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tbProgramName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents tbLocation As TextBox
End Class
