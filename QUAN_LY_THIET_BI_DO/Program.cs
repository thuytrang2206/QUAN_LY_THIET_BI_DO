using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VBSQLHelper;

namespace QUAN_LY_THIET_BI_DO
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //SQLHelper.SERVER_NAME = "172.28.10.17";
            //SQLHelper.USERNAME_DB = "sa";
            //SQLHelper.PASSWORD_DB = "umc@2019";
            SQLHelper.SERVER_NAME = @"UMC-C862\SQLEXPRESS";
            SQLHelper.USERNAME_DB = "sa";
            SQLHelper.PASSWORD_DB = "umcvn@123";
            SQLHelper.DATABASE = "DeviceControl";
            SQLHelper.ConnectString();
            Application.Run(new FormMain());
        }
    }
}
