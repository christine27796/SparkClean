
using System;
using System.Windows.Forms;
using SparkClean.Controllers;

namespace SparkClean.Views
{
    public partial class PaymentsView : Form
    {
        private PaymentController paymentController;

        public PaymentsView()
        {
            InitializeComponent();
            FormStyle.Apply(this);

            paymentController = new PaymentController();

            cmbPaymentStatus.Items.Clear();
            cmbPaymentStatus.Items.Add("Pending");
            cmbPaymentStatus.Items.Add("Paid");
            cmbPaymentStatus.Items.Add("Failed");

            btnRefresh.Click += btnRefresh_Click;
            btnUpdateStatus.Click += btnUpdateStatus_Click;
            btnClose.Click += btnClose_Click;

            LoadPayments();
        }

        private void LoadPayments()
        {
            try
            {
                dgvPayments.DataSource =
                    paymentController.GetPaymentsForAdmin();

                dgvPayments.ReadOnly = true;
                dgvPayments.AllowUserToAddRows = false;
                dgvPayments.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvPayments.MultiSelect = false;
                dgvPayments.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                if (dgvPayments.Columns["PaymentID"] != null)
                    dgvPayments.Columns["PaymentID"].HeaderText = "Payment ID";

                if (dgvPayments.Columns["BookingID"] != null)
                    dgvPayments.Columns["BookingID"].HeaderText = "Booking ID";

                if (dgvPayments.Columns["CustomerName"] != null)
                    dgvPayments.Columns["CustomerName"].HeaderText = "Customer";

                if (dgvPayments.Columns["ServiceName"] != null)
                    dgvPayments.Columns["ServiceName"].HeaderText = "Service";

                if (dgvPayments.Columns["Amount"] != null)
                    dgvPayments.Columns["Amount"].HeaderText = "Amount (RWF)";

                if (dgvPayments.Columns["PaymentStatus"] != null)
                    dgvPayments.Columns["PaymentStatus"].HeaderText = "Payment Status";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading payments: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPayments();
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dgvPayments.CurrentRow == null)
            {
                MessageBox.Show("Please select a payment first.");
                return;
            }

            if (cmbPaymentStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a payment status.");
                return;
            }

            int paymentID = Convert.ToInt32(
                dgvPayments.CurrentRow.Cells["PaymentID"].Value);

            string status = cmbPaymentStatus.SelectedItem.ToString();

            try
            {
                bool updated = paymentController.UpdatePaymentStatus(
                    paymentID, status);

                if (updated)
                {
                    MessageBox.Show("Payment status updated successfully.");
                    LoadPayments();
                }
                else
                {
                    MessageBox.Show("Payment status was not updated.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating payment: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
