using System;
using MonoTouch.ExternalAccessory;

namespace ZebraSDKDemos
{
	public class BluetoothPrinterSelectedEventArgs : EventArgs
	{
		public EAAccessory Accessory { get; private set;}

		public BluetoothPrinterSelectedEventArgs (EAAccessory accessory)
		{
			Accessory = accessory;
		}
	}
}

