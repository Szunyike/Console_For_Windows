Imports System.ComponentModel
Imports Szunyi.Common.Extensions
Public Class NewProgram
    Public Property H As Hierarchy
    Public Property P As Program
    Public Property SP As SubProgram
    Public Property cKeyWords As New List(Of String)
    Public Property cProgram As Program
    Public Property Type As Type

    Private Sub SetIt()

    End Sub


    Public Sub New(h As Hierarchy, type As Type)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.H = h
        Me.Type = type
        Me.P = New Program
    End Sub
    Public Sub New(h As Hierarchy, P As Program, type As Type)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.Type = type
        Me.H = h
        Me.P = P

    End Sub

    Public Sub New(h As Hierarchy, P As Program, SP As SubProgram, type As Type)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Type = type
        Me.H = h
        Me.P = P
        Me.SP = SP

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Select Case Me.Type
            Case Type.New_Program
                If H.HasProgramName(P.Description.Name) = True Then
                    Dim res = MsgBox("ProgramName has Already Entered. Do you want to override it?", MsgBoxStyle.OkCancel)
                    If res = MsgBoxResult.Cancel Then Exit Sub
                End If
            Case Type.New_SubProgram
                If Me.P.HasProgramName(P.Description.Name) = True Then
                    Dim res = MsgBox("ProgramName has Already Entered.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
        End Select
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub



    Private Sub NewProgram_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.cbProgramType.Items.AddRange(Szunyi.Common.Util_Helpers.Get_All_Enum_Names(Of Console_For_Windows.ProgramType)(Nothing).ToArray)
        Me.Bd1.Set_BD(P.Description)
        Me.tbLocation.DataBindings.Add("Text", P, "Location")
        Me.cbProgramType.DataBindings.Add(New Binding("SelectedIndex", P, "Type", formattingEnabled:=True, dataSourceUpdateMode:=DataSourceUpdateMode.OnPropertyChanged))
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        If Me.Type = Type.Edit_Program Or Me.Type = Type.New_Program Then
            Dim File = Szunyi.IO.Pick_Up.File()
            If IsNothing(File) = False Then

                tbLocation.Text = File.FullName
              
            End If
        End If

    End Sub

End Class