namespace CommonModules.SerialPort
{
    partial class SerialPortUI
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
            this.Label1 = new System.Windows.Forms.Label();
            this.cb_SerialPortNames = new System.Windows.Forms.ComboBox();
            this.gb_BaudRate = new System.Windows.Forms.GroupBox();
            this.rb_baudRate256000 = new System.Windows.Forms.RadioButton();
            this.rb_baudRate128000 = new System.Windows.Forms.RadioButton();
            this.rb_baudRate115200 = new System.Windows.Forms.RadioButton();
            this.rb_baudRate57600 = new System.Windows.Forms.RadioButton();
            this.rb_baudRate38400 = new System.Windows.Forms.RadioButton();
            this.rb_baudRate28800 = new System.Windows.Forms.RadioButton();
            this.rb_baudRate19600 = new System.Windows.Forms.RadioButton();
            this.rb_baudRate14400 = new System.Windows.Forms.RadioButton();
            this.rb_baudRate9600 = new System.Windows.Forms.RadioButton();
            this.rb_baudRate7200 = new System.Windows.Forms.RadioButton();
            this.rb_baudRate4800 = new System.Windows.Forms.RadioButton();
            this.rb_baudRate2400 = new System.Windows.Forms.RadioButton();
            this.gb_DataBit = new System.Windows.Forms.GroupBox();
            this.rb_DataBit8 = new System.Windows.Forms.RadioButton();
            this.rb_DataBit7 = new System.Windows.Forms.RadioButton();
            this.rb_DataBit6 = new System.Windows.Forms.RadioButton();
            this.rb_DataBit5 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_Parity = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_StopBit = new System.Windows.Forms.ComboBox();
            this.btn_OpenPort = new System.Windows.Forms.Button();
            this.btn_ClosePort = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb_BaudRate.SuspendLayout();
            this.gb_DataBit.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Controls.Add(this.cb_SerialPortNames);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择串口";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label1.Location = new System.Drawing.Point(25, 21);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(112, 16);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "SerialPorts：";
            // 
            // cb_SerialPortNames
            // 
            this.cb_SerialPortNames.BackColor = System.Drawing.Color.White;
            this.cb_SerialPortNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SerialPortNames.FormattingEnabled = true;
            this.cb_SerialPortNames.Location = new System.Drawing.Point(145, 22);
            this.cb_SerialPortNames.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_SerialPortNames.Name = "cb_SerialPortNames";
            this.cb_SerialPortNames.Size = new System.Drawing.Size(208, 20);
            this.cb_SerialPortNames.TabIndex = 2;
            this.cb_SerialPortNames.SelectedIndexChanged += new System.EventHandler(this.cb_SerialPortNames_SelectedIndexChanged);
            // 
            // gb_BaudRate
            // 
            this.gb_BaudRate.Controls.Add(this.rb_baudRate256000);
            this.gb_BaudRate.Controls.Add(this.rb_baudRate128000);
            this.gb_BaudRate.Controls.Add(this.rb_baudRate115200);
            this.gb_BaudRate.Controls.Add(this.rb_baudRate57600);
            this.gb_BaudRate.Controls.Add(this.rb_baudRate38400);
            this.gb_BaudRate.Controls.Add(this.rb_baudRate28800);
            this.gb_BaudRate.Controls.Add(this.rb_baudRate19600);
            this.gb_BaudRate.Controls.Add(this.rb_baudRate14400);
            this.gb_BaudRate.Controls.Add(this.rb_baudRate9600);
            this.gb_BaudRate.Controls.Add(this.rb_baudRate7200);
            this.gb_BaudRate.Controls.Add(this.rb_baudRate4800);
            this.gb_BaudRate.Controls.Add(this.rb_baudRate2400);
            this.gb_BaudRate.Enabled = false;
            this.gb_BaudRate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb_BaudRate.Location = new System.Drawing.Point(4, 62);
            this.gb_BaudRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gb_BaudRate.Name = "gb_BaudRate";
            this.gb_BaudRate.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gb_BaudRate.Size = new System.Drawing.Size(313, 230);
            this.gb_BaudRate.TabIndex = 3;
            this.gb_BaudRate.TabStop = false;
            this.gb_BaudRate.Text = "波特率：";
            // 
            // rb_baudRate256000
            // 
            this.rb_baudRate256000.AutoSize = true;
            this.rb_baudRate256000.Location = new System.Drawing.Point(219, 176);
            this.rb_baudRate256000.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb_baudRate256000.Name = "rb_baudRate256000";
            this.rb_baudRate256000.Size = new System.Drawing.Size(74, 20);
            this.rb_baudRate256000.TabIndex = 11;
            this.rb_baudRate256000.Text = "256000";
            this.rb_baudRate256000.UseVisualStyleBackColor = true;
            this.rb_baudRate256000.CheckedChanged += new System.EventHandler(this.rb_baudRate256000_CheckedChanged);
            // 
            // rb_baudRate128000
            // 
            this.rb_baudRate128000.AutoSize = true;
            this.rb_baudRate128000.Location = new System.Drawing.Point(132, 176);
            this.rb_baudRate128000.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb_baudRate128000.Name = "rb_baudRate128000";
            this.rb_baudRate128000.Size = new System.Drawing.Size(74, 20);
            this.rb_baudRate128000.TabIndex = 10;
            this.rb_baudRate128000.Text = "128000";
            this.rb_baudRate128000.UseVisualStyleBackColor = true;
            this.rb_baudRate128000.CheckedChanged += new System.EventHandler(this.rb_baudRate128000_CheckedChanged);
            // 
            // rb_baudRate115200
            // 
            this.rb_baudRate115200.AutoSize = true;
            this.rb_baudRate115200.Location = new System.Drawing.Point(31, 173);
            this.rb_baudRate115200.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb_baudRate115200.Name = "rb_baudRate115200";
            this.rb_baudRate115200.Size = new System.Drawing.Size(74, 20);
            this.rb_baudRate115200.TabIndex = 9;
            this.rb_baudRate115200.Text = "115200";
            this.rb_baudRate115200.UseVisualStyleBackColor = true;
            this.rb_baudRate115200.CheckedChanged += new System.EventHandler(this.rb_baudRate115200_CheckedChanged);
            // 
            // rb_baudRate57600
            // 
            this.rb_baudRate57600.AutoSize = true;
            this.rb_baudRate57600.Location = new System.Drawing.Point(219, 135);
            this.rb_baudRate57600.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb_baudRate57600.Name = "rb_baudRate57600";
            this.rb_baudRate57600.Size = new System.Drawing.Size(66, 20);
            this.rb_baudRate57600.TabIndex = 8;
            this.rb_baudRate57600.Text = "57600";
            this.rb_baudRate57600.UseVisualStyleBackColor = true;
            this.rb_baudRate57600.CheckedChanged += new System.EventHandler(this.rb_baudRate57600_CheckedChanged);
            // 
            // rb_baudRate38400
            // 
            this.rb_baudRate38400.AutoSize = true;
            this.rb_baudRate38400.Location = new System.Drawing.Point(132, 135);
            this.rb_baudRate38400.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb_baudRate38400.Name = "rb_baudRate38400";
            this.rb_baudRate38400.Size = new System.Drawing.Size(66, 20);
            this.rb_baudRate38400.TabIndex = 7;
            this.rb_baudRate38400.Text = "38400";
            this.rb_baudRate38400.UseVisualStyleBackColor = true;
            this.rb_baudRate38400.CheckedChanged += new System.EventHandler(this.rb_baudRate38400_CheckedChanged);
            // 
            // rb_baudRate28800
            // 
            this.rb_baudRate28800.AutoSize = true;
            this.rb_baudRate28800.Location = new System.Drawing.Point(31, 133);
            this.rb_baudRate28800.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb_baudRate28800.Name = "rb_baudRate28800";
            this.rb_baudRate28800.Size = new System.Drawing.Size(66, 20);
            this.rb_baudRate28800.TabIndex = 6;
            this.rb_baudRate28800.Text = "28800";
            this.rb_baudRate28800.UseVisualStyleBackColor = true;
            this.rb_baudRate28800.CheckedChanged += new System.EventHandler(this.rb_baudRate28800_CheckedChanged);
            // 
            // rb_baudRate19600
            // 
            this.rb_baudRate19600.AutoSize = true;
            this.rb_baudRate19600.Location = new System.Drawing.Point(219, 94);
            this.rb_baudRate19600.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb_baudRate19600.Name = "rb_baudRate19600";
            this.rb_baudRate19600.Size = new System.Drawing.Size(66, 20);
            this.rb_baudRate19600.TabIndex = 5;
            this.rb_baudRate19600.Text = "19600";
            this.rb_baudRate19600.UseVisualStyleBackColor = true;
            this.rb_baudRate19600.CheckedChanged += new System.EventHandler(this.rb_baudRate19600_CheckedChanged);
            // 
            // rb_baudRate14400
            // 
            this.rb_baudRate14400.AutoSize = true;
            this.rb_baudRate14400.Location = new System.Drawing.Point(132, 94);
            this.rb_baudRate14400.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb_baudRate14400.Name = "rb_baudRate14400";
            this.rb_baudRate14400.Size = new System.Drawing.Size(66, 20);
            this.rb_baudRate14400.TabIndex = 4;
            this.rb_baudRate14400.Text = "14400";
            this.rb_baudRate14400.UseVisualStyleBackColor = true;
            this.rb_baudRate14400.CheckedChanged += new System.EventHandler(this.rb_baudRate14400_CheckedChanged);
            // 
            // rb_baudRate9600
            // 
            this.rb_baudRate9600.AutoSize = true;
            this.rb_baudRate9600.Location = new System.Drawing.Point(39, 93);
            this.rb_baudRate9600.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb_baudRate9600.Name = "rb_baudRate9600";
            this.rb_baudRate9600.Size = new System.Drawing.Size(58, 20);
            this.rb_baudRate9600.TabIndex = 3;
            this.rb_baudRate9600.Text = "9600";
            this.rb_baudRate9600.UseVisualStyleBackColor = true;
            this.rb_baudRate9600.CheckedChanged += new System.EventHandler(this.rb_baudRate9600_CheckedChanged);
            // 
            // rb_baudRate7200
            // 
            this.rb_baudRate7200.AutoSize = true;
            this.rb_baudRate7200.Location = new System.Drawing.Point(219, 53);
            this.rb_baudRate7200.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb_baudRate7200.Name = "rb_baudRate7200";
            this.rb_baudRate7200.Size = new System.Drawing.Size(58, 20);
            this.rb_baudRate7200.TabIndex = 2;
            this.rb_baudRate7200.Text = "7200";
            this.rb_baudRate7200.UseVisualStyleBackColor = true;
            this.rb_baudRate7200.CheckedChanged += new System.EventHandler(this.rb_baudRate7200_CheckedChanged);
            // 
            // rb_baudRate4800
            // 
            this.rb_baudRate4800.AutoSize = true;
            this.rb_baudRate4800.Location = new System.Drawing.Point(132, 53);
            this.rb_baudRate4800.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb_baudRate4800.Name = "rb_baudRate4800";
            this.rb_baudRate4800.Size = new System.Drawing.Size(58, 20);
            this.rb_baudRate4800.TabIndex = 1;
            this.rb_baudRate4800.Text = "4800";
            this.rb_baudRate4800.UseVisualStyleBackColor = true;
            this.rb_baudRate4800.CheckedChanged += new System.EventHandler(this.rb_baudRate4800_CheckedChanged);
            // 
            // rb_baudRate2400
            // 
            this.rb_baudRate2400.AutoSize = true;
            this.rb_baudRate2400.Location = new System.Drawing.Point(42, 53);
            this.rb_baudRate2400.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb_baudRate2400.Name = "rb_baudRate2400";
            this.rb_baudRate2400.Size = new System.Drawing.Size(58, 20);
            this.rb_baudRate2400.TabIndex = 0;
            this.rb_baudRate2400.Text = "2400";
            this.rb_baudRate2400.UseVisualStyleBackColor = true;
            this.rb_baudRate2400.CheckedChanged += new System.EventHandler(this.rb_baudRate2400_CheckedChanged);
            // 
            // gb_DataBit
            // 
            this.gb_DataBit.Controls.Add(this.rb_DataBit8);
            this.gb_DataBit.Controls.Add(this.rb_DataBit7);
            this.gb_DataBit.Controls.Add(this.rb_DataBit6);
            this.gb_DataBit.Controls.Add(this.rb_DataBit5);
            this.gb_DataBit.Enabled = false;
            this.gb_DataBit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb_DataBit.Location = new System.Drawing.Point(325, 62);
            this.gb_DataBit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gb_DataBit.Name = "gb_DataBit";
            this.gb_DataBit.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gb_DataBit.Size = new System.Drawing.Size(111, 230);
            this.gb_DataBit.TabIndex = 4;
            this.gb_DataBit.TabStop = false;
            this.gb_DataBit.Text = "数据位";
            // 
            // rb_DataBit8
            // 
            this.rb_DataBit8.AutoSize = true;
            this.rb_DataBit8.Location = new System.Drawing.Point(33, 176);
            this.rb_DataBit8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb_DataBit8.Name = "rb_DataBit8";
            this.rb_DataBit8.Size = new System.Drawing.Size(50, 20);
            this.rb_DataBit8.TabIndex = 6;
            this.rb_DataBit8.TabStop = true;
            this.rb_DataBit8.Text = "8位";
            this.rb_DataBit8.UseVisualStyleBackColor = true;
            this.rb_DataBit8.CheckedChanged += new System.EventHandler(this.rb_DataBit8_CheckedChanged);
            // 
            // rb_DataBit7
            // 
            this.rb_DataBit7.AutoSize = true;
            this.rb_DataBit7.Location = new System.Drawing.Point(33, 133);
            this.rb_DataBit7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb_DataBit7.Name = "rb_DataBit7";
            this.rb_DataBit7.Size = new System.Drawing.Size(50, 20);
            this.rb_DataBit7.TabIndex = 5;
            this.rb_DataBit7.TabStop = true;
            this.rb_DataBit7.Text = "7位";
            this.rb_DataBit7.UseVisualStyleBackColor = true;
            this.rb_DataBit7.CheckedChanged += new System.EventHandler(this.rb_DataBit7_CheckedChanged);
            // 
            // rb_DataBit6
            // 
            this.rb_DataBit6.AutoSize = true;
            this.rb_DataBit6.Location = new System.Drawing.Point(33, 87);
            this.rb_DataBit6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb_DataBit6.Name = "rb_DataBit6";
            this.rb_DataBit6.Size = new System.Drawing.Size(50, 20);
            this.rb_DataBit6.TabIndex = 4;
            this.rb_DataBit6.TabStop = true;
            this.rb_DataBit6.Text = "6位";
            this.rb_DataBit6.UseVisualStyleBackColor = true;
            this.rb_DataBit6.CheckedChanged += new System.EventHandler(this.rb_DataBit6_CheckedChanged);
            // 
            // rb_DataBit5
            // 
            this.rb_DataBit5.AutoSize = true;
            this.rb_DataBit5.Location = new System.Drawing.Point(33, 46);
            this.rb_DataBit5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb_DataBit5.Name = "rb_DataBit5";
            this.rb_DataBit5.Size = new System.Drawing.Size(50, 20);
            this.rb_DataBit5.TabIndex = 3;
            this.rb_DataBit5.TabStop = true;
            this.rb_DataBit5.Text = "5位";
            this.rb_DataBit5.UseVisualStyleBackColor = true;
            this.rb_DataBit5.CheckedChanged += new System.EventHandler(this.rb_DataBit5_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(13, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "校验方式：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmb_Parity
            // 
            this.cmb_Parity.BackColor = System.Drawing.Color.White;
            this.cmb_Parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Parity.Enabled = false;
            this.cmb_Parity.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_Parity.FormattingEnabled = true;
            this.cmb_Parity.Items.AddRange(new object[] {
            "无校验",
            "奇校验",
            "偶校验",
            "空格校验"});
            this.cmb_Parity.Location = new System.Drawing.Point(89, 309);
            this.cmb_Parity.Name = "cmb_Parity";
            this.cmb_Parity.Size = new System.Drawing.Size(121, 24);
            this.cmb_Parity.TabIndex = 6;
            this.cmb_Parity.SelectedIndexChanged += new System.EventHandler(this.cmb_Parity_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(220, 312);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "停止位：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmb_StopBit
            // 
            this.cmb_StopBit.BackColor = System.Drawing.Color.White;
            this.cmb_StopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_StopBit.Enabled = false;
            this.cmb_StopBit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_StopBit.FormattingEnabled = true;
            this.cmb_StopBit.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.cmb_StopBit.Location = new System.Drawing.Point(287, 309);
            this.cmb_StopBit.Name = "cmb_StopBit";
            this.cmb_StopBit.Size = new System.Drawing.Size(121, 24);
            this.cmb_StopBit.TabIndex = 8;
            this.cmb_StopBit.SelectedIndexChanged += new System.EventHandler(this.cmb_StopBit_SelectedIndexChanged);
            // 
            // btn_OpenPort
            // 
            this.btn_OpenPort.Location = new System.Drawing.Point(93, 363);
            this.btn_OpenPort.Name = "btn_OpenPort";
            this.btn_OpenPort.Size = new System.Drawing.Size(101, 39);
            this.btn_OpenPort.TabIndex = 9;
            this.btn_OpenPort.Text = "打开端口";
            this.btn_OpenPort.UseVisualStyleBackColor = true;
            this.btn_OpenPort.Click += new System.EventHandler(this.btn_OpenPort_Click);
            // 
            // btn_ClosePort
            // 
            this.btn_ClosePort.Location = new System.Drawing.Point(252, 363);
            this.btn_ClosePort.Name = "btn_ClosePort";
            this.btn_ClosePort.Size = new System.Drawing.Size(101, 39);
            this.btn_ClosePort.TabIndex = 10;
            this.btn_ClosePort.Text = "关闭端口";
            this.btn_ClosePort.UseVisualStyleBackColor = true;
            this.btn_ClosePort.Click += new System.EventHandler(this.btn_ClosePort_Click);
            // 
            // SerialPortUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_ClosePort);
            this.Controls.Add(this.btn_OpenPort);
            this.Controls.Add(this.cmb_StopBit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmb_Parity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gb_DataBit);
            this.Controls.Add(this.gb_BaudRate);
            this.Controls.Add(this.groupBox1);
            this.Name = "SerialPortUI";
            this.Size = new System.Drawing.Size(447, 430);
            this.Load += new System.EventHandler(this.SerialPortUI_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_BaudRate.ResumeLayout(false);
            this.gb_BaudRate.PerformLayout();
            this.gb_DataBit.ResumeLayout(false);
            this.gb_DataBit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cb_SerialPortNames;
        internal System.Windows.Forms.GroupBox gb_BaudRate;
        internal System.Windows.Forms.RadioButton rb_baudRate256000;
        internal System.Windows.Forms.RadioButton rb_baudRate128000;
        internal System.Windows.Forms.RadioButton rb_baudRate115200;
        internal System.Windows.Forms.RadioButton rb_baudRate57600;
        internal System.Windows.Forms.RadioButton rb_baudRate38400;
        internal System.Windows.Forms.RadioButton rb_baudRate28800;
        internal System.Windows.Forms.RadioButton rb_baudRate19600;
        internal System.Windows.Forms.RadioButton rb_baudRate14400;
        internal System.Windows.Forms.RadioButton rb_baudRate9600;
        internal System.Windows.Forms.RadioButton rb_baudRate7200;
        internal System.Windows.Forms.RadioButton rb_baudRate4800;
        internal System.Windows.Forms.RadioButton rb_baudRate2400;
        internal System.Windows.Forms.GroupBox gb_DataBit;
        internal System.Windows.Forms.RadioButton rb_DataBit8;
        internal System.Windows.Forms.RadioButton rb_DataBit7;
        internal System.Windows.Forms.RadioButton rb_DataBit6;
        internal System.Windows.Forms.RadioButton rb_DataBit5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_Parity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_StopBit;
        private System.Windows.Forms.Button btn_OpenPort;
        private System.Windows.Forms.Button btn_ClosePort;
    }
}
