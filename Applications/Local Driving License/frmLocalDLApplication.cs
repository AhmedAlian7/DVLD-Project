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
    public partial class frmLocalDLApplication : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        int LocalDLApplicationID = -1;
        int ApplicantPersonID = -1;
        clsLocalDLApplication _LocalDLApplication;
        int _SelectedPerson;

        public frmLocalDLApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew; 
        }
        public frmLocalDLApplication(int LocalDLApplicationID)
        {
            InitializeComponent();
            _Mode = enMode.Update;

            this.LocalDLApplicationID = LocalDLApplicationID;
        }


        private void FillClassesInComboBox()
        {
            DataTable dtClasses = clsLicenseClass.AppTypesTable();

            foreach (DataRow row in dtClasses.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"]);

            }
        }
        private void InitializeControls()
        {
            FillClassesInComboBox();

            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "New Local License Application";
                this.Text = "Add New Local License Application";
                ctrPersonCardWithFilter1.FilterFocus();

                _LocalDLApplication = new clsLocalDLApplication();
                pnlAppInfo.Enabled = false;
                cbLicenseClass.SelectedIndex = 2; // Class 3
                txbFees.Text = clsApplicationType.Find(1).Fees.ToString();
                lblLicenseDate.Text = DateTime.Now.ToShortDateString();
                lblUserName.Text = ClsGloabl.CurrentUser.UserName; 


            }
            else if (_Mode == enMode.Update)
            {
                lblMode.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                tbcApplication.Enabled = true;
                btnSave.Enabled = true;

            }


        }

        private void LoadAppData()
        {
            ctrPersonCardWithFilter1.Enabled = false;
            ctrPersonCardWithFilter1.ShowpnlFilter = false;
            _LocalDLApplication = clsLocalDLApplication.FindByLocalDLApplicationID(LocalDLApplicationID);

            if (_LocalDLApplication == null )
            {
                MessageBox.Show("Doesn't Exist Application with ID = " + LocalDLApplicationID, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrPersonCardWithFilter1.LoadPersonInfo(_LocalDLApplication.ApplicantPersonID);
            lblLicenseID.Text = _LocalDLApplication.LocalDLApplicationID.ToString();
            lblLicenseDate.Text = _LocalDLApplication.ApplicatonDate.ToShortDateString();
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(clsLicenseClass.Find(_LocalDLApplication.LicenseClassID).ClassName);
            txbFees.Text = _LocalDLApplication.PaidFees.ToString();
            lblUserName.Text = _LocalDLApplication.CreatedUserInfo.UserName;
        }
        private void AddUpdateLicense_Load(object sender, EventArgs e)
        {
            InitializeControls();

            if (_Mode == enMode.Update)
                LoadAppData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int LicenseClassID = cbLicenseClass.SelectedIndex + 1;

            int ActiveApplicationID = clsLocalDLApplication.GetActiveApplicationIDForLicenseClass(_SelectedPerson, 1, LicenseClassID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("The Selected Person Already has License From This Class, Can't Complete this Opertion!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }

            // Check if he already has Active License

            _LocalDLApplication.ApplicantPersonID = ctrPersonCardWithFilter1.PersonID;
            _LocalDLApplication.ApplicatonDate = DateTime.Now;
            _LocalDLApplication.ApplicationTypeID = 1;
            _LocalDLApplication.ApplicationStatus = clsApplication.enStaus.New;
            _LocalDLApplication.LastStatusUpdate = DateTime.Now;
            _LocalDLApplication.PaidFees = Convert.ToDouble(txbFees.Text);
            _LocalDLApplication.CreatedUserID = ClsGloabl.CurrentUser.UserID;
            _LocalDLApplication.LicenseClassID = LicenseClassID;

            if (_LocalDLApplication.Save())
            {
                lblLicenseID.Text = _LocalDLApplication.LocalDLApplicationID.ToString();

                _Mode = enMode.Update;
                if (MessageBox.Show("Application Added Successfully", "Success", MessageBoxButtons.OK,
                   MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Save Failed!", "Error", MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }

        }

        private void ctrPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _SelectedPerson = obj;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                pnlAppInfo.Enabled = true;

                tbcApplication.SelectedTab = tbcApplication.TabPages[1];
                return;
            }

            // Add New Mode:
            if (ctrPersonCardWithFilter1.PersonID != -1)
            {
                    btnSave.Enabled = true;
                    pnlAppInfo.Enabled = true;
                    tbcApplication.SelectedIndex = 1;
            }
            else
            {
                MessageBox.Show("Select a person!", "Error", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
