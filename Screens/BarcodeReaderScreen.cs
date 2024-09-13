using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.Windows.Compatibility;



namespace DynamicBakery.Screens
{
    // CONTAINS QR CODE SCANNING
    public partial class BarcodeReaderScreen : Form
    {
        private FilterInfoCollection captureDevices;
        private VideoCaptureDevice? finalFrame;
        private CustomerManager customerManager;
        private BarcodeReader barcodeReader = new BarcodeReader();

        public delegate void BarcodeScanSuccessEventHandler(string qrCodeId);
        public event BarcodeScanSuccessEventHandler SuccessfulQRConnectionEvent;


        public BarcodeReaderScreen(CustomerManager customerManager)
        {
            this.customerManager = customerManager;
            InitializeComponent();
        }

        private void SuccessfulScan(string qrCodeId)
        {
            SuccessfulQRConnectionEvent.Invoke(qrCodeId);
        }
        private void BarcodeReaderScreen_Load(object sender, EventArgs e)
        {
            captureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in captureDevices)
            {
                cboCamera.Items.Add(device.Name);
            }
            cboCamera.SelectedIndex = 0;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            finalFrame = new VideoCaptureDevice(captureDevices[cboCamera.SelectedIndex].MonikerString);  //video capture device is selected and created
            finalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            finalFrame.Start(); // starts video capture
            Thread.Sleep(1000); // waits for 1 second to let everything load and avoid errors
            tmrQR.Start(); //checks qr code every second
        }

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pboQRView.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void BarcodeReaderScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            // stops video capture and closes form
            if (finalFrame.IsRunning)
            {
                if (finalFrame.IsRunning)
                {
                    finalFrame.SignalToStop();
                    finalFrame.WaitForStop();
                    finalFrame = null;
                }
            }
        }

        private void tmrQR_Tick(object sender, EventArgs e)
        {
            // MAKES SURE THAT THERE IS SOMETHING BEING READ (ERROR HANDLING)
            try
            {
                Result result = barcodeReader.Decode((Bitmap)pboQRView.Image);

                if (result != null)
                {
                    string decoded = result.ToString().Trim();
                    if (decoded != "")
                    {

                        if (customerManager.DoesCustomerExistByQRCode(decoded))
                        {
                            SuccessfulScan(decoded);
                            tmrQR.Stop();
                            Close();
                        }
                    }
                }
            }
            catch
            {
                Close();
                MessageBox.Show("Error scanning QR code");
            }


        }

    }
}
