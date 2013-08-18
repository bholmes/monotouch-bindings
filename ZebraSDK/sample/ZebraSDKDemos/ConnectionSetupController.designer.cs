// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace ZebraSDKDemos
{
	[Register ("ConnectionSetupController")]
	partial class ConnectionSetupController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton bluetoothButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel bluetoothPrinterLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView bluetoothView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField ipDnsTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIControl networkView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField portTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISegmentedControl segmentedControl { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel statusLabel { get; set; }

		[Action ("BackgroundTap:")]
		partial void BackgroundTap (MonoTouch.Foundation.NSObject sender);

		[Action ("ChooseBluetoothButtonPressed:")]
		partial void ChooseBluetoothButtonPressed (MonoTouch.Foundation.NSObject sender);

		[Action ("SegmentedControlChanged:")]
		partial void SegmentedControlChanged (MonoTouch.Foundation.NSObject sender);

		[Action ("TextFieldDoneEditing:")]
		partial void TextFieldDoneEditing (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (statusLabel != null) {
				statusLabel.Dispose ();
				statusLabel = null;
			}

			if (ipDnsTextField != null) {
				ipDnsTextField.Dispose ();
				ipDnsTextField = null;
			}

			if (portTextField != null) {
				portTextField.Dispose ();
				portTextField = null;
			}

			if (segmentedControl != null) {
				segmentedControl.Dispose ();
				segmentedControl = null;
			}

			if (networkView != null) {
				networkView.Dispose ();
				networkView = null;
			}

			if (bluetoothView != null) {
				bluetoothView.Dispose ();
				bluetoothView = null;
			}

			if (bluetoothButton != null) {
				bluetoothButton.Dispose ();
				bluetoothButton = null;
			}

			if (bluetoothPrinterLabel != null) {
				bluetoothPrinterLabel.Dispose ();
				bluetoothPrinterLabel = null;
			}
		}
	}
}
