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
    public partial class UC_BangDangXuat : UserControl
    {
        public event EventHandler DangXuat;
        public UC_BangDangXuat()
        {
            InitializeComponent();
          
        }

        private void guna2ButtonDangXuat_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Bạn có chắc chắc muốn đăng xuất", "Thông Báo Đăng Xuất",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                DangXuat?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
