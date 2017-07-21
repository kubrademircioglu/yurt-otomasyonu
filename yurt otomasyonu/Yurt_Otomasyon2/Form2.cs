using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using Oracle.ManagedDataAccess.Client;
using System.Diagnostics;


namespace Yurt_Otomasyon2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
      public   OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
               

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        KullaniciIslemleri ki = new KullaniciIslemleri();
        private void button2_Click(object sender, EventArgs e)
        {
           
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            
            


           
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
       
        private void button3_Click(object sender, EventArgs e)
        {
          
                    
        }

        private void button4_Click(object sender, EventArgs e)
        {
              
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                string sorgu = "drop table  YEDEKLENEN_HESAP";
                OracleCommand command = new OracleCommand(sorgu, baglan);
                command.ExecuteNonQuery();
                this.Close();
            }
            catch { this.Close(); }
       
            string sorgu1 = "create table YEDEKLENEN_HESAP as select * from  TB_HESAP";
            OracleCommand command1 = new OracleCommand(sorgu1, baglan);
            command1.ExecuteNonQuery();
  
            MessageBox.Show("Hesap tablosu yedeklendi");
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //string sorgu1 = "drop table  TB_HESAP CASCADE CONSTRAINTS";
            //OracleCommand command1 = new OracleCommand(sorgu1, baglan);
            //command1.ExecuteNonQuery();
            //this.Close();

            string sorgu2 = "create table TB_HESAP as select * from  YEDEKLENEN_HESAP";
            OracleCommand command2 = new OracleCommand(sorgu2, baglan);
            command2.ExecuteNonQuery();

            MessageBox.Show("Hesap tablosu yedekden döndü");
            this.Close();
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                string sorgu = "drop table  YEDEKLENEN_OGRENCI";
                OracleCommand command = new OracleCommand(sorgu, baglan);
                command.ExecuteNonQuery();
                this.Close();
            }
            catch { this.Close(); }

            string sorgu1 = "create table YEDEKLENEN_OGRENCI as select * from  TB_OGRENCI";
            OracleCommand command1 = new OracleCommand(sorgu1, baglan);
            command1.ExecuteNonQuery();

            MessageBox.Show("Öğrenci tablosu yedeklendi");
            this.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //string sorgu1 = "drop table  TB_OGRENCI CASCADE CONSTRAINTS";
            //OracleCommand command1 = new OracleCommand(sorgu1, baglan);
            //command1.ExecuteNonQuery();
            //this.Close();

            string sorgu2 = "create table TB_OGRENCI as select * from  YEDEKLENEN_OGRENCI";
            OracleCommand command2 = new OracleCommand(sorgu2, baglan);
            command2.ExecuteNonQuery();

            MessageBox.Show("Öğrenci tablosu yedekden döndü");
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                string sorgu = "drop table  YEDEKLENEN_PERSONEL";
                OracleCommand command = new OracleCommand(sorgu, baglan);
                command.ExecuteNonQuery();
                this.Close();
            }
            catch { this.Close(); }

            string sorgu1 = "create table YEDEKLENEN_PERSONEL as select * from  TB_PERSONEL";
            OracleCommand command1 = new OracleCommand(sorgu1, baglan);
            command1.ExecuteNonQuery();

            MessageBox.Show("Personel tablosu yedeklendi");
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //string sorgu1 = "drop table  TB_PERSONEL CASCADE CONSTRAINTS";
            //OracleCommand command1 = new OracleCommand(sorgu1, baglan);
            //command1.ExecuteNonQuery();
            //this.Close();

            string sorgu2 = "create table TB_PERSONEL as select * from  YEDEKLENEN_PERSONEL";
            OracleCommand command2 = new OracleCommand(sorgu2, baglan);
            command2.ExecuteNonQuery();

            MessageBox.Show("Personel tablosu yedekden döndü");
            this.Close();
        }
    }
    }

