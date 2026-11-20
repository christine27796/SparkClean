
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SparkClean.Controllers;

namespace SparkClean.Views
{
    public partial class ReportsView : Form
    {
        private BookingController bookingController;

        private Label lblTotal;
        private Label lblPending;
        private Label lblConfirmed;
        private Label lblInProgress;
        private Label lblCompleted;

        private DataGridView dgvReports;
        private Button btnRefresh;
        private Button btnClose;

        public ReportsView()
        {
            InitializeComponent();
            FormStyle.Apply(this);

            bookingController = new BookingController();

            CreateReportControls();
            LoadReports();
        }

        private void CreateReportControls()
        {
            Text = "Booking Reports";
            Size = new Size(1000, 650);
            StartPosition = FormStartPosition.CenterScreen;

            lblTotal = CreateLabel(20, 20, 180, 35);
            lblPending = CreateLabel(210, 20, 180, 35);
            lblConfirmed = CreateLabel(400, 20, 180, 35);
            lblInProgress = CreateLabel(590, 20, 180, 35);
            lblCompleted = CreateLabel(780, 20, 180, 35);

            dgvReports = new DataGridView();
            dgvReports.Location = new Point(20, 90);
            dgvReports.Size = new Size(940, 450);
            dgvReports.ReadOnly = true;
            dgvReports.AllowUserToAddRows = false;
            dgvReports.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvReports.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            btnRefresh = new Button();
            btnRefresh.Text = "Refresh";
            btnRefresh.Location = new Point(750, 560);
            btnRefresh.Size = new Size(100, 35);
            btnRefresh.Click += btnRefresh_Click;

            btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.Location = new Point(860, 560);
            btnClose.Size = new Size(100, 35);
            btnClose.Click += btnClose_Click;

            Controls.Add(lblTotal);
            Controls.Add(lblPending);
            Controls.Add(lblConfirmed);
            Controls.Add(lblInProgress);
            Controls.Add(lblCompleted);
            Controls.Add(dgvReports);
            Controls.Add(btnRefresh);
            Controls.Add(btnClose);
        }

        private Label CreateLabel(int x, int y, int width, int height)
        {
            return new Label
            {
                Location = new Point(x, y),
                Size = new Size(width, height),
                Font = new Font("Arial", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };
        }

        private void LoadReports()
        {
            try
            {
                DataTable bookings =
                    bookingController.GetAllBookings();

                int total = bookings.Rows.Count;
                int pending = 0;
                int confirmed = 0;
                int inProgress = 0;
                int completed = 0;

                foreach (DataRow row in bookings.Rows)
                {
                    string status = Convert.ToString(
                        row["Status"]);

                    if (status.Equals(
                        "Pending",
                        StringComparison.OrdinalIgnoreCase))
                        pending++;

                    else if (status.Equals(
                        "Confirmed",
                        StringComparison.OrdinalIgnoreCase))
                        confirmed++;

                    else if (status.Equals(
                        "In Progress",
                        StringComparison.OrdinalIgnoreCase))
                        inProgress++;

                    else if (status.Equals(
                        "Completed",
                        StringComparison.OrdinalIgnoreCase))
                        completed++;
                }

                lblTotal.Text = "Total: " + total;
                lblPending.Text = "Pending: " + pending;
                lblConfirmed.Text = "Confirmed: " + confirmed;
                lblInProgress.Text = "In Progress: " + inProgress;
                lblCompleted.Text = "Completed: " + completed;

                dgvReports.DataSource = bookings;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading reports: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReports();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
