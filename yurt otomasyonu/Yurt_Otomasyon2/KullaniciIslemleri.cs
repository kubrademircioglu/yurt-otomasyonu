using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Yurt_Otomasyon2
{
    class KullaniciIslemleri
    {
        public string KayitEkle(string ad, string soyad, string yas,int persid)
        {

            string sonuc = "";
            try
            {
                OracleConnection connect = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");

                OracleCommand command = new OracleCommand("PROC_KULLANICI_EKLE", connect);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@P_USERNAME", OracleDbType.Varchar2, 20).Value = ad;
                command.Parameters.Add("@P_PASSWORD", OracleDbType.Varchar2, 20).Value = soyad;
                command.Parameters.Add("@P_YETKI_TURU", OracleDbType.Varchar2, 20).Value = yas;
                command.Parameters.Add("@P_PERSONEL_ID", OracleDbType.Int32).Value = persid;



                connect.Open();
                command.ExecuteNonQuery();
                connect.Close();

                sonuc = "Kayıt Başarılı";
            }


            catch (Exception )
            {
                sonuc = "Kayıt Hatalı";

            }


            return sonuc;

        }
        public string HESAP_Ekle(string ucret, string taksit, string odenecek, string kalan,string durum,int ogr,int persid)
        {

            string sonuc = "";
            try
            {
                OracleConnection connect = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");

                OracleCommand command = new OracleCommand("PROC_HESAP_EKLE", connect);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@P_UCRET", OracleDbType.Varchar2, 20).Value = ucret;
                command.Parameters.Add("@P_TAKSIT", OracleDbType.Varchar2, 20).Value = taksit;
                command.Parameters.Add("@P_ODENECEK", OracleDbType.Varchar2, 20).Value = odenecek;
                command.Parameters.Add("@P_KALAN", OracleDbType.Varchar2,20).Value = kalan;
                command.Parameters.Add("@P_DURUM", OracleDbType.Varchar2, 20).Value = durum;
                command.Parameters.Add("@P_OGRENCI", OracleDbType.Int32).Value = ogr;
                command.Parameters.Add("@P_PERSONEL", OracleDbType.Int32).Value = persid;

                connect.Open();
                command.ExecuteNonQuery();
                connect.Close();

                sonuc = "Kayıt Başarılı";
            }


            catch (Exception)
            {
                sonuc = "Kayıt Hatalı";

            }


            return sonuc;

        }

        public string Kayit(string ad, string soyad, string yas, string cinsiyet, string tc, string tel, string email, string adres, string gorev, string maas)
        {

            string sonuc="";
            try
            {
                OracleConnection connect = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");

                OracleCommand command = new OracleCommand("PROC_PERSONEL_EKLE", connect);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@P_AD", OracleDbType.Varchar2, 20).Value = ad;
                command.Parameters.Add("@P_SOYAD", OracleDbType.Varchar2, 20).Value = soyad;
                command.Parameters.Add("@P_YAS", OracleDbType.Varchar2, 20).Value = yas;
                command.Parameters.Add("@P_CD", OracleDbType.Varchar2, 20).Value = cinsiyet;
                command.Parameters.Add("@P_TC", OracleDbType.Varchar2, 20).Value = tc;
                command.Parameters.Add("@P_TEL", OracleDbType.Varchar2,20).Value = tel;
                command.Parameters.Add("@P_EMAIL", OracleDbType.Varchar2, 20).Value = email;
                command.Parameters.Add("@P_ADRES", OracleDbType.Varchar2, 20).Value = adres;
                command.Parameters.Add("@P_GOREV", OracleDbType.Varchar2, 20).Value = gorev;
                command.Parameters.Add("@P_MAAS", OracleDbType.Varchar2, 20).Value = maas;

                connect.Open();
                command.ExecuteNonQuery();
                connect.Close();

                sonuc = "Kayıt Başarılı";
            }


            catch (Exception )
            {
                sonuc = "Kayıt Hatalı";

            }


            return sonuc;

        }

        public string IZIN_EKLE(string bas,string bitis,string adres,int ogrenci)
        {

            string sonuc = "";
            try
            {
                OracleConnection connect = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");

                OracleCommand command = new OracleCommand("PROC_IZIN_EKLE ", connect);

                command.CommandType = CommandType.StoredProcedure;
                
                command.Parameters.Add("@P_BASLANGIC", OracleDbType.Varchar2,20).Value = bas;
                command.Parameters.Add("@P_BITIS", OracleDbType.Varchar2,20).Value = bitis;
                command.Parameters.Add("@P_ADRES", OracleDbType.Varchar2, 20).Value = adres;
                command.Parameters.Add("@P_OGRENCI", OracleDbType.Int32).Value = ogrenci;
             

                connect.Open();
                command.ExecuteNonQuery();
                connect.Close();

                sonuc = "Kayıt Başarılı";
            }


            catch (Exception)
            {
                sonuc = "Kayıt Hatalı";

            }


            return sonuc;

        }



        public string OgrenciEkle(string ad, string soyad, string yas, string tc, string tel, string email, string adres, string okul, string bolum,int oda)
        {

            string sonuc = "";
            try
            {
                OracleConnection connect = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");

                OracleCommand command = new OracleCommand("PROC_OGRENCI_EKLE", connect);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@P_AD", OracleDbType.Varchar2, 20).Value = ad;
                command.Parameters.Add("@P_SOYAD", OracleDbType.Varchar2, 20).Value = soyad;
                command.Parameters.Add("@P_YAS", OracleDbType.Varchar2, 20).Value = yas;
                command.Parameters.Add("@P_TC", OracleDbType.Varchar2, 20).Value = tc;
                command.Parameters.Add("@P_TEL", OracleDbType.Varchar2,20).Value = tel;
                command.Parameters.Add("@P_EMAIL", OracleDbType.Varchar2, 20).Value = email;
                command.Parameters.Add("@P_ADRES", OracleDbType.Varchar2, 20).Value = adres;
                command.Parameters.Add("@P_OKUL", OracleDbType.Varchar2, 20).Value = okul;
                command.Parameters.Add("@P_BOLUM", OracleDbType.Varchar2, 20).Value = bolum;
                command.Parameters.Add("@P_ODA", OracleDbType.Int32).Value = oda;
                connect.Open();
                command.ExecuteNonQuery();
                connect.Close();

                sonuc = "Kayıt Başarılı";
            }


            catch (Exception)
            {
                sonuc = "Kayıt Hatalı";

            }


            return sonuc;

        }
        public string OgrenciGuncelle(int userid,string ad, string soyad, string yas, string tc, string tel, string email, string adres, string okul, string bolum, int oda)
        {

            string sonuc = "";
            try
            {
                OracleConnection connect = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");

                OracleCommand command = new OracleCommand("PROC_OGRENCI_GUNCELLE", connect);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@P_USER_ID", OracleDbType.Varchar2, 20).Value = userid;
                command.Parameters.Add("@P_AD", OracleDbType.Varchar2, 20).Value = ad;
                command.Parameters.Add("@P_SOYAD", OracleDbType.Varchar2, 20).Value = soyad;
                command.Parameters.Add("@P_YAS", OracleDbType.Varchar2, 20).Value = yas;
                command.Parameters.Add("@P_TC", OracleDbType.Varchar2, 20).Value = tc;
                command.Parameters.Add("@P_TEL", OracleDbType.Varchar2, 20).Value = tel;
                command.Parameters.Add("@P_EMAIL", OracleDbType.Varchar2, 20).Value = email;
                command.Parameters.Add("@P_ADRES", OracleDbType.Varchar2, 20).Value = adres;
                command.Parameters.Add("@P_OKUL", OracleDbType.Varchar2, 20).Value = okul;
                command.Parameters.Add("@P_BOLUM", OracleDbType.Varchar2, 20).Value = bolum;
                command.Parameters.Add("@P_ODA", OracleDbType.Int32).Value = oda;
                connect.Open();
                command.ExecuteNonQuery();
                connect.Close();

                sonuc = "Güncelleme Başarılı";
            }


            catch (Exception)
            {
                sonuc = "Güncelleme Hatalı";

            }


            return sonuc;

        }
        public string HESAP_Guncelle(int userid, string ucret, string taksit, string odenecek, string kalan, string durum, int ogr, int persid)
        {

            string sonuc = "";
            try
            {
                OracleConnection connect = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");

                OracleCommand command = new OracleCommand("PROC_HESAP_GUNCELLE", connect);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@P_USER_ID", OracleDbType.Varchar2, 20).Value = userid;
                command.Parameters.Add("@P_UCRET", OracleDbType.Varchar2, 20).Value = ucret;
                command.Parameters.Add("@P_TAKSIT", OracleDbType.Varchar2, 20).Value = taksit;
                command.Parameters.Add("@P_ODENECEK", OracleDbType.Varchar2, 20).Value = odenecek;
                command.Parameters.Add("@P_KALAN", OracleDbType.Varchar2, 20).Value = kalan;
                command.Parameters.Add("@P_DURUM", OracleDbType.Varchar2, 20).Value = durum;
                command.Parameters.Add("@P_OGRENCI", OracleDbType.Int32).Value = ogr;
                command.Parameters.Add("@P_PERSONEL", OracleDbType.Int32).Value = persid;
                connect.Open();
                command.ExecuteNonQuery();
                connect.Close();

                sonuc = "Güncelleme Başarılı";
            }


            catch (Exception)
            {
                sonuc = "Güncelleme Hatalı";

            }


            return sonuc;

        }
        public string KayitSil(int userid)
        {
            string sonuc;

            OracleConnection connect = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");

            OracleCommand command = new OracleCommand("PROC_KULLANICI_SIL", connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@P_USER_ID", OracleDbType.Varchar2, 20).Value = userid;

            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
            sonuc = "Silme İşlemi Başarılı";



            return sonuc;
        }
        


        public string Guncelle(int userid, string username, string password,string tip)
        {
            string sonuc;
            try
            {
                OracleConnection connect = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");

                OracleCommand command = new OracleCommand("PROC_KULLANICI_GUNCELLE", connect);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@P_USER_ID", OracleDbType.Varchar2, 20).Value = userid;
                command.Parameters.Add("@P_USERNAME", OracleDbType.Varchar2, 20).Value = username;
                command.Parameters.Add("@P_PASSWORD", OracleDbType.Varchar2, 20).Value = password;
                command.Parameters.Add("@P_TYPE", OracleDbType.Varchar2, 20).Value = tip;
                connect.Open();
                command.ExecuteNonQuery();
                connect.Close();
                sonuc = "Güncelleme Başarılı";
            }
            catch (Exception )
            {
                sonuc = "Güncelleme Hatalı";
            }
            return sonuc;

        }

        public string KayitGuncelle(int userid, string ad, string soyad, string yas, string cinsiyet, string tc,string tel, string email, string adres, string gorev, string maas)
        {
            string sonuc;
            try
            {
                OracleConnection connect = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");

                OracleCommand command = new OracleCommand("PROC_PERSONEL_GUNCELLE", connect);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@P_USER_ID", OracleDbType.Varchar2, 20).Value = userid;
                command.Parameters.Add("@P_AD", OracleDbType.Varchar2, 20).Value = ad;
                command.Parameters.Add("@P_SOYAD", OracleDbType.Varchar2, 20).Value = soyad;
                command.Parameters.Add("@P_YAS", OracleDbType.Varchar2, 20).Value = yas;
                command.Parameters.Add("@P_CD", OracleDbType.Varchar2, 20).Value = cinsiyet;
                command.Parameters.Add("@P_TC", OracleDbType.Varchar2, 20).Value = tc;
                command.Parameters.Add("@P_TEL", OracleDbType.Varchar2,20).Value = tel;
                command.Parameters.Add("@P_EMAIL", OracleDbType.Varchar2, 20).Value = email;
                command.Parameters.Add("@P_ADRES", OracleDbType.Varchar2, 20).Value = adres;
                command.Parameters.Add("@P_GOREV", OracleDbType.Varchar2, 20).Value = gorev;
                command.Parameters.Add("@P_MAAS", OracleDbType.Varchar2, 20).Value = maas;


                connect.Open();
                command.ExecuteNonQuery();
                connect.Close();
                sonuc = "Güncelleme Başarılı";
            }
            catch (Exception )
            {
                sonuc = "Güncelleme Hatalı";
            }
            return sonuc;

        }
        public string IZINGuncelle(int userid, string baslangic, string bitis, string adres,int ogr)
        {
            string sonuc;
            try
            {
                OracleConnection connect = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");

                OracleCommand command = new OracleCommand("PROC_IZIN_GUNCELLE", connect);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@P_USER_ID", OracleDbType.Varchar2, 20).Value = userid;
                command.Parameters.Add("@P_BASLANGIC", OracleDbType.Varchar2, 20).Value = baslangic;
                command.Parameters.Add("@P_BITIS", OracleDbType.Varchar2, 20).Value = bitis;
                command.Parameters.Add("@P_ADRES", OracleDbType.Varchar2, 20).Value = adres;
                command.Parameters.Add("@P_OGRENCI", OracleDbType.Int32).Value = ogr;



                connect.Open();
                command.ExecuteNonQuery();
                connect.Close();
                sonuc = "Güncelleme Başarılı";
            }
            catch (Exception)
            {
                sonuc = "Güncelleme Hatalı";
            }
            return sonuc;

        }


        public string Sil(int userid)
        {
            string sonuc;

            OracleConnection connect = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");

            OracleCommand command = new OracleCommand("PROC_PERSONEL_SIL", connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@P_USER_ID", OracleDbType.Varchar2, 20).Value = userid;

            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
            sonuc = "Silme İşlemi Başarılı";



            return sonuc;
        }
        public string IZIN_Sil(int userid)
        {
            string sonuc;

            OracleConnection connect = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");

            OracleCommand command = new OracleCommand("PROC_IZIN_SIL", connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@P_USER_ID", OracleDbType.Int32).Value = userid;

            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
            sonuc = "Silme İşlemi Başarılı";



            return sonuc;
        }
        public string OgrenciSil(int userid)
        {
            string sonuc;

            OracleConnection connect = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");

            OracleCommand command = new OracleCommand("PROC_OGRENCI_SIL", connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@P_USER_ID", OracleDbType.Varchar2, 20).Value = userid;

            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
            sonuc = "Silme İşlemi Başarılı";



            return sonuc;
        }
        public void  Oda_guncelle(int userid)
        {
            

            OracleConnection connect = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");

            OracleCommand command = new OracleCommand("PROC_ODA_DURUMU_GUNCELLE", connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@P_USER_ID", OracleDbType.Int32).Value = userid;

            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();                    
        }
       
        public OracleConnection connect = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");

        public void Ara(string ad)
        {

           

            
        }
        public void Oda_ters(int userid)
        {


            OracleConnection connect = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));uSER id=system;password=23072015Og;");

            OracleCommand command = new OracleCommand(" PROC_ODA_GUNCELLE", connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@P_USER_ID", OracleDbType.Int32).Value = userid;

            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();


        }





        
    }
}
