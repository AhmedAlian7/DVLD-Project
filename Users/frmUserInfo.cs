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
    public partial class frmUserInfo : Form
    {
        int UserID;
        User user;
        public frmUserInfo(int UserID)
        {
            InitializeComponent();
            this.UserID = UserID;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmUserInfo_Load(object sender, EventArgs e)
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

            ctrPersonCard1.LoadPersonInfo(user.PersonID);
            lblUserID.Text = UserID.ToString();
            lblUserName.Text = user.UserName;
            lblIsActive.Text = (user.IsActive) ? "Yes" : "No";
        }
    }
}
