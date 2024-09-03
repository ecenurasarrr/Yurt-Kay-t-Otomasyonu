using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YurtKayıtSistemi;

namespace YURTOTOMASYONPROJESİ
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        private void FrmAnaForm_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'yurtotomasyonuDataSet3.Ogrenci1' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.ogrenci1TableAdapter.Fill(this.yurtotomasyonuDataSet3.Ogrenci1);
            timer1.Start();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString();
            label2.Text = DateTime.Now.ToLongTimeString();


        }

        
        private void hesapMakinesiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");

        }

        private void paintToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("MSPaint.Exe");

        }

        private void radyo1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "http://37.247.98.8/stream/166/";
        }

        private void radyo2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "http://37.1.145.21:9001/stream.mp3";
        }

        private void radyo3ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "http://46.20.3.204:80/";
        }

        private void öğrenciEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOgrKayıtSistemi fr = new FrmOgrKayıtSistemi();
            fr.Show();
        }

        private void öğrenciListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOgrListe fr= new FrmOgrListe();
            fr.Show();
        }

        private void öğrenciDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOgrListe fr=new FrmOgrListe();
            fr.Show();
        }

        private void bölümEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBolumler frm = new FrmBolumler();
            frm.Show();
        }

        private void bölümDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBolumler frm= new FrmBolumler();
            frm.Show();
        }

        private void ödemeAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOdemeler frm= new FrmOdemeler();
            frm.Show();
        }

        private void giderListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGiderGüncelle frm =new FrmGiderGüncelle();
            frm.Show();
        }

        private void giderListesiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmGiderListesi frm= new FrmGiderListesi(); 
            frm.Show();
        }

        private void gelirİstatistikleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGelirİstatistik frm=new FrmGelirİstatistik();
            frm.Show();
        }

        private void şifreİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            FrmYonetici frm= new FrmYonetici();
            frm.Show();
        }

        private void personelDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPersonel frm= new FrmPersonel();
            frm.Show();
        }

        private void yöneticiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void notEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNotEkle frm= new FrmNotEkle();
            frm.Show();
        }

        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Bu program bir yurdun kayıt sistemidir.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
