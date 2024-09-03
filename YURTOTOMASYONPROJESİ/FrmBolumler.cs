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
    public partial class FrmBolumler : Form
    {
        public FrmBolumler()
        {
            InitializeComponent();

        }

        SqlBaglantim bgl=new SqlBaglantim();


        private void FrmBolumler_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'yurtotomasyonuDataSet2.Bolumler1' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.bolumler1TableAdapter.Fill(this.yurtotomasyonuDataSet2.Bolumler1);


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            try
            {
               
                SqlCommand komut1 = new SqlCommand("insert into Bolumler1 (BolumAd) values (@p1)", bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1", textBox2.Text);
                komut1.ExecuteNonQuery();
                MessageBox.Show("Bölüm eklendi.");
                this.bolumler1TableAdapter.Fill(this.yurtotomasyonuDataSet2.Bolumler1);
                bgl.baglanti().Close();
                textBox2.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
               
                SqlCommand komut2 = new SqlCommand("delete from Bolumler1 where BolumAd=@p1", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", textBox2.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Silme işlemi gerçekleşti.");
                this.bolumler1TableAdapter.Fill(this.yurtotomasyonuDataSet2.Bolumler1);
            }
            catch (Exception)
            {
                MessageBox.Show("Hata!işlem gerçekleşmedi.");

            }

        }
        int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string BolumAd;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            BolumAd = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox2.Text = BolumAd;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                
                SqlCommand komut2 = new SqlCommand("update Bolumler1 set BolumAd=@p1 where BolumID=@p2", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", textBox2.Text);
                komut2.Parameters.AddWithValue("@p2", dataGridView1.Rows[secilen].Cells[0].Value); 
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Güncelleme gerçekleşti.");
                this.bolumler1TableAdapter.Fill(this.yurtotomasyonuDataSet2.Bolumler1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }


    }
}
