namespace SparkClean.Views
{
    partial class AdminDashboardView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            btnCustomers = new Button();
            btnCleaners = new Button();
            btnServices = new Button();
            btnBookings = new Button();
            btnPayments = new Button();
            btnReports = new Button();
            btnLogout = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(177, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(313, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "\tSPARK CLEAN – ADMIN DASHBOARD";
            lblTitle.Click += label1_Click;
            // 
            // btnCustomers
            // 
            btnCustomers.Location = new Point(12, 69);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Size = new Size(192, 34);
            btnCustomers.TabIndex = 1;
            btnCustomers.Text = "Manage Customers";
            btnCustomers.UseVisualStyleBackColor = true;
            // 
            // btnCleaners
            // 
            btnCleaners.Location = new Point(12, 133);
            btnCleaners.Name = "btnCleaners";
            btnCleaners.Size = new Size(192, 34);
            btnCleaners.TabIndex = 2;
            btnCleaners.Text = "Manage Cleaners";
            btnCleaners.UseVisualStyleBackColor = true;
            // 
            // btnServices
            // 
            btnServices.Location = new Point(12, 188);
            btnServices.Name = "btnServices";
            btnServices.Size = new Size(192, 34);
            btnServices.TabIndex = 3;
            btnServices.Text = "Manage Services";
            btnServices.UseVisualStyleBackColor = true;
            btnServices.Click += button3_Click;
            // 
            // btnBookings
            // 
            btnBookings.Location = new Point(22, 243);
            btnBookings.Name = "btnBookings";
            btnBookings.Size = new Size(182, 34);
            btnBookings.TabIndex = 4;
            btnBookings.Text = "\tManage Bookings";
            btnBookings.UseVisualStyleBackColor = true;
            // 
            // btnPayments
            // 
            btnPayments.Location = new Point(12, 294);
            btnPayments.Name = "btnPayments";
            btnPayments.Size = new Size(192, 34);
            btnPayments.TabIndex = 5;
            btnPayments.Text = "Manage Payments";
            btnPayments.UseVisualStyleBackColor = true;
            btnPayments.Click += button5_Click;
            // 
            // btnReports
            // 
            btnReports.Location = new Point(12, 349);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(192, 34);
            btnReports.TabIndex = 6;
            btnReports.Text = "View Reports";
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += button6_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(12, 404);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(192, 34);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // AdminDashboardView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLogout);
            Controls.Add(btnReports);
            Controls.Add(btnPayments);
            Controls.Add(btnBookings);
            Controls.Add(btnServices);
            Controls.Add(btnCleaners);
            Controls.Add(btnCustomers);
            Controls.Add(lblTitle);
            Name = "AdminDashboardView";
            Text = "\tSpark Clean - Admin Dashboard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnCustomers;
        private Button btnCleaners;
        private Button btnServices;
        private Button btnBookings;
        private Button btnPayments;
        private Button btnReports;
        private Button btnLogout;
    }
}