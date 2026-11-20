
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SparkClean.Views
{
    public partial class HomeView : Form
    {
        public HomeView()
        {
            InitializeComponent();
            CreateHomePage();
        }

        private void CreateHomePage()
        {
            Text = "SparkClean";
            Size = new Size(600, 450);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Label lblTitle = new Label();
            lblTitle.Text = "SparkClean";
            lblTitle.Font = new Font("Arial", 22, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(200, 55);

            Label lblWelcome = new Label();
            lblWelcome.Text = "Welcome! Select your portal.";
            lblWelcome.Font = new Font("Arial", 12);
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(175, 125);

            Button btnAdmin = CreateButton("Admin", 185);
            Button btnCustomer = CreateButton("Customer", 255);
            Button btnCleaner = CreateButton("Cleaner", 325);

            btnAdmin.Click += btnAdmin_Click;
            btnCustomer.Click += btnCustomer_Click;
            btnCleaner.Click += btnCleaner_Click;

            Controls.Add(lblTitle);
            Controls.Add(lblWelcome);
            Controls.Add(btnAdmin);
            Controls.Add(btnCustomer);
            Controls.Add(btnCleaner);
        }

        private Button CreateButton(string text, int y)
        {
            Button button = new Button();
            button.Text = text;
            button.Size = new Size(180, 45);
            button.Location = new Point(200, y);
            button.Font = new Font("Arial", 11);

            return button;
        }

        private void OpenLogin()
        {
            using (LoginView login = new LoginView())
            {
                login.ShowDialog();
            }
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            OpenLogin();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            OpenLogin();
        }

        private void btnCleaner_Click(object sender, EventArgs e)
        {
            OpenLogin();
        }
    }
}
