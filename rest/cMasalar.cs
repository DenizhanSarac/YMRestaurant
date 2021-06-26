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
    class cMasalar
    {
        #region Fields
        private int _ID;
        private int _KAPASITE;
        private int _SERVISTURU;
        private int _DURUM;
        private int _ONAY;
        private string _MasaBilgi;
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

        public int KAPASITE
        {
            get
            {
                return _KAPASITE;
            }

            set
            {
                _KAPASITE = value;
            }
        }

        public int SERVISTURU
        {
            get
            {
                return _SERVISTURU;
            }

            set
            {
                _SERVISTURU = value;
            }
        }

        public int DURUM
        {
            get
            {
                return _DURUM;
            }

            set
            {
                _DURUM = value;
            }
        }

        public int ONAY
        {
            get
            {
                return _ONAY;
            }

            set
            {
                _ONAY = value;
            }
        }

        public string MasaBilgi
        {
            get
            {
                return _MasaBilgi;
            }

            set
            {
                _MasaBilgi = value;
            }
        }
        #endregion

        cGenel gnl = new cGenel();
        public string SessionSum(int state,string masaId) {
            string dt = "";
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select TARIH,MASAID From adisyonlar Right Join masalar on adisyonlar.MASAID=masalar.ID Where masalar.DURUM=@durum and adisyonlar.Durum=0 and masalar.ID=@masaId", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@durum", SqlDbType.Int).Value = state;
            cmd.Parameters.Add("@masaId",SqlDbType.Int).Value = Convert.ToInt32(masaId);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dt = Convert.ToDateTime(dr["TARIH"]).ToString();
                }

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally {
                dr.Close();
                con.Dispose();
                con.Close();
            }
            return dt;

        }

        public int TableGetbyNumber(string TableValue) {
            string aa = TableValue;
            int length = aa.Length;

            if (length > 8)
            {
                return Convert.ToInt32(aa.Substring(length - 2, 2));
            }
            else
            {
                return Convert.ToInt32(aa.Substring(length - 1, 1));
            }

            

        }

        public bool TableGetbyState(int ButtonName,int state)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select DURUM from masalar Where ID=@TableId and DURUM=@state", con);

            cmd.Parameters.Add("@TableId", SqlDbType.Int).Value = ButtonName;
            cmd.Parameters.Add("@state", SqlDbType.Int).Value = state;
            try
            {
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
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

        public void setChangeTableState(string ButonName,int state)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update Masalar Set DURUM=@Durum Where ID=@MasaNo", con);
            string masaNo = "";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            string aa = ButonName;
            int uzunuluk = aa.Length;
            cmd.Parameters.Add("@Durum", SqlDbType.Int).Value = state;
            if (uzunuluk>8)
            {
                masaNo = aa.Substring(uzunuluk - 2, 2);
            }
            else
            {
                masaNo = aa.Substring(uzunuluk - 1, 1);
            }
            
            cmd.Parameters.Add("@MasaNo", SqlDbType.Int).Value = aa.Substring(uzunuluk - 1, 1);
            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();
        }

        public void MasaKapasitesiVeDurumuGetir(ComboBox cm)
        {
            cm.Items.Clear();
            string durum = "";

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from masalar", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cMasalar c = new cMasalar();
                if (c._DURUM ==2)
                {
                    durum = "DOLU";
                }
                else if (c._DURUM ==3)
                {
                    durum = "REZERVE";
                }
                c._KAPASITE = Convert.ToInt32(dr["KAPASITE"]);
                c._MasaBilgi = "Masa No: " + dr["ID"].ToString() + " Kapasitesi:  " + dr["KAPASITE"].ToString();
                c._ID = Convert.ToInt32(dr["ID"]);
                cm.Items.Add(c);
            }

            dr.Close();
            con.Dispose();
            con.Close();
        }

        public override string ToString()
        {
            return MasaBilgi;
        }

    }
}
