using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace yemeksepeti
{
    public partial class UserControl4 : UserControl
    {
        public string yy, p;

        string connString;
        NpgsqlConnection con;
        private void button1_Click(object sender, EventArgs e)
        {
            int k=int.Parse(p)+(int)1;
            p = "" + k;
            label2.Text = "Puan:" + p;
            string connString =
               String.Format(
                   "Server=localhost;User Id=postgres;Database=yemegimigetir;Port=5432;Password=benbuyum123;SSLMode=Prefer");
            con = new NpgsqlConnection(connString);
            con.Open();
            using (var command2 = new NpgsqlCommand("UPDATE magaza SET  magaza_puan = @puan WHERE magaza_isim = @isim ", con))
            {
                command2.Parameters.AddWithValue("isim", yy);
                command2.Parameters.AddWithValue("puan", int.Parse(p));
                command2.ExecuteNonQuery();
                con.Close();
            }
        }

        public UserControl4(string yemekyeri,string puan)
        {
            InitializeComponent();
            label1.Text = yemekyeri;
            label2.Text += puan;
            yy = yemekyeri;
            p = puan;
        }
    }
}
