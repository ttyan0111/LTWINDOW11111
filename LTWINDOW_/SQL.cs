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
       
        public List<ThongBao> GetThongBao()
        {
            List<ThongBao> thongBaos = new List<ThongBao>();

            // Ví dụ truy vấn SQL
            string query = "SELECT TieuDe, MoTa, Ngay FROM ThongBao ORDER BY Ngay DESC";

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
                                TieuDe = reader["TieuDe"].ToString(),
                                MoTa = reader["MoTa"].ToString(),
                                Ngay = Convert.ToDateTime(reader["Ngay"])
                            };
                            thongBaos.Add(tBao);
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

            return thongBaos;
        }
        public List<Mon> GetDanhSachMon()
        {
            List<Mon> danhSachMonList = new List<Mon>();

            string query = "SELECT * FROM DanhSachMon";

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
                                Convert.ToInt32(reader["SoLuong"]),
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
            string query = "INSERT INTO CHiTietDonHang (MaMon, SoLuongMon, TongPhu, MaDonHang) " +
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


    }
}




   
