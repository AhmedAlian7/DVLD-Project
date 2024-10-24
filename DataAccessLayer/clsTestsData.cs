using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People_DataAccessLayer
{
    public static class clsTestsData
    {
        static public bool GetAppointmentInfoByID(int TestID, ref int AppointmentID, ref bool TestResult,
                                                  ref string Notes, ref int UserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "SELECT * FROM Tests WHERE TestID = @ID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", TestID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    AppointmentID = (int)reader[1];
                    TestResult = (bool)reader[2];
                    Notes = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    UserID = Convert.ToInt32(reader[4]);

                }
            }
            catch
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        static public bool GetLastTestInfoByPersonIDTypeIDLicenseID(int PersonID, int TestTypeID, int LicenseClassID,
                           ref int TestID, ref int AppointmentID, ref bool TestResult,
                           ref string Notes, ref int UserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"SELECT Top 1
                                Tests.TestID, 
                                Tests.TestAppointmentID, 
                                Tests.TestResult, 
                                Tests.Notes, 
                                Tests.CreatedByUserID 
                            FROM 
                                LocalDrivingLicenseApplications
                            JOIN 
                                Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                            JOIN 
                                TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                            JOIN 
                                Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID 
                            WHERE 
                                Applications.ApplicantPersonID = @PersonID	
                                AND LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
                                AND TestAppointments.TestTypeID = TestTypeID
                            ORDER BY 
                                Applications.ApplicationDate DESC;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    AppointmentID = (int)reader[1];
                    TestResult = (bool)reader[2];
                    Notes = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    UserID = Convert.ToInt32(reader[4]);

                }
            }
            catch
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static DataTable GetAllTests()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"SELECT * FROM Test;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        static public int AddNewAppointment(int AppointmentID, bool TestResult,
                                            string Notes, int CreatedByUserID)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int PeopleID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"INSERT INTO Tests
                                VALUES
                                      (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);

                             UPDATE TestAppointments
                                SET 
                                   IsActive = 0
                              WHERE TestAppointmentID=@TestAppointmentID;

                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", AppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);





            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PeopleID = insertedID;
                }
            }

            catch
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return PeopleID;
        }

        static public bool UpdateTest(int TestID ,int TestAppointmentID, bool TestResult,
                                            string Notes, int CreatedByUserID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"Update Tests 
                             Set
                                 TestAppointmentID = @TestAppointmentID,
                             	TestResult = @TestResult,
                             	Notes = @Notes,
                             	CreatedByUserID = @CreatedByUserID
                             WHERE
                             	TestID = @TestID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestID", TestID);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        static public int GetPassedTestsCount(int LocalDLAppID)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int Passed = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"SELECT CouNT(*) 
                            FROM
                            	Tests
                            JOin 
                            	TestAppointments
                            ON 
                            	Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                            WHERE 
                            	LocalDrivingLicenseApplicationID = @LocalDLAppID And TestResult= 1;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDLAppID", LocalDLAppID);





            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    Passed = insertedID;
                }
            }

            catch
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return Passed;
        }
    }
}
