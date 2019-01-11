<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewParameter
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
        Me.cbParameterType = New System.Windows.Forms.ComboBox()
        Me.tbProgramName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.tbSimpleText = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.tbSelection = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.tbDef = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbMax = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbMin = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbIncompatibleParameters = New System.Windows.Forms.TextBox()
        Me.cbIncompatibleParamters = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chEssentialParamter = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.tbSymbol = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbDescription = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbParameterType
        '
        Me.cbParameterType.FormattingEnabled = True
        Me.cbParameterType.Location = New System.Drawing.Point(206, 175)
        Me.cbParameterType.Name = "cbParameterType"
        Me.cbParameterType.Size = New System.Drawing.Size(121, 21)
        Me.cbParameterType.TabIndex = 0
        '
        'tbProgramName
        '
        Me.tbProgramName.Location = New System.Drawing.Point(206, 34)
        Me.tbProgramName.Name = "tbProgramName"
        Me.tbProgramName.Size = New System.Drawing.Size(390, 20)
        Me.tbProgramName.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Parameter Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(48, 183)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Parameter Type"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TabControl1.Location = New System.Drawing.Point(0, 451)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(943, 224)
        Me.TabControl1.TabIndex = 17
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.tbSimpleText)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(935, 244)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Free Text"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'tbSimpleText
        '
        Me.tbSimpleText.Location = New System.Drawing.Point(184, 42)
        Me.tbSimpleText.Name = "tbSimpleText"
        Me.tbSimpleText.Size = New System.Drawing.Size(390, 20)
        Me.tbSimpleText.TabIndex = 21
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(26, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Free Text"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.tbSelection)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(935, 244)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "String Selection"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'tbSelection
        '
        Me.tbSelection.Dock = System.Windows.Forms.DockStyle.Left
        Me.tbSelection.Location = New System.Drawing.Point(3, 3)
        Me.tbSelection.Multiline = True
        Me.tbSelection.Name = "tbSelection"
        Me.tbSelection.Size = New System.Drawing.Size(213, 238)
        Me.tbSelection.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.tbDef)
        Me.TabPage3.Controls.Add(Me.Label5)
        Me.TabPage3.Controls.Add(Me.tbMax)
        Me.TabPage3.Controls.Add(Me.Label4)
        Me.TabPage3.Controls.Add(Me.tbMin)
        Me.TabPage3.Controls.Add(Me.Label3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(935, 198)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Number"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'tbDef
        '
        Me.tbDef.Location = New System.Drawing.Point(184, 122)
        Me.tbDef.Name = "tbDef"
        Me.tbDef.Size = New System.Drawing.Size(390, 20)
        Me.tbDef.TabIndex = 23
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Default Value"
        '
        'tbMax
        '
        Me.tbMax.Location = New System.Drawing.Point(181, 77)
        Me.tbMax.Name = "tbMax"
        Me.tbMax.Size = New System.Drawing.Size(390, 20)
        Me.tbMax.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Maximum Value"
        '
        'tbMin
        '
        Me.tbMin.Location = New System.Drawing.Point(181, 32)
        Me.tbMin.Name = "tbMin"
        Me.tbMin.Size = New System.Drawing.Size(390, 20)
        Me.tbMin.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Minimum Value"
        '
        'tbIncompatibleParameters
        '
        Me.tbIncompatibleParameters.Location = New System.Drawing.Point(206, 262)
        Me.tbIncompatibleParameters.Multiline = True
        Me.tbIncompatibleParameters.Name = "tbIncompatibleParameters"
        Me.tbIncompatibleParameters.Size = New System.Drawing.Size(539, 76)
        Me.tbIncompatibleParameters.TabIndex = 25
        '
        'cbIncompatibleParamters
        '
        Me.cbIncompatibleParamters.FormattingEnabled = True
        Me.cbIncompatibleParamters.Location = New System.Drawing.Point(206, 218)
        Me.cbIncompatibleParamters.Name = "cbIncompatibleParamters"
        Me.cbIncompatibleParamters.Size = New System.Drawing.Size(302, 21)
        Me.cbIncompatibleParamters.TabIndex = 24
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(48, 226)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(126, 13)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Incompatible Paramteres:"
        '
        'chEssentialParamter
        '
        Me.chEssentialParamter.AutoSize = True
        Me.chEssentialParamter.Location = New System.Drawing.Point(206, 361)
        Me.chEssentialParamter.Name = "chEssentialParamter"
        Me.chEssentialParamter.Size = New System.Drawing.Size(136, 17)
        Me.chEssentialParamter.TabIndex = 26
        Me.chEssentialParamter.Text = "Is Essential Parameter?"
        Me.chEssentialParamter.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(206, 398)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 27
        Me.Button1.Text = "Ok"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(330, 398)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 28
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'tbSymbol
        '
        Me.tbSymbol.Location = New System.Drawing.Point(206, 74)
        Me.tbSymbol.Name = "tbSymbol"
        Me.tbSymbol.Size = New System.Drawing.Size(390, 20)
        Me.tbSymbol.TabIndex = 30
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(48, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Symbol:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(48, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 13)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Description"
        '
        'tbDescription
        '
        Me.tbDescription.ForeColor = System.Drawing.Color.Turquoise
        Me.tbDescription.Location = New System.Drawing.Point(206, 100)
        Me.tbDescription.Multiline = True
        Me.tbDescription.Name = "tbDescription"
        Me.tbDescription.Size = New System.Drawing.Size(539, 59)
        Me.tbDescription.TabIndex = 32
        '
        'NewParameter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(943, 675)
        Me.Controls.Add(Me.tbDescription)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tbSymbol)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.chEssentialParamter)
        Me.Controls.Add(Me.tbIncompatibleParameters)
        Me.Controls.Add(Me.cbIncompatibleParamters)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbProgramName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbParameterType)
        Me.Name = "NewParameter"
        Me.Text = "NewParameter"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbParameterType As ComboBox
    Friend WithEvents tbProgramName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents tbSimpleText As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents tbDef As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents tbMax As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents tbMin As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbSelection As TextBox
    Friend WithEvents tbIncompatibleParameters As TextBox
    Friend WithEvents cbIncompatibleParamters As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents chEssentialParamter As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents tbSymbol As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents tbDescription As TextBox
End Class
