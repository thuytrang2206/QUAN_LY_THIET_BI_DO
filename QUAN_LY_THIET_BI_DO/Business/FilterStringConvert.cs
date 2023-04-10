using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUAN_LY_THIET_BI_DO.Business
{
    public static class FilterStringConvert
    {
        public static string FilterStringconverter(string filter)
        {
            string newColFilter = "";
            filter = filter.Replace("(", "").Replace(")", "");
            var colFilterList = filter.Split(new string[] { "AND" }, StringSplitOptions.None);
            string andOperator = "";
            foreach (var colFilter in colFilterList)
            {
                newColFilter += andOperator;
                var temp1 = colFilter.Trim().Split(new string[] { "IN" }, StringSplitOptions.None);
                var colName = temp1[0].Split('[', ']')[1].Trim().Insert(0, "t1.");
                newColFilter += string.Format("{0} != null or ", colName);
                string orOperator = "";
                var filterValsList = temp1[1].Split(',');
                foreach (var filterVal in filterValsList)
                {
                    var cleanFilterVal = filterVal.Replace("'", "").Trim();

                    double tempNum = 0;
                    if (Double.TryParse(cleanFilterVal, out tempNum))
                        newColFilter += string.Format("{0} {1} = {2}", orOperator, colName, cleanFilterVal.Trim());
                    else
                        newColFilter += string.Format("{0} {1} LIKE '{2}'", orOperator, colName, cleanFilterVal.Trim());

                    orOperator = " OR ";
                }

                newColFilter += string.Format("and t1.STATUS= 1", colName); ;

                andOperator = " AND ";
            }
            return newColFilter;
        }
    }
}
