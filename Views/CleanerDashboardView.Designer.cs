namespace SparkClean.Views
{
    partial class CleanerDashboardView
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
            lblWelcome = new Label();
            btnMyJobs = new Button();
            btnLogout = new Button();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(340, 23);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(157, 25);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "\tWelcome, Cleaner!";
            // 
            // btnMyJobs
            // 
            btnMyJobs.Location = new Point(36, 121);
            btnMyJobs.Name = "btnMyJobs";
            btnMyJobs.Size = new Size(239, 34);
            btnMyJobs.TabIndex = 1;
            btnMyJobs.Text = "\tMy Assigned Jobs";
            btnMyJobs.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(108, 285);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(112, 34);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // CleanerDashboardView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLogout);
            Controls.Add(btnMyJobs);
            Controls.Add(lblWelcome);
            Name = "CleanerDashboardView";
            Text = "CleanerDashboardView";
            Load += CleanerDashboardView_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Button btnMyJobs;
        private Button btnLogout;
    }
}