namespace DynamicBakery.Screens.DashboardUserControls
{
    partial class ProductsScreen
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
            dgvProducts = new DataGridView();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            CurrentPrice = new DataGridViewTextBoxColumn();
            BasePrice = new DataGridViewTextBoxColumn();
            quantityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            productTypeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            productBindingSource = new BindingSource(components);
            btnDelete = new Button();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { nameDataGridViewTextBoxColumn, CurrentPrice, BasePrice, quantityDataGridViewTextBoxColumn, productTypeDataGridViewTextBoxColumn });
            dgvProducts.DataSource = productBindingSource;
            dgvProducts.Location = new Point(13, 124);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.Size = new Size(625, 258);
            dgvProducts.TabIndex = 0;
            dgvProducts.ColumnHeaderMouseClick += dgvProducts_ColumnHeaderMouseClick;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // CurrentPrice
            // 
            CurrentPrice.DataPropertyName = "CurrentPrice";
            CurrentPrice.HeaderText = "CurrentPrice";
            CurrentPrice.Name = "CurrentPrice";
            // 
            // BasePrice
            // 
            BasePrice.DataPropertyName = "BasePrice";
            BasePrice.HeaderText = "BasePrice";
            BasePrice.Name = "BasePrice";
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            // 
            // productTypeDataGridViewTextBoxColumn
            // 
            productTypeDataGridViewTextBoxColumn.DataPropertyName = "ProductType";
            productTypeDataGridViewTextBoxColumn.HeaderText = "Product Type";
            productTypeDataGridViewTextBoxColumn.Name = "productTypeDataGridViewTextBoxColumn";
            // 
            // productBindingSource
            // 
            productBindingSource.DataSource = typeof(Models.Product);
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(504, 72);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(134, 37);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(504, 17);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(134, 37);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // ProductsScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(dgvProducts);
            Name = "ProductsScreen";
            Size = new Size(650, 400);
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label TEST;
        private DataGridView dgvProducts;
        private BindingSource productBindingSource;
        private Button btnDelete;
        private Button btnSave;
        private DataGridViewTextBoxColumn basePriceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn CurrentPrice;
        private DataGridViewTextBoxColumn BasePrice;
        private DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn productTypeDataGridViewTextBoxColumn;
    }
}
