using LTWINDOW_.MenuQuanLy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTWINDOW_.Options
{
    public partial class UC_QuanLi : UserControl
    {
        public UC_QuanLi()
        {
            InitializeComponent();
        }


        private void panel_top_ThucDon_MouseHover(object sender, EventArgs e)
        {
            panel_top_ThucDon.BackColor = Color.FromArgb(255, 128, 255);
            panel_top_ThucDon.BorderStyle = BorderStyle.Fixed3D;
        }

        private void panel_top_ThucDon_MouseLeave(object sender, EventArgs e)
        {
            panel_top_ThucDon.BackColor = Color.FromArgb(255, 192, 255);
            panel_top_ThucDon.BorderStyle = BorderStyle.FixedSingle;
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
        private void ptn_ThongBao_MouseHover(object sender, EventArgs e)
        {
            panel_top_taiKhoan.BackColor = Color.FromArgb(255, 128, 255);
            panel_top_taiKhoan.BorderStyle = BorderStyle.Fixed3D;
        }
        private void ptn_ThongBao_MouseLeave(object sender, EventArgs e)
        {
            panel_top_taiKhoan.BackColor = Color.FromArgb(255, 192, 255);
            panel_top_taiKhoan.BorderStyle = BorderStyle.FixedSingle;
        }

        private void ptbLoaiMon_Click_1(object sender, EventArgs e)
        {

        }

        private void ptbLoaiMon_Click_2(object sender, EventArgs e)
        {
            uC_QuanLyMon.Visible = true;
        }
    }
}
