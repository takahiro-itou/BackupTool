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
        Me.imlExplorer = New System.Windows.Forms.ImageList(Me.components)
        Me.mnuMainMenu = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileOpenSelect = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuOpenAnime = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpenRecord = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tspProgressRoot = New System.Windows.Forms.ToolStripProgressBar()
        Me.tspProgressDir = New System.Windows.Forms.ToolStripProgressBar()
        Me.tsStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.trvDirectory = New System.Windows.Forms.TreeView()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.lsvFile = New System.Windows.Forms.ListView()
        Me.colFileName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colFileSize = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNumFolder = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNumFile = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colWmvSize = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMpgSize = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNumWmv = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNumMpg = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTimeStamp = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.mnuMainMenu.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'imlExplorer
        '
        Me.imlExplorer.ImageStream = CType(resources.GetObject("imlExplorer.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlExplorer.TransparentColor = System.Drawing.Color.Transparent
        Me.imlExplorer.Images.SetKeyName(0, "CLSDFLDS.BMP")
        Me.imlExplorer.Images.SetKeyName(1, "OPENFLDS.BMP")
        Me.imlExplorer.Images.SetKeyName(2, "DOCS.BMP")
        '
        'mnuMainMenu
        '
        Me.mnuMainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile})
        resources.ApplyResources(Me.mnuMainMenu, "mnuMainMenu")
        Me.mnuMainMenu.Name = "mnuMainMenu"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFileOpenSelect, Me.ToolStripMenuItem1, Me.mnuOpenAnime, Me.mnuOpenRecord, Me.ToolStripMenuItem2, Me.mnuFileExit})
        Me.mnuFile.Name = "mnuFile"
        resources.ApplyResources(Me.mnuFile, "mnuFile")
        '
        'mnuFileOpenSelect
        '
        Me.mnuFileOpenSelect.Name = "mnuFileOpenSelect"
        resources.ApplyResources(Me.mnuFileOpenSelect, "mnuFileOpenSelect")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'mnuOpenAnime
        '
        Me.mnuOpenAnime.Name = "mnuOpenAnime"
        resources.ApplyResources(Me.mnuOpenAnime, "mnuOpenAnime")
        '
        'mnuOpenRecord
        '
        Me.mnuOpenRecord.Name = "mnuOpenRecord"
        resources.ApplyResources(Me.mnuOpenRecord, "mnuOpenRecord")
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        '
        'mnuFileExit
        '
        Me.mnuFileExit.Name = "mnuFileExit"
        resources.ApplyResources(Me.mnuFileExit, "mnuFileExit")
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tspProgressRoot, Me.tspProgressDir, Me.tsStatusLabel})
        resources.ApplyResources(Me.StatusStrip1, "StatusStrip1")
        Me.StatusStrip1.Name = "StatusStrip1"
        '
        'tspProgressRoot
        '
        Me.tspProgressRoot.Name = "tspProgressRoot"
        resources.ApplyResources(Me.tspProgressRoot, "tspProgressRoot")
        '
        'tspProgressDir
        '
        Me.tspProgressDir.Name = "tspProgressDir"
        resources.ApplyResources(Me.tspProgressDir, "tspProgressDir")
        '
        'tsStatusLabel
        '
        Me.tsStatusLabel.Name = "tsStatusLabel"
        resources.ApplyResources(Me.tsStatusLabel, "tsStatusLabel")
        '
        'trvDirectory
        '
        resources.ApplyResources(Me.trvDirectory, "trvDirectory")
        Me.trvDirectory.ImageList = Me.imlExplorer
        Me.trvDirectory.Name = "trvDirectory"
        '
        'Splitter1
        '
        resources.ApplyResources(Me.Splitter1, "Splitter1")
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.TabStop = False
        '
        'lsvFile
        '
        Me.lsvFile.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colFileName, Me.colFileSize, Me.colNumFolder, Me.colNumFile, Me.colWmvSize, Me.colMpgSize, Me.colNumWmv, Me.colNumMpg, Me.colTimeStamp})
        resources.ApplyResources(Me.lsvFile, "lsvFile")
        Me.lsvFile.HideSelection = False
        Me.lsvFile.Name = "lsvFile"
        Me.lsvFile.UseCompatibleStateImageBehavior = False
        Me.lsvFile.View = System.Windows.Forms.View.Details
        '
        'colFileName
        '
        resources.ApplyResources(Me.colFileName, "colFileName")
        '
        'colFileSize
        '
        resources.ApplyResources(Me.colFileSize, "colFileSize")
        '
        'colNumFolder
        '
        resources.ApplyResources(Me.colNumFolder, "colNumFolder")
        '
        'colNumFile
        '
        resources.ApplyResources(Me.colNumFile, "colNumFile")
        '
        'colWmvSize
        '
        resources.ApplyResources(Me.colWmvSize, "colWmvSize")
        '
        'colMpgSize
        '
        resources.ApplyResources(Me.colMpgSize, "colMpgSize")
        '
        'colNumWmv
        '
        resources.ApplyResources(Me.colNumWmv, "colNumWmv")
        '
        'colNumMpg
        '
        resources.ApplyResources(Me.colNumMpg, "colNumMpg")
        '
        'colTimeStamp
        '
        resources.ApplyResources(Me.colTimeStamp, "colTimeStamp")
        '
        'Explorer
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.lsvFile)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.trvDirectory)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.mnuMainMenu)
        Me.MainMenuStrip = Me.mnuMainMenu
        Me.Name = "Explorer"
        Me.mnuMainMenu.ResumeLayout(False)
        Me.mnuMainMenu.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents imlExplorer As System.Windows.Forms.ImageList
    Friend WithEvents mnuMainMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileOpenSelect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents trvDirectory As System.Windows.Forms.TreeView
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents lsvFile As System.Windows.Forms.ListView
    Friend WithEvents colFileName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colFileSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNumFolder As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNumFile As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTimeStamp As System.Windows.Forms.ColumnHeader
    Friend WithEvents tspProgressRoot As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents tsStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tspProgressDir As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents colNumWmv As ColumnHeader
    Friend WithEvents colWmvSize As ColumnHeader
    Friend WithEvents colMpgSize As ColumnHeader
    Friend WithEvents colNumMpg As ColumnHeader
    Friend WithEvents mnuOpenAnime As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents mnuOpenRecord As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents mnuFileExit As ToolStripMenuItem
End Class
