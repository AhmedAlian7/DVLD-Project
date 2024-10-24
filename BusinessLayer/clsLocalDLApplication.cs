using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using People_DataAccessLayer;
using static System.Net.Mime.MediaTypeNames;

namespace People_BusinessLayer
{
    public class clsLocalDLApplication : clsApplication
    {
        public enum enMode { AddNew, Update};
        public enMode Mode { get; set; }
        public int LocalDLApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public string PersonFullName { get { return base.PersonInfo.FullName; } }

        public clsLicenseClass LicenseClassInfo;
        public clsLocalDLApplication() 
        {
            Mode = enMode.AddNew; 

            LocalDLApplicationID = 0;
            LicenseClassID = 0;
        }
        private clsLocalDLApplication(int localDLApplicationID, int licenseClassID,
                                     int ApplicationID,
                                     int PersonID, DateTime AppDate,
                                     int AppTypeID, enStaus AppStatus, DateTime LastStatus,
                                     double PaidFees, int CreatedUserID
                                     )
        {
            Mode = enMode.Update;

           this.LocalDLApplicationID = localDLApplicationID;
           this.LicenseClassID = licenseClassID;

            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = PersonID;
            this.ApplicatonDate = AppDate;
            this.ApplicationTypeID = AppTypeID;
            this.ApplicationStatus = AppStatus;
            this.LastStatusUpdate = LastStatus;
            this.PaidFees = PaidFees;
            this.CreatedUserID = CreatedUserID;

            LicenseClassInfo = clsLicenseClass.Find(this.LicenseClassID);

        }

        private bool _AddNewLocalDLApplication()
        {
            this.LocalDLApplicationID = clsLocalDLApplicationData.AddNewLocalDLApplication(
                                                                                            this.ApplicationID, this.LicenseClassID

                                                                                          );
            return this.LocalDLApplicationID != -1;
        }
        private bool _UpdateLocalDLApplication()
        {
            return clsLocalDLApplicationData.UpdateLocalDLApplication( this.LocalDLApplicationID,
                                                                       this.ApplicationID, this.LicenseClassID
                                                                     );
        }
        static public clsLocalDLApplication FindByLocalDLApplicationID( int localDLApplicationID )
        {
            int LicenseClassID = -1;
            int ApplicationID = -1;

            if (clsLocalDLApplicationData.GetLocalDLAppByID(localDLApplicationID,ref ApplicationID, ref LicenseClassID))
            {
                clsApplication application = clsApplication.FindApplication(ApplicationID);

                return new clsLocalDLApplication(localDLApplicationID, LicenseClassID, ApplicationID,
                                                 application.ApplicantPersonID, application.ApplicatonDate,
                                                 application.ApplicationTypeID, application.ApplicationStatus,
                                                 application.LastStatusUpdate, application.PaidFees, application.CreatedUserID);
            }
            else
            {
                return null;
            }    
                

        }
        static public clsLocalDLApplication FindByBaseApplicationID(int ApplicationID)
        {
            int LicenseClassID = -1;
            int LocalDLApplicationID = -1;

            if (clsLocalDLApplicationData.GetLocalDLAppByBaseApplicationID(ref LocalDLApplicationID, ApplicationID, ref LicenseClassID))
            {
                clsApplication application = FindApplication(ApplicationID);

                return new clsLocalDLApplication(LocalDLApplicationID, LicenseClassID, ApplicationID,
                                                 application.ApplicantPersonID, application.ApplicatonDate,
                                                 application.ApplicationTypeID, application.ApplicationStatus,
                                                 application.LastStatusUpdate, application.PaidFees, application.CreatedUserID);
            }
            else
            {
                return null;
            }


        }

        public bool Save()
        {
            base.ApplicationMode = (clsApplication.enMode) this.Mode;

            if (!base.Save())
                return false;

            switch (Mode)
            {
                case enMode.AddNew :
                    if (_AddNewLocalDLApplication())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return (_UpdateLocalDLApplication());
            }
            return false;
        }

        static public DataTable GetAllLocalDLApplications()
        {
            return clsLocalDLApplicationData.GetAllLocalDLApplications();
        }

        public bool Delete()
        {
            return clsLocalDLApplicationData.DeleteLocalDLApplication(this.LocalDLApplicationID);
        }

        public bool DoesAttendTest(clsTestType.enTestType TestType)
        {
            return clsLocalDLApplicationData.TestAttendanceTrails((int)TestType, this.LocalDLApplicationID) > 0;
        }
        public int TotalTrialsPerTest(clsTestType.enTestType TestType)
        {
            return clsLocalDLApplicationData.TestAttendanceTrails((int)TestType, this.LocalDLApplicationID);
        }
        public bool IsThereActiveAppointment()
        {
            return clsLocalDLApplicationData.IsThereActiveAppointment(this.LocalDLApplicationID);
        }
        public bool IsThereActiveAppointment(clsTestType.enTestType testType)
        {
            return clsLocalDLApplicationData.IsThereActiveAppointment(this.LocalDLApplicationID, (int)testType);
        }

        public bool IsPassThisTest(clsTestType.enTestType TestType)
        {
            return clsLocalDLApplicationData.IsPassthisTest(this.LocalDLApplicationID, (int)TestType);
        }
        public bool PassedAllTests()
        {
            return (clsLocalDLApplicationData.PassedTests(this.LocalDLApplicationID) == 3);

        }

        public clsTest GetLastTestPerTestType(clsTestType.enTestType TestType)
        {
            return clsTest.FindLastTestInfoByPersonIDTypeIDLicenseID(this.ApplicantPersonID, this.LicenseClassID, TestType);
        }

        public int IssueLicenseForFirstTime(string Notes, int UserID)
        {
            int DriverID = -1;

            clsDriver driver = clsDriver.FindByPersonID(this.ApplicantPersonID);
            if (driver == null)
            {
                driver = new clsDriver();
                driver.PersonID = this.ApplicantPersonID;
                driver.CreatedByUserID = UserID;
                driver.CreationDate = DateTime.Now;
                if (driver.Save())
                    driver.DriverID = DriverID;
                else
                    return -1;

            }
            else
                DriverID = driver.DriverID;


            clsLicense NewLicense = new clsLicense();
            NewLicense.ApplicationID = this.ApplicationID;
            NewLicense.DriverID = DriverID;
            NewLicense.LicenseClass = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(clsLicenseClass.Find(this.LicenseClassID).DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = clsLicenseClass.Find(this.LicenseClassID).ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = clsLicense.enIssueReason.FirstTime;
            NewLicense.CreatedByUserID = UserID;

            if (NewLicense.Save())
            {
                this.setCompleted();
                return NewLicense.LicenseID;
            }
            else
            {
                return -1;
            }
        }

        public int LicenseID
        {
            get { return clsLocalDLApplicationData.LicenseIDforApp(this.LocalDLApplicationID); }
        }
        public clsLicense LicenseInfo
        {
            get { return LicenseID == -1 ? null : clsLicense.Find(LicenseID); }
        }
    }
}
