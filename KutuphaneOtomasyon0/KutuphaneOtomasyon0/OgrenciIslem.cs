using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace KutuphaneOtomasyon0
{
    public partial class OgrenciIslem : Form
    {
        public OgrenciIslem()
        {
            InitializeComponent();
        }
        int AtIsareti, NoktaIsareti;

        public OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +
             Application.StartupPath + "\\kutuphane.mdb");


        public void Hepsinisil()
        //Kontrol sayılarına göre textleri sıfırlıyoruz
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (Controls[i] is TextBox)
                {
                    Controls[i].Text = "";
                }

                if (Controls[i] is TextBox)
                {
                    Controls[i].Text = "";
                }

                if (Controls[i] is TextBox)
                {
                    Controls[i].Text = "";
                }

                if (Controls[i] is TextBox)
                {
                    Controls[i].Text = "";
                }


            }
        }
        private void Btn_ogrenciEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglantim.State == ConnectionState.Closed)
                {
                    if (Txt_tcNo.Text.Length < 11)
                    {
                        MessageBox.Show(" TC Kimlik No 11 Haneli Olmak Zorundadır.");
                    }

                    if (Txt_tcNo.Text.Length == 11 && Txt_adSoyad.Text == "" && Txt_email.Text == "" && comboBox_Cinsiyet.Text == "")
                    {
                        MessageBox.Show("Lütfen Boş Alanları Doldurunuz.");
                    }
                    if (Txt_tcNo.Text != "" && Txt_adSoyad.Text != "" && Txt_email.Text != "" && comboBox_Cinsiyet.Text != "" && dateTimePicker_uyelikTarihi.Text != "")
                    {
                        baglantim.Open();
                        string sorgu = "insert into okuyucu(tcno,adsoyad,telefon,mailadresi,uyeoldugutarih,cinsiyet,aldigikitapsayisi,emanetkitapsayisi,ceza) values (@tcno,@adsoyad,@telefon,@mailadresi,@uyeoldugutarih,@cinsiyet,@aldigikitapsayisi,@emanetkitapsayisi,@ceza)";
                        OleDbCommand komut = new OleDbCommand(sorgu, baglantim);
                        komut.Parameters.AddWithValue("@tcno", Txt_tcNo.Text);
                        komut.Parameters.AddWithValue("@adsoyad", Txt_adSoyad.Text);
                        komut.Parameters.AddWithValue("@telefon", Txt_telefon.Text);
                        komut.Parameters.AddWithValue("@mailadresi", Txt_email.Text);
                        komut.Parameters.AddWithValue("@uyeoldugutarih", dateTimePicker_uyelikTarihi.Text);
                        komut.Parameters.AddWithValue("@cinsiyet", comboBox_Cinsiyet.Text);
                        komut.Parameters.AddWithValue("@aldigikitapsayisi", 0);
                        komut.Parameters.AddWithValue("@emanetkitapsayisi", 0);
                        komut.Parameters.AddWithValue("@ceza", 0);
                        komut.ExecuteNonQuery();
                        baglantim.Close();
                        MessageBox.Show("Veriler başarıyla kaydedildi");
                        Hepsinisil();

                    }




                }

            }
            catch (Exception h)
            {
                MessageBox.Show("İşlem sırasında hata oluştu:" + h.ToString());

            }
            baglantim.Close();
        }

        private void Btn_ogrenciGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (Txt_tcNo.Text != "" && Txt_adSoyad.Text != "" && Txt_telefon.Text != "" && Txt_email.Text != "" && dateTimePicker_uyelikTarihi.Text != "" && comboBox_Cinsiyet.Text != "" && Txt_tcNo.Text.Length == 11)
                {
                    if (baglantim.State == ConnectionState.Closed)
                    {
                        baglantim.Open();

                        string Sorgu = "update okuyucu set adsoyad=@adsoyad,telefon=@telefon,mailadresi=@mailadresi,uyeoldugutarih=@uyeoldugutarih,cinsiyet=@cinsiyet where tcno like '" + Txt_tcNo.Text + "%'";
                        OleDbCommand Komut = new OleDbCommand(Sorgu, baglantim);

                        Komut.Parameters.AddWithValue("@adsoyad", Txt_adSoyad.Text);
                        Komut.Parameters.AddWithValue("@telefon", Txt_telefon.Text);
                        Komut.Parameters.AddWithValue("@mailadresi", Txt_email.Text);
                        Komut.Parameters.AddWithValue("@uyeoldugutarih", dateTimePicker_uyelikTarihi.Text);
                        Komut.Parameters.AddWithValue("@cinsiyet", comboBox_Cinsiyet.Text);

                        Komut.ExecuteNonQuery();
                        baglantim.Close();

                        MessageBox.Show("Kayıtlar Başarılı Bir Şekilde Güncellendi.");

                        Hepsinisil();


                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Boş Alanları Doldurunuz");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "Güncelleme Problemi");
                baglantim.Close();
            }
        }

        private void Btn_ogrenciSil_Click(object sender, EventArgs e)
        {
            try
            {
                baglantim.Open();
                //Öğrenciyi veritabanından silme sorgusu
                string Sorgu = "delete from okuyucu where tcno like '" + Txt_tcNo.Text + "%'";
                OleDbCommand Komut = new OleDbCommand(Sorgu, baglantim);
                string SilinsinMi = Txt_tcNo.Text.ToString();
                //Öğrencinin silinip silinmemesi için bir uyarı oluşturuldu
                DialogResult Durum = MessageBox.Show(SilinsinMi + " TC Numaralı Kayıt Silinsin Mi ? ", " Silme Onayı ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                //Yes seçilirse silinecek
                if (DialogResult.Yes == Durum)
                {
                    Komut.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı Bir Şekilde Silindi.");
                    Hepsinisil();//alanlar temizleniyor

                }
                baglantim.Close();
            }
            catch (Exception hata)
            {
                //bir hata oluşursa hata mesajı veriliyor, her ihtimale karşı
                //veri tabanı bağlantısı kapatılıyor
                MessageBox.Show(hata.Message, "Silme Problemi");
                baglantim.Close();
            }
        }

        private void TxtTCNOKarakter(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != 08)
            {
                e.Handled = true;//TCye harf girişi engelleniyor

            }

        }

        private void TxtEmailKontrol(object sender, CancelEventArgs e)
        {   //Girilen mailin uygunluğu
            //Emailde @ ve . konulup konulmama kontrolleri
            try
            {
                AtIsareti = Txt_email.Text.IndexOf("@", 1);

                // @ den sonra . geliyorsa
                if (AtIsareti > 0)
                {
                    NoktaIsareti = Txt_email.Text.IndexOf(".", AtIsareti + 1);
                }
                // @ ve nokta yoksa
                if (AtIsareti < 0 || NoktaIsareti < 0 || NoktaIsareti == Txt_email.Text.Length - 1)
                {
                    MessageBox.Show("Mail adresinizi yalnış girdiniz", "MAIL HATA");
                    e.Cancel = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen Epostayi Tam Giriniz.", "Mail Kontrol");
                Txt_email.Focus();
            }

        }

        private void TCkarsilastirma(object sender, EventArgs e)
        {//Girilen Tc veritabanında eşleşiyorsa güncelleme ve silme aktif oluyor
            if (Txt_tcNo.Text.Length == 11)
            {

                if (baglantim.State == ConnectionState.Closed)
                {
                    baglantim.Open();
                    string Sorgu = "select tcno from okuyucu"; //Veri tabanında n TCNO lar çekiliyor
                    OleDbCommand Komut = new OleDbCommand(Sorgu, baglantim);
                    OleDbDataReader Oku = Komut.ExecuteReader();

                    while (Oku.Read())
                    {
                        if (Txt_tcNo.Text == Oku[0].ToString())
                        {

                            MessageBox.Show("Kayıtlı Kullanıcı Girdiniz ");

                            Btn_ogrenciEkle.Enabled = false;
                            //Artık günvelleme ve silme işlemleri yapıla bilecek
                            Btn_ogrenciSil.Enabled = true;
                            Btn_ogrenciGuncelle.Enabled = true;

                            string SorguGuncelle = ("select * from okuyucu where tcno like '" + Txt_tcNo.Text + "%'");
                            OleDbCommand KomutGuncelle = new OleDbCommand(SorguGuncelle, baglantim);
                            OleDbDataReader OkuGuncelle = KomutGuncelle.ExecuteReader();

                            while (OkuGuncelle.Read())
                            {
                                if (Txt_tcNo.Text == OkuGuncelle[0].ToString())
                                {
                                    Txt_tcNo.Text = OkuGuncelle[0].ToString();
                                    Txt_adSoyad.Text = OkuGuncelle[1].ToString();
                                    Txt_telefon.Text = OkuGuncelle[2].ToString();
                                    Txt_email.Text = OkuGuncelle[3].ToString();
                                    dateTimePicker_uyelikTarihi.Text = OkuGuncelle[4].ToString();
                                    comboBox_Cinsiyet.Text = OkuGuncelle[5].ToString();

                                }

                            }
                        }
                    }
                    baglantim.Close();
                }
            }
            if (Txt_tcNo.Text.Length < 11)
            {
                Btn_ogrenciEkle.Enabled = true;

                Btn_ogrenciGuncelle.Enabled = false;
                Btn_ogrenciSil.Enabled = false;

                Txt_adSoyad.Text = "";
                Txt_telefon.Text = "";
                Txt_email.Text = "";
                dateTimePicker_uyelikTarihi.Text = "";
                comboBox_Cinsiyet.Text = "";

            }


        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void OgrenciIslem_Load(object sender, EventArgs e)
        {
            //Girilen TC kaydı varsa true olacaklar.
            Btn_ogrenciGuncelle.Enabled = false;
            Btn_ogrenciSil.Enabled = false;
        }

      


    }
}
