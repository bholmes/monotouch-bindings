using System;

namespace ZebraSDK
{
	public partial class MfiBtPrinterConnection {

		public int TimeToWaitAfterWriteInMilliseconds { set {SetTimeToWaitAfterWriteInMilliseconds (value);} }

		public int TimeToWaitAfterReadInMilliseconds { set {SetTimeToWaitAfterReadInMilliseconds (value);} }
	}
}

