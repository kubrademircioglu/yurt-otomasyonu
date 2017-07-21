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

namespace Yurt_Otomasyon2
{
    public partial class izin : Form
    {
        public izin()
        {
            InitializeComponent();
        }
        OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
       
        KullaniciIslemleri kullaniciislemleri = new KullaniciIslemleri();
        private void button1_Click(object sender, EventArgs e)
        {
            
            DateTime bTarih = Convert.ToDateTime(dateTimePicker1.Text);
            DateTime kTarih = Convert.ToDateTime(dateTimePicker2.Text);
            TimeSpan Sonuc = kTarih - bTarih;
            if (Sonuc.TotalDays == 0)
            {
                MessageBox.Show("BAŞLANGIÇ VE BİTİŞ GÜNLERİ AYNI OLAMAZ!"); 
            }
            if (Sonuc.TotalDays < 0)
            {
                MessageBox.Show("BİTİŞ GÜNÜ BAŞLANGIÇ GÜNÜNDEN ÖNCE OLAMAZ!"); 
            }
            if (Sonuc.TotalDays >0)
            {
                string donustur = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string donustur2 = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                MessageBox.Show(kullaniciislemleri.IZIN_EKLE(donustur, donustur2, richTextBox1.Text, Convert.ToInt32(textBox2.Text)));
                dataGridKayitGoster();
            }
        }
        public void dataGridKayitGoster()
        {
            string sorgu = "select t.ızın_ıd,o.ad,o.soyad,o.tc,t.baslangıc,t.bıtıs,t.adres FROM TB_IZIN T JOIN TB_OGRENCI O ON T.OGRENCI_ID=O.OGRENCI_ID ";
            OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
            OracleDataAdapter oda = new OracleDataAdapter(sorgu, baglan);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            baglan.Close();
        }

        private void izin_Load(object sender, EventArgs e)
        {
            dataGridKayitGoster();
            textBox2.Visible = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false; 
            textBox8.Visible = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sorgu1 = "SELECT OGRENCI_ID,AD,SOYAD FROM TB_OGRENCI WHERE TC='"+textBox1.Text+"'";
            OracleCommand command = new OracleCommand(sorgu1, baglan);
            OracleDataReader oku;
            baglan.Open();
            oku = command.ExecuteReader();
           
            while (oku.Read())
            {
                textBox2.Text = oku["OGRENCI_ID"].ToString();
                textBox3.Text = oku["AD"].ToString();
                textBox4.Text = oku["SOYAD"].ToString();
                
                
            }
             textBox3.Visible = true;
            textBox4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            baglan.Close();
        }
        public int userid;

        private void button2_Click(object sender, EventArgs e)
        {
            userid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            MessageBox.Show(kullaniciislemleri.IZIN_Sil(userid));
            dataGridKayitGoster();
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            userid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            dateTimePicker3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            dateTimePicker4.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            richTextBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            string sorgu1 = "SELECT OGRENCI_ID,AD,SOYAD FROM TB_OGRENCI WHERE TC='" + textBox7.Text + "'";
            OracleCommand command = new OracleCommand(sorgu1, baglan);
            OracleDataReader oku;
            baglan.Open();
            oku = command.ExecuteReader();

            while (oku.Read())
            {
                textBox8.Text = oku["OGRENCI_ID"].ToString();
                


            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
                  
            DateTime bTarih = Convert.ToDateTime(dateTimePicker3.Text);
            DateTime kTarih = Convert.ToDateTime(dateTimePicker4.Text);
            TimeSpan Sonuc = kTarih - bTarih;
            if (Sonuc.TotalDays == 0)
            {
                MessageBox.Show("BAŞLANGIÇ VE BİTİŞ GÜNLERİ AYNI OLAMAZ!"); 
            }
            if (Sonuc.TotalDays < 0)
            {
                MessageBox.Show("BİTİŞ GÜNÜ BAŞLANGIÇ GÜNÜNDEN ÖNCE OLAMAZ!"); 
            }
            if (Sonuc.TotalDays > 0)
            {
                string donustu3 = dateTimePicker3.Value.ToString("yyyy-MM-dd");
                string donustur5 = dateTimePicker4.Value.ToString("yyyy-MM-dd");
                MessageBox.Show(kullaniciislemleri.IZINGuncelle(userid, donustu3, donustur5, richTextBox2.Text, Convert.ToInt32(textBox8.Text)));
                dataGridKayitGoster();
            }
           
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
            string donustur2 = dateTimePicker6.Value.ToString("yyyy-MM-dd");
            string donustur1 = dateTimePicker5.Value.ToString("yyyy-MM-dd");
            OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
            baglan.Open();
            string sorgu = "SELECT * FROM TB_IZIN  WHERE  BASLANGIC>='" + donustur2 + "' AND  BITIS<='" + donustur1 + "'";
            OracleCommand command = new OracleCommand(sorgu, baglan);
            OracleDataAdapter oda = new OracleDataAdapter(sorgu, baglan);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglan.Close();
        }
    }
}
