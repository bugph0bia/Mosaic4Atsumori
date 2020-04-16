Mosaic4Atsumori
===

![Software Version](http://img.shields.io/badge/Version-v0.0.2-green.svg?style=flat)
![.NET Framework](http://img.shields.io/badge/.NET_Framework-v4.6.1-blue.svg?style=flat)
![VS Version](http://img.shields.io/badge/VisualStudio-2017-blue.svg?style=flat)
[![MIT License](http://img.shields.io/badge/license-MIT-blue.svg?style=flat)](LICENSE)

[English Page](./README.en.md)

## 概要
あつ森（あつまれ どうぶつの森）のマイデザイン作成を補助するツールです。  
※Windows専用です。

![main](https://user-images.githubusercontent.com/18702413/79063578-876e7080-7cdd-11ea-8487-713fc93fb072.png)

### できること
- 画像ファイルを下記フォーマットのモザイクアート（ドット絵）に変換して表示。
    - 幅:32px
    - 高さ:32px
    - 色パレット:15色以下
- 使用するパレット色の「いろあい」「あざやかさ」「あかるさ」を表示。
- 選択したパレット色をハイライト表示。

### できないこと
- 32x32 以外への画像変換（服用のドット絵表示）。
- QRコード作成。

## バージョン
v0.0.2

## ダウンロード
[こちら](https://github.com/mat2umoto/Mosaic4Atsumori/releases/download/v0.0.2/Mosaic4Atsumori.zip) から V0.0.2 をダウンロードできます。

## 動作要件
- Windows
- .NET Framework V4.6.1 以降

## 開発環境
Visual Studio 2017

## ライセンス
MIT License

## インストール／アンインストール
### インストール方法
`Mosaic4Atsumotri.exe` を任意のディレクトリに置いて起動するだけです。  

### アンインストール方法
`Mosaic4Atsumotri.exe` を削除してください。レジストリは使用しません。

## 使用方法
### 操作の流れ
1. `Mosaic4Atsumotri.exe` をダブルクリック等で起動する。
2. 画面左上の「画像読み込み」ボタンもしくはドラッグ＆ドロップして画像ファイル（bmp, jpg, png, gif）を読み込む。
3. 画像がモザイクアートに変換されて表示されるので、それを見ながらマイデザインを作成する。

### パレットについて

![palette](https://user-images.githubusercontent.com/18702413/79063581-889f9d80-7cdd-11ea-8308-fad304efcc6a.png)

- 画像表示エリアの上部に最大 15 色のパレットが表示され、画像内で使用される色を確認できます。  
- パレットは画像内で使用されている場所が多い順に並びます。  
- パレットのどれかをクリックすると、右側にその色の「いろあい」「あざやかさ」「あかるさ」が表示されるので、色の作成に利用できます。  
- 画像の中でクリックされた色を使用してる場所がハイライト表示され、その色が使われている数が各行／各列に表示されるので、画像作成時のヒントとして利用できます。  

※ウィンドウサイズが小さいと、列方向の数字が改行されてしまうので注意が必要。  
※使用されている色が 15 色に満たない場合は残りのパレットは白色になり、クリックしても反応しません。

