Public Class Explorer

    'リストビュー
    Const NAME_COLUMN As Long = 0
    Const TYPE_COLUMN As Long = 1
    Const SIZE_COLUMN As Long = 2
    Const DATE_COLUMN As Long = 3

    Private mblnFlagMoveSplitter As Boolean
    Const mcsglSplitterLimit As Single = 500
    Const mclngSplitterWidth As Long = 40

    'ディレクトリツリー
    Private mobjDirectoryTree As CDirectoryTree
    Private mstrRootDirectory As String

    'ソート
    Private mlngCurDirectory As Long
    Private mlngSortKey As Long
    Private mlngSortOrder As ListSortOrderConstants

    '
    Private mobjPrevNode As TreeNode
    Private mlngPrevViewMode As Long

    'SortOrder constants
    Public Enum ListSortOrderConstants

        'Ascending
        lvwAscending = 0  '&H0

        'Descending
        lvwDescending = 1  '&H1
    End Enum

    ' イメージリスト
    Public Enum ItemImage
        ClosedFolder = 0
        OpenedFolder = 1
        File = 2
    End Enum

    '******************************************************************************
    'パブリックプロシージャ
    Public Sub MakeDirectoryTree(ByVal strRootDir As String, _
        ByVal blnInitTree As Boolean, ByVal blnProcessSubDirectory As Boolean)
        '------------------------------------------------------------------------------
        '指定したディレクトリをルートに持つディレクトリツリーを作成する
        '------------------------------------------------------------------------------
        Dim lngNodeIndex As Long

        If (mobjDirectoryTree Is Nothing) Then
            mobjDirectoryTree = New CDirectoryTree
        End If

        If (Strings.Right(strRootDir, 1) = "\") Then strRootDir = Strings.Left(strRootDir, Len(strRootDir) - 1)

        With tspProgressDir
            .Width = 300
            .Value = 0
            .Visible = True
        End With
        With tspProgressRoot
            .Width = 200
            .Value = 0
            .Visible = True
        End With
        With tsStatusLabel
            .Text = ""
            .Visible = True
        End With

        'ルートディレクトリを作成する
        With mobjDirectoryTree
            If (blnInitTree) Then
                .InitializeTree(TREE_NODE, "バックアップリスト")
                trvDirectory.Nodes.Clear()
                lsvFile.Items .Clear()
            End If

            '指定されたディレクトリをルートの下に作る
            lngNodeIndex = .AddChildNode(0, TREE_NODE, strRootDir, False)
            Try
                .NodesTimeField(lngNodeIndex) = FileDateTime(strRootDir)
            Catch
            End Try

            'ルートディレクトリ内のサブディレクトリやファイルを処理する
            MakeDirTreeSub(lngNodeIndex, strRootDir, 0, blnProcessSubDirectory, 3)
        End With

        With tspProgressDir
            .Value = 0
            .Visible = False
        End With
        With tspProgressRoot
            .Value = 0
            .Visible = False
        End With
        With tsStatusLabel
            .Text = ""
            .Visible = False
        End With

    End Sub

    Public Function SelectDirectory(ByVal strInitDir As String) As String
        '------------------------------------------------------------------------------
        'ディレクトリを選択する
        '------------------------------------------------------------------------------
        Dim objfDir As Directory

        'objfDir = New Directory

        'With objfDir
        ' .SelectedDirectory = strInitDir
        ' .Show vbModal
        '
        'SelectDirectory = .SelectedDirectory
        'End With

        'Unload objfDir
        objfDir = Nothing
        SelectDirectory = "F:"
    End Function

    Public Sub UpdateExplorer(ByVal strRootDir As String, _
        ByVal blnInitTree As Boolean, ByVal blnProcessSubDirectory As Boolean)
        '------------------------------------------------------------------------------
        '指定したディレクトリ以下のツリーを作成・表示する
        '------------------------------------------------------------------------------
        Dim trvNode As TreeNode

        mobjPrevNode = Nothing

        If (mobjDirectoryTree Is Nothing) Then
            mobjDirectoryTree = New CDirectoryTree
        End If

        '指定があれば、ツリーを作成しなおす
        If (strRootDir <> "") Then
            MakeDirectoryTree(strRootDir, blnInitTree, blnProcessSubDirectory)
        End If

        If (mobjDirectoryTree.TreeSize <= 0) Then
            MsgBox("There are no directories/files", vbOKOnly, "Empty tree!")
            Exit Sub
        End If

        'プログレスフレーム

        'ツリービューに表示する
        With trvDirectory
            .Nodes.Clear()
            trvNode = New TreeNode(mobjDirectoryTree.NodeData(0), ItemImage.ClosedFolder, ItemImage.OpenedFolder)
            trvNode.Name = GetNodeKeyName(0, True)
            '.Nodes.Add, , GetNodeKeyName(0, True), mobjDirectoryTree.NodeData(0), "Closed"
            .Nodes.Add(trvNode)
        End With

        UpdateExplorerSub(0, 0, trvNode, -1)

        Refresh()
    End Sub

    Public Sub UpdateFileList(ByVal lngDirectoryIndex As Long, _
        ByVal lngSortKey As Long, ByVal lngSortOrder As ListSortOrderConstants)
        '------------------------------------------------------------------------------
        'ファイルの一覧を表示する
        'SortKeyに0を指定すると、ソートしない
        '------------------------------------------------------------------------------
        Dim i As Long, j As Long, lngChildCount As Long
        Dim lngInsertPos As Long, lngCmpResult As Long
        Dim lngFileField As Long, lngDirsField As Long
        Dim lngTimeField As Date
        Dim lngNodeType As Long
        Dim numWmvFile As Long, sizeWmvFile As Long
        Dim numMpgFile As Long, sizeMpgFile As Long
        Dim strEntry As String, strTemp As String
        Dim strNodeData As String, strSizeText As String
        Dim objListItem As ListViewItem
        Dim objItems As ListView.ListViewItemCollection
        Dim objSize As CLongInteger

        If (mobjDirectoryTree Is Nothing) Then Exit Sub

        objItems = lsvFile.Items
        objSize = New CLongInteger

        With mobjDirectoryTree
            lngChildCount = .NodesChildCountField(lngDirectoryIndex)

            objItems.Clear()

            For i = 0 To lngChildCount - 1
                j = .GetChildNodeIndex(lngDirectoryIndex, i)
                lngNodeType = .NodeType(j)
                strEntry = .NodeData(j)

                .GetNodesSizeField(j, objSize)
                strSizeText = Strings.Right(Space$(18) & objSize.LongIntegerToString(3), 18)

                lngFileField = .NodesFileField(j)
                lngDirsField = .NodesDirsField(j)
                lngTimeField = .NodesTimeField(j)
                numWmvFile = .NodesWmvFileField(j)
                sizeWmvFile = .NodesWmvSizeField(j)
                numMpgFile = .NodesMpgFileField(j)
                sizeMpgFile = .NodesMpgSizeField(j)


                strNodeData = strEntry
                Select Case lngSortKey
                    Case 1 '名前
                        strNodeData = strEntry
                    Case 2 'サイズ
                        strNodeData = strSizeText
                    Case 3 'サブフォルダ数
                        strNodeData = LongToString(lngDirsField, 0, " ")
                    Case 4 'ファイル総数
                        strNodeData = LongToString(lngFileField, 0, " ")
                    Case 5 '更新日時
                        strNodeData = lngTimeField
                End Select

                '挿入位置を検索する
                lngInsertPos = GetFileListInsertPos(objItems, lngSortKey, lngSortOrder, lngNodeType, strNodeData)

                '挿入する
                If (lngNodeType = TREE_LEAF) Then
                    objListItem = New ListViewItem(strEntry, ItemImage.File)
                    objListItem.SubItems.Add(strSizeText)

                    'objListItem = objItems.Add(lngInsertPos, "f;" & strEntry, strEntry, "File", "File")
                    With objListItem.SubItems
                        .Add("")
                        .Add("")
                        .Add(LongToString(sizeWmvFile, 0, " "))
                        .Add(LongToString(sizeMpgFile, 0, " "))
                        .Add(LongToString(numWmvFile, 0, " "))
                        .Add(LongToString(numMpgFile, 0, " "))
                    End With
                ElseIf (lngNodeType = TREE_NODE) Then
                    objListItem = New ListViewItem(strEntry, ItemImage.ClosedFolder)
                    'objListItem = objItems.Add(lngInsertPos, "d;" & strEntry, strEntry, "Folder", "Folder")
                    With objListItem.SubItems
                        .Add(strSizeText)
                        .Add(LongToString(lngDirsField, 0, " "))
                        .Add(LongToString(lngFileField, 0, " "))
                        .Add(LongToString(sizeWmvFile, 0, " "))
                        .Add(LongToString(sizeMpgFile, 0, " "))
                        .Add(LongToString(numWmvFile, 0, " "))
                        .Add(LongToString(numMpgFile, 0, " "))
                    End With
                End If
                objListItem.SubItems.Add(lngTimeField)
                objItems.Add(objListItem)
            Next i
        End With

        objSize = Nothing
        objItems = Nothing
    End Sub

    '******************************************************************************
    'プライベートプロシージャ

    Private Function GetFileListInsertPos(ByRef lpListItems As ListView.ListViewItemCollection, _
        ByVal lngSortKey As Integer, ByVal lngSortOrder As ListSortOrderConstants, _
        ByVal lngInsertType As Long, ByVal strInsertKeyData As String) As Long
        '------------------------------------------------------------------------------
        'strInsertKeyDataを挿入する位置を決定する
        '------------------------------------------------------------------------------
        Dim i As Integer, lngCount As Integer
        Dim lngInsertPos As Long
        Dim lngCmpResult As Long
        Dim strTemp As String

        lngCount = lpListItems.Count

        If (lngSortKey = 0) Then
            'ソートしない
            GetFileListInsertPos = lngCount + 1
            Exit Function
        End If

        lngInsertPos = lngCount + 1

        For i = 1 To lngCount
            If (lngSortKey = 1) Then
                strTemp = lpListItems(i).Text
            Else
                strTemp = lpListItems(i).SubItems(lngSortKey - 1).text
            End If

            If (lngSortOrder = ListSortOrderConstants.lvwAscending) Then
                '昇順
                If (lngInsertType = TREE_NODE) Then
                    'ディレクトリは、ファイルより先に表示
                    If (lpListItems(i).ImageIndex = ItemImage.File) Then
                        lngInsertPos = i
                        Exit For
                    Else
                        'ディレクトリ同士は、内容でソートする
                        lngCmpResult = StrComp(strTemp, strInsertKeyData, vbTextCompare)
                        If (lngCmpResult = 1) Then
                            lngInsertPos = i
                            Exit For
                        ElseIf (lngCmpResult = 0) Then
                            '同一の値をとった場合は、名前でソートする
                        End If
                    End If
                ElseIf (lngInsertType = TREE_LEAF) Then
                    'ファイルは、ディレクトリの後に表示
                    If (lpListItems(i).ImageIndex = ItemImage.File) Then
                        lngCmpResult = StrComp(strTemp, strInsertKeyData, vbTextCompare)
                        If (lngCmpResult = 1) Then
                            lngInsertPos = i
                            Exit For
                        ElseIf (lngCmpResult = 0) Then
                            '同一の値をとった場合は、名前でソートする
                        End If
                    End If
                End If
            Else
                '降順
                If (lngInsertType = TREE_LEAF) Then
                    'ファイルは、ディレクトリ先に表示
                    If (lpListItems(i).ImageIndex <> ItemImage.File ) Then
                        lngInsertPos = i
                        Exit For
                    Else
                        'ファイル同士の場合は、内容でソートする
                        lngCmpResult = StrComp(strTemp, strInsertKeyData, vbTextCompare)
                        If (lngCmpResult = -1) Then
                            lngInsertPos = i
                            Exit For
                        Else
                            '同一の値をとった場合は、名前でソートする
                        End If
                    End If
                ElseIf (lngInsertType = TREE_NODE) Then
                    'ディレクトリは、ファイルの後に表示
                    If (lpListItems(i).ImageIndex <> ItemImage.File) Then
                        lngCmpResult = StrComp(strTemp, strInsertKeyData, vbTextCompare)
                        If (lngCmpResult = -1) Then
                            lngInsertPos = i
                            Exit For
                        ElseIf (lngCmpResult = 0) Then
                            '同一の値をとった場合は、名前でソートする
                        End If
                    End If
                End If
            End If
        Next i

        GetFileListInsertPos = lngInsertPos
    End Function

    Private Function GetNodeKeyName(ByVal lngNodeIndex As Long, ByVal blnExpanded As Boolean) As String
        If (blnExpanded) Then
            If (lngNodeIndex >= 0) Then
                GetNodeKeyName = "key_dir" & lngNodeIndex
            Else
                GetNodeKeyName = "key_dir"
            End If
        Else
            If (lngNodeIndex >= 0) Then
                GetNodeKeyName = "key_drc" & lngNodeIndex
            Else
                GetNodeKeyName = "key_drc"
            End If
        End If
    End Function

    Private Function LongToString(ByVal lngValue As Long, ByVal lngDigit As Integer, ByVal strBlank As String) As String
        Dim i As Integer
        Dim strResult As String

        strResult = Format$(lngValue, "#,##0")
        If (strResult.Length >= lngDigit) Then
            LongToString = strResult
            Exit Function
        End If

        Dim strPad As System.Text.StringBuilder = New System.Text.StringBuilder(strBlank.Length * lngDigit)
        For i = 1 To lngDigit - 1
            strPad.Append(strBlank)
        Next

        LongToString = Strings.Right(strPad.ToString() & strResult, lngDigit)
    End Function

    Private Sub MakeDirTreeSub(ByVal lngBaseIndex As Long, ByVal strBaseDir As String, _
        ByVal lngDepth As Integer, ByVal blnProcessSubDirectory As Boolean, _
        ByVal maxProgressDepth As Integer
    )
        '------------------------------------------------------------------------------
        '指定したディレクトリ以下のディレクトリ構造を読み取ってツリーを作る
        '------------------------------------------------------------------------------
        Dim i As Integer
        Dim lngChildCount As Integer, lngChildIndex As Long, lngChildNodeType As Long
        Dim strDir As String, strCurDir As String
        Dim strNameLower As String
        Dim lngFileCount As Long, lngDirsCount As Long
        Dim numWmvFile As Long, sizeWmvFile As Long
        Dim numMpgFile As Long, sizeMpgFile As Long
        Dim lngSize As Long
        Dim objTotalSize As CLongInteger, objChildSize As CLongInteger

        If (Strings.Right(strBaseDir, 1) = "\") Then strBaseDir = Strings.Left$(strBaseDir, Len(strBaseDir) - 1)

        '最初のディレクトリを取得する
        strCurDir = strBaseDir & "\"
        strDir = Dir$(strCurDir, vbReadOnly Or vbHidden Or vbSystem Or vbDirectory)

        Do While strDir <> ""
            '現在のディレクトリと親ディレクトリは除く
            If ((strDir <> ".") And (strDir <> "..")) Then
                '対象外に設定されていないことを確認する
                If (True) Then
                    '属性を確認する
                    If (GetAttr(strCurDir & strDir) And vbDirectory) Then
                        i = mobjDirectoryTree.AddChildNode(lngBaseIndex, TREE_NODE, strDir, True)
                    Else
                        i = mobjDirectoryTree.AddChildNode(lngBaseIndex, TREE_LEAF, strDir, True)
                    End If
                End If
            End If

            strDir = Dir$()
        Loop

        'サブディレクトリを処理する
        lngFileCount = 0
        lngDirsCount = 0
        numWmvFile = 0
        numMpgFile = 0
        sizeWmvFile = 0
        sizeMpgFile = 0
        objTotalSize = New CLongInteger
        objTotalSize.SetValue(0)

        With mobjDirectoryTree
            lngChildCount = .NodesChildCountField(lngBaseIndex)
            For i = 0 To lngChildCount - 1
                Application.DoEvents()

                lngChildIndex = .GetChildNodeIndex(lngBaseIndex, i)
                strDir = strCurDir & .NodeData(lngChildIndex)
                lngChildNodeType = .NodeType(lngChildIndex)

                If (lngChildNodeType = TREE_NODE) Then
                    'この子ノードがディレクトリの場合
                    '進行状況を表示する
                    tsStatusLabel.Text = strDir
                    If (lngDepth <= 0) Then
                        With tspProgressRoot
                            .Minimum = 0
                            .Maximum = lngChildCount
                            .Value = i + 1
                        End With
                    End If
                    If (lngDepth <= maxProgressDepth) Then
                        With tspProgressDir
                            .Minimum = 0
                            .Maximum = lngChildCount
                            .Value = i + 1
                        End With
                    End If
                    '進行状況を指定されたオブジェクトへ転送表示する

                    '
                    If (blnProcessSubDirectory) Then
                        If ((lngDepth = 0) And (lngChildCount = 1)) Then
                            MakeDirTreeSub(lngChildIndex, strDir, lngDepth, True, maxProgressDepth)
                        Else
                            MakeDirTreeSub(lngChildIndex, strDir, lngDepth + 1, True, maxProgressDepth)
                        End If
                    End If

                    '子ノードの情報を更新する
                    Try
                        .NodesTimeField(lngChildIndex) = FileDateTime(strDir)
                    Catch
                    End Try

                    '子ノードの情報を集計して、親（現在の）ノードに通知する
                    lngFileCount = lngFileCount + .NodesFileField(lngChildIndex)
                    lngDirsCount = lngDirsCount + .NodesDirsField(lngChildIndex) + 1
                    numWmvFile = numWmvFile + .NodesWmvFileField(lngChildIndex)
                    numMpgFile = numMpgFile + .NodesMpgFileField(lngChildIndex)
                    sizeWmvFile = sizeWmvFile + .NodesWmvSizeField(lngChildIndex)
                    sizeMpgFile = sizeMpgFile + .NodesMpgSizeField(lngChildIndex)

                    objChildSize = New CLongInteger
                    .GetNodesSizeField(lngChildIndex, objChildSize)
                    objTotalSize.AddLong(objChildSize)
                    objChildSize = Nothing

                ElseIf (lngChildNodeType = TREE_LEAF) Then
                    'この子ノードがファイルの場合
                    strNameLower = .NodeData(lngChildIndex).ToLower()

                    lngSize = FileLen(strDir)

                    .SetNodesSizeField(lngChildIndex, lngSize, Nothing)
                    .NodesTimeField(lngChildIndex) = FileDateTime(strDir)
                    .NodesDirsField(lngChildIndex) = 0
                    .NodesFileField(lngChildIndex) = 0

                    If strNameLower.EndsWith(".wmv") Then
                        .NodesWmvFileField(lngChildIndex) = 1
                        .NodesWmvSizeField(lngChildIndex) = lngSize
                        numWmvFile = numWmvFile + 1
                        sizeWmvFile = sizeWmvFile + lngSize
                    End If
                    If strNameLower.EndsWith(".mpg") Then
                        .NodesMpgFileField(lngChildIndex) = 1
                        .NodesMpgSizeField(lngChildIndex) = lngSize
                        numMpgFile = numMpgFile + 1
                        sizeMpgFile = sizeMpgFile + lngSize
                    End If

                    lngFileCount = lngFileCount + 1
                    objTotalSize.AddInteger(lngSize)
                End If
            Next i

            'このノードにデータを書き込む
            .NodesFileField(lngBaseIndex) = lngFileCount
            .NodesDirsField(lngBaseIndex) = lngDirsCount
            .NodesWmvFileField(lngBaseIndex) = numWmvFile
            .NodesWmvSizeField(lngBaseIndex) = sizeWmvFile
            .NodesMpgFileField(lngBaseIndex) = numMpgFile
            .NodesMpgSizeField(lngBaseIndex) = sizeMpgFile
            .SetNodesSizeField(lngBaseIndex, -1, objTotalSize)
        End With

    End Sub

    Private Sub SetControlSize(ByVal lngSplitterPos As Long)
        '------------------------------------------------------------------------------
        'コントロールのサイズを設定する
        '------------------------------------------------------------------------------

    End Sub

    Private Sub UpdateExplorerSub(ByVal lngBaseNodeIndex As Long, ByVal lngDepth As Integer, ByVal parentNode As TreeNode, ByVal maxExpandDepth As Integer)
        '------------------------------------------------------------------------------
        '指定したディレクトリ以下の階層の表示を更新する
        '------------------------------------------------------------------------------
        Dim i As Long, j As Long, C As Long
        Dim strBaseKey As String, strKey As String
        Dim strDirName As String, strNodeData As String
        Dim trvNodeNew As TreeNode

        'ベースディレクトリのキーを取得する
        strBaseKey = GetNodeKeyName(lngBaseNodeIndex, True)

        With mobjDirectoryTree
            C = .NodesChildCountField(lngBaseNodeIndex)

            For i = 0 To C - 1
                Application.DoEvents()

                j = .GetChildNodeIndex(lngBaseNodeIndex, i)
                If (.NodeType(j) = TREE_NODE) Then
                    'この子ノードがディレクトリの場合

                    '進行状況を表示する
                    '進行状況を指定されたオブジェクトへ転送表示する

                    'この子ノードと、それ以下のノードを処理する
                    strNodeData = .NodeData(j)
                    If (maxExpandDepth < 0) Or (lngDepth < maxExpandDepth) Then
                        strKey = GetNodeKeyName(j, True)
                        trvNodeNew = New TreeNode(strNodeData, ItemImage.ClosedFolder, ItemImage.OpenedFolder)
                        trvNodeNew.Name = strKey
                        parentNode.Nodes.Add(trvNodeNew)
                        UpdateExplorerSub(j, lngDepth + 1, trvNodeNew, maxExpandDepth)
                    Else
                        strKey = GetNodeKeyName(j, False)
                        trvNodeNew = New TreeNode(strNodeData, ItemImage.ClosedFolder, ItemImage.OpenedFolder)
                        trvNodeNew.Name = strKey
                        parentNode.Nodes.Add(trvNodeNew)
                    End If
                End If
            Next i
        End With
    End Sub

    Private Sub trvDirectory_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvDirectory.AfterSelect
        '------------------------------------------------------------------------------
        'ツリービューコントロールのノードをクリックした場合は
        'そのディレクトリの内容をリストビューコントロールに表示する
        '------------------------------------------------------------------------------
        Dim strKey As String

        'If (Not (mobjPrevNode Is Nothing)) Then mobjPrevNode.Image = "Closed"

        mobjPrevNode = e.Node

        strKey = e.Node.Name
        If (Strings.Left$(strKey, 7) = "key_dir") Then
            mlngCurDirectory = Val(Mid$(strKey, 8))
            '        If (mlngCurDirectory = 0) Then
            '            mlngSortKey = 0
            '        End If
            UpdateFileList(mlngCurDirectory, mlngSortKey, mlngSortOrder)
        End If
    End Sub

    Private Sub OpenDirectoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenDirectoryToolStripMenuItem.Click
        '------------------------------------------------------------------------------
        'ディレクトリを開く
        '------------------------------------------------------------------------------
        Dim strTemp As String

        strTemp = SelectDirectory(mstrRootDirectory)
        If (strTemp = "") Then Exit Sub

        mstrRootDirectory = strTemp
        UpdateExplorer(strTemp, True, True)
    End Sub

End Class