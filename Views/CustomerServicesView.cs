
using System;
using System.Windows.Forms;
using SparkClean.Controllers;

namespace SparkClean.Views
{
    public partial class CustomerServicesView : Form
    {
        private ServiceController controller = new ServiceController();

        public CustomerServicesView()
        {
            InitializeComponent();
            FormStyle.Apply(this);



            btnRefresh.Click += btnRefresh_Click;
            btnClose.Click += btnClose_Click;

            LoadServices();
        }

        private void LoadServices()
        {
            try
            {
                dgvServices.DataSource = controller.GetAllServices();

                dgvServices.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvServices.ReadOnly = true;
                dgvServices.AllowUserToAddRows = false;
                dgvServices.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load services: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadServices();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
