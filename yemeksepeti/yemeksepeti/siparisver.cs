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
    public partial class siparisver : Form
    {
        
        NpgsqlConnection con;
        int kID;
        anasayfa an;
        int mid;
        public siparisver(anasayfa a,int magazaID)
        {
            InitializeComponent();
            an = a;
            mid = magazaID;            InitializeComponent();
            ekle();
            label2.Text = "asdasq";
        }
        public siparisver()
        {
            InitializeComponent();
            label2.Text = "asdasq";
        }
        private void ekle()
        {
            string connString =
               String.Format(
                   "Server=localhost;User Id=postgres;Database=yemegimigetir;Port=5432;Password=benbuyum123;SSLMode=Prefer");
            con = new NpgsqlConnection(connString);

            con.Open();
            using (var command = new NpgsqlCommand("SELECT kurye_adi,kurye_soyadi From kurye where kurye_magazaid=@id", con))
            {
                command.Parameters.AddWithValue("id", mid);
                NpgsqlDataReader dr = command.ExecuteReader();


                while (dr.Read())
                {
                    string x = dr["kurye_adi"].ToString();
                    string y = dr["kurye_soyadi"].ToString();
                    x += y;
                    cb1.Items.Add("asd");
                }
                con.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
