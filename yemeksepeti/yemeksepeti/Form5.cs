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
    public partial class Form5 : Form
    {
        anasayfa an;
        int mid,f;
        public Form5(anasayfa a,int id,int fiyat)
        {
            an = a;
            f = fiyat;
            InitializeComponent();
            string connString =
               String.Format(
                   "Server=localhost;User Id=postgres;Database=yemegimigetir;Port=5432;Password=benbuyum123;SSLMode=Prefer");
            NpgsqlConnection con = new NpgsqlConnection(connString);
            con.Open();
            using (var command = new NpgsqlCommand("SELECT kurye_adi,kurye_soyadi From kurye where kurye_magazaid=@id", con))
            {
                command.Parameters.AddWithValue("id", id);
                NpgsqlDataReader dr = command.ExecuteReader();


                while (dr.Read())
                {
                    string x = dr["kurye_adi"].ToString();
                    string y = dr["kurye_soyadi"].ToString();
                    x +=" "+ y;
                    comboBox1.Items.Add(x);
                }
                con.Close();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Siparişiniz alınmıştır");
            an.fiyatkes(f);
            this.Hide();
        }
    }
}
