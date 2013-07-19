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
        /// �������������ݿ�����
        /// </summary>
        protected SqlConnection Connection;

        /// <summary>
        /// �������������ݿ������ַ���
        /// </summary>
        protected String ConnectionString;

        /// <summary>
        /// ���캯��
        /// </summary>

        public DataBase(string DBConnectionString)
        {
            ConnectionString = DBConnectionString;
        }

        /// <summary>
        /// �����������ر����ݿ�����
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
        /// ���������������ݿ�����
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
        /// ���з������ر����ݿ�����
        /// </summary>
        public void Close()
        {
            if (Connection != null)
                Connection.Close();
        }


        /// <summary>
        /// ���з�������ȡһ��DataReader������SqlDataReader
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