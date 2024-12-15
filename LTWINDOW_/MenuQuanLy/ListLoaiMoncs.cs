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

                        loaiMons.Add(new LoaiMon(strId, strName));
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

    }
}
