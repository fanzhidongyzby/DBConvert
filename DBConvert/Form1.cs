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
                if (ckMode.Checked)//���ݿ���
                {
                    sqlString = "Server=.;Initial Catalog=" + txtDB.Text.Trim() + ";Integrated Security=True";
                }
                else
                {
                    sqlString = txtDB.Text.Trim();
                }
                db=new DataBase (sqlString);
                db.Open();//�����ݿ�
                //��ȡ����
                String[] tables = txtTB.Text.Trim().Split
                    (new char[] { ' ', ',', '\n', '\t', '.', '��', '��', '��' ,'\r'}
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
                if (tn == "")//ת��ȡ��
                    return;
                tn = tn.Remove(tn.Length - 1);
                MessageBox.Show("���ݿ��еı�" + tn + "�ɹ�����!");
            }
            catch (Exception)
            {
                MessageBox.Show("����Դ��������ת��ʧ�ܣ�");
            }
        }

        void Convert(String table , String path)
        {
            DataTable dt = db.GetDataTable("select * from " + table);//����DataTable

            FileStream fs = new FileStream(path + "\\" + table+".sql", FileMode.Create);
            //ʵ����һ��StreamWriter-->��fs����� 
            //StreamWriter sw =  new StreamWriter(fs, Encoding.Default);
            StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("GB2312"));

            String[] cols = new String[dt.Columns.Count];
            //Type[] types = new Type[dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                cols[i] = dt.Columns[i].ColumnName.Trim();//��ȡ����
                //types[i] = dt.Columns[i].DataType;//��ȡ������
            }
            //��ʼ��sql���ǰ���
            String SqlCmd = "insert into " + table + " (";
            for (int i = 0; i < cols.Length; i++)
            {
                SqlCmd += cols[i];
                if (i == cols.Length - 1)
                    SqlCmd += ")values(";
                else
                    SqlCmd += ",";
            }            

            //���ж�ȡ�����Ӻ���
            DataRowCollection rows = dt.Rows;
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                String sql = SqlCmd;
                DataRow currRow = rows[r];
                for (int i = 0; i < cols.Length; i++)//��ȡÿһ��Ԫ��
                {
                    sql += "'" + currRow[cols[i]].ToString().Trim() + "'";
                    if (i == cols.Length - 1)
                        sql += ");\n\n";
                    else
                        sql += ",";
                }
                //������д���ļ�
                
                //��ʼд��
                sw.Write(sql);
            }
            //��ջ�����  
            sw.Flush();
            //�ر��� 
            sw.Close();
            fs.Close();  

            ////ʵ����һ�������ļ��Ի���  
            //SaveFileDialog sf = new SaveFileDialog(); 
            ////�����ļ���������  
            //sf.Filter = "sql�ű�|*sql"; 
            ////����û�û��������չ�����Զ�׷�Ӻ�׺  
            //sf.AddExtension = true;  
            ////���ñ���  
            //sf.Title = "����SQL�ű�";
            //sf.FileName = txtDB.Text.Trim()+"-"+ txtTB.Text.Trim()+".sql";
            ////����û�����˱��水ť  
            //if(sf.ShowDialog()==DialogResult.OK) 
            //{  
            //    //ʵ����һ���ļ���--->��д���ļ������            
            //}            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String info ="��ʾ:\n\n"+
                "    �������ݿ������������ַ���(�������ݿ�İ汾��ͬ�������ַ���������Ҫ�Լ�д,������Ĭ�ϵ���C# �� SQL Server 2008�������ַ���)"+
                "����Ҫ�����ı���������������ó��õķָ����ֿ���"+
                "���ת��,ѡ�������ļ���Ŀ¼��ȷ�ϼ���!        \n"+
                "                                                                                 �������� һҶ�³�";
            MessageBox.Show(info);
        }

        private void ckMode_CheckedChanged(object sender, EventArgs e)
        {
            if (ckMode.Checked)//�������ݿ���
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