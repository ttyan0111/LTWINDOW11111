using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LTWINDOW_.MenuQuanLy
{
    public partial class FixNhanVien : Form
    {
        SQL sql;
        public FixNhanVien()
        {
            InitializeComponent();
        }

        // đẩy mã nhân viên lên cmbId.
        void loadId(string query)
        {
            sql = new SQL();

            using (SqlConnection connection = sql.Conn)
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        cmbId.Items.Add(dataReader.GetInt32(0) + "");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        private void FixNhanVien_Load(object sender, EventArgs e)
        {
            string query = "select MaNhanVien from NhanVien";
            loadId(query);
        }

        // đẩy thông tin của nhân viện có mã được chọn lên khung chưa dữ liệu.
        void dayData(string query, int id)
        {
            sql = new SQL();

            using (SqlConnection connection = sql.Conn)
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);


                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        txtName.Text = dataReader.GetString(1);
                        txtUsername.Text = dataReader.GetString(2);
                        txtPassword.Text = dataReader.GetString(3);
                        txtPosition.Text = dataReader.GetString(4);
                        if (dataReader.GetBoolean(5)) cmbStatus.SelectedIndex = 1;
                        else cmbStatus.SelectedIndex = 0;
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void cmbId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbId.SelectedIndex != -1)
            {
                string query = "select * from NhanVien where MaNhanVien = @id";
                int id = int.Parse(cmbId.Items[cmbId.SelectedIndex].ToString());
                dayData(query, id);
            }

        }

        // update NhanVien.
        bool updateNhanVien(string strUpdate, int id,string name, string username, string password, string position, bool status)
        {
            sql = new SQL();

            using (SqlConnection connection = sql.Conn)
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(strUpdate, connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@position", position);
                    command.Parameters.AddWithValue("@status", status);

                    command.ExecuteNonQuery();

                    return true;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                } 
                
            }    
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int id = -1;
            if(cmbId.SelectedIndex != -1) { id = int.Parse(cmbId.Items[cmbId.SelectedIndex].ToString());}
            string name = txtName.Text;
            string position = txtPosition.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            bool status = false;
            if (cmbStatus.SelectedIndex == 0) status = false;
            else if(cmbStatus.SelectedIndex == 1) status = true;
                

            errorProvider1.Clear();
            bool check = false; // kiểm tra dòng bỏ trống.
            if(id == -1)
            {
                errorProvider1.SetError(cmbId, "chưa chọn id");
                check = true;
            }    
            if (name == "")
            {
                errorProvider1.SetError(txtName, "không được để trống");
                check = true;
            } 
            if(position == "")
            {
                errorProvider1.SetError(txtPosition, "không được để trống");
                check = true;
            }    
            if(username == "")
            {
                errorProvider1.SetError(txtUsername, "không được để trống");
                check = true;
            } 
            if(password == "")
            {
                errorProvider1.SetError(txtPassword, "không được để trống");
                check = true;
            }    
            if(cmbStatus.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbStatus, "chưa chọn trạng thái");
                check = true;
            }    


            if(!check)
            {
                // chuỗi.
                string strUpdate = "update NhanVien\n" +
                    "set TenNhanVien = @name, UserName = @username, Passcode = @password, ChucVu = @position, trangThaiHoatDong = @status\n" +
                    "where MaNhanVien = @id";

                // update.
                if (updateNhanVien(strUpdate, id, name, username, password, position, status))
                {
                    MessageBox.Show("Thành công", "Thông Báo Update");
                }
                else MessageBox.Show("thất bại", "Thông Báo Update");

            }   
            
        }
        
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("bạn có chắc muốn thoát!\nnếu có chọn Yes không chọn No", "Thông Báo Thoát", 
                MessageBoxButtons.YesNo) == DialogResult.Yes) 
                this.Close();
        }
    }
}
