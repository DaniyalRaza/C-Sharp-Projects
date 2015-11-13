using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Wholesale_Management_System
{
    public partial class SalesReport : Form
    {
        public SalesReport()
        {
            InitializeComponent();
        }

        private void SalesReport_Load(object sender, EventArgs e)
        {
            chart1.Series["Series1"].ChartType = SeriesChartType.Line;
            chart1.Series["Series1"].Points.AddY(120);
            chart1.Series["Series1"].Points.AddY(230);
            chart1.Series["Series1"].Points.AddY(440);
        }
    }
}
