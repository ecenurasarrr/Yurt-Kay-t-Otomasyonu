using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace YURTOTOMASYONPROJESİ
{
    public class SqlBaglantim
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-BG8JPCA\\SQLEXPRESS04;Initial Catalog=yurtotomasyonu;Integrated Security=True");
            baglan.Open();
            return baglan;
    }
    }
}
