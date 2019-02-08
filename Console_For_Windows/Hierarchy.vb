Imports System.IO
Imports System.Runtime.CompilerServices
Imports Szunyi, Szunyi.Common.Extensions
Imports Szunyi.IO.Extensions
Public Enum [Type]
    New_Program = 1
    Edit_Program = 2
    New_SubProgram = 3
    Edit_SubProgram = 4
    New_Parameter = 5
    Edit_Parameter = 6

End Enum
Public Enum File_ReName
    Append_Before_Extension = 1
    Change_Extension = 2

End Enum
Public Class Hierarchy
    Public Property Programs As New List(Of Program)
End Class
<Serializable>
Public Class Program
    Public Property SubPrograms As New List(Of SubProgram)
    Public Property Type As ProgramType

    Public Description As New Basic_Description
    Public Property Location As String
    '   Public Property Working_Directory As DirectoryInfo

    Friend Shared Function Get_Header() As String
        Return "Program Name	Program Description	Program Symbol	Program KeyWords	Program Location	Program Working Directory	Program Type"
    End Function
    Public Overrides Function ToString() As String
        Return Me.Description.ToString.Replace(vbCrLf, " ") & vbTab & Me.Location & vbTab & Me.Type
    End Function
    Public Function Get_Command()
        Dim str As New System.Text.StringBuilder
        Select Case Me.Type
            Case ProgramType.windows_perl
                str.Append("perl ").Append(Me.Location)
        End Select
        Return str.ToString
    End Function
End Class
<Serializable>
Public Class SubProgram
    Public Property Parameters As New List(Of Parameter)
    Public Property ParameterGroupss As New List(Of ParameterGroup)
    Public Property Description As Basic_Description

    Friend Shared Function Get_Header() As String
        Return Split("SubProgram Name,SubProgram Description,SubProgram Symbol,SubProgram KeyWords", ",").GetText(vbTab)
    End Function
    Public Overrides Function ToString() As String
        Return Me.Description.ToString.Replace(vbCrLf, " ")
    End Function
    Public Function Get_Command()
        If IsNothing(Me.Description) = True Then Return String.Empty
        If IsNothing(Me.Description.Symbol) = True Then Return String.Empty
        Return " " & Me.Description.Symbol
    End Function
End Class
<Serializable>
Public Class ParameterGroup
    Public Property Parameters As New List(Of Parameter)
    Public Property Description As Basic_Description
    Public Overrides Function ToString() As String
        Dim str As New System.Text.StringBuilder

        Return Description.ToString.Replace(vbCrLf, " ")
    End Function
    Friend Shared Function Get_Header() As String
        Return Split("ParameterGroup Name,ParameterGroup Description,ParameterGroup KeyWords", ",").GetText(vbTab)
    End Function
End Class

<Serializable>
Public Class Parameter
    Public Sub New()

    End Sub
    Public Property Description As New Basic_Description
    Public Property Type As ParameterType = ParameterType.Boolean
    Public Property Default_Value As String = ""
    Public Property Acceptable_Values As List(Of String)
    Public Property MinValue As Double
    Public Property MaxValue As Double
    Public Property Incompatible_Parameters As New List(Of String)
    Public Property Must_Parameters As New List(Of String)
    Public Property Is_Essential_Paramater As Boolean
    Public Property Nof_Item As Integer
    Public Property Selected_File As String = ""
    Public Property Selected_Files As List(Of String)
    Public Property File_Filter As String
    Public Property Separator As String
    Public Property File_Name_Append As String
    Public Property Values As List(Of String)

    '   Public Property Working_Directory As String
    Public Overrides Function ToString() As String
        Dim str As New System.Text.StringBuilder
        '    Parameter Name
        '      Parameter Description
        '    Parameter Symbol
        '     Parameter KeyWords
        '    Parameter Append Working Directory
        '     Parameter Type
        '    Parameter Separator
        '     Parameter Nof Item
        '     Parameter FileName Append
        '   Parameter Incompatible Parameters
        str.Append(Me.Description.ToString)
        '    str.Append(vbTab).Append(Me.Working_DIrectory)
        str.Append(vbTab).Append(Me.Type)
        '     str.Append(vbTab).Append(Me.Separator)
        str.Append(vbTab).Append(Me.Nof_Item)
        '   str.Append(vbTab).Append(Me.Separator)
        '   str.Append(vbTab).Append(Me.File_Name_Append)
        str.Append(vbTab).Append(Me.Incompatible_Parameters.GetText(";"))
        Return str.ToString.Replace(vbCrLf, " ").Replace(vbCr, " ").Replace(vbLf, " ")
    End Function

    Friend Shared Function Get_Header() As String
        Dim s = Split("Parameter Name,Parameter Description,Parameter Symbol,Parameter KeyWords,Parameter Append Working Directory,Parameter Type,Parameter Separator,Parameter Nof Item,Parameter FileName Append,Parameter Incompatible Parameters", ",").GetText
        Return s.Replace(vbCr, " ").Replace(vbLf, " ")
    End Function
    Public Iterator Function Get_Current_Values() As IEnumerable(Of String)
        Select Case Me.Type
            Case ParameterType.List_Of_Double, ParameterType.List_Of_Integer, ParameterType.Files
                For Each Item In Me.Values
                    Yield Me.Description.Symbol & " " & Item
                Next
            Case Else
                Yield Me.Description.Symbol & " " & Me.Default_Value
        End Select
    End Function
