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
    public partial class QuanLiBan : Form
    {
        public QuanLiBan()
        {
            
            InitializeComponent();
        }

        

        void loadData()
        {
            SQL sql = new SQL();

            using (SqlConnection connect = sql.Conn)
            {
                try
                {
                    connect.Open();
                    string query = @"select * from Ban";
                    // command.
                    SqlCommand command = new SqlCommand(query, connect);

                    // adapter.
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    // tạo dataTable rỗng để chứa  dữ liệu
                    DataTable table = new DataTable();

                    // đổ dữ liệu vào table.
                    adapter.Fill(table);

                    // hiển thị dữ liệu lên bảng.
                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                } 
                
            }

        }

        private void QuanLiBan_Load(object sender, EventArgs e)
        {
            
            loadData();
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // khởi tạo form thêm bàng.
            AddBan addBan = new AddBan();

            // thực thi xong form thêm bàn mới chạy câu lệnh tiếp theo.
            addBan.ShowDialog();

            // load lại datagrid view.
            loadData();

        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chác muốn xóa những hàng đã chọn không?", "Xóa Hàng Đã Chọn", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                // câu truy vấn.
                string query = "delete from Ban where MaBan = @MaBan";

                SQL sql = new SQL();

                
                int check = 0; // kiểm tra xem có xóa được dữ liệu chưa.

                using (SqlConnection connection = sql.Conn)
                {
                    try
                    {
                        connection.Open();

                        SqlCommand command = new SqlCommand(query, connection);

                        while(dataGridView1.SelectedRows.Count > 0)
                        {
                            DataGridViewRow row = dataGridView1.SelectedRows[0];

                            if (row.IsNewRow) continue;

                            var getValueColumnCurrent = dataGridView1.SelectedRows[0].Cells[0].Value;
                            int MaBan = int.Parse(getValueColumnCurrent.ToString());

                            // add parameter
                            command.Parameters.AddWithValue("@MaBan", MaBan);

                            // thực thi không tri vấn
                            command.ExecuteNonQuery();

                            command.Parameters.Clear();

                            // xóa hàng đầu tiên được chọn.
                            dataGridView1.Rows.Remove(row);
                        }    


                        // dã xóa dữ liệu.
                        check = 1; 
                    }
                    catch  (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    } 
                    
                }

               
                if (check == 1) loadData();  // nếu đã xóa thì load lại datagridView.
            }
            else MessageBox.Show("không có dòng nào để xóa");
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuaBan suaBan = new SuaBan();
            suaBan.ShowDialog();
            loadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // khởi tạo form thêm bàng.
            AddBan addBan = new AddBan();

            // thực thi xong form thêm bàn mới chạy câu lệnh tiếp theo.
            addBan.ShowDialog();

            // load lại datagrid view.
            loadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SuaBan suaBan = new SuaBan();
            suaBan.ShowDialog();
            loadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chác muốn xóa những hàng đã chọn không?", "Xóa Hàng Đã Chọn", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                // câu truy vấn.
                string query = "delete from Ban where MaBan = @MaBan";

                SQL sql = new SQL();


                int check = 1; // kiểm tra xem có xóa được dữ liệu chưa.

                using (SqlConnection connection = sql.Conn)
                {
                    try
                    {
                        connection.Open();

                        SqlCommand command = new SqlCommand(query, connection);

                        
                        while (dataGridView1.SelectedRows.Count > 0 )
                        {
                            DataGridViewRow row = dataGridView1.SelectedRows[0];

                            if (!row.IsNewRow)
                            {
                                var getValueColumnCurrent = dataGridView1.SelectedRows[0].Cells[0].Value;
                                int MaBan = int.Parse(getValueColumnCurrent.ToString());

                                // add parameter
                                command.Parameters.AddWithValue("@MaBan", MaBan);

                                // thực thi không tri vấn
                                command.ExecuteNonQuery();

                                command.Parameters.Clear();

                                // xóa hàng đầu tiên được chọn.
                                dataGridView1.Rows.Remove(row);
                            }
                            else
                            {
                                check = 0; // không có dòng nào được xóa
                                MessageBox.Show("khi xóa không nên chọn hàng mới \n(Hàng mới là Hàng Cuối cùng và không có bất kì thông tin nào)");
                                break;
                            } 
                                
                            
                        }
                    }
                    catch (SqlException ex)
                    {
                        check = 0; // không có dòng nào được xóa
                        MessageBox.Show(ex.Message);
                    }

                }


                if (check == 1) loadData();  // nếu đã xóa thì load lại datagridView.
                else MessageBox.Show("Xóa Thất Bại", "Xóa Hàng Của bảng");
            }
            else MessageBox.Show("không có dòng nào để xóa hoặc Bạn chưa chọn dòng cần xóa");
        }
    }
}
