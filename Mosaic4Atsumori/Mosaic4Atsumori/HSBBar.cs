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
    /// <summary>
    /// HSBバーコントロールクラス
    /// </summary>
    public partial class HSBBar : UserControl
    {

        #region 定数

        /// <summary>
        /// HBarStepの初期値
        /// </summary>
        const int DEFAULT_HBAR_STEP_COUNT = 30;
        /// <summary>
        /// SBarStepの初期値
        /// </summary>
        const int DEFAULT_SBAR_STEP_COUNT = 15;
        /// <summary>
        /// BBarStepの初期値
        /// </summary>
        const int DEFAULT_BBAR_STEP_COUNT = 15;

        #endregion

        #region プロパティ

        /// <summary>
        /// 色相バーのステップの数
        /// </summary>
        public int HBarStepCount { set; get; }

        /// <summary>
        /// 彩度バーのステップの数
        /// </summary>
        public int SBarStepCount { set; get; }

        /// <summary>
        /// 明度バーのステップの数
        /// </summary>
        public int BBarStepCount { set; get; }

        /// <summary>
        /// 選択色
        /// </summary>
        private Color _selectedColor;
        public Color SelectedColor
        {
            set
            {
                _selectedColor = value;
                // バーを再描画
                Redraw();
            }
            get
            {
                return _selectedColor;
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

        #endregion

        #region イベント

        /// <summary>
        /// イベント：コントロールロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            Redraw();
        }

        #endregion

        #region メソッド

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public HSBBar()
        {
            InitializeComponent();

            // メンバを初期化
            SelectedColor = Color.Empty;
            HBarStepCount = DEFAULT_HBAR_STEP_COUNT;
            SBarStepCount = DEFAULT_SBAR_STEP_COUNT;
            BBarStepCount = DEFAULT_BBAR_STEP_COUNT;
        }

        /// <summary>
        /// マーカー色を取得
        /// </summary>
        /// <returns>色データ</returns>
        public Color GetMarkerColor()
        {
            // 補色をマーカー色とする
            return ColorUtil.GetComplementaryColor(SelectedColor);
        }

        /// <summary>
        /// 色相バー描画
        /// </summary>
        /// <param name="g">グラフィックオブジェクト</param>
        private void DrawHBar(Graphics g)
        {
            // 色配列を作成
            var colors = new List<Color>();
            for (int i = 0; i < HBarStepCount; i++)
            {
                colors.Add(ColorUtil.FromHSB(ColorUtil.HMAX / HBarStepCount * i, ColorUtil.SMAX, ColorUtil.BMAX));
            }

            // 描画
            DrawBar(g, HBar, colors, ColorUtil.GetHueStep(SelectedColor, HBarStepCount));
        }

        /// <summary>
        /// 彩度バー描画
        /// </summary>
        /// <param name="g">グラフィックオブジェクト</param>
        private void DrawSBar(Graphics g)
        {
            // 色配列を作成
            var colors = new List<Color>();
            for (int i = 0; i < SBarStepCount; i++)
            {
                colors.Add(ColorUtil.FromHSB(SelectedColor.GetHue(), (float)i / SBarStepCount, SelectedColor.GetBrightness()));
            }

            // 描画
            DrawBar(g, SBar, colors, ColorUtil.GetSaturationStep(SelectedColor, SBarStepCount));
        }

        /// <summary>
        /// 明度バー描画
        /// </summary>
        /// <param name="g">グラフィックオブジェクト</param>
        private void DrawBBar(Graphics g)
        {
            // 色配列を作成
            var colors = new List<Color>();
            for (int i = 0; i < BBarStepCount; i++)
            {
                colors.Add(ColorUtil.FromHSB(SelectedColor.GetHue(), SelectedColor.GetSaturation(), (float)i / BBarStepCount));
            }

            // 描画
            DrawBar(g, BBar, colors, ColorUtil.GetBrightnessStep(SelectedColor, BBarStepCount));
        }

        /// <summary>
        /// バー描画
        /// </summary>
        /// <param name="g">グラフィックオブジェクト</param>
        /// <param name="bar">対象のバー（ピクチャーボックス）</param>
        /// <param name="colors">描画色コレクション（要素数=選択色の対象のHSB値のステップ総数）</param>
        /// <param name="step">選択色の対象のHSB値のステップ値</param>
        private void DrawBar(Graphics g, PictureBox bar, List<Color> colors, int step)
        {
            int x = 0;
            int y = 0;
            int h = bar.Height;

            // ステップごとに描画
            for (int i = 0; i < colors.Count; i++)
            {
                int w = (int)(bar.Width * ((double)(i + 1) / colors.Count)) - x;
                g.FillRectangle(new SolidBrush(colors[i]), x, y, w, h);

                // 選択色のステップ値なら
                if(i == step)
                {
                    // 枠線を描画
                    g.DrawRectangle(new Pen(GetMarkerColor(), 2), x, y, w - 2, h - 2);
                }

                x += w;
            }
        }

        /// <summary>
        /// 再描画
        /// </summary>
        private void Redraw()
        {
            // 3つのバーを再描画
            HBar.Invalidate();
            SBar.Invalidate();
            BBar.Invalidate();
        }

        #endregion
    }
}
