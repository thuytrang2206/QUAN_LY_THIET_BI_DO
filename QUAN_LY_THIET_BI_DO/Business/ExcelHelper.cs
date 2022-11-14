using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;
using QUAN_LY_THIET_BI_DO.Model;

namespace QUAN_LY_THIET_BI_DO.Business
{
    public static class ExcelHelper
    {
        public static async Task<ExcelResponse> ImportExcelToDataTableAsync(bool useHeaderRow = true)
        {
            using (var ofd = new OpenFileDialog() { Filter = "Excel File|*.xlsx;*.xls|Excel Workbook|*.xlsx|Excel Workbook 97-2003|*.xls", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var task = Task<ExcelResponse>.Factory.StartNew(() =>
                    {
                        using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            IExcelDataReader reader;
                            if (Path.GetExtension(ofd.FileName).Equals(".xls"))
                            {
                                reader = ExcelReaderFactory.CreateBinaryReader(stream);
                            }
                            else
                            {
                                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                            }

                            var excelResponse = new ExcelResponse();
                            excelResponse.URI = ofd.FileName;
                            var ds = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                FilterSheet = (tableReader, sheetIndex) => tableReader.VisibleState == "visible",
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = useHeaderRow
                                }
                            });
                            excelResponse.DATA = ds.Tables;
                            excelResponse.SheetName = ds.Tables[0].TableName;
                            return excelResponse;
                        }
                    });
                    var responses = await task;
                    return responses;
                }
            }
            return null;

        }
    }
}
