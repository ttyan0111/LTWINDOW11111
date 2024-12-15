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
    }
}
