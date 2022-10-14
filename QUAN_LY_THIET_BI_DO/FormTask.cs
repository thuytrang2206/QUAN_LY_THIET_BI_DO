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
using ExcelDataReader;
using QUAN_LY_THIET_BI_DO.Model;

namespace QUAN_LY_THIET_BI_DO
{
    public partial class FormTask : Form
    {
        DeviceControl_Model dbcontext = new DeviceControl_Model();
        //List<DEVICE> device = new List<DEVICE>();
        Form_device form_Device;
        List<CONVERT_DEVICE> list_convert = new List<CONVERT_DEVICE>();
        Task task;
        public FormTask(Form_device form_Device)
        {
            InitializeComponent();
            this.form_Device = form_Device;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdimportexcel.Checked == true)
                {
                    var Result = dtgvreaderexcel.Rows.OfType<DataGridViewRow>().Select(
                    r => r.Cells.OfType<DataGridViewCell>().Select(c => c.Value).ToArray()).ToList();
                    if (Result.Count() == 0)
                    {
                        MessageBox.Show("Xem lại thông tin cần lưu!");
                    }
                    else
                    {
                        
                        foreach (var item in Result)
                        {
                            string part_no = item[2].ToString();
                            var checkpartno = dbcontext.DEVICEs.Where(c => c.PART_NO ==part_no ).SingleOrDefault();
                            if (checkpartno == null)
                            {
                                int equipment_state =0 ;
                                if (item[18].ToString() == "OK")
                                {
                                    equipment_state= Convert.ToInt32(Task.OK);
                                }
                                else if (item[18].ToString() == "NG chờ sửa")
                                {
                                    equipment_state = Convert.ToInt32(Task.NG_Waiting_for_Repair);
                                }
                                else if (item[18].ToString() == "NG hủy")
                                {
                                    equipment_state = Convert.ToInt32(Task.NG_Cancel);
                                }
                                else
                                {
                                    equipment_state = Convert.ToInt32(Task.Stop_Calibration);
                                }

                                var data = new DEVICE()
                                {
                                    PART_NO = item[2].ToString(),
                                    PART_NAME = item[4].ToString(),
                                    SAP_BARCODE = item[3].ToString(),
                                    MODEL = item[5].ToString(),
                                    SERIAL = item[6].ToString(),
                                    MANUFACTORY = item[7].ToString(),
                                    CALI_CYCLE = int.Parse(item[8].ToString()),
                                    REGISTRATION_DATE = Convert.ToDateTime(item[9].ToString()),
                                    DEPT_CONTROL = item[10].ToString(),
                                    PLACE_USE = item[11].ToString(),
                                    CONTROL_MNG = item[12].ToString(),
                                    ENQUIP_STATE = equipment_state,
                                    MAKER = item[17].ToString(),
                                    RMK = item[19].ToString(),
                                };

                                dbcontext.DEVICEs.Add(data);
                                var data_cali = new CALIBRATION()
                                {
                                    PART_NO = item[2].ToString(),
                                    CALI_DATE = Convert.ToDateTime(item[13].ToString()),
                                    CALI_RECOMMEND = Convert.ToDateTime(item[14].ToString()),
                                };
                                dbcontext.CALIBRATIONs.Add(data_cali);
                                dbcontext.SaveChanges();
                            }
                            else
                            {
                                MessageBox.Show("Mã quản lý " + item[2].ToString() + " đã có trong database!", "Thông báo");
                            }
                            
                        }
                        

                    }
                }
                else
                {
                    if (CheckValueTextBox() == true)
                    {
                        var check_part_no = dbcontext.DEVICEs.Where(c => c.PART_NO == txtpart_no.Text).SingleOrDefault();
                        if (check_part_no == null)
                        {
                            var data = new DEVICE()
                            {
                            PART_NO = txtpart_no.Text,
                            PART_NAME = txtpart_name.Text,
                            SAP_BARCODE = txtsap_barcode.Text,
                            MODEL = txtmodel.Text,
                            SERIAL = txtserial.Text,
                            MANUFACTORY = txtmanufactory.Text,
                            CALI_CYCLE = int.Parse(txtcycle.Text),
                            REGISTRATION_DATE = Convert.ToDateTime(dateTimePicker1.Text),
                            DEPT_CONTROL = txtdept_control.Text,
                            PLACE_USE = txtpleace_use.Text,
                            CONTROL_MNG = txtcontrol_mng.Text,
                            MAKER = txtmaker.Text,
                            ENQUIP_STATE = cbbequip_state.SelectedIndex,
                            RMK = txtrmk.Text
                            };
                            dbcontext.DEVICEs.Add(data);
                            var data_cali = new CALIBRATION()
                            {
                                PART_NO = txtpart_no.Text,
                                CALI_DATE = Convert.ToDateTime(dateTimePicker2.Text),
                                CALI_RECOMMEND = Convert.ToDateTime(dateTimePicker3.Text),
                            };                            
                            dbcontext.CALIBRATIONs.Add(data_cali);
                            dbcontext.SaveChanges();
                            MessageBox.Show("Lưu thành công!", "Thông báo");
                            
                        }
                        else
                        {
                            MessageBox.Show("Mã quản lý "+txtpart_no.Text+"đã có trong database!", "Thông báo");
                        }
                        
                    }
                    
                }
                this.Hide();
                Reload_datawhencreate();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
           
        }
        public void Reload_datawhencreate()
        {
            var result = dbcontext.DEVICEs.ToList();
            foreach (var item in result)
            {
                var result_cali = dbcontext.CALIBRATIONs.Where(c => c.PART_NO == item.PART_NO).SingleOrDefault();
          
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
            form_Device.dtgv_device.DataSource = list_convert;
        }
        public bool CheckValueTextBox()
        {
            bool ok;
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
            if (cbbequip_state.SelectedValue==null)
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
            else
            {
                return ok= true;
            }
            return ok=false;

        }

        private void txtpayment_Validating(object sender, CancelEventArgs e)
        {

        }
        private void btnOpenfile_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Files(.xlsx)|*.xlsx" })
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                        {
                            lblnamefile.Visible = true;
                            lblnamefile.Text = openFileDialog.FileName.Split('\\').LastOrDefault();

                            using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                    {// Gets or sets a value indicating whether to use a row from the 
                                     // data as column names.
                                        UseHeaderRow = true,

                                        // Gets or sets a callback to determine which row is the header row. 
                                        // Only called when UseHeaderRow = true.
                                        //ReadHeaderRow = (rowReader) => {
                                        //    // F.ex skip the first row and use the 2nd row as column headers:
                                        //    rowReader.Read();
                                        //},
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

        private void FormTask_Load(object sender, EventArgs e)
        {

        }

        private void btnAddHander_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            btnOpenfile.Enabled = false;
        }
        public void Restart()
        {
            btnOpenfile.Enabled = true;
            groupBox1.Visible = false;
        }
        private void rdHander_CheckedChanged(object sender, EventArgs e)
        {
            if (rdHander.Checked == true)
            {
                groupBox1.Visible = true;
                rdimportexcel.Checked = false;
                groupBox7.Visible = false;
                groupBox1.Location = new Point(5, 155);
                btnOpenfile.Enabled = false;
            }
            
        }

        private void rdimportexcel_CheckedChanged(object sender, EventArgs e)
        {
            if (rdimportexcel.Checked == true)
            {
                groupBox7.Visible = true;
                rdimportexcel.Checked = true;
                groupBox1.Visible = false;
                groupBox7.Size = new Size(893, 404);
                btnOpenfile.Enabled = true;
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

        private void cbbequip_state_Click(object sender, EventArgs e)
        {
            lblequipment.Visible = false;
            lblequipment.Text = "";
        }
    }
}
