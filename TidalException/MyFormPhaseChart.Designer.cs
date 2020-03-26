namespace TidalException
{
    partial class MyFormPhaseChart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyFormPhaseChart));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pdraw = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pheader = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnSavePic = new System.Windows.Forms.Button();
            this.btnVertical = new System.Windows.Forms.Button();
            this.btnHorizon = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnMerge = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.txtExcel = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnEarthquake = new System.Windows.Forms.Button();
            this.txtEarthquake = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lblWaterMax = new System.Windows.Forms.Label();
            this.lblWaterMin = new System.Windows.Forms.Label();
            this.cbColorWater = new System.Windows.Forms.ComboBox();
            this.txtWater = new System.Windows.Forms.TextBox();
            this.txtMaxWater = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMinWater = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbSymbol = new System.Windows.Forms.ComboBox();
            this.btndraw = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblAmpMax = new System.Windows.Forms.Label();
            this.lblAmpMin = new System.Windows.Forms.Label();
            this.cbColor2 = new System.Windows.Forms.ComboBox();
            this.txtY2 = new System.Windows.Forms.TextBox();
            this.txtAmpMax = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAmpmin = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblPhaseMax = new System.Windows.Forms.Label();
            this.lblPhaseMin = new System.Windows.Forms.Label();
            this.txtPhaseMax = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPhaseMin = new System.Windows.Forms.TextBox();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ofdExcel = new System.Windows.Forms.OpenFileDialog();
            this.ofdEarthquake = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pheader.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 210);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1149, 407);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "绘图区";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.pdraw);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(1143, 387);
            this.panel1.TabIndex = 1;
            // 
            // pdraw
            // 
            this.pdraw.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pdraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdraw.Location = new System.Drawing.Point(10, 10);
            this.pdraw.Margin = new System.Windows.Forms.Padding(10);
            this.pdraw.Name = "pdraw";
            this.pdraw.Size = new System.Drawing.Size(1123, 367);
            this.pdraw.TabIndex = 0;
            this.pdraw.Paint += new System.Windows.Forms.PaintEventHandler(this.pdraw_Paint);
            this.pdraw.MouseEnter += new System.EventHandler(this.pdraw_MouseEnter);
            this.pdraw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pdraw_MouseMove);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pheader);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1149, 210);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作区";
            // 
            // pheader
            // 
            this.pheader.Controls.Add(this.groupBox6);
            this.pheader.Controls.Add(this.groupBox8);
            this.pheader.Controls.Add(this.groupBox7);
            this.pheader.Controls.Add(this.groupBox5);
            this.pheader.Controls.Add(this.groupBox4);
            this.pheader.Controls.Add(this.groupBox3);
            this.pheader.Location = new System.Drawing.Point(75, 12);
            this.pheader.Name = "pheader";
            this.pheader.Size = new System.Drawing.Size(1068, 173);
            this.pheader.TabIndex = 5;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnSavePic);
            this.groupBox6.Controls.Add(this.btnVertical);
            this.groupBox6.Controls.Add(this.btnHorizon);
            this.groupBox6.Location = new System.Drawing.Point(941, 8);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(120, 148);
            this.groupBox6.TabIndex = 13;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "工具";
            // 
            // btnSavePic
            // 
            this.btnSavePic.Location = new System.Drawing.Point(17, 104);
            this.btnSavePic.Name = "btnSavePic";
            this.btnSavePic.Size = new System.Drawing.Size(75, 23);
            this.btnSavePic.TabIndex = 2;
            this.btnSavePic.Text = "保存图片";
            this.btnSavePic.UseVisualStyleBackColor = true;
            this.btnSavePic.Click += new System.EventHandler(this.btnSavePic_Click);
            // 
            // btnVertical
            // 
            this.btnVertical.Location = new System.Drawing.Point(17, 63);
            this.btnVertical.Name = "btnVertical";
            this.btnVertical.Size = new System.Drawing.Size(75, 23);
            this.btnVertical.TabIndex = 1;
            this.btnVertical.Text = "竖线";
            this.btnVertical.UseVisualStyleBackColor = true;
            this.btnVertical.Click += new System.EventHandler(this.btnVertical_Click);
            // 
            // btnHorizon
            // 
            this.btnHorizon.Location = new System.Drawing.Point(17, 25);
            this.btnHorizon.Name = "btnHorizon";
            this.btnHorizon.Size = new System.Drawing.Size(75, 23);
            this.btnHorizon.TabIndex = 0;
            this.btnHorizon.Text = "横线";
            this.btnHorizon.UseVisualStyleBackColor = true;
            this.btnHorizon.Click += new System.EventHandler(this.btnHorizon_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btnMerge);
            this.groupBox8.Controls.Add(this.label16);
            this.groupBox8.Controls.Add(this.btnExcel);
            this.groupBox8.Controls.Add(this.txtExcel);
            this.groupBox8.Controls.Add(this.label15);
            this.groupBox8.Controls.Add(this.btnEarthquake);
            this.groupBox8.Controls.Add(this.txtEarthquake);
            this.groupBox8.Location = new System.Drawing.Point(552, 8);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(383, 89);
            this.groupBox8.TabIndex = 12;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "总体参数设置";
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(312, 49);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(60, 23);
            this.btnMerge.TabIndex = 15;
            this.btnMerge.Text = "合并";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Visible = false;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 12);
            this.label16.TabIndex = 14;
            this.label16.Text = "选择绘图Excel";
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(250, 20);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(121, 23);
            this.btnExcel.TabIndex = 12;
            this.btnExcel.Text = "浏览...";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // txtExcel
            // 
            this.txtExcel.Location = new System.Drawing.Point(92, 20);
            this.txtExcel.Name = "txtExcel";
            this.txtExcel.ReadOnly = true;
            this.txtExcel.Size = new System.Drawing.Size(153, 21);
            this.txtExcel.TabIndex = 13;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 53);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 12);
            this.label15.TabIndex = 11;
            this.label15.Text = "选择震级Excel";
            // 
            // btnEarthquake
            // 
            this.btnEarthquake.Location = new System.Drawing.Point(250, 49);
            this.btnEarthquake.Name = "btnEarthquake";
            this.btnEarthquake.Size = new System.Drawing.Size(56, 23);
            this.btnEarthquake.TabIndex = 9;
            this.btnEarthquake.Text = "浏览";
            this.btnEarthquake.UseVisualStyleBackColor = true;
            this.btnEarthquake.Click += new System.EventHandler(this.btnEarthquake_Click);
            // 
            // txtEarthquake
            // 
            this.txtEarthquake.Location = new System.Drawing.Point(92, 48);
            this.txtEarthquake.Name = "txtEarthquake";
            this.txtEarthquake.ReadOnly = true;
            this.txtEarthquake.Size = new System.Drawing.Size(153, 21);
            this.txtEarthquake.TabIndex = 10;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lblWaterMax);
            this.groupBox7.Controls.Add(this.lblWaterMin);
            this.groupBox7.Controls.Add(this.cbColorWater);
            this.groupBox7.Controls.Add(this.txtWater);
            this.groupBox7.Controls.Add(this.txtMaxWater);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.txtMinWater);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Location = new System.Drawing.Point(3, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(543, 52);
            this.groupBox7.TabIndex = 8;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "水位参数设置";
            // 
            // lblWaterMax
            // 
            this.lblWaterMax.AutoSize = true;
            this.lblWaterMax.Location = new System.Drawing.Point(384, 27);
            this.lblWaterMax.Name = "lblWaterMax";
            this.lblWaterMax.Size = new System.Drawing.Size(41, 12);
            this.lblWaterMax.TabIndex = 16;
            this.lblWaterMax.Text = "最大值";
            // 
            // lblWaterMin
            // 
            this.lblWaterMin.AutoSize = true;
            this.lblWaterMin.Location = new System.Drawing.Point(213, 27);
            this.lblWaterMin.Name = "lblWaterMin";
            this.lblWaterMin.Size = new System.Drawing.Size(41, 12);
            this.lblWaterMin.TabIndex = 15;
            this.lblWaterMin.Text = "最小值";
            // 
            // cbColorWater
            // 
            this.cbColorWater.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColorWater.FormattingEnabled = true;
            this.cbColorWater.Items.AddRange(new object[] {
            "黑色",
            "红色",
            "蓝色",
            "绿色"});
            this.cbColorWater.Location = new System.Drawing.Point(45, 23);
            this.cbColorWater.Name = "cbColorWater";
            this.cbColorWater.Size = new System.Drawing.Size(47, 20);
            this.cbColorWater.TabIndex = 10;
            // 
            // txtWater
            // 
            this.txtWater.Location = new System.Drawing.Point(486, 23);
            this.txtWater.Name = "txtWater";
            this.txtWater.Size = new System.Drawing.Size(33, 21);
            this.txtWater.TabIndex = 8;
            this.txtWater.Text = "5";
            // 
            // txtMaxWater
            // 
            this.txtMaxWater.Location = new System.Drawing.Point(315, 23);
            this.txtMaxWater.Name = "txtMaxWater";
            this.txtMaxWater.Size = new System.Drawing.Size(59, 21);
            this.txtMaxWater.TabIndex = 14;
            this.txtMaxWater.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "最大值";
            // 
            // txtMinWater
            // 
            this.txtMinWater.Location = new System.Drawing.Point(153, 23);
            this.txtMinWater.Name = "txtMinWater";
            this.txtMinWater.Size = new System.Drawing.Size(50, 21);
            this.txtMinWater.TabIndex = 12;
            this.txtMinWater.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(102, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "最小值";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(435, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 2;
            this.label13.Text = "刻度数";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 27);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 5;
            this.label14.Text = "颜色";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbSymbol);
            this.groupBox5.Controls.Add(this.btndraw);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.txtX);
            this.groupBox5.Location = new System.Drawing.Point(552, 104);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(383, 52);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "总体参数设置";
            // 
            // cbSymbol
            // 
            this.cbSymbol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSymbol.FormattingEnabled = true;
            this.cbSymbol.Items.AddRange(new object[] {
            "Q1",
            "O1",
            "M1",
            "P1S1K1",
            "J1",
            "OO1",
            "2N2",
            "N2",
            "M2",
            "L2",
            "S2K2",
            "M3"});
            this.cbSymbol.Location = new System.Drawing.Point(50, 20);
            this.cbSymbol.Name = "cbSymbol";
            this.cbSymbol.Size = new System.Drawing.Size(73, 20);
            this.cbSymbol.TabIndex = 1;
            // 
            // btndraw
            // 
            this.btndraw.Location = new System.Drawing.Point(263, 22);
            this.btndraw.Name = "btndraw";
            this.btndraw.Size = new System.Drawing.Size(75, 23);
            this.btndraw.TabIndex = 0;
            this.btndraw.Text = "绘图";
            this.btndraw.UseVisualStyleBackColor = true;
            this.btndraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(129, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "总刻度数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "SYMBOL:";
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(187, 19);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(33, 21);
            this.txtX.TabIndex = 3;
            this.txtX.Text = "20";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblAmpMax);
            this.groupBox4.Controls.Add(this.lblAmpMin);
            this.groupBox4.Controls.Add(this.cbColor2);
            this.groupBox4.Controls.Add(this.txtY2);
            this.groupBox4.Controls.Add(this.txtAmpMax);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txtAmpmin);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Location = new System.Drawing.Point(3, 112);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(543, 52);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "振幅参数设置";
            // 
            // lblAmpMax
            // 
            this.lblAmpMax.AutoSize = true;
            this.lblAmpMax.Location = new System.Drawing.Point(384, 27);
            this.lblAmpMax.Name = "lblAmpMax";
            this.lblAmpMax.Size = new System.Drawing.Size(41, 12);
            this.lblAmpMax.TabIndex = 18;
            this.lblAmpMax.Text = "最大值";
            // 
            // lblAmpMin
            // 
            this.lblAmpMin.AutoSize = true;
            this.lblAmpMin.Location = new System.Drawing.Point(213, 27);
            this.lblAmpMin.Name = "lblAmpMin";
            this.lblAmpMin.Size = new System.Drawing.Size(41, 12);
            this.lblAmpMin.TabIndex = 17;
            this.lblAmpMin.Text = "最小值";
            // 
            // cbColor2
            // 
            this.cbColor2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColor2.FormattingEnabled = true;
            this.cbColor2.Items.AddRange(new object[] {
            "黑色",
            "红色",
            "蓝色",
            "绿色"});
            this.cbColor2.Location = new System.Drawing.Point(45, 23);
            this.cbColor2.Name = "cbColor2";
            this.cbColor2.Size = new System.Drawing.Size(47, 20);
            this.cbColor2.TabIndex = 10;
            // 
            // txtY2
            // 
            this.txtY2.Location = new System.Drawing.Point(486, 23);
            this.txtY2.Name = "txtY2";
            this.txtY2.Size = new System.Drawing.Size(33, 21);
            this.txtY2.TabIndex = 8;
            this.txtY2.Text = "5";
            // 
            // txtAmpMax
            // 
            this.txtAmpMax.Location = new System.Drawing.Point(315, 23);
            this.txtAmpMax.Name = "txtAmpMax";
            this.txtAmpMax.Size = new System.Drawing.Size(59, 21);
            this.txtAmpMax.TabIndex = 14;
            this.txtAmpMax.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(264, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "最大值";
            // 
            // txtAmpmin
            // 
            this.txtAmpmin.Location = new System.Drawing.Point(153, 23);
            this.txtAmpmin.Name = "txtAmpmin";
            this.txtAmpmin.Size = new System.Drawing.Size(50, 21);
            this.txtAmpmin.TabIndex = 12;
            this.txtAmpmin.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(102, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 11;
            this.label10.Text = "最小值";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(435, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 2;
            this.label11.Text = "刻度数";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 5;
            this.label12.Text = "颜色";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblPhaseMax);
            this.groupBox3.Controls.Add(this.lblPhaseMin);
            this.groupBox3.Controls.Add(this.txtPhaseMax);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtPhaseMin);
            this.groupBox3.Controls.Add(this.cbColor);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtY);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(3, 54);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(543, 52);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "相位参数设置";
            // 
            // lblPhaseMax
            // 
            this.lblPhaseMax.AutoSize = true;
            this.lblPhaseMax.Location = new System.Drawing.Point(384, 28);
            this.lblPhaseMax.Name = "lblPhaseMax";
            this.lblPhaseMax.Size = new System.Drawing.Size(41, 12);
            this.lblPhaseMax.TabIndex = 17;
            this.lblPhaseMax.Text = "最大值";
            // 
            // lblPhaseMin
            // 
            this.lblPhaseMin.AutoSize = true;
            this.lblPhaseMin.Location = new System.Drawing.Point(213, 28);
            this.lblPhaseMin.Name = "lblPhaseMin";
            this.lblPhaseMin.Size = new System.Drawing.Size(41, 12);
            this.lblPhaseMin.TabIndex = 16;
            this.lblPhaseMin.Text = "最小值";
            // 
            // txtPhaseMax
            // 
            this.txtPhaseMax.Location = new System.Drawing.Point(315, 24);
            this.txtPhaseMax.Name = "txtPhaseMax";
            this.txtPhaseMax.Size = new System.Drawing.Size(59, 21);
            this.txtPhaseMax.TabIndex = 14;
            this.txtPhaseMax.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(264, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "最大值";
            // 
            // txtPhaseMin
            // 
            this.txtPhaseMin.Location = new System.Drawing.Point(153, 24);
            this.txtPhaseMin.Name = "txtPhaseMin";
            this.txtPhaseMin.Size = new System.Drawing.Size(50, 21);
            this.txtPhaseMin.TabIndex = 12;
            this.txtPhaseMin.Text = "0";
            // 
            // cbColor
            // 
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Items.AddRange(new object[] {
            "黑色",
            "红色",
            "蓝色",
            "绿色"});
            this.cbColor.Location = new System.Drawing.Point(45, 24);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(47, 20);
            this.cbColor.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(102, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "最小值";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(435, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "刻度数";
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(486, 24);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(33, 21);
            this.txtY.TabIndex = 4;
            this.txtY.Text = "5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "颜色";
            // 
            // MyFormPhaseChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 617);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MyFormPhaseChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "振幅相位图";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormFactorChart_Load);
            this.SizeChanged += new System.EventHandler(this.MyFormPhaseChart_SizeChanged);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.pheader.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pheader;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.ComboBox cbSymbol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btndraw;
        private System.Windows.Forms.ComboBox cbColor2;
        private System.Windows.Forms.TextBox txtY2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtPhaseMax;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPhaseMin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtAmpMax;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAmpmin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ComboBox cbColorWater;
        private System.Windows.Forms.TextBox txtWater;
        private System.Windows.Forms.TextBox txtMaxWater;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMinWater;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel pdraw;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtEarthquake;
        private System.Windows.Forms.Button btnEarthquake;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.TextBox txtExcel;
        private System.Windows.Forms.OpenFileDialog ofdExcel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog ofdEarthquake;
        private System.Windows.Forms.Label lblWaterMax;
        private System.Windows.Forms.Label lblWaterMin;
        private System.Windows.Forms.Label lblAmpMax;
        private System.Windows.Forms.Label lblAmpMin;
        private System.Windows.Forms.Label lblPhaseMax;
        private System.Windows.Forms.Label lblPhaseMin;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnVertical;
        private System.Windows.Forms.Button btnHorizon;
        private System.Windows.Forms.Button btnSavePic;
        private System.Windows.Forms.Button btnMerge;
    }
}