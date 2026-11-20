namespace SparkClean.Views
{
    partial class CleanerJobsView
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
            btnRefresh = new Button();
            btnUpdateStatus = new Button();
            btnClose = new Button();
            dgvJobs = new DataGridView();
            cmbJobStatus = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvJobs).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(12, 115);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(229, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "\tMy Assigned Cleaning Jobs";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(76, 375);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(112, 34);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnUpdateStatus
            // 
            btnUpdateStatus.Location = new Point(370, 375);
            btnUpdateStatus.Name = "btnUpdateStatus";
            btnUpdateStatus.Size = new Size(112, 34);
            btnUpdateStatus.TabIndex = 2;
            btnUpdateStatus.Text = "\tUpdate Job Status";
            btnUpdateStatus.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(559, 375);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(112, 34);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // dgvJobs
            // 
            dgvJobs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvJobs.Location = new Point(464, 12);
            dgvJobs.Name = "dgvJobs";
            dgvJobs.RowHeadersWidth = 62;
            dgvJobs.Size = new Size(409, 300);
            dgvJobs.TabIndex = 4;
            // 
            // cmbJobStatus
            // 
            cmbJobStatus.FormattingEnabled = true;
            cmbJobStatus.Location = new Point(256, 115);
            cmbJobStatus.Name = "cmbJobStatus";
            cmbJobStatus.Size = new Size(182, 33);
            cmbJobStatus.TabIndex = 5;
            // 
            // CleanerJobsView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(885, 450);
            Controls.Add(cmbJobStatus);
            Controls.Add(dgvJobs);
            Controls.Add(btnClose);
            Controls.Add(btnUpdateStatus);
            Controls.Add(btnRefresh);
            Controls.Add(lblTitle);
            Name = "CleanerJobsView";
            Text = "CleanerJobsView";
            ((System.ComponentModel.ISupportInitialize)dgvJobs).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnRefresh;
        private Button btnUpdateStatus;
        private Button btnClose;
        private DataGridView dgvJobs;
        private ComboBox cmbJobStatus;
    }
}