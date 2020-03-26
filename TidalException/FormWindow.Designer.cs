namespace TidalException
{
    partial class FormWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.潮汐计算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.潮汐数据处理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.潮汐异常计算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制水位图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制振幅相位图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制气压变化图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制影响因子图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制气压变化图日均值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.啊啊啊ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成测试数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.潮汐计算ToolStripMenuItem,
            this.潮汐数据处理ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(581, 25);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 潮汐计算ToolStripMenuItem
            // 
            this.潮汐计算ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.潮汐计算ToolStripMenuItem.Name = "潮汐计算ToolStripMenuItem";
            this.潮汐计算ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.潮汐计算ToolStripMenuItem.Text = "系统";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 潮汐数据处理ToolStripMenuItem
            // 
            this.潮汐数据处理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.潮汐异常计算ToolStripMenuItem,
            this.绘图ToolStripMenuItem,
            this.生成测试数据ToolStripMenuItem});
            this.潮汐数据处理ToolStripMenuItem.Name = "潮汐数据处理ToolStripMenuItem";
            this.潮汐数据处理ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.潮汐数据处理ToolStripMenuItem.Text = "潮汐数据处理";
            // 
            // 潮汐异常计算ToolStripMenuItem
            // 
            this.潮汐异常计算ToolStripMenuItem.Name = "潮汐异常计算ToolStripMenuItem";
            this.潮汐异常计算ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.潮汐异常计算ToolStripMenuItem.Text = "潮汐分析";
            this.潮汐异常计算ToolStripMenuItem.Click += new System.EventHandler(this.潮汐异常计算ToolStripMenuItem_Click);
            // 
            // 绘图ToolStripMenuItem
            // 
            this.绘图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.绘制水位图ToolStripMenuItem,
            this.绘制振幅相位图ToolStripMenuItem,
            this.绘制气压变化图ToolStripMenuItem,
            this.绘制影响因子图ToolStripMenuItem,
            this.绘制气压变化图日均值ToolStripMenuItem,
            this.啊啊啊ToolStripMenuItem});
            this.绘图ToolStripMenuItem.Name = "绘图ToolStripMenuItem";
            this.绘图ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.绘图ToolStripMenuItem.Text = "绘图";
            // 
            // 绘制水位图ToolStripMenuItem
            // 
            this.绘制水位图ToolStripMenuItem.Name = "绘制水位图ToolStripMenuItem";
            this.绘制水位图ToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.绘制水位图ToolStripMenuItem.Text = "绘制水位图";
            this.绘制水位图ToolStripMenuItem.Click += new System.EventHandler(this.绘制水位图ToolStripMenuItem_Click);
            // 
            // 绘制振幅相位图ToolStripMenuItem
            // 
            this.绘制振幅相位图ToolStripMenuItem.Name = "绘制振幅相位图ToolStripMenuItem";
            this.绘制振幅相位图ToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.绘制振幅相位图ToolStripMenuItem.Text = "绘制振幅相位图";
            this.绘制振幅相位图ToolStripMenuItem.Click += new System.EventHandler(this.绘制振幅相位图ToolStripMenuItem_Click);
            // 
            // 绘制气压变化图ToolStripMenuItem
            // 
            this.绘制气压变化图ToolStripMenuItem.Enabled = false;
            this.绘制气压变化图ToolStripMenuItem.Name = "绘制气压变化图ToolStripMenuItem";
            this.绘制气压变化图ToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.绘制气压变化图ToolStripMenuItem.Text = "绘制气压变化图(整点值)";
            this.绘制气压变化图ToolStripMenuItem.Click += new System.EventHandler(this.绘制气压变化图ToolStripMenuItem_Click);
            // 
            // 绘制影响因子图ToolStripMenuItem
            // 
            this.绘制影响因子图ToolStripMenuItem.Enabled = false;
            this.绘制影响因子图ToolStripMenuItem.Name = "绘制影响因子图ToolStripMenuItem";
            this.绘制影响因子图ToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.绘制影响因子图ToolStripMenuItem.Text = "绘制影响因子图";
            this.绘制影响因子图ToolStripMenuItem.Click += new System.EventHandler(this.绘制影响因子图ToolStripMenuItem_Click);
            // 
            // 绘制气压变化图日均值ToolStripMenuItem
            // 
            this.绘制气压变化图日均值ToolStripMenuItem.Enabled = false;
            this.绘制气压变化图日均值ToolStripMenuItem.Name = "绘制气压变化图日均值ToolStripMenuItem";
            this.绘制气压变化图日均值ToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.绘制气压变化图日均值ToolStripMenuItem.Text = "绘制气压变化图（日均值）";
            this.绘制气压变化图日均值ToolStripMenuItem.Click += new System.EventHandler(this.绘制气压变化图日均值ToolStripMenuItem_Click);
            // 
            // 啊啊啊ToolStripMenuItem
            // 
            this.啊啊啊ToolStripMenuItem.Enabled = false;
            this.啊啊啊ToolStripMenuItem.Name = "啊啊啊ToolStripMenuItem";
            this.啊啊啊ToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.啊啊啊ToolStripMenuItem.Text = "测试";
            this.啊啊啊ToolStripMenuItem.Click += new System.EventHandler(this.啊啊啊ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // 生成测试数据ToolStripMenuItem
            // 
            this.生成测试数据ToolStripMenuItem.Name = "生成测试数据ToolStripMenuItem";
            this.生成测试数据ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.生成测试数据ToolStripMenuItem.Text = "生成测试数据";
            this.生成测试数据ToolStripMenuItem.Click += new System.EventHandler(this.生成测试数据ToolStripMenuItem_Click);
            // 
            // FormWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(581, 409);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Name = "FormWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "潮汐分析软件";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 潮汐计算ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 潮汐数据处理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 潮汐异常计算ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制水位图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制振幅相位图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制气压变化图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制影响因子图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制气压变化图日均值ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 啊啊啊ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成测试数据ToolStripMenuItem;
    }
}