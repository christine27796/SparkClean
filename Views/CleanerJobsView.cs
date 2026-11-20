
using System;
using System.Windows.Forms;
using SparkClean.Controllers;
using SparkClean.Models;

namespace SparkClean.Views
{
    public partial class CleanerJobsView : Form
    {
        private User loggedInUser;
        private BookingController bookingController;

        public CleanerJobsView(User user)
        {
            InitializeComponent();
            FormStyle.Apply(this);

            loggedInUser = user;
            bookingController = new BookingController();

            // Add job status options
            cmbJobStatus.Items.Clear();
            cmbJobStatus.Items.Add("Confirmed");
            cmbJobStatus.Items.Add("In Progress");
            cmbJobStatus.Items.Add("Completed");

            // Connect buttons
            btnRefresh.Click += btnRefresh_Click;
            btnUpdateStatus.Click += btnUpdateStatus_Click;
            btnClose.Click += btnClose_Click;

            LoadJobs();
        }

        private void LoadJobs()
        {
            try
            {
                // Load assigned jobs into the DataGridView
                dgvJobs.DataSource =
                    bookingController.GetBookingsForCleaner(
                        loggedInUser.UserID);

                // Configure DataGridView
                dgvJobs.ReadOnly = true;
                dgvJobs.AllowUserToAddRows = false;
                dgvJobs.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvJobs.MultiSelect = false;
                dgvJobs.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                // Set column headings
                if (dgvJobs.Columns["BookingID"] != null)
                    dgvJobs.Columns["BookingID"].HeaderText = "Booking ID";

                if (dgvJobs.Columns["CustomerName"] != null)
                    dgvJobs.Columns["CustomerName"].HeaderText = "Customer";

                if (dgvJobs.Columns["CustomerPhone"] != null)
                    dgvJobs.Columns["CustomerPhone"].HeaderText = "Phone";

                if (dgvJobs.Columns["CustomerAddress"] != null)
                    dgvJobs.Columns["CustomerAddress"].HeaderText = "Address";

                if (dgvJobs.Columns["ServiceName"] != null)
                    dgvJobs.Columns["ServiceName"].HeaderText = "Cleaning Service";

                if (dgvJobs.Columns["BookingDate"] != null)
                    dgvJobs.Columns["BookingDate"].HeaderText = "Date";

                if (dgvJobs.Columns["BookingTime"] != null)
                    dgvJobs.Columns["BookingTime"].HeaderText = "Time";

                if (dgvJobs.Columns["Status"] != null)
                    dgvJobs.Columns["Status"].HeaderText = "Job Status";

                if (dgvJobs.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "You have no assigned cleaning jobs yet.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading assigned jobs: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadJobs();
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dgvJobs.CurrentRow == null)
            {
                MessageBox.Show("Please select a job first.");
                return;
            }

            if (cmbJobStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a job status.");
                return;
            }

            try
            {
                int bookingID = Convert.ToInt32(
                    dgvJobs.CurrentRow.Cells["BookingID"].Value);

                string status =
                    cmbJobStatus.SelectedItem.ToString();

                bool updated =
                    bookingController.UpdateCleanerJobStatus(
                        bookingID,
                        loggedInUser.UserID,
                        status);

                if (updated)
                {
                    MessageBox.Show(
                        "Job status updated successfully.");

                    LoadJobs();
                    cmbJobStatus.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show(
                        "The job status could not be updated. " +
                        "Check that the job is assigned to you " +
                        "and has not already been completed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error updating job status: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
