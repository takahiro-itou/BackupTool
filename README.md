# 各フォルダのサイズを計測する du コマンド相当

##  0 . 必要なソフト

- Visual Studio 2022 Community 以上. Visual Basic を利用
    - https://visualstudio.microsoft.com/ja/vs/community/

##  1. クローン

```
git clone https://gitlab.com/takahiro-itou-vb6-upgrade-net/BackupTool.git
```

##  2. ビルド

###  2.1. IDE を使う場合

- BackupTool フォルダ内のソリューションファイル BackupTool.sln を IDE で開きます。
- 構成マネージャで Release か Debug を選びます。
- メニューの「ビルド」- 「ソリューションのリビルド」を選択します。

###  2.2. コマンドプロンプトを使う場合

- スタートメニューから「Visual Studio 2022」- 「x64 Native Tools Command Prompt for VS 2022」を選択
- カレントフォルダをクローンした場所に移動します。

```
cd BackupTool
REM カレントフォルダに .sln ファイルがあることを確認します
msbuild /restore /t:Rebuild /p:Platform="Any CPU" /p:Configuration=Release
```

- 詳しくは Rebuild.bat をご覧ください。
