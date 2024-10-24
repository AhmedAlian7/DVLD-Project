using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using People_BusinessLayer;

namespace DVLD_Full_Project
{
    public partial class LocalDLApplicationInfo : UserControl
    {
        clsLocalDLApplication _LocalDLApplicaion;
        int _DLApplicationID;

        public int LocalDLApplicaionID { get { return _DLApplicationID; } } 

        public LocalDLApplicationInfo()
        {
            InitializeComponent();
        }

        void _FillLablesInfo()
        {
            lblLocalDLApplicationID.Text = _LocalDLApplicaion.LocalDLApplicationID.ToString();
            lblLicenseClass.Text = clsLicenseClass.Find(_LocalDLApplicaion.LicenseClassID).ClassName;
            lblApplicationID.Text = _LocalDLApplicaion.ApplicationID.ToString();
            lblStatus.Text = _LocalDLApplicaion.StatusText;
            lblFees.Text = _LocalDLApplicaion.PaidFees.ToString();
            lblType.Text = _LocalDLApplicaion.ApplicationType.Title;
            lblPersonID.Text = _LocalDLApplicaion.PersonFullName;
            lblApplicationDate.Text = _LocalDLApplicaion.ApplicatonDate.ToString();
            lblFees.Text = _LocalDLApplicaion.PaidFees.ToString();
            lblLastStatusUpdate.Text = _LocalDLApplicaion.LastStatusUpdate.ToString();
            lblCreatedUserID.Text = _LocalDLApplicaion.PaidFees.ToString();





        }

        public void LoadApplicationInfoByLocalID(int LocalDLApplicationID)
        {
            _LocalDLApplicaion = clsLocalDLApplication.FindByLocalDLApplicationID(LocalDLApplicationID);
            if ( _LocalDLApplicaion == null )
            {
                MessageBox.Show("No Applicaion With ID: "+ LocalDLApplicationID, "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _FillLablesInfo();
            }

        }
        public void LoadApplicationInfoByBaseAppID(int ApplicaionID)
        {
            _LocalDLApplicaion = clsLocalDLApplication.FindByBaseApplicationID(ApplicaionID);
            if (_LocalDLApplicaion == null)
            {
                MessageBox.Show("No Applicaion With ID: " + ApplicaionID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

            }

        }

        private void linkPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(_LocalDLApplicaion.ApplicantPersonID);
            frm.Show();
        }
    }
}
