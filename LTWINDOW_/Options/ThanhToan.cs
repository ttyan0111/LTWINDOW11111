using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




// thư viện để chuyển pdf
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Drawing.Printing;
using System.Xml.Linq;
using System.Runtime.CompilerServices;

namespace LTWINDOW_.Options
{
    public partial class ThanhToan : Form
    {
        SQL sql;
        int check;
        string maNhanVien;
        string maDonHang;
        double grandTotal ;
        bool checkIn;

        public List<KeyValuePair<string, int>> ds { get; set; }

        public ThanhToan(List<KeyValuePair<string, int>> ds, int u, string maNhanVien,double grandTotal)
        {
            InitializeComponent();
            this.ds = ds ?? new List<KeyValuePair<string, int>>(); // Gán danh sách
            this.check = u;
            sql = new SQL(); // Khởi tạo SQL nếu cần
            this.maNhanVien = maNhanVien;
            this.maDonHang = Guid.NewGuid().ToString();
            HienThiThongTin(maNhanVien, maDonHang); // Hiển thị thông tin khi mở form
            this.grandTotal = grandTotal;
            this.checkIn = false;
        }
        public void HienThiThongTin(string maNhanVien,string maDonHang)
        {
            // Xóa dữ liệu cũ trong Panel không tương tác
            panelHienThi.Controls.Clear();

            // Tạo TableLayoutPanel để căn chỉnh các cột
            TableLayoutPanel table = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 4, // 4 cột
                RowCount = ds.Count + 6, // Thêm 3 dòng mới cho tên công ty, ngày, mã đơn hàng và mã nhân viên
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
            };

