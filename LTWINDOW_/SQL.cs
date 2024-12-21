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
using Org.BouncyCastle.Asn1.Cmp;
using System.Xml.Linq;

namespace LTWINDOW_
{
    internal class SQL
    {
        string connectionString = @"server=localhost;database=QuanLyQuanNuoc_GDM;integrated security=true";

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
        public void LuuDonHang(string maDonHang, string maNhanVien, DateTime ngayDatHang, double tongTien)
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

        public void LuuChiTietDonHang(string maMon, int soLuong, double tongTien, string maDonHang)
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
        public List<string> GetMaLoaiMon()
        {
            // Tạo danh sách chứa kết quả
            List<string> maLoaiMonList = new List<string>();

            // Câu truy vấn SQL
            string query = "SELECT MaLoaiMon FROM LoaiMon";

            // Kết nối tới cơ sở dữ liệu
            using (conn = new SqlConnection(connectionString))
            {
                // Tạo đối tượng SqlCommand
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        // Mở kết nối
                        conn.Open();

                        // Thực thi câu lệnh và đọc dữ liệu
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read()) // Đọc từng dòng kết quả
                            {
                                string maLoaiMon = reader["MaLoaiMon"].ToString();
                                maLoaiMonList.Add(maLoaiMon);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Ghi log hoặc hiển thị thông báo lỗi
                        MessageBox.Show("Lỗi khi truy vấn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return maLoaiMonList; // Trả về danh sách MaLoaiMon
        }
        public void AddMonMoi(string maLoaiMon, string maMon, string tenMon, double gia, string pathImg = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Kiểm tra xem món đã tồn tại hay chưa
                    string checkQuery = "SELECT TrangThai FROM DanhSachMon WHERE MaMon = @MaMon";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@MaMon", maMon);

                        object result = checkCmd.ExecuteScalar();

                        if (result != null) // Nếu mã món tồn tại
                        {
                            int trangThai = Convert.ToInt32(result);

                            if (trangThai == 0) // Nếu TrangThai đang là 0, cập nhật về 1
                            {
                                string updateQuery = "UPDATE DanhSachMon SET TrangThai = 1, TenMon = @TenMon, Gia = @Gia, _Image = @Image WHERE MaMon = @MaMon";
                                using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                                {
                                    updateCmd.Parameters.AddWithValue("@MaMon", maMon);
                                    updateCmd.Parameters.AddWithValue("@TenMon", tenMon);
                                    updateCmd.Parameters.AddWithValue("@Gia", gia);

                                    // Xử lý ảnh
                                    if (string.IsNullOrWhiteSpace(pathImg))
                                    {
                                        updateCmd.Parameters.AddWithValue("@Image", DBNull.Value);
                                    }
                                    else
                                    {
                                        byte[] imageBytes = File.ReadAllBytes(pathImg);
                                        updateCmd.Parameters.AddWithValue("@Image", imageBytes);
                                    }

                                    updateCmd.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Mã món đã tồn tại và đang ở trạng thái kích hoạt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else // Nếu mã món chưa tồn tại, thực hiện thêm mới
                        {
                            string insertQuery = "INSERT INTO DanhSachMon (MaLoaiMon, MaMon, TenMon, Gia, _Image, TrangThai) VALUES (@MaLoaiMon, @MaMon, @TenMon, @Gia, @Image, 1)";
                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@MaLoaiMon", maLoaiMon);
                                insertCmd.Parameters.AddWithValue("@MaMon", maMon);
                                insertCmd.Parameters.AddWithValue("@TenMon", tenMon);
                                insertCmd.Parameters.AddWithValue("@Gia", gia);

                                // Xử lý ảnh
                                if (string.IsNullOrWhiteSpace(pathImg))
                                {
                                    insertCmd.Parameters.AddWithValue("@Image", DBNull.Value);
                                }
                                else
                                {
                                    byte[] imageBytes = File.ReadAllBytes(pathImg);
                                    insertCmd.Parameters.AddWithValue("@Image", imageBytes);
                                }

                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xử lý món: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void DeleteMon(string maMon)
        {
            string query = "UPDATE DanhSachMon SET TrangThai = 0 WHERE MaMon = @MaMon";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Thêm tham số cho câu truy vấn
                    cmd.Parameters.AddWithValue("@MaMon", maMon);

                    // Mở kết nối
                    conn.Open();

                    // Thực thi truy vấn
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UpdateMon(string maMon, string maLoaiMon, string tenMon, double gia, Image image)
        {
            // Truy vấn SQL với điều kiện cập nhật các cột tương ứng
            string query = @"
        UPDATE DanhSachMon 
        SET MaLoaiMon = @MaLoaiMon, 
            TenMon = @TenMon, 
            Gia = @Gia, 
            _Image = @Image
        WHERE MaMon = @MaMon";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Thêm tham số cho câu truy vấn
                    cmd.Parameters.AddWithValue("@MaMon", maMon);
                    cmd.Parameters.AddWithValue("@MaLoaiMon", maLoaiMon);
                    cmd.Parameters.AddWithValue("@TenMon", tenMon);
                    cmd.Parameters.AddWithValue("@Gia", gia);

                    // Chuyển đổi ảnh thành mảng byte (hoặc null nếu không có ảnh)
                    byte[] imageBytes = image != null ? ConvertImageToBytes(image) : null;
                    cmd.Parameters.AddWithValue("@Image", (object)imageBytes ?? DBNull.Value);


                    // Mở kết nối
                    conn.Open();

                    // Thực thi truy vấn
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public byte[] ConvertImageToBytes(Image img)
        {
            if (img == null)
                return null;

            using (MemoryStream ms = new MemoryStream())
            {
                // Chuyển đổi hình ảnh thành mảng byte
                img.Save(ms, img.RawFormat);
                return ms.ToArray(); // Trả về mảng byte
            }
        }

    }
}





