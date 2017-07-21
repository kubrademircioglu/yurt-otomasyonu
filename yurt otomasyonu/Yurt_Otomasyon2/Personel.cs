using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Data.OleDb;
using System.IO;


namespace Yurt_Otomasyon2
{
    public partial class Personel : Form
    {
        public Personel()
        {
            InitializeComponent();
        }
       
        KullaniciIslemleri kullaniciislemleri = new KullaniciIslemleri();
        public DataSet ds;
        public OracleDataReader dr;
        public OracleDataAdapter da;
        public OracleCommand cmd;
        public DataTable dt;
        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void dataGridKayitGoster()
        {
            string sorgu = "SELECT * FROM TB_PERSONEL";
            OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
            OracleDataAdapter oda = new OracleDataAdapter(sorgu, baglan);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            baglan.Close();
        }

        private void Personel_Load(object sender, EventArgs e)
            
        {
            comboBox6.Visible = false;
            textBox17.Visible = false;
            OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
            baglan.Open();
            cmd = new OracleCommand("select * from TB_PERSONEL", baglan); cmd.ExecuteNonQuery();
            da = new OracleDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            baglan.Close();
           
            
        }
            
        private void button1_Click(object sender, EventArgs e)
        {
          
            MessageBox.Show(kullaniciislemleri.Kayit(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.Text, textBox4.Text, textBox5.Text, textBox6.Text,richTextBox1.Text,comboBox4.Text,textBox16.Text));
            string sorgu = "SELECT * FROM TB_PERSONEL";
            OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
            OracleDataAdapter oda = new OracleDataAdapter(sorgu, baglan);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            baglan.Close();
            textBox1.Text="";
            textBox2.Text="";
            textBox3.Text="";comboBox1.Text="";textBox4.Text="";
            textBox5.Text="";
            textBox6.Text="";richTextBox1.Text=""; comboBox4.Text="";textBox16.Text="";
            textBox9.Text = "";
            textBox8.Text = "";
            textBox7.Text = ""; comboBox2.Text = ""; comboBox5.Text = "";
            textBox10.Text = "";   textBox16.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            comboBox2.Text = "";
            richTextBox2.Text = "";
          
          

            
                
                
           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            
          
           
        }
        public int userid;
        private void button2_Click(object sender, EventArgs e)
        {
            userid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());


            MessageBox.Show(kullaniciislemleri.Sil(userid));
            string sorgu = "SELECT * FROM TB_PERSONEL";
            OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
            OracleDataAdapter oda = new OracleDataAdapter(sorgu, baglan);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            baglan.Close();
            textBox9.Text = "";
            textBox8.Text = "";
            textBox7.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            comboBox2.Text = "";
            richTextBox2.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            userid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());


            MessageBox.Show(kullaniciislemleri.Sil(userid));
            string sorgu = "SELECT * FROM TB_USERS";
            OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
            OracleDataAdapter oda = new OracleDataAdapter(sorgu, baglan);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
          

