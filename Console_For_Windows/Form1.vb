Imports Szunyi.IO.Export_Module

Public Class Form1
    Public Property Hierarchy As New Hierarchy
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
        Dim File = Szunyi.IO.File_Extensions.Xml.File_To_Save()
        txt.Export_Text(File)
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
            Next
            out.Add(t)
        Next
        Return out
    End Function

    Private Sub NewSubProgramToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubProgramToolStripMenuItem.Click
        If IsNothing(tv1.SelectedNode) = False Then
            If tv1.SelectedNode.IsProgram = True Then
                Dim Pr As Program = tv1.SelectedNode.Tag
                Dim x As New NewProgram(Hierarchy, Pr, Type.New_SubProgram)
                x.cbProgramType.Enabled = False
                If x.ShowDialog = DialogResult.OK Then
                    Dim p As Program = tv1.SelectedNode.Tag
                    p.SubPrograms.Add(New SubProgram With {.Description = x.P.Description})
                    ReFresh_Treeview()
                End If
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
                End If
            End If
        End If
        ReFresh_Treeview()
    End Sub
    Private Sub Load_HierarchyToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles HierarchyToolStripMenuItem1.Click
        Dim File = Szunyi.IO.Pick_Up.XML
        If IsNothing(File) = True Then Exit Sub
        Me.Hierarchy = Szunyi.IO.XML.Deserialize(Of Hierarchy)(File)
        tv1.Nodes.Clear()
        tv1.Nodes.AddRange(GetTreeNodes(Me.Hierarchy).ToArray)
    End Sub
    Private Sub Load_ProgramsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProgramsToolStripMenuItem.Click
        Dim Files = Szunyi.IO.Pick_Up.XMLs.ToList
        If Files.Count = 0 Then Exit Sub
        If IsNothing(Hierarchy) = True Then Me.Hierarchy = New Hierarchy
        For Each File In Files
            Try
                Dim pr = Szunyi.IO.XML.Deserialize(Of Program)(File)
                Me.Hierarchy.Programs.Add(pr)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        Next
        ReFresh_Treeview()
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
            Dim sp As SubProgram = tv1.SelectedNode.Parent.Tag
            Dim p As Parameter = tv1.SelectedNode.Tag
            Dim x As New NewParameter(sp, p)
            If x.ShowDialog = DialogResult.OK Then
                Dim Index = sp.Parameters.IndexOf(p)
                sp.Parameters.RemoveAt(Index)
                sp.Parameters.Insert(Index, x.Parameter)
                ReFresh_Treeview()
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
            If res = MsgBoxResult.Ok Then
                Dim sp As SubProgram = tv1.SelectedNode.Parent.Tag
                sp.Parameters.Remove(tv1.SelectedNode.Tag)
            End If
        Else
            MsgBox("It is not a Parameter")
        End If
        ReFresh_Treeview()
    End Sub
    Private Sub ReFresh_Treeview(Optional Node As TreeNode = Nothing)
        tv1.Nodes.Clear()
        tv1.Nodes.AddRange(GetTreeNodes(Me.Hierarchy).ToArray)
        If IsNothing(Node) = False Then

        End If
    End Sub

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
End Class
