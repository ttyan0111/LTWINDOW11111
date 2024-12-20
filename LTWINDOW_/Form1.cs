using Guna.UI2.WinForms;
using LTWINDOW_.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        string idNhanVien;
        public Form1(string tenNhanVien,string maNhanVien)
        {
            InitializeComponent();
            


            sql = new SQL();
            sql.OpenConnection();
            uC_DashBoard1.SetTenNhanVien(tenNhanVien);
            uC_Menu1.SetMaNhanVien(maNhanVien);

            uC_DashBoard1.Visible = true;
            uC_DashBoard1.DangXuat += uC_DashBoard1_DangXuat;
            uC_Menu1.Visible = false;
            uC_QuanLi1.Visible = false;
            HUBan.Visible = false;
            HUMenu.Visible = false;
            HUQuanLi.Visible = false;
            HUTrangChinh.Visible = true;
            this.idNhanVien = maNhanVien;
            

        }

        private void buttonTrangChinh_Click(object sender, EventArgs e)
        {
            // đóng form đang mở
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            
            uC_DashBoard1.Visible = true;
            uC_Menu1.Visible = false;
            uC_QuanLi1.Visible = false;
            uC_DashBoard1.LoadDuLieuAll();
            HUBan.Visible = false;
            HUMenu.Visible = false;
            HUQuanLi.Visible = false;
            HUTrangChinh.Visible = true;
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            // đóng form đang mở
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }

            uC_DashBoard1.Visible = false;
            uC_Menu1.Visible = true;
            uC_QuanLi1.Visible = false;
            HUBan.Visible = false;
            HUMenu.Visible = true;
            HUQuanLi.Visible = false;
            HUTrangChinh.Visible = false;
        }

        private void buttonQuanLyBan_Click(object sender, EventArgs e)
        {
            //khởi tạo form quản lý bàn
            Form QuanLyBan = new QuanLiBan();

            // mở form QuanLyBan trong panel_body.
            openCurrentFormChild(QuanLyBan);

            HUBan.Visible = true;
            HUMenu.Visible = false;
            HUQuanLi.Visible = false;
            HUTrangChinh.Visible = false;
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

        private void buttonQuanLy_Click(object sender, EventArgs e)
        {
            // lấy chức vụ của của tài khoản đã đăng nhập vào hệ thống.
            string position = getPosition("select ChucVu from NhanVien where MaNhanVien = @idNhanVien").Trim().ToLower();

            // check chức vụ
            if (position == "quản lý" || position == "quản lí")
            {
                // đóng form đang mở
                if (currentFormChild != null)
                {
                    currentFormChild.Close();
                }

                uC_DashBoard1.Visible = false;
                uC_Menu1.Visible = false;
                uC_QuanLi1.Visible = true;

                HUBan.Visible = false;
                HUMenu.Visible = false;
                HUQuanLi.Visible = true;
                HUTrangChinh.Visible = false;
            }
            else
            {
                MessageBox.Show("Chỉ có quản lý mới được sử dụng chức năng này.", "Thông Báo Không Được truy Cập");
            }

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // Đóng toàn bộ ứng dụng bao gồm các form ẩn
                Application.Exit();
                // Đóng form hiện tại
                this.Close();

               
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // đóng form đang mở
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }

            uC_DashBoard1.Visible = true;
            uC_Menu1.Visible = false;
            uC_QuanLi1.Visible = false;
            HUBan.Visible = false;
            HUMenu.Visible = false;
            HUQuanLi.Visible = false;
            HUTrangChinh.Visible = true;
        }
        string getPosition(string query)
        {
            sql = new SQL();

            string result = "";
            using (SqlConnection connection = sql.Conn)
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@idNhanVien", idNhanVien);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        result = reader.GetString(0);
                    }

                    return result;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return result;
                }

            }
        }

        private void uC_DashBoard1_DangXuat(object sender, EventArgs e)
        {
            this.Close(); // Đóng ứng dụng hoặc thực hiện logic khác
            
        }

    }
}