End Class
<Serializable>
Public Enum ProgramType
    linux = 0
    java = 1
    phyton = 2
    powershell = 4
    windows_command_line = 5
    windows_perl = 6
End Enum
<Serializable>
Public Enum ParameterType
    [Integer] = 1
    [Double] = 4
    [string] = 6
    Selection = 8
    File = 9
    Files = 10
    stdin = 11
    [Boolean] = 12
    [List_Of_Integer] = 13
    [List_Of_Double] = 14
    Constant_File = 15
    File_Rename = 16
End Enum
<Serializable>
Public Class Basic_Description
    Public Property Name As String = ""
    Public Property Description As String = ""
    Public Property Symbol As String = ""
    Public Property KeyWords As New List(Of String)
    Public Sub New(Name As String, Description As String, KeyWords As IEnumerable(Of String))
        Me.Name = Name
        Me.Description = Description
        Me.KeyWords = KeyWords.ToList
    End Sub
    Public Sub New()

    End Sub
    Public Overrides Function ToString() As String
        Dim str As New System.Text.StringBuilder
        str.Append(Me.Name)
        str.Append(vbTab).Append(Me.Description)
        str.Append(vbTab).Append(Me.Symbol)
        str.Append(vbTab).Append(Me.KeyWords.GetText(";"))
        Return str.ToString.Replace(vbCrLf, " ")
    End Function
End Class

