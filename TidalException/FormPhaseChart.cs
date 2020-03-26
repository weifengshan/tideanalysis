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
    public partial class FormPhaseChart : Form
    {

        private string datafile = ""; //output06
        private string inputdatafile = ""; //数据文件
        private string startDate = "";
        private string endDate = "";
        private int shift = 0;
        private IList<ChartData2> list = new List<ChartData2>();
        private double? max = 0; //相位最大值
        private double? min = 0;//相位最小值
        private double? max2 = 0;//振幅最大值
        private double? min2 = 0;//振幅最小值 
        private double? maxWater = 0;//水位最大值
        private double? minWater = 0;//水位最小值

        public FormPhaseChart(string inputdatafile,string outputfile06,string startdate,string endate, string shift)
        {
            InitializeComponent();
            this.datafile = outputfile06;
            this.inputdatafile = inputdatafile;
            startDate = startdate;
            endDate = endate;
            this.shift = int.Parse(shift);
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            double dX = 0; //x轴间隔
            double dY = 0;//相位间隔
            double dY2 = 0;//振幅间隔
            double dWater = 0;//水位间隔
            try
            {
                dX = double.Parse(txtX.Text);
                dY = double.Parse(txtY.Text);
                dY2 = double.Parse(txtY2.Text);
                dWater = double.Parse( txtWater.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("请输入合适的X轴和Y轴刻度间隔，为浮点数类型");
                return;
            }

            chart1.ChartAreas.Clear();
            ChartArea waterLevel = chart1.ChartAreas.Add("Water");
            ChartArea phaseAmp = chart1.ChartAreas.Add("PhaseAmp");
             
            //waterLevel.
            //处理振幅、相位数据
            bool b = LoadData();
            if (!b)
            {
                MessageBox.Show("处理振幅、相位数据错误");
                return;
            }
            //处理水位信息
            bool bwater = LoadWaterData();
            if (!bwater)
            {
                MessageBox.Show("处水位数据错误");
                return;
            }

            //判断最大值和最小值是否在指定的范围内
            try
            {
                //相位
                double d = Convert.ToDouble( txtPhaseMax.Text);
                if (max < d)
                {
                    max= d;
                }
                d = Convert.ToDouble(txtPhaseMin.Text);
                if (d < min)
                {
                    min = d;
                }

                //振幅
                 d = Convert.ToDouble(txtAmpMax.Text);
                if (max2 < d)
                {
                    max2 = d;
                }
                d = Convert.ToDouble( txtAmpmin.Text);
                if (d < min2)
                {
                    min2 = d;
                }

                //水位
                d = Convert.ToDouble( txtMaxWater.Text);
                if (maxWater < d)
                {
                    maxWater = d;
                }
                d = Convert.ToDouble(txtMinWater.Text);
                if (d < minWater)
                {
                    minWater = d;
                }

                txtPhaseMin.Text = min.ToString();
                txtPhaseMax.Text = max.ToString();
                txtAmpmin.Text = min2.ToString();
                txtAmpMax.Text = max2.ToString();

                txtMinWater.Text = minWater.ToString();
                txtMaxWater.Text = maxWater.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("输入的最大值和最小值有误，为浮点数类型");
                return;
            }

            
            chart1.Series.Clear();
            Series phaseSeries =  chart1.Series.Add("相位");
            phaseSeries.Type = SeriesChartType.Line; //
            phaseSeries.ChartArea = "PhaseAmp";
            phaseSeries.ValueMemberX = "DataName";
            phaseSeries.ValueMembersY = "DataValue1";
            phaseSeries.YValueType = ChartValueTypes.Double;
            //chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Auto;

            if (cbColor.SelectedItem.ToString() == "黑色")
                phaseSeries.Color = Color.Black;
            else if (cbColor.SelectedItem.ToString() == "红色")
                phaseSeries.Color = Color.Red;
            else if (cbColor.SelectedItem.ToString() == "蓝色")
                phaseSeries.Color = Color.Navy;
            else if (cbColor.SelectedItem.ToString() == "绿色")
                phaseSeries.Color = Color.Green;
            
            //////////////////////////////////////////////////////
            Series ampSeries = chart1.Series.Add("振幅");
            ampSeries.Type = SeriesChartType.Line; //Line
            ampSeries.ChartArea = "PhaseAmp";
            ampSeries.ValueMemberX = "DataName";
            ampSeries.ValueMembersY = "DataValue2";
            ampSeries.YValueType = ChartValueTypes.Double;
            if (cbColor2.SelectedItem.ToString() == "黑色")
                ampSeries.Color = Color.Black;
            else if (cbColor2.SelectedItem.ToString() == "红色")
                ampSeries.Color = Color.Red;
            else if (cbColor2.SelectedItem.ToString() == "蓝色")
                ampSeries.Color = Color.Navy;
            else if (cbColor2.SelectedItem.ToString() == "绿色")
                ampSeries.Color = Color.Green;
            ampSeries.YAxisType = AxisType.Secondary;

            //相位，最大值和最小值+-5
            //振幅，最大值和最小值+-0.5
            
            
            phaseAmp.AxisY.Minimum = min.Value;
            phaseAmp.AxisY.Maximum = max.Value;

            phaseAmp.AxisY2.Minimum = min2.Value;
            phaseAmp.AxisY2.Maximum = max2.Value;
            phaseAmp.AxisX.MajorGrid.Enabled = false; //不显示坐标轴线
            phaseAmp.AxisY.MajorGrid.Enabled = false; //不显示坐标轴线
            phaseAmp.AxisY2.MajorGrid.Enabled = false;


            phaseAmp.AxisX.Interval = dX; //间隔刻度
            phaseAmp.AxisY.Interval = dY;  //间隔刻度
            phaseAmp.AxisY2.Interval = dY2;  //间隔刻度

            //////////////////////////////////////////////////////////////
            Series waterSeries = chart1.Series.Add("水位");
            waterSeries.Type = SeriesChartType.Line; //Line
            waterSeries.ValueMemberX = "DataName";
            waterSeries.ValueMembersY = "WaterLevel";
            waterSeries.YValueType = ChartValueTypes.Double;
            //waterSeries.Points.DataBindXY(list, "DataName", list, "WaterLevel");
            waterSeries.ChartArea = "Water";
            waterLevel.AxisX.MajorGrid.Enabled = false;
            waterLevel.AxisY.MajorGrid.Enabled = false;
            waterLevel.AxisY2.MajorGrid.Enabled = false;
            waterLevel.AxisX.MajorTickMark.Enabled = false;
            waterLevel.AxisX.LabelStyle.Enabled = false;

            if (cbColorWater.SelectedItem.ToString() == "黑色")
                waterSeries.Color = Color.Black;
            else if (cbColorWater.SelectedItem.ToString() == "红色")
                waterSeries.Color = Color.Red;
            else if (cbColorWater.SelectedItem.ToString() == "蓝色")
                waterSeries.Color = Color.Navy;
            else if (cbColorWater.SelectedItem.ToString() == "绿色")
                waterSeries.Color = Color.Green;
            waterLevel.AxisY.Minimum = minWater.Value;//水位刻度最小值
            waterLevel.AxisY.Maximum = maxWater.Value;//水位刻度最大值
            //======================================================================
            Series earthquakeSeries = chart1.Series.Add("地震（测试）");
            earthquakeSeries.Type = SeriesChartType.Point; //Line
            earthquakeSeries.ChartArea = "Water";
            earthquakeSeries.YAxisType = AxisType.Secondary;

            earthquakeSeries.ValueMemberX = "DataName";
            earthquakeSeries.ValueMembersY = "Earthquake";
            earthquakeSeries.YValueType = ChartValueTypes.Double;
            earthquakeSeries.Color = Color.SkyBlue;
            earthquakeSeries.ShowLabelAsValue = true;

            waterLevel.AxisY2.Minimum = 0;//水位刻度最小值
            waterLevel.AxisY2.Maximum = 12;//水位刻度最大值

            waterLevel.AxisX.Interval = dX; //间隔刻度

            //waterLevel.AxisX2.Arrows = ArrowsType.SharpTriangle;
            //waterLevel.AxisX2.Minimum = 0;
            //waterLevel.AxisX2.Maximum = 100;


            chart1.DataSource = list;
            chart1.DataBind();
            // MessageBox.Show("记录数共：" + list.Count);
            


            //保存数据

            string path = datafile.Replace("\\output06.dat",  "\\mydata.txt");
            if (File.Exists(path))
                File.Delete(path);
            StreamWriter sw = new StreamWriter(path, false);
            for (int i = 0; i < list.Count; i++)
            {
                sw.WriteLine(list[i].DataName + "\t" + list[i].WaterLevel + "\t" + list[i].DataValue1 + "\t" + list[i].DataValue2 );
            }
            sw.Close(); 


        }
        /// <summary>
        /// 处理振幅、相位数据
        /// </summary>
        /// <returns></returns>
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
            
            str = sr.ReadToEnd();
            sr.Close();

            try
            {
                string period = "PERIOD";
                //string groupsymbol = "  GROUP          SYMBOL       FACTOR   (RMSE)       PHASE   (RMSE)   AMPLITUDE  (RMSE)";
                int pos1 = -1;
                int startIndex1 =0;
                //int pos2 = -1;
               // int startIndex2 =0;
                string linesign = "";
                string s = cbSymbol.Text;
                if (s == "Q1")
                {
                    linesign = "1  (  1-143 : Q1      )";//行标记
                }
                else if (s == "O1")
                {
                    linesign = "2  (144-201 : O1      )";//行标记
                }
                else if (s == "M1")
                {
                    linesign = "3  (202-249 : M1      )";//行标记
                }
                else if (s == "P1S1K1")
                {
                    linesign = "4  (250-305 : P1S1K1  )";//行标记
                }
                else if (s == "J1")
                {
                    linesign = "5  (306-345 : J1      )";//行标记
                }
                else if (s == "OO1")
                {
                    linesign = "6  (346-450 : OO1     )";//行标记
                }
                else if (s == "2N2")
                {
                    linesign = "7  (451-549 : 2N2     )";//行标记
                }
                else if (s == "N2")
                {
                    linesign = "8  (550-599 : N2      )";//行标记
                }
                else if (s == "M2")
                {
                    linesign = "9  (600-655 : M2      )";//行标记
                }
                else if (s == "L2")
                {
                    linesign = "10  (656-681 : L2      )";//行标记
                }
                else if (s == "S2K2")
                {
                    linesign = "11  (682-827 : S2K2    )";//行标记
                }
                else if (s == "M3")
                {
                    linesign = "12  (828-909 : M3      )";//行标记
                }
        
                string strTime ="";
                int first1 = 0;
                int first2 = 0;

                while (startIndex1 > -1 && startIndex1 < str.Length)
                {
                    //find                                              PERIOD     2008  6 27   .0 - 2008  7 26 23.0
                    pos1 = str.IndexOf(period, startIndex1);
                    if (pos1 == -1)
                        break;   

                    //PERIOD     2008 12  9   .0
                    strTime = str.Substring(pos1 + 6, 20);
                    //strTime = strTime.Replace(" ","").Replace(".","0");
                    string[] a = strTime.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
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
                                //影响因子介于第1个“)”和“ (“之间
                                int p1 = line.IndexOf(")");
                                int p2 = line.IndexOf("(", p1);
                                if (p1 != -1 && p2 != -1)
                                {
                                    p1 = line.IndexOf(")", p2);
                                    p2 = line.IndexOf("(", p1);
                                    //Phase 介于第2个“)”和“ (“之间
                                    if (p1 != -1 && p2 != -1)
                                    {
                                        string strV = line.Substring(p1 + 1, p2 - p1 - 1);
                                        double? v = double.Parse(strV.Trim());
                                        startIndex1 = posRN2 + 1;
                                        if (v < 90000)
                                        {
                                            if (first1 == 0)
                                            {
                                                max = v;
                                                min = v;
                                                first1++;
                                            }
                                            if (v > max)
                                                max = v;
                                            if (v < min)
                                                min = v;
                                            //list.Add(new ChartData(strTime, v));
                                        }
                                        else
                                        {
                                            //list.Add(new ChartData(strTime, null));
                                            v = null;
                                        }
                                        // 振幅介于第3个“)”和“ (“之间
                                        p1 = line.IndexOf(")", p2);
                                        p2 = line.IndexOf("(", p1);
                                        if (p1 != -1 && p2 != -1)
                                        {
                                            string strV2 = line.Substring(p1 + 1, p2 - p1 - 1);
                                            double? v2 = double.Parse(strV2.Trim());
                                            startIndex1 = posRN2 + 1;
                                            if (v2 < 90000)
                                            {
                                                if (first2 == 0)
                                                {
                                                    max2 = v2;
                                                    min2 = v2;
                                                    first2++;
                                                }
                                                if (v2 > max2)
                                                    max2 = v2;
                                                if (v2 < min2)
                                                    min2 = v2;
                                                //list.Add(new ChartData2(sTime, v));
                                            }
                                            else
                                            {
                                                //list.Add(new ChartData2(sTime, null));
                                                v2 = null;
                                            }
                                            list.Add(new ChartData2(sTime, v, v2));
                                        }

                                    }

                                }
                                posRN = posRN2 + 2;
                                posRN2 = str.IndexOf("\r\n", posRN2 + 1);
                                break;
                            }
                            else
                            {
                                //不是目标行
                                posRN = posRN2 + 2;
                                posRN2 = str.IndexOf("\r\n", posRN2 + 1);
                            }
                            
                        }
                        //重设开始搜索位置
                        startIndex1 = posRN2;
                       continue ;
                    }
                    else
                        break;
                }
               
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据格式有误，错误的数据：" + ex.ToString());
                return false;
            }
            finally
            {
                sr.Close();
            }
        }

        /// <summary>
        /// 处理水位数据
        /// </summary>
        /// <returns></returns>
        private bool LoadWaterData()
        {
            string str = "";
            StreamReader sr = new StreamReader(inputdatafile, Encoding.Default);
            //sr.ReadLine();//跳过行头
            bool bFindFirstLine = false;
            try
            {
                
                int counter1 = 0; //总计数，包括无效数据
                int counter2 = 0;//仅包括有效数据，用于计数平均值

                double total = 0;
                int mIndex = 0;
                while ((str = sr.ReadLine()) != null)
                {
                    if (!bFindFirstLine)
                    {
                        if (str.StartsWith(startDate))
                        {
                            bFindFirstLine = true;
                            //初始化最大值和最小值
                            string[] start = str.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                            if (start.Length > 1)
                            {
                                double v = double.Parse(start[1]);
                                maxWater = minWater = v;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    string[] a = str.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (a.Length > 1)
                    {
                        double v = double.Parse(a[1]);
                        
                        if (v < 90000)
                        {
                            if (v > maxWater)
                            {
                                maxWater = v;
                            }
                            if (v < minWater)
                            {
                                minWater = v;
                            }
                            counter2++;
                            total += v ;
                        }
                        counter1++;
                        if (counter1 == shift && mIndex < list.Count)
                        {
                            //开始求平均值
                            double t = total / counter2;
                            //list.Add(new ChartData(ConvertDateTime(prevDay), t));
                            list[mIndex].WaterLevel = t;

                            //模拟产生震级
                            if (mIndex % 20 == 0)
                            {
                                list[mIndex].Earthquake = 5.1;
                            }
                            else
                            {
                                list[mIndex].Earthquake = null;
                            }
                            ////////////////////
                            counter1 = 0;
                            counter2 = 0;                            
                            total = 0;
                            mIndex++;

                            
                        }

                    }
                    else
                    {
                        MessageBox.Show("该行数据格式有误：" + str);
                        return false;
                    }

                }

                if (!bFindFirstLine)
                {
                    MessageBox.Show("数据格式有误，没有找到开始时间数据：" + startDate);
                    return false;
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
    //OUP          SYMBOL       FACTOR   (RMSE)       PHASE   (RMSE)   AMPLITUDE  (RMSE)
    //                                            (LOCAL, LAG:NEGATIVE)
    //1  (  1-143 : Q1      ) 51.41720 (30.16042)   140.544 ( 33.530)    93.882 (55.069 )
    //2  (144-201 : O1      ) 10.79045 ( 5.98054)  -136.915 ( 31.759)   102.903 (57.034 )
    //3  (202-249 : M1      ) 22.41307 (66.87686)    68.571 (171.165)    16.810 (50.158 )
    //4  (250-266 : P1      ) 11.00085 (14.22956)    98.123 ( 74.089)    48.814 (63.141 )
    //5  (267-270 : S1      )455.78486 (********)   -96.263 ( 75.395)    47.820 (62.875 )
    //6  (271-305 : K1      )  2.79214 ( 4.38711)   -88.927 ( 90.143)    37.448 (58.840 )
    //7  (306-345 : J1      )144.78821 (75.74738)    69.174 ( 29.929)   108.589 (56.809 )
    //8  (346-450 : OO1     ) 93.42883 (********)    83.306 ( 62.377)    38.339 (41.638 )

   // 1  (  1-143 : Q1      ) 55.37634 (28.97394)  -101.517 ( 30.006)   101.111 (52.903 )
   // 2  (144-201 : O1      )  9.36246 ( 6.56470)   131.350 ( 40.167)    89.285 (62.604 )
   // 3  (202-249 : M1      ) 15.32038 (60.29828)    33.577 (225.503)    11.490 (45.224 )
   // 4  (250-305 : P1S1K1  ) 14.57783 ( 6.38921)    90.723 ( 25.144)   195.519 (85.692 )
   // 5  (306-345 : J1      )122.67459 (70.75044)    40.169 ( 33.023)    92.004 (53.062 )
   // 6  (346-450 : OO1     )105.02217 (********)   105.089 ( 60.264)    43.096 (45.283 )

   // 7  (451-549 : 2N2     )116.50880 (71.62893)   -85.345 ( 35.205)    47.805 (29.390 )
   // 8  (550-599 : N2      ) 23.86202 (17.19133)   140.964 ( 41.287)    73.991 (53.307 )
   // 9  (600-655 : M2      )  5.90900 ( 3.82102)    47.273 ( 37.050)    95.699 (61.883 )
   //10  (656-681 : L2      )258.57039 (********)     8.549 ( 32.375)   118.365 (66.861 )
   //11  (682-827 : S2K2    ) 17.08911 ( 6.67550)  -122.978 ( 22.383)   128.766 (50.300 )

   //12  (828-909 : M3      )494.66192 (********)   160.776 ( 38.966)    85.380 (58.072 )



        private void FormFactorChart_Load(object sender, EventArgs e)
        {
            cbSymbol.SelectedIndex = 0;
            cbColor.SelectedIndex = 0;
            cbColor2.SelectedIndex = 1;
            cbColorWater.SelectedIndex = 2;
        }
    }



    public class ChartData2
    {
        string dataName = "";
        public string DataName
        {
            get { return dataName; }
            set { dataName = value; }
        }
        //相位
        double? dataValue1 = 0;
        public double? DataValue1
        {
            get { return dataValue1; }
            set { dataValue1 = value; }
        }
        //振幅
        double? dataValue2 = 0;
        public double? DataValue2
        {
            get { return dataValue2; }
            set { dataValue2 = value; }
        }

        //水位
        double? waterLevel;
        public double? WaterLevel
        {
            get { return waterLevel; }
            set { waterLevel = value; }
        }
        //地震
        double? earthquake;
        public double? Earthquake
        {
            get { return earthquake; }
            set { earthquake = value; }
        }

        public ChartData2()
        {
        }
        public ChartData2(string name, double? value1, double? value2)
        {
            this.dataName = name;
            this.dataValue1 = value1;
            this.dataValue2 = value2;
        }

    }

}
