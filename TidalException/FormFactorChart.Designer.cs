namespace TidalException
{
    partial class FormFactorChart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFactorChart));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pheader = new System.Windows.Forms.Panel();
            this.txtPhaseMax = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPhaseMin = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.cbSymbol = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtY = new System.Windows.Forms.TextBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btndraw = new System.Windows.Forms.Button();
            this.chart1 = new Dundas.Charting.WinControl.Chart();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pheader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chart1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1133, 404);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "绘图区";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pheader);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1133, 57);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作区";
            // 
            // pheader
            // 
            this.pheader.Controls.Add(this.txtPhaseMax);
            this.pheader.Controls.Add(this.label8);
            this.pheader.Controls.Add(this.txtPhaseMin);
            this.pheader.Controls.Add(this.label7);
            this.pheader.Controls.Add(this.cbColor);
            this.pheader.Controls.Add(this.cbSymbol);
            this.pheader.Controls.Add(this.label1);
            this.pheader.Controls.Add(this.label3);
            this.pheader.Controls.Add(this.txtY);
            this.pheader.Controls.Add(this.txtX);
            this.pheader.Controls.Add(this.label2);
            this.pheader.Controls.Add(this.label4);
            this.pheader.Controls.Add(this.btndraw);
            this.pheader.Location = new System.Drawing.Point(124, 12);
            this.pheader.Name = "pheader";
            this.pheader.Size = new System.Drawing.Size(802, 44);
            this.pheader.TabIndex = 4;
            this.pheader.SizeChanged += new System.EventHandler(this.pheader_SizeChanged);
            // 
            // txtPhaseMax
            // 
            this.txtPhaseMax.Location = new System.Drawing.Point(394, 14);
            this.txtPhaseMax.Name = "txtPhaseMax";
            this.txtPhaseMax.Size = new System.Drawing.Size(59, 21);
            this.txtPhaseMax.TabIndex = 18;
            this.txtPhaseMax.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(341, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "最大值";
            // 
            // txtPhaseMin
            // 
            this.txtPhaseMin.Location = new System.Drawing.Point(286, 14);
            this.txtPhaseMin.Name = "txtPhaseMin";
            this.txtPhaseMin.Size = new System.Drawing.Size(50, 21);
            this.txtPhaseMin.TabIndex = 16;
            this.txtPhaseMin.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(245, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "最小值";
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
            this.cbColor.Location = new System.Drawing.Point(496, 14);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(84, 20);
            this.cbColor.TabIndex = 6;
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
            this.cbSymbol.Location = new System.Drawing.Point(629, 14);
            this.cbSymbol.Name = "cbSymbol";
            this.cbSymbol.Size = new System.Drawing.Size(73, 20);
            this.cbSymbol.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(586, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "SYMBOL:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(460, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "颜色";
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(191, 14);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(48, 21);
            this.txtY.TabIndex = 4;
            this.txtY.Text = "1";
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(71, 14);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(61, 21);
            this.txtX.TabIndex = 3;
            this.txtX.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Y轴间隔";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "X轴间隔";
            // 
            // btndraw
            // 
            this.btndraw.Location = new System.Drawing.Point(718, 13);
            this.btndraw.Name = "btndraw";
            this.btndraw.Size = new System.Drawing.Size(75, 23);
            this.btndraw.TabIndex = 0;
            this.btndraw.Text = "绘图";
            this.btndraw.UseVisualStyleBackColor = true;
            this.btndraw.Click += new System.EventHandler(this.btndraw_Click_1);
            // 
            // chart1
            // 
            this.chart1.AlwaysRecreateHotregions = true;
            chartArea1.Area3DStyle.WallWidth = 0;
            chartArea1.AxisX.MinorTickMark.Size = 2F;
            chartArea1.AxisX.Title = "时间";
            chartArea1.AxisY.MinorTickMark.Size = 2F;
            chartArea1.AxisY.Title = "影响因子";
            chartArea1.BorderColor = System.Drawing.Color.Empty;
            chartArea1.Name = "Default";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Default";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 17);
            this.chart1.Name = "chart1";
            this.chart1.Palette = Dundas.Charting.WinControl.ChartColorPalette.Pastel;
            series1.ChartType = "FastPoint";
            series1.CustomAttributes = "DrawingStyle=Cylinder";
            series1.MarkerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series1.Name = "Series1";
            series1.PaletteCustomColors = new System.Drawing.Color[0];
            series1.ShadowOffset = 1;
            series1.SmartLabels.Enabled = true;
            series2.ChartType = "FastPoint";
            series2.CustomAttributes = "DrawingStyle=Cylinder";
            series2.MarkerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series2.Name = "Series2";
            series2.PaletteCustomColors = new System.Drawing.Color[0];
            series2.ShadowOffset = 1;
            series2.SmartLabels.Enabled = true;
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1127, 384);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title1.Name = "Title1";
            this.chart1.Titles.Add(title1);
            // 
            // FormFactorChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 461);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormFactorChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "影响因子图";
            this.Load += new System.EventHandler(this.FormFactorChart_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.pheader.ResumeLayout(false);
            this.pheader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSymbol;
        private System.Windows.Forms.Panel pheader;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btndraw;
        private System.Windows.Forms.TextBox txtPhaseMax;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPhaseMin;
        private System.Windows.Forms.Label label7;
        private Dundas.Charting.WinControl.Chart chart1;
    }
}