using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUAN_LY_THIET_BI_DO
{
    public partial class Views : Form
    {
        public Views( string localPath)
        {
            InitializeComponent();
            //axAcroPDFView.src = localPath;
            pdfViewer1.LoadDocument(localPath);
        }
    }
}
