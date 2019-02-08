Imports System.ComponentModel
Imports Szunyi.Common
Public Class BD
    Dim cKeyWords As New List(Of String)
    Public BD As Basic_Description
    Private Sub BD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbProgramName.DataBindings.Add("Text", BD, "Name", formattingEnabled:=True, updateMode:=DataSourceUpdateMode.OnPropertyChanged)
        tbDescription.DataBindings.Add("Text", BD, "Description", formattingEnabled:=True, updateMode:=DataSourceUpdateMode.OnPropertyChanged)
        tbSymbol.DataBindings.Add("Text", BD, "Symbol", formattingEnabled:=True, updateMode:=DataSourceUpdateMode.OnPropertyChanged)
        cbKeyWords.Items.AddRange(cKeyWords.ToArray)
    End Sub
    Public Sub New(KeyWords As List(Of String))

        ' This call is required by the designer.
        InitializeComponent()
        Me.cKeyWords = KeyWords
        ' Add any initialization after the InitializeComponent() call.
        BD = New Basic_Description
    End Sub
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        BD = New Basic_Description
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(Item As Basic_Description, KeyWords As List(Of String))

        ' This call is required by the designer.
        InitializeComponent()
        BD = Item
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub cbKeyWords_Validating(sender As Object, e As CancelEventArgs) Handles cbKeyWords.Validating
        KeyWord()
    End Sub
    Private Sub KeyWord()
        If cKeyWords.HasContain(cbKeyWords.Text) = False Then
            BD.KeyWords.Add(cbKeyWords.Text)
            cKeyWords.Add(cbKeyWords.Text)
            cbKeyWords.Text = String.Empty
            tbKeyWords.Text = cKeyWords.GetText(";")
        End If
    End Sub
    Private Sub cbKeyWords_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbKeyWords.KeyPress
        If e.KeyChar = Chr(13) Then
            KeyWord()
        End If
    End Sub
    Public Sub Set_BD(BD As Basic_Description, Optional KeyWords As List(Of String) = Nothing)
        Me.BD = BD
        If IsNothing(KeyWords) = False Then cbKeyWords.Items.AddRange(KeyWords.ToArray)
        tbProgramName.DataBindings.Clear()
        tbDescription.DataBindings.Clear()
        tbSymbol.DataBindings.Clear()
        tbKeyWords.DataBindings.Clear()
        tbProgramName.DataBindings.Add("Text", BD, "Name", formattingEnabled:=True, updateMode:=DataSourceUpdateMode.OnPropertyChanged)
        tbDescription.DataBindings.Add("Text", BD, "Description", formattingEnabled:=True, updateMode:=DataSourceUpdateMode.OnPropertyChanged)
        tbSymbol.DataBindings.Add("Text", BD, "Symbol", formattingEnabled:=True, updateMode:=DataSourceUpdateMode.OnPropertyChanged)
        tbKeyWords.DataBindings.Add("Text", BD, "KeyWords", formattingEnabled:=True, updateMode:=DataSourceUpdateMode.OnPropertyChanged)
    End Sub
End Class
