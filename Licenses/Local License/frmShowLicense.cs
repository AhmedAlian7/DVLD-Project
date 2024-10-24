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
    public partial class frmShowLicense : Form
    {
        private int _LicenseID;
        public frmShowLicense(int licenseID)
        {
            InitializeComponent();
            _LicenseID = licenseID; 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowLicense_Load(object sender, EventArgs e)
        {
            ctrLicenseInfo1.LoadInfo(_LicenseID);
        }
    }
}
