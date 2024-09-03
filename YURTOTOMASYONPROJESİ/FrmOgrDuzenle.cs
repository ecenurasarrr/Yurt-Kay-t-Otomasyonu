using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace YURTOTOMASYONPROJESİ
{
    public partial class FrmOgrDuzenle : Form
    {
        public FrmOgrDuzenle()
        {
            InitializeComponent();
        }
        public string id,ad,soyad,TC,telefon,dogum,bolum,maıl;

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("delete from Ogrenci1 where Ogrid=@k1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@k1", textBox5.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("kayıt silindi");

            //oda kontenjanı arttırma
            SqlCommand komutoda = new SqlCommand("update Odalar set OdaAktif=OdaAktif-1 where OdaNo=@oda", bgl.baglanti());
            komutoda.Parameters.AddWithValue("@oda", cmbOdaNo.Text);
            komutoda.ExecuteNonQuery(); 
            bgl.baglanti() .Close();
        }

        SqlBaglantim bgl =new SqlBaglantim();    

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut= new SqlCommand("update Ogrenci1 set OgrAd=@p2,OgrSoyad=@p3,OgrTC=@p4,OgrTelefon=@p5,OgrDogum=@p6,OgrBolum=@p7,OgrMail=@p8,OgrOdaNo=@p9,OgrVeliAdSoyad=@p10,OgrVeliTelefon=@p11,OgrVeliAdres=@p12 where Ogrid=@p1 ",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox5.Text);
            komut.Parameters.AddWithValue("@p2", textBox1.Text);
            komut.Parameters.AddWithValue("@p3", textBox2.Text);
            komut.Parameters.AddWithValue("@p4", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p5", maskedTextBox2.Text);
            komut.Parameters.AddWithValue("@p6", maskedTextBox3.Text);
            komut.Parameters.AddWithValue("@p7", CmbBolum.Text);
            komut.Parameters.AddWithValue("@p8", textBox3.Text);
            komut.Parameters.AddWithValue("@p9", cmbOdaNo.Text);
            komut.Parameters.AddWithValue("@p10", textBox4.Text);
            komut.Parameters.AddWithValue("@p11", maskedTextBox4.Text);
            komut.Parameters.AddWithValue("@p12", richTextBox1.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        public string mail, odano, veliad, velitel, adres;
        private void FrmOgrDuzenle_Load(object sender, EventArgs e)
        {
            textBox5.Text = id;
            textBox1.Text = ad;
            textBox2.Text=soyad;    
            maskedTextBox1.Text=TC;
            maskedTextBox2.Text=telefon;
            maskedTextBox3.Text=dogum;
            CmbBolum.Text=bolum;
            textBox3.Text = mail;
            cmbOdaNo.Text= odano;
            textBox4.Text = veliad;
            maskedTextBox4.Text = velitel;
            richTextBox1.Text=adres;



            
        }
    }
}
