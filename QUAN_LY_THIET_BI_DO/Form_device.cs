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
    public partial class Form_device : Form
    {
        DeviceControl_Model dbcontext = new DeviceControl_Model();
        List<CONVERT_DEVICE> list_convert = new List<CONVERT_DEVICE>();
        public Form_device()
        {
            InitializeComponent();
            Load_data();
        }
        public void Load_data()
        {
            var result = dbcontext.DEVICEs.ToList();
            foreach(var item in result)
            {
                var result_cali = dbcontext.CALIBRATIONs.Where(c => c.PART_NO == item.PART_NO).SingleOrDefault();
                if (result_cali == null)
                {
                    MessageBox.Show("Mã quản lý không có thời gian hiệu chuẩn", "Thông báo");
                }
                else
                {
                    string equipment = "";
                    if (item.ENQUIP_STATE == Convert.ToInt32(Task.OK))
                    {
                        equipment = "OK";
                    }
                    else if (item.ENQUIP_STATE == Convert.ToInt32(Task.Stop_Calibration))
                    {
                        equipment = "Stop Calibration & Use";
                    }
                    else if (item.ENQUIP_STATE == Convert.ToInt32(Task.NG_Waiting_for_Repair))
                    {
                        equipment = "NG chờ sửa";
                    }
                    else
                    {
                        equipment = "NG hủy";
                    }
                    DateTime cali_next = result_cali.CALI_DATE.AddMonths(item.CALI_CYCLE);
                    list_convert.Add(new CONVERT_DEVICE()
                    {
                        PART_NO = item.PART_NO,
                        SAP_BARCODE = item.SAP_BARCODE,
                        PART_NAME = item.PART_NAME,
                        MODEL = item.MODEL,
                        SERIAL = item.SERIAL,
                        MANUFACTORY = item.MANUFACTORY,
                        CALI_CYCLE = item.CALI_CYCLE,
                        REGISTRATION_DATE = item.REGISTRATION_DATE,
                        DEPT_CONTROL = item.DEPT_CONTROL,
                        PLACE_USE = item.PLACE_USE,
                        CONTROL_MNG = item.CONTROL_MNG,
                        CALI_DATE = result_cali.CALI_DATE,
                        CALI_RECOMMEND = result_cali.CALI_RECOMMEND,
                        CALI_NEXT_LASTEST = cali_next,
                        MONTH_YEAR = cali_next.Month.ToString() + "/" + cali_next.Year.ToString(),
                        MAKER = item.MAKER,
                        ENQUIP_STATE = equipment,
                        RMK = item.RMK

                    });
                }
            }
            dtgv_device.DataSource = list_convert ;
           
        }

        private void Form_device_Load(object sender, EventArgs e)
        {
            Load_data();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormTask formTask = new FormTask(this);
            formTask.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormEditdevice formEditdevice = new FormEditdevice(this);
            formEditdevice.ShowDialog();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {

        }

        private void dtgv_device_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormEditdevice formEditdevice = new FormEditdevice(this);
            formEditdevice.txtpart_no.Text = this.dtgv_device.CurrentRow.Cells[0].Value.ToString();
            formEditdevice.txtsap_barcode.Text = this.dtgv_device.CurrentRow.Cells[2].Value.ToString();
            formEditdevice.txtpart_name.Text = this.dtgv_device.CurrentRow.Cells[1].Value.ToString();
            formEditdevice.txtmodel.Text = this.dtgv_device.CurrentRow.Cells[3].Value.ToString();
            formEditdevice.txtserial.Text = this.dtgv_device.CurrentRow.Cells[4].Value.ToString();
            formEditdevice.txtmanufactory.Text = this.dtgv_device.CurrentRow.Cells[5].Value.ToString();
            formEditdevice.txtcycle.Text = this.dtgv_device.CurrentRow.Cells[6].Value.ToString();
            formEditdevice.dtregistration_date.Text = this.dtgv_device.CurrentRow.Cells[7].Value.ToString();
            formEditdevice.txtdept_control.Text = this.dtgv_device.CurrentRow.Cells[8].Value.ToString();
            formEditdevice.txtpleace_use.Text = this.dtgv_device.CurrentRow.Cells[9].Value.ToString();
            formEditdevice.txtcontrol_mng.Text = this.dtgv_device.CurrentRow.Cells[10].Value.ToString();
            formEditdevice.dtcalibrationdate.Text = this.dtgv_device.CurrentRow.Cells[11].Value.ToString();
            formEditdevice.dtrecommend_date.Text = this.dtgv_device.CurrentRow.Cells[12].Value.ToString();
            formEditdevice.txtmaker.Text = this.dtgv_device.CurrentRow.Cells[15].Value.ToString();
            if (this.dtgv_device.CurrentRow.Cells[16].Value.ToString() == "OK")
            {
                formEditdevice.cbbequip_state.SelectedIndex = 0;
            }
            else if (this.dtgv_device.CurrentRow.Cells[16].Value.ToString() == "Stop Calibration & Use")
            {
                formEditdevice.cbbequip_state.SelectedIndex = 1;
            }
            else if (this.dtgv_device.CurrentRow.Cells[16].Value.ToString() == "NG chờ sửa")
            {
                formEditdevice.cbbequip_state.SelectedIndex = 2;
            }
            else 
            {
                formEditdevice.cbbequip_state.SelectedIndex = 3;
            }
            formEditdevice.txtrmk.Text = this.dtgv_device.CurrentRow.Cells[17].Value.ToString();
            formEditdevice.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            List<CONVERT_DEVICE>list_convert_search= new List<CONVERT_DEVICE>() ;
           var result = dbcontext.DEVICEs.Where(x => x.PART_NO.Contains(txtsearch.Text)).ToList();
            foreach (var item in result)
            {
                var result_cali = dbcontext.CALIBRATIONs.Where(c => c.PART_NO == item.PART_NO).SingleOrDefault();
                if (result_cali == null)
                {
                    MessageBox.Show("Mã quản lý không có thời gian hiệu chuẩn", "Thông báo");
                }
                else
                {
                    string equipment = "";
                    if (item.ENQUIP_STATE == Convert.ToInt32(Task.OK))
                    {
                        equipment = "OK";
                    }
                    else if (item.ENQUIP_STATE == Convert.ToInt32(Task.Stop_Calibration))
                    {
                        equipment = "Stop Calibration & Use";
                    }
                    else if (item.ENQUIP_STATE == Convert.ToInt32(Task.NG_Waiting_for_Repair))
                    {
                        equipment = "NG chờ sửa";
                    }
                    else
                    {
                        equipment = "NG hủy";
                    }
                    DateTime cali_next = result_cali.CALI_DATE.AddMonths(item.CALI_CYCLE);
                    list_convert_search.Add(new CONVERT_DEVICE()
                    {
                        PART_NO = item.PART_NO,
                        SAP_BARCODE = item.SAP_BARCODE,
                        PART_NAME = item.PART_NAME,
                        MODEL = item.MODEL,
                        SERIAL = item.SERIAL,
                        MANUFACTORY = item.MANUFACTORY,
                        CALI_CYCLE = item.CALI_CYCLE,
                        REGISTRATION_DATE = item.REGISTRATION_DATE,
                        DEPT_CONTROL = item.DEPT_CONTROL,
                        PLACE_USE = item.PLACE_USE,
                        CONTROL_MNG = item.CONTROL_MNG,
                        CALI_DATE = result_cali.CALI_DATE,
                        CALI_RECOMMEND = result_cali.CALI_RECOMMEND,
                        CALI_NEXT_LASTEST = cali_next,
                        MONTH_YEAR = cali_next.Month.ToString() + "/" + cali_next.Year.ToString(),
                        MAKER = item.MAKER,
                        ENQUIP_STATE = equipment,
                        RMK = item.RMK

                    });
                }
                
            }
            dtgv_device.DataSource = list_convert_search;
        }
    }
}
