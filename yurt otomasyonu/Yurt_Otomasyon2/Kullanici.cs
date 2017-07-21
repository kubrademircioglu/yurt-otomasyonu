using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Collections;
using Oracle.ManagedDataAccess.Types;






namespace Yurt_Otomasyon2
{
    public partial class Kullanici : Form
    {
        public Kullanici()
        {
            InitializeComponent();
        }
            KullaniciIslemleri kullaniciislemleri = new KullaniciIslemleri();
            public String exceleGelecekler;
            public Microsoft.Office.Interop.Excel.Application ExcelNesnesi;
            public Microsoft.Office.Interop.Excel.Worksheet tablo;
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(kullaniciislemleri.KayitEkle(textBox1.Text, textBox2.Text,comboBox1.Text,Convert.ToInt32(textBox7.Text)));
            dataGridKayitGoster();
        }
        public void dataGridKayitGoster()
        {
            string sorgu = "SELECT * FROM TB_USERS";
            OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
            OracleDataAdapter oda = new OracleDataAdapter(sorgu, baglan);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            baglan.Close();
        }
        public int userid;
        private void Kullanici_Load(object sender, EventArgs e)
        {
            textBox7.Visible = false;
            dataGridKayitGoster();
            string sorgum = "SELECT AD FROM TB_PERSONEL WHERE GOREV='MEMUR'";
            exceleGelecekler = sorgum;     
            OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
            OracleCommand command = new OracleCommand(sorgum, baglan);
            OracleDataReader oku;
            baglan.Open();
            oku = command.ExecuteReader();
            while (oku.Read())
            { comboBox3.Items.Add(oku[0]); }
            baglan.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            userid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());


            MessageBox.Show(kullaniciislemleri.KayitSil(userid));
            dataGridKayitGoster();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
            baglan.Open();
            string sorgu = "SELECT * FROM TB_USERS WHERE  USERNAME='" + textBox5.Text + "'";
            OracleCommand command = new OracleCommand(sorgu, baglan);
            OracleDataAdapter oda = new OracleDataAdapter(sorgu, baglan);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            baglan.Close();
            textBox5.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            userid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(kullaniciislemleri.Guncelle(userid, textBox4.Text, textBox3.Text,comboBox2.Text));
            dataGridKayitGoster();
            textBox4.Text = "";
            textBox3.Text = "";
          
            comboBox2.Text = "";
           
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
        //    baglan.Open();
        //    string sorgu = "SELECT * FROM TB_USERS WHERE  USERNAME='" + textBox6.Text + "'";
        //    OracleCommand command = new OracleCommand(sorgu, baglan);
        //    OracleDataAdapter oda = new OracleDataAdapter(sorgu, baglan);
        //    DataSet ds = new DataSet();
        //    oda.Fill(ds);
        //    dataGridView1.DataSource = ds.Tables[0];

        //    baglan.Close();
        //    textBox6.Text = "";
        //}

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
            baglan.Open();
            string sorgu = "SELECT PERSONEL_ID FROM TB_PERSONEL WHERE  AD='" + comboBox3.Text + "'";
            OracleCommand command = new OracleCommand(sorgu, baglan);
            OracleDataAdapter oda = new OracleDataAdapter(sorgu, baglan);
             OracleDataReader oku;
            oku = command.ExecuteReader();
            while (oku.Read())
            { textBox7.Text = oku["PERSONEL_ID"].ToString(); }
            baglan.Close();
        }

        private void T6_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }
        public void Ara(string ad)
        {
           
            OracleConnection connect = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");

            OracleCommand command = new OracleCommand("PROC_ARAT_EKLE", connect);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@AD", OracleDbType.Varchar2, 20).Value = ad;
            command.Parameters.Add("cursor_c", OracleDbType.RefCursor, ParameterDirection.InputOutput);

            connect.Open();
            OracleDataAdapter da = new OracleDataAdapter(command);
            DataSet dt = new DataSet();
            command.ExecuteNonQuery();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
           
             OracleConnection connect = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");

            OracleCommand command = new OracleCommand("PROC_ARAT_EKLE", connect);
            command.CommandType = CommandType.StoredProcedure;
            List<System.Windows.Forms.ListBox> liste = new List<System.Windows.Forms.ListBox>();
            command.Parameters.Add("@AD", OracleDbType.Varchar2, 20).Value = textBox6.Text.ToString();
            OracleParameter output = command.Parameters.Add("cursor_c",OracleDbType.RefCursor);
            output.Direction = ParameterDirection.ReturnValue;
            command.ExecuteNonQuery();
            OracleDataReader dr1=((OracleRefCursor)output.Value).GetDataReader();

            while (dr1.Read())
            {
                System.Windows.Forms.ListBox l = new System.Windows.Forms.ListBox();
               
                
            }
            connect.Open();
            OracleDataAdapter da = new OracleDataAdapter(command);
            DataSet dt = new DataSet();
            command.ExecuteNonQuery();

            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connect.Close();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {

            

            }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }
        }

      
    }
