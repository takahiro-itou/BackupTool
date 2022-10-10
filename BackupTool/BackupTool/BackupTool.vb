Module BackupTool

    '========================================================================================
    '   BackupTool
    '
    '   mdlBackupTook (BackupTool.bas)
    '   バックアップ管理ツール
    '
    '   Copyright Takahiro Itou, 2003/08/10 - 2007/07/01
    '========================================================================================

    '******************************************************************************
    'アプリケーション情報
    Public gstrAppPath As String
    Public gstrIniFileName As String

    'エクスプローラ(コピー元、コピー先)
    Private glngExplorerCount As Long
    Private gobjfExplorer() As Explorer

    '比較オプション
    Public Enum eVerifyFlags
        VFSIZE = 1              'ファイルサイズを比較する
        VFDIRS = 2              'ディレクトリ数を検査する
        VFPARENT = 4            '親ディレクトでも報告する
        VFDATE = 8              '更新日時を検査する
        VFFILE = 16             'ファイル内容を検査する
        VFREPORTONLY = 32       '報告のみ
        VFERRORSKIP = 256       'エラーが発生してもダイアログを表示しない
        VFRELOADDIR = 512       'ディレクトリ構造を再ロードする
        VFSHOWIFONLY = 1024     '修正しないしか選択できなくても表示する
    End Enum

    '修正アクション
    Public Enum eCorrectAction
        CACOPYFILE = 0          'ファイルをコピーする
        CAVERIFYCOPY = 1        '比較後ファイルをコピーする
        CADELETEFILE = 2        'コピー先のファイルを削除する
        CANOCORRECT = 3         '修正しない
        CORRECTCANCEL = 255     'キャンセル
    End Enum

    'キャンセル
    Public gCancel As Boolean

    '検査したファイル数
    Public gCurrentFileCount As Long
    Public gCurrentDirCount As Long
    Public gCurrentFileBytes As CLongInteger
    Public gTotalFileCount As Long
    Public gTotalDirCount As Long
    Public gTotalFileBytes As CLongInteger

    '検出されたエラー
    Private gMismatchCount As Long          '不一致のファイル数
    Private gReportedCount As Long          '報告されたファイル・ディレクトリ数
    Private gCorrectedCount As Long         '修正されたファイル・ディレクトリ数
    Private gErrorCount As Long             'エラー

    Public gTotalMismatch As Long           'バックアップモードでの総計
    Public gTotalReported As Long
    Public gTotalCorrected As Long
    Public gTotalError As Long

    Public gAllProcCurrentDir As Long
    Public gAllProcTotalDir As Long
    Public gAllProcCurrentFile As Long
    Public gAllProcTotalFile As Long

    'プログレスウィンドウ
    'Private mfProgress As frmProgress

    '******************************************************************************
    'ツリーの各ノードの種類
    Public Const TREE_EMPTY As Long = 0     '未使用領域
    Public Const TREE_LEAF As Long = 1      '葉(末端のノード)
    Public Const TREE_NODE As Long = 2      '節(子ノードを持つ)

    'ツリーの各ノードの情報
    Public Structure tTreeNode
        'ノード自身の情報
        Public nNodeType As Long               'ノードの種類
        Public sNodeData As String             'ノードに格納されたデータ
        Public nDepth As Long                  'ノードの深さ(ルートでは0)

        'ノードデータの追加情報
        Public nSize As Long                   'サイズ(最大1GB,-1:CLongInteger型に切り替え)
        Public nExSize As CLongInteger         'サイズ(CLongInteger型による巨大ファイルサイズの扱い)
        Public nTime As Date                   '更新日時
        Public nDirs As Long                   'サブディレクトリ
        Public nFile As Long                   'ファイル総数(サブディレクトリ含む)

        Public numWmvFile As Long               ' 拡張子 .wmv ファイルの総数 (サブディレクトリ含む)
        Public numMpgFile As Long               ' 拡張子 .mpg ファイルの総数 (サブディレクトリ含む)
        Public sizeWmvFile As Long              ' 拡張子 .wmv ファイルのサイズ
        Public sizeMpgFile As Long              ' 拡張子 .mpg ファイルのサイズ

        '親と子供
        Public lpParent As Long                '親ノードへのポインタ(配列のインデックス)
        Public nChildCount As Long             '子ノードの数
        Public lpChild() As Long               '子ノードへのポインタ(配列のインデックス)
    End Structure


    Public Sub ActivateExplorer(ByVal lngIndex As Long)
        '------------------------------------------------------------------------------
        'エクスプローラをアクティブにする
        '指定したエクスプローラが開かれていなければ何もしない
        '------------------------------------------------------------------------------

        If (gobjfExplorer(lngIndex) Is Nothing) Then Exit Sub
        'gobjfExplorer(lngIndex).SetFocus()
    End Sub

    Public Sub CloseExplorer(ByVal lngIndex As Long)
        '------------------------------------------------------------------------------
        'エクスプローラを閉じる
        '指定したエクスプローラが開かれていなければ何もしない
        '------------------------------------------------------------------------------

        If (gobjfExplorer(lngIndex) Is Nothing) Then Exit Sub

        gobjfExplorer(lngIndex).Close()
        gobjfExplorer(lngIndex) = Nothing
    End Sub

    Public Function GetAppPath() As String
        Return System.IO.Path.GetDirectoryName(
            System.Reflection.Assembly.GetExecutingAssembly().Location)
    End Function
    '------------------------------------------------------------------------------
    'アプリケーションのエントリポイント
    '------------------------------------------------------------------------------
    <STAThread()> _
    Public Sub Main()

        'アプリケーションのパスを取得する
        gstrAppPath = GetAppPath()
        If (Right$(gstrAppPath, 1) = "\") Then gstrAppPath = Left$(gstrAppPath, Len(gstrAppPath) - 1)

        '設定ファイルの名前を取得する
        gstrIniFileName = gstrAppPath & "\Backup.ini"

        'メインフォームを起動する
        Dim frmExplorer As New Explorer
        Application.Run(frmExplorer)
    End Sub

    Public Sub MoveExplorer(ByVal lngIndex As Long, _
        ByVal lngLeft As Long, ByVal lngTop As Long, ByVal lngWidth As Long, ByVal lngHeight As Long)
        '------------------------------------------------------------------------------
        'エクスプローラを移動する
        '指定したエクスプローラが開かれていなければ何もしない
        '------------------------------------------------------------------------------

        If (gobjfExplorer(lngIndex) Is Nothing) Then Exit Sub
        ''gobjfExplorer(lngIndex).Move(lngLeft, lngTop, lngWidth, lngHeight)
    End Sub

    Public Function OpenExplorer(ByVal lngIndex As Long, ByVal strCaption As String) As Long
        '------------------------------------------------------------------------------
        'エクスプローラを開く
        '指定したエクスプローラが既に開かれていれば、
        'キャプションの変更だけ行い、そのフォームをアクティブにする
        '------------------------------------------------------------------------------

        If (lngIndex >= glngExplorerCount) Then
            glngExplorerCount = lngIndex + 1
            ReDim Preserve gobjfExplorer(0 To glngExplorerCount - 1)
        End If

        If (gobjfExplorer(lngIndex) Is Nothing) Then
            gobjfExplorer(lngIndex) = New Explorer
        End If
        With gobjfExplorer(lngIndex)
            '.Show(vbModeless)
            .Show()
            .Text = strCaption
        End With

        OpenExplorer = lngIndex
    End Function

End Module
