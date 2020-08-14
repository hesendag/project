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
    public partial class Form3 : Form
    {
        string connString;
        NpgsqlConnection con;
        int kID;
        public Form3()
        {
            InitializeComponent();
            string connString =
               String.Format(
                   "Server=localhost;User Id=postgres;Database=yemegimigetir;Port=5432;Password=benbuyum123;SSLMode=Prefer");
            con = new NpgsqlConnection(connString);

            con.Open();
            using (var command = new NpgsqlCommand("SELECT magaza_isim From magaza", con))
            {
                NpgsqlDataReader dr = command.ExecuteReader();


                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["magaza_isim"].ToString());
                    comboBox2.Items.Add(dr["magaza_isim"].ToString());
                    comboBox3.Items.Add(dr["magaza_isim"].ToString());
                    comboBox4.Items.Add(dr["magaza_isim"].ToString());
                    comboBox5.Items.Add(dr["magaza_isim"].ToString());
                    comboBox6.Items.Add(dr["magaza_isim"].ToString());
                }
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = @"select * from magaza_insert(@isim,@adres)";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("isim", textBox_yyisim.Text.TrimEnd());
            cmd.Parameters.AddWithValue("adres", richTextBox_yyAdres.Text.TrimEnd());
            int result = (int)cmd.ExecuteScalar();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            using (var command = new NpgsqlCommand("SELECT magaza_id From magaza WHERE magaza_isim=@isim ", con))
            {
                command.Parameters.AddWithValue("isim", comboBox1.Text);
                int magazaid = (int)command.ExecuteScalar();
                con.Close();


                con.Open();
                string sql = @"select * from menu_insert(@isim,@fiyat,@icerik,@magazaid)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("isim", textBox_menuAdi.Text.TrimEnd());
                cmd.Parameters.AddWithValue("icerik", richTextBox_menuicerik.Text.TrimEnd());
                cmd.Parameters.AddWithValue("fiyat", int.Parse(textBox_menufiyat.Text.TrimEnd()));
                cmd.Parameters.AddWithValue("magazaid", magazaid);
                int result = (int)cmd.ExecuteScalar();
                con.Close();
                MessageBox.Show("Menu basariyla eklendi");
            }

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            using (var command = new NpgsqlCommand("SELECT magaza_id From magaza WHERE magaza_isim=@isim ", con))
            {
                command.Parameters.AddWithValue("isim", comboBox2.Text);
                int magazaid = (int)command.ExecuteScalar();
                con.Close();


                con.Open();
                string sql = @"select * from yemek_insert(@isim,@fiyat,@magazaid)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("isim", textBox_yiyecekAdi.Text.TrimEnd());
                cmd.Parameters.AddWithValue("fiyat", int.Parse(textBox_yiyecekFiyat.Text.TrimEnd()));
                cmd.Parameters.AddWithValue("magazaid", magazaid);
                int result = (int)cmd.ExecuteScalar();
                con.Close();
                MessageBox.Show("yiyecek basariyla eklendi");


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            using (var command = new NpgsqlCommand("SELECT magaza_id From magaza WHERE magaza_isim=@isim ", con))
            {
                command.Parameters.AddWithValue("isim", comboBox3.Text);
                int magazaid = (int)command.ExecuteScalar();
                con.Close();

                con.Open();
                string sql = @"select * from icecek_insert(@isim,@fiyat,@magazaid)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("isim", textBox_icecekAdi.Text.TrimEnd());
                cmd.Parameters.AddWithValue("fiyat", int.Parse(textBox_icecekFiyat.Text.TrimEnd()));
                cmd.Parameters.AddWithValue("magazaid", magazaid);
                int result = (int)cmd.ExecuteScalar();
                con.Close();
                MessageBox.Show("icecek basariyla eklendi");

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            using (var command = new NpgsqlCommand("SELECT magaza_id From magaza WHERE magaza_isim=@isim ", con))
            {
                command.Parameters.AddWithValue("isim", comboBox4.Text);
                int magazaid = (int)command.ExecuteScalar();
                con.Close();
                con.Open();
                using (var command2 = new NpgsqlCommand("INSERT INTO kurye(kurye_adi,kurye_soyadi,kurye_magazaid)VALUES(@isim,@soyisim,@id); ", con))
                {
                    command2.Parameters.AddWithValue("isim", textBox2.Text.TrimEnd());
                    command2.Parameters.AddWithValue("soyisim", textBox1.Text.TrimEnd());
                    command2.Parameters.AddWithValue("id", magazaid);
                    command2.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("basariyla eklendi");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            using (var command = new NpgsqlCommand("SELECT magaza_id From magaza WHERE magaza_isim=@isim ", con))
            {
                command.Parameters.AddWithValue("isim", comboBox5.Text);
                int magazaid = (int)command.ExecuteScalar();
                con.Close();

                con.Open();
                var cmd = new NpgsqlCommand("DELETE FROM menu WHERE menu_magazaid = @id; ", con);
                cmd.Parameters.AddWithValue("id", magazaid);
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                cmd = new NpgsqlCommand("DELETE FROM yemek WHERE yemek_magazaid = @id; ", con);
                cmd.Parameters.AddWithValue("id", magazaid);
                cmd.ExecuteNonQuery();
                con.Close();


                con.Open();
                cmd = new NpgsqlCommand("DELETE FROM icecek WHERE icecek_magazaid = @id; ", con);
                cmd.Parameters.AddWithValue("id", magazaid);
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                cmd = new NpgsqlCommand("DELETE FROM kurye WHERE kurye_magazaid = @id; ", con);
                cmd.Parameters.AddWithValue("id", magazaid);
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();

                using (var command2 = new NpgsqlCommand("DELETE FROM magaza WHERE magaza_id = @id; ", con))
                {
                    command2.Parameters.AddWithValue("id", magazaid);
                    command2.ExecuteNonQuery();
                    con.Close();

                    comboBox1.Items.Clear();
                    comboBox2.Items.Clear();
                    comboBox3.Items.Clear();
                    comboBox4.Items.Clear();
                    comboBox5.Items.Clear();
                    comboBox6.Items.Clear();

                    con.Open();
                    using (var command3 = new NpgsqlCommand("SELECT magaza_isim From magaza", con))
                    {
                        NpgsqlDataReader dr = command3.ExecuteReader();


                        while (dr.Read())
                        {
                            comboBox1.Items.Add(dr["magaza_isim"].ToString());
                            comboBox2.Items.Add(dr["magaza_isim"].ToString());
                            comboBox3.Items.Add(dr["magaza_isim"].ToString());
                            comboBox4.Items.Add(dr["magaza_isim"].ToString());
                            comboBox5.Items.Add(dr["magaza_isim"].ToString());
                            comboBox6.Items.Add(dr["magaza_isim"].ToString());
                        }
                        con.Close();
                    }
                    MessageBox.Show("basariyla silindi");
                }

            }


               
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            using (var command = new NpgsqlCommand("SELECT magaza_id From magaza WHERE magaza_isim=@isim ", con))
            {
                command.Parameters.AddWithValue("isim", comboBox6.Text);
                int magazaid = (int)command.ExecuteScalar();
                con.Close();
                con.Open();
                using (var command2 = new NpgsqlCommand("UPDATE magaza SET  magaza_isim = @isim WHERE magaza_id = @id ", con))
                {
                    command2.Parameters.AddWithValue("id", magazaid);
                    command2.Parameters.AddWithValue("isim", textBox3.Text.TrimEnd());
                    command2.ExecuteNonQuery();
                    con.Close();



                    comboBox1.Items.Clear();
                    comboBox2.Items.Clear();
                    comboBox3.Items.Clear();
                    comboBox4.Items.Clear();
                    comboBox5.Items.Clear();
                    comboBox6.Items.Clear();

                    con.Open();
                    using (var command3 = new NpgsqlCommand("SELECT magaza_isim From magaza", con))
                    {
                        NpgsqlDataReader dr = command3.ExecuteReader();


                        while (dr.Read())
                        {
                            comboBox1.Items.Add(dr["magaza_isim"].ToString());
                            comboBox2.Items.Add(dr["magaza_isim"].ToString());
                            comboBox3.Items.Add(dr["magaza_isim"].ToString());
                            comboBox4.Items.Add(dr["magaza_isim"].ToString());
                            comboBox5.Items.Add(dr["magaza_isim"].ToString());
                            comboBox6.Items.Add(dr["magaza_isim"].ToString());
                        }
                        con.Close();
                    }
                    MessageBox.Show("Güncelleme basarili");

                }

            }
        }
    }
}
