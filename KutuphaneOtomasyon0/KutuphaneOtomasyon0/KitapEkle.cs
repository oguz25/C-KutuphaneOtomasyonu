using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb; //veri tabanı için gereken kütüphane ekleniyor

namespace KutuphaneOtomasyon0
{
    public partial class KitapEkle : Form
    {
        public KitapEkle()
        {
            InitializeComponent();
        }

        public OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +
             Application.StartupPath + "\\kutuphane.mdb");
        //Veri tabanı için gereken Bağlantı oluşturuluyor, 'Projenin Debug klasöründeki veri tabanı'

        public void HepsiniSil()
        {
            for (int i = 0; i < this.Controls.Count; i++)
            //Formda bulunan alanları temizleyen method
            {
                if (Controls[i] is TextBox)      // kaç tane varsa ve aralarından bizim seçtiklerimiz
                {
                    Controls[i].Text = "";
                }
                if (Controls[i] is ComboBox)
                {
                    Controls[i].Text = "";
                }
                if (Controls[i] is DateTimePicker)
                {
                    Controls[i].Text = "";
                }
                if (Controls[i] is MaskedTextBox)
                {
                    Controls[i].Text = "";
                }

            }
        }

        private void Txt_kitapID_TextChanged(object sender, EventArgs e)
        {
            Txt_kitapID.Text = Txt_kitapID.Text.ToUpper();
            Txt_kitapID.SelectionStart = Txt_kitapID.Text.Length;

           
                //Veri tabanı bağlantısı kapalıysa acılıyor
                baglantim.Open();
                string sorgu = "select kitapid from kitap"; //tüm verileri almak için sorgu oluşturuluyor
                OleDbCommand komut = new OleDbCommand(sorgu, baglantim);//sorgu bağlantı ile ilişkilendirilip komutumuz hazır ediliyor
                OleDbDataReader oku = komut.ExecuteReader(); //veri tabanındaki verileri okumak için data reader oluşturuluyor
                
                while (oku.Read())
                {
                    if (Txt_kitapID.Text == oku[0].ToString())
                    {//Girilen Kitap Id si herhangi bir kitapla eşleşirse
                        //veri tabanında var demektir
                        //Bu kitap zaten kayıtlı olduğu için eklenemez
                        //Sadece silme ve güncelleme yapılabilir
                        Btn_kitapEkle.Enabled = false; //Ekleme butonu pasif hale geliyor
                        Btn_kitapSil.Enabled = true; //Sil butonu aktif hale getiriliyor
                        Btn_kitapGuncelle.Enabled = true; //Güncelle butonu aktif hale getiriliyor

                        string Sorgu2 = ("select * from kitap where kitapid like '" + Txt_kitapID.Text + "%'");//ID ile veri çekmek için gereken sorgu
                        //Hali hazırda elimizdeki ID veri tabanında olduğu için
                        //Bu ID ye ait veriler Alanlara doldurulmak üzere veri tabanından çekiliyor
                        OleDbCommand Komut2 = new OleDbCommand(Sorgu2, baglantim); //Sorgu ve baglanti ilişkilendirilip komut oluşturuluyor
                        OleDbDataReader Oku2 = Komut2.ExecuteReader(); //Veri tabanından okuma işlemi yapılıyor

                        while (Oku2.Read())
                        {
                            //ID ile uyuşan değerin bilgileri çekilip alanlar dolduruluyor
                            if (Txt_kitapID.Text == Oku2[0].ToString())
                            {
                                Txt_kitapID.Text = Oku2[0].ToString();
                                Txt_kitapAd.Text = Oku2[1].ToString();
                                Txt_kitapTur.Text = Oku2[2].ToString();
                                Txt_yazar.Text = Oku2[3].ToString();
                                Txt_yayinEvi.Text = Oku2[4].ToString();
                                Txt_basimYeri.Text = Oku2[5].ToString();
                                dateTimePicker_basimTarihi.Text = Oku2[6].ToString();
                                Txt_sayfaSayisi.Text = Oku2[7].ToString();

                            }
                        }
                    }
                }
                baglantim.Close(); //İşlemden sonra veri tabanı bağlantısı kapatılıyor

            
            if (Txt_kitapID.Text.Length < 6)
            {
                Btn_kitapEkle.Enabled = true;
                Btn_kitapGuncelle.Enabled = false;
                Btn_kitapSil.Enabled = false;

                //Alanla temizleniyor
                Txt_kitapAd.Text = "";
                Txt_kitapTur.Text = "";
                Txt_yazar.Text = "";
                Txt_yayinEvi.Text = "";
                Txt_basimYeri.Text = "";
                dateTimePicker_basimTarihi.Text = "";
                Txt_sayfaSayisi.Text = "";


            }
        }

        private void KitapEkle_Load(object sender, EventArgs e)
        {
            Btn_kitapGuncelle.Enabled = false;
            Btn_kitapSil.Enabled = false;
            Txt_kitapID.MaxLength = 6;
        }

