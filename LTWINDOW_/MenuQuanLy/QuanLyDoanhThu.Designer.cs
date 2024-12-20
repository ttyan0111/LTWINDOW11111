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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_top = new System.Windows.Forms.Panel();
            this.guna2HtmlLabelTongTien = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbldenNgay = new System.Windows.Forms.Label();
            this.labeltuNgay = new System.Windows.Forms.Label();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
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
            this.panel_top.Controls.Add(this.guna2HtmlLabelTongTien);
            this.panel_top.Controls.Add(this.guna2HtmlLabel1);
            this.panel_top.Controls.Add(this.lbldenNgay);
            this.panel_top.Controls.Add(this.labeltuNgay);
            this.panel_top.Controls.Add(this.btnAdd);
            this.panel_top.Controls.Add(this.dtpdenNgay);
            this.panel_top.Controls.Add(this.dtptuNgay);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(1889, 92);
            this.panel_top.TabIndex = 0;
            // 
            // guna2HtmlLabelTongTien
            // 
            this.guna2HtmlLabelTongTien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.guna2HtmlLabelTongTien.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2HtmlLabelTongTien.ForeColor = System.Drawing.Color.Purple;
            this.guna2HtmlLabelTongTien.Location = new System.Drawing.Point(1073, 29);
            this.guna2HtmlLabelTongTien.Name = "guna2HtmlLabelTongTien";
            this.guna2HtmlLabelTongTien.Size = new System.Drawing.Size(60, 34);
            this.guna2HtmlLabelTongTien.TabIndex = 14;
            this.guna2HtmlLabelTongTien.Text = "hello";
            this.guna2HtmlLabelTongTien.Click += new System.EventHandler(this.guna2HtmlLabelTongTien_Click);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Purple;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(919, 29);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(148, 34);
            this.guna2HtmlLabel1.TabIndex = 13;
            this.guna2HtmlLabel1.Text = "Tổng Tiền:";
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
            this.btnAdd.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAdd.ForeColor = System.Drawing.Color.Purple;
            this.btnAdd.Image = global::LTWINDOW_.Properties.Resources.xem;
            this.btnAdd.ImageSize = new System.Drawing.Size(25, 25);
            this.btnAdd.Location = new System.Drawing.Point(493, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(173, 56);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Xem";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idOrder,
            this.idEmployee,
            this.employeeName,
            this.dateOrder,
            this.sumMoney});
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1889, 333);
            this.dataGridView1.TabIndex = 0;
            // 
            // idOrder
            // 
            this.idOrder.DataPropertyName = "MaDonHang";
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Purple;
            this.idOrder.DefaultCellStyle = dataGridViewCellStyle18;
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
        private System.Windows.Forms.Label lbldenNgay;
        private System.Windows.Forms.Label labeltuNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn idOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumMoney;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabelTongTien;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}