Public Module Extensions
    <Extension>
    Public Function Full_Name(File As FileInfo, type As ProgramType)
        Select Case type
            Case ProgramType.phyton
                Return File.FullName_Linux
            Case ProgramType.phyton
                Return File.FullName_Python
            Case ProgramType.windows_command_line
                Return File.FullName_Windows_cmd
            Case ProgramType.windows_perl
                Return File.FullName_Windows_cmd
        End Select
    End Function
    <Extension>
    Public Function Get_File_Input(Paras As IEnumerable(Of Parameter)) As Parameter
        Dim res = Paras.Get_File_Inputs

        Return res.First
    End Function
    <Extension>
    Public Function Get_File_ReName(Paras As IEnumerable(Of Parameter)) As Parameter
        Dim res = From x In Paras Where x.Type = ParameterType.File_Rename
        If res.Count = 0 Then Return Nothing

        Return res.First
    End Function
    <Extension>
    Public Iterator Function Get_File_Inputs(Paras As IEnumerable(Of Parameter)) As IEnumerable(Of Parameter)
        Dim res = From x In Paras Where x.Type = ParameterType.Files Or x.Type = ParameterType.File

        For Each r In res
            Yield r
        Next
    End Function
    <Extension>
    Public Iterator Function Get_Default_Parameters(SP As SubProgram) As IEnumerable(Of Parameter)
        For Each P In SP.Get_All_Parameters
            If P.Type = ParameterType.Files Or P.Type = ParameterType.File_Rename Then

            Else
                Yield P
            End If
        Next

    End Function
    <Extension>
    Public Iterator Function Get_All_Parameters(SP As SubProgram) As IEnumerable(Of Parameter)
        For Each P In SP.Parameters
            Yield P
        Next
        For Each PG In SP.ParameterGroupss
            For Each P In PG.Parameters
                Yield P
            Next
        Next
    End Function
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

        If Programs.Count = 0 Then Return False
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
        If IsNothing(P.SubPrograms) = True Then Return False
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
        If IsNothing(tr) = True Then Return False
        If IsNothing(tr.Tag) = True Then Return False
        If TypeOf tr.Tag Is Program Then
            Return True
        Else
            Return False
        End If
    End Function
    <Extension>
    Public Function IsSubProgram(tr As TreeNode) As Boolean
        If IsNothing(tr) = True Then Return False
        If IsNothing(tr.Tag) = True Then Return False
        If TypeOf tr.Tag Is SubProgram Then
            Return True
        Else
            Return False
        End If
    End Function
    <Extension>
    Public Function IsSubProgram_OR_ParameterGroup(tr As TreeNode) As Boolean
        If IsNothing(tr) = True Then Return False
        If IsNothing(tr.Tag) = True Then Return False
        If TypeOf tr.Tag Is SubProgram Then
            Return True
        ElseIf TypeOf tr.Tag Is ParameterGroup Then
            Return True
        Else
            Return False
        End If
    End Function
    <Extension>
    Public Function IsParameter(tr As TreeNode) As Boolean
        If IsNothing(tr) = True Then Return False
        If IsNothing(tr.Tag) = True Then Return False
        If TypeOf tr.Tag Is Parameter Then
            Return True
        Else
            Return False
        End If
    End Function
    <Extension>
    Public Function IsParameterGroup(tr As TreeNode) As Boolean
        If IsNothing(tr) = True Then Return False
        If IsNothing(tr.Tag) = True Then Return False
        If TypeOf tr.Tag Is ParameterGroup Then
            Return True
        Else
            Return False
        End If
    End Function

    <Extension>
    Public Function Clone(SubPrograms As IEnumerable(Of SubProgram)) As List(Of SubProgram)
        Dim out As New List(Of SubProgram)
        For Each Sp In SubPrograms
            out.Add(Sp.Clone)
        Next
        Return out
    End Function

    <Extension>
    Public Function Clone(SP As SubProgram) As SubProgram
        Return New SubProgram With {.Description = SP.Description.Clone, .Parameters = SP.Parameters.Clone}

    End Function

    <Extension>
    Public Function Clone(BD As Basic_Description) As Basic_Description
        Return New Basic_Description With {.Name = BD.Name, .Description = BD.Description, .Symbol = BD.Symbol, .KeyWords = BD.KeyWords.Clone}

    End Function
    <Extension>
    Public Function Clone(s As IEnumerable(Of String)) As List(Of String)
        Dim out As New List(Of String)
        If IsNothing(s) = True Then Return out
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
        Return New Parameter With {.Nof_Item = Pa.Nof_Item, .Acceptable_Values = Pa.Acceptable_Values.Clone, .Default_Value = Pa.Default_Value, .Description = Pa.Description.Clone,
             .MaxValue = Pa.MaxValue, .MinValue = Pa.MinValue, .Type = Pa.Type, .Incompatible_Parameters = Pa.Incompatible_Parameters.Clone, .Is_Essential_Paramater = Pa.Is_Essential_Paramater}

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

    <Extension>
    Public Function Get_Program(h As Hierarchy, Name As String) As Program

        Dim P = From x In h.Programs Where x.Description.Name.IndexOf(Name) > -1 Select x

        Select Case P.Count
            Case 0
                MsgBox("No any Program has found")
            Case 1
                Return P.First
            Case Else
                MsgBox("Too many Program has found")
        End Select
        Return Nothing
    End Function

    <Extension>
    Public Function Get_Sub_Program(P As Program, Name As String) As SubProgram

        Dim SP = From x In P.SubPrograms Where x.Description.Name.IndexOf(Name) > -1 Select x

        Select Case SP.Count
            Case 0
                MsgBox("No any Program has found")
            Case 1
                Return SP.First
            Case Else
                MsgBox("Too many Program has found")
        End Select
        Return Nothing
    End Function
    <Extension>
    Public Function Get_ParameterGroup(SP As SubProgram, Name As String) As ParameterGroup

        Dim PG = From x In SP.ParameterGroupss Where x.Description.Name.IndexOf(Name) > -1 Select x

        Select Case PG.Count
            Case 0
                MsgBox("No any Program has found")
            Case 1
                Return PG.First
            Case Else
                MsgBox("Too many Program has found")
        End Select
        Return Nothing
    End Function

    <Extension>
    Public Function Get_Header(Tr As TreeNode) As String
        If Tr.IsProgram Then
            Return Split("Program Name,Program Description,Program Symbol,Program KeyWords,Program Location,Program Working Directory,Program Type", ",").GetText
        ElseIf Tr.IsSubProgram Then
            Return Split("SubProgram Name,SubProgram Description,SubProgram Symbol,SubProgram KeyWords", ",").GetText
        ElseIf Tr.IsParameterGroup Then
            Return Split("ParameterGroup Name,ParameterGroup Description,ParameterGroup KeyWords", ",").GetText
        ElseIf Tr.IsParameter Then
            Return Split("Parameter Name,Parameter Description,Parameter Symbol,Parameter KeyWords,Parameter Append Working Directory,Parameter Type,Parameter Separator,Parameter Nof Item,Parameter FileName Append,Parameter Incompatible Parameters", ",").GetText
        Else ' tr is nothing means full
            Dim str As New System.Text.StringBuilder
            str.Append(Split("Program Name,Program Description,Program Symbol,Program KeyWords,Program Location,Program Working Directory,Program Type", ",").GetText)
            str.Append(vbTab).Append(Split("SubProgram Name,SubProgram Description,SubProgram Symbol,SubProgram KeyWords", ",").GetText)
            str.Append(vbTab).Append(Split("ParameterGroup Name,ParameterGroup Description,ParameterGroup KeyWords", ",").GetText)
            str.Append(vbTab).Append(Split("Parameter Name,Parameter Description,Parameter Symbol,Parameter KeyWords,Parameter Append Working Directory,Parameter Type,Parameter Separator,Parameter Nof Item,Parameter FileName Append,Parameter Incompatible Parameters", ",").GetText)
            Return str.ToString
        End If
    End Function

    <Extension>
    Public Function Get_Values(tr As TreeNode)
        If tr.IsProgram Then

        ElseIf tr.IsSubProgram Then

        ElseIf tr.IsParameterGroup Then

        ElseIf tr.IsParameter Then
            Dim P As Parameter = tr.Tag
            Return P.ToString
        Else

        End If
    End Function
End Module