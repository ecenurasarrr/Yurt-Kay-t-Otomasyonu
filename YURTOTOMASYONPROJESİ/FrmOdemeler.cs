
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
    public partial class FrmOdemeler : Form
    {
        public FrmOdemeler()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();


        private void FrmOdemeler_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'yurtotomasyonuDataSet8.Borclar1' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.borclar1TableAdapter1.Fill(this.yurtotomasyonuDataSet8.Borclar1);
            // TODO: Bu kod satırı 'yurtotomasyonuDataSet7.Borclar1' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.borclar1TableAdapter.Fill(this.yurtotomasyonuDataSet7.Borclar1);
            

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the student ID from textBox6
            string OgrId = textBox6.Text;

            // Get the payment and remaining debt values
            int odenen = Convert.ToInt32(textBox4.Text);
            int kalan = Convert.ToInt32(textBox3.Text);

            // Calculate the new remaining debt
            int yeniborc = kalan - odenen;

            // Update the textBox3 with the new remaining debt
            textBox3.Text = yeniborc.ToString();

            // Update the database with the new remaining debt
            SqlCommand komut = new SqlCommand("UPDATE Borclar1 SET OgrKalanBorc = @p1 WHERE Ogrid = @p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", yeniborc);
            komut.Parameters.AddWithValue("@p2", OgrId);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Borç ödendi");
            
            //Anında Güncelleme givens
            DataTable dta = new DataTable();
            SqlDataAdapter dab = new SqlDataAdapter("SELECT * FROM Borclar1", bgl.baglanti());
            dab.Fill(dta);
            dataGridView1.DataSource = dta;
            //kasa tablosuna ekleme yapma
            try
            {
                
                SqlBaglantim bgl = new SqlBaglantim();
                SqlCommand komut2 = new SqlCommand("insert into Kasa(OdemeAy,OdemeMiktar) Values (@k1,@k4)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@k1", textBox1.Text);
                komut2.Parameters.AddWithValue("@k4", textBox4.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
               

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
            textBox6.Clear();
            textBox2.Clear();
            textBox5.Clear();
            textBox4.Clear();
            textBox3.Clear();
            textBox1.Clear();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked
            {
                int selectedRowIndex = e.RowIndex;

                // Assuming the order of columns in the DataGridView is: OgrId, OgrAd, OgrSoyad, OgrKalanBorc
                string id = dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString();
                string ad = dataGridView1.Rows[selectedRowIndex].Cells[1].Value.ToString();
                string soyad = dataGridView1.Rows[selectedRowIndex].Cells[2].Value.ToString();
                string kalan = dataGridView1.Rows[selectedRowIndex].Cells[3].Value.ToString();

                textBox6.Text = id;
                textBox2.Text = ad;
                textBox5.Text = soyad;
                textBox3.Text = kalan;
            }
        }
    }
}