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
using System.Management;
using System.Collections;

namespace LTWINDOW_.MenuQuanLy
{
    public partial class QuanLyDoanhThu : UserControl
    {
        SQL sql;
        SqlConnection connection;
        SqlCommand command;
        public QuanLyDoanhThu()
        {
            InitializeComponent();
        }

        void pushDataInNameNhanVien(string queryIdEmployee, int id, int indexRow)
        {
            sql = new SQL();
            
            using(connection = sql.Conn)
            {
                try
                {
                    connection.Open();

                    command = new SqlCommand(queryIdEmployee, connection);
                    command.Parameters.AddWithValue("@id", id);
                    
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        dataGridView1.Rows[indexRow].Cells["employeeName"].Value = reader["TenNhanVien"].ToString();
                    } 
                        
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + $"\nlỗi khi lấy tên dòng {indexRow}");
                } 
                
            } 
            
        }

        void loadData(string query)
        {
            sql = new SQL();
            using(connection = sql.Conn)
            {
                try
                {
                    // mở kết nối
                    connection.Open();

                    command = new SqlCommand(query, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    dataGridView1.Rows.Clear();
                    while (reader.Read())
                    {
                        int rowIndex =  dataGridView1.Rows.Add(); // tạo dòng mới.

                        // thêm dữ liệu vào dòng mới.
                        dataGridView1.Rows[rowIndex].Cells["idOrder"].Value = reader["MaDonHang"].ToString();
                        dataGridView1.Rows[rowIndex].Cells["idEmployee"].Value = reader["MaNhanVien"].ToString();
                        int idNhanVien;
                        if (int.TryParse(reader["MaNhanVien"].ToString(), out idNhanVien))
                        {
                            pushDataInNameNhanVien("select TenNhanVien from NhanVien where MaNhanVien = @id", idNhanVien, rowIndex);
                        }    
                        dataGridView1.Rows[rowIndex].Cells["sumMoney"].Value = reader["TongTien"].ToString();
                        dataGridView1.Rows[rowIndex].Cells["dateOrder"].Value = reader["NgayDatHang"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                } 
            }

            

        }
        private void QuanLyDoanhThu_Load(object sender, EventArgs e)
        {
            loadData("select MaDonHang, TongTien, MaNhanVien, format(NgayDatHang, 'dd/MM/yyyy') as NgayDatHang from DonHang");
        }

        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // ngày bắt đầu phả lớn hơn ngày kết thúc.

            if (dtptuNgay.Value <= dtpdenNgay.Value)
            {
                // truy vấn.
                DateTime sdt = dtptuNgay.Value;
                string starDate = sdt.ToString("yyyy/MM/dd");
                sdt = dtpdenNgay.Value;
                string enDate = sdt.ToString("yyyy/MM/dd");

                string queryDate = "select MaDonHang, TongTien, MaNhanVien, format(NgayDatHang, 'dd/MM/yyyy') as NgayDatHang " +
                    "from DonHang " +
                    $"where NgayDatHang between '{starDate}' and '{enDate}'";
                loadData(queryDate);
            }
            else
            {
                MessageBox.Show("Ngày Bắt đầu phải lớn hơn hoặc bằng ngày kết thức", "Thông Báo Chọn Ngày");
            }

            

            
        }
    }
}
