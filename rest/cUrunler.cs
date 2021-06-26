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
    class cUrunler
    {
        cGenel gnl = new cGenel();

        #region 
        private int _urunid;
        private int _urunturno;
        private string _urunad;
        private decimal _fiyat;
        private string _aciklama;
<<<<<<< HEAD
        #endregion 
=======
        #endregion
>>>>>>> 0633e52559559d0d1823dcfe5c82ab9be877ca14
        #region property

        public string Aciklama
        {
            get { return _aciklama; }
            set { _aciklama = value; }
        }

        public int Urunid
        {
            get { return _urunid; }
            set { _urunid = value; }
        }

        public string Urunad
        {
            get { return _urunad; }
            set { _urunad = value; }
        }

        public decimal Fiyat
        {
            get { return _fiyat; }
            set { _fiyat = value; }
        }

        public int Urunturno
        {
            get { return _urunturno; }
            set { _urunturno = value; }
        }
        #endregion

        //Ürün Adına Göre Listeleme...
        public void UrunleriListeleByUrunAdi(ListView lv, string urunadi)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from urunler Where Durum=0 and URUNAD like '&' + @urunAdi   + '&'", con);
<<<<<<< HEAD
            SqlDataReader dr = null; 
=======
            SqlDataReader dr = null;
>>>>>>> 0633e52559559d0d1823dcfe5c82ab9be877ca14

            cmd.Parameters.Add("@urunAdi", SqlDbType.VarChar).Value = urunadi;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();

                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());
                    lv.Items[sayac].SubItems.Add(string.Format("{0:0#00.0}", dr["FIYAT"].ToString()));
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

        //Ürün Ekleme...
        public int UrunEkle(cUrunler u)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into urunler(KATEGORIID,URUNAD,ACIKLAMA,FIYAT) Values(@KATEGORIID,@URUNAD,@ACIKLAMA,@FIYAT)", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@KATEGORIID", SqlDbType.VarChar).Value = u._urunturno;
                cmd.Parameters.Add("@URUNAD", SqlDbType.VarChar).Value = u._urunad;
                cmd.Parameters.Add("@ACIKLAMA", SqlDbType.VarChar).Value = u._aciklama;
                cmd.Parameters.Add("@FIYAT", SqlDbType.Money).Value = u._fiyat;

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

        //Ürünler ve Kategorileri Listele
        public void urunleriListele(ListView lv)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select urunler.*,KATEGORIADI from urunler inner join kategoriler on kategoriler.ID=urunler.KATEGORIID Where urunler.Durum=0", con);
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
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIADI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(string.Format("{0:0#00.0}", dr["FIYAT"].ToString()));
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
        //Urunleri Guncelle
        public int urunGuncelle(cUrunler u)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update urunler set  URUNAD=@urunad,KATEGORIID=@katID,ACIKLAMA=@aciklama,FIYAT=@fiyat where ID=@urunID", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@urunad", SqlDbType.VarChar).Value = u._urunad;
                cmd.Parameters.Add("@katID", SqlDbType.Int).Value = u._urunturno;
                cmd.Parameters.Add("@aciklama", SqlDbType.VarChar).Value = u._aciklama;
                cmd.Parameters.Add("@fiyat", SqlDbType.Money).Value = u._fiyat;
                cmd.Parameters.Add("@urunID ", SqlDbType.Int).Value = u._urunid;
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
        //Urunleri Sil yani sakla ....
        public int UrunSil(cUrunler u, int kat) 
        {
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);

            string sql = "update urunler set  Durum=1 where ";
            if (kat == 0)
            {
                sql += "KATEGORIID=@urunID";
            }
            else
            {
                sql += "ID=@urunID";
            }

            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@urunID ", SqlDbType.Int).Value = u._urunid;
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
        //Ürün ID Göre Listeleme...
        public void UrunleriListeleByUrunAdi(ListView lv, int urunId)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select urunler.*,KATEGORIADI from urunler inner join kategoriler on kategoriler.ID=urunler.KATEGORIID  Where urunler.Durum=0 and urunler.KATEGORIID=@urunID", con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("@urunID", SqlDbType.Int).Value = urunId;

            try
            {
                if (con.State == ConnectionState.Closed)

                    con.Open();

                dr = cmd.ExecuteReader();

                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIADI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(string.Format("{0:0#00.0}", dr["FIYAT"].ToString()));
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
        //Bütün ürünleri getirir 2 tarih arası
        public void urunleriListeleIstatistiklereGore(ListView lv, DateTimePicker Baslangic, DateTimePicker Bitis)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SELECT top 10 dbo.urunler.URUNAD,sum(dbo.satislar.ADET) as adeti FROM dbo.kategoriler INNER JOIN dbo.urunler ON " +
                "dbo.kategoriler.ID =dbo.urunler.KATEGORIID INNER JOIN dbo.satislar ON dbo.urunler.ID=dbo.satislar.URUNID INNER JOIN " +
                "dbo.adisyonlar ON dbo.satislar.ADISYONID=dbo.adisyonlar.ID WHERE(CONVERT(datetime,TARIH,104) BETWEEN CONVERT(datetime,@Baslangic,104)" +
                "AND CONVERT(datetime,@Bitis,104)) group by dbo.urunler.URUNAD order by adeti desc", con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("@Baslangic", SqlDbType.VarChar).Value = Baslangic.Value.ToShortDateString();
            cmd.Parameters.Add("@Bitis", SqlDbType.VarChar).Value = Bitis.Value.ToShortDateString();
            try
            {
                if (con.State == ConnectionState.Closed)

                    con.Open();

                dr = cmd.ExecuteReader();

                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["adeti"].ToString());
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
        //belli kategoriye göre ürünleri getirir.
        public void urunleriListeleIstatistiklereGoreUrunId(ListView lv, DateTimePicker Baslangic, DateTimePicker Bitis, int urunkatId)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SELECT top 10 dbo.urunler.URUNAD,sum(dbo.satislar.ADET) as adeti FROM dbo.kategoriler INNER JOIN dbo.urunler ON " +
                "dbo.kategoriler.ID =dbo.urunler.KATEGORIID INNER JOIN dbo.satislar ON dbo.urunler.ID=dbo.satislar.URUNID INNER JOIN " +
                "dbo.adisyonlar ON dbo.satislar.ADISYONID=dbo.adisyonlar.ID WHERE(CONVERT(datetime,TARIH,104) BETWEEN CONVERT(datetime,@Baslangic,104)" +
                "AND CONVERT(datetime,@Bitis,104)) and (dbo.urunler.KATEGORIID=@katId) group by dbo.urunler.URUNAD order by adeti desc", con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("@Baslangic", SqlDbType.VarChar).Value = Baslangic.Value.ToShortDateString();
            cmd.Parameters.Add("@Bitis", SqlDbType.VarChar).Value = Bitis.Value.ToShortDateString();
            cmd.Parameters.Add("@katId", SqlDbType.Int).Value = urunkatId;
            try
            {
                if (con.State == ConnectionState.Closed)

                    con.Open();

                dr = cmd.ExecuteReader();

                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["adeti"].ToString());
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



    }
}
