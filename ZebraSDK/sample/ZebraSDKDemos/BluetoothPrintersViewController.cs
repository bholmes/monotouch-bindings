using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ExternalAccessory;

namespace ZebraSDKDemos
{
	public partial class BluetoothPrintersViewController : UITableViewController
	{
		EAAccessory [] bluetoothPrinters;
		public BluetoothPrintersViewController () : base ("BluetoothPrintersView", null)
		{

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			EAAccessoryManager manager = EAAccessoryManager.SharedAccessoryManager;
			bluetoothPrinters = manager.ConnectedAccessories;
		}

		public override int NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return bluetoothPrinters == null ? 0 : bluetoothPrinters.Length;
		}

		public override string TitleForHeader (UITableView tableView, int section)
		{
			return @"If you do not see your printer here, you need to make sure it is configured in your iOS settings.   Go to Settings > Bluetooth and pair with your printer.";
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			const string CellIdentifier = @"Cell";

			var cell = tableView.DequeueReusableCell (CellIdentifier);
			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Default, CellIdentifier);
			}

			var accessory = bluetoothPrinters[indexPath.Row];
			cell.TextLabel.Text = string.Format ("{0} ({1})", accessory.Name, accessory.SerialNumber);

			return cell;
		}

		public event EventHandler BluetoothPrinterSelected;

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var accessory = bluetoothPrinters[indexPath.Row];
			if (BluetoothPrinterSelected != null)
				BluetoothPrinterSelected (this, new BluetoothPrinterSelectedEventArgs (accessory));

			NavigationController.PopViewControllerAnimated (true);
		}
	}
}

