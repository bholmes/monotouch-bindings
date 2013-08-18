using System;

namespace ZebraSDK
{
	public partial class DiscoveredPrinter
	{
		public string Address { get{return this.GetAddress ();} }

		public override string ToString ()
		{
			return ToStringInternal ();
		}
	}
}

