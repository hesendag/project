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
    public partial class anasayfa : Form
    {
        string connString;
        NpgsqlConnection con;
        int kID;
        int toplam;
        int bakiye;
        public anasayfa(int k)
        {
            
            InitializeComponent();
            kID = k;
            string connString =
                String.Format(
                    "Server=localhost;User Id=postgres;Database=yemegimigetir;Port=5432;Password=benbuyum123;SSLMode=Prefer");
            con = new NpgsqlConnection(connString);

            con.Open();

            using (var command = new NpgsqlCommand("SELECT kullanici_adi,kullanici_soyadi,kullanici_bakiye From kullanici WHERE kullanici_id=@id ", con))
                {
                    command.Parameters.AddWithValue("id", kID);
                    NpgsqlDataReader dr = command.ExecuteReader();
                    

                    if (dr.Read())
                    {
                    label_isim.Text = dr["kullanici_adi"].ToString() + " " + dr["kullanici_soyadi"].ToString();
                    label_bakiye.Text += dr["kullanici_bakiye"].ToString();
                    bakiye= int.Parse(dr["kullanici_bakiye"].ToString());
                }
                con.Close();
            }

            con.Open();
            using (var command = new NpgsqlCommand("SELECT adres_baslik,adres_adres From adres WHERE adres_kid=@id ", con))
            {
                command.Parameters.AddWithValue("id", kID);
                NpgsqlDataReader dr = command.ExecuteReader();

                
                while (dr.Read())
                {
                    UserControl3 uc3 = new UserControl3(dr["adres_baslik"].ToString(), dr["adres_adres"].ToString());
                    uc3.Dock = DockStyle.Top;
                    panel9.Controls.Add(uc3);
                }
                con.Close();
            }

            con.Open();
            using (var command = new NpgsqlCommand("SELECT magaza_isim,magaza_puan From magaza ", con))
            {
                NpgsqlDataReader dr = command.ExecuteReader();


                while (dr.Read())
                {
                    UserControl4 uc4 = new UserControl4(dr["magaza_isim"].ToString(), dr["magaza_puan"].ToString());
                    uc4.Dock = DockStyle.Top;
                    uc4.MouseHover+= new EventHandler(this.mh);
                    uc4.MouseLeave += new EventHandler(this.ml);
                    uc4.Click += new EventHandler(this.click);
                    panel11.Controls.Add(uc4);
                }
                con.Close();
            }

        }
        public void magazaGuncelle()
        {
            for (int i = 0; i < panel11.Controls.Count; i++)
            {

                panel11.Controls.RemoveAt(i);
            }
            con.Open();
            using (var command = new NpgsqlCommand("SELECT magaza_isim,magaza_puan From magaza ", con))
            {
                NpgsqlDataReader dr = command.ExecuteReader();


                while (dr.Read())
                {
                    UserControl4 uc4 = new UserControl4(dr["magaza_isim"].ToString(), dr["magaza_puan"].ToString());
                    uc4.Dock = DockStyle.Top;
                    uc4.MouseHover += new EventHandler(this.mh);
                    uc4.MouseLeave += new EventHandler(this.ml);
                    uc4.Click += new EventHandler(this.click);
                    panel11.Controls.Add(uc4);
                }
                con.Close();
            }
        }
        public void adresGuncelle()
        {
            for(int i = 0; i < panel9.Controls.Count; i++)
            {

                panel9.Controls.RemoveAt(i);
            }
            con.Open();
            using (var command = new NpgsqlCommand("SELECT adres_baslik,adres_adres From adres WHERE adres_kid=@id ", con))
            {
                command.Parameters.AddWithValue("id", kID);
                NpgsqlDataReader dr = command.ExecuteReader();


                while (dr.Read())
                {
                    UserControl3 uc3 = new UserControl3(dr["adres_baslik"].ToString(), dr["adres_adres"].ToString());
                    uc3.Dock = DockStyle.Top;
                    panel9.Controls.Add(uc3);
                }
                con.Close();
            }
        }
        private void button1_Clik(object sender, EventArgs e)
        {
            UserControl2 el = new UserControl2("asd", "100");
            el.Dock =DockStyle.Top;
            panel6.Controls.Add(el);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            adresEklecs ae = new adresEklecs(kID,this);
            ae.Show();

        }
        void mh(object sender, EventArgs e)
        {
            UserControl4 panel = (UserControl4)sender;
            panel.BackColor = SystemColors.ActiveBorder;
        }
        void ml(object sender, EventArgs e)
        {
            UserControl4 panel = (UserControl4)sender;
            panel.BackColor = SystemColors.Control;
        }
        int magazaID;
        void click(object sender, EventArgs e)
        {
            panel_menu2.Controls.Clear();
            panel_yemek.Controls.Clear();
            panel_icecek2.Controls.Clear();
            UserControl4 uc4 = (UserControl4)sender;

            con.Open();
            var command1 = new NpgsqlCommand("SELECT magaza_id From magaza where magaza_isim=@isim and magaza_puan=@puan", con);
            
                command1.Parameters.AddWithValue("isim", uc4.yy);
                command1.Parameters.AddWithValue("puan", int.Parse(uc4.p));
                var mid = command1.ExecuteScalar();
                con.Close();
            magazaID = (int)mid;

            panel15.Visible = true;

            panel11.Controls.Clear();
            
            button_geri.Visible=true;
            con.Open();
            using (var command = new NpgsqlCommand("SELECT menu_isim,menu_fiyat From menu where menu_magazaid=@id", con))
            {
                command.Parameters.AddWithValue("id", mid);
                NpgsqlDataReader dr = command.ExecuteReader();


                while (dr.Read())
                {
                    UserControl5 uc5 = new UserControl5(dr["menu_isim"].ToString(), int.Parse(dr["menu_fiyat"].ToString()),this);
                    uc5.Dock = DockStyle.Top;
                    panel_menu2.Controls.Add(uc5);
                }
                con.Close();
            }

            con.Open();
            using (var command = new NpgsqlCommand("SELECT yemek_isim,yemek_fiyat From yemek where yemek_magazaid=@id", con))
            {
                command.Parameters.AddWithValue("id", mid);
                NpgsqlDataReader dr = command.ExecuteReader();


                while (dr.Read())
                {
                    UserControl5 uc5 = new UserControl5(dr["yemek_isim"].ToString(), int.Parse(dr["yemek_fiyat"].ToString()), this);
                    uc5.Dock = DockStyle.Top;
                    panel_yemek.Controls.Add(uc5);
                }
                con.Close();
            }

            con.Open();
            using (var command = new NpgsqlCommand("SELECT icecek_isim,icecek_fiyat From icecek where icecek_magazaid=@id", con))
            {
                command.Parameters.AddWithValue("id", mid);
                NpgsqlDataReader dr = command.ExecuteReader();


                while (dr.Read())
                {
                    UserControl5 uc5 = new UserControl5(dr["icecek_isim"].ToString(), int.Parse(dr["icecek_fiyat"].ToString()), this);
                    uc5.Dock = DockStyle.Top;
                    panel_icecek2.Controls.Add(uc5);
                }
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            panel15.Visible = false;
            for (int i = 0; i < panel11.Controls.Count; i++)
            {

                panel11.Controls.RemoveAt(i);
            }
            magazaGuncelle();
            button_geri.Visible = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        public void SiparisEkle(string isim,int fiyat)
        {
            panel17.Visible = true;
            toplam += fiyat;
            if (toplam > bakiye)
                label_uyari.Visible = true;
            else
                label_uyari.Visible = false;
            label8.Text = "Toplam Ücret:" + toplam;
            UserControl6 uc6 = new UserControl6(isim,fiyat,this);
            uc6.Dock = DockStyle.Top;
            panel6.Controls.Add(uc6);
        }
        public void SiparisCikar(int fiyat,UserControl6 uc6)
        {
            panel6.Controls.Remove(uc6);
            toplam -= fiyat;
            if (toplam > bakiye)
                label_uyari.Visible = true;
            else
                label_uyari.Visible = false;
            label8.Text = "Toplam Ücret:" + toplam;
        }

            private void button_geri_Click(object sender, EventArgs e)
        {
            panel15.Visible = false;
            for (int i = 0; i < panel11.Controls.Count; i++)
            {

                panel11.Controls.RemoveAt(i);
            }
            magazaGuncelle();
            button_geri.Visible = false;
        }

        public void fiyatkes(int fiyat)
        {
            bakiye -= toplam;
            label_bakiye.Text = "Bakiye:" + bakiye;

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (label_uyari.Visible == false)
            {
                Form5 f5 = new Form5(this,magazaID,toplam);
                f5.Show();
                
            }
        }
    }
}
