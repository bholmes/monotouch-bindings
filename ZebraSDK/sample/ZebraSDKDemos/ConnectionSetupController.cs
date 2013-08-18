using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace ZebraSDKDemos
{
	public partial class ConnectionSetupController : UIViewController
	{
		public ConnectionSetupController () : base ("ConnectionSetupView", null)
		{
			View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
			SetUserDefaults ();
			var frameRect = View.Frame;
			frameRect.Height = 134;
			View.Frame = frameRect;
		}

		public MonoTouch.UIKit.UITextField IpDnsTextField {
			get {
				return ipDnsTextField;
			}
		}

		public MonoTouch.UIKit.UITextField PortTextField {
			get {
				return portTextField;
			}
		}

		public MonoTouch.UIKit.UILabel BluetoothPrinterLabel {
			get {
				return bluetoothPrinterLabel;
			}
		}

		public bool IsBluetoothSelected { get; private set;}

		void SetUserDefaults ()
		{
			var defaults = NSUserDefaults.StandardUserDefaults;
			ipDnsTextField.Text = defaults ["ipDnsName"] as NSString;
			portTextField.Text = defaults ["portNum"] as NSString;
			bluetoothPrinterLabel.Text = defaults ["bluetooth"] as NSString;
		}

		void SaveUserDefaults (string ipDnsName, string portNumAsNsString, string aBluetoothSerialNumber)
		{
			var defaults = NSUserDefaults.StandardUserDefaults;
			defaults["ipDnsName"] = new NSString (ipDnsName == null ? string.Empty : ipDnsName);
			defaults["portNum"] = new NSString (portNumAsNsString == null ? string.Empty : portNumAsNsString);
			defaults["bluetooth"] = new NSString (aBluetoothSerialNumber == null ? string.Empty : aBluetoothSerialNumber);
		}

		public void ChangeStatusLabel (string status, UIColor color )
		{
			statusLabel.Text = status;
			statusLabel.BackgroundColor = color;
		}

		partial void TextFieldDoneEditing (NSObject sender)
		{
			(sender as UITextField).ResignFirstResponder ();
		}

		partial void BackgroundTap (NSObject sender)
		{
			ipDnsTextField.ResignFirstResponder ();
			portTextField.ResignFirstResponder ();
		}

		partial void SegmentedControlChanged (NSObject sender)
		{
			switch (segmentedControl.SelectedSegment)
			{
			case 0:
				bluetoothView.Hidden = !(networkView.Hidden = false);
				IsBluetoothSelected = false;
				break;
			case 1:
				bluetoothView.Hidden = !(networkView.Hidden = true);
				IsBluetoothSelected = true;
				break;
			default:
				break;
			}
		}

		partial void ChooseBluetoothButtonPressed (NSObject sender)
		{
			BluetoothPrintersViewController btViewController = new BluetoothPrintersViewController ();

			btViewController.BluetoothPrinterSelected += (object eventSender, EventArgs e) => {
				bluetoothPrinterLabel.Text = (e as BluetoothPrinterSelectedEventArgs).Accessory.SerialNumber;
			};

			(UIApplication.SharedApplication.Windows[0].RootViewController as UINavigationController)
				.PushViewController (btViewController, true);
		}

		public override void ViewWillDisappear (bool animated)
		{
			SaveUserDefaults (ipDnsTextField.Text, portTextField.Text, bluetoothPrinterLabel.Text);
			base.ViewWillDisappear (animated);
		}
	}
}

