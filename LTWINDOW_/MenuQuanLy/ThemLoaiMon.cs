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

namespace LTWINDOW_.MenuQuanLy
{
    public partial class ThemLoaiMon : Form
    {
        SQL sql;
        ListLoaiMoncs loaiMoncs;

        public ThemLoaiMon()
        {
            InitializeComponent();
            sql = new SQL();
            loaiMoncs = new ListLoaiMoncs();
        }


        // thêm 1 dòng dữ liệu vào sql.
        void addRow(string query, string id, string name)
        {
            sql = new SQL();
            using (SqlConnection connection = sql.Conn)
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", name);

                    command.ExecuteNonQuery();
                    MessageBox.Show("thêm thành công");
                    txtId.Text = txtName.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "thêm thất bại");
                }
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = txtId.Text.Trim(), name = txtName.Text.Trim();
            // 
            int check = 1;

            // hết error cũ.
            errorProvider1.Clear();
            // hiển thị error khi để trống thông tin mã loại món, tên loại món.
            if (id == "")
            {
                errorProvider1.SetError(txtId, "Mã loại món không được để trống!");
                check = 2;
            }

            if (name == "") 
            {
                errorProvider1.SetError(txtName, "Tên Loại Món không được để trống!");
                check = 2;
            }


            if (check == 1 && loaiMoncs.fill() && loaiMoncs.isExist(id))
            {
                string insertSql = "insert into LoaiMon(MaLoaiMon, TenLoaiMon) values (@id, @name)";
                addRow(insertSql, id, name);
            }
            else MessageBox.Show("thêm thất bại");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát nếu có nhấn Yes không nhấn No", "Thông báo thoát",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
        }
    }
}
