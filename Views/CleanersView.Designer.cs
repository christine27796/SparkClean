namespace SparkClean.Views
{
    partial class CleanersView
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
            lblFullName = new Label();
            lblPhone = new Label();
            lblEmail = new Label();
            txtFullName = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            dgvCleaners = new DataGridView();
            btnAdd = new Button();
            lblPassword = new Label();
            txtPassword = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvCleaners).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(309, 26);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(147, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Manage Cleaners";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(12, 138);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(91, 25);
            lblFullName.TabIndex = 1;
            lblFullName.Text = "Full Name";
            lblFullName.Click += lblFullName_Click;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(16, 191);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(62, 25);
            lblPhone.TabIndex = 2;
            lblPhone.Text = "Phone";
            lblPhone.Click += label3_Click;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(12, 244);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(54, 25);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(145, 138);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(150, 31);
            txtFullName.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(145, 256);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(150, 31);
            txtEmail.TabIndex = 5;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(145, 191);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(150, 31);
            txtPhone.TabIndex = 6;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(250, 478);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 34);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Update Cleaner";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(557, 478);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete Cleaner";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(736, 478);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(112, 34);
            btnClear.TabIndex = 9;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // dgvCleaners
            // 
            dgvCleaners.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCleaners.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCleaners.Location = new Point(421, 114);
            dgvCleaners.MultiSelect = false;
            dgvCleaners.Name = "dgvCleaners";
            dgvCleaners.ReadOnly = true;
            dgvCleaners.RowHeadersWidth = 62;
            dgvCleaners.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCleaners.Size = new Size(487, 326);
            dgvCleaners.TabIndex = 10;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(16, 478);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "Add Cleaner";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(16, 319);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(87, 25);
            lblPassword.TabIndex = 12;
            lblPassword.Text = "Password";
            lblPassword.Click += label1_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(145, 313);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(150, 31);
            txtPassword.TabIndex = 13;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // CleanersView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(916, 580);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(btnAdd);
            Controls.Add(dgvCleaners);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(txtPhone);
            Controls.Add(txtEmail);
            Controls.Add(txtFullName);
            Controls.Add(lblEmail);
            Controls.Add(lblPhone);
            Controls.Add(lblFullName);
            Controls.Add(lblTitle);
            Name = "CleanersView";
            Text = "CleanersView";
            Load += CleanersView_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvCleaners).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblFullName;
        private Label lblPhone;
        private Label lblEmail;
        private TextBox txtFullName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private DataGridView dgvCleaners;
        private Button btnAdd;
        private Label lblPassword;
        private TextBox txtPassword;
    }
}