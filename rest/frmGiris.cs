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
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }
        
        private void frmGiris_Load(object sender, EventArgs e)
        {
            cPersoneller p = new cPersoneller();
            p.personelGetbyInformation(cbKullanici);
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            cGenel gnl = new cGenel();
            cPersoneller p = new cPersoneller();
            bool result = p.personelEntryControl(txtSifre.Text, cGenel._personelId);

            if (result)
            {
                cPersonelHareketleri ch = new cPersonelHareketleri();
                ch.PersonelId = cGenel._personelId;
                ch.Islem = "Giriş Yaptı";
                ch.Tarih = DateTime.Now;
                ch.PersonelActionSave(ch);


                this.Hide();
                frmMenu menu = new frmMenu();
                menu.Show();
            }
            else {
                MessageBox.Show("Şifreniz yanlış", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void cbKullanici_SelectedIndexChanged(object sender, EventArgs e)
        {
            cPersoneller p = (cPersoneller)cbKullanici.SelectedItem;
            cGenel._personelId = p.PersonelId;
            cGenel._gorevId = p.PersonelGorevId;
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinizden emin misiniz ?","Uyarı",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
