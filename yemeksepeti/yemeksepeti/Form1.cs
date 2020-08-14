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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            hata.Hide();
        }

        
        
        private static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=benbuyum123;Database=yemegimigetir;");
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string connString =
                String.Format(
                    "Server=localhost;User Id=postgres;Database=yemegimigetir;Port=5432;Password=benbuyum123;SSLMode=Prefer");

            using (var conn = new NpgsqlConnection(connString))
            {

                Console.Out.WriteLine("Opening connection");
                conn.Open();

                using (var command = new NpgsqlCommand("SELECT kullanici_id,kullanici_tip From kullanici WHERE kullanici_kadi=@ad and kullanici_sifre=@sifre", conn))
                {
                    command.Parameters.AddWithValue("ad", textBox_kID.Text.TrimEnd());
                    command.Parameters.AddWithValue("sifre", textBox_parola.Text.TrimEnd());

                    NpgsqlDataReader dr = command.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr["kullanici_tip"].ToString() == "musteri")
                        {
                            this.Hide();
                            anasayfa tm = new anasayfa((int)dr["kullanici_id"]);
                            tm.Show();
                        }
                        if (dr["kullanici_tip"].ToString() == "admin")
                        {
                            this.Hide();
                            Form3 tm = new Form3();
                            tm.Show();
                        }
                    }
                    conn.Close();

                    if (dr == null)
                    {
                        hata.Show();
                    }
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            UyeKaydı uk = new UyeKaydı();
            uk.Show();
        }
    }
}
