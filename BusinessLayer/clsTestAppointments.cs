using People_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People_BusinessLayer
{
    public class clsTestAppointments
    {
        public enum enMode { AddNew, Update };
        public enMode Mode = enMode.AddNew;

        public int TestAppointmentID {  get; set; }
        public clsTestType.enTestType TestType { get; set; }
        public int LocalDLApplicationID { get; set; }
        public DateTime AppointmentDate {  get; set; }
        public double PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsActive { get; set; }
        public int RetakeTestAppID { get; set; }
        public clsApplication RetakeTestAppInfo { get; set; }

        public int TestID
        {
            get { return clsTestAppointmentsData.GetTestID(TestAppointmentID); }
        }

        public clsTestAppointments()
        {
            TestType = clsTestType.enTestType.Vision;
            Mode = enMode.AddNew;
        }
        private clsTestAppointments(int TestAppointmentID, clsTestType.enTestType TestType, DateTime AppointmentDate,
                            int LocalDLApplicationID, double PaidFees, int CreatedByUserID, bool IsActive, int RetakeTestAppID)
        {
            this.LocalDLApplicationID = TestAppointmentID;
            this.AppointmentDate = AppointmentDate;
            this.TestType = TestType;
            this.LocalDLApplicationID = LocalDLApplicationID;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsActive = IsActive;
            this.RetakeTestAppID = RetakeTestAppID;
            this.RetakeTestAppInfo = clsApplication.FindApplication(RetakeTestAppID);

            Mode = enMode.Update;
        }

        private bool _AddNewAppointments()
        {
            this.TestAppointmentID = clsTestAppointmentsData.AddNewAppointment((int)this.TestType,
                AppointmentDate, LocalDLApplicationID, IsActive, PaidFees, CreatedByUserID,
                this.RetakeTestAppID);
            return this.TestAppointmentID != -1;
        }

        private bool _UpdateAppointment()
        {
            return clsTestAppointmentsData.UpdateAppointment(this.TestAppointmentID,
                (int)this.TestType,
                AppointmentDate, LocalDLApplicationID, IsActive, PaidFees, CreatedByUserID
                , RetakeTestAppID);
        }

        static public clsTestAppointments Find(int AppointmentID)
        {
            int TestTypeID = -1; int LocalDLApplicationID = -1;
            DateTime AppointmentDate = DateTime.MinValue;
            double PaidFees = 0;
            int CreatedByUserID = -1; int RetakeTestAppID = -1;
            bool IsActive = false;

            if (clsTestAppointmentsData.GetAppointmentInfoByID(AppointmentID, ref TestTypeID, ref AppointmentDate,
                ref LocalDLApplicationID, ref IsActive, ref PaidFees, ref CreatedByUserID, ref RetakeTestAppID))
            {
                return new clsTestAppointments(AppointmentID, (clsTestType.enTestType)TestTypeID, AppointmentDate,
                                               LocalDLApplicationID, PaidFees, CreatedByUserID, IsActive, RetakeTestAppID);
            }
            else
                return null;
        }

        static public clsTestAppointments GetLastAppointment(int LocalDLApplicationID, int TestTypeID)
        {
            int AppointmentID = -1;
            DateTime AppointmentDate = DateTime.MinValue;
            double PaidFees = 0;
            int CreatedByUserID = -1; int RetakeTestAppID = -1;
            bool IsActive = false;

            if (clsTestAppointmentsData.GetLastAppointmentInfoByID(LocalDLApplicationID, TestTypeID, ref AppointmentDate,
                ref AppointmentID, ref IsActive, ref PaidFees, ref CreatedByUserID, ref RetakeTestAppID))
            {
                return new clsTestAppointments(AppointmentID, (clsTestType.enTestType)TestTypeID, AppointmentDate,
                                               LocalDLApplicationID, PaidFees, CreatedByUserID, IsActive, RetakeTestAppID);
            }
            else
                return null;
        }
        static public DataTable GetAppointmentsTable()
        {
            return clsTestAppointmentsData.GetAppointmentsTable();
        }

        static public DataTable GetAppointmentsTable(clsTestType.enTestType testType, int LocalDLApplicationID)
        {
            return clsTestAppointmentsData.GetAppointmentInfoByIDPerTestType(LocalDLApplicationID, (int)testType);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewAppointments())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    if (_UpdateAppointment())
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
    }
}
