using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters;
using System.IO;
using System.ComponentModel;
using System.Collections;
using System.Data.Common;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;

namespace LTWINDOW_
{
    internal class SQL
    {
        string connectionString = @"server=localhost;database=QuanLyQuanNuoc;integrated security=true";

        //string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuanLyQuanNuoc;Integrated Security=True;";
        private SqlDataAdapter adapter;
        private DataTable dt;
        private SqlConnection conn;
        public SQL()
        {
            conn = new SqlConnection(connectionString); 
            
        }

        // lấy chuỗi kết nối.
        public SqlConnection Conn { get { return conn; } }

        // Phương thức mở kết nối
        public void OpenConnection()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể kết nối đến SQL Server.\nLỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phương thức đóng kết nối
        public void CloseConnection()
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể đóng kết nối.\nLỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Phương thức thực thi câu lệnh SQL (INSERT, UPDATE, DELETE)
        public void ExecuteQuery(string query)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thực thi câu lệnh SQL.\nLỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Phương thức lấy dữ liệu từ cơ sở dữ liệu
        public DataTable GetOrderSummary()
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT 
                    CAST(NgayDatHang AS DATE) AS Ngay, 
                    SUM(TongTien) AS TongTien
                FROM DonHang
                GROUP BY CAST(NgayDatHang AS DATE)
                ORDER BY Ngay;
            ";

            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand(query, conn);
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy dữ liệu từ cơ sở dữ liệu.\nLỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        public List<ThongBao> GetThongBao(out int lastIndex)
        {
            List<ThongBao> thongBaos = new List<ThongBao>();
            lastIndex = 0; // Khởi tạo giá trị mặc định cho lastIndex

            // Ví dụ truy vấn SQL
            string query = "SELECT ID, TieuDe, MoTa, Ngay FROM ThongBao ORDER BY Ngay DESC";
            int max = -99999999;
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ThongBao tBao = new ThongBao
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                TieuDe = reader["TieuDe"].ToString(),
                                MoTa = reader["MoTa"].ToString(),
                                Ngay = Convert.ToDateTime(reader["Ngay"])
                            };
                            thongBaos.Add(tBao);
                            int stt = Convert.ToInt32(reader["ID"]);
                            if (max < stt)
                            {
                                max = stt;
                            }
                        }

                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy dữ liệu thông báo từ cơ sở dữ liệu.\nLỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                
                CloseConnection();
            }
            lastIndex = max;
            return thongBaos;
        }

        public List<Mon> GetDanhSachMon()
        {
            List<Mon> danhSachMonList = new List<Mon>();

            string query = "SELECT * FROM DanhSachMon Where TrangThai = 1";

            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           
                            Mon mon = new Mon
                            (
                                reader["MaLoaiMon"].ToString(),
                                reader["MaMon"].ToString(),
                                reader["TenMon"].ToString(),
                                Convert.ToDouble(reader["Gia"]),
                                reader["_Image"] as byte[]
                            );
                            danhSachMonList.Add(mon);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy dữ liệu món từ cơ sở dữ liệu.\nLỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }

            return danhSachMonList;
        }
        public List<LoaiMon> GetLoaiMon()
        {
            List<LoaiMon> loaiMons = new List<LoaiMon>();

            string query = "SELECT MaLoaiMon, TenLoaiMon FROM LoaiMon";

            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LoaiMon loaiMon = new LoaiMon
                            {
                                MaLoaiMon = reader["MaLoaiMon"].ToString(),
                                TenLoaiMon = reader["TenLoaiMon"].ToString()
                            };
                            loaiMons.Add(loaiMon);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy dữ liệu loại món từ cơ sở dữ liệu.\nLỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }

            return loaiMons;
        }
        public void LuuDonHang(string maDonHang,string maNhanVien, DateTime ngayDatHang, double tongTien)
        {
            string query = "INSERT INTO DonHang (MaDonHang, MaNhanVien, NgayDatHang, TongTien) " +
                           "VALUES (@MaDonHang, @MaNhanVien, @NgayDatHang, @TongTien)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDonHang", maDonHang);
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    cmd.Parameters.AddWithValue("@NgayDatHang", ngayDatHang);
                    cmd.Parameters.AddWithValue("@TongTien", tongTien);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void LuuChiTietDonHang(string maMon,int soLuong,double tongTien,string maDonHang)
        {
            string query = "INSERT INTO ChiTietDonHang (MaMon, SoLuongMon, TongPhu, MaDonHang) " +
                           "VALUES (@MaMon, @SoLuongMon, @TongPhu, @MaDonHang)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaMon", maMon);
                    cmd.Parameters.AddWithValue("@SoLuongMon", soLuong);
                    cmd.Parameters.AddWithValue("@TongPhu", tongTien);
                    cmd.Parameters.AddWithValue("@MaDonHang", maDonHang);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UpdateThongBao(List<ThongBao> list)
        {
            try
            {
                if (list == null || list.Count == 0)
                {
                    MessageBox.Show("Danh sách thông báo rỗng hoặc chưa được khởi tạo.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Khởi tạo DataTable mới và cấu hình các cột
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("ID", typeof(int));
                dataTable.Columns.Add("TieuDe", typeof(string));
                dataTable.Columns.Add("MoTa", typeof(string));
                dataTable.Columns.Add("Ngay", typeof(DateTime));

                // Duyệt qua danh sách và thêm vào DataTable
                foreach (ThongBao tb in list)
                {
                    DataRow row = dataTable.NewRow();
                    row["ID"] = tb.ID;
                    row["TieuDe"] = tb.TieuDe;
                    row["MoTa"] = tb.MoTa;
                    row["Ngay"] = tb.Ngay;
                    dataTable.Rows.Add(row);
                }

                // Thực hiện xóa toàn bộ dữ liệu trong bảng trước khi chèn
                OpenConnection();
                using (SqlCommand deleteCommand = new SqlCommand("DELETE FROM ThongBao", conn))
                {
                    deleteCommand.ExecuteNonQuery();
                }
                foreach (ThongBao tb in list)
                {
                    using (SqlCommand insertCommand = new SqlCommand("INSERT INTO ThongBao (ID, TieuDe, MoTa, Ngay) VALUES (@ID, @TieuDe, @MoTa, @Ngay)", conn))
                    {
                        // Gắn tham số cho câu lệnh SQL
                        insertCommand.Parameters.AddWithValue("@ID", tb.ID);
                        insertCommand.Parameters.AddWithValue("@TieuDe", tb.TieuDe);
                        insertCommand.Parameters.AddWithValue("@MoTa", tb.MoTa);
                        insertCommand.Parameters.AddWithValue("@Ngay", tb.Ngay);

                        // Thực thi câu lệnh INSERT
                        insertCommand.ExecuteNonQuery();
                    }
                }
                CloseConnection();
                MessageBox.Show("Cập nhật thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                CloseConnection();
                MessageBox.Show($"Lỗi khi cập nhật thông báo.\nLỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void DeleteThongBao(int ID)
        {
            // Câu lệnh SQL để xóa thông báo dựa trên ID
            string query = "DELETE FROM ThongBao WHERE ID = @ID";

            try
            {
                OpenConnection();

                // Tạo SqlCommand với câu lệnh SQL và kết nối
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Gắn giá trị cho tham số @ID
                    cmd.Parameters.AddWithValue("@ID", ID);

                    // Thực thi câu lệnh SQL
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Kiểm tra nếu không có dòng nào bị ảnh hưởng
                    if (rowsAffected == 0)
                    {
                        MessageBox.Show("Không tìm thấy thông báo với ID được cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thực thi câu lệnh SQL.\nLỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }
        }

    }
}




   
