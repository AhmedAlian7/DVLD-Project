using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Full_Project
{
    public partial class frmLocalDLApplicaionInfo : Form
    {
        int ID =-1;
        public frmLocalDLApplicaionInfo(int LocalDLApplicationInfo)
        {
            InitializeComponent();
            ID = LocalDLApplicationInfo;
        }

        private void frmLocalDLApplicaionInfo_Load(object sender, EventArgs e)
        {
            localDLApplicationInfo1.LoadApplicationInfoByLocalID(ID);
        }
    }
}
