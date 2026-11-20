
using System;
using System.Windows.Forms;
using SparkClean.Controllers;

namespace SparkClean.Views
{
    public partial class CustomerRegistrationView : Form
    {
        private CustomerController controller = new CustomerController();

        public CustomerRegistrationView()
        {
            InitializeComponent();
            FormStyle.Apply(this);

            btnRegister.Click += btnRegister_Click;
            btnClear.Click += btnClear_Click;
            btnBack.Click += btnBack_Click;

            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                bool registered = controller.RegisterCustomer(
                    txtFullName.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtPassword.Text,
                    txtPhone.Text.Trim(),
                    txtAddress.Text.Trim()
                );

                if (registered)
                {
                    MessageBox.Show(
                        "Registration successful! You can now log in.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    ClearFields();
                    Close();
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Registration failed: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClearFields()
        {
            txtFullName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
        }

        // Designer event handlers
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
        }
    }
}
