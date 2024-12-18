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
            uC_QuanLyLoaiMon.Visible = false;
            uC_QuanLyNhanVien.Visible = false;
            uC_quanLyDoanhThu.Visible = false;
        }


    
        //
        // hiệu ứng chuột ptb loại món
        //
    

        private void ptbLoaiMon_MouseLeave(object sender, EventArgs e)
        {
            panel_top_loaiMon.BackColor = Color.FromArgb(255, 192, 255);
            panel_top_loaiMon.BorderStyle = BorderStyle.FixedSingle;
        }
        //
        // hiệu ứng chuột ptb loại món
        //
        private void ptbTaiKhoan_MouseLeave(object sender, EventArgs e)
        {
            panel_top_taiKhoan.BackColor = Color.FromArgb(255, 192, 255);
            panel_top_taiKhoan.BorderStyle = BorderStyle.FixedSingle;
        }
   
    
        private void ptbLoaiMon_Click_1(object sender, EventArgs e)
        {

        }

        private void ptbLoaiMon_Click_2(object sender, EventArgs e)
        {
            uC_quanLyDoanhThu.Visible = false;
            uC_QuanLyNhanVien.Visible = false;
            uC_QuanLyLoaiMon.Visible = true;
            uC_ThongBao1.Visible = false;
        }

        private void ptbTaiKhoan_Click(object sender, EventArgs e)
        {
            uC_quanLyDoanhThu.Visible = false;
            uC_QuanLyLoaiMon.Visible = false;
            uC_QuanLyNhanVien.Visible = true;
            uC_ThongBao1.Visible = false;

        }

        private void uC_QuanLyMon_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            ptn_ThongBao.BackColor = Color.FromArgb(255, 192, 255);
            ptn_ThongBao.BorderStyle = BorderStyle.FixedSingle;
        }

        private void ptbThucDon_MouseLeave(object sender, EventArgs e)
        {
            panel_top_ThucDon.BackColor = Color.FromArgb(255, 192, 255);
            panel_top_ThucDon.BorderStyle = BorderStyle.FixedSingle;
        }

        private void ptbThucDon_MouseMove(object sender, MouseEventArgs e)
        {
            panel_top_ThucDon.BackColor = Color.FromArgb(255, 128, 255);
            panel_top_ThucDon.BorderStyle = BorderStyle.Fixed3D;
        }

        private void lblThucDon_MouseLeave(object sender, EventArgs e)
        {
            panel_top_ThucDon.BackColor = Color.FromArgb(255, 192, 255);
            panel_top_ThucDon.BorderStyle = BorderStyle.FixedSingle;
        }

        private void ptbLoaiMon_MouseMove(object sender, MouseEventArgs e)
        {
            panel_top_loaiMon.BackColor = Color.FromArgb(255, 128, 255);
            panel_top_loaiMon.BorderStyle = BorderStyle.Fixed3D;
        }

        private void lblLoaiMon_MouseLeave(object sender, EventArgs e)
        {
            panel_top_loaiMon.BackColor = Color.FromArgb(255, 192, 255);
            panel_top_loaiMon.BorderStyle = BorderStyle.FixedSingle;
        }

        private void ptbTaiKhoan_MouseMove(object sender, MouseEventArgs e)
        {
            panel_top_taiKhoan.BackColor = Color.FromArgb(255, 128, 255);
            panel_top_taiKhoan.BorderStyle = BorderStyle.Fixed3D;
        }

        private void lblTaiKhoan_MouseLeave(object sender, EventArgs e)
        {
            panel_top_taiKhoan.BackColor = Color.FromArgb(255, 192, 255);
            panel_top_taiKhoan.BorderStyle = BorderStyle.FixedSingle;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            ptn_ThongBao.BackColor = Color.FromArgb(255, 128, 255);
            ptn_ThongBao.BorderStyle = BorderStyle.Fixed3D;
        }
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            ptn_ThongBao.BackColor = Color.FromArgb(255, 192, 255);
            ptn_ThongBao.BorderStyle = BorderStyle.FixedSingle;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            uC_quanLyDoanhThu.Visible = false;
            uC_QuanLyNhanVien.Visible = false;
            uC_QuanLyLoaiMon.Visible = false;
            uC_ThongBao1.Visible = true;
        }

        private void ptbThucDon_Click(object sender, EventArgs e)
        {
           
        }

        private void lblThucDon_MouseMove(object sender, MouseEventArgs e)
        {
            panel_top_ThucDon.BackColor = Color.FromArgb(255, 128, 255);
            panel_top_ThucDon.BorderStyle = BorderStyle.Fixed3D;
        }

        private void lblLoaiMon_MouseMove(object sender, MouseEventArgs e)
        {
            panel_top_loaiMon.BackColor = Color.FromArgb(255, 128, 255);
            panel_top_loaiMon.BorderStyle = BorderStyle.Fixed3D;
        }

        private void lblTaiKhoan_MouseMove(object sender, MouseEventArgs e)
        {
            panel_top_taiKhoan.BackColor = Color.FromArgb(255, 128, 255);
            panel_top_taiKhoan.BorderStyle = BorderStyle.Fixed3D;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            ptn_ThongBao.BackColor = Color.FromArgb(255, 128, 255);
            ptn_ThongBao.BorderStyle = BorderStyle.Fixed3D;
        }

        private void lblTaiKhoan_Click(object sender, EventArgs e)
        {
            uC_quanLyDoanhThu.Visible = false;
            uC_QuanLyLoaiMon.Visible = false;
            uC_QuanLyNhanVien.Visible = true;
            uC_ThongBao1.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            uC_quanLyDoanhThu.Visible = false;
            uC_QuanLyNhanVien.Visible = false;
            uC_QuanLyLoaiMon.Visible = false;
            uC_ThongBao1.Visible = true;
        }

        private void lblLoaiMon_Click(object sender, EventArgs e)
        {
            uC_quanLyDoanhThu.Visible = false;
            uC_QuanLyNhanVien.Visible = false;
            uC_QuanLyLoaiMon.Visible = true;
            uC_ThongBao1.Visible = false;
        }

        private void lblThucDon_Click(object sender, EventArgs e)
        {

        }
        //
        // Daonh thu
        //
        private void ptbDoanhThu_MouseMove(object sender, MouseEventArgs e)
        {
            panel_top_doanhThu.BackColor = Color.FromArgb(255, 128, 255);
            panel_top_doanhThu.BorderStyle = BorderStyle.Fixed3D;
        }

        private void ptbDoanhThu_MouseLeave(object sender, EventArgs e)
        {
            panel_top_doanhThu.BackColor = Color.FromArgb(255, 192, 255);
            panel_top_doanhThu.BorderStyle = BorderStyle.FixedSingle;
        }

        private void lblDoanhThu_MouseMove(object sender, MouseEventArgs e)
        {
            panel_top_doanhThu.BackColor = Color.FromArgb(255, 128, 255);
            panel_top_doanhThu.BorderStyle = BorderStyle.Fixed3D;
        }

        private void lblDoanhThu_MouseLeave(object sender, EventArgs e)
        {
            panel_top_doanhThu.BackColor = Color.FromArgb(255, 192, 255);
            panel_top_doanhThu.BorderStyle = BorderStyle.FixedSingle;
        }

        private void ptbDoanhThu_Click(object sender, EventArgs e)
        {
            uC_ThongBao1.Visible = false;
            uC_QuanLyLoaiMon.Visible = false;  
            uC_QuanLyNhanVien.Visible = false;
            uC_quanLyDoanhThu.Visible = true;
        }

        private void lblDoanhThu_Click(object sender, EventArgs e)
        {
            uC_ThongBao1.Visible = false;
            uC_QuanLyLoaiMon.Visible = false;
            uC_QuanLyNhanVien.Visible = false;
            uC_quanLyDoanhThu.Visible = true;
        }
    }
}
