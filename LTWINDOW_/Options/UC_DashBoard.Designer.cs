﻿namespace LTWINDOW_.Options
{
    partial class UC_DashBoard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.labelThongBao = new System.Windows.Forms.Label();
            this.panelButton = new System.Windows.Forms.FlowLayoutPanel();
            this.labelTenNhanVien = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelBangDangXuat = new System.Windows.Forms.Panel();
            this.acount = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uC_BangDangXuat1 = new LTWINDOW_.Options.UC_BangDangXuat();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panelBangDangXuat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelThongBao
            // 
            this.labelThongBao.AutoSize = true;
            this.labelThongBao.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelThongBao.ForeColor = System.Drawing.Color.DarkViolet;
            this.labelThongBao.Location = new System.Drawing.Point(1234, 337);
            this.labelThongBao.Name = "labelThongBao";
            this.labelThongBao.Size = new System.Drawing.Size(197, 35);
            this.labelThongBao.TabIndex = 13;
            this.labelThongBao.Text = "THÔNG BÁO";
            // 
            // panelButton
            // 
            this.panelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panelButton.Location = new System.Drawing.Point(936, 384);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(779, 698);
            this.panelButton.TabIndex = 17;
            // 
            // labelTenNhanVien
            // 
            this.labelTenNhanVien.AutoSize = true;
            this.labelTenNhanVien.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelTenNhanVien.Location = new System.Drawing.Point(1337, 32);
            this.labelTenNhanVien.Name = "labelTenNhanVien";
            this.labelTenNhanVien.Size = new System.Drawing.Size(150, 26);
            this.labelTenNhanVien.TabIndex = 16;
            this.labelTenNhanVien.Text = "Ten nhan vien";
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.chart1.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Cursor = System.Windows.Forms.Cursors.Default;
            this.chart1.DataSource = this.chart1.Images;
            legend2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(0, 124);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series2.BackImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            series2.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            series2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            series2.Color = System.Drawing.Color.DarkOrchid;
            series2.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            series2.LabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            series2.LabelBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            series2.Legend = "Legend1";
            series2.MarkerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            series2.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            series2.Name = "Doanh thu quán";
            series2.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1120, 583);
            this.chart1.TabIndex = 15;
            this.chart1.Text = "Doanh thu quán";
            // 
            // panelBangDangXuat
            // 
            this.panelBangDangXuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panelBangDangXuat.Controls.Add(this.uC_BangDangXuat1);
            this.panelBangDangXuat.Location = new System.Drawing.Point(1416, 79);
            this.panelBangDangXuat.Name = "panelBangDangXuat";
            this.panelBangDangXuat.Size = new System.Drawing.Size(299, 154);
            this.panelBangDangXuat.TabIndex = 19;
            // 
            // acount
            // 
            this.acount.BackColor = System.Drawing.Color.White;
            this.acount.BorderColor = System.Drawing.Color.White;
            this.acount.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.acount.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.acount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.acount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.acount.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.acount.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.acount.ForeColor = System.Drawing.Color.Black;
            this.acount.Image = global::LTWINDOW_.Properties.Resources.avata;
            this.acount.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.acount.ImageSize = new System.Drawing.Size(40, 40);
            this.acount.Location = new System.Drawing.Point(1638, 0);
            this.acount.Name = "acount";
            this.acount.PressedColor = System.Drawing.Color.Transparent;
            this.acount.Size = new System.Drawing.Size(77, 87);
            this.acount.TabIndex = 18;
            this.acount.Click += new System.EventHandler(this.acount_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LTWINDOW_.Properties.Resources.thongBao1;
            this.pictureBox1.Location = new System.Drawing.Point(1416, 322);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // uC_BangDangXuat1
            // 
            this.uC_BangDangXuat1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.uC_BangDangXuat1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_BangDangXuat1.Location = new System.Drawing.Point(0, 0);
            this.uC_BangDangXuat1.Name = "uC_BangDangXuat1";
            this.uC_BangDangXuat1.Size = new System.Drawing.Size(299, 154);
            this.uC_BangDangXuat1.TabIndex = 0;
            // 
            // UC_DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.panelBangDangXuat);
            this.Controls.Add(this.acount);
            this.Controls.Add(this.labelThongBao);
            this.Controls.Add(this.panelButton);
            this.Controls.Add(this.labelTenNhanVien);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "UC_DashBoard";
            this.Size = new System.Drawing.Size(1715, 1099);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panelBangDangXuat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelThongBao;
        private System.Windows.Forms.FlowLayoutPanel panelButton;
        public System.Windows.Forms.Label labelTenNhanVien;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Button acount;
        private System.Windows.Forms.Panel panelBangDangXuat;
        private UC_BangDangXuat uC_BangDangXuat1;
    }
}
