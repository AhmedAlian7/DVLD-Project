using People_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People_BusinessLayer
{
    public class clsTestType
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Fees { get; set; }

        public enum enTestType { Vision =1, Written =2, Street=3};

        public clsTestType(int ID, string Title, string Description, float Fees)
        {
            this.ID = ID;
            this.Title = Title;
            this.Description = Description;
            this.Fees = Fees;
        }

        public static clsTestType Find(int ID)
        {
            string Title = "";
            string Description = "";
            float Fees = 0;

            if (TestTypesData.GetTestByID(ID, ref Title, ref Description, ref Fees))
            {
                return new clsTestType(ID, Title, Description, Fees);
            }
            else
            {
                return null;
            }
        }

        private bool _Update()
        {
            return TestTypesData.UpdateTestType(this.ID, this.Title, this.Description, this.Fees);
        }

        public bool Save()
        {
            return _Update();
        }

        public static DataTable AppTypesTable()
        {
            return TestTypesData.GetTestsTable();
        }

    }
}
