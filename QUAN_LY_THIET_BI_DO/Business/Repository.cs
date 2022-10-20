﻿using System;
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
        public List<CaliEntity> FindAll()
        {
            string sql = @"SELECT t1.*, t2.CALI_DATE,t2.CALI_RECOMMEND
                             FROM[DeviceControl].[dbo].[DEVICE] t1
                             INNER JOIN[DeviceControl].[dbo].[CALIBRATION] t2 ON t2.PART_NO = t1.PART_NO";
            var res = context.Database.SqlQuery<CaliEntity>(sql, "").OrderByDescending(c=>c.PART_NO).ToList();
            return res;
        }
        public List<CaliEntity> Search(string key)
        {
            string sql = @"SELECT t1.*, t2.CALI_DATE,t2.CALI_RECOMMEND
                             FROM[DeviceControl].[dbo].[DEVICE] t1
                             INNER JOIN[DeviceControl].[dbo].[CALIBRATION] t2 ON t2.PART_NO = t1.PART_NO
                            WHERE t1.PART_NO LIKE " + "'%"+ key +"%'";
            var res = context.Database.SqlQuery<CaliEntity>(sql, "").OrderByDescending(c => c.PART_NO).ToList();
            return res;
        }
    }
}
