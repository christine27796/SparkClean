
using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using SparkClean;

namespace SparkClean.Views
{
    public partial class AdminSetupView : Form
    {
        private DatabaseConnection db = new DatabaseConnection();

        public AdminSetupView()
        {
            InitializeComponent();
        }

        // Create Admin account
        private void btnCreateAdmin_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            // Check empty fields
            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Check password length
            if (password.Length < 8)
            {
                MessageBox.Show(
                    "Password must contain at least 8 characters.");
                return;
            }

            try
            {
                using (SqlConnection connection = db.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        INSERT INTO Users
                        (FullName, Email, PasswordHash, Role)
                        VALUES
                        (@FullName, @Email, @PasswordHash, @Role)";

                    using (SqlCommand command =
                        new SqlCommand(query, connection))
                    {
                        string hashedPassword =
                            PasswordHelper.HashPassword(password);

                        command.Parameters.AddWithValue(
                            "@FullName", fullName);

                        command.Parameters.AddWithValue(
                            "@Email", email);

                        command.Parameters.AddWithValue(
                            "@PasswordHash", hashedPassword);

                        command.Parameters.AddWithValue(
                            "@Role", "Admin");

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Admin account created successfully!");

                txtFullName.Clear();
                txtEmail.Clear();
                txtPassword.Clear();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show(
                        "This email address is already registered.");
                }
                else
                {
                    MessageBox.Show(
                        "Database error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Connect the old Designer event to the new button method
        private void button1_Click(object sender, EventArgs e)
        {
            btnCreateAdmin_Click(sender, e);
        }
    }
}
