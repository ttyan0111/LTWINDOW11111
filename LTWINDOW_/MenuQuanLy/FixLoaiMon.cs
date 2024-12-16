using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design;
using System.Windows.Forms;

namespace LTWINDOW_.MenuQuanLy
{
    public partial class FixLoaiMon : Form
    {
        static string query = "select * from LoaiMon";
        List<LoaiMon> idList = ListLoaiMoncs.getLoaiMonList(query);
        public FixLoaiMon()
        {
            InitializeComponent();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = cmbId.SelectedItem.ToString();

            foreach(LoaiMon lm in idList)
            {
                if (lm.getId() == id)
                {
                    txtName.Text = lm.getName();
                    if(lm.getTrangThai())
                    {
                        cmbStatus.SelectedIndex = 1;
                    }
                    else cmbStatus.SelectedIndex = 0;
                    break;
                }
            }    
        }

        private void FixLoaiMon_Load(object sender, EventArgs e)
        {
            
            foreach (LoaiMon lm in idList) { 
                cmbId.Items.Add(lm.getId());
            }
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc muốn thoát!,\nThoát nhấp Yes không nhấp No", "Thông Báo Thoát", 
                MessageBoxButtons.YesNo) == DialogResult.Yes) this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string strUpdate = "update LoaiMon  set TenLoaiMon = @name, TrangThai = @status where MaLoaiMon = @id";
            errorProvider1.Clear();
            if (cmbId.SelectedIndex == -1) errorProvider1.SetError(cmbId, "chưa chọn Mã loại món");
            else
            {
                string id = cmbId.Items[cmbId.SelectedIndex].ToString();
                string name = txtName.Text;
                bool status = true;
                if(cmbStatus.SelectedIndex == 1) status = true;
                else if(cmbStatus.SelectedIndex == 0) status = false;

                if (ListLoaiMoncs.update(strUpdate, name, status, id))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo thêm");
                }
                else MessageBox.Show("Thêm Thất bại", "Thông báo thêm");
            } 
                

            
        }
    }
}
