Imports System.Runtime.CompilerServices
Public Enum [Type]
    New_Program = 1
    Edit_Program = 2
    New_SubProgram = 3
    Edit_SubProgram = 4
    New_Parameter = 5
    Edit_Parameter = 6

End Enum
Public Class Hierarchy
    Public Property Programs As New List(Of Program)
End Class
<Serializable>
Public Class Program
    Public Property SubPrograms As New List(Of SubProgram)
    Public Property Type As ProgramType
    '  Public Property Name As String
    '  Public Property Description As String
    '  Public Property KeyWords As New List(Of String)
    Public Description As Basic_Description
    Public Property Location As String
End Class
<Serializable>
Public Class SubProgram
    Public Property Parameters As New List(Of Parameter)
    Public Property Description As Basic_Description
End Class
<Serializable>
Public Class Parameter
    Public Property Name As String
    Public Property Symbol As String
    Public Property Description As Basic_Description
    Public Property Type As ParameterType
    Public Property KeyWords As New List(Of String)
    Public Property DefaultValue As String
    Public Property AcceptableValues As List(Of String)
    Public Property MinValue As Double
    Public Property MaxValue As Double
    Public Property IncompatibleParameters As New List(Of String)
    Public Property IsEssentialParamater As Boolean
End Class
<Serializable>
Public Enum ProgramType
    linux = 1
    java = 2
    phyton = 3
    powershell = 4
    windows_command_line = 5
End Enum
<Serializable>
Public Enum ParameterType
    [Integer] = 1
    [Double] = 4
    [string] = 6
    strings = 7
    Selection = 8
    File = 9
    Files = 10
    stdin = 11


End Enum
<Serializable>
Public Class Basic_Description
    Public Property Name As String
    Public Property Description As String
    Public Property KeyWords As New List(Of String)
    Public Sub New(Name As String, Description As String, KeyWords As IEnumerable(Of String))
        Me.Name = Name
        Me.Description = Description
        Me.KeyWords = KeyWords.ToList
    End Sub
    Public Sub New()

    End Sub
End Class

