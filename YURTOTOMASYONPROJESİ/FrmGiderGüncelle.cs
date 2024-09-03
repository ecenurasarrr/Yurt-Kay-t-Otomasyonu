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
    public partial class FrmGiderGüncelle : Form
    {
        public FrmGiderGüncelle()
        {
            InitializeComponent();
        }
       
        public string elektrik, su, dogalgaz, gida, diger, internet, personel,id;
        SqlBaglantim bgl=new SqlBaglantim();
        private void FrmGiderGüncelle_Load(object sender, EventArgs e)
        {
            textBox8.Text = id;
            textBox1.Text = elektrik;
            textBox2.Text=su;
            textBox3.Text=dogalgaz;
            textBox4.Text=internet;
            textBox5.Text=gida;
            textBox6.Text=personel;
            textBox7.Text=diger;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("update Giderler set Elektrik=@p1,Su=@p2,Dogalgaz=@p3,İnternet=@p4,Gıda=@p5,Personel=@p6,Diger=@p7 where Odemeid=@p8", bgl.baglanti());
                komut.Parameters.AddWithValue("@p8", textBox8.Text);
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.Parameters.AddWithValue("@p2", textBox2.Text);
                komut.Parameters.AddWithValue("@p3", textBox3.Text);
                komut.Parameters.AddWithValue("@p4", textBox4.Text);
                komut.Parameters.AddWithValue("@p5", textBox5.Text);
                komut.Parameters.AddWithValue("@p6", textBox6.Text);
                komut.Parameters.AddWithValue("@p7", textBox7.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Güncelleme yapıldı.");


            }
            catch (Exception)
            {

                MessageBox.Show("Hata,Yeniden Deneyiniz");
            }

        }
    }
}
