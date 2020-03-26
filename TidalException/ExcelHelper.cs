/// 常用工具类——Excel操作类
/// <para>　------------------------------------------------</para>
/// <para>　CreateConnection：根据Excel文件路径和EXCEL驱动版本生成OleConnection对象实例</para>
/// <para>　ExecuteDataSet：执行一条SQL语句，返回一个DataSet对象</para>
/// <para>　ExecuteDataTable：执行一条SQL语句，返回一个DataTable对象</para>
/// <para>　ExecuteDataAdapter：表示一组数据命令和一个数据库连接，它们用于填充 DataSet 和更新数据源。</para>
/// <para>　ExecuteNonQuery：执行数据库语句返回受影响的行数，失败或异常返回-1[通常为:INSERT、DELETE、UPDATE 和 SET 语句等命令]。</para>
/// <para>　ExecuteScalar：执行数据库语句返回第一行第一列，失败或异常返回null</para>
/// <para>　ExecuteDataReader：执行数据库语句返回一个自进结果集流</para>
/// <para>　GetWorkBookName：获取Excel中的所有工作簿</para>
using System;
using System.Configuration;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace TidalException
{
    class ExcelHelper
    {
        private ExcelHelper() { }
  
        #region EXCEL版本
        /// <summary>
        /// EXCEL版本
        /// </summary>
        public enum ExcelVerion
        {
            /// <summary>
            /// Excel97-2003版本
            /// </summary>
            Excel2003,
            /// <summary>
            /// Excel2007版本
            /// </summary>
            Excel2007
        }
        #endregion
  
        #region 根据EXCEL路径生成OleDbConnectin对象
        /// <summary>
        /// 根据EXCEL路径生成OleDbConnectin对象
        /// </summary>
        /// <param name="ExcelFilePath">EXCEL文件相对于站点根目录的路径</param>
        /// <param name="Verion">Excel数据驱动版本：97-2003或2007,分别需要安装数据驱动软件</param>
        /// <returns>OleDbConnection对象</returns>
        public static OleDbConnection CreateConnection(string ExcelFilePath,ExcelVerion Verion)
        {
            OleDbConnection Connection = null;
            string strConnection = string.Empty;
            try
            {
                switch (Verion)
                {
                    case ExcelVerion.Excel2003: //读取Excel97-2003版本
                        strConnection = "Provider=Microsoft.Jet.OLEDB.4.0; " +
"Data Source=" + HttpContext.Current.Server.MapPath(ExcelFilePath) + ";Extended Properties=Excel 8.0";
                        break;
                    case ExcelVerion.Excel2007: //读取Excel2007版本
                         strConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0;HDR=YES';data source=" + ExcelFilePath;
                        break;
                }               
               if(!string.IsNullOrEmpty(strConnection)) Connection = new OleDbConnection(strConnection);
            }
            catch (Exception)
            {
            }
  
            return Connection;
        }        
        #endregion
  
        #region 创建一个OleDbCommand对象实例
        /// <summary>
        /// 创建一个OleDbCommand对象实例
        /// </summary>
        /// <param name="CommandText">SQL命令</param>
        /// <param name="Connection">数据库连接对象实例OleDbConnection</param>
        /// <param name="OleDbParameters">可选参数</param>
        /// <returns></returns>
        private static OleDbCommand CreateCommand(string CommandText, OleDbConnection Connection, params System.Data.OleDb.OleDbParameter[] OleDbParameters)
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();
            OleDbCommand comm = new OleDbCommand(CommandText, Connection);
            if (OleDbParameters != null)
            {
                foreach (OleDbParameter parm in OleDbParameters)
                {
                    comm.Parameters.Add(parm);
                }
            }
            return comm;
        }
        #endregion
  
        #region 执行一条SQL语句，返回一个DataSet对象
        /// <summary>
        /// 执行一条SQL语句，返回一个DataSet对象
        /// </summary>
        /// <param name="Connection">OleDbConnection对象</param>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="OleDbParameters">OleDbParameter可选参数</param>
        /// <returns>DataSet对象</returns>
        public static DataSet ExecuteDataSet(OleDbConnection Connection, string CommandText, params OleDbParameter[] OleDbParameters)
        {
            DataSet ds = new DataSet();
            try
            {
                OleDbCommand comm = CreateCommand(CommandText, Connection, OleDbParameters);
                OleDbDataAdapter da = new OleDbDataAdapter(comm);
                da.Fill(ds);
            }
            catch (Exception)
            {
            }
            finally
            {
                if (Connection.State == ConnectionState.Open) Connection.Close();
            }
  
            return ds;
        }
        #endregion
  
        #region 执行一条SQL语句,返回一个DataTable对象
        /// <summary>
        /// 执行一条SQL语句,返回一个DataTable对象
        /// </summary>
        /// <param name="Connection">OleDbConnection对象</param>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="OleDbParameters">OleDbParameter可选参数</param>
        /// <returns>DataSet对象</returns>
        public static DataTable ExecuteDataTable(OleDbConnection Connection, string CommandText, params OleDbParameter[] OleDbParameters)
        {
            DataTable Dt = null;
            try
            {
                OleDbCommand comm = CreateCommand(CommandText, Connection, OleDbParameters);
                OleDbDataAdapter da = new OleDbDataAdapter(comm);
                DataSet Ds = new DataSet();
                da.Fill(Ds);
                Dt = Ds.Tables[0];
            }
            catch (Exception)
            {
            }
            finally
            {
                if (Connection.State == ConnectionState.Open) Connection.Close();
            }
            return Dt;
        }
  
        #endregion
  
        #region 表示一组数据命令和一个数据库连接，它们用于填充 DataSet 和更新数据源。
        /// <summary>
        /// 表示一组数据命令和一个数据库连接，它们用于填充 DataSet 和更新数据源。
        /// </summary>
        /// <param name="Connection">OleDbConnection对象</param>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="OleDbParameters">OleDbParameter可选参数</param>
        /// <returns></returns>
        public static OleDbDataAdapter ExecuteDataAdapter(OleDbConnection Connection, string CommandText, params System.Data.OleDb.OleDbParameter[] OleDbParameters)
        {
            OleDbDataAdapter Da = null;
            try
            {
                OleDbCommand comm = CreateCommand(CommandText, Connection, OleDbParameters);
                Da = new OleDbDataAdapter(comm);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(Da);
            }
            catch (Exception)
            {
            }
            finally
            {
                if (Connection.State == ConnectionState.Open) Connection.Close();
            }
            return Da;
        }
        #endregion
  
        #region 执行数据库语句返回受影响的行数，失败或异常返回-1[通常为:INSERT、DELETE、UPDATE 和 SET 语句等命令]。
        /// <summary>
        /// 执行数据库语句返回受影响的行数，失败或异常返回-1[通常为:INSERT、DELETE、UPDATE 和 SET 语句等命令]。
        /// </summary>
        /// <param name="Connection">OleDbConnection对象</param>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="OleDbParameters">OleDbParameter可选参数</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(OleDbConnection Connection, string CommandText, params System.Data.OleDb.OleDbParameter[] OleDbParameters)
        {
            int i = -1;
            try
            {
                if (Connection.State == ConnectionState.Closed) Connection.Open();
                OleDbCommand comm = CreateCommand(CommandText, Connection, OleDbParameters);
                i = comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                if (Connection.State == ConnectionState.Open) Connection.Close();
            }
            return i;
        }
        #endregion


        #region 执行数据库语句返回受影响的行数，失败或异常返回-1[通常为:INSERT、DELETE、UPDATE 和 SET 语句等命令]。
        /// <summary>
        /// 执行数据库语句返回受影响的行数，失败或异常返回-1[通常为:INSERT、DELETE、UPDATE 和 SET 语句等命令]。
        /// </summary>
        /// <param name="Connection">OleDbConnection对象</param>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="OleDbParameters">OleDbParameter可选参数</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQueryNotClose(OleDbConnection Connection, string CommandText, params System.Data.OleDb.OleDbParameter[] OleDbParameters)
        {
            int i = -1;
            try
            {
                //if (Connection.State == ConnectionState.Closed) Connection.Open();
                OleDbCommand comm = CreateCommand(CommandText, Connection, OleDbParameters);
                i = comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            
            return i;
        }
        #endregion

  
        #region 执行数据库语句返回第一行第一列，失败或异常返回null
        /// <summary>
        /// 执行数据库语句返回第一行第一列，失败或异常返回null
        /// </summary>
        /// <param name="Connection">OleDbConnection对象</param>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="OleDbParameters">OleDbParameter可选参数</param>
        /// <returns>第一行第一列的值</returns>
        public static object ExecuteScalar(OleDbConnection Connection, string CommandText, params System.Data.OleDb.OleDbParameter[] OleDbParameters)
        {
            object Result = null;
            try
            {
                OleDbCommand comm = CreateCommand(CommandText, Connection, OleDbParameters);
                Result = comm.ExecuteScalar();
            }
            catch (Exception)
            {
            }
            finally
            {
                if (Connection.State == ConnectionState.Open) Connection.Close();
            }
            return Result;
        }
        #endregion
  
        #region 执行数据库语句返回一个自进结果集流
        /// <summary>
        /// 执行数据库语句返回一个自进结果集流
        /// </summary>
        /// <param name="Connection">OleDbConnection对象</param>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="OleDbParameters">OleDbParameter可选参数</param>
        /// <returns>DataReader对象</returns>
        public static OleDbDataReader ExecuteDataReader(OleDbConnection Connection, string CommandText, params System.Data.OleDb.OleDbParameter[] OleDbParameters)
        {
            OleDbDataReader Odr = null;
            try
            {
                OleDbCommand comm = CreateCommand(CommandText, Connection, OleDbParameters);
                Odr = comm.ExecuteReader();
            }
            catch (Exception)
            {
            }
            finally
            {
                if (Connection.State == ConnectionState.Open) Connection.Close();
            }
            return Odr;
        }
        #endregion
  
        #region 获取Excel中的所有工作簿
        /// <summary>
        /// 获取Excel中的所有工作簿
        /// </summary>
        /// <param name="Connection">OleDbConnection对象</param>
        /// <returns></returns>
        public static DataTable GetWorkBookName(OleDbConnection Connection)
        {
            DataTable Dt = null;
            try
            {
                if (Connection.State == ConnectionState.Closed) Connection.Open();
                Dt = Connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            }
            catch (Exception)
            {
            }
            finally
            {
                if (Connection.State == ConnectionState.Open) Connection.Close();
            }
            return Dt;
        }
        #endregion
    
    }
}
