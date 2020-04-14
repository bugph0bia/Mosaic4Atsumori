using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mosaic4Atsumori
{
    /// <summary>
    /// メインフォーム
    /// </summary>
    public partial class FormMain : Form
    {
        #region 定数

        /// <summary>
        /// 画像の幅
        /// </summary>
        const int IMAGE_WIDTH = 32;

        /// <summary>
        /// 画像の高さ
        /// </summary>
        const int IMAGE_HEIGHT = 32;

        /// <summary>
        /// 画像の使用する色数
        /// </summary>
        const int COLOR_MAX = 15;

        /// <summary>
        /// 色相のステップ総数
        /// </summary>
        const int HSTEP_COUNT = 30;

        /// <summary>
        /// 彩度のステップ総数
        /// </summary>
        const int SSTEP_COUNT = 15;

        /// <summary>
        /// 明度のステップ総数
        /// </summary>
        const int BSTEP_COUNT = 15;

        #endregion

        #region プロパティ

        /// <summary>
        /// チェックボックス配列
        /// </summary>
        public CheckBox[] CheckBoxPallets { set; get; }

        /// <summary>
        /// 表示用画像生成オブジェクト
        /// </summary>
        DrawingImage Drawer { set; get; }

        /// <summary>
        /// 画像変換オブジェクト
        /// </summary>
        MedianCut Converter { set; get; }

        #endregion

        #region イベント

        /// <summary>
        /// イベント：フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            // 画像表示
            PictureBoxDraw.SizeMode = PictureBoxSizeMode.StretchImage;

            // ファイル選択ダイアログ
            DialogImageLoad.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            // チェックボックス配列
            CheckBoxPallets = new CheckBox[COLOR_MAX];
            CheckBoxPallets[0] = CheckBoxPallet00;
            CheckBoxPallets[1] = CheckBoxPallet01;
            CheckBoxPallets[2] = CheckBoxPallet02;
            CheckBoxPallets[3] = CheckBoxPallet03;
            CheckBoxPallets[4] = CheckBoxPallet04;
            CheckBoxPallets[5] = CheckBoxPallet05;
            CheckBoxPallets[6] = CheckBoxPallet06;
            CheckBoxPallets[7] = CheckBoxPallet07;
            CheckBoxPallets[8] = CheckBoxPallet08;
            CheckBoxPallets[9] = CheckBoxPallet09;
            CheckBoxPallets[10] = CheckBoxPallet10;
            CheckBoxPallets[11] = CheckBoxPallet11;
            CheckBoxPallets[12] = CheckBoxPallet12;
            CheckBoxPallets[13] = CheckBoxPallet13;
            CheckBoxPallets[14] = CheckBoxPallet14;

            // パレット詳細
            HSBBarPallet.HBarLabel = "いろあい";
            HSBBarPallet.HBarStepCount = HSTEP_COUNT;
            HSBBarPallet.SBarLabel = "あざやかさ";
            HSBBarPallet.SBarStepCount = SSTEP_COUNT;
            HSBBarPallet.BBarLabel = "あかるさ";
            HSBBarPallet.BBarStepCount = BSTEP_COUNT;
        }

        /// <summary>
        /// イベント：画像読み込みボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            // ファイル選択ダイアログを表示
            if (DialogImageLoad.ShowDialog() != DialogResult.OK) return;

            // 画像ファイルを読み込み
            LoadImage(DialogImageLoad.FileName);

            // 選択したフォルダを次回に使用
            DialogImageLoad.InitialDirectory = Path.GetDirectoryName(DialogImageLoad.FileName);
            DialogImageLoad.FileName = "";
        }

        /// <summary>
        /// イベント：フォームリサイズ後
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_ResizeEnd(object sender, EventArgs e)
        {
            // フォームサイズを短辺に合わせて正方形にする
            //this.Height = this.Width = Math.Min(this.Height, this.Width);
        }

        /// <summary>
        /// イベント：ドラッグ開始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            // エクスプローラからのファイルドラッグの場合は許可する
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// イベント：ドロップ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            // ドロップされたファイルパスを取得
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            // 最初の画像ファイルを読み込む
            LoadImage(files[0]);
        }

        /// <summary>
        /// イベント：チェックボックスボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxPalletXX_CheckedChanged(object sender, EventArgs e)
        {
            // 操作されたチェックボックス
            CheckBox cbCurrent = (CheckBox)sender;

            // チェックONにされた場合
            if (cbCurrent.CheckState == CheckState.Checked)
            {
                // 操作されていないチェックボックスを全てOFFにする
                foreach (var cb in CheckBoxPallets)
                {
                    if (cb.Name != cbCurrent.Name)
                    {
                        cb.CheckState = CheckState.Unchecked;
                    }
                }

                // パレット詳細を更新
                HSBBarPallet.SelectedColor = cbCurrent.BackColor;
            }

            // ピクチャーボックスの描画イベント発行
            PictureBoxDraw.Invalidate();
        }

        /// <summary>
        /// イベント：ピクチャーボックス再描画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxDraw_Paint(object sender, PaintEventArgs e)
        {
            if(Drawer != null)
            {
                // パレット選択状態を設定
                Drawer.SelectedPallet = -1;
                int i = 0;
                foreach (var cb in CheckBoxPallets)
                {
                    if (cb.CheckState == CheckState.Checked)
                    {
                        Drawer.SelectedPallet = i;
                        break;
                    }
                    i++;
                }

                // ハイライト色を設定（選択中パレットの補色）
                if(Drawer.SelectedPallet >= 0 && Drawer.SelectedPallet < Converter.Cubes.Count)
                {
                    Drawer.HighLightColor = ColorUtil.GetComplementaryColor(Converter.Cubes[Drawer.SelectedPallet].RepColor);
                }

                // 画像を表示する
                Bitmap bmp = Drawer.Execute(PictureBoxDraw.Size);

                //// チェックOFFならアンチエイリアシング無し
                //if (CheckBoxSmooth.CheckState != CheckState.Checked)
                //    e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                e.Graphics.DrawImage(bmp, 0, 0, PictureBoxDraw.Width, PictureBoxDraw.Height);
            }
        }

        #endregion

        #region メソッド

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 画像ファイルの読み込み
        /// </summary>
        /// <param name="strFilePath">ファイルパス</param>
        private void LoadImage(string strFilePath)
        {
            // 選択されたファイルパスをラベルに表示
            LabelFileName.Text = strFilePath;

            try
            {
                // 画像ファイルを読み込んで、Imageオブジェクトを作成する
                using (Image imgOrg = Image.FromFile(strFilePath))
                {
                    // 表示用画像を作成
                    MakeDrawingImage(imgOrg);
                }
            }
            catch
            {
                // エラー
                LabelFileName.Text = "画像ファイルを読み込めませんでした";
            }

            // ピクチャーボックスの描画イベント発行
            PictureBoxDraw.Invalidate();
        }

        /// <summary>
        /// 表示用画像作成
        /// </summary>
        /// <param name="imgOrg">変換前画像データ</param>
        /// <returns></returns>
        private void MakeDrawingImage(Image imgOrg)
        {
            // 画像の正方形化(32x32)
            int w = IMAGE_WIDTH;
            int h = IMAGE_HEIGHT;
            Bitmap bmpMosaic = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(bmpMosaic))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(imgOrg, 0, 0, w, h);
            }

            // 画像メディアンカットによる減色(15色)
            Converter = new MedianCut(bmpMosaic, COLOR_MAX);
            Converter.Run(HSTEP_COUNT, SSTEP_COUNT, BSTEP_COUNT);

            // 表示用画像用オブジェクトを生成
            Drawer = new DrawingImage(Converter);

            // 画面にパレットを表示
            int i = 0;
            foreach(var cb in CheckBoxPallets)
            {
                // チェックボタンの背景色を設定
                if (i < Converter.Cubes.Count) cb.BackColor = Converter.Cubes[i].RepColor;
                else cb.BackColor = Color.White;

                // チェックをOFFにする
                cb.CheckState = CheckState.Unchecked;
                i++;
            }
        }

        #endregion
    }
}
