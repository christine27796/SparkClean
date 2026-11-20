
using System;
using System.Windows.Forms;
using SparkClean.Controllers;

namespace SparkClean.Views
{
    public partial class BookingsView : Form
    {
        private BookingController controller = new BookingController();
        private CleanerController cleanerController = new CleanerController();

        private int selectedBookingID = 0;

        public BookingsView()
        {
            InitializeComponent();
            FormStyle.Apply(this);

            LoadCleaners();

            cmbStatus.Items.AddRange(new string[]
            {
                "Pending",
                "Confirmed",
                "In Progress",
                "Completed"
            });

            LoadBookings();

            dgvBookings.SelectionChanged += dgvBookings_SelectionChanged;
            btnAssignCleaner.Click += btnAssignCleaner_Click;
            btnUpdateStatus.Click += btnUpdateStatus_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnClose.Click += btnClose_Click;
        }

        private void LoadBookings()
        {
            dgvBookings.DataSource = controller.GetAllBookings();
            selectedBookingID = 0;
        }

        private void LoadCleaners()
        {
            cmbCleaner.DataSource = cleanerController.GetAllCleaners();
            cmbCleaner.DisplayMember = "FullName";
            cmbCleaner.ValueMember = "CleanerID";
            cmbCleaner.SelectedIndex = -1;
        }

        private void dgvBookings_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBookings.CurrentRow == null ||
                dgvBookings.CurrentRow.IsNewRow ||
                dgvBookings.CurrentRow.Cells["BookingID"].Value == null ||
                dgvBookings.CurrentRow.Cells["BookingID"].Value == DBNull.Value)
            {
                selectedBookingID = 0;
                return;
            }

            selectedBookingID = Convert.ToInt32(
                dgvBookings.CurrentRow.Cells["BookingID"].Value);

            object cleanerID =
                dgvBookings.CurrentRow.Cells["CleanerID"].Value;

            if (cleanerID != null && cleanerID != DBNull.Value)
                cmbCleaner.SelectedValue = Convert.ToInt32(cleanerID);
            else
                cmbCleaner.SelectedIndex = -1;

            object status =
                dgvBookings.CurrentRow.Cells["Status"].Value;

            if (status != null && status != DBNull.Value)
                cmbStatus.Text = status.ToString();
        }

        private void btnAssignCleaner_Click(object sender, EventArgs e)
        {
            if (selectedBookingID == 0 || cmbCleaner.SelectedValue == null)
            {
                MessageBox.Show("Please select a booking and a cleaner.");
                return;
            }

            int cleanerID = Convert.ToInt32(cmbCleaner.SelectedValue);

            controller.AssignCleaner(selectedBookingID, cleanerID);

            MessageBox.Show("Cleaner assigned successfully!");
            LoadBookings();
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (selectedBookingID == 0 || cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a booking and status.");
                return;
            }

            controller.UpdateBookingStatus(selectedBookingID, cmbStatus.Text);

            MessageBox.Show("Booking status updated successfully!");
            LoadBookings();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCleaners();
            LoadBookings();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
