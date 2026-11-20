
using Microsoft.Data.SqlClient;
using System;

namespace SparkClean
{
    public class DatabaseConnection
    {
        private string connectionString =
            @"Server=(localdb)\MSSQLLocalDB;Database=SparkCleanDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public bool TestConnection()
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
