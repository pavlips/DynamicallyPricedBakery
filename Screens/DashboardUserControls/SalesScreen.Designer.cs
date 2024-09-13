namespace DynamicBakery.Screens.DashboardUserControls
{
    partial class SalesScreen
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
            components = new System.ComponentModel.Container();
            btnConfirm = new Button();
            btnQRCodeConnect = new Button();
            lblStatus = new Label();
            lblStaticStatus = new Label();
            dgvProducts = new DataGridView();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            currentPriceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            quantityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            productBindingSource = new BindingSource(components);
            dgvCart = new DataGridView();
            nameDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            CurrentPrice = new DataGridViewTextBoxColumn();
            quantityDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            btnReset = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();
            // 
            // btnConfirm
            // 
            btnConfirm.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConfirm.Location = new Point(405, 321);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(80, 52);
            btnConfirm.TabIndex = 17;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnQRCodeConnect
            // 
            btnQRCodeConnect.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnQRCodeConnect.Location = new Point(229, 27);
            btnQRCodeConnect.Name = "btnQRCodeConnect";
            btnQRCodeConnect.Size = new Size(92, 52);
            btnQRCodeConnect.TabIndex = 16;
            btnQRCodeConnect.Text = "Scan QR Code";
            btnQRCodeConnect.UseVisualStyleBackColor = true;
            btnQRCodeConnect.Click += btnQRCodeConnect_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(81, 41);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(114, 23);
            lblStatus.TabIndex = 15;
            lblStatus.Text = "Disconnected";
            // 
            // lblStaticStatus
            // 
            lblStaticStatus.AutoSize = true;
            lblStaticStatus.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStaticStatus.Location = new Point(12, 41);
            lblStaticStatus.Name = "lblStaticStatus";
            lblStaticStatus.Size = new Size(63, 23);
            lblStaticStatus.TabIndex = 14;
            lblStaticStatus.Text = "Status:";
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { nameDataGridViewTextBoxColumn, currentPriceDataGridViewTextBoxColumn, quantityDataGridViewTextBoxColumn });
            dgvProducts.DataSource = productBindingSource;
            dgvProducts.Location = new Point(12, 108);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.Size = new Size(339, 265);
            dgvProducts.TabIndex = 20;
            dgvProducts.CellDoubleClick += dgvProducts_CellDoubleClick;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // currentPriceDataGridViewTextBoxColumn
            // 
            currentPriceDataGridViewTextBoxColumn.DataPropertyName = "CurrentPrice";
            currentPriceDataGridViewTextBoxColumn.HeaderText = "Current Price";
            currentPriceDataGridViewTextBoxColumn.Name = "currentPriceDataGridViewTextBoxColumn";
            currentPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            quantityDataGridViewTextBoxColumn.HeaderText = "Stock";
            quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            quantityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productBindingSource
            // 
            productBindingSource.DataSource = typeof(Models.Product);
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AllowUserToDeleteRows = false;
            dgvCart.AutoGenerateColumns = false;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Columns.AddRange(new DataGridViewColumn[] { nameDataGridViewTextBoxColumn1, CurrentPrice, quantityDataGridViewTextBoxColumn1 });
            dgvCart.DataSource = productBindingSource;
            dgvCart.Location = new Point(357, 13);
            dgvCart.Name = "dgvCart";
            dgvCart.ReadOnly = true;
            dgvCart.Size = new Size(277, 280);
            dgvCart.TabIndex = 21;
            dgvCart.CellDoubleClick += dgvCart_CellDoubleClick;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            nameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // CurrentPrice
            // 
            CurrentPrice.DataPropertyName = "CurrentPrice";
            CurrentPrice.HeaderText = "Current Price";
            CurrentPrice.Name = "CurrentPrice";
            CurrentPrice.ReadOnly = true;
            // 
            // quantityDataGridViewTextBoxColumn1
            // 
            quantityDataGridViewTextBoxColumn1.DataPropertyName = "Quantity";
            quantityDataGridViewTextBoxColumn1.HeaderText = "Quantity";
            quantityDataGridViewTextBoxColumn1.Name = "quantityDataGridViewTextBoxColumn1";
            quantityDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReset.Location = new Point(523, 321);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(80, 52);
            btnReset.TabIndex = 22;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // SalesScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnReset);
            Controls.Add(dgvCart);
            Controls.Add(dgvProducts);
            Controls.Add(btnConfirm);
            Controls.Add(btnQRCodeConnect);
            Controls.Add(lblStatus);
            Controls.Add(lblStaticStatus);
            Name = "SalesScreen";
            Size = new Size(650, 400);
            Enter += SalesScreen_Enter;
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnDelete;
        private Label lblEmailReset;
        private TextBox txtEmailReset;
        private Button btnQRCodeReset;
        private Button btnConfirm;
        private Button btnQRCodeConnect;
        private Label lblStatus;
        private Label lblStaticStatus;
        private DataGridView dgvProducts;
        private BindingSource productBindingSource;
        private DataGridView dgvCart;
        private Button btnReset;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn currentPriceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn CurrentPrice;
        private DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn1;
    }
}
