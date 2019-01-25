Imports System.IO
Imports System.Text
Imports System.Web.Security
Imports Szunyi.IO.Export_Module
Imports Szunyi.IO.Extensions
Imports Szunyi.Common.Extensions

Public Class Form1
    Public Property Hierarchy As New Hierarchy

    Public Property File As FileInfo

    Private Sub ProgramToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProgramToolStripMenuItem.Click
        Dim x As New NewProgram(Hierarchy, Type.New_Program)
        If x.ShowDialog = DialogResult.OK Then
            ' Check ProgramName is 
            If Hierarchy.HasProgramName(x.P.Description.Name) = True Then

            Else

                Me.Hierarchy.Programs.Add(x.P)
                tv1.Nodes.Clear()
                tv1.Nodes.AddRange(GetTreeNodes(Me.Hierarchy).ToArray)
            End If
        End If
    End Sub

    Private Sub Save_HierarchyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HierarchyToolStripMenuItem.Click

        Dim txt = Szunyi.IO.XML.Serialize(Of Hierarchy)(Me.Hierarchy)
        If IsNothing(Me.File) = True Then
            Dim File = Szunyi.IO.File_Extensions.Xml.File_To_Save()
            txt.Export_Text(File)
        Else
            txt.Export_Text(Me.File)
        End If

    End Sub
    Private Sub Save_ProgramToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ProgramToolStripMenuItem1.Click
        If tv1.SelectedNode.IsProgram = True Then
            Dim pr = tv1.SelectedNode.Tag
            Dim txt = Szunyi.IO.XML.Serialize(Of Program)(pr)
            Dim File = Szunyi.IO.File_Extensions.Xml.File_To_Save()
            txt.Export_Text(File)
        End If
    End Sub

    Private Sub Save_ParametersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ParametersToolStripMenuItem.Click

    End Sub


    Private Function GetTreeNodes(h As Hierarchy) As List(Of TreeNode)
        Dim out As New List(Of TreeNode)
        For Each P In Hierarchy.Programs
            Dim t As New TreeNode With {.Text = P.Description.Name, .SelectedImageIndex = P.Type, .Tag = P}
            t.AddKeyWords(P.Description)
            For Each SubP In P.SubPrograms
                Dim sp As New TreeNode With {.Text = SubP.Description.Name, .ToolTipText = SubP.Description.Name, .Tag = SubP}
                sp.AddKeyWords(SubP.Description)
                t.Nodes.Add(sp)
                For Each Para In SubP.Parameters
                    Dim tp As New TreeNode With {.Text = Para.Description.Name, .ToolTipText = Para.Description.Description, .Tag = Para}
                    tp.AddKeyWords(Para.Description)
                    sp.Nodes.Add(tp)
                Next
                For Each PG In SubP.ParameterGroupss
                    Dim pg_tr As New TreeNode With {.Text = PG.Description.Name, .ToolTipText = PG.Description.Description, .Tag = PG}
                    For Each Para In PG.Parameters
                        Dim tp As New TreeNode With {.Text = Para.Description.Name, .ToolTipText = Para.Description.Description, .Tag = Para}
                        tp.AddKeyWords(Para.Description)
                        pg_tr.Nodes.Add(tp)
                    Next
                    sp.Nodes.Add(pg_tr)
                Next
            Next
            out.Add(t)
        Next
        Return out
    End Function

    Private Sub NewSubProgramToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubProgramToolStripMenuItem.Click
        If tv1.SelectedNode.IsProgram = True Then
            Dim Pr As Program = tv1.SelectedNode.Tag
            Dim x As New NewProgram(Hierarchy, Pr, Type.New_SubProgram)
            x.cbProgramType.Enabled = False
            If x.ShowDialog = DialogResult.OK Then
                Dim p As Program = tv1.SelectedNode.Tag
                p.SubPrograms.Add(New SubProgram With {.Description = x.SP.Description})
                ReFresh_Treeview()
            End If
        End If

    End Sub

    Private Sub NewParameterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ParameterToolStripMenuItem.Click
        ' Vagy egy Program es akkor ervenyes az osszes subprogramjara
        ' Later
        ' Vagy Subprogram
        ' kesobb masolas
        If IsNothing(tv1.SelectedNode) = False Then
            If tv1.SelectedNode.IsSubProgram = True Then
                Dim x As New NewParameter(tv1.SelectedNode.Tag)
                If x.ShowDialog = DialogResult.OK Then
                    Dim sp As SubProgram = tv1.SelectedNode.Tag
                    sp.Parameters.Add(x.Parameter)
                    tv1.SelectedNode.Nodes.Add(New TreeNode With {.Text = x.Parameter.Description.Name, .ToolTipText = x.Parameter.Description.Description, .Tag = x.Parameter})
                    '        ReFresh_Treeview()
                End If
            End If
        End If

    End Sub


    Private Sub Edit_ProgramToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ProgramToolStripMenuItem2.Click
        If tv1.SelectedNode.IsProgram = True Then
            Dim p As Program = tv1.SelectedNode.Tag
            Dim x As New NewProgram(Me.Hierarchy, p, Type.Edit_Program)
            Dim SelNode = tv1.SelectedNode.FullPath
            If x.ShowDialog = DialogResult.OK Then
                Dim Index = tv1.SelectedNode.Index
                x.P.SubPrograms.AddRange(p.SubPrograms.Clone)
                Me.Hierarchy.Programs.RemoveAt(Index)
                Me.Hierarchy.Programs.Insert(Index, x.P)
                ReFresh_Treeview()

            End If
        End If
    End Sub

    Private Sub Edit_SubProgramToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SubProgramToolStripMenuItem1.Click
        If tv1.SelectedNode.IsSubProgram = True Then
            Dim sp As SubProgram = tv1.SelectedNode.Tag
            Dim Pr As Program = tv1.SelectedNode.Parent.Tag
            Dim x As New NewProgram(Hierarchy, Pr, sp, Type.Edit_SubProgram)
            x.cbProgramType.Enabled = False
            If x.ShowDialog = DialogResult.OK Then
                Dim p As Program = tv1.SelectedNode.Parent.Tag
                Dim Index = p.SubPrograms.IndexOf(sp)
                p.SubPrograms.RemoveAt(Index)
                p.SubPrograms.Insert(Index, New SubProgram With {.Description = x.SP.Description, .Parameters = x.SP.Parameters.Clone})
                ReFresh_Treeview()
            End If
        End If

    End Sub

    Private Sub Edit_ParameterToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ParameterToolStripMenuItem1.Click
        If tv1.SelectedNode.IsParameter Then
            If tv1.SelectedNode.Parent.IsSubProgram = True Then
                Dim sp As SubProgram = tv1.SelectedNode.Parent.Tag
                Dim p As Parameter = tv1.SelectedNode.Tag
                Dim x As New NewParameter(sp, p)
                If x.ShowDialog = DialogResult.OK Then
                    Dim Index = sp.Parameters.IndexOf(p)
                    sp.Parameters.RemoveAt(Index)
                    sp.Parameters.Insert(Index, x.Parameter)
                    ReFresh_Treeview()
                End If
            Else
                Dim sp As SubProgram = tv1.SelectedNode.Parent.Parent.Tag
                Dim PG As ParameterGroup = tv1.SelectedNode.Parent.Tag
                Dim p As Parameter = tv1.SelectedNode.Tag
                Dim x As New NewParameter(sp, p)
                If x.ShowDialog = DialogResult.OK Then
                    Dim Index = PG.Parameters.IndexOf(p)
                    PG.Parameters.RemoveAt(Index)
                    PG.Parameters.Insert(Index, x.Parameter)
                    ReFresh_Treeview()
                End If
            End If

        End If
    End Sub

    Private Sub Delete_ProgramToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ProgramToolStripMenuItem3.Click
        If tv1.SelectedNode.IsProgram = True Then
            Dim res = MsgBox("Do you really want to Delete it?", MsgBoxStyle.OkCancel)
            If res = MsgBoxResult.Ok Then
                Dim sp As Program = tv1.SelectedNode.Tag
                Me.Hierarchy.Programs.Remove(sp)
            End If
        Else
            MsgBox("It is not a Parameter")
        End If
        ReFresh_Treeview()
    End Sub

    Private Sub Delete_SubProgramToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles SubProgramToolStripMenuItem2.Click
        If tv1.SelectedNode.IsSubProgram = True Then
            Dim res = MsgBox("Do you really want to Delete it?", MsgBoxStyle.OkCancel)
            If res = MsgBoxResult.Ok Then
                Dim sp As Program = tv1.SelectedNode.Parent.Tag
                sp.SubPrograms.Remove(tv1.SelectedNode.Tag)
            End If
        Else
            MsgBox("It is not a Parameter")
        End If
        ReFresh_Treeview()
    End Sub

    Private Sub Delete_ParameterToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ParameterToolStripMenuItem2.Click
        If tv1.SelectedNode.IsParameter = True Then
            Dim res = MsgBox("Do you really want to Delete it?", MsgBoxStyle.OkCancel)

            If res = MsgBoxResult.Cancel Then Exit Sub
            If tv1.SelectedNode.Parent.IsSubProgram Then

                Dim sp As SubProgram = tv1.SelectedNode.Parent.Tag
                sp.Parameters.Remove(tv1.SelectedNode.Tag)
            Else
                Dim PG As ParameterGroup = tv1.SelectedNode.Parent.Tag
                PG.Parameters.Remove(tv1.SelectedNode.Tag)
            End If
            ReFresh_Treeview()
        Else
            MsgBox("It is not a Parameter")
        End If

    End Sub

#Region "Scripts"
    Private Sub CreateDefaultScriptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateDefaultScriptToolStripMenuItem.Click
        If tv1.SelectedNode.IsSubProgram Then

        End If
    End Sub

    Private Sub CreateMultipleScriptsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateMultipleScriptsToolStripMenuItem.Click

    End Sub

    Private Sub CopyScriptsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyScriptsToolStripMenuItem.Click

    End Sub

    Private Sub SaveScriptsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveScriptsToolStripMenuItem.Click

    End Sub

    Private Sub EecuteScriptsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EecuteScriptsToolStripMenuItem.Click

    End Sub



#End Region

    Private Sub ParametersIntoGroupNoIncompatibleParametersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ParametersIntoGroupNoIncompatibleParametersToolStripMenuItem.Click
        If tv1.SelectedNode.IsSubProgram Then
            Dim nodes = From x As TreeNode In tv1.SelectedNode.Nodes Where x.Checked = True
            Dim SP As SubProgram = tv1.SelectedNode.Tag
            If nodes.Count > 1 Then
                Dim Name = InputBox("Enter the name of ParmeterGroup")
                Dim Description = InputBox("Enter the description")
                Dim bd As New Basic_Description With {.Name = Name, .Description = Description}
                Dim x As New ParameterGroup With {.Description = bd}

                Dim kj As Int16 = 54
                ' Set Incomapitble 
                For Each Node In nodes
                    Dim P As Parameter = Node.Tag


                    x.Parameters.Add(P)
                    SP.Parameters.Remove(P)
                Next
                SP.ParameterGroupss.Add(x)
                ReFresh_Treeview(tv1.SelectedNode)
            End If
        End If
    End Sub

    Private Sub ParamtersIntoGroupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ParamtersIntoGroupToolStripMenuItem.Click
        If tv1.SelectedNode.IsSubProgram Then
            Dim nodes = From x As TreeNode In tv1.SelectedNode.Nodes Where x.Checked = True
            Dim SP As SubProgram = tv1.SelectedNode.Tag
            If nodes.Count > 1 Then
                Dim Name = InputBox("Enter the name of ParmeterGroup")
                Dim Description = InputBox("Enter the description")
                Dim bd As New Basic_Description With {.Name = Name, .Description = Description}
                Dim x As New ParameterGroup With {.Description = bd}

                Dim kj As Int16 = 54
                ' Set Incomapitble 
                For Each Node In nodes
                    Dim P As Parameter = Node.Tag
                    P.IncompatibleParameters.Clear()
                    For Each nod2 In nodes

                        If Node IsNot nod2 Then
                            Dim p1 As Parameter = nod2.Tag
                            P.IncompatibleParameters.Add(p1.Symbol)
                        End If
                    Next
                    x.Parameters.Add(P)
                    SP.Parameters.Remove(P)
                Next
                SP.ParameterGroupss.Add(x)
                ReFresh_Treeview(tv1.SelectedNode)
            End If
        End If
    End Sub

#Region "Local USers"
    Private Sub ReoveLocalUsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReoveLocalUsersToolStripMenuItem.Click
        Dim str As New StringBuilder

        Dim Users = FileSystemPermissions.Get_All_Users()
        For Each User In Users
            str.Append("Remove-LocalUser -Name " & Chr(34) & User.Name & Chr(34)).AppendLine()
        Next
        Clipboard.SetText(str.ToString)
    End Sub

    Private Sub CreatePwdToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreatePwdToolStripMenuItem.Click
        Dim File = Szunyi.IO.Pick_Up.File
        Dim str As New StringBuilder
        Dim str2 As New System.Text.StringBuilder
        For Each Line In File.Parse_Lines
            Dim pwd = Membership.GeneratePassword(36, 12)
            str.Append("$Password = ConvertTo-SecureString " & Chr(34) & pwd & Chr(34) & " -AsPlainText -Force").AppendLine()
            str.Append("New-LocalUser -Name " & Chr(34) & Line & Chr(34) & " -Password $Password").AppendLine()
            str2.Append(Line & vbTab & pwd).AppendLine()
        Next
        Clipboard.SetText(str.ToString & vbCrLf & str2.ToString)
    End Sub

    Private Sub SetQuotaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetQuotaToolStripMenuItem.Click
        '   Set-FsrmQuota -Path "C:\Shares" 
        Dim File = Szunyi.IO.Pick_Up.File
        Dim dir = Szunyi.IO.Pick_Up.Directory
        Dim str As New StringBuilder
        Dim Max As Long = InputBox("Enter the size in bytes")
        Dim Th As Long = Max * 0.9
        Dim d = InputBox("Enter the drive")
        Dim str2 As New System.Text.StringBuilder
        For Each Line In File.Parse_Lines

            str.Append("fsutil quota  modify D: " & Th & " " & Max & " " & Chr(34) & Line & Chr(34)).AppendLine()
        Next
        Clipboard.SetText(str.ToString & vbCrLf & str2.ToString)
    End Sub

    Private Sub GetProToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GetProToolStripMenuItem.Click
        Dim j = Environment.ProcessorCount
        Dim kj As Int16 = 32
    End Sub
    Private Sub AddGroupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddGroupToolStripMenuItem.Click
        'Add-LocalGroupMember -Member "Bartal Attila" -Name Ph.D
        Dim File = Szunyi.IO.Pick_Up.File
        Dim s = InputBox("Enter Group Name")
        Dim str As New System.Text.StringBuilder
        For Each Line In File.Parse_Lines
            str.Append("Add-LocalGroupMember -Member " & Chr(34) & Line & Chr(34) & " -Name " & s & vbCrLf)
        Next
        Clipboard.SetText(str.ToString)
    End Sub

    Private Sub GetAllUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GetAllUserToolStripMenuItem.Click
        Dim Users = FileSystemPermissions.Get_All_Users()
        Dim x1 = (From x In Users Where x.Disabled = False).ToList
        Dim x2 = From x In Users Where x.Disabled = True

        Dim BasicFolder = Szunyi.IO.Pick_Up.Directory
        For Each User In x1
            Dim basicDIr As New DirectoryInfo(BasicFolder.FullName & "\" & User.Name)

            Dim PrivateDIr As New DirectoryInfo(basicDIr.FullName & "\private")


            Dim publicDir As New DirectoryInfo(basicDIr.FullName & "\public")
            '    publicDir.Create()
            '    PrivateDIr.Create()
            '   basicDIr.Create()
            '  FileSystemPermissions.SetPublicteDirectory(User.Name, basicDIr)
            ' FileSystemPermissions.SetPrivateDIrectory(User.DomainwUser, PrivateDIr)
            ' FileSystemPermissions.SetPublicteDirectory(User.DomainwUser, publicDir)
            ' FileSystemPermissions.RemoveDirectorySecurity("Hitelesített felhasználók", PrivateDIr)
            FileSystemPermissions.CreatePublicteDirectory(User.Name, basicDIr)
            FileSystemPermissions.CreatePrivateDIrectory(User.DomainwUser, PrivateDIr)
            FileSystemPermissions.CreatePublicteDirectory(User.DomainwUser, publicDir)
            Dim kj As Int16 = 54
        Next
    End Sub
#End Region
#Region "tv1"
    Private Sub tv1_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles tv1.AfterCheck

        For Each subnode As TreeNode In e.Node.Nodes
            subnode.Checked = e.Node.Checked
        Next

    End Sub

    Private Sub ReFresh_Treeview(Optional Node As TreeNode = Nothing)

        If IsNothing(Node) = False Then
            Dim path = Node.FullPath
            tv1.Nodes.Clear()
            tv1.Nodes.AddRange(GetTreeNodes(Me.Hierarchy).ToArray)
            Dim x = tv1.Nodes.GetNodeFromPath(path)
            tv1.SelectedNode = x
        End If
    End Sub
#End Region
#Region "Load"
    Private Sub Load_Hierarchy(File As FileInfo)
        Me.Hierarchy = Szunyi.IO.XML.Deserialize(Of Hierarchy)(File)
        tv1.Nodes.Clear()
        tv1.Nodes.AddRange(GetTreeNodes(Me.Hierarchy).ToArray)
    End Sub
    Private Sub Load_HierarchyToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles HierarchyToolStripMenuItem1.Click
        Dim File = Szunyi.IO.Pick_Up.XML
        If IsNothing(File) = True Then Exit Sub
        Me.File = File
        Load_Hierarchy(File)
    End Sub
    Private Sub Load_ProgramsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProgramsToolStripMenuItem.Click
        Dim Files = Szunyi.IO.Pick_Up.XMLs.ToList
        If Files.Count = 0 Then Exit Sub
        If IsNothing(Hierarchy) = True Then Me.Hierarchy = New Hierarchy
        For Each F In Files
            Try
                Dim pr = Szunyi.IO.XML.Deserialize(Of Program)(F)
                Me.Hierarchy.Programs.Add(pr)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        Next
        ReFresh_Treeview()
    End Sub
    Private Sub ReloadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReloadToolStripMenuItem.Click
        Load_Hierarchy(Me.File)
    End Sub

    Private Sub ParametersToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ParametersToolStripMenuItem1.Click

    End Sub

    Private Sub NameSzymbolDescriptionFileExtensionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NameSzymbolDescriptionFileExtensionToolStripMenuItem.Click
        If tv1.SelectedNode.IsSubProgram_OR_ParameterGroup Then

            Dim File = Szunyi.IO.Pick_Up.File(Szunyi.IO.File_Extensions.All_TAB_Like)
            For Each Line In File.Parse_Lines
                Dim s = Split(Line, vbTab)
                Dim bd As New Basic_Description With {.Name = s(0), .Description = (s(2))}
                Dim x As New Parameter With {.Name = s(0), .Symbol = s(1), .Description = bd, .Type = ParameterType.File, .File_ReName = s(3)}
                If tv1.SelectedNode.IsSubProgram Then
                    Dim SP As SubProgram = tv1.SelectedNode.Tag
                    SP.Parameters.Add(x)
                Else
                    Dim PG As ParameterGroup = tv1.SelectedNode.Tag
                    PG.Parameters.Add(x)
                End If
            Next
            ReFresh_Treeview(tv1.SelectedNode)
        End If
    End Sub

    Private Sub FullToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FullToolStripMenuItem.Click
        Dim Files = Szunyi.IO.Pick_Up.TabLikes.ToList
        For Each f In Files
            For Each Line In f.ParseToArray(vbTab, 1)
                Dim P = Me.Hierarchy.Get_Program(Line(0)) ' 0 Program
                If IsNothing(P) = False Then
                    Dim SP = P.Get_Sub_Program(Line(1)) ' 1 SubProgram
                    If IsNothing(SP) = False Then
                        If Line(2) <> "" Then ' 2 Parameter Group
                            Dim PG = SP.Get_ParameterGroup(Line(3))
                            If IsNothing(PG) = True Then
                                Dim bd As New Basic_Description With {.Name = Line(3), .Description = Line(3)}
                                PG = New ParameterGroup With {.Description = bd}
                            End If
                            Dim p As New Parameter With {.s}
                        End If
                    End If
                End If
            Next
        Next
    End Sub


#End Region
End Class
