using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Dundas.Charting.WinControl;
using System.Threading.Tasks;

namespace TidalException
{
    public partial class MyFormPhaseChart : Form
    {

        private string datafile = ""; //output06
        private string dataExcelfile = ""; //绘图Excel数据文件
        private string earthquakeExcelfile = ""; //地震数据文件
        private string inputdatafile = ""; //数据文件
        private string startDate = "";
        private string endDate = "";
        private int shift = 0;

        private static List<BaytapChartData> list = new List<BaytapChartData>(); //相位、振幅
        private static List<WaterEarthQuake> listWater = new List<WaterEarthQuake>();  //水位
        private static List<WaterEarthQuake> earthquakelist = new List<WaterEarthQuake>();  //地震信息
        
        private double? max = 0; //相位最大值
        private double? min = 0;//相位最小值
        private double? max2 = 0;//振幅最大值
        private double? min2 = 0;//振幅最小值 
        private double? maxWater = 0;//水位最大值
        private double? minWater = 0;//水位最小值

        private int tnWater = 0; //水位 显示刻度总数
        private int tnPhase = 0;//相位显示刻度总数
        private int tnAmp = 0;//振幅显示刻度总数
        private int tnDate = 0;//X轴显示刻度总数

        private static PointF[] phasePoints;
        private static PointF[] ampPoints;
        private static PointF[] waterPoints;
        private static PointF[] earthquakePoints;

        Bitmap bmp ;

        Color[] verticalLine;//待擦除的垂直线
        Color[] horozionLine; //待擦除的水平线
        Color oldPointColor;
        //垂直线
        bool bVertialFlag = false;
        //水平线
        bool bHorizionFlag = false;

        public MyFormPhaseChart()
        {
            InitializeComponent();             
        }

        public MyFormPhaseChart(string inputdatafile, string outputfile06, string startdate, string endate, string shift)
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
            Graphics g = pdraw.CreateGraphics();
            g.Clear(Color.White);

            //double dX = 0; //x轴间隔
            //double dY = 0;//相位  Phase 间隔
            //double dY2 = 0;//振幅间隔  Amp
            //double dWater = 0;//水位间隔
            try
            {
                tnDate = int.Parse(txtX.Text); // 总刻度数
                tnPhase = int.Parse(txtY.Text);  //相位  刻度数
                tnAmp = int.Parse(txtY2.Text);  //振幅  刻度数
                tnWater = int.Parse(txtWater.Text); //水位  刻度数
            }
            catch (Exception ex)
            {
                MessageBox.Show("请输入合适的X轴和Y轴刻度间隔，为浮点数类型");
                return;
            }
            if (dataExcelfile == "")
            {
                MessageBox.Show("请选择Excel数据文件！");
                  return;
            }
            
            //加载水位数据
            string sqlWater = "select * from [WaterLevel$]";
            DataSet ds = ExcelDbHelper.ExecuteSelectSql(dataExcelfile,sqlWater);

            string t = "";
            list.Clear();   //波形数据
            listWater.Clear(); //清空水位信息            
            for (int i =0; i< ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                //从第2行开始读取
                t = dr["时间"].ToString();
                if (string.IsNullOrEmpty(t))
                {
                    break;
                }                
                double? d3 = null;//水位
                d3 = double.Parse(dr["水位"].ToString()); //水位



                string ms = dr["震级"].ToString();
                string lat = dr["纬度"].ToString();
                string lon = dr["经度"].ToString();
                string depth = dr["深度"].ToString();
                string location = dr["参考地点"].ToString();

                if (i == 0)
                {
                    if (d3 < 90000)
                    {
                        maxWater = minWater =d3;
                    }
                    else
                    {
                        maxWater = minWater = 0;
                    }
                }
                else
                {                   
                    if (d3 < 90000)
                    {
                        if (d3 > maxWater)
                            maxWater = d3;
                        if (d3 < minWater)
                            minWater = d3;
                    }
                    
                }                      
                WaterEarthQuake earthquake = new WaterEarthQuake(t,d3, ms, lon, lat, depth, location);
                listWater.Add(earthquake);                               
            }
            

            //加载各个波的数据
            string sqlWave = "select * from [Sheet_{0}$]";
            sqlWave = string.Format(sqlWave, cbSymbol.SelectedItem.ToString());
            DataSet dsWave = ExcelDbHelper.ExecuteSelectSql(dataExcelfile, sqlWave);
            for (int i = 0; i < dsWave.Tables[0].Rows.Count; i++)
            {
                DataRow dr = dsWave.Tables[0].Rows[i];
                //从第2行开始读取
                t = dr["时间"].ToString();
                if (string.IsNullOrEmpty(t))
                {
                    break;
                }
                double? d1 = null; //相位
                double? d2 = null;//振幅

                d1 = double.Parse(dr["相位"].ToString()); //相位
                d2 = double.Parse(dr["振幅"].ToString()); //振幅
                
               
                if (i == 0)
                {
                    max = min = d1;
                    max2 = min2 = d2;                    
                }
                else
                {
                    if (d1 != null && d1 > max)
                        max = d1;
                    if (d1 != null && d1 < min)
                        min = d1;

                    if (d2 != null && d2 > max2)
                        max2 = d2;
                    if (d2 != null && d2 < min2)
                        min2 = d2;    
                }
                if (d1 != null && d2 != null)
                {
                    list.Add(new BaytapChartData(t, d1, d2));
                }               

            }

            //最大值和最小值参考
            lblAmpMax.Text = max2.ToString();
            lblAmpMin.Text = min2.ToString();
            lblPhaseMax.Text = max.ToString();
            lblPhaseMin.Text = min.ToString();
            lblWaterMax.Text = maxWater.ToString();
            lblWaterMin.Text = minWater.ToString();
           
            
            double d = 0;
            //相位
            try
            {
                if (string.IsNullOrEmpty(txtPhaseMax.Text))
                {
                    txtPhaseMax.Text = max.ToString();
                }
                else
                {
                    d = Convert.ToDouble(txtPhaseMax.Text);
                    if (max < d)
                    {
                        max = d;
                    }
                }
                if (string.IsNullOrEmpty(txtPhaseMin.Text))
                {
                    txtPhaseMin.Text = min.ToString();
                }
                else
                {
                    d = Convert.ToDouble(txtPhaseMin.Text);
                    if (d < min)
                    {
                        min = d;
                    }
                }

                //振幅
                if (string.IsNullOrEmpty(txtAmpMax.Text))
                {
                    txtAmpMax.Text = max2.ToString();
                }
                else
                {

                    d = Convert.ToDouble(txtAmpMax.Text);
                    if (max2 < d)
                    {
                        max2 = d;
                    }

                }
                if (string.IsNullOrEmpty(txtAmpmin.Text))
                {
                    txtAmpmin.Text = min2.ToString();
                }
                {
                    d = Convert.ToDouble(txtAmpmin.Text);
                    if (d < min2)
                    {
                        min2 = d;
                    }
                }

            }
            catch
            {
                MessageBox.Show("无该波形数据！"+cbSymbol.Text);
                return;
            }
            

            //水位
            d = Convert.ToDouble(txtMaxWater.Text);
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




            //将地震信息合并到 最接近的 开始时间
            if (earthquakelist != null && earthquakelist.Count > 0)
            {
                MergeData(earthquakelist, listWater);
            }
            try
            {
                //bmp = new Bitmap(pdraw.Width, pdraw.Height);
                ////Graphics g = Graphics.FromImage(bmp); //pdraw.CreateGraphics();            
                //g.Clear(Color.White);
                //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; //消除锯齿
                //Utility timer = new Utility();
                //timer.Start();

                SerialDraw(g);

                //timer.Stop();

                //Graphics g2 = pdraw.CreateGraphics();
                //g2.DrawImage(bmp, 0, 0);
                //g2.Dispose();

                //ParallelDraw();

              
               

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("绘图时，出现异常，请重试！");
            }

           //pdraw.BackgroundImage = bmp;
          
            


        }

       


        private void FormFactorChart_Load(object sender, EventArgs e)
        {
            //双缓冲
            DoubleBuffered = true;
            //跨线程访问控件
            Control.CheckForIllegalCrossThreadCalls = false;

            bmp = new Bitmap(pdraw.Width, pdraw.Height);
            verticalLine = new Color[pdraw.Height];
            horozionLine = new Color[pdraw.Width];

            cbSymbol.SelectedIndex = 0;
            cbColor.SelectedIndex = 3;
            cbColor2.SelectedIndex = 1;
            cbColorWater.SelectedIndex = 2;
            //窗体大小变化时，完全重绘窗体
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

       
        /// <summary>
        /// 绘制坐标轴
        /// </summary>
        public void _DrawXY()
        {
            //Bitmap _bmp = new Bitmap(pdraw.Width, pdraw.Height);
            //Graphics g =  Graphics.FromImage(_bmp); //pdraw.CreateGraphics();            
            //g.Clear(Color.White);
            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; //消除锯齿

            Graphics g = pdraw.CreateGraphics();//

            phasePoints = new PointF[list.Count];
            ampPoints = new PointF[list.Count];

            waterPoints = new PointF[listWater.Count];
            earthquakePoints = new PointF[listWater.Count]; //大部分为空值

            if (pdraw.Width == 0 && pdraw.Height == 0)
                return;


            StringFormat verticalformat = new StringFormat();
            verticalformat.FormatFlags = StringFormatFlags.DirectionVertical;


            //绘制坐标轴
            float totalwidth = pdraw.Width;
            float totalheight = pdraw.Height;
            //x轴(50,totalheight -50)
            float margin = 50; //左右边框和上边框的边距
            float margin2 = 80; //下边框的边距
            float margin3 = 100; //下边距的间距
            float space = 30; // 水位之间的间隔


            float oX0 = margin + 20;
            float oY0 = totalheight - margin3;
            float oX1 = totalwidth - margin;
            float oY1 = oY0;

            //x轴宽度
            float w = oX1 - oX0;
            int splitenumber = list.Count / int.Parse(txtX.Text);
            float splitX = w / list.Count;

            //水位，振幅相位各占一半
            float effectiveHeigh = totalheight - margin - margin3 - space;

            float waterheight = effectiveHeigh / 2 - space / 2;

            //绘制振幅y轴
            float oY2 = margin + effectiveHeigh / 2 + space / 2;
            //左侧 y2轴 中间点               
            float oY3 = margin + effectiveHeigh / 2 - space / 2;

            //pdraw.AppendText(sb.ToString());
            //绘制振幅、相位x坐标轴
            g.DrawLine(new Pen(new SolidBrush(Color.Black)), new PointF(oX0, oY0), new PointF(oX1, oY1));
            //左侧 y1轴
            // float oX2 = oX0;
            //水位，振幅相位各占一半
            //float effectiveHeigh = totalheight - margin - margin3 - space;
            //绘制振幅y轴
            //float oY2 = margin + effectiveHeigh / 2 + space / 2;
            g.DrawLine(new Pen(new SolidBrush(Color.Black)), new PointF(oX0, oY0), new PointF(oX0, oY2));
            //float waterheight = effectiveHeigh / 2 - space / 2;
            //左侧 y2轴 中间点               
            // float oY3 = margin + effectiveHeigh / 2 - space / 2;
            //绘制水位X坐标轴
            g.DrawLine(new Pen(new SolidBrush(Color.Black)), new PointF(oX0, oY3), new PointF(oX1, oY3));
            //绘制水位y坐标轴左侧
            float oY4 = margin;
            g.DrawLine(new Pen(new SolidBrush(Color.Black)), new PointF(oX0, oY3), new PointF(oX0, oY4));
            //右侧y轴线
            g.DrawLine(new Pen(new SolidBrush(Color.Black)), new PointF(oX1, oY1), new PointF(oX1, oY2));
            g.DrawLine(new Pen(new SolidBrush(Color.Black)), new PointF(oX1, oY3), new PointF(oX1, oY4));
            //坐标轴名称
            g.DrawString("相位/°", new Font(new FontFamily("宋体"), 10), new SolidBrush(Color.Red), 2, oY2 + effectiveHeigh / 4 - 10, verticalformat);
            g.DrawString("振幅/cm", new Font(new FontFamily("宋体"), 10), new SolidBrush(Color.Red), totalwidth - 20, oY2 + effectiveHeigh / 4 - 10, verticalformat);
            g.DrawString("水位/m", new Font(new FontFamily("宋体"), 10), new SolidBrush(Color.Red), 2, oY4 + waterheight / 2 - 10, verticalformat);
            //振幅、相位时间
            g.DrawString("时间", new Font(new FontFamily("宋体"), 10), new SolidBrush(Color.Red), totalwidth / 2 - 10, totalheight - 15);
            //水位时间
            g.DrawString("时间", new Font(new FontFamily("宋体"), 10), new SolidBrush(Color.Red), totalwidth / 2 - 10, oY3 + 20);
            //图例
            g.DrawLine(new Pen(new SolidBrush(GetColor(cbColor.SelectedItem.ToString()))), new PointF(oX1 - 80, oY2 + 10), new PointF(oX1 - 40, oY2 + 10));
            g.DrawString("相位", new Font(new FontFamily("宋体"), 10), new SolidBrush(Color.Black), oX1 - 40, oY2 + 5);
            g.DrawLine(new Pen(new SolidBrush(GetColor(cbColor2.SelectedItem.ToString()))), new PointF(oX1 - 80, oY2 + 30), new PointF(oX1 - 40, oY2 + 30));
            g.DrawString("振幅", new Font(new FontFamily("宋体"), 10), new SolidBrush(Color.Black), oX1 - 40, oY2 + 25);
            g.DrawLine(new Pen(new SolidBrush(GetColor(cbColorWater.SelectedItem.ToString()))), new PointF(oX1 - 80, oY4 + 30), new PointF(oX1 - 40, oY4 + 30));
            g.DrawString("水位", new Font(new FontFamily("宋体"), 10), new SolidBrush(Color.Black), oX1 - 40, oY4 + 25);
                       
        }


        /// <summary>
        ///   绘制振幅、相位X轴刻度       
        /// </summary>
        /// <param name="oX0"></param>
        /// <param name="oY0"></param>
        /// <param name="splitenumber"></param>
        /// <param name="splitX"></param>
        public void _DrawXKedu(float oX0, float oY0, int splitenumber, float splitX)
        {
            Graphics g = pdraw.CreateGraphics();                        
            float d = oX0;
            for (int i = 0; i <= list.Count; i++)
           {
                if (splitenumber > 0 && i % splitenumber == 0)
                {
                    //标注刻度
                    g.DrawLine(new Pen(new SolidBrush(Color.Black)), new PointF(d, oY0), new PointF(d, oY0 + 5)); //高度为5
                    StringFormat sf = new StringFormat();
                    sf.FormatFlags = StringFormatFlags.DirectionVertical;
                    if (i < list.Count)
                        g.DrawString(list[i].DataTime.Substring(0, 8), new Font(new FontFamily("宋体"), 8),
                            new SolidBrush(Color.Black), d - 7, (oY0 + 6), sf);
                }
                else if (splitenumber == 0)
                {
                    g.DrawLine(new Pen(new SolidBrush(Color.Black)), new PointF(d, oY0), new PointF(d, oY0 + 5)); //高度为5
                    StringFormat sf = new StringFormat();
                    sf.FormatFlags = StringFormatFlags.DirectionVertical;
                    if (i < list.Count)
                        g.DrawString(list[i].DataTime.Substring(0, 8), new Font(new FontFamily("宋体"), 8),
                            new SolidBrush(Color.Black), d - 7, (oY0 + 6), sf);

                }
                //g.DrawString(list[i].DataName, new Font("宋体", 10), new SolidBrush(Color.Black), (int)d, oY0);
                d += splitX;
            }
        }
        /// <summary>
        /// 处理振幅、相位坐标点，绘制数据
        /// </summary>
        private void _DrawPhaseAmp(float oX0, float oY0,float splitX,float h1)
        {
            Graphics g = pdraw.CreateGraphics(); 
            for (int i = 0; i < list.Count; i++)
            {

                string t = list[i].DataTime;
                double? phase = list[i].Phase;
                double? amp = list[i].Amplitude;


                float xx = (oX0 + splitX * i);
                float yy = oY0;
                //相位
                if (phase.Value > 90000)
                {
                    //忽略该值,现在置为0
                    PointF p = new PointF(xx, yy);
                    phasePoints[i] = p;
                }
                else
                {
                    yy = (float)(oY0 - (phase - min) * h1 / (max - min));
                    PointF p = new PointF(xx, yy);
                    phasePoints[i] = p;
                }
                //振幅
                if (amp.Value > 90000)
                {
                    //忽略该值,现在置为0
                    PointF p = new PointF(xx, yy);
                    ampPoints[i] = p;
                }
                else
                {
                    yy = (float)(oY0 - (amp - min2) * h1 / (max2 - min2));
                    PointF p = new PointF(xx, yy);
                    ampPoints[i] = p;
                }
            }
            //绘制相位曲线
            if (phasePoints.Length > 0) 
                g.DrawLines(new Pen(new SolidBrush(GetColor(cbColor.SelectedItem.ToString()))), phasePoints);//相位
            //绘制振幅曲线
            if (ampPoints.Length >0)
                g.DrawLines(new Pen(new SolidBrush(GetColor(cbColor2.SelectedItem.ToString()))), ampPoints);//振幅

        }

        /// <summary>
        /// 绘制振幅、相位、水位 y坐标轴刻度
        /// </summary>
        /// <param name="oX0"></param>
        /// <param name="oY0"></param>
        /// <param name="oX1"></param>
        /// <param name="oY1"></param>
        /// <param name="oY3"></param>
        /// <param name="h1"></param>
        /// <param name="splitX"></param>
        private void _DrawYKedu(float oX0, float oY0, float oX1, float oY1, float oY3, float h1, float waterheight)
        {
            Graphics g = pdraw.CreateGraphics();   
            //绘制相位Y坐标轴
            for (int i = 0; i <= tnPhase; i++)
            {
                // d += splitY1;
                float x2 = oX0;
                float y2 = (oY0 - (i * h1 / tnPhase)); //*splitY1
                float x1 = oX0 - 5;
                float y1 = y2;

                g.DrawLine(new Pen(new SolidBrush(Color.Black)), new PointF(x1, y1), new PointF(x2, y2));
                string str = (min + (i * (max - min) / tnPhase)).Value.ToString("0.00");
                g.DrawString(str, new Font(new FontFamily("宋体"), 8), new SolidBrush(Color.Black), x1 - 40, y1 - 5);

            }
            //绘制振幅Y坐标轴
            for (int i = 0; i <= tnAmp; i++)
            {
                // d += splitY1;
                float x1 = oX1;
                float y1 = (oY0 - (i * h1 / tnAmp)); //*splitY1
                float x2 = oX1 + 5;
                float y2 = y1;

                g.DrawLine(new Pen(new SolidBrush(Color.Black)), new PointF(x1, y1), new PointF(x2, y2));
                string str = (min2 + (i * (max2 - min2) / tnAmp)).Value.ToString("0.00");
                g.DrawString(str, new Font(new FontFamily("宋体"), 8), new SolidBrush(Color.Black), x2, y2 - 5);
            }

            //绘制左侧水位坐标轴刻度
            for (int i = 0; i <= tnWater; i++)
            {

                float x1 = oX0 - 5;
                float y1 = (oY3 - (i * waterheight / tnWater));
                float x2 = oX0;
                float y2 = y1; //*splitY1
                //或左侧刻度
                g.DrawLine(new Pen(new SolidBrush(Color.Black)), new PointF(x1, y1), new PointF(x2, y2));
                string waterlevel = (minWater + (i * (maxWater - minWater) / tnWater)).Value.ToString("0.0");
                //绘制刻度值
                g.DrawString(waterlevel, new Font(new FontFamily("宋体"), 8), new SolidBrush(Color.Black), x1 - 40, y1 - 5);

            }
        }
       
        
        /// <summary>
        /// 绘制水位
        /// </summary>
        private void _DrawWater(float oX0, float oY0, float oY3, float waterheight,float w)
        {
            Graphics g = pdraw.CreateGraphics(); 
            //绘制水位X轴刻度
            float splitWaterX = (float)(w * 1.0 / listWater.Count);
            float d = oX0;
            int month = 0;
            for (int i = 0; i < listWater.Count; i++)
            {
                if (listWater[i].Time.EndsWith("0100"))
                {
                    //标注刻度
                    StringFormat sf = new StringFormat();
                    if (month % 6 == 0)
                    {
                        g.DrawLine(new Pen(new SolidBrush(Color.Red)), new PointF(d, oY3), new PointF(d, oY3 + 8)); //高度为5
                        //半年标注一个刻度
                        g.DrawString(listWater[i].Time.Substring(0, 8), new Font(new FontFamily("宋体"), 8),
                            new SolidBrush(Color.Black), d - 12, (oY3 + 6), sf);
                    }
                    else
                    {
                        g.DrawLine(new Pen(new SolidBrush(Color.Black)), new PointF(d, oY3), new PointF(d, oY3 + 5)); //高度为5
                    }
                    month++;
                    d += splitWaterX;
                }
                else
                {
                    d += splitWaterX;
                }

            }
            //准备水位数据
            for (int i = 0; i < listWater.Count; i++)
            {
                float xx = (oX0 + splitWaterX * i);
                float yy = oY0;

                double? water = listWater[i].WaterLevel;
                //水位
                if (water == null || water.Value > 90000)
                {
                    //忽略该值,现在置为0
                    PointF p = new PointF(xx, oY3);
                    waterPoints[i] = p;
                }
                else
                {
                    yy = (float)(oY3 - (water - minWater) * waterheight / (maxWater - minWater));
                    PointF p = new PointF(xx, yy);
                    waterPoints[i] = p;
                }
            }
            //绘制水位曲线
            g.DrawLines(new Pen(new SolidBrush(GetColor(cbColorWater.SelectedItem.ToString()))), waterPoints); //水位

        }


        private void _DrawEarthquake(float oX0,float splitX)
        {
            Graphics g = pdraw.CreateGraphics();
            for (int i = 0; i < listWater.Count; i++)
            {
                float ex = (oX0 + splitX * i);
                DrawEathquakeInfo(listWater[i], waterPoints[i], g);
            }

        }

        /// <summary>
        /// 并行绘图
        /// </summary>
        private void ParallelDraw()
        {
            Utility timer = new Utility();
            timer.Start();

            Graphics g = pdraw.CreateGraphics();
            phasePoints = new PointF[list.Count];
            ampPoints = new PointF[list.Count];
            waterPoints = new PointF[listWater.Count];
            earthquakePoints = new PointF[listWater.Count]; //大部分为空值
            if (pdraw.Width == 0 && pdraw.Height == 0)
                return;
                  
            StringFormat verticalformat = new StringFormat();
            verticalformat.FormatFlags = StringFormatFlags.DirectionVertical;


            //绘制坐标轴
            float totalwidth = pdraw.Width;
            float totalheight = pdraw.Height;
            //x轴(50,totalheight -50)
            float margin = 50; //左右边框和上边框的边距
            float margin2 = 80; //下边框的边距
            float margin3 = 100; //下边距的间距
            float space = 30; // 水位之间的间隔


            float oX0 = margin + 20;
            float oY0 = totalheight - margin3;
            float oX1 = totalwidth - margin;
            float oY1 = oY0;

            //x轴宽度
            float w = oX1 - oX0;
            int splitenumber = list.Count / int.Parse(txtX.Text);
            float splitX = w / list.Count;

            //水位，振幅相位各占一半
            float effectiveHeigh = totalheight - margin - margin3 - space;

            float waterheight = effectiveHeigh / 2 - space / 2;

            //绘制振幅y轴
            float oY2 = margin + effectiveHeigh / 2 + space / 2;
            //左侧 y2轴 中间点               
            float oY3 = margin + effectiveHeigh / 2 - space / 2;

           
            //启动单独任务绘制坐标轴
            Task t1 = Task.Factory.StartNew(() =>
            {
                _DrawXY();              
            }
            );
            //绘制振幅/相位 X轴刻度
            Task t2 = Task.Factory.StartNew(() =>
            {
                _DrawXKedu(oX0, oY0, splitenumber, splitX);              
            }
            );


          

            //相位,振幅总高度和间隔
            float h1 = oY0 - oY2;
            float splitY1 = (float)((max.Value - min.Value) / h1); //相位
            float splitY2 = (float)((max2.Value - min2.Value) / h1);//振幅            
            //float splitY3 = (float)((maxWater.Value - minWater.Value) / h3); //水位
            float d = 0;
            //绘制振幅/相位 X轴刻度
            Task t3 = Task.Factory.StartNew(() =>
            {
                _DrawYKedu(oX0, oY0,oX1,oY1,oY3,h1,waterheight);
            }
            );


            //处理振幅、相位坐标点，准备绘制数据
            Task t4 = Task.Factory.StartNew(() =>
            {
                _DrawPhaseAmp(oX0, oY0, splitX, h1);
            }
            );

             //处理水位数据，绘制点和坐标
            Task t5 = Task.Factory.StartNew(() =>
            {
                _DrawWater(oX0, oY0, oY3, waterheight, w);
            }
            );
            
            

            //绘制地震信息           
           Task t6 = Task.Factory.StartNew(() =>
            {
                _DrawEarthquake(oX0, splitX);
            }
            );


           Task.WaitAll(t1, t2,t3,t4,t5,t6);

           timer.Stop();
        }

        /// <summary>
        /// 串行绘图
        /// </summary>
        private void SerialDraw(Graphics g)
        {
            phasePoints = new PointF[list.Count];
            ampPoints = new PointF[list.Count];

            waterPoints = new PointF[listWater.Count];
            earthquakePoints = new PointF[listWater.Count]; //大部分为空值

            if (pdraw.Width == 0 && pdraw.Height == 0)
                return;

            //bmp = new Bitmap(pdraw.Width, pdraw.Height);
            //Graphics g = Graphics.FromImage(bmp); //pdraw.CreateGraphics();            
            //g.Clear(Color.White);
            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; //消除锯齿

            StringFormat verticalformat = new StringFormat();
            verticalformat.FormatFlags = StringFormatFlags.DirectionVertical;


            //绘制坐标轴
            float totalwidth = pdraw.Width;
            float totalheight = pdraw.Height;
            //x轴(50,totalheight -50)
            float margin = 50; //左右边框和上边框的边距
            float margin2 = 80; //下边框的边距
            float margin3 = 100; //下边距的间距
            float space = 30; // 水位之间的间隔
           

            float oX0 = margin+20;
            float oY0 = totalheight - margin3;
            float oX1 = totalwidth - margin;
            float oY1 = oY0;

            //x轴宽度
            float w = oX1 - oX0;
            int splitenumber = list.Count / int.Parse(txtX.Text);
            float splitX = w / list.Count;
            //绘制振幅、相位x坐标轴
            g.DrawLine(new Pen(new SolidBrush(Color.Black)), new PointF(oX0, oY0), new PointF(oX1, oY1));


            /*
            |margin
            |
            oX0, oY4-----------------------------------------------------------------------------------------ox1,oy4
            |
            |waterheight
            |
            |
            oX0, oY3-----------------------------------------------------------------------------------------oX1, oY3
             
             (space)
            oX0, oY2-----------------------------------------------------------------------------------------ox1,oy2
            |
            |
            |
            |
            |
            |
            ox0,oy0___________________________________________________________________________________________ox1,oy1
            |
            |
            */

            //左侧 y1轴
           // float oX2 = oX0;
            //水位，振幅相位各占一半
            float effectiveHeigh = totalheight - margin -margin3 - space;
            //绘制振幅y轴
            float oY2 = margin+effectiveHeigh / 2 + space / 2;
            g.DrawLine(new Pen(new SolidBrush(Color.Black)), new PointF(oX0, oY0), new PointF(oX0, oY2));


            float waterheight = effectiveHeigh / 2 - space/2;

            //左侧 y2轴 中间点
            //float oX3 = oX0;

            float oY3 = margin + effectiveHeigh / 2 - space / 2;
            //绘制水位X坐标轴
            g.DrawLine(new Pen(new SolidBrush(Color.Black)), new PointF(oX0, oY3), new PointF(oX1, oY3));

            //绘制水位y坐标轴左侧
            float oY4 = margin;
            g.DrawLine(new Pen(new SolidBrush(Color.Black)), new PointF(oX0, oY3), new PointF(oX0, oY4));

            
            //右侧y轴线
            g.DrawLine(new Pen(new SolidBrush(Color.Black)), new PointF(oX1, oY1), new PointF(oX1, oY2));
            g.DrawLine(new Pen(new SolidBrush(Color.Black)), new PointF(oX1, oY3), new PointF(oX1, oY4));


            //坐标轴名称
            g.DrawString("相位/°", new Font(new FontFamily("宋体"), 10), new SolidBrush(Color.Red), 2, oY2 + effectiveHeigh / 4 - 10, verticalformat);
            g.DrawString("振幅/cm", new Font(new FontFamily("宋体"), 10), new SolidBrush(Color.Red), totalwidth - 20, oY2 + effectiveHeigh / 4 - 10, verticalformat);
            g.DrawString("水位/m", new Font(new FontFamily("宋体"), 10), new SolidBrush(Color.Red), 2, oY4 + waterheight / 2 - 10, verticalformat);
            //振幅、相位时间
            g.DrawString("时间", new Font(new FontFamily("宋体"), 10), new SolidBrush(Color.Red), totalwidth / 2 - 10, totalheight - 15);
            //水位时间
            g.DrawString("时间", new Font(new FontFamily("宋体"), 10), new SolidBrush(Color.Red), totalwidth / 2 - 10, oY3 + 20);

            //图例
            g.DrawLine(new Pen(new SolidBrush(GetColor(cbColor.SelectedItem.ToString())  )), new PointF(oX1 - 80, oY2 + 10), new PointF(oX1 - 40, oY2 + 10));
            g.DrawString("相位", new Font(new FontFamily("宋体"), 10), new SolidBrush(Color.Black), oX1 - 40, oY2 + 5);

            g.DrawLine(new Pen(new SolidBrush(GetColor(cbColor2.SelectedItem.ToString()) )), new PointF(oX1 - 80, oY2 + 30), new PointF(oX1 - 40, oY2 + 30));
            g.DrawString("振幅", new Font(new FontFamily("宋体"), 10), new SolidBrush(Color.Black), oX1 - 40, oY2 + 25);

            g.DrawLine(new Pen(new SolidBrush(GetColor(cbColorWater.SelectedItem.ToString()))), new PointF(oX1 - 80, oY4 + 30), new PointF(oX1 - 40, oY4 + 30));
            g.DrawString("水位", new Font(new FontFamily("宋体"), 10), new SolidBrush(Color.Black), oX1 - 40, oY4 + 25);
            


            //绘制振幅、相位X轴刻度                     
            float d = oX0;
            for (int i = 0; i <= list.Count; i++)
            {
                if (splitenumber > 0 && i % splitenumber == 0)
                {
                    //标注刻度
                    g.DrawLine(new Pen(new SolidBrush(Color.Black)), new PointF(d, oY0), new PointF(d, oY0 + 5)); //高度为5
                    StringFormat sf = new StringFormat();
                    sf.FormatFlags = StringFormatFlags.DirectionVertical;
                    if (i < list.Count)
                        g.DrawString(list[i].DataTime.Substring(0, 8), new Font(new FontFamily("宋体"), 10), new SolidBrush(Color.Black), d - 7, (oY0 + 6), sf);
                }
                else  if (splitenumber == 0)
                {
                    g.DrawLine(new Pen(new SolidBrush(Color.Black)), new PointF(d, oY0), new PointF(d, oY0 + 5)); //高度为5
                    StringFormat sf = new StringFormat();
                    sf.FormatFlags = StringFormatFlags.DirectionVertical;
                    if (i < list.Count)
                        g.DrawString(list[i].DataTime.Substring(0, 8), new Font(new FontFamily("宋体"), 10), new SolidBrush(Color.Black), d - 7, (oY0 + 6), sf);
            
                }
                //g.DrawString(list[i].DataName, new Font("宋体", 10), new SolidBrush(Color.Black), (int)d, oY0);
                d += splitX;
            }

            

            //相位,振幅总高度和间隔
            float h1 = oY0 - oY2;
            float splitY1 = (float)((max.Value - min.Value) / h1); //相位
            float splitY2 = (float)((max2.Value - min2.Value) / h1);//振幅            
            //float splitY3 = (float)((maxWater.Value - minWater.Value) / h3); //水位
            d = 0;
            //绘制相位坐标轴
            for (int i = 0; i <= tnPhase ; i++)
            {
              // d += splitY1;
                float x2 = oX0;
                float y2 =  (oY0 - (i * h1 / tnPhase)); //*splitY1
                float x1 = oX0 - 5;
                float y1 = y2;

                g.DrawLine(new Pen(new SolidBrush(Color.Black)), new PointF(x1, y1), new PointF(x2, y2));
                string str = (min + (i * (max - min) / tnPhase)).Value.ToString("0.00");
                g.DrawString(str, new Font(new FontFamily("宋体"), 10), new SolidBrush(Color.Black), x1-40, y1 - 5);
                
            }
            //绘制振幅坐标轴
            for (int i = 0; i <= tnAmp; i++)
            {
                // d += splitY1;
                float x1 = oX1;
                float y1 =  (oY0 - (i * h1 / tnAmp)); //*splitY1
                float x2 = oX1 + 5;
                float y2 = y1;

                g.DrawLine(new Pen(new SolidBrush(Color.Black)), new PointF(x1, y1), new PointF(x2, y2));
                string str = (min2 + (i * (max2 - min2) / tnAmp)).Value.ToString("0.00");
                g.DrawString(str, new Font(new FontFamily("宋体"), 10), new SolidBrush(Color.Black), x2, y2 - 5);
            }
            
            //绘制左侧水位坐标轴刻度
            for (int i = 0; i <= tnWater; i++)
            {

                float x1 = oX0 - 5;
                float y1 = (oY3 - (i * waterheight / tnWater));
                float x2 = oX0;
                float y2 = y1; //*splitY1

                //或左侧刻度
                g.DrawLine(new Pen(new SolidBrush(Color.Black)), new PointF(x1, y1), new PointF(x2, y2));

                //float x3 = oX1;
                //float y3 = (oY3 - (i * waterheight / tnWater)); //*splitY1
                //float x4 = oX1 + 5;
                //float y4 = y3;
                //g.DrawLine(new Pen(new SolidBrush(Color.Black)), new PointF(x3, y3), new PointF(x4, y4));
                // yy = (float)(oY3 - (water - minWater) * waterheight / (maxWater - minWater));
                string waterlevel = (minWater + (i * (maxWater - minWater) / tnWater)).Value.ToString("0.0");
                //绘制刻度值
                g.DrawString(waterlevel, new Font(new FontFamily("宋体"), 10), new SolidBrush(Color.Black), x1 - 40, y1 - 5);
                //g.DrawString(waterlevel, new Font(new FontFamily("宋体"), 8), new SolidBrush(Color.Black), x4, y4-5);
                

            }
            
           
            //处理振幅、相位坐标点，准备绘制数据
            for (int i = 0; i < list.Count; i++)
            {

                string t = list[i].DataTime;
                double? phase = list[i].Phase;
                double? amp = list[i].Amplitude;

               
                float xx =  (oX0 + splitX * i);
                float yy = oY0;
                //相位
                if (phase.Value > 90000)
                {                 
                    //忽略该值,现在置为0
                    PointF p = new PointF(xx, yy);
                    phasePoints[i] = p;
                }
                else
                {
                    yy = (float)(oY0 - (phase - min) * h1 / (max - min));
                    PointF p = new PointF(xx, yy);
                    phasePoints[i] = p;
                }
                //振幅
                if (amp.Value > 90000)
                {
                    //忽略该值,现在置为0
                    PointF p = new PointF(xx, yy);
                    ampPoints[i] = p;
                }
                else
                {
                    yy =  (float)(oY0 - (amp - min2) * h1 / (max2 - min2));
                    PointF p = new PointF(xx, yy);
                    ampPoints[i] = p;
                }
            }

            //绘制水位X轴刻度
            float splitWaterX = (float)(w*1.0 / listWater.Count);
            d = oX0;
            int month =0;
            for (int i = 0; i < listWater.Count; i++)
            {
                if (listWater[i].Time.EndsWith("0100"))
                {
                    //标注刻度
                    
                    StringFormat sf = new StringFormat();
                    //sf.FormatFlags = StringFormatFlags.DirectionVertical;
                    if (month % 6 == 0)
                    {
                        g.DrawLine(new Pen(new SolidBrush(Color.Red)), new PointF(d, oY3), new PointF(d, oY3 + 8)); //高度为5
                        //半年标注一个刻度
                        g.DrawString(listWater[i].Time.Substring(0, 8), new Font(new FontFamily("宋体"), 10), new SolidBrush(Color.Black), d - 12, (oY3 + 6), sf);
                    }
                    else
                    {
                        g.DrawLine(new Pen(new SolidBrush(Color.Black)), new PointF(d, oY3), new PointF(d, oY3 + 5)); //高度为5
                    }
                    month++;
                    d += splitWaterX;
                }
                else
                {
                    d += splitWaterX;
                }
               
            }
            //准备水位数据
            for (int i = 0; i < listWater.Count; i++)
            {
                float xx = (oX0 + splitWaterX * i);
                float yy = oY0;

                double? water = listWater[i].WaterLevel;
                //水位
                if (water == null || water.Value > 90000)
                {
                    //忽略该值,现在置为0
                    PointF p = new PointF(xx, oY3);
                    waterPoints[i] = p;
                }
                else
                {
                    yy = (float)(oY3 - (water - minWater) * waterheight / (maxWater - minWater));
                    PointF p = new PointF(xx, yy);
                    waterPoints[i] = p;
                }
            }

            //绘制相位曲线
            g.DrawLines(new Pen(new SolidBrush(GetColor(cbColor.SelectedItem.ToString()))), phasePoints);//相位
            //绘制振幅曲线
            g.DrawLines(new Pen(new SolidBrush(GetColor(cbColor2.SelectedItem.ToString()))), ampPoints);//振幅
            //绘制水位曲线
            g.DrawLines(new Pen(new SolidBrush(GetColor(cbColorWater.SelectedItem.ToString()))), waterPoints); //水位


            //绘制地震信息           
            //int ey0 = 25;
            //int ey1 = 50;

            for (int i = 0; i < listWater.Count; i++)
            {
                float ex = (oX0 + splitX * i);
                //DrawEathquakeInfo(new PointF(ex, ey0), new PointF(ex, ey1), listWater[i], waterPoints[i], g);
                DrawEathquakeInfo(listWater[i], waterPoints[i], g);
            }
         


        }

        private void DrawEathquakeInfo(WaterEarthQuake e, PointF p ,Graphics g)
        {
            //画箭头
            if (!string.IsNullOrEmpty(e.Ms))
            {
                PointF a = new PointF(p.X, p.Y - 15);
                PointF b = p;
                g.DrawLine(new Pen(new SolidBrush(Color.Black), 2), a, b);
                PointF c = new PointF(b.X - 5, b.Y - 8);
                PointF d = new PointF(b.X + 5, b.Y - 8);
                g.FillPolygon(new SolidBrush(Color.Black), new PointF[] { b, c, d });
                g.DrawString("Ms" + e.Ms + " " + e.Location, new Font(new FontFamily("宋体"), 8), new SolidBrush(Color.Black), a.X + 5, a.Y - 5);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ofdExcel.Title = "选择绘图Excel文件";
            ofdExcel.Filter = "Excel文件（*.xlsx,*.xlsx）|*.xls;*.xlsx";
            if (ofdExcel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                dataExcelfile = ofdExcel.FileName;
                txtExcel.Text = dataExcelfile;
            }
        }


        private Color GetColor(string color)
        {
            if (color == "黑色")
                return Color.Black;
            else if (color == "红色")
                return Color.Red;
            else if (color == "蓝色")
                return Color.Navy;
            else if (color == "绿色")
                return Color.Green;
            return Color.Yellow;
        }

        /// <summary>
        /// 选择地震文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEarthquake_Click(object sender, EventArgs e)
        {
            if (dataExcelfile == "")
            {
                MessageBox.Show("请先选择绘图数据Excel文件，地震信息数据对每个绘图数据Excel文件仅需要执行一次");
                return;
            }


            ofdEarthquake.Filter = "Excel文件（*.xls;*.xlsx）|*.xls;*.xlsx";
            ofdEarthquake.Title = "地震信息Excel文件";
            if (ofdEarthquake.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                earthquakeExcelfile = ofdEarthquake.FileName;
                txtEarthquake.Text = earthquakeExcelfile;

                //读取地震信息，并排序
                earthquakelist = LoadEarthquakeData(earthquakeExcelfile);
                if (earthquakelist.Count == 0)
                {
                    MessageBox.Show("地震信息数据Excel文件,数据有误，必须遵照规定的数据格式!");
                    return;
                }
                Comparison<WaterEarthQuake> com = new Comparison<WaterEarthQuake>(CompareEarthquakeTime);
                earthquakelist.Sort(com);


                MessageBox.Show("地震信息数据处理完毕，请重新绘图！");

            }
             

        }


        /// <summary>
        /// 读取地震信息，并排序
        /// </summary>
        /// <returns></returns>
        private List<WaterEarthQuake> LoadEarthquakeData(string excel)
        {
            //System.Collections.Generic.SortedList<string,EarthQuake> earthquakelist =new SortedList<string,EarthQuake>();
            List<WaterEarthQuake> earthquakelist = new List<WaterEarthQuake>();
                    
            //地震excel            
            //FarPoint.Win.Spread.FpSpread earthquake = new FarPoint.Win.Spread.FpSpread();
            //bool b = earthquake.OpenExcel(excel);
            //if (!b)
            //{
            //    MessageBox.Show("读取地震信息Excel数据文件失败！");
            //    return earthquakelist;
            //}
            //FarPoint.Win.Spread.SheetView earthquakesheet = earthquake.Sheets[0];

            DataSet ds = ExcelDbHelper.ExecuteSelectSql(excel, "select * from   [Sheet1$]");
            //0           1      2   3     4         5         6        7      8     9            10
            //日期	     年	    月	日	 时间	   震级5	纬度6	经度7	深度8	参考位置	参考地点10
            //19900123	1990	1	23	15:40:53	5.2	   25.17	96.4	33	    缅甸	     缅甸
            //(string time, double? water, string ms, string longitude, string latitude, string depth, string location)

           // int count1 =1;
           // int count2 =1;
            for (int count1 = 1; count1 < ds.Tables[0].Rows.Count; count1++ )
            {
                //精确到小时
                //取日期
                string earthquaketime = ds.Tables[0].Rows[count1][0].ToString();
                if (earthquaketime == "")
                {
                    //已处理完
                    break;
                }
                //取小时值
                string time = DateTime.Parse(ds.Tables[0].Rows[count1][4].ToString()).Hour.ToString("00");
                    //int.Parse(ds.Tables[0].Rows[count1][4].ToString().Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[0]).ToString("00");

                earthquakelist.Add(new WaterEarthQuake(earthquaketime + time,
                    double.Parse(ds.Tables[0].Rows[count1][3].ToString()),
                    ds.Tables[0].Rows[count1][5].ToString(),
                    ds.Tables[0].Rows[count1][7].ToString(),
                    ds.Tables[0].Rows[count1][6].ToString(),
                    ds.Tables[0].Rows[count1][8].ToString(),
                    ds.Tables[0].Rows[count1][10].ToString()
                    ));

               
            }
            return earthquakelist;
        }

        private void MergeData(IList<WaterEarthQuake> earthquakelist, IList<WaterEarthQuake> water)
        {
            if (earthquakelist == null || water == null || earthquakelist.Count == 0 || water.Count == 0)
                return;
             int n = 0;
            for (int m = 0; m < earthquakelist.Count; m++)
            {
                string t1 = earthquakelist[m].Time;
                for (int i = n; i < water.Count; i++)
                {
                    string t2 = water[i].Time;
                    int ret =CompareDateTime(t1, t2);
                    if (ret != 0)
                    {
                        continue;
                    }                   
                    else //==
                    {
                        water[i].Ms = earthquakelist[m].Ms;
                        water[i].Latitude = earthquakelist[m].Latitude;
                        water[i].Longitude = earthquakelist[m].Longitude;
                        water[i].Depth = earthquakelist[m].Depth;
                        n++;
                    }
                }
                if (n == water.Count - 1)
                {
                    break;//不需要再处理后面的震级数据了，因为不在绘图的时间范围内
                }

            }

        }

        private int CompareEarthquakeTime(WaterEarthQuake e1, WaterEarthQuake e2)
        {
           // int result;
            string t1 = e1.Time;
            string t2 = e2.Time; 
            return CompareDateTime(t1,t2);
        }

        private int CompareDateTime(string t1,string t2)
        {
            //忽略时分秒
            DateTime d1 = new DateTime(int.Parse(t1.Substring(0, 4)), int.Parse(t1.Substring(4, 2)),
               int.Parse(t1.Substring(6, 2)), int.Parse(t1.Substring(8, 2)), 0, 0); //int.Parse(t1.Substring(8, 2))
            DateTime d2 = new DateTime(int.Parse(t2.Substring(0, 4)), int.Parse(t2.Substring(4, 2)),
                int.Parse(t2.Substring(6, 2)), int.Parse(t2.Substring(8, 2)), 0, 0);
            return d1.CompareTo(d2);
        }

        /// <summary>
        /// 垂直线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVertical_Click(object sender, EventArgs e)
        {
            bVertialFlag = !bVertialFlag;
            if (bVertialFlag)
            {
                btnVertical.ForeColor = Color.Red;
            }
            else
            {
                btnVertical.ForeColor = Color.Black;
            }
        }

        private void pdraw_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(bmp, 0, 0);
            
        }

        private void MyFormPhaseChart_SizeChanged(object sender, EventArgs e)
        {
            if (dataExcelfile != "")
            {
                btnDraw_Click(sender, e);
            }
            verticalLine = new Color[pdraw.Height];
            horozionLine = new Color[pdraw.Width];

            oldX = -1;
            oldY = -1;
            oldPoint = new Point(-1, -1);

            pdraw.Invalidate();

        }

        private void pdraw_MouseEnter(object sender, EventArgs e)
        {
             
        }

        private int oldX = -1;
        private int oldY = -1;
        private Point oldPoint = new Point(-1, -1);
        private void pdraw_MouseMove(object sender, MouseEventArgs e)
        {
             

            //绘制垂直线 和水平线
            if (bHorizionFlag && bVertialFlag)
            {
                Graphics g = Graphics.FromImage(bmp);
                if (oldX != -1)
                {
                    
                    for (int i = 0; i < pdraw.Height; i++)
                    {
                        
                        bmp.SetPixel(oldX, i, verticalLine[i]);
                    }
                    pdraw.Invalidate(new Rectangle(oldX, 0, 1, pdraw.Height));
                }
                if (oldY != -1)
                {
                    

                    for (int i = 0; i < pdraw.Width; i++)
                    {
                        bmp.SetPixel(i, oldY, horozionLine[i]);
                    }
                    pdraw.Invalidate(new Rectangle(0, oldY, pdraw.Width, 1));
                }
                if (oldPoint.X != -1)
                {
                    bmp.SetPixel(oldPoint.X,oldPoint.Y, oldPointColor);
                    pdraw.Invalidate(new Rectangle(oldPoint.X, oldPoint.Y, 1, 1));
                }


                int x = e.X;
                int y = e.Y;
                //保存原有值Y
                for (int i = 0; i < pdraw.Height; i++)
                {
                    verticalLine[i] = bmp.GetPixel(x, i);
                }
                //保存原有值X
                for (int i = 0; i < pdraw.Width; i++)
                {
                    horozionLine[i] = bmp.GetPixel(i, y);
                }
                oldPointColor = bmp.GetPixel(e.X, e.Y);
                oldX = x;
                oldY = y;
                oldPoint = e.Location;

                //绘制新值
                Point a = new Point(0, y);
                Point b = new Point(pdraw.Width - 1, y);
                g.DrawLine(new Pen(new SolidBrush(Color.Black), 1), a, b);
                
                //绘制新值
                Point c = new Point(x, 0);
                Point d = new Point(x, pdraw.Height - 1);
                g.DrawLine(new Pen(new SolidBrush(Color.Black), 1), c, d);


                g.Dispose();
                 

            }
            // 仅绘制垂直线
            else if (bVertialFlag )             
            {
                //Graphics g = pdraw.CreateGraphics();
                // pdraw.Invalidate();
                Graphics g = Graphics.FromImage(bmp);
                if (oldX != -1)
                {
                    
                    for (int i = 0; i < pdraw.Height; i++)
                    {
                        bmp.SetPixel(oldX, i, verticalLine[i]);
                    }
                    pdraw.Invalidate(new Rectangle(oldX, 0, 1, pdraw.Height));
                }

                int x = e.X;
                int y = e.Y;

                //保存原有值
                for (int i = 0; i < pdraw.Height; i++)
                {
                    verticalLine[i] = bmp.GetPixel(x, i);
                }
                oldX = x;


                //会新值
                Point a = new Point(x, 0);
                Point b = new Point(x, pdraw.Height-1);
                g.DrawLine(new Pen(new SolidBrush(Color.Black), 1), a, b);
                g.Dispose();
            }
            // 仅绘制水平线
            else if (bHorizionFlag)            
            {
                //Graphics g = pdraw.CreateGraphics();
                // pdraw.Invalidate();
                Graphics g = Graphics.FromImage(bmp);
                if (oldY != -1)
                {
                    
                    for (int i = 0; i < pdraw.Width; i++)
                    {
                        bmp.SetPixel(i, oldY, horozionLine[i]);
                    }
                    pdraw.Invalidate(new Rectangle(0, oldY, pdraw.Width, 1));
                }

                int x = e.X;
                int y = e.Y;

                //保存原有值
                for (int i = 0; i < pdraw.Width; i++)
                {
                    horozionLine[i] = bmp.GetPixel(i, y);
                }
                oldY = y;


                //会新值
                Point a = new Point(0, y);
                Point b = new Point(pdraw.Width-1,y);
                g.DrawLine(new Pen(new SolidBrush(Color.Black), 1), a, b);
                g.Dispose();
            }

            

        }
        /// <summary>
        /// 设置水平线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHorizon_Click(object sender, EventArgs e)
        {
            bHorizionFlag = !bHorizionFlag;
            if (bHorizionFlag)
            {
                btnHorizon.ForeColor = Color.Red;
            }
            else
            {
                btnHorizon.ForeColor = Color.Black;
            }
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            //earthquakeExcelfile  dataExcelfile
            if (string.IsNullOrEmpty(earthquakeExcelfile))
            {
                MessageBox.Show("请先选择地震目录Excel文件！");
                return;
            }

            DataSet dsearthquake = null;
            try
            {
                string sqlWater = "select * from [Sheet1$]";
                dsearthquake = ExcelDbHelper.ExecuteSelectSql(dataExcelfile, sqlWater);
            }
            catch (Exception ex)
            {
                MessageBox.Show("地震信息Excel文件中的地震信息务必放在第一个Sheet中，且名称为“Sheet1”！");
                return;
            }

            //FarPoint.Win.Spread.FpSpread excel = new FarPoint.Win.Spread.FpSpread();
            //bool b = excel.OpenExcel(dataExcelfile);
            //if (!b)
            //{
            //    MessageBox.Show("读取Excel数据文件失败！");
            //    return;
            //}
            //以M2为例读取数据           

            //读取地震信息，并排序
            List<WaterEarthQuake> earthquakelist = LoadEarthquakeData(earthquakeExcelfile); 
            if (earthquakelist.Count == 0)
            {
                MessageBox.Show("地震信息数据Excel文件,数据有误，必须遵照规定的数据格式!");
                return;
            } 
            Comparison<WaterEarthQuake> com = new Comparison<WaterEarthQuake>(CompareEarthquakeTime);
            earthquakelist.Sort(com);

            

            //将地震信息合并到 最接近的 开始时间
            //MergeData(earthquakelist, list);
            MessageBox.Show("地震信息数据处理完毕，请重新绘图！");

            //保存Excel
            //try
            //{
            //    int jjj = 1;

            //    FarPoint.Win.Spread.SheetView sv = excel.Sheets[1];
            //    for (int j = 0; j < earthquakelist.Count; j++)
            //    {
            //        //excel SHUJU
            //        for (; jjj < sv.Rows.Count; )
            //        {
            //            string t = sv.Cells[jjj, 0].Text;
            //            string ms = sv.Cells[jjj, 4].Text;
            //            if (string.IsNullOrEmpty(t))
            //            {
            //                break;
            //            }
            //            int ret = CompareDateTime(earthquakelist[j].Time, t);
            //            if (ret == 0)
            //            {
            //                for (int i = 1; i < excel.Sheets.Count; i++)
            //                {

            //                    //如果地震的震级大于现有的震级，就替换
            //                    bool bGreater = true;
            //                    if (!string.IsNullOrEmpty(ms))
            //                    {
            //                        if (double.Parse(ms) >= double.Parse(earthquakelist[j].Ms))
            //                            bGreater = false;

            //                    }
            //                    if (bGreater)
            //                    {
            //                        excel.Sheets[i].Cells[jjj, 4].Text = earthquakelist[j].Ms;
            //                        excel.Sheets[i].Cells[jjj, 5].Text = earthquakelist[j].Latitude;
            //                        excel.Sheets[i].Cells[jjj, 6].Text = earthquakelist[j].Longitude;
            //                        excel.Sheets[i].Cells[jjj, 7].Text = earthquakelist[j].Depth;
            //                        excel.Sheets[i].Cells[jjj, 8].Text = earthquakelist[j].Location;
            //                    }
            //                }
            //                //jjj++;
            //                break;
            //            }
            //            else if (ret > 0)
            //            {
            //                jjj++;
            //                continue;
            //            }
            //            else if (ret < 0)
            //            {
            //                break;
            //            }

            //        }
            //    }

            //    excel.SaveExcel(dataExcelfile);
            //    MessageBox.Show("地震信息数据处理完毕！");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("合并时出现错误，请检查格式是否正确！");
            //}
            
            
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSavePic_Click(object sender, EventArgs e)
        {
            if (bmp != null)
            {
                SaveFileDialog f = new SaveFileDialog();
                f.Filter="JPEG图片文件(*.jpg)|";
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string fname = f.FileName.ToLower().EndsWith(".jpg") ? f.FileName : f.FileName + ".jpg";
                    bmp.Save(fname, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }


    }



    public class BaytapChartData
    {
        string dataTime = ""; //时间
        public string DataTime
        {
            get { return dataTime; }
            set { dataTime = value; }
        }
        //相位
        double? phase = 0;
        public double? Phase
        {
            get { return phase; }
            set { phase = value; }
        }
        //振幅
        double? amplitude = 0;
        public double? Amplitude
        {
            get { return amplitude; }
            set { amplitude = value; }
        }


        public BaytapChartData()
        {
        }
        public BaytapChartData(string dataTime, double? phase, double? amplitude)
        {
            this.dataTime = dataTime;
            this.phase = phase;
            this.amplitude = amplitude;
        }
        


    }

     

    public class WaterEarthQuake 
    {
        public WaterEarthQuake(string time, double? water, string ms, string longitude, string latitude, string depth, string location)
        {
            this.time = time;
            this.longitude = longitude;
            this.latitude = latitude;
            this.ms = ms;
            this.depth = depth;
            this.location = location;
            this.waterLevel = water;
        }

        //水位
        double? waterLevel;
        public double? WaterLevel
        {
            get { return waterLevel; }
            set { waterLevel = value; }
        }
        
        private string time; //发震时间
        public string Time
        {
          get { return time; }
          set { time = value; }
        }

        private string ms;//震级
        public string Ms
        {
          get { return ms; }
          set { ms = value; }
        }
        private string longitude;//经度
        public string Longitude
        {
          get { return longitude; }
          set { longitude = value; }
        }
        
        private string latitude;// 纬度
        public string Latitude
        {
          get { return latitude; }
          set { latitude = value; }
        }
        
        private string depth; //深度
        public string Depth
        {
          get { return depth; }
          set { depth = value; }
        }
        
        private string location; //发震位置
        public string Location
        {
          get { return location; }
          set { location = value; }
        }
    }





}
