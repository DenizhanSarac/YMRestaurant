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
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += Timer1_Tick;

            cbKullanici.Height = 46;
            
            this.WindowState = FormWindowState.Maximized;
            
            cPersoneller p = new cPersoneller();
            p.personelGetbyInformation(cbKullanici);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //Random rnd = new Random();

            //int x = rnd.Next(255);
            //int y = rnd.Next(255);
            //int z = rnd.Next(255);
            //label1.ForeColor = Color.FromArgb(x, y, z);

            label6.Text = DateTime.Now.ToLongTimeString();
            label5.Text = DateTime.Today.ToLongDateString();

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       

       
    }
}
