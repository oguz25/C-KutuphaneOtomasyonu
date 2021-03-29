using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;//Veri tabanı için gereken kütüphane

namespace KutuphaneOtomasyon0
{
    public partial class KitapBirak : Form
    {
        public KitapBirak()
        {
            InitializeComponent();
        }

        public OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +
           Application.StartupPath + "\\kutuphane.mdb");
        //Veri tabanı için bağlantı oluşturuldu


        private void KitapBirak_Load(object sender, EventArgs e)
        {   //Gerekli bilgiler girilmeden işlem yapılamasın diye ilgili alanların ayarları yapılıyor
            dateTimePicker_teslimTarihi.Enabled = false;
            textBox_Kitap.Visible = false;
            textBox_Kitap.Enabled = false;
            label_Emanet.Visible = false;
            dataGridView_kitapBirak.ReadOnly = true;
        }

        public void Goster()
        {
            //Sorguda join işlemi yapılarak iki tablodan veriler çekiliyor.
            string Sorgu = "Select E.adsoyad,E.tcno,E.kitapadi,E.durum,E.bitistarihi,E.kitapid,O.ceza from emanet E,okuyucu O where O.tcno=E.tcno and E.tcno like '" +
                Txt_TCNO.Text + "%' and E.durum like '" + "Teslim Edilmedi" + "'";
            OleDbCommand Komut = new OleDbCommand(Sorgu, baglantim);
            OleDbDataAdapter Adapter = new OleDbDataAdapter(Komut);
            DataTable Table = new DataTable();
            Adapter.Fill(Table);
            //OleDbDataReader Oku = Komut.ExecuteReader();


            dataGridView_kitapBirak.DataSource = Table;
            dataGridView_kitapBirak.Columns[0].HeaderText = "Ad Soyad";
            dataGridView_kitapBirak.Columns[1].HeaderText = "TC NO";
            dataGridView_kitapBirak.Columns[2].HeaderText = "Kitap Adı";
            dataGridView_kitapBirak.Columns[3].HeaderText = "Emanet Durumu";
            dataGridView_kitapBirak.Columns[4].HeaderText = "Bitiş Tarihi";
            dataGridView_kitapBirak.Columns[5].HeaderText = "Barkod No";
            dataGridView_kitapBirak.Columns[6].HeaderText = "Ceza";


            dataGridView_kitapBirak.Columns[0].Width = 115;
            dataGridView_kitapBirak.Columns[1].Width = 100;
            dataGridView_kitapBirak.Columns[2].Width = 100;
            dataGridView_kitapBirak.Columns[3].Width = 100;
            dataGridView_kitapBirak.Columns[4].Width = 140;
            dataGridView_kitapBirak.Columns[5].Width = 70;
            dataGridView_kitapBirak.Columns[6].Width = 70;



            for (int i = 0; i < dataGridView_kitapBirak.Rows.Count - 1; i++) // DataGrid Satırı saydırılıyor.
            {//DAtagridde renklendirme için cellstyle kullanılıyor
                DataGridViewCellStyle CellColor = new DataGridViewCellStyle();


                DateTime Tarih; // Tarih değişkeni oluşturduk.
                Tarih = Convert.ToDateTime(dataGridView_kitapBirak.Rows[i].Cells[4].Value);

                DateTime Suan = Convert.ToDateTime(DateTime.Now.ToLongDateString());


                TimeSpan GunFarki = Suan.Subtract(Tarih); // Suanki zaman ile veritabanındaki kayıt zamanı karşılaştırılıyor
                                                          // Bu karşılaştırma sonucuna görede renklendirme işlemi yapılıyor.

                int Fark = int.Parse(GunFarki.Days.ToString());

                if ((dataGridView_kitapBirak.Rows[i].Cells[3].Value.ToString() == "Teslim Edilmedi"))
                {
                    if (Fark < -2)
                    { //Daha günü varsa yeşil
                        CellColor.BackColor = Color.Green;
                        CellColor.ForeColor = Color.White;
                        dataGridView_kitapBirak.Rows[i].DefaultCellStyle = CellColor;
                    }
                    else if (Fark <= 2)
                    { // Güne iki gün kalmışsa Sarı
                        CellColor.BackColor = Color.Yellow;
                        CellColor.ForeColor = Color.Black;
                        dataGridView_kitapBirak.Rows[i].DefaultCellStyle = CellColor;
                    }
                    if (Fark > 0)
                    {

                        // günü geçmişse kırmızı
                        CellColor.BackColor = Color.Red;
                        CellColor.ForeColor = Color.White;
                        dataGridView_kitapBirak.Rows[i].DefaultCellStyle = CellColor;

                    }
                }
                else
                {
                    // Teslim edildiyse yeşil
                    CellColor.BackColor = Color.Green;
                    CellColor.ForeColor = Color.White;
                    dataGridView_kitapBirak.Rows[i].DefaultCellStyle = CellColor;
                }
            }
            dataGridView_kitapBirak.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button_EmanetTCKontrol_Click(object sender, EventArgs e)
        {
            if (Txt_TCNO.Text != "") //TC alanı boş değilse
            {
                baglantim.Open();
                //Sorguda ikitablodanda veriler çekiliyor.
                string Sorgu = "select E.adsoyad,E.tcno,E.kitapadi,E.durum,E.bitistarihi,E.kitapid,O.ceza from emanet E,okuyucu O where O.tcno=E.tcno and E.tcno like '" + Txt_TCNO.Text + "%' and E.durum like '" + "Teslim Edilmedi" + "'";
               //Sorgu stringi
                OleDbCommand Komut = new OleDbCommand(Sorgu, baglantim);//Bağlantı ile sorgunun ilişkilendirilip komut oluşturulması
                OleDbDataAdapter Adapter = new OleDbDataAdapter(Komut);//Bağlantı için adapter oluşumu
                DataTable Table = new DataTable(); 
                Adapter.Fill(Table);
                OleDbDataReader Oku = Komut.ExecuteReader();
                //Data Grid View alanları isimlendiriliyor
                dataGridView_kitapBirak.DataSource = Table;
                dataGridView_kitapBirak.Columns[0].HeaderText = "Ad Soyad";
                dataGridView_kitapBirak.Columns[1].HeaderText = "Tc Kimlik No";
                dataGridView_kitapBirak.Columns[2].HeaderText = "Kitap Adı";
                dataGridView_kitapBirak.Columns[3].HeaderText = "Emanet Durumu";
                dataGridView_kitapBirak.Columns[4].HeaderText = "Bitiş Tarihi";
                dataGridView_kitapBirak.Columns[5].HeaderText = "Barkod No";
                dataGridView_kitapBirak.Columns[6].HeaderText = "Ceza";

                //ALanların boyutları belirleniyor
                dataGridView_kitapBirak.Columns[0].Width = 115;
                dataGridView_kitapBirak.Columns[1].Width = 100;
                dataGridView_kitapBirak.Columns[2].Width = 100;
                dataGridView_kitapBirak.Columns[3].Width = 100;
                dataGridView_kitapBirak.Columns[4].Width = 140;
                dataGridView_kitapBirak.Columns[5].Width = 70;
                dataGridView_kitapBirak.Columns[6].Width = 70;



                for (int i = 0; i < dataGridView_kitapBirak.Rows.Count - 1; i++)
                {
                    DataGridViewCellStyle CellColor = new DataGridViewCellStyle();


                    DateTime Tarih;
                    Tarih = Convert.ToDateTime(dataGridView_kitapBirak.Rows[i].Cells[4].Value);

                    DateTime Suan = Convert.ToDateTime(DateTime.Now.ToLongDateString());


                    TimeSpan GunFarki = Suan.Subtract(Tarih);
                    int Fark = int.Parse(GunFarki.Days.ToString());
                    //DataGriddeki emanetdurumuna göre ifler devreye girecek.
                    if ((dataGridView_kitapBirak.Rows[i].Cells[3].Value.ToString() == "Teslim Edilmedi"))
                    {
                        if (Fark < -2)
                        { //Günü daha varsa yeşil
                            CellColor.BackColor = Color.Green;
                            CellColor.ForeColor = Color.White;
                            dataGridView_kitapBirak.Rows[i].DefaultCellStyle = CellColor;
                        }
                        else if (Fark <= 2)
                        { // İki gün kalmışsa sarı
                            CellColor.BackColor = Color.Yellow;
                            CellColor.ForeColor = Color.White;
                            dataGridView_kitapBirak.Rows[i].DefaultCellStyle = CellColor;
                        }
                        if (Fark > 0)
                        {

                            // Günü geçmişse kırmızı
                            CellColor.BackColor = Color.Red;
                            CellColor.ForeColor = Color.White;
                            dataGridView_kitapBirak.Rows[i].DefaultCellStyle = CellColor;
                        }
                    }
                    else
                    {
                        // Eğer Teslim edildi ise direk yeşil renk yapımı sağlanıyor.
                        CellColor.BackColor = Color.Green;
                        CellColor.ForeColor = Color.White;
                        dataGridView_kitapBirak.Rows[i].DefaultCellStyle = CellColor;
                    }
                }
                dataGridView_kitapBirak.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // DataGrid Tüm satırı seçme işlemi



                baglantim.Close();

            }
            else
            {
                MessageBox.Show("Lütfen TcKimlik Numarası Giriniz", "TC NO Eksik");
            }
        
    }

        private void dataGridView_kitapBirak_Click(object sender, EventArgs e)
        {
            try
            {   //Data gride tıklandığında bilgiler textboxa aktarılıyor.
                textBox_Kitap.Text = dataGridView_kitapBirak.SelectedRows[0].Cells[5].Value.ToString();
                textBox_Kitap.Visible = true;
                label_Emanet.Visible = true;

           }
            catch (Exception)
            {

                MessageBox.Show("Hata Lütfen Tekrar Deneyiniz", "Hata");
            }
        }

        private void button_TeslimOnay_Click(object sender, EventArgs e)
        {
            if (textBox_Kitap.Text != "")
            {
                baglantim.Open();
                // Sorgu ile teslimtarhi ve emanet durumu güncelleniyor
                string TeslimTarihiYaz = "update emanet set teslimtarihi=@teslimtarihi where kitapid like '" + textBox_Kitap.Text + "%' and durum like '" + "Teslim Edilmedi" + "%'";
                OleDbCommand KomutTeslimTarihi = new OleDbCommand(TeslimTarihiYaz, baglantim);
                KomutTeslimTarihi.Parameters.AddWithValue("@teslimtarihi", dateTimePicker_teslimTarihi.Text);
                KomutTeslimTarihi.ExecuteNonQuery();


                string Sorgu = "update kitap set kitapdurumu=@kitapdurumu where kitapid like '" + textBox_Kitap.Text + "%'";
                OleDbCommand Komut = new OleDbCommand(Sorgu, baglantim);
                Komut.Parameters.AddWithValue("@kitapdurumu", 1);
                Komut.ExecuteNonQuery();

                //ps:Durum=@EmanetDurumu
                string SorguOkuyucu = "update emanet set durum=@durum where kitapid like '" + textBox_Kitap.Text + "%'";
                OleDbCommand KomutOkuyucu = new OleDbCommand(SorguOkuyucu, baglantim);
                KomutOkuyucu.Parameters.AddWithValue("@durum", "Teslim Edildi");
                KomutOkuyucu.ExecuteNonQuery();


                // Sorgu ile öğrencinin emanetsayisi alınıyor.
                string EmanetCek = "select emanetkitapsayisi from okuyucu where tcno like '" + Txt_TCNO.Text + "%'";
                OleDbCommand KomutEmanetCek = new OleDbCommand(EmanetCek, baglantim);
                OleDbDataReader OkuyucuEmanetSayisi = KomutEmanetCek.ExecuteReader();
                while (OkuyucuEmanetSayisi.Read())
                {

                    int EmanetSayisi = Convert.ToInt32(OkuyucuEmanetSayisi[0].ToString());
                    EmanetSayisi = EmanetSayisi - 1;
                    // EKitap tslim edildiğinde güncelleme yapılıyor
                    string SorguEmanet = "update okuyucu set emanetkitapsayisi=@emanetsayisi Where TCNO Like '" + Txt_TCNO.Text + "%'";

                    OleDbCommand KomutEmanet = new OleDbCommand(SorguEmanet, baglantim);
                    KomutEmanet.Parameters.AddWithValue("@emanetsayisi", EmanetSayisi);
                    KomutEmanet.ExecuteNonQuery();
                }


                DateTime Tarih;
                Tarih = Convert.ToDateTime(dataGridView_kitapBirak.SelectedRows[0].Cells[4].Value.ToString());
                DateTime Suan = Convert.ToDateTime(DateTime.Now.ToLongDateString());


                TimeSpan GunFarki = Suan.Subtract(Tarih);
                int Fark = int.Parse(GunFarki.Days.ToString());

                //Sorgu ile Tc'ye göre cezayı alıyoruz.
                string CezaGetir = "select ceza from okuyucu where tcno like '" + Txt_TCNO.Text + "%'";
                OleDbCommand KomutCezaGetir = new OleDbCommand(CezaGetir, baglantim);
                OleDbDataReader CezaOku = KomutCezaGetir.ExecuteReader();
                if (CezaOku.Read()) // Ceza okunuyor
                {

                    if (Fark > 0) // Fark değeri ne göre
                    {
                        int CezaDegeri = Convert.ToInt32(CezaOku["ceza"]);
                        int CezaPuanı = 0;
                        // Ceza ve fark değerlerine göre arttırılıyor.
                        CezaPuanı = (Fark + CezaDegeri);
                        //ceza durumu güncelleniyor.
                        string SorguCeza = "update okuyucu set ceza=@ceza where tcno like '" + Txt_TCNO.Text + "%'";
                        OleDbCommand KomutCeza = new OleDbCommand(SorguCeza, baglantim);
                        KomutCeza.Parameters.AddWithValue("@ceza", CezaPuanı);
                        KomutCeza.ExecuteNonQuery();
                        MessageBox.Show("Okuyucunun Para Cezası" + CezaPuanı.ToString() + " TL'Dir");
                    }
                }


                Goster();//OKuyucu ve emanet tablolarından verileri çekip ekrana yazan metot
                baglantim.Close();

                textBox_Kitap.Text = "";
                textBox_Kitap.Visible = false;
                label_Emanet.Visible = false;

            }
            else
            {
                MessageBox.Show("Lütfen Kitap Seçimini Yapınız");
            }
        }
    }
}
