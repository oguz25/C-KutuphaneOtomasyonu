
namespace KutuphaneOtomasyon0
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.Btn_ogrenciListele = new System.Windows.Forms.Button();
            this.Btn_kitapEkle = new System.Windows.Forms.Button();
            this.Btn_kitapListesi = new System.Windows.Forms.Button();
            this.Btn_emanetKitaplar = new System.Windows.Forms.Button();
            this.Btn_kitapAl = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_ogrenciEkle = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.BackColor = System.Drawing.SystemColors.Control;
            this.zedGraphControl1.IsShowPointValues = false;
            this.zedGraphControl1.Location = new System.Drawing.Point(28, 180);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.PointValueFormat = "G";
            this.zedGraphControl1.Size = new System.Drawing.Size(748, 329);
            this.zedGraphControl1.TabIndex = 9;
            this.zedGraphControl1.Load += new System.EventHandler(this.zedGraphControl1_Load);
            // 
            // Btn_ogrenciListele
            // 
            this.Btn_ogrenciListele.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Btn_ogrenciListele.Location = new System.Drawing.Point(120, 86);
            this.Btn_ogrenciListele.Name = "Btn_ogrenciListele";
            this.Btn_ogrenciListele.Size = new System.Drawing.Size(99, 49);
            this.Btn_ogrenciListele.TabIndex = 11;
            this.Btn_ogrenciListele.Text = "Öğrenci Listele";
            this.Btn_ogrenciListele.UseVisualStyleBackColor = false;
            this.Btn_ogrenciListele.Click += new System.EventHandler(this.Btn_ogrenciListele_Click);
            // 
            // Btn_kitapEkle
            // 
            this.Btn_kitapEkle.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Btn_kitapEkle.Location = new System.Drawing.Point(237, 86);
            this.Btn_kitapEkle.Name = "Btn_kitapEkle";
            this.Btn_kitapEkle.Size = new System.Drawing.Size(99, 49);
            this.Btn_kitapEkle.TabIndex = 12;
            this.Btn_kitapEkle.Text = "Kitap Ekle";
            this.Btn_kitapEkle.UseVisualStyleBackColor = false;
            this.Btn_kitapEkle.Click += new System.EventHandler(this.Btn_kitapEkle_Click);
            // 
            // Btn_kitapListesi
            // 
            this.Btn_kitapListesi.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Btn_kitapListesi.Location = new System.Drawing.Point(360, 86);
            this.Btn_kitapListesi.Name = "Btn_kitapListesi";
            this.Btn_kitapListesi.Size = new System.Drawing.Size(99, 49);
            this.Btn_kitapListesi.TabIndex = 13;
            this.Btn_kitapListesi.Text = "Kitap Listesi";
            this.Btn_kitapListesi.UseVisualStyleBackColor = false;
            this.Btn_kitapListesi.Click += new System.EventHandler(this.Btn_kitapListesi_Click);
            // 
            // Btn_emanetKitaplar
            // 
            this.Btn_emanetKitaplar.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Btn_emanetKitaplar.Location = new System.Drawing.Point(486, 86);
            this.Btn_emanetKitaplar.Name = "Btn_emanetKitaplar";
            this.Btn_emanetKitaplar.Size = new System.Drawing.Size(99, 49);
            this.Btn_emanetKitaplar.TabIndex = 14;
            this.Btn_emanetKitaplar.Text = "Emanet Kitaplar";
            this.Btn_emanetKitaplar.UseVisualStyleBackColor = false;
            this.Btn_emanetKitaplar.Click += new System.EventHandler(this.Btn_emanetKitaplar_Click);
            // 
            // Btn_kitapAl
            // 
            this.Btn_kitapAl.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Btn_kitapAl.Location = new System.Drawing.Point(586, 25);
            this.Btn_kitapAl.Name = "Btn_kitapAl";
            this.Btn_kitapAl.Size = new System.Drawing.Size(115, 49);
            this.Btn_kitapAl.TabIndex = 15;
            this.Btn_kitapAl.Text = "Kitap Al / Bırak\r\n";
            this.Btn_kitapAl.UseVisualStyleBackColor = false;
            this.Btn_kitapAl.Click += new System.EventHandler(this.Btn_kitapAl_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Turquoise;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Btn_ogrenciEkle);
            this.panel1.Controls.Add(this.Btn_kitapAl);
            this.panel1.Controls.Add(this.Btn_ogrenciListele);
            this.panel1.Controls.Add(this.Btn_emanetKitaplar);
            this.panel1.Controls.Add(this.Btn_kitapEkle);
            this.panel1.Controls.Add(this.Btn_kitapListesi);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 153);
            this.panel1.TabIndex = 16;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(287, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 38);
            this.label1.TabIndex = 17;
            this.label1.Text = "Ana Menü";
            // 
            // Btn_ogrenciEkle
            // 
            this.Btn_ogrenciEkle.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Btn_ogrenciEkle.Location = new System.Drawing.Point(19, 25);
            this.Btn_ogrenciEkle.Name = "Btn_ogrenciEkle";
            this.Btn_ogrenciEkle.Size = new System.Drawing.Size(99, 49);
            this.Btn_ogrenciEkle.TabIndex = 16;
            this.Btn_ogrenciEkle.Text = "Öğrenci Ekle";
            this.Btn_ogrenciEkle.UseVisualStyleBackColor = false;
            this.Btn_ogrenciEkle.Click += new System.EventHandler(this.Btn_ogrenciEkle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(803, 521);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.zedGraphControl1);
            this.Name = "Form1";
            this.Text = "Kütüphane Otomasyonu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Button Btn_ogrenciListele;
        private System.Windows.Forms.Button Btn_kitapEkle;
        private System.Windows.Forms.Button Btn_kitapListesi;
        private System.Windows.Forms.Button Btn_emanetKitaplar;
        private System.Windows.Forms.Button Btn_kitapAl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Btn_ogrenciEkle;
        private System.Windows.Forms.Label label1;
    }
}

