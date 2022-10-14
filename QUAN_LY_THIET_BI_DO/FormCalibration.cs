using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QUAN_LY_THIET_BI_DO.Model;
namespace QUAN_LY_THIET_BI_DO
{
    public partial class FormCalibration : Form
    {

        DeviceControl_Model dbContext = new DeviceControl_Model();
        List<Calibration> list_calibrations = new List<Calibration>();
        public FormCalibration()
        {
            InitializeComponent();
        }
        public void Load_Calibration()
        {
            var result = dbContext.DEVICEs.ToList();
            foreach(var item in result)
            {

            }
        }
    }
}
