using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Dundas.Charting.WinControl;
namespace TidalException
{
    public partial class FormFactorChart : Form
    {

        public string datafile = "";
        private IList<ChartData> list = new List<ChartData>();
        private double max = 0;
        private double min = 0;

        public FormFactorChart(string outputfile06)
        {
            InitializeComponent();
            this.datafile = outputfile06;

        }

 

        private bool LoadData()
        {
             list.Clear();
            string str = "";
            if (!File.Exists(datafile))
            {
                MessageBox.Show("数据文件不存在：" + datafile);
                return false;
            }
            StreamReader sr = new StreamReader(datafile, Encoding.Default);
            //sr.ReadLine();//跳过行头
            //while ((str = sr.ReadLine()) != null)
            //{

            //}

            str = sr.ReadToEnd();
            sr.Close();

            try
            {
                string period = "PERIOD";
               // string groupsymbol = "  GROUP          SYMBOL   ";
                int pos1 = -1;
                int startIndex1 =0;
                //int pos2 = -1;
                int startIndex2 =0;
                string linesign = " : " + cbSymbol.Text;//行标记
                string strTime ="";
                int first = 0;
                while (true)
                {
                    //find                                              PERIOD     2008  6 27   .0 - 2008  7 26 23.0
                    pos1 = str.IndexOf(period, startIndex1);
                    if (pos1 == -1)
                        break;  
                    //PERIOD     2008 12  9   .0
                    strTime = str.Substring(pos1+6,20);
                    //strTime = strTime.Replace(" ","").Replace(".","0");
                    string[] a = strTime.Split(new char[] { ' '},StringSplitOptions.RemoveEmptyEntries);
                    if (a.Length != 4)
                    {
                        MessageBox.Show("数据格式不正确(PERIOD)");
                        break;
                    }
                    string sTime = a[0] + int.Parse(a[1]).ToString("00") + int.Parse(a[2]).ToString("00");

                     
                    //FIND   GROUP          SYMBOL       FACTOR   (RMSE)       PHASE   (RMSE)   AMPLITUDE  (RMSE)
                    //pos2 = str.IndexOf(groupsymbol, pos1+1);
                    //if (pos2 == -1)
                    //    break; 
                    //查找指定那一行
                    int posRN = str.IndexOf("\r\n", pos1+1);
                    if (posRN != -1)
                    {
                        int posRN2 = str.IndexOf("\r\n", posRN+1);
                        while ( (posRN2 != -1))
                        {
                            //获取当前行
                            string line = str.Substring(posRN + 2, posRN2 - posRN-2);
                            //    3  (202-249 : M1      )   .11367 (  .05216)   -26.419 ( 26.324)      .071 (  .033 )
                            if (line.IndexOf(linesign) != -1)
                            {
                                //介于第一个“)”和“ (“之间
                                int p1 = line.IndexOf(")");
                                int p2 = line.IndexOf("(",p1);
                                if (p1 != -1 && p2 != -1)
                                {
                                    string strV = line.Substring(p1+1,p2-p1-1);
                                    double v = double.Parse(strV.Trim());
                                    startIndex1 = posRN2 + 1;
                                    if (v < 90000)
                                    {
                                        if (first == 0)
                                        {
                                            max = v;
                                            min = v;
                                            first++;
                                        }
                                        if (v > max)
                                            max = v;
                                        if (v < min)
                                            min = v;
                                        list.Add(new ChartData(sTime, v));
                                    }
                                    else
                                    {
                                        list.Add(new ChartData(sTime, null));
                                    }

                                }                                
                                break;
                            }
                            posRN = posRN2;
                            posRN2 = str.IndexOf("\r\n", posRN2+1);
                        }                     
                       continue ;
                    }
                    else
                        break;
                }
               
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据格式有误，错误的数据：" + str);
                return false;
            }
            finally
            {
                sr.Close();
            }
        }

        private void FormFactorChart_Load(object sender, EventArgs e)
        {
            cbSymbol.SelectedIndex = 0;
            cbColor.SelectedIndex = 0;
        }

        private void btndraw_Click_1(object sender, EventArgs e)
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
            bool b = LoadData();

            //相位
            double d = Convert.ToDouble(txtPhaseMax.Text);
            if (max < d)
            {
                max = d;
            }
            d = Convert.ToDouble(txtPhaseMin.Text);
            if (d < min)
            {
                min = d;
            }
            txtPhaseMin.Text = min.ToString();
            txtPhaseMax.Text = max.ToString();

            if (b)
            {
                //chart1.Series.Clear();
                //chart1.DataSource = list;
                //chart1.Series.Add("影响因子");
                //chart1.Series[0].Type = SeriesChartType.Line; //Line
                //chart1.Series[0].ValueMemberX = "DataName";
                //chart1.Series[0].ValueMembersY = "DataValue";
                //chart1.Series[0].YValueType = ChartValueTypes.Double;
                //chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Auto;
                //chart1.ChartAreas[0].AxisY.Maximum = max + 0.2;

                //chart1.DataBind();
                // MessageBox.Show("记录数共：" + list.Count);

                chart1.Titles.Clear();
                chart1.Titles.Add(new Title("影响因子"));
                chart1.Series.Clear();
                chart1.DataSource = list;
                chart1.Series.Add("影响因子");
                chart1.Series[0].Type = SeriesChartType.Line; //Line
                chart1.Series[0].ValueMemberX = "DataName";
                chart1.Series[0].ValueMembersY = "DataValue";
                chart1.Series[0].XValueType = ChartValueTypes.DateTime;
                chart1.Series[0].YValueType = ChartValueTypes.Double;
                chart1.ChartAreas[0].AxisY.Maximum = max;// double.Parse(max.ToString(".00")) + 0.1;
                chart1.ChartAreas[0].AxisY.Minimum = min;// double.Parse(min.ToString(".00")) - 0.1;
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

        private void pheader_SizeChanged(object sender, EventArgs e)
        {
            pheader.Left = (this.Width - pheader.Width) / 2;
        }
    }



    public class ChartData
    {
        string dataName = "";
        public string DataName
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
        public ChartData(string name, double? value)
        {
            this.dataName = name;
            this.dataValue = value;
        }

    }

}
