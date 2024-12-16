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

        private void btnThem_Click(object sender, EventArgs e)
        {
            Form addNhanVien = new AddNhanVien();
            addNhanVien.ShowDialog();
            loadData();
        }
    }
}
