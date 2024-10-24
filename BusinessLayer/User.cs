using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using People_DataAccessLayer;

namespace People_BusinessLayer
{
    public class User
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public clsPerson PersonInfo;

        public User() 
        {
            Mode = enMode.AddNew;

        }
        User(int userID, int personID, string userName, string password, bool isActive)
        {
            Mode = enMode.Update;
            UserID = userID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            IsActive = isActive;
            PersonInfo = clsPerson.Find(PersonID);
        }

        private bool _AddNew()
        {
            this.UserID = UsersData.AddUser(this.PersonID, this.UserName, this.Password, this.IsActive);

            if (UserID == -1)
                return false;
            else
                return true;
        }
        private bool _Update()
        {
            return UsersData.UpdateUser(this.UserID, this.PersonID, this.UserName, this.Password, this.IsActive);
        }

        public static User FindByUserID(int userID)
        {
            int PersonID =-1;
            string UserName = "", Password ="";
            bool IsActive = false;

            if (UsersData.GetUserInfoByUserID(userID, ref PersonID, ref UserName, ref Password, ref IsActive))
                return new User(userID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }
        public static User FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;

            if (UsersData.GetUserInfoByPersonID(ref UserID,PersonID, ref UserName, ref Password, ref IsActive))
                return new User(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }

        public static User Find(string UserName, string Password)
        {
            int UserID = -1;
            int PersonID = -1;
            bool IsActive = false;

            if (UsersData.GetUserInfoByUserNameAndPass(ref UserID,ref PersonID,  UserName,  Password, ref IsActive))
                return new User(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }
        static public bool IsUserExist(string UserName)
        {
            return UsersData.IsUserExist(UserName);
        }

        static public bool IsUserActive(string UserName, string Password)
        {
            return UsersData.IsUserActive(UserName, Password);
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

        public static bool IsExistForPerson(int PersonId) 
        {
            return UsersData.IsUserExistsForPerson(PersonId);
        }

        public static bool ChangePass(int UserID, string NewPassword)
        {
            return UsersData.ChangePassword(UserID, NewPassword);
        }

        static public DataTable UsersTable()
        {
            return UsersData.GetAlUsers();
        }

        static public bool DeleteUser(int UserID)
        {
            return UsersData.DeleteUser(UserID);
        }
    }
}
