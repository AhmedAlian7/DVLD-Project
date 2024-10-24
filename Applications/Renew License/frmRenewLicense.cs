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
    public partial class frmRenewLicense : Form
    {
        private int _newLicenseID;
        public frmRenewLicense()
        {
            InitializeComponent();
        }
        private void frmRenewLicense_Load(object sender, EventArgs e)
        {
            ctrLicenseInfoWithFilter1.FilterFocus();
            lblAppDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblAppFees.Text = clsApplicationType.Find((int)clsApplicationType.enApplicationType.RenewDrivingLicense).Fees.ToString();
            lblUserID.Text = ClsGloabl.CurrentUser.UserName;

        }
        private void ctrLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = (int)obj;

            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            lnkShowLicensesHistory.Enabled = SelectedLicenseID != -1;

            if (SelectedLicenseID == -1) return;

            lblExpirationDate.Text = DateTime.Now.AddYears(ctrLicenseInfoWithFilter1.LicenseInfo.LicenseClassInfo.DefaultValidityLength).ToShortDateString();
            lblLicenseFees.Text = ctrLicenseInfoWithFilter1.LicenseInfo.LicenseClassInfo.ClassFees.ToString();

            lblTotalFees.Text = (Convert.ToSingle(lblAppFees.Text) + Convert.ToSingle(lblLicenseFees.Text)).ToString();
            txbNotes.Text = ctrLicenseInfoWithFilter1.LicenseInfo.Notes;

            if (!ctrLicenseInfoWithFilter1.LicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected license is not expired yet, it will expire at : " +
                    ctrLicenseInfoWithFilter1.LicenseInfo.ExpirationDate.ToShortDateString(), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            if (!ctrLicenseInfoWithFilter1.LicenseInfo.IsActive)
            {
                MessageBox.Show("Selected license is not active, cannot complete opertion" , "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("Are you sure to renew this license?", "Confirm", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No
                ) return;

            clsLicense newLicense = ctrLicenseInfoWithFilter1.LicenseInfo.RenewLicense(txbNotes.Text,ClsGloabl.CurrentUser.UserID);
            if (newLicense != null)
            {
                MessageBox.Show("Faild to renew license!", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _newLicenseID = newLicense.LicenseID;
            lblAppID.Text = newLicense.ApplicationID.ToString();
            lblRenewLicenseID.Text = newLicense.LicenseID.ToString();
            MessageBox.Show("License renewed successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnSave.Enabled = false;
            ctrLicenseInfoWithFilter1.FilterEnabaled = false;
            lnkShowLicenseInfo.Enabled = true;
        }

        private void lnkShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicense frm = new frmShowLicense(_newLicenseID);
            frm.ShowDialog();
        }
    }
}
