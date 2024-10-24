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
    public partial class MainForm : Form
    {
        frmLogin LoginForm;
        public MainForm(frmLogin login)
        {
            InitializeComponent();
            LoginForm = login;
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagePeople frmManagePeople = new ManagePeople();
            frmManagePeople.Show();
        }

        private void accountSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsGloabl.CurrentUser = null;
            LoginForm.Show();

            this.Close();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageUsers frm = new ManageUsers();
            frm.Show();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ClsGloabl.CurrentUser != null)
                Application.Exit();
        }

        private void changePasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmChangePass frm = new frmChangePass(ClsGloabl.CurrentUser.UserID);
            frm.Show();
        }

        private void MyProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(ClsGloabl.CurrentUser.UserID);
            frm.Show();

        }

        private void applicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmApplictionTypes frm = new frmApplictionTypes();
            frm.Show();
        }

        private void testTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestTypes frm = new frmTestTypes();
            frm.Show();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDLApplication frm = new frmLocalDLApplication();
            frm.Show();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLocalDrivingLicenseApplications frm = new frmManageLocalDrivingLicenseApplications();
            frm.Show();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLicense frm = new frmRenewLicense();
            frm.Show();
        }

        private void replacementForDaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceLicense frm = new frmReplaceLicense();
            frm.Show();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDrivers frm = new frmManageDrivers();
            frm.Show();
        }
    }
}
