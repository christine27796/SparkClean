namespace SparkClean.Views
{
    partial class CustomerDashboardView
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
            lblWelcome = new Label();
            btnServices = new Button();
            btnBookings = new Button();
            btnPayments = new Button();
            btnLogout = new Button();
            btnBookCleaning = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(195, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(275, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "\tSparkClean Customer Dashboard";
            lblTitle.Click += label1_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(255, 400);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(171, 25);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Welcome, Customer";
            // 
            // btnServices
            // 
            btnServices.Location = new Point(12, 158);
            btnServices.Name = "btnServices";
            btnServices.Size = new Size(254, 34);
            btnServices.TabIndex = 2;
            btnServices.Text = "View Cleaning Services";
            btnServices.UseVisualStyleBackColor = true;
            // 
            // btnBookings
            // 
            btnBookings.Location = new Point(12, 216);
            btnBookings.Name = "btnBookings";
            btnBookings.Size = new Size(254, 34);
            btnBookings.TabIndex = 3;
            btnBookings.Text = "My Bookings";
            btnBookings.UseVisualStyleBackColor = true;
            // 
            // btnPayments
            // 
            btnPayments.Location = new Point(12, 280);
            btnPayments.Name = "btnPayments";
            btnPayments.Size = new Size(254, 34);
            btnPayments.TabIndex = 4;
            btnPayments.Text = "My Payments";
            btnPayments.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(608, 324);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(112, 34);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnBookCleaning
            // 
            btnBookCleaning.Location = new Point(12, 344);
            btnBookCleaning.Name = "btnBookCleaning";
            btnBookCleaning.Size = new Size(254, 34);
            btnBookCleaning.TabIndex = 6;
            btnBookCleaning.Text = "\tBook a Cleaning Service";
            btnBookCleaning.UseVisualStyleBackColor = true;
            // 
            // CustomerDashboardView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBookCleaning);
            Controls.Add(btnLogout);
            Controls.Add(btnPayments);
            Controls.Add(btnBookings);
            Controls.Add(btnServices);
            Controls.Add(lblWelcome);
            Controls.Add(lblTitle);
            Name = "CustomerDashboardView";
            Text = "CustomerDashboardView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblWelcome;
        private Button btnServices;
        private Button btnBookings;
        private Button btnPayments;
        private Button btnLogout;
        private Button btnBookCleaning;
    }
}