Public Class CDirectoryTree
    '========================================================================================
    '   BackupTool
    '
    '   CDirectoryTreeクラス (DirectoryTree.cls)
    '   ディレクトリツリー構造を管理するクラス
    '
    '   Copyright Takahiro Itou, 2003/08/10 - 2007/07/03
    '========================================================================================

    'ツリーデータ
    Private mlngSizeOfNodeBuffer As Long        'ノード用バッファのサイズ
    Private mutTreeData() As tTreeNode          'ツリーのノードのデータ

    Private mlngTreeSize As Long                'ツリーの大きさ(実際に存在するノードの数)
    Private mlngTreeHeight As Long              'ツリーの高さ

    'ポインタ
    Private Const TREENODENULL As Long = -1

    '******************************************************************************
    'パブリックプロシージャ

    Public Function AddChildNode(ByVal lngParent As Long, ByVal lngNodeType As Long, _
        ByVal strNodeData As String, ByVal blnFlagSorted As Boolean) As Long
        '------------------------------------------------------------------------------
        '指定されたノードに子ノードを作成して追加する
        '作成されたノードのポインタ(インデックス)を返す
        'blnFlagSortedがTrueで、データがすでに並んでいれば、
        '基本挿入法によりソートを行う
        '------------------------------------------------------------------------------
        Dim i As Long
        Dim lngIndex As Long, lngInsertPos As Long
        Dim lngNewDepth As Long
        Dim utChildNode As tTreeNode

        'ノード用バッファから、空きを検索する
        lngIndex = FindEmptyNode()

        '親の情報を格納する
        If (lngParent = TREENODENULL) Then
            'ルートノード
            If (lngIndex > 0) Then
                MsgBox("エラー：親ノードが指定されていません。" & vbCrLf & _
                    "ルートノードを作るとき以外は無効です。")
                Stop
                AddChildNode = TREENODENULL
                Exit Function
            End If
            lngNewDepth = 0
        Else
            With mutTreeData(lngParent)
                '子ノードを挿入する位置を決める
                If (blnFlagSorted) Then
                    'ソートして挿入する
                    lngInsertPos = .nChildCount
                    For i = 0 To .nChildCount - 1
                        utChildNode = mutTreeData(.lpChild(i))

                        If (lngNodeType = TREE_LEAF) Then
                            'リーフの中で検索する
                            If (utChildNode.nNodeType = TREE_LEAF) Then
                                If (StrComp(utChildNode.sNodeData, strNodeData, vbTextCompare) = 1) Then
                                    lngInsertPos = i
                                    Exit For
                                End If
                            End If
                        ElseIf (lngNodeType = TREE_NODE) Then
                            '検索する
                            If (utChildNode.nNodeType = TREE_LEAF) Then
                                lngInsertPos = i
                                Exit For
                            End If
                            If (StrComp(utChildNode.sNodeData, strNodeData, vbTextCompare) = 1) Then
                                lngInsertPos = i
                                Exit For
                            End If
                        End If
                    Next i
                Else
                    'ソートしない
                    lngInsertPos = .nChildCount
                End If

                '挿入位置より後ろのデータをずらす
                ReDim Preserve .lpChild(0 To .nChildCount)
                For i = .nChildCount To lngInsertPos + 1 Step -1
                    .lpChild(i) = .lpChild(i - 1)
                Next i
                .nChildCount = .nChildCount + 1

                '子ノードを挿入する
                .lpChild(lngInsertPos) = lngIndex

                lngNewDepth = .nDepth + 1
            End With
        End If

        'ノードの情報を記録する
        With mutTreeData(lngIndex)
            .nNodeType = lngNodeType
            .sNodeData = strNodeData
            .nDepth = lngNewDepth

            .nExSize = Nothing

            .lpParent = lngParent
            .nChildCount = 0
        End With

        '木の高さを再計算する
        If (lngNewDepth > mlngTreeHeight) Then mlngTreeHeight = lngNewDepth

        'データの個数を再設定
        mlngTreeSize = mlngTreeSize + 1

        'ポインタを返す
        AddChildNode = lngIndex
    End Function

    Public Sub Clear()
        '------------------------------------------------------------------------------
        'ツリーをクリアする。すべてのノードを削除する
        '------------------------------------------------------------------------------

        mlngSizeOfNodeBuffer = 0
        Erase mutTreeData

        mlngTreeSize = 0
        mlngTreeHeight = 0
    End Sub

    Public Function GetChildNodeIndex(ByVal lngIndex As Long, ByVal lngChildIndex As Long) As Long
        '------------------------------------------------------------------------------
        'ノードlngIndex のlngChildIndex番目の子ノードのポインタを返す
        '------------------------------------------------------------------------------
        GetChildNodeIndex = mutTreeData(lngIndex).lpChild(lngChildIndex)
    End Function

    Public Sub GetNodesSizeField(ByVal lngIndex As Long, ByRef lpResult As CLongInteger)
        '------------------------------------------------------------------------------
        'ノードのサイズフィールドの値を返す
        '------------------------------------------------------------------------------
        Dim lngSize As Long

        With mutTreeData(lngIndex)
            lngSize = .nSize
            If (lngSize < 0) Then
                lpResult.SetLongInt(.nExSize)
            Else
                lpResult.SetValue(lngSize)
            End If
        End With
    End Sub

    Public Sub InitializeTree(ByVal lngRootNodeType As Long,
        ByVal strRootNodeData As String, Optional ByVal lngStartBufferSize As Long = 1024)
        '------------------------------------------------------------------------------
        'ツリーを初期化する
        'ツリー内のすべてのノードを初期化し、ルートノードのみを作成する
        'lngStartBufferSizeで初期化の時に確保しておくバッファのサイズを指定できる
        '------------------------------------------------------------------------------
        Dim i As Long

        'バッファを初期化する
        mlngSizeOfNodeBuffer = lngStartBufferSize
        ReDim mutTreeData(0 To mlngSizeOfNodeBuffer - 1)

        For i = 0 To mlngSizeOfNodeBuffer - 1
            With mutTreeData(i)
                .nNodeType = TREE_EMPTY
            End With
        Next i

        'ルートノードを作成する
        With mutTreeData(0)
            .nNodeType = lngRootNodeType
            .sNodeData = strRootNodeData
            .nDepth = 0

            .lpParent = TREENODENULL
            .nChildCount = 0
        End With

        mlngTreeSize = 1
        mlngTreeHeight = 0
    End Sub

    Public Sub SetNodesSizeField(ByVal lngIndex As Long,
        ByVal lngSize As Long, ByRef objLongSize As CLongInteger)
        '------------------------------------------------------------------------------
        'ノードのサイズフィールドの値を設定する
        '------------------------------------------------------------------------------

        With mutTreeData(lngIndex)
            If (lngSize >= 0) Or (objLongSize Is Nothing) Then
                .nSize = lngSize
                .nExSize = Nothing
            ElseIf (objLongSize.DataSize <= 1) Then
                .nSize = objLongSize.Value(0)
                .nExSize = Nothing
            Else
                .nSize = -1
                If (.nExSize Is Nothing) Then
                    .nExSize = New CLongInteger
                End If
                .nExSize.SetLongInt(objLongSize)
            End If
        End With
    End Sub

    '******************************************************************************
    'プライベートプロシージャ

    Private Function FindEmptyNode() As Long
        '------------------------------------------------------------------------------
        'ノード用バッファから空いているインデックスを探し、その番号を返す
        'なければ、新規に作成する
        '------------------------------------------------------------------------------
        Dim i As Long
        Dim lngIndex As Long

        If (mlngTreeSize < mlngSizeOfNodeBuffer) Then
            If (mutTreeData(mlngTreeSize).nNodeType = TREE_EMPTY) Then
                FindEmptyNode = mlngTreeSize
                Exit Function
            End If
        End If

        For i = 0 To mlngSizeOfNodeBuffer - 1
            If (mutTreeData(i).nNodeType = TREE_EMPTY) Then
                FindEmptyNode = i
                Exit Function
            End If
        Next i

        '見つからなければ、新しく作成する
        '余分に確保する。(1024個分 約 64KB)
        lngIndex = mlngSizeOfNodeBuffer

        mlngSizeOfNodeBuffer = (mlngSizeOfNodeBuffer + 1024) And &H7FFFFC00
        ReDim Preserve mutTreeData(0 To mlngSizeOfNodeBuffer - 1)

        For i = lngIndex To mlngSizeOfNodeBuffer - 1
            With mutTreeData(i)
                .nNodeType = TREE_EMPTY
            End With
        Next i

        FindEmptyNode = lngIndex
    End Function

    Protected Overrides Sub Finalize()
        Clear()
        MyBase.Finalize()
    End Sub


    '******************************************************************************
    'プロパティプロシージャ

    Public Property NodeData(ByVal Index As Long) As String
        Get
            NodeData = mutTreeData(Index).sNodeData
        End Get
        Set(ByVal strNewData As String)
            mutTreeData(Index).sNodeData = strNewData
        End Set
    End Property


    Public ReadOnly Property NodesChildCountField(ByVal Index As Long) As Long
        Get
            NodesChildCountField = mutTreeData(Index).nChildCount
        End Get
    End Property


    Public Property NodesTimeField(ByVal Index As Long) As Date
        Get
            NodesTimeField = mutTreeData(Index).nTime
        End Get
        Set(ByVal lngNewValue As Date)
            mutTreeData(Index).nTime = lngNewValue
        End Set
    End Property


    Public Property NodesDirsField(ByVal Index As Long) As Long
        Get
            NodesDirsField = mutTreeData(Index).nDirs
        End Get
        Set(ByVal lngNewValue As Long)
            mutTreeData(Index).nDirs = lngNewValue
        End Set
    End Property


    Public Property NodesFileField(ByVal Index As Long) As Long
        Get
            NodesFileField = mutTreeData(Index).nFile
        End Get
        Set(ByVal lngNewValue As Long)
            mutTreeData(Index).nFile = lngNewValue
        End Set
    End Property

    Public Property NodesMpgFileField(ByVal Index As Integer) As Long
        Get
            NodesMpgFileField = mutTreeData(Index).numMpgFile
        End Get
        Set(ByVal lngNewValue As Long)
            mutTreeData(Index).numMpgFile = lngNewValue
        End Set
    End Property

    Public Property NodesMpgSizeField(ByVal Index As Integer) As Long
        Get
            NodesMpgSizeField = mutTreeData(Index).sizeMpgFile
        End Get
        Set(ByVal lngNewValue As Long)
            mutTreeData(Index).sizeMpgFile = lngNewValue
        End Set
    End Property


    Public ReadOnly Property NodeParent(ByVal Index As Long) As Long
        Get
            NodeParent = mutTreeData(Index).lpParent
        End Get
    End Property


    Public ReadOnly Property NodeType(ByVal Index As Long) As Long
        Get
            NodeType = mutTreeData(Index).nNodeType
        End Get
    End Property

    Public Property NodesWmvFileField(ByVal Index As Integer) As Long
        Get
            NodesWmvFileField = mutTreeData(Index).numWmvFile
        End Get
        Set(ByVal lngNewValue As Long)
            mutTreeData(Index).numWmvFile = lngNewValue
        End Set
    End Property

    Public Property NodesWmvSizeField(ByVal Index As Integer) As Long
        Get
            NodesWmvSizeField = mutTreeData(Index).sizeWmvFile
        End Get
        Set(ByVal lngNewValue As Long)
            mutTreeData(Index).sizeWmvFile = lngNewValue
        End Set
    End Property

    Public ReadOnly Property TreeSize() As Long
        Get
            TreeSize = mlngTreeSize
        End Get
    End Property


End Class
