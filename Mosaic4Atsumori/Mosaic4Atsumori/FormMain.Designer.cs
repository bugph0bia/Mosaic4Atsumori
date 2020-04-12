namespace Mosaic4Atsumori
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonLoad = new System.Windows.Forms.Button();
            this.DialogImageLoad = new System.Windows.Forms.OpenFileDialog();
            this.LabelFileName = new System.Windows.Forms.Label();
            this.PictureBoxDraw = new System.Windows.Forms.PictureBox();
            this.CheckBoxPallet00 = new System.Windows.Forms.CheckBox();
            this.CheckBoxPallet01 = new System.Windows.Forms.CheckBox();
            this.CheckBoxPallet02 = new System.Windows.Forms.CheckBox();
            this.CheckBoxPallet03 = new System.Windows.Forms.CheckBox();
            this.CheckBoxPallet04 = new System.Windows.Forms.CheckBox();
            this.CheckBoxPallet05 = new System.Windows.Forms.CheckBox();
            this.CheckBoxPallet06 = new System.Windows.Forms.CheckBox();
            this.CheckBoxPallet07 = new System.Windows.Forms.CheckBox();
            this.CheckBoxPallet08 = new System.Windows.Forms.CheckBox();
            this.CheckBoxPallet09 = new System.Windows.Forms.CheckBox();
            this.CheckBoxPallet10 = new System.Windows.Forms.CheckBox();
            this.CheckBoxPallet11 = new System.Windows.Forms.CheckBox();
            this.CheckBoxPallet12 = new System.Windows.Forms.CheckBox();
            this.CheckBoxPallet13 = new System.Windows.Forms.CheckBox();
            this.CheckBoxPallet14 = new System.Windows.Forms.CheckBox();
            this.HSBBarPallet = new Mosaic4Atsumori.HSBBar();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxDraw)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonLoad
            // 
            this.ButtonLoad.Location = new System.Drawing.Point(12, 37);
            this.ButtonLoad.Name = "ButtonLoad";
            this.ButtonLoad.Size = new System.Drawing.Size(92, 52);
            this.ButtonLoad.TabIndex = 0;
            this.ButtonLoad.Text = "画像読み込み";
            this.ButtonLoad.UseVisualStyleBackColor = true;
            this.ButtonLoad.Click += new System.EventHandler(this.ButtonLoad_Click);
            // 
            // DialogImageLoad
            // 
            this.DialogImageLoad.Filter = "画像ファイル(*.bmp;*.jpg;*.png;*gif)|*.bmp;*.jpg;*.png;*gif|すべてのファイル(*.*)|*.*";
            // 
            // LabelFileName
            // 
            this.LabelFileName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabelFileName.Location = new System.Drawing.Point(12, 12);
            this.LabelFileName.Name = "LabelFileName";
            this.LabelFileName.Size = new System.Drawing.Size(332, 23);
            this.LabelFileName.TabIndex = 1;
            this.LabelFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PictureBoxDraw
            // 
            this.PictureBoxDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureBoxDraw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureBoxDraw.Location = new System.Drawing.Point(12, 95);
            this.PictureBoxDraw.Name = "PictureBoxDraw";
            this.PictureBoxDraw.Size = new System.Drawing.Size(520, 520);
            this.PictureBoxDraw.TabIndex = 2;
            this.PictureBoxDraw.TabStop = false;
            this.PictureBoxDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxDraw_Paint);
            // 
            // CheckBoxPallet00
            // 
            this.CheckBoxPallet00.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBoxPallet00.Location = new System.Drawing.Point(110, 37);
            this.CheckBoxPallet00.Name = "CheckBoxPallet00";
            this.CheckBoxPallet00.Size = new System.Drawing.Size(24, 24);
            this.CheckBoxPallet00.TabIndex = 2;
            this.CheckBoxPallet00.UseVisualStyleBackColor = true;
            this.CheckBoxPallet00.CheckedChanged += new System.EventHandler(this.CheckBoxPalletXX_CheckedChanged);
            // 
            // CheckBoxPallet01
            // 
            this.CheckBoxPallet01.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBoxPallet01.Location = new System.Drawing.Point(140, 37);
            this.CheckBoxPallet01.Name = "CheckBoxPallet01";
            this.CheckBoxPallet01.Size = new System.Drawing.Size(24, 24);
            this.CheckBoxPallet01.TabIndex = 3;
            this.CheckBoxPallet01.UseVisualStyleBackColor = true;
            this.CheckBoxPallet01.CheckedChanged += new System.EventHandler(this.CheckBoxPalletXX_CheckedChanged);
            // 
            // CheckBoxPallet02
            // 
            this.CheckBoxPallet02.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBoxPallet02.Location = new System.Drawing.Point(170, 37);
            this.CheckBoxPallet02.Name = "CheckBoxPallet02";
            this.CheckBoxPallet02.Size = new System.Drawing.Size(24, 24);
            this.CheckBoxPallet02.TabIndex = 4;
            this.CheckBoxPallet02.UseVisualStyleBackColor = true;
            this.CheckBoxPallet02.CheckedChanged += new System.EventHandler(this.CheckBoxPalletXX_CheckedChanged);
            // 
            // CheckBoxPallet03
            // 
            this.CheckBoxPallet03.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBoxPallet03.Location = new System.Drawing.Point(200, 37);
            this.CheckBoxPallet03.Name = "CheckBoxPallet03";
            this.CheckBoxPallet03.Size = new System.Drawing.Size(24, 24);
            this.CheckBoxPallet03.TabIndex = 5;
            this.CheckBoxPallet03.UseVisualStyleBackColor = true;
            this.CheckBoxPallet03.CheckedChanged += new System.EventHandler(this.CheckBoxPalletXX_CheckedChanged);
            // 
            // CheckBoxPallet04
            // 
            this.CheckBoxPallet04.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBoxPallet04.Location = new System.Drawing.Point(230, 37);
            this.CheckBoxPallet04.Name = "CheckBoxPallet04";
            this.CheckBoxPallet04.Size = new System.Drawing.Size(24, 24);
            this.CheckBoxPallet04.TabIndex = 6;
            this.CheckBoxPallet04.UseVisualStyleBackColor = true;
            this.CheckBoxPallet04.CheckedChanged += new System.EventHandler(this.CheckBoxPalletXX_CheckedChanged);
            // 
            // CheckBoxPallet05
            // 
            this.CheckBoxPallet05.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBoxPallet05.Location = new System.Drawing.Point(260, 37);
            this.CheckBoxPallet05.Name = "CheckBoxPallet05";
            this.CheckBoxPallet05.Size = new System.Drawing.Size(24, 24);
            this.CheckBoxPallet05.TabIndex = 7;
            this.CheckBoxPallet05.UseVisualStyleBackColor = true;
            this.CheckBoxPallet05.CheckedChanged += new System.EventHandler(this.CheckBoxPalletXX_CheckedChanged);
            // 
            // CheckBoxPallet06
            // 
            this.CheckBoxPallet06.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBoxPallet06.Location = new System.Drawing.Point(290, 37);
            this.CheckBoxPallet06.Name = "CheckBoxPallet06";
            this.CheckBoxPallet06.Size = new System.Drawing.Size(24, 24);
            this.CheckBoxPallet06.TabIndex = 8;
            this.CheckBoxPallet06.UseVisualStyleBackColor = true;
            this.CheckBoxPallet06.CheckedChanged += new System.EventHandler(this.CheckBoxPalletXX_CheckedChanged);
            // 
            // CheckBoxPallet07
            // 
            this.CheckBoxPallet07.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBoxPallet07.Location = new System.Drawing.Point(320, 37);
            this.CheckBoxPallet07.Name = "CheckBoxPallet07";
            this.CheckBoxPallet07.Size = new System.Drawing.Size(24, 24);
            this.CheckBoxPallet07.TabIndex = 9;
            this.CheckBoxPallet07.UseVisualStyleBackColor = true;
            this.CheckBoxPallet07.CheckedChanged += new System.EventHandler(this.CheckBoxPalletXX_CheckedChanged);
            // 
            // CheckBoxPallet08
            // 
            this.CheckBoxPallet08.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBoxPallet08.Location = new System.Drawing.Point(110, 65);
            this.CheckBoxPallet08.Name = "CheckBoxPallet08";
            this.CheckBoxPallet08.Size = new System.Drawing.Size(24, 24);
            this.CheckBoxPallet08.TabIndex = 10;
            this.CheckBoxPallet08.UseVisualStyleBackColor = true;
            this.CheckBoxPallet08.CheckedChanged += new System.EventHandler(this.CheckBoxPalletXX_CheckedChanged);
            // 
            // CheckBoxPallet09
            // 
            this.CheckBoxPallet09.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBoxPallet09.Location = new System.Drawing.Point(140, 65);
            this.CheckBoxPallet09.Name = "CheckBoxPallet09";
            this.CheckBoxPallet09.Size = new System.Drawing.Size(24, 24);
            this.CheckBoxPallet09.TabIndex = 11;
            this.CheckBoxPallet09.UseVisualStyleBackColor = true;
            this.CheckBoxPallet09.CheckedChanged += new System.EventHandler(this.CheckBoxPalletXX_CheckedChanged);
            // 
            // CheckBoxPallet10
            // 
            this.CheckBoxPallet10.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBoxPallet10.Location = new System.Drawing.Point(170, 65);
            this.CheckBoxPallet10.Name = "CheckBoxPallet10";
            this.CheckBoxPallet10.Size = new System.Drawing.Size(24, 24);
            this.CheckBoxPallet10.TabIndex = 12;
            this.CheckBoxPallet10.UseVisualStyleBackColor = true;
            this.CheckBoxPallet10.CheckedChanged += new System.EventHandler(this.CheckBoxPalletXX_CheckedChanged);
            // 
            // CheckBoxPallet11
            // 
            this.CheckBoxPallet11.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBoxPallet11.Location = new System.Drawing.Point(200, 65);
            this.CheckBoxPallet11.Name = "CheckBoxPallet11";
            this.CheckBoxPallet11.Size = new System.Drawing.Size(24, 24);
            this.CheckBoxPallet11.TabIndex = 13;
            this.CheckBoxPallet11.UseVisualStyleBackColor = true;
            this.CheckBoxPallet11.CheckedChanged += new System.EventHandler(this.CheckBoxPalletXX_CheckedChanged);
            // 
            // CheckBoxPallet12
            // 
            this.CheckBoxPallet12.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBoxPallet12.Location = new System.Drawing.Point(230, 65);
            this.CheckBoxPallet12.Name = "CheckBoxPallet12";
            this.CheckBoxPallet12.Size = new System.Drawing.Size(24, 24);
            this.CheckBoxPallet12.TabIndex = 14;
            this.CheckBoxPallet12.UseVisualStyleBackColor = true;
            this.CheckBoxPallet12.CheckedChanged += new System.EventHandler(this.CheckBoxPalletXX_CheckedChanged);
            // 
            // CheckBoxPallet13
            // 
            this.CheckBoxPallet13.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBoxPallet13.Location = new System.Drawing.Point(260, 65);
            this.CheckBoxPallet13.Name = "CheckBoxPallet13";
            this.CheckBoxPallet13.Size = new System.Drawing.Size(24, 24);
            this.CheckBoxPallet13.TabIndex = 15;
            this.CheckBoxPallet13.UseVisualStyleBackColor = true;
            this.CheckBoxPallet13.CheckedChanged += new System.EventHandler(this.CheckBoxPalletXX_CheckedChanged);
            // 
            // CheckBoxPallet14
            // 
            this.CheckBoxPallet14.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBoxPallet14.Location = new System.Drawing.Point(290, 65);
            this.CheckBoxPallet14.Name = "CheckBoxPallet14";
            this.CheckBoxPallet14.Size = new System.Drawing.Size(24, 24);
            this.CheckBoxPallet14.TabIndex = 16;
            this.CheckBoxPallet14.UseVisualStyleBackColor = true;
            this.CheckBoxPallet14.CheckedChanged += new System.EventHandler(this.CheckBoxPalletXX_CheckedChanged);
            // 
            // HSBBarPallet
            // 
            this.HSBBarPallet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HSBBarPallet.BBarLabel = "あかるさ";
            this.HSBBarPallet.BBarStep = 15;
            this.HSBBarPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.HSBBarPallet.DrawColor = System.Drawing.Color.White;
            this.HSBBarPallet.HBarLabel = "いろあい";
            this.HSBBarPallet.HBarStep = 30;
            this.HSBBarPallet.Location = new System.Drawing.Point(350, 12);
            this.HSBBarPallet.Name = "HSBBarPallet";
            this.HSBBarPallet.SBarLabel = "あざやかさ";
            this.HSBBarPallet.SBarStep = 15;
            this.HSBBarPallet.Size = new System.Drawing.Size(244, 77);
            this.HSBBarPallet.TabIndex = 18;
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 625);
            this.Controls.Add(this.HSBBarPallet);
            this.Controls.Add(this.CheckBoxPallet14);
            this.Controls.Add(this.CheckBoxPallet13);
            this.Controls.Add(this.CheckBoxPallet12);
            this.Controls.Add(this.CheckBoxPallet11);
            this.Controls.Add(this.CheckBoxPallet10);
            this.Controls.Add(this.CheckBoxPallet09);
            this.Controls.Add(this.CheckBoxPallet08);
            this.Controls.Add(this.CheckBoxPallet07);
            this.Controls.Add(this.CheckBoxPallet06);
            this.Controls.Add(this.CheckBoxPallet05);
            this.Controls.Add(this.CheckBoxPallet04);
            this.Controls.Add(this.CheckBoxPallet03);
            this.Controls.Add(this.CheckBoxPallet02);
            this.Controls.Add(this.CheckBoxPallet01);
            this.Controls.Add(this.CheckBoxPallet00);
            this.Controls.Add(this.PictureBoxDraw);
            this.Controls.Add(this.LabelFileName);
            this.Controls.Add(this.ButtonLoad);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "あつ森 マイデザイン作成 V0.0.1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResizeEnd += new System.EventHandler(this.FormMain_ResizeEnd);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxDraw)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonLoad;
        private System.Windows.Forms.OpenFileDialog DialogImageLoad;
        private System.Windows.Forms.Label LabelFileName;
        private System.Windows.Forms.PictureBox PictureBoxDraw;
        private System.Windows.Forms.CheckBox CheckBoxPallet00;
        private System.Windows.Forms.CheckBox CheckBoxPallet01;
        private System.Windows.Forms.CheckBox CheckBoxPallet02;
        private System.Windows.Forms.CheckBox CheckBoxPallet03;
        private System.Windows.Forms.CheckBox CheckBoxPallet04;
        private System.Windows.Forms.CheckBox CheckBoxPallet05;
        private System.Windows.Forms.CheckBox CheckBoxPallet06;
        private System.Windows.Forms.CheckBox CheckBoxPallet07;
        private System.Windows.Forms.CheckBox CheckBoxPallet08;
        private System.Windows.Forms.CheckBox CheckBoxPallet09;
        private System.Windows.Forms.CheckBox CheckBoxPallet10;
        private System.Windows.Forms.CheckBox CheckBoxPallet11;
        private System.Windows.Forms.CheckBox CheckBoxPallet12;
        private System.Windows.Forms.CheckBox CheckBoxPallet13;
        private System.Windows.Forms.CheckBox CheckBoxPallet14;
        private HSBBar HSBBarPallet;
    }
}

