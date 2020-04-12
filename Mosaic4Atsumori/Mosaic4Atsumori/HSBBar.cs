using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mosaic4Atsumori
{
    public partial class HSBBar : UserControl
    {
        /// <summary>
        /// HBarStepの初期値
        /// </summary>
        const int DEFAULT_HBAR_STEP = 30;
        /// <summary>
        /// SBarStepの初期値
        /// </summary>
        const int DEFAULT_SBAR_STEP = 15;
        /// <summary>
        /// BBarStepの初期値
        /// </summary>
        const int DEFAULT_BBAR_STEP = 15;

        /// <summary>
        /// 色相バーの刻み数
        /// </summary>
        public int HBarStep { set; get; }
        /// <summary>
        /// 彩度バーの刻み数
        /// </summary>
        public int SBarStep { set; get; }
        /// <summary>
        /// 明度バーの刻み数
        /// </summary>
        public int BBarStep { set; get; }

        /// <summary>
        /// 描画色
        /// </summary>
        private Color _drawColor;
        public Color DrawColor
        {
            set
            {
                _drawColor = value;

                // バーを再描画
                HBar.Invalidate();
                SBar.Invalidate();
                BBar.Invalidate();
            }
            get
            {
                return _drawColor;
            }
        }

        /// <summary>
        /// HBarラベル
        /// </summary>
        public string HBarLabel
        {
            set
            {
                LabelH.Text = value;
            }
            get
            {
                return LabelH.Text;
            }
        }

        /// <summary>
        /// SBarラベル
        /// </summary>
        public string SBarLabel
        {
            set
            {
                LabelS.Text = value;
            }
            get
            {
                return LabelS.Text;
            }
        }

        /// <summary>
        /// BBarラベル
        /// </summary>
        public string BBarLabel
        {
            set
            {
                LabelB.Text = value;
            }
            get
            {
                return LabelB.Text;
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public HSBBar()
        {
            InitializeComponent();

            DrawColor = Color.White;
            HBarStep = DEFAULT_HBAR_STEP;
            SBarStep = DEFAULT_SBAR_STEP;
            BBarStep = DEFAULT_BBAR_STEP;
        }

        /// <summary>
        /// マーカー色を取得
        /// </summary>
        /// <returns></returns>
        public Color GetMarkerColor()
        {
            // 描画色の色相を180度反転した色
            return ColorFromHSB(DrawColor.GetHue() + 180.0, 1.0, 1.0);
        }

        private void HSBBar_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// イベント：色相バーの再描画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HBar_Paint(object sender, PaintEventArgs e)
        {
            DrawHBar(e.Graphics);
        }

        /// <summary>
        /// イベント：彩度バーの再描画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBar_Paint(object sender, PaintEventArgs e)
        {
            DrawSBar(e.Graphics);
        }

        /// <summary>
        /// イベント：明度バーの再描画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BBar_Paint(object sender, PaintEventArgs e)
        {
            DrawBBar(e.Graphics);
        }

        /// <summary>
        /// イベント：再描画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSBBar_Paint(object sender, PaintEventArgs e)
        {
            // バーを再描画
            HBar.Invalidate();
            SBar.Invalidate();
            BBar.Invalidate();
        }

        /// <summary>
        /// 色相バー描画
        /// </summary>
        private void DrawHBar(Graphics g)
        {
            // 色配列を作成
            var colors = new List<Color>();
            for (int i = 0; i < HBarStep; i++)
            {
                colors.Add(ColorFromHSB(360.0 / HBarStep * i, 1.0, 1.0));
            }

            // 描画
            DrawBar(g, HBar, colors, (int)(DrawColor.GetHue() / 360.0 * HBarStep));
        }

        /// <summary>
        /// 彩度バー描画
        /// </summary>
        private void DrawSBar(Graphics g)
        {
            // 色配列を作成
            var colors = new List<Color>();
            for (int i = 0; i < SBarStep; i++)
            {
                colors.Add(ColorFromHSB(DrawColor.GetHue(), (double)i / SBarStep, DrawColor.GetBrightness()));
            }

            // 描画
            DrawBar(g, SBar, colors, (int)(DrawColor.GetSaturation() * SBarStep));
        }

        /// <summary>
        /// 明度バー描画
        /// </summary>
        private void DrawBBar(Graphics g)
        {
            // 色配列を作成
            var colors = new List<Color>();
            for (int i = 0; i < BBarStep; i++)
            {
                colors.Add(ColorFromHSB(DrawColor.GetHue(), DrawColor.GetSaturation(), (double)i / BBarStep));
            }

            // 描画
            DrawBar(g, BBar, colors, (int)(DrawColor.GetBrightness() * BBarStep));
        }

        /// <summary>
        /// バー描画
        /// </summary>
        /// <param name="g"></param>
        /// <param name="bar"></param>
        /// <param name="colors"></param>
        /// <param name="Selected"></param>
        private void DrawBar(Graphics g, PictureBox bar, List<Color> colors, int Selected)
        {
            int x = 0;
            int y = 0;
            int h = bar.Height;

            // 選択値がMAXの場合は右端を選択するように補正する
            if (Selected == colors.Count) Selected -= 1;

            // ステップごとに描画
            for (int i = 0; i < colors.Count; i++)
            {
                int w = (int)(bar.Width * ((double)(i + 1) / colors.Count)) - x;
                g.FillRectangle(new SolidBrush(colors[i]), x, y, w, h);

                // 描画色のインデックスなら
                if(i == Selected)
                {
                    g.DrawRectangle(new Pen(GetMarkerColor(), 2), x, y, w - 2, h - 2);
                }

                x += w;
            }
        }

        /// <summary>
        /// HSBからColorを作成
        /// </summary>
        /// <param name="h"></param>
        /// <param name="s"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private Color ColorFromHSB(double h, double s, double b)
        {
            // H を 0.0 ～ 359.0 とする
            h = h % 360.0;

            // 計算用の値
            double h2 = h / 60 % 1.0;
            double calA = b * 255.0;
            double calB = b * (1.0 - s) * 255.0;
            double calC = b * (1.0 - s * h2) * 255.0;
            double calD = b * (1.0 - s * (1.0 - h2)) * 255.0;

            int R, G, B;
            if(s == 0)
            {
                R = (int)calA;
                G = (int)calA;
                B = (int)calA;
            }
            else if (h < 60)
            {
                R = (int)calA;
                G = (int)calD;
                B = (int)calB;
            }
            else if (h < 120)
            {
                R = (int)calC;
                G = (int)calA;
                B = (int)calB;
            }
            else if (h < 180)
            {
                R = (int)calB;
                G = (int)calA;
                B = (int)calD;
            }
            else if (h < 240)
            {
                R = (int)calB;
                G = (int)calC;
                B = (int)calA;
            }
            else if (h < 300)
            {
                R = (int)calD;
                G = (int)calB;
                B = (int)calA;
            }
            else
            {
                R = (int)calA;
                G = (int)calB;
                B = (int)calC;
            }

            return Color.FromArgb(R, G, B);
        }
    }
}
