using People_BusinessLayer;
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
    public partial class frmIssueLicenseFirstTime : Form
    {
        int _LocalDLAppID;
        clsLocalDLApplication _LocalDLApp;

        public frmIssueLicenseFirstTime(int LocalDrivingLicenseAppID)
        {
            InitializeComponent();
            this._LocalDLAppID = LocalDrivingLicenseAppID;
            this._LocalDLApp = clsLocalDLApplication.FindByLocalDLApplicationID(this._LocalDLAppID);
        }

        private void frmIssueLicenseFirstTime_Load(object sender, EventArgs e)
        {
            
            if (_LocalDLApp == null)
            {
                MessageBox.Show("NO Application With ID = " + _LocalDLAppID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            if (!_LocalDLApp.PassedAllTests())
            {
                MessageBox.Show("Person Have to Pass All Tests First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            localDLApplicationInfo1.LoadApplicationInfoByLocalID(this._LocalDLAppID);
            txbNotes.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int LicenseID = _LocalDLApp.IssueLicenseForFirstTime(txbNotes.Text, ClsGloabl.CurrentUser.UserID);

            if (LicenseID != -1)
            {
                MessageBox.Show("License Issued Successfully with LicenseID = " + LicenseID, "Confirm",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("License Issued Failed !", "Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
