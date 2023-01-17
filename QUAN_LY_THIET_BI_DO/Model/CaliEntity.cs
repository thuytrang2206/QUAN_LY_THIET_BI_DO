using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUAN_LY_THIET_BI_DO.Model
{
    public class CaliEntity
    {
        public string PAYMENT_BY { get; set; }        

        public string PART_NO { get; set; }

        public string SAP_BARCODE { get; set; }

        public string PART_NAME { get; set; }

        public string MODEL { get; set; }

        public string SERIAL { get; set; }

        public string MANUFACTORY { get; set; }

        public int CALI_CYCLE { get; set; }

        public DateTime REGISTRATION_DATE { get; set; }

        public string DEPARTMENT_CONTROL { get; set; }

        public string PLACE_OF_USE { get; set; }

        public string CONTROL_MANAGE { get; set; } 

        public DateTime CALI_DATE { get; set; }

        public DateTime CALI_RECOMMEND { get; set; }

        //public DateTime CALI_NEXT_LASTEST { get; set; }
        private DateTime _CALI_NEXT_LASTEST;
        public DateTime CALI_NEXT_LASTEST
        {
            get
            {
                return CALI_DATE.AddDays(-1).AddMonths(CALI_CYCLE);
            }
            set
            {
                this._CALI_NEXT_LASTEST = value;
            }
        }


        public string MONTH_YEAR
        {
            get {
                return CALI_NEXT_LASTEST.Month + "/" + CALI_NEXT_LASTEST.Year;
             }
        }
         
        public string CALIBRATION_BY { get; set; }

        public string EQUIPMENT_STATUS { get; set; }
        //private int ENQUIP_STATE { get; set; }

        //public string Enquip_Name
        //{
        //    get
        //    {
        //        return this.ENQUIP_STATE == 0 ? "OK" : this.ENQUIP_STATE == 1 ? "Stop Calibration & use" : this.ENQUIP_STATE == 2 ? "NG chờ sửa" : "NG hủy";
        //    }
        //}

        public string REMARK { get; set; }       

        public string LINE { get; set; }

        public string FCT_NO { get; set; }

        public string MODEL_UMC { get; set; }

        public string PDF_FILE { get; set; }

        private bool _Check;
        public bool Check
        {
            get
            {
                if (CALI_RECOMMEND.Year == DateTime.Now.Year && CALI_RECOMMEND.Month == DateTime.Now.Month && DateTime.Now.Day + 7 == CALI_RECOMMEND.Day)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                this._Check = value;
            }
        }
    }
}
