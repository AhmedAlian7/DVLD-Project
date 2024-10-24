using People_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People_BusinessLayer
{
    public class clsLicense
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement =3, LostReplacement = 4}

        public int LicenseID {  get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass {  get; set; }
        public DateTime IssueDate {  get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public double PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }
        public int CreatedByUserID { get; set; }
        public string IsseReasonText{ get
            {
                switch(this.IssueReason)
                {
                    case enIssueReason.FirstTime:
                        return "FirstTime";
                    case enIssueReason.Renew:
                        return "Renew";
                    case enIssueReason.DamagedReplacement:
                        return "DamagedReplacement";
                    case enIssueReason.LostReplacement:
                        return "LostReplacement";
                    default:
                        return "";
                }
            } }

        public clsDriver DriverInfo;
        public clsLicenseClass LicenseClassInfo;

        public clsLicense()
        {
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClass = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = string.Empty;
            PaidFees = 0;
            IsActive = false;
            IssueReason = enIssueReason.FirstTime;
            CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }
        public clsLicense(int licenseID, int applicationID, int driverID, int licenseClass,
            DateTime issueDate, DateTime expirationDate, string notes, double paidFees,
            bool isActive, enIssueReason issueReason, int createdByUserID)
        {
            LicenseID = licenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            LicenseClass = licenseClass;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidFees;
            IsActive = isActive;
            IssueReason = issueReason;
            CreatedByUserID = createdByUserID;

            DriverInfo = clsDriver.FindByDriverID(DriverID);
            LicenseClassInfo = clsLicenseClass.Find(licenseClass);
            Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            this.LicenseID = clsLicenseData.AddnewLicense(ApplicationID, DriverID, LicenseClass, IssueDate,
                ExpirationDate, Notes, PaidFees, IsActive, (byte)IssueReason, CreatedByUserID);

            return !(LicenseID == -1);
        }
        private bool _Update()
        {
            return clsLicenseData.UpdateLicense(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate,
                ExpirationDate, Notes, PaidFees, IsActive, (byte)IssueReason, CreatedByUserID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    if (_Update())
                    {

                        return true;
                    }
                    else
                    {
                        return false;
                    }
            }
            return false;
        }

        public static clsLicense Find(int LicenseID)
        {
            int ApplicationID = -1; int DriverID = -1; int LicenseClass = -1;
            DateTime IssueDate = DateTime.MinValue; DateTime ExpirationDate = DateTime.MinValue;
            string Notes = string.Empty; double PaidFees = 0;
            bool IsActive = false; byte IssueReason = (byte)enIssueReason.FirstTime;
            int CreatedByUserID = -1;

            if (clsLicenseData.GetLicenseInfoByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass,
                ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive,
                ref IssueReason, ref CreatedByUserID))

                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate,
                ExpirationDate, Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);

            else
                return null;
        }

        public static DataTable GetAllLicenses()
        {
            return clsLicenseData.GetAlLicenses();
        }
        public static bool IsPersonHasLicense(int PersonID, int LicenseClass)
        {
            return !(clsLicenseData.GetActiveLicenseIDForPerson(PersonID, LicenseClass) == -1);
        }
        public static int GetPersonLicenseID(int PersonID, int LicenseClass)
        {
            return clsLicenseData.GetActiveLicenseIDForPerson(PersonID, LicenseClass);
        }
        public static DataTable GetDriverLicenses(int DriverID)
        {
            return clsLicenseData.GetDriverLicenses(DriverID);
        }
        public bool IsLicenseExpired()
        {
            return (this.ExpirationDate <= DateTime.Now);
        }
        public bool DeactivateLicense()
        {
            return clsLicenseData.DeactivateLicense(this.LicenseID);
        }

        public clsLicense Replace(enIssueReason reason, int UserID)
        {
            clsApplication application = new clsApplication();

            application.ApplicantPersonID = this.DriverInfo.PersonID;
            application.ApplicatonDate = DateTime.Now;
            application.ApplicationTypeID =
                (reason == enIssueReason.DamagedReplacement ?
                (int)clsApplicationType.enApplicationType.ReplacementDamagedDrivingLicense :
                (int)clsApplicationType.enApplicationType.ReplacementLostDrivingLicense);
            application.ApplicationStatus = clsApplication.enStaus.Completed;
            application.LastStatusUpdate = DateTime.Now;
            application.PaidFees = clsApplicationType.Find(application.ApplicationTypeID).Fees;
            application.CreatedUserID = UserID;

            if (!application.Save()) return null;

            clsLicense NewLicense = new clsLicense();
            NewLicense.ApplicationID = application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClass = this.LicenseClass;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = this.ExpirationDate;
            NewLicense.Notes = this.Notes;
            NewLicense.PaidFees = 0;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = reason;
            NewLicense.CreatedByUserID = UserID;

            if (!NewLicense.Save()) return null;

            DeactivateLicense();

            return NewLicense;


        }

        public clsLicense RenewLicense(string Notes, int UserID)
        {
            clsApplication application = new clsApplication();

            application.ApplicantPersonID = this.DriverInfo.PersonID;
            application.ApplicatonDate = DateTime.Now;
            application.ApplicationTypeID = (int)clsApplicationType.enApplicationType.RenewDrivingLicense;
            application.ApplicationStatus = clsApplication.enStaus.Completed;
            application.LastStatusUpdate = DateTime.Now;
            application.PaidFees = clsApplicationType.Find(application.ApplicationTypeID).Fees;
            application.CreatedUserID = UserID;

            if (!application.Save()) return null;

            clsLicense NewLicense = new clsLicense();
            NewLicense.ApplicationID = application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClass = this.LicenseClass;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = this.LicenseClassInfo.ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = enIssueReason.Renew;
            NewLicense.CreatedByUserID = UserID;

            if (!NewLicense.Save()) return null;

            DeactivateLicense();

            return NewLicense;

        }
    }
}
