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
    public partial class frmUpdateApps : Form
    {
        int _AppID;
        clsApplicationType _App;

        public frmUpdateApps(int AppID)
        {
            InitializeComponent();
            _AppID = AppID;
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void frmUpdateApps_Load(object sender, EventArgs e)
        {
             _App = clsApplicationType.Find(_AppID);

            if (_App == null)
            {
                MessageBox.Show("Can't Find Application With ID = " + _AppID, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblAppID.Text = _AppID.ToString();
            txtTitle.Text = _App.Title;
            txtFees.Text = _App.Fees.ToString();
        }

        private void btnSaved_Click(object sender, EventArgs e)
        {
            _App.Title = txtTitle.Text.Trim();
            _App.Fees = float.Parse(txtFees.Text);

            if (_App.Save())
            {

                MessageBox.Show("User Added Successfully", "Success", MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("Save Failed!", "Error", MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void btnCansled_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
