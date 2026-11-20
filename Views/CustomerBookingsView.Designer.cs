namespace SparkClean.Views
{
    partial class CustomerBookingsView
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
            btnClose = new Button();
            btnCancelBooking = new Button();
            btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBookings).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(291, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(116, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "My Bookings";
            lblTitle.Click += label1_Click;
            // 
            // dgvBookings
            // 
            dgvBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBookings.Location = new Point(59, 59);
            dgvBookings.Name = "dgvBookings";
            dgvBookings.RowHeadersWidth = 62;
            dgvBookings.Size = new Size(569, 225);
            dgvBookings.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(516, 373);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(112, 34);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // btnCancelBooking
            // 
            btnCancelBooking.Location = new Point(239, 373);
            btnCancelBooking.Name = "btnCancelBooking";
            btnCancelBooking.Size = new Size(155, 34);
            btnCancelBooking.TabIndex = 3;
            btnCancelBooking.Text = "Cancel Booking";
            btnCancelBooking.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(33, 373);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(112, 34);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // CustomerBookingsView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRefresh);
            Controls.Add(btnCancelBooking);
            Controls.Add(btnClose);
            Controls.Add(dgvBookings);
            Controls.Add(lblTitle);
            Name = "CustomerBookingsView";
            Text = "CustomerBookingsView";
            ((System.ComponentModel.ISupportInitialize)dgvBookings).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private DataGridView dgvBookings;
        private Button btnClose;
        private Button btnCancelBooking;
        private Button btnRefresh;
    }
}