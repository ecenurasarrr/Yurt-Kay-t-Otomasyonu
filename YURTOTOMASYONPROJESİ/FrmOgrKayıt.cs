using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms; 
using YurtKayıtSistemi;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using YURTOTOMASYONPROJESİ;
using System.Linq.Expressions;

namespace YurtKayıtSistemi
{
    public partial class FrmOgrKayıtSistemi : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-BG8JPCA \\SQLEXPRESS04;Initial Catalog=yurtotomasyonu;Integrated Security=True");

        public FrmOgrKayıtSistemi()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();
        private void FrmOgrKayıtSistemi_Load_1(object sender, EventArgs e)
        {
            try
            {
                //bölümleri listeleme komutu
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT BolumAd FROM Bolumler1", bgl.baglanti());
                SqlDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    CmbBolum.Items.Add(oku[0].ToString());
                }

                baglanti.Close();

                //boş odaları listeleme komutu

                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("SELECT OdaNo FROM Odalar WHERE OdaKapasite!=OdaAktif", bgl.baglanti());
                SqlDataReader oku2 = komut2.ExecuteReader();

                while (oku2.Read())
                {
                    cmbOdaNo.Items.Add(oku2[0].ToString());
                }
                baglanti.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA!!! LÜTFEN YENİDEN DENEYİNİZ" + ex.Message);
            }


        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand komutkaydet = new SqlCommand("insert into Ogrenci1 (OgrAd,OgrSoyad,OgrTC,OgrTelefon,OgrDogum,OgrBolum,OgrMail,OgrOdaNo,OgrVeliAdSoyad,OgrVeliTelefon,OgrVeliAdres ) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", baglanti);
                komutkaydet.Parameters.AddWithValue("@p1", textBox1.Text);
                komutkaydet.Parameters.AddWithValue("@p2", textBox2.Text);
                komutkaydet.Parameters.AddWithValue("@p3", maskedTextBox1.Text);
                komutkaydet.Parameters.AddWithValue("@p4", maskedTextBox2.Text);
                komutkaydet.Parameters.AddWithValue("@p5", maskedTextBox3.Text);
                komutkaydet.Parameters.AddWithValue("@p6", CmbBolum.Text);
                komutkaydet.Parameters.AddWithValue("@p7", textBox3.Text);
                komutkaydet.Parameters.AddWithValue("@p8", cmbOdaNo.Text);
                komutkaydet.Parameters.AddWithValue("@p9", textBox4.Text);
                komutkaydet.Parameters.AddWithValue("@p10", maskedTextBox4.Text);
                komutkaydet.Parameters.AddWithValue("@p11", richTextBox1.Text);
                komutkaydet.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("kayıt başarılı bir şekilde eklendi.");

                //öğrenciid yi label a çekme
                SqlCommand komut=new SqlCommand();
                SqlDataReader oku=komut.ExecuteReader();
                while (oku.Read())
                {
                    label12.Text = oku[0].ToString();
                }
                bgl.baglanti().Close();


                //öğrenci borç alanı oluşturma
                SqlCommand komutkaydet2 = new SqlCommand("insert into Borclar1 (Ogrid,OgrAd,OgrrSoyad) values (@b1,@b2,@b3)", bgl.baglanti());
                komutkaydet2.Parameters.AddWithValue("@b1", label12.Text);
                komutkaydet2.Parameters.AddWithValue("@b2", textBox1.Text);
                komutkaydet2.Parameters.AddWithValue("@b3", textBox2.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
            }
            catch (Exception)
            {

               
            }
            //öğrenci oda kontenjanını arttırma

            SqlCommand komutoda = new SqlCommand("update Odalar set OdaAktif=OdaAktif+1 Where OdaNo=@oda1", bgl.baglanti());
            komutoda.Parameters.AddWithValue("@oda1", cmbOdaNo.Text);
            komutoda .ExecuteNonQuery();
            bgl .baglanti().Close();
            

        }

       
    }
}