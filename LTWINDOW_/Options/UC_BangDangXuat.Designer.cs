﻿namespace LTWINDOW_.Options
{
    partial class UC_BangDangXuat
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
            this.components = new System.ComponentModel.Container();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ButtonDangXuat = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 3;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2ButtonDangXuat
            // 
            this.guna2ButtonDangXuat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2ButtonDangXuat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2ButtonDangXuat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2ButtonDangXuat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2ButtonDangXuat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.guna2ButtonDangXuat.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ButtonDangXuat.ForeColor = System.Drawing.Color.Purple;
            this.guna2ButtonDangXuat.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.guna2ButtonDangXuat.Location = new System.Drawing.Point(56, 63);
            this.guna2ButtonDangXuat.Name = "guna2ButtonDangXuat";
            this.guna2ButtonDangXuat.Size = new System.Drawing.Size(243, 45);
            this.guna2ButtonDangXuat.TabIndex = 3;
            this.guna2ButtonDangXuat.Text = "Đăng Xuất";
            this.guna2ButtonDangXuat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.guna2ButtonDangXuat.Click += new System.EventHandler(this.guna2ButtonDangXuat_Click);
            // 
            // guna2Button2
            // 
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.guna2Button2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button2.ForeColor = System.Drawing.Color.Purple;
            this.guna2Button2.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.guna2Button2.Location = new System.Drawing.Point(56, 3);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(243, 54);
            this.guna2Button2.TabIndex = 4;
            this.guna2Button2.Text = "Trang Cá Nhân";
            this.guna2Button2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // UC_BangDangXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.guna2ButtonDangXuat);
            this.Name = "UC_BangDangXuat";
            this.Size = new System.Drawing.Size(299, 154);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Button guna2ButtonDangXuat;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
    }
}
