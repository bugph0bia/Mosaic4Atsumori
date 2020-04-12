using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Mosaic4Atsumori
{
    /// <summary>
    /// ピクセル情報クラス
    /// </summary>
    struct Pixel
    {
        /// <summary>
        /// RGB値
        /// </summary>
        public Color Color { set; get; }
        /// <summary>
        /// 元の画像の位置
        /// </summary>
        public Point Position { set; get; }

        /// <summary>
        /// 軸色を返す
        /// </summary>
        /// <param name="axis"></param>
        /// <returns></returns>
        public int GetAxisColor(Char axis)
        {
            if (axis == 'G') return Color.G;
            if (axis == 'B') return Color.B;
            return Color.R;
        }
    }

    /// <summary>
    /// キューブ情報クラス
    /// </summary>
    class Cube
    {
        /// <summary>
        /// ピクセル情報コレクション(軸色が昇順となるようにソート済み)
        /// </summary>
        public List<Pixel> Pixels { set; get; }

        /// <summary>
        /// 軸色（'R' 'G' 'B'）
        /// </summary>
        public Char AxisColor { set; get; }

        /// <summary>
        /// 代表色
        /// </summary>
        public Color RepColor { set; get; }

        /// <summary>
        /// コンストラクタ：ビットマップから生成
        /// </summary>
        /// <param name="bmp"></param>
        public Cube(Bitmap bmp)
        {
            // ビットマップからピクセル配列を抽出
            List<Pixel> pixels = new List<Pixel>();
            for (int y = 0; y < bmp.Width; y++)
            {
                for (int x = 0; x < bmp.Height; x++)
                {
                    // ピクセル情報を格納
                    Pixel p = new Pixel();
                    p.Color = bmp.GetPixel(x, y);
                    p.Position = new Point(x, y);
                    pixels.Add(p);
                }
            }

            // 初期化
            Initialize(pixels);
        }

        /// <summary>
        /// コンストラクタ：ピクセル配列から生成
        /// </summary>
        /// <param name="pixels">ピクセル配列</param>
        public Cube(List<Pixel> pixels)
        {
            // 初期化
            Initialize(pixels);
        }

        public void Add(Cube other)
        {
            // ピクセルを連結
            Pixels.AddRange(other.Pixels);
            // 再度初期化する
            Initialize();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="pixels">ピクセル配列</param>
        private void Initialize(List<Pixel> pixels = null)
        {
            // null指定されたら保持しているピクセル情報を再利用する
            if(pixels != null) Pixels = pixels;

            //////// 軸色を決定 ////////

            // RGBそれぞれの軸長（最大値 - 最小値)を算出
            double lenR = CalcAxisLength('R');
            double lenG = CalcAxisLength('G');
            double lenB = CalcAxisLength('B');

            // RGは人間の目で識別しやすいので係数を掛けて軸色として採用され易くする
            lenR *= 1.2;
            lenG *= 1.2;

            // 規定を R とする
            AxisColor = 'R';
            if (lenG > lenR && lenG > lenB) AxisColor = 'G';
            if (lenB > lenR && lenB > lenG) AxisColor = 'B';

            //////// ピクセル配列を確定 ///////

            // 軸色の昇順でソート
            Pixels.Sort((l, r) => l.GetAxisColor(AxisColor) - r.GetAxisColor(AxisColor));

            //////// 代表色を作成 ////////

            // RGBそれぞれの平均値を使用
            RepColor = Color.FromArgb(
                Pixels.Sum(v => v.Color.R) / Pixels.Count,
                Pixels.Sum(v => v.Color.G) / Pixels.Count,
                Pixels.Sum(v => v.Color.B) / Pixels.Count);
        }

        /// <summary>
        /// 指定した軸の長さ（最大値 - 最小値）を計算
        /// </summary>
        /// <param name="axis"></param>
        /// <returns></returns>
        public int CalcAxisLength(Char axis)
        {
            if (axis == 'R') return Pixels.Max(v => v.Color.R) - Pixels.Min(v => v.Color.R);
            if (axis == 'G') return Pixels.Max(v => v.Color.G) - Pixels.Min(v => v.Color.G);
            if (axis == 'B') return Pixels.Max(v => v.Color.B) - Pixels.Min(v => v.Color.B);
            return 0;
        }
    }

    /// <summary>
    /// メディアンカットクラス
    /// </summary>
    class MedianCut
    {
        /// <summary>
        /// キューブ情報コレクション
        /// </summary>
        public List<Cube> Cubes { set; get; }

        /// <summary>
        /// 画像
        /// </summary>
        public Bitmap Bitmap { set; get; }

        /// <summary>
        /// 分割数
        /// </summary>
        public int CutCount { set; get; }

        public MedianCut(Bitmap bmp, int count)
        {
            Bitmap = bmp;
            CutCount = count;
        }

        /// <summary>
        /// 実行
        /// </summary>
        public void Run()
        {
            // 元画像から最初のキューブを作成
            Cubes = new List<Cube>();
            Cubes.Add(new Cube(Bitmap));

            // 分割数に達するまで繰り返す
            while(Cubes.Count < CutCount)
            {
                // 末尾のキューブを2分割する
                Cube maxCube = Cubes[Cubes.Count - 1];
                // これ以上分割不可
                if (maxCube.Pixels.Count == 1) break;

                // 分割点（分割後の1つ目の配列の要素数）
                int sp = (maxCube.Pixels.Count + 1) / 2 - 1;

                // 分割後の1つ目のキューブ
                List<Pixel> pixels1 = maxCube.Pixels.GetRange(0, sp);
                Cube cube1 = new Cube(pixels1);

                // 分割後の2つ目のキューブ
                List<Pixel> pixels2 = maxCube.Pixels.GetRange(sp, maxCube.Pixels.Count - sp);
                Cube cube2 = new Cube(pixels2);

                // 分割後のキューブを配列へ
                Cubes.RemoveAt(Cubes.Count - 1);
                Cubes.Add(cube1);
                Cubes.Add(cube2);

                // キューブ配列を面積（ピクセル数）でソート
                //Cubes.Sort((l, r) => l.Pixels.Count - r.Pixels.Count);
                // キューブ配列を軸長（最も分散が大きい色の最大値-最小値）でソート
                Cubes.Sort((l, r) => l.CalcAxisLength(l.AxisColor) - r.CalcAxisLength(r.AxisColor));
            }

            // 同じ代表色を持つキューブはマージする
            // ※リストの削除を伴うため降順ソート
            for (int i = Cubes.Count - 1; i >= 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if(Cubes[i].RepColor == Cubes[j].RepColor)
                    {
                        // i番目をj番目に連結して削除
                        Cubes[j].Add(Cubes[i]);
                        Cubes.RemoveAt(i);
                    }
                }
            }

            // 最終的にキューブ配列を面積（ピクセル数）の降順でソートする
            Cubes.Sort((l, r) => r.Pixels.Count - l.Pixels.Count);

            // 全キューブの代表色を使用して画像の全ピクセルを更新
            foreach (var c in Cubes)
            {
                foreach(var p in c.Pixels)
                {
                    Bitmap.SetPixel(p.Position.X, p.Position.Y, c.RepColor);
                }
            }
        }
    }
}