            baglan.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT * FROM TB_USERS";
            OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
            OracleDataAdapter oda = new OracleDataAdapter(sorgu, baglan);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        
            baglan.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT * FROM TB_PERSONEL";
            OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
            OracleDataAdapter oda = new OracleDataAdapter(sorgu, baglan);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
            baglan.Open();
            string sorgu = "SELECT * FROM TB_PERSONEL WHERE  AD='" + textBox7.Text + "'";
            OracleCommand command = new OracleCommand(sorgu, baglan);
            OracleDataAdapter oda = new OracleDataAdapter(sorgu, baglan);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            baglan.Close();
            textBox7.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            userid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            textBox13.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox12.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox11.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            richTextBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            comboBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            textBox15.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
        
           
        }

     

        private void button4_Click_1(object sender, EventArgs e)
        {

            MessageBox.Show(kullaniciislemleri.KayitGuncelle(userid, textBox13.Text, textBox12.Text, textBox11.Text,comboBox2.Text,textBox10.Text,textBox9.Text,textBox8.Text,richTextBox2.Text,comboBox5.Text,textBox15.Text ));
            dataGridKayitGoster();
            textBox9.Text = "";
            textBox8.Text = "";
            textBox7.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox15.Text = "";
            comboBox2.Text = "";
            comboBox5.Text = ""; 
            richTextBox2.Text = "";

           
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0)
            {
                label18.Text = "Ad Giriniz:";
                comboBox6.Visible = false;
                textBox14.Visible = true;
                
            }
            if (comboBox3.SelectedIndex == 1)
            {
                label18.Text = "Soyad Giriniz:";
                comboBox6.Visible = false;
                textBox14.Visible = true;

            }
            if (comboBox3.SelectedIndex == 2)
            {
                label18.Text = "TC Giriniz:";
                comboBox6.Visible = false;
                textBox14.Visible = true;
            }
            if (comboBox3.SelectedIndex == 3)
            {
                label18.Text = "Görev Seçiniz:";
                comboBox6.Visible = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0)
            {
                OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
                baglan.Open();
                string sorgu = "SELECT * FROM TB_PERSONEL WHERE  AD='" + textBox14.Text + "'";
                OracleCommand command = new OracleCommand(sorgu, baglan);
                OracleDataAdapter oda = new OracleDataAdapter(sorgu, baglan);
                DataSet ds = new DataSet();
                oda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                textBox14.Text = "";
                baglan.Close();

            }
            if (comboBox3.SelectedIndex == 1)
            {
               
                OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
                baglan.Open();
                string sorgu = "SELECT * FROM TB_PERSONEL WHERE  SOYAD='" + textBox14.Text + "'";
                OracleCommand command = new OracleCommand(sorgu, baglan);
                OracleDataAdapter oda = new OracleDataAdapter(sorgu, baglan);
                DataSet ds = new DataSet();
                oda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                textBox14.Text = "";
                baglan.Close();
            }
            if (comboBox3.SelectedIndex == 2)
            {
               
                OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
                baglan.Open();
                string sorgu = "SELECT * FROM TB_PERSONEL WHERE  TC='" + textBox14.Text + "'";
                OracleCommand command = new OracleCommand(sorgu, baglan);
                OracleDataAdapter oda = new OracleDataAdapter(sorgu, baglan);
                DataSet ds = new DataSet();
                oda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                textBox14.Text = "";
                baglan.Close();
            }
            if (comboBox3.SelectedIndex == 3)
            {
                label18.Text = "Görev Seçiniz:";
                textBox14.Visible = false;
                OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
                baglan.Open();
                string sorgu = "SELECT * FROM TB_PERSONEL WHERE  GOREV='" +comboBox6.Text + "'";
                OracleCommand command = new OracleCommand(sorgu, baglan);
                OracleDataAdapter oda = new OracleDataAdapter(sorgu, baglan);
                DataSet ds = new DataSet();
                oda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                baglan.Close();
            }
           
        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = true;
            object Missing = Type.Missing;
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(Missing);
            Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
            int StartCol = 1;
            int StartRow = 1;
            for (int j = 0; j < dataGridView1.Columns.Count; j++)
            {
                Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                myRange.Value2 = dataGridView1.Columns[j].HeaderText;
            }
            StartRow++;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {

                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                    myRange.Value2 = dataGridView1[j, i].Value == null ? "" : dataGridView1[j, i].Value;
                    myRange.Select();


                }
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.textBox17.Text = openFileDialog1.FileName;
            }
            string yolBaglantisi = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox17.Text + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";
            OleDbConnection con = new OleDbConnection(yolBaglantisi);
            OleDbDataAdapter myAdapter = new OleDbDataAdapter("select * from [Sayfa1$]", con);
            DataTable dt = new DataTable();
            myAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                MessageBox.Show(kullaniciislemleri.Kayit(dataGridView1[0, i].Value.ToString(), dataGridView1[1, i].Value.ToString(), dataGridView1[2, i].Value.ToString(), dataGridView1[3, i].Value.ToString(), dataGridView1[4, i].Value.ToString(), dataGridView1[5, i].Value.ToString(), dataGridView1[6, i].Value.ToString(), dataGridView1[7, i].Value.ToString(), dataGridView1[8, i].Value.ToString(), dataGridView1[9, i].Value.ToString()));

            }
            dataGridKayitGoster();
            
        }

       
       
    }
}
