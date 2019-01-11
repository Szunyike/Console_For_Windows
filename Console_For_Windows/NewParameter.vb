Imports Szunyi.Common.Extensions
Public Class NewParameter
    Public Parameter As Parameter
    Private _SubProgram As SubProgram
    Dim cIncompatibleParamters As New List(Of String)

    Private Sub NewParameter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.cbParameterType.Items.AddRange(Szunyi.Common.Util_Helpers.Get_All_Enum_Names(Of Console_For_Windows.ParameterType)(Nothing).ToArray)

    End Sub

    Private Sub cbParameterType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbParameterType.SelectedIndexChanged
        Dim ex = Szunyi.IO.Util_Helpers.Get_Enum_Value(Of Console_For_Windows.ParameterType)(cbParameterType.Text)
        Select Case ex
            Case Console_For_Windows.ParameterType.string
                Me.TabControl1.SelectedIndex = 0
            Case Console_For_Windows.ParameterType.strings

            Case Console_For_Windows.ParameterType.File

            Case Console_For_Windows.ParameterType.Files

            Case Console_For_Windows.ParameterType.Selection
                Me.TabControl1.SelectedIndex = 1
            Case Else
                Me.TabControl1.SelectedIndex = 2

        End Select
    End Sub

    Private Sub Save(sender As Object, e As EventArgs) Handles Button1.Click
        ' Validate
        Dim pa As New Parameter
        Dim ex = Szunyi.IO.Util_Helpers.Get_Enum_Value(Of Console_For_Windows.ParameterType)(cbParameterType.Text)
        pa.Type = ex
        pa.Description = New Basic_Description With {.Description = tbDescription.Text, .Name = tbProgramName.Text}
        pa.Symbol = tbSymbol.Text
        pa.IncompatibleParameters = cIncompatibleParamters
        pa.IsEssentialParamater = chEssentialParamter.Checked
        Select Case ex
            Case Console_For_Windows.ParameterType.string
                pa.DefaultValue = tbSimpleText.Text
            Case Console_For_Windows.ParameterType.strings
                pa.AcceptableValues = Split(tbSelection.Text, vbCrLf).ToList
                pa.DefaultValue = pa.AcceptableValues.First
            Case Console_For_Windows.ParameterType.File

            Case Console_For_Windows.ParameterType.Files

            Case Console_For_Windows.ParameterType.Selection

                pa.DefaultValue = pa.AcceptableValues.First

                'Numbers Are COming

            Case ParameterType.Integer
                If tbMin.Text = "" Then
                    pa.MinValue = Int64.MinValue
                Else
                    Try
                        pa.MinValue = Convert.ToInt64(tbMin.Text)
                    Catch ex1 As Exception
                        MsgBox("Error in Minimum Value")
                        Exit Sub
                    End Try

                End If
                If tbMax.Text = "" Then
                    pa.MaxValue = Int64.MaxValue
                Else
                    Try
                        pa.MaxValue = Convert.ToInt64(tbMax.Text)
                    Catch ex1 As Exception
                        MsgBox("Error in Minimum Value")
                        Exit Sub
                    End Try
                End If
                If tbDef.Text = "" Then
                    pa.DefaultValue = tbDef.Text
                Else
                    Try
                        pa.DefaultValue = Convert.ToUInt64(tbDef.Text)
                    Catch ex1 As Exception
                        MsgBox("Error in Default Value")
                        Exit Sub
                    End Try
                End If

            Case ParameterType.Double
                If tbMin.Text = "" Then
                    pa.MinValue = Double.MinValue
                Else
                    Try
                        pa.MinValue = Convert.ToDouble(tbMin.Text)
                    Catch ex1 As Exception
                        MsgBox("Error in Minimum Value")
                        Exit Sub
                    End Try

                End If
                If tbMax.Text = "" Then
                    pa.MaxValue = Double.MaxValue
                Else
                    Try
                        pa.MaxValue = Convert.ToDouble(tbMax.Text)
                    Catch ex1 As Exception
                        MsgBox("Error in Minimum Value")
                        Exit Sub
                    End Try
                End If
                If tbDef.Text = "" Then
                    pa.DefaultValue = tbDef.Text
                Else
                    Try
                        pa.DefaultValue = Convert.ToDouble(tbDef.Text)
                    Catch ex1 As Exception
                        MsgBox("Error in Default Value")
                        Exit Sub
                    End Try
                End If

        End Select

        Me.Parameter = pa
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(sP As SubProgram)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _SubProgram = sP

    End Sub
    ''' <summary>
    ''' For Edit
    ''' </summary>
    ''' <param name="sP"></param>
    ''' <param name="P"></param>
    Public Sub New(sP As SubProgram, P As Parameter)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _SubProgram = sP
        Me.Parameter = P
        Me.tbDef.Text = P.Description.Description
        Me.tbIncompatibleParameters.Text = P.Description.KeyWords.GetText(";")
        Me.tbProgramName.Text = P.Description.Name
        Me.tbSymbol.Text = P.Symbol
        Dim t = Szunyi.Common.Util_Helpers.Get_Enum_Name(Of ParameterType)(P.Type)
        cbParameterType.Items.AddRange(Szunyi.Common.Util_Helpers.Get_All_Enum_Names(Of ParameterType)(Nothing).ToArray)
        cbParameterType.SelectedIndex = cbParameterType.FindStringExact(t)
        tbDescription.Text = P.Description.Description
        tbMin.Text = P.MinValue
        tbMax.Text = P.MaxValue
        tbDef.Text = P.DefaultValue
        tbIncompatibleParameters.Text = P.KeyWords.GetText(",")
        chEssentialParamter.Checked = P.IsEssentialParamater
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cbIncompatibleParamters_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbIncompatibleParamters.Validating
        If cIncompatibleParamters.HasContain(cbIncompatibleParamters.Text) = False Then
            cIncompatibleParamters.Add(cbIncompatibleParamters.Text)
            cbIncompatibleParamters.Text = String.Empty
            tbIncompatibleParameters.Text = cIncompatibleParamters.GetText(";")
        End If
    End Sub

End Class