using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Mosaic4Atsumori
{
    /// <summary>
    /// 表示用画像生成クラス
    /// </summary>
    class DrawingImage
    {
        #region 定数

        /// <summary>
        /// 上下左右の余白(割合)
        /// </summary>
        const double MARGIN_RATIO = 0.05;

        /// <summary>
        /// 行列方向のテキストエリア(割合)
        /// </summary>
        const double TEXT_AREA_RATIO = 0.15;

        /// <summary>
        /// 色定義：背景
        /// </summary>
        readonly Color C_BACKGROUND = Color.White;

        /// <summary>
        /// 色定義：線
        /// </summary>
        readonly Color C_BORDER = Color.DarkGray;

        /// <summary>
        /// 色定義：中心線
        /// </summary>
        readonly Color C_BORDER_CENTER = Color.Black;

        /// <summary>
        ///  色定義：ハイライト
        /// </summary>
        readonly Color C_HIGHLIGHT = Color.Magenta;

        #endregion

        #region プロパティ

        /// <summary>
        /// ハイライト色（外部指定可能とする）
        /// </summary>
        public Color HighLightColor { set; get; }

        /// <summary>
        /// モザイク画像生成オブジェクト
        /// </summary>
        public MedianCut Converter { set; get; }

        /// <summary>
        /// 選択中のパレット
        /// </summary>
        public int SelectedPallet { set; get; }

        /// <summary>
        /// セルの枠線描画フラグ
        /// </summary>
        public bool IsDrawBorder { set; get; }

        #endregion

        #region メソッド

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="c">メディアンカットオブジェクト</param>
        public DrawingImage(MedianCut c)
        {
            Converter = c;
            SelectedPallet = 2;
            IsDrawBorder = true;
            HighLightColor = C_HIGHLIGHT;
        }

        /// <summary>
        /// 表示用画像生成
        /// </summary>
        /// <param name="imageSize">画像サイズ</param>
        /// <returns>表示用画像</returns>
        public Bitmap Execute(Size imageSize)
        {
            // 画像を作成
            Bitmap bmp = new Bitmap(imageSize.Width, imageSize.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                // 背景を初期化
                g.FillRectangle(new SolidBrush(C_BACKGROUND), 0, 0, bmp.Size.Width, bmp.Size.Height);

                // モザイク画像を配置
                for (int y = 0; y < Converter.BitmapData.Size.Height; y++)
                {
                    for (int x = 0; x < Converter.BitmapData.Size.Width; x++)
                    {
                        FillCell(g, imageSize, x, y, Converter.BitmapData.GetPixel(x, y));
                    }
                }

                // 枠線を描画
                if (IsDrawBorder)
                {
                    // セルの枠線
                    for (int y = 0; y < Converter.BitmapData.Size.Height; y++)
                    {
                        for (int x = 0; x < Converter.BitmapData.Size.Width; x++)
                        {
                            DrawCell(g, imageSize, x, y, C_BORDER, 1);
                        }
                    }

                    // セルの中心線
                    DrawCenterLine(g, imageSize, Converter.BitmapData.Size, C_BORDER_CENTER, 2);

                    if (SelectedPallet >= 0 && SelectedPallet < Converter.Cubes.Count)
                    {
                        // 選択中パレットの該当セルの枠線をハイライト
                        foreach (var p in Converter.Cubes[SelectedPallet].Pixels)
                        {
                            DrawCell(g, imageSize, p.Position.X, p.Position.Y, HighLightColor, 2);
                        }
                    }

                    // テキストエリアの枠線と数値
                    for (int x = 0; x < Converter.BitmapData.Size.Width; x++)
                    {
                        DrawTextArea(g, imageSize, x, 1, C_BORDER, 1);

                        if (SelectedPallet >= 0 && SelectedPallet < Converter.Cubes.Count)
                        {
                            DrawText(g, imageSize, x, 1, Color.Black);
                        }
                    }
                    for (int y = 0; y < Converter.BitmapData.Size.Height; y++)
                    {
                        DrawTextArea(g, imageSize, y, 0, C_BORDER, 1);

                        if (SelectedPallet >= 0 && SelectedPallet < Converter.Cubes.Count)
                        {
                            DrawText(g, imageSize, y, 0, Color.Black);
                        }
                    }
                }
            }

            return bmp;
        }

        /// <summary>
        /// 指定したセルの枠線を描画
        /// </summary>
        /// <param name="g">グラフィックオブジェクト</param>
        /// <param name="imageSize">画像サイズ</param>
        /// <param name="x">セル位置X</param>
        /// <param name="y">セル位置Y</param>
        /// <param name="c">描画色</param>
        /// <param name="penWidth">ペン幅</param>
        private void DrawCell(Graphics g, Size imageSize, int x, int y, Color c, int penWidth)
        {
            // セルの位置とサイズを計算
            int px, py, pw, ph;
            CalcCellRect(
                imageSize,
                x, y, out px, out py, out pw, out ph
            );

            // ハイライトの場合は描画する線をセルの内側に補正する
            if(c == HighLightColor)
            {
                px += penWidth;
                py += penWidth;
                pw -= penWidth * 2 - 1;
                ph -= penWidth * 2 - 1;
            }

            g.DrawRectangle(new Pen(c, penWidth), px, py, pw, ph);
        }

        /// <summary>
        /// 指定したセルを塗り潰す
        /// </summary>
        /// <param name="g">グラフィックオブジェクト</param>
        /// <param name="imageSize">画像サイズ</param>
        /// <param name="x">セル位置X</param>
        /// <param name="y">セル位置Y</param>
        /// <param name="c">描画色</param>
        private void FillCell(Graphics g, Size imageSize, int x, int y, Color c)
        {
            // セルの位置とサイズを計算
            int px, py, pw, ph;
            CalcCellRect(
                imageSize,
                x, y, out px, out py, out pw, out ph
            );

            g.FillRectangle(new SolidBrush(c), px, py, pw, ph);
        }

        /// <summary>
        /// 指定したテキストエリアの枠線を描画
        /// </summary>
        /// <param name="g">グラフィックオブジェクト</param>
        /// <param name="imageSize">画像サイズ</param>
        /// <param name="xy">セル位置(縦方向:X 横方向:Y)</param>
        /// <param name="dir">テキストエリアの方向(縦/横)</param>
        /// <param name="c">描画色</param>
        /// <param name="penWidth">ペン幅</param>
        private void DrawTextArea(Graphics g, Size imageSize, int xy, int dir, Color c, int penWidth)
        {
            // テキストエリアの位置とサイズを計算
            int px, py, pw, ph;
            CalcTextAreaRect(
                imageSize,
                xy, dir, out px, out py, out pw, out ph
            );

            // 横方向のテキストエリアの場合
            if (dir == 0)
            {
                g.DrawLine(new Pen(c, penWidth), px, py, px + pw, py);
                g.DrawLine(new Pen(c, penWidth), px, py + ph, px + pw, py + ph);
            }
            // 縦方向のテキストエリアの場合
            else if (dir == 1)
            {
                g.DrawLine(new Pen(c, penWidth), px, py, px, py + ph);
                g.DrawLine(new Pen(c, penWidth), px + pw, py, px + pw, py + ph);
            }
        }

        /// <summary>
        /// 指定したテキストエリアのテキストを描画
        /// </summary>
        /// <param name="g">グラフィックオブジェクト</param>
        /// <param name="imageSize">画像サイズ</param>
        /// <param name="xy">位置(縦方向:X 横方向:Y)</param>
        /// <param name="dir">テキストエリアの方向(縦/横)</param>
        /// <param name="c">描画色</param>
        private void DrawText(Graphics g, Size imageSize, int xy, int dir, Color c)
        {
            // テキストエリアの位置とサイズを計算
            int px, py, pw, ph;
            CalcTextAreaRect(
                imageSize,
                xy, dir, out px, out py, out pw, out ph
            );

            // 選択色
            Color SelectedColor = Converter.Cubes[SelectedPallet].RepColor;

            // 横方向のテキストエリアの場合
            if (dir == 0)
            {
                string strNum = "";

                // 選択色が連続する数を取得
                int num = 0;
                for (int i=0; i<Converter.BitmapData.Width; i++)
                {
                    Color c1 = Converter.BitmapData.GetPixel(i, xy);
                    Color c2 = SelectedColor;

                    if (c1.R == c2.R && c1.G == c2.G && c1.B == c2.B)
                    //if(c1 == c2)
                    {
                        num++;
                    }
                    else
                    {
                        if (num != 0) strNum += (num.ToString() + " ");
                        num = 0;
                    }
                }
                if (num != 0) strNum += (num.ToString() + "  ");

                // テキストアライメント：右寄せ
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Far;
                sf.LineAlignment = StringAlignment.Center;

                using (Font font = new Font("MS Ｐゴシック", 8, FontStyle.Regular, GraphicsUnit.Point))
                {
                    g.DrawString(
                        strNum, font, new SolidBrush(c),
                        new RectangleF(px, py, pw, ph), sf
                    );
                }
            }
            // 縦方向のテキストエリアの場合
            else if (dir == 1)
            {
                string strNum = "";

                // 選択色が連続する数を取得
                int num = 0;
                for (int i = 0; i < Converter.BitmapData.Height; i++)
                {
                    Color c1 = Converter.BitmapData.GetPixel(xy, i);
                    Color c2 = SelectedColor;

                    if (c1.R == c2.R && c1.G == c2.G && c1.B == c2.B)
                    //if (c1 == c2)
                    {
                        num++;
                    }
                    else
                    {
                        if (num != 0) strNum += (num.ToString() + "\n");
                        num = 0;
                    }
                }
                if (num != 0) strNum += (num.ToString() + "\n");

                // テキストアライメント：下寄せ
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Far;

                using (Font font = new Font("@MS Ｐゴシック", 8, FontStyle.Regular, GraphicsUnit.Point))
                {
                    g.DrawString(
                        strNum, font, new SolidBrush(c),
                        new RectangleF(px, py, pw, ph), sf
                    );
                }
            }
        }

        /// <summary>
        /// セルの中心線の描画
        /// </summary>
        /// <param name="g">グラフィックオブジェクト</param>
        /// <param name="imageSize">画像サイズ</param>
        /// <param name="x">セル位置X</param>
        /// <param name="y">セル位置Y</param>
        /// <param name="c">描画色</param>
        /// <param name="penWidth">ペン幅</param>
        private void DrawCenterLine(Graphics g, Size imageSize, Size cellSize, Color c, int penWidth)
        {
            // 中心のセル
            int centerX = cellSize.Width / 2;
            int centerY = cellSize.Height / 2;

            // 縦方向に描画
            for (int y = 0; y < cellSize.Height; y++)
            {
                // セルの位置とサイズを計算
                int px, py, pw, ph;
                CalcCellRect(imageSize,
                    centerX, y,
                    out px, out py, out pw, out ph
                );

                g.DrawLine(new Pen(c, penWidth), px, py, px, py + ph);
            }

            // 横方向に描画
            for (int x = 0; x < cellSize.Width; x++)
            {
                // 隣接するセルの位置とサイズを計算
                int px, py, pw, ph;
                CalcCellRect(imageSize,
                    x, centerY,
                    out px, out py, out pw, out ph
                );

                g.DrawLine(new Pen(c, penWidth), px, py, px + pw, py);
            }
        }

        /// <summary>
        /// セルの位置とサイズを計算
        /// </summary>
        /// <param name="imageSize">画像サイズ</param>
        /// <param name="x">セル位置X</param>
        /// <param name="y">セル位置Y</param>
        /// <param name="px">セルの左上のX座標(pixel)</param>
        /// <param name="py">セルの左上のY座標(pixel)</param>
        /// <param name="pw">セルの幅(pixel)</param>
        /// <param name="ph">セルの高さ(pixel)</param>
        private void CalcCellRect(
            Size imageSize, int x, int y,
            out int px, out int py, out int pw, out int ph)
        {
            // 余白を計算
            int marginW = (int)(imageSize.Width * MARGIN_RATIO);
            int marginH = (int)(imageSize.Height * MARGIN_RATIO);

            // テキストエリアサイズを計算
            int textAreaW = (int)(imageSize.Width * TEXT_AREA_RATIO);
            int textAreaH = (int)(imageSize.Height * TEXT_AREA_RATIO);

            // セル全域サイズを計算
            int cellAllW = imageSize.Width - (marginW * 2) - textAreaW;
            int cellAllH = imageSize.Height - (marginH * 2) - textAreaH;

            // セルのサイズを計算
            int cellW = cellAllW / Converter.BitmapData.Size.Width;
            int cellH = cellAllH / Converter.BitmapData.Size.Height;

            // 余りを計算（より左側,上側のセルに余りを+1ずつ加える）
            int remainX = cellAllW - Converter.BitmapData.Size.Width * cellW;
            int remainY = cellAllH - Converter.BitmapData.Size.Height * cellH;

            // 座標 = 余白 + テキストエリア + そのセルの左端,上端の位置 + そのセルまでに含まれる余り
            px = marginW + textAreaW + (cellW * x) + Math.Min(x, remainX);
            py = marginH + textAreaH + (cellH * y) + Math.Min(y, remainY);

            // 長さ = セルの大きさ + そのセルに余りを加算するなら+1
            pw = cellW + (x < remainX ? 1 : 0);
            ph = cellH + (y < remainY ? 1 : 0);
        }

        /// <summary>
        /// テキストエリアの位置とサイズを計算
        /// </summary>
        /// <param name="imageSize">画像サイズ</param>
        /// <param name="xy">位置(縦方向:X 横方向:Y)</param>
        /// <param name="dir">テキストエリアの方向(縦/横)</param>
        /// <param name="px">テキストエリアの左上のX座標(pixel)</param>
        /// <param name="py">テキストエリアの左上のY座標(pixel)</param>
        /// <param name="pw">テキストエリアの幅(pixel)</param>
        /// <param name="ph">テキストエリアの高さ(pixel)</param>
        private void CalcTextAreaRect(Size imageSize, int xy, int dir,
            out int px, out int py, out int pw, out int ph)
        {
            int x = 0;
            int y = 0;
            // 横方向のテキストエリアの場合
            if (dir == 0)
            {
                x = 0;
                y = xy;
            }
            // 縦方向のテキストエリアの場合
            else if (dir == 1)
            {
                x = xy;
                y = 0;
            }

            // 隣接するセルの位置とサイズを計算
            CalcCellRect(imageSize,
                x, y,
                out px, out py, out pw, out ph
            );

            // テキストエリアサイズを計算
            int textAreaW = (int)(imageSize.Width * TEXT_AREA_RATIO);
            int textAreaH = (int)(imageSize.Height * TEXT_AREA_RATIO);

            // 横方向のテキストエリアの場合
            if (dir == 0)
            {
                px -= textAreaW;
                pw = textAreaW;
            }
            // 縦方向のテキストエリアの場合
            else if (dir == 1)
            {
                py -= textAreaH;
                ph = textAreaH;
            }
        }

        #endregion
    }
}