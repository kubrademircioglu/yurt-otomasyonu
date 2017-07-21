using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Microsoft.Office.Interop.Excel;
using System.Data.OleDb;

namespace Yurt_Otomasyon2
{
    public partial class Ogrenci : Form
    {
        public Ogrenci()
        {
            InitializeComponent();
        }
        KullaniciIslemleri kullaniciislemleri = new KullaniciIslemleri(); 
       
        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            if (comboBox3.SelectedIndex == 0)
            {
                OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
                baglan.Open();
                string sorgu = "SELECT * FROM TB_OGRENCI WHERE  AD='" + textBox10.Text + "'";
                OracleCommand command = new OracleCommand(sorgu, baglan);
                OracleDataAdapter oda = new OracleDataAdapter(sorgu, baglan);
                DataSet ds = new DataSet();
                oda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                textBox10.Text = "";
                baglan.Close();

            }
            if (comboBox3.SelectedIndex == 1)
            {

                OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
                baglan.Open();
                string sorgu = "SELECT * FROM TB_OGRENCI WHERE  SOYAD='" + textBox10.Text + "'";
                OracleCommand command = new OracleCommand(sorgu, baglan);
                OracleDataAdapter oda = new OracleDataAdapter(sorgu, baglan);
                DataSet ds = new DataSet();
                oda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                textBox10.Text = "";
                baglan.Close();
            }
            
            if (comboBox3.SelectedIndex == 2)
            {
                string sorgu = "select OGRENCI_ID,AD,SOYAD,YAS,TC,TELEFON,EPOSTA,ADRES,OKUL,BOLUM,ODA_TİPİ,ODA_NUM,YATAK_NO from TB_ODATİPİ t join tb_oda d on t.odatipi_id=d.odatipi_id join tb_ogrenci o on d.oda_id=o.oda_id where ODA_NUM='" +  comboBox8.Text + "'";
                OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
                OracleDataAdapter oda = new OracleDataAdapter(sorgu, baglan);
                DataSet ds = new DataSet();
                oda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                baglan.Close();

               
            }
        }
        public void dataGridKayitGoster()
        {
            string sorgu = "select OGRENCI_ID,AD,SOYAD,YAS,TC,TELEFON,EPOSTA,ADRES,OKUL,BOLUM,ODA_TİPİ,ODA_NUM,YATAK_NO from TB_ODATİPİ t join tb_oda d on t.odatipi_id=d.odatipi_id join tb_ogrenci o on d.oda_id=o.oda_id";
            OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
            OracleDataAdapter oda = new OracleDataAdapter(sorgu, baglan);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            baglan.Close();
        }

        private void Ogrenci_Load(object sender, EventArgs e)
        {
            comboBox8.Visible = false;
            textBox9.Visible = false;
            textBox12.Visible = false;
            dataGridKayitGoster();
            string sorgu = "SELECT ODA_TİPİ  FROM TB_ODATİPİ group by ODA_TİPİ  ";
            OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
            OracleCommand command = new OracleCommand(sorgu, baglan);
            OracleDataReader oku;
            baglan.Open();
            oku = command.ExecuteReader();

            while (oku.Read())
            { comboBox1.Items.Add(oku[0]); }
            baglan.Close();
            OracleDataReader oku1;
            baglan.Open();
            oku1 = command.ExecuteReader();

            while (oku1.Read())
            { comboBox6.Items.Add(oku1[0]); }
            baglan.Close();



        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(kullaniciislemleri.OgrenciGuncelle(userid, textBox23.Text, textBox22.Text, textBox21.Text, textBox20.Text, textBox19.Text, textBox18.Text, richTextBox2.Text, textBox16.Text, textBox17.Text, Convert.ToInt32(comboBox2.Text)));
            kullaniciislemleri.Oda_ters(Convert.ToInt32(textBox9.Text));
            kullaniciislemleri.Oda_guncelle(Convert.ToInt32(comboBox2.Text));
            textBox23.Text="";
            textBox22.Text=""; textBox21.Text="";
            textBox20.Text="";
            textBox19.Text=""; 
            textBox18.Text="";
            richTextBox2.Text="";
            textBox16.Text="";
            textBox17.Text = ""; comboBox2.Text = "";
            comboBox6.Text = ""; comboBox7.Text = "";

            dataGridKayitGoster();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(kullaniciislemleri.OgrenciEkle(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, richTextBox1.Text, textBox8.Text, textBox7.Text, Convert.ToInt32(comboBox5.Text)));
            kullaniciislemleri.Oda_guncelle(Convert.ToInt32(comboBox5.Text));
            dataGridKayitGoster();
            textBox1.Text=""; 
            textBox2.Text="";
            textBox3.Text="";
            textBox4.Text=""; 
            textBox5.Text=""; 
            textBox6.Text=""; 
            richTextBox1.Text="";
            textBox8.Text="";
            textBox7.Text = ""; comboBox5.Text = ""; comboBox1.Text = ""; comboBox4.Text = "";


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox4.Items.Clear();
            string sorgu = "SELECT ODA_NUM  FROM TB_ODA   O  JOIN TB_ODATİPİ B ON O.ODATIPI_ID=B.ODATIPI_ID where ODA_TİPİ ='" + comboBox1.Text + "' GROUP BY ODA_NUM";
            OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
            OracleCommand command = new OracleCommand(sorgu, baglan);
            OracleDataReader oku;
            baglan.Open();
            oku = command.ExecuteReader();
            while (oku.Read())
            { comboBox4.Items.Add(oku[0]); }
            baglan.Close();






        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();

            string sorgu = "SELECT YATAK_NO,ODA_DURUMU FROM TB_ODATİPİ O  JOIN TB_ODA b ON O.ODATIPI_ID=b.ODATIPI_ID WHERE ODA_DURUMU='BOŞ' AND b.ODA_NUM='" + comboBox4.Text + "'";
            OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
            OracleCommand command = new OracleCommand(sorgu, baglan);
            OracleDataReader oku;
            baglan.Open();
            oku = command.ExecuteReader();
            while (oku.Read())
            { comboBox5.Items.Add(oku[0]); }

            baglan.Close();

        }
        public int userid;
        public int a;
        public int b;
        public int c;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            userid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            textBox23.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox22.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox21.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox20.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox19.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox18.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            richTextBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textBox16.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            textBox17.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            comboBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            a = Convert.ToInt32(dataGridView1.CurrentRow.Cells[11].Value.ToString());
            b = Convert.ToInt32(dataGridView1.CurrentRow.Cells[12].Value.ToString());

