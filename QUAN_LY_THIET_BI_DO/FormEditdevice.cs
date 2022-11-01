using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QUAN_LY_THIET_BI_DO.Business;
using QUAN_LY_THIET_BI_DO.Model;
namespace QUAN_LY_THIET_BI_DO
{
    public partial class FormEditdevice : Form
    {
        DeviceControl_Model dbcontext = new DeviceControl_Model();
        DEVICE device = new DEVICE();
        Form_device form_Device;
        Repository repository = new Repository();
        public FormEditdevice(Form_device form_Device, string part_no)
        {
            InitializeComponent();
            this.form_Device = form_Device;
            LoadInTextbox(part_no);
        }
        public void LoadInTextbox(string part_no)
        {
            var result = dbcontext.DEVICEs.Where(c => c.PART_NO == part_no).SingleOrDefault();
            txtpayment.Text = result.PAYMENT;
            txtpart_no.Text = result.PART_NO;
            txtsap_barcode.Text = result.SAP_BARCODE;
            txtpart_name.Text = result.PART_NAME;
            txtmodel.Text = result.MODEL;
            txtserial.Text = result.SERIAL;
            txtmanufactory.Text = result.MANUFACTORY;
            txtcycle.Text = result.CALI_CYCLE.ToString(); ;
            dtregistration_date.Text = result.REGISTRATION_DATE.ToString();
            txtdept_control.Text = result.DEPT_CONTROL;
            txtpleace_use.Text = result.PLACE_USE;
            txtcontrol_mng.Text = result.CONTROL_MNG;
            txtmaker.Text = result.MAKER;
            cbbequip_state.SelectedIndex = result.ENQUIP_STATE == 0 ? 0 : result.ENQUIP_STATE == 1 ? 1 : result.ENQUIP_STATE == 2 ? 2 : 3;
            txtrmk.Text = result.RMK;
            txtline.Text = result.LINE;
            txtfctno.Text = result.FCT_NO;
            txtmodelumc.Text = result.MODEL_UMC;
            lblpdf.Text = result.PDF_FILE;
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
                device.PAYMENT = txtpayment.Text;
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
                device.MAKER = txtmaker.Text;
                device.ENQUIP_STATE = cbbequip_state.SelectedIndex;
                device.RMK = txtrmk.Text;
                device.LINE = txtline.Text;
                device.FCT_NO = txtfctno.Text;
                device.MODEL_UMC = txtmodelumc.Text;
                device.PDF_FILE = lblpdf.Text;
                dbcontext.SaveChanges();                              
                MessageBox.Show("Mã quản lý " + txtpart_no.Text + " được sửa thành công!", "Thông báo");
                this.Hide();
                Reload_datawhenedit();
            }
        }

        public void Reload_datawhenedit()
        {
            var res = repository.FindAll();
            form_Device.dtgv_device.DataSource = res;
        }
        private void btnchoosepdf_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog openFileDialog= new OpenFileDialog() { Multiselect=false,ValidateNames=true,FileName="*.pdf" })
            {
                if(openFileDialog.ShowDialog()== DialogResult.OK)
                {
                    FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                    UploadFiles.UploadFile(fileInfo.FullName, @"/Cali_Pdf/"+ fileInfo.Name );
                    lblpdf.Text = fileInfo.Name;
                }
            }         
        }
    }
    
}
