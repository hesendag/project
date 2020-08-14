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
    public partial class UserControl6 : UserControl
    {
        anasayfa an;
        int f;
        public UserControl6(string isim,int fiyat,anasayfa a)
        {
            InitializeComponent();
            label1.Text = isim;
            label2.Text += fiyat;
            an = a;
            f = fiyat;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            an.SiparisCikar(f, this);
        }
    }
}
