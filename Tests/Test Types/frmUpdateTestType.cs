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
    public partial class frmUpdateTestType : Form
    {
        int _TestID;
        clsTestType _Test;

        public frmUpdateTestType(int testID)
        {
            InitializeComponent();
            _TestID = testID;
        }
        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            _Test = clsTestType.Find(_TestID);

            if (_Test == null)
            {
                MessageBox.Show("Can't Find Test With ID = " + _TestID, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblTestID.Text = _TestID.ToString();
            txtTitle.Text = _Test.Title;
            txtDescription.Text = _Test.Description;
            txtFees.Text = _Test.Fees.ToString();
        }

        private void btnSaved_Click(object sender, EventArgs e)
        {
            _Test.Title = txtTitle.Text.Trim();
            _Test.Description = txtDescription.Text.Trim();
            _Test.Fees = float.Parse(txtFees.Text);

            if (_Test.Save())
            {

                MessageBox.Show("Test Updated Successfully", "Success", MessageBoxButtons.OK,
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
