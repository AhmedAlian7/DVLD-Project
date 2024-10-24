using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using People_DataAccessLayer;

namespace People_BusinessLayer
{
    public class clsApplication
    {
        public enum enStaus { New =1, Cancelled =2, Completed =3};
        public enum enMode { AddNew, Update};

        public string StatusText { get 
            {
                if (this.ApplicationStatus == enStaus.New) return "New";
                if (this.ApplicationStatus == enStaus.Cancelled) return "Cancelled";
                if (this.ApplicationStatus == enStaus.Completed) return "Completed";
                return "";
            }
        }
        public enMode ApplicationMode { get; set; }
        public int ApplicationID {  get; set; }
        public int ApplicantPersonID {  get; set; }
        public clsPerson PersonInfo { get { return clsPerson.Find(ApplicantPersonID); } }
        public DateTime ApplicatonDate { get; set; }
        public int ApplicationTypeID  { get; set; }
        public clsApplicationType ApplicationType { get { return clsApplicationType.Find(ApplicationTypeID); } }
        public enStaus ApplicationStatus { get; set; }
        public DateTime LastStatusUpdate { get; set; }
        public double PaidFees { get; set; }
        public int CreatedUserID { get; set; }
        public User CreatedUserInfo { get { return User.FindByUserID(CreatedUserID); } }

        public clsApplication()
        {
            ApplicationMode = enMode.AddNew;

            ApplicationID = -1;
            ApplicantPersonID = -1;
            ApplicatonDate = DateTime.Now; 
            ApplicationTypeID = -1;
            PaidFees = 0;
            LastStatusUpdate = DateTime.Now;
            CreatedUserID = -1;
        }
        private clsApplication(int ApplicationID,
                               int PersonID, DateTime AppDate,
                               int AppTypeID, enStaus AppStatus, DateTime LastStatus,
                               double PaidFees, int CreatedUserID)
        {
            ApplicationMode = enMode.Update;

            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = PersonID;
            this.ApplicatonDate = AppDate;
            this.ApplicationTypeID = AppTypeID;
            this.ApplicationStatus = AppStatus;
            this.LastStatusUpdate = LastStatus;
            this.PaidFees = PaidFees;
            this.CreatedUserID = CreatedUserID;
        }


        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationData.AddNewApplication(this.ApplicantPersonID, this.ApplicatonDate,
                                                                      this.ApplicationTypeID, (int)this.ApplicationStatus,
                                                                      this.LastStatusUpdate, this.PaidFees, this.CreatedUserID);
            return ApplicationID != -1;
                
        }

        private bool _UpdateApplication()
        {
            return clsApplicationData.UpdateApplication(this.ApplicationID,
                                                        this.ApplicantPersonID, this.ApplicatonDate,
                                                        this.ApplicationTypeID, (int)this.ApplicationStatus,
                                                        this.LastStatusUpdate, this.PaidFees, this.CreatedUserID);
        }

        public bool Save()
        {
            switch (ApplicationMode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {

                        ApplicationMode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    if (_UpdateApplication())
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

        static public clsApplication FindApplication(int ApplicationID)
        {
            int ApplicantPersonID = -1;
            DateTime ApplicatonDate = DateTime.MinValue;
            int ApplicationTypeID = -1;
            int ApplicationStatus = -1;
            DateTime LastStatusUpdate = DateTime.MinValue;
            double PaidFees = 0;
            int CreatedUserID = -1;

            if (clsApplicationData.GetAppByID(ApplicationID, ref  ApplicantPersonID, ref  ApplicatonDate, 
                                              ref ApplicationTypeID, ref ApplicationStatus, ref LastStatusUpdate,
                                              ref PaidFees, ref CreatedUserID))
            {
                return new clsApplication(ApplicationID, ApplicantPersonID, ApplicatonDate, ApplicationTypeID, (enStaus)ApplicationStatus, LastStatusUpdate, PaidFees, CreatedUserID);
            }
            else
            {
                return null;
            }


        }
        public bool Cancel()
        {
            return clsApplicationData.UpdateApplicationStatus(this.ApplicationID, (int)enStaus.Cancelled);
        }
        public bool setCompleted()
        {
            return clsApplicationData.UpdateApplicationStatus(this.ApplicationID, (int)enStaus.Completed);
        }
        public bool Delete()
        {
            return clsApplicationData.DeleteApplication(this.ApplicationID);
        }
        static public bool isExist(int ApplicationID) 
        {
            return clsApplicationData.IsApplicationExist(ApplicationID);
        }
        static public bool DoesPersonHasActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return (clsApplicationData.GetActiveApplication(PersonID, ApplicationTypeID) != -1);
        }
        public bool DoesPersonHasActiveApplication(int ApplicationTypeID)
        {
            return (clsApplicationData.GetActiveApplication(this.ApplicantPersonID, ApplicationTypeID) != -1);
        }
        static public int GetActiveApplicationID(int PersonID, int ApplicationTypeID)
        {
            return clsApplicationData.GetActiveApplication(PersonID, ApplicationTypeID);
        }
        static public int GetActiveApplicationIDForLicenseClass(int PersonID, int ApplicationTypeID, int LicenseClassID)
        {
            return clsApplicationData.GetActiveApplicationForLisenceClass(PersonID, ApplicationTypeID, LicenseClassID);
        }
        static public bool DoesPersonHasActiveApplicationForLicenseClass(int PersonID, int ApplicationTypeID, int LicenseClassID)
        {
            return clsApplicationData.GetActiveApplicationForLisenceClass(PersonID, ApplicationTypeID, LicenseClassID) != -1;
        }
        public bool DoesPersonHasActiveApplicationForLicenseClass(int ApplicationTypeID, int LicenseClassID)
        {
            return clsApplicationData.GetActiveApplicationForLisenceClass(this.ApplicantPersonID, ApplicationTypeID, LicenseClassID) != -1;
        }

    }
}
