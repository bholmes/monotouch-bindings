using System;

namespace ZebraSDK
{
	public partial class TcpPrinterConnection {

		public int DEFAULT_MAX_TIMEOUT_FOR_READ { get {return GetDEFAULT_MAX_TIMEOUT_FOR_READ (); } }

		public int DEFAULT_TIME_TO_WAIT_FOR_MORE_DATA { get {return GetDEFAULT_TIME_TO_WAIT_FOR_MORE_DATA ();} }

		public int MaxTimeoutForOpen { set {SetMaxTimeoutForOpen (value); } }
	}
}

