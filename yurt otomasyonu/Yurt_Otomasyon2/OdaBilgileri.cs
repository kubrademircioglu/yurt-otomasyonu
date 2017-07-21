using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
namespace Yurt_Otomasyon2
{
    public partial class OdaBilgileri : Form
    {
        public OdaBilgileri()
        {
            InitializeComponent();
        }
        OracleConnection baglan = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
       

        private void OdaBilgileri_Load(object sender, EventArgs e)
        {
            //baglan.Open();
            //string sorgu = "SELECT ODA_KAT,ODA_NUM,ODA_TİPİ,YATAK_NO,ODA_DURUMU FROM TB_ODA o INNER JOIN TB_ODATİPİ t ON o.ODATIPI_ID=t.ODATIPI_ID";
            //OracleDataAdapter oda = new OracleDataAdapter(sorgu, baglan);
            //DataSet ds = new DataSet();
            //oda.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0];
            //baglan.Close();
            baglan.Open();
            string sorgu = "SELECT * FROM TB_ODATİPİ";
            OracleDataAdapter oda = new OracleDataAdapter(sorgu, baglan);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglan.Close();

            string sorgu1 = "SELECT YATAK_NO FROM TB_ODATİPİ  ";
            OracleCommand command = new OracleCommand(sorgu1, baglan);
            OracleDataReader oku;
            baglan.Open();
            oku = command.ExecuteReader();

            while (oku.Read())
            { comboBox1.Items.Add(oku[0]); }
            baglan.Close();



            comboBox2.Items.Clear();
            string sorgu3 = "select ODA_NUM from  tb_oda  GROUP BY ODA_NUM";
            OracleCommand command3 = new OracleCommand(sorgu3, baglan);
            OracleDataReader oku3;
            baglan.Open();
            oku3 = command3.ExecuteReader();
            while (oku3.Read())
            { comboBox2.Items.Add(oku3[0]); }
            baglan.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            OracleCommand cmd = new OracleCommand("SELECT COUNT(ODA_DURUMU) FROM TB_ODATİPİ WHERE ODA_DURUMU='BOŞ'",baglan);
            textBox1.Text = cmd.ExecuteScalar().ToString();
            OracleCommand cmd1 = new OracleCommand("SELECT COUNT(ODA_DURUMU) FROM TB_ODATİPİ WHERE ODA_DURUMU='DOLU'", baglan);
            textBox2.Text = cmd1.ExecuteScalar().ToString();
            baglan.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string sorgu3 = "SELECT ODA_KAT,ODA_NUM,ODA_TİPİ,YATAK_NO,ODA_DURUMU FROM TB_ODA o INNER JOIN TB_ODATİPİ t ON o.ODATIPI_ID=t.ODATIPI_ID WHERE YATAK_NO='" + comboBox1.Text + "'";
            OracleCommand command = new OracleCommand(sorgu3, baglan);
            OracleDataAdapter oda = new OracleDataAdapter(sorgu3, baglan);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
          
            baglan.Close();
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string sorgu3 = "select ODA_TİPİ,ODA_NUM,YATAK_NO,ODA_DURUMU from TB_ODATİPİ t join tb_oda d on t.odatipi_id=d.odatipi_id  WHERE ODA_NUM='" + comboBox2.Text + "'";
            OracleCommand command = new OracleCommand(sorgu3, baglan);
            OracleDataAdapter oda = new OracleDataAdapter(sorgu3, baglan);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            baglan.Close();
        }
        KullaniciIslemleri kullaniciislemleri = new KullaniciIslemleri();

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public string userid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            

           

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
