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
    public partial class frmReplaceLicense : Form
    {
        private int _newLicenseID;
        public frmReplaceLicense()
        {
            InitializeComponent();
        }

        private void frmReplaceLicense_Load(object sender, EventArgs e)
        {
            lblAppDate.Text = DateTime.Now.ToShortDateString();
            lblUserID.Text = ClsGloabl.CurrentUser.UserName;

            rbDamaged.Checked = true;   
        }

        private void rbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            lblTitle.Text = "Replacement Damaged License";
            lblAppFees.Text = clsApplicationType.Find((int)clsApplicationType.enApplicationType.ReplacementDamagedDrivingLicense).Fees.ToString();
                
        }

        private void rbLost_CheckedChanged(object sender, EventArgs e)
        {
            lblTitle.Text = "Replacement Lost License";
            lblAppFees.Text = clsApplicationType.Find((int)clsApplicationType.enApplicationType.ReplacementLostDrivingLicense).Fees.ToString();

        }

        private void ctrLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = (int)obj;

            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            lnkShowLicensesHistory.Enabled = SelectedLicenseID != -1;

            if (SelectedLicenseID == -1) return;

            if (!ctrLicenseInfoWithFilter1.LicenseInfo.IsActive)
            {
                MessageBox.Show("Selected license is not active, cannot complete opertion", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }
            btnSave.Enabled = true;

        }

        private clsLicense.enIssueReason ReplacementReason()
        {
            if (rbDamaged.Checked)
            {
                return clsLicense.enIssueReason.DamagedReplacement;
            }
            else
            {
                return clsLicense.enIssueReason.LostReplacement;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (
             MessageBox.Show("Are you sure to replace this license?", "Confirm", MessageBoxButtons.YesNo,
             MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No
             ) return;

            clsLicense newLicense = ctrLicenseInfoWithFilter1.LicenseInfo.Replace(ReplacementReason(), ClsGloabl.CurrentUser.UserID);
            if (newLicense != null)
            {
                MessageBox.Show("Faild to replace license!", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblAppID.Text = newLicense.ApplicationID.ToString();
            _newLicenseID = newLicense.LicenseID;
            lblReplacedLicenseID.Text = _newLicenseID.ToString();
            MessageBox.Show("License renewed successfully", "Success",
        MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnSave.Enabled = false;
            ctrLicenseInfoWithFilter1.FilterEnabaled = false;
            lnkShowLicenseInfo.Enabled = true;
            gbReplacement.Enabled = false;
        }
    }
}
