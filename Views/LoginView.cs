
using System;
using System.Windows.Forms;
using SparkClean.Controllers;

namespace SparkClean.Views
{
    public partial class LoginView : Form
    {
        public LoginView()
        {
            InitializeComponent();
            FormStyle.Apply(this);

            btnRegister.Click += btnRegister_Click;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter your email and password.");
                return;
            }

            try
            {
                LoginController controller = new LoginController();

                var user = controller.Login(email, password);

                if (user == null)
                {
                    MessageBox.Show("Invalid email or password.");
                    return;
                }

                MessageBox.Show("Welcome " + user.FullName + "!");

                this.Hide();

                if (user.Role == "Admin")
                {
                    using (AdminDashboardView dashboard =
                        new AdminDashboardView())
                    {
                        dashboard.ShowDialog();
                    }
                }
                else if (user.Role == "Customer")
                {
                    using (CustomerDashboardView dashboard =
                        new CustomerDashboardView(user))
                    {
                        dashboard.ShowDialog();
                    }
                }
                else if (user.Role == "Cleaner")
                {
                    using (CleanerDashboardView dashboard =
                        new CleanerDashboardView(user))
                    {
                        dashboard.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Unknown user role.");
                }

                txtPassword.Clear();
                this.Show();
            }
            catch (Exception ex)
            {
                this.Show();
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            using (CustomerRegistrationView registration =
                new CustomerRegistrationView())
            {
                registration.ShowDialog();
            }
        }
    }
}
