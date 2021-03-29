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
    public partial class EmanetAl : Form
    {
        public EmanetAl()
        {
            InitializeComponent();
        }

        public OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +
          Application.StartupPath + "\\kutuphane.mdb");

        public void KitapKayit()
        {
            string emanetsayisi = "select emanetkitapsayisi from okuyucu where tcno like'" + Txt_TC.Text + "%'";
            OleDbCommand emanetkomut = new OleDbCommand(emanetsayisi, baglantim);
            OleDbDataReader emanetoku = emanetkomut.ExecuteReader();
            while (emanetoku.Read()) // Kayıda kadar okuma işlemi yapılıyor.
            {
                int Okuyucu = Convert.ToInt32(emanetoku[0]); // Öğrencinin emanet sayısı alınıyor.
                if (Okuyucu < 5) // Bir öğrenciye efazla 5 kitap verilir. Eğer emanet sayısı 5'ten küçükse kitap alabilir.
                {
                    string Emanet = "Teslim Edilmedi";

                    string Sorgu = "insert into emanet(adsoyad,tcno,kitapid,kitapadi,alistarihi,bitistarihi,teslimtarihi,durum) values (@adsoyad,@tcno,@kitapid,@kitapadi,@alistarihi,@bitistarihi,@teslimtarihi,@durum)";
                    OleDbCommand Komut = new OleDbCommand(Sorgu, baglantim);
                    // Sorgu ile veritabanına emanet kaydediliyor.
                    Komut.Parameters.AddWithValue("@adsoyad", Txt_adSoyad.Text);
                    Komut.Parameters.AddWithValue("@tcno", Txt_TC.Text);
                    Komut.Parameters.AddWithValue("@kitapid", Txt_kitapID.Text);
                    Komut.Parameters.AddWithValue("@kitapadi", Txt_kitapID.Text);
                    Komut.Parameters.AddWithValue("@alistarihi", dateTimePicker_Baslangic.Text);

                    Komut.Parameters.AddWithValue("@bitistarihi", dateTimePicker_Bitis.Text);
                    Komut.Parameters.AddWithValue("@teslimtarihi", dateTimePicker_Bitis.Text);
                    Komut.Parameters.AddWithValue("@durum", Emanet);
                    Komut.ExecuteNonQuery();
                    // Sorgu ile alınan kitabı başkası almasın diye durumu '0' yapılıyor.
                    string SorguKitapDurumu1 = "update kitap set kitapdurumu=@kitapdurumu where kitapid like '" + Txt_kitapID.Text + "%'";
                    OleDbCommand KomutKitapDurumu1 = new OleDbCommand(SorguKitapDurumu1, baglantim);
                    KomutKitapDurumu1.Parameters.AddWithValue("@kitapdurumu", 0);
                    KomutKitapDurumu1.ExecuteNonQuery();
                    // Sorgu ile KitapSayısı ve Emanet Sayısı Text teki TCNO ya göre Okuyucu dan getirilir
                    string SorguOkuyucuKitapSayisi = "select aldigikitapsayisi,emanetkitapsayisi from okuyucu where tcno like '" + Txt_TC.Text + "%'";
                    OleDbCommand KomutOkuyucuKitapSayisi = new OleDbCommand(SorguOkuyucuKitapSayisi, baglantim);
                    OleDbDataReader OkuyucuKitapSayisi = KomutOkuyucuKitapSayisi.ExecuteReader();


                    while (OkuyucuKitapSayisi.Read()) // Okuma işlemi yapılıyr
                    {
                        int KitapSayisi = Convert.ToInt32(OkuyucuKitapSayisi[0]); //   Veritabanından gelen Değerler ilgili değişkene aktarılr
                        int EmanetSayisi = Convert.ToInt32(OkuyucuKitapSayisi[1]);//   Veritabanından gelen Değerler ilgili değişkene aktarılr

                        KitapSayisi = KitapSayisi + 1; // Kitap Sayısı 1 arttırılır
                        EmanetSayisi = EmanetSayisi + 1; // Emaet Sayısı 1 Arttırılır
                        MessageBox.Show("Kitap Sayisi " + KitapSayisi.ToString()); // Kaç Kitap Adlığı Toplamda Ekrana Yazdırılır
                                                                                   //Sorgu ile emanet sayisi ve kitap sayisi ogrenci TCNO ya göre 1 arttırılarak okuyucu dakideğerleri güncellenir.
                                                                                   // Sorguile KitapSayisi ve Emanet Sayısı Okuyucu TCNO ya göre 1 er artırılıp Okuyucu daki karşılıklı yerlerine update ettirilir.
                        string SorguOkuyucuKSayi = "update okuyucu set aldigikitapsayisi=@aldigikitapsayisi, emanetkitapsayisi=@emanetkitapsayisi where tcno like '" + Txt_TC.Text + "%'";
                        OleDbCommand KomutOkuyucuDurumu = new OleDbCommand(SorguOkuyucuKSayi, baglantim);
                        KomutOkuyucuDurumu.Parameters.AddWithValue("@aldigikitapsayisi", KitapSayisi);
                        KomutOkuyucuDurumu.Parameters.AddWithValue("@aldigikitapsayisi", EmanetSayisi);
                        KomutOkuyucuDurumu.ExecuteNonQuery();
                    }


                    string SorguOgr = "select tcno,adsoyad,emanetkitapsayisi from okuyucu";
                    OleDbCommand KomutOgr = new OleDbCommand(SorguOgr, baglantim);
                    OleDbDataAdapter AdaptorOgr = new OleDbDataAdapter(KomutOgr);
                    DataTable TableOgr = new DataTable(); // TAble olusturuluyor
                    AdaptorOgr.Fill(TableOgr); //Tablela veritabanındaki bilgiler ekleniyor.
                    dataGridView_OgrenciBilgileri.DataSource = TableOgr;
                    // Datagride headerlar veriliyor.
                    dataGridView_OgrenciBilgileri.Columns[0].HeaderText = "TC NO";
                    dataGridView_OgrenciBilgileri.Columns[1].HeaderText = "Adı Soyadı";
                    dataGridView_OgrenciBilgileri.Columns[2].HeaderText = "Emanet Kitap Sayısı";

                    // DataGrid sütun uzunlukları ayarlanıyor.
                    dataGridView_OgrenciBilgileri.Columns[0].Width = 100;
                    dataGridView_OgrenciBilgileri.Columns[1].Width = 135;
                    dataGridView_OgrenciBilgileri.Columns[2].Width = 83;
                    dataGridView_OgrenciBilgileri.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // tüm satır seçiliyor.             

                    label_BitisTarihi.Visible = true;
                    dateTimePicker_Bitis.Visible = true;

                    MessageBox.Show("Kitap Teslimi Kullanıcı Üzerine Yapıldı", "Sonuç");
                }
                else
                {
                    MessageBox.Show(" Emanet Sayısı 5 Kitabı Aşamaz. Bu Kitabı Alamazsınız", "Uyarı");
                }
            }

        }

        private void Btn_kitapTeslim_Click(object sender, EventArgs e)
        {
            KitapBirak birak = new KitapBirak();
            birak.Show();
        }

        private void Btn_kitapAl_Click(object sender, EventArgs e)
        {

            if (Txt_kitapID.Text != "" && Txt_kitapAdi.Text != "" && Txt_TC.Text != "" && Txt_adSoyad.Text != "" && Txt_emanetAldSayi.Text != "")
            {
                if (baglantim.State == ConnectionState.Closed)
                {
                    baglantim.Open();
                    // burada sorgu  ile  emanetalıcı_txt barkod numarasına göre BarkodNo ve EmanetDurumu nu getirtiriliyor.
                    string SorguKontrolKitapID = "select kitapid,durum from emanet where kitapid like '" + Txt_kitapID.Text + "%' ";
                    OleDbCommand KomutKontrolKitapID = new OleDbCommand(SorguKontrolKitapID, baglantim);
                    OleDbDataReader OkuKontrolKitapID = KomutKontrolKitapID.ExecuteReader();



                    if (OkuKontrolKitapID.HasRows == false) // Veritabanında kayıdın olup olmadığı kontrol ediliyor.Yoksa kayıt yapılıyor.
                    {



                        KitapKayit();


                    }
                    else
                    {

                        string KitapDurumu = "select kitapdurumu from kitap where kitapid like '" + Txt_kitapID.Text + "%'";
                        OleDbCommand KomutKitapDurumu = new OleDbCommand(KitapDurumu, baglantim);
                        OleDbDataReader OkuKitapDurumu = KomutKitapDurumu.ExecuteReader();

                        int Durum = 0;

                        while (OkuKitapDurumu.Read())
                        {
                            if (Durum == Convert.ToInt32(OkuKitapDurumu["kitapdurumu"])) // Kitap Durumu Kontrol eidliyor 0 ise başkasına verilmiyor.
                            {
                                MessageBox.Show("Bu Kitap Başka Kullanıcı Üzerinde Bulunmaktadır. Kitap Teslim Verilemez ", "UYARI");
                            }
                            else
                            {
                                KitapKayit(); // Değilse kitap kayıt edilir.

                            }
                        }
                    }
                    baglantim.Close();

                }
            }
            else
            {
                MessageBox.Show("Bilgileri eksik doldurdunuz");
            }
            Form1 grafik = new Form1();
        }

        private void EmanetAl_Load(object sender, EventArgs e)
        {
            //Datagridview deki verilere tıklandığında değiştirilmemesi için değerlerini true yapıyoruz.
            dataGridView_KitapBilgileri.ReadOnly = true;
            dataGridView_OgrenciBilgileri.ReadOnly = true;
            //textboxlara dışarıdan girişler engelleniyor.
            Txt_TC.ReadOnly = true;
            Txt_adSoyad.ReadOnly = true;
            Txt_emanetAldSayi.ReadOnly = true;
            Txt_kitapID.ReadOnly = true;
            Txt_kitapAdi.ReadOnly = true;
            dateTimePicker_Baslangic.Enabled = false;
            dateTimePicker_Bitis.Visible = true; ;
            label_BitisTarihi.Visible = true;


            Txt_ogrTCAra.Focus();

            baglantim.Open(); //veri tabanı bağlantısı açılıyor
            // Sorgu ile okuyucular listeleniyor.
            string SorguOgr = "select tcno,adsoyad,emanetkitapsayisi from okuyucu";
            OleDbCommand KomutOgr = new OleDbCommand(SorguOgr, baglantim);
            OleDbDataAdapter AdaptorOgr = new OleDbDataAdapter(KomutOgr);
            DataTable TableOgr = new DataTable();
            AdaptorOgr.Fill(TableOgr);
            dataGridView_OgrenciBilgileri.DataSource = TableOgr;

            dataGridView_OgrenciBilgileri.Columns[0].HeaderText = "Tc Kimlik No";
            dataGridView_OgrenciBilgileri.Columns[1].HeaderText = "Adı Soyadı";
            dataGridView_OgrenciBilgileri.Columns[2].HeaderText = "Emanet Sayısı";


            dataGridView_OgrenciBilgileri.Columns[0].Width = 100;
            dataGridView_OgrenciBilgileri.Columns[1].Width = 135;
            dataGridView_OgrenciBilgileri.Columns[2].Width = 83;
            dataGridView_OgrenciBilgileri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            baglantim.Close();



            baglantim.Open();
            // Sorgu ile kitap bilgilerini datagridkitap'a yazdırılıyor.
            string SorguKtp = "select kitapid,kitapadi,tur,yazar from kitap";
            OleDbCommand KomutKtp = new OleDbCommand(SorguKtp, baglantim);
            OleDbDataAdapter AdaptorKtp = new OleDbDataAdapter(KomutKtp);
            DataTable TableKtp = new DataTable();
            AdaptorKtp.Fill(TableKtp);
            dataGridView_KitapBilgileri.DataSource = TableKtp;

            //  DataGridKitap Header Text lerini ayarlanyor.
            dataGridView_KitapBilgileri.Columns[0].HeaderText = "KitapID";
            dataGridView_KitapBilgileri.Columns[1].HeaderText = "Ktap Adı";
            dataGridView_KitapBilgileri.Columns[2].HeaderText = "Kitap Türü";
            dataGridView_KitapBilgileri.Columns[3].HeaderText = "Kitap Yazarı";

            // DataGridKitap sütun uzunluklarını ayarlanıyor.
            dataGridView_KitapBilgileri.Columns[0].Width = 100;
            dataGridView_KitapBilgileri.Columns[1].Width = 130;
            dataGridView_KitapBilgileri.Columns[2].Width = 113;
            dataGridView_KitapBilgileri.Columns[3].Width = 115;
            dataGridView_KitapBilgileri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            baglantim.Close();
        }

        private void textBox_KitapAd_TextChanged(object sender, EventArgs e)
        {

            baglantim.Open();
            // Barkod numarasında girilen değerler ile başlayanalr gelecek
            string SorguKtp = "select kitapid,kitapadi,tur,yazar from kitap where kitapadi like '" + textBox_KitapAd.Text + "%'";
            OleDbCommand KomutKtp = new OleDbCommand(SorguKtp, baglantim);
            OleDbDataAdapter AdaptorKtp = new OleDbDataAdapter(KomutKtp);
            DataTable TableKtp = new DataTable();
            AdaptorKtp.Fill(TableKtp);
            dataGridView_KitapBilgileri.DataSource = TableKtp;


            dataGridView_KitapBilgileri.Columns[0].HeaderText = "KitapId";
            dataGridView_KitapBilgileri.Columns[1].HeaderText = "Ktap Adı";
            dataGridView_KitapBilgileri.Columns[2].HeaderText = "Kitap Türü";
            dataGridView_KitapBilgileri.Columns[3].HeaderText = "Kitap Yazarı";


            dataGridView_KitapBilgileri.Columns[0].Width = 100;
            dataGridView_KitapBilgileri.Columns[1].Width = 130;
            dataGridView_KitapBilgileri.Columns[2].Width = 113;
            dataGridView_KitapBilgileri.Columns[3].Width = 115;


            dataGridView_KitapBilgileri.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // DataGridView deki tüm satır seçilir.

            baglantim.Close();
        }

        private void dataGridView_OgrenciBilgileri_Click(object sender, EventArgs e)
        {
            try
            {   //Herhangi bir yere tıklandığında hata almamak için try-catch kullanıldı.
                Txt_TC.Text = dataGridView_OgrenciBilgileri.SelectedRows[0].Cells[0].Value.ToString();
                Txt_adSoyad.Text = dataGridView_OgrenciBilgileri.SelectedRows[0].Cells[1].Value.ToString();
                Txt_emanetAldSayi.Text = dataGridView_OgrenciBilgileri.SelectedRows[0].Cells[2].Value.ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen Emanet Almak için istenilen Alanı Seçiniz.", "HATA!!");
            }
        }

        private void dataGridView_KitapBilgileri_Click(object sender, EventArgs e)
        {
            try
            {
                dateTimePicker_Bitis.Visible = true; // Burada Datagrid de farklı kayıt seçildiği zaman görünürlüklerini değiştirildi
                label_BitisTarihi.Visible = true;

                Txt_kitapID.Text = dataGridView_KitapBilgileri.SelectedRows[0].Cells[0].Value.ToString();
                Txt_kitapAdi.Text = dataGridView_KitapBilgileri.SelectedRows[0].Cells[1].Value.ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen Emanet Almak için istenilen Alanı Seçiniz.", "HATA");
            }
        }

        private void Txt_ogrTCAra_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Eğer öğrenci tc değiştirilirse aşağıdaki kodlar devreye girecek.

                baglantim.Open();
                // burada sorgu ile ogrencitc TextBox takki gibi olursa Bize TCNO AdSoyad EmanetSayisi ni vericek
                string Sorgu = "select tcno,adsoyad,emanetkitapsayisi from okuyucu where tcno like '" + Txt_ogrTCAra.Text + "%'";
                // Bastığımız sayılarla başlayanlar sıralanacak
                OleDbCommand Komut = new OleDbCommand(Sorgu, baglantim);
                OleDbDataAdapter Adaptor = new OleDbDataAdapter(Komut);
                DataTable Table = new DataTable();
                Adaptor.Fill(Table);
                dataGridView_OgrenciBilgileri.DataSource = Table;

                dataGridView_OgrenciBilgileri.Columns[0].HeaderText = "TC NO";
                dataGridView_OgrenciBilgileri.Columns[1].HeaderText = "Adı Soyadı";
                dataGridView_OgrenciBilgileri.Columns[2].HeaderText = "Emanet Kitap Sayısı";


                dataGridView_OgrenciBilgileri.Columns[0].Width = 100;
                dataGridView_OgrenciBilgileri.Columns[1].Width = 135;
                dataGridView_OgrenciBilgileri.Columns[2].Width = 83;

                dataGridView_OgrenciBilgileri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                baglantim.Close();
            }
            catch (Exception hata)
            {   //Hata oluşursa kullanıcı bilgilendiriliyor
                MessageBox.Show(hata.Message);
                baglantim.Close();
                //Hata sonucu bağlantı kapanmamıl olabilir, bağlantı kapatılıyor.
            }
        }
        //Veri tabanı için bağlantı oluşturuldu


    }
}
