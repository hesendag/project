using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace yemeksepeti
{
    public partial class adresEklecs : Form
    {
        string connString;
        NpgsqlConnection con;
        int kID;
        anasayfa an;
        public adresEklecs(int k,anasayfa a)
        {
            an = a;
            kID = k;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString =
                String.Format(
                    "Server=localhost;User Id=postgres;Database=yemegimigetir;Port=5432;Password=benbuyum123;SSLMode=Prefer");
            con = new NpgsqlConnection(connString);


            con.Open();

            using (var command = new NpgsqlCommand("INSERT INTO adres(adres_baslik,adres_adres,adres_kid)VALUES(@baslik,@adres,@kid); ", con))
            {
                command.Parameters.AddWithValue("kid", kID);
                command.Parameters.AddWithValue("baslik", textBox_baslik.Text.TrimEnd());
                command.Parameters.AddWithValue("adres", richTextBox1.Text.TrimEnd());
                command.ExecuteNonQuery();
                con.Close();
            }
            an.adresGuncelle();
            this.Close();
        }
    }
}
