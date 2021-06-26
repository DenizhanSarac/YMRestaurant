namespace rest
{
    partial class frmMutfak
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelAnaKategori = new System.Windows.Forms.Panel();
            this.txtKategoriId = new System.Windows.Forms.TextBox();
            this.txtAcıklama = new System.Windows.Forms.TextBox();
            this.txtKategoriAd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbAltKategori = new System.Windows.Forms.RadioButton();
            this.rbAnaKategori = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnDegistir = new System.Windows.Forms.Button();
            this.btnBul = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.lvKategoriler = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvGıdaListesi = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelUrun = new System.Windows.Forms.Panel();
            this.txtUrunId = new System.Windows.Forms.TextBox();
            this.txtGıdaFiyat = new System.Windows.Forms.TextBox();
            this.txtGıdaAdı = new System.Windows.Forms.TextBox();
            this.cbKategoriler = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnGeriDon = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelAnaKategori.SuspendLayout();
            this.panelUrun.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAnaKategori
            // 
            this.panelAnaKategori.BackColor = System.Drawing.Color.Transparent;
            this.panelAnaKategori.Controls.Add(this.txtKategoriId);
            this.panelAnaKategori.Controls.Add(this.txtAcıklama);
            this.panelAnaKategori.Controls.Add(this.txtKategoriAd);
            this.panelAnaKategori.Controls.Add(this.label2);
            this.panelAnaKategori.Controls.Add(this.label1);
            this.panelAnaKategori.Location = new System.Drawing.Point(5, 11);
            this.panelAnaKategori.Name = "panelAnaKategori";
            this.panelAnaKategori.Size = new System.Drawing.Size(281, 102);
            this.panelAnaKategori.TabIndex = 0;
            this.panelAnaKategori.Paint += new System.Windows.Forms.PaintEventHandler(this.panelAnaKategori_Paint);
            // 
            // txtKategoriId
            // 
            this.txtKategoriId.Location = new System.Drawing.Point(222, 26);
            this.txtKategoriId.Name = "txtKategoriId";
            this.txtKategoriId.Size = new System.Drawing.Size(10, 20);
            this.txtKategoriId.TabIndex = 4;
            this.txtKategoriId.Visible = false;
            // 
            // txtAcıklama
            // 
            this.txtAcıklama.Location = new System.Drawing.Point(116, 53);
            this.txtAcıklama.Name = "txtAcıklama";
            this.txtAcıklama.Size = new System.Drawing.Size(100, 20);
            this.txtAcıklama.TabIndex = 3;
            // 
            // txtKategoriAd
            // 
            this.txtKategoriAd.Location = new System.Drawing.Point(116, 23);
            this.txtKategoriAd.Name = "txtKategoriAd";
            this.txtKategoriAd.Size = new System.Drawing.Size(100, 20);
            this.txtKategoriAd.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Açıklama";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kategori Ad";
            // 
            // rbAltKategori
            // 
            this.rbAltKategori.AutoSize = true;
            this.rbAltKategori.BackColor = System.Drawing.Color.Transparent;
            this.rbAltKategori.Font = new System.Drawing.Font("Chiller", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAltKategori.Location = new System.Drawing.Point(494, 48);
            this.rbAltKategori.Name = "rbAltKategori";
            this.rbAltKategori.Size = new System.Drawing.Size(154, 47);
            this.rbAltKategori.TabIndex = 1;
            this.rbAltKategori.TabStop = true;
            this.rbAltKategori.Text = "Ürün Ekle";
            this.rbAltKategori.UseVisualStyleBackColor = false;
            this.rbAltKategori.CheckedChanged += new System.EventHandler(this.rbAltKategori_CheckedChanged);
            // 
            // rbAnaKategori
            // 
            this.rbAnaKategori.AutoSize = true;
            this.rbAnaKategori.BackColor = System.Drawing.Color.Transparent;
            this.rbAnaKategori.Font = new System.Drawing.Font("Chiller", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAnaKategori.Location = new System.Drawing.Point(667, 48);
            this.rbAnaKategori.Name = "rbAnaKategori";
            this.rbAnaKategori.Size = new System.Drawing.Size(263, 47);
            this.rbAnaKategori.TabIndex = 2;
            this.rbAnaKategori.TabStop = true;
            this.rbAnaKategori.Text = "Ürün Kategori Ekle";
            this.rbAnaKategori.UseVisualStyleBackColor = false;
            this.rbAnaKategori.CheckedChanged += new System.EventHandler(this.rbAnaKategori_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(507, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Aramak İstediğiniz Ürün :";
            // 
            // txtArama
            // 
            this.txtArama.Location = new System.Drawing.Point(637, 242);
            this.txtArama.Name = "txtArama";
            this.txtArama.Size = new System.Drawing.Size(191, 20);
            this.txtArama.TabIndex = 4;
            this.txtArama.TextChanged += new System.EventHandler(this.txtArama_TextChanged);
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.Color.Transparent;
            this.btnEkle.BackgroundImage = global::rest.Properties.Resources.MutfakEkle;
            this.btnEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEkle.FlatAppearance.BorderSize = 0;
            this.btnEkle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEkle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEkle.Location = new System.Drawing.Point(494, 289);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 75);
            this.btnEkle.TabIndex = 5;
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnDegistir
            // 
            this.btnDegistir.BackColor = System.Drawing.Color.Transparent;
            this.btnDegistir.BackgroundImage = global::rest.Properties.Resources.MutfakDuzenle;
            this.btnDegistir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDegistir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDegistir.FlatAppearance.BorderSize = 0;
            this.btnDegistir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDegistir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDegistir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDegistir.Location = new System.Drawing.Point(588, 289);
            this.btnDegistir.Name = "btnDegistir";
            this.btnDegistir.Size = new System.Drawing.Size(75, 75);
            this.btnDegistir.TabIndex = 6;
            this.btnDegistir.UseVisualStyleBackColor = false;
            this.btnDegistir.Click += new System.EventHandler(this.btnDegistir_Click);
            // 
            // btnBul
            // 
            this.btnBul.BackColor = System.Drawing.Color.Transparent;
            this.btnBul.BackgroundImage = global::rest.Properties.Resources.MutfakAra;
            this.btnBul.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBul.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBul.FlatAppearance.BorderSize = 0;
            this.btnBul.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBul.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBul.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBul.Location = new System.Drawing.Point(688, 289);
            this.btnBul.Name = "btnBul";
            this.btnBul.Size = new System.Drawing.Size(75, 75);
            this.btnBul.TabIndex = 7;
            this.btnBul.UseVisualStyleBackColor = false;
            this.btnBul.Click += new System.EventHandler(this.btnBul_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.Transparent;
            this.btnSil.BackgroundImage = global::rest.Properties.Resources.MutfakSil;
            this.btnSil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSil.FlatAppearance.BorderSize = 0;
            this.btnSil.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.Location = new System.Drawing.Point(774, 270);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(92, 109);
            this.btnSil.TabIndex = 8;
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // lvKategoriler
            // 
            this.lvKategoriler.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvKategoriler.FullRowSelect = true;
            this.lvKategoriler.GridLines = true;
            this.lvKategoriler.Location = new System.Drawing.Point(10, 15);
            this.lvKategoriler.Name = "lvKategoriler";
            this.lvKategoriler.Size = new System.Drawing.Size(494, 284);
            this.lvKategoriler.TabIndex = 9;
            this.lvKategoriler.UseCompatibleStateImageBehavior = false;
            this.lvKategoriler.View = System.Windows.Forms.View.Details;
            this.lvKategoriler.SelectedIndexChanged += new System.EventHandler(this.lvKategoriler_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "TurId";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Kategori";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 249;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Açıklama";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 241;
            // 
            // lvGıdaListesi
            // 
            this.lvGıdaListesi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lvGıdaListesi.FullRowSelect = true;
            this.lvGıdaListesi.GridLines = true;
            this.lvGıdaListesi.Location = new System.Drawing.Point(10, 15);
            this.lvGıdaListesi.Name = "lvGıdaListesi";
            this.lvGıdaListesi.Size = new System.Drawing.Size(494, 284);
            this.lvGıdaListesi.TabIndex = 10;
            this.lvGıdaListesi.UseCompatibleStateImageBehavior = false;
            this.lvGıdaListesi.View = System.Windows.Forms.View.Details;
            this.lvGıdaListesi.SelectedIndexChanged += new System.EventHandler(this.lvGıdaListesi_SelectedIndexChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "UrunId";
            this.columnHeader4.Width = 0;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "UrunTurNo";
            this.columnHeader5.Width = 0;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Kategori";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 80;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Ürün Ad";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 177;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Fiyat";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 157;
            // 
            // panelUrun
            // 
            this.panelUrun.BackColor = System.Drawing.Color.Transparent;
            this.panelUrun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelUrun.Controls.Add(this.txtUrunId);
            this.panelUrun.Controls.Add(this.txtGıdaFiyat);
            this.panelUrun.Controls.Add(this.txtGıdaAdı);
            this.panelUrun.Controls.Add(this.cbKategoriler);
            this.panelUrun.Controls.Add(this.label6);
            this.panelUrun.Controls.Add(this.label5);
            this.panelUrun.Controls.Add(this.label4);
            this.panelUrun.ForeColor = System.Drawing.Color.Black;
            this.panelUrun.Location = new System.Drawing.Point(4, 11);
            this.panelUrun.Name = "panelUrun";
            this.panelUrun.Size = new System.Drawing.Size(282, 114);
            this.panelUrun.TabIndex = 11;
            this.panelUrun.Paint += new System.Windows.Forms.PaintEventHandler(this.panelUrun_Paint);
            // 
            // txtUrunId
            // 
            this.txtUrunId.Location = new System.Drawing.Point(248, 50);
            this.txtUrunId.Name = "txtUrunId";
            this.txtUrunId.Size = new System.Drawing.Size(10, 20);
            this.txtUrunId.TabIndex = 6;
            this.txtUrunId.Visible = false;
            // 
            // txtGıdaFiyat
            // 
            this.txtGıdaFiyat.Location = new System.Drawing.Point(121, 78);
            this.txtGıdaFiyat.Name = "txtGıdaFiyat";
            this.txtGıdaFiyat.Size = new System.Drawing.Size(121, 20);
            this.txtGıdaFiyat.TabIndex = 5;
            // 
            // txtGıdaAdı
            // 
            this.txtGıdaAdı.Location = new System.Drawing.Point(121, 50);
            this.txtGıdaAdı.Name = "txtGıdaAdı";
            this.txtGıdaAdı.Size = new System.Drawing.Size(121, 20);
            this.txtGıdaAdı.TabIndex = 4;
            // 
            // cbKategoriler
            // 
            this.cbKategoriler.FormattingEnabled = true;
            this.cbKategoriler.Location = new System.Drawing.Point(121, 22);
            this.cbKategoriler.Name = "cbKategoriler";
            this.cbKategoriler.Size = new System.Drawing.Size(121, 21);
            this.cbKategoriler.TabIndex = 3;
            this.cbKategoriler.SelectedIndexChanged += new System.EventHandler(this.cbKategoriler_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Gıda Fiyatı";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Gıda Adı";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Gıda Kategorisi";
            // 
            // btnCikis
            // 
            this.btnCikis.Location = new System.Drawing.Point(93, 503);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(75, 23);
            this.btnCikis.TabIndex = 17;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Visible = false;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnGeriDon
            // 
            this.btnGeriDon.BackColor = System.Drawing.Color.Transparent;
            this.btnGeriDon.BackgroundImage = global::rest.Properties.Resources.exit;
            this.btnGeriDon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGeriDon.FlatAppearance.BorderSize = 0;
            this.btnGeriDon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnGeriDon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnGeriDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeriDon.Location = new System.Drawing.Point(-16, 682);
            this.btnGeriDon.Name = "btnGeriDon";
            this.btnGeriDon.Size = new System.Drawing.Size(156, 42);
            this.btnGeriDon.TabIndex = 16;
            this.btnGeriDon.UseVisualStyleBackColor = false;
            this.btnGeriDon.Click += new System.EventHandler(this.btnGeriDon_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lvGıdaListesi);
            this.groupBox1.Controls.Add(this.lvKategoriler);
            this.groupBox1.Location = new System.Drawing.Point(422, 385);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 305);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.panelUrun);
            this.groupBox2.Controls.Add(this.panelAnaKategori);
            this.groupBox2.Location = new System.Drawing.Point(529, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(299, 137);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            // 
            // frmMutfak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::rest.Properties.Resources.flatSiparis;
            this.ClientSize = new System.Drawing.Size(1111, 788);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnGeriDon);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnBul);
            this.Controls.Add(this.btnDegistir);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.txtArama);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rbAnaKategori);
            this.Controls.Add(this.rbAltKategori);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMutfak";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMutfak";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMutfak_Load);
            this.panelAnaKategori.ResumeLayout(false);
            this.panelAnaKategori.PerformLayout();
            this.panelUrun.ResumeLayout(false);
            this.panelUrun.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelAnaKategori;
        private System.Windows.Forms.TextBox txtKategoriId;
        private System.Windows.Forms.TextBox txtAcıklama;
        private System.Windows.Forms.TextBox txtKategoriAd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbAltKategori;
        private System.Windows.Forms.RadioButton rbAnaKategori;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtArama;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnDegistir;
        private System.Windows.Forms.Button btnBul;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.ListView lvKategoriler;
        private System.Windows.Forms.ListView lvGıdaListesi;
        private System.Windows.Forms.Panel panelUrun;
        private System.Windows.Forms.TextBox txtGıdaFiyat;
        private System.Windows.Forms.TextBox txtGıdaAdı;
        private System.Windows.Forms.ComboBox cbKategoriler;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUrunId;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnGeriDon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}