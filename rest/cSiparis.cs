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
    class cSiparis
    {
        cGenel gnl = new cGenel();
        #region Fields
        private int _Id;
        private int _adisyonID;
        private int _urunId;
        private int _adet;
        private int _masaId; 
        #endregion

        #region Properties
        public int Id
        {
            get
            {
                return _Id;
            }

            set
            {
                _Id = value;
            }
        }

        public int AdisyonID
        {
            get
            {
                return _adisyonID;
            }

            set
            {
                _adisyonID = value;
            }
        }

        public int UrunId
        {
            get
            {
                return _urunId;
            }

            set
            {
                _urunId = value;
            }
        }

        public int Adet
        {
            get
            {
                return _adet;
            }

            set
            {
                _adet = value;
            }
        }

        public int MasaId
        {
            get
            {
                return _masaId;
            }

            set
            {
                _masaId = value;
            }
        }
        #endregion

        //Siparişleri Getir
        public void getByOrder(ListView lv, int AdisyonId)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select URUNAD,FIYAT,satislar.ID,URUNID,satislar.ADET from satislar Inner Join urunler on satislar.URUNID=urunler.ID Where ADISYONID=@AdisyonId", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@AdisyonId", SqlDbType.Int).Value = AdisyonId;
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

                    lv.Items.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADET"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNID"].ToString());
                    lv.Items[sayac].SubItems.Add(Convert.ToString(Convert.ToDecimal(dr["FIYAT"]) * Convert.ToDecimal(dr["ADET"])));
                    lv.Items[sayac].SubItems.Add(dr["ID"].ToString());


                    sayac++;
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally {
                dr.Close();
                con.Dispose();
                con.Close();
            }
        }

        public bool setSaveOrder(cSiparis Bilgiler)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into satislar(ADISYONID,URUNID,ADET,MASAID) Values(@AdisyonNo,@UrunId,@Adet,@masaId)",con);
            try
            {
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@AdisyonNo", SqlDbType.Int).Value = Bilgiler._adisyonID;
                cmd.Parameters.Add("@UrunId", SqlDbType.Int).Value = Bilgiler._urunId;
                cmd.Parameters.Add("@Adet", SqlDbType.Int).Value = Bilgiler._adet;
                cmd.Parameters.Add("@masaId", SqlDbType.Int).Value = Bilgiler._masaId;
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());

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

        public void setDeleteOrder(int satisId) {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Delete From satislar Where ID=@SatisID", con);

            cmd.Parameters.Add("@SatisID", SqlDbType.Int).Value = satisId;
            if (con.State == ConnectionState.Closed) {
                con.Open();
            }
            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();
        }

        public decimal GenelToplamBul(int musteriId)
        {
            decimal geneltoplam = 0;
            /*SELECT SUM(dbo.satislar.ADET * dbo.urunler.FIYAT) AS fiyat FROM  dbo.musteriler  INNER JOIN "+
            "dbo.paketSiparis ON dbo.musteriler.ID = paketSiparis.MUSTERIID INNER JOIN adisyonlar on adisyonlar.ID=paketSiparis.ADISYONID inner join " +
            "dbo.satislar ON dbo.adisyonlar.ID = dbo.satislar.ADISYONID INNER JOIN dbo.urunler ON dbo.satislar.URUNID = dbo.urunler.ID WHERE" +
            "(dbo.paketSiparis.MUSTERIID = @musteriId) AND(dbo.paketSiparis.Durum = 0)*/
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select sum(TOPLAMTUTAR) from hesapOdemeleri where MUSTERIID=@musteriId", con);
            cmd.Parameters.Add("@musteriId", SqlDbType.Int).Value = musteriId;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                    geneltoplam = Convert.ToDecimal(cmd.ExecuteScalar()); 
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
            return geneltoplam;
        }

        public void adisyonpaketsiparisDetaylari(ListView lv,int adisyonID) {
            lv.Items.Clear();
            decimal geneltoplam = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select satislar.ID as satisID,urunler.URUNAD,urunler.FIYAT,satislar.ADET from satislar inner join adisyonlar on adisyonlar.ID=satislar.ADISYONID inner join urunler on urunler.ID=satislar.URUNID where satislar.ADISYONID=@adisyonID", con);
            cmd.Parameters.Add("@adisyonID", SqlDbType.Int).Value = adisyonID;
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                int i = 0;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lv.Items.Add(dr["satisID"].ToString());
                    lv.Items[i].SubItems.Add(dr["URUNAD"].ToString());
                    lv.Items[i].SubItems.Add(dr["ADET"].ToString());
                    lv.Items[i].SubItems.Add(dr["FIYAT"].ToString());
                    i++;
                }

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;

            }
            finally
            {
                con.Dispose();
                con.Close();
            }
        }
    }
}
