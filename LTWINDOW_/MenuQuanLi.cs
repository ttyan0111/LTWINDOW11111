using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTWINDOW_
{
    public partial class MenuQuanLi : Form
    {
        public MenuQuanLi()
        {
            InitializeComponent();
        }
        //
        // hiệu ứng chuột ptb loại món
        //
        private void ptbThucDon_MouseHover_1(object sender, EventArgs e)
        {
            panel_top_mon.BackColor = Color.FromArgb(255, 128, 255);
            panel_top_mon.BorderStyle = BorderStyle.Fixed3D;
        }

        private void ptbThucDon_MouseLeave_1(object sender, EventArgs e)
        {
            panel_top_mon.BackColor = Color.FromArgb(255, 192, 255);
            panel_top_mon.BorderStyle = BorderStyle.FixedSingle;
        }
        //
        // hiệu ứng chuột ptb loại món
        //
        private void ptbLoaiMon_Click(object sender, EventArgs e)
        {

        }

        private void ptbLoaiMon_MouseHover(object sender, EventArgs e)
        {
            panel_top_loaiMon.BackColor = Color.FromArgb(255, 128, 255);
            panel_top_loaiMon.BorderStyle = BorderStyle.Fixed3D;
        }
        
        private void ptbLoaiMon_MouseLeave(object sender, EventArgs e)
        {
            panel_top_loaiMon.BackColor = Color.FromArgb(255, 192, 255);
            panel_top_loaiMon.BorderStyle = BorderStyle.FixedSingle;
        }
        //
        // hiệu ứng chuột ptb loại món
        //
        private void ptbTaiKhoan_MouseHover(object sender, EventArgs e)
        {
            panel_top_taiKhoan.BackColor = Color.FromArgb(255, 128, 255);
            panel_top_taiKhoan.BorderStyle = BorderStyle.Fixed3D;
        }

        private void ptbTaiKhoan_MouseLeave(object sender, EventArgs e)
        {
            panel_top_taiKhoan.BackColor = Color.FromArgb(255, 192, 255);
            panel_top_taiKhoan.BorderStyle = BorderStyle.FixedSingle;
        }

        
    }
}
