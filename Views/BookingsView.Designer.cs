namespace SparkClean.Views
{
    partial class BookingsView
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
            dgvBookings = new DataGridView();
            lblCleaner = new Label();
            cmbCleaner = new ComboBox();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            btnClose = new Button();
            btnRefresh = new Button();
            btnUpdateStatus = new Button();
            btnAssignCleaner = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBookings).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(256, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(155, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Manage Bookings";
            // 
            // dgvBookings
            // 
            dgvBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBookings.Location = new Point(82, 57);
            dgvBookings.MultiSelect = false;
            dgvBookings.Name = "dgvBookings";
            dgvBookings.ReadOnly = true;
            dgvBookings.RowHeadersWidth = 62;
            dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBookings.Size = new Size(497, 225);
            dgvBookings.TabIndex = 1;
            // 
            // lblCleaner
            // 
            lblCleaner.AutoSize = true;
            lblCleaner.Location = new Point(12, 410);
            lblCleaner.Name = "lblCleaner";
            lblCleaner.Size = new Size(128, 25);
            lblCleaner.TabIndex = 2;
            lblCleaner.Text = "Assign Cleaner";
            // 
            // cmbCleaner
            // 
            cmbCleaner.FormattingEnabled = true;
            cmbCleaner.Location = new Point(146, 410);
            cmbCleaner.Name = "cmbCleaner";
            cmbCleaner.Size = new Size(182, 33);
            cmbCleaner.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(442, 413);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(131, 25);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Booking Status";
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(579, 413);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(182, 33);
            cmbStatus.TabIndex = 5;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(568, 566);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(112, 34);
            btnClose.TabIndex = 6;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(352, 566);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(112, 34);
            btnRefresh.TabIndex = 7;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnUpdateStatus
            // 
            btnUpdateStatus.Location = new Point(171, 566);
            btnUpdateStatus.Name = "btnUpdateStatus";
            btnUpdateStatus.Size = new Size(112, 34);
            btnUpdateStatus.TabIndex = 8;
            btnUpdateStatus.Text = "Update Status";
            btnUpdateStatus.UseVisualStyleBackColor = true;
            // 
            // btnAssignCleaner
            // 
            btnAssignCleaner.Location = new Point(12, 566);
            btnAssignCleaner.Name = "btnAssignCleaner";
            btnAssignCleaner.Size = new Size(112, 34);
            btnAssignCleaner.TabIndex = 9;
            btnAssignCleaner.Text = "Assign Cleaner";
            btnAssignCleaner.UseVisualStyleBackColor = true;
            // 
            // BookingsView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 625);
            Controls.Add(btnAssignCleaner);
            Controls.Add(btnUpdateStatus);
            Controls.Add(btnRefresh);
            Controls.Add(btnClose);
            Controls.Add(cmbStatus);
            Controls.Add(lblStatus);
            Controls.Add(cmbCleaner);
            Controls.Add(lblCleaner);
            Controls.Add(dgvBookings);
            Controls.Add(lblTitle);
            Name = "BookingsView";
            Text = "BookingsView";
            ((System.ComponentModel.ISupportInitialize)dgvBookings).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private DataGridView dgvBookings;
        private Label lblCleaner;
        private ComboBox cmbCleaner;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Button btnClose;
        private Button btnRefresh;
        private Button btnUpdateStatus;
        private Button btnAssignCleaner;
    }
}