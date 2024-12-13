using LTWINDOW_.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LTWINDOW_
{
    public partial class Form1 : Form
    {
        SQL sql;
        public Form1()
        {
            InitializeComponent();
            sql = new SQL();
            sql.OpenConnection();
            uC_DashBoard1.Visible = true;
            uC_Menu1.Visible = false;

        }

        private void buttonTrangChinh_Click(object sender, EventArgs e)
        {
            uC_DashBoard1.Visible = true;
            uC_Menu1.Visible = false;
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            uC_DashBoard1.Visible = false;
            uC_Menu1.Visible = true;
        }
    }
}
