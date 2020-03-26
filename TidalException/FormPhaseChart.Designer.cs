namespace TidalException
{
    partial class FormPhaseChart
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
            Dundas.Charting.WinControl.ChartArea chartArea1 = new Dundas.Charting.WinControl.ChartArea();
            Dundas.Charting.WinControl.Legend legend1 = new Dundas.Charting.WinControl.Legend();
            Dundas.Charting.WinControl.Series series1 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Series series2 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Title title1 = new Dundas.Charting.WinControl.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPhaseChart));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chart1 = new Dundas.Charting.WinControl.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pheader = new System.Windows.Forms.Panel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
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
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbColor2 = new System.Windows.Forms.ComboBox();
            this.txtY2 = new System.Windows.Forms.TextBox();
            this.txtAmpMax = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAmpmin = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPhaseMax = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPhaseMin = new System.Windows.Forms.TextBox();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btndraw = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.pheader.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chart1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 210);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1149, 251);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "绘图区";
            // 
            // chart1
            // 
            this.chart1.AlwaysRecreateHotregions = true;
            chartArea1.Area3DStyle.WallWidth = 0;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MinorTickMark.Size = 2F;
            chartArea1.AxisX.Title = "时间";
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.MinorTickMark.Size = 2F;
            chartArea1.AxisY.StartFromZero = false;
            chartArea1.AxisY.Title = "相位";
            chartArea1.BorderColor = System.Drawing.Color.Empty;
            chartArea1.Name = "Default";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Default";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 17);
            this.chart1.Name = "chart1";
            this.chart1.Palette = Dundas.Charting.WinControl.ChartColorPalette.Pastel;
            series1.BorderWidth = 2;
            series1.ChartType = "Line";
            series1.MarkerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series1.Name = "Series1";
            series1.PaletteCustomColors = new System.Drawing.Color[0];
            series1.ShadowOffset = 1;
            series1.SmartLabels.Enabled = true;
            series2.BorderWidth = 2;
            series2.ChartType = "Line";
            series2.MarkerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series2.Name = "Series2";
            series2.PaletteCustomColors = new System.Drawing.Color[0];
            series2.ShadowOffset = 1;
            series2.SmartLabels.Enabled = true;
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1143, 231);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "振幅相位图";
            title1.Name = "Title1";
            title1.Text = "振幅相位图";
            this.chart1.Titles.Add(title1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.pheader);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1149, 210);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作区";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBox1);
            this.groupBox6.Location = new System.Drawing.Point(715, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(279, 127);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "使用说明：";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 17);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(273, 107);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "1、通过调整振幅和相位的最大值和最小值可以使绘制的线条上下移动，设置最大值不能小于实际数据段最大值，设置的最小值不能大于实际的最小值。              " +
                "         2、通过调整间隔，调整显示的刻度坐标，可以为小数。                             3、通过将最大值、最小值、间隔设置" +
                "为小数，可以调整坐标显示的刻度精度";
            // 
            // pheader
            // 
            this.pheader.Controls.Add(this.groupBox7);
            this.pheader.Controls.Add(this.groupBox5);
            this.pheader.Controls.Add(this.groupBox4);
            this.pheader.Controls.Add(this.groupBox3);
            this.pheader.Controls.Add(this.btndraw);
            this.pheader.Location = new System.Drawing.Point(75, 12);
            this.pheader.Name = "pheader";
            this.pheader.Size = new System.Drawing.Size(634, 173);
            this.pheader.TabIndex = 5;
            // 
            // groupBox7
            // 
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
            this.groupBox7.Size = new System.Drawing.Size(395, 52);
            this.groupBox7.TabIndex = 8;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "水位参数设置";
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
            this.cbColorWater.Location = new System.Drawing.Point(41, 23);
            this.cbColorWater.Name = "cbColorWater";
            this.cbColorWater.Size = new System.Drawing.Size(47, 20);
            this.cbColorWater.TabIndex = 10;
            // 
            // txtWater
            // 
            this.txtWater.Location = new System.Drawing.Point(341, 23);
            this.txtWater.Name = "txtWater";
            this.txtWater.Size = new System.Drawing.Size(33, 21);
            this.txtWater.TabIndex = 8;
            this.txtWater.Text = "1";
            // 
            // txtMaxWater
            // 
            this.txtMaxWater.Location = new System.Drawing.Point(243, 23);
            this.txtMaxWater.Name = "txtMaxWater";
            this.txtMaxWater.Size = new System.Drawing.Size(59, 21);
            this.txtMaxWater.TabIndex = 14;
            this.txtMaxWater.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "最大值";
            // 
            // txtMinWater
            // 
            this.txtMinWater.Location = new System.Drawing.Point(135, 23);
            this.txtMinWater.Name = "txtMinWater";
            this.txtMinWater.Size = new System.Drawing.Size(50, 21);
            this.txtMinWater.TabIndex = 12;
            this.txtMinWater.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(94, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "最小值";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(308, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 2;
            this.label13.Text = "间隔";
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
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.txtX);
            this.groupBox5.Location = new System.Drawing.Point(404, 8);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(218, 52);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(129, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "X轴间隔";
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
            this.txtX.Location = new System.Drawing.Point(181, 19);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(33, 21);
            this.txtX.TabIndex = 3;
            this.txtX.Text = "1";
            // 
            // groupBox4
            // 
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
            this.groupBox4.Size = new System.Drawing.Size(395, 52);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "振幅参数设置";
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
            this.cbColor2.Location = new System.Drawing.Point(41, 23);
            this.cbColor2.Name = "cbColor2";
            this.cbColor2.Size = new System.Drawing.Size(47, 20);
            this.cbColor2.TabIndex = 10;
            // 
            // txtY2
            // 
            this.txtY2.Location = new System.Drawing.Point(341, 23);
            this.txtY2.Name = "txtY2";
            this.txtY2.Size = new System.Drawing.Size(33, 21);
            this.txtY2.TabIndex = 8;
            this.txtY2.Text = "1";
            // 
            // txtAmpMax
            // 
            this.txtAmpMax.Location = new System.Drawing.Point(243, 23);
            this.txtAmpMax.Name = "txtAmpMax";
            this.txtAmpMax.Size = new System.Drawing.Size(59, 21);
            this.txtAmpMax.TabIndex = 14;
            this.txtAmpMax.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(189, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "最大值";
            // 
            // txtAmpmin
            // 
            this.txtAmpmin.Location = new System.Drawing.Point(135, 23);
            this.txtAmpmin.Name = "txtAmpmin";
            this.txtAmpmin.Size = new System.Drawing.Size(50, 21);
            this.txtAmpmin.TabIndex = 12;
            this.txtAmpmin.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(94, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 11;
            this.label10.Text = "最小值";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(308, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 2;
            this.label11.Text = "间隔";
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
            this.groupBox3.Size = new System.Drawing.Size(395, 52);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "相位参数设置";
            // 
            // txtPhaseMax
            // 
            this.txtPhaseMax.Location = new System.Drawing.Point(243, 24);
            this.txtPhaseMax.Name = "txtPhaseMax";
            this.txtPhaseMax.Size = new System.Drawing.Size(59, 21);
            this.txtPhaseMax.TabIndex = 14;
            this.txtPhaseMax.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(191, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "最大值";
            // 
            // txtPhaseMin
            // 
            this.txtPhaseMin.Location = new System.Drawing.Point(135, 24);
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
            this.cbColor.Location = new System.Drawing.Point(41, 24);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(47, 20);
            this.cbColor.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(95, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "最小值";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(311, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "间隔";
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(341, 24);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(33, 21);
            this.txtY.TabIndex = 4;
            this.txtY.Text = "1";
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
            // btndraw
            // 
            this.btndraw.Location = new System.Drawing.Point(464, 85);
            this.btndraw.Name = "btndraw";
            this.btndraw.Size = new System.Drawing.Size(75, 23);
            this.btndraw.TabIndex = 0;
            this.btndraw.Text = "绘图";
            this.btndraw.UseVisualStyleBackColor = true;
            this.btndraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // FormPhaseChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 461);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPhaseChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "振幅相位图";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormFactorChart_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.pheader.ResumeLayout(false);
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
        private Dundas.Charting.WinControl.Chart chart1;
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
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ComboBox cbColorWater;
        private System.Windows.Forms.TextBox txtWater;
        private System.Windows.Forms.TextBox txtMaxWater;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMinWater;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
    }
}