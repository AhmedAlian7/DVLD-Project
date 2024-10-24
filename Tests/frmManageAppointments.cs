using DVLD_Full_Project.Properties;
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
    public partial class frmManageAppointments : Form
    {
        int _LocalID;
        clsTestType.enTestType _TestType;

        public frmManageAppointments(int localDlApplicationID, clsTestType.enTestType TestType)
        {
            InitializeComponent();
            _LocalID = localDlApplicationID;
            _TestType = TestType;
        }

        void _Refreshdgv()
        {
            dgvAppointments.DataSource = clsTestAppointments.GetAppointmentsTable(_TestType, _LocalID);
        }
        private void frmManageAppointments_Load(object sender, EventArgs e)
        {
            switch (_TestType)
            {
                case clsTestType.enTestType.Vision:
                    {
                        lblCreationMode.Text = "Vision Test Appointments";
                        picTestType.Image = Resources.icons8_vision_48;
                        break;
                    }
                case clsTestType.enTestType.Written:
                    {
                        lblCreationMode.Text = "Written Test Appointments";
                        picTestType.Image = Resources.test;
                        break;
                    }
                case clsTestType.enTestType.Street:
                    {
                        lblCreationMode.Text = "Street Test Appointments";
                        picTestType.Image = Resources.StreetTest;
                        break;
                    }
            }

            localDLApplicationInfo1.LoadApplicationInfoByLocalID(_LocalID);
            _Refreshdgv();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            clsLocalDLApplication app = clsLocalDLApplication.FindByLocalDLApplicationID(_LocalID);

            if (app.IsThereActiveAppointment(_TestType))
            {
                MessageBox.Show("There already active appointment, you cannot add new one",
                    "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (app.IsPassThisTest(_TestType))
            {
                MessageBox.Show("this test already pessed by this person",
                    "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsTest LastTest = app.GetLastTestPerTestType(_TestType);

            if (LastTest == null)
            {
                frmSchedualeTest frm = new frmSchedualeTest(_LocalID, _TestType);
                frm.ShowDialog();
                _Refreshdgv();
                return;
            }
            if (LastTest.TestResult)
            {
                MessageBox.Show("This Person Already Passed ThisTest!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Edit Mode
            frmSchedualeTest frm1 = new frmSchedualeTest(LastTest.AppointmentInfo.LocalDLApplicationID, _TestType);
            frm1.ShowDialog();
            _Refreshdgv();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            frmSchedualeTest frm = new frmSchedualeTest(_LocalID, _TestType, (int)dgvAppointments.CurrentRow.Cells[0].Value);
            frm .ShowDialog();
            _Refreshdgv();
        }

        private void takeTheTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int appointmentID = (int)dgvAppointments.CurrentRow.Cells[0].Value;
            frmTakeTest takeTest = new frmTakeTest(appointmentID, _TestType);
            takeTest .ShowDialog();
            _Refreshdgv();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvAppointments.CurrentRow.Cells[0].Value;

            frmSchedualeTest frm = new frmSchedualeTest(_LocalID, _TestType, TestAppointmentID);
            frm.ShowDialog();
            _Refreshdgv();
        }
    }
}
