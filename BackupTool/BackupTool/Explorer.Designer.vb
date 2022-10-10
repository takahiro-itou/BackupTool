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
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenDirectoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.mnuMainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.mnuMainMenu.Location = New System.Drawing.Point(0, 0)
        Me.mnuMainMenu.Name = "mnuMainMenu"
        Me.mnuMainMenu.Size = New System.Drawing.Size(1104, 24)
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
        Me.OpenDirectoryToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.OpenDirectoryToolStripMenuItem.Text = "Open &Directory"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tspProgressRoot, Me.tspProgressDir, Me.tsStatusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 479)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1104, 22)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tspProgressRoot
        '
        Me.tspProgressRoot.Name = "tspProgressRoot"
        Me.tspProgressRoot.Size = New System.Drawing.Size(200, 16)
        '
        'tspProgressDir
        '
        Me.tspProgressDir.Name = "tspProgressDir"
        Me.tspProgressDir.Size = New System.Drawing.Size(200, 16)
        '
        'tsStatusLabel
        '
        Me.tsStatusLabel.Name = "tsStatusLabel"
        Me.tsStatusLabel.Size = New System.Drawing.Size(0, 17)
        '
        'trvDirectory
        '
        Me.trvDirectory.Dock = System.Windows.Forms.DockStyle.Left
        Me.trvDirectory.ImageIndex = 0
        Me.trvDirectory.ImageList = Me.imlExplorer
        Me.trvDirectory.Location = New System.Drawing.Point(0, 24)
        Me.trvDirectory.Name = "trvDirectory"
        Me.trvDirectory.SelectedImageIndex = 0
        Me.trvDirectory.Size = New System.Drawing.Size(256, 455)
        Me.trvDirectory.TabIndex = 7
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(256, 24)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(15, 455)
        Me.Splitter1.TabIndex = 8
        Me.Splitter1.TabStop = False
        '
        'lsvFile
        '
        Me.lsvFile.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colFileName, Me.colFileSize, Me.colNumFolder, Me.colNumFile, Me.colWmvSize, Me.colMpgSize, Me.colNumWmv, Me.colNumMpg, Me.colTimeStamp})
        Me.lsvFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvFile.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lsvFile.HideSelection = False
        Me.lsvFile.Location = New System.Drawing.Point(271, 24)
        Me.lsvFile.Name = "lsvFile"
        Me.lsvFile.Size = New System.Drawing.Size(833, 455)
        Me.lsvFile.TabIndex = 9
        Me.lsvFile.UseCompatibleStateImageBehavior = False
        Me.lsvFile.View = System.Windows.Forms.View.Details
        '
        'colFileName
        '
        Me.colFileName.Text = "名前"
        Me.colFileName.Width = 192
        '
        'colFileSize
        '
        Me.colFileSize.Text = "サイズ"
        Me.colFileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colFileSize.Width = 112
        '
        'colNumFolder
        '
        Me.colNumFolder.Text = "フォルダ数"
        Me.colNumFolder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'colNumFile
        '
        Me.colNumFile.Text = "ファイル数"
        Me.colNumFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'colWmvSize
        '
        Me.colWmvSize.Text = "wmv サイズ"
        Me.colWmvSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colWmvSize.Width = 80
        '
        'colMpgSize
        '
        Me.colMpgSize.Text = "mpg サイズ"
        Me.colMpgSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colMpgSize.Width = 80
        '
        'colNumWmv
        '
        Me.colNumWmv.Text = "wmv 数"
        Me.colNumWmv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'colNumMpg
        '
        Me.colNumMpg.Text = "mpg 数"
        Me.colNumMpg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'colTimeStamp
        '
        Me.colTimeStamp.Text = "更新日時"
        Me.colTimeStamp.Width = 100
        '
        'Explorer
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1104, 501)
        Me.Controls.Add(Me.lsvFile)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.trvDirectory)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.mnuMainMenu)
        Me.MainMenuStrip = Me.mnuMainMenu
        Me.Name = "Explorer"
        Me.Text = "Explorer"
        Me.mnuMainMenu.ResumeLayout(False)
        Me.mnuMainMenu.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents imlExplorer As System.Windows.Forms.ImageList
    Friend WithEvents mnuMainMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenDirectoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
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
End Class
