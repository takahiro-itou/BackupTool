<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Explorer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Explorer))
        Me.trvDirectory = New System.Windows.Forms.TreeView()
        Me.imlExplorer = New System.Windows.Forms.ImageList(Me.components)
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.lsvFile = New System.Windows.Forms.ListView()
        Me.mnuMainMenu = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenDirectoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMainMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'trvDirectory
        '
        Me.trvDirectory.Dock = System.Windows.Forms.DockStyle.Left
        Me.trvDirectory.ImageIndex = 0
        Me.trvDirectory.ImageList = Me.imlExplorer
        Me.trvDirectory.Location = New System.Drawing.Point(0, 24)
        Me.trvDirectory.Name = "trvDirectory"
        Me.trvDirectory.SelectedImageIndex = 0
        Me.trvDirectory.Size = New System.Drawing.Size(217, 237)
        Me.trvDirectory.TabIndex = 0
        '
        'imlExplorer
        '
        Me.imlExplorer.ImageStream = CType(resources.GetObject("imlExplorer.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlExplorer.TransparentColor = System.Drawing.Color.Transparent
        Me.imlExplorer.Images.SetKeyName(0, "CLSDFLDS.BMP")
        Me.imlExplorer.Images.SetKeyName(1, "OPENFLDS.BMP")
        Me.imlExplorer.Images.SetKeyName(2, "DOCS.BMP")
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(217, 24)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(9, 237)
        Me.Splitter1.TabIndex = 3
        Me.Splitter1.TabStop = False
        '
        'lsvFile
        '
        Me.lsvFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvFile.Location = New System.Drawing.Point(226, 24)
        Me.lsvFile.Name = "lsvFile"
        Me.lsvFile.Size = New System.Drawing.Size(542, 237)
        Me.lsvFile.TabIndex = 4
        Me.lsvFile.UseCompatibleStateImageBehavior = False
        '
        'mnuMainMenu
        '
        Me.mnuMainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.mnuMainMenu.Location = New System.Drawing.Point(0, 0)
        Me.mnuMainMenu.Name = "mnuMainMenu"
        Me.mnuMainMenu.Size = New System.Drawing.Size(768, 24)
        Me.mnuMainMenu.TabIndex = 5
        Me.mnuMainMenu.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenDirectoryToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'OpenDirectoryToolStripMenuItem
        '
        Me.OpenDirectoryToolStripMenuItem.Name = "OpenDirectoryToolStripMenuItem"
        Me.OpenDirectoryToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.OpenDirectoryToolStripMenuItem.Text = "Open &Directory"
        '
        'Explorer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(768, 261)
        Me.Controls.Add(Me.lsvFile)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.trvDirectory)
        Me.Controls.Add(Me.mnuMainMenu)
        Me.MainMenuStrip = Me.mnuMainMenu
        Me.Name = "Explorer"
        Me.Text = "Explorer"
        Me.mnuMainMenu.ResumeLayout(False)
        Me.mnuMainMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents trvDirectory As System.Windows.Forms.TreeView
    Friend WithEvents imlExplorer As System.Windows.Forms.ImageList
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents lsvFile As System.Windows.Forms.ListView
    Friend WithEvents mnuMainMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenDirectoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
