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

    public partial class frmTakeTest : Form
    {
        private int _appointmentID;
        private clsTestType.enTestType _TestType = clsTestType.enTestType.Vision;
        private int _testTD  = -1;
        private clsTest _test;

        public frmTakeTest(int appointmentID, clsTestType.enTestType TestType)
        {
            InitializeComponent();

            this._appointmentID = appointmentID;
            this._TestType = TestType;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctrlSchedualedTest1.TestTypeID = _TestType;
            ctrlSchedualedTest1.LoadData(_appointmentID);

            if (_appointmentID == -1)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;
            int TestID = ctrlSchedualedTest1.TestID;
            if (TestID != -1)
            { 
                clsTest test = clsTest.Find(TestID);
                if (test.TestResult)
                    rbPass.Checked = true;
                else
                    rbPass.Checked = true;
                txbNotes.Text = test.Notes;
                lblusermessage.Visible = true;
                rbFail.Enabled = false;
                rbPass.Enabled = false;

            }
            else
            {
                _test = new clsTest();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (
            MessageBox.Show("Are you sure you want to save, you can't change it again!?", "Confirm",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No
                )
                return;

            _test.TestAppointmentID = _appointmentID;
            _test.TestResult = rbPass.Checked;
            _test.Notes = txbNotes.Text.Trim();
            _test.CreatedUserID = ClsGloabl.CurrentUser.UserID;

            if(_test.Save())
            {
                MessageBox.Show("Data saved successfully", "Saved",MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
            else
                MessageBox.Show("Data isn't saved successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
