using System;

namespace ZebraSDK
{
	public partial class PrinterStatus {

		public bool IsReadyToPrint { get {return GetIsReadyToPrint ();} set { SetIsReadyToPrint (value);} }

		public bool IsHeadOpen { get {return GetIsHeadOpen ();} set { SetIsHeadOpen (value);} }

		public bool IsHeadCold { get {return GetIsHeadCold ();} set { SetIsHeadCold (value);} }

		public bool IsHeadTooHot { get {return GetIsHeadTooHot ();} set { SetIsHeadTooHot (value);} }

		public bool IsPaperOut { get {return GetIsPaperOut ();} set { SetIsPaperOut (value);} }

		public bool IsRibbonOut { get {return GetIsRibbonOut ();} set { SetIsRibbonOut (value);} }

		public bool IsReceiveBufferFull { get {return GetIsReceiveBufferFull ();} set { SetIsReceiveBufferFull (value);} }

		public bool IsPaused { get {return GetIsPaused ();} set { SetIsPaused (value);} }

		public int LabelLengthInDots { get {return GetLabelLengthInDots ();} set { SetLabelLengthInDots (value);} }

		public int NumberOfFormatsInReceiveBuffer { get {return GetNumberOfFormatsInReceiveBuffer ();} set { SetNumberOfFormatsInReceiveBuffer (value);} }

		public int LabelsRemainingInBatch { get {return GetLabelsRemainingInBatch ();} set { SetLabelsRemainingInBatch (value);} }

		public bool IsPartialFormatInProgress { get {return GetIsPartialFormatInProgress ();} set { SetIsPartialFormatInProgress (value);} }

		public ZplPrintMode PrintMode { get {return GetPrintMode ();} set { SetPrintMode (value);} }
	}
}

