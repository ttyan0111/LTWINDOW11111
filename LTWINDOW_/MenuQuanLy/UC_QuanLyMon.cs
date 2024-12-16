using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms.DataVisualization.Charting;

namespace LTWINDOW_.MenuQuanLy
{
    public partial class UC_QuanLyMon : UserControl
    {
        SQL sql;
        public UC_QuanLyMon()
        {
            InitializeComponent();
            loadData();
        }

        void loadData()
        {
            sql = new SQL();

            using (SqlConnection connection = sql.Conn)
            {
                try
                {
                    connection.Open(); // mở kết nối với sql.

                    // chuổi truy Vấn.
                    string query = "select * from LoaiMon";

                    SqlCommand command = new SqlCommand(query, connection);

                    //  tạo adapter để đọc toàn bộ dữ liệu.
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    // chứa dữ liệu.
                    DataTable dt = new DataTable();

                    // đổ dữ liệu vào dataSource.
                    adapter.Fill(dt);

                    // đổ dữ liệu lên datagridview.
                    dataGridView1.DataSource = dt;


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                } 
                
            }    
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThemLoaiMon themLoaiMon = new ThemLoaiMon();
            themLoaiMon.ShowDialog();
            loadData();
        }

        private void btnDelate_Click(object sender, EventArgs e)
        {
            

            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc muốn bỏ những món đã chọn khỏi quán không?", "Thông báo xác nhận",
                                    MessageBoxButtons.YesNo) == DialogResult.No) return;


                bool check = false;
                while (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dataGridView1.SelectedRows[0];

                    if (row.IsNewRow)
                    {
                        MessageBox.Show("Khi xóa không nên chọn hàng mới," +
                            "\nHàng mới là hàng cuối cùng và không có bất kì thông tin nào.", "thông báo chọn dòng");
                        break;
                    }
                        

                    string id = row.Cells[0].Value.ToString().Trim();
                    string strDelte = "update DanhSachMon set TrangThai = @TrangThai where MaLoaiMon = @id " +
                                       "\n update LoaiMon set TrangThai = @TrangThai where MaLoaiMon = @Id";

                    
                   

                    if (!ListLoaiMoncs.delete(strDelte, id))
                    {
                        return;
                    }
                    else
                    {
                        dataGridView1.Rows.Remove(row);
                        check = true;
                    }

                }

                if (check)
                {
                    loadData();
                    MessageBox.Show("đã dừng hoạt động của món đã chọn.");
                }
            }
            else MessageBox.Show("Bạn chưa chọn dòng nào!", "thông báo chưa chọn dòng");

            
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            Form fixLoaiMon = new FixLoaiMon();
            fixLoaiMon.ShowDialog();
            loadData();
        }
    }
}
