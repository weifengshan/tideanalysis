namespace TidalException
{
    partial class FormWaterLevelChartHour
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWaterLevelChartHour));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pheader = new System.Windows.Forms.Panel();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtY = new System.Windows.Forms.TextBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDraw = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chart1 = new Dundas.Charting.WinControl.Chart();
            this.lblcount = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.pheader.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pheader);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(871, 57);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作区";
            this.groupBox1.SizeChanged += new System.EventHandler(this.groupBox1_SizeChanged);
            // 
            // pheader
            // 
            this.pheader.Controls.Add(this.lblcount);
            this.pheader.Controls.Add(this.cbColor);
            this.pheader.Controls.Add(this.label3);
            this.pheader.Controls.Add(this.txtY);
            this.pheader.Controls.Add(this.txtX);
            this.pheader.Controls.Add(this.label2);
            this.pheader.Controls.Add(this.label1);
            this.pheader.Controls.Add(this.btnDraw);
            this.pheader.Location = new System.Drawing.Point(193, 12);
            this.pheader.Name = "pheader";
            this.pheader.Size = new System.Drawing.Size(542, 44);
            this.pheader.TabIndex = 1;
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
            this.cbColor.Location = new System.Drawing.Point(288, 14);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(84, 20);
            this.cbColor.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 19);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "X轴间隔";
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(393, 12);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 0;
            this.btnDraw.Text = "绘图";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chart1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(871, 323);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "绘图区";
            // 
            // chart1
            // 
            this.chart1.AlwaysRecreateHotregions = true;
            this.chart1.BorderLineColor = System.Drawing.Color.Brown;
            chartArea1.Area3DStyle.WallWidth = 0;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorTickMark.Style = Dundas.Charting.WinControl.TickMarkStyle.Inside;
            chartArea1.AxisX.MinorTickMark.Size = 2F;
            chartArea1.AxisX.Title = "时间";
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.MinorTickMark.Size = 2F;
            chartArea1.AxisY.Title = "水位（米）";
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
            series1.CustomAttributes = "DrawingStyle=LightToDark";
            series1.MarkerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series1.Name = "Series1";
            series1.PaletteCustomColors = new System.Drawing.Color[0];
            series1.ShadowOffset = 1;
            series1.SmartLabels.Enabled = true;
            series2.BorderWidth = 2;
            series2.ChartType = "Line";
            series2.Color = System.Drawing.Color.Black;
            series2.CustomAttributes = "DrawingStyle=LightToDark";
            series2.MarkerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series2.Name = "Series2";
            series2.PaletteCustomColors = new System.Drawing.Color[0];
            series2.ShadowOffset = 1;
            series2.SmartLabels.Enabled = true;
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(865, 303);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "整点值-水位变化图";
            this.chart1.Titles.Add(title1);
            // 
            // lblcount
            // 
            this.lblcount.AutoSize = true;
            this.lblcount.Location = new System.Drawing.Point(475, 14);
            this.lblcount.Name = "lblcount";
            this.lblcount.Size = new System.Drawing.Size(0, 12);
            this.lblcount.TabIndex = 7;
            // 
            // FormWaterLevelChartHour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 380);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormWaterLevelChartHour";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "整点值——水位变化图";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormWaterLevelChartHour_Load);
            this.groupBox1.ResumeLayout(false);
            this.pheader.ResumeLayout(false);
            this.pheader.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.GroupBox groupBox2;
        private Dundas.Charting.WinControl.Chart chart1;
        private System.Windows.Forms.Panel pheader;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblcount;
    }
}