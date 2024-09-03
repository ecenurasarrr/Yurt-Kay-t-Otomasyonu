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
    public partial class FrmAdminGiriş : Form
    {
        public FrmAdminGiriş()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl=new SqlBaglantim();

        private void button1_Click(object sender, EventArgs e)
        {
          SqlCommand komut=new SqlCommand("select*from Admin1 where YoneticiAd=@p1 and YoneticiSifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            SqlDataReader oku=komut.ExecuteReader();
            if (oku.Read())
            {
                FrmAnaForm fr=new FrmAnaForm();
                fr.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre!");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
         
            }
            bgl.baglanti().Close();
        }
    }
}
