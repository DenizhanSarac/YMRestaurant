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
    public partial class frmMutfak : Form
    {
        public frmMutfak()
        {
            InitializeComponent();
        }

        private void HCp_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            ControlPaint.DrawBorder(e.Graphics, p.DisplayRectangle, Color.White, ButtonBorderStyle.Inset);
        }

        private void frmMutfak_Load(object sender, EventArgs e)
        {
            rbAltKategori.Checked = true;
            cUrunCesitleri AnaKategori = new cUrunCesitleri();
            AnaKategori.urunCesitleriniGetir(cbKategoriler);
            cbKategoriler.Items.Insert(0, "Tüm Kategoriler");
            cbKategoriler.SelectedIndex = 0;

            label3.Visible = false;
            txtArama.Visible = false;
            

            cUrunler c = new cUrunler();
            c.urunleriListele(lvGıdaListesi);
        }

        private void Temizle()
        {
            txtGıdaAdı.Clear();
            txtGıdaFiyat.Clear();
            txtGıdaFiyat.Text = string.Format("{0:##0.00}", 0);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (rbAltKategori.Checked)
            {
                if (txtGıdaAdı.Text.Trim() == "" || txtGıdaFiyat.Text.Trim() == "" || cbKategoriler.SelectedItem.ToString() == "Tüm Kategoriler")
                {
                    MessageBox.Show("Alanları Boş Geçmeyiniz", "Dikkat Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cUrunler c = new cUrunler();
                    c.Fiyat = Convert.ToDecimal(txtGıdaFiyat.Text);
                    c.Urunad = txtGıdaAdı.Text;
                    c.Aciklama = "ürün eklendi";
                    c.Urunturno = urunturNo;
                    int sonuc = c.UrunEkle(c);
                    if (sonuc != 0)
                    {
                        MessageBox.Show("Ürün Eklenmiştir.");
                        Yenile();
                        Temizle();
                    }
                }
            }
            else
            {


                if (txtKategoriAd.Text.Trim() == "")
                {
                    MessageBox.Show("Lütfen Kategori İsmi Giriniz", "Dikkat Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cUrunCesitleri gida = new cUrunCesitleri();
                    gida.KategoriAd = txtKategoriAd.Text;
                    gida.Aciklama = txtAcıklama.Text;
                    int sonuc = gida.urunKategoriEkle(gida);
                    if (sonuc != 0)
                    {
                        MessageBox.Show("Kategori Eklenmiştir.");
                        Yenile();
                        Temizle();
                    }
                }
            }
        }

        int urunturNo = 0;
        private void cbKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            cUrunler u = new cUrunler();
            if (cbKategoriler.SelectedItem.ToString() == "Tüm Kategoriler")
            {
                u.urunleriListele(lvGıdaListesi);
            }
            else
            {
                cUrunCesitleri cesit = (cUrunCesitleri)cbKategoriler.SelectedItem;
                urunturNo = cesit.UrunTurNo;
                u.UrunleriListeleByUrunAdi(lvGıdaListesi, urunturNo);
            }
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            if (rbAltKategori.Checked)
            {
                if (txtGıdaAdı.Text.Trim() == "" || txtGıdaFiyat.Text.Trim() == "" || cbKategoriler.SelectedItem.ToString() == "Tüm Kategoriler")
                {
                    MessageBox.Show("Alanları Boş Geçmeyiniz", "Dikkat Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cUrunler c = new cUrunler();
                    c.Fiyat = Convert.ToDecimal(txtGıdaFiyat.Text);
                    c.Urunad = txtGıdaAdı.Text;
                    c.Urunid = Convert.ToInt32(txtUrunId.Text);
                    c.Urunturno = urunturNo;
                    c.Aciklama = "ürün Güncellendi";
                    int sonuc = c.urunGuncelle(c);
                    if (sonuc != 0)
                    {
                        MessageBox.Show("Ürün Güncellenmiştir.");
                        Yenile();
                        Temizle();
                    }
                }
            }
            else
            {
                if (txtKategoriId.Text.Trim() == "")
                {
                    MessageBox.Show("Lütfen Kategori Seçiniz", "Dikkat Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cUrunCesitleri gida = new cUrunCesitleri();
                    gida.KategoriAd = txtKategoriAd.Text;
                    gida.Aciklama = txtAcıklama.Text;
                    gida.UrunTurNo = Convert.ToInt32(txtKategoriId.Text);
                    int sonuc = gida.urunKategoriGuncelle(gida);
                    if (sonuc != 0)
                    {
                        MessageBox.Show("Kategori Güncellenmiştir.");
                        gida.urunCesitleriniGetir(lvKategoriler);
                        Temizle();
                    }
                }

            }
        }

        private void lvGıdaListesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvGıdaListesi.SelectedItems.Count > 0)
            {
                txtGıdaAdı.Text = lvGıdaListesi.SelectedItems[0].SubItems[3].Text;
                txtGıdaFiyat.Text = lvGıdaListesi.SelectedItems[0].SubItems[4].Text;
                txtUrunId.Text = lvGıdaListesi.SelectedItems[0].SubItems[0].Text;
            }
        }

        private void lvKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvKategoriler.SelectedItems.Count > 0)
            {
                txtKategoriAd.Text = lvKategoriler.SelectedItems[0].SubItems[1].Text;
                txtKategoriId.Text = lvKategoriler.SelectedItems[0].SubItems[0].Text;
                txtAcıklama.Text = lvKategoriler.SelectedItems[0].SubItems[2].Text;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (rbAltKategori.Checked)
            {
                if (lvGıdaListesi.SelectedItems.Count > 0)
                {


                    if (MessageBox.Show("Ürün Silmekte Eminmisiniz ? ", "Dikkat Bilgiler Silinecek", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        cUrunler c = new cUrunler();
                        c.Urunid = Convert.ToInt32(txtUrunId.Text);

                        int sonuc = c.UrunSil(c,1);
                        if (sonuc != 0)
                        {
                            MessageBox.Show("Ürün Silinmiştir.");
                            cbKategoriler_SelectedIndexChanged(sender, e);
                            Yenile();
                            Temizle();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Silmek istediğiniz Ürünü Seçiniz..");
                }
            }
            else
            {
                if (lvKategoriler.SelectedItems.Count > 0)
                {


                    if (MessageBox.Show("Kategori Silmekte Eminmisiniz ? ", "Dikkat Bilgiler Silinecek", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        cUrunCesitleri uc = new cUrunCesitleri();

                        int sonuc = uc.urunKategoriSil(Convert.ToInt32(txtKategoriId.Text));

                        if (sonuc != 0)
                        {
                            MessageBox.Show("Kategori Silinmiştir.");
                            cUrunler c = new cUrunler();
                            c.Urunid = Convert.ToInt32(txtKategoriId.Text);
                            c.UrunSil(c, 0);
                            Yenile();
                            Temizle();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Silmek istediğiniz Kategoriyi Seçiniz..");
                }
            }
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            this.Close();
            frm.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinizden emin misiniz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            txtArama.Visible = true;
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            if (rbAltKategori.Checked)
            {
                cUrunler u = new cUrunler();
                u.UrunleriListeleByUrunAdi(lvGıdaListesi, txtArama.Text);
            }
            else
            {
                cUrunCesitleri uc = new cUrunCesitleri();
                uc.urunCesitleriniGetir(lvKategoriler, txtArama.Text);
            }
        }

        private void rbAltKategori_CheckedChanged(object sender, EventArgs e)
        {
            panelUrun.Visible = true;
            panelAnaKategori.Visible = false;
            lvKategoriler.Visible = false;
            lvGıdaListesi.Visible = true;
            Yenile();

        }

        private void rbAnaKategori_CheckedChanged(object sender, EventArgs e)
        {
            panelUrun.Visible = false;
            panelAnaKategori.Visible = true;
            lvKategoriler.Visible = true;
            lvGıdaListesi.Visible = false;
            Yenile();
            //cUrunCesitleri uc = new cUrunCesitleri();
            //uc.urunCesitleriniGetir(lvKategoriler);
        }

        private void Yenile()
        {
            cUrunCesitleri uc = new cUrunCesitleri();
            uc.urunCesitleriniGetir(cbKategoriler);
            cbKategoriler.Items.Insert(0, "Tüm Kategoriler");
            cbKategoriler.SelectedIndex = 0;
            uc.urunCesitleriniGetir(lvKategoriler);
            cUrunler c = new cUrunler();
            c.urunleriListele(lvGıdaListesi);
        }

        private void panelUrun_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelAnaKategori_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
