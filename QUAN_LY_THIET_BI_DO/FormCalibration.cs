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
using QUAN_LY_THIET_BI_DO.Business;
using QUAN_LY_THIET_BI_DO.Model;
namespace QUAN_LY_THIET_BI_DO
{
    public partial class FormCalibration : Form
    {

        DeviceControl_Model dbContext = new DeviceControl_Model();
        CALIBRATION calibration = new CALIBRATION();
        Repository repository = new Repository();
        HISTORY_CALIBRATION history = new HISTORY_CALIBRATION();
        DataTable tableDevice;
        public FormCalibration()
        {
            InitializeComponent();
            Load_Calibration();           
            var get_partno= dbContext.CALIBRATIONs.Where(c=>c.STATUS==true).ToList();
            foreach (var item  in get_partno)
            {
                cbbpart_no.Items.Add(item.PART_NO);
                
            }
            cbbpart_no.SelectedIndex = -1;
            cbbpart_no.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbbpart_no.AutoCompleteSource = AutoCompleteSource.ListItems;
           
            
        }
        public void Load_Calibration()
        {
            var result = repository.List_Calibration();
            dtgvcalibration.DataSource = result;
            dtgvcalibration.Columns["STATUS"].Visible = false;
        }


        private void btn_save_Click(object sender, EventArgs e)
        {
            //if (tabControl.SelectedTab==im)
            //{
                if (cbbpart_no.SelectedIndex < 0)
                {
                    lblpart_no.Text = "Mã quản lý không được để trống!";
                    lblpart_no.Visible = true;
                }
                else
                {
                    var check_part_no = dbContext.DEVICEs.Where(c => c.PART_NO == cbbpart_no.SelectedItem.ToString()).SingleOrDefault();
                    if (check_part_no == null)
                    {
                        MessageBox.Show("Mã quản lý " + cbbpart_no.SelectedItem.ToString() + "không tồn tại!", "Thông báo");
                    }
                    else
                    {
                        calibration = dbContext.CALIBRATIONs.Find(cbbpart_no.SelectedItem.ToString());
                        //calibration.CALI_DATE = dtcali_dateimport.Value;
                        //calibration.CALI_RECOMMEND = dtcali_recommendimport.Value;
                        calibration.STATUS = true;
                        dbContext.SaveChanges();
                        MessageBox.Show("Lưu thành công!", "Thông báo");                        
                    }
                }
            //}
            //else
            //{
                
            //}
            Load_Calibration();
        }
        DataTableCollection tableCollection;
        private async void btnOpenfile_Click(object sender, EventArgs e)
        {
            var response = await ExcelHelper.ImportExcelToDataTableAsync();
            if (response?.DATA == null) return;
            tableCollection = response.DATA;
            cbbsheet.Items.Clear();
            foreach (DataTable table in tableCollection)
            {
                cbbsheet.Items.Add(table.TableName);
                cbbsheet.SelectedIndex = 0;
            }
            lblnamefile.Visible = true;
            lblnamefile.Text = response.URI;
            //try
            //{
            //    using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Files(.xlsx)|*.xlsx" })
            //    {
            //        if (openFileDialog.ShowDialog() == DialogResult.OK)
            //        {
            //            using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            //            {
            //                lblnamefile.Visible = true;
            //                lblnamefile.Text = openFileDialog.FileName.Split('\\').LastOrDefault();

            //                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
            //                {
            //                    DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
            //                    {
            //                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
            //                        {// Gets or sets a value indicating whether to use a row from the 
            //                         // data as column names.
            //                            UseHeaderRow = true,

            //                            // Gets or sets a callback to determine which row is the header row. 
            //                            // Only called when UseHeaderRow = true.
            //                            //ReadHeaderRow = (rowReader) => {
            //                            //    // F.ex skip the first row and use the 2nd row as column headers:
            //                            //    rowReader.Read();
            //                            //},
            //                        }
            //                    });
            //                    if (result.Tables.Count > 0)
            //                    {
            //                        var dtData = result.Tables[0];
            //                        this.dtgvimport_excel.DataSource = dtData;
            //                        this.dtgvimport_excel.Visible = true;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void cbbpart_no_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblpart_no.Visible = false;
            lblpart_no.Text = "";
            string partno = cbbpart_no.SelectedItem.ToString();
            var result =repository.Search_cbbox(partno);
            var result_history = repository.Findhistory(partno);
            if (result == null)
            {
                MessageBox.Show("Mã quản lý " + partno + " không tìm thấy!", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                dtgvcalibration.DataSource = result ;
                foreach( var item in result)
                {
                    dtcali_date.Value = item.CALI_DATE;
                    dtcali_recommend.Value = item.CALI_RECOMMEND;
                }            
                dtgv_his.DataSource = result_history;
                dtgv_his.Columns["ID"].Visible = false;
            }
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (chkbox_donecheck.Checked )
            {
                calibration = dbContext.CALIBRATIONs.Find(cbbpart_no.SelectedItem.ToString());
                var result_device = repository.SearchPartNo(cbbpart_no.SelectedItem.ToString());
                foreach(var item in result_device)
                {
                    calibration.CALI_DATE =DateTime.Parse(DateTime.Now.AddMonths(item.CALI_CYCLE).ToString("dd/MM/yyyy"));
                    calibration.CALI_RECOMMEND = DateTime.Parse(calibration.CALI_DATE.ToString("dd/MM/yyyy")).AddDays(-1);
                    var itemdb = new HISTORY_CALIBRATION
                    {
                        PART_NO = item.PART_NO,
                        PART_NAME= item.PART_NAME,
                        SERIAL = item.SERIAL,
                        DATE_CHECK = DateTime.Now
                    };
                    dbContext.HISTORY_CALIBRATIONs.Add(itemdb);
                    dbContext.SaveChanges();
                }
                Load_Calibration();
                cbbpart_no_SelectedIndexChanged(sender, e);
                chkbox_donecheck.Checked = false;
            }
        }

        private void cbbox_import_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string partno = cbbox_import.SelectedItem.ToString();
            //var result = repository.Search_cbbox(partno);
            //if (result == null)
            //{
            //    MessageBox.Show("Mã quản lý " + partno + " không tìm thấy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            //{
            //    dtgvcalibration.DataSource = result;
            //    foreach (var item in result)
            //    {
            //        dtcali_dateimport.Value = item.CALI_DATE;
            //        dtcali_recommendimport.Value = item.CALI_RECOMMEND;
            //    }
            //}
        }

