using Org.BouncyCastle.Bcpg.OpenPgp;
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
using System.Web.UI.WebControls;

namespace LTWINDOW_.MenuQuanLy
{
    public partial class QuanLyNhanVien : UserControl
    {
        SQL sql;
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }
        void loadData()
        {
            sql = new SQL();
            string query = "select * from NhanVien";
            using(SqlConnection connection = sql.Conn)
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(query, connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message + "\nLỗi");
                }
            }    


        }
        private void QuanLyAccount_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form addNhanVien = new AddNhanVien();
            addNhanVien.ShowDialog();
            loadData();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //khai báo form.
            Form fixNhanVien = new FixNhanVien();

            // hiển thị form.
            fixNhanVien.ShowDialog();

            // tải lại data lên gridView
            loadData();
        }

        bool discontinedNhanVien(string query, int id)
        {
            sql = new SQL();

            using(SqlConnection connection = sql.Conn)
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@status", 0);
                    command.ExecuteNonQuery();
                    return true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                } 
                
            }    
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc muốn dừng hoạt động của những nhân viên đã chọn?\nNếu có chọn Yes không chọn No",
                    "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No) return;

                // check có dòng nào thay đổi không.
                bool check = false;

                string strDiscontinued = "update NhanVien set trangThaiHoatDong = @status where MaNhanVien = @id";
                while (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dataGridView1.SelectedRows[0];

                    if (row.IsNewRow)
                    {
                        MessageBox.Show("không nên chọn dòng mới, dòng mới là dòng cuối cùng và không có bất kì thông nào", "thông báo không chọn dòng mới");
                        break;
                    }

                    if (row.Cells[5].Value.ToString() == "False")
                    {
                        dataGridView1.Rows.Remove(row);
                        check = true;
                        continue;
                    }

                    int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

                    if (discontinedNhanVien(strDiscontinued, id))
                    {
                        check = true;
                        dataGridView1.Rows.Remove(row);
                    }
                    else break;

                }

                if (check)
                {
                    MessageBox.Show("Thành công", "thông báo dừng hoạt động của nhân viên");
                    loadData();
                }
                else MessageBox.Show("Thất bại", "thông báo dừng hoạt động của nhân viên");

            }
            else
            {
                MessageBox.Show("bạn chưa chọn dòng nào", "Thông Báo Chọn Dòng");
            }
        }

        

        

        
    }
}
