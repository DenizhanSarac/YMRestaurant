using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace rest
<<<<<<< HEAD
{ 
=======
{
>>>>>>> 0633e52559559d0d1823dcfe5c82ab9be877ca14
    class cPaketler
    {
        cGenel gnl = new cGenel();
        #region MyRegion
        private int _ID;
        private int _AdditionID;
        private int _CilentId;
        private string _Description;
        private int _State;
        private int _Paytypeid; 
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

        public int AdditionID
        {
            get
            {
                return _AdditionID;
            }

            set
            {
                _AdditionID = value;
            }
        }

        public int CilentId
        {
            get
            {
                return _CilentId;
            }

            set
            {
                _CilentId = value;
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

        public int State
        {
            get
            {
                return _State;
            }

            set
            {
                _State = value;
            }
        }

        public int Paytypeid
        {
            get
            {
                return _Paytypeid;
            }

            set
            {
                _Paytypeid = value;
            }
        }
<<<<<<< HEAD
        #endregion 
=======
        #endregion
>>>>>>> 0633e52559559d0d1823dcfe5c82ab9be877ca14
        //paket açma
        public bool OrderSeriveceOpen(cPaketler order)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert into paketSiparis(ADISYONID,MUSTERIID,ODEMETURID,ACIKLAMA) values(@ADISYONID,@MUSTERIID,@ODEMETURID,@ACIKLAMA)", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@ADISYONID", SqlDbType.Int).Value = order._AdditionID;
                cmd.Parameters.Add("@MUSTERIID", SqlDbType.Int).Value = order._CilentId;
                cmd.Parameters.Add("@ODEMETURID", SqlDbType.Int).Value = order._Paytypeid;
                cmd.Parameters.Add("@ACIKLAMA", SqlDbType.VarChar).Value = order._Description;
                result = Convert.ToBoolean(cmd.ExecuteNonQuery());

            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }
            finally {
                con.Dispose();
                con.Close();


            }
            return result;

        }
        //paket kapama
        public void OrderSeriveceClose(int AdditionID)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update paketSiparis set paketSiparis.Durum=1 where paketSiparis.ADISYONID=@AdditionID", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@AdditionID", SqlDbType.Int).Value = AdditionID;
                
                Convert.ToBoolean(cmd.ExecuteNonQuery());

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
        //açılan adisyon ve paket siparis için ön girilen ödeme türü
        public int OdemeTurIdGetir(int adisyonId)
        {
            int odemeTurID = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select paketSiparis.ODEMETURID as odeme from paketSiparis inner join adisyonlar on paketSiparis.ADISYONID=adisyonlar.ID where adisyonlar.ID=@AdisyonID", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@adisyonId", SqlDbType.Int).Value = adisyonId;
                odemeTurID = Convert.ToInt32(cmd.ExecuteScalar());

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

            return odemeTurID;
        }
        //siparis kontrol için müşteriye ait açık olan son adisyon nosunu getirme
        //iki adisyon açamaz
        public int musteriSonAdisyonIDGetir(int musteriID)
        {
            int no = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select adisyonlar.ID from adisyonlar inner join paketSiparis on paketSiparis.ADISYONID=adisyonlar.ID where (adisyonlar.Durum=0) and (paketSiparis.Durum=0) and paketSiparis.MUSTERIID=@musteriID", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@musteriID", SqlDbType.Int).Value = musteriID;
                no = Convert.ToInt32(cmd.ExecuteScalar());

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

            return no;
        }
        //müşteri arama ekranında adisyonbul butonu adisyon açık mı değil i kontrol
        public bool getCheckOpenAdditionID(int additionID)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from adisyonlar where (Durum=0) and (ID=@additionID)", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@additionID", SqlDbType.Int).Value = additionID;
                result = Convert.ToBoolean(cmd.ExecuteScalar());

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
            return result;

        }
    }
}
