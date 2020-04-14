namespace Mosaic4Atsumori
{
    partial class HSBBar
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.LabelH = new System.Windows.Forms.Label();
            this.HBar = new System.Windows.Forms.PictureBox();
            this.LabelS = new System.Windows.Forms.Label();
            this.SBar = new System.Windows.Forms.PictureBox();
            this.LabelB = new System.Windows.Forms.Label();
            this.BBar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.HBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BBar)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelH
            // 
            this.LabelH.Location = new System.Drawing.Point(12, 7);
            this.LabelH.Name = "LabelH";
            this.LabelH.Size = new System.Drawing.Size(64, 19);
            this.LabelH.TabIndex = 0;
            this.LabelH.Text = "色相";
            this.LabelH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HBar
            // 
            this.HBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HBar.Location = new System.Drawing.Point(82, 7);
            this.HBar.Name = "HBar";
            this.HBar.Size = new System.Drawing.Size(172, 19);
            this.HBar.TabIndex = 1;
            this.HBar.TabStop = false;
            this.HBar.Paint += new System.Windows.Forms.PaintEventHandler(this.HBar_Paint);
            // 
            // LabelS
            // 
            this.LabelS.Location = new System.Drawing.Point(12, 29);
            this.LabelS.Name = "LabelS";
            this.LabelS.Size = new System.Drawing.Size(64, 19);
            this.LabelS.TabIndex = 0;
            this.LabelS.Text = "彩度";
            this.LabelS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SBar
            // 
            this.SBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SBar.Location = new System.Drawing.Point(82, 29);
            this.SBar.Name = "SBar";
            this.SBar.Size = new System.Drawing.Size(172, 19);
            this.SBar.TabIndex = 1;
            this.SBar.TabStop = false;
            this.SBar.Paint += new System.Windows.Forms.PaintEventHandler(this.SBar_Paint);
            // 
            // LabelB
            // 
            this.LabelB.Location = new System.Drawing.Point(12, 51);
            this.LabelB.Name = "LabelB";
            this.LabelB.Size = new System.Drawing.Size(64, 19);
            this.LabelB.TabIndex = 0;
            this.LabelB.Text = "明度";
            this.LabelB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BBar
            // 
            this.BBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BBar.Location = new System.Drawing.Point(82, 51);
            this.BBar.Name = "BBar";
            this.BBar.Size = new System.Drawing.Size(172, 19);
            this.BBar.TabIndex = 1;
            this.BBar.TabStop = false;
            this.BBar.Paint += new System.Windows.Forms.PaintEventHandler(this.BBar_Paint);
            // 
            // HSBBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BBar);
            this.Controls.Add(this.LabelB);
            this.Controls.Add(this.SBar);
            this.Controls.Add(this.LabelS);
            this.Controls.Add(this.HBar);
            this.Controls.Add(this.LabelH);
            this.Name = "HSBBar";
            this.Size = new System.Drawing.Size(268, 77);
            this.Load += new System.EventHandler(this.HSBBar_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.HSBBar_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.HBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LabelH;
        private System.Windows.Forms.PictureBox HBar;
        private System.Windows.Forms.Label LabelS;
        private System.Windows.Forms.PictureBox SBar;
        private System.Windows.Forms.Label LabelB;
        private System.Windows.Forms.PictureBox BBar;
    }
}
