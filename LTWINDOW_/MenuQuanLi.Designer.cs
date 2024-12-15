namespace LTWINDOW_
{
    partial class MenuQuanLi
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuQuanLi));
            this.panel_body = new System.Windows.Forms.Panel();
            this.panel_Top = new System.Windows.Forms.Panel();
            this.panel_top_loaiMon = new System.Windows.Forms.Panel();
            this.ptbLoaiMon = new System.Windows.Forms.PictureBox();
            this.lblLoaiMon = new System.Windows.Forms.Label();
            this.panel_top_taiKhoan = new System.Windows.Forms.Panel();
            this.ptbTaiKhoan = new System.Windows.Forms.PictureBox();
            this.lblTaiKhoan = new System.Windows.Forms.Label();
            this.panel_top_mon = new System.Windows.Forms.Panel();
            this.ptbThucDon = new System.Windows.Forms.PictureBox();
            this.lblThucDon = new System.Windows.Forms.Label();
            this.panel_Top.SuspendLayout();
            this.panel_top_loaiMon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLoaiMon)).BeginInit();
            this.panel_top_taiKhoan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTaiKhoan)).BeginInit();
            this.panel_top_mon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbThucDon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_body
            // 
            this.panel_body.BackColor = System.Drawing.Color.White;
            this.panel_body.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_body.Location = new System.Drawing.Point(0, 0);
            this.panel_body.Name = "panel_body";
            this.panel_body.Size = new System.Drawing.Size(800, 450);
            this.panel_body.TabIndex = 0;
            // 
            // panel_Top
            // 
            this.panel_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel_Top.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_Top.Controls.Add(this.panel_top_mon);
            this.panel_Top.Controls.Add(this.panel_top_loaiMon);
            this.panel_Top.Controls.Add(this.panel_top_taiKhoan);
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Top.Location = new System.Drawing.Point(0, 0);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(800, 159);
            this.panel_Top.TabIndex = 1;
            // 
            // panel_top_loaiMon
            // 
            this.panel_top_loaiMon.Controls.Add(this.ptbLoaiMon);
            this.panel_top_loaiMon.Controls.Add(this.lblLoaiMon);
            this.panel_top_loaiMon.Location = new System.Drawing.Point(197, 0);
            this.panel_top_loaiMon.Name = "panel_top_loaiMon";
            this.panel_top_loaiMon.Size = new System.Drawing.Size(163, 149);
            this.panel_top_loaiMon.TabIndex = 9;
            // 
            // ptbLoaiMon
            // 
            this.ptbLoaiMon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbLoaiMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbLoaiMon.Image = global::LTWINDOW_.Properties.Resources.Thực_đơn_1;
            this.ptbLoaiMon.Location = new System.Drawing.Point(0, 0);
            this.ptbLoaiMon.Name = "ptbLoaiMon";
            this.ptbLoaiMon.Size = new System.Drawing.Size(163, 121);
            this.ptbLoaiMon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbLoaiMon.TabIndex = 0;
            this.ptbLoaiMon.TabStop = false;
            this.ptbLoaiMon.Click += new System.EventHandler(this.ptbLoaiMon_Click);
            this.ptbLoaiMon.MouseLeave += new System.EventHandler(this.ptbLoaiMon_MouseLeave);
            this.ptbLoaiMon.MouseHover += new System.EventHandler(this.ptbLoaiMon_MouseHover);
            // 
            // lblLoaiMon
            // 
            this.lblLoaiMon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLoaiMon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblLoaiMon.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiMon.ForeColor = System.Drawing.Color.Purple;
            this.lblLoaiMon.Location = new System.Drawing.Point(0, 121);
            this.lblLoaiMon.Name = "lblLoaiMon";
            this.lblLoaiMon.Size = new System.Drawing.Size(163, 28);
            this.lblLoaiMon.TabIndex = 1;
            this.lblLoaiMon.Text = "Loại Món";
            this.lblLoaiMon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_top_taiKhoan
            // 
            this.panel_top_taiKhoan.Controls.Add(this.ptbTaiKhoan);
            this.panel_top_taiKhoan.Controls.Add(this.lblTaiKhoan);
            this.panel_top_taiKhoan.Location = new System.Drawing.Point(396, 0);
            this.panel_top_taiKhoan.Name = "panel_top_taiKhoan";
            this.panel_top_taiKhoan.Size = new System.Drawing.Size(163, 149);
            this.panel_top_taiKhoan.TabIndex = 9;
            // 
            // ptbTaiKhoan
            // 
            this.ptbTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbTaiKhoan.Image = global::LTWINDOW_.Properties.Resources.account2;
            this.ptbTaiKhoan.Location = new System.Drawing.Point(0, 0);
            this.ptbTaiKhoan.Name = "ptbTaiKhoan";
            this.ptbTaiKhoan.Size = new System.Drawing.Size(163, 121);
            this.ptbTaiKhoan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbTaiKhoan.TabIndex = 0;
            this.ptbTaiKhoan.TabStop = false;
            this.ptbTaiKhoan.MouseLeave += new System.EventHandler(this.ptbTaiKhoan_MouseLeave);
            this.ptbTaiKhoan.MouseHover += new System.EventHandler(this.ptbTaiKhoan_MouseHover);
            // 
            // lblTaiKhoan
            // 
            this.lblTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTaiKhoan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTaiKhoan.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaiKhoan.ForeColor = System.Drawing.Color.Purple;
            this.lblTaiKhoan.Location = new System.Drawing.Point(0, 121);
            this.lblTaiKhoan.Name = "lblTaiKhoan";
            this.lblTaiKhoan.Size = new System.Drawing.Size(163, 28);
            this.lblTaiKhoan.TabIndex = 1;
            this.lblTaiKhoan.Text = "Tài Khoản";
            this.lblTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_top_mon
            // 
            this.panel_top_mon.Controls.Add(this.ptbThucDon);
            this.panel_top_mon.Controls.Add(this.lblThucDon);
            this.panel_top_mon.Location = new System.Drawing.Point(3, 3);
            this.panel_top_mon.Name = "panel_top_mon";
            this.panel_top_mon.Size = new System.Drawing.Size(163, 149);
            this.panel_top_mon.TabIndex = 10;
            // 
            // ptbThucDon
            // 
            this.ptbThucDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbThucDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbThucDon.Image = global::LTWINDOW_.Properties.Resources.Thực_Đon_main1;
            this.ptbThucDon.Location = new System.Drawing.Point(0, 0);
            this.ptbThucDon.Name = "ptbThucDon";
            this.ptbThucDon.Size = new System.Drawing.Size(163, 121);
            this.ptbThucDon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbThucDon.TabIndex = 0;
            this.ptbThucDon.TabStop = false;
            this.ptbThucDon.MouseLeave += new System.EventHandler(this.ptbThucDon_MouseLeave_1);
            this.ptbThucDon.MouseHover += new System.EventHandler(this.ptbThucDon_MouseHover_1);
            // 
            // lblThucDon
            // 
            this.lblThucDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblThucDon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblThucDon.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThucDon.ForeColor = System.Drawing.Color.Purple;
            this.lblThucDon.Location = new System.Drawing.Point(0, 121);
            this.lblThucDon.Name = "lblThucDon";
            this.lblThucDon.Size = new System.Drawing.Size(163, 28);
            this.lblThucDon.TabIndex = 1;
            this.lblThucDon.Text = "Thực đơn";
            this.lblThucDon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MenuQuanLi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel_Top);
            this.Controls.Add(this.panel_body);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MenuQuanLi";
            this.Text = "Menu Quan Li";
            this.panel_Top.ResumeLayout(false);
            this.panel_top_loaiMon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbLoaiMon)).EndInit();
            this.panel_top_taiKhoan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbTaiKhoan)).EndInit();
            this.panel_top_mon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbThucDon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_body;
        private System.Windows.Forms.Panel panel_Top;
        private System.Windows.Forms.Panel panel_top_loaiMon;
        private System.Windows.Forms.PictureBox ptbLoaiMon;
        private System.Windows.Forms.Label lblLoaiMon;
        private System.Windows.Forms.Panel panel_top_taiKhoan;
        private System.Windows.Forms.PictureBox ptbTaiKhoan;
        private System.Windows.Forms.Label lblTaiKhoan;
        private System.Windows.Forms.Panel panel_top_mon;
        private System.Windows.Forms.PictureBox ptbThucDon;
        private System.Windows.Forms.Label lblThucDon;
    }
}