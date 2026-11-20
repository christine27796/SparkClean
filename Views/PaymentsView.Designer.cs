namespace SparkClean.Views
{
    partial class PaymentsView
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
            dgvPayments = new DataGridView();
            btnRefresh = new Button();
            btnUpdateStatus = new Button();
            btnClose = new Button();
            cmbPaymentStatus = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(48, 355);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(157, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "\tManage Payments";
            // 
            // dgvPayments
            // 
            dgvPayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPayments.Location = new Point(31, 67);
            dgvPayments.Name = "dgvPayments";
            dgvPayments.RowHeadersWidth = 62;
            dgvPayments.Size = new Size(656, 225);
            dgvPayments.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(93, 472);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(112, 34);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnUpdateStatus
            // 
            btnUpdateStatus.Location = new Point(364, 472);
            btnUpdateStatus.Name = "btnUpdateStatus";
            btnUpdateStatus.Size = new Size(112, 34);
            btnUpdateStatus.TabIndex = 3;
            btnUpdateStatus.Text = "Update Status";
            btnUpdateStatus.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(591, 472);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(112, 34);
            btnClose.TabIndex = 4;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // cmbPaymentStatus
            // 
            cmbPaymentStatus.FormattingEnabled = true;
            cmbPaymentStatus.Location = new Point(248, 347);
            cmbPaymentStatus.Name = "cmbPaymentStatus";
            cmbPaymentStatus.Size = new Size(182, 33);
            cmbPaymentStatus.TabIndex = 5;
            // 
            // PaymentsView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 635);
            Controls.Add(cmbPaymentStatus);
            Controls.Add(btnClose);
            Controls.Add(btnUpdateStatus);
            Controls.Add(btnRefresh);
            Controls.Add(dgvPayments);
            Controls.Add(lblTitle);
            Name = "PaymentsView";
            Text = "PaymentsView";
            ((System.ComponentModel.ISupportInitialize)dgvPayments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private DataGridView dgvPayments;
        private Button btnRefresh;
        private Button btnUpdateStatus;
        private Button btnClose;
        private ComboBox cmbPaymentStatus;
    }
}