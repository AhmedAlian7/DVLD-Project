using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People_DataAccessLayer
{
    public class clsTestAppointmentsData
    {
        static public bool GetAppointmentInfoByID(int ID,
                              ref int TestTypeID, ref DateTime AppointmentDate,
                              ref int LocalDLApplicationID, ref bool IsActive,
                              ref double PaidFees, ref int CreatedUserID, ref int RetakeTestAppID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "SELECT * FROM TestAppointments WHERE TestAppointmentID = @ID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    TestTypeID = (int)reader[1];
                    LocalDLApplicationID = (int)reader[2];
                    AppointmentDate = Convert.ToDateTime(reader[3]);
                    PaidFees = Convert.ToDouble(reader[4]);
                    CreatedUserID = (int)reader[5];
                    IsActive = (bool)reader[6];
                    RetakeTestAppID = reader[7] == DBNull.Value ? -1 : (int)reader[7];
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


        static public bool GetLastAppointmentInfoByID(int LocalDLApplicationID, int TestTypeID,
                                    ref DateTime AppointmentDate,
                                    ref int AppointmentID, ref bool IsActive,
                                    ref double PaidFees, ref int CreatedUserID, ref int RetakeTestAppID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"SELECT TOP 1 * FROM TestAppointments WHERE TestTypeID =@TestTypeID AND LocalDrivingLicenseApplicationID =LocalDrivingLicenseApplicationID
                                ORDER BY TestAppointmentID DESC;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDLApplicationID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    AppointmentID = (int)reader[0];
                    AppointmentDate = Convert.ToDateTime(reader[3]);
                    PaidFees = Convert.ToDouble(reader[4]);
                    CreatedUserID = (int)reader[5];
                    IsActive = (bool)reader[6];
                    RetakeTestAppID = reader[7] == DBNull.Value ? -1 : (int)reader[7];

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

        public static DataTable GetAppointmentsTable()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"SELECT * FROM TestAppointments_View1;";

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

        static public DataTable GetAppointmentInfoByIDPerTestType(int LocalDLApplicationID, int TestTypeID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"SELECT * FROM TestAppointments WHERE TestTypeID =@TestTypeID AND LocalDrivingLicenseApplicationID =LocalDrivingLicenseApplicationID
                                ORDER BY TestAppointmentID DESC;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDLApplicationID);


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
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        static public int AddNewAppointment(
                               int TestTypeID,  DateTime AppointmentDate,
                               int LocalDLApplicationID,  bool IsActive,
                               double PaidFees, int CreatedUserID, int RetakeTestAppID)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int PeopleID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"INSERT INTO TestAppointments VALUES
            (@TestTypeID ,@LocalDrivingLicenseApplicationID, @AppointmentDate, @PaidFees, @CreatedByUserID, @IsActive, @RetakeTestAppID);
			SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDLApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedUserID);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@@RetakeTestAppID", RetakeTestAppID);




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


        static public bool UpdateAppointment(int AppointmentID
                                            ,int TestTypeID, DateTime AppointmentDate,
                                             int LocalDLApplicationID, bool IsActive,
                                             double PaidFees, int CreatedUserID, int RetakeTestAppID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"Update  TestAppointments  
                 set  
                     TestTypeID = @TestTypeID, 
                     LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID, 
                     AppointmentDate = @AppointmentDate,
                     PaidFees = @PaidFees,
                     CreatedByUserID = @CreatedByUserID,
                     IsActive = @IsActive
                     RetakeTestAppID = @RetakeTestAppID

                     where TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", AppointmentID);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDLApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@RetakeTestAppID", RetakeTestAppID);

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

        static public int GetTestID(int AppointmentID)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int TestID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"SELECT TestID FROM Tests WHERE TestAppointmentID =@TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", AppointmentID);




            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestID = insertedID;
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


            return TestID;
        }
    }
}
