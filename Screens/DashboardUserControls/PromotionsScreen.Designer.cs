namespace DynamicBakery.Screens.DashboardUserControls
{
    partial class PromotionsScreen
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
            dgvPromotions = new DataGridView();
            descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            startDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            endDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            discountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            promotionBindingSource2 = new BindingSource(components);
            promotionBindingSource = new BindingSource(components);
            btnSave = new Button();
            btnDelete = new Button();
            promotionBindingSource1 = new BindingSource(components);
            cboProductSelect = new ComboBox();
            productBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dgvPromotions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)promotionBindingSource2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)promotionBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)promotionBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvPromotions
            // 
            dgvPromotions.AllowUserToDeleteRows = false;
            dgvPromotions.AutoGenerateColumns = false;
            dgvPromotions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPromotions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPromotions.Columns.AddRange(new DataGridViewColumn[] { descriptionDataGridViewTextBoxColumn, startDateDataGridViewTextBoxColumn, endDateDataGridViewTextBoxColumn, discountDataGridViewTextBoxColumn });
            dgvPromotions.DataSource = promotionBindingSource2;
            dgvPromotions.Location = new Point(18, 158);
            dgvPromotions.Name = "dgvPromotions";
            dgvPromotions.Size = new Size(606, 221);
            dgvPromotions.TabIndex = 1;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // startDateDataGridViewTextBoxColumn
            // 
            startDateDataGridViewTextBoxColumn.DataPropertyName = "StartDate";
            startDateDataGridViewTextBoxColumn.HeaderText = "StartDate";
            startDateDataGridViewTextBoxColumn.Name = "startDateDataGridViewTextBoxColumn";
            // 
            // endDateDataGridViewTextBoxColumn
            // 
            endDateDataGridViewTextBoxColumn.DataPropertyName = "EndDate";
            endDateDataGridViewTextBoxColumn.HeaderText = "EndDate";
            endDateDataGridViewTextBoxColumn.Name = "endDateDataGridViewTextBoxColumn";
            // 
            // discountDataGridViewTextBoxColumn
            // 
            discountDataGridViewTextBoxColumn.DataPropertyName = "Discount";
            discountDataGridViewTextBoxColumn.HeaderText = "Percentage Discount";
            discountDataGridViewTextBoxColumn.Name = "discountDataGridViewTextBoxColumn";
            // 
            // promotionBindingSource2
            // 
            promotionBindingSource2.DataSource = typeof(Models.Promotion);
            // 
            // promotionBindingSource
            // 
            promotionBindingSource.DataSource = typeof(Models.Promotion);
            // 
            // btnSave
            // 
            btnSave.Location = new Point(536, 48);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(536, 95);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // promotionBindingSource1
            // 
            promotionBindingSource1.DataSource = typeof(Models.Promotion);
            // 
            // cboProductSelect
            // 
            cboProductSelect.FormattingEnabled = true;
            cboProductSelect.Location = new Point(18, 24);
            cboProductSelect.Name = "cboProductSelect";
            cboProductSelect.Size = new Size(187, 23);
            cboProductSelect.TabIndex = 14;
            cboProductSelect.SelectedIndexChanged += cboProductSelect_SelectedIndexChanged;
            // 
            // productBindingSource
            // 
            productBindingSource.DataSource = typeof(Models.Product);
            // 
            // PromotionsScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cboProductSelect);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(dgvPromotions);
            Name = "PromotionsScreen";
            Size = new Size(640, 400);
            Enter += PromotionsScreen_Enter;
            ((System.ComponentModel.ISupportInitialize)dgvPromotions).EndInit();
            ((System.ComponentModel.ISupportInitialize)promotionBindingSource2).EndInit();
            ((System.ComponentModel.ISupportInitialize)promotionBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)promotionBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPromotions;
        private Button btnSave;
        private Button btnDelete;
        private BindingSource promotionBindingSource;
        private BindingSource promotionBindingSource2;
        private BindingSource promotionBindingSource1;
        private ComboBox cboProductSelect;
        private BindingSource productBindingSource;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn startDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn endDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn discountDataGridViewTextBoxColumn;
    }
}
