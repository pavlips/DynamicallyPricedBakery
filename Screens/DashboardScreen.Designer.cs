namespace DynamicBakery.Screens
{
    partial class DashboardScreen
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
            pnlDashNav = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnPromotion = new Button();
            btnCustomers = new Button();
            btnProducts = new Button();
            btnSale = new Button();
            pnlDashContent = new Panel();
            pnlDashNav.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlDashNav
            // 
            pnlDashNav.BackColor = SystemColors.ControlLight;
            pnlDashNav.Controls.Add(tableLayoutPanel1);
            pnlDashNav.Dock = DockStyle.Left;
            pnlDashNav.Location = new Point(0, 0);
            pnlDashNav.Name = "pnlDashNav";
            pnlDashNav.Size = new Size(153, 450);
            pnlDashNav.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(btnPromotion, 0, 3);
            tableLayoutPanel1.Controls.Add(btnCustomers, 0, 2);
            tableLayoutPanel1.Controls.Add(btnProducts, 0, 1);
            tableLayoutPanel1.Controls.Add(btnSale, 0, 0);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(132, 278);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnPromotion
            // 
            btnPromotion.BackColor = SystemColors.ControlLightLight;
            btnPromotion.FlatAppearance.BorderColor = Color.Black;
            btnPromotion.Font = new Font("Calibri", 14.25F);
            btnPromotion.Location = new Point(3, 210);
            btnPromotion.Name = "btnPromotion";
            btnPromotion.Size = new Size(126, 63);
            btnPromotion.TabIndex = 3;
            btnPromotion.Text = "Manage Promotions ";
            btnPromotion.UseVisualStyleBackColor = false;
            btnPromotion.Click += btnLoyalty_Click;
            // 
            // btnCustomers
            // 
            btnCustomers.BackColor = SystemColors.ControlLightLight;
            btnCustomers.FlatAppearance.BorderColor = Color.Black;
            btnCustomers.Font = new Font("Calibri", 14.25F);
            btnCustomers.Location = new Point(3, 141);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Size = new Size(126, 63);
            btnCustomers.TabIndex = 2;
            btnCustomers.Text = "Manage Customers";
            btnCustomers.UseVisualStyleBackColor = false;
            btnCustomers.Click += btnCustomers_Click;
            // 
            // btnProducts
            // 
            btnProducts.BackColor = SystemColors.ControlLightLight;
            btnProducts.FlatAppearance.BorderColor = Color.Black;
            btnProducts.Font = new Font("Calibri", 14.25F);
            btnProducts.Location = new Point(3, 72);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(126, 63);
            btnProducts.TabIndex = 1;
            btnProducts.Text = "Manage Products";
            btnProducts.UseVisualStyleBackColor = false;
            btnProducts.Click += btnProducts_Click;
            // 
            // btnSale
            // 
            btnSale.BackColor = SystemColors.ControlLightLight;
            btnSale.FlatAppearance.BorderColor = Color.Black;
            btnSale.Font = new Font("Calibri", 14.25F);
            btnSale.Location = new Point(3, 3);
            btnSale.Name = "btnSale";
            btnSale.Size = new Size(126, 63);
            btnSale.TabIndex = 0;
            btnSale.Text = "Register Sale";
            btnSale.UseVisualStyleBackColor = false;
            btnSale.Click += btnSale_Click;
            // 
            // pnlDashContent
            // 
            pnlDashContent.Dock = DockStyle.Fill;
            pnlDashContent.Location = new Point(153, 0);
            pnlDashContent.Name = "pnlDashContent";
            pnlDashContent.Size = new Size(647, 450);
            pnlDashContent.TabIndex = 1;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlDashContent);
            Controls.Add(pnlDashNav);
            Name = "Dashboard";
            Text = "Dashboard";
            pnlDashNav.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlDashNav;
        private Panel pnlDashContent;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnPromotion;
        private Button btnCustomers;
        private Button btnProducts;
        private Button btnSale;
    }
}