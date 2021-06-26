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
    public partial class frmSiparisKontrol : Form
    {
        public frmSiparisKontrol()
        {
            InitializeComponent();
        }

        private void frmSiparisKontrol_Load(object sender, EventArgs e)
        {
            cAdisyon c = new cAdisyon();
            int butonsayisi = c.paketAdisyonIdbulAdedi();
            c.acikPaketAdisyonlar(lvMusteriler);
            int alt = 50;
            int sol = 40;
            int bol = Convert.ToInt32(Math.Ceiling(Math.Sqrt(butonsayisi)));
            int a = 2;

            for (int i = 1; i <= butonsayisi; i++)
            {
                Button btn = new Button();

                btn.AutoSize = false;
                btn.Size = new Size(170, 80);
                btn.FlatStyle = FlatStyle.Flat;
                btn.Name = lvMusteriler.Items[i - 1].SubItems[0].Text;
                btn.Text = lvMusteriler.Items[i - 1].SubItems[1].Text;
                btn.Font = new Font(btn.Font.FontFamily.Name, 18);
                btn.Location = new Point(sol, alt);
                this.Controls.Add(btn);

                sol += btn.Width + 5;

                if (i == a)
                {
                    sol = 40;
                    alt += 85;
                    a+=2;
                }
                btn.Click += new EventHandler(dinamikMetod);
                btn.MouseEnter += new EventHandler(dinamikMetod2);
             }
        }
        protected void dinamikMetod(object sender, EventArgs e)
        {
            Button dinamikButon = (sender as Button);
            cAdisyon c = new cAdisyon();
            frmBill frm = new frmBill();
            cGenel._ServisTurNo = 2;
            cGenel._AdisyonId = Convert.ToString(c.musterininsonadisyonId(Convert.ToInt32(dinamikButon.Name)));
            frm.Show();
        }

        protected void dinamikMetod2(object sender, EventArgs e)
        {
            Button dinamikButon = (sender as Button);
            cAdisyon c = new cAdisyon();
            c.musteriDetaylar(lvMusteriDetayları, Convert.ToInt32(dinamikButon.Name));
            sonSiparisTarihi();
            lvSatisDetayları.Items.Clear();
            cSiparis s = new cSiparis();
            cGenel._ServisTurNo = 2;
            cGenel._AdisyonId = Convert.ToString(c.musterininsonadisyonId(Convert.ToInt32(dinamikButon.Name)));
            //lblGenelToplam.Text = s.GenelToplamBul(Convert.ToInt32(dinamikButon.Name)).ToString()+" TL";
        }

        void sonSiparisTarihi()
        {
            if (lvMusteriDetayları.Items.Count>0)
            {
                int s = lvMusteriDetayları.Items.Count;
                lblSonSiparisTarihi.Text = lvMusteriDetayları.Items[s - 1].SubItems[3].Text;
                txtToplamTutar.Text = s + "Adet";
            }
        }
        void toplam()
        {
            int kayıtSayisi = lvSatisDetayları.Items.Count;
            decimal toplam = 0;
            for (int i = 0; i < kayıtSayisi; i++)
            {
                toplam += Convert.ToDecimal(lvSatisDetayları.Items[i].SubItems[2].Text) * Convert.ToDecimal(lvSatisDetayları.Items[i].SubItems[3].Text);
            }

            lblToplamSiparis.Text = toplam.ToString() + " TL";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lvMusteriDetayları_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (lvMusteriDetayları.SelectedItems.Count>0)
            {
                cSiparis c = new cSiparis();
                c.adisyonpaketsiparisDetaylari(lvSatisDetayları,Convert.ToInt32(lvMusteriDetayları.SelectedItems[0].SubItems[4].Text));
                toplam();

                //lblGenelToplam.Text = c.GenelToplamBul(Convert.ToInt32(lvMusteriDetayları.SelectedItems[0].SubItems[0].Text)).ToString()+" TL";
            }
        }

        private void lvSatisDetayları_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
