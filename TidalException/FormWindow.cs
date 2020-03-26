using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TidalException
{
    public partial class FormWindow : Form
    {
        public FormWindow()
        {
            InitializeComponent();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout f = new FormAbout();
            f.ShowDialog();
        }

        private void 潮汐异常计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMain f = new FormMain();
            f.ShowDialog();
        }

        private void 绘制水位图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string datafile = "";
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "水位文本文件（*.txt）|*.txt";
            f.Multiselect = false;
            f.Title = "请选择水位数据文本文件";
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                datafile = f.FileName;
                if (datafile.Length == 0)
                {
                    MessageBox.Show("没有选择数据文件或数据文件不存在，请选择数据文件！");
                    return;
                }
                FormWaterLevelChartHour chart = new FormWaterLevelChartHour(datafile);
                chart.ShowDialog();
            }
        }

        private void 绘制振幅相位图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyFormPhaseChart f = new MyFormPhaseChart();
            f.ShowDialog();
        }

        private void 绘制影响因子图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string out06 = OutputDirPathForThis + "output06.dat";
            ////DataDir
            ////string out06 = DataDir + "output06.dat";
            //if (!File.Exists(out06))
            //{
            //    MessageBox.Show("没有output06.dat数据文件,请先点击“运行”按钮！");
            //    return;
            //}
            //FormFactorChart f = new FormFactorChart(out06);
            //f.ShowDialog();
        }

        private void 绘制气压变化图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (DataFile.Length == 0)
            //{
            //    MessageBox.Show("没有选择数据文件或数据文件不存在，请选择数据文件！");
            //    return;
            //}

            //FormTematureChartHour chart = new FormTematureChartHour(DataFile);
            //chart.ShowDialog();
        }

        private void 绘制气压变化图日均值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (DataFile.Length == 0)
            //{
            //    MessageBox.Show("没有选择数据文件或数据文件不存在，请选择数据文件！");
            //    return;
            //}

            //FormTematureChartDay chart = new FormTematureChartDay(DataFile);
            //chart.ShowDialog();
        }

        private void 啊啊啊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string out06 = OutputDirPathForThis + "output06.dat";
            ////DataDir
            //// string out06 = DataDir + "output06.dat";
            //if (!File.Exists(out06))
            //{
            //    MessageBox.Show("没有output06.dat数据文件,请先点击“运行”按钮！");
            //    return;
            //}
            ////  public FormPhaseChart(string inputdatafile,string outputfile06,string startdate,string endate, string shift)

            //MyFormPhaseChart f = new MyFormPhaseChart(DataFile, out06, txtStartTime.Text, txtEndTime.Text, txtShift.Text);
            //f.ShowDialog();
        }

        private void 生成测试数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormData f = new FormData();
            f.ShowDialog();
        }
    }
}
