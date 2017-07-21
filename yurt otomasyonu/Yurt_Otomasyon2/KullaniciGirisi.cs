using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;

namespace Yurt_Otomasyon2
{
    class KullaniciGirisi
    {
        string username;


        private string kullaniciAdi
        {
            get { return this.kullaniciAdi; }
            set { this.kullaniciAdi = value; }
        }

        private string parola
        {
            get
            { return this.parola; }
            set { this.parola = value; }
        }
        public string tut;
        public string girisYap(string kullaniciAdi, string parola)
        {
            string sorgu = "SELECT * FROM TB_USERS WHERE USERNAME='" + kullaniciAdi + "' AND PASSWORD='" + parola + "'";

            OracleConnection connection = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");
            OracleCommand command = new OracleCommand(sorgu, connection);
            connection.Open();
            OracleDataReader reader = command.ExecuteReader();
            tut = kullaniciAdi;
            try
            {
                while (reader.Read())
                {

                    username = reader.GetValue(3).ToString();
                }
            }
            finally
            {
                reader.Close();
            }
           
            return username;

        }
    }
}
    

