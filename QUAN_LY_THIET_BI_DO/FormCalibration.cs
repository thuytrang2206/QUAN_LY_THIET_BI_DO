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
using QUAN_LY_THIET_BI_DO.Model;
namespace QUAN_LY_THIET_BI_DO
{
    public partial class FormCalibration : Form
    {

        DeviceControl_Model dbContext = new DeviceControl_Model();
        CALIBRATION calibration = new CALIBRATION();
        
        public FormCalibration()
        {
            InitializeComponent();
            Load_Calibration();
            grb_importhand.Size = new Size(501, 340);
            var get_partno= dbContext.CALIBRATIONs.ToList();
            foreach (var item  in get_partno)
            {
                cbbpart_no.Items.Add(item.PART_NO);
                
            }
            cbbpart_no.SelectedIndex = -1;
        }
        public void Load_Calibration()
        {
            dtgvcalibration.DataSource = dbContext.CALIBRATIONs.ToList();

        }

        public bool CheckValueTextBox()
        {
            bool ok;
            //if (String.IsNullOrEmpty(txtPart_no.Text))
            //{
            //    lblpart_no.Visible = true;
            //    lblpart_no.Text = "Mã quản lý không được để trống!";
            //}
            
            //else
            //{
            //    return ok = true;
            //}
            return ok = false;

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (checkboximportexcel.Checked == false)
            {

                var check_part_no = dbContext.DEVICEs.Where(c => c.PART_NO == cbbpart_no.SelectedItem.ToString()).SingleOrDefault();
                if(check_part_no == null)
                {
                    MessageBox.Show("Mã quản lý " + cbbpart_no.SelectedItem.ToString() + "không tồn tại!", "Thông báo");
                }
                else
                {
                    calibration = dbContext.CALIBRATIONs.Find(cbbpart_no.SelectedItem.ToString());
                    calibration.CALI_DATE = dtcali_date.Value;
                    calibration.CALI_RECOMMEND = dtcali_recommend.Value;
                    dbContext.SaveChanges();
                    MessageBox.Show("Lưu thành công!", "Thông báo");

                }

             }
            else
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
                            dbContext.SaveChanges();
                        }

                    }
                    MessageBox.Show("Lưu thành công!", "Thông báo");
                   
                }
            }
            Load_Calibration();
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

                                    this.dtgvimport_excel.DataSource = dtData;
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

        private void cbbpart_no_SelectedIndexChanged(object sender, EventArgs e)
        {
            string partno = cbbpart_no.SelectedItem.ToString();
            var result = dbContext.CALIBRATIONs.Where(x => x.PART_NO==partno).SingleOrDefault();
            if (result == null)
            {
                MessageBox.Show("Mã quản lý " + partno + " không tìm thấy!","Thông báo");
            }
            else
            {              
                    dtcali_date.Value = result.CALI_DATE;
                    dtcali_recommend.Value = result.CALI_RECOMMEND;                
            }
        }

        private void checkboximportexcel_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboximportexcel.Checked == true)
            {
                grbimport_excel.Visible = true;
                grb_importhand.Visible = false;
                grbimport_excel.Location = new Point(486, 152);
                grbimport_excel.Size = new Size(501, 340);
                btnOpenfile.Enabled = true;
            }
            else
            {

                grb_importhand.Visible = true;
                grbimport_excel.Visible = false;
                grb_importhand.Size = new Size(501, 340);
                grb_importhand.Location = new Point(486, 152);
                btnOpenfile.Enabled = false;

            }
        }
    }
}
