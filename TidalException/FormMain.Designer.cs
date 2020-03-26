namespace TidalException
{
    partial class FormMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSigmal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaxjmp = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSpan = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtLpout = new System.Windows.Forms.TextBox();
            this.txtLagp = new System.Windows.Forms.TextBox();
            this.txtKind = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtIaug = new System.Windows.Forms.TextBox();
            this.txtFilout = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtLagint = new System.Windows.Forms.TextBox();
            this.txtDmin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtprepro = new System.Windows.Forms.TextBox();
            this.txtShift = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTimesys = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtEndTime = new System.Windows.Forms.TextBox();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtElevation = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtLatitude = new System.Windows.Forms.TextBox();
            this.txtLongitude = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnSaveExcel = new System.Windows.Forms.Button();
            this.txtExcel = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.txtDataFile = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.ofdData = new System.Windows.Forms.OpenFileDialog();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsbTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSigmal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtWeight);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtMaxjmp);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtSpan);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtLpout);
            this.groupBox1.Controls.Add(this.txtLagp);
            this.groupBox1.Controls.Add(this.txtKind);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtIaug);
            this.groupBox1.Controls.Add(this.txtFilout);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtLagint);
            this.groupBox1.Controls.Add(this.txtDmin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtprepro);
            this.groupBox1.Controls.Add(this.txtShift);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTimesys);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(14, 226);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 147);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参数设置";
            // 
            // txtSigmal
            // 
            this.txtSigmal.Location = new System.Drawing.Point(300, 85);
            this.txtSigmal.Name = "txtSigmal";
            this.txtSigmal.Size = new System.Drawing.Size(59, 21);
            this.txtSigmal.TabIndex = 21;
            this.txtSigmal.Text = "1.00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "KIND=";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(375, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "MAXJMP=";
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(424, 11);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(59, 21);
            this.txtWeight.TabIndex = 20;
            this.txtWeight.Text = "1.0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(250, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "sigma1=";
            // 
            // txtMaxjmp
            // 
            this.txtMaxjmp.Location = new System.Drawing.Point(424, 47);
            this.txtMaxjmp.Name = "txtMaxjmp";
            this.txtMaxjmp.Size = new System.Drawing.Size(59, 21);
            this.txtMaxjmp.TabIndex = 13;
            this.txtMaxjmp.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(250, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "TIMSYS=";
            // 
            // txtSpan
            // 
            this.txtSpan.Location = new System.Drawing.Point(53, 48);
            this.txtSpan.Name = "txtSpan";
            this.txtSpan.Size = new System.Drawing.Size(59, 21);
            this.txtSpan.TabIndex = 19;
            this.txtSpan.Text = "720";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(375, 89);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 12);
            this.label14.TabIndex = 8;
            this.label14.Text = "prepro=";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(375, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "WEIGHT=";
            // 
            // txtLpout
            // 
            this.txtLpout.Location = new System.Drawing.Point(53, 85);
            this.txtLpout.Name = "txtLpout";
            this.txtLpout.Size = new System.Drawing.Size(59, 21);
            this.txtLpout.TabIndex = 18;
            this.txtLpout.Text = "0";
            // 
            // txtLagp
            // 
            this.txtLagp.Location = new System.Drawing.Point(177, 120);
            this.txtLagp.Name = "txtLagp";
            this.txtLagp.Size = new System.Drawing.Size(59, 21);
            this.txtLagp.TabIndex = 9;
            this.txtLagp.Text = "1";
            // 
            // txtKind
            // 
            this.txtKind.Location = new System.Drawing.Point(53, 13);
            this.txtKind.Name = "txtKind";
            this.txtKind.Size = new System.Drawing.Size(59, 21);
            this.txtKind.TabIndex = 1;
            this.txtKind.Text = "8";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(250, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 5;
            this.label11.Text = "LAGINT=";
            // 
            // txtIaug
            // 
            this.txtIaug.Location = new System.Drawing.Point(53, 120);
            this.txtIaug.Name = "txtIaug";
            this.txtIaug.Size = new System.Drawing.Size(59, 21);
            this.txtIaug.TabIndex = 17;
            this.txtIaug.Text = "0";
            // 
            // txtFilout
            // 
            this.txtFilout.Location = new System.Drawing.Point(177, 84);
            this.txtFilout.Name = "txtFilout";
            this.txtFilout.Size = new System.Drawing.Size(59, 21);
            this.txtFilout.TabIndex = 10;
            this.txtFilout.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "SPAN=";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(128, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 6;
            this.label12.Text = "LAGP=";
            // 
            // txtLagint
            // 
            this.txtLagint.Location = new System.Drawing.Point(300, 12);
            this.txtLagint.Name = "txtLagint";
            this.txtLagint.Size = new System.Drawing.Size(59, 21);
            this.txtLagint.TabIndex = 16;
            this.txtLagint.Text = "0";
            // 
            // txtDmin
            // 
            this.txtDmin.Location = new System.Drawing.Point(177, 13);
            this.txtDmin.Name = "txtDmin";
            this.txtDmin.Size = new System.Drawing.Size(59, 21);
            this.txtDmin.TabIndex = 11;
            this.txtDmin.Text = "0.50D0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "SHIFT=";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 12);
            this.label13.TabIndex = 7;
            this.label13.Text = "IAUG=";
            // 
            // txtprepro
            // 
            this.txtprepro.Location = new System.Drawing.Point(424, 84);
            this.txtprepro.Name = "txtprepro";
            this.txtprepro.Size = new System.Drawing.Size(59, 21);
            this.txtprepro.TabIndex = 15;
            this.txtprepro.Text = "1";
            // 
            // txtShift
            // 
            this.txtShift.Location = new System.Drawing.Point(177, 49);
            this.txtShift.Name = "txtShift";
            this.txtShift.Size = new System.Drawing.Size(59, 21);
            this.txtShift.TabIndex = 12;
            this.txtShift.Text = "360";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(128, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "DMIN=";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(128, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "FILOUT=";
            // 
            // txtTimesys
            // 
            this.txtTimesys.Location = new System.Drawing.Point(300, 48);
            this.txtTimesys.Name = "txtTimesys";
            this.txtTimesys.Size = new System.Drawing.Size(59, 21);
            this.txtTimesys.TabIndex = 14;
            this.txtTimesys.Text = "-8.0D0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "LPOUT=";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtInterval);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.txtEndTime);
            this.groupBox2.Controls.Add(this.txtStartTime);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Location = new System.Drawing.Point(14, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 108);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "自动读取开始、结束时间";
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(66, 76);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.ReadOnly = true;
            this.txtInterval.Size = new System.Drawing.Size(147, 21);
            this.txtInterval.TabIndex = 5;
            this.txtInterval.Text = "1.0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(4, 81);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 4;
            this.label20.Text = "读取间隔：";
            // 
            // txtEndTime
            // 
            this.txtEndTime.Location = new System.Drawing.Point(66, 46);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.ReadOnly = true;
            this.txtEndTime.Size = new System.Drawing.Size(147, 21);
            this.txtEndTime.TabIndex = 3;
            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(66, 18);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.ReadOnly = true;
            this.txtStartTime.Size = new System.Drawing.Size(147, 21);
            this.txtStartTime.TabIndex = 2;
            this.txtStartTime.Text = "2006010100";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(4, 51);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 1;
            this.label16.Text = "结束时间：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(4, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 0;
            this.label15.Text = "开始时间：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtElevation);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.txtLatitude);
            this.groupBox3.Controls.Add(this.txtLongitude);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Location = new System.Drawing.Point(260, 112);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(244, 108);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "井（泉）经度、维度、高程";
            // 
            // txtElevation
            // 
            this.txtElevation.Location = new System.Drawing.Point(81, 75);
            this.txtElevation.Name = "txtElevation";
            this.txtElevation.Size = new System.Drawing.Size(147, 21);
            this.txtElevation.TabIndex = 5;
            this.txtElevation.Text = "617";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(19, 80);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 12);
            this.label19.TabIndex = 4;
            this.label19.Text = "高程：";
            // 
            // txtLatitude
            // 
            this.txtLatitude.Location = new System.Drawing.Point(81, 46);
            this.txtLatitude.Name = "txtLatitude";
            this.txtLatitude.Size = new System.Drawing.Size(147, 21);
            this.txtLatitude.TabIndex = 3;
            this.txtLatitude.Text = "35.545";
            // 
            // txtLongitude
            // 
            this.txtLongitude.Location = new System.Drawing.Point(81, 18);
            this.txtLongitude.Name = "txtLongitude";
            this.txtLongitude.Size = new System.Drawing.Size(147, 21);
            this.txtLongitude.TabIndex = 2;
            this.txtLongitude.Text = "106.667";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(19, 51);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 12);
            this.label17.TabIndex = 1;
            this.label17.Text = "纬度：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(19, 23);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 12);
            this.label18.TabIndex = 0;
            this.label18.Text = "经度：";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.btnExecute);
            this.groupBox4.Controls.Add(this.btnSaveExcel);
            this.groupBox4.Controls.Add(this.txtExcel);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.btnBrowser);
            this.groupBox4.Controls.Add(this.txtDataFile);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Location = new System.Drawing.Point(14, 14);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(489, 91);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "设置输入、输出文件";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(9, 42);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(389, 12);
            this.label21.TabIndex = 13;
            this.label21.Text = "文件中仅能包含时间、水位、气压【可选】小时数据，不要有空行或注释";
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(424, 16);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(57, 62);
            this.btnExecute.TabIndex = 0;
            this.btnExecute.Text = "计算";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnSaveExcel
            // 
            this.btnSaveExcel.Location = new System.Drawing.Point(356, 55);
            this.btnSaveExcel.Name = "btnSaveExcel";
            this.btnSaveExcel.Size = new System.Drawing.Size(60, 23);
            this.btnSaveExcel.TabIndex = 12;
            this.btnSaveExcel.Text = "浏览...";
            this.btnSaveExcel.UseVisualStyleBackColor = true;
            this.btnSaveExcel.Click += new System.EventHandler(this.btnSaveExcel_Click);
            // 
            // txtExcel
            // 
            this.txtExcel.Location = new System.Drawing.Point(94, 57);
            this.txtExcel.Name = "txtExcel";
            this.txtExcel.ReadOnly = true;
            this.txtExcel.Size = new System.Drawing.Size(259, 21);
            this.txtExcel.TabIndex = 11;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(5, 60);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(77, 12);
            this.label22.TabIndex = 10;
            this.label22.Text = "输出文件夹：";
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(356, 16);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(60, 23);
            this.btnBrowser.TabIndex = 6;
            this.btnBrowser.Text = "浏览...";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // txtDataFile
            // 
            this.txtDataFile.Location = new System.Drawing.Point(94, 18);
            this.txtDataFile.Name = "txtDataFile";
            this.txtDataFile.ReadOnly = true;
            this.txtDataFile.Size = new System.Drawing.Size(259, 21);
            this.txtDataFile.TabIndex = 2;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(4, 23);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(89, 12);
            this.label23.TabIndex = 0;
            this.label23.Text = "选择水位数据：";
            // 
            // ofdData
            // 
            this.ofdData.Filter = "潮汐文本文件|*.txt";
            this.ofdData.Title = "选择待处理的潮汐数据文件";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbTime,
            this.tsbStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 384);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(520, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsbTime
            // 
            this.tsbTime.AutoSize = false;
            this.tsbTime.Name = "tsbTime";
            this.tsbTime.Size = new System.Drawing.Size(250, 17);
            this.tsbTime.Text = "时间";
            this.tsbTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsbStatus
            // 
            this.tsbStatus.ForeColor = System.Drawing.Color.Peru;
            this.tsbStatus.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.tsbStatus.Name = "tsbStatus";
            this.tsbStatus.Size = new System.Drawing.Size(29, 17);
            this.tsbStatus.Text = "状态";
            this.tsbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 406);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "潮汐分析";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSigmal;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.TextBox txtMaxjmp;
        private System.Windows.Forms.TextBox txtSpan;
        private System.Windows.Forms.TextBox txtLpout;
        private System.Windows.Forms.TextBox txtLagp;
        private System.Windows.Forms.TextBox txtIaug;
        private System.Windows.Forms.TextBox txtFilout;
        private System.Windows.Forms.TextBox txtLagint;
        private System.Windows.Forms.TextBox txtDmin;
        private System.Windows.Forms.TextBox txtprepro;
        private System.Windows.Forms.TextBox txtShift;
        private System.Windows.Forms.TextBox txtTimesys;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtEndTime;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtLatitude;
        private System.Windows.Forms.TextBox txtLongitude;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtElevation;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtDataFile;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.OpenFileDialog ofdData;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private System.Windows.Forms.Button btnSaveExcel;
        private System.Windows.Forms.TextBox txtExcel;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsbTime;
        private System.Windows.Forms.ToolStripStatusLabel tsbStatus;
        private System.Windows.Forms.Timer timer1;
    }
}

