using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUAN_LY_THIET_BI_DO
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnDevice_Click(object sender, EventArgs e)
        {
            Form_device form_Device = new Form_device();
            form_Device.ShowDialog();
        }

        private void btncalibration_Click(object sender, EventArgs e)
        {
            FormCalibration formCalibration = new FormCalibration();
            formCalibration.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
