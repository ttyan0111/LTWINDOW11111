using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTWINDOW_.MenuQuanLy
{
    public partial class UC_ThongBao : UserControl
    {
        SQL sql;
        int lastIndex;
        BindingList<ThongBao> bindingList;
        int stt;
        List<ThongBao> listThongBao;
        List<ThongBao> listChuyenDoi;
        public UC_ThongBao()
        {
            InitializeComponent();
            sql = new SQL();
            listChuyenDoi = new List<ThongBao>();
            listThongBao = new List<ThongBao>();
            LoadDSThongBao();
           

        }
        public void LoadDSThongBao()
        {
            
            listThongBao.Clear();
            listThongBao = sql.GetThongBao(out this.lastIndex);

            bindingList = new BindingList<ThongBao>(listThongBao);
            dataGridView.DataSource = bindingList;
           

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Cột tự căn chỉnh
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Hàng tự căn chỉnh
            dataGridView.Dock = DockStyle.Fill; // Chiếm toàn bộ vùng chứa
                                                // Cài đặt font chữ lớn hơn cho toàn bộ bảng
            dataGridView.DefaultCellStyle.Font = new Font("Arial", 14); // Font chữ lớn hơn
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16, FontStyle.Bold); // Font chữ tiêu đề
            dataGridView.Columns["ID"].HeaderText = "ID";
            dataGridView.Columns["TieuDe"].HeaderText = "Tiêu Đề";
            dataGridView.Columns["MoTa"].HeaderText = "Mô Tả";
            dataGridView.Columns["Ngay"].HeaderText = "Ngày Hiệu Lực";
        }
      

        private void guna2ButtonThem_Click(object sender, EventArgs e)
        {
            // Tạo một đối tượng mới cho Thông Báo
            this.lastIndex += 1;
            ThongBao newThongBao = new ThongBao
            {
                ID = lastIndex,
                TieuDe ="",
                MoTa = "",
                Ngay = DateTime.Now // Hoặc giá trị mặc định
            };

            // Thêm vào BindingList ở đầu danh sách
          
            bindingList.Insert(0, newThongBao); // Thêm vào đầu danh sách

            // Di chuyển đến dòng mới
            dataGridView.CurrentCell = dataGridView.Rows[0].Cells[1]; // Chọn ô đầu tiên của dòng mới
            dataGridView.BeginEdit(true); // Bắt đầu chế độ chỉnh sửa
        }

        private void guna2ButtonXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Lấy ID từ dòng được chọn
                        int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);

                        // Xóa dòng khỏi cơ sở dữ liệu
                        sql.DeleteThongBao(id);

                        // Xóa dòng khỏi BindingList
                        bindingList = (BindingList<ThongBao>)dataGridView.DataSource;
                        int selectedIndex = dataGridView.SelectedRows[0].Index;
                        bindingList.RemoveAt(selectedIndex);

                        // Refresh lại DataGridView
                        dataGridView.Refresh();

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


        private void guna2ButtonCapNhat_Click(object sender, EventArgs e)
        {
            CapNhatTable();
           
            sql.UpdateThongBao(listChuyenDoi);
        }
        private void CapNhatTable()
        {
            // Sắp xếp bindingList theo ID từ nhỏ đến lớn
            var sortedList = bindingList.OrderBy(tb => tb.ID).ToList();
            listChuyenDoi.Clear();
            // Duyệt qua danh sách đã sắp xếp
            foreach (ThongBao tb in sortedList)
            {

                listChuyenDoi.Add(tb);
            }
        }
      


    }

}
