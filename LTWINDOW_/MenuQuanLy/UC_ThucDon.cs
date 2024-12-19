using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace LTWINDOW_.MenuQuanLy
{
    public partial class UC_ThucDon : UserControl
    {
        private List<Mon> listMon;
        private SQL sql;
        DataTable dt;
        public UC_ThucDon()
        {
            InitializeComponent();
            listMon = new List<Mon>();
            sql = new SQL();
            LoadThucDon();
        }

        public void LoadThucDon()
        {
            // Lấy danh sách món từ cơ sở dữ liệu

            listMon = sql.GetDanhSachMon();

            // Chuyển đổi danh sách thành DataTable
            dt = new DataTable();
            dt.Columns.Add("MaLoaiMon", typeof(string));
            dt.Columns.Add("MaMon", typeof(string));
            dt.Columns.Add("TenMon", typeof(string));
            dt.Columns.Add("Gia", typeof(double));
            dt.Columns.Add("Image", typeof(Image));

            foreach (var mon in listMon)
            {
                Image originalImage = mon.ConvertBytesToImage();
                Image resizedImage = ResizeImage(originalImage, 100, 100);

                dt.Rows.Add(mon.MaLoaiMon, mon.MaMon, mon.TenMon, mon.Gia, resizedImage);
            }

            // Gán DataTable vào DataGridView
            dataGridViewThucDon.DataSource = null;
            dataGridViewThucDon.DataSource = dt;


            // Cài đặt chế độ hiển thị ảnh
            dataGridViewThucDon.Columns["Image"].DefaultCellStyle.NullValue = null;
            dataGridViewThucDon.Columns["Image"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Căn chỉnh độ rộng từng cột
            dataGridViewThucDon.Columns["MaLoaiMon"].Width = 200;
            dataGridViewThucDon.Columns["MaMon"].Width = 200;
            dataGridViewThucDon.Columns["TenMon"].Width = 400;
            dataGridViewThucDon.Columns["Gia"].Width = 250;
            dataGridViewThucDon.Columns["Image"].Width = 280;

            // Thêm căn chỉnh chữ trong ô
            dataGridViewThucDon.Columns["MaLoaiMon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewThucDon.Columns["MaMon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewThucDon.Columns["Gia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Đặt chế độ không tự động co giãn
            dataGridViewThucDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Căn chỉnh và định dạng DataGridView
            dataGridViewThucDon.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewThucDon.Dock = DockStyle.Fill;

            // Cài đặt font chữ
            dataGridViewThucDon.DefaultCellStyle.Font = new Font("Arial", 14);
            dataGridViewThucDon.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16, FontStyle.Bold);

            // Đặt tiêu đề cột
            dataGridViewThucDon.Columns["MaLoaiMon"].HeaderText = "Mã Loại Món";
            dataGridViewThucDon.Columns["MaMon"].HeaderText = "Mã Món";
            dataGridViewThucDon.Columns["TenMon"].HeaderText = "Tên Món";
            dataGridViewThucDon.Columns["Gia"].HeaderText = "Giá";
            dataGridViewThucDon.Columns["Image"].HeaderText = "Hình Ảnh";

            // Gắn sự kiện định dạng giá
            dataGridViewThucDon.CellFormatting += DataGridViewThucDon_CellFormatting;
        }

        private void DataGridViewThucDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewThucDon.Columns[e.ColumnIndex].Name == "Gia" && e.Value != null)
            {
                double gia = Convert.ToDouble(e.Value);
                e.Value = $"{gia:N0} đ";
                e.FormattingApplied = true;
            }
        }

        private Image ResizeImage(Image img, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, width, height);
            }
            return bmp;
        }

        private void UC_ThucDon_Load(object sender, EventArgs e)
        {
        }

        private void guna2ButtonThem_Click(object sender, EventArgs e)
        {
            Mon monMoi;

            // Mở form AddMon như một cửa sổ modal và lấy dữ liệu trả về
            using (AddMon form = new AddMon())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    monMoi = form.MonMoi;  // Lấy đối tượng MonMoi từ form AddMon
                }
                else
                {
                    return; // Nếu người dùng đóng form hoặc không xác nhận, không thực hiện gì thêm
                }
            }

            if (monMoi != null)
            {
                // Thêm món mới vào danh sách
                listMon.Add(monMoi);

                // Chuyển đổi hình ảnh từ byte array thành Image
                Image originalImage = monMoi.ConvertBytesToImage();

                // Thay đổi kích thước hình ảnh (ví dụ: 100x100)
                Image resizedImage = ResizeImage(originalImage, 100, 100);

                // Thêm vào DataTable của DataGridView
                DataTable dt = (DataTable)dataGridViewThucDon.DataSource;
                dt.Rows.Add(monMoi.MaLoaiMon, monMoi.MaMon, monMoi.TenMon, monMoi.Gia, resizedImage);
                dataGridViewThucDon.DataSource = null;
                dataGridViewThucDon.DataSource = dt;
                SetUpData();
            }
        }

        private void guna2ButtonXoa_Click(object sender, EventArgs e)
        {
            if (dataGridViewThucDon.SelectedRows.Count > 0)
            {
                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa món này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Lấy mã món từ dòng được chọn
                        string maMon = dataGridViewThucDon.SelectedRows[0].Cells["MaMon"].Value.ToString();

                        // Xóa dòng khỏi cơ sở dữ liệu
                        sql.DeleteMon(maMon);

                        // Xóa dòng khỏi DataTable
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["MaMon"].ToString() == maMon)
                            {
                                dt.Rows.Remove(row);
                                break;
                            }
                        }

                        // Cập nhật lại DataGridView
                        dataGridViewThucDon.DataSource = null;
                        dataGridViewThucDon.DataSource = dt;
                        SetUpData();

                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void SetUpData()
        {
            // Cài đặt chế độ hiển thị ảnh
            dataGridViewThucDon.Columns["Image"].DefaultCellStyle.NullValue = null;
            dataGridViewThucDon.Columns["Image"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Căn chỉnh độ rộng từng cột
            dataGridViewThucDon.Columns["MaLoaiMon"].Width = 200;
            dataGridViewThucDon.Columns["MaMon"].Width = 200;
            dataGridViewThucDon.Columns["TenMon"].Width = 400;
            dataGridViewThucDon.Columns["Gia"].Width = 250;
            dataGridViewThucDon.Columns["Image"].Width = 280;

            // Thêm căn chỉnh chữ trong ô
            dataGridViewThucDon.Columns["MaLoaiMon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewThucDon.Columns["MaMon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewThucDon.Columns["Gia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Đặt chế độ không tự động co giãn
            dataGridViewThucDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Căn chỉnh và định dạng DataGridView
            dataGridViewThucDon.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewThucDon.Dock = DockStyle.Fill;
        }

        private void guna2ButtonCapNhat_Click(object sender, EventArgs e)
        {
            if (dataGridViewThucDon.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = dataGridViewThucDon.SelectedRows[0];

                // Lấy giá trị từng cột
                string maLoaiMon = selectedRow.Cells["MaLoaiMon"].Value.ToString();
                string maMon = selectedRow.Cells["MaMon"].Value.ToString();
                string tenMon = selectedRow.Cells["TenMon"].Value.ToString();
                double gia = Convert.ToDouble(selectedRow.Cells["Gia"].Value);

                // Kiểm tra nếu cột Image có giá trị
                Image image = null;
                if (selectedRow.Cells["Image"].Value != null && selectedRow.Cells["Image"].Value is Image)
                {
                    image = (Image)selectedRow.Cells["Image"].Value;
                }

                // Mở form UpdateMon và truyền dữ liệu
                using (UpdateMon form = new UpdateMon(maLoaiMon, maMon, tenMon, gia, image))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        // Lấy dữ liệu đã chỉnh sửa từ form
                        Mon monCapNhat = form.MonCapNhat;

                        // Kiểm tra nếu có ảnh mới
                        if (monCapNhat.Image != null)
                        {
                            Image originalImage = monCapNhat.ConvertBytesToImage();
                            Image resizedImage = ResizeImage(originalImage, 100, 100);

                            // Cập nhật lại giá trị trong DataGridView
                            selectedRow.Cells["Image"].Value = resizedImage;
                        }
                        else
                        {
                            // Trường hợp không có ảnh mới, giữ nguyên ảnh hiện tại
                            selectedRow.Cells["Image"].Value = image;
                        }

                        selectedRow.Cells["MaLoaiMon"].Value = monCapNhat.MaLoaiMon;
                        selectedRow.Cells["MaMon"].Value = monCapNhat.MaMon;
                        selectedRow.Cells["TenMon"].Value = monCapNhat.TenMon;
                        selectedRow.Cells["Gia"].Value = monCapNhat.Gia;
                        
                        
                       

                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


    }

}
