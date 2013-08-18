using System;
using MonoTouch.Foundation;

namespace ZebraSDK
{
	public partial class ZebraPrinterConnection {

		public int MaxTimeoutForRead { get {return GetMaxTimeoutForRead ();} }

		public int TimeToWaitForMoreData { get {return GetTimeToWaitForMoreData ();} }

		public bool IsConnected { get {return GetIsConnected ();} }

		public bool HasBytesAvailable { get {return GetHasBytesAvailable ();} }

		public override string ToString ()
		{
			return ToStringInternal ();
		}

		public int Write (NSData data) // TODO Should I do more of this?  Is there a way to automate it?
		{
			NSError error;
			var ret = TryWrite (data, out error);
			if (error != null)
				throw new NSErrorException (error);
			return ret;
		}
	}
}

