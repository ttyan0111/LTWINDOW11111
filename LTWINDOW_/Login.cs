using LTWINDOW_.Options;
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
    public partial class Login : Form
    {
        string maNhanVien, tenNhanVien;
        private string actualPassword = "";
        public Login()
        {
            InitializeComponent();
            


        }
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            // Lấy vị trí con trỏ hiện tại
            int cursorPosition = txtPassword.SelectionStart;

            // Cập nhật mật khẩu thực tế
            if (txtPassword.Text.Length > actualPassword.Length)
            {
                // Nếu có ký tự mới được nhập
                actualPassword += txtPassword.Text.Substring(actualPassword.Length);
            }
            else if (txtPassword.Text.Length < actualPassword.Length)
            {
                // Nếu có ký tự bị xóa
                actualPassword = actualPassword.Substring(0, txtPassword.Text.Length);
            }

            // Thay thế tất cả ký tự hiển thị bằng dấu *
            txtPassword.Text = new string('*', actualPassword.Length);

            // Khôi phục vị trí con trỏ
            txtPassword.SelectionStart = cursorPosition;
        }
        private async void Login_Load(object sender, EventArgs e)
        {
            
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserName_KeyDown);

            await Task.Delay(100); // Đợi 100ms để đảm bảo form đã sẵn sàng
            txtUserName.Focus();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
          
            string username = txtUserName.Text, passsword = actualPassword;

            ListTaiKhoan ltk = new ListTaiKhoan();
            ltk.queryTaiKhoan(@"select NhanVien.UserName, NhanVien.Passcode, NhanVien.TenNhanVien, NhanVien.MaNhanVien from NhanVien");
            List<TaiKhoan> taiKhoans = ltk.List;

            errorProvider1.Clear();
            if(username.Trim() == "") errorProvider1.SetError(txtUserName, "Bạn chưa nhập tài khoản.");
            if(passsword.Trim() == "") errorProvider1.SetError(txtPassword, "Bạn chưa nhập mật khẩu.");
            if (username.Trim() != "" && passsword.Trim() != "")
            {
                if (taiKhoans.Count > 0)
                {
                    int check = 0;
                    foreach (TaiKhoan tk in taiKhoans)
                    {
                        if (tk.UserName == username && tk.Password == passsword)
                        {
                            maNhanVien = tk.MaNhanVien;
                            tenNhanVien = tk.TenNhanVien;
                          
                            check = 1;
                            break;
                        }
                    }

                    if (check == 1)
                    {
                        lblThongBaoInvalid.Visible = false;
                        this.Hide();
                        Form1 form = new Form1(tenNhanVien, maNhanVien);
                        form.Show();
                        
                    }
                    else lblThongBaoInvalid.Visible = true;
                }
            }
            

            //if (username.Trim() != "" && passsword.Trim() != "")
            //{
            //    if (ltk.isExit(username, passsword))
            //    {
            //        this.Hide();
            //        Form1 form1 = new Form1();
            //        form1.Show();
            //    }
            //    else MessageBox.Show("Tài Khoản hoặc mật khẩu không chính xác.");
            //}
            //else MessageBox.Show("Bạn chưa nhập mật khẩu hoặc Tài Khoản");


        }
       
        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            // Kiểm tra xem phím Enter có được nhấn không
            if (e.KeyCode == Keys.Enter)
            {
                // Ngừng hành vi mặc định của phím Enter (không tạo dòng mới)
                e.SuppressKeyPress = true;

                // Chuyển focus từ txtUserName sang txtPassword
                txtPassword.Focus();
            }

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát?\nNếu thoát chon Yes không chọn No.", "Thoát Đăng Nhập",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
                e.Cancel = true;

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            // Kiểm tra xem phím Enter có được nhấn không
            if (e.KeyCode == Keys.Enter)
            {
                // Ngừng hành vi mặc định của phím Enter (không tạo dòng mới)
                e.SuppressKeyPress = true;

                // Gọi hàm tìm kiếm
                button1_Click(sender, e);
            }
        }
        
    }
}
