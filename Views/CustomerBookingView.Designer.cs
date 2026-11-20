namespace SparkClean.Views
{
    partial class CustomerBookingView
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
            lblService = new Label();
            lblDate = new Label();
            lblTime = new Label();
            cmbService = new ComboBox();
            dtpBookingDate = new DateTimePicker();
            dtpBookingTime = new DateTimePicker();
            btnBook = new Button();
            btnClear = new Button();
            btnClose = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(268, 23);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(200, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "\tBook a Cleaning Service";
            // 
            // lblService
            // 
            lblService.AutoSize = true;
            lblService.Location = new Point(16, 189);
            lblService.Name = "lblService";
            lblService.Size = new Size(118, 25);
            lblService.TabIndex = 1;
            lblService.Text = "Select Service";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(16, 245);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(120, 25);
            lblDate.TabIndex = 2;
            lblDate.Text = "Booking Date";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(16, 316);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(121, 25);
            lblTime.TabIndex = 3;
            lblTime.Text = "Booking Time";
            // 
            // cmbService
            // 
            cmbService.FormattingEnabled = true;
            cmbService.Location = new Point(172, 189);
            cmbService.Name = "cmbService";
            cmbService.Size = new Size(182, 33);
            cmbService.TabIndex = 4;
            // 
            // dtpBookingDate
            // 
            dtpBookingDate.Format = DateTimePickerFormat.Short;
            dtpBookingDate.Location = new Point(172, 245);
            dtpBookingDate.Name = "dtpBookingDate";
            dtpBookingDate.Size = new Size(300, 31);
            dtpBookingDate.TabIndex = 5;
            // 
            // dtpBookingTime
            // 
            dtpBookingTime.Format = DateTimePickerFormat.Time;
            dtpBookingTime.Location = new Point(172, 311);
            dtpBookingTime.Name = "dtpBookingTime";
            dtpBookingTime.Size = new Size(300, 31);
            dtpBookingTime.TabIndex = 6;
            // 
            // btnBook
            // 
            btnBook.Location = new Point(22, 490);
            btnBook.Name = "btnBook";
            btnBook.Size = new Size(112, 34);
            btnBook.TabIndex = 7;
            btnBook.Text = "Confirm Booking";
            btnBook.UseVisualStyleBackColor = true;
            btnBook.Click += button1_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(308, 490);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(112, 34);
            btnClear.TabIndex = 8;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(580, 490);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(112, 34);
            btnClose.TabIndex = 9;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // CustomerBookingView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 592);
            Controls.Add(btnClose);
            Controls.Add(btnClear);
            Controls.Add(btnBook);
            Controls.Add(dtpBookingTime);
            Controls.Add(dtpBookingDate);
            Controls.Add(cmbService);
            Controls.Add(lblTime);
            Controls.Add(lblDate);
            Controls.Add(lblService);
            Controls.Add(lblTitle);
            Name = "CustomerBookingView";
            Text = "CustomerBookingView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblService;
        private Label lblDate;
        private Label lblTime;
        private ComboBox cmbService;
        private DateTimePicker dtpBookingDate;
        private DateTimePicker dtpBookingTime;
        private Button btnBook;
        private Button btnClear;
        private Button btnClose;
    }
}