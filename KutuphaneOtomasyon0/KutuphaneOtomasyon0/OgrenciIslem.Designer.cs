
namespace KutuphaneOtomasyon0
{
    partial class OgrenciIslem
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
            this.comboBox_Cinsiyet = new System.Windows.Forms.ComboBox();
            this.dateTimePicker_uyelikTarihi = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_email = new System.Windows.Forms.TextBox();
            this.Txt_telefon = new System.Windows.Forms.TextBox();
            this.Txt_adSoyad = new System.Windows.Forms.TextBox();
            this.Txt_tcNo = new System.Windows.Forms.TextBox();
            this.Btn_ogrenciGuncelle = new System.Windows.Forms.Button();
            this.Btn_ogrenciSil = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.Btn_ogrenciEkle = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_Cinsiyet
            // 
            this.comboBox_Cinsiyet.FormattingEnabled = true;
            this.comboBox_Cinsiyet.Items.AddRange(new object[] {
            "Erkek",
            "Bayan"});
            this.comboBox_Cinsiyet.Location = new System.Drawing.Point(212, 393);
            this.comboBox_Cinsiyet.Name = "comboBox_Cinsiyet";
            this.comboBox_Cinsiyet.Size = new System.Drawing.Size(230, 24);
            this.comboBox_Cinsiyet.TabIndex = 31;
            // 
            // dateTimePicker_uyelikTarihi
            // 
            this.dateTimePicker_uyelikTarihi.Location = new System.Drawing.Point(212, 346);
            this.dateTimePicker_uyelikTarihi.Name = "dateTimePicker_uyelikTarihi";
            this.dateTimePicker_uyelikTarihi.Size = new System.Drawing.Size(230, 22);
            this.dateTimePicker_uyelikTarihi.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 396);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 17);
            this.label6.TabIndex = 29;
            this.label6.Text = "Cinsiyet :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 351);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "Üyelik Tarihi :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "E-Mail :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 26;
            this.label3.Text = "Telefon :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "Ad Soyad :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "TC NO :";
            // 
            // Txt_email
            // 
            this.Txt_email.Location = new System.Drawing.Point(212, 288);
            this.Txt_email.Name = "Txt_email";
            this.Txt_email.Size = new System.Drawing.Size(230, 22);
            this.Txt_email.TabIndex = 23;
            this.Txt_email.Validating += new System.ComponentModel.CancelEventHandler(this.TxtEmailKontrol);
            // 
            // Txt_telefon
            // 
            this.Txt_telefon.Location = new System.Drawing.Point(212, 241);
            this.Txt_telefon.Name = "Txt_telefon";
            this.Txt_telefon.Size = new System.Drawing.Size(230, 22);
            this.Txt_telefon.TabIndex = 22;
            // 
            // Txt_adSoyad
            // 
            this.Txt_adSoyad.Location = new System.Drawing.Point(212, 185);
            this.Txt_adSoyad.Name = "Txt_adSoyad";
            this.Txt_adSoyad.Size = new System.Drawing.Size(230, 22);
            this.Txt_adSoyad.TabIndex = 21;
            // 
            // Txt_tcNo
            // 
            this.Txt_tcNo.Location = new System.Drawing.Point(212, 139);
            this.Txt_tcNo.Name = "Txt_tcNo";
            this.Txt_tcNo.Size = new System.Drawing.Size(230, 22);
            this.Txt_tcNo.TabIndex = 20;
            this.Txt_tcNo.TextChanged += new System.EventHandler(this.TCkarsilastirma);
            this.Txt_tcNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTCNOKarakter);
            // 
            // Btn_ogrenciGuncelle
            // 
            this.Btn_ogrenciGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Btn_ogrenciGuncelle.Location = new System.Drawing.Point(281, 460);
            this.Btn_ogrenciGuncelle.Name = "Btn_ogrenciGuncelle";
            this.Btn_ogrenciGuncelle.Size = new System.Drawing.Size(176, 96);
            this.Btn_ogrenciGuncelle.TabIndex = 33;
            this.Btn_ogrenciGuncelle.Text = "Öğrenci Güncelle";
            this.Btn_ogrenciGuncelle.UseVisualStyleBackColor = true;
            this.Btn_ogrenciGuncelle.Click += new System.EventHandler(this.Btn_ogrenciGuncelle_Click);
            // 
            // Btn_ogrenciSil
            // 
            this.Btn_ogrenciSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Btn_ogrenciSil.Location = new System.Drawing.Point(505, 460);
            this.Btn_ogrenciSil.Name = "Btn_ogrenciSil";
            this.Btn_ogrenciSil.Size = new System.Drawing.Size(176, 96);
            this.Btn_ogrenciSil.TabIndex = 34;
            this.Btn_ogrenciSil.Text = "Öğrenci Sil";
            this.Btn_ogrenciSil.UseVisualStyleBackColor = true;
            this.Btn_ogrenciSil.Click += new System.EventHandler(this.Btn_ogrenciSil_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.button4);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 100);
            this.panel1.TabIndex = 35;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button4.Location = new System.Drawing.Point(15, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(746, 71);
            this.button4.TabIndex = 36;
            this.button4.Text = "Öğrenci İşlemleri";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // Btn_ogrenciEkle
            // 
            this.Btn_ogrenciEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Btn_ogrenciEkle.Location = new System.Drawing.Point(50, 460);
            this.Btn_ogrenciEkle.Name = "Btn_ogrenciEkle";
            this.Btn_ogrenciEkle.Size = new System.Drawing.Size(176, 96);
            this.Btn_ogrenciEkle.TabIndex = 37;
            this.Btn_ogrenciEkle.Text = "Öğrenci Ekle";
            this.Btn_ogrenciEkle.UseVisualStyleBackColor = true;
            this.Btn_ogrenciEkle.Click += new System.EventHandler(this.Btn_ogrenciEkle_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(470, 142);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(318, 197);
            this.panel2.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(29, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(257, 160);
            this.label7.TabIndex = 39;
            this.label7.Text = "Öğrenci Güncelleme\r\nve Öğrenci Silme\r\nişlemi için TC NO\r\nbaz alınmaktadır!\r\n\r\n";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // OgrenciIslem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(800, 568);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Btn_ogrenciEkle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Btn_ogrenciSil);
            this.Controls.Add(this.Btn_ogrenciGuncelle);
            this.Controls.Add(this.comboBox_Cinsiyet);
            this.Controls.Add(this.dateTimePicker_uyelikTarihi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Txt_email);
            this.Controls.Add(this.Txt_telefon);
            this.Controls.Add(this.Txt_adSoyad);
            this.Controls.Add(this.Txt_tcNo);
            this.Name = "OgrenciIslem";
            this.Text = "OgrenciIslem";
            this.Load += new System.EventHandler(this.OgrenciIslem_Load);
            this.TextChanged += new System.EventHandler(this.TCkarsilastirma);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTCNOKarakter);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Cinsiyet;
        private System.Windows.Forms.DateTimePicker dateTimePicker_uyelikTarihi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_email;
        private System.Windows.Forms.TextBox Txt_telefon;
        private System.Windows.Forms.TextBox Txt_adSoyad;
        private System.Windows.Forms.TextBox Txt_tcNo;
        private System.Windows.Forms.Button Btn_ogrenciGuncelle;
        private System.Windows.Forms.Button Btn_ogrenciSil;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button Btn_ogrenciEkle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
    }
}