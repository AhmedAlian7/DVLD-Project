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
    public partial class frmManageLocalDrivingLicenseApplications : Form
    {
        public frmManageLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }
        private void _RefreshTable()
        {
            dgvUsers.DataSource = clsLocalDLApplication.GetAllLocalDLApplications();
        }

        private void frmManageLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _RefreshTable();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmLocalDLApplication frm = new frmLocalDLApplication();
            frm.Show();
        }

        private void tsmShowDetails_Click(object sender, EventArgs e)
        {
            frmLocalDLApplicaionInfo frm = new frmLocalDLApplicaionInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.Show();
        }

        private void tsmUpdateUser_Click(object sender, EventArgs e)
        {
            frmLocalDLApplication frm = new frmLocalDLApplication((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.Show();
            _RefreshTable();
        }

        private void tmsDeleteUser_Click(object sender, EventArgs e)
        {
            if (
            MessageBox.Show("Are You Sure You Want To Delete This Application?", "Confirm",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                == DialogResult.OK)
            {
                int ID = (int)dgvUsers.CurrentRow.Cells[0].Value;
                clsLocalDLApplication App = clsLocalDLApplication.FindByLocalDLApplicationID(ID);
                if (App != null && App.Delete())
                {
                    MessageBox.Show("Application Deleted Successfully", "Confirm",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshTable();
                }
                else
                {
                    MessageBox.Show("Couldn't Delete This Appliaction!", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (
                    MessageBox.Show("Are You Sure You Want To Cancel This Application?", "Confirm",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                                  == DialogResult.OK
                )
            {
                int ID = (int)dgvUsers.CurrentRow.Cells[0].Value;
                clsLocalDLApplication App = clsLocalDLApplication.FindByLocalDLApplicationID(ID);
                if (App != null && App.Cancel())
                {
                    MessageBox.Show("Application Canceled Successfully", "Confirm",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshTable();
                }
                else
                {
                    MessageBox.Show("Couldn't Cancel This Appliaction!", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmsApplication_Opening(object sender, CancelEventArgs e)
        {
            //int ID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            //clsLocalDLApplication App = clsLocalDLApplication.FindByLocalDLApplicationID(ID);

            ////int TotalPassedTests = (int)dgvUsers.CurrentRow.Cells[5].Value;
            ////bool LicenseExist = App.IsLicenseIssued();


            //clsLocalDLApplication.enStaus AppStatus = App.ApplicationStatus;
            //cancelApplicationToolStripMenuItem.Enabled = AppStatus == clsApplication.enStaus.New; // && !LicenseExist
            //tmsDeleteApp.Enabled = AppStatus == clsApplication.enStaus.New; // && !LicenseExist
            //tsmUpdateApplication.Enabled = AppStatus == clsApplication.enStaus.New; // && !LicenseExist

            //scheduleTestToolStripMenuItem.Enabled = !LicenseExist;


            int PaseedTests = Convert.ToInt16(dgvUsers.CurrentRow.Cells[5].Value);
            string Status = dgvUsers.CurrentRow.Cells[6].Value.ToString();

            tsmUpdateApplication.Enabled = false;
            tmsDeleteApp.Enabled = false;
            cancelApplicationToolStripMenuItem.Enabled = false;
            scheduleTestToolStripMenuItem.Enabled = false;

            visionTestToolStripMenuItem.Enabled = false;
            wrtittenTestToolStripMenuItem.Enabled = false;
            streetTestToolStripMenuItem .Enabled = false;

            isToolStripMenuItem.Enabled = false;
            showDrivingLicenseToolStripMenuItem.Enabled = false;
            personLicenseHistoryToolStripMenuItem .Enabled = false;

            if (Status == "Cancelled")
            {
                return;
            }

            if (Status == "New" && PaseedTests == 3)
            {
                tsmUpdateApplication.Enabled = true;
                tmsDeleteApp.Enabled = true;
                cancelApplicationToolStripMenuItem.Enabled = true;

                isToolStripMenuItem.Enabled = true;

                return;
            }

            if (Status == "Completed")
            {
                showDrivingLicenseToolStripMenuItem.Enabled = true;
                personLicenseHistoryToolStripMenuItem.Enabled = true;
                return;
            }

            if (PaseedTests == 0)
            {
                tsmUpdateApplication.Enabled = true;
                tmsDeleteApp.Enabled = true;
                cancelApplicationToolStripMenuItem.Enabled = true;
                scheduleTestToolStripMenuItem.Enabled = true;


                visionTestToolStripMenuItem.Enabled = true;
                wrtittenTestToolStripMenuItem.Enabled = false;
                streetTestToolStripMenuItem.Enabled = false;

                return;

            }

            if (PaseedTests == 1)
            {
                tsmUpdateApplication.Enabled = true;
                tmsDeleteApp.Enabled = true;
                cancelApplicationToolStripMenuItem.Enabled = true;
                scheduleTestToolStripMenuItem.Enabled = true;


                visionTestToolStripMenuItem.Enabled = false;
                wrtittenTestToolStripMenuItem.Enabled = true;
                streetTestToolStripMenuItem.Enabled = false;

                return;
            }

            if (PaseedTests == 2)
            {
                tsmUpdateApplication.Enabled = true;
                tmsDeleteApp.Enabled = true;
                cancelApplicationToolStripMenuItem.Enabled = true;
                scheduleTestToolStripMenuItem.Enabled = true;


                visionTestToolStripMenuItem.Enabled = false;
                wrtittenTestToolStripMenuItem.Enabled = false;
                streetTestToolStripMenuItem.Enabled = true;

                return;
            }

        }

        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LoaclID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            frmManageAppointments frm = new frmManageAppointments(LoaclID, clsTestType.enTestType.Vision);
            frm.ShowDialog();
            _RefreshTable();
        }

        private void wrtittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LoaclID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            frmManageAppointments frm = new frmManageAppointments(LoaclID, clsTestType.enTestType.Written);
            frm.ShowDialog();
            _RefreshTable();
        }

        private void streetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LoaclID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            frmManageAppointments frm = new frmManageAppointments(LoaclID, clsTestType.enTestType.Street);
            frm.ShowDialog();
            _RefreshTable();
        }

        private void isToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LoaclID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            frmIssueLicenseFirstTime frm = new frmIssueLicenseFirstTime(LoaclID);
            frm.ShowDialog();
        }

        private void showDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LoaclID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            int LicenseID = clsLocalDLApplication.FindByLocalDLApplicationID(LoaclID).LicenseID;
            frmShowLicense frm = new frmShowLicense(LicenseID);
            frm.ShowDialog();
        }

        private void personLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LoaclID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            int PersonId = clsLocalDLApplication.FindByLocalDLApplicationID(LoaclID).ApplicantPersonID;
            frmLicensesHistory frm = new frmLicensesHistory(PersonId);
            frm.ShowDialog();
        }
    }
}
