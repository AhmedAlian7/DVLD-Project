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
    public partial class ctrLicenseInfoWithFilter : UserControl
    {
        public event Action<int> OnLicenseSelected;
        protected virtual void LicenseSelected(int LicenseID)
        {
            Action <int> handler = OnLicenseSelected;

            handler?.Invoke(LicenseID);
        }  // Raise Selection Event

        private bool _FilterEnabaled = true;
        public bool FilterEnabaled { get { return _FilterEnabaled; } set { _FilterEnabaled = value; pnlFilter.Enabled = value; } }

        private int _LicenseID = -1;
        public int LicenseID { get { return ctrLicenseInfo1.LicenseID; } }
        public clsLicense LicenseInfo { get { return ctrLicenseInfo1.LicenseInfo; } }

        public ctrLicenseInfoWithFilter()
        {
            InitializeComponent();

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Field Isn't Valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _LicenseID = int.Parse(txbLicenseID.Text);
            ctrLicenseInfo1.LoadInfo(_LicenseID);

            if (OnLicenseSelected != null && FilterEnabaled)
            {
                OnLicenseSelected(_LicenseID);
            }
        }
        private void LoadInfo(int licenseID)
        {
            txbLicenseID.Text = licenseID.ToString();
            ctrLicenseInfo1.LoadInfo(licenseID);
            _LicenseID = licenseID;
            if (OnLicenseSelected != null && FilterEnabaled)
            {
                OnLicenseSelected(licenseID);

            }
        }
        public void FilterFocus()
        {
            txbLicenseID.Focus();
        }

        private void txbLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // Enter
            {
                btnFind.PerformClick();
            }
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