        private void Btn_kitapEkle_Click(object sender, EventArgs e)
        {
            try
            {
                
                    if (Txt_kitapID.Text.Length < 6)
                    {
                        MessageBox.Show("Lütfen Kitap Id'yi 4 basamaklı giriniz", "Kitap Id Uzunluğu Hatası");
                    }
                    if (Txt_kitapID.Text.Length == 6 && Txt_kitapAd.Text == "" && Txt_kitapTur.Text == "" && Txt_yazar.Text == "" && Txt_sayfaSayisi.Text == "" && Txt_yayinEvi.Text == "" && Txt_basimYeri.Text == "" && dateTimePicker_basimTarihi.Text == "")
                    {
                        MessageBox.Show("Boş alanları doldurunuz", "Hata");

                    }
                    if (Txt_kitapID.Text != "" && Txt_kitapAd.Text != "" && Txt_kitapTur.Text != "" && Txt_yazar.Text != "" && Txt_sayfaSayisi.Text != "" && Txt_yayinEvi.Text != "" && Txt_basimYeri.Text != "" && dateTimePicker_basimTarihi.Text != "")
                    {
                        baglantim.Open();
                        string sorgu = "insert into kitap(kitapid,kitapadi,tur,yazar,yayinevi,basimyeri,basimtarihi,sayfasayisi,kitapdurumu) values(@kitapid,@kitapadi,@tur,@yazar,@yayinevi,@basimyeri,@basimtarihi,@sayfasayisi,@kitapdurumu)";
                        OleDbCommand komut = new OleDbCommand(sorgu, baglantim);
                        komut.Parameters.AddWithValue("@kitapid", Txt_kitapID.Text);
                        komut.Parameters.AddWithValue("@kitapadi", Txt_kitapAd.Text);
                        komut.Parameters.AddWithValue("@tur", Txt_kitapTur.Text);
                        komut.Parameters.AddWithValue("@yazar", Txt_yazar.Text);
                        komut.Parameters.AddWithValue("@yayinevi", Txt_yayinEvi.Text);
                        komut.Parameters.AddWithValue("@basimyeri", Txt_basimYeri.Text);
                        komut.Parameters.AddWithValue("@basimtarihi", dateTimePicker_basimTarihi.Text);
                        komut.Parameters.AddWithValue("@sayfasayisi", Txt_sayfaSayisi.Text);
                        komut.Parameters.AddWithValue("@kitapdurumu", 1);
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Kitap Başarılı bir şekilde kaydedildi", "Kayıt Sonucu");
                        baglantim.Close();//Bağlantı kapatılıyor

                    }

                

            }
            catch (Exception h)
            {
                MessageBox.Show("İşlem sırasında hata meydana geldi" + h);

                baglantim.Close();//Bağlantı kapatılıyor
                                  //Hata sırasında bağlantı kapatılmamış olabilir bu sebeple 
                                  //kapatılması garantileniyor
            }
            HepsiniSil();//Alanları temizleyen metot
            baglantim.Close();

        }

        private void Btn_kitapGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                //Güncelleme için
                    baglantim.Open();//VT bağlantısı açılıyor
                //Sorgu yazılıyor
                    string sorgu = "update kitap set kitapadi=@kitapadi,tur=@tur,yazar=@yazar,yayinevi=@yayinevi,basimyeri=@basimyeri,basimtarihi=@basimtarihi,sayfasayisi=@sayfasayisi where kitapid='" + Txt_kitapID.Text + "'";
                    OleDbCommand komut = new OleDbCommand(sorgu, baglantim);
                    komut.Parameters.AddWithValue("@kitapadi", Txt_kitapAd.Text);
                    komut.Parameters.AddWithValue("@tur", Txt_kitapTur.Text);
                    komut.Parameters.AddWithValue("@yazar", Txt_yazar.Text);
                    komut.Parameters.AddWithValue("@yayinevi", Txt_yayinEvi.Text);
                    komut.Parameters.AddWithValue("@basimyeri", Txt_basimYeri.Text);
                    komut.Parameters.AddWithValue("@basimtarihi", dateTimePicker_basimTarihi.Text);
                    komut.Parameters.AddWithValue("@sayfasayisi", Txt_sayfaSayisi.Text);
                    komut.ExecuteNonQuery();
                //İşlem yapılıyor
                    baglantim.Close();//Bağlantı kapatılıyor

                    MessageBox.Show("Güncelleme başarılı bir şekilde gerçekleşti", "Güncelleme Sonucu");
                    HepsiniSil();


                
            }
            catch (Exception hata)
            {   //Hata oluşursa yakalanıp kullanıcı bilgilendiriliyor
                MessageBox.Show(hata.Message, "Hata");
                baglantim.Close();//hata sırasında bağlantı kapanmamışsa kapanması garanti ediliyor

            }
        }

        private void Btn_kitapSil_Click(object sender, EventArgs e)
        {
            try
            {
                baglantim.Open();
                //Veri tabanı sorgusu
                string sorgu = "delete from kitap where kitapid like '" + Txt_kitapID.Text + "%'";
                OleDbCommand komut = new OleDbCommand(sorgu, baglantim);
                string onay = Txt_kitapID.Text.ToString();
                DialogResult olay = MessageBox.Show(onay + "kitap ID'li Kayıt Silinsin mi?", "ONAY", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (DialogResult.Yes == olay)
                {   //İşlem onaylanırsa devam ediliyor
                    komut.ExecuteNonQuery();//Veri tabanından silme işlemi yapılıyor
                    MessageBox.Show("Kayıt Başarılı bir şekilde silindi", "Sonuç");
                    HepsiniSil();//ALanları temizleyen metot


                }
                baglantim.Close();
                //Bağlantı kapatılıyor

            }
            catch (Exception hata)
            {
                //Bir hata oluşursa sebebi kullanıcıya bildiriliyor
                MessageBox.Show(hata.Message, "Hata!");
                baglantim.Close();
                //Hata sırasında bağlantı kapatılmamış olabilir bu sebeple 
                //kapatılması garantileniyor
            }
        }

        private void Btn_alanlariTemizle_Click(object sender, EventArgs e)
        {
            HepsiniSil();//Alanları temizleyen metot
            Txt_kitapID.Focus();
        }
    }
}
