using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTWINDOW_
{
    internal class ThongBao
    {
        public string TieuDe { get; set; }
        public string MoTa { get; set; }
        public DateTime Ngay { get; set; }

        // Constructor để khởi tạo các thuộc tính
        public ThongBao(string tieuDe, string moTa, DateTime ngay)
        {
            TieuDe = tieuDe;
            MoTa = moTa;
            Ngay = ngay;
        }

        // Constructor mặc định (cần thiết khi sử dụng lớp mà không cần khởi tạo tất cả các thuộc tính)
        public ThongBao() { }
    }

}
