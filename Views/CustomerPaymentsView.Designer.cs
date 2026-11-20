namespace SparkClean.Views
{
    partial class CustomerPaymentsView
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
            btnClose = new Button();
            lblPaymentMethod = new Label();
            cmbPaymentMethod = new ComboBox();
            btnMakePayment = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(320, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(118, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "My Payments";
            // 
            // dgvPayments
            // 
            dgvPayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPayments.Location = new Point(453, 51);
            dgvPayments.Name = "dgvPayments";
            dgvPayments.RowHeadersWidth = 62;
            dgvPayments.Size = new Size(460, 257);
            dgvPayments.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(475, 367);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(112, 34);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(658, 367);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(112, 34);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // lblPaymentMethod
            // 
            lblPaymentMethod.AutoSize = true;
            lblPaymentMethod.Location = new Point(12, 68);
            lblPaymentMethod.Name = "lblPaymentMethod";
            lblPaymentMethod.Size = new Size(148, 25);
            lblPaymentMethod.TabIndex = 4;
            lblPaymentMethod.Text = "Payment Method";
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.FormattingEnabled = true;
            cmbPaymentMethod.Location = new Point(181, 68);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(182, 33);
            cmbPaymentMethod.TabIndex = 5;
            // 
            // btnMakePayment
            // 
            btnMakePayment.Location = new Point(26, 198);
            btnMakePayment.Name = "btnMakePayment";
            btnMakePayment.Size = new Size(199, 34);
            btnMakePayment.TabIndex = 6;
            btnMakePayment.Text = "Make Payment";
            btnMakePayment.UseVisualStyleBackColor = true;
            // 
            // CustomerPaymentsView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 450);
            Controls.Add(btnMakePayment);
            Controls.Add(cmbPaymentMethod);
            Controls.Add(lblPaymentMethod);
            Controls.Add(btnClose);
            Controls.Add(btnRefresh);
            Controls.Add(dgvPayments);
            Controls.Add(lblTitle);
            Name = "CustomerPaymentsView";
            Text = "CustomerPaymentsView";
            ((System.ComponentModel.ISupportInitialize)dgvPayments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private DataGridView dgvPayments;
        private Button btnRefresh;
        private Button btnClose;
        private Label lblPaymentMethod;
        private ComboBox cmbPaymentMethod;
        private Button btnMakePayment;
    }
}