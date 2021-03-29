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
    public partial class OgrenciListele : Form
    {
        public OgrenciListele()
        {
            InitializeComponent();
        }

        public OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +
             Application.StartupPath + "\\kutuphane.mdb");

        public void kayital()
        {
            try
            {   
                baglantim.Open();    //Veri tabanı bağlantısı açılıyor
                string sorgu = "select * from okuyucu"; //Veri tabanı için sorgu yazılıyor
                OleDbCommand komut = new OleDbCommand(sorgu, baglantim);  
                //sorgu açılan bağlantıyla ilişkilendirilip komut oluşturuluyor
                OleDbDataAdapter adapter = new OleDbDataAdapter(komut);
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                //DataTable tipinde üretilen nesne veri tabanı değerleri ile dolduruluyor
                dataGridView_ogrListele.DataSource = Table;
                //Datagridview'e veritabaından veriler çekiliyor
                dataGridView_ogrListele.Columns[0].HeaderText = "Tc Kimlik No";
                dataGridView_ogrListele.Columns[1].HeaderText = "Adı Soyadı";
                dataGridView_ogrListele.Columns[2].HeaderText = "Telefon";
                dataGridView_ogrListele.Columns[3].HeaderText = "Mail Adresi";
                dataGridView_ogrListele.Columns[4].HeaderText = "Üyelik Olduğu Tarih";
                dataGridView_ogrListele.Columns[5].HeaderText = "Cinsiyet";
                dataGridView_ogrListele.Columns[6].HeaderText = "Aldığı kitap sayısı";
                dataGridView_ogrListele.Columns[7].HeaderText = "Emanet Kitap sayısı";
                dataGridView_ogrListele.Columns[8].HeaderText = "Ceza";
                //DataGridView'in boyutları belirleniyor.

                dataGridView_ogrListele.Columns[0].Width = 100;
                dataGridView_ogrListele.Columns[1].Width = 100;
                dataGridView_ogrListele.Columns[2].Width = 100;
                dataGridView_ogrListele.Columns[3].Width = 100;
                dataGridView_ogrListele.Columns[4].Width = 100;
                dataGridView_ogrListele.Columns[5].Width = 55;
                dataGridView_ogrListele.Columns[6].Width = 55;
                dataGridView_ogrListele.Columns[7].Width = 55;
                dataGridView_ogrListele.Columns[8].Width = 55;
                //Datagridview deki tümsatırları seçiyor
                dataGridView_ogrListele.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                baglantim.Close();
            }
            catch (Exception hata)
            {   //Hata meydana gelirse kullanıcıya bildiriliyor
                MessageBox.Show(hata.Message, "Hata Tespit Edildi");
                baglantim.Close();//Her ihtimale karşı veri tabanı bağlantısı kapatılıyor
            }
        }


        private void OgrenciListele_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            kayital();//Öğrencileri yani okuyucuları ekrana yazan metot
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                baglantim.Open(); //Veri tabanı bağlantısı açılıyor
                string sorgu = "select * from okuyucu where tcno like '" + textBox1.Text + "%'";
                //veri tabanı için sorgu yazılıyor
                OleDbCommand komut = new OleDbCommand(sorgu, baglantim);
                //veri tabanı sorgumuz veri tabanı bağlantımızla ilişkilendirilip
                //veri tabanı komutumuz oluşturuluyor
                OleDbDataAdapter adapter = new OleDbDataAdapter(komut);
                //Veri alışverişi için adapter nesnesi oluşturuluyor
                DataTable table = new DataTable();
                //Veri tablosu oluşturulup adapterin Fill metoduyla
                //veri tabanından gelen veriler tabloya ekleniyor
                adapter.Fill(table);
                dataGridView_ogrListele.DataSource = table;
                //DataTable tipindeki tablomuzdan data gridview
                //Nesnemize veriler aktarılıyor
                baglantim.Close();  // Veri tabanı Bağlantısı Kapatılıyor
            }
            catch (Exception hata)//hata yakalama
            {
                MessageBox.Show(hata.Message, "Hata");
                baglantim.Close();
                //Hata meydana gelirse kullanıcı bilgilendirilip 
                //her ihtimale karşı veri tabanı bağlantısı kapatılıyor
            }

        }
    }
}
