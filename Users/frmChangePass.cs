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
    public partial class frmChangePass : Form
    {
        int UserID;
        User user;
        public frmChangePass(int UserID)
        {
            InitializeComponent();
            this.UserID = UserID;
        }

        private void txbCurrentPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txbCurrentPass.Text) || ClsGloabl.CurrentUser.Password != txbCurrentPass.Text)
            {
                errorProvider1.SetError(txbCurrentPass, "Incorrect Password!");
            }
            else
            {
                errorProvider1.SetError(txbCurrentPass, "");
            }
        }

        private void txbNewPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txbNewPass.Text))
            {
                errorProvider1.SetError(txbNewPass, "Enter The Password!");
            }
            else
            {
                errorProvider1.SetError(txbNewPass, "");
            }
        }

        private void txbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txbConfirmPassword.Text) || txbConfirmPassword.Text != txbNewPass.Text)
            {
                errorProvider1.SetError(txbConfirmPassword, "Password not match!");
            }
            else
            {

                errorProvider1.SetError(txbConfirmPassword, "");
            }
        }

        private void frmChangePass_Load(object sender, EventArgs e)
        {
            user = User.FindByUserID(UserID);
            if (user == null)
            {
                MessageBox.Show("Doesn't Exist User with ID = " + UserID, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.Close();
                return;
            }


            ctrPersonCard1.LoadPersonInfo(user.PersonID);
            lblUserID.Text = UserID.ToString();
            lblUserName.Text = user.UserName;
            lblIsActive.Text = (user.IsActive) ? "Yes" : "No";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields Are Not Valid, Enter All Required Boxes!", "Error", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                return;
            }

            if (User.ChangePass(UserID, txbNewPass.Text.Trim())) 
            {
                if (MessageBox.Show("Password Changed Successfully", "Success", MessageBoxButtons.OK,
                              MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
