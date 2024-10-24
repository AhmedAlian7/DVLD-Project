using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using People_DataAccessLayer;

namespace People_BusinessLayer
{
    public class clsApplicationType
    {
        public  int ID { get; set; }
        public string Title { get; set; }
        public float Fees { get; set; }

        public enum enApplicationType { NewLocalDrivingLicense, RenewDrivingLicense, ReplacementLostDrivingLicense, ReplacementDamagedDrivingLicense, ReleaseDetainedDrivingLicsense, NewInternationalLicense, RetakeTest };

        public clsApplicationType(int ID, string Title, float Fees) 
        {
            this.ID = ID;   
            this.Title = Title; 
            this.Fees = Fees;
        }

        public static clsApplicationType Find(int ID)
        {
            string Title = "";
            float Fees = 0;

            if(AppTypesData.GetAppByID(ID, ref Title, ref Fees))
            {
                return new clsApplicationType(ID, Title, Fees);
            }
            else
            {
                return null;
            }
        }

        private bool _Update()
        {
            return AppTypesData.UpdateApp(this.ID, this.Title, this.Fees);
        }

        public bool Save()
        {
            return _Update();
        }

        public static DataTable AppTypesTable()
        {
            return AppTypesData.GetAppTable();
        }

    }
}
