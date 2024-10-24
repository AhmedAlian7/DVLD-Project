using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace People_DataAccessLayer
{
    public class clsLocalDLApplicationData
    {
        static public bool GetLocalDLAppByID(int LoacalDLAppID, ref int AppliactionID, ref int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @ID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", LoacalDLAppID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    AppliactionID = Convert.ToInt32(reader["ApplicationID"]);
                    LicenseClassID = Convert.ToInt32(reader["LicenseClassID"]);
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

        static public bool GetLocalDLAppByBaseApplicationID(ref int LoacalDLAppID, int AppliactionID, ref int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE ApplicationID = @ID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", AppliactionID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    AppliactionID = (int)reader["AppliactionID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
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

        public static DataTable GetAllLocalDLApplications()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"SELECT * FROM LocalDrivingLicenseApplication_View1 ORDER BY ApplicationDate DESC;";

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


        static public int AddNewLocalDLApplication(
                                            int ApplicationID, int LicenseClassID
                                           )
        {
            //this function will return the new id if succeeded and -1 if not.
            int LocalDLApplicationID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"INSERT INTO LocalDrivingLicenseApplications
                                 VALUES
                                       (@ApplicationID,
                                        @LicenseClassID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);




            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LocalDLApplicationID = insertedID;
                }
            }

            catch
            {
            }

            finally
            {
                connection.Close();
            }


            return ApplicationID;
        }

        static public bool UpdateLocalDLApplication(int LoacalDLAppID, int AppliactionID, int LicenseClassID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"UPDATE LocalDrivingLicenseApplications
                               SET [ApplicationID] = @AppliactionID
                                  ,[LicenseClassID] = @LicenseClassID
                             WHERE LocalDrivingLicenseApplicationID = @LoacalDLAppID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LoacalDLAppID", LoacalDLAppID);

            command.Parameters.AddWithValue("@AppliactionID", AppliactionID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

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

        static public bool DeleteLocalDLApplication(int LoacalDLAppID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"DELETE FROM LocalDrivingLicenseApplications
                                      WHERE LocalDrivingLicenseApplicationID = @LoacalDLAppID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LoacalDLAppID", LoacalDLAppID);

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

        static public int TestAttendanceTrails(int TestType, int LocalDLAppID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"SELECT * FROM TestAppointments 
                        where LocalDrivingLicenseApplicationID = LoacalDLAppID and TestTypeID = @TestType;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LoacalDLAppID", LocalDLAppID);
            command.Parameters.AddWithValue("@TestType", TestType);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch
            {
                //Console.WriteLine("Error: " + ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return rowsAffected;
        }

        static public bool IsThereActiveAppointment(int LocalDLAppID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "SELECT found =1 FROM TestAppointments where LocalDrivingLicenseApplicationID =@ID and IsActive = 1;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", LocalDLAppID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        static public bool IsPassthisTest(int LocalDLAppID, int TestType)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"SELECT found =1 FROM Tests JOIN TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID 
	                            WHERE LocalDrivingLicenseApplicationID = @LocalDLAppID AND TestTypeID = @TestType AND TestResult =1;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDLAppID", LocalDLAppID);
            command.Parameters.AddWithValue("@TestType", TestType);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        static public bool IsThereActiveAppointment(int LocalDLAppID, int TestTypeID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "SELECT found =1 FROM TestAppointments where LocalDrivingLicenseApplicationID =@ID and IsActive = 1 AND TestTypeID = @TestType;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", LocalDLAppID);
            command.Parameters.AddWithValue("@TestType", TestTypeID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        static public int PassedTests(int LocalDLAppID)
        {
            int PassedTests = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"Select Count(1) 
	                    from Tests JOin TestAppointments
                            ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
	Where Tests.TestResult = 1 and TestAppointments.LocalDrivingLicenseApplicationID =@LoacalDLAppID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LoacalDLAppID", LocalDLAppID);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PassedTests = insertedID;
                }
            }

            catch
            {
            }

            finally
            {
                connection.Close();
            }


            return PassedTests;
        }

        static public int LicenseIDforApp(int LocalDLAppID)
        {
            int LicenseID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"SELECT Licenses.LicenseID 
                             	FROM LocalDrivingLicenseApplications JOIN Licenses
                             ON LocalDrivingLicenseApplications.ApplicationID = Licenses.ApplicationID
                             	WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =@LoacalDLAppID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LoacalDLAppID", LocalDLAppID);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseID = insertedID;
                }
            }

            catch
            {
            }

            finally
            {
                connection.Close();
            }


            return LicenseID ;
        }


    }
}
