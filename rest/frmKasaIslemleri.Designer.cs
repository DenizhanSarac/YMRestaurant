namespace rest
{
    partial class frmKasaIslemleri
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
            this.components = new System.ComponentModel.Container();
            //Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            //Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.DataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new rest.DataSet1();
            this.DataTable2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAylikRaporu = new System.Windows.Forms.Button();
            this.btnZrapor = new System.Windows.Forms.Button();
            //this.rpvAylik = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            //this.rpvGunluk = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataTable1TableAdapter = new rest.DataSet1TableAdapters.DataTable1TableAdapter();
            this.DataTable2TableAdapter = new rest.DataSet1TableAdapters.DataTable2TableAdapter();
            this.btnGeriDon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTable1BindingSource
            // 
            this.DataTable1BindingSource.DataMember = "DataTable1";
            this.DataTable1BindingSource.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DataTable2BindingSource
            // 
            this.DataTable2BindingSource.DataMember = "DataTable2";
            this.DataTable2BindingSource.DataSource = this.DataSet1;
            // 
            // btnAylikRaporu
            // 
            this.btnAylikRaporu.BackColor = System.Drawing.Color.Transparent;
            this.btnAylikRaporu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAylikRaporu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAylikRaporu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAylikRaporu.Font = new System.Drawing.Font("Chiller", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAylikRaporu.Location = new System.Drawing.Point(22, 144);
            this.btnAylikRaporu.Name = "btnAylikRaporu";
            this.btnAylikRaporu.Size = new System.Drawing.Size(136, 100);
            this.btnAylikRaporu.TabIndex = 0;
            this.btnAylikRaporu.Text = "AYLIK RAPOR";
            this.btnAylikRaporu.UseVisualStyleBackColor = false;
            this.btnAylikRaporu.Click += new System.EventHandler(this.btnAylikRaporu_Click);
            // 
            // btnZrapor
            // 
            this.btnZrapor.BackColor = System.Drawing.Color.Transparent;
            this.btnZrapor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnZrapor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnZrapor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZrapor.Font = new System.Drawing.Font("Chiller", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZrapor.Location = new System.Drawing.Point(22, 250);
            this.btnZrapor.Name = "btnZrapor";
            this.btnZrapor.Size = new System.Drawing.Size(136, 100);
            this.btnZrapor.TabIndex = 1;
            this.btnZrapor.Text = "Z RAPORU";
            this.btnZrapor.UseVisualStyleBackColor = false;
            this.btnZrapor.Click += new System.EventHandler(this.btnZrapor_Click);
            // 
            // rpvAylik
            // 
            
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Chiller", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(185, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "AYLIK RAPOR";
            // 
            // rpvGunluk
            // 
            
            // 
            // DataTable1TableAdapter
            // 
            this.DataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // DataTable2TableAdapter
            // 
            this.DataTable2TableAdapter.ClearBeforeFill = true;
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
            this.btnGeriDon.Location = new System.Drawing.Point(22, 357);
            this.btnGeriDon.Name = "btnGeriDon";
            this.btnGeriDon.Size = new System.Drawing.Size(136, 69);
            this.btnGeriDon.TabIndex = 5;
            this.btnGeriDon.Text = "Geri";
            this.btnGeriDon.UseVisualStyleBackColor = false;
            this.btnGeriDon.Click += new System.EventHandler(this.btnGeriDon_Click);
            // 
            // frmKasaIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::rest.Properties.Resources.flatSiparis;
            this.ClientSize = new System.Drawing.Size(1145, 788);
            this.Controls.Add(this.btnGeriDon);
            
            this.Controls.Add(this.btnZrapor);
            this.Controls.Add(this.btnAylikRaporu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmKasaIslemleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmKasaIslemleri";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmKasaIslemleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable2BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAylikRaporu;
        private System.Windows.Forms.Button btnZrapor;
      
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private DataSet1 DataSet1;
        private DataSet1TableAdapters.DataTable1TableAdapter DataTable1TableAdapter;
        private System.Windows.Forms.Label label1;
       
        private System.Windows.Forms.BindingSource DataTable2BindingSource;
        private DataSet1TableAdapters.DataTable2TableAdapter DataTable2TableAdapter;
        private System.Windows.Forms.Button btnGeriDon;
    }
}