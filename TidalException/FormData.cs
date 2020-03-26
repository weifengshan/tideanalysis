using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TidalException
{
    public partial class FormData : Form
    {
        public FormData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string []sheet = {"Q1","O1","M1","P1S1K1","J1","OO1","2N2","N2","M2","L2","S2K2","M3"};
            DateTime start = new DateTime();
            DateTime end = new DateTime();

            DataSet ds = ExcelDbHelper.ExecuteSelectSql(textBox1.Text, "select top 1 * from [WaterLevel$] where 时间 is not null  order by 时间 desc");            
            if (ds != null && ds.Tables.Count >0 && ds.Tables[0].Rows.Count >0)
            {
                string a = ds.Tables[0].Rows[0]["时间"].ToString();
                string b = a.Substring(0, 4) + "-" + a.Substring(4, 2) + "-" + a.Substring(6, 2);
                end = DateTime.Parse(b);
            }
            ds = ExcelDbHelper.ExecuteSelectSql(textBox1.Text, "select top 1 * from [WaterLevel$] where 时间 is not null order by 时间 asc");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                 string a = ds.Tables[0].Rows[0]["时间"].ToString();
                 string b = a.Substring(0, 4) + "-" + a.Substring(4, 2) + "-" + a.Substring(6, 2);
                 start = DateTime.Parse(b);
            }

            for ( int i =0 ;i < sheet.Length; i++)
            {
                string table = "[Sheet_" + sheet[i] + "$]";
                string sql = "select  AVG(相位) as xiangwei ,MAX(相位)-MIN(相位) as xiangweicha,AVG(振幅) as  zhengfu,MAX(振幅)-MIN(振幅) as zhenfucha  from " + table;
                DataSet dssheet = ExcelDbHelper.ExecuteSelectSql(textBox1.Text, sql);
                
                if (dssheet != null && dssheet.Tables.Count >0 && dssheet.Tables[0].Rows.Count >0 )
                {
                    float avg_xiangwei = float.Parse(dssheet.Tables[0].Rows[0]["xiangwei"].ToString());
                    float xiangweicha = float.Parse(dssheet.Tables[0].Rows[0]["xiangweicha"].ToString());
                    float zhenfucha = float.Parse(dssheet.Tables[0].Rows[0]["zhenfucha"].ToString());
                    float zhengfu = float.Parse(dssheet.Tables[0].Rows[0]["zhengfu"].ToString());
                   
                    Random r =new Random();
                    int num = 0;

                    string x = "select  时间    from " + table;
                    DataSet dsold = ExcelDbHelper.ExecuteSelectSql(textBox1.Text, x);

                    DateTime d = start;
                    for (; ; )
                    {
                        if (num < dsold.Tables[0].Rows.Count)
                        {
                            string s = "update " + table + " set 时间='{0}',相位={1},振幅={2} where 时间='"+dsold.Tables[0].Rows[num][0].ToString()+"'";
                            s = string.Format(s, d.ToString("yyyy-MM-dd"), avg_xiangwei + r.Next((int)xiangweicha),
                                zhengfu +  + r.Next((int)zhenfucha));
                            //update [Sheet_Q1$] set 时间='2004-01-01',相位='116.993930926214',振幅='0.798766816057231' where 时间='2004-1-1'
                            //Sheet_Q1
                            ExcelDbHelper.ExecuteNoQuerySql(textBox1.Text, s);
                            d = start.AddDays(int.Parse(textBox2.Text));
                        }
                        else
                        {
                            string s = "insert into " + table + "(时间,相位,振幅) values('{0}',{1},{2})";
                            s = string.Format(s, d.ToString("yyyy-MM-dd"), avg_xiangwei + r.Next((int)xiangweicha),
                                zhengfu + + r.Next((int)zhenfucha));
                            ExcelDbHelper.ExecuteNoQuerySql(textBox1.Text, s);
                            d = start.AddDays(int.Parse(textBox2.Text));
                        }
                        num++;
                        if (d > end)
                            break;
                    }
                }
                
            }
        }
    }
}
