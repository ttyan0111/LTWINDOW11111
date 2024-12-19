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
using iTextSharp.text.pdf.codec;

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

        string[] getDate_S_E()
        {
            string[] dateSAndE = new string[3];
            DateTime sdt = dtptuNgay.Value;
            dateSAndE[0] = sdt.ToString("yyyy/MM/dd");
            sdt = dtpdenNgay.Value;
            dateSAndE[1] = sdt.ToString("yyyy/MM/dd");

            return dateSAndE;
        }
        private void QuanLyDoanhThu_Load(object sender, EventArgs e)
        {
            string[] date_s_e = getDate_S_E();
            loadData("select MaDonHang, TongTien, MaNhanVien, format(NgayDatHang, 'dd/MM/yyyy') as NgayDatHang " +
                    "from DonHang " +
                    $"where NgayDatHang between '{date_s_e[0]}' and '{date_s_e[1]}'");
        }

        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // ngày bắt đầu phả lớn hơn ngày kết thúc.

            if (dtptuNgay.Value <= dtpdenNgay.Value)
            {

                // truy vấn.
                string[] date_s_e = getDate_S_E();

                string queryDate = "select MaDonHang, TongTien, MaNhanVien, format(NgayDatHang, 'dd/MM/yyyy') as NgayDatHang " +
                    "from DonHang " +
                    $"where NgayDatHang between '{date_s_e[0]}' and '{date_s_e[1]}'";
                loadData(queryDate);
            }
            else
            {
                MessageBox.Show("Ngày Bắt đầu phải nhỏ hơn hoặc bằng ngày kết thức", "Thông Báo Chọn Ngày");
            }

            

            
        }


        // xóa dữ liệu đơn hàng trong sql.
        bool deleteDonHang(string strDeleteDonHang, string strDeleteChiTietDonHang_LQ, string idDonHang)
        {
            sql = new SQL();
            string delteteDonhHangSql = $"{strDeleteChiTietDonHang_LQ}\n\n{strDeleteDonHang}";
            using (connection = sql.Conn)
            {
                try
                {
                    if(connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                        
                    }

                    
                    SqlCommand command = new SqlCommand(delteteDonhHangSql, connection);

                    command.Parameters.AddWithValue("@idDonHang", idDonHang);
                    
                    command.ExecuteNonQuery();

                    MessageBox.Show("check");

                    return true; // đã xóa thành công.
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false; // xóa không thành công.
                } 
                
            } 
                
        }
        private void btnFix_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                // thông báo có chắc chắc xóa.
                if (MessageBox.Show("Bạn có chắc chắc xóa những dòng đã chọn!\nDòng mới là dòng cuối cùng và không có bất kì thông tin nào.", "Thông Báo Xác Nhận xóa Dòng Chọn",
                    MessageBoxButtons.YesNo) == DialogResult.No) return; 

                string strdeleteDonHang = "delete DonHang  where MaDonHang = @idDonHang";
                string strdeleteChiTietDonHang = "delete ChitietDonHang where MaDonHang = @idDonHang";

                bool check = false; // check có dòng nào xóa không;
                while(dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dataGridView1.SelectedRows[0];
                    // xử lý khi có chọn dòng mới
                    if (row.IsNewRow)
                    {
                        MessageBox.Show("khi Xóa không nên chọn dòng mới", "Thông báo khi chọn dòng mới");
                        break;
                    } 

                    string idDonHang = row.Cells["idOrder"].Value.ToString();
                    if(deleteDonHang(strdeleteDonHang, strdeleteChiTietDonHang, idDonHang))
                    {
                        check = true;
                    }
                    else
                    {
                        MessageBox.Show($"Xóa Dòng có mã Đơn {idDonHang} thất bại", "Thông Báo Xóa Dòng");
                    } 
                    dataGridView1.Rows.Remove(row);
                        
                }

                if (check) MessageBox.Show("Thành công", "Thông Báo Xóa dòng");
                else MessageBox.Show("Thất bại", "Thông Báo Xóa dòng");
                string[] date_s_e = getDate_S_E();

                string queryDate = "select MaDonHang, TongTien, MaNhanVien, format(NgayDatHang, 'dd/MM/yyyy') as NgayDatHang " +
                    "from DonHang " +
                    $"where NgayDatHang between '{date_s_e[0]}' and '{date_s_e[1]}'";
                loadData(queryDate);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dòng để xóa", "Thông Báo Chọn Dòng");
            } 
                
                
        }
    }
}
