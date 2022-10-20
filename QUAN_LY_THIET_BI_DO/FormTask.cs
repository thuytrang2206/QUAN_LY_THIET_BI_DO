﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;
using QUAN_LY_THIET_BI_DO.Business;
using QUAN_LY_THIET_BI_DO.Model;

namespace QUAN_LY_THIET_BI_DO
{
    public partial class FormTask : Form
    {
        DeviceControl_Model dbcontext = new DeviceControl_Model();
        Form_device form_Device;
        CALIBRATION calibration = new CALIBRATION();
        DEVICE device = new DEVICE();
        Repository repository = new Repository();
        public FormTask(Form_device form_Device)
        {
            InitializeComponent();
            this.form_Device = form_Device;
            grboximpportexcel.Size = new Size(893, 404);

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkboximport.Checked == true)
                {
                    var Result = dtgvreaderexcel.Rows.OfType<DataGridViewRow>().Select(
                    r => r.Cells.OfType<DataGridViewCell>().Select(c => c.Value).ToArray()).ToList();
                    if (Result.Count() == 0)
                    {
                        MessageBox.Show("Bạn chưa chọn file excel để nhập thông tin!");
                    }
                    else
                    {
                        foreach (var item in Result)
                        {
                            string part_no = item[2].ToString();
                            var checkpartno = dbcontext.DEVICEs.Where(c => c.PART_NO == part_no).SingleOrDefault();
                            if (checkpartno == null)
                            {
                                var data = new DEVICE()
                                {
                                    PAYMENT = item[1].ToString() == "" ? "." : item[1].ToString(),
                                    PART_NO = item[2].ToString(),
                                    PART_NAME = item[4].ToString() == "" ? "." : item[4].ToString(),
                                    SAP_BARCODE = item[3].ToString() == "" ? "." : item[3].ToString(),
                                    MODEL = item[5].ToString() == "" ? "." : item[5].ToString(),
                                    SERIAL = item[6].ToString() == "" ? "." : item[6].ToString(),
                                    MANUFACTORY = item[7].ToString() == "" ? "." : item[7].ToString(),
                                    CALI_CYCLE = int.Parse(item[8].ToString()),
                                    REGISTRATION_DATE = Convert.ToDateTime(item[9].ToString()),
                                    DEPT_CONTROL = item[10].ToString() == "" ? "." : item[10].ToString(),
                                    PLACE_USE = item[11].ToString() == "" ? "." : item[11].ToString(),
                                    CONTROL_MNG = item[12].ToString() == "" ? "." : item[12].ToString(),
                                    ENQUIP_STATE = Check_equipment(item[18].ToString()),
                                    MAKER = item[17].ToString() == "" ? "." : item[17].ToString(),
                                    RMK = item[19].ToString() == "" ? "." : item[19].ToString(),
                                    LINE= item[20].ToString() == "" ? "." : item[20].ToString(),
                                    FCT_NO= item[21].ToString() == "" ? "." : item[21].ToString(),
                                    MODEL_UMC= item[22].ToString() == "" ? "." : item[22].ToString(),
                                    STATUS = true,
                                };
                                dbcontext.DEVICEs.Add(data);
                                var data_cali = new CALIBRATION()
                                {
                                    PART_NO = item[2].ToString(),
                                    CALI_DATE = Convert.ToDateTime(item[13].ToString()),
                                    CALI_RECOMMEND = Convert.ToDateTime(item[14].ToString()),
                                    STATUS = true,
                                };
                                dbcontext.CALIBRATIONs.Add(data_cali);
                                dbcontext.SaveChanges();
                            }
                            // part_no đã có trong csdl=>sửa dữ liệu theo item file excel
                            else
                            {
                                device = dbcontext.DEVICEs.Find(item[2].ToString());
                                device.PAYMENT = item[1].ToString() == "" ? "." : item[1].ToString();
                                device.SAP_BARCODE = item[3].ToString() == "" ? "." : item[3].ToString();
                                device.PART_NAME = item[4].ToString() == "" ? "." : item[4].ToString();
                                device.MODEL = item[5].ToString() == "" ? "." : item[5].ToString();
                                device.SERIAL = item[6].ToString() == "" ? "." : item[6].ToString();
                                device.MANUFACTORY = item[7].ToString() == "" ? "." : item[7].ToString();
                                device.CALI_CYCLE = int.Parse(item[8].ToString());
                                device.REGISTRATION_DATE = Convert.ToDateTime(item[9].ToString());
                                device.DEPT_CONTROL = item[10].ToString() == "" ? "." : item[10].ToString();
                                device.PLACE_USE = item[11].ToString() == "" ? "." : item[11].ToString();
                                device.CONTROL_MNG = item[12].ToString() == "" ? "." : item[12].ToString();
                                device.MAKER = item[17].ToString() == "" ? "." : item[17].ToString();
                                device.ENQUIP_STATE = Check_equipment(item[18].ToString());
                                device.RMK = item[19].ToString() == "" ? "." : item[19].ToString();
                                device.LINE = item[20].ToString() == "" ? "." : item[20].ToString();
                                device.FCT_NO = item[21].ToString() == "" ? "." : item[21].ToString();
                                device.MODEL_UMC = item[22].ToString() == "" ? "." : item[22].ToString();
                                device.STATUS = true;
                                calibration = dbcontext.CALIBRATIONs.Find(item[2].ToString());
                                calibration.CALI_DATE = Convert.ToDateTime(item[13].ToString());
                                calibration.CALI_RECOMMEND = Convert.ToDateTime(item[14].ToString());
                                calibration.STATUS = true;
                                dbcontext.SaveChanges();
                            }
                        }
                        Reloadlistconvert_datagridview();
                        Reload_datawhencreate();
                    }
                }
                else
                {
                    if (CheckValueTextBox() == true)
                    {
                        var check_part_no = dbcontext.DEVICEs.Where(c => c.PART_NO == txtpart_no.Text).SingleOrDefault();
                        // part_no chưa có trong csdl
                        if (check_part_no == null)
                        {
                            var data = new DEVICE()
                            {
                                PAYMENT= txtpay.Text,
                                PART_NO = txtpart_no.Text,
                                PART_NAME = txtpart_name.Text,
                                SAP_BARCODE = txtsap_barcode.Text,
                                MODEL = txtmodel.Text,
                                SERIAL = txtserial.Text,
                                MANUFACTORY = txtmanufactory.Text,
                                CALI_CYCLE = int.Parse(txtcycle.Text),
                                REGISTRATION_DATE = Convert.ToDateTime(dateTimeregistration.Text),
                                DEPT_CONTROL = txtdept_control.Text,
                                PLACE_USE = txtpleace_use.Text,
                                CONTROL_MNG = txtcontrol_mng.Text,
                                MAKER = txtmaker.Text,
                                ENQUIP_STATE = cbbequip_state.SelectedIndex,
                                RMK = txtrmk.Text,
                                LINE = txtline.Text,
                                FCT_NO = txtfctno.Text,
                                MODEL_UMC = txtmodelumc.Text,
                                STATUS = true,
                            };
                            dbcontext.DEVICEs.Add(data);
                            var data_cali = new CALIBRATION()
                            {
                                PART_NO = txtpart_no.Text,
                                CALI_DATE = Convert.ToDateTime(dateTimecalidate.Value),
                                CALI_RECOMMEND = Convert.ToDateTime(dateTimerecon.Value),
                                STATUS = true,
                            };
                            dbcontext.CALIBRATIONs.Add(data_cali);
                            dbcontext.SaveChanges();
                            Reloadlistconvert_datagridview();
                            Reload_datawhencreate();
                        }
                        //part_no có trong csdl
                        else
                        {
                            //kiểm tra status
                            //status=false=> sửa dữ liệu theo textbox và status= true
                            if (check_part_no.STATUS == true)
                            {
                                MessageBox.Show("Mã quản lý " + txtpart_no.Text + " đã có trong database!", "Thông báo");
                            }
                            else
                            {
                                device = dbcontext.DEVICEs.Find(txtpart_no.Text);
                                device.PAYMENT = txtpay.Text;
                                device.SAP_BARCODE = txtsap_barcode.Text;
                                device.PART_NAME = txtpart_no.Text;
                                device.MODEL = txtmodel.Text;
                                device.SERIAL = txtserial.Text;
                                device.MANUFACTORY = txtmanufactory.Text;
                                device.CALI_CYCLE = int.Parse(txtcycle.Text);
                                device.REGISTRATION_DATE = Convert.ToDateTime(dateTimeregistration.Text);
                                device.DEPT_CONTROL = txtdept_control.Text;
                                device.PLACE_USE = txtpleace_use.Text;
                                device.CONTROL_MNG = txtcontrol_mng.Text;
                                device.MAKER = txtmaker.Text;
                                device.ENQUIP_STATE = cbbequip_state.SelectedIndex;
                                device.RMK = txtrmk.Text;
                                device.LINE = txtline.Text;
                                device.FCT_NO = txtfctno.Text;
                                device.MODEL_UMC = txtmodelumc.Text;
                                device.STATUS = true;
                                calibration = dbcontext.CALIBRATIONs.Find(device.PART_NO);
                                calibration.CALI_DATE = Convert.ToDateTime(dateTimecalidate.Value);
                                calibration.CALI_RECOMMEND = Convert.ToDateTime(dateTimerecon.Value);
                                calibration.STATUS = true;
                                dbcontext.SaveChanges();
                                Reloadlistconvert_datagridview();
                                Reload_datawhencreate();
                            }
                        }
                    }
                }
            }
           catch(System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }
        }

        public void Reloadlistconvert_datagridview()
        {
            MessageBox.Show("Lưu thành công!", "Thông báo");
            this.Hide();

            //form_Device.dtgv_device.DataSource = null;
        }

        public int Check_equipment(string equipment)
        {
            int equipment_state = equipment == "OK" ? 0 : equipment == "Stop Calibration & Use" ? 1 : equipment == "NG chờ sửa" ? 2 : 3;
            return equipment_state;
        }

        public void Reload_datawhencreate()
        {
            var res = repository.FindAll();

            form_Device.dtgv_device.DataSource = res.OrderByDescending(c => c.PART_NO).ToList();
        }

        public bool CheckValueTextBox()
        {
            bool ok;
            if (String.IsNullOrEmpty(txtpay.Text))
            {
                lblpartno.Visible = true;
                lblpartno.Text = "Thanh toán không được để trống!";
            }
            if (String.IsNullOrEmpty(txtpart_no.Text))
            {
                lblpartno.Visible = true;
                lblpartno.Text = "Mã quản lý không được để trống!";
            }
            if (String.IsNullOrEmpty(txtpart_name.Text))
            {
                lblpartname.Visible = true;
                lblpartname.Text = "Tên thiết bị không được để trống!";
            }
            if (String.IsNullOrEmpty(txtsap_barcode.Text))
            {
                lblsapbarcode.Visible = true;
                lblsapbarcode.Text = "SAP barcode không được để trống!";
            }
            if (String.IsNullOrEmpty(txtmodel.Text))
            {
                lblmodel.Visible = true;
                lblmodel.Text = "Mã sản phẩm không được để trống!";
            }
            if (String.IsNullOrEmpty(txtserial.Text))
            {
                lblserial.Visible = true;
                lblserial.Text = "Số serial không được để trống!";

            }
            if (String.IsNullOrEmpty(txtmanufactory.Text))
            {
                lblfactory.Visible = true;
                lblfactory.Text = "Nhà sản xuất không được để trống!";

            }
            if (String.IsNullOrEmpty(txtdept_control.Text))
            {
                lbldepartment.Visible = true;
                lbldepartment.Text = "Bộ phận quản lý không được để trống!";
            }
            if (String.IsNullOrEmpty(txtcontrol_mng.Text))
            {
                lblcontrolman.Visible = true;
                lblcontrolman.Text = "Người quản lý không được để trống!";
            }
            if (String.IsNullOrEmpty(txtpleace_use.Text))
            {
                lblpleaceuse.Visible = true;
                lblpleaceuse.Text = "Nơi sử dụng không được để trống!";
            }
            if (String.IsNullOrEmpty(txtmaker.Text))
            {
                lblCalibrationby.Visible = true;
                lblCalibrationby.Text = "Đơn vị đo không được để trống!";
            }
            if (cbbequip_state.SelectedIndex < 0)
            {
                lblequipment.Visible = true;
                lblequipment.Text = "Tình trạng thiết bị không được để trống!";
            }
            if (String.IsNullOrEmpty(txtrmk.Text))
            {
                lblrmk.Visible = true;
                lblrmk.Text = "Ghi chú không được để trống!";
            }
            if (String.IsNullOrEmpty(txtcycle.Text))
            {
                lblcycle.Visible = true;
                lblcycle.Text = "Chu kỳ hiệu chuẩn không được để trống!";
            }
            if (cbbequip_state.SelectedIndex < 0)
            {
                lblequipment.Text = "Tình trạng thiết bị không được để trống!";
                lblequipment.Visible = true;
            }
            if (String.IsNullOrEmpty(txtline.Text))
            {
                lblline.Visible = true;
                lblline.Text = "Line không được để trống!";
            }
            if (String.IsNullOrEmpty(txtfctno.Text))
            {
                lblfctno.Visible = true;
                lblfctno.Text = "FCT No không được để trống!";
            }
            if (String.IsNullOrEmpty(txtmodelumc.Text))
            {
                lblmodelumc.Visible = true;
                lblmodelumc.Text = "Model thành phẩm không được để trống!";
            }
            else
            {
                return ok = true;
            }
            return ok = false;

        }

        private void btnOpenfile_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Files(.xlsx)|*.xlsx" })
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            lblnamefile.Visible = true;
                            lblnamefile.Text = openFileDialog.FileName.Split('\\').LastOrDefault();
                            using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                    {
                                        UseHeaderRow = true,
                                    }
                                });
                                if (result.Tables.Count > 0)
                                {
                                    var dtData = result.Tables[0];
                                    this.dtgvreaderexcel.DataSource = dtData;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtcycle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;         //Just Digits
            if (e.KeyChar == (char)8) e.Handled = false;            //Allow Backspace

        }

        private void txtsap_barcode_TextChanged(object sender, EventArgs e)
        {
            lblsapbarcode.Visible = false;
            lblsapbarcode.Text = "";
        }

        private void txtpart_name_TextChanged(object sender, EventArgs e)
        {
            lblpartname.Visible = false;
            lblpartname.Text = "";
        }

        private void txtmodel_TextChanged(object sender, EventArgs e)
        {
            lblmodel.Visible = false;
            lblmodel.Text = "";
        }

        private void txtdept_control_TextChanged(object sender, EventArgs e)
        {
            lbldepartment.Visible = false;
            lbldepartment.Text = "";
        }

        private void txtpleace_use_TextChanged(object sender, EventArgs e)
        {
            lblpleaceuse.Visible = false;
            lblpleaceuse.Text = "";
        }

        private void txtcontrol_mng_TextChanged(object sender, EventArgs e)
        {
            lblcontrolman.Visible = false;
            lblcontrolman.Text = "";
        }

        private void txtmaker_TextChanged(object sender, EventArgs e)
        {
            lblCalibrationby.Visible = false;
            lblCalibrationby.Text = "";
        }

        private void txtmanufactory_TextChanged(object sender, EventArgs e)
        {
            lblfactory.Visible = false;
            lblfactory.Text = "";
        }

        private void txtcycle_TextChanged(object sender, EventArgs e)
        {
            lblcycle.Visible = false;
            lblcycle.Text = "";
        }

        private void txtserial_TextChanged(object sender, EventArgs e)
        {
            lblserial.Visible = false;
            lblserial.Text = "";
        }

        private void txtpart_no_TextChanged(object sender, EventArgs e)
        {
            lblpartno.Visible = false;
            lblpartno.Text = "";
        }

        private void txtrmk_TextChanged(object sender, EventArgs e)
        {
            lblrmk.Visible = false;
            lblrmk.Text = "";
        }

        private void cbbequip_state_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblequipment.Visible = false;
            lblequipment.Text = "";
        }

        private void checkboximport_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboximport.Checked == false)
            {
                grboximporthand.Visible = true;
                grboximpportexcel.Visible = false;
                grboximporthand.Location = new Point(5, 155);
                btnOpenfile.Enabled = false;
            }
            else
            {
                grboximpportexcel.Visible = true;
                grboximporthand.Visible = false;
                grboximpportexcel.Size = new Size(893, 404);
                btnOpenfile.Enabled = true;
            }
        }

        private void txtpay_TextChanged(object sender, EventArgs e)
        {
            lblpayment.Visible = false;
            lblpayment.Text = "";
        }

        private void txtline_TextChanged(object sender, EventArgs e)
        {
            lblline.Visible = false;
            lblline.Text = "";
        }

        private void txtfctno_TextChanged(object sender, EventArgs e)
        {
            lblfctno.Visible = false;
            lblfctno.Text = "";
        }

        private void txtmodelumc_TextChanged(object sender, EventArgs e)
        {
            lblmodelumc.Visible = false;
            lblmodelumc.Text = "";
        }
    }
}
