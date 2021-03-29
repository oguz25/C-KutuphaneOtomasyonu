using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;//Access veri tabanı bağlantısı için gereken kütüphane

namespace KutuphaneOtomasyon0
{
    public partial class KitapListele : Form
    {
        public KitapListele()
        {
            InitializeComponent();
        }

        public OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +
             Application.StartupPath + "\\kutuphane.mdb");
        //Veri tabanı bağlantısı oluşturuluyor


        public void KayitAl()
        {

            try
            {
                baglantim.Open();
                string sorgu = "select kitapid,kitapadi,tur,yazar,yayinevi,basimyeri,basimtarihi,sayfasayisi from kitap";
                OleDbCommand komut = new OleDbCommand(sorgu, baglantim);
                OleDbDataAdapter adapter = new OleDbDataAdapter(komut);
                DataTable table = new DataTable();
                adapter.Fill(table);
                //Datagridde gerekli alanları oluşturarak isimlendirdik.
                dataGridView_Listele.DataSource = table;
                dataGridView_Listele.Columns[0].HeaderText = "KitapID";
                dataGridView_Listele.Columns[1].HeaderText = "Kitap Adi";
                dataGridView_Listele.Columns[2].HeaderText = "Tur";
                dataGridView_Listele.Columns[3].HeaderText = "Yazar";
                dataGridView_Listele.Columns[4].HeaderText = "Yayin Evi";
                dataGridView_Listele.Columns[5].HeaderText = "Basim Yeri";
                dataGridView_Listele.Columns[6].HeaderText = "Basim Tarihi";
                dataGridView_Listele.Columns[7].HeaderText = "Sayfa Sayisi";

                //Alanlara boyut veriliyor
                dataGridView_Listele.Columns[0].Width = 100;
                dataGridView_Listele.Columns[1].Width = 100;
                dataGridView_Listele.Columns[2].Width = 100;
                dataGridView_Listele.Columns[3].Width = 100;
                dataGridView_Listele.Columns[4].Width = 100;
                dataGridView_Listele.Columns[5].Width = 100;
                dataGridView_Listele.Columns[6].Width = 60;

                dataGridView_Listele.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                baglantim.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "Hata!");
                //Hata oluşursa kullanıcı bilgilendiriliyor
                baglantim.Close();
                //bağlantıya her ihtimale karşı kapatma komutu veriliyor
            }

        }


        private void KitapListele_Load(object sender, EventArgs e)
        {
            Txt_arama.Focus();
            KayitAl();//Kitap listesindeki verileri çekip ekrana yazan metot
            Txt_arama.Focus();
        }

        private void Txt_arama_TextChanged(object sender, EventArgs e)
        {
            try
            {
                baglantim.Open();//Veri tabanı bağlantısı açılıyor
                string Sorgu = "select * from kitap where kitapid like '" + Txt_arama.Text + "%'";
                //sorgu yazılıyor kitap tablosundan aranan id ye uygun olan değer için
                OleDbCommand Komut = new OleDbCommand(Sorgu, baglantim);
                //Sorgu bağlantı ile ilişkilendirilip komut oluşturuluyor
                OleDbDataAdapter Adaptor = new OleDbDataAdapter(Komut);
                //OleDbDataAdapter verileri kaynaktan almak için köprü görevi yapar 
                DataTable table = new DataTable();
                Adaptor.Fill(table);
                //Tablo veri tabından gelen bilgilerle doldurulur
                //ardından Datagridviev tablodan verileri alır
                dataGridView_Listele.DataSource = table;
                baglantim.Close();//veri tabanı bağlantısı kapatılır
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "Hata!");
                baglantim.Close();
                //Hata oluşursa bildiriliyor ve bağlantı açık
                //kalmış olabilir diye kapatma komutu veriliyor
            }
        }

        private void Btn_teslimAlanlar_Click(object sender, EventArgs e)
        {

            if (Txt_arama.Text.Length == 6)
            {
                try
                {
                    baglantim.Open();

                    string Sorgu = "select adsoyad,tcno,kitapid,alistarihi,teslimtarihi from emanet where kitapid like '" + Txt_arama.Text + "%' ";
                    OleDbCommand Komut = new OleDbCommand(Sorgu, baglantim);
                    OleDbDataAdapter Adapter = new OleDbDataAdapter(Komut);
                    DataTable table = new DataTable();
                    Adapter.Fill(table);
                    dataGridView_Listele.DataSource = table;

                    dataGridView_Listele.Columns[0].HeaderText = "Tc Kimlik No";
                    dataGridView_Listele.Columns[1].HeaderText = "Ad Soyad";
                    dataGridView_Listele.Columns[2].HeaderText = "KitapID ";
                    dataGridView_Listele.Columns[3].HeaderText = "Başlangic Tarihi";
                    dataGridView_Listele.Columns[4].HeaderText = "Teslim Tarihi";

                    dataGridView_Listele.Columns[0].Width = 100;
                    dataGridView_Listele.Columns[1].Width = 100;
                    dataGridView_Listele.Columns[2].Width = 100;
                    dataGridView_Listele.Columns[3].Width = 100;
                    dataGridView_Listele.Columns[4].Width = 100;

                    dataGridView_Listele.Width = 500;
                    dataGridView_Listele.Height = 200;

                    this.ClientSize = new System.Drawing.Size(550, 350);




                    dataGridView_Listele.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
                catch (Exception h)
                {

                    MessageBox.Show("Hata" + h);
                }
            }
            else
            {
                MessageBox.Show("Lütfen Bir ID Numarası Giriniz");
            }


            baglantim.Close();//Bağlantı kapatılıyor
        }

        private void DataGridsome(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 08)
            {
                this.ClientSize = new System.Drawing.Size(885, 360);
                dataGridView_Listele.Width = 836;
                dataGridView_Listele.Height = 269;

            }
        }
    }
}
