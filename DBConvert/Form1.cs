using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;

namespace DBConvert
{
    public partial class Form1 : Form
    {
        DataBase db;
        String sqlString = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                if (ckMode.Checked)//数据库名
                {
                    sqlString = "Server=.;Initial Catalog=" + txtDB.Text.Trim() + ";Integrated Security=True";
                }
                else
                {
                    sqlString = txtDB.Text.Trim();
                }
                db=new DataBase (sqlString);
                db.Open();//打开数据库
                //提取表名
                String[] tables = txtTB.Text.Trim().Split
                    (new char[] { ' ', ',', '\n', '\t', '.', '、', '，', '。' ,'\r'}
                    , StringSplitOptions.RemoveEmptyEntries);
                FolderBrowserDialog fb = new FolderBrowserDialog();
                String tn = "";
                if (fb.ShowDialog() == DialogResult.OK)
                {
                    String path = fb.SelectedPath;
                    for (int i = 0; i < tables.Length; i++)
                    {
                        String t = tables[i];
                        tn += t + ",";
                        Convert(t,path);
                    }
                }
                db.Close();
                if (tn == "")//转换取消
                    return;
                tn = tn.Remove(tn.Length - 1);
                MessageBox.Show("数据库中的表" + tn + "成功导出!");
            }
            catch (Exception)
            {
                MessageBox.Show("部分源数据有误，转换失败！");
            }
        }

        void Convert(String table , String path)
        {
            DataTable dt = db.GetDataTable("select * from " + table);//生成DataTable

            FileStream fs = new FileStream(path + "\\" + table+".sql", FileMode.Create);
            //实例化一个StreamWriter-->与fs相关联 
            //StreamWriter sw =  new StreamWriter(fs, Encoding.Default);
            StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("GB2312"));

            String[] cols = new String[dt.Columns.Count];
            //Type[] types = new Type[dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                cols[i] = dt.Columns[i].ColumnName.Trim();//提取列名
                //types[i] = dt.Columns[i].DataType;//提取列类型
            }
            //初始化sql语句前半段
            String SqlCmd = "insert into " + table + " (";
            for (int i = 0; i < cols.Length; i++)
            {
                SqlCmd += cols[i];
                if (i == cols.Length - 1)
                    SqlCmd += ")values(";
                else
                    SqlCmd += ",";
            }            

            //按行读取，附加后半段
            DataRowCollection rows = dt.Rows;
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                String sql = SqlCmd;
                DataRow currRow = rows[r];
                for (int i = 0; i < cols.Length; i++)//提取每一个元素
                {
                    sql += "'" + currRow[cols[i]].ToString().Trim() + "'";
                    if (i == cols.Length - 1)
                        sql += ");\n\n";
                    else
                        sql += ",";
                }
                //将该行写入文件
                
                //开始写入
                sw.Write(sql);
            }
            //清空缓冲区  
            sw.Flush();
            //关闭流 
            sw.Close();
            fs.Close();  

            ////实例化一个保存文件对话框  
            //SaveFileDialog sf = new SaveFileDialog(); 
            ////设置文件保存类型  
            //sf.Filter = "sql脚本|*sql"; 
            ////如果用户没有输入扩展名，自动追加后缀  
            //sf.AddExtension = true;  
            ////设置标题  
            //sf.Title = "导出SQL脚本";
            //sf.FileName = txtDB.Text.Trim()+"-"+ txtTB.Text.Trim()+".sql";
            ////如果用户点击了保存按钮  
            //if(sf.ShowDialog()==DialogResult.OK) 
            //{  
            //    //实例化一个文件流--->与写入文件相关联            
            //}            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String info ="提示:\n\n"+
                "    输入数据库名或者连接字符串(由于数据库的版本不同，连接字符串可能需要自己写,本程序默认的是C# 与 SQL Server 2008的连接字符串)"+
                "输入要导出的表名，多个表名请用常用的分隔符分开。"+
                "点击转换,选择生成文件的目录，确认即可!        \n"+
                "                                                                                 ———— 一叶孤城";
            MessageBox.Show(info);
        }

        private void ckMode_CheckedChanged(object sender, EventArgs e)
        {
            if (ckMode.Checked)//输入数据库名
            {
                txtDB.Text = "DataBaseName";
            }
            else
            {
                txtDB.Text = "Server=.;Initial Catalog=DataBaseName;Integrated Security=True";
            }
        }

    }
}