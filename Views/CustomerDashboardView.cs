
using System;
using System.Windows.Forms;
using SparkClean.Models;

namespace SparkClean.Views
{
    public partial class CustomerDashboardView : Form
    {
        private User loggedInUser;

        public CustomerDashboardView(User user)
        {
            InitializeComponent();
            FormStyle.Apply(this);

            loggedInUser = user;

            lblWelcome.Text = "Welcome, " + loggedInUser.FullName + "!";

            btnServices.Click += btnServices_Click;
            btnBookings.Click += btnBookings_Click;
            btnPayments.Click += btnPayments_Click;
            btnLogout.Click += btnLogout_Click;
            btnBookCleaning.Click += btnBookCleaning_Click;
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            using (CustomerServicesView view = new CustomerServicesView())
            {
                view.ShowDialog();
            }
        }

        private void btnBookCleaning_Click(object sender, EventArgs e)
        {
            using (CustomerBookingView view =
                new CustomerBookingView(loggedInUser))
            {
                view.ShowDialog();
            }
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            using (CustomerBookingsView view =
                new CustomerBookingsView(loggedInUser))
            {
                view.ShowDialog();
            }
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            using (CustomerPaymentsView view =
                new CustomerPaymentsView(loggedInUser))
            {
                view.ShowDialog();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
