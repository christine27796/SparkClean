
using System;
using System.Windows.Forms;
using SparkClean.Controllers;
using SparkClean.Models;

namespace SparkClean.Views
{
    public partial class CustomersView : Form
    {
        private CustomerController controller = new CustomerController();

        private int selectedCustomerID = 0;
        private int selectedUserID = 0;

        public CustomersView()
        {
            InitializeComponent();
            FormStyle.Apply(this);

            LoadCustomers();

            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += btnClear_Click;

            dgvCustomers.CellClick += dgvCustomers_CellClick;
        }

        // Form Load event
        private void CustomersView_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        // Load customers into DataGridView
        private void LoadCustomers()
        {
            try
            {
                dgvCustomers.DataSource = null;
                dgvCustomers.DataSource = controller.GetAllCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading customers: " + ex.Message);
            }
        }

        // Select customer from DataGridView
        private void dgvCustomers_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];

                selectedCustomerID = Convert.ToInt32(
                    row.Cells["CustomerID"].Value);

                selectedUserID = Convert.ToInt32(
                    row.Cells["UserID"].Value);

                txtFullName.Text =
                    row.Cells["FullName"].Value?.ToString() ?? "";

                txtEmail.Text =
                    row.Cells["Email"].Value?.ToString() ?? "";

                txtPhone.Text =
                    row.Cells["Phone"].Value?.ToString() ?? "";

                txtAddress.Text =
                    row.Cells["Address"].Value?.ToString() ?? "";
            }
        }

        // Update customer
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedCustomerID == 0)
            {
                MessageBox.Show("Please select a customer first.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show(
                    "Full Name and Email are required.");
                return;
            }

            try
            {
                Customer customer = new Customer
                {
                    CustomerID = selectedCustomerID,
                    UserID = selectedUserID,
                    FullName = txtFullName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Address = txtAddress.Text.Trim()
                };

                if (controller.UpdateCustomer(customer))
                {
                    MessageBox.Show(
                        "Customer updated successfully!");

                    LoadCustomers();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error updating customer: " + ex.Message);
            }
        }

        // Delete customer
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCustomerID == 0)
            {
                MessageBox.Show("Please select a customer first.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this customer?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (controller.DeleteCustomer(selectedCustomerID))
                    {
                        MessageBox.Show(
                            "Customer deleted successfully!");

                        LoadCustomers();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Customer was not found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error deleting customer: " + ex.Message +
                        "\n\nA customer with existing bookings or payments cannot be deleted.");
                }
            }
        }

        // Clear fields
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();

            selectedCustomerID = 0;
            selectedUserID = 0;

            dgvCustomers.ClearSelection();
        }
    }
}
