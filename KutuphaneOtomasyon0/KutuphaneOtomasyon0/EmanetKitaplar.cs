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
    public partial class EmanetKitaplar : Form
    {
        public EmanetKitaplar()
        {
            InitializeComponent();
        }
        public OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +
            Application.StartupPath + "\\kutuphane.mdb");
        private void EmanetKitaplar_Load(object sender, EventArgs e)
        {
            dataGridView_emanetKitaplar.ReadOnly = true;
            // Readonly true yapılarak üstüne tıklandığında içeriğinin 
            // değiştirilememesi için böyle bir parametre koyduk
            baglantim.Open();
            goster();
            baglantim.Close();
        }

       
        public void TeselimetmeyenlerGoster()
        {
            string Sorgu = "Select adsoyad,tcno,kitapadi,durum,bitistarihi,teslimtarihi From emanet Where durum Like '" + "Teslim Edilmedi" + "'";
            OleDbCommand Komut = new OleDbCommand(Sorgu, baglantim);
            OleDbDataAdapter Adapter = new OleDbDataAdapter(Komut);
            DataTable Table = new DataTable();
            Adapter.Fill(Table);

            dataGridView_emanetKitaplar.DataSource = Table;
            dataGridView_emanetKitaplar.Columns[0].HeaderText = "Ad Soyad";
            dataGridView_emanetKitaplar.Columns[1].HeaderText = "TC NO";
            dataGridView_emanetKitaplar.Columns[2].HeaderText = "Kitap Adı";
            dataGridView_emanetKitaplar.Columns[3].HeaderText = "Durum";
            dataGridView_emanetKitaplar.Columns[4].HeaderText = "Bitiş Tarihi";
            dataGridView_emanetKitaplar.Columns[5].HeaderText = "Teslim Tarihi";


            dataGridView_emanetKitaplar.Columns[0].Width = 110;
            dataGridView_emanetKitaplar.Columns[1].Width = 100;
            dataGridView_emanetKitaplar.Columns[2].Width = 100;
            dataGridView_emanetKitaplar.Columns[3].Width = 100;
            dataGridView_emanetKitaplar.Columns[4].Width = 120;
            dataGridView_emanetKitaplar.Columns[5].Width = 120;



            for (int i = 0; i < dataGridView_emanetKitaplar.Rows.Count - 1; i++)
            {
                DataGridViewCellStyle CellColor = new DataGridViewCellStyle();


                DateTime Tarih; // Tarih değişkeni oluşturduk.
                Tarih = Convert.ToDateTime(dataGridView_emanetKitaplar.Rows[i].Cells[4].Value); // DataGrid deki Tarih değişkenini Tarih değişkenimize aktardık.

                DateTime Suan = Convert.ToDateTime(DateTime.Now.ToLongDateString());


                TimeSpan GunFarki = Suan.Subtract(Tarih); // Suanki zaman ile veritabanındaki kayıt zamanı karşılaştırılıyor
                // Bu karşılaştırma sonucuna görede renklendirme işlemi yapılıyr.
                //Alttaki kodda integer türüne çevirme işlemi yapılmıştır.
                int Fark = int.Parse(GunFarki.Days.ToString());
                // MessageBox.Show(Fark.ToString());
                // MessageBox.Show(Fark.ToString());
                if ((dataGridView_emanetKitaplar.Rows[i].Cells[3].Value.ToString() == "Teslim Edilmedi"))
                {
                    if (Fark < -2)
                    { // Günü daha çok varsa =) yeşil yaptık.
                        CellColor.BackColor = Color.Green;
                        CellColor.ForeColor = Color.White;
                        dataGridView_emanetKitaplar.Rows[i].DefaultCellStyle = CellColor;
                    }
                    else if (Fark <= 2)
                    { // Güne iki gün kalmışsa Pembe renk yaptık
                        CellColor.BackColor = Color.Yellow; 
                        CellColor.ForeColor = Color.Black;
                        dataGridView_emanetKitaplar.Rows[i].DefaultCellStyle = CellColor;
                    }
                    if (Fark > 0)
                    {

                        // Eğer günü geçmişse DataGrid de kırmızı renk ile boyanıyor satır
                        CellColor.BackColor = Color.Red;
                        CellColor.ForeColor = Color.White;
                        dataGridView_emanetKitaplar.Rows[i].DefaultCellStyle = CellColor;

                    }
                }
                else
                {
                    // Eğer Teslim edildi ise direk yeşil renk yapımı sağlanıyor.
                    CellColor.BackColor = Color.Green;
                    CellColor.ForeColor = Color.White;
                    dataGridView_emanetKitaplar.Rows[i].DefaultCellStyle = CellColor;
                }
            }


        }

        public void goster()
        {

            // Aşağıdaki Sorgu cümleciği ile Emanet Table dan istenen bilgiler çekilip DataGrid e dolduruluyor
            string Sorgu = "Select adsoyad,tcno,kitapadi,durum,bitistarihi,teslimtarihi From emanet";
            OleDbCommand Komut = new OleDbCommand(Sorgu, baglantim);
            OleDbDataAdapter Adapter = new OleDbDataAdapter(Komut);
            DataTable Table = new DataTable();
            Adapter.Fill(Table);

            dataGridView_emanetKitaplar.DataSource = Table;//Veri kaynağı atanıyor
            dataGridView_emanetKitaplar.Columns[0].HeaderText = "Ad Soyad";
            dataGridView_emanetKitaplar.Columns[1].HeaderText = "TC NO";

            dataGridView_emanetKitaplar.Columns[2].HeaderText = "Kitap Adı";
            dataGridView_emanetKitaplar.Columns[3].HeaderText = "Durumu";
            dataGridView_emanetKitaplar.Columns[4].HeaderText = "Bitiş Tarihi";
            dataGridView_emanetKitaplar.Columns[5].HeaderText = "Teslim Tarihi";


            dataGridView_emanetKitaplar.Columns[0].Width = 110;
            dataGridView_emanetKitaplar.Columns[1].Width = 100;
            dataGridView_emanetKitaplar.Columns[2].Width = 100;
            dataGridView_emanetKitaplar.Columns[3].Width = 100;
            dataGridView_emanetKitaplar.Columns[4].Width = 120;
            dataGridView_emanetKitaplar.Columns[5].Width = 120;
            // Üst tarafdaki kod blokları DataGrid header adlarının ve  uzunluklarının belirlenmesi için kullanıldı.


            for (int i = 0; i < dataGridView_emanetKitaplar.Rows.Count - 1; i++) // DataGrid in satırları saydırılıyor
            {
                DataGridViewCellStyle CellColor = new DataGridViewCellStyle(); // Renklendirmek için bunu kullanıyoruz.


                DateTime Tarih; // Tarih değişkeni oluşturduk.
                Tarih = Convert.ToDateTime(dataGridView_emanetKitaplar.Rows[i].Cells[4].Value); // DataGrid deki Tarih değişkenini Tarih değişkenimize aktardık.

                DateTime Suan = Convert.ToDateTime(DateTime.Now.ToLongDateString()); // Şuanki saati çekiyorz.


                TimeSpan GunFarki = Suan.Subtract(Tarih); // Suanki zaman ile veritabanındaki kayıt zamanı karşılaştırılıyor
                // Bu karşılaştırma sonucuna görede renklendirme işlemi yapılıyr.
                //Alttaki kodda integer türüne çevirme işlemi yapılmıştır.
                int Fark = int.Parse(GunFarki.Days.ToString());
                // MessageBox.Show(Fark.ToString());
                // MessageBox.Show(Fark.ToString());
                if ((dataGridView_emanetKitaplar.Rows[i].Cells[3].Value.ToString() == "Teslim Edilmedi")) // DataGrid in Emanet Durumu hücresi Teslim Edilmedi ise
                { // aşağıdaki kod blokları çalışıyor
                    if (Fark < -2)
                    { // Günü daha çok varsa =) yeşil yaptık.
                        CellColor.BackColor = Color.Green;
                        CellColor.ForeColor = Color.White;
                        dataGridView_emanetKitaplar.Rows[i].DefaultCellStyle = CellColor;
                    }
                    else if (Fark <= 2)
                    { // Güne iki gün kalmışsa Pembe renk yaptık
                        CellColor.BackColor = Color.Yellow; 
                        CellColor.ForeColor = Color.Black;
                        dataGridView_emanetKitaplar.Rows[i].DefaultCellStyle = CellColor;
                    }
                    if (Fark > 0)
                    {

                        // Eğer günü geçmişse DataGrid de kırmızı renk ile boyanıyor satır
                        CellColor.BackColor = Color.Red;
                        CellColor.ForeColor = Color.White;
                        dataGridView_emanetKitaplar.Rows[i].DefaultCellStyle = CellColor;

                    }
                }
                else
                {
                    // Eğer Teslim edildi ise direk yeşil renk yapımı sağlanıyor.
                    CellColor.BackColor = Color.Green;
                    CellColor.ForeColor = Color.White;
                    dataGridView_emanetKitaplar.Rows[i].DefaultCellStyle = CellColor;
                }
            }


        }

        public void TcNoileGoster()
        {
            // Aşağdaki sorgu cümleciği Goster ile aynı ama sadece Tc numaraya göre kayıt gösteriyor
            string Sorgu = "Select adsoyad,tcno,kitapadi,bitistarihi,teslimtarihi,durum From emanet Where tcno LIKE '" + Txt_tcileSorgula.Text + "%'";
            OleDbCommand Komut = new OleDbCommand(Sorgu, baglantim);
            OleDbDataAdapter Adapter = new OleDbDataAdapter(Komut);
            DataTable Table = new DataTable();
            Adapter.Fill(Table);

            dataGridView_emanetKitaplar.DataSource = Table;
            dataGridView_emanetKitaplar.Columns[0].HeaderText = "Ad Soyad";
            dataGridView_emanetKitaplar.Columns[1].HeaderText = "TC NO";
            dataGridView_emanetKitaplar.Columns[2].HeaderText = "Kitap Adı";
            dataGridView_emanetKitaplar.Columns[3].HeaderText = "Bitiş Tarihi";
            dataGridView_emanetKitaplar.Columns[4].HeaderText = "Teslim Tarihi";
            dataGridView_emanetKitaplar.Columns[5].HeaderText = "Durumu";


            dataGridView_emanetKitaplar.Columns[0].Width = 110;
            dataGridView_emanetKitaplar.Columns[1].Width = 100;
            dataGridView_emanetKitaplar.Columns[2].Width = 100;
            dataGridView_emanetKitaplar.Columns[3].Width = 100;
            dataGridView_emanetKitaplar.Columns[4].Width = 120;
            dataGridView_emanetKitaplar.Columns[5].Width = 120;



            for (int i = 0; i < dataGridView_emanetKitaplar.Rows.Count - 1; i++)
            {
                DataGridViewCellStyle CellColor = new DataGridViewCellStyle();


                DateTime Tarih; // Tarih değişkeni oluşturduk.
                Tarih = Convert.ToDateTime(dataGridView_emanetKitaplar.Rows[i].Cells[4].Value); // DataGrid deki Tarih değişkenini Tarih değişkenimize aktardık.

                DateTime Suan = Convert.ToDateTime(DateTime.Now.ToLongDateString());


                TimeSpan GunFarki = Suan.Subtract(Tarih); // Suanki zaman ile veritabanındaki kayıt zamanı karşılaştırılıyor
                // Bu karşılaştırma sonucuna görede renklendirme işlemi yapılıyr.
                //Alttaki kodda integer türüne çevirme işlemi yapılmıştır.
                int Fark = int.Parse(GunFarki.Days.ToString());
                // MessageBox.Show(Fark.ToString());
                // MessageBox.Show(Fark.ToString());
                if ((dataGridView_emanetKitaplar.Rows[i].Cells[3].Value.ToString() == "Teslim Edilmedi"))
                {
                    if (Fark < -2)
                    { // Günü daha çok varsa =) yeşil yaptık.
                        CellColor.BackColor = Color.Green;
                        CellColor.ForeColor = Color.White;
                        dataGridView_emanetKitaplar.Rows[i].DefaultCellStyle = CellColor;
                    }
                    else if (Fark <= 2)
                    { // Güne iki gün kalmışsa Pembe renk yaptık
                        CellColor.BackColor = Color.Yellow;
                        CellColor.ForeColor = Color.Black;
                        dataGridView_emanetKitaplar.Rows[i].DefaultCellStyle = CellColor;
                    }
                    if (Fark > 0)
                    {

                        // Eğer günü geçmişse DataGrid de kırmızı renk ile boyanıyor satır
                        CellColor.BackColor = Color.Red;
                        CellColor.ForeColor = Color.White;
                        dataGridView_emanetKitaplar.Rows[i].DefaultCellStyle = CellColor;

                    }
                }
                else
                {
                    // Eğer Teslim edildi ise direk yeşil renk yapımı sağlanıyor.
                    CellColor.BackColor = Color.Green;
                    CellColor.ForeColor = Color.White;
                    dataGridView_emanetKitaplar.Rows[i].DefaultCellStyle = CellColor;
                }
            }


        }

        private void Btn_teslimEdilmeyen_Click(object sender, EventArgs e)
        {
            TeselimetmeyenlerGoster();//Bu butona tıklandığında sadece teslime edilmeyenler gösterilecek.

        }

        private void Btn_tumKayitlar_Click(object sender, EventArgs e)
        {
            goster();//Teslim edilen ve teslim edilmeyen herkezi göseterecek.

        }

        private void Txt_tcileSorgula_TextChanged(object sender, EventArgs e)
        {
            TcNoileGoster();//Txt e yazılan TC ile arama yapılacak

        }

        private void dataGridView_emanetKitaplar_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            baglantim.Open();
            goster();//Emanet tablodaki verileri çekip ekrana yazan method
            baglantim.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
