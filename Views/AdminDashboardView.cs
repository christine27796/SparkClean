
using System;
using System.Windows.Forms;

namespace SparkClean.Views
{
    public partial class AdminDashboardView : Form
    {
        public AdminDashboardView()
        {
            InitializeComponent();
            FormStyle.Apply(this);

            btnServices.Click += btnServices_Click;
            btnCustomers.Click += btnCustomers_Click;
            btnCleaners.Click += btnCleaners_Click;
            btnBookings.Click += btnBookings_Click;
            btnPayments.Click += btnPayments_Click;
            btnReports.Click += btnReports_Click;
            btnLogout.Click += btnLogout_Click;
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            using (ServicesView view = new ServicesView())
            {
                view.ShowDialog();
            }
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            using (CustomersView view = new CustomersView())
            {
                view.ShowDialog();
            }
        }

        private void btnCleaners_Click(object sender, EventArgs e)
        {
            using (CleanersView view = new CleanersView())
            {
                view.ShowDialog();
            }
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            using (BookingsView view = new BookingsView())
            {
                view.ShowDialog();
            }
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            using (PaymentsView view = new PaymentsView())
            {
                view.ShowDialog();
            }
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            using (ReportsView view = new ReportsView())
            {
                view.ShowDialog();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (LoginView loginView = new LoginView())
            {
                loginView.ShowDialog();
            }

            this.Close();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void button6_Click(object sender, EventArgs e) { }
        private void button5_Click(object sender, EventArgs e) { }
        private void button3_Click(object sender, EventArgs e) { }
    }
}
