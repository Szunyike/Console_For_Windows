<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NewProgram
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
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cbProgramType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbLocation = New System.Windows.Forms.TextBox()
        Me.Bd1 = New Console_For_Windows.BD()
        Me.SuspendLayout()
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
        'cbProgramType
        '
        Me.cbProgramType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbProgramType.FormattingEnabled = True
        Me.cbProgramType.Location = New System.Drawing.Point(198, 30)
        Me.cbProgramType.Name = "cbProgramType"
        Me.cbProgramType.Size = New System.Drawing.Size(302, 21)
        Me.cbProgramType.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Program Type:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(66, 425)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Location"
        '
        'tbLocation
        '
        Me.tbLocation.Location = New System.Drawing.Point(198, 418)
        Me.tbLocation.Name = "tbLocation"
        Me.tbLocation.Size = New System.Drawing.Size(539, 20)
        Me.tbLocation.TabIndex = 24
        '
        'Bd1
        '
        Me.Bd1.Location = New System.Drawing.Point(0, 57)
        Me.Bd1.Name = "Bd1"
        Me.Bd1.Size = New System.Drawing.Size(782, 337)
        Me.Bd1.TabIndex = 27
        '
        'NewProgram
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1807, 598)
        Me.Controls.Add(Me.Bd1)
        Me.Controls.Add(Me.tbLocation)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cbProgramType)
        Me.Controls.Add(Me.Label2)
        Me.Name = "NewProgram"
        Me.Text = "NewProgram"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents cbProgramType As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents tbLocation As TextBox
    Friend WithEvents Bd1 As BD
End Class
