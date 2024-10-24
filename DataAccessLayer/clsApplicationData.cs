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
    public class clsApplicationData
    {
        static public bool GetAppByID(int ID, 
                                      ref int PersonID, ref DateTime AppDate, 
                                      ref int AppTypeID, ref int AppStatusID, ref DateTime LastStatus,
                                      ref double PaidFees, ref int CreatedUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "SELECT * FROM Applications WHERE ApplicationID = @ID; ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["ApplicantPersonID"];
                    AppDate = Convert.ToDateTime(reader["ApplicationDate"]);
                    PersonID = (int)reader["ApplicantPersonID"];
                    AppTypeID = (int)reader["ApplicationTypeID"];
                    AppStatusID = Convert.ToInt32(reader["ApplicationStatus"]);
                    LastStatus = Convert.ToDateTime(reader["LastStatusDate"]);
                    PaidFees = Convert.ToDouble(reader["PaidFees"]);
                    CreatedUserID = (int)reader["CreatedByUserID"];
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

        public static DataTable GetAllApplictions()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"SELECT * FROM Applications ORDER BY ApplicationDate;";

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

            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        static public int AddNewApplication(
                                            int PersonID, DateTime AppDate,
                                            int AppTypeID, int AppStatusID, DateTime LastStatus,
                                            double PaidFees, int CreatedUserID
                                           )
        {
            //this function will return the new id if succeeded and -1 if not.
            int ApplicationID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"INSERT INTO [dbo].[Applications]
                                    VALUES
                                        (@ApplicantPersonID
                                        ,@ApplicationDate
                                        ,@ApplicationTypeID
                                        ,@ApplicationStatus
                                        ,@LastStatusDate
                                        ,@PaidFees
                                        ,@CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            command.Parameters.AddWithValue("@ApplicationDate", AppDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", AppTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", AppStatusID);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatus);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedUserID);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ApplicationID = insertedID;
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

        static public bool UpdateApplication(int ApplicationID,
                                            int PersonID, DateTime AppDate,
                                            int AppTypeID, int AppStatusID, DateTime LastStatus,
                                            double PaidFees, int CreatedUserID
                                            )
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"UPDATE [dbo].[Applications]
                                   SET [ApplicantPersonID] = @ApplicantPersonID
                                      ,[ApplicationDate] = 	 @ApplicationDate 
                                      ,[ApplicationTypeID] = @ApplicationTypeID
                                      ,[ApplicationStatus] = @ApplicationStatus
                                      ,[LastStatusDate] = 	 @LastStatusDate 
                                      ,[PaidFees] = 		 @PaidFees 
                                      ,[CreatedByUserID] = 	 @CreatedByUserID
                                 WHERE 
		                                ApplicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            command.Parameters.AddWithValue("@ApplicationDate", AppDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", AppTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", AppStatusID);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatus);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedUserID);

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


        static public bool DeleteApplication(int ApplicationID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"DELETE FROM Applications
                                      WHERE ApplicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", ApplicationID);

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

        public static bool IsApplicationExist(int ApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "SELECT Found =1  FROM Applications WHERE ApplicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", ApplicationID);


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

        static public int GetActiveApplication(
                                            int PersonID, 
                                            int AppTypeID
                                              )
        {
            //this function will return the new id if succeeded and -1 if not.
            int ApplicationID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"SELECT Applications.ApplicationID FROM Applications 
			WHERE ApplicantPersonID = @ApplicantPersonID AND ApplicationTypeID = @ApplicationTypeID AND ApplicationStatus =1; ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", AppTypeID);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ApplicationID = insertedID;
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

        static public int GetActiveApplicationForLisenceClass(
                                                                int PersonID,
                                                                int AppTypeID,
                                                                int LisenseClass
                                                             )
        {
            //this function will return the new id if succeeded and -1 if not.
            int ApplicationID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"SELECT Applications.ApplicationID FROM Applications JOIN
                             LocalDrivingLicenseApplications ON Applications.ApplicationID =  LocalDrivingLicenseApplications.ApplicationID
                             WHERE ApplicantPersonID =@ApplicantPersonID AND
                             ApplicationTypeID = @ApplicationTypeID AND
                             LocalDrivingLicenseApplications.LicenseClassID = @LisenseClass AND  Applications.ApplicationStatus =1;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", AppTypeID);
            command.Parameters.AddWithValue("@LisenseClass", LisenseClass);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ApplicationID = insertedID;
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

        static public bool UpdateApplicationStatus(int ApplicationID,
                                                   int NewStatus
                                                  )
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"UPDATE [dbo].[Applications]
                                   SET 
                                      [ApplicationStatus] = @ApplicationStatus
                                      ,[LastStatusDate] = 	 @LastStatusDate 
                                 WHERE 
		                                ApplicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@ApplicationStatus", NewStatus);
            command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);


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

    }


}
