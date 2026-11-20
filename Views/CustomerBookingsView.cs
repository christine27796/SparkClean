
using System;
using System.Windows.Forms;
using SparkClean.Controllers;
using SparkClean.Models;

namespace SparkClean.Views
{
    public partial class CustomerBookingsView : Form
    {
        private User loggedInUser;
        private BookingController bookingController;

        public CustomerBookingsView(User user)
        {
            InitializeComponent();
            FormStyle.Apply(this);

            loggedInUser = user;
            bookingController = new BookingController();

            btnRefresh.Click += btnRefresh_Click;
            btnCancelBooking.Click += btnCancelBooking_Click;
            btnClose.Click += btnClose_Click;

            LoadBookings();
        }

        private void LoadBookings()
        {
            try
            {
                dgvBookings.DataSource =
                    bookingController.GetBookingsForCustomer(
                        loggedInUser.UserID);

                dgvBookings.ReadOnly = true;
                dgvBookings.AllowUserToAddRows = false;
                dgvBookings.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvBookings.MultiSelect = false;
                dgvBookings.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                if (dgvBookings.Columns["BookingID"] != null)
                    dgvBookings.Columns["BookingID"].HeaderText = "Booking ID";

                if (dgvBookings.Columns["ServiceName"] != null)
                    dgvBookings.Columns["ServiceName"].HeaderText = "Service";

                if (dgvBookings.Columns["BookingDate"] != null)
                    dgvBookings.Columns["BookingDate"].HeaderText = "Date";

                if (dgvBookings.Columns["BookingTime"] != null)
                    dgvBookings.Columns["BookingTime"].HeaderText = "Time";

                if (dgvBookings.Columns["CleanerName"] != null)
                    dgvBookings.Columns["CleanerName"].HeaderText = "Assigned Cleaner";

                if (dgvBookings.Columns["Status"] != null)
                    dgvBookings.Columns["Status"].HeaderText = "Booking Status";

                if (dgvBookings.Rows.Count == 0)
                    MessageBox.Show("You have no bookings yet.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bookings: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBookings();
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            if (dgvBookings.CurrentRow == null)
            {
                MessageBox.Show("Please select a booking first.");
                return;
            }

            int bookingID = Convert.ToInt32(
                dgvBookings.CurrentRow.Cells["BookingID"].Value);

            DialogResult result = MessageBox.Show(
                "Are you sure you want to cancel this booking?",
                "Confirm Cancellation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool cancelled =
                        bookingController.CancelCustomerBooking(
                            bookingID,
                            loggedInUser.UserID);

                    if (cancelled)
                    {
                        MessageBox.Show("Booking cancelled successfully.");
                        LoadBookings();
                    }
                    else
                    {
                        MessageBox.Show(
                            "This booking cannot be cancelled. Only Pending or Confirmed bookings can be cancelled.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error cancelling booking: " + ex.Message);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Empty designer event handler
        }
    }
}
