Imports System.ComponentModel
Imports Szunyi.Common.Extensions
Public Class BasicTextBox
    Private NotValidNames As New List(Of String)
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(Label As String, Optional NotValidNames As IEnumerable(Of String) = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If IsNothing(NotValidNames) = True Then Me.NotValidNames = NotValidNames.ToList
    End Sub

    Public Sub SetLabel(Label As String)
        Me.Label1.Text = Label
    End Sub
End Class
