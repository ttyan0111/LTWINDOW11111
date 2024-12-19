using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTWINDOW_.MenuQuanLy
{
    public partial class HienThiTongTien : Form
    {
        public HienThiTongTien(float tongTien)
        {
            InitializeComponent();
            CultureInfo cultureInfo = new CultureInfo("vi-VN");
            lblTongTien.Text = tongTien.ToString("C", cultureInfo);
        }

        private void HienThiTongTien_Load(object sender, EventArgs e)
        {

        }
    }
}
