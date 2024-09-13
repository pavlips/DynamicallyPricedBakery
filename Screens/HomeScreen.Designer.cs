namespace DynamicBakery
{
    partial class HomeScreen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnDashboardDirect = new Button();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            btnProductsDisplay = new Button();
            btnQuit = new Button();
            btnReportGen = new Button();
            SuspendLayout();
            // 
            // btnDashboardDirect
            // 
            btnDashboardDirect.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDashboardDirect.Location = new Point(123, 115);
            btnDashboardDirect.Name = "btnDashboardDirect";
            btnDashboardDirect.Size = new Size(169, 53);
            btnDashboardDirect.TabIndex = 0;
            btnDashboardDirect.Text = "Dashboard";
            btnDashboardDirect.UseVisualStyleBackColor = true;
            btnDashboardDirect.Click += dashboardDirect_Click;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // btnProductsDisplay
            // 
            btnProductsDisplay.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProductsDisplay.Location = new Point(123, 207);
            btnProductsDisplay.Name = "btnProductsDisplay";
            btnProductsDisplay.Size = new Size(169, 76);
            btnProductsDisplay.TabIndex = 1;
            btnProductsDisplay.Text = "Products Display";
            btnProductsDisplay.UseVisualStyleBackColor = true;
            btnProductsDisplay.Click += btnProductsDisplay_Click;
            // 
            // btnQuit
            // 
            btnQuit.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnQuit.Location = new Point(123, 426);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(169, 60);
            btnQuit.TabIndex = 2;
            btnQuit.Text = "Quit";
            btnQuit.UseVisualStyleBackColor = true;
            // 
            // btnReportGen
            // 
            btnReportGen.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReportGen.Location = new Point(123, 328);
            btnReportGen.Name = "btnReportGen";
            btnReportGen.Size = new Size(169, 60);
            btnReportGen.TabIndex = 3;
            btnReportGen.Text = "Generate Report";
            btnReportGen.UseVisualStyleBackColor = true;
            btnReportGen.Click += btnReportGen_Click;
            // 
            // HomeScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(431, 553);
            Controls.Add(btnReportGen);
            Controls.Add(btnQuit);
            Controls.Add(btnProductsDisplay);
            Controls.Add(btnDashboardDirect);
            Name = "HomeScreen";
            Text = "Home";
            ResumeLayout(false);
        }

        #endregion

        private Button btnDashboardDirect;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Button btnProductsDisplay;
        private Button btnQuit;
        private Button btnReportGen;
    }
}
