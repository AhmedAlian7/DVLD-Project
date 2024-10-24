using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using People_DataAccessLayer;

namespace People_BusinessLayer
{
    public class clsDriver
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreationDate { get; set; }

        public clsPerson PersonInfo;
        public clsDriver()
        {
            DriverID = 0;
            PersonID = 0;
            CreatedByUserID = 0;
            CreationDate = DateTime.Now;
            Mode = enMode.AddNew;
        }
        public clsDriver(int driverID, int personID, int createdByUserID, DateTime creationDate)
        {
            DriverID = driverID;
            PersonID = personID;
            CreatedByUserID = createdByUserID;
            CreationDate = creationDate;

            PersonInfo = clsPerson.Find(personID);
            Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            this.DriverID = clsDriverData.AddnewDriver(this.PersonID, this.CreatedByUserID);

            return !(DriverID == -1);
        }
        private bool _Update()
        {
            return clsDriverData.UpdateDriver(this.DriverID,this.PersonID,this.CreatedByUserID);
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

        public static clsDriver FindByDriverID(int DriverID)
        {
            int PersonID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (clsDriverData.GetDriverInfoByDriverID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;
        }
        public static clsDriver FindByPersonID(int PersonID)
        {
            int DriverID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (clsDriverData.GetDriverInfoByPersonID(ref DriverID, PersonID, ref CreatedByUserID, ref CreatedDate))
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;
        }

        static public DataTable DriversTable()
        {
            return clsDriverData.GetAlDrivers();
        }

        public static DataTable GetDriverLicenses(int DriverID)
        {
            return clsLicense.GetDriverLicenses(DriverID);
        }
        public DataTable GetLicenses()
        {
            return clsLicense.GetDriverLicenses(this.DriverID);
        }
        //public static DataTable GetDriverInternationalLicenses(int DriverID)
        //{

        //}
    }
}
