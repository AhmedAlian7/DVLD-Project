using DVLD_Full_Project.Properties;
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
using System.IO;
namespace DVLD_Full_Project
{
    public partial class ctrLicenseInfo : UserControl
    {
        private int _LicesneID; private clsLicense _LicenseInfo;

        public int LicenseID { get { return _LicesneID; } }
        public clsLicense LicenseInfo { get { return _LicenseInfo; } }

        public ctrLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadInfo(int licenseID)
        {
            _LicesneID = licenseID;
            _LicenseInfo = clsLicense.Find(_LicesneID);
            if (_LicenseInfo == null)
            {
                MessageBox.Show("Can't Find License With This ID = " + licenseID, "Error",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicesneID = -1;
                return;
            }
            lblName.Text = _LicenseInfo.DriverInfo.PersonInfo.FullName;
            lblClass.Text = _LicenseInfo.LicenseClassInfo.ClassName;
            lblLicenseID.Text = _LicenseInfo.LicenseID.ToString();
            lblGender.Text = _LicenseInfo.DriverInfo.PersonInfo.Gender;
            lblNationalNo.Text = _LicenseInfo.DriverInfo.PersonInfo.NationalNo;
            lblIssueDate.Text = _LicenseInfo.IssueDate.ToShortDateString();
            lblIssueReason.Text = _LicenseInfo.IsseReasonText;
            lblDateOfBirth.Text = _LicenseInfo.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            lblIsActive.Text = _LicenseInfo.IsActive ? "Yes" : "No";
            lblDriverID.Text = _LicenseInfo.DriverID.ToString();
            lblExpirationDate.Text = _LicenseInfo.ExpirationDate.ToShortDateString();

            _LoadImage();
        }

        private void _LoadImage()
        {

            string ImagePath = _LicenseInfo.DriverInfo.PersonInfo.ImagePath;
            if (ImagePath != "")
            {
                if (File.Exists(ImagePath))
                    picPerson.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Can't Find Image With This Path" + ImagePath, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (_LicenseInfo.DriverInfo.PersonInfo.Gender == "Female")
                {
                    picPerson.Image = Resources.UnknownFemale;
                }
                else
                {
                    picPerson.Image = Resources.UnknownMale;
                }
            }
        }
    }
}
