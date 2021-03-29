using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;//Zedgraph için ekleniyor
using System.Data.OleDb;// veri tabanı için ekleniyor

namespace KutuphaneOtomasyon0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Veritabanı bağlantısı oluşturluyor.
        public OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +
             Application.StartupPath + "\\kutuphane.mdb");
   



        private void Btn_ogrenciEkle_Click(object sender, EventArgs e)
        {
            OgrenciIslem ogrislem = new OgrenciIslem();
            ogrislem.Show();
            
        }

        private void Btn_ogrenciListele_Click(object sender, EventArgs e)
        {
            OgrenciListele OgrenciListele = new OgrenciListele();
            OgrenciListele.Show();
        }

        private void Btn_kitapEkle_Click(object sender, EventArgs e)
        {
            KitapEkle Kitapekle = new KitapEkle();
            Kitapekle.Show();
        }

        private void Btn_kitapListesi_Click(object sender, EventArgs e)
        {
            KitapListele kitaplistele = new KitapListele();
            kitaplistele.Show();
        }

        private void Btn_emanetKitaplar_Click(object sender, EventArgs e)
        {
            EmanetKitaplar EmanetKitaplar = new EmanetKitaplar();
            EmanetKitaplar.Show();
        }

        private void Btn_kitapAl_Click(object sender, EventArgs e)
        {
            EmanetAl emanetal = new EmanetAl();
            emanetal.Show();
        }

        public void ZedGraph_Olustur(ZedGraphControl zg)
        {
            baglantim.Open();
            //Sorgu ile kitap sayısını veritabanından çekiliyor.

            string GrafikSorgu = "Select count(*) From kitap";
            OleDbCommand KomutGrafik = new OleDbCommand(GrafikSorgu, baglantim);
            double KitapSayisi = Convert.ToDouble(KomutGrafik.ExecuteScalar());
            //Tesil edilmeyen kitap sayısını çekiyoruz.
            string SorguTeslimEdilmeyen = "Select count(*) From emanet where durum Like '" + "Teslim Edilmedi" + "'";
            OleDbCommand KomutTeslimEdilmeyen = new OleDbCommand(SorguTeslimEdilmeyen, baglantim);

            double TeslimEdilmeyenSayisi = Convert.ToDouble(KomutTeslimEdilmeyen.ExecuteScalar());
            //Bu sorgu ile de teslim edilenlerin sayısını çekiliyor
            string SorguTeslimedilen = "Select count(*) from emanet where durum like'" + "Teslim Edildi" + "'";
            OleDbCommand KomutTeslimEdildi = new OleDbCommand(SorguTeslimedilen, baglantim);

            double TeslimEdilenSayisi = Convert.ToDouble(KomutTeslimEdildi.ExecuteScalar());

            GraphPane pane = zg.GraphPane;
            pane.Title = "Kütüphanede ki Kitap Sayisi";
            pane.XAxis.Title = "Kitaplar";
            pane.YAxis.Title = "Kitap Sayisi";
            string[] YIsimler = { "Tüm Kitaplar", "Teslim Edilmeyenler", "Teslim Edilenler" };

            double[] Ciz = { KitapSayisi, 0, 0 };//Zedgraph degeri cekiliyor
            double[] Teslimedilmeyen = { 0, TeslimEdilmeyenSayisi, 0 };
            double[] TeslimEdilen = { 0, 0, TeslimEdilenSayisi };

            BarItem bar = pane.AddBar("Tüm Kitaplar", null, Ciz, Color.Aqua);
            bar = pane.AddBar("Teslim Edilmeyen", null, Teslimedilmeyen, Color.Yellow);
            bar = pane.AddBar("Teslim Edilen", null, TeslimEdilen, Color.DarkBlue);

            pane.Legend.FontSpec.Size = 18;//Grafikteki yazı boyutu ayarlanıyor

            pane.XAxis.IsTicsBetweenLabels = true;//Araya ayraç koyma komutu

            pane.XAxis.TextLabels = YIsimler;//Eksenlerin değişken tiplerini tanımlanan değişkenle bağdaşlaştırılıyor
            pane.XAxis.Type = AxisType.Text;// Eksen değerlerinin yazı tipinde olmasını sağlama

            baglantim.Close();
            zg.AxisChange();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Formun açılmasıyla birlikte Zedgraph oluşuyor
            this.ZedGraph_Olustur(zedGraphControl1);
        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
