using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Mosaic4Atsumori
{
    /// <summary>
    /// 軸色の列挙型
    /// </summary>
    enum AxisColor { R, G, B }

    /// <summary>
    /// ピクセル情報クラス
    /// </summary>
    struct Pixel
    {
        #region プロパティ

        /// <summary>
        /// RGB値
        /// </summary>
        public Color Color { set; get; }
        /// <summary>
        /// 元の画像の位置
        /// </summary>
        public Point Position { set; get; }

        #endregion

        #region メソッド

        /// <summary>
        /// 軸色の値を返す
        /// </summary>
        /// <param name="axis">軸</param>
        /// <returns>軸色の値</returns>
        public byte GetAxisColor(AxisColor axis)
        {
            switch (axis)
            {
                case AxisColor.R:
                default:
                    return Color.R;
                case AxisColor.G:
                    return Color.G;
                case AxisColor.B:
                    return Color.B;
            }

            #endregion
        }
    }
    /// <summary>
    /// キューブ情報クラス
    /// </summary>
    class Cube
    {
        #region プロパティ

        /// <summary>
        /// ピクセル情報コレクション(軸色が昇順となるようにソート済み)
        /// </summary>
        public List<Pixel> Pixels { set; get; }

        /// <summary>
        /// 軸色（'R' 'G' 'B'）
        /// </summary>
        public AxisColor Axis { set; get; }

        /// <summary>
        /// 代表色
        /// </summary>
        public Color RepColor { set; get; }

        #endregion

        #region メソッド

        /// <summary>
        /// コンストラクタ：ビットマップから生成
        /// </summary>
        /// <param name="bmp">元データとするビットマップ</param>
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
        /// <param name="pixels">元データとするピクセル配列</param>
        public Cube(List<Pixel> pixels)
        {
            // 初期化
            Initialize(pixels);
        }

        /// <summary>
        /// 別のCubeオブジェクトを連結
        /// </summary>
        /// <param name="other">別のCubeオブジェクト</param>
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
        /// <param name="pixels">元データとするピクセル配列</param>
        private void Initialize(List<Pixel> pixels = null)
        {
            // 元データが指定されていればピクセル情報を更新する
            if (pixels != null) Pixels = pixels;

            //////// 軸色を決定 ////////

            // RGBそれぞれの軸長（最大値 - 最小値)を算出
            double lenR = CalcAxisLength(AxisColor.R);
            double lenG = CalcAxisLength(AxisColor.G);
            double lenB = CalcAxisLength(AxisColor.B);

            // RGは人間の目で識別しやすいので係数を掛けて軸色として採用され易くする
            lenR *= 1.2;
            lenG *= 1.2;

            // 規定を R とする
            Axis = AxisColor.R;
            if (lenG > lenR && lenG > lenB) Axis = AxisColor.G;
            if (lenB > lenR && lenB > lenG) Axis = AxisColor.B;

            //////// ピクセル配列を確定 ///////

            // 軸色の昇順でソート
            Pixels.Sort((l, r) => l.GetAxisColor(Axis) - r.GetAxisColor(Axis));

            //////// 代表色を作成 ////////

            // RGBそれぞれの平均値を使用
            RepColor = Color.FromArgb(
                Pixels.Sum(v => v.Color.R) / Pixels.Count,
                Pixels.Sum(v => v.Color.G) / Pixels.Count,
                Pixels.Sum(v => v.Color.B) / Pixels.Count);
        }

        /// <summary>
        /// 指定した軸色の長さ（最大値 - 最小値）を計算
        /// </summary>
        /// <param name="axis">軸色</param>
        /// <returns></returns>
        public int CalcAxisLength(AxisColor axis)
        {
            switch (axis)
            {
                case AxisColor.R:
                    return Pixels.Max(v => v.Color.R) - Pixels.Min(v => v.Color.R);
                case AxisColor.G:
                    return Pixels.Max(v => v.Color.G) - Pixels.Min(v => v.Color.G);
                case AxisColor.B:
                    return Pixels.Max(v => v.Color.B) - Pixels.Min(v => v.Color.B);
            }
            return 0;
        }

        #endregion
    }

    /// <summary>
    /// メディアンカットクラス
    /// </summary>
    class MedianCut
    {
        #region プロパティ

        /// <summary>
        /// キューブ情報コレクション
        /// </summary>
        public List<Cube> Cubes { set; get; }

        /// <summary>
        /// 画像
        /// </summary>
        public Bitmap BitmapData { set; get; }

        /// <summary>
        /// 分割数
        /// </summary>
        public int CutCount { set; get; }

        #endregion

        #region メソッド

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="bmp">元データとするビットマップ</param>
        /// <param name="count">分割数</param>
        public MedianCut(Bitmap bmp, int cutCount)
        {
            BitmapData = bmp;
            CutCount = cutCount;
        }

        /// <summary>
        /// 実行
        /// </summary>
        /// <param name="HStepCount">色相のステップ総数</param>
        /// <param name="SStepCount">彩度のステップ総数</param>
        /// <param name="BStepCount">明度のステップ総数</param>
        public void Run(int HStepCount, int SStepCount, int BStepCount)
        {
            // 元画像から最初のキューブを作成
            Cubes = new List<Cube>();
            Cubes.Add(new Cube(BitmapData));

            // 分割数に達するまで繰り返す
            while (Cubes.Count < CutCount)
            {
                // 末尾のキューブを2分割する
                Cube maxCube = Cubes[Cubes.Count - 1];
                // これ以上分割不可
                if (maxCube.Pixels.Count <= 1) break;

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
                Cubes.Sort((l, r) => l.CalcAxisLength(l.Axis) - r.CalcAxisLength(r.Axis));
            }

            // HSB値の全ステップ値が一致する代表色を持つキューブはマージする
            // ※リストの削除を伴うため降順ソート
            for (int i = Cubes.Count - 1; i >= 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (ColorUtil.EqualHSBSteps(Cubes[i].RepColor, Cubes[j].RepColor, HStepCount, SStepCount, BStepCount))
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
                foreach (var p in c.Pixels)
                {
                    BitmapData.SetPixel(p.Position.X, p.Position.Y, c.RepColor);
                }
            }
        }

        #endregion
    }
}
