// File:    SqlDbHelper.cs
// Author:  audrey
// Created: 2009年6月15日 10:30:03
// Purpose: Definition of Class SqlDbHelper

using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using System.Collections.Generic;

public class ExcelDbHelper
{

    //public static DataSet ExecuteSelectSql(string excelfile,string strSql)
    //{
    //    string ConnectStrFormat = "Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0;HDR=YES;';Data Source={0}";
    //    string ConnectStr = string.Format(ConnectStrFormat, excelfile);
    //    OleDbConnection conn = new OleDbConnection(ConnectStr);
    //    OleDbDataAdapter da = new OleDbDataAdapter(strSql, conn);
    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        da.Fill(ds);
    //        return ds;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception("执行SQL出现错误：\r\n" + strSql + "\r\n" + ex.ToString());
    //    }
    //    finally
    //    {
    //        conn.Close();
    //    }
    //    //throw new NotImplementedException();
    //}

   // private string CONNECTION_STRING = "";
   //public string connectionString;
    /// <summary>
    /// 执行Select语句，
    /// </summary>
    /// <param name="strSql"></param>
    /// <returns></returns>
    public static DataSet ExecuteSelectSql(string excelfile,string strSql)
   {
       string ConnectStrFormat = "Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0;HDR=YES;';Data Source={0}";
       string ConnectStr = string.Format(ConnectStrFormat, excelfile);
       OleDbConnection conn = new OleDbConnection(ConnectStr);
       OleDbDataAdapter da = new OleDbDataAdapter(strSql, conn);
       DataSet ds = new DataSet();
       try
       {
           da.Fill(ds);
           return ds;
       }
       catch (Exception ex)
       {
           TidalException.Mylog.Log("执行SQL出现错误：\r\n" + strSql + "\r\n" + ex.ToString());
           throw new Exception("执行SQL出现错误：\r\n"+strSql+"\r\n"+ex.ToString());
       }
       finally
       {
           conn.Close();
       }
       
       
      //throw new NotImplementedException();
   }
   /// <summary>
   /// 执行UPDATE,Insert,Delete语句
   /// </summary>
   /// <param name="strSql"></param>
   /// <returns></returns>
    public static int ExecuteNoQuerySql(string excelfile, string strSql)
   {
       string ConnectStrFormat = "Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0;HDR=YES;';Data Source={0}";
       string ConnectStr = string.Format(ConnectStrFormat, excelfile);
       OleDbConnection conn = new OleDbConnection(ConnectStr);
       OleDbCommand comm = new OleDbCommand();
       comm.Connection = conn;
       comm.CommandType = CommandType.Text;
       comm.CommandText = strSql;
       int ret = -1;
       try
       {
           conn.Open();
           ret = comm.ExecuteNonQuery();

           return ret;
       }
       catch (Exception ex)
       {
           TidalException.Mylog.Log("执行SQL出现错误：\r\n" + strSql + "\r\n" + ex.ToString());
           throw new Exception("执行SQL出现错误：\r\n" + strSql + "\r\n" + ex.ToString());
       }
       finally
       {
           conn.Close();
       }
       
       //throw new NotImplementedException();
   }

    public static bool ExecuteNoQuerySql(string excelfile, List<string> strSql)
   {
       string ConnectStrFormat = "Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0;HDR=YES;';Data Source={0}";
       string ConnectStr = string.Format(ConnectStrFormat, excelfile);
       OleDbConnection conn = new OleDbConnection(ConnectStr);
       OleDbTransaction tx = null;     
       
       int ret = -1;
       try
       {
           conn.Open();
          tx= conn.BeginTransaction();
                   

           for (int i = 0; i < strSql.Count; i++)
           {
               OleDbCommand comm = new OleDbCommand(strSql[i],conn,tx);  
               ret = comm.ExecuteNonQuery();
           }
           tx.Commit();
          
       }
       catch (Exception ex)
       {
           tx.Rollback();
           TidalException.Mylog.Log("执行SQL出现错误：\r\n" + strSql + "\r\n" + ex.ToString());
           throw new Exception("执行SQL出现错误：\r\n" + strSql + "\r\n" + ex.ToString());
       }
       finally
       {
           conn.Close();
       }
       return true;
       //throw new NotImplementedException();
   }

    public static Object ExecuteScalar(string excelfile, string strSql)
   {
       string ConnectStrFormat = "Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0;HDR=YES;';Data Source={0}";
       string ConnectStr = string.Format(ConnectStrFormat, excelfile);
       OleDbConnection conn = new OleDbConnection(ConnectStr);
       OleDbCommand comm = new OleDbCommand();
       comm.Connection = conn;
       comm.CommandType = CommandType.Text;
       comm.CommandText = strSql;
       
       try
       {
           conn.Open();
           OleDbDataReader dr = comm.ExecuteReader();
           if (dr.Read())
           {
               return dr[0];
           }
           else
           {
               return null;
           }
       }
       catch (Exception ex)
       {
           TidalException.Mylog.Log("执行SQL出现错误：\r\n" + strSql + "\r\n" + ex.ToString());
           throw new Exception("执行SQL出现错误：\r\n" + strSql + "\r\n" + ex.ToString());
       }
       finally
       {
           conn.Close();
       }
       

      //throw new NotImplementedException();
   }
   
   //public static void initConnection(string connstr)
   //{
   //    CONNECTION_STRING = connstr;
   //   //throw new NotImplementedException();
   //}
   
   

}