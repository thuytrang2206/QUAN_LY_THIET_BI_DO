using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QUAN_LY_THIET_BI_DO.Model;

namespace QUAN_LY_THIET_BI_DO.Business
{ 
    public class Repository
    {
        public DeviceControl_Model context = new DeviceControl_Model();
        string sql = @"SELECT t1.*, t2.CALI_DATE,t2.CALI_RECOMMEND
                     FROM[DeviceControl].[dbo].[DEVICE] t1
                     INNER JOIN[DeviceControl].[dbo].[CALIBRATION] t2 ON t2.PART_NO = t1.PART_NO
                     WHERE t1.STATUS=1";
        public List<CaliEntity> FindAll()
        {           
            var res = context.Database.SqlQuery<CaliEntity>(sql, "").OrderByDescending(c=>c.PART_NO).ToList();
            return res;
        }
        public List<CaliEntity> SearchPartNo(string key)
        {
            string sql_search = @"SELECT t1.*, t2.CALI_DATE,t2.CALI_RECOMMEND
                                FROM[DeviceControl].[dbo].[DEVICE] t1
                                INNER JOIN[DeviceControl].[dbo].[CALIBRATION] t2 ON t2.PART_NO = t1.PART_NO
                                WHERE t1.PART_NO LIKE " + "'%" + key + "%' and t1.STATUS= 1";
            var res = context.Database.SqlQuery<CaliEntity>(sql_search, "").OrderByDescending(c => c.PART_NO).ToList();
            return res;
        }
        public List<CaliEntity> EquipmentFilter(string key)
        {
            string sql_search = @"SELECT t1.*, t2.CALI_DATE,t2.CALI_RECOMMEND
                                FROM[DeviceControl].[dbo].[DEVICE] t1
                                INNER JOIN[DeviceControl].[dbo].[CALIBRATION] t2 ON t2.PART_NO = t1.PART_NO
                                WHERE t1.EQUIPMENT_STATUS LIKE " + "'%" + key + "%' and t1.STATUS= 1";
            var res = context.Database.SqlQuery<CaliEntity>(sql_search, "").OrderByDescending(c => c.PART_NO).ToList();
            return res;
        }
        public List<CaliEntity> ExportMonthYear(DateTime datetime)
        {
            string convert = datetime.Month + "/" + datetime.Year;
            var res = context.Database.SqlQuery<CaliEntity>(sql, "").Where(c=>c.MONTH_YEAR==convert).OrderByDescending(c => c.PART_NO).ToList();
            return res;
        }
        public List<CaliEntity> ExportEquipment(string eqiupment)
        {           
            var res = context.Database.SqlQuery<CaliEntity>(sql, "").Where(c => c.EQUIPMENT_STATUS.Contains(eqiupment)).OrderByDescending(c => c.PART_NO).ToList();
            return res;
        }
        public List<CaliEntity> Findtopartno_inviewpdf(string part_no)
        {
            var res = context.Database.SqlQuery<CaliEntity>(sql, "").Where(c => c.PART_NO == part_no).ToList();
            return res;
        }
        public List<CALIBRATION> Search_cbbox(string key)
        {
            string sql_search_cali = @"SELECT PART_NO,CALI_DATE,CALI_RECOMMEND ,STATUS FROM [DeviceControl].[dbo].[CALIBRATION] 
            WHERE PART_NO LIKE " + "'%" + key + "%' AND STATUS=1";
            var res_cali = context.Database.SqlQuery<CALIBRATION>(sql_search_cali, "").OrderByDescending(c => c.PART_NO).ToList();
            return res_cali;
        }
        public List<CALIBRATION> List_Calibration()
        {
            string sqlcali = @"SELECT * FROM [DeviceControl].[dbo].[CALIBRATION] WHERE STATUS=1";
            var res_cali = context.Database.SqlQuery<CALIBRATION>(sqlcali, "").OrderByDescending(c => c.PART_NO).ToList();
            return res_cali;
        }
        public List<HISTORY_CALIBRATION> Findhistory(string key)
        {
            string sqlhis = @"SELECT * FROM [DeviceControl].[dbo].[HISTORY_CALIBRATION] WHERE PART_NO=" + "'" + key + "'";
            var res_cali = context.Database.SqlQuery<HISTORY_CALIBRATION>(sqlhis, "").OrderByDescending(c => c.PART_NO).ToList();
            return res_cali;
        }
    }
}
