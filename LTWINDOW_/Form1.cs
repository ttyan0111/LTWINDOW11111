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
           
        }

       

        

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }
    }
}
