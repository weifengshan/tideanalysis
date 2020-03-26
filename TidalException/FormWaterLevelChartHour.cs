using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Dundas.Charting.WinControl;
namespace TidalException
{
    public partial class FormWaterLevelChartHour : Form
    {
        public string datafile = "";
        private IList<ChartData> list = new List<ChartData>();
        private double max = -1;
        private double min = -1;

        public FormWaterLevelChartHour(string datafile)
        {
            
            InitializeComponent();
            this.datafile = datafile;

        }

        private void btnDraw_Click(object sender, EventArgs e)
        {

            double dX = 0;            
            double dY = 0;

            try
            {
                dX = double.Parse(txtX.Text);
                dY = double.Parse(txtY.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("请输入合适的X轴和Y轴刻度间隔，为浮点数类型");
                return;
            }
            bool b=  Loaddata();
            lblcount.Text = "共："+list.Count;
            if (b)
            {
                chart1.Series.Clear();           
                chart1.DataSource = list;
                chart1.Series.Add("水位小时值");
                chart1.Series[0].Type = SeriesChartType.Line; //Line
                chart1.Series[0].ValueMemberX = "DataName";
                chart1.Series[0].ValueMembersY = "DataValue";
                chart1.Series[0].XValueType =ChartValueTypes.DateTime;
                chart1.Series[0].YValueType = ChartValueTypes.Double;
                chart1.ChartAreas[0].AxisY.Maximum = (int)max + 1;
                chart1.ChartAreas[0].AxisY.Minimum = (int)min - 1;
                chart1.ChartAreas[0].AxisX.Interval = dX; //间隔刻度
                chart1.ChartAreas[0].AxisY.Interval = dY;  //间隔刻度
                chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false; //不显示坐标轴线
                chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false; //不显示坐标轴线
                if (cbColor.SelectedItem.ToString() == "黑色")
                    chart1.Series[0].Color = Color.Black;
                else if (cbColor.SelectedItem.ToString() == "红色")
                    chart1.Series[0].Color = Color.Red;
                else if (cbColor.SelectedItem.ToString() == "蓝色")
                    chart1.Series[0].Color = Color.Navy;
                else if (cbColor.SelectedItem.ToString() == "绿色")
                    chart1.Series[0].Color = Color.Green;

                //series2.Color = System.Drawing.Color.Black;

                chart1.DataBind();
                
            }

        }

        public class ChartData
        {
            DateTime dataName = DateTime.Now;
            public DateTime DataName
            {
                get { return dataName; }
                set { dataName = value; }
            }
            double? dataValue = 0;
            public double? DataValue
            {
                get { return dataValue; }
                set { dataValue = value; }
            }
            public ChartData()
            {

            }
            public ChartData(DateTime name, double? value)
            {
                this.dataName = name;
                this.dataValue = value;
            }
        }

        private bool Loaddata()
        {
            list.Clear();
            string str = "";
            StreamReader sr = new StreamReader(datafile, Encoding.Default);
            sr.ReadLine();//跳过行头
            try
            {
                int first = 0;
                while ((str = sr.ReadLine()) != null)
                {
                    string[] a = str.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (a.Length > 1)
                    {
                         
                        double v = double.Parse(a[1]);
                        if (v < 90000)
                        {
                            if (first == 0)
                            {
                                max = v;
                                min = v;
                                first++;
                            }                             
                            if (v > max)
                                max =v;
                            if (v<min)
                                min= v;
                            list.Add(new ChartData(ConvertDateTime(a[0]), v));
                        }
                        else
                        {
                            list.Add(new ChartData(ConvertDateTime(a[0]), null));
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                sr.Close();
                MessageBox.Show("数据格式有误，错误的数据：" + str);
                return false;
            }
            sr.Close();
            return true;
        }

        private DateTime ConvertDateTime(string ymdh)
        {
            string year = ymdh.Substring(0, 4);
            string month = ymdh.Substring(4, 2);
            string day = ymdh.Substring(6, 2);
            int hour = int.Parse(ymdh.Substring(8, 2));

            DateTime d = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day), hour, 0, 0);
            return d;

        }

        private void groupBox1_SizeChanged(object sender, EventArgs e)
        {
            pheader.Left = (this.Width - pheader.Width)/2  ;
        }

        private void FormWaterLevelChartHour_Load(object sender, EventArgs e)
        {
            cbColor.SelectedIndex = 0;
        }
    }
}
