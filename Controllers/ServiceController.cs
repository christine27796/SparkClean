
using Microsoft.Data.SqlClient;
using SparkClean.Models;
using System.Collections.Generic;

namespace SparkClean.Controllers
{
    public class ServiceController
    {
        private DatabaseConnection db = new DatabaseConnection();

        // Get all cleaning services
        public List<Service> GetAllServices()
        {
            List<Service> services = new List<Service>();

            using (SqlConnection connection = db.GetConnection())
            {
                connection.Open();

                string query = @"
                    SELECT ServiceID, ServiceName, Description, Price
                    FROM Services";

                using (SqlCommand command =
                    new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        services.Add(new Service
                        {
                            ServiceID = (int)reader["ServiceID"],
                            ServiceName = reader["ServiceName"].ToString()!,
                            Description = reader["Description"] == DBNull.Value
                                ? string.Empty
                                : reader["Description"].ToString()!,
                            Price = (decimal)reader["Price"]
                        });
                    }
                }
            }

            return services;
        }

        // Add a new cleaning service
        public bool AddService(Service service)
        {
            using (SqlConnection connection = db.GetConnection())
            {
                connection.Open();

                string query = @"
                    INSERT INTO Services
                    (ServiceName, Description, Price)
                    VALUES
                    (@ServiceName, @Description, @Price)";

                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@ServiceName", service.ServiceName);

                    command.Parameters.AddWithValue(
                        "@Description",
                        string.IsNullOrWhiteSpace(service.Description)
                            ? DBNull.Value
                            : service.Description);

                    command.Parameters.AddWithValue(
                        "@Price", service.Price);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // Update an existing cleaning service
        public bool UpdateService(Service service)
        {
            using (SqlConnection connection = db.GetConnection())
            {
                connection.Open();

                string query = @"
                    UPDATE Services
                    SET ServiceName = @ServiceName,
                        Description = @Description,
                        Price = @Price
                    WHERE ServiceID = @ServiceID";

                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@ServiceID", service.ServiceID);

                    command.Parameters.AddWithValue(
                        "@ServiceName", service.ServiceName);

                    command.Parameters.AddWithValue(
                        "@Description",
                        string.IsNullOrWhiteSpace(service.Description)
                            ? DBNull.Value
                            : service.Description);

                    command.Parameters.AddWithValue(
                        "@Price", service.Price);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // Delete a cleaning service
        public bool DeleteService(int serviceID)
        {
            using (SqlConnection connection = db.GetConnection())
            {
                connection.Open();

                string query = @"
                    DELETE FROM Services
                    WHERE ServiceID = @ServiceID";

                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@ServiceID", serviceID);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
