using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yemeksepeti
{
    public partial class UserControl5 : UserControl
    {
        anasayfa anasayfa;
        string ad;
        int f;
        public UserControl5(string isim,int fiyat,anasayfa a)
        {
            InitializeComponent();
            label1.Text = isim;
            label2.Text += fiyat;
            anasayfa = a;
            ad = isim;
            f = fiyat;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            anasayfa.SiparisEkle(ad, f);
        }
    }
}
