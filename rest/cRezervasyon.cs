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
    class cRezervasyon
    {
        cGenel gnl = new cGenel();
        #region Fields
        private int _ID;
        private int _TableId;
        private int _ClientId;
        private DateTime _Date;
        private int _ClientCount;
        private string _Description;
        private int _AdditionId;
        #endregion

        #region Properties
        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }

        public int TableId
        {
            get
            {
                return _TableId;
            }

            set
            {
                _TableId = value;
            }
        }

        public int ClientId
        {
            get
            {
                return _ClientId;
            }

            set
            {
                _ClientId = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return _Date;
            }

            set
            {
                _Date = value;
            }
        }

        public int ClientCount
        {
            get
            {
                return _ClientCount;
            }

            set
            {
                _ClientCount = value;
            }
        }

        public string Description
        {
            get
            {
                return _Description;
            }

            set
            {
                _Description = value;
            }
        }

        public int AdditionId
        {
            get
            {
                return _AdditionId;
            }

            set
            {
                _AdditionId = value;
            }
        } 
        #endregion

        //MusteriId masa numarasına göre    
        public int getByClientIdFromRezervasyon(int tableId)
        {
            int clientId = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select top 1 MUSTERIID from Rezervasyonlar Where MASAID=@masaid order by MUSTERIID Desc", con);


            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@masaid", SqlDbType.Int).Value = tableId;
               

                clientId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                con.Dispose();
                con.Close();

            }

            return clientId;
        }

        //Hesap kapatırken rezervasyonlu masayı kapattık.
        public bool rezervationClose(int adisyonID)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update Rezervasyonlar set durum=1 where ADISYONID=@adisyonID", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@adisyonID", SqlDbType.Int).Value = adisyonID;
                result = Convert.ToBoolean(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return result;
        }

        //Rezervasyonları Getir
        public void musteriIdGetirFromRezervasyon(ListView lv)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Rezervasyonlar.MUSTERIID,(AD+SOYAD) as musteri from Rezervasyonlar INNER JOIN musteriler on Rezervasyonlar.MUSTERIID=musteriler.ID where Rezervasyonlar.Durum=0", con);
           
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                lv.Items.Add(dr["MUSTERIID"].ToString());
                lv.Items[i].SubItems.Add(dr["musteri"].ToString());
                i++;
            }
            dr.Close();
            con.Dispose();
            con.Close();
        }

        //Eski Rezervasyonları Getir
        public void eskiRezervasyonlariGetir(ListView lv,int mId)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Rezervasyonlar.MUSTERIID,AD,SOYAD,ADISYONID,TARIH from Rezervasyonlar INNER JOIN musteriler on Rezervasyonlar.MUSTERIID=musteriler.ID where Rezervasyonlar.MUSTERIID=@mId and Rezervasyonlar.Durum=0 order by Rezervasyonlar.ID Desc", con);

            cmd.Parameters.Add("mId",SqlDbType.Int).Value=mId;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                lv.Items.Add(dr["MUSTERIID"].ToString());
                lv.Items[i].SubItems.Add(dr["AD"].ToString());
                lv.Items[i].SubItems.Add(dr["SOYAD"].ToString());
                lv.Items[i].SubItems.Add(dr["TARIH"].ToString());
                lv.Items[i].SubItems.Add(dr["ADISYONID"].ToString());
                i++;
            }
            dr.Close();
            con.Dispose();
            con.Close();
        }

        //En Son Rezervasyon Tarihini Getir
        public DateTime EnsonRezervasyonTarihi(int mId)
        {
            DateTime tar = DateTime.Now;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select TARIH from Rezervasyonlar where Rezervasyonlar.MUSTERIID=@mId and Rezervasyonlar.Durum=1 order by Rezervasyonlar.ID Desc", con);

            cmd.Parameters.Add("mId", SqlDbType.Int).Value = mId;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            tar=Convert.ToDateTime( cmd.ExecuteScalar());
             
            con.Dispose();
            con.Close();

            return tar;  
        }

        //Açık Rezervasyonların Sayısını Getir
        public int acikRezervasyonSayisi()
        {
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);//Altta durumda hata alabilirsin dikkat et!!Yılmaz Not
            SqlCommand cmd = new SqlCommand("Select Count(*) from Rezervasyonlar where Rezervasyonlar.Durum=0", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {

                throw;
            }
            
            con.Dispose();
            con.Close();
            return sonuc;
        }

        //Rezervasyon Açıkmı Kontrol Ediyoruz
        public bool RezervasyonAcikmiKontrol(int mId)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select top 1 Rezervasyonlar.ID from Rezervasyonlar where MUSTERIID=@mID and durum=1 order by ID desc", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@mID", SqlDbType.Int).Value = mId;
                result = Convert.ToBoolean(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return result;
        }

        //Rezervasyon Aç
        public bool RezervasyonAc(cRezervasyon r)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Rezervasyonlar (MUSTERIID,MASAID,ADISYONID,KISISAYISI,TARIH,ACIKLAMA,DURUM) Values (@MUSTERIID,@MASAID,@ADISYONID,@KISISAYISI,@TARIH,@ACIKLAMA,1)", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@MUSTERIID", SqlDbType.Int).Value = r._ClientId;
                cmd.Parameters.Add("@MASAID", SqlDbType.Int).Value = r._TableId;
                cmd.Parameters.Add("@ADISYONID", SqlDbType.Int).Value = r._AdditionId;
                cmd.Parameters.Add("@KISISAYISI", SqlDbType.Int).Value = r._ClientCount;
                cmd.Parameters.Add("@TARIH", SqlDbType.Date).Value = r._Date;
                cmd.Parameters.Add("@ACIKLAMA", SqlDbType.VarChar).Value = r._Description;
                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return result;
        }

        //Rezerve Masanın Id'sini Getir.
        public int RezerveMasaIdGetir(int mId)
        {
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Rezervasyonlar.MASAID from Rezervasyonlar INNER JOIN adisyonlar on Rezervasyonlar.ADISYONID=adisyonlar.ID where (Rezervasyonlar.Durum=1) and (adisyonlar.Durum=0) and Rezervasyonlar.MUSTERIID=@mId", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                cmd.Parameters.Add("@mId", SqlDbType.Int).Value = mId;
                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {

                throw;
            }

            con.Dispose();
            con.Close();
            return sonuc;
        }


    }
}
