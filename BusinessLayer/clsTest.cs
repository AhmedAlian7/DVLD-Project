using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using People_DataAccessLayer;

namespace People_BusinessLayer
{
    public class clsTest
    {
        public enum enMode { AddNew, Update};
        public enMode Mode = enMode.AddNew;

        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public clsTestAppointments AppointmentInfo { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedUserID { get; set; }

        public clsTest()
        {
            Mode = enMode.AddNew;
            TestID = -1;
            TestAppointmentID = -1;
            TestResult = false;
            CreatedUserID = -1;
        }
        
        private clsTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedUserID = CreatedUserID;

            AppointmentInfo = clsTestAppointments.Find(TestAppointmentID);
            Mode = enMode.Update;
        }

        bool _AddNew()
        {
            this.TestID =  clsTestsData.AddNewAppointment(TestAppointmentID, TestResult, Notes, CreatedUserID);
            return TestID != -1;
        }
        bool _Update()
        {
            return clsTestsData.UpdateTest(TestID, TestAppointmentID, TestResult, Notes, CreatedUserID);
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

        public static clsTest Find(int TestID)
        {
            int TestAppointmentID = -1; bool TestResult = false;
            string Notes = ""; int UserID = -1;

            if (clsTestsData.GetAppointmentInfoByID(TestID, ref TestAppointmentID, ref TestResult, ref Notes, ref UserID))
            {
                return new clsTest(TestID, TestAppointmentID, TestResult, Notes, UserID);
            }
            else
                return null;

        }

        public static clsTest FindLastTestInfoByPersonIDTypeIDLicenseID(int PersonID, int LicenseClassID, clsTestType.enTestType TestType)
        {
            int TestID = -1;
            int TestAppointmentID = -1; bool TestResult = false;
            string Notes = ""; int UserID = -1;

            if (clsTestsData.GetLastTestInfoByPersonIDTypeIDLicenseID ( PersonID, (int)TestType, LicenseClassID
                ,ref TestID, ref TestAppointmentID, ref TestResult, ref Notes, ref UserID))
            {
                return new clsTest(TestID, TestAppointmentID, TestResult, Notes, UserID);
            }
            else
                return null;

        }

        static public DataTable GetTestsTable()
        {
            return clsTestsData.GetAllTests();
        }

        public static int GetPassedTestCount(int LocalDLappID)
        {
            return clsTestsData.GetPassedTestsCount(LocalDLappID);
        }

        public static bool DoesPassAllTests(int LocalDLappID)
        {
            return clsTestsData.GetPassedTestsCount(LocalDLappID) == 3;
        }
    }
}
