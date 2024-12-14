﻿using LTWINDOW_.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LTWINDOW_
{
    public partial class Form1 : Form
    {
        SQL sql;
        Form currentFormChild;
        public Form1()
        {
            InitializeComponent();
            sql = new SQL();
            sql.OpenConnection();
            uC_DashBoard1.Visible = true;
            uC_Menu1.Visible = false;

        }

        private void buttonTrangChinh_Click(object sender, EventArgs e)
        {
            uC_DashBoard1.Visible = true;
            uC_Menu1.Visible = false;
           

            
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            uC_DashBoard1.Visible = false;
            uC_Menu1.Visible = true;
        }

        private void buttonQuanLyBan_Click(object sender, EventArgs e)
        {
            // khởi tạo form quản lý bàn
            //Form QuanLyBan = new QuanLiBan();

            //// mở form QuanLyBan trong panel_body.
            //openCurrentFormChild(QuanLyBan);

        }

        // gắn form con vào panel_body.
        private void openCurrentFormChild(Form formChild)
        {
            // đóng form đang mở
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }

            // khởi tạo form con là form  muốn hiển thị.
            currentFormChild = formChild;

            currentFormChild.TopLevel = false; // làm cho form này hoạt động như một form con,

            // hiển thị full trên panel chứa nó.
            currentFormChild.Dock = DockStyle.Fill;

            // tắt thanh tiêu đề của form.
            

            // thêm form muốn hiển thị vào panel
            panel1.Controls.Add(currentFormChild);

            // để form con hiển thị ở chế độ ưu tiên.
            currentFormChild.BringToFront();

            // hiển thị form trên panel chứa nó.
            currentFormChild.Show();

        }
    }
}
