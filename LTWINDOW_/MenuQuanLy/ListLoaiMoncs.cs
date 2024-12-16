using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace LTWINDOW_.MenuQuanLy
{
    internal class ListLoaiMoncs
    {
        List<LoaiMon> loaiMons;

        public ListLoaiMoncs()
        {
            loaiMons = new List<LoaiMon>();  
        }
        
        public List<LoaiMon> GetLoaiMons() { return loaiMons; }

        // đẩy dữ liệu loại món trong sql vào list loại món.
        public bool fill()
        {
            SQL sql = new SQL();

            using(SqlConnection connection = sql.Conn)
            {
                try
                {
                    connection.Open();

                    // chuổi truy vấn.
                    string query = "select * from LoaiMon";

                    // 
                    SqlCommand cmd = new SqlCommand(query, connection);

                    // đọc từng dòng.
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string strId = reader.GetString(0);
                        string strName = reader.GetString(1);
                        bool strStatus = reader.GetBoolean(2);

                        loaiMons.Add(new LoaiMon(strId, strName, strStatus));
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                } 
                
            }    
        }

        public bool isExist(string id)
        {
            bool check = true;
            foreach (LoaiMon loaiMon in loaiMons)
            {
                if (loaiMon.getId().Trim() == id)
                {
                    MessageBox.Show("Mã Đã tồn tại không thể thêm!");
                    check = false;
                    break;
                }
            }

            return check;
        }

        
        public static bool delete(string strDelete, string id)
        {
            SQL sQL = new SQL();

            using (SqlConnection connection = sQL.Conn)
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(strDelete, connection);
                    command.Parameters.AddWithValue("@TrangThai", 0);
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message + "\nThất bại.", "Thông Báo Dừng hoạt động món");
                    return false;
                }
            }
        }

       
        public static List<LoaiMon> getLoaiMonList(string query)
        {
            SQL sQL = new SQL();
            
            List<LoaiMon> loaiMonList = new List<LoaiMon>();
            using(SqlConnection connection = sQL.Conn)
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string code = reader.GetString(0);
                        string name = reader.GetString(1);
                        bool status = reader.GetBoolean(2);
                        loaiMonList.Add(new LoaiMon(code, name, status));
                    } 
                        
                    return loaiMonList;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\nLỗi kết nối sql.");
                    return loaiMonList;
                } 
                
            } 
                
        }

        // update
        public static bool update(string strUpdate, string name, bool status, string id)
        {
            SQL sQL = new SQL();

            using(SqlConnection connection = sQL.Conn)
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(strUpdate, connection);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@status", status);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                } 
                
            } 
                
        }
    }
}
