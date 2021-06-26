using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rest
{
    public partial class MusteriEkleme : Form
    {
        public MusteriEkleme()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtTelefon.Text.Length>6)
            {
                if (txtMusteriAd.Text=="" || txtMusteriSoyad.Text=="")
                {
                    MessageBox.Show("Lütfen Müşterinin Ad ve Soyad bilgilerini doldurunuz.");
                }
                else
                {
                    cMusteriler c = new cMusteriler();
                    bool sonuc = c.MusteriVarmi(txtTelefon.Text);
                    if (!sonuc)
                    {
                        c.Musteriad = txtMusteriAd.Text;
                        c.Musterisoyad = txtMusteriSoyad.Text;
                        c.Telefon = txtTelefon.Text;
                        c.Email = txtEmail.Text;
                        c.Adres = txtAdres.Text;
                        txtMusteriNo.Text= c.musteriEkle(c).ToString();
                        if (txtMusteriNo.Text != "")
                        {
                            MessageBox.Show("Müşteri Eklendi");
                        }

                        else
                        {
                            MessageBox.Show("HATA Müşteri Eklenemedi!!!!!");
                        }
                    }

                    else
                    {
                        MessageBox.Show("Kayıt Zaten Var");
                    }
                }
            }

            else
            {
                MessageBox.Show("Lütfen en az 7 haneli bir telefon numarası girin.");
            }
        }

        private void MusteriEkleme_Load(object sender, EventArgs e)
        {
            if (cGenel._musteriId>0)
            {
                cMusteriler c = new cMusteriler();
                txtMusteriNo.Text = cGenel._musteriId.ToString();
                c.musterilerigetirID(Convert.ToInt32(txtMusteriNo.Text),txtMusteriAd,txtMusteriSoyad,txtTelefon,txtAdres,txtEmail);

            }
        }

        private void btnMusteriSec_Click(object sender, EventArgs e)
        {
            if (cGenel._musteriEkleme==0)
            {
                frmRezervasyon frm = new frmRezervasyon();
                cGenel._musteriEkleme = 1;
                this.Close();
                frm.Show();
            }
            else if(cGenel._musteriEkleme == 1)
            {
                frmPaketSiparis frm = new frmPaketSiparis();
                cGenel._musteriEkleme = 0;
                this.Close();
                frm.Show();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtTelefon.Text.Length > 6)
            {
                if (txtMusteriAd.Text == "" || txtMusteriSoyad.Text == "")
                {
                    MessageBox.Show("Lütfen Müşterinin Ad ve Soyad bilgilerini doldurunuz.");
                }

                else
                {
                    cMusteriler c = new cMusteriler();
                    c.Musteriad = txtMusteriAd.Text;
                    c.Musterisoyad = txtMusteriSoyad.Text;
                    c.Telefon = txtTelefon.Text;
                    c.Email = txtEmail.Text;
                    c.Adres = txtAdres.Text;
                    c.Musteriid = Convert.ToInt32(txtMusteriNo.Text);
                    bool sonuc=c.musteriBilgileriGuncelle(c);
                    if (sonuc)
                    {
                        
                        if (txtMusteriNo.Text != "")
                        {
                            MessageBox.Show("Müşteri Güncellendi");
                        }
                        else
                        {
                            MessageBox.Show("HATA Müşteri güncellenemedi!!!!!");
                        }
                    }

                    else
                    {
                        MessageBox.Show("Kayıt Zaten Var");
                    }
                }
            }

            else
            {
                MessageBox.Show("Lütfen en az 7 haneli bir telefon numarası girin.");
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            frmMusteriAra frm = new frmMusteriAra();
            this.Close();
            frm.Show();
        }

        public void DisableButton(int sayi)
        {
            if (sayi==1)
            {
                btnEkle.Visible = false;
            }

            else if (sayi==0)

            {
                btnEkle.Visible = true;
            }
        }

        public void VisibleButton(int sayi)
        {
            if (sayi==0)
            {
                btnGuncelle.Visible = true;
            }

            else if (sayi==1)

            {
                btnGuncelle.Visible = false;
            }

        }
    }
}
