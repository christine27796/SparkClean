
using System;
using System.Windows.Forms;
using System.Globalization;
using SparkClean.Controllers;
using SparkClean.Models;

namespace SparkClean.Views
{
    public partial class ServicesView : Form
    {
        private ServiceController controller = new ServiceController();

        private int selectedServiceID = 0;

        public ServicesView()
        {
            InitializeComponent();
            FormStyle.Apply(this);

            LoadServices();

            // Connect button events
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += btnClear_Click;

            // Connect table selection event
            dgvServices.CellClick += dgvServices_CellClick;
        }

        // Load all services into the table
        private void LoadServices()
        {
            try
            {
                dgvServices.DataSource = controller.GetAllServices();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading services: " + ex.Message);
            }
        }

        // Add a new service
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out decimal price))
                return;

            try
            {
                Service service = new Service
                {
                    ServiceName = txtServiceName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    Price = price
                };

                if (controller.AddService(service))
                {
                    MessageBox.Show("Service added successfully!");
                    LoadServices();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding service: " + ex.Message);
            }
        }

        // Update selected service
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedServiceID == 0)
            {
                MessageBox.Show("Please select a service first.");
                return;
            }

            if (!ValidateInputs(out decimal price))
                return;

            try
            {
                Service service = new Service
                {
                    ServiceID = selectedServiceID,
                    ServiceName = txtServiceName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    Price = price
                };

                if (controller.UpdateService(service))
                {
                    MessageBox.Show("Service updated successfully!");
                    LoadServices();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating service: " + ex.Message);
            }
        }

        // Delete selected service
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedServiceID == 0)
            {
                MessageBox.Show("Please select a service first.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this service?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (controller.DeleteService(selectedServiceID))
                    {
                        MessageBox.Show("Service deleted successfully!");
                        LoadServices();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Service was not found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error deleting service: " + ex.Message +
                        "\n\nA service that is already used in a booking cannot be deleted.");
                }
            }
        }

        // Clear all fields
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtServiceName.Clear();
            txtDescription.Clear();
            txtPrice.Clear();

            selectedServiceID = 0;
            dgvServices.ClearSelection();
        }

        // Validate input fields
        private bool ValidateInputs(out decimal price)
        {
            price = 0;

            if (string.IsNullOrWhiteSpace(txtServiceName.Text))
            {
                MessageBox.Show("Please enter the service name.");
                txtServiceName.Focus();
                return false;
            }

            if (!decimal.TryParse(
                txtPrice.Text.Trim(),
                NumberStyles.Number,
                CultureInfo.InvariantCulture,
                out price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid price greater than zero.");
                txtPrice.Focus();
                return false;
            }

            return true;
        }

        // Select a service from the table
        private void dgvServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvServices.Rows[e.RowIndex];

                selectedServiceID = Convert.ToInt32(
                    row.Cells["ServiceID"].Value);

                txtServiceName.Text =
                    row.Cells["ServiceName"].Value?.ToString() ?? "";

                txtDescription.Text =
                    row.Cells["Description"].Value?.ToString() ?? "";

                txtPrice.Text =
                    row.Cells["Price"].Value?.ToString() ?? "";
            }
        }
    }
}
