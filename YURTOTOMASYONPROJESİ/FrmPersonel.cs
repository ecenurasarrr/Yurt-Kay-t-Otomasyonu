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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl=new SqlBaglantim();
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'yurtotomasyonuDataSet12.Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.personelTableAdapter.Fill(this.yurtotomasyonuDataSet12.Personel);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Personel(PersonelAdSoyad,PersonelDepartman) values (@p1,@p2)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.Parameters.AddWithValue("@p2", textBox3.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("kayıt eklendi.");
            this.personelTableAdapter.Fill(this.yurtotomasyonuDataSet12.Personel);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from Personel where Personelid=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",textBox1.Text); 
            komut.ExecuteNonQuery (); 
            bgl.baglanti().Close();
            MessageBox.Show("kayıt silindi.");
            this.personelTableAdapter.Fill(this.yurtotomasyonuDataSet12.Personel);


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            string ad,gorev,id;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            gorev = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

            textBox2.Text = ad;
            textBox3.Text = gorev;
            textBox1.Text = id;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komutgun = new SqlCommand("update Personel set PersonelAdSoyad=@p1,PersonelDepartman=@p2 where Personelid=@p3", bgl.baglanti());
            komutgun.Parameters.AddWithValue("@p1",textBox2.Text);
            komutgun.Parameters.AddWithValue("@p2",textBox3.Text);
            komutgun.Parameters.AddWithValue("@p3",textBox1.Text);
            komutgun.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("kayıt güncellendi");
            this.personelTableAdapter.Fill(this.yurtotomasyonuDataSet12.Personel);

        }
    }
}
