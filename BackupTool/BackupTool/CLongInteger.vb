Public Class CLongInteger

    '========================================================================================
    '   BackupTool
    '
    '   CLongIntegerクラス (LongInteger.cls)
    '   多倍長整数クラス。ファイルの合計サイズが2Gを超える場合に対応
    '
    '   Copyright Takahiro Itou, 2003/08/10 - 2007/07/03
    '========================================================================================

    '多倍長整数を処理するデータ
    Private mlngDataSize As Long        'データmValue()のサイズ
    Private mlngValue() As Long         '値

    '******************************************************************************
    'パブリック関数(メソッド)

    Public Sub AddInteger(ByVal X As Long)
        '------------------------------------------------------------------------------
        '現在の値に、整数 X (Long)を加える
        '------------------------------------------------------------------------------
        Dim i As Long
        Dim Cy As Long

        Cy = X
        For i = 0 To mlngDataSize - 1
            mlngValue(i) = mlngValue(i) + Cy
            If mlngValue(i) >= 10000 Then
                Cy = mlngValue(i) \ 10000
                mlngValue(i) = mlngValue(i) Mod 10000
            Else
                Cy = 0
                Exit For
            End If
        Next i

        Do While Cy
            mlngDataSize = mlngDataSize + 1
            ReDim Preserve mlngValue(0 To mlngDataSize - 1)
            mlngValue(mlngDataSize - 1) = Cy Mod 10000
            Cy = Cy \ 10000
        Loop
    End Sub

    Public Sub AddLong(ByVal lngintX As CLongInteger)
        '------------------------------------------------------------------------------
        '現在の値に、整数 X (CLongIntger)を加える
        '------------------------------------------------------------------------------
        Dim i As Long, C As Long
        Dim Cy As Long

        'データのサイズを大きいほうにそろえる
        C = lngintX.DataSize
        If mlngDataSize < C Then
            mlngDataSize = C
            ReDim Preserve mlngValue(0 To mlngDataSize - 1)
        End If

        Cy = 0
        For i = 0 To C - 1
            mlngValue(i) = mlngValue(i) + lngintX.Value(i) + Cy
            Cy = mlngValue(i) \ 10000
            mlngValue(i) = mlngValue(i) Mod 10000
        Next i
        For i = C To mlngDataSize - 1
            mlngValue(i) = mlngValue(i) + Cy
            If mlngValue(i) >= 10000 Then
                Cy = mlngValue(i) \ 10000
                mlngValue(i) = mlngValue(i) Mod 10000
            Else
                Cy = 0
                Exit For
            End If
        Next i

        Do While Cy
            mlngDataSize = mlngDataSize + 1
            ReDim Preserve mlngValue(0 To mlngDataSize - 1)
            mlngValue(mlngDataSize - 1) = Cy Mod 10000
            Cy = Cy \ 10000
        Loop
    End Sub

    Public Function IsEqual(ByVal lngintX As CLongInteger) As Boolean
        '------------------------------------------------------------------------------
        '値を比較する。等しければTrue,等しくなければFalseを返す
        '------------------------------------------------------------------------------
        Dim X() As Long, y() As Long
        Dim i As Long, C As Long, TS As Long

        TS = lngintX.DataSize
        C = TS
        If mlngDataSize > C Then C = mlngDataSize
        If C = 0 Then
            'どちらも０なので等しい
            IsEqual = True
            Exit Function
        End If

        ReDim X(0 To C - 1)
        ReDim y(0 To C - 1)

        For i = 0 To mlngDataSize - 1
            X(i) = mlngValue(i)
        Next i
        For i = 0 To TS - 1
            y(i) = lngintX.Value(i)
        Next i

        For i = 0 To C - 1
            If X(i) <> y(i) Then
                IsEqual = False
                Exit Function
            End If
        Next i

        IsEqual = True
    End Function

    Public Function IsSmall(ByVal lngintX As CLongInteger) As Boolean
        '------------------------------------------------------------------------------
        '値を比較する。小さければTrue,そうでなければFalseを返す
        '------------------------------------------------------------------------------
        Dim X() As Long, y() As Long
        Dim i As Long, C As Long, TS As Long

        TS = lngintX.DataSize
        C = TS
        If mlngDataSize > C Then C = mlngDataSize
        If C = 0 Then
            'どちらも０なので等しい。よって小さくない
            IsSmall = False
            Exit Function
        End If

        ReDim X(0 To C - 1)
        ReDim y(0 To C - 1)

        For i = 0 To mlngDataSize - 1
            X(i) = mlngValue(i)
        Next i
        For i = 0 To TS - 1
            y(i) = lngintX.Value(i)
        Next i

        For i = C - 1 To 0 Step -1
            If X(i) < y(i) Then
                IsSmall = True
                Exit Function
            ElseIf X(i) > y(i) Then
                IsSmall = False
                Exit Function
            End If
        Next i

        '等しい。よって小さくない
        IsSmall = False
    End Function

    Public Function LongIntegerToString(ByVal nSep As Long) As String
        '------------------------------------------------------------------------------
        '現在の値を文字列にして返す
        'nSepで0以上の値を指定すると、その桁数ごとにカンマを打つ
        '------------------------------------------------------------------------------
        Dim i As Long, nFlag As Long
        Dim sTemp As String

        If (mlngDataSize = 0) Then
            sTemp = "0"
        Else
            sTemp = ""
            nFlag = 0
            For i = mlngDataSize - 1 To 0 Step -1
                If (nFlag) Then
                    sTemp = sTemp & Format$(mlngValue(i), "0000")
                ElseIf (mlngValue(i)) Or (i = 0) Then
                    sTemp = mlngValue(i)
                    nFlag = 1
                End If
            Next i
        End If

        '指定された桁数ごとにカンマを打つ
        If nSep Then
            i = Len(sTemp) - nSep
            Do While i > 0
                sTemp = Left$(sTemp, i) & "," & Mid$(sTemp, i + 1)
                i = i - 3
            Loop
        End If

        LongIntegerToString = sTemp
    End Function

    Public Sub SetLongInt(ByVal lngintX As CLongInteger)
        '------------------------------------------------------------------------------
        '値を代入する
        '------------------------------------------------------------------------------
        Dim i As Long
        Dim v() As Long

        mlngDataSize = lngintX.DataSize
        If mlngDataSize = 0 Then
            mlngDataSize = 1
            ReDim mlngValue(0 To mlngDataSize - 1)
            Exit Sub
        End If

        ReDim v(0 To mlngDataSize - 1)

        For i = 0 To mlngDataSize - 1
            v(i) = lngintX.Value(i)
        Next i

        ReDim mlngValue(0 To mlngDataSize - 1)
        For i = 0 To mlngDataSize - 1
            mlngValue(i) = v(i)
        Next i
    End Sub

    Public Sub SetValue(ByVal X As Long)
        '------------------------------------------------------------------------------
        '32ビット以内の値を設定する
        '------------------------------------------------------------------------------
        mlngDataSize = 0
        AddInteger(X)
    End Sub

    '******************************************************************************
    'プロパティプロシージャ
    Public ReadOnly Property DataSize() As Long
        Get
            DataSize = mlngDataSize
        End Get
    End Property

    Public ReadOnly Property Value(ByVal Index As Long) As Long
        Get
            If Index < mlngDataSize Then
                Value = mlngValue(Index)
            Else
                Value = 0
            End If
        End Get
    End Property

End Class
