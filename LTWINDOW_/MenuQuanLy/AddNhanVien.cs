using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LTWINDOW_.MenuQuanLy
{
    public partial class AddNhanVien : Form
    {
        SQL sql;
        public AddNhanVien()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc muốn thoát?", "Thông Báo Thoát", 
               MessageBoxButtons.YesNo)  == DialogResult.Yes) this.Close();
        }

        bool addNhanVien(string strInsert, string name, string username, string password, string position)
        {
            sql = new SQL();

            using(SqlConnection connection = sql.Conn)
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(strInsert, connection);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@position", position);
                    command.Parameters.AddWithValue("@status", true);
                    command.ExecuteNonQuery();
                    
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                } 
                
            } 
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string position = txtPosition.Text.Trim();

            bool check = false; // check dòng trống
            errorProvider1.Clear();
            if (name == "")
            {
                errorProvider1.SetError(txtName, "không được để trống");
                check = true;
            }
            if (username == "")
            {
                errorProvider1.SetError(txtUsername, "không đươc để trống");
                check = true;
            }
            if (password == "")
            {
                errorProvider1.SetError(txtPassword, "không đươc để trống");
                check = true;
            }
            if (position == "")
            {
                errorProvider1.SetError(txtPosition, "không đươc để trống");
                check = true;
            }

            if(!check)
            {
                //command.Parameters.AddWithValue("@name", name);
                //command.Parameters.AddWithValue("@username", username);
                //command.Parameters.AddWithValue("@password", password);
                //command.Parameters.AddWithValue("@position", position);
                //command.Parameters.AddWithValue("@status", status);
                string strInsert = "insert into NhanVien(TenNhanVien, UserName, Passcode, ChucVu, trangThaiHoatDong) Values" +
                                   "\n(@name, @username, @password, @position, @status)";
                if (addNhanVien(strInsert, name, username, password, position))
                {
                    MessageBox.Show("Thành Công", "Thông Báo Thêm");
                    txtName.Text = "";
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtPosition.Text = "";
                }
                else MessageBox.Show("Thất bại", "Thông Báo Thêm");
            }    
        }
        
    }
}
