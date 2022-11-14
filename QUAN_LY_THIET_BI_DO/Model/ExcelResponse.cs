using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUAN_LY_THIET_BI_DO.Model
{
    public class ExcelResponse
    {
        public string URI { set; get; }
        public string SheetName { set; get; }
        public DataTableCollection DATA { set; get; }
    }
}
