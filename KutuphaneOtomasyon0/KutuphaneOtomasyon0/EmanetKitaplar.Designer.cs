
namespace KutuphaneOtomasyon0
{
    partial class EmanetKitaplar
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
            this.dataGridView_emanetKitaplar = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btn_tumKayitlar = new System.Windows.Forms.Button();
            this.Btn_teslimEdilmeyen = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_tcileSorgula = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_emanetKitaplar)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_emanetKitaplar
            // 
            this.dataGridView_emanetKitaplar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_emanetKitaplar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView_emanetKitaplar.Location = new System.Drawing.Point(0, 363);
            this.dataGridView_emanetKitaplar.Name = "dataGridView_emanetKitaplar";
            this.dataGridView_emanetKitaplar.RowHeadersWidth = 51;
            this.dataGridView_emanetKitaplar.RowTemplate.Height = 24;
            this.dataGridView_emanetKitaplar.Size = new System.Drawing.Size(972, 220);
            this.dataGridView_emanetKitaplar.TabIndex = 0;
            this.dataGridView_emanetKitaplar.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_emanetKitaplar_ColumnHeaderMouseClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.Btn_tumKayitlar);
            this.panel1.Controls.Add(this.Btn_teslimEdilmeyen);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Txt_tcileSorgula);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(972, 363);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Btn_tumKayitlar
            // 
            this.Btn_tumKayitlar.BackColor = System.Drawing.Color.DodgerBlue;
            this.Btn_tumKayitlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Btn_tumKayitlar.Location = new System.Drawing.Point(114, 153);
            this.Btn_tumKayitlar.Name = "Btn_tumKayitlar";
            this.Btn_tumKayitlar.Size = new System.Drawing.Size(166, 71);
            this.Btn_tumKayitlar.TabIndex = 6;
            this.Btn_tumKayitlar.Text = "Tüm Kayıtlar";
            this.Btn_tumKayitlar.UseVisualStyleBackColor = false;
            this.Btn_tumKayitlar.Click += new System.EventHandler(this.Btn_tumKayitlar_Click);
            // 
            // Btn_teslimEdilmeyen
            // 
            this.Btn_teslimEdilmeyen.BackColor = System.Drawing.Color.DodgerBlue;
            this.Btn_teslimEdilmeyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Btn_teslimEdilmeyen.Location = new System.Drawing.Point(114, 71);
            this.Btn_teslimEdilmeyen.Name = "Btn_teslimEdilmeyen";
            this.Btn_teslimEdilmeyen.Size = new System.Drawing.Size(166, 68);
            this.Btn_teslimEdilmeyen.TabIndex = 5;
            this.Btn_teslimEdilmeyen.Text = "Teslim Edilmeyenler";
            this.Btn_teslimEdilmeyen.UseVisualStyleBackColor = false;
            this.Btn_teslimEdilmeyen.Click += new System.EventHandler(this.Btn_teslimEdilmeyen_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(267, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 38);
            this.label2.TabIndex = 3;
            this.label2.Text = "Emanet Kitaplar";
            // 
            // Txt_tcileSorgula
            // 
            this.Txt_tcileSorgula.Location = new System.Drawing.Point(312, 164);
            this.Txt_tcileSorgula.Name = "Txt_tcileSorgula";
            this.Txt_tcileSorgula.Size = new System.Drawing.Size(186, 22);
            this.Txt_tcileSorgula.TabIndex = 2;
            this.Txt_tcileSorgula.TextChanged += new System.EventHandler(this.Txt_tcileSorgula_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(309, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "TC ile Sorgula";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(12, 11);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(49, 46);
            this.button3.TabIndex = 5;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Orange;
            this.button4.Location = new System.Drawing.Point(12, 82);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(49, 46);
            this.button4.TabIndex = 6;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Yellow;
            this.button5.Location = new System.Drawing.Point(12, 134);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(49, 46);
            this.button5.TabIndex = 7;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.DarkViolet;
            this.button6.Location = new System.Drawing.Point(12, 200);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(49, 46);
            this.button6.TabIndex = 8;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button7.Location = new System.Drawing.Point(13, 17);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(49, 46);
            this.button7.TabIndex = 9;
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.LightCoral;
            this.button8.Location = new System.Drawing.Point(13, 71);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(49, 46);
            this.button8.TabIndex = 10;
            this.button8.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.LimeGreen;
            this.button9.Location = new System.Drawing.Point(13, 123);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(49, 46);
            this.button9.TabIndex = 11;
            this.button9.UseVisualStyleBackColor = false;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Blue;
            this.button10.Location = new System.Drawing.Point(13, 189);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(49, 46);
            this.button10.TabIndex = 12;
            this.button10.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.Controls.Add(this.button3);
            this.panel5.Controls.Add(this.button4);
            this.panel5.Controls.Add(this.button5);
            this.panel5.Controls.Add(this.button6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(891, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(81, 363);
            this.panel5.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.button10);
            this.panel2.Controls.Add(this.button9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(75, 363);
            this.panel2.TabIndex = 14;
            // 
            // EmanetKitaplar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(972, 583);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView_emanetKitaplar);
            this.Name = "EmanetKitaplar";
            this.Text = "EmanetKitaplar";
            this.Load += new System.EventHandler(this.EmanetKitaplar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_emanetKitaplar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_emanetKitaplar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txt_tcileSorgula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Btn_tumKayitlar;
        private System.Windows.Forms.Button Btn_teslimEdilmeyen;
    }
}