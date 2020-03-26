using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

//using Microsoft.Office.Interop.Excel;


namespace TidalException
{
    public partial class FormMain : Form
    {
        protected string InputO5 = ""; //输入文件05
        protected string Input12 = "";//输入文件12
        protected string Input14 = "";//输入文件14
        protected string Baytap = "";//Baytap文件

        protected string DataFile = "";//选择的数据文件

       // private int cpus = 1;  //cpu核数
        private int nThread = 1; //并发线程数
        private int nWaterLineLen = 0; //水位文件中，一行数据的字符长度
        private int nYearsOnce = 10; //一个线程一次处理的水位数据，默认10年

        protected long TotalDataRecord = 0;//数据记录个数
        private string CurrentDir = AppDomain.CurrentDomain.BaseDirectory;

        //private string OutputDataPath = ""; //保存数据路径(总目录)
       // private string OutputDirPathForThis = ""; //保存数据路径(本次文件输出路径)
       // private string OutputIni = ""; //保存文件的输出路径
        private string OutputDataExcelFile = ""; //保存数据路径(总目录)
        private string OutputPath = ""; //输出文件路径

        private string out06From;
        private string out16From;
        private string out06To;
        private string out16To;

        //Xlsx 文件 这种语法使用 .Xlsx 文件链接 Excel 2007，这是一个 Office Open XML 的格式文件，这种格式不支持宏
        //Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\myFolder\myExcel2007file.xlsx;Extended Properties="Excel 12.0 Xml;HDR=YES";

        //excel2003, Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}; Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'
        //"Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0;HDR=YES';data source=" + ExcelFilePath;
        private string ConnectStrFormat = "Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0;HDR=YES;';Data Source={0}";
        private string ConnectStr = "";



        public FormMain()
        {
            InitializeComponent();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            tsbTime.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒");
            tsbStatus.Text = "";            
            
           
            InputO5 = CurrentDir + "\\input05_t.dat";
            Input12 = CurrentDir + "\\input12_t.dat";
            Input14 = CurrentDir + "\\input14_t.dat";
            Baytap = CurrentDir + "\\baytap.exe";

            //cpus =  CpuUtil.GetCpuCores();
            //if (cpus <=0)
            //{
            //    cpus = 1;
            //}
            //else if (cpus > 8)
            //{
            //    cpus = 8;//最多4个线程
            //}
        }

        /// <summary>
        /// 执行数据处理生成输出数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (DataFile.Length == 0)
            {
                MessageBox.Show("没有选择数据文件或数据文件不存在，请选择数据文件！");
                return;
            }         
            if (OutputPath.Length == 0)
            {
                MessageBox.Show("请选择输出结果保存路径！");
                return;
            }
          
            //删除原有输出文件,每次执行都会生成输出文件
            out06From = CurrentDir + "\\output06.dat";
            out16From = CurrentDir + "\\output16.dat";


            //合并后输出结果,如果存在先删除            
            //out06To = OutputDirPathForThis + "output06.dat";
            //out16To = OutputDirPathForThis + "output16.dat";
            Thread t = new Thread(ExecuteTidal);
            t.Start();
            //ExecuteTidal();
           
