using System;
using System.Data;
using People_DataAccessLayer;


namespace People_BusinessLayer
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        public string FullName { get { return FirstName + " " + SecondName + " " + LastName; } }


        public clsPerson()
        {
            PersonID = -1;
            NationalNo = string.Empty;
            FirstName = string.Empty;
            SecondName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.MinValue;
            Gender = string.Empty;
            Address = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            NationalityCountryID = -1;
            ImagePath = string.Empty;

            Mode = enMode.AddNew;
        }

        private clsPerson (int personID, string nationalNo, string firstName, string secondName, string lastName,
            DateTime dateOfBirth, string gender, string address, string phone, string email, int nationalityCountryID,
            string imagePath)
        {
            PersonID = personID;
            NationalNo = nationalNo;
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Address = address;
            Phone = phone;
            Email = email;
            NationalityCountryID = nationalityCountryID;
            ImagePath = imagePath;

            // Called from find method
            Mode = enMode.Update;
        }

        static public DataTable GetPeopleTable()
        {
            return PeopleData.GetAllPeople();
        }

        private bool _AddNewPerson()
        {
            //call DataAccess Layer 

            this.PersonID = PeopleData.AddNewPerson(this.NationalNo,this.FirstName, this.SecondName, this.LastName, 
                this.DateOfBirth,this.Gender, this.Address, this.Phone, this.Email, this.NationalityCountryID,this.ImagePath);

            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            //call DataAccess Layer 

            return PeopleData.UpdatePerson(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.LastName,
                this.DateOfBirth, this.Gender, this.Address, this.Phone, this.Email, this.NationalityCountryID, 
                this.ImagePath);

        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    if (_UpdatePerson())
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

        public static clsPerson Find(int ID)
        {

            string NationalNo = "" ,FirstName = "", SecondName = "", LastName = "", Email = "", Phone = "",
                Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.MinValue;
            string Gender = "";
            int NationalityCountryID = -1;

            if (PeopleData.GetPersonByID(ID, ref NationalNo, ref FirstName, ref SecondName, ref LastName,ref DateOfBirth,
                ref Gender, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))

                return new clsPerson(ID, NationalNo, FirstName, SecondName, LastName,DateOfBirth,
                           Gender, Address, Phone, Email , NationalityCountryID, ImagePath);
            else
                return null;
        }

        public static clsPerson Find(string NationalNo)
        {
            int PersonID = -1;
            string  FirstName = "", SecondName = "", LastName = "", Email = "", Phone = "",
                Address = "", ImagePath = "";
            DateTime DateOfBirth = new DateTime();
            string Gender = "";
            int NationalityCountryID = -1;

            if (PeopleData.GetPersonByNationalNo(ref PersonID, NationalNo, ref FirstName, ref SecondName, ref LastName, ref DateOfBirth,
                ref Gender, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))

                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, LastName, DateOfBirth,
                           Gender, Address, Phone, Email, NationalityCountryID, ImagePath);
            else
                return null;
        }

        public static bool IsExist(string NationalNo)
        {
            return PeopleData.IsPersonExist(NationalNo);
        }

        public static bool Delete(int PersonId)
        {
            return clsPerson.Delete(PersonId);
        }
    }
}
