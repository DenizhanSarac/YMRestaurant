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
    public partial class frmKasaIslemleri : Form
    {
        public frmKasaIslemleri()
        {
            InitializeComponent();
        }

        private void frmKasaIslemleri_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.DataTable2' table. You can move, or remove it, as needed.
            this.DataTable2TableAdapter.Fill(this.DataSet1.DataTable2);
            // TODO: This line of code loads data into the 'DataSet1.DataTable1' table. You can move, or remove it, as needed.
            this.DataTable1TableAdapter.Fill(this.DataSet1.DataTable1);

            
        }

        private void btnAylikRaporu_Click(object sender, EventArgs e)
        {
           
        }

        private void btnZrapor_Click(object sender, EventArgs e)
        {
            
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            this.Close();
            frm.Show();
        }
    }
}
