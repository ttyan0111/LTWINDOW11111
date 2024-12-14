using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace LTWINDOW_.Options
{
    public partial class UC_Menu : UserControl
    {
        double totalPrice = 0;
        SQL sql;
        List<KeyValuePair<string, int>> ds;

        private Dictionary<string, Label> quantityLabels = new Dictionary<string, Label>();
        public UC_Menu()
        {
            InitializeComponent();
           
            sql = new SQL();
            panelHienThiHoaDon.AutoScroll = true; // Bật thanh cuộn dọc
            ds = new List<KeyValuePair<string, int>>();
            LoadDanhSachMon();
            LoadLoaiMonComboBox();
            richTextBoxTenMon.KeyDown += richTextBoxTenMon_KeyDown;
          

        }
        public void LoadDanhSachMon(List<Mon> danhSachMonList= null)
        {
            panelDanhSachMon.Controls.Clear();
            panelDanhSachMon.AutoScroll = true; // Bật thanh cuộn dọc
            if(danhSachMonList == null)
            {
                danhSachMonList = sql.GetDanhSachMon();
            }
            Image image;
            foreach (var mon in danhSachMonList)
            {
                if (mon.Image != null)
                {
                    image = ConvertBytesToImage(mon.Image);
                }
                else image = Properties.Resources.trừ;

                // Tạo PictureBox
                PictureBox pictureBox = new PictureBox
                {
                    Image = image,
                    SizeMode = PictureBoxSizeMode.Zoom, // Zoom để vừa hình ảnh vào PictureBox
                    Size = new Size(250, 300) // Kích thước hình ảnh
                };


                // Thêm sự kiện Click cho PictureBox
                pictureBox.Click += (sender, e) =>
                {
                    // Xử lý logic khi nhấp vào hình ảnh
                    HienThiMonTrenHoaDon(mon); // Hàm xử lý hiển thị trên panelHienThiHoaDon
                };


                // Tạo Label dưới PictureBox
                Label label = new Label
                {
                    Text = mon.TenMon, // Tên món
                    AutoSize = true, // Tự động điều chỉnh kích thước văn bản
                   
                    Font = new Font("Arial", 16, FontStyle.Bold), // Font chữ và cỡ chữ
                    ForeColor = Color.Purple,
                    Height = 40 // Chiều cao mặc định cho Label
                };

                // Tạo Label dưới PictureBox cho giá
                Label priceLabel = new Label
                {
                    Text = string.Format("{0:N0} đ", mon.Gia), // Hiển thị dạng 20,000 đ thay vì 20.000,00 đ
                    AutoSize = true, // Tự động điều chỉnh kích thước văn bản
                    TextAlign = ContentAlignment.MiddleCenter, // Căn giữa văn bản
                    Font = new Font("Arial", 14, FontStyle.Regular), // Font chữ và cỡ chữ cho giá tiền
                    ForeColor = Color.Black,
                    Height = 20 // Chiều cao cố định cho label giá tiền
                };
                
                // Tính chiều rộng của văn bản
                int textWidth = TextRenderer.MeasureText(label.Text, label.Font).Width;

                // Tính vị trí X cho Label để nó nằm giữa ảnh
                int xPosition = pictureBox.Width/2 - textWidth / 2;

                // Đặt Label vào đúng vị trí
                
                // Đặt PictureBox và Label vào Panel
                Panel monPanel = new Panel
                {
                    Width = pictureBox.Width,
                    Height = pictureBox.Height + label.Height // Kết hợp kích thước PictureBox và Label
                };
                label.Location = new Point(xPosition - 10, pictureBox.Height); // Label dưới cùng của PictureBox
                int priceTextWidth = TextRenderer.MeasureText(priceLabel.Text, priceLabel.Font).Width;

                // Đặt vị trí của giá tiền để căn giữa
                int priceXPosition = (pictureBox.Width - priceTextWidth) / 2;

                priceLabel.Location = new Point(priceXPosition, label.Bottom); // Căn giữa theo chiều ngang và đặt ngay dưới tên món

                monPanel.Controls.Add(pictureBox);
                monPanel.Controls.Add(label);
                monPanel.Controls.Add(priceLabel);
                panelDanhSachMon.Controls.Add(monPanel);


            }
        }


       
        public Image ConvertBytesToImage(byte[] imageData)
        {
            if (imageData == null)
            {
                return null;
            }

            try
            {
                using (var ms = new MemoryStream(imageData))
                {
                    return Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                // Lỗi khi chuyển đổi từ mảng byte sang hình ảnh
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
        }



        private void HienThiMonTrenHoaDon(Mon mon)
        {
            int index = ds.FindIndex(item => item.Key == mon.TenMon);

            if (index != -1)
            {
                // Cập nhật số lượng món trong danh sách
                var existingItem = ds[index];
                ds[index] = new KeyValuePair<string, int>(existingItem.Key, existingItem.Value + 1);
                totalPrice += mon.Gia;
                labelTien.Text = string.Format("{0:N0} đ", totalPrice);

                // Cập nhật giao diện số lượng món
                if (quantityLabels.ContainsKey(mon.TenMon))
                {
                    quantityLabels[mon.TenMon].Text = $"Số lượng: {ds[index].Value}";
                }
            }
            else
            {
                // Thêm món mới vào danh sách
                ds.Add(new KeyValuePair<string, int>(mon.TenMon, 1));
                totalPrice += mon.Gia;
                labelTien.Text = string.Format("{0:N0} đ", totalPrice);

                // Tạo panel con để chứa các controls của món
                Panel itemPanel = new Panel
                {
                    AutoSize = true,
                    BorderStyle = BorderStyle.None ,// Loại bỏ viền
                    BackColor = Color.White // Màu nền của panel

                };

                // Tạo và cấu hình các controls
                Label nameLabel = new Label
                {
                    Text = $"Tên món: {mon.TenMon}",
                    AutoSize = true,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    ForeColor = Color.Black,
                    Location = new Point(10, 10)
                };

                Button closeButton = new Button
                {
                    Text = "X",
                    Size = new Size(30, 30),
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    BackColor = Color.Red,
                    ForeColor = Color.White,
                    Location = new Point(panelHienThiHoaDon.Width - 50, 10)
                };

                Label priceLabel = new Label
                {
                    Text = $"Giá: {mon.Gia:N0} đ",
                    AutoSize = true,
                    Font = new Font("Arial", 12, FontStyle.Regular),
                    ForeColor = Color.Black,
                    Location = new Point(10, nameLabel.Bottom + 5)
                };

                Label quantityLabel = new Label
                {
                    Text = $"Số lượng: 1",
                    AutoSize = true,
                    Font = new Font("Arial", 12, FontStyle.Regular),
                    ForeColor = Color.Black,
                    Location = new Point(10, priceLabel.Bottom + 5)
                };

                Button decreaseButton = new Button
                {
                    Text = "-",
                    Size = new Size(30, 30),
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    BackColor = Color.LightGray,
                    ForeColor = Color.Black,
                    Location = new Point(150, priceLabel.Bottom + 2)
                };

                Button increaseButton = new Button
                {
                    Text = "+",
                    Size = new Size(30, 30),
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    BackColor = Color.LightGray,
                    ForeColor = Color.Black,
                    Location = new Point(190, priceLabel.Bottom + 2)
                };

                // Lưu label số lượng vào dictionary
                quantityLabels[mon.TenMon] = quantityLabel;

                // Gắn sự kiện cho nút xóa
                closeButton.Click += (s, e) =>
                {
                    // Xóa khỏi danh sách
                    var currentIndex = ds.FindIndex(item => item.Key == mon.TenMon);
                    totalPrice -= mon.Gia * ds[currentIndex].Value;
                    labelTien.Text = string.Format("{0:N0} đ", totalPrice);
                    ds.RemoveAll(item => item.Key == mon.TenMon);
                    

                    // Xóa panel con khỏi giao diện
                    panelHienThiHoaDon.Controls.Remove(itemPanel);

                    // Cập nhật lại vị trí các panels còn lại
                    foreach (Control control in panelHienThiHoaDon.Controls)
                    {
                        control.Location = new Point(control.Location.X, control.Location.Y - itemPanel.Height - 10);
                    }
                };

                // Gắn sự kiện cho nút tăng và giảm
                decreaseButton.Click += (s, e) =>
                {
                    var currentIndex = ds.FindIndex(item => item.Key == mon.TenMon);
                    if (currentIndex != -1 && ds[currentIndex].Value > 1)
                    {
                        ds[currentIndex] = new KeyValuePair<string, int>(
                            ds[currentIndex].Key,
                            ds[currentIndex].Value - 1
                        );
                        quantityLabels[mon.TenMon].Text = $"Số lượng: {ds[currentIndex].Value}";
                        totalPrice -= mon.Gia;
                        
                    }
                    labelTien.Text = string.Format("{0:N0} đ", totalPrice);

                };

                increaseButton.Click += (s, e) =>
                {
                    var currentIndex = ds.FindIndex(item => item.Key == mon.TenMon);
                    if (currentIndex != -1)
                    {
                        ds[currentIndex] = new KeyValuePair<string, int>(
                            ds[currentIndex].Key,
                            ds[currentIndex].Value + 1
                        );
                        quantityLabels[mon.TenMon].Text = $"Số lượng: {ds[currentIndex].Value}";
                        totalPrice += mon.Gia;
                        
                    }
                    labelTien.Text = string.Format("{0:N0} đ", totalPrice);

                };

                // Thêm các controls vào panel con
                itemPanel.Controls.Add(nameLabel);
                itemPanel.Controls.Add(closeButton);
                itemPanel.Controls.Add(priceLabel);
                itemPanel.Controls.Add(quantityLabel);
                itemPanel.Controls.Add(decreaseButton);
                itemPanel.Controls.Add(increaseButton);
          
                // Thêm panel con vào panelHienThiHoaDon
                panelHienThiHoaDon.Controls.Add(itemPanel);

                // Đặt vị trí của panel con
                int currentYPosition = panelHienThiHoaDon.Controls.Count > 0
                    ? panelHienThiHoaDon.Controls[panelHienThiHoaDon.Controls.Count - 1].Bottom + 10
                    : 10;
                itemPanel.Location = new Point(10, currentYPosition);
                labelTien.Text = string.Format("{0:N0} đ", totalPrice);

            }
        }

        public void LoadLoaiMonComboBox()
        {
            
            List<LoaiMon> loaiMons = sql.GetLoaiMon();

            
            gunaComboBoxLoaiMon.Items.Clear();

            gunaComboBoxLoaiMon.Items.Add("");
            // Thêm dữ liệu mới vào ComboBox
            foreach (var loaiMon in loaiMons)
            {
                gunaComboBoxLoaiMon.Items.Add(loaiMon.TenLoaiMon);
            }

            // Tùy chọn đặt giá trị mặc định
            if (gunaComboBoxLoaiMon.Items.Count > 0)
            {
                gunaComboBoxLoaiMon.SelectedIndex = 0; // Chọn item đầu tiên
            }
        }

        private List<Mon> TimKiemDanhSachMon(string tenMon, string maLoaiMon)
        {
            List<Mon> danhSachMonList = sql.GetDanhSachMon();

            // Lọc theo tên món và loại món
            return danhSachMonList.Where(mon =>
                (string.IsNullOrEmpty(tenMon) || mon.TenMon.IndexOf(tenMon, StringComparison.OrdinalIgnoreCase) >= 0) &&  // Lọc theo tên nếu có
                (string.IsNullOrEmpty(maLoaiMon) || mon.MaLoaiMon == maLoaiMon) // Lọc theo loại nếu có
            ).ToList();
        }


        private void buttonTim_Click(object sender, EventArgs e)
        {
            // Lấy thông tin tìm kiếm từ TextBox và ComboBox
            string tenMon = richTextBoxTenMon.Text.Trim(); // Tên món tìm kiếm
            string tenLoaiMon = gunaComboBoxLoaiMon.SelectedItem?.ToString(); // Loại món được chọn

            if(tenMon == "")
            {
                labelTenMonTimKiem.Text = "";
            }
            else labelTenMonTimKiem.Text = "Tìm Kiếm: " + tenMon;
            // Kiểm tra giá trị của loại món. Nếu không chọn loại, gán giá trị là string.Empty
            if (string.IsNullOrEmpty(tenLoaiMon) || tenLoaiMon == "Tất cả")
            {
                tenLoaiMon = string.Empty; // Nếu "Tất cả" hoặc không chọn gì, không lọc theo loại
            }

            // Tìm mã loại món từ tên loại món
            string maLoaiMon = string.Empty;

            if (!string.IsNullOrEmpty(tenLoaiMon))
            {
                LoaiMon loaiMon = sql.GetLoaiMon().FirstOrDefault(l => l.TenLoaiMon == tenLoaiMon);
                if (loaiMon != null)
                {
                    maLoaiMon = loaiMon.MaLoaiMon; // Gán mã loại món
                }
            }

            // Lọc danh sách món dựa trên tên và loại món
            List<Mon> danhSachMonTimKiem = TimKiemDanhSachMon(tenMon, maLoaiMon);

            // Hiển thị lại danh sách đã lọc
            richTextBoxTenMon.Clear();  // Xóa nội dung trong RichTextBox
            gunaComboBoxLoaiMon.SelectedIndex = 0;  // Đặt lại ComboBox về giá trị mặc định (hoặc Tất cả nếu muốn)
            LoadDanhSachMon(danhSachMonTimKiem);
        }
        private void richTextBoxTenMon_KeyDown(object sender, KeyEventArgs e)
        {
            // Kiểm tra xem phím Enter có được nhấn không
            if (e.KeyCode == Keys.Enter)
            {
                // Ngừng hành vi mặc định của phím Enter (không tạo dòng mới)
                e.SuppressKeyPress = true;

                // Gọi hàm tìm kiếm
                buttonTim_Click(sender, e);
            }
        }

        private void buttonThanhToan_Click(object sender, EventArgs e)
        {
            ThanhToan form = new ThanhToan(ds);
            // khởi tạo form con là form  muốn hiển thị.

           
            
            
            // hiển thị full trên panel chứa nó.
            form.Dock = DockStyle.Fill;
            form.ShowDialog();

        }
    }
}
