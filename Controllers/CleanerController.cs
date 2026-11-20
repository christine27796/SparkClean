
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using SparkClean;
using SparkClean.Models;

namespace SparkClean.Controllers
{
    public class CleanerController
    {
        private DatabaseConnection db = new DatabaseConnection();

        // GET ALL CLEANERS
        public List<Cleaner> GetAllCleaners()
        {
            List<Cleaner> cleaners = new List<Cleaner>();

            using (SqlConnection connection = db.GetConnection())
            {
                connection.Open();

                string query = @"
                    SELECT c.CleanerID, c.UserID,
                           u.FullName, u.Email, c.Phone
                    FROM Cleaners c
                    INNER JOIN Users u ON c.UserID = u.UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cleaners.Add(new Cleaner
                        {
                            CleanerID = (int)reader["CleanerID"],
                            UserID = (int)reader["UserID"],
                            FullName = reader["FullName"].ToString()!,
                            Email = reader["Email"].ToString()!,
                            Phone = reader["Phone"] == DBNull.Value
                                ? ""
                                : reader["Phone"].ToString()!
                        });
                    }
                }
            }

            return cleaners;
        }

        // ADD CLEANER WITH ADMIN-CREATED PASSWORD
        public bool AddCleaner(
            string fullName,
            string email,
            string phone,
            string password)
        {
            using (SqlConnection connection = db.GetConnection())
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string userQuery = @"
                            INSERT INTO Users
                            (FullName, Email, PasswordHash, Role)
                            VALUES
                            (@FullName, @Email, @PasswordHash, 'Cleaner');

                            SELECT CAST(SCOPE_IDENTITY() AS INT);";

                        int userID;

                        using (SqlCommand command =
                            new SqlCommand(userQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@FullName", fullName);
                            command.Parameters.AddWithValue("@Email", email);
                            command.Parameters.AddWithValue(
                                "@PasswordHash",
                                PasswordHelper.HashPassword(password));

                            userID = (int)command.ExecuteScalar();
                        }

                        string cleanerQuery = @"
                            INSERT INTO Cleaners (UserID, Phone)
                            VALUES (@UserID, @Phone)";

                        using (SqlCommand command =
                            new SqlCommand(cleanerQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@UserID", userID);
                            command.Parameters.AddWithValue("@Phone", phone);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // UPDATE CLEANER
        public bool UpdateCleaner(Cleaner cleaner)
        {
            using (SqlConnection connection = db.GetConnection())
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string userQuery = @"
                            UPDATE Users
                            SET FullName = @FullName,
                                Email = @Email
                            WHERE UserID = @UserID
                            AND Role = 'Cleaner'";

                        using (SqlCommand command =
                            new SqlCommand(userQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@FullName", cleaner.FullName);
                            command.Parameters.AddWithValue("@Email", cleaner.Email);
                            command.Parameters.AddWithValue("@UserID", cleaner.UserID);

                            command.ExecuteNonQuery();
                        }

                        string cleanerQuery = @"
                            UPDATE Cleaners
                            SET Phone = @Phone
                            WHERE CleanerID = @CleanerID";

                        using (SqlCommand command =
                            new SqlCommand(cleanerQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Phone", cleaner.Phone);
                            command.Parameters.AddWithValue("@CleanerID", cleaner.CleanerID);

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // DELETE CLEANER
        public bool DeleteCleaner(int cleanerID)
        {
            using (SqlConnection connection = db.GetConnection())
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int userID;

                        string findQuery = @"
                            SELECT UserID
                            FROM Cleaners
                            WHERE CleanerID = @CleanerID";

                        using (SqlCommand command =
                            new SqlCommand(findQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@CleanerID", cleanerID);

                            object result = command.ExecuteScalar();

                            if (result == null)
                            {
                                transaction.Rollback();
                                return false;
                            }

                            userID = (int)result;
                        }

                        using (SqlCommand command = new SqlCommand(
                            "DELETE FROM Cleaners WHERE CleanerID = @CleanerID",
                            connection, transaction))
                        {
                            command.Parameters.AddWithValue("@CleanerID", cleanerID);
                            command.ExecuteNonQuery();
                        }

                        using (SqlCommand command = new SqlCommand(
                            "DELETE FROM Users WHERE UserID = @UserID",
                            connection, transaction))
                        {
                            command.Parameters.AddWithValue("@UserID", userID);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
