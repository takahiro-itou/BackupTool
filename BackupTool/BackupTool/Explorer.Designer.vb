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
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.lsvFile = New System.Windows.Forms.ListView()
        Me.imlExplorer = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        '
        'trvDirectory
        '
        Me.trvDirectory.Location = New System.Drawing.Point(27, 28)
        Me.trvDirectory.Name = "trvDirectory"
        Me.trvDirectory.Size = New System.Drawing.Size(217, 141)
        Me.trvDirectory.TabIndex = 0
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(0, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(9, 261)
        Me.Splitter1.TabIndex = 1
        Me.Splitter1.TabStop = False
        '
        'lsvFile
        '
        Me.lsvFile.Location = New System.Drawing.Point(309, 42)
        Me.lsvFile.Name = "lsvFile"
        Me.lsvFile.Size = New System.Drawing.Size(320, 207)
        Me.lsvFile.TabIndex = 2
        Me.lsvFile.UseCompatibleStateImageBehavior = False
        '
        'imlExplorer
        '
        Me.imlExplorer.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imlExplorer.ImageSize = New System.Drawing.Size(16, 16)
        Me.imlExplorer.TransparentColor = System.Drawing.Color.Transparent
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
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents lsvFile As System.Windows.Forms.ListView
    Friend WithEvents imlExplorer As System.Windows.Forms.ImageList
End Class
