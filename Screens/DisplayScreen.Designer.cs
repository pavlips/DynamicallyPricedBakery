namespace DynamicBakery.Screens
{
    partial class DisplayScreen
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
            tmrDisplay = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // tmrDisplay
            // 
            tmrDisplay.Enabled = true;
            tmrDisplay.Interval = 4000;
            tmrDisplay.Tick += tmrDisplay_Tick;
            // 
            // DisplayScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "DisplayScreen";
            Text = "DisplayScreen";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer tmrDisplay;
    }
}