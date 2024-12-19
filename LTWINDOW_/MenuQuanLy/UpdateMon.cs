using iTextSharp.text.pdf.parser.clipper;
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

namespace LTWINDOW_.MenuQuanLy
{
    public partial class UpdateMon : Form
    {
        public Mon MonCapNhat { get; private set; }
        SQL sql;
        Image image;
        bool check = false;
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ ComboBox
            string maLoaiMon = comboBoxMaLoaiMon.SelectedItem?.ToString();
            txtMaMon.ReadOnly = false;

            // Thu thập dữ liệu từ form
            string maMon = txtMaMon.Text;
            string tenMon = txtTenMon.Text;
            double gia = double.Parse(txtGia.Text);

            // Kiểm tra nếu image là null, sử dụng ảnh hiện tại từ PictureBox
            if (image == null && guna2PictureBox1.Image != null)
            {
                image = guna2PictureBox1.Image;
            }
           
            if (check)
            {
                byte[] imageBytes = ConvertImageToBytes(guna2PictureBox1.Image);
                MonCapNhat = new Mon
                {
                    MaLoaiMon = maLoaiMon,
                    MaMon = maMon,
                    TenMon = tenMon,
                    Gia = gia,
                    Image = imageBytes
                };
            }
            else
            {

                MonCapNhat = new Mon
                {
                    MaLoaiMon = maLoaiMon,
                    MaMon = maMon,
                    TenMon = tenMon,
                    Gia = gia,
                };
            }

            // Tạo đối tượng món

            sql.UpdateMon(maMon, maLoaiMon, tenMon, gia,guna2PictureBox1.Image);

            this.DialogResult = DialogResult.OK; // Đóng form và trả kết quả
            this.Close();
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
       
        public UpdateMon(string maLoaiMon,string maMon,string tenMon, double gia,Image imagee)
        {
            InitializeComponent();
            sql = new SQL();
            LoadComBoBoxMon();
            // Gán giá trị vào các control
            if (comboBoxMaLoaiMon.Items.Contains(maLoaiMon))
            {
                comboBoxMaLoaiMon.SelectedItem = maLoaiMon; // Gán trực tiếp nếu item tồn tại
            }
            txtMaMon.Text = maMon;
            txtTenMon.Text = tenMon;
            txtGia.Text = gia.ToString();
            guna2PictureBox1.Image = imagee;
            this.image = imagee;
            txtMaMon.ReadOnly = true;

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

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            // Tạo một hộp thoại mở tệp
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                string pathImg;
                // Cài đặt bộ lọc chỉ chọn các tệp ảnh
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Chọn ảnh";

                // Hiển thị hộp thoại và kiểm tra xem người dùng có chọn file không
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn của ảnh được chọn
                    pathImg = openFileDialog.FileName;

                    // Hiển thị đường dẫn ảnh trong MessageBox (hoặc gán vào một điều khiển khác nếu cần)
                    image = Image.FromFile(pathImg);
                    check = true;
                    // Nếu bạn muốn hiển thị ảnh lên PictureBox
                    guna2PictureBox1.Image = Image.FromFile(pathImg);
                    guna2PictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // Hiển thị ảnh với tỉ lệ co giãn phù hợp
                }
            }
        }

      
    }
}
