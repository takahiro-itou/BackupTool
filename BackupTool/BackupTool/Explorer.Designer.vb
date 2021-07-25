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
        Me.trvDirectory = New System.Windows.Forms.TreeView()
        Me.imlExplorer = New System.Windows.Forms.ImageList(Me.components)
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.lsvFile = New System.Windows.Forms.ListView()
        Me.SuspendLayout()
        '
        'trvDirectory
        '
        Me.trvDirectory.Dock = System.Windows.Forms.DockStyle.Left
        Me.trvDirectory.Location = New System.Drawing.Point(0, 0)
        Me.trvDirectory.Name = "trvDirectory"
        Me.trvDirectory.Size = New System.Drawing.Size(217, 261)
        Me.trvDirectory.TabIndex = 0
        '
        'imlExplorer
        '
        Me.imlExplorer.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imlExplorer.ImageSize = New System.Drawing.Size(16, 16)
        Me.imlExplorer.TransparentColor = System.Drawing.Color.Transparent
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(217, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(9, 261)
        Me.Splitter1.TabIndex = 3
        Me.Splitter1.TabStop = False
        '
        'lsvFile
        '
        Me.lsvFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvFile.Location = New System.Drawing.Point(226, 0)
        Me.lsvFile.Name = "lsvFile"
        Me.lsvFile.Size = New System.Drawing.Size(542, 261)
        Me.lsvFile.TabIndex = 4
        Me.lsvFile.UseCompatibleStateImageBehavior = False
        '
        'Explorer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(768, 261)
        Me.Controls.Add(Me.lsvFile)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.trvDirectory)
        Me.Name = "Explorer"
        Me.Text = "Explorer"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents trvDirectory As System.Windows.Forms.TreeView
    Friend WithEvents imlExplorer As System.Windows.Forms.ImageList
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents lsvFile As System.Windows.Forms.ListView
End Class
