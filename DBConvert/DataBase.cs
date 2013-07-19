using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace DBConvert
{
    public class DataBase
    {
        /// <summary>
        /// 保护变量，数据库连接
        /// </summary>
        protected SqlConnection Connection;

        /// <summary>
        /// 保护变量，数据库连接字符串
        /// </summary>
        protected String ConnectionString;

        /// <summary>
        /// 构造函数
        /// </summary>

        public DataBase(string DBConnectionString)
        {
            ConnectionString = DBConnectionString;
        }

        /// <summary>
        /// 析构函数，关闭数据库连接
        /// </summary>
        ~DataBase()
        {
            try
            {
                Close();

            }
            catch { }

        }

        /// <summary>
        /// 保护方法，打开数据库连接
        /// </summary>
        public void Open()
        {
            if (Connection == null)
            {
                Connection = new SqlConnection(ConnectionString);
            }

            if (Connection.State.Equals(ConnectionState.Closed))
            {
                Connection.Open();
            }
        }

        /// <summary>
        /// 公有方法，关闭数据库连接
        /// </summary>
        public void Close()
        {
            if (Connection != null)
                Connection.Close();
        }


        /// <summary>
        /// 公有方法，获取一个DataReader，返回SqlDataReader
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public SqlDataReader GetDataReader(String sqlString)
        {

            SqlCommand myCommand = Connection.CreateCommand();
            myCommand.CommandText = sqlString;

            SqlDataReader myDataReader = myCommand.ExecuteReader();

            return myDataReader;
        }

        public void ExcuteSqlNoResult(String sqlString)
        {
            SqlCommand myCommand = Connection.CreateCommand();
            myCommand.CommandText = sqlString;
            myCommand.ExecuteNonQuery();
        }

        public DataTable GetDataTable(string sqlString)
        {
            SqlCommand comm = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable datatable = new DataTable();

            comm.Connection = Connection;
            comm.CommandType = CommandType.Text;
            comm.CommandText = sqlString;
            da.SelectCommand = comm;
            da.Fill(datatable);
            return datatable;
        }
    }
}