        private void btn_saveimport_Click(object sender, EventArgs e)
        {
            var Result = dtgvimport_excel.Rows.OfType<DataGridViewRow>().Select(
               r => r.Cells.OfType<DataGridViewCell>().Select(c => c.Value).ToArray()).ToList();
            if (Result.Count() == 0)
            {
                MessageBox.Show("Xem lại thông tin cần lưu!");
            }
            else
            {
                foreach (var item in Result)
                {
                    string part_no = item[0].ToString();
                    var checkpartno = dbContext.CALIBRATIONs.Where(c => c.PART_NO == part_no).SingleOrDefault();
                    if (checkpartno == null)
                    {
                        MessageBox.Show("Mã quản lý " + part_no + "không tìm thấy", "Thông báo");
                    }
                    else
                    {
                        calibration = dbContext.CALIBRATIONs.Find(item[0].ToString());
                        calibration.CALI_DATE = Convert.ToDateTime(item[1].ToString());
                        calibration.CALI_RECOMMEND = Convert.ToDateTime(item[2].ToString());
                        calibration.STATUS = true;
                        var result_device = repository.SearchPartNo(item[0].ToString());
                        foreach(var item_device in result_device)
                        {
                            var itemdb = new HISTORY_CALIBRATION
                            {
                                PART_NO = item_device.PART_NO,
                                PART_NAME = item_device.PART_NAME,
                                SERIAL = item_device.SERIAL,
                                DATE_CHECK = Convert.ToDateTime(item[1].ToString())
                            };
                            dbContext.HISTORY_CALIBRATIONs.Add(itemdb);
                        }                        
                        dbContext.SaveChanges();
                    }
                }
                MessageBox.Show("Lưu thành công!", "Thông báo");
                dtgvimport_excel.DataSource = null;
                lblnamefile.Text = "";
            }
        }

        private void cbbsheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            tableDevice = tableCollection[cbbsheet.SelectedItem.ToString()];
            dtgvimport_excel.DataSource = tableDevice;
        }
    }
}
