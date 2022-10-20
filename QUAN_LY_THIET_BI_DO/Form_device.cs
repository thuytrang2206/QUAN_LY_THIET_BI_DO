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
    public partial class Form_device : Form
    {
        DeviceControl_Model dbcontext = new DeviceControl_Model();
        Repository repository = new Repository();
        DEVICE device = new DEVICE();
        CALIBRATION calibration = new CALIBRATION();
        public Form_device()
        {
            InitializeComponent();
            toolStripStatusVersion.Text = Ultils.GetRunningVersion();
            this.dtgv_device.AutoGenerateColumns = false;
        }
        public void Load_data()
        {
            var res =  repository.FindAll();
            this.dtgv_device.DataSource = res;
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
            FormEditdevice formEditdevice = new FormEditdevice(this, this.dtgv_device.CurrentRow.Cells[2].Value.ToString());
            formEditdevice.Show();          
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
       {
            var result = repository.Search(txtsearch.Text);
            dtgv_device.DataSource = result;
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
            btnEdit_Click(sender, e);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Int32 selectedCellCount =dtgv_device.GetCellCount(DataGridViewElementStates.Selected);          
            if (selectedCellCount > 0)
            {
                StringBuilder ClipboardBuillder = new StringBuilder();
                if (selectedCellCount == 1)
                {
                    ClipboardBuillder.Append(dtgv_device.Rows[dtgv_device.SelectedCells[0].RowIndex].Cells[dtgv_device.SelectedCells[0].ColumnIndex].Value.ToString() + " ");
                }
                else
                {
                    for (int i = selectedCellCount-1; i >=0; i--)
                    {
                        ClipboardBuillder.Append(dtgv_device.Rows[dtgv_device.SelectedCells[i].RowIndex].Cells[dtgv_device.SelectedCells[i].ColumnIndex].Value.ToString() + " ");                 
                    }                                    
                }
                Clipboard.SetText(ClipboardBuillder.ToString());
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
                dtgv_device.DataSource = null;
                Form_device_Load(sender, e);
            }
        }

        private void dtgv_device_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dtgv_device.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
           
            using (SaveFileDialog saveFileDialog= new SaveFileDialog() { Filter="Excel workbook|* .xlsx"})
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    var fileInfo = new FileInfo(saveFileDialog.FileName);
                    try
                    {
                        Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                        Microsoft.Office.Interop.Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);
                        System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.CurrentCulture;
                        for (int i = 1; i < dtgv_device.Columns.Count + 1; i++)
                        {
                            app.Cells[1, i] = dtgv_device.Columns[i - 1].HeaderText;
                        }
                        for (int i = 0; i < dtgv_device.Rows.Count; i++)
                        {
                            for (int j = 0; j < dtgv_device.Columns.Count; j++)
                            {
                                app.Cells[i + 2, j + 1] = dtgv_device.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                        workbook.SaveAs(fileInfo, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        app.Quit();
                    }
                    catch
                    {

                    }
                }
            }    
        }

        
    }
}
