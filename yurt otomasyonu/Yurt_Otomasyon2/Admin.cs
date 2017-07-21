using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Yurt_Otomasyon2
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        Personel personel = new Personel();
        Ogrenci ogrenci = new Ogrenci();
        Kullanici kullanici = new Kullanici();
        OdaBilgileri odaBilgileri = new OdaBilgileri();
        

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            personel.Show();
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kullanici.Show();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ogrenci.Show(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            odaBilgileri.Show();
        }
        izin izin = new izin();
        private void button5_Click(object sender, EventArgs e)
        {
            izin.Show();

        }
        Hesap hesap = new Hesap();
        private void button6_Click(object sender, EventArgs e)
        {
            hesap.Show();

        }
        Form2 f = new Form2();
        
        private void button7_Click(object sender, EventArgs e)
        {
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