Public Module Extensions
    ''' <summary>
    ''' Yield All ProgramName from IEnumerable(Of Program)
    ''' </summary>
    ''' <param name="Programs"></param>
    ''' <returns></returns>
    <Extension>
    Public Iterator Function Get_All_ProgramName(Programs As IEnumerable(Of Program)) As IEnumerable(Of String)
        For Each ProgramName In From x In Programs Select x.Description.Name
            Yield ProgramName
        Next
    End Function
    ''' <summary>
    ''' Yield All ProgramName from IEnumerable(Of Program)
    ''' </summary>
    ''' <param name="Programs"></param>
    ''' <returns></returns>
    <Extension>
    Public Iterator Function Get_All_ProgramName(Programs As IEnumerable(Of SubProgram)) As IEnumerable(Of String)
        For Each ProgramName In From x In Programs Select x.Description.Name
            Yield ProgramName
        Next
    End Function
    ''' <summary>
    ''' Yield All ProgramName from Hierarchy
    ''' </summary>
    ''' <param name="CurrHierarchy"></param>
    ''' <returns></returns>
    <Extension>
    Public Iterator Function Get_All_ProgramName(CurrHierarchy As Hierarchy) As IEnumerable(Of String)
        For Each ProgramName In CurrHierarchy.Programs.Get_All_ProgramName
            Yield ProgramName
        Next
    End Function

    <Extension>
    Public Function HasProgramName(Programs As IEnumerable(Of Program), ProgramName As String) As Boolean
        Dim res = From x In Programs.Get_All_ProgramName Where x.IndexOf(ProgramName, comparisonType:=StringComparison.InvariantCultureIgnoreCase) > -1 And ProgramName.Length = x.Length

        If res.Count > 0 Then Return True
        Return False
    End Function
    <Extension>
    Public Function HasProgramName(Programs As IEnumerable(Of SubProgram), ProgramName As String) As Boolean
        Dim res = From x In Programs.Get_All_ProgramName Where x.IndexOf(ProgramName, comparisonType:=StringComparison.InvariantCultureIgnoreCase) > -1 And ProgramName.Length = x.Length

        If res.Count > 0 Then Return True
        Return False
    End Function
    <Extension>
    Public Function HasProgramName(CurrHierarchy As Hierarchy, ProgramName As String) As Boolean
        Return CurrHierarchy.Programs.HasProgramName(ProgramName)
    End Function
    <Extension>
    Public Function HasProgramName(P As Program, ProgramName As String) As Boolean
        Return P.SubPrograms.HasProgramName(ProgramName)
    End Function

    ''' <summary>
    ''' Yield All ProgramName from IEnumerable(Of Program)
    ''' </summary>
    ''' <param name="Programs"></param>
    ''' <returns></returns>
    <Extension>
    Public Iterator Function Get_All_KeyWords(Programs As IEnumerable(Of Program)) As IEnumerable(Of String)
        Dim Out As New List(Of String)
        For Each ProgramName In From x In Programs Select x.Description.KeyWords
            Out.AddRange(ProgramName)
        Next
        For Each Item In Out.Distinct
            Yield Item
        Next
    End Function
    ''' <summary>
    ''' Yield All ProgramName from Hierarchy
    ''' </summary>
    ''' <param name="CurrHierarchy"></param>
    ''' <returns></returns>
    <Extension>
    Public Iterator Function Get_All_KeyWords(CurrHierarchy As Hierarchy) As IEnumerable(Of String)
        For Each ProgramName In CurrHierarchy.Programs.Get_All_KeyWords
            Yield ProgramName
        Next
    End Function
    ''' <summary>
    ''' Add All KeyWords From Basic_Descriptio to Tree-node
    ''' </summary>
    ''' <param name="Tr"></param>
    ''' <param name="b"></param>
    <Extension>
    Public Sub AddKeyWords(ByRef Tr As TreeNode, b As Basic_Description)
        For Each Item In b.KeyWords
            Dim t As New TreeNode With {.Text = Item}
            Tr.Nodes.Add(t)
        Next
    End Sub

    <Extension>
    Public Function IsProgram(tr As TreeNode) As Boolean
        If IsNothing(tr.Tag) = True Then Return False
        If TypeOf tr.Tag Is Program Then
            Return True
        Else
            Return False
        End If
    End Function
    <Extension>
    Public Function IsSubProgram(tr As TreeNode) As Boolean
        If IsNothing(tr.Tag) = True Then Return False
        If TypeOf tr.Tag Is SubProgram Then
            Return True
        Else
            Return False
        End If
    End Function
    <Extension>
    Public Function IsParameter(tr As TreeNode) As Boolean
        If IsNothing(tr.Tag) = True Then Return False
        If TypeOf tr.Tag Is Parameter Then
            Return True
        Else
            Return False
        End If
    End Function

    <Extension>
    Public Function Clone(SubPrograms As IEnumerable(Of SubProgram)) As List(Of SubProgram)
        Dim out As New List(Of SubProgram)
        For Each Sp In SubPrograms
            out.Add(Sp.CLone)
        Next
        Return out
    End Function

    <Extension>
    Public Function Clone(SP As SubProgram) As SubProgram
        Return New SubProgram With {.Description = SP.Description.Clone, .Parameters = SP.Parameters.Clone}

    End Function

    <Extension>
    Public Function Clone(BD As Basic_Description) As Basic_Description
        Return New Basic_Description With {.Name = BD.Name, .Description = BD.Description, .KeyWords = BD.KeyWords.Clone}

    End Function
    <Extension>
    Public Function Clone(s As IEnumerable(Of String)) As List(Of String)
        Dim out As New List(Of String)
        For Each item In s
            out.Add(item)

        Next
        Return out
    End Function
    <Extension>
    Public Function Clone(Pas As IEnumerable(Of Parameter)) As List(Of Parameter)
        Dim out As New List(Of Parameter)
        For Each Item In Pas
            out.Add(Item.Clone)
        Next
        Return out
    End Function
    <Extension>
    Public Function Clone(Pa As Parameter) As Parameter
        Return New Parameter With {.AcceptableValues = Pa.AcceptableValues.Clone, .DefaultValue = Pa.DefaultValue, .Description = Pa.Description.Clone, .KeyWords = Pa.KeyWords.Clone, .MaxValue = Pa.MaxValue, .MinValue = Pa.MinValue, .Name = Pa.Name, .Type = Pa.Type, .Symbol = Pa.Symbol, .IncompatibleParameters = Pa.IncompatibleParameters.Clone, .IsEssentialParamater = Pa.IsEssentialParamater}

    End Function

    <Extension>
    Public Function Clone(Pa As Program) As Program
        Return New Program With {.Description = Pa.Description.Clone, .SubPrograms = Pa.SubPrograms.Clone, .Type = Pa.Type, .Location = Pa.Location}

    End Function
    <Extension>
    Public Function Clone(Pa As IEnumerable(Of Program)) As List(Of Program)
        Dim out As New List(Of Program)

        For Each Item In Pa
            out.Add(Item.Clone)
        Next
        Return out
    End Function
    <Extension>
    Public Function Clone(Pa As Hierarchy) As Hierarchy
        Dim x As New Hierarchy
        For Each Item In Pa.Programs
            x.Programs.Add(Item.Clone)
        Next
        Return x
    End Function
End Module