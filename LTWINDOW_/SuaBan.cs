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

namespace LTWINDOW_
{
    public partial class SuaBan : Form
    {
        SQL sql;
        public SuaBan()
        {
            sql = new SQL();
            InitializeComponent();
        }
        private void SuaBan_Load(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = 0;

            using (SqlConnection connection = sql.Conn)
            {
                try
                {
                    connection.Open();

                    String query = "select MaBan from Ban";

                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbCode.Items.Add(reader["MaBan"].ToString());
                        }
                    }    
                        
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void cmbCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(cmbCode.SelectedItem == null)
            {
                MessageBox.Show("vui lòng chọn 1 mã bàn");
            } 
                
            // lấy MaBan Được chọn.
            int MaBan = int.Parse(cmbCode.SelectedItem.ToString());
            sql = new SQL();
            using (SqlConnection connection = sql.Conn)
            {
                connection.Open();
                string query = $"select Tenban from Ban where MaBan = @MaBan";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaBan", MaBan);

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while(dataReader.Read())
                    {
                        txtName.Text = dataReader.GetString(0);
                    }    
                }    
            } 
                
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát", "Warnning", MessageBoxButtons.OKCancel) == DialogResult.OK) this.Close();
        }

        bool updateBan(string query)
        {
            bool result = true;
            string TenBan = txtName.Text, TrangThai = cmbStatus.SelectedItem.ToString();
            if (cmbCode.SelectedItem != null && TenBan.Trim() != "")
            {
                sql = new SQL();
                using (SqlConnection connection = sql.Conn)
                {
                    try
                    {
                        connection.Open();

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@TenBan", TenBan);
                        command.Parameters.AddWithValue("@TrangThai", TrangThai);
                        int MaBan;
                        if (int.TryParse(cmbCode.SelectedItem.ToString(), out MaBan))
                            command.Parameters.AddWithValue("@MaBan", MaBan);

                        command.ExecuteNonQuery();
                        
                    }
                    catch (Exception ex)
                    {
                        result = false;
                        MessageBox.Show(ex.Message);
                    } 
                }
            }
            else result = false;

            return result;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(cmbCode.Items.Count > 0 )
            {
                string query = "update Ban Set TenBan=@TenBan, TrangThai = @TrangThai where MaBan = @MaBan";
                if (updateBan(query))
                {
                    if (MessageBox.Show("Bạn đã update thành công!.\n nếu muốn update tiếp chọn yes không chọn No?", "Thông Báo", 
                        MessageBoxButtons.YesNo) == DialogResult.No) 
                        this.Close();
                    return;
                }
                else MessageBox.Show("update thất bại!");
                this.Close();
            }    
            else
            {
                if (MessageBox.Show("Không có bàn nào để sửa!", "Thông Báo", MessageBoxButtons.OK) == DialogResult.OK) this.Close();
            }
        }
    }
}
