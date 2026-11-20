namespace SparkClean.Views
{
    partial class ServicesView
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
            lblServiceName = new Label();
            lblDescription = new Label();
            lblPrice = new Label();
            txtPrice = new TextBox();
            txtDescription = new TextBox();
            txtServiceName = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            dgvServices = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvServices).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(264, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(217, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Manage Cleaning Services";
            // 
            // lblServiceName
            // 
            lblServiceName.AutoSize = true;
            lblServiceName.Location = new Point(8, 126);
            lblServiceName.Name = "lblServiceName";
            lblServiceName.Size = new Size(119, 25);
            lblServiceName.TabIndex = 1;
            lblServiceName.Text = "Service Name";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(12, 187);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(102, 25);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Description";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(8, 266);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(101, 25);
            lblPrice.TabIndex = 3;
            lblPrice.Text = "Price (RWF)";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(131, 266);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(150, 31);
            txtPrice.TabIndex = 4;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(148, 187);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(150, 31);
            txtDescription.TabIndex = 5;
            // 
            // txtServiceName
            // 
            txtServiceName.Location = new Point(148, 126);
            txtServiceName.Name = "txtServiceName";
            txtServiceName.Size = new Size(150, 31);
            txtServiceName.TabIndex = 6;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(15, 387);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Add Service";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(201, 387);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 34);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Update Service";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(400, 387);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Delete Service";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(569, 387);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(112, 34);
            btnClear.TabIndex = 10;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // dgvServices
            // 
            dgvServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServices.Location = new Point(377, 72);
            dgvServices.MultiSelect = false;
            dgvServices.Name = "dgvServices";
            dgvServices.ReadOnly = true;
            dgvServices.RowHeadersWidth = 62;
            dgvServices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServices.Size = new Size(360, 225);
            dgvServices.TabIndex = 11;
            // 
            // ServicesView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvServices);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(txtServiceName);
            Controls.Add(txtDescription);
            Controls.Add(txtPrice);
            Controls.Add(lblPrice);
            Controls.Add(lblDescription);
            Controls.Add(lblServiceName);
            Controls.Add(lblTitle);
            Name = "ServicesView";
            Text = "ServicesView";
            ((System.ComponentModel.ISupportInitialize)dgvServices).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblServiceName;
        private Label lblDescription;
        private Label lblPrice;
        private TextBox txtPrice;
        private TextBox txtDescription;
        private TextBox txtServiceName;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private DataGridView dgvServices;
    }
}