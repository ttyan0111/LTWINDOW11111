using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTWINDOW_.Options
{
    public partial class ThanhToan : Form
    {
        SQL sql;
        public List<KeyValuePair<string, int>> ds { get; set; }

        public ThanhToan(List<KeyValuePair<string, int>> ds)
        {
            InitializeComponent();
            this.ds = ds ?? new List<KeyValuePair<string, int>>(); // Gán danh sách
            sql = new SQL(); // Khởi tạo SQL nếu cần
            HienThiThongTin(); // Hiển thị thông tin khi mở form
        }
        public void HienThiThongTin()
        {
            // Xóa dữ liệu cũ trong Panel không tương tác
            panelHienThi.Controls.Clear();

            // Tạo TableLayoutPanel để căn chỉnh các cột
            TableLayoutPanel table = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 4, // 4 cột: Tên món, Số lượng, Giá Đơn, Tổng Giá
                RowCount = ds.Count + 2, // Số dòng là số món ăn + 1 cho tiêu đề + 1 cho tổng tiền
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
            };

            // Thiết lập độ rộng các cột
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40f)); // Tên món
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f)); // Số lượng
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f)); // Giá đơn
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f)); // Tổng giá

            // Tạo tiêu đề cho các cột
            table.Controls.Add(new Label { Text = "Tên món", Font = new Font("Arial", 12, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter, AutoSize = true }, 0, 0);
            table.Controls.Add(new Label { Text = "SL", Font = new Font("Arial", 12, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter, AutoSize = true }, 1, 0);
            table.Controls.Add(new Label { Text = "Giá Đơn", Font = new Font("Arial", 12, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter, AutoSize = true }, 2, 0);
            table.Controls.Add(new Label { Text = "Tổng Giá", Font = new Font("Arial", 12, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter, AutoSize = true }, 3, 0);

            double grandTotal = 0; // Tổng tiền cho tất cả các món

            // Duyệt qua danh sách món đã chọn
            int row = 1; // Dòng bắt đầu từ 1, vì dòng 0 là tiêu đề
            foreach (var item in ds)
            {
                string tenMon = item.Key;
                int soLuong = item.Value;

                // Lấy thông tin món từ cơ sở dữ liệu
                Mon mon = sql.GetDanhSachMon().FirstOrDefault(m => m.TenMon == tenMon);
                if (mon == null) continue;

                // Tính giá tổng
                double total = mon.Gia * soLuong;
                grandTotal += total; // Cộng tổng tiền vào grandTotal

                // Tạo Label cho Tên Món với khả năng xuống dòng
                Label tenMonLabel = new Label
                {
                    Text = tenMon,
                    Font = new Font("Arial", 12, FontStyle.Regular),
                    TextAlign = ContentAlignment.MiddleLeft,
                    AutoSize = true,
                    MaximumSize = new Size(0, 0), // Cho phép Label tự động mở rộng khi cần
                };

                // Thêm thông tin vào TableLayoutPanel
                table.Controls.Add(tenMonLabel, 0, row);
                table.Controls.Add(new Label { Text = soLuong.ToString(), Font = new Font("Arial", 12, FontStyle.Regular), TextAlign = ContentAlignment.MiddleCenter }, 1, row);
                table.Controls.Add(new Label { Text = mon.Gia.ToString("N0") + " đ", Font = new Font("Arial", 12, FontStyle.Regular), TextAlign = ContentAlignment.MiddleRight }, 2, row);
                table.Controls.Add(new Label { Text = total.ToString("N0") + " đ", Font = new Font("Arial", 12, FontStyle.Regular), TextAlign = ContentAlignment.MiddleRight }, 3, row);

                row++;
            }

            // Thêm dòng tổng tiền
            table.Controls.Add(new Label { Text = "Tổng Cộng", Font = new Font("Arial", 12, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter, AutoSize = true }, 0, row);
            table.Controls.Add(new Label { Text = "", Font = new Font("Arial", 12, FontStyle.Regular), TextAlign = ContentAlignment.MiddleCenter }, 1, row); // Ô trống cho SL
            table.Controls.Add(new Label { Text = "", Font = new Font("Arial", 12, FontStyle.Regular), TextAlign = ContentAlignment.MiddleCenter }, 2, row); // Ô trống cho Giá Đơn
            table.Controls.Add(new Label { Text = grandTotal.ToString("N0") + " đ", Font = new Font("Arial", 12, FontStyle.Bold), TextAlign = ContentAlignment.MiddleRight }, 3, row); // Hiển thị tổng tiền

            // Thêm TableLayoutPanel vào Panel cha
            panelHienThi.Controls.Add(table);
        }




    }


}
