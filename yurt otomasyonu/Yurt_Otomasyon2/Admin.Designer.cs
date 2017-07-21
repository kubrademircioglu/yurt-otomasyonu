namespace Yurt_Otomasyon2
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(273, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 90);
            this.button1.TabIndex = 0;
            this.button1.Text = "PERSONEL İŞLEMLEMLERİ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Info;
            this.button2.Location = new System.Drawing.Point(535, 146);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(185, 90);
            this.button2.TabIndex = 1;
            this.button2.Text = "KULLANICI İŞLEMLERİ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(273, 299);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(185, 90);
            this.button3.TabIndex = 2;
            this.button3.Text = "ÖĞRENCİ İŞLEMLERİ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Maroon;
            this.button4.Location = new System.Drawing.Point(535, 299);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(185, 90);
            this.button4.TabIndex = 3;
            this.button4.Text = "ODA BİLGİLERİ";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(273, 481);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(185, 90);
            this.button5.TabIndex = 4;
            this.button5.Text = "İZİN";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(556, 481);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(185, 90);
            this.button6.TabIndex = 5;
            this.button6.Text = "HESAP";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button7.Location = new System.Drawing.Point(273, 25);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(185, 82);
            this.button7.TabIndex = 6;
            this.button7.Text = "BACKUP";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(535, 25);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(176, 82);
            this.button8.TabIndex = 7;
            this.button8.Text = "ÇIKIŞ";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BackgroundImage = global::Yurt_Otomasyon2.Properties.Resources.Litterbox;
            this.ClientSize = new System.Drawing.Size(1027, 651);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Admin";
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.Admin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;

    }
}