namespace LTWINDOW_
{
    partial class QuanLyLoaiMon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuanLyLoaiMon));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel_dtgrv = new System.Windows.Forms.Panel();
            this.panel_info = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel_dtgrv.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(848, 464);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel_dtgrv
            // 
            this.panel_dtgrv.Controls.Add(this.dataGridView1);
            this.panel_dtgrv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_dtgrv.Location = new System.Drawing.Point(0, 0);
            this.panel_dtgrv.Name = "panel_dtgrv";
            this.panel_dtgrv.Size = new System.Drawing.Size(848, 464);
            this.panel_dtgrv.TabIndex = 1;
            // 
            // panel_info
            // 
            this.panel_info.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_info.Location = new System.Drawing.Point(0, 0);
            this.panel_info.Name = "panel_info";
            this.panel_info.Size = new System.Drawing.Size(848, 100);
            this.panel_info.TabIndex = 2;
            // 
            // QuanLyLoaiMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 464);
            this.Controls.Add(this.panel_info);
            this.Controls.Add(this.panel_dtgrv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuanLyLoaiMon";
            this.Text = "Quan Ly Loai Mon";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel_dtgrv.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel_dtgrv;
        private System.Windows.Forms.Panel panel_info;
    }
}