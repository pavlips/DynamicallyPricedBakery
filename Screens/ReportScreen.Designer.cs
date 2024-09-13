namespace DynamicBakery.Screens
{
    partial class ReportScreen
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
            components = new System.ComponentModel.Container();
            cboCustomerTier = new ComboBox();
            cboReportType = new ComboBox();
            dtpStart = new DateTimePicker();
            dtpEnd = new DateTimePicker();
            btnGenerateReport = new Button();
            productBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)productBindingSource).BeginInit();
            SuspendLayout();
            // 
            // cboCustomerTier
            // 
            cboCustomerTier.FormattingEnabled = true;
            cboCustomerTier.Items.AddRange(new object[] { "Bronze", "Silver", "Gold" });
            cboCustomerTier.Location = new Point(37, 89);
            cboCustomerTier.Name = "cboCustomerTier";
            cboCustomerTier.Size = new Size(121, 23);
            cboCustomerTier.TabIndex = 5;
            cboCustomerTier.Visible = false;
            // 
            // cboReportType
            // 
            cboReportType.FormattingEnabled = true;
            cboReportType.Items.AddRange(new object[] { "Sales", "Customer Engagement" });
            cboReportType.Location = new Point(37, 35);
            cboReportType.Name = "cboReportType";
            cboReportType.Size = new Size(121, 23);
            cboReportType.TabIndex = 0;
            cboReportType.SelectedIndexChanged += cboReportType_SelectedIndexChanged;
            // 
            // dtpStart
            // 
            dtpStart.Location = new Point(216, 35);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(200, 23);
            dtpStart.TabIndex = 1;
            // 
            // dtpEnd
            // 
            dtpEnd.Location = new Point(216, 86);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(200, 23);
            dtpEnd.TabIndex = 2;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Location = new Point(37, 141);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(75, 23);
            btnGenerateReport.TabIndex = 3;
            btnGenerateReport.Text = "Generate";
            btnGenerateReport.UseVisualStyleBackColor = true;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // productBindingSource
            // 
            productBindingSource.DataSource = typeof(Models.Product);
            // 
            // ReportScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(511, 227);
            Controls.Add(cboCustomerTier);
            Controls.Add(btnGenerateReport);
            Controls.Add(dtpEnd);
            Controls.Add(dtpStart);
            Controls.Add(cboReportType);
            Name = "ReportScreen";
            Text = "ReportScreen";
            ((System.ComponentModel.ISupportInitialize)productBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cboReportType;
        private DateTimePicker dtpStart;
        private DateTimePicker dtpEnd;
        private Button btnGenerateReport;
        private BindingSource productBindingSource;
        private ComboBox cboCustomerTier;
    }
}