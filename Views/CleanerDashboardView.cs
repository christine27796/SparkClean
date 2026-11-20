
using System;
using System.Windows.Forms;
using SparkClean.Models;

namespace SparkClean.Views
{
    public partial class CleanerDashboardView : Form
    {
        private User loggedInUser;

        public CleanerDashboardView(User user)
        {
            InitializeComponent();

            loggedInUser = user;

            lblWelcome.Text = "Welcome, " + loggedInUser.FullName + "!";

            btnMyJobs.Click += btnMyJobs_Click;
            btnLogout.Click += btnLogout_Click;
        }

        private void CleanerDashboardView_Load(object sender, EventArgs e)
        {
            // Dashboard loads here
        }

        private void btnMyJobs_Click(object sender, EventArgs e)
        {
            using (CleanerJobsView view = new CleanerJobsView(loggedInUser))
            {
                view.ShowDialog();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
