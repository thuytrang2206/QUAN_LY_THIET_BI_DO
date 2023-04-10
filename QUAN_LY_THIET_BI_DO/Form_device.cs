using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniExcelLibs;
using QUAN_LY_THIET_BI_DO.Business;
using QUAN_LY_THIET_BI_DO.Model;

namespace QUAN_LY_THIET_BI_DO
{
    public partial class Form_device : Form
    {
        DeviceControl_Model dbcontext = new DeviceControl_Model();
        Repository repository = new Repository();
        DEVICE device = new DEVICE();
        CALIBRATION calibration = new CALIBRATION();
        string equipmentStatus = "";
        List<CaliEntity> res = new List<CaliEntity>();
        List<CaliEntity> res_filter;
        public Form_device()
        {
            InitializeComponent();
            toolStripStatusLabel7.Text = Ultils.GetRunningVersion();
            adgv_device.Columns[25].ReadOnly = true;
            this.adgv_device.AutoGenerateColumns = false;
            Load_data();
            //cbboxFilter.SelectedIndex = -1;
        }
        public void Load_data()
        {
            
            res = repository.FindAll();
            this.adgv_device.DataSource = res;
        }
        private void Form_device_Load(object sender, EventArgs e)
        {
            //Load_data();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormTask formTask = new FormTask(this);
            formTask.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormEditdevice formEditdevice = new FormEditdevice(this, this.adgv_device.CurrentRow.Cells[2].Value.ToString());
            formEditdevice.Show();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            var result = repository.SearchPartNo(txtsearch.Text);
            adgv_device.DataSource = result;
        }

        private void adgv_device_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void adgv_device_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
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
            btnEdit_Click(sender, e);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Int32 selectedCellCount = adgv_device.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                StringBuilder ClipboardBuillder = new StringBuilder();
                if (selectedCellCount == 1)
                {
                    ClipboardBuillder.Append(adgv_device.Rows[adgv_device.SelectedCells[0].RowIndex].Cells[adgv_device.SelectedCells[0].ColumnIndex].Value.ToString() + " ");
                }
                else
                {
                    for (int i = selectedCellCount - 1; i >= 0; i--)
                    {
                        ClipboardBuillder.Append(adgv_device.Rows[adgv_device.SelectedCells[i].RowIndex].Cells[adgv_device.SelectedCells[i].ColumnIndex].Value.ToString() + " ");
                    }
                }
                Clipboard.SetText(ClipboardBuillder.ToString());
            }
        }

        private void deletetoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string part_no = this.adgv_device.CurrentRow.Cells[2].Value.ToString();
            var check_partno = dbcontext.DEVICEs.Where(c => c.PART_NO == part_no).ToList();
            if (check_partno == null)
            {
                MessageBox.Show("Không tìm thấy mã quản lý: " + this.adgv_device.CurrentRow.Cells[2].Value.ToString(), "Thông báo");
            }
            else
            {
                device = dbcontext.DEVICEs.Find(this.adgv_device.CurrentRow.Cells[2].Value.ToString());
                device.STATUS = false;
                calibration = dbcontext.CALIBRATIONs.Find(device.PART_NO);
                calibration.STATUS = false;
                dbcontext.SaveChanges();
                MessageBox.Show("Xóa thành công!", "Thông báo");
                adgv_device.DataSource = null;
                Load_data();
            }
        }

        private void adgv_device_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            adgv_device.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var data = new List<CaliEntity>();
            if (checkboxexportall.Checked == true)
            {
                data = repository.FindAll();              
                Opendialog(data);
            }
            else if (checkboxexport_monthyear.Checked == true)
            {
                data = repository.ExportMonthYear(datetime_export.Value);
                adgv_device.DataSource = data;
                if (data.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu bạn muốn xuất ra file excel!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Opendialog(data);
                }
            }
            else if(chboxequipment.Checked==true)
            {
                equipmentStatus = rdOK.Checked == true ? rdOK.Text : (rdNG.Checked == true) ? rdNG.Text : (rdStop.Checked == true) ? rdStop.Text : "";
                if (!String.IsNullOrEmpty(equipmentStatus))
                {
                    data = repository.ExportEquipment(equipmentStatus);
                    Opendialog(data);
                    adgv_device.DataSource = data;
                }
                else
                {
                    MessageBox.Show("Tình trạng thiết bị chưa được chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn đối tượng để xuất file excel!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void Opendialog(List<CaliEntity> caliEntities)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Excel workbook|* .xlsx" })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileInfo = new FileInfo(saveFileDialog.FileName);
                    var path = $@"{fileInfo}";
                    MiniExcel.SaveAs(path, caliEntities);
                    MessageBox.Show("File excel xuất thành công!");
                }
            }
        }

        private void adgv_device_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string localPath = "";
                if (e.ColumnIndex == 23) //2nd column - DGV_ImageColumn
                {
                    string part_no = adgv_device.Rows[e.RowIndex].Cells[2].Value.ToString();
                    var result = repository.Findtopartno_inviewpdf(part_no);
                    if (result.Count() != 0)
                    {
                        foreach (var item in result)
                        {
                            if (item.PDF_FILE != null)
                            {
                                localPath = @"D:\2. Projects\FTP_Root\Cali_Pdf\" + item.PDF_FILE;
                                //localPath = @"\\172.28.10.12\Share\48 DM" + "\\" + result.PDF_FILE;
                                DownloadFiles.DownloadFile(localPath, @"/Cali_Pdf/" + item.PDF_FILE);
                                Views view = new Views(localPath);
                                view.Show();
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Kiểm tra lại mạng kết nối internet!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }

        private void checkboxexportall_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxexportall.Checked == true)
            {
                checkboxexport_monthyear.Checked = false;
            }
        }

        private void checkboxexport_monthyear_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxexport_monthyear.Checked == true)
            {
                checkboxexportall.Checked = false;
            }
        }

        private void adgv_device_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in adgv_device.Rows)
            {
                if (row.Cells[25].Value.ToString().Contains("OK"))
                {
                    row.Cells[25].Style.BackColor = Color.LightGreen;
                }
                else
                {
                    row.Cells[25].Style.BackColor = Color.Salmon;
                }
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            Load_data();
        }

        private void adgv_device_FilterStringChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(adgv_device.FilterString) == true)
                {
                    adgv_device.DataSource = res;
                }
                else
                {
                    string listfilter = FilterStringConvert.FilterStringconverter(adgv_device.FilterString);
                    res_filter = repository.Filter(listfilter);
                    adgv_device.DataSource = res_filter;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " - " + MethodBase.GetCurrentMethod().Name);
            }


        }
        private void adgv_device_SortStringChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(adgv_device.SortString))
                    return;

                if (!string.IsNullOrEmpty(adgv_device.FilterString))
                {
                    // the grid is not filtered!
                    adgv_device.DataSource = res;
                }
                else
                {
                    // the grid is filtered!
                    var sortStr = adgv_device.SortString.Replace("[", "").Replace("]", "");
                    res_filter = repository.FilterSort(sortStr);
                    adgv_device.DataSource = res_filter;
                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " - " + MethodBase.GetCurrentMethod().Name);
            }
        }
        //"t1.EQUIPMENT_STATUS != null and  t1.EQUIPMENT_STATUS LIKE 'Stop cal. 11/2022'and t1.STATUS= 1"
    }
}
