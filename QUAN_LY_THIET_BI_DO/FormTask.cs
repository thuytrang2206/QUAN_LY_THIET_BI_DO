using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;
using QUAN_LY_THIET_BI_DO.Business;
using QUAN_LY_THIET_BI_DO.Model;
using VBSQLHelper;

namespace QUAN_LY_THIET_BI_DO
{
    public partial class FormTask : Form
    {
        DeviceControl_Model dbcontext = new DeviceControl_Model();
        Form_device form_Device;
        CALIBRATION calibration = new CALIBRATION();
        DEVICE device = new DEVICE();
        Repository repository = new Repository();
        List<ListPartNo> listPartNo = new List<ListPartNo>();
        DataTable tableDevice;
        public FormTask(Form_device form_Device)
        {
            InitializeComponent();
            this.form_Device = form_Device;
            grboximpportexcel.Size = new Size(893, 404);

        }
        
        private  void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkboximport.Checked == true)
                {
                    if (listPartNo.Count != 0)
                    {
                        var set = new HashSet<string>();
                        //Kiểm tra file import có part_no nào trùng hay không
                        var filterduplicatepartno = listPartNo.Where(x => !set.Add(x.PART_NO)).ToList();
                        if (filterduplicatepartno.Count > 0)
                        {
                            MessageBox.Show("Mã quản lý: " + filterduplicatepartno.Select(inc => inc.PART_NO).Aggregate((buffer, next) => buffer + "," + next.ToString()) + " trong file excel đang bị trùng", "Thông báo");
                        }
                        else
                        {
                            if (listPartNo.Count() == 0)
                            {
                                MessageBox.Show("Bạn chưa chọn file excel để nhập thông tin!");
                            }
                            else
                            {
                                foreach (var item in listPartNo)
                                {
                                    string part_no = item.PART_NO;
                                    if (part_no != "")
                                    {
                                        var checkpartno = dbcontext.DEVICEs.Where(c => c.PART_NO == part_no).SingleOrDefault();
                                        if (checkpartno == null)
                                        {
                                            var data = new DEVICE()
                                            {
                                                PAYMENT = item.PAYMENT == "" ? "." : item.PAYMENT,
                                                PART_NO = item.PART_NO,
                                                PART_NAME = item.PART_NAME == "" ? "." : item.PART_NAME,
                                                SAP_BARCODE = item.SAP_BARCODE == "" ? "." : item.SAP_BARCODE,
                                                MODEL = item.MODEL == "" ? "." : item.MODEL,
                                                SERIAL = item.SERIAL == "" ? "." : item.SERIAL,
                                                MANUFACTORY = item.MANUFACTORY == "" ? "." : item.MANUFACTORY,
                                                CALI_CYCLE = int.Parse(item.CALI_CYCLE.ToString()),
                                                REGISTRATION_DATE = Convert.ToDateTime(item.REGISTRATION_DATE),
                                                DEPT_CONTROL = item.DEPT_CONTROL == "" ? "." : item.DEPT_CONTROL,
                                                PLACE_USE = item.PLACE_USE == "" ? "." : item.PLACE_USE,
                                                CONTROL_MNG = item.CONTROL_MNG == "" ? "." : item.CONTROL_MNG,
                                                ENQUIP_STATE = item.ENQUIP_STATE == "" ? "." : item.ENQUIP_STATE,
                                                MAKER = item.MAKER == "" ? "." : item.MAKER,
                                                RMK = item.RMK == "" ? "." : item.RMK,
                                                LINE = item.LINE == "" ? "." : item.LINE,
                                                FCT_NO = item.FCT_NO == "" ? "." : item.FCT_NO,
                                                MODEL_UMC = item.MODEL_UMC == "" ? "." : item.MODEL_UMC,
                                                STATUS = true,
                                            };
                                            dbcontext.DEVICEs.Add(data);
                                            var data_cali = new CALIBRATION()
                                            {
                                                PART_NO = item.PART_NO,
                                                CALI_DATE = Convert.ToDateTime(item.CALI_DATE),
                                                CALI_RECOMMEND = Convert.ToDateTime(item.CALI_RECOMMEND),
                                                STATUS = true,
                                            };
                                            dbcontext.CALIBRATIONs.Add(data_cali);
                                            dbcontext.SaveChanges();
                                        }
                                        // part_no đã có trong csdl=>sửa dữ liệu theo item file excel
                                        else
                                        {
                                            device = dbcontext.DEVICEs.Find(item.PART_NO);
                                            device.PAYMENT = item.PAYMENT == "" ? "." : item.PAYMENT;
                                            device.SAP_BARCODE = item.SAP_BARCODE == "" ? "." : item.SAP_BARCODE;
                                            device.PART_NAME = item.PART_NAME == "" ? "." : item.PART_NAME;
                                            device.MODEL = item.MODEL == "" ? "." : item.MODEL;
                                            device.SERIAL = item.SERIAL == "" ? "." : item.SERIAL;
                                            device.MANUFACTORY = item.MANUFACTORY == "" ? "." : item.MANUFACTORY;
                                            device.CALI_CYCLE = int.Parse(item.CALI_CYCLE.ToString());
                                            device.REGISTRATION_DATE = Convert.ToDateTime(item.REGISTRATION_DATE);
                                            device.DEPT_CONTROL = item.DEPT_CONTROL == "" ? "." : item.DEPT_CONTROL;
                                            device.PLACE_USE = item.PLACE_USE == "" ? "." : item.PLACE_USE;
                                            device.CONTROL_MNG = item.CONTROL_MNG == "" ? "." : item.CONTROL_MNG;
                                            device.MAKER = item.MAKER == "" ? "." : item.MAKER;
                                            device.ENQUIP_STATE = item.ENQUIP_STATE == "" ? "." : item.ENQUIP_STATE;
                                            device.RMK = item.RMK == "" ? "." : item.RMK;
                                            device.LINE = item.LINE == "" ? "." : item.LINE;
                                            device.FCT_NO = item.FCT_NO == "" ? "." : item.FCT_NO;
                                            device.MODEL_UMC = item.MODEL_UMC == "" ? "." : item.MODEL_UMC;
                                            device.STATUS = true;
                                            calibration = dbcontext.CALIBRATIONs.Find(item.PART_NO);
                                            calibration.CALI_DATE = Convert.ToDateTime(item.CALI_DATE);
                                            calibration.CALI_RECOMMEND = Convert.ToDateTime(item.CALI_RECOMMEND);
                                            calibration.STATUS = true;
                                            dbcontext.SaveChanges();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Mã quản lý của file import đang để trống. Vui lòng điền mã quản lý để import thành công!", "Thông báo");
                                    }
                                }
                                MessageBox.Show("Lưu thành công!", "Thông báo");
                                this.Hide();
                                Reload_datawhencreate();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("File excel để nhập dữ liệu không đúng định dạng. Vui lòng xem lại file!", "Thông báo");
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
                                PAYMENT = txtpay.Text,
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
                                ENQUIP_STATE = txtequip_status.Text,
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
                            MessageBox.Show("Lưu thành công!", "Thông báo");
                            this.Hide();
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
                                device.ENQUIP_STATE = txtequip_status.Text;
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
                                MessageBox.Show("Lưu thành công!", "Thông báo");
                                this.Hide();
                                Reload_datawhencreate();
                            }
                        }
                    }
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
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
            if (String.IsNullOrEmpty(txtequip_status.Text))
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
        DataTableCollection tableCollection;
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
                                     //var dtData = result.Tables[0];
                                    //this.dtgvreaderexcel.DataSource = dtData;
                                    tableCollection = result.Tables;
                                    cbbsheet.Items.Clear();
                                    foreach (DataTable table in tableCollection)
                                    {
                                        cbbsheet.Items.Add(table.TableName);
                                        cbbsheet.SelectedIndex = 0;
                                    }
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
        DataTable dt;
        private void cbbsheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = tableCollection[cbbsheet.SelectedItem.ToString()];
            dtgvreaderexcel.DataSource = dt;
            var Result = dtgvreaderexcel.Rows.OfType<DataGridViewRow>().Select(
                   r => r.Cells.OfType<DataGridViewCell>().Select(c => c.Value).ToArray()).ToList();
            if (((DataTable)this.dtgvreaderexcel.DataSource).Columns.Count >= 23)
            {
                listPartNo.Clear();
                foreach (var data in Result)
                {
                    listPartNo.Add(new ListPartNo
                    {
                        PAYMENT = data[1].ToString(),
                        PART_NO = data[2].ToString(),
                        PART_NAME = data[4].ToString(),
                        SAP_BARCODE = data[3].ToString(),
                        MODEL = data[5].ToString(),
                        SERIAL = data[6].ToString(),
                        MANUFACTORY = data[7].ToString(),
                        CALI_CYCLE = int.Parse(data[8].ToString()),
                        REGISTRATION_DATE = Convert.ToDateTime(data[9].ToString()),
                        DEPT_CONTROL = data[10].ToString(),
                        PLACE_USE = data[11].ToString(),
                        CONTROL_MNG = data[12].ToString(),
                        CALI_DATE = Convert.ToDateTime(data[13].ToString()),
                        CALI_RECOMMEND = Convert.ToDateTime(data[14].ToString()),
                        MAKER = data[17].ToString(),
                        ENQUIP_STATE = data[18].ToString(),
                        RMK = data[19].ToString(),
                        LINE = data[20].ToString(),
                        FCT_NO = data[21].ToString(),
                        MODEL_UMC = data[22].ToString(),
                    });
                }
                var checkpartNonotnull = listPartNo.Where(x => x.PART_NO == "").ToList();
                if (checkpartNonotnull.Count != 0)
                {
                    MessageBox.Show("Mã quản lý không được để trống! Vui lòng xem lại thông tin của file excel!");
                    listPartNo.Clear();
                }
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
