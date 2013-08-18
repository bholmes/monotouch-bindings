using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Threading.Tasks;
using ZebraSDK;

namespace ZebraSDKDemos
{
	public partial class ConnectivityDemoController : UIViewController
	{
		ConnectionSetupController connectionSetupController;
		bool performingDemo = false;

		public ConnectivityDemoController () : base ("ConnectivityDemoController", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			connectionSetupController = new ConnectionSetupController ();
			performingDemo = false;
			View.AddSubview (connectionSetupController.View);
		}

		public override void ViewWillDisappear (bool animated)
		{
			if (performingDemo)
				System.Threading.Thread.Sleep (5000);

			base.ViewWillDisappear (animated);
		}

		void PrintTestLabel(PrinterLanguage language, ZebraPrinterConnection connection)
		{
			string testLabel;
			if (language == PrinterLanguage.ZPL) {
				testLabel = @"^XA^FO17,16^GB379,371,8^FS^FT65,255^A0N,135,134^FDTEST^FS^XZ";
			} else if (language == PrinterLanguage.CPCL) {
				testLabel = @"! 0 200 200 406 1\r\nON-FEED IGNORE\r\nBOX 20 20 380 380 8\r\nT 0 6 137 177 TEST\r\nPRINT\r\n";
			} else
				throw new NotImplementedException ();

			var data = NSData.FromString (testLabel);
			connection.Write (data);
		}

		async partial void TouchButtonPressed (NSObject sender)
		{
			performingDemo = true;
			testButton.Enabled = false;
			int sleepTime = 1000;

			IProgress<Pair<string, UIColor>> progress = new Progress <Pair<string, UIColor>> ((pair) => {
				connectionSetupController.ChangeStatusLabel ( pair.First, pair.Second);
			});

			var bluetoothPrinterLabelText = connectionSetupController.BluetoothPrinterLabel.Text;
			var IpDnsTextFieldText = connectionSetupController.IpDnsTextField.Text;
			var portTextFieldText = connectionSetupController.PortTextField.Text;

			await System.Threading.Tasks.Task.Factory.StartNew ( () => {
				progress.Report (new Pair<string, UIColor> ("Connecting...", UIColor.Yellow));

				ZebraPrinterConnection connection;
				if (connectionSetupController.IsBluetoothSelected) {
					connection = new MfiBtPrinterConnection (bluetoothPrinterLabelText);
				} else {
					var ipAddress = IpDnsTextFieldText;

					int port;
					if (!int.TryParse (portTextFieldText, out port))
						port = 0;

					connection	= new TcpPrinterConnection (ipAddress, port);
				}

				var didOpen = connection.Open ();

				if (didOpen) {
					progress.Report (new Pair<string, UIColor> ("Connected...", UIColor.Green));
					System.Threading.Thread.Sleep (sleepTime);
					progress.Report (new Pair<string, UIColor> ("Determining Printer Language...", UIColor.Yellow));

					NSError err;
					var printer = ZebraPrinterFactory.GetInstance (connection, out err);
					if (printer != null) {
						var language = printer.PrinterControlLanguage;
						progress.Report (new Pair<string, UIColor> (string.Format ("Printer Language {0}", language), UIColor.Cyan));
						System.Threading.Thread.Sleep (sleepTime);

						progress.Report (new Pair<string, UIColor> ("Sending Data", UIColor.Cyan));

						try {
							PrintTestLabel (language, connection);
							progress.Report (new Pair<string, UIColor>("Test Label Sent", UIColor.Red));
						}catch (NSErrorException) {
							progress.Report (new Pair<string, UIColor>("Test Label Failed to Print", UIColor.Red));
						}

					} else {
						progress.Report (new Pair<string, UIColor> ("Could not Detect Language", UIColor.Red));
					}

				} else {
					progress.Report (new Pair<string, UIColor> ("Could not connect to printer", UIColor.Red));
				}

				System.Threading.Thread.Sleep (sleepTime);
			});

			performingDemo = false;
			connectionSetupController.ChangeStatusLabel ("Not Connected", UIColor.Red);
			testButton.Enabled = true;
		}
	}
}

