
using Microsoft.Data.SqlClient;
using SparkClean.Models;

namespace SparkClean.Controllers
{
    public class LoginController
    {
        private DatabaseConnection db = new DatabaseConnection();

        public User? Login(string email, string password)
        {
            using (SqlConnection connection = db.GetConnection())
            {
                connection.Open();

                string query = @"
                    SELECT UserID, FullName, Email, PasswordHash, Role
                    FROM Users
                    WHERE Email = @Email";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHash = reader["PasswordHash"].ToString()!;

                            if (BCrypt.Net.BCrypt.Verify(password, storedHash))
                            {
                                return new User
                                {
                                    UserID = (int)reader["UserID"],
                                    FullName = reader["FullName"].ToString()!,
                                    Email = reader["Email"].ToString()!,
                                    PasswordHash = storedHash,
                                    Role = reader["Role"].ToString()!
                                };
                            }
                        }
                    }
                }
            }

            return null;
        }
    }
}