            // Thiết lập độ rộng các cột
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40f)); // Tên món
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f)); // Số lượng
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f)); // Giá đơn
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f)); // Tổng giá

            // ==== Thêm mã đơn hàng và mã nhân viên (dòng 0) ==== 
            // Tạo mã ngẫu nhiên cho mã đơn hàng
            
            Label maDonHangNhanVienLabel = new Label
            {
                Text = $"Mã đơn hàng: {maDonHang}\n" +
                $"Mã nhân viên: {maNhanVien}", // Gộp thông tin vào 1 ô
                Font = new System.Drawing.Font("Arial", 10, FontStyle.Italic),
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill,
                AutoSize = true
            };
            table.Controls.Add(maDonHangNhanVienLabel, 0, 2);
            table.SetColumnSpan(maDonHangNhanVienLabel, 4); // Chiếm hết 4 cột

            // ==== Thêm tên công ty (dòng 1) ==== 
            Label tenCongTyLabel = new Label
            {
                Text = "Cafe Rise and Shine",
                Font = new System.Drawing.Font("Arial", 14, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                AutoSize = true
            };
            table.Controls.Add(tenCongTyLabel, 0, 0);
            table.SetColumnSpan(tenCongTyLabel, 4); // Chiếm hết 4 cột

            // ==== Thêm ngày lập hóa đơn (dòng 2) ==== 
            Label ngayLabel = new Label
            {
                Text = "Ngày: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                Font = new System.Drawing.Font("Arial", 12, FontStyle.Italic),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                AutoSize = true
            };
            table.Controls.Add(ngayLabel, 0, 1);
            table.SetColumnSpan(ngayLabel, 4); // Chiếm hết 4 cột

            // ==== Thêm tiêu đề bảng (dòng 3) ==== 
            table.Controls.Add(new Label { Text = "Tên món", Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter, AutoSize = true }, 0, 3);
            table.Controls.Add(new Label { Text = "SL", Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter, AutoSize = true }, 1, 3);
            table.Controls.Add(new Label { Text = "Giá Đơn", Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter, AutoSize = true }, 2, 3);
            table.Controls.Add(new Label { Text = "Tổng Giá", Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter, AutoSize = true }, 3, 3);

            
            int row = 4; // Bắt đầu dòng dữ liệu từ dòng 4

            // ==== Duyệt qua danh sách món ăn ==== 
            foreach (var item in ds)
            {
                string tenMon = item.Key;
                int soLuong = item.Value;

                // Lấy thông tin món từ cơ sở dữ liệu
                Mon mon = sql.GetDanhSachMon().FirstOrDefault(m => m.TenMon == tenMon);
                if (mon == null) continue;

                double total = mon.Gia * soLuong;
             

                // Thêm thông tin vào bảng
                table.Controls.Add(new Label { Text = tenMon, Font = new System.Drawing.Font("Arial", 12), TextAlign = ContentAlignment.MiddleLeft, AutoSize = true }, 0, row);
                table.Controls.Add(new Label { Text = soLuong.ToString(), Font = new System.Drawing.Font("Arial", 12), TextAlign = ContentAlignment.MiddleCenter }, 1, row);
                table.Controls.Add(new Label { Text = mon.Gia.ToString("N0") + " đ", Font = new System.Drawing.Font("Arial", 12), TextAlign = ContentAlignment.MiddleRight }, 2, row);
                table.Controls.Add(new Label { Text = total.ToString("N0") + " đ", Font = new System.Drawing.Font("Arial", 12), TextAlign = ContentAlignment.MiddleRight }, 3, row);

                row++;
            }

            // ==== Thêm dòng Tổng Cộng ==== 
            table.Controls.Add(new Label { Text = "Tổng Cộng", Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter, AutoSize = true }, 0, row);
            table.Controls.Add(new Label { Text = "", AutoSize = true }, 1, row);
            table.Controls.Add(new Label { Text = "", AutoSize = true }, 2, row);
            table.Controls.Add(new Label { Text = grandTotal.ToString("N0") + " đ", Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold), TextAlign = ContentAlignment.MiddleRight }, 3, row);

            row++; // Chuyển xuống dòng mới

            // ==== Thêm trạng thái ==== 
            Label trangThaiLabel = new Label
            {
                Text = "Trạng thái: " + (check == 1 ? "Mua về" : "Tại quán"),
                Font = new System.Drawing.Font("Arial", 12, FontStyle.Italic),
                TextAlign = ContentAlignment.MiddleRight,
                AutoSize = true
            };
            table.Controls.Add(trangThaiLabel, 0, row);
            table.SetColumnSpan(trangThaiLabel, 4); // Chiếm hết 4 cột

            // ==== Thêm TableLayoutPanel vào Panel cha ==== 
            panelHienThi.Controls.Add(table);
        }



        private void buttonInHoaDon_Click(object sender, EventArgs e)
        {

            sql.LuuDonHang(maDonHang, maNhanVien, DateTime.Now, grandTotal);






            // Mở hộp thoại chọn vị trí lưu file
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                Title = "Lưu hóa đơn dưới dạng PDF",
                FileName = "HoaDon.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Khởi tạo tài liệu PDF
                    Document pdfDoc = new Document(PageSize.A4, 20, 20, 30, 30);
                    PdfWriter.GetInstance(pdfDoc, new FileStream(saveFileDialog.FileName, FileMode.Create));

                    // Mở tài liệu để ghi
                    pdfDoc.Open();

                    // Tạo Font từ BaseFont
                    // Đường dẫn đến file font hỗ trợ Unicode (Times New Roman là một ví dụ)
                    string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");
                    BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font customFont = new iTextSharp.text.Font(baseFont, 18, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font italicFont = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.ITALIC);

                    Paragraph tenCongTy = new Paragraph("Cafe Rise and Shine", customFont);
                    tenCongTy.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(tenCongTy);

                    Paragraph ngay = new Paragraph("Ngày: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), italicFont);
                    ngay.Alignment = Element.ALIGN_CENTER;
                    ngay.SpacingAfter = 20;

                    // Thêm khoảng trắng rõ ràng giữa các phần:
                    ngay.Add(" ");

                    pdfDoc.Add(ngay);


                    // Thêm mã nhân viên
                    Paragraph maNhanVienParagraph = new Paragraph("Mã nhân viên: " + maNhanVien, italicFont); // Thay `maNhanVien` bằng biến lưu mã nhân viên
                    maNhanVienParagraph.Alignment = Element.ALIGN_LEFT;
                    maNhanVienParagraph.SpacingBefore = 5;
                    pdfDoc.Add(maNhanVienParagraph);

                    // Thêm mã đơn hàng
                    Paragraph maDonHangParagraph = new Paragraph("Mã đơn hàng: " + maDonHang, italicFont); // Thay `maDonHang` bằng biến lưu mã đơn hàng
                    maDonHangParagraph.Alignment = Element.ALIGN_LEFT;
                    maDonHangParagraph.SpacingBefore = 3;
                    maDonHangParagraph.SpacingAfter = 5; // Cách từ mã hàng ra 20 điểm
                    pdfDoc.Add(maDonHangParagraph);

                    // Tạo bảng
                    PdfPTable table = new PdfPTable(4);
                    table.WidthPercentage = 100;
                    table.SetWidths(new float[] { 40f, 20f, 20f, 20f }); // Độ rộng từng cột

                    // Thêm tiêu đề bảng với font đậm
                    iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.BOLD);
                    string[] headers = { "Tên món", "SL", "Giá Đơn", "Tổng Giá" };
                    foreach (string header in headers)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(header, headerFont));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(cell);
                    }

                    // Thêm dữ liệu món ăn
                   
                    foreach (var item in ds)
                    {
                        string tenMon = item.Key;
                        int soLuong = item.Value;

                        // Lấy thông tin từ cơ sở dữ liệu
                        Mon mon = sql.GetDanhSachMon().FirstOrDefault(m => m.TenMon == tenMon);
                        if (mon == null) continue;

                        double total = mon.Gia * soLuong;
                        
                        
                        table.AddCell(new PdfPCell(new Phrase(tenMon, new iTextSharp.text.Font(baseFont, 12))));
                        table.AddCell(new PdfPCell(new Phrase(soLuong.ToString(), new iTextSharp.text.Font(baseFont, 12))));
                        table.AddCell(new PdfPCell(new Phrase(mon.Gia.ToString("N0") + " đ", new iTextSharp.text.Font(baseFont, 12))));
                        table.AddCell(new PdfPCell(new Phrase(total.ToString("N0") + " đ", new iTextSharp.text.Font(baseFont, 12))));
                        sql.LuuChiTietDonHang(mon.MaMon, soLuong, total, maDonHang);

                    }

                    // Dòng Tổng Cộng
                    PdfPCell emptyCell = new PdfPCell(new Phrase(""));
                    emptyCell.Colspan = 2;
                    table.AddCell(emptyCell);
                    table.AddCell(new PdfPCell(new Phrase("Tổng Cộng", new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.BOLD))));
                    table.AddCell(new PdfPCell(new Phrase(grandTotal.ToString("N0") + " đ", new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.BOLD))));

                    // Thêm bảng vào tài liệu
                    pdfDoc.Add(table);

                    // Thêm trạng thái
                    Paragraph trangThai = new Paragraph("Trạng thái: " + (check == 1 ? "Mua về" : "Tại quán"), italicFont);
                    trangThai.Alignment = Element.ALIGN_RIGHT;
                    trangThai.SpacingBefore = 10;
                    pdfDoc.Add(trangThai);

                    // Đóng tài liệu
                    pdfDoc.Close();

                    DialogResult result = MessageBox.Show("Hóa đơn đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    
                   

                    // Nếu người dùng nhấn OK, đóng form hiện tại
                    if (result == DialogResult.OK)
                    {
                        this.checkIn = true;
                        // Đóng Form hiện tại
                        this.Close();



                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tạo file PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public bool getCheckIn() { return checkIn; }






    }


}
