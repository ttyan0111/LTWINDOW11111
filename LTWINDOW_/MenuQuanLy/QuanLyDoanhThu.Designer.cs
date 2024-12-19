namespace LTWINDOW_.MenuQuanLy
{
    partial class QuanLyDoanhThu
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_top = new System.Windows.Forms.Panel();
            this.lbldenNgay = new System.Windows.Forms.Label();
            this.labeltuNgay = new System.Windows.Forms.Label();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnFix = new Guna.UI2.WinForms.Guna2Button();
            this.dtpdenNgay = new System.Windows.Forms.DateTimePicker();
            this.dtptuNgay = new System.Windows.Forms.DateTimePicker();
            this.panel_body = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEmployee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_top.SuspendLayout();
            this.panel_body.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_top
            // 
            this.panel_top.Controls.Add(this.lbldenNgay);
            this.panel_top.Controls.Add(this.labeltuNgay);
            this.panel_top.Controls.Add(this.btnAdd);
            this.panel_top.Controls.Add(this.btnFix);
            this.panel_top.Controls.Add(this.dtpdenNgay);
            this.panel_top.Controls.Add(this.dtptuNgay);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(1889, 92);
            this.panel_top.TabIndex = 0;
            // 
            // lbldenNgay
            // 
            this.lbldenNgay.AutoSize = true;
            this.lbldenNgay.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldenNgay.ForeColor = System.Drawing.Color.Purple;
            this.lbldenNgay.Location = new System.Drawing.Point(1475, 32);
            this.lbldenNgay.Name = "lbldenNgay";
            this.lbldenNgay.Size = new System.Drawing.Size(106, 24);
            this.lbldenNgay.TabIndex = 12;
            this.lbldenNgay.Text = "Đến ngày:";
            // 
            // labeltuNgay
            // 
            this.labeltuNgay.AutoSize = true;
            this.labeltuNgay.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeltuNgay.ForeColor = System.Drawing.Color.Purple;
            this.labeltuNgay.Location = new System.Drawing.Point(19, 32);
            this.labeltuNgay.Name = "labeltuNgay";
            this.labeltuNgay.Size = new System.Drawing.Size(96, 24);
            this.labeltuNgay.TabIndex = 11;
            this.labeltuNgay.Text = "Từ ngày:";
            // 
            // btnAdd
            // 
            this.btnAdd.BorderColor = System.Drawing.Color.Purple;
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.FillColor = System.Drawing.Color.Plum;
            this.btnAdd.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAdd.ForeColor = System.Drawing.Color.Purple;
            this.btnAdd.Image = global::LTWINDOW_.Properties.Resources.xem;
            this.btnAdd.ImageSize = new System.Drawing.Size(25, 25);
            this.btnAdd.Location = new System.Drawing.Point(764, 21);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(116, 45);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Xem";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnFix
            // 
            this.btnFix.BorderColor = System.Drawing.Color.Purple;
            this.btnFix.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFix.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFix.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFix.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFix.FillColor = System.Drawing.Color.Plum;
            this.btnFix.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnFix.ForeColor = System.Drawing.Color.Purple;
            this.btnFix.Image = global::LTWINDOW_.Properties.Resources.exit;
            this.btnFix.ImageSize = new System.Drawing.Size(30, 30);
            this.btnFix.Location = new System.Drawing.Point(928, 21);
            this.btnFix.Name = "btnFix";
            this.btnFix.Size = new System.Drawing.Size(116, 45);
            this.btnFix.TabIndex = 10;
            this.btnFix.Text = "Xóa";
            this.btnFix.Click += new System.EventHandler(this.btnFix_Click);
            // 
            // dtpdenNgay
            // 
            this.dtpdenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpdenNgay.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpdenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdenNgay.Location = new System.Drawing.Point(1607, 29);
            this.dtpdenNgay.Name = "dtpdenNgay";
            this.dtpdenNgay.Size = new System.Drawing.Size(200, 30);
            this.dtpdenNgay.TabIndex = 1;
            // 
            // dtptuNgay
            // 
            this.dtptuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtptuNgay.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtptuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtptuNgay.Location = new System.Drawing.Point(131, 29);
            this.dtptuNgay.Name = "dtptuNgay";
            this.dtptuNgay.Size = new System.Drawing.Size(200, 30);
            this.dtptuNgay.TabIndex = 0;
            this.dtptuNgay.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // panel_body
            // 
            this.panel_body.Controls.Add(this.dataGridView1);
            this.panel_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_body.Location = new System.Drawing.Point(0, 92);
            this.panel_body.Name = "panel_body";
            this.panel_body.Size = new System.Drawing.Size(1889, 333);
            this.panel_body.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idOrder,
            this.idEmployee,
            this.employeeName,
            this.dateOrder,
            this.sumMoney});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1889, 333);
            this.dataGridView1.TabIndex = 0;
            // 
            // idOrder
            // 
            this.idOrder.DataPropertyName = "MaDonHang";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Purple;
            this.idOrder.DefaultCellStyle = dataGridViewCellStyle2;
            this.idOrder.HeaderText = "Mã Đơn Hàng";
            this.idOrder.MinimumWidth = 6;
            this.idOrder.Name = "idOrder";
            this.idOrder.ReadOnly = true;
            this.idOrder.Width = 300;
            // 
            // idEmployee
            // 
            this.idEmployee.DataPropertyName = "MaNhanVien";
            this.idEmployee.HeaderText = "Mã Nhân Viên";
            this.idEmployee.MinimumWidth = 6;
            this.idEmployee.Name = "idEmployee";
            this.idEmployee.ReadOnly = true;
            this.idEmployee.Width = 200;
            // 
            // employeeName
            // 
            this.employeeName.DataPropertyName = "TenNhanVien";
            this.employeeName.HeaderText = "Tên nhân viên";
            this.employeeName.MinimumWidth = 6;
            this.employeeName.Name = "employeeName";
            this.employeeName.ReadOnly = true;
            this.employeeName.Width = 250;
            // 
            // dateOrder
            // 
            this.dateOrder.DataPropertyName = "NgayDatHang";
            this.dateOrder.HeaderText = "Ngày đặt hàng";
            this.dateOrder.MinimumWidth = 6;
            this.dateOrder.Name = "dateOrder";
            this.dateOrder.ReadOnly = true;
            this.dateOrder.Width = 200;
            // 
            // sumMoney
            // 
            this.sumMoney.DataPropertyName = "TongTien";
            this.sumMoney.HeaderText = "Tổng Tiền";
            this.sumMoney.MinimumWidth = 6;
            this.sumMoney.Name = "sumMoney";
            this.sumMoney.ReadOnly = true;
            this.sumMoney.Width = 370;
            // 
            // QuanLyDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.panel_body);
            this.Controls.Add(this.panel_top);
            this.Name = "QuanLyDoanhThu";
            this.Size = new System.Drawing.Size(1889, 425);
            this.Load += new System.EventHandler(this.QuanLyDoanhThu_Load);
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            this.panel_body.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Panel panel_body;
        private System.Windows.Forms.DateTimePicker dtpdenNgay;
        private System.Windows.Forms.DateTimePicker dtptuNgay;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnFix;
        private System.Windows.Forms.Label lbldenNgay;
        private System.Windows.Forms.Label labeltuNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn idOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumMoney;
    }
}
