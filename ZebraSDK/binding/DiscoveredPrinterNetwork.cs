using System;

namespace ZebraSDK
{
	public partial class DiscoveredPrinterNetwork
	{
		public int Port { get {return GetPort ();} }

		public string DnsName { get{return GetDnsName ();} set {SetDnsName (value);} }

		public override string ToString ()
		{
			return ToStringInternal ();
		}
	}
}

