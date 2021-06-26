using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rest
{
    class cUrunCesitleri
    {
        cGenel gnl = new cGenel();

        #region Fields
        private int _UrunTurNo;
        private string _KategoriAd;
        private string _Aciklama;
        #endregion

        #region Properties
        public int UrunTurNo
        {
            get
            {
                return _UrunTurNo;
            }

            set
            {
                _UrunTurNo = value;
            }
        }

        public string KategoriAd
        {
            get
            {
                return _KategoriAd;
            }

            set
            {
                _KategoriAd = value;
            }
        }

        public string Aciklama
        {
            get
            {
                return _Aciklama;
            }

            set
            {
                _Aciklama = value;
            }
        }
        #endregion

        public void getByProductTypes(ListView Cesitler, Button btn)
        {
            Cesitler.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select URUNAD,FIYAT,urunler.ID From kategoriler Inner Join urunler on kategoriler.ID=urunler.KATEGORIID where urunler.KATEGORIID=@KATEGORIID", con);

            string aa = btn.Name;
            int uzunluk = aa.Length;
            cmd.Parameters.Add("KATEGORIID", SqlDbType.Int).Value = aa.Substring(uzunluk - 1, 1);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                Cesitler.Items.Add(dr["URUNAD"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["FIYAT"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["ID"].ToString());
                i++;
            }
            dr.Close();
            con.Dispose();
            con.Close();
        }

        public void getByProductSearch(ListView Cesitler, int txt)
        {
            Cesitler.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from urunler where ID=@ID", con);

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = txt;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                Cesitler.Items.Add(dr["URUNAD"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["FIYAT"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["ID"].ToString());
                i++;
            }
            dr.Close();
            con.Dispose();
            con.Close();
        }

        //Ürün Çeşitlerini Getir Combobox
        public void urunCesitleriniGetir(ComboBox cb)
        {
            cb.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from kategoriler where Durum=0", con);
            SqlDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)

                    con.Open();

                dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    cUrunCesitleri uc = new cUrunCesitleri();
                    uc._UrunTurNo = Convert.ToInt32(dr["ID"]);
                    uc._KategoriAd = dr["KATEGORIADI"].ToString();
                    uc._Aciklama = dr["ACIKLAMA"].ToString();

                    cb.Items.Add(uc);
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;

            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }

        }

        //Ürün Çeşitlerini Getir ListView
        public void urunCesitleriniGetir(ListView lv)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from kategoriler where Durum=0", con);
            SqlDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)

                    con.Open();

                dr = cmd.ExecuteReader();

                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIADI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());

                    sayac++;
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;

            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }

        }

        //Ürün Çeşitlerini Getir ListView Arama
        public void urunCesitleriniGetir(ListView lv,string source)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from kategoriler where Durum=0 and KATEGORIADI like '&' + @source + '&' ", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@source", SqlDbType.VarChar).Value = source;

            try
            {
                if (con.State == ConnectionState.Closed)

                    con.Open();

                dr = cmd.ExecuteReader();

                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIADI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());

                    sayac++;
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;

            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }

        }

        //Ürün Çeşitleri Ekle
        public int urunKategoriEkle(cUrunCesitleri u)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into kategoriler(KATEGORIADI,ACIKLAMA) Values(@KATEGORIADI,@ACIKLAMA)", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@KATEGORIADI", SqlDbType.VarChar).Value = u.KategoriAd;
                cmd.Parameters.Add("@ACIKLAMA", SqlDbType.VarChar).Value = u.Aciklama;

                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());

            }
            catch (SqlException)
            {

                throw;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return sonuc;
        }

        //Ürün Çeşitleri  Güncelle
        public int urunKategoriGuncelle(cUrunCesitleri u)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update kategoriler set  KATEGORIADI=@KATEGORIADI,ACIKLAMA=@ACIKLAMA where ID=@KATID", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@KATEGORIADI", SqlDbType.VarChar).Value = u.KategoriAd;
                cmd.Parameters.Add("@ACIKLAMA", SqlDbType.VarChar).Value = u.Aciklama;
                cmd.Parameters.Add("@KATID", SqlDbType.Int).Value = u.UrunTurNo;

                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());

            }
            catch (SqlException)
            {

                throw;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return sonuc;
        }

        //Ürün Çeşitleri Sil
        public int urunKategoriSil(int id)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update kategoriler set  Durum=1 where ID=@KATID", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@KATID", SqlDbType.Int).Value = id;

                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());

            }
            catch (SqlException)
            {

                throw;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return sonuc;
        }

        public override string ToString()
        {
            return KategoriAd;
        }
    }
}
