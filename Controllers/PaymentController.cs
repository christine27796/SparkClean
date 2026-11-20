
using Microsoft.Data.SqlClient;
using SparkClean;
using SparkClean.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace SparkClean.Controllers
{
    public class PaymentController
    {
        private DatabaseConnection db = new DatabaseConnection();

        // GET ALL PAYMENTS
        public List<Payment> GetAllPayments()
        {
            List<Payment> payments = new List<Payment>();

            using (SqlConnection connection = db.GetConnection())
            {
                connection.Open();

                string query = @"
                    SELECT PaymentID, BookingID, Amount,
                           PaymentDate, PaymentMethod, PaymentStatus
                    FROM Payments";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        payments.Add(new Payment
                        {
                            PaymentID = (int)reader["PaymentID"],
                            BookingID = (int)reader["BookingID"],
                            Amount = (decimal)reader["Amount"],
                            PaymentDate = reader["PaymentDate"] == DBNull.Value
                                ? null : (DateTime?)reader["PaymentDate"],
                            PaymentMethod = reader["PaymentMethod"] == DBNull.Value
                                ? null : reader["PaymentMethod"].ToString(),
                            PaymentStatus = reader["PaymentStatus"].ToString()
                        });
                    }
                }
            }

            return payments;
        }

        // GET PAYMENTS WITH CUSTOMER DETAILS FOR ADMIN
        public DataTable GetPaymentsForAdmin()
        {
            DataTable table = new DataTable();

            using (SqlConnection connection = db.GetConnection())
            {
                connection.Open();

                string query = @"
                    SELECT
                        p.PaymentID,
                        p.BookingID,
                        u.FullName AS CustomerName,
                        s.ServiceName,
                        p.Amount,
                        p.PaymentDate,
                        p.PaymentMethod,
                        p.PaymentStatus
                    FROM Payments p
                    INNER JOIN Bookings b ON p.BookingID = b.BookingID
                    INNER JOIN Customers c ON b.CustomerID = c.CustomerID
                    INNER JOIN Users u ON c.UserID = u.UserID
                    INNER JOIN Services s ON b.ServiceID = s.ServiceID
                    ORDER BY p.PaymentID DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                }
            }

            return table;
        }

        // GET PAYMENTS FOR A PARTICULAR CUSTOMER
        public DataTable GetPaymentsForCustomer(int userID)
        {
            DataTable table = new DataTable();

            using (SqlConnection connection = db.GetConnection())
            {
                connection.Open();

                string query = @"
                    SELECT
                        p.PaymentID,
                        b.BookingID,
                        s.ServiceName,
                        p.Amount,
                        p.PaymentDate,
                        p.PaymentMethod,
                        p.PaymentStatus
                    FROM Payments p
                    INNER JOIN Bookings b
                        ON p.BookingID = b.BookingID
                    INNER JOIN Customers c
                        ON b.CustomerID = c.CustomerID
                    INNER JOIN Services s
                        ON b.ServiceID = s.ServiceID
                    WHERE c.UserID = @UserID
                    ORDER BY p.PaymentID DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                    }
                }
            }

            return table;
        }

        // CUSTOMER MAKES A SIMULATED PAYMENT
        public bool MakeSimulatedPayment(
            int paymentID,
            int userID,
            string paymentMethod)
        {
            string[] allowedMethods =
            {
                "Cash",
                "MTN Mobile Money",
                "Card"
            };

            if (Array.IndexOf(allowedMethods, paymentMethod) < 0)
            {
                throw new ArgumentException("Invalid payment method.");
            }

            using (SqlConnection connection = db.GetConnection())
            {
                connection.Open();

                string query = @"
                    UPDATE Payments
                    SET PaymentMethod = @PaymentMethod,
                        PaymentDate = GETDATE(),
                        PaymentStatus = 'Paid'
                    WHERE PaymentID = @PaymentID
                    AND PaymentStatus = 'Pending'
                    AND EXISTS
                    (
                        SELECT 1
                        FROM Bookings b
                        INNER JOIN Customers c
                            ON b.CustomerID = c.CustomerID
                        WHERE b.BookingID = Payments.BookingID
                        AND c.UserID = @UserID
                    )";

                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@PaymentMethod", paymentMethod);

                    command.Parameters.AddWithValue(
                        "@PaymentID", paymentID);

                    command.Parameters.AddWithValue(
                        "@UserID", userID);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // UPDATE PAYMENT STATUS BY ADMIN
        public bool UpdatePaymentStatus(int paymentID, string status)
        {
            string[] allowedStatuses =
            {
                "Pending",
                "Paid",
                "Failed"
            };

            if (Array.IndexOf(allowedStatuses, status) < 0)
            {
                throw new ArgumentException("Invalid payment status.");
            }

            using (SqlConnection connection = db.GetConnection())
            {
                connection.Open();

                string query = @"
                    UPDATE Payments
                    SET PaymentStatus = @Status
                    WHERE PaymentID = @PaymentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@PaymentID", paymentID);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
