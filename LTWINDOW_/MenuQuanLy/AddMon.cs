using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Asn1.Ocsp;
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
using System.Xml.Linq;

namespace LTWINDOW_.MenuQuanLy
{
    public partial class AddMon : Form
    {
        public string pathImg = ""; // Biến lưu đường dẫn ảnh
        SQL sql;
        public Mon MonMoi { get; private set; }

        public AddMon()
        {
            InitializeComponent();
            sql = new SQL();
            LoadComBoBoxMon();
            txtMaMon.MaxLength = 4;
           
        }

       

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            // Tạo một hộp thoại mở tệp
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Cài đặt bộ lọc chỉ chọn các tệp ảnh
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Chọn ảnh";

                // Hiển thị hộp thoại và kiểm tra xem người dùng có chọn file không
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn của ảnh được chọn
                    pathImg = openFileDialog.FileName;

                    // Hiển thị đường dẫn ảnh trong MessageBox (hoặc gán vào một điều khiển khác nếu cần)
                   

                    // Nếu bạn muốn hiển thị ảnh lên PictureBox
                    guna2PictureBox1.Image = Image.FromFile(pathImg);
                    guna2PictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // Hiển thị ảnh với tỉ lệ co giãn phù hợp
                }
            }

        }
        void LoadComBoBoxMon()
        {
            // Lấy danh sách MaLoaiMon từ cơ sở dữ liệu
            List<string> list = sql.GetMaLoaiMon();

            // Xóa các mục hiện có trong ComboBox và thêm dữ liệu mới
            comboBoxMaLoaiMon.Items.Clear();
            foreach (string maLoaiMon in list)
            {
                comboBoxMaLoaiMon.Items.Add(maLoaiMon);
            }

            // Kiểm tra và chọn mục đầu tiên nếu có dữ liệu
            if (comboBoxMaLoaiMon.Items.Count > 0)
            {
                comboBoxMaLoaiMon.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string maLoaiMon = comboBoxMaLoaiMon.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(txtMaMon.Text) || txtMaMon.Text.Length != 4)
            {
                labelBaoLoi.Text = "Cần nhập mã đủ 4 ký tự hoặc không được để trống!";
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenMon.Text))
            {
                labelBaoLoi.Text = "Tên không được để trống!";
                return;
            }

            if (string.IsNullOrWhiteSpace(txtGia.Text) || !double.TryParse(txtGia.Text, out _))
            {
                labelBaoLoi.Text = "Giá không được để trống và phải là số!";
                return;
            }

            string maMon = txtMaMon.Text;
            string tenMon = txtTenMon.Text;
            double gia = Convert.ToDouble(txtGia.Text);

            // Gọi hàm thêm món
            if (string.IsNullOrEmpty(pathImg))
            {
                sql.AddMonMoi(maLoaiMon, maMon, tenMon, gia, null);
            }
            else
            {
                sql.AddMonMoi(maLoaiMon, maMon, tenMon, gia, pathImg);
            }
            
            MonMoi = new Mon
            {
                MaLoaiMon = maLoaiMon,
                MaMon = maMon,
                TenMon = tenMon,
                Gia = Convert.ToDouble(txtGia.Text),
                Image = ConvertImageToBytes(guna2PictureBox1.Image)
            };
            labelBaoLoi.Text = "";
            MessageBox.Show("Thêm Thành Công!", "Thông báo");
            // Đóng form và trả về DialogResult.OK để thông báo thành công
            this.DialogResult = DialogResult.OK;
            this.Close();
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
