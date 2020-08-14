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
    public partial class UyeKaydı : Form
    {
        string connString;
        NpgsqlConnection con;
        public UyeKaydı()
        {
            InitializeComponent();
            string connString =
               String.Format(
                   "Server=localhost;User Id=postgres;Database=yemegimigetir;Port=5432;Password=benbuyum123;SSLMode=Prefer");
            con = new NpgsqlConnection(connString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            using (var command2 = new NpgsqlCommand("INSERT INTO kullanici(kullanici_kadi,kullanici_adi,kullanici_soyadi,kullanici_sifre,kullanici_dTarihi,kullanici_tip)VALUES(@kid,@isim,@soyisim,@sifre,@date,@tip); ", con))
            {
                command2.Parameters.AddWithValue("kid", textBox_kID.Text.TrimEnd());
                command2.Parameters.AddWithValue("isim", textBox_isim.Text.TrimEnd());
                command2.Parameters.AddWithValue("soyisim", textBox_soyisim.Text.TrimEnd());
                command2.Parameters.AddWithValue("sifre", textBox_parola.Text.TrimEnd());
                command2.Parameters.AddWithValue("date", dateTimePicker1.Value);
                command2.Parameters.AddWithValue("tip", comboBox1.Text.TrimEnd());
                command2.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("basariyla eklendi");
                this.Close();
            }
        }
    }
}
