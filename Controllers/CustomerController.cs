
using Microsoft.Data.SqlClient;
using SparkClean;
using SparkClean.Models;
using System;
using System.Collections.Generic;

namespace SparkClean.Controllers
{
    public class CustomerController
    {
        private DatabaseConnection db = new DatabaseConnection();

        // REGISTER CUSTOMER
        public bool RegisterCustomer(
            string fullName,
            string email,
            string password,
            string phone,
            string address)
        {
            using (SqlConnection connection = db.GetConnection())
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Check whether email already exists
                        string checkQuery = @"
                            SELECT COUNT(*)
                            FROM Users
                            WHERE Email = @Email";

                        using (SqlCommand command =
                            new SqlCommand(checkQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Email", email);

                            int count = Convert.ToInt32(command.ExecuteScalar());

                            if (count > 0)
                            {
                                throw new InvalidOperationException(
                                    "This email is already registered.");
                            }
                        }

                        // Hash the customer's password
                        string passwordHash = PasswordHelper.HashPassword(password);

                        // Insert user account
                        string userQuery = @"
                            INSERT INTO Users
                            (FullName, Email, PasswordHash, Role)
                            VALUES
                            (@FullName, @Email, @PasswordHash, 'Customer');

                            SELECT CAST(SCOPE_IDENTITY() AS INT);";

                        int userID;

                        using (SqlCommand command =
                            new SqlCommand(userQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@FullName", fullName);
                            command.Parameters.AddWithValue("@Email", email);
                            command.Parameters.AddWithValue("@PasswordHash", passwordHash);

                            userID = Convert.ToInt32(command.ExecuteScalar());
                        }

                        // Insert customer profile
                        string customerQuery = @"
                            INSERT INTO Customers
                            (UserID, Phone, Address)
                            VALUES
                            (@UserID, @Phone, @Address)";

                        using (SqlCommand command =
                            new SqlCommand(customerQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@UserID", userID);
                            command.Parameters.AddWithValue("@Phone", phone);
                            command.Parameters.AddWithValue("@Address", address);

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

        // GET ALL CUSTOMERS
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = db.GetConnection())
            {
                connection.Open();

                string query = @"
                    SELECT
                        c.CustomerID,
                        c.UserID,
                        u.FullName,
                        u.Email,
                        c.Phone,
                        c.Address
                    FROM Customers c
                    INNER JOIN Users u ON c.UserID = u.UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customer
                        {
                            CustomerID = (int)reader["CustomerID"],
                            UserID = (int)reader["UserID"],
                            FullName = reader["FullName"].ToString()!,
                            Email = reader["Email"].ToString()!,
                            Phone = reader["Phone"] == DBNull.Value
                                ? string.Empty
                                : reader["Phone"].ToString()!,
                            Address = reader["Address"] == DBNull.Value
                                ? string.Empty
                                : reader["Address"].ToString()!
                        });
                    }
                }
            }

            return customers;
        }

        // UPDATE CUSTOMER
        public bool UpdateCustomer(Customer customer)
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
                            WHERE UserID = @UserID";

                        using (SqlCommand command =
                            new SqlCommand(userQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue(
                                "@FullName", customer.FullName);

                            command.Parameters.AddWithValue(
                                "@Email", customer.Email);

                            command.Parameters.AddWithValue(
                                "@UserID", customer.UserID);

                            command.ExecuteNonQuery();
                        }

                        string customerQuery = @"
                            UPDATE Customers
                            SET Phone = @Phone,
                                Address = @Address
                            WHERE CustomerID = @CustomerID";

                        using (SqlCommand command =
                            new SqlCommand(customerQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue(
                                "@Phone",
                                string.IsNullOrWhiteSpace(customer.Phone)
                                    ? DBNull.Value
                                    : customer.Phone);

                            command.Parameters.AddWithValue(
                                "@Address",
                                string.IsNullOrWhiteSpace(customer.Address)
                                    ? DBNull.Value
                                    : customer.Address);

                            command.Parameters.AddWithValue(
                                "@CustomerID", customer.CustomerID);

                            int rows = command.ExecuteNonQuery();

                            if (rows == 0)
                            {
                                transaction.Rollback();
                                return false;
                            }
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

        // DELETE CUSTOMER
        public bool DeleteCustomer(int customerID)
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
                            FROM Customers
                            WHERE CustomerID = @CustomerID";

                        using (SqlCommand command =
                            new SqlCommand(findQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue(
                                "@CustomerID", customerID);

                            object result = command.ExecuteScalar();

                            if (result == null)
                            {
                                transaction.Rollback();
                                return false;
                            }

                            userID = Convert.ToInt32(result);
                        }

                        string deleteCustomer = @"
                            DELETE FROM Customers
                            WHERE CustomerID = @CustomerID";

                        using (SqlCommand command =
                            new SqlCommand(deleteCustomer, connection, transaction))
                        {
                            command.Parameters.AddWithValue(
                                "@CustomerID", customerID);

                            command.ExecuteNonQuery();
                        }

                        string deleteUser = @"
                            DELETE FROM Users
                            WHERE UserID = @UserID";

                        using (SqlCommand command =
                            new SqlCommand(deleteUser, connection, transaction))
                        {
                            command.Parameters.AddWithValue(
                                "@UserID", userID);

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
