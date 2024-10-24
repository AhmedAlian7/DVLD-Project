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
    public partial class frmAddUpdateUser : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _UserID = -1;
        User _User;

        public frmAddUpdateUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;

        }
        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _UserID = UserID;

        }

        private void ctrPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _UserID = obj;
        }

        private void _LoadUserData()
        {
            _User = User.FindByUserID(_UserID);
            ctrPersonCardWithFilter1.ShowpnlFilter = false;

            if (_User == null)
            {
                MessageBox.Show("Doesn't Exist User with ID = " +  _UserID, "Error",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblUserID.Text = _User.UserID.ToString();
            txbUserName.Text = _User.UserName;
            txbPassword.Text = _User.Password;
            txbConfirmPassword.Text = _User.Password;
            chkIsActive.Checked = (_User.IsActive) ? true : false;
            ctrPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);



        }
        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New User";
                this.Text = "Add New User";
                _User = new User();
                pnlLoginInfo.Enabled = false;

                txbUserName.Text = "";
                txbPassword.Text = "";
                txbConfirmPassword.Text = "";        
            }
            else
            {
                lblMode.Text = "Update User";
                this.Text = "Update User";
                pnlLoginInfo.Enabled = true;
                btnNext.Enabled = true;

                _LoadUserData();
            }

        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                pnlLoginInfo.Enabled = true;

                tbcUser.SelectedTab = tbcUser.TabPages[1];
                return;
            }

            // Add New Mode:
            if (ctrPersonCardWithFilter1.PersonID != -1)
            {
                if (User.IsExistForPerson(ctrPersonCardWithFilter1.PersonID))
                {
                    MessageBox.Show("Selected Person Is Already a User, Choose another One!", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    btnSave.Enabled = true;
                    pnlLoginInfo.Enabled = true;
                    tbcUser.SelectedIndex = 1;
                }
            }
            else
            {
                MessageBox.Show("Select a person!", "Error", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields Are Not Valid, Enter All Required Boxes!", "Error", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                return;
            }

            _User.PersonID = ctrPersonCardWithFilter1.PersonID;
            _User.UserName = txbUserName.Text;
            _User.Password = txbPassword.Text;
            _User.IsActive = chkIsActive.Checked;   

            if (_User.Save())
            {
                if(MessageBox.Show("User Added Successfully", "Success", MessageBoxButtons.OK,
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

        private void txbUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txbUserName.Text) || User.IsUserExist(txbUserName.Text))
            {
                errorProvider1.SetError(txbUserName, "Invalid User Name");
            }
            else
            {

                errorProvider1.SetError(txbUserName, "");
            }
        }

        private void txbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txbPassword.Text))
            {
                errorProvider1.SetError(txbPassword, "Password Is required");
            }
            else
            {

                errorProvider1.SetError(txbPassword, "");
            }
        }

        private void txbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txbConfirmPassword.Text) || txbConfirmPassword.Text != txbPassword.Text)
            {
                errorProvider1.SetError(txbConfirmPassword, "Password not match!");
            }
            else
            {

                errorProvider1.SetError(txbConfirmPassword, "");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