            comboBox2.Text = b.ToString();
            comboBox7.Text = a.ToString();
            textBox9.Text = b.ToString();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox7.Items.Clear();
            string sorgu = "SELECT ODA_NUM  FROM TB_ODA   O  JOIN TB_ODATİPİ B ON O.ODATIPI_ID=B.ODATIPI_ID where ODA_TİPİ ='" + comboBox6.Text + "' GROUP BY ODA_NUM";
            OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
            OracleCommand command = new OracleCommand(sorgu, baglan);
            OracleDataReader oku;
            baglan.Open();
            oku = command.ExecuteReader();
            while (oku.Read())
            { comboBox7.Items.Add(oku[0]); }
            baglan.Close();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {


            comboBox2.Items.Clear();

            string sorgu = "SELECT YATAK_NO,ODA_DURUMU FROM TB_ODATİPİ O  JOIN TB_ODA b ON O.ODATIPI_ID=b.ODATIPI_ID WHERE ODA_DURUMU='BOŞ' AND b.ODA_NUM='" + comboBox7.Text + "'";
            OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
            OracleCommand command = new OracleCommand(sorgu, baglan);
            OracleDataReader oku;
            baglan.Open();
            oku = command.ExecuteReader();
            while (oku.Read())
            { comboBox2.Items.Add(oku[0]); }

            baglan.Close();

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0)
            {
                label11.Text = "AD GİRİNİZ:";
                comboBox8.Visible = false;

            }
            if (comboBox3.SelectedIndex == 1)
            {
                label11.Text = "SOYAD GİRİNİZ:";
                comboBox8.Visible = false;

            }
            
            if (comboBox3.SelectedIndex == 2)
            {
                label11.Text = "ODA SEÇİNİZ:";
                comboBox8.Visible = true;
                comboBox8.Items.Clear();

                string sorgu7 = "SELECT ODA_NUM FROM TB_ODA GROUP BY ODA_NUM ORDER BY ODA_NUM ASC";
                OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
                OracleCommand command = new OracleCommand(sorgu7, baglan);
                OracleDataReader oku7;
                baglan.Open();
                oku7 = command.ExecuteReader();
                while (oku7.Read())
                { comboBox8.Items.Add(oku7[0]); }

                baglan.Close();

            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
            baglan.Open();
            string sorgu = "SELECT * FROM TB_OGRENCI WHERE  TC='" + textBox11.Text + "'";
            OracleCommand command = new OracleCommand(sorgu, baglan);
            OracleDataAdapter oda = new OracleDataAdapter(sorgu, baglan);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            
            baglan.Close();
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            userid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            MessageBox.Show(kullaniciislemleri.OgrenciSil(userid));
            string sorgu = "select OGRENCI_ID,AD,SOYAD,YAS,TC,TELEFON,EPOSTA,ADRES,OKUL,BOLUM,ODA_TİPİ,ODA_NUM,YATAK_NO from TB_ODATİPİ t join tb_oda d on t.odatipi_id=d.odatipi_id join tb_ogrenci o on d.oda_id=o.oda_id";
           
            OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
            OracleDataAdapter oda = new OracleDataAdapter(sorgu, baglan);
            kullaniciislemleri.Oda_ters(Convert.ToInt32(b));
            DataSet ds = new DataSet();
            oda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            baglan.Close(); 



            
        }
        //EXCELE CIKTI
        private void button6_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = true;
            object Missing = Type.Missing;
            Workbook workbook = excel.Workbooks.Add(Missing);
            Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
            int StartCol = 1;
            int StartRow = 1;
            for (int j = 0; j < dataGridView1.Columns.Count; j++)
            {
                Range myRange = (Range)sheet1.Cells[StartRow, StartCol + j];
                myRange.Value2 = dataGridView1.Columns[j].HeaderText;
            }
            StartRow++;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {

                    Range myRange = (Range)sheet1.Cells[StartRow + i, StartCol + j];
                    myRange.Value2 = dataGridView1[j, i].Value == null ? "" : dataGridView1[j, i].Value;
                    myRange.Select();


                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            
     
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridKayitGoster();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        Hesap h = new Hesap();
        private void button11_Click(object sender, EventArgs e)
        {
            h.Show();
            this.Hide();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {

        }
  
       
    }
}
