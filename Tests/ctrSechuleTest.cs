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
using DVLD_Full_Project.Properties;

namespace DVLD_Full_Project
{
    public partial class ctrSechuleTest : UserControl
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;

        public enum enCreation { First = 0, Retake = 1 };
        private enCreation _Creation = enCreation.First;

        private clsTestType.enTestType _TestType = clsTestType.enTestType.Vision;

        private clsLocalDLApplication _LocalDLApplication;
        private int _LocalDLApplicationID = -1;

        private clsTestAppointments _TestAppointment;
        private int _AppointmentID = -1;

        public clsTestType.enTestType TestTypeID
        {
            get
            {
                return _TestType;
            }
            set
            {
                _TestType = value;
                switch(_TestType)
                {
                    case clsTestType.enTestType.Vision:
                        {
                            grTest.Text = "Vision Test";
                            lblCreationMode.Text = "Schedule Vision Test";
                            picTestType.Image = Resources.icons8_vision_48;
                            break;
                        }
                    case clsTestType.enTestType.Written:
                        {
                            grTest.Text = "Written Test";
                            lblCreationMode.Text = "Schedule Written Test";
                            picTestType.Image = Resources.test;
                            break;
                        }
                    case clsTestType.enTestType.Street:
                        {
                            grTest.Text = "Street Test";
                            lblCreationMode.Text = "Schedule Street Test";
                            picTestType.Image = Resources.StreetTest;
                            break;
                        }
                }
            }
        }

        public ctrSechuleTest()
        {
            InitializeComponent();
        }

        bool _LoadAppointmentData()
        {
            _TestAppointment = clsTestAppointments.Find(_AppointmentID);
            if (_TestAppointment == null)
            {
                MessageBox.Show("Doesn't Exist Appointment ID with ID = " + _AppointmentID,
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            lblTestFees.Text = _TestAppointment.PaidFees.ToString();

            if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0)
                dateTimePicker1.MinDate = DateTime.Now;
            else
                dateTimePicker1.MinDate = _TestAppointment.AppointmentDate;
            dateTimePicker1.Value = _TestAppointment.AppointmentDate;

            if (_TestAppointment.RetakeTestAppID != -1) // Retest case
            {
                gbRetakeTest.Enabled = true;
                lblRetakeTestFees.Text = _TestAppointment.RetakeTestAppInfo.PaidFees.ToString();
                lblCreationMode.Text = "Schedule Retake Test";
                lblRetakeAppID.Text = _TestAppointment.RetakeTestAppID.ToString();
            }
            else
            {
                lblRetakeAppID.Text = "N/A";
                lblRetakeTestFees.Text = "0";
            }
            return true;

        }

        bool PassPreviosTest()
        {
            switch(_TestType)
            {
                case clsTestType.enTestType.Vision:
                    {
                        lblErrorMessege.Visible = false;
                        return true;
                    }
                case clsTestType.enTestType.Written:
                    {
                        if (!_LocalDLApplication.IsPassThisTest(clsTestType.enTestType.Vision))
                        {
                            lblErrorMessege.Visible = true;
                            lblErrorMessege.Text = "Cannot schedule written test before pass vision test";
                            btnSave.Enabled = false;
                            dateTimePicker1.Enabled = false;
                            return false;

                        }
                        return true;
                    }
                case clsTestType.enTestType.Street:
                    {
                        if (!_LocalDLApplication.IsPassThisTest(clsTestType.enTestType.Written))
                        {
                            lblErrorMessege.Visible = true;
                            lblErrorMessege.Text = "Cannot schedule street test before pass whritten test";
                            btnSave.Enabled = false;
                            dateTimePicker1.Enabled = false;
                            return false;

                        }
                        return true;
                    }
            }
            return true;
        }
        public void LoadInfo(int LocalDLAppID, int AppointmentID = -1)
        {
            _Mode = (AppointmentID == -1) ? enMode.AddNew : enMode.Update;

            _LocalDLApplicationID = LocalDLAppID;
            _AppointmentID = AppointmentID;

            _LocalDLApplication = clsLocalDLApplication.FindByLocalDLApplicationID(_LocalDLApplicationID);
            if (_LocalDLApplication == null)
            {
                MessageBox.Show("Doesn't Exist Local Driving License Application with ID = " + _LocalDLApplicationID,
                    "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            _Creation = (_LocalDLApplication.DoesAttendTest(_TestType)) ? enCreation.Retake : enCreation.First;

            if (_Creation == enCreation.Retake)
            {
                gbRetakeTest.Enabled = true;
                lblRetakeTestFees.Text = clsApplicationType.Find(7).Fees.ToString();
                lblCreationMode.Text = "Schedule Retake Test";
            }
            else
            {
                gbRetakeTest.Enabled = false;
                lblRetakeTestFees.Text = "0";
                lblCreationMode.Text = "Schedule Test";
                lblRetakeAppID.Text = "N/A";
            }

            lblDLAppID.Text = _LocalDLApplication.LocalDLApplicationID.ToString();
            lblLicenseClassID.Text = clsLicenseClass.Find(_LocalDLApplicationID).ClassName;
            lblName.Text = _LocalDLApplication.PersonFullName;
            lblTrails.Text = _LocalDLApplication.TotalTrialsPerTest(_TestType).ToString();

            if (_Mode == enMode.AddNew)
            {
                lblTestFees.Text = clsTestType.Find((int)_TestType).Fees.ToString();
                dateTimePicker1.MinDate = DateTime.Now;
                lblRetakeAppID.Text = "N/A";

                _TestAppointment = new clsTestAppointments();
            }
            else
            {
                if (!_LoadAppointmentData())
                    return;
            }
            lblTestFees.Text = (Convert.ToDouble(lblTestFees.Text) + Convert.ToDouble(lblRetakeTestFees.Text)).ToString() ;

            // Constraints
            if (_Mode == enMode.AddNew && _LocalDLApplication.IsThereActiveAppointment())
            {
                lblErrorMessege.Text = "Person Already have an active appointment";
                btnSave.Enabled = false;
                dateTimePicker1.Enabled = false;
                return;
            }
            if (!_TestAppointment.IsActive)
            {
                lblErrorMessege.Text = "Person Already sat for this test, cannot edit it";
                btnSave.Enabled = false;
                dateTimePicker1.Enabled = false;
                return;
            }

            if (!PassPreviosTest())
                return;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew && _Creation == enCreation.Retake)
            {
                clsApplication app = new clsApplication();
                app.ApplicantPersonID = _LocalDLApplication.ApplicantPersonID;
                app.ApplicatonDate = DateTime.Now;
                app.ApplicationTypeID = 7;
                app.ApplicationStatus = clsApplication.enStaus.New;
                app.LastStatusUpdate = DateTime.Now;
                app.PaidFees = clsApplicationType.Find(7).Fees;
                app.CreatedUserID = ClsGloabl.CurrentUser.UserID;

                if (!app.Save())
                {
                    _TestAppointment.RetakeTestAppID = -1;

                    MessageBox.Show("Cannot creat retake test application",
                                 "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return ;
                }
                _TestAppointment.RetakeTestAppID = app.ApplicationID;
            }

            _TestAppointment.TestType = _TestType;
            _TestAppointment.LocalDLApplicationID = _LocalDLApplicationID;
            _TestAppointment.AppointmentDate = dateTimePicker1.Value;
            _TestAppointment.PaidFees = Convert.ToDouble(lblTestFees.Text);
            _TestAppointment.CreatedByUserID = ClsGloabl.CurrentUser.UserID;

            if (_TestAppointment.Save())
            {
                _Mode = enMode.Update;
                MessageBox.Show("Appointment saved successfully",
                        "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cannot save appointment!",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }
    }
}
