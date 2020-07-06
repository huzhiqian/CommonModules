namespace CommonModules.SaveImage
{
    partial class SaveImageEditor
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chk_IsSaveImage = new System.Windows.Forms.CheckBox();
            this.num_DiskSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rb_png = new System.Windows.Forms.RadioButton();
            this.rb_jpg = new System.Windows.Forms.RadioButton();
            this.rb_bmp = new System.Windows.Forms.RadioButton();
            this.chk_isCheckDiskSize = new System.Windows.Forms.CheckBox();
            this.chk_autoCreateDateFolder = new System.Windows.Forms.CheckBox();
            this.chk_checkNameValidity = new System.Windows.Forms.CheckBox();
            this.chk_imageNameEndWithTime = new System.Windows.Forms.CheckBox();
            this.btn_Bowser = new System.Windows.Forms.Button();
            this.tbx_SaveImagePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_DiskSize)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chk_IsSaveImage);
            this.groupBox1.Controls.Add(this.num_DiskSize);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.chk_isCheckDiskSize);
            this.groupBox1.Controls.Add(this.chk_autoCreateDateFolder);
            this.groupBox1.Controls.Add(this.chk_checkNameValidity);
            this.groupBox1.Controls.Add(this.chk_imageNameEndWithTime);
            this.groupBox1.Controls.Add(this.btn_Bowser);
            this.groupBox1.Controls.Add(this.tbx_SaveImagePath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(759, 178);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(622, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "GB";
            // 
            // chk_IsSaveImage
            // 
            this.chk_IsSaveImage.AutoSize = true;
            this.chk_IsSaveImage.Location = new System.Drawing.Point(273, 127);
            this.chk_IsSaveImage.Name = "chk_IsSaveImage";
            this.chk_IsSaveImage.Size = new System.Drawing.Size(91, 20);
            this.chk_IsSaveImage.TabIndex = 10;
            this.chk_IsSaveImage.Text = "保存图像";
            this.chk_IsSaveImage.UseVisualStyleBackColor = true;
            this.chk_IsSaveImage.CheckedChanged += new System.EventHandler(this.chk_IsSaveImage_CheckedChanged);
            // 
            // num_DiskSize
            // 
            this.num_DiskSize.DecimalPlaces = 1;
            this.num_DiskSize.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.num_DiskSize.Location = new System.Drawing.Point(516, 126);
            this.num_DiskSize.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.num_DiskSize.Name = "num_DiskSize";
            this.num_DiskSize.Size = new System.Drawing.Size(100, 26);
            this.num_DiskSize.TabIndex = 9;
            this.num_DiskSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.num_DiskSize.ValueChanged += new System.EventHandler(this.num_DiskSize_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(402, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "最小磁盘容量：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rb_png);
            this.groupBox2.Controls.Add(this.rb_jpg);
            this.groupBox2.Controls.Add(this.rb_bmp);
            this.groupBox2.Location = new System.Drawing.Point(10, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 70);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "保存图像格式";
            // 
            // rb_png
            // 
            this.rb_png.AutoSize = true;
            this.rb_png.Location = new System.Drawing.Point(126, 34);
            this.rb_png.Name = "rb_png";
            this.rb_png.Size = new System.Drawing.Size(50, 20);
            this.rb_png.TabIndex = 2;
            this.rb_png.TabStop = true;
            this.rb_png.Text = "png";
            this.rb_png.UseVisualStyleBackColor = true;
            this.rb_png.CheckedChanged += new System.EventHandler(this.rb_png_CheckedChanged);
            // 
            // rb_jpg
            // 
            this.rb_jpg.AutoSize = true;
            this.rb_jpg.Location = new System.Drawing.Point(70, 34);
            this.rb_jpg.Name = "rb_jpg";
            this.rb_jpg.Size = new System.Drawing.Size(50, 20);
            this.rb_jpg.TabIndex = 1;
            this.rb_jpg.TabStop = true;
            this.rb_jpg.Text = "jpg";
            this.rb_jpg.UseVisualStyleBackColor = true;
            this.rb_jpg.CheckedChanged += new System.EventHandler(this.rb_jpg_CheckedChanged);
            // 
            // rb_bmp
            // 
            this.rb_bmp.AutoSize = true;
            this.rb_bmp.Location = new System.Drawing.Point(14, 34);
            this.rb_bmp.Name = "rb_bmp";
            this.rb_bmp.Size = new System.Drawing.Size(50, 20);
            this.rb_bmp.TabIndex = 0;
            this.rb_bmp.TabStop = true;
            this.rb_bmp.Text = "bmp";
            this.rb_bmp.UseVisualStyleBackColor = true;
            this.rb_bmp.CheckedChanged += new System.EventHandler(this.rb_bmp_CheckedChanged);
            // 
            // chk_isCheckDiskSize
            // 
            this.chk_isCheckDiskSize.AutoSize = true;
            this.chk_isCheckDiskSize.Location = new System.Drawing.Point(619, 75);
            this.chk_isCheckDiskSize.Name = "chk_isCheckDiskSize";
            this.chk_isCheckDiskSize.Size = new System.Drawing.Size(123, 20);
            this.chk_isCheckDiskSize.TabIndex = 6;
            this.chk_isCheckDiskSize.Text = "检查磁盘容量";
            this.chk_isCheckDiskSize.UseVisualStyleBackColor = true;
            this.chk_isCheckDiskSize.CheckedChanged += new System.EventHandler(this.chk_isCheckDiskSize_CheckedChanged);
            // 
            // chk_autoCreateDateFolder
            // 
            this.chk_autoCreateDateFolder.AutoSize = true;
            this.chk_autoCreateDateFolder.Location = new System.Drawing.Point(430, 75);
            this.chk_autoCreateDateFolder.Name = "chk_autoCreateDateFolder";
            this.chk_autoCreateDateFolder.Size = new System.Drawing.Size(171, 20);
            this.chk_autoCreateDateFolder.TabIndex = 5;
            this.chk_autoCreateDateFolder.Text = "自动创建日期文件夹";
            this.chk_autoCreateDateFolder.UseVisualStyleBackColor = true;
            this.chk_autoCreateDateFolder.CheckedChanged += new System.EventHandler(this.chk_autoCreateDateFolder_CheckedChanged);
            // 
            // chk_checkNameValidity
            // 
            this.chk_checkNameValidity.AutoSize = true;
            this.chk_checkNameValidity.Location = new System.Drawing.Point(273, 75);
            this.chk_checkNameValidity.Name = "chk_checkNameValidity";
            this.chk_checkNameValidity.Size = new System.Drawing.Size(139, 20);
            this.chk_checkNameValidity.TabIndex = 4;
            this.chk_checkNameValidity.Text = "检查名称合法性";
            this.chk_checkNameValidity.UseVisualStyleBackColor = true;
            this.chk_checkNameValidity.CheckedChanged += new System.EventHandler(this.chk_checkNameValidity_CheckedChanged);
            // 
            // chk_imageNameEndWithTime
            // 
            this.chk_imageNameEndWithTime.AutoSize = true;
            this.chk_imageNameEndWithTime.Location = new System.Drawing.Point(10, 75);
            this.chk_imageNameEndWithTime.Name = "chk_imageNameEndWithTime";
            this.chk_imageNameEndWithTime.Size = new System.Drawing.Size(235, 20);
            this.chk_imageNameEndWithTime.TabIndex = 3;
            this.chk_imageNameEndWithTime.Text = "自动在图像名称后加时间后缀";
            this.chk_imageNameEndWithTime.UseVisualStyleBackColor = true;
            this.chk_imageNameEndWithTime.CheckedChanged += new System.EventHandler(this.chk_imageNameEndWithTime_CheckedChanged);
            // 
            // btn_Bowser
            // 
            this.btn_Bowser.Location = new System.Drawing.Point(657, 13);
            this.btn_Bowser.Name = "btn_Bowser";
            this.btn_Bowser.Size = new System.Drawing.Size(95, 36);
            this.btn_Bowser.TabIndex = 2;
            this.btn_Bowser.Text = "浏览";
            this.btn_Bowser.UseVisualStyleBackColor = true;
            this.btn_Bowser.Click += new System.EventHandler(this.btn_Bowser_Click);
            // 
            // tbx_SaveImagePath
            // 
            this.tbx_SaveImagePath.BackColor = System.Drawing.Color.White;
            this.tbx_SaveImagePath.Location = new System.Drawing.Point(87, 20);
            this.tbx_SaveImagePath.Name = "tbx_SaveImagePath";
            this.tbx_SaveImagePath.ReadOnly = true;
            this.tbx_SaveImagePath.Size = new System.Drawing.Size(564, 26);
            this.tbx_SaveImagePath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "保存路径：";
            // 
            // SaveImageEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SaveImageEditor";
            this.Size = new System.Drawing.Size(759, 178);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_DiskSize)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chk_autoCreateDateFolder;
        private System.Windows.Forms.CheckBox chk_checkNameValidity;
        private System.Windows.Forms.CheckBox chk_imageNameEndWithTime;
        private System.Windows.Forms.Button btn_Bowser;
        private System.Windows.Forms.TextBox tbx_SaveImagePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk_isCheckDiskSize;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rb_png;
        private System.Windows.Forms.RadioButton rb_jpg;
        private System.Windows.Forms.RadioButton rb_bmp;
        private System.Windows.Forms.NumericUpDown num_DiskSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chk_IsSaveImage;
    }
}
