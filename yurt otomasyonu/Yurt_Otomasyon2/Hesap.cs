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
   
    public partial class Hesap : Form
    {
        public Hesap()
        {
            InitializeComponent();
        }
        KullaniciIslemleri kullaniciislemleri = new KullaniciIslemleri(); 
        OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
        
        private void tabPage1_Click(object sender, EventArgs e)
        {
            
      
            baglan.Open();
            string sorgue = "SELECT PERSONEL_ID FROM TB_USERS WHERE  USERNAME='" + textBox10.Text + "'";
            OracleCommand commande = new OracleCommand(sorgue, baglan);
            OracleDataAdapter odae = new OracleDataAdapter(sorgue, baglan);
            OracleDataReader okue;
            okue = commande.ExecuteReader();
            while (okue.Read())
            { textBox9.Text = okue["PERSONEL_ID"].ToString(); }
            baglan.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sorgu = "SELECT OGRENCI_ID,AD,SOYAD,ODA_NUM,ODA_TİPİ FROM TB_OGRENCI O  JOIN TB_ODA b ON O.ODA_ID=b.ODA_ID JOIN TB_ODATİPİ P ON P.ODATIPI_ID=B.ODATIPI_ID WHERE O.TC='" + textBox1.Text + "'";

            OracleCommand command = new OracleCommand(sorgu, baglan);
            OracleDataReader oku;
            baglan.Open();
            oku = command.ExecuteReader();
            while (oku.Read())
            {
                label12.Text = oku["OGRENCI_ID"].ToString();
                label13.Text = oku["OGRENCI_ID"].ToString();
                textBox2.Text = oku["AD"].ToString();
                textBox3.Text = oku["SOYAD"].ToString();
                textBox4.Text = oku["ODA_NUM"].ToString();
                textBox5.Text = oku["ODA_TİPİ"].ToString();

            }
            baglan.Close();

            if (textBox5.Text == "TEK")
            { textBox6.Text="9000"; }
             if (textBox5.Text == "İKİ KİŞİLİK")
            { textBox6.Text="8000"; }
             if (textBox5.Text == "ÜÇ KİŞİLİK")
             { textBox6.Text = "7000"; }
             if (textBox5.Text == "DÖRT KİŞİLİK")
             { textBox6.Text = "6000"; } 
             
            
             
            
        }
        public void dataGridKayitGoster()
        {
            string sorgu = "select h.hesap_ıd,o.ad,o.soyad,h.ucret,h.taksıt,h.odenecek,h.kalan,h.durum from TB_HESAP H JOIN TB_OGRENCI O ON H.OGRENCI_ID=o.ogrencı_ıd ";
            OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
            OracleDataAdapter oda = new OracleDataAdapter(sorgu, baglan);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            baglan.Close();

            


        }

        private void Hesap_Load(object sender, EventArgs e)
        {
            dataGridKayitGoster();
           
            textBox10.Visible = false;
            label12.Visible = false;
            label13.Visible = false; label21.Visible = false;
            textBox9.Visible = false;
            textBox13.Visible = false;
            textBox14.Visible = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox20.Enabled = false;
            textBox21.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox10.Text = Form1.id;
            baglan.Open();
            string sorgue = "SELECT PERSONEL_ID FROM TB_USERS WHERE  USERNAME='" + textBox10.Text + "'";
            OracleCommand commande = new OracleCommand(sorgue, baglan);
            OracleDataAdapter odae = new OracleDataAdapter(sorgue, baglan);
            OracleDataReader okue;
            okue = commande.ExecuteReader();
            while (okue.Read())
            { textBox9.Text = okue["PERSONEL_ID"].ToString();
            label21.Text = okue["PERSONEL_ID"].ToString();
            }
            baglan.Close();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
           MessageBox.Show(kullaniciislemleri.HESAP_Ekle(textBox6.Text, comboBox1.Text, textBox8.Text, textBox11.Text, textBox7.Text,Convert.ToInt32(label12.Text),Convert.ToInt32(textBox9.Text)));
           dataGridKayitGoster();
            textBox6.Text=""; comboBox1.Text="";textBox8.Text=""; textBox11.Text="";
            textBox7.Text="";
            textBox1.Text = ""; textBox2.Text = "";
            textBox3.Text = ""; textBox4.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBox8.Text = textBox6.Text;
                textBox11.Text = "0";
                textBox7.Text = "TAMAMLANDI";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                if (textBox5.Text == "TEK")
                { 
                textBox8.Text = "3000";
                textBox11.Text = "6000";
                textBox7.Text = "DEVAM EDİYOR";
                }
                if (textBox5.Text == "İKİ KİŞİLİK")
                {
                   
                    textBox8.Text = "2667";
                    textBox11.Text = "5333";
                    textBox7.Text = "DEVAM EDİYOR";
                }
                if (textBox5.Text == "ÜÇ KİŞİLİK")
                {
                    textBox8.Text = "2333";
                    textBox11.Text = "4667";
                    textBox7.Text = "DEVAM EDİYOR";
                }
                if (textBox5.Text == "DÖRT KİŞİLİK")
                {
                    textBox8.Text = "2000";
                    textBox11.Text ="4000";
                    textBox7.Text = "DEVAM EDİYOR";
                } 

            }
            if (comboBox1.SelectedIndex == 2)
            {
                if (textBox5.Text == "TEK")
                {
                    textBox8.Text = "1800";
                    textBox11.Text = "7200";
                    textBox7.Text = "DEVAM EDİYOR";
                }
                if (textBox5.Text == "İKİ KİŞİLİK")
                {

                    textBox8.Text = "1600";
                    textBox11.Text = "6400";
                    textBox7.Text = "DEVAM EDİYOR";
                }
                if (textBox5.Text == "ÜÇ KİŞİLİK")
                {
                    textBox8.Text = "1400";
                    textBox11.Text = "5600";
                    textBox7.Text = "DEVAM EDİYOR";
                }
                if (textBox5.Text == "DÖRT KİŞİLİK")
                {
                    textBox8.Text = "1200";
                    textBox11.Text = "4800";
                    textBox7.Text = "DEVAM EDİYOR";
                }
            }
            if (comboBox1.SelectedIndex == 3)
            {
                if (textBox5.Text == "TEK")
                {
                    textBox8.Text = "900";
                    textBox11.Text = "8100";
                    textBox7.Text = "DEVAM EDİYOR";
                }
                if (textBox5.Text == "İKİ KİŞİLİK")
                {

                    textBox8.Text = "800";
                    textBox11.Text = "7200";
                    textBox7.Text = "DEVAM EDİYOR";
                }
                if (textBox5.Text == "ÜÇ KİŞİLİK")
                {
                    textBox8.Text = "700";
                    textBox11.Text = "6300";
                    textBox7.Text = "DEVAM EDİYOR";
                }
                if (textBox5.Text == "DÖRT KİŞİLİK")
                {
                    textBox8.Text = "600";
                    textBox11.Text = "5400";
                    textBox7.Text = "DEVAM EDİYOR";
                }
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
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
        public int userid;
        public int a;
        public int b;
        public int c;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            userid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            textBox21.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox20.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox17.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox23.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            string sorgum = "SELECT OGRENCI_ID,ODA_TİPİ FROM TB_OGRENCI O  JOIN TB_ODA b ON O.ODA_ID=b.ODA_ID JOIN TB_ODATİPİ P ON P.ODATIPI_ID=B.ODATIPI_ID WHERE O.AD='" + textBox21.Text + "'";

            OracleCommand commandm = new OracleCommand(sorgum, baglan);
            OracleDataReader oku1;
            baglan.Open();
            oku1 = commandm.ExecuteReader();
            while (oku1.Read())
            {
                label13.Text = oku1["OGRENCI_ID"].ToString();
                textBox13.Text = oku1["ODA_TİPİ"].ToString();

            }
            baglan.Close();
       
             if (textBox23.Text =="3")
            {
                if (textBox13.Text == "TEK")
                { 
                textBox15.Text = "3000";
                a = int.Parse(textBox17.Text);
                b = int.Parse(textBox15.Text);
                c = a - b;
                textBox12.Text = c.ToString();
                }
                if (textBox13.Text == "İKİ KİŞİLİK")
                {
                   
                    textBox15.Text = "2667";
                    a = int.Parse(textBox17.Text);
                    b = int.Parse(textBox15.Text);
                    c = a - b;
                    textBox12.Text = c.ToString();
                   
                }
                if (textBox13.Text == "ÜÇ KİŞİLİK")
                {
                    textBox15.Text = "2333";
                    a = int.Parse(textBox17.Text);
                    b = int.Parse(textBox15.Text);
                    c = a - b;
                    textBox12.Text = c.ToString();
                    
                  
                }
                if (textBox13.Text == "DÖRT KİŞİLİK")
                {
                    textBox15.Text = "2000";
                    a = int.Parse(textBox17.Text);
                    b = int.Parse(textBox15.Text);
                    c = a - b;
                    textBox12.Text = c.ToString();
                    
                }
                if (c == 0 || c == 1)
                {
                    textBox12.Text = "0";
                    textBox16.Text = "TAMAMLANDI";
                  
                    

                }
                else
                { textBox16.Text = "DEVAM EDİYOR"; }

            }
            if (textBox23.Text =="5")
            {
                if (textBox13.Text == "TEK")
                {
                    textBox15.Text = "1800";
                    a = int.Parse(textBox17.Text);
                    b = int.Parse(textBox15.Text);
                    c = a - b;
                    textBox12.Text = c.ToString();
                    
                }
                if (textBox13.Text == "İKİ KİŞİLİK")
                {

                    textBox15.Text = "1600";
                    a = int.Parse(textBox17.Text);
                    b = int.Parse(textBox15.Text);
                    c = a - b;
                    textBox12.Text = c.ToString();
                    
                }
                if (textBox13.Text == "ÜÇ KİŞİLİK")
                {
                    textBox15.Text = "1400";
                    a = int.Parse(textBox17.Text);
                    b = int.Parse(textBox15.Text);
                    c = a - b;
                    textBox12.Text = c.ToString();
                }
                if (textBox13.Text == "DÖRT KİŞİLİK")
                {
                    textBox15.Text = "1200";
                    a = int.Parse(textBox17.Text);
                    b = int.Parse(textBox15.Text);
                    c = a - b;
                    textBox12.Text = c.ToString();
                    
                }
                if (c == 0 || c == 1)
                {
                    textBox16.Text = "TAMAMLANDI";
                   
                    textBox12.Text = "0";

                }
                else
                 { textBox16.Text = "DEVAM EDİYOR"; } 
            }
            if (textBox23.Text == "10")
            {
                if (textBox13.Text == "TEK")
                {
                    textBox15.Text = "900";
                         a = int.Parse(textBox17.Text);
                    b = int.Parse(textBox15.Text);
                    c = a - b;
                    textBox12.Text = c.ToString();

                }
                if (textBox13.Text == "İKİ KİŞİLİK")
                {

                    textBox15.Text = "800";
                     a = int.Parse(textBox17.Text);
                    b = int.Parse(textBox15.Text);
                    c = a - b;
                    textBox12.Text = c.ToString();

                }
                if (textBox13.Text == "ÜÇ KİŞİLİK")
                {
                    textBox15.Text = "700";
                    a = int.Parse(textBox17.Text);
                    b = int.Parse(textBox15.Text);
                    c = a - b;
                    textBox12.Text = c.ToString();

                }
                if (textBox13.Text == "DÖRT KİŞİLİK")
                {
                    textBox15.Text = "600";
                    a = int.Parse(textBox17.Text);
                    b = int.Parse(textBox15.Text);
                    c = a - b;
                    textBox12.Text = c.ToString();

                }
                if (c == 0 || c == 1)
                {
                    textBox16.Text = "TAMAMLANDI";
                  
                    textBox12.Text = "0";

                }
                else
                
                { textBox16.Text = "DEVAM EDİYOR"; }
            }





          
        }
        public int x;
        public int y;
        public int z;
        private void button4_Click(object sender, EventArgs e)
        {
            x = int.Parse(textBox17.Text);
            y = int.Parse(textBox15.Text);
            z = x - y;
            MessageBox.Show(kullaniciislemleri.HESAP_Guncelle(userid, textBox12.Text, textBox23.Text, textBox15.Text, textBox12.Text, textBox16.Text, Convert.ToInt32(label13.Text), Convert.ToInt32(textBox9.Text)));
            dataGridKayitGoster();
            textBox20.Text = "";
            textBox21.Text = "";
            textBox17.Text = "";
            textBox23.Text = "";
            textBox15.Text = "";
            textBox12.Text = "";
            textBox16.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
            baglan.Open();
            string sorgu = "select h.hesap_ıd,o.ad,o.soyad,h.ucret,h.taksıt,h.odenecek,h.kalan,h.durum from TB_HESAP H JOIN TB_OGRENCI O ON H.OGRENCI_ID=o.ogrencı_ıd WHERE  o.tc='" + textBox18.Text + "'";
            OracleCommand command = new OracleCommand(sorgu, baglan);
            OracleDataAdapter oda = new OracleDataAdapter(sorgu, baglan);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            textBox18.Text = "";
            baglan.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        }
    }

