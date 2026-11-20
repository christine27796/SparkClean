namespace SparkClean
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {


            DatabaseConnection db = new DatabaseConnection();

            if (db.TestConnection())
            {
                MessageBox.Show("Database connected successfully!");
            }
            else
            {
                MessageBox.Show("Database connection failed!");
            }

        }
    }
}
