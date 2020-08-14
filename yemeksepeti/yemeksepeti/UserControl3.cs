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
    public partial class UserControl3 : UserControl
    {
        public UserControl3(string baslik,string adres)
        {
            InitializeComponent();
            label1.Text = adres;
            label2.Text = baslik;
        }
    }
}
