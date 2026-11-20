
using System;
using System.Windows.Forms;
using SparkClean.Controllers;
using SparkClean.Models;

namespace SparkClean.Views
{
    public partial class CustomerPaymentsView : Form
    {
        private User loggedInUser;
        private PaymentController paymentController;

        public CustomerPaymentsView(User user)
        {
            InitializeComponent();
            FormStyle.Apply(this);

            loggedInUser = user;
            paymentController = new PaymentController();

            cmbPaymentMethod.Items.Clear();
            cmbPaymentMethod.Items.Add("Cash");
            cmbPaymentMethod.Items.Add("MTN Mobile Money");
            cmbPaymentMethod.Items.Add("Card");
            cmbPaymentMethod.SelectedIndex = -1;

            btnRefresh.Click += btnRefresh_Click;
            btnClose.Click += btnClose_Click;
            btnMakePayment.Click += btnMakePayment_Click;

            LoadPayments();
        }

        private void LoadPayments()
        {
            try
            {
                dgvPayments.DataSource =
                    paymentController.GetPaymentsForCustomer(
                        loggedInUser.UserID);

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

                if (dgvPayments.Columns["ServiceName"] != null)
                    dgvPayments.Columns["ServiceName"].HeaderText = "Service";

                if (dgvPayments.Columns["Amount"] != null)
                    dgvPayments.Columns["Amount"].HeaderText = "Amount (RWF)";

                if (dgvPayments.Columns["PaymentDate"] != null)
                    dgvPayments.Columns["PaymentDate"].HeaderText = "Payment Date";

                if (dgvPayments.Columns["PaymentMethod"] != null)
                    dgvPayments.Columns["PaymentMethod"].HeaderText = "Payment Method";

                if (dgvPayments.Columns["PaymentStatus"] != null)
                    dgvPayments.Columns["PaymentStatus"].HeaderText = "Payment Status";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading payments: " + ex.Message);
            }
        }

        private void btnMakePayment_Click(object sender, EventArgs e)
        {
            if (dgvPayments.CurrentRow == null)
            {
                MessageBox.Show("Please select a payment first.");
                return;
            }

            if (cmbPaymentMethod.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a payment method.");
                return;
            }

            string status = Convert.ToString(
                dgvPayments.CurrentRow.Cells["PaymentStatus"].Value);

            if (status != "Pending")
            {
                MessageBox.Show("Only pending payments can be paid.");
                return;
            }

            int paymentID = Convert.ToInt32(
                dgvPayments.CurrentRow.Cells["PaymentID"].Value);

            string paymentMethod =
                cmbPaymentMethod.SelectedItem.ToString();

            DialogResult confirmation = MessageBox.Show(
                "Confirm simulated payment using " + paymentMethod + "?",
                "Confirm Payment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmation != DialogResult.Yes)
                return;

            try
            {
                bool success =
                    paymentController.MakeSimulatedPayment(
                        paymentID,
                        loggedInUser.UserID,
                        paymentMethod);

                if (success)
                {
                    MessageBox.Show(
                        "Simulated payment completed successfully!");

                    LoadPayments();
                    cmbPaymentMethod.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show(
                        "Payment could not be completed. " +
                        "Check that the payment is still Pending.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Payment error: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPayments();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
