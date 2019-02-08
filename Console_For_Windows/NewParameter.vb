Imports Szunyi.Common.Extensions
Imports Szunyi.Common.Util_Helpers

Public Class NewParameter
    Public Property Parameter As Parameter
    Public Property P As Program
    Public Property SP As SubProgram

    Dim ParamterNames() As String
    Dim cIncompatibleParamters As New List(Of String)
    Dim cMustParamters As New List(Of String)
#Region "New"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(sP As SubProgram)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.SP = sP
        Me.Parameter = New Parameter
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
        Me.SP = sP
        Me.Parameter = P
    End Sub
    Private Sub NewParameter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim t = Szunyi.Common.Util_Helpers.Get_Enum_Name(Of Console_For_Windows.ParameterType)(Parameter.Type)
        Me.cbParameterType.Items.AddRange(Szunyi.Common.Util_Helpers.Get_All_Enum_Names(Of Console_For_Windows.ParameterType)(Nothing).ToArray)

        tbIncompatibleParameters.Text = Parameter.Incompatible_Parameters.GetText(",")

        ParamterNames = (From x In SP.Parameters Select x.Description.Name).ToArray
        cbIncompatibleParamters.Items.AddRange(ParamterNames)
        cbMust.Items.AddRange(ParamterNames)

        Dim cType1 = Szunyi.Common.Util_Helpers.Get_Enum_Name(Of Console_For_Windows.ParameterType)(Parameter.Type)
        cbParameterType.SelectedText = cType1
        tbDef.DataBindings.Add("Text", Parameter, "Default_Value")
        tbMax.DataBindings.Add("Text", Parameter, "MaxValue")
        tbMin.DataBindings.Add("Text", Parameter, "MinValue")
        tbSimpleText.DataBindings.Add("Text", Parameter, "Default_Value")

        tbSeparator.DataBindings.Add("Text", Parameter, "Separator")
        tbSeparator2.DataBindings.Add("Text", Parameter, "Separator")

        tbNofItem.DataBindings.Add("Text", Parameter, "Nof_Item")
        tbFileFIlter.DataBindings.Add("Text", Parameter, "File_Filter")
        tbFileRename.DataBindings.Add("Text", Parameter, "File_Name_Append")

        chEssentialParamter.DataBindings.Add("Checked", Parameter, "Is_Essential_Paramater")

        tbmust.Text = Parameter.Must_Parameters.GetText(";")
        tbIncompatibleParameters.Text = Parameter.Incompatible_Parameters.GetText(";")

        tbSelection.Text = Parameter.Acceptable_Values.GetText(vbCrLf)
        Me.Bd1.Set_BD(Me.Parameter.Description)
    End Sub
#End Region


    Private Sub cbParameterType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbParameterType.SelectedIndexChanged

    End Sub
    Private Sub SetTabControl(Index As Integer)
        For i1 = 0 To Me.TabControl1.TabPages.Count - 1
            If i1 = Index Then
                TabControl1.SelectedIndex = Index
                TabControl1.TabPages(Index).Enabled = True
            Else
                TabControl1.TabPages(i1).Enabled = False
            End If
        Next
    End Sub
    Private Sub Save(sender As Object, e As EventArgs) Handles Button1.Click
        ' Validate

        If cbParameterType.Text = "" Then
            MsgBox("Set Parameter Type")
            Exit Sub
        End If
        Dim ex = Szunyi.Common.Util_Helpers.Get_Enum_Value(Of ParameterType)(cbParameterType.Text)

        Me.Parameter.Incompatible_Parameters = Split(tbIncompatibleParameters.Text, ";").RemoveEmpty

        Me.Parameter.Must_Parameters = Split(tbmust.Text, ";").RemoveEmpty
        Select Case ex
            Case Console_For_Windows.ParameterType.Selection
                Me.Parameter.Acceptable_Values = Split(tbSelection.Text, vbCrLf).ToList
                Me.Parameter.Default_Value = Me.Parameter.Acceptable_Values.First

            Case ParameterType.Integer
                If tbMin.Text = "" Then
                    Me.Parameter.MinValue = Int64.MinValue
                Else
                    Try
                        Me.Parameter.MinValue = Convert.ToInt64(tbMin.Text)
                    Catch ex1 As Exception
                        MsgBox("Error in Minimum Value")
                        Exit Sub
                    End Try

                End If
                If tbMax.Text = "" Then

                    Me.Parameter.MaxValue = Int64.MaxValue
                Else
                    Try
                        Me.Parameter.MaxValue = Convert.ToInt64(tbMax.Text)
                    Catch ex1 As Exception
                        MsgBox("Error in Minimum Value")
                        Exit Sub
                    End Try
                End If
                If tbDef.Text = "" Then
                    Me.Parameter.Default_Value = tbDef.Text
                Else
                    Try
                        Me.Parameter.Default_Value = Convert.ToUInt64(tbDef.Text)
                    Catch ex1 As Exception
                        MsgBox("Error in Default Value")
                        Exit Sub
                    End Try
                End If

            Case ParameterType.Double
                If tbMin.Text = "" Then
                    Me.Parameter.MinValue = Double.MinValue
                Else
                    Try
                        Me.Parameter.MinValue = Convert.ToDouble(tbMin.Text)
                    Catch ex1 As Exception
                        MsgBox("Error in Minimum Value")
                        Exit Sub
                    End Try

                End If
                If tbMax.Text = "" Then
                    Me.Parameter.MaxValue = Double.MaxValue
                Else
                    Try
                        Me.Parameter.MaxValue = Convert.ToDouble(tbMax.Text)
                    Catch ex1 As Exception
                        MsgBox("Error in Minimum Value")
                        Exit Sub
                    End Try
                End If
                If tbDef.Text = "" Then
                    Me.Parameter.Default_Value = tbDef.Text
                Else
                    Try
                        Me.Parameter.Default_Value = Convert.ToDouble(tbDef.Text)
                    Catch ex1 As Exception
                        MsgBox("Error in Default Value")
                        Exit Sub
                    End Try
                End If

        End Select


        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub cbParameterType_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbParameterType.SelectedValueChanged
        Dim ex = Szunyi.IO.Util_Helpers.Get_Enum_Value(Of Console_For_Windows.ParameterType)(cbParameterType.Text)
        Parameter.Type = ex
        Select Case ex
            Case Console_For_Windows.ParameterType.string
                SetTabControl(0)

            Case Console_For_Windows.ParameterType.Selection
                SetTabControl(1)
            Case Console_For_Windows.ParameterType.List_Of_Integer
                SetTabControl(3)
            Case Console_For_Windows.ParameterType.List_Of_Double
                SetTabControl(3)
            Case Console_For_Windows.ParameterType.Constant_File
                Dim f = Szunyi.IO.Pick_Up.File
                If IsNothing(f) = False Then tbSimpleText.Text = f.FullName
                SetTabControl(0)
            Case Console_For_Windows.ParameterType.File
                Dim c = Szunyi.Common.Util_Helpers.Get_Constant_Values(GetType(Szunyi.IO.File_Extensions))
                Dim s As New Szunyi.IO.CheckBoxForStringsFull(c, 1, "", "")
                If s.ShowDialog = DialogResult.OK Then
                    Parameter.File_Filter = s.SelectedStrings.First
                End If
            Case Console_For_Windows.ParameterType.Files
                Dim c = Szunyi.Common.Util_Helpers.Get_Constant_Values(GetType(Szunyi.IO.File_Extensions))
                Dim s As New Szunyi.IO.CheckBoxForStringsFull(c, 1, "", "")
                If s.ShowDialog = DialogResult.OK Then
                    Parameter.File_Filter = s.SelectedStrings.First
                End If
                SetTabControl(4)
            Case Console_For_Windows.ParameterType.File_Rename
                SetTabControl(4)
            Case Else
                SetTabControl(2)

        End Select
    End Sub
    Private Sub Set_Must()
        If cbMust.SelectedIndex > -1 Then
            Dim txt As String = cbMust.Items((cbMust.SelectedIndex).ToString)
            If cMustParamters.HasContain(txt) = False Then
                cMustParamters.Add(cbMust.Text)
                cbMust.Text = String.Empty
                tbmust.Text = cMustParamters.GetText(";")

            End If
        Else
            If cbMust.Text <> String.Empty Then
                If cMustParamters.HasContain(cbMust.Text) = False Then
                    cMustParamters.Add(cbMust.Text)
                    cbMust.Text = String.Empty
                    tbmust.Text = cMustParamters.GetText(";")

                End If
            End If
        End If
    End Sub
    Private Sub cbMust_KeyUp(sender As Object, e As KeyEventArgs) Handles cbMust.KeyUp
        If e.KeyCode = Keys.Enter Then
            Set_Must()
        End If
    End Sub
    Private Sub cbMust_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMust.SelectedIndexChanged
        Set_Must()
    End Sub

    Private Sub cbIncompatibleParamters_KeyUp(sender As Object, e As KeyEventArgs) Handles cbIncompatibleParamters.KeyUp
        If e.KeyCode = Keys.Enter Then
            Set_Incompatible()
        End If
    End Sub
    Private Sub Set_Incompatible()
        If cbIncompatibleParamters.SelectedIndex > -1 Then
            Dim txt As String = cbIncompatibleParamters.Items((cbIncompatibleParamters.SelectedIndex).ToString)
            If cIncompatibleParamters.HasContain(txt) = False Then
                cIncompatibleParamters.Add(cbIncompatibleParamters.Text)
                cbIncompatibleParamters.Text = String.Empty
                tbIncompatibleParameters.Text = cIncompatibleParamters.GetText(";")

            End If
        Else
            If cbIncompatibleParamters.Text <> String.Empty Then
                If cIncompatibleParamters.HasContain(cbIncompatibleParamters.Text) = False Then
                    cIncompatibleParamters.Add(cbIncompatibleParamters.Text)
                    cbIncompatibleParamters.Text = String.Empty
                    tbIncompatibleParameters.Text = cIncompatibleParamters.GetText(";")

                End If
            End If
        End If
    End Sub

    Private Sub cbIncompatibleParamters_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbIncompatibleParamters.Validating

        Set_Incompatible()
    End Sub

End Class