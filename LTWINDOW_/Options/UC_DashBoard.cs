using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LTWINDOW_.Options
{
    public partial class UC_DashBoard : UserControl
    {
        SQL sql;
        int index;
        List<ThongBao> tBao;
        public UC_DashBoard()
        {
           
            InitializeComponent();
            tBao = new List<ThongBao>();
            sql = new SQL();
            sql.OpenConnection();
            LoadRevenueChart();
            uC_BangDangXuat1.Visible = false;
            LoadThongBao();
        }

        private void LoadRevenueChart()
        {
            DataTable data = sql.GetOrderSummary();

            // Cấu hình biểu đồ
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.Title = "Ngày";
            chart1.ChartAreas[0].AxisY.Title = "Tổng Tiền";

            // Thay đổi kích thước chữ của trục X và trục Y
            chart1.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);
            chart1.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 12, FontStyle.Bold);

            // Thay đổi kích thước chữ của nhãn trên trục
            chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 10);
            chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 10);

            // Thay đổi kích thước chữ của tiêu đề biểu đồ
            chart1.Titles.Clear();
            chart1.Titles.Add("Biểu đồ doanh thu");
            chart1.Titles[0].Font = new Font("Arial", 18, FontStyle.Bold);


            // Tạo series
            Series series = new Series
            {
                Name = "Doanh Thu Quán",
               
                ChartType = SeriesChartType.StackedBar, // Dạng cột
                XValueType = ChartValueType.Date
            };


            chart1.Series.Add(series);

            // Thêm dữ liệu vào series
            foreach (DataRow row in data.Rows)
            {
                DateTime ngay = Convert.ToDateTime(row["Ngay"]);
                double tongTien = Convert.ToDouble(row["TongTien"]);
                series.Points.AddXY(ngay, tongTien);
            }

            // Thay đổi kích thước chữ của chú thích (Legend)
            if (chart1.Legends.Count > 0)
            {
                chart1.Legends[0].Font = new Font("Arial", 12);
            }
        }

        public void SetTenNhanVien(string tenNhanVien)
        {
            labelTenNhanVien.Text = tenNhanVien;
        }
       

        private void LoadThongBao()
        {
            tBao.Clear();
            tBao = sql.GetThongBao(out this.index);
            int thongBaoIndex = 0;
            panelButton.BackColor = Color.FromArgb(255, 192, 255);// Đặt màu nền
            panelButton.FlowDirection = FlowDirection.TopDown; // Sắp xếp theo chiều dọc
            panelButton.AutoScroll = true; // Bật thanh cuộn dọc
            panelButton.WrapContents = false; // Không cho phép cuộn ngang
            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
            foreach (ThongBao thongBao in tBao)
            {
                thongBaoIndex++;
               
                // Tạo Panel để chứa PictureBox và Label
                Panel container = new Panel
                {
                    Width = panelButton.ClientSize.Width - 20, // Chiều rộng container
                    Height = 70, // Chiều cao container
                    BackColor = Color.White,

                    Margin = new Padding(5) // Khoảng cách giữa các container
                };

                // Tạo PictureBox
                PictureBox pictureBox = new PictureBox
                {
                    Width = 30,
                    Height = 30,
                    Image = Properties.Resources.chuong, // Thay cho đường dẫn chuông
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(10, 10) // Căn lề trái
                };


                // Tạo Label
                Label lbl = new Label
                {
                    Text = $"{thongBao.TieuDe} - {thongBao.Ngay:dd/MM/yyyy}",
                    Width = container.Width - pictureBox.Width - 20, // Trừ khoảng cách của PictureBox
                    Height = 50,
                    Location = new Point(pictureBox.Right + 10, 10), // Đặt Label bên cạnh PictureBox
                    BackColor = Color.White,
                    Padding = new Padding(5),
                    Font = new Font("Arial", 14F, FontStyle.Bold),
                    Tag = thongBao // Gán dữ liệu vào Tag để sử dụng khi cần
                };

                // Thêm sự kiện MouseEnter để hiển thị chi tiết
                lbl.MouseEnter += (sender, e) =>
                {
                    Label hoveredLabel = (Label)sender;
                    ThongBao data = (ThongBao)hoveredLabel.Tag;

                    // Thiết lập font cho ToolTip
                    Font font = new Font("Arial", 15F); // Chọn font và kích thước bạn muốn

                    // Hiển thị mô tả đầy đủ trong ToolTip
                    toolTip.SetToolTip(hoveredLabel, data.MoTa);

                    // Thay đổi font của Label khi di chuột vào
                    hoveredLabel.Text = $"{data.TieuDe}: {data.MoTa}";
                    hoveredLabel.Font = new Font("Arial", 12F, FontStyle.Italic);
                };

                // Thêm sự kiện MouseLeave để trả lại trạng thái ban đầu
                lbl.MouseLeave += (sender, e) =>
                {
                    Label hoveredLabel = (Label)sender;
                    ThongBao data = (ThongBao)hoveredLabel.Tag;

                    // Hiển thị lại nội dung ban đầu
                    hoveredLabel.Text = $"{data.TieuDe} - {data.Ngay:dd/MM/yyyy}";
                    hoveredLabel.Font = new Font("Arial", 14F, FontStyle.Bold);
                };



                // Thêm PictureBox và Label vào container
                container.Controls.Add(pictureBox);
                container.Controls.Add(lbl);
                if (thongBaoIndex <= 3)
                {
                    PictureBox pictureBoxHot = new PictureBox
                    {
                        Width = 40,
                        Height = 40,
                        Image = Properties.Resources.hot, // Sử dụng từ Resources
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Location = new Point(container.ClientSize.Width - 40, 10) // Đảm bảo nằm trong container
                    };

                    container.Controls.Add(pictureBoxHot);
                    container.Controls.SetChildIndex(pictureBoxHot, 0); // Đưa PictureBoxHot lên trên
                }
                // Thêm container vào panelButton
                panelButton.Controls.Add(container);
            }
        }
        private bool isVisible = false;
        private void acount_Click(object sender, EventArgs e)
        {
            if (!isVisible)
            {
                uC_BangDangXuat1.Visible = true;
                isVisible = true;
            }
            else
            {
                uC_BangDangXuat1.Visible = false;
                isVisible = false;
            }
            
        }
        public void LoadDuLieuAll()
        {
            panelButton.Controls.Clear();
            LoadRevenueChart();
            LoadThongBao();

        }
    }
}
