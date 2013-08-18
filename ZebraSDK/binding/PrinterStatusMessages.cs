using System;

namespace ZebraSDK
{
	public partial class PrinterStatusMessages {

		public string HEAD_OPEN_MSG { get {return GetHEAD_OPEN_MSG ();} }

		public string HEAD_TOO_HOT_MSG { get {return GetHEAD_TOO_HOT_MSG (); } }

		public string PAPER_OUT_MSG { get { return GetPAPER_OUT_MSG (); } }

		public string RIBBON_OUT_MSG { get { return GetRIBBON_OUT_MSG (); } }

		public string RECEIVE_BUFFER_FULL_MSG { get { return GetRECEIVE_BUFFER_FULL_MSG (); } }

		public string PAUSE_MSG { get {return GetPAUSE_MSG ();} }

		public string [] StatusMessage { get { return GetStatusMessage ();} }
	}
}

