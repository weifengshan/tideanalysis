using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TidalException
{
    public class Mylog
    {
        private static string LogFile = AppDomain.CurrentDomain.BaseDirectory + "/mylog.txt";
        public static void Log(string msg)
        {
            StreamWriter sw =null;
            try
            {
                sw = new StreamWriter(LogFile, true, System.Text.Encoding.Default);
                sw.WriteLine("------------------start------------"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                sw.WriteLine(msg);
                
            }
            finally
            {
                sw.Close();
            }
        }
        public static void Log(Exception  ex)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(LogFile, true, System.Text.Encoding.Default);
                sw.WriteLine("------------------start------------" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                sw.WriteLine(ex.Message+"\r\n"+ex.StackTrace);
                
            }
            finally
            {
                sw.Close();
            }
        }
        public static void Log(Object obj)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(LogFile, true, System.Text.Encoding.Default);
                sw.WriteLine("------------------start------------" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                sw.WriteLine(obj.ToString());
                sw.WriteLine("------------------end------------" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            finally
            {
                sw.Close();
            }
        }
    }
}
