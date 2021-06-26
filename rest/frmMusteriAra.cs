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
    public partial class frmMusteriAra : Form
    {
        public frmMusteriAra()
        {
            InitializeComponent();
        }

        private void btnYeniMusteri_Click(object sender, EventArgs e)
        {
            MusteriEkleme m = new MusteriEkleme();
            cGenel._musteriEkleme = 1;
            this.Close();
            m.VisibleButton(1);
            m.DisableButton(0);  
            m.Show();
        }

        private void frmMusteriAra_Load(object sender, EventArgs e)
        {
            cMusteriler c = new cMusteriler();
            c.musterileriGetir(lvMusteriler);
        }


        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            this.Close();
            frm.Show();
        }

        private void btnMusteriSec_Click(object sender, EventArgs e)
        {

        }

        private void btnMusteriGuncelle_Click(object sender, EventArgs e)
        {
            if (lvMusteriler.SelectedItems.Count>0)
            {
                MusteriEkleme frm = new MusteriEkleme();
                cGenel._musteriEkleme = 1;
                cGenel._musteriId = Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text);
                frm.DisableButton(1);
                frm.VisibleButton(0);
                
                this.Close();
                frm.Show();
            }
        }

        private void txtMusteriAd_TextChanged(object sender, EventArgs e)
        {
            cMusteriler c = new cMusteriler();
            c.musterigetirAd(lvMusteriler,txtMusteriAd.Text);
        }

        private void txtSoyad_TextChanged(object sender, EventArgs e)
        {
            cMusteriler c = new cMusteriler();
            c.musterigetirSoyad(lvMusteriler, txtSoyad.Text);
        }

        private void txtTelefon_TextChanged(object sender, EventArgs e)
        {
            cMusteriler c = new cMusteriler();
            c.musterigetirTlf(lvMusteriler, txtTelefon.Text);
        }

        private void btnAdisyonBul_Click(object sender, EventArgs e)
        {
            if (txtAdisyonId.Text!="")
            {
                cGenel._AdisyonId = txtAdisyonId.Text;
                cPaketler c = new cPaketler();
                bool sonuc = c.getCheckOpenAdditionID(Convert.ToInt32(txtAdisyonId.Text));
                if (sonuc)
                {
                    frmBill frm = new frmBill();
                    cGenel._ServisTurNo = 2;
                    frm.Show();
                }
                else
                {
                    MessageBox.Show(txtAdisyonId.Text+" nolu bir adisyon bulunamadı.");
                }
            }
            else
            {
                MessageBox.Show("Aramak istediğiniz adisyonu yazınız");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmSiparisKontrol frm = new frmSiparisKontrol();
            frm.Show();
        }

        private void lvMusteriler_DoubleClick(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            cGenel._musteriId = Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text);
            cGenel._ButttonValue =null;
            cGenel._ButtonName = null;
            this.Close();
            frm.Show();
        }
    }
}
