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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        KullaniciGirisi kullanicigirisi = new KullaniciGirisi();
         Admin admin = new Admin();
         public static string id;
        
        private void button1_Click(object sender, EventArgs e)
         {
             id = textBox1.Text;



         string sonuc = kullanicigirisi.girisYap(textBox1.Text,textBox2.Text);

             
            if (sonuc == "Admin")
            {
                admin.Show();
                this.Hide();
             
               


            }
            else if (sonuc == "MEMUR")
            {
                admin.Show();
                admin.button1.Visible = false;
                admin.button2.Visible = false;

              

            }
          
            else
            {
                MessageBox.Show("Yanlış Kullanıcı Adi veya Şifre Girişi...");
               textBox1.Text = "";
               textBox2.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "GULAY";
            textBox2.Text = "12345";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        }
    }

