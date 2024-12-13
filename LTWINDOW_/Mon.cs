using System;
using System.Drawing;

namespace LTWINDOW_
{
    internal class Mon
    {
        public string MaLoaiMon { get; set; }
        public string MaMon { get; set; }
        public string TenMon { get; set; }
        public double Gia { get; set; }
        public int SoLuong { get; set; }
        public byte[] Image { get; set; }

        // Constructor để khởi tạo một món ăn với các thông tin cần thiết
        public Mon(string maLoaiMon, string maMon, string tenMon, double gia, int soLuong, byte[] image)
        {
            MaLoaiMon = maLoaiMon;
            MaMon = maMon;
            TenMon = tenMon;
            Gia = gia;
            SoLuong = soLuong;
            Image = image;
        }

       
    }
}
