using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        Form_device form_Device;
        CALIBRATION calibration = new CALIBRATION();
        DEVICE device = new DEVICE();
        Repository repository = new Repository();
        DataTable tableDevice;
        public FormTask(Form_device form_Device)
        {
            InitializeComponent();
            this.form_Device = form_Device;
            grboximpportexcel.Size = new Size(893, 404);

        }
       
        private string CreateTypeUserDefinedSQL(List<ItemTable> itemTables, string tablename)
        {
            string filename_datatype;
            var temp = new List<string>();
            foreach (var item in itemTables)
            {

                if (item.Caption == "Part no")
                {
                    item.Key = true;
                }
                if (item.Key) // primary key
                {
                    if (string.IsNullOrEmpty(item.Length))
                    {
                        filename_datatype = $"[{item.FieldName}][{item.DataType.ToUpper()}] NOT NULL";
                    }
                    else
                    {
                        filename_datatype = $"[{item.FieldName}][{item.DataType.ToUpper()}]({item.Length}) NOT NULL";
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(item.Length))
                    {
                        filename_datatype = $"[{item.FieldName}][{item.DataType.ToUpper()}]";
                    }
                    else
                    {
                        filename_datatype = $"[{item.FieldName}][{item.DataType.ToUpper()}]({item.Length})";
                    }

                    if (item.AllowNull)
                    {
                        filename_datatype += " NULL";
                    }
                    else
                    {
                        filename_datatype += " NOT NULL";
                    }
                }
                temp.Add(filename_datatype);
            }           

            // end add default 
            var item_fieldname = string.Join(", \n\t", temp);
            
            var result = $@"CREATE TYPE [dbo].[udt_{tablename}] AS TABLE
                        ({item_fieldname}); ";
            return result;
        }

        private string CreateProcedureSQL(List<ItemTable> itemTables, string tablename)
        {
            var list_primarykey = itemTables.Where(x => x.Key == true).ToList();
            var list_temp = new List<string>();
            foreach (var item in list_primarykey)
            {
                var itemJoin = $"[Source].[{item.FieldName}] = [Target].[{item.FieldName}]";
                list_temp.Add(itemJoin);
            }
            var item_join_text = string.Join(" AND ", list_temp);
            
            var list_item_fieldname_insert_device = itemTables.Select(x => $"[{x.FieldName}]").ToList();
            var item_fieldname_text = string.Join(",\n\t", list_item_fieldname_insert_device)+ ",\n[STATUS]";

            var list_item_fieldname_text_source = itemTables.Select(x => $"[Source].[{x.FieldName}]").ToList();
            var item_fieldname_text_source = string.Join(",\n\t", list_item_fieldname_text_source)+",\n1";
                        
            var list_item_fieldname_update_text_source = itemTables.Where(x => x.Key == false).Select(x => $"[Target].[{x.FieldName}] = [Source].[{x.FieldName}]").ToList();

            var item_fieldname_update_text_source = string.Join(",\n\t", list_item_fieldname_update_text_source);

            var result = $@"CREATE PROC [dbo].[sp_{tablename}]
                            (
                                @Data AS [dbo].[udt_{tablename}] READONLY                              
                            )
                            AS
                            BEGIN
                                MERGE [dbo].[DEVICE] AS [Target]
                                USING @Data AS [Source]
                                ON {item_join_text}
                                -- For Inserts
                                WHEN NOT MATCHED BY TARGET THEN
                                    INSERT
                                    ({item_fieldname_text})
                                    VALUES
                                    ({item_fieldname_text_source})
                                -- For Updates
                                WHEN MATCHED THEN
                                    UPDATE SET {item_fieldname_update_text_source} ;
                            END;
                            ";
            return result;
        }

        private string CreateTypeUserDefinedSQL_Calibration(List<ItemTable> itemTables, string tablename)
        {
            string filename_datatype;
            var temp = new List<string>();
            foreach (var item in itemTables)
            {

                if (item.Caption == "Part no")
                {
                    item.Key = true;
                }
                if (item.Key) // primary key
                {
                    if (string.IsNullOrEmpty(item.Length))
                    {
                        filename_datatype = $"[{item.FieldName}][{item.DataType.ToUpper()}] NOT NULL";
                    }
                    else
                    {
                        filename_datatype = $"[{item.FieldName}][{item.DataType.ToUpper()}]({item.Length}) NOT NULL";
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(item.Length))
                    {
                        filename_datatype = $"[{item.FieldName}][{item.DataType.ToUpper()}]";
                    }
                    else
                    {
                        filename_datatype = $"[{item.FieldName}][{item.DataType.ToUpper()}]({item.Length})";
                    }

                    if (item.AllowNull)
                    {
                        filename_datatype += " NULL";
                    }
                    else
                    {
                        filename_datatype += " NOT NULL";
                    }
                }
                temp.Add(filename_datatype);
            }

            // end add default 
            var item_fieldname = string.Join(", \n\t", temp);

            var result = $@"CREATE TYPE [dbo].[udt_{tablename}] AS TABLE
                        ({item_fieldname}                            
                        ); ";
            return result;
        }

        private string CreateProcedureSQL_Calibration(List<ItemTable> itemTables, string tablename)
        {
            var list_primarykey = itemTables.Where(x => x.Key == true).ToList();
            var list_temp = new List<string>();
            foreach (var item in list_primarykey)
            {
                var itemJoin = $"[Source].[{item.FieldName}] = [Target].[{item.FieldName}]";
                list_temp.Add(itemJoin);
            }
            var item_join_text = string.Join(" AND ", list_temp);

            var list_item_fieldname_insert_device = itemTables.Select(x => $"[{x.FieldName}]").ToList();
            var item_fieldname_text = string.Join(",\n\t", list_item_fieldname_insert_device) +",\n[STATUS]";
            var list_item_fieldname_text_source = itemTables.Select(x => $"[Source].[{x.FieldName}]").ToList();
            var item_fieldname_text_source = string.Join(",\n\t", list_item_fieldname_text_source) + ",\n1";
            var list_item_fieldname_update_text_source = itemTables.Where(x => x.Key == false).Select(x => $"[Target].[{x.FieldName}] = [Source].[{x.FieldName}]").ToList();

            var item_fieldname_update_text_source = string.Join(",\n\t", list_item_fieldname_update_text_source);

            var result = $@"CREATE PROC [dbo].[sp_{tablename}]
                            (
                                @Data AS [dbo].[udt_{tablename}] READONLY                              
                            )
                            AS
                            BEGIN
                                MERGE [dbo].[CALIBRATION] AS [Target]
                                USING @Data AS [Source]
                                ON {item_join_text}
                                -- For Inserts
                                WHEN NOT MATCHED BY TARGET THEN
                                    INSERT
                                    ({item_fieldname_text})
                                    VALUES
                                    ({item_fieldname_text_source})
                                -- For Updates
                                WHEN MATCHED THEN
                                    UPDATE SET {item_fieldname_update_text_source} ;
                            END;
                            ";
            return result;
        }
        private async void btn_save_Click(object sender, EventArgs e)
        {
            var data = dtgrtoconvert.DataSource as List<ItemTable>;
            var data_calibration =new List<ItemTable>();
            foreach (var item in data.ToList())
            {
                if(item.FieldName == "PART_NO")
                {
                    data_calibration.Add(item);
                }
                if (item.FieldName == "CALI_DATE" || item.FieldName == "CALI_RECOMMEND" )
                {
                    data_calibration.Add(item);
                    data.Remove(item);
                }
                else if(  item.FieldName == "NEXT_CALIBRATION_LATEST" || item.FieldName == "MONTH_YEAR")
                {
                    data.Remove(item);
                }
            
            }
            if (data.Count() >= 18)
            {
                string table_name_device = tableDevice.TableName + DateTime.Now.ToString("ddMMyyyyHHmmss");
                //insert table DEVICE
                // create Type user defined
                var sql_type_user_defined = CreateTypeUserDefinedSQL(data, table_name_device);
                // create Store Procedure
                var sql_store_procedure = CreateProcedureSQL(data, table_name_device);
                SQLHelper.ExecQueryNonData(sql_type_user_defined.Trim());
                SQLHelper.ExecQueryNonData(sql_store_procedure.Trim());

                //insert table CALIBRATION
                string table_name_calibration = tableDevice.TableName+"_Cali"+ DateTime.Now.ToString("ddMMyyyyHHmmss");
                var sql_type_user_defined_calibration = CreateTypeUserDefinedSQL_Calibration(data_calibration, table_name_calibration);
                var sql_store_procedure_calibration = CreateProcedureSQL_Calibration(data_calibration, table_name_calibration);
                SQLHelper.ExecQueryNonData(sql_type_user_defined_calibration.Trim());
                SQLHelper.ExecQueryNonData(sql_store_procedure_calibration.Trim());
                try
                {                   
                    var arrayNamesColumn = (from DataColumn x in tableDevice.Columns.Cast<DataColumn>() select x.ColumnName).ToArray();
                    var getnamecolumndevicedelete =new  List<string>();
                    var getnamecolumncalibration= new List<string>();
                    for (int i = 0; i < arrayNamesColumn.Count(); i++)
                    {
                        if (i==0 || i == 13 || i == 14 || i == 15 || i == 16)
                        {
                            getnamecolumndevicedelete.Add(arrayNamesColumn[i]);
                        }
                        if (i != 2&& i != 13&& i != 14)
                        {
                            getnamecolumncalibration.Add(arrayNamesColumn[i]);
                        }
                    }
                    foreach (var item_calicolumn in getnamecolumncalibration)
                    {

                        if (dt_cali.Columns.Contains(item_calicolumn))
                        {
                            dt_cali.Columns.Remove(item_calicolumn);
                        }
                    }
                    foreach (var item_devicecolumn in getnamecolumndevicedelete)
                    {
                        if (tableDevice.Columns.Contains(item_devicecolumn))
                        {
                            tableDevice.Columns.Remove(item_devicecolumn);
                        }
                    }
                    //DEVICE
                    //Tìm column nào có datatype là object
                    int k = 0;
                    var listtemp = new List<int>();
                    foreach (DataColumn col in tableDevice.Columns)
                    {
                        if (col.DataType == typeof(object))
                        {
                            listtemp.Add(k);
                        }
                        k++;
                    }
                    //end 
                    //convert datatype object => string
                    DataTable dtCloned = tableDevice.Clone();
                    foreach (var item in listtemp)
                    {
                        dtCloned.Columns[item].DataType = typeof(string);
                    }
                    var listpartno = new List<string>();
                    foreach (DataRow row in tableDevice.Rows)
                    {
                        listpartno.Add(row.ItemArray[1].ToString().Trim());
                        dtCloned.ImportRow(row);
                    }
                    var query = listpartno.GroupBy(x => x).Where(g => g.Count() > 1).Select(y => y.Key).ToList();
                    if (query.Count == 0)
                    {
                        SQLHelper.ExecProcedureNonData($"sp_{table_name_device}", new { Data = dtCloned });
                        //CALIBRATION
                        int j = 0;
                        var listtemp_cali = new List<int>();
                        foreach (DataColumn col in dt_cali.Columns)
                        {
                            if (col.DataType == typeof(object))
                            {
                                listtemp_cali.Add(j);
                            }
                            j++;
                        }
                        //end 
                        //convert datatype object => string
                        DataTable dtCloned_Cali = dt_cali.Clone();
                        foreach (var item in listtemp_cali)
                        {
                            dtCloned_Cali.Columns[item].DataType = typeof(string);
                        }
                        foreach (DataRow row in dt_cali.Rows)
                        {
                            dtCloned_Cali.ImportRow(row);
                        }
                        SQLHelper.ExecProcedureNonData($"sp_{table_name_calibration}", new { Data = dtCloned_Cali });
                        MessageBox.Show("Đã thực hiện thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reload_datawhencreate();
                    }
                    else
                    {
                        MessageBox.Show("Mã quản lý: " + query.Select(inc => inc).Aggregate((buffer, next) => buffer + "," + next.ToString()) + " trong file excel đang bị trùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không đúng định dạng số cột file import! Vui lòng xem lại", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       

        
        public void Reload_datawhencreate()
        {
            var res = repository.FindAll();
            form_Device.dtgv_device.DataSource = res.OrderByDescending(c => c.PART_NO).ToList();
        }
        public string NonUnicode(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
                "đ",
                "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
                "í","ì","ỉ","ĩ","ị",
                "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
                "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
                "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
                "d",
                "e","e","e","e","e","e","e","e","e","e","e",
                "i","i","i","i","i",
                "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
                "u","u","u","u","u","u","u","u","u","u","u",
                "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }
        public string GetDataTypeFromExcelToTypeSql(Type dataType)
        {
            if (dataType == typeof(string) || dataType == typeof(object))
            {
                return "nvarchar";
            }
            else if (dataType == typeof(DateTime))
            {
                return "date";
            }
            else if (dataType == typeof(int))
            {
                return "int";
            }
            else if (dataType == typeof(double))
            {
                return "decimal";
            }
            else if (dataType == typeof(bool))
            {
                return "bit";
            }
            return "varchar";
        }
        private string GetExcelColumnName(int columnNumber)
        {
            string columnName = "";

            while (columnNumber > 0)
            {
                int modulo = (columnNumber - 1) % 26;
                columnName = Convert.ToChar('A' + modulo) + columnName;
                columnNumber = (columnNumber - modulo) / 26;
            }

            return columnName;
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
        DataTable dt_cali;
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
        }
        public string GetSubstringByString(string a, string b, string c)
        {
            return c.Substring((c.IndexOf(a) + a.Length), (c.IndexOf(b) - c.IndexOf(a) - a.Length));
        }
        private void cbbsheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            tableDevice = tableCollection[cbbsheet.SelectedItem.ToString()];
            dt_cali = tableDevice.Copy();
            dtgvreaderexcel.DataSource = tableDevice;           
            char[] separators = new char[] { ' ', ';', ',', '\r', '\t', '\n', '\'', '/', '\\', '(', ')', '.', '[', ']', '-' };
            
            var listItemTable = new List<ItemTable>();
            if (tableDevice.Rows.Count > 0)
            {
                var i = 1;
                foreach (DataColumn column in tableDevice.Columns)
                {
                    if(column.ColumnName != "No")
                    {
                        string name = column.ColumnName;
                        string getcolumnnameinroundbrackets = "";
                        if (name.Contains("("))
                        {
                           getcolumnnameinroundbrackets = GetSubstringByString("(", ")", name);;                           
                        }
                        else
                        {
                            getcolumnnameinroundbrackets=name;
                        }
                        if (getcolumnnameinroundbrackets != "")
                        {
                            var columnName = getcolumnnameinroundbrackets.Trim();
                            var itemTable = new ItemTable();
                            // Get Caption
                            
                            itemTable.Caption = getcolumnnameinroundbrackets.Replace("\n"," ").Trim(' ');
                            // Get FieldName
                            string[] temp = getcolumnnameinroundbrackets.Replace("'", "").Replace("_", "").Split(separators, StringSplitOptions.RemoveEmptyEntries);
                            var columnNameRemoveSpecialChar = String.Join("\n", temp);
                            //string[] getFielName = item.FieldName.Split(new char[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries);
                            // [SO_SERIAL][MANFACTORY_PART_NAME],[MONTH_CALIBRATION],\,,\n\t[MODEL_THANH_PHAM]"
                            var FielName = NonUnicode(columnNameRemoveSpecialChar.ToUpper().Replace('\n', '_'));
                            if(FielName== "SO_SERIAL")
                            {
                                itemTable.FieldName = "SERIAL" ;
                            }else if(FielName == "MANFACTORY_PART_NAME")
                            {
                                itemTable.FieldName = "MANUFACTORY";
                            }
                            else if (FielName == "MONTH_CALIBRATION")
                            {
                                itemTable.FieldName = "CALI_CYCLE";
                            }
                            else if (FielName == "MODEL_THANH_PHAM")
                            {
                                itemTable.FieldName = "MODEL_UMC";
                            }
                            else if (FielName == "DATE_OF_CALIBRATION")
                            {
                                itemTable.FieldName = "CALI_DATE";
                            }
                            else if (FielName == "RE_CALIBRATION_RECOMMENDED")
                            {
                                itemTable.FieldName = "CALI_RECOMMEND";
                            }
                            else
                            {
                                itemTable.FieldName = NonUnicode(columnNameRemoveSpecialChar.ToUpper().Replace('\n', '_'));
                            }

                            // Get DataType and Sample Data
                            itemTable.DataType = GetDataTypeFromExcelToTypeSql(column.DataType);
                            if (itemTable.DataType.Contains("varchar"))
                            {
                                itemTable.Length = "255";
                            }
                            else if (itemTable.DataType == "decimal")
                            {
                                itemTable.Length = "10,2";
                            }
                            itemTable.SampleData = tableDevice.Rows[0][column.ColumnName].ToString();
                            itemTable.ExcelCharacter = GetExcelColumnName(i);
                            listItemTable.Add(itemTable);
                            i++;
                        }
                    }
                    
                    
                }
            }
            
            dtgrtoconvert.DataSource = listItemTable;
            
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
