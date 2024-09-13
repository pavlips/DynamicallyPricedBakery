namespace DynamicBakery.Screens
{
    partial class BarcodeReaderScreen
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
            lblCamera = new Label();
            cboCamera = new ComboBox();
            pboQRView = new PictureBox();
            btnStart = new Button();
            tmrQR = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pboQRView).BeginInit();
            SuspendLayout();
            // 
            // lblCamera
            // 
            lblCamera.AutoSize = true;
            lblCamera.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCamera.Location = new Point(42, 23);
            lblCamera.Name = "lblCamera";
            lblCamera.Size = new Size(59, 19);
            lblCamera.TabIndex = 0;
            lblCamera.Text = "Camera";
            // 
            // cboCamera
            // 
            cboCamera.FormattingEnabled = true;
            cboCamera.Location = new Point(129, 23);
            cboCamera.Name = "cboCamera";
            cboCamera.Size = new Size(121, 23);
            cboCamera.TabIndex = 1;
            // 
            // pboQRView
            // 
            pboQRView.BorderStyle = BorderStyle.Fixed3D;
            pboQRView.Location = new Point(28, 82);
            pboQRView.Name = "pboQRView";
            pboQRView.Size = new Size(397, 331);
            pboQRView.TabIndex = 2;
            pboQRView.TabStop = false;
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnStart.Location = new Point(278, 16);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(92, 33);
            btnStart.TabIndex = 4;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // tmrQR
            // 
            tmrQR.Interval = 50;
            tmrQR.Tick += tmrQR_Tick;
            // 
            // BarcodeReaderScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(459, 439);
            Controls.Add(btnStart);
            Controls.Add(pboQRView);
            Controls.Add(cboCamera);
            Controls.Add(lblCamera);
            Name = "BarcodeReaderScreen";
            Text = "BarcodeReader";
            FormClosing += BarcodeReaderScreen_FormClosing;
            Load += BarcodeReaderScreen_Load;
            ((System.ComponentModel.ISupportInitialize)pboQRView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCamera;
        private ComboBox cboCamera;
        private PictureBox pboQRView;
        private Button btnStart;
        private System.Windows.Forms.Timer tmrQR;
    }
}