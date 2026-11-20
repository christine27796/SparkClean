
using System;
using System.Windows.Forms;
using SparkClean.Controllers;
using SparkClean.Models;

namespace SparkClean.Views
{
    public partial class CleanersView : Form
    {
        private CleanerController controller = new CleanerController();

        private int selectedCleanerID = 0;
        private int selectedUserID = 0;

        public CleanersView()
        {
            InitializeComponent();

            LoadCleaners();
            FormStyle.Apply(this);

            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += btnClear_Click;

            dgvCleaners.CellClick += dgvCleaners_CellClick;
        }

        private void CleanersView_Load(object sender, EventArgs e)
        {
            LoadCleaners();
        }

        private void lblFullName_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void LoadCleaners()
        {
            try
            {
                dgvCleaners.DataSource = null;
                dgvCleaners.DataSource = controller.GetAllCleaners();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading cleaners: " + ex.Message);
            }
        }

        // ADD CLEANER
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show(
                    "Please enter the cleaner's full name, email and password.");
                return;
            }

            try
            {
                bool added = controller.AddCleaner(
                    txtFullName.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtPhone.Text.Trim(),
                    txtPassword.Text
                );

                if (added)
                {
                    MessageBox.Show(
                        "Cleaner added successfully!\n\n" +
                        "Name: " + txtFullName.Text.Trim() +
                        "\nEmail: " + txtEmail.Text.Trim() +
                        "\n\nThe cleaner can now log in using the email " +
                        "and password you created.",
                        "Cleaner Account Created",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    LoadCleaners();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding cleaner: " + ex.Message);
            }
        }

        // SELECT CLEANER
        private void dgvCleaners_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCleaners.Rows[e.RowIndex];

                selectedCleanerID =
                    Convert.ToInt32(row.Cells["CleanerID"].Value);

                selectedUserID =
                    Convert.ToInt32(row.Cells["UserID"].Value);

                txtFullName.Text =
                    row.Cells["FullName"].Value?.ToString() ?? "";

                txtEmail.Text =
                    row.Cells["Email"].Value?.ToString() ?? "";

                txtPhone.Text =
                    row.Cells["Phone"].Value?.ToString() ?? "";

                txtPassword.Clear();
            }
        }

        // UPDATE CLEANER
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedCleanerID == 0)
            {
                MessageBox.Show("Please select a cleaner first.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Full Name and Email are required.");
                return;
            }

            try
            {
                Cleaner cleaner = new Cleaner
                {
                    CleanerID = selectedCleanerID,
                    UserID = selectedUserID,
                    FullName = txtFullName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Phone = txtPhone.Text.Trim()
                };

                if (controller.UpdateCleaner(cleaner))
                {
                    MessageBox.Show("Cleaner updated successfully!");
                    LoadCleaners();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating cleaner: " + ex.Message);
            }
        }

        // DELETE CLEANER
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCleanerID == 0)
            {
                MessageBox.Show("Please select a cleaner first.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this cleaner?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (controller.DeleteCleaner(selectedCleanerID))
                    {
                        MessageBox.Show("Cleaner deleted successfully!");
                        LoadCleaners();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Cleaner was not found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error deleting cleaner: " + ex.Message +
                        "\n\nA cleaner assigned to existing bookings cannot be deleted."
                    );
                }
            }
        }

        // CLEAR FIELDS
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtPassword.Clear();

            selectedCleanerID = 0;
            selectedUserID = 0;

            dgvCleaners.ClearSelection();
        }

        private void CleanersView_Load_1(object sender, EventArgs e)
        {
        }
    }
}