            //try
            //{
               
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("执行出现异常!" + ex.ToString());
            //    return;
            //}
        }
        /// <summary>
        ///  //处理output16.out,替换行号
        /// </summary>
        private void DealOutput16(string outfile, string outnewfile, string startTime)
        {

            if (File.Exists(outfile))
            {
                StreamReader sr = new StreamReader(outfile, Encoding.Default);    
                StreamWriter sw = new StreamWriter(outnewfile, true, Encoding.Default);
                string line = "";
                int y = int.Parse(startTime.Substring(0, 4));
                int month = int.Parse(startTime.Substring(4, 2));
                int d = int.Parse(startTime.Substring(6, 2));
                int h = int.Parse(startTime.Substring(8, 2));
                DateTime startDate = new DateTime(y, month, d, h, 0, 0);
                int m = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    //6位数字，转换为2001090400
                    //跳过前3行
                    if (m < 3)
                    {
                        sw.WriteLine(line);
                    }
                    else
                    {
                        string s = line.Substring(0, 6);
                        line = line.Replace(s, startDate.ToString("yyyyMMddHH"));
                        sw.WriteLine(line);
                        startDate = startDate.AddHours(1);
                    }
                    m++;
                }
                sr.Close();
                sw.Flush();
                sw.Close();
            }

        }
               

     
        /// <summary>
        /// 获取一个月有多少个小时
        /// </summary>
        /// <param name="strDate"></param>
        /// <returns></returns>
        public int GetMonthHours(string strDate)
        {
            int year = int.Parse(strDate.Substring(0, 4));
            int month = int.Parse(strDate.Substring(4, 2));
            int day = 0;
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                day = 31;
            }
            else if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                day = 30;
            }
            else if (month == 2)
            {
                if (year % 4 == 0 && year % 100 != 0 || year % 100 == 0 && year % 400 == 0)
                {
                    day = 29;
                }
                else
                {
                    day = 28;
                }
            }
            else
            {
                MessageBox.Show("错误的时间数据：" + strDate);
                return -1;
            }
            return day * 24;
        }

        
        /// <summary>
        /// 设置参数,50000个数据的限制，循环100次的限制
        /// </summary>
        public void ExecuteTidal()
        {

            try
            {
                tsbStatus.Text = "正在计算，请等待....";
                //开始时间
                string strStartTime = txtStartTime.Text.Trim();
                string strEndTime = txtEndTime.Text.Trim();

                string year = strStartTime.Substring(0, 4);
                string month = strStartTime.Substring(4, 2);
                string day = strStartTime.Substring(6, 2);
                string hour = double.Parse(strStartTime.Substring(8, 2)).ToString("0.0");

                //校验数据，由结束时间-开始时间，每天24个数据
                DateTime d1 = DateTime.Now;
                DateTime d2 = DateTime.Now;
                TimeSpan d3 = new TimeSpan();
                try
                {
                    d1 = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day), int.Parse(txtStartTime.Text.Substring(8, 2)), 0, 0);
                    d2 = new DateTime(int.Parse(strEndTime.Substring(0, 4)), int.Parse(strEndTime.Substring(4, 2)),
                        int.Parse(strEndTime.Substring(6, 2)), int.Parse(strEndTime.Substring(8, 2)), 0, 0);
                    d3 = d2.Subtract(d1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("开始时间或结束时间输入有误");
                    return;
                }
                //开始时间
                DateTime startTime = d1;
                //根据时间，计算总的记录数
                long lRecordsNumber = (long)d3.Days * 24 + d3.Hours + 1;
                tsbStatus.Text = "分析数据，共" + lRecordsNumber + "条";
                //初始化excel文件信息,保存水位数据
                // FarPoint.Win.Spread.FpSpread fpExcel = new FarPoint.Win.Spread.FpSpread();
                // InitExcel(ref fpExcel);


                if (File.Exists(OutputDataExcelFile))
                {
                    File.Delete(OutputDataExcelFile);
                }
                File.Copy(CurrentDir + "modelV2.xlsx", OutputDataExcelFile);


                //Baytap程序最多循环100次,单次处理的数据数《99999,大约11年水位数据
                //计算需要开启几个线程同时运行,默认10年一个线程，如果少于10年数据，则仅开启一个线程
                //double thread = lRecordsNumber / 365 / 24 / nYearsOnce;
                //if (thread <= 1.0)
                //{
                //    nThread = 1;
                //}
                //else
                //{
                //    nThread = (int)thread;
                //}

                StringBuilder sb12 = new StringBuilder();
                StringBuilder sb14 = new StringBuilder();

                // string input05_1="";
                //准备好input05 和input12，input14文件
                //仅考虑年份问题，
                //读取全部数据文件
                StreamReader sr = new StreamReader(DataFile, Encoding.Default);
                tsbStatus.Text = "处理水位数据，保存至Excel中";
                string line = "";
                int pos = 0;
                List<string> sqls = new List<string>();
                while ((line = sr.ReadLine()) != null)
                {
                    string[] a = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (a.Length == 2)
                    {
                        //时间
                        //  fpExcel.Sheets["WaterLevel"].Cells[pos, 0].Text = a[0].Trim();
                        //设置水位信息
                        double level = double.Parse(a[1].Trim());
                        // fpExcel.Sheets["WaterLevel"].Cells[pos, 1].Text = level.ToString(".000");

                        sb12.Append(level.ToString(".000") + " \r\n");
                        string sql = "insert into [WaterLevel$](时间,水位) values('{0}','{1}')";
                        sql = string.Format(sql, a[0].Trim(), level.ToString(".000"));
                        sqls.Add(sql);
                    }
                    else if (a.Length == 3)
                    {
                        //时间
                        //fpExcel.Sheets["WaterLevel"].Cells[pos, 0].Text = a[0].Trim();
                        //设置水位信息
                        double level = double.Parse(a[1].Trim());
                        // fpExcel.Sheets["WaterLevel"].Cells[pos, 1].Text = level.ToString(".000");
                        //气压数据
                        double pressure = double.Parse(a[2].Trim());
                        //fpExcel.Sheets["WaterLevel"].Cells[pos, 2].Text = pressure.ToString(".000");

                        string sql = "insert into [WaterLevel$](时间,水位,气压) values('{0}','{1}','{2}')";
                        sql = string.Format(sql, a[0].Trim(), level.ToString(".000"), pressure.ToString(".000"));
                        sqls.Add(sql);

                        sb12.Append(level.ToString(".000") + " \r\n");
                        sb14.Append(pressure.ToString(".000") + " \r\n");
                    }
                    pos++;
                    // fpExcel.Sheets["WaterLevel"].RowCount = pos ;
                }
                sr.Close();
                //保存到excel
                ExcelDbHelper.ExecuteNoQuerySql(OutputDataExcelFile, sqls);


                //处理的开始时间     

                if (sb12.Length == 0)
                {
                    MessageBox.Show("数据处理错误，没有找到水位数据");
                    return;
                }
                if (txtIaug.Text == "1" && sb14.Length == 0)
                {
                    MessageBox.Show("数据处理错误，没有找到气压数据");
                    return;
                }

                int realcount = pos;


                //首先清除input05,input12,input14文件
                string f = CurrentDir + "\\input05.dat";
                File.Delete(f);
                f = CurrentDir + "\\input12.dat";
                File.Delete(f);
                f = CurrentDir + "\\input14.dat";
                File.Delete(f);
                f = CurrentDir + "\\output06.dat";
                File.Delete(f);
                f = CurrentDir + "\\output16.dat";
                File.Delete(f);

                tsbStatus.Text = "准备input05.data和input12.data";
                //读取numOnce条记录，然后生成input05，input12，input14文件,返回最后一条数据的时间
                //行数 1
                //string data = LoadTemplateFile(DataFile);
                //int recordcount=data.Split(new char[]{'\r'}).Length -1; //去掉行头
                //===========================input 05 start================
                string t05 = LoadTemplateFile(InputO5);

                string starttime = txtStartTime.Text;
                // string monthpath = OutputDirPathForThis + strBeginTime.Substring(0, 6);

                t05 = string.Format(t05, txtKind.Text, txtSpan.Text, txtShift.Text, txtDmin.Text, txtLpout.Text, txtFilout.Text,
                    txtprepro.Text, txtIaug.Text, txtLagp.Text, txtTimesys.Text, txtMaxjmp.Text,
                    GetStrWithEmpty(starttime.Substring(0, 4), 5), GetStrWithEmpty(starttime.Substring(4, 2), 5),
                    GetStrWithEmpty(starttime.Substring(6, 2), 5), GetStrWithEmpty(starttime.Substring(8, 2), 5),
                    GetStrWithEmpty(realcount.ToString(), 5), GetStrWithEmpty(txtInterval.Text, 5), txtSigmal.Text);
                //保存配置文件
                SaveFile(t05, "input05.dat");
                //SaveFileToProjectRoot(t05, "input05.dat");
                //===========================input 05 end ===================


                //===========================input 12 start================   
                string s12 = sb12.ToString();
                s12 = s12.Substring(0, s12.Length - 2);//去掉最后一个空行
                string t12 = LoadTemplateFile(Input12);
                t12 = string.Format(t12, GetStrWithEmpty(txtLatitude.Text, 10), GetStrWithEmpty(txtLongitude.Text, 10),
                    GetStrWithEmpty(txtElevation.Text, 10),

                   GetStrWithEmpty(starttime.Substring(0, 4), 5), GetStrWithEmpty(starttime.Substring(4, 2), 5),
                    GetStrWithEmpty(starttime.Substring(6, 2), 5), GetStrWithEmpty(starttime.Substring(8, 2), 5),

                    GetStrWithEmpty(realcount.ToString(), 5), GetStrWithEmpty(txtInterval.Text, 5), s12);
                SaveFile(t12, "input12.dat");
                //SaveFileToProjectRoot(t12, "input12.dat");
                //===========================input 12 end================


                //===========================input 14 start================
                //提取数据
                if (sb14.Length > 0)
                {
                    string s14 = sb14.ToString();
                    s14 = s14.Substring(0, s14.Length - 2);//去掉最后一个空行
                    string t14 = LoadTemplateFile(Input14);
                    t14 = string.Format(t14, GetStrWithEmpty(txtLatitude.Text, 10), GetStrWithEmpty(txtLongitude.Text, 10), GetStrWithEmpty(txtElevation.Text, 10),

                          GetStrWithEmpty(starttime.Substring(0, 4), 5), GetStrWithEmpty(starttime.Substring(4, 2), 5),
                        GetStrWithEmpty(starttime.Substring(6, 2), 5), GetStrWithEmpty(starttime.Substring(8, 2), 5),

                        GetStrWithEmpty(realcount.ToString(), 5), GetStrWithEmpty(txtInterval.Text, 5), s14);
                    SaveFile(t14, "input14.dat");
                    //SaveFileToProjectRoot(t14, "input14.dat");
                }

                tsbStatus.Text = "执行baytap中.....";
                //===========================input 14 end================

                //执行baytap程序
                //1.需要执行带“/C”参数的“cmd.exe”命令，它表示执行完命令后立即退出控制台。
               // 2.设置startInfo.UseShellExecute = false;     //不使用系统外壳程序启动进程
               // 3.设置startInfo.CreateNoWindow = true;     //不创建窗口

                ProcessStartInfo psi = new ProcessStartInfo(CurrentDir + "baytap.exe", "");
                psi.CreateNoWindow = true;
                psi.WorkingDirectory = CurrentDir;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                psi.UseShellExecute = false;
                Process p = Process.Start(psi);
                string strRet = p.StandardOutput.ReadToEnd();
                String strerr = p.StandardError.ReadToEnd();
                if (String.IsNullOrEmpty(strerr) &&  strRet != null && strRet.IndexOf("Program terminated") > -1)
                {
                    tsbStatus.Text = "分析output06，并将结果保存至excel中....";
                    //执行成功，合并输出结果  
                    if (File.Exists(out06From))
                    {
                        File.Copy(out06From, OutputPath + "output06.dat", true);

                        DealOutpu06();

                    }

                    //合并output16文件，将编号变成日期
                    if (File.Exists(out16From))
                    {
                        //拷贝、备份
                        File.Copy(out16From, OutputPath + "output16.dat", true);
                        //DealOutput16(out16From);
                    }
                }
                else 
                {
                    MessageBox.Show("执行Baytap时产生错误！\r\n" + strerr);
                    Mylog.Log(strRet + "\r\n"+ strerr);
                    return;
                }
                tsbStatus.Text = "分析完成，请查看输出文件下的输出数据";
                MessageBox.Show("执行完毕!");

                //System.Diagnostics.Process.Start(DataDir+"\\baytap.exe"); 要重定向 IO 流，Process 对象必须将 UseShellExecute 属性设置为 False。
                //return true;
            }
            catch (Exception ex)
            {
                Mylog.Log(ex.StackTrace);                
                MessageBox.Show("程序执行过程中出现未知异常，请将发送日志文件给技术人员!");
                
            }
            
        }



        //private void InitExcel2(ref FarPoint.Win.Spread.FpSpread fpExcel)
        //{
        //    //if (File.Exists(OutputDataExcelFile))
        //    //{
        //    //    File.Delete(OutputDataExcelFile);
        //    //}
        //    //fpExcel.OpenExcel(AppDomain.CurrentDomain.BaseDirectory + "modelV2.xlsx");

        //    //fpExcel.SaveExcel(OutputDataExcelFile, FarPoint.Excel.ExcelSaveFlags.UseOOXMLFormat);//, FarPoint.Excel.ExcelSaveFlags.UseOOXMLFormat
        //    //fpExcel.OpenExcel(OutputDataExcelFile);
        //}

        /// <summary>
        /// 处理output06数据文件
        /// </summary>
        /// <param name="monthdir"></param>
        /// <param name="fpExcel"></param>
        private void DealOutpu06()
        {
            
            StreamReader sr1 = new StreamReader(out06From, Encoding.Default);
            string line = "";
            string sTime = "";
            int count = 0; //位置计数器
            List<string> sqls = new List<string>();
            while ((line = sr1.ReadLine()) != null)
            {
                if (line.IndexOf("PERIOD     ") > -1)
                {
                    string[] a = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (a.Length < 4)
                    {
                        MessageBox.Show("数据格式不正确(PERIOD)");
                        break;
                    }
                    sTime = a[1] + "-" + a[2] + "-" + a[3];
                    /*
                     * 
   PERIOD     2006  1 16   .0 - 2006  2 14 23.0

                                             AVAILABLE / BLOCK LEN.      720 /   720

   ANALYZED BY BAYTAP-G    VERSION 99-11-15
   POTENTIAL   : TAMURA, Y., 1987, BIM, 99. (WITH P4)
   CALCULATION : NATIONAL ASTRONOMICAL OBSERVATORY, MIZUSAWA                 


  GROUP          SYMBOL       FACTOR   (RMSE)       PHASE   (RMSE)   AMPLITUDE  (RMSE)
                                                (LOCAL, LAG:NEGATIVE)
    1  (  1-143 : Q1      )   .04555 (  .03378)   -80.506 ( 42.487)      .083 (  .062 )
    2  (144-201 : O1      )   .03843 (  .00775)   -33.488 ( 11.312)      .366 (  .074 )
    3  (202-249 : M1      )   .02197 (  .04101)  -138.924 (106.950)      .016 (  .031 )
    4  (250-305 : P1S1K1  )   .04668 (  .00468)   -73.248 (  5.365)      .626 (  .063 )
    5  (306-345 : J1      )   .01673 (  .04738)   -82.740 (160.001)      .013 (  .036 )
    6  (346-450 : OO1     )   .03116 (  .06184)  -102.104 (114.318)      .013 (  .025 )

    7  (451-549 : 2N2     )   .04913 (  .02686)   -28.678 ( 31.315)      .020 (  .011 )
    8  (550-599 : N2      )   .03575 (  .00676)   -38.233 ( 10.830)      .111 (  .021 )
    9  (600-655 : M2      )   .03389 (  .00139)   -48.627 (  2.352)      .549 (  .023 )
   10  (656-681 : L2      )   .00570 (  .02696)   -64.427 (271.291)      .003 (  .012 )
   11  (682-827 : S2K2    )   .05701 (  .00258)    10.066 (  2.596)      .430 (  .019 )

   12  (828-909 : M3      )   .08071 (  .06049)   144.532 ( 42.927)      .014 (  .010 )


                     * 
                      PERIOD     2006  1 16   .0 - 2006  2 14 23.0
  GROUP          SYMBOL       FACTOR   (RMSE)       PHASE   (RMSE)   AMPLITUDE  (RMSE)                    
                         1  (  1-143 : Q1      )   .11870 (  .04965)    11.175 ( 23.350)      .181 (  .076 )
    2  (144-201 : O1      )   .10266 (  .00977)     -.931 (  5.291)      .816 (  .078 )
    3  (202-249 : M1      )   .13428 (  .05088)    -2.973 ( 21.701)      .084 (  .032 )
    4  (250-305 : P1S1K1  )   .15922 (  .00812)    10.869 (  3.092)     1.780 (  .091 )
    5  (306-345 : J1      )   .11593 (  .05861)    14.353 ( 29.006)      .072 (  .037 )
    6  (346-450 : OO1     )   .09109 (  .07490)   -17.931 ( 46.964)      .031 (  .026 )

    7  (451-549 : 2N2     )   .06241 (  .06477)    -9.552 ( 59.811)      .031 (  .032 )
    8  (550-599 : N2      )   .09961 (  .00731)   -14.189 (  4.181)      .376 (  .028 )
    9  (600-655 : M2      )   .11328 (  .00118)   -11.954 (   .593)     2.235 (  .023 )
   10  (656-681 : L2      )   .16439 (  .03657)     6.161 ( 12.715)      .092 (  .020 )
   11  (682-827 : S2K2    )   .13886 (  .00176)    10.355 (   .725)     1.275 (  .016 )

   12  (828-909 : M3      )   .09422 (  .04570)   -34.596 ( 27.805)      .022 (  .011 )
                     */
                    //分别拷贝各个波的数据
                  
                    int lines = 0;
                    while ((line = sr1.ReadLine()) != null)
                    {
                        lines++;
                        if (line.IndexOf(": Q1 ") > -1)
                        {
                            string phase = line.Substring(48, 10);
                            string amplitude = line.Substring(68, 10);
                            //insert into [WaterLevel$](时间,水位,气压) values('{0}','{1}','{2}')
                            string sql = "insert into [Sheet_Q1$]([时间],[相位],[振幅],[相位误差],[振幅误差],[FACTOR],[FACTOR-RMSE]) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";
                            //时间	相位	振幅	相位误差	振幅误差	FACTOR	FACTOR-RMSE
                            sql = string.Format(sql, sTime, phase, amplitude, line.Substring(59, 7), line.Substring(79, 7), line.Substring(27, 10), line.Substring(38, 8));
                            sqls.Add(sql);
                            //fpExcel.Sheets["Q1"].Cells[count, 0].Text = sTime;
                            //fpExcel.Sheets["Q1"].Cells[count, 1].Text = phase;
                            //fpExcel.Sheets["Q1"].Cells[count, 2].Text = amplitude;

                            //fpExcel.Sheets["Q1"].Cells[count, 9].Text = line.Substring(59, 7);
                            //fpExcel.Sheets["Q1"].Cells[count, 10].Text = line.Substring(79, 7);

                            //fpExcel.Sheets["Q1"].Cells[count, 11].Text = line.Substring(27, 10); //factor
                            //fpExcel.Sheets["Q1"].Cells[count, 12].Text = line.Substring(38, 8);//RMSE

                        }
                        else if (line.IndexOf(": O1 ") > -1)
                        {
                            string phase = line.Substring(48, 10);
                            string amplitude = line.Substring(68, 10);
                            string sql = "insert into [Sheet_O1$]([时间],[相位],[振幅],[相位误差],[振幅误差],[FACTOR],[FACTOR-RMSE]) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";
                            //时间	相位	振幅	相位误差	振幅误差	FACTOR	FACTOR-RMSE
                            sql = string.Format(sql, sTime, phase, amplitude, line.Substring(59, 7), line.Substring(79, 7), line.Substring(27, 10), line.Substring(38, 8));
                            sqls.Add(sql);
                            //fpExcel.Sheets["O1"].Cells[count, 0].Text = sTime;
                            //fpExcel.Sheets["O1"].Cells[count, 1].Text = phase;
                            //fpExcel.Sheets["O1"].Cells[count, 2].Text = amplitude;

                            //fpExcel.Sheets["O1"].Cells[count, 9].Text = line.Substring(59, 7);
                            //fpExcel.Sheets["O1"].Cells[count, 10].Text = line.Substring(79, 7);

                            //fpExcel.Sheets["O1"].Cells[count, 11].Text = line.Substring(27, 10); //factor
                            //fpExcel.Sheets["O1"].Cells[count, 12].Text = line.Substring(38, 8);//RMSE

                        }
                        else if (line.IndexOf(": M1 ") > -1)
                        {
                            string phase = line.Substring(48, 10);
                            string amplitude = line.Substring(68, 10);
                            string sql = "insert into [Sheet_M1$]([时间],[相位],[振幅],[相位误差],[振幅误差],[FACTOR],[FACTOR-RMSE]) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";
                            //时间	相位	振幅	相位误差	振幅误差	FACTOR	FACTOR-RMSE
                            sql = string.Format(sql, sTime, phase, amplitude, line.Substring(59, 7), line.Substring(79, 7), line.Substring(27, 10), line.Substring(38, 8));
                            sqls.Add(sql);
                            //fpExcel.Sheets["M1"].Cells[count, 0].Text = sTime;
                            //fpExcel.Sheets["M1"].Cells[count, 1].Text = phase;
                            //fpExcel.Sheets["M1"].Cells[count, 2].Text = amplitude;

                            //fpExcel.Sheets["M1"].Cells[count, 9].Text = line.Substring(59, 7);
                            //fpExcel.Sheets["M1"].Cells[count, 10].Text = line.Substring(79, 7);

                            //fpExcel.Sheets["M1"].Cells[count, 11].Text = line.Substring(27, 10); //factor
                            //fpExcel.Sheets["M1"].Cells[count, 12].Text = line.Substring(38, 8);//RMSE

                        }
                        else if (line.IndexOf(": P1S1K1 ") > -1)
                        {
                            string phase = line.Substring(48, 10);
                            string amplitude = line.Substring(68, 10);
                            string sql = "insert into [Sheet_P1S1K1$]([时间],[相位],[振幅],[相位误差],[振幅误差],[FACTOR],[FACTOR-RMSE]) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";
                            //时间	相位	振幅	相位误差	振幅误差	FACTOR	FACTOR-RMSE
                            sql = string.Format(sql, sTime, phase, amplitude, line.Substring(59, 7), line.Substring(79, 7), line.Substring(27, 10), line.Substring(38, 8));
                            sqls.Add(sql);
                            //fpExcel.Sheets["P1S1K1"].Cells[count, 0].Text = sTime;
                            //fpExcel.Sheets["P1S1K1"].Cells[count, 1].Text = phase;
                            //fpExcel.Sheets["P1S1K1"].Cells[count, 2].Text = amplitude;

                            //fpExcel.Sheets["P1S1K1"].Cells[count, 9].Text = line.Substring(59, 7);
                            //fpExcel.Sheets["P1S1K1"].Cells[count, 10].Text = line.Substring(79, 7);

                            //fpExcel.Sheets["P1S1K1"].Cells[count, 11].Text = line.Substring(27, 10); //factor
                            //fpExcel.Sheets["P1S1K1"].Cells[count, 12].Text = line.Substring(38, 8);//RMSE

                        }
                        else if (line.IndexOf(": J1 ") > -1)
                        {
                            string phase = line.Substring(48, 10);
                            string amplitude = line.Substring(68, 10);
                            string sql = "insert into [Sheet_J1$]([时间],[相位],[振幅],[相位误差],[振幅误差],[FACTOR],[FACTOR-RMSE]) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";
                            //时间	相位	振幅	相位误差	振幅误差	FACTOR	FACTOR-RMSE
                            sql = string.Format(sql, sTime, phase, amplitude, line.Substring(59, 7), line.Substring(79, 7), line.Substring(27, 10), line.Substring(38, 8));
                            sqls.Add(sql);
                            //fpExcel.Sheets["J1"].Cells[count, 0].Text = sTime;
                            //fpExcel.Sheets["J1"].Cells[count, 1].Text = phase;
                            //fpExcel.Sheets["J1"].Cells[count, 2].Text = amplitude;

                            //fpExcel.Sheets["J1"].Cells[count, 9].Text = line.Substring(59, 7);
                            //fpExcel.Sheets["J1"].Cells[count, 10].Text = line.Substring(79, 7);

                            //fpExcel.Sheets["J1"].Cells[count, 11].Text = line.Substring(27, 10); //factor
                            //fpExcel.Sheets["J1"].Cells[count, 12].Text = line.Substring(38, 8);//RMSE
                        }
                        else if (line.IndexOf(": OO1 ") > -1)
                        {
                            string phase = line.Substring(48, 10);
                            string amplitude = line.Substring(68, 10);
                            string sql = "insert into [Sheet_OO1$]([时间],[相位],[振幅],[相位误差],[振幅误差],[FACTOR],[FACTOR-RMSE]) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";
                            //时间	相位	振幅	相位误差	振幅误差	FACTOR	FACTOR-RMSE
                            sql = string.Format(sql, sTime, phase, amplitude, line.Substring(59, 7), line.Substring(79, 7), line.Substring(27, 10), line.Substring(38, 8));
                            sqls.Add(sql);
                            //fpExcel.Sheets["OO1"].Cells[count, 0].Text = sTime;
                            //fpExcel.Sheets["OO1"].Cells[count, 1].Text = phase;
                            //fpExcel.Sheets["OO1"].Cells[count, 2].Text = amplitude;

                            //fpExcel.Sheets["OO1"].Cells[count, 9].Text = line.Substring(59, 7);
                            //fpExcel.Sheets["OO1"].Cells[count, 10].Text = line.Substring(79, 7);

                            //fpExcel.Sheets["OO1"].Cells[count, 11].Text = line.Substring(27, 10); //factor
                            //fpExcel.Sheets["OO1"].Cells[count, 12].Text = line.Substring(38, 8);//RMSE
                        }
                        else if (line.IndexOf(": 2N2 ") > -1)
                        {
                            string phase = line.Substring(48, 10);
                            string amplitude = line.Substring(68, 10);
                            string sql = "insert into [Sheet_2N2$]([时间],[相位],[振幅],[相位误差],[振幅误差],[FACTOR],[FACTOR-RMSE]) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";
                            //时间	相位	振幅	相位误差	振幅误差	FACTOR	FACTOR-RMSE
                            sql = string.Format(sql, sTime, phase, amplitude, line.Substring(59, 7), line.Substring(79, 7), line.Substring(27, 10), line.Substring(38, 8));
                            sqls.Add(sql);
                            //fpExcel.Sheets["2N2"].Cells[count, 0].Text = sTime;
                            //fpExcel.Sheets["2N2"].Cells[count, 1].Text = phase;
                            //fpExcel.Sheets["2N2"].Cells[count, 2].Text = amplitude;

                            //fpExcel.Sheets["2N2"].Cells[count, 9].Text = line.Substring(59, 7);
                            //fpExcel.Sheets["2N2"].Cells[count, 10].Text = line.Substring(79, 7);

                            //fpExcel.Sheets["2N2"].Cells[count, 11].Text = line.Substring(27, 10); //factor
                            //fpExcel.Sheets["2N2"].Cells[count, 12].Text = line.Substring(38, 8);//RMSE
                        }
                        else if (line.IndexOf(": N2 ") > -1)
                        {
                            string phase = line.Substring(48, 10);
                            string amplitude = line.Substring(68, 10);
                            string sql = "insert into [Sheet_N2$]([时间],[相位],[振幅],[相位误差],[振幅误差],[FACTOR],[FACTOR-RMSE]) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";
                            //时间	相位	振幅	相位误差	振幅误差	FACTOR	FACTOR-RMSE
                            sql = string.Format(sql, sTime, phase, amplitude, line.Substring(59, 7), line.Substring(79, 7), line.Substring(27, 10), line.Substring(38, 8));
                            sqls.Add(sql);
                            //fpExcel.Sheets["N2"].Cells[count, 0].Text = sTime;
                            //fpExcel.Sheets["N2"].Cells[count, 1].Text = phase;
                            //fpExcel.Sheets["N2"].Cells[count, 2].Text = amplitude;

                            //fpExcel.Sheets["N2"].Cells[count, 9].Text = line.Substring(59, 7);
                            //fpExcel.Sheets["N2"].Cells[count, 10].Text = line.Substring(79, 7);

                            //fpExcel.Sheets["N2"].Cells[count, 11].Text = line.Substring(27, 10); //factor
                            //fpExcel.Sheets["N2"].Cells[count, 12].Text = line.Substring(38, 8);//RMSE
                        }
                        else if (line.IndexOf(": M2 ") > -1)
                        {
                            string phase = line.Substring(48, 10);
                            string amplitude = line.Substring(68, 10);
                            string sql = "insert into [Sheet_M2$]([时间],[相位],[振幅],[相位误差],[振幅误差],[FACTOR],[FACTOR-RMSE]) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";
                            //时间	相位	振幅	相位误差	振幅误差	FACTOR	FACTOR-RMSE
                            sql = string.Format(sql, sTime, phase, amplitude, line.Substring(59, 7), line.Substring(79, 7), line.Substring(27, 10), line.Substring(38, 8));
                            sqls.Add(sql);
                            //fpExcel.Sheets["M2"].Cells[count, 0].Text = sTime;
                            //fpExcel.Sheets["M2"].Cells[count, 1].Text = phase;
                            //fpExcel.Sheets["M2"].Cells[count, 2].Text = amplitude;

                            //fpExcel.Sheets["M2"].Cells[count, 9].Text = line.Substring(59, 7);
                            //fpExcel.Sheets["M2"].Cells[count, 10].Text = line.Substring(79, 7);

                            //fpExcel.Sheets["M2"].Cells[count, 11].Text = line.Substring(27, 10); //factor
                            //fpExcel.Sheets["M2"].Cells[count, 12].Text = line.Substring(38, 8);//RMSE
                        }
                        else if (line.IndexOf(": L2 ") > -1)
                        {
                            string phase = line.Substring(48, 10);
                            string amplitude = line.Substring(68, 10);
                            string sql = "insert into [Sheet_L2$]([时间],[相位],[振幅],[相位误差],[振幅误差],[FACTOR],[FACTOR-RMSE]) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";
                            //时间	相位	振幅	相位误差	振幅误差	FACTOR	FACTOR-RMSE
                            sql = string.Format(sql, sTime, phase, amplitude, line.Substring(59, 7), line.Substring(79, 7), line.Substring(27, 10), line.Substring(38, 8));
                            sqls.Add(sql);
                            //fpExcel.Sheets["L2"].Cells[count, 0].Text = sTime;
                            //fpExcel.Sheets["L2"].Cells[count, 1].Text = phase;
                            //fpExcel.Sheets["L2"].Cells[count, 2].Text = amplitude;
                            //fpExcel.Sheets["L2"].Cells[count, 9].Text = line.Substring(59, 7);
                            //fpExcel.Sheets["L2"].Cells[count, 10].Text = line.Substring(79, 7);

                            //fpExcel.Sheets["L2"].Cells[count, 11].Text = line.Substring(27, 10); //factor
                            //fpExcel.Sheets["L2"].Cells[count, 12].Text = line.Substring(38, 8);//RMSE

                        }
                        else if (line.IndexOf(": S2K2 ") > -1)
                        {
                            string phase = line.Substring(48, 10);
                            string amplitude = line.Substring(68, 10);
                            string sql = "insert into [Sheet_S2K2$]([时间],[相位],[振幅],[相位误差],[振幅误差],[FACTOR],[FACTOR-RMSE]) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";
                            //时间	相位	振幅	相位误差	振幅误差	FACTOR	FACTOR-RMSE
                            sql = string.Format(sql, sTime, phase, amplitude, line.Substring(59, 7), line.Substring(79, 7), line.Substring(27, 10), line.Substring(38, 8));
                            sqls.Add(sql);
                            //fpExcel.Sheets["S2K2"].Cells[count, 0].Text = sTime;
                            //fpExcel.Sheets["S2K2"].Cells[count, 1].Text = phase;
                            //fpExcel.Sheets["S2K2"].Cells[count, 2].Text = amplitude;
                            //fpExcel.Sheets["S2K2"].Cells[count, 9].Text = line.Substring(59, 7);
                            //fpExcel.Sheets["S2K2"].Cells[count, 10].Text = line.Substring(79, 7);

                            //fpExcel.Sheets["S2K2"].Cells[count, 11].Text = line.Substring(27, 10); //factor
                            //fpExcel.Sheets["S2K2"].Cells[count, 12].Text = line.Substring(38, 8);//RMSE
                        }
                        else if (line.IndexOf(": M3 ") > -1)
                        {
                            string phase = line.Substring(48, 10);
                            string amplitude = line.Substring(68, 10);
                            string sql = "insert into [Sheet_M3$]([时间],[相位],[振幅],[相位误差],[振幅误差],[FACTOR],[FACTOR-RMSE]) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";
                            //时间	相位	振幅	相位误差	振幅误差	FACTOR	FACTOR-RMSE
                            sql = string.Format(sql, sTime, phase, amplitude, line.Substring(59, 7), line.Substring(79, 7), line.Substring(27, 10), line.Substring(38, 8));
                            sqls.Add(sql);
                            //fpExcel.Sheets["M3"].Cells[count, 0].Text = sTime;
                            //fpExcel.Sheets["M3"].Cells[count, 1].Text = phase;
                            //fpExcel.Sheets["M3"].Cells[count, 2].Text = amplitude;
                            //fpExcel.Sheets["M3"].Cells[count, 9].Text = line.Substring(59, 7);
                            //fpExcel.Sheets["M3"].Cells[count, 10].Text = line.Substring(79, 7);

                            //fpExcel.Sheets["M3"].Cells[count, 11].Text = line.Substring(27, 10); //factor
                            //fpExcel.Sheets["M3"].Cells[count, 12].Text = line.Substring(38, 8);//RMSE
                            break; //开始下一个数据
                        }
                        else
                        {
                            if (lines > 30)
                                break;
                            else
                                continue;
                        }
                    }
                    count++;
                   
                }
                
                /////////
            }          

            //过滤需要的数据
            //  PERIOD     2006  2 26   .0 - 2006  3 27 23.0                     
            //GROUP          SYMBOL       FACTOR   (RMSE)       PHASE   (RMSE)   AMPLITUDE  (RMSE)
            //                                              (LOCAL, LAG:NEGATIVE)
            //  1  (  1-143 : Q1      )   .09029 (  .03965)   -10.780 ( 27.800)      .165 (  .072 )
            //  2  (144-201 : O1      )   .07557 (  .01071)     4.305 (  8.787)      .721 (  .102 )
            //  3  (202-249 : M1      )   .08751 (  .04516)    -8.792 ( 29.352)      .066 (  .034 )
            //  4  (250-305 : P1S1K1  )   .05106 (  .00979)   -87.030 ( 10.319)      .685 (  .131 )
            //  5  (306-345 : J1      )   .09127 (  .05355)   -53.836 ( 33.334)      .068 (  .040 )
            //  6  (346-450 : OO1     )   .06998 (  .06764)   -50.713 ( 55.364)      .029 (  .028 )
            //  7  (451-549 : 2N2     )   .05963 (  .03448)    10.376 ( 32.936)      .024 (  .014 )
            //  8  (550-599 : N2      )   .09380 (  .00938)   -10.843 (  5.728)      .291 (  .029 )
            //  9  (600-655 : M2      )   .08751 (  .00200)    -9.674 (  1.312)     1.417 (  .032 )
            // 10  (656-681 : L2      )   .13433 (  .03732)    -7.044 ( 15.950)      .061 (  .017 )
            // 11  (682-827 : S2K2    )   .12770 (  .00284)    24.846 (  1.272)      .962 (  .021 )
            // 12  (828-909 : M3      )   .06822 (  .08206)   -50.291 ( 68.921)      .012 (  .014 )

            sr1.Close();
            ExcelDbHelper.ExecuteNoQuerySql(OutputDataExcelFile, sqls);

        }

        /// <summary>
        /// 读取模板文件
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private string LoadTemplateFile(string filename)
        {
            string str = "";
            StreamReader sr = new StreamReader(filename, Encoding.Default);
            str = sr.ReadToEnd();
            sr.Close();
            return str;
        }

        /// <summary>
        /// 保存字符串到文件
        /// </summary>
        /// <param name="str"></param>
        /// <param name="shortfilename"></param>
        private void SaveFile(string str, string shortfilename)
        {
            string path = CurrentDir + "\\" + shortfilename;
            if (File.Exists(path))
                File.Delete(path);
            StreamWriter sw = new StreamWriter(path, false);
            sw.Write(str);
            sw.Close();
            //拷贝至输出目录
            string dir = OutputPath;
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            string newf = dir + "\\" + shortfilename;
            if (File.Exists(newf))
                File.Delete(newf);

            File.Copy(path, newf);

        }


   

        /// <summary>
        /// 选择水位数据文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowser_Click(object sender, EventArgs e)
        {
            if (ofdData.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.DataFile = ofdData.FileName;
                txtDataFile.Text = DataFile;
                //读取数据的开始时间和结束时间
                //StreamReader sr = new StreamReader(this.DataFile);
                //string firstline = sr.ReadLine();
                //string lastline = "";
                //string s = "";
                //while ((s = sr.ReadLine()) != null)
                //{
                //    lastline = s;
                //}
                //sr.Close();

                //使用二进制读取方法，提高运行速度
                byte[] start = new byte[30];
                byte[] end = new byte[30];
                int b;
                FileStream fs = new FileStream(this.DataFile, FileMode.Open);
                fs.Read(start, 0, start.Length);
                fs.Seek(end.Length * -1, SeekOrigin.End);
                fs.Read(end, 0, end.Length);
                long nlength = fs.Length;
                fs.Close();
                System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();
                String ss = ASCII.GetString(start);
                String ee = ASCII.GetString(end);

                //2002120100 28.711
                string sStart = ss.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];
                //一行水位数据的长度，含\R\N
                nWaterLineLen = ss.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)[0].Length + 2;
                if (nlength / nWaterLineLen > 365 * 24 * 11)
                {
                    MessageBox.Show("单次计算的数据量不能超过11年，请手动分开计算！");
                    return;
                }
                string[] sEnds = ee.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                string sEnd = sEnds[sEnds.Length - 1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];
                txtStartTime.Text = sStart;
                txtEndTime.Text = sEnd;

                

            }
            else
            {
                this.DataFile = "";
                txtDataFile.Text = "";
                txtStartTime.Text = "";
                txtEndTime.Text = "";
            }
        }
   


        /// <summary>
        /// 用空格填充前面的内容
        /// </summary>
        /// <param name="str"></param>
        /// <param name="totallenth"></param>
        /// <returns></returns>
        private string GetStrWithEmpty(string str, int totallenth)
        {
            string s = str.Trim();
            for (int i = s.Length; i < totallenth; i++)
            {
                s = " " + s;
            }
            return s;
        }

   

        /// <summary>
        /// 选择保存excel文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveExcel_Click(object sender, EventArgs e)
        {
            fbd.ShowNewFolderButton = true;
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                OutputPath = fbd.SelectedPath;
                if (!OutputPath.EndsWith("||"))
                    OutputPath += "\\";


                try
                {
                    //首先清除输出目录下的input05,input12,input14等文件
                    string f = OutputPath + "\\input05.dat";
                    File.Delete(f);
                    f = OutputPath + "\\input12.dat";
                    File.Delete(f);
                    f = OutputPath + "\\input14.dat";
                    File.Delete(f);
                    f = OutputPath + "\\output06.dat";
                    File.Delete(f);
                    f = OutputPath + "\\output16.dat";
                    File.Delete(f);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("清除该文件夹下文件失败，请手动清除");
                    return;
                }

                OutputDataExcelFile = OutputPath + "out.xlsx";
                //ConnectStr = string.Format(ConnectStrFormat, OutputDataExcelFile);
                ////初始化excel连接串
                //ExcelDbHelper.initConnection(DataFile, ConnectStr);
                txtExcel.Text = OutputPath;
            }
            else
            {
                txtExcel.Text = OutputDataExcelFile = "";
            }


        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            tsbTime.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒");
        }
    }
}

