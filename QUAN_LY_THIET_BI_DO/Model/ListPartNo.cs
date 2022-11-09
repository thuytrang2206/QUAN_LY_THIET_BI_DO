using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUAN_LY_THIET_BI_DO.Model
{
    public class ListPartNo
    {
        public string PAYMENT { get; set; }

        public string PART_NO { get; set; }

        public string SAP_BARCODE { get; set; }

        public string PART_NAME { get; set; }

        public string MODEL { get; set; }

        public string SERIAL { get; set; }

        public string MANUFACTORY { get; set; }

        public int CALI_CYCLE { get; set; }

        public DateTime REGISTRATION_DATE { get; set; }

        public string DEPT_CONTROL { get; set; }

        public string PLACE_USE { get; set; }

        public string CONTROL_MNG { get; set; }

        public DateTime CALI_DATE { get; set; }

        public DateTime CALI_RECOMMEND { get; set; }
        public string MAKER { get; set; }

        public string ENQUIP_STATE { get; set; }
        public string RMK { get; set; }

        public string LINE { get; set; }

        public string FCT_NO { get; set; }

        public string MODEL_UMC { get; set; }
    }
}
