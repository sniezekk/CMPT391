using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

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

        // returns the insertion id

    }
}
