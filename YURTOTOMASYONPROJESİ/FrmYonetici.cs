using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace YURTOTOMASYONPROJESİ
{
    public partial class FrmYonetici : Form
    {
        public FrmYonetici()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl=new SqlBaglantim();
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'yurtotomasyonuDataSet11.Admin1' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.admin1TableAdapter.Fill(this.yurtotomasyonuDataSet11.Admin1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("insert into Admin1 (YoneticiAd,YoneticiSifre) values (@p1,@p2)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.Parameters.AddWithValue ("@p2", textBox3.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("yönetici eklendi");
            this.admin1TableAdapter.Fill(this.yurtotomasyonuDataSet11.Admin1);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            string ad, sifre,id;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            sifre = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

            textBox2.Text = ad; 
            textBox3.Text = sifre;
            textBox1.Text = id;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut= new SqlCommand("delete from Admin1 where Yoneticiid=@p1 ",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",textBox1.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("silme işlemi gerçekleşti");
            this.admin1TableAdapter.Fill(this.yurtotomasyonuDataSet11.Admin1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Admin1 set YoneticiAd=@p1,YoneticiSifre=@p2 where Yoneticiid=@p3", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.Parameters.AddWithValue("@p2", textBox3.Text);
            komut.Parameters.AddWithValue("@p3", textBox1.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("güncelleme gerçekleşti");
            this.admin1TableAdapter.Fill(this.yurtotomasyonuDataSet11.Admin1);

        }
    }
}
