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
            if (con.State==ConnectionState.Closed)
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
    }
}
