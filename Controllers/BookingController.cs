
using Microsoft.Data.SqlClient;
using SparkClean;
using SparkClean.Models;
using System;
using System.Data;

namespace SparkClean.Controllers
{
    public class BookingController
    {
        private DatabaseConnection db = new DatabaseConnection();

        // CREATE CUSTOMER BOOKING AND PAYMENT
        public int CreateCustomerBooking(
            int userID,
            int serviceID,
            DateTime bookingDate,
            TimeSpan bookingTime)
        {
            using (SqlConnection connection = db.GetConnection())
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int customerID;

                        string customerQuery = @"
                            SELECT CustomerID
                            FROM Customers
                            WHERE UserID = @UserID";

                        using (SqlCommand command =
                            new SqlCommand(customerQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@UserID", userID);

                            object result = command.ExecuteScalar();

                            if (result == null)
                                throw new Exception("Customer account was not found.");

                            customerID = Convert.ToInt32(result);
                        }

                        decimal amount;

                        string serviceQuery = @"
                            SELECT Price
                            FROM Services
                            WHERE ServiceID = @ServiceID";

                        using (SqlCommand command =
                            new SqlCommand(serviceQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@ServiceID", serviceID);

                            object result = command.ExecuteScalar();

                            if (result == null)
                                throw new Exception("Selected cleaning service was not found.");

                            amount = Convert.ToDecimal(result);
                        }

                        string bookingQuery = @"
                            INSERT INTO Bookings
                            (CustomerID, ServiceID, BookingDate,
                             BookingTime, Status)
                            VALUES
                            (@CustomerID, @ServiceID, @BookingDate,
                             @BookingTime, 'Pending');

                            SELECT CAST(SCOPE_IDENTITY() AS INT);";

                        int bookingID;

                        using (SqlCommand command =
                            new SqlCommand(bookingQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@CustomerID", customerID);
                            command.Parameters.AddWithValue("@ServiceID", serviceID);
                            command.Parameters.AddWithValue("@BookingDate", bookingDate.Date);
                            command.Parameters.AddWithValue("@BookingTime", bookingTime);

                            bookingID = Convert.ToInt32(command.ExecuteScalar());
                        }

                        string paymentQuery = @"
                            INSERT INTO Payments
                            (BookingID, Amount, PaymentStatus)
                            VALUES
                            (@BookingID, @Amount, 'Pending')";

                        using (SqlCommand command =
                            new SqlCommand(paymentQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@BookingID", bookingID);
                            command.Parameters.AddWithValue("@Amount", amount);

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        return bookingID;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // GET ALL BOOKINGS FOR ADMIN
        public DataTable GetAllBookings()
        {
            DataTable table = new DataTable();

            using (SqlConnection connection = db.GetConnection())
            {
                connection.Open();

                string query = @"
                    SELECT
                        b.BookingID,
                        u.FullName AS CustomerName,
                        u.Email AS CustomerEmail,
                        s.ServiceName,
                        b.BookingDate,
                        b.BookingTime,
                        b.Status,
                        b.CleanerID,
                        cu.FullName AS CleanerName
                    FROM Bookings b
                    INNER JOIN Customers c ON b.CustomerID = c.CustomerID
                    INNER JOIN Users u ON c.UserID = u.UserID
                    INNER JOIN Services s ON b.ServiceID = s.ServiceID
                    LEFT JOIN Cleaners cl ON b.CleanerID = cl.CleanerID
                    LEFT JOIN Users cu ON cl.UserID = cu.UserID
                    ORDER BY b.BookingID DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                }
            }

            return table;
        }

        // GET BOOKINGS FOR A PARTICULAR CUSTOMER
        public DataTable GetBookingsForCustomer(int userID)
        {
            DataTable table = new DataTable();

            using (SqlConnection connection = db.GetConnection())
            {
                connection.Open();

                string query = @"
                    SELECT
                        b.BookingID,
                        s.ServiceName,
                        b.BookingDate,
                        b.BookingTime,
                        b.Status,
                        cu.FullName AS CleanerName
                    FROM Bookings b
                    INNER JOIN Customers c
                        ON b.CustomerID = c.CustomerID
                    INNER JOIN Services s
                        ON b.ServiceID = s.ServiceID
                    LEFT JOIN Cleaners cl
                        ON b.CleanerID = cl.CleanerID
                    LEFT JOIN Users cu
                        ON cl.UserID = cu.UserID
                    WHERE c.UserID = @UserID
                    ORDER BY b.BookingID DESC";

                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);

                    using (SqlDataAdapter adapter =
                        new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                    }
                }
            }

            return table;
        }

        // CANCEL CUSTOMER BOOKING
        public bool CancelCustomerBooking(int bookingID, int userID)
        {
            using (SqlConnection connection = db.GetConnection())
            {
                connection.Open();

                string query = @"
                    UPDATE Bookings
                    SET Status = 'Cancelled'
                    WHERE BookingID = @BookingID
                    AND CustomerID = (
                        SELECT CustomerID
                        FROM Customers
                        WHERE UserID = @UserID
                    )
                    AND Status IN ('Pending', 'Confirmed')";

                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookingID", bookingID);
                    command.Parameters.AddWithValue("@UserID", userID);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // ASSIGN CLEANER TO BOOKING
        public bool AssignCleaner(int bookingID, int cleanerID)
        {
            using (SqlConnection connection = db.GetConnection())
            {
                connection.Open();

                string query = @"
                    UPDATE Bookings
                    SET CleanerID = @CleanerID
                    WHERE BookingID = @BookingID";

                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CleanerID", cleanerID);
                    command.Parameters.AddWithValue("@BookingID", bookingID);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // UPDATE BOOKING STATUS BY ADMIN
        public bool UpdateBookingStatus(int bookingID, string status)
        {
            string[] allowedStatuses =
            {
                "Pending",
                "Confirmed",
                "In Progress",
                "Completed"
            };

            if (Array.IndexOf(allowedStatuses, status) < 0)
                throw new ArgumentException("Invalid booking status.");

            using (SqlConnection connection = db.GetConnection())
            {
                connection.Open();

                string query = @"
                    UPDATE Bookings
                    SET Status = @Status
                    WHERE BookingID = @BookingID";

                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@BookingID", bookingID);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // GET BOOKINGS ASSIGNED TO A PARTICULAR CLEANER
        public DataTable GetBookingsForCleaner(int userID)
        {
            DataTable table = new DataTable();

            using (SqlConnection connection = db.GetConnection())
            {
                connection.Open();

                string query = @"
                    SELECT
                        b.BookingID,
                        u.FullName AS CustomerName,
                        c.Phone AS CustomerPhone,
                        c.Address AS CustomerAddress,
                        s.ServiceName,
                        b.BookingDate,
                        b.BookingTime,
                        b.Status
                    FROM Bookings b
                    INNER JOIN Customers c
                        ON b.CustomerID = c.CustomerID
                    INNER JOIN Users u
                        ON c.UserID = u.UserID
                    INNER JOIN Services s
                        ON b.ServiceID = s.ServiceID
                    INNER JOIN Cleaners cl
                        ON b.CleanerID = cl.CleanerID
                    WHERE cl.UserID = @UserID
                    ORDER BY b.BookingDate DESC, b.BookingTime";

                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);

                    using (SqlDataAdapter adapter =
                        new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                    }
                }
            }

            return table;
        }

        // UPDATE JOB STATUS BY THE ASSIGNED CLEANER
        public bool UpdateCleanerJobStatus(
            int bookingID, int userID, string status)
        {
            string[] allowedStatuses =
            {
                "Confirmed",
                "In Progress",
                "Completed"
            };

            if (Array.IndexOf(allowedStatuses, status) < 0)
                throw new ArgumentException("Invalid job status.");

            using (SqlConnection connection = db.GetConnection())
            {
                connection.Open();

                string query = @"
                    UPDATE Bookings
                    SET Status = @Status
                    WHERE BookingID = @BookingID
                    AND CleanerID = (
                        SELECT CleanerID
                        FROM Cleaners
                        WHERE UserID = @UserID
                    )
                    AND (
                        (Status = 'Pending' AND @Status = 'Confirmed')
                        OR
                        (Status = 'Confirmed' AND @Status = 'In Progress')
                        OR
                        (Status = 'In Progress' AND @Status = 'Completed')
                    )";

                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookingID", bookingID);
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@Status", status);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
