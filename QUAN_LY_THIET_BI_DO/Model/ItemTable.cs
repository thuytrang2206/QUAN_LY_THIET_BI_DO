using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUAN_LY_THIET_BI_DO.Model
{
   public class ItemTable
    {
        public bool Key { get; set; } = false;
        public string ExcelCharacter { get; set; }
        public string Caption { get; set; }
        public string FieldName { get; set; }
        public string DataType { get; set; }
        public string Length { get; set; }
        public bool AllowNull { get; set; } = true;
        public string SampleData { get; set; }
    }

}
