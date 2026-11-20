
using System;
using System.Windows.Forms;
using SparkClean.Controllers;
using SparkClean.Models;

namespace SparkClean.Views
{
    public partial class CustomerBookingView : Form
    {
        private User loggedInUser;
        private ServiceController serviceController;
        private BookingController bookingController;

        public CustomerBookingView(User user)
        {
            InitializeComponent();
            FormStyle.Apply(this);

            loggedInUser = user;

            serviceController = new ServiceController();
            bookingController = new BookingController();

            // Configure booking date
            dtpBookingDate.Format = DateTimePickerFormat.Short;
            dtpBookingDate.MinDate = DateTime.Today;
            dtpBookingDate.Value = DateTime.Today;

            // Configure booking time
            dtpBookingTime.Format = DateTimePickerFormat.Time;
            dtpBookingTime.ShowUpDown = true;
            dtpBookingTime.Value = DateTime.Today.AddHours(10);

            // Connect buttons
            btnBook.Click += btnBook_Click;
            btnClear.Click += btnClear_Click;
            btnClose.Click += btnClose_Click;

            LoadServices();
        }

        private void LoadServices()
        {
            try
            {
                var services = serviceController.GetAllServices();

                cmbService.DataSource = null;
                cmbService.DataSource = services;
                cmbService.DisplayMember = "ServiceName";
                cmbService.ValueMember = "ServiceID";
                cmbService.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading services: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            if (cmbService.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a cleaning service.");
                return;
            }

            int serviceID = Convert.ToInt32(cmbService.SelectedValue);

            DateTime bookingDate = dtpBookingDate.Value.Date;

            TimeSpan bookingTime = dtpBookingTime.Value.TimeOfDay;

            if (bookingDate < DateTime.Today)
            {
                MessageBox.Show("Please select today or a future date.");
                return;
            }

            try
            {
                int bookingID = bookingController.CreateCustomerBooking(
                    loggedInUser.UserID,
                    serviceID,
                    bookingDate,
                    bookingTime
                );

                MessageBox.Show(
                    "Booking created successfully!\n\n" +
                    "Booking ID: " + bookingID +
                    "\nBooking Status: Pending" +
                    "\nPayment Status: Pending",
                    "Booking Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error creating booking: " + ex.Message,
                    "Booking Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            cmbService.SelectedIndex = -1;
            dtpBookingDate.Value = DateTime.Today;
            dtpBookingTime.Value = DateTime.Today.AddHours(10);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Designer event handler
        }
    }
}
