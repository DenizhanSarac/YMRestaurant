﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rest
{
    class cAdisyon
    {
        cGenel gnl = new cGenel();

        #region Fields
        private int _ID;
        private int _ServisTurNo;
        private decimal _Tutar;
        private DateTime _Tarih;
        private int _PersonelId;
        private int _Durum;
        private int _MasaId; 
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

        public int ServisTurNo
        {
            get
            {
                return _ServisTurNo;
            }

            set
            {
                _ServisTurNo = value;
            }
        }

        public decimal Tutar
        {
            get
            {
                return _Tutar;
            }

            set
            {
                _Tutar = value;
            }
        }

        public DateTime Tarih
        {
            get
            {
                return _Tarih;
            }

            set
            {
                _Tarih = value;
            }
        }

        public int PersonelId
        {
            get
            {
                return _PersonelId;
            }

            set
            {
                _PersonelId = value;
            }
        }

        public int Durum
        {
            get
            {
                return _Durum;
            }

            set
            {
                _Durum = value;
            }
        }

        public int MasaId
        {
            get
            {
                return _MasaId;
            }

            set
            {
                _MasaId = value;
            }
        }
        #endregion

        public int getByAddition(int MasaId) {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select top 1 ID From Adisyonlar Where MASAID=@MasaId Order by ID desc", con);

            cmd.Parameters.Add("@MasaId", SqlDbType.Int).Value = MasaId;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                MasaId = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return MasaId;
        }

        public bool setByAdditionNew(cAdisyon Bilgiler)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Adisyonlar(SERVISTURNO,TARIH,PERSONELID,MASAID,Durum)values(@ServisTurNo,@Tarih,@PersonelID,@MasaId,@Durum)", con);
            try
            {
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@ServisTurNo", SqlDbType.Int).Value = Bilgiler.ServisTurNo;
                cmd.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = Bilgiler.Tarih;
                cmd.Parameters.Add("@PersonelID", SqlDbType.Int).Value = Bilgiler.PersonelId;
                cmd.Parameters.Add("@MasaId", SqlDbType.Int).Value = Bilgiler.MasaId;
                cmd.Parameters.Add("@Durum", SqlDbType.Bit).Value = 0;
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
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

            return sonuc;
            
        }
    }
}
