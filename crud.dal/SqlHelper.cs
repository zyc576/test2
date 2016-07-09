using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud.dal
{
   public class SqlHelper
    {
       private static string connStr = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
       public static int ExecuteNonQuery(string sql,CommandType cmdType,params SqlParameter[]ps)
       {
           using(SqlConnection conn=new SqlConnection (connStr))
           {
               using(SqlCommand cmd=new SqlCommand (sql,conn))
               {
                   cmd.CommandType = cmdType;
                   if(ps!=null)
                   {
                       cmd.Parameters.AddRange(ps);
                   }
                   conn.Open();
                   return cmd.ExecuteNonQuery();
               }
           }
       }
       public static object ExecuteScalar(string sql,CommandType cmdType,params SqlParameter[]ps)
       {
           using(SqlConnection conn=new SqlConnection (connStr))
           {
               using(SqlCommand cmd=new SqlCommand (sql,conn))
               {
                   cmd.Parameters.AddRange(ps);
                   if (ps != null)
                   {
                       cmd.Parameters.AddRange(ps);
                   }
                   conn.Open();
                   return cmd.ExecuteScalar();
               }
              
           }
       }
       public static SqlDataReader ExecuteReader(string sql,CommandType cmdType,params SqlParameter[]ps)
       {
           SqlConnection conn = new SqlConnection(connStr);
           
               using(SqlCommand cmd=new SqlCommand (sql,conn))
               {
                   cmd.CommandType = cmdType;
                   if(ps!=null)
                   {
                       cmd.Parameters.AddRange(ps);
                   }
                   try
                   {
                       conn.Open();
                       return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                   }
                   catch(Exception e)
                   {
                       conn.Dispose();
                       throw e;
                   }
               }
           
       }
       public static DataTable GetDataTable(string sql,CommandType cmdType,params SqlParameter[]ps)
       {
           DataTable dt = new DataTable();
           using(SqlDataAdapter adapter=new SqlDataAdapter (sql,connStr))
           {
               adapter.SelectCommand.CommandType = cmdType;
               if(ps!=null)
               {
                   adapter.SelectCommand.Parameters.AddRange(ps);
               }
               adapter.Fill(dt);
           }
           return dt;
       }
    }
}
