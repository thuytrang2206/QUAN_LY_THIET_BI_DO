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
        DEVICE device = new DEVICE();
        CALIBRATION calibration = new CALIBRATION();
        public Form_device()
        {
            InitializeComponent();
            toolStripStatusVersion.Text = Ultils.GetRunningVersion();
        }
        public void Load_data()
        {
            try
            {
                var result = dbcontext.DEVICEs.Where(c => c.STATUS == true).ToList();
                foreach (var item in result)
                {
                    var result_cali = dbcontext.CALIBRATIONs.Where(c => c.PART_NO == item.PART_NO && c.STATUS==true).SingleOrDefault();
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
                            //CALI_DATE = result_cali.CALI_DATE,
                            //CALI_RECOMMEND = result_cali.CALI_RECOMMEND,
                            CALI_NEXT_LASTEST = cali_next,
                            MONTH_YEAR = cali_next.Month.ToString() + "/" + cali_next.Year.ToString(),
                            MAKER = item.MAKER,
                            ENQUIP_STATE = equipment,
                            RMK = item.RMK

                        });
                    }
                }
                dtgv_device.DataSource = list_convert;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
           
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
            //formEditdevice.dtcalibrationdate.Text = this.dtgv_device.CurrentRow.Cells[11].Value.ToString();
            //formEditdevice.dtrecommend_date.Text = this.dtgv_device.CurrentRow.Cells[12].Value.ToString();
            formEditdevice.txtmaker.Text = this.dtgv_device.CurrentRow.Cells[13].Value.ToString();
            if (this.dtgv_device.CurrentRow.Cells[14].Value.ToString() == "OK")
            {
                formEditdevice.cbbequip_state.SelectedIndex = 0;
            }
            else if (this.dtgv_device.CurrentRow.Cells[14].Value.ToString() == "Stop Calibration & Use")
            {
                formEditdevice.cbbequip_state.SelectedIndex = 1;
            }
            else if (this.dtgv_device.CurrentRow.Cells[14].Value.ToString() == "NG chờ sửa")
            {
                formEditdevice.cbbequip_state.SelectedIndex = 2;
            }
            else
            {
                formEditdevice.cbbequip_state.SelectedIndex = 3;
            }
            formEditdevice.txtrmk.Text = this.dtgv_device.CurrentRow.Cells[15].Value.ToString();
            formEditdevice.Show();
           
        }

        private void btnDel_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            List<CONVERT_DEVICE>list_convert_search= new List<CONVERT_DEVICE>() ;
           var result = dbcontext.DEVICEs.Where(x => x.PART_NO.Contains(txtsearch.Text) && x.STATUS==true).ToList();
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

        private void dtgv_device_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void dtgv_device_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    var pos = ((DataGridView)sender).GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                    pos.X += e.X;
                    pos.Y += e.Y;
                    contextMenuStrip1.Show(Control.MousePosition);
             
                }
                catch (Exception)
                {

                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
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
            //formEditdevice.dtcalibrationdate.Text = this.dtgv_device.CurrentRow.Cells[11].Value.ToString();
            //formEditdevice.dtrecommend_date.Text = this.dtgv_device.CurrentRow.Cells[12].Value.ToString();
            formEditdevice.txtmaker.Text = this.dtgv_device.CurrentRow.Cells[13].Value.ToString();
            if (this.dtgv_device.CurrentRow.Cells[14].Value.ToString() == "OK")
            {
                formEditdevice.cbbequip_state.SelectedIndex = 0;
            }
            else if (this.dtgv_device.CurrentRow.Cells[14].Value.ToString() == "Stop Calibration & Use")
            {
                formEditdevice.cbbequip_state.SelectedIndex = 1;
            }
            else if (this.dtgv_device.CurrentRow.Cells[14].Value.ToString() == "NG chờ sửa")
            {
                formEditdevice.cbbequip_state.SelectedIndex = 2;
            }
            else
            {
                formEditdevice.cbbequip_state.SelectedIndex = 3;
            }
            formEditdevice.txtrmk.Text = this.dtgv_device.CurrentRow.Cells[15].Value.ToString();
            formEditdevice.Show();

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Int32 selectedCellCount =
              dtgv_device.GetCellCount(DataGridViewElementStates.Selected);
           
            if (selectedCellCount > 0)
            {
                if (dtgv_device.AreAllCellsSelected(true))
                {
                    MessageBox.Show("All cells are selected", "Selected Cells");
                }
                else
                {
                    System.Text.StringBuilder sb =
                        new System.Text.StringBuilder();
                    StringBuilder ClipboardBuillder = new StringBuilder();
                    for (int i = 0;
                        i < selectedCellCount; i++)
                    {
                        ClipboardBuillder.Append(dtgv_device.Rows[dtgv_device.SelectedCells[i].RowIndex].Cells[dtgv_device.SelectedCells[i].ColumnIndex].Value.ToString() + " ");                 
                    }

                    Clipboard.SetText(ClipboardBuillder.ToString());                   
                }
            }
        }

        private void deletetoolStripMenuItem2_Click(object sender, EventArgs e)
        {
          
            string part_no= this.dtgv_device.CurrentRow.Cells[0].Value.ToString();
            var check_partno= dbcontext.DEVICEs.Where(c=>c.PART_NO==part_no).ToList();
            if (check_partno == null)
            {
                MessageBox.Show("Không tìm thấy mã quản lý: " + this.dtgv_device.CurrentRow.Cells[0].Value.ToString(), "Thông báo");
            }
            else
            {
                device = dbcontext.DEVICEs.Find(this.dtgv_device.CurrentRow.Cells[0].Value.ToString());
                device.STATUS = false;
                calibration = dbcontext.CALIBRATIONs.Find(device.PART_NO);
                calibration.STATUS = false;
                dbcontext.SaveChanges();
                MessageBox.Show("Xóa thành công!", "Thông báo");
                list_convert.Clear();
                dtgv_device.DataSource = null;
                Load_data();
            }
        }       
    }
}
