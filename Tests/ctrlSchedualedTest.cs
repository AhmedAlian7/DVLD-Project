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
using static People_BusinessLayer.clsTestType;

namespace DVLD_Full_Project
{
    public partial class ctrlSchedualedTest : UserControl
    {
        private clsTestType.enTestType _TestType = clsTestType.enTestType.Vision;
        private clsTestAppointments _TestAppointment;
        private int _TestID = -1;
        private int _TestAppointmentID = -1;
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsLocalDLApplication _LocalDrivingLicenseApplication;

        public ctrlSchedualedTest()
        {
            InitializeComponent();
        }

        public clsTestType.enTestType TestTypeID
        {
            get
            {
                return _TestType;
            }
            set
            {
                _TestType = value;
                switch (_TestType)
                {
                    case clsTestType.enTestType.Vision:
                        {
                            grTest.Text = "Vision Test";
                            picTestType.Image = Resources.icons8_vision_48;
                            break;
                        }
                    case clsTestType.enTestType.Written:
                        {
                            grTest.Text = "Written Test";
                            picTestType.Image = Resources.test;
                            break;
                        }
                    case clsTestType.enTestType.Street:
                        {
                            grTest.Text = "Street Test";
                            picTestType.Image = Resources.StreetTest;
                            break;
                        }
                }
            }
        }


        public void LoadData(int AppointmentID)
        {
            _TestAppointmentID = AppointmentID;
            _TestAppointment = clsTestAppointments.Find(AppointmentID);
            if (_TestAppointment == null)
            {
                MessageBox.Show("Doesn't Exist Appointment ID with ID = " + AppointmentID,
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _TestID = _TestAppointment.TestID;
            _LocalDrivingLicenseApplicationID = _TestAppointment.LocalDLApplicationID;
            clsLocalDLApplication app = clsLocalDLApplication.FindByLocalDLApplicationID(_TestAppointment.LocalDLApplicationID);
            _LocalDrivingLicenseApplication = app;
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblDLAppID.Text = _LocalDrivingLicenseApplication.LocalDLApplicationID.ToString();
            lblLicenseClassID.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblName.Text = _LocalDrivingLicenseApplication.PersonFullName;


            //this will show the trials for this test before 
            lblTrails.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestType).ToString();



            lblDate.Text = _TestAppointment.AppointmentDate.ToShortDateString();
            lblTestFees.Text = _TestAppointment.PaidFees.ToString();
            lblTestID.Text = (_TestAppointment.TestID == -1) ? "Not Taken Yet" : _TestAppointment.TestID.ToString();


        }
        public int TestID { get { return _TestAppointment.TestID; } }
    }
}
