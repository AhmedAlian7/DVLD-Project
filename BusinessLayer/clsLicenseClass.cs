using People_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using People_DataAccessLayer;
using System.Data;

namespace People_BusinessLayer
{
    public class clsLicenseClass
    {
        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public int MinimumAllowedAge { get; set; }
        public int DefaultValidityLength { get; set; }
        public double ClassFees { get; set; }

        clsLicenseClass()
        {
        }
        clsLicenseClass(int licenseClassID, string className, string classDescription, int minimumAllowedAge, int defaultValidityLength, double classFees)
        {
            LicenseClassID = licenseClassID;
            ClassName = className;
            ClassDescription = classDescription;
            MinimumAllowedAge = minimumAllowedAge;
            DefaultValidityLength = defaultValidityLength;
            ClassFees = classFees;
        }

        public static clsLicenseClass Find(int ClassID)
        {
            string ClassName = "";
            string Description = "";
            int MinAge = 0;
            int Validity = 0;
            double Fees = 0;

            if (clsLicenseClassData.GetClassByID(ClassID, ref ClassName, ref Description, ref MinAge, ref Validity, ref Fees))
            {
                return new clsLicenseClass(ClassID, ClassName, Description, MinAge, Validity, Fees);
            }
            else
            {
                return null;
            }
        }

        public static DataTable AppTypesTable()
        {
            return clsLicenseClassData.GetLicenseClassesTable();
        }




    }
}
