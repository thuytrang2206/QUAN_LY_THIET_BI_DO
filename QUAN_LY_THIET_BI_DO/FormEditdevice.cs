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
    public partial class FormEditdevice : Form
    {
        DeviceControl_Model dbcontext = new DeviceControl_Model();
        DEVICE device = new DEVICE();
        Form_device form_Device;
        List<CONVERT_DEVICE> list_convert = new List<CONVERT_DEVICE>();
        public FormEditdevice(Form_device form_Device)
        {
            InitializeComponent();
            this.form_Device = form_Device;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            device = dbcontext.DEVICEs.Find(txtpart_no.Text);
            if(device == null)
            {
                MessageBox.Show("Không tìm thấy mã quản lý thiết bị", "Thông báo");
            }
            else
            {
                device.SAP_BARCODE = txtsap_barcode.Text;
                device.PART_NAME = txtpart_name.Text;
                device.MODEL = txtmodel.Text;
                device.SERIAL = txtserial.Text;
                device.MANUFACTORY = txtmanufactory.Text;
                device.CALI_CYCLE =int.Parse( txtcycle.Text);
                device.REGISTRATION_DATE = Convert.ToDateTime(dtregistration_date.Value);
                device.DEPT_CONTROL = txtdept_control.Text;
                device.PLACE_USE = txtpleace_use.Text;
                device.CONTROL_MNG = txtcontrol_mng.Text;
               // device.CALI_DATE = Convert.ToDateTime(dtcalibrationdate.Text);
                //device.CALI_RECOMMEND = Convert.ToDateTime(dtrecommend_date.Text);
                device.MAKER = txtmaker.Text;
                device.ENQUIP_STATE = cbbequip_state.SelectedIndex;
                device.RMK = txtrmk.Text;
                dbcontext.SaveChanges();                              
                MessageBox.Show("Mã quản lý " + txtpart_no.Text + " được sửa thành công!", "Thành công");
                this.Hide();
                Reload_datawhenedit();
            }
        }

        public void Reload_datawhenedit()
        {
            var result = dbcontext.DEVICEs.ToList();
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
            form_Device.dtgv_device.DataSource = list_convert;
        }
    }
    
}
