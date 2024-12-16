namespace LTWINDOW_.MenuQuanLy
{
    partial class QuanLyNhanVien
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
            this.panel_top = new System.Windows.Forms.Panel();
            this.btnDiscontined = new System.Windows.Forms.Button();
            this.btnFix = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.panel_body = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_top.SuspendLayout();
            this.panel_body.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_top
            // 
            this.panel_top.Controls.Add(this.btnDiscontined);
            this.panel_top.Controls.Add(this.btnFix);
            this.panel_top.Controls.Add(this.btnThem);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(711, 113);
            this.panel_top.TabIndex = 0;
            // 
            // btnDiscontined
            // 
            this.btnDiscontined.Location = new System.Drawing.Point(314, 40);
            this.btnDiscontined.Name = "btnDiscontined";
            this.btnDiscontined.Size = new System.Drawing.Size(141, 23);
            this.btnDiscontined.TabIndex = 2;
            this.btnDiscontined.Text = "Dừng hoạt động";
            this.btnDiscontined.UseVisualStyleBackColor = true;
            this.btnDiscontined.Click += new System.EventHandler(this.btnDiscontined_Click);
            // 
            // btnFix
            // 
            this.btnFix.Location = new System.Drawing.Point(201, 40);
            this.btnFix.Name = "btnFix";
            this.btnFix.Size = new System.Drawing.Size(75, 23);
            this.btnFix.TabIndex = 1;
            this.btnFix.Text = "Sửa";
            this.btnFix.UseVisualStyleBackColor = true;
            this.btnFix.Click += new System.EventHandler(this.btnFix_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(108, 40);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // panel_body
            // 
            this.panel_body.Controls.Add(this.dataGridView1);
            this.panel_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_body.Location = new System.Drawing.Point(0, 113);
            this.panel_body.Name = "panel_body";
            this.panel_body.Size = new System.Drawing.Size(711, 315);
            this.panel_body.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.userName,
            this.passcode,
            this.position,
            this.status});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(711, 315);
            this.dataGridView1.TabIndex = 0;
            // 
            // id
            // 
            this.id.DataPropertyName = "MaNhanVien";
            this.id.HeaderText = "Mã Nhân Viên";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.Width = 125;
            // 
            // name
            // 
            this.name.DataPropertyName = "TenNhanVien";
            this.name.HeaderText = "Tên Nhân Viên";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.Width = 125;
            // 
            // userName
            // 
            this.userName.DataPropertyName = "UserName";
            this.userName.HeaderText = "Username";
            this.userName.MinimumWidth = 6;
            this.userName.Name = "userName";
            this.userName.Width = 125;
            // 
            // passcode
            // 
            this.passcode.DataPropertyName = "Passcode";
            this.passcode.HeaderText = "Password";
            this.passcode.MinimumWidth = 6;
            this.passcode.Name = "passcode";
            this.passcode.Width = 125;
            // 
            // position
            // 
            this.position.DataPropertyName = "ChucVu";
            this.position.HeaderText = "Chức Vụ";
            this.position.MinimumWidth = 6;
            this.position.Name = "position";
            this.position.Width = 125;
            // 
            // status
            // 
            this.status.DataPropertyName = "trangThaiHoatDong";
            this.status.HeaderText = "Trang Thái Hoạt Động";
            this.status.MinimumWidth = 6;
            this.status.Name = "status";
            this.status.Width = 125;
            // 
            // QuanLyNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.panel_body);
            this.Controls.Add(this.panel_top);
            this.Name = "QuanLyNhanVien";
            this.Size = new System.Drawing.Size(711, 428);
            this.Load += new System.EventHandler(this.QuanLyAccount_Load);
            this.panel_top.ResumeLayout(false);
            this.panel_body.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Panel panel_body;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDiscontined;
        private System.Windows.Forms.Button btnFix;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn userName;
        private System.Windows.Forms.DataGridViewTextBoxColumn passcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn position;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}
