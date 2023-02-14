using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CollegeRegistrationApp.SQL
{
    public class DBConnection
    {
        readonly String connectionString = "Server = localhost; Database = CollegeRegistration; Trusted_Connection = yes;";
        SqlConnection connection;

        public DBConnection()
        {
            // Constructor
            connection = new SqlConnection(connectionString);
        }
        ~DBConnection()
        {
            // Destructor
            connection.Close();
        }

        public void OpenConnection()
        {
            connection.Open();
        }

        //used to close the connection from other modules
        public void CloseConnection()
        {
            connection.Close();
        }


        //execute a query from a string NOTE: Close the reader when done reading, then call CloseConnection()
        public SqlDataReader? GetDataReader(String query) {
            SqlDataReader? reader = null;
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                reader = command.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
             return reader;
        }

        // returns rows affect, uses a query string of plain sql
        public int ExecuteMutation(String mutation)
        {
            int rowsAffected = 0;
            try
            {
                SqlCommand command = new SqlCommand(mutation, connection);
                rowsAffected =  command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
            return rowsAffected;
        }

        public String? ExecuteRegisterProcedureWithReturn(
            String StudentId,
            String CourseId,
            String SectionId,
            String Year,
            String Semester
            )
        {
            SqlCommand command = new SqlCommand("dbo.registerInClass", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentId", SqlDbType.Int);
            command.Parameters.Add("@CourseId", SqlDbType.Int);
            command.Parameters.Add("@SectionId", SqlDbType.Int);
            command.Parameters.Add("@Year", SqlDbType.Int);
            command.Parameters.Add("@Semester", SqlDbType.VarChar, 6);
            command.Parameters.Add("@Message", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output; ;

            command.Parameters["@StudentId"].Value = StudentId;
            command.Parameters["@CourseId"].Value = CourseId;
            command.Parameters["@SectionId"].Value = SectionId;
            command.Parameters["@Year"].Value = Year;
            command.Parameters["@Semester"].Value = Semester;

            command.ExecuteNonQuery();
            return command.Parameters["@Message"].Value.ToString();
        }

    }
}
