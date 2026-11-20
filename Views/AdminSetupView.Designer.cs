namespace SparkClean.Views
{
    partial class AdminSetupView
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
            btnCreateAdmin = new Button();
            lblTitle = new Label();
            lblFullName = new Label();
            lblEmail = new Label();
            lblPassword = new Label();
            txtFullName = new TextBox();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            SuspendLayout();
            // 
            // btnCreateAdmin
            // 
            btnCreateAdmin.Location = new Point(285, 404);
            btnCreateAdmin.Name = "btnCreateAdmin";
            btnCreateAdmin.Size = new Size(236, 34);
            btnCreateAdmin.TabIndex = 0;
            btnCreateAdmin.Text = "Create Admin";
            btnCreateAdmin.UseVisualStyleBackColor = true;
            btnCreateAdmin.Click += button1_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(229, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(190, 25);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Create Admin Account";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(16, 219);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(91, 25);
            lblFullName.TabIndex = 2;
            lblFullName.Text = "Full Name";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(8, 286);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(54, 25);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(16, 357);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(87, 25);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(319, 213);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(150, 31);
            txtFullName.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(319, 351);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(150, 31);
            txtPassword.TabIndex = 6;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(331, 286);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(150, 31);
            txtEmail.TabIndex = 7;
            // 
            // AdminSetupView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtEmail);
            Controls.Add(txtPassword);
            Controls.Add(txtFullName);
            Controls.Add(lblPassword);
            Controls.Add(lblEmail);
            Controls.Add(lblFullName);
            Controls.Add(lblTitle);
            Controls.Add(btnCreateAdmin);
            Name = "AdminSetupView";
            Text = "AdminSetupView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCreateAdmin;
        private Label lblTitle;
        private Label lblFullName;
        private Label lblEmail;
        private Label lblPassword;
        private TextBox txtFullName;
        private TextBox txtPassword;
        private TextBox txtEmail;
    }
}