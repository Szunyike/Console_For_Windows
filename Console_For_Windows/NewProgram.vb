Imports System.ComponentModel
Imports Szunyi.Common.Extensions
Public Class NewProgram
    Public Property H As Hierarchy
    Public Property P As Program
    Public Property SP As SubProgram
    Public Property cKeyWords As New List(Of String)
    Public Property cProgram As Program
    Public Property Type As Type
    Private Sub Programs1_Load(sender As Object, e As EventArgs)

    End Sub
    Private Sub SetIt()

    End Sub


    Public Sub New(h As Hierarchy, type As Type)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.H = h
        Me.cbProgramType.Items.AddRange(Szunyi.Common.Util_Helpers.Get_All_Enum_Names(Of Console_For_Windows.ProgramType)(Nothing).ToArray)
        Me.cbKeyWords.Items.AddRange(h.Get_All_KeyWords.ToArray)
        Me.Type = type
    End Sub
    Public Sub New(h As Hierarchy, P As Program, type As Type)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Type = type
        Me.H = h
        Me.cbProgramType.Items.AddRange(Szunyi.Common.Util_Helpers.Get_All_Enum_Names(Of Console_For_Windows.ProgramType)(Nothing).ToArray)
        Dim t = Szunyi.Common.Util_Helpers.Get_Enum_Name(Of Console_For_Windows.ProgramType)(P.Type)
        cbProgramType.SelectedIndex = cbProgramType.FindStringExact(t)
        Me.cbKeyWords.Items.AddRange(h.Get_All_KeyWords.ToArray)
        Me.cKeyWords = P.Description.KeyWords.Clone
        Me.tbProgramName.Text = P.Description.Name
        Me.tbKeyWords.Text = Szunyi.Common.GetText(P.Description.KeyWords, ";")
        Me.tbDescription.Text = P.Description.Description
        Me.cProgram = P.Clone
        Me.tbLocation.Text = Me.cProgram.Location

    End Sub

    Public Sub New(h As Hierarchy, P As Program, SP As SubProgram, type As Type)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Type = type
        Me.H = h
        Me.cKeyWords = SP.Description.KeyWords.Clone
        Me.cbKeyWords.Items.AddRange(h.Get_All_KeyWords.ToArray)
        Me.tbProgramName.Text = SP.Description.Name
        Me.tbKeyWords.Text = Szunyi.Common.GetText(SP.Description.KeyWords, ";")
        Me.tbDescription.Text = SP.Description.Description
        Me.P = P
        Me.SP = SP

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Select Case Me.Type
            Case Type.New_Program
                If H.HasProgramName(tbProgramName.Text) = True Then

                    Dim res = MsgBox("ProgramName has Already Entered. Do you want to override it?", MsgBoxStyle.OkCancel)
                    If res = MsgBoxResult.Cancel Then Exit Sub
                Else
                    Dim b As New Basic_Description With {.Name = tbProgramName.Text, .Description = tbDescription.Text, .KeyWords = cKeyWords.CloneStrings.ToList}
                    Me.P = New Program With {.Description = b, .Type = Szunyi.Common.Util_Helpers.Get_Enum_Value(Of Console_For_Windows.ProgramType)(cbProgramType.SelectedItem), .Location = tbLocation.Text}
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                End If
            Case Type.Edit_Program
                Dim b As New Basic_Description With {.Name = tbProgramName.Text, .Description = tbDescription.Text, .KeyWords = cKeyWords.CloneStrings.ToList}
                Me.P = New Program With {.Description = b, .Type = Szunyi.Common.Util_Helpers.Get_Enum_Value(Of Console_For_Windows.ProgramType)(cbProgramType.SelectedItem), .Location = tbLocation.Text}
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Case Type.New_SubProgram
                If Me.cProgram.HasProgramName(tbProgramName.Text) = True Then
                    Dim res = MsgBox("ProgramName has Already Entered.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    Dim b1 As New Basic_Description With {.Name = tbProgramName.Text, .Description = tbDescription.Text, .KeyWords = cKeyWords.CloneStrings.ToList}
                    Me.SP = New SubProgram With {.Description = b1}
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                End If
            Case Type.Edit_SubProgram
                Dim b1 As New Basic_Description With {.Name = tbProgramName.Text, .Description = tbDescription.Text, .KeyWords = cKeyWords.CloneStrings.ToList}
                Me.SP = New SubProgram With {.Description = b1, .Parameters = SP.Parameters}
                Me.DialogResult = DialogResult.OK
                Me.Close()
        End Select

    End Sub

    Private Sub cbKeyWords_Validating(sender As Object, e As CancelEventArgs) Handles cbKeyWords.Validating
        If cKeyWords.HasContain(cbKeyWords.Text) = False Then
            cKeyWords.Add(cbKeyWords.Text)
            cbKeyWords.Text = String.Empty
            tbKeyWords.Text = cKeyWords.GetText(";")
        End If
    End Sub

    Private Sub NewProgram_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        If Me.Type = Type.Edit_Program Or Me.Type = Type.New_Program Then
            Dim File = Szunyi.IO.Pick_Up.File()
            If IsNothing(File) = False Then
                Me.tbLocation.Enabled = True
                tbLocation.Text = File.FullName
                Me.tbLocation.Enabled = False
            End If
        End If

    End Sub

End Class