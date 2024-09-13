namespace DynamicBakery.Screens.DashboardUserControls
{
    partial class CustomersScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblStaticStatus = new Label();
            lblStatus = new Label();
            btnQRCodeConnect = new Button();
            btnUpdateCustomer = new Button();
            btnQRCodeReset = new Button();
            txtEmailResetUpdate = new TextBox();
            pnlInfo = new Panel();
            cboLoyalty = new ComboBox();
            txtLastName = new TextBox();
            txtEmailInfo = new TextBox();
            lblEmailInfo = new Label();
            lblLoyaltyStatus = new Label();
            txtFirstName = new TextBox();
            lblLastName = new Label();
            lblFirstName = new Label();
            lblEmailReset = new Label();
            pnlReset = new Panel();
            btnDelete = new Button();
            pnlInfo.SuspendLayout();
            pnlReset.SuspendLayout();
            SuspendLayout();
            // 
            // lblStaticStatus
            // 
            lblStaticStatus.AutoSize = true;
            lblStaticStatus.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStaticStatus.Location = new Point(436, 26);
            lblStaticStatus.Name = "lblStaticStatus";
            lblStaticStatus.Size = new Size(63, 23);
            lblStaticStatus.TabIndex = 0;
            lblStaticStatus.Text = "Status:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(506, 26);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(114, 23);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Disconnected";
            // 
            // btnQRCodeConnect
            // 
            btnQRCodeConnect.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnQRCodeConnect.Location = new Point(528, 83);
            btnQRCodeConnect.Name = "btnQRCodeConnect";
            btnQRCodeConnect.Size = new Size(92, 52);
            btnQRCodeConnect.TabIndex = 2;
            btnQRCodeConnect.Text = "Scan QR Code";
            btnQRCodeConnect.UseVisualStyleBackColor = true;
            btnQRCodeConnect.Click += btnQRCodeConnect_Click;
            // 
            // btnUpdateCustomer
            // 
            btnUpdateCustomer.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUpdateCustomer.Location = new Point(407, 83);
            btnUpdateCustomer.Name = "btnUpdateCustomer";
            btnUpdateCustomer.Size = new Size(92, 52);
            btnUpdateCustomer.TabIndex = 3;
            btnUpdateCustomer.Text = "Update Customer";
            btnUpdateCustomer.UseVisualStyleBackColor = true;
            btnUpdateCustomer.Click += btnUpdateCustomer_Click;
            // 
            // btnQRCodeReset
            // 
            btnQRCodeReset.BackColor = SystemColors.Window;
            btnQRCodeReset.BackgroundImageLayout = ImageLayout.None;
            btnQRCodeReset.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnQRCodeReset.Location = new Point(43, 66);
            btnQRCodeReset.Name = "btnQRCodeReset";
            btnQRCodeReset.Size = new Size(149, 37);
            btnQRCodeReset.TabIndex = 4;
            btnQRCodeReset.Text = "Resend QR Code";
            btnQRCodeReset.UseVisualStyleBackColor = false;
            btnQRCodeReset.Click += btnQRCodeReset_Click;
            // 
            // txtEmailResetUpdate
            // 
            txtEmailResetUpdate.Location = new Point(85, 22);
            txtEmailResetUpdate.Name = "txtEmailResetUpdate";
            txtEmailResetUpdate.Size = new Size(120, 23);
            txtEmailResetUpdate.TabIndex = 5;
            // 
            // pnlInfo
            // 
            pnlInfo.BackColor = SystemColors.ControlLight;
            pnlInfo.BorderStyle = BorderStyle.FixedSingle;
            pnlInfo.Controls.Add(cboLoyalty);
            pnlInfo.Controls.Add(txtLastName);
            pnlInfo.Controls.Add(txtEmailInfo);
            pnlInfo.Controls.Add(lblEmailInfo);
            pnlInfo.Controls.Add(lblLoyaltyStatus);
            pnlInfo.Controls.Add(txtFirstName);
            pnlInfo.Controls.Add(lblLastName);
            pnlInfo.Controls.Add(lblFirstName);
            pnlInfo.Location = new Point(36, 105);
            pnlInfo.Name = "pnlInfo";
            pnlInfo.Size = new Size(320, 266);
            pnlInfo.TabIndex = 6;
            // 
            // cboLoyalty
            // 
            cboLoyalty.FormattingEnabled = true;
            cboLoyalty.Items.AddRange(new object[] { "Bronze", "Silver", "Gold" });
            cboLoyalty.Location = new Point(131, 206);
            cboLoyalty.Name = "cboLoyalty";
            cboLoyalty.Size = new Size(130, 23);
            cboLoyalty.TabIndex = 13;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(131, 96);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(176, 23);
            txtLastName.TabIndex = 12;
            // 
            // txtEmailInfo
            // 
            txtEmailInfo.Location = new Point(131, 152);
            txtEmailInfo.Name = "txtEmailInfo";
            txtEmailInfo.Size = new Size(176, 23);
            txtEmailInfo.TabIndex = 8;
            // 
            // lblEmailInfo
            // 
            lblEmailInfo.AutoSize = true;
            lblEmailInfo.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmailInfo.Location = new Point(21, 152);
            lblEmailInfo.Name = "lblEmailInfo";
            lblEmailInfo.Size = new Size(49, 19);
            lblEmailInfo.TabIndex = 11;
            lblEmailInfo.Text = "Email:";
            // 
            // lblLoyaltyStatus
            // 
            lblLoyaltyStatus.AutoSize = true;
            lblLoyaltyStatus.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLoyaltyStatus.Location = new Point(21, 206);
            lblLoyaltyStatus.Name = "lblLoyaltyStatus";
            lblLoyaltyStatus.Size = new Size(103, 19);
            lblLoyaltyStatus.TabIndex = 10;
            lblLoyaltyStatus.Text = "Loyalty Status:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(131, 44);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(176, 23);
            txtFirstName.TabIndex = 7;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLastName.Location = new Point(21, 96);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(82, 19);
            lblLastName.TabIndex = 8;
            lblLastName.Text = "Last Name:";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFirstName.Location = new Point(21, 44);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(83, 19);
            lblFirstName.TabIndex = 7;
            lblFirstName.Text = "First Name:";
            // 
            // lblEmailReset
            // 
            lblEmailReset.AutoSize = true;
            lblEmailReset.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmailReset.Location = new Point(14, 22);
            lblEmailReset.Name = "lblEmailReset";
            lblEmailReset.Size = new Size(49, 19);
            lblEmailReset.TabIndex = 12;
            lblEmailReset.Text = "Email:";
            // 
            // pnlReset
            // 
            pnlReset.BackColor = SystemColors.ControlLight;
            pnlReset.BorderStyle = BorderStyle.FixedSingle;
            pnlReset.Controls.Add(btnDelete);
            pnlReset.Controls.Add(lblEmailReset);
            pnlReset.Controls.Add(txtEmailResetUpdate);
            pnlReset.Controls.Add(btnQRCodeReset);
            pnlReset.Location = new Point(392, 202);
            pnlReset.Name = "pnlReset";
            pnlReset.Size = new Size(228, 169);
            pnlReset.TabIndex = 13;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = SystemColors.Window;
            btnDelete.BackgroundImageLayout = ImageLayout.None;
            btnDelete.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(43, 109);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(149, 37);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Delete Customer";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // CustomersScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlReset);
            Controls.Add(pnlInfo);
            Controls.Add(btnUpdateCustomer);
            Controls.Add(btnQRCodeConnect);
            Controls.Add(lblStatus);
            Controls.Add(lblStaticStatus);
            Name = "CustomersScreen";
            Size = new Size(650, 400);
            pnlInfo.ResumeLayout(false);
            pnlInfo.PerformLayout();
            pnlReset.ResumeLayout(false);
            pnlReset.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStaticStatus;
        private Label lblStatus;
        private Button btnQRCodeConnect;
        private Button btnUpdateCustomer;
        private Button btnQRCodeReset;
        private TextBox txtEmailResetUpdate;
        private Panel pnlInfo;
        private TextBox txtEmailInfo;
        private Label lblEmailInfo;
        private Label lblLoyaltyStatus;
        private TextBox txtFirstName;
        private Label lblLastName;
        private Label lblFirstName;
        private TextBox txtLastName;
        private ComboBox cboLoyalty;
        private Label lblEmailReset;
        private Panel pnlReset;
        private Button btnDelete;
    }
}
