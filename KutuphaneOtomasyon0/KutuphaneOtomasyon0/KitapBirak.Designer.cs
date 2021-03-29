
namespace KutuphaneOtomasyon0
{
    partial class KitapBirak
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
            this.dataGridView_kitapBirak = new System.Windows.Forms.DataGridView();
            this.button_TeslimOnay = new System.Windows.Forms.Button();
            this.button_EmanetTCKontrol = new System.Windows.Forms.Button();
            this.label_Emanet = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker_teslimTarihi = new System.Windows.Forms.DateTimePicker();
            this.textBox_Kitap = new System.Windows.Forms.TextBox();
            this.Txt_TCNO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_kitapBirak)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_kitapBirak
            // 
            this.dataGridView_kitapBirak.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_kitapBirak.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView_kitapBirak.Location = new System.Drawing.Point(0, 364);
            this.dataGridView_kitapBirak.Name = "dataGridView_kitapBirak";
            this.dataGridView_kitapBirak.RowHeadersWidth = 51;
            this.dataGridView_kitapBirak.RowTemplate.Height = 24;
            this.dataGridView_kitapBirak.Size = new System.Drawing.Size(1010, 256);
            this.dataGridView_kitapBirak.TabIndex = 19;
            this.dataGridView_kitapBirak.Click += new System.EventHandler(this.dataGridView_kitapBirak_Click);
            // 
            // button_TeslimOnay
            // 
            this.button_TeslimOnay.BackColor = System.Drawing.Color.Turquoise;
            this.button_TeslimOnay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_TeslimOnay.Location = new System.Drawing.Point(669, 238);
            this.button_TeslimOnay.Name = "button_TeslimOnay";
            this.button_TeslimOnay.Size = new System.Drawing.Size(104, 41);
            this.button_TeslimOnay.TabIndex = 18;
            this.button_TeslimOnay.Text = "ONAY";
            this.button_TeslimOnay.UseVisualStyleBackColor = false;
            this.button_TeslimOnay.Click += new System.EventHandler(this.button_TeslimOnay_Click);
            // 
            // button_EmanetTCKontrol
            // 
            this.button_EmanetTCKontrol.BackColor = System.Drawing.Color.Turquoise;
            this.button_EmanetTCKontrol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_EmanetTCKontrol.Location = new System.Drawing.Point(256, 158);
            this.button_EmanetTCKontrol.Name = "button_EmanetTCKontrol";
            this.button_EmanetTCKontrol.Size = new System.Drawing.Size(219, 58);
            this.button_EmanetTCKontrol.TabIndex = 17;
            this.button_EmanetTCKontrol.Text = "TC NO Kontrol ";
            this.button_EmanetTCKontrol.UseVisualStyleBackColor = false;
            this.button_EmanetTCKontrol.Click += new System.EventHandler(this.button_EmanetTCKontrol_Click);
            // 
            // label_Emanet
            // 
            this.label_Emanet.AutoSize = true;
            this.label_Emanet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_Emanet.Location = new System.Drawing.Point(666, 158);
            this.label_Emanet.Name = "label_Emanet";
            this.label_Emanet.Size = new System.Drawing.Size(57, 25);
            this.label_Emanet.TabIndex = 16;
            this.label_Emanet.Text = "Kitap";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(30, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Kitap Teslim Tarihi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(30, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "TC NO:";
            // 
            // dateTimePicker_teslimTarihi
            // 
            this.dateTimePicker_teslimTarihi.Location = new System.Drawing.Point(33, 277);
            this.dateTimePicker_teslimTarihi.Name = "dateTimePicker_teslimTarihi";
            this.dateTimePicker_teslimTarihi.Size = new System.Drawing.Size(204, 22);
            this.dateTimePicker_teslimTarihi.TabIndex = 13;
            // 
            // textBox_Kitap
            // 
            this.textBox_Kitap.Location = new System.Drawing.Point(669, 194);
            this.textBox_Kitap.Name = "textBox_Kitap";
            this.textBox_Kitap.Size = new System.Drawing.Size(233, 22);
            this.textBox_Kitap.TabIndex = 12;
            // 
            // Txt_TCNO
            // 
            this.Txt_TCNO.Location = new System.Drawing.Point(33, 194);
            this.Txt_TCNO.Name = "Txt_TCNO";
            this.Txt_TCNO.Size = new System.Drawing.Size(204, 22);
            this.Txt_TCNO.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 28.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(40, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 54);
            this.label1.TabIndex = 20;
            this.label1.Text = "Kitap Bırak";
            // 
            // KitapBirak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1010, 620);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_kitapBirak);
            this.Controls.Add(this.button_TeslimOnay);
            this.Controls.Add(this.button_EmanetTCKontrol);
            this.Controls.Add(this.label_Emanet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker_teslimTarihi);
            this.Controls.Add(this.textBox_Kitap);
            this.Controls.Add(this.Txt_TCNO);
            this.Name = "KitapBirak";
            this.Text = "KitapBirak";
            this.Load += new System.EventHandler(this.KitapBirak_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_kitapBirak)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_kitapBirak;
        private System.Windows.Forms.Button button_TeslimOnay;
        private System.Windows.Forms.Button button_EmanetTCKontrol;
        private System.Windows.Forms.Label label_Emanet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_teslimTarihi;
        private System.Windows.Forms.TextBox textBox_Kitap;
        private System.Windows.Forms.TextBox Txt_TCNO;
        private System.Windows.Forms.Label label1;
    }
}