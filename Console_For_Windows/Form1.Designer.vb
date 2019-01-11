<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tv1 = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgramToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubProgramToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ParameterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HierarchyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgramToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ParametersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HierarchyToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgramsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ParametersToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgramToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubProgramToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ParameterToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgramToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubProgramToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ParameterToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ScriptsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateDefaultScriptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateMultipleScriptsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyScriptsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveScriptsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EecuteScriptsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.dgvScripts = New System.Windows.Forms.DataGridView()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dgvScripts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tv1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(800, 426)
        Me.SplitContainer1.SplitterDistance = 266
        Me.SplitContainer1.TabIndex = 0
        '
        'tv1
        '
        Me.tv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tv1.ImageIndex = 0
        Me.tv1.ImageList = Me.ImageList1
        Me.tv1.Location = New System.Drawing.Point(0, 0)
        Me.tv1.Name = "tv1"
        Me.tv1.SelectedImageIndex = 0
        Me.tv1.Size = New System.Drawing.Size(266, 426)
        Me.tv1.TabIndex = 0
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "linux.png")
        Me.ImageList1.Images.SetKeyName(1, "java.png")
        Me.ImageList1.Images.SetKeyName(2, "py.png")
        Me.ImageList1.Images.SetKeyName(3, "commandprompt.jpg")
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.SaveToolStripMenuItem, Me.CopyToolStripMenuItem, Me.LoadToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ScriptsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgramToolStripMenuItem, Me.SubProgramToolStripMenuItem, Me.ParameterToolStripMenuItem})
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.AddToolStripMenuItem.Text = "Add "
        '
        'ProgramToolStripMenuItem
        '
        Me.ProgramToolStripMenuItem.Name = "ProgramToolStripMenuItem"
        Me.ProgramToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.ProgramToolStripMenuItem.Text = "Program"
        '
        'SubProgramToolStripMenuItem
        '
        Me.SubProgramToolStripMenuItem.Name = "SubProgramToolStripMenuItem"
        Me.SubProgramToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.SubProgramToolStripMenuItem.Text = "SubProgram"
        '
        'ParameterToolStripMenuItem
        '
        Me.ParameterToolStripMenuItem.Name = "ParameterToolStripMenuItem"
        Me.ParameterToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.ParameterToolStripMenuItem.Text = "Parameter"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HierarchyToolStripMenuItem, Me.ProgramToolStripMenuItem1, Me.ParametersToolStripMenuItem})
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'HierarchyToolStripMenuItem
        '
        Me.HierarchyToolStripMenuItem.Name = "HierarchyToolStripMenuItem"
        Me.HierarchyToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.HierarchyToolStripMenuItem.Text = "Hierarchy"
        '
        'ProgramToolStripMenuItem1
        '
        Me.ProgramToolStripMenuItem1.Name = "ProgramToolStripMenuItem1"
        Me.ProgramToolStripMenuItem1.Size = New System.Drawing.Size(133, 22)
        Me.ProgramToolStripMenuItem1.Text = "Program"
        '
        'ParametersToolStripMenuItem
        '
        Me.ParametersToolStripMenuItem.Name = "ParametersToolStripMenuItem"
        Me.ParametersToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.ParametersToolStripMenuItem.Text = "Parameters"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'LoadToolStripMenuItem
        '
        Me.LoadToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HierarchyToolStripMenuItem1, Me.ProgramsToolStripMenuItem, Me.ParametersToolStripMenuItem1})
        Me.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem"
        Me.LoadToolStripMenuItem.Size = New System.Drawing.Size(45, 20)
        Me.LoadToolStripMenuItem.Text = "Load"
        '
        'HierarchyToolStripMenuItem1
        '
        Me.HierarchyToolStripMenuItem1.Name = "HierarchyToolStripMenuItem1"
        Me.HierarchyToolStripMenuItem1.Size = New System.Drawing.Size(133, 22)
        Me.HierarchyToolStripMenuItem1.Text = "Hierarchy"
        '
        'ProgramsToolStripMenuItem
        '
        Me.ProgramsToolStripMenuItem.Name = "ProgramsToolStripMenuItem"
        Me.ProgramsToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.ProgramsToolStripMenuItem.Text = "Programs"
        '
        'ParametersToolStripMenuItem1
        '
        Me.ParametersToolStripMenuItem1.Name = "ParametersToolStripMenuItem1"
        Me.ParametersToolStripMenuItem1.Size = New System.Drawing.Size(133, 22)
        Me.ParametersToolStripMenuItem1.Text = "Parameters"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgramToolStripMenuItem2, Me.SubProgramToolStripMenuItem1, Me.ParameterToolStripMenuItem1})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ProgramToolStripMenuItem2
        '
        Me.ProgramToolStripMenuItem2.Name = "ProgramToolStripMenuItem2"
        Me.ProgramToolStripMenuItem2.Size = New System.Drawing.Size(140, 22)
        Me.ProgramToolStripMenuItem2.Text = "Program"
        '
        'SubProgramToolStripMenuItem1
        '
        Me.SubProgramToolStripMenuItem1.Name = "SubProgramToolStripMenuItem1"
        Me.SubProgramToolStripMenuItem1.Size = New System.Drawing.Size(140, 22)
        Me.SubProgramToolStripMenuItem1.Text = "SubProgram"
        '
        'ParameterToolStripMenuItem1
        '
        Me.ParameterToolStripMenuItem1.Name = "ParameterToolStripMenuItem1"
        Me.ParameterToolStripMenuItem1.Size = New System.Drawing.Size(140, 22)
        Me.ParameterToolStripMenuItem1.Text = "Parameter"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgramToolStripMenuItem3, Me.SubProgramToolStripMenuItem2, Me.ParameterToolStripMenuItem2})
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ProgramToolStripMenuItem3
        '
        Me.ProgramToolStripMenuItem3.Name = "ProgramToolStripMenuItem3"
        Me.ProgramToolStripMenuItem3.Size = New System.Drawing.Size(140, 22)
        Me.ProgramToolStripMenuItem3.Text = "Program"
        '
        'SubProgramToolStripMenuItem2
        '
        Me.SubProgramToolStripMenuItem2.Name = "SubProgramToolStripMenuItem2"
        Me.SubProgramToolStripMenuItem2.Size = New System.Drawing.Size(140, 22)
        Me.SubProgramToolStripMenuItem2.Text = "SubProgram"
        '
        'ParameterToolStripMenuItem2
        '
        Me.ParameterToolStripMenuItem2.Name = "ParameterToolStripMenuItem2"
        Me.ParameterToolStripMenuItem2.Size = New System.Drawing.Size(140, 22)
        Me.ParameterToolStripMenuItem2.Text = "Parameter"
        '
        'ScriptsToolStripMenuItem
        '
        Me.ScriptsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreateDefaultScriptToolStripMenuItem, Me.CreateMultipleScriptsToolStripMenuItem, Me.CopyScriptsToolStripMenuItem, Me.SaveScriptsToolStripMenuItem, Me.EecuteScriptsToolStripMenuItem})
        Me.ScriptsToolStripMenuItem.Name = "ScriptsToolStripMenuItem"
        Me.ScriptsToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.ScriptsToolStripMenuItem.Text = "Scripts"
        '
        'CreateDefaultScriptToolStripMenuItem
        '
        Me.CreateDefaultScriptToolStripMenuItem.Name = "CreateDefaultScriptToolStripMenuItem"
        Me.CreateDefaultScriptToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.CreateDefaultScriptToolStripMenuItem.Text = "Create Default Script"
        '
        'CreateMultipleScriptsToolStripMenuItem
        '
        Me.CreateMultipleScriptsToolStripMenuItem.Name = "CreateMultipleScriptsToolStripMenuItem"
        Me.CreateMultipleScriptsToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.CreateMultipleScriptsToolStripMenuItem.Text = "Create Multiple Scripts"
        '
        'CopyScriptsToolStripMenuItem
        '
        Me.CopyScriptsToolStripMenuItem.Name = "CopyScriptsToolStripMenuItem"
        Me.CopyScriptsToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.CopyScriptsToolStripMenuItem.Text = "Copy Scripts"
        '
        'SaveScriptsToolStripMenuItem
        '
        Me.SaveScriptsToolStripMenuItem.Name = "SaveScriptsToolStripMenuItem"
        Me.SaveScriptsToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.SaveScriptsToolStripMenuItem.Text = "Save Scripts"
        '
        'EecuteScriptsToolStripMenuItem
        '
        Me.EecuteScriptsToolStripMenuItem.Name = "EecuteScriptsToolStripMenuItem"
        Me.EecuteScriptsToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.EecuteScriptsToolStripMenuItem.Text = "Eecute Scripts"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.dgvScripts)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.TextBox1)
        Me.SplitContainer2.Size = New System.Drawing.Size(530, 426)
        Me.SplitContainer2.SplitterDistance = 229
        Me.SplitContainer2.TabIndex = 0
        '
        'TextBox1
        '
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Location = New System.Drawing.Point(0, 0)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(530, 193)
        Me.TextBox1.TabIndex = 0
        '
        'dgvScripts
        '
        Me.dgvScripts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvScripts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvScripts.Location = New System.Drawing.Point(0, 0)
        Me.dgvScripts.Name = "dgvScripts"
        Me.dgvScripts.Size = New System.Drawing.Size(530, 229)
        Me.dgvScripts.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dgvScripts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProgramToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SubProgramToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ParameterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tv1 As TreeView
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HierarchyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProgramToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ParametersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LoadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HierarchyToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ProgramsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ParametersToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProgramToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents SubProgramToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ParameterToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProgramToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents SubProgramToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ParameterToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ScriptsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreateDefaultScriptToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreateMultipleScriptsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyScriptsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveScriptsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EecuteScriptsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents dgvScripts As DataGridView
    Friend WithEvents TextBox1 As TextBox
End Class
