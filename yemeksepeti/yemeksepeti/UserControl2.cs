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
    public partial class UserControl2 : UserControl
    {
        public UserControl2(string isim,string fiyat)
        {
            InitializeComponent();
            label_fiyat.Text += fiyat;
            label_isim.Text = isim;
            
        }
    }
}
