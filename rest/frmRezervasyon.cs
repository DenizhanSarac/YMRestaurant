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
    public partial class frmRezervasyon : Form
    {
        public frmRezervasyon()
        {
            InitializeComponent();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinizden emin misiniz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            this.Close();
            frm.Show();
        }

        private void frmRezervasyon_Load(object sender, EventArgs e)
        {
            cMusteriler m = new cMusteriler();
            m.musterileriGetir(lvMusteriler);
            

            cMasalar masa = new cMasalar();
            masa.MasaKapasitesiVeDurumuGetir(cbMasa);

            dtTarih.MinDate = DateTime.Today;
            dtTarih.Format = DateTimePickerFormat.Time;
        }

        private void txtMusteriAd_TextChanged(object sender, EventArgs e)
        {
            cMusteriler m = new cMusteriler();
            m.musterigetirAd(lvMusteriler, txtMusteriAd.Text);
        }

        private void txtTelefon_TextChanged(object sender, EventArgs e)
        {
            cMusteriler m = new cMusteriler();
            m.musterigetirTlf(lvMusteriler, txtTelefon.Text);
        }

        void temizle()
        {
            txtAdres.Clear();
            txtKisiSayisi.Clear();
            txtMasa.Clear();
            txtTarih.Clear();
            txtAciklama.Clear();

        }

        private void btnRezervasyonAc_Click(object sender, EventArgs e)
        {
            cRezervasyon r = new cRezervasyon();

            if (lvMusteriler.SelectedItems.Count > 0)
            {
                bool sonuc = r.RezervasyonAcikmiKontrol(Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text));
                if (!sonuc)
                {
                    if (txtTarih.Text != "")
                    {
                        if (txtKisiSayisi.Text != "")
                        {
                            cMasalar masa = new cMasalar();
                            if (masa.TableGetbyState(Convert.ToInt32(txtMasaNo.Text), 1))
                            {
                                cAdisyon a = new cAdisyon();
                                a.Tarih = Convert.ToDateTime(txtTarih.Text);
                                a.ServisTurNo = 1;
                                a.MasaId = Convert.ToInt32(txtMasaNo.Text);
                                a.PersonelId = cGenel._personelId;

                                r.ClientId = Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text);
                                r.TableId = Convert.ToInt32(txtMasaNo.Text);
                                r.Date = Convert.ToDateTime(txtTarih.Text);
                                r.ClientCount = Convert.ToInt32(txtKisiSayisi.Text);
                                r.Description = txtAciklama.Text;

                                r.AdditionId = a.RezervasyonAdisyonAc(a);
                                sonuc = r.RezervasyonAc(r);

                                masa.setChangeTableState(txtMasaNo.Text, 3);

                                if (sonuc)
                                {
                                    MessageBox.Show("Rezervasyon Başarıyla Açılmıştır");
                                    temizle();
                                }
                                else
                                {
                                    MessageBox.Show("Rezervasyon Kaydı Gerçekleştirilemedi, Lütfen yetkiliyle iletişime Geçinn");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Rezervasyon Yapılan Masa Şuan Dolu");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Lütfen Kişi Sayısı Seçiniz");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Bir Tarih Seçiniz");
                    }
                }
                else
                {
                    MessageBox.Show("Bu müşteri üzerine açık bir rezervasyon bulunmaktadır.");
                }
            }
        }

        private void dtTarih_MouseEnter(object sender, EventArgs e)
        {
            //dtTarih.Width = 200;
        }

        private void dtTarih_Enter(object sender, EventArgs e)
        {
            //dtTarih.Width = 200; 
        }

        private void dtTarih_MouseLeave(object sender, EventArgs e)
        {
            //dtTarih.Width = 23;
        }

        private void dtTarih_ValueChanged(object sender, EventArgs e)
        {
            txtTarih.Text = dtTarih.Value.ToString();
        }

        private void cbMasa_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbKisiSayisi.Enabled = true;
            txtMasa.Text = cbMasa.SelectedItem.ToString();

            cMasalar Kapasitesi = (cMasalar)cbMasa.SelectedItem;
            int kapasite = Kapasitesi.KAPASITE;
            txtMasaNo.Text = Convert.ToString(Kapasitesi.ID);

            cbKisiSayisi.Items.Clear();
            for (int i = 0; i < kapasite; i++)
            {
                cbKisiSayisi.Items.Add(i + 1);
            }
        }

        private void cbKisiSayisi_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKisiSayisi.Text = cbKisiSayisi.SelectedItem.ToString();
        }

        private void cbMasa_MouseEnter(object sender, EventArgs e)
        {
            //cbMasa.Width = 305;
        }

        private void cbMasa_MouseLeave(object sender, EventArgs e)
        {
            //cbMasa.Width = 23;
        }

        private void cbKisiSayisi_MouseLeave(object sender, EventArgs e)
        {
            //cbKisiSayisi.Width = 23;    
        }

        private void cbKisiSayisi_MouseEnter(object sender, EventArgs e)
        {
            //cbKisiSayisi.Width = 100;
        }

        private void btnRezervasyonlar_Click(object sender, EventArgs e)
        {
            frmSiparisKontrol frm = new frmSiparisKontrol();
            this.Close();
            frm.Show();
        }

        private void btnYeniMusteri_Click(object sender, EventArgs e)
        {
            MusteriEkleme frm = new MusteriEkleme();
            cGenel._musteriEkleme = 0;
            frm.VisibleButton(1);
            frm.DisableButton(0);
            this.Close();
            frm.Show();
        }

        private void btnMusteriGuncelle_Click(object sender, EventArgs e)
        {
            if (lvMusteriler.SelectedItems.Count>0)
            {
                MusteriEkleme frm = new MusteriEkleme();
                cGenel._musteriEkleme = 0;
                cGenel._musteriId = Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0]);
                frm.VisibleButton(0);
                frm.DisableButton(1);
                this.Close();
                frm.Show();
            }
        }
    }
}
