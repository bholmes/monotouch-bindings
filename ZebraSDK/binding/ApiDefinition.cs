using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;

namespace ZebraSDK
{
	[BaseType (typeof (NSObject))]
	public partial interface DiscoveredPrinter {

		[Bind ("address"), Internal]
		string GetAddress ();

		[Bind ("initWithAddress:")]
		IntPtr Constructor (string anAddress);

		[Bind ("toString"), Internal]
		string ToStringInternal();
	}

	[BaseType (typeof (DiscoveredPrinter))]
	public partial interface DiscoveredPrinterNetwork {

		[Bind ("port"), Internal]
		int GetPort ();

		[Bind ("dnsName"), Internal]
		string GetDnsName ();

		[Bind ("setDnsName:"), Internal]
		void SetDnsName (string value);

		[Bind ("initWithAddress:andWithPort:")]
		IntPtr Constructor (string anAddress, int aPort);

		[Bind ("toString"), Internal]
		string ToStringInteranl ();
	}

	[BaseType (typeof (NSObject))]
	public partial interface FieldDescriptionData {

		[Bind ("initWithFieldNumber:andWithFieldName:")]
		IntPtr Constructor (NSNumber aFieldNumber, string aFieldName);

		[Bind ("fieldNumber"), Internal]
		NSNumber GetFieldNumber ();

		[Bind ("fieldName"), Internal]
		string GetFieldName ();
	}

	//	[Model]
	[BaseType (typeof (NSObject))]
	public partial interface FileUtil {

		[Bind ("sendFileContents:error:")]
		bool SendFileContents (string filePath, out NSError error);

		[Bind ("retrieveFileNames:")]
		string [] RetrieveFileNames (out NSError error);

		[Bind ("retrieveFileNamesWithExtensions:error:")]
		string [] RetrieveFileNames (string [] extensions, out NSError error);
	}

	//	[Model]
	[BaseType (typeof (NSObject))]
	public partial interface FormatUtil {

		[Bind ("retrieveFormatFromPrinterWithPath:error:")]
		NSData RetrieveFormatFromPrinter (string formatPathOnPrinter, out NSError error);

		// TODO is FieldDescriptionData correct
		[Bind ("getVariableFieldsWithFormatContents:error:")]
		FieldDescriptionData [] GetVariableFields (string formatContents, out NSError error);

		[Bind ("printStoredFormat:withFormatData:error:")]
		bool PrintStoredFormat (string formatPathOnPrinter, string [] vars, out NSError error);

		[Bind ("printStoredFormat:withFormatData:andWithEncoding:error:")]
		bool PrintStoredFormat (string formatPathOnPrinter, string [] vars, NSStringEncoding encoding, out NSError error);

		[Bind ("printStoredFormat:withDictionary:error:")]
		bool PrintStoredFormat (string formatPathOnPrinter, NSMutableDictionary vars, out NSError error);

		[Bind ("printStoredFormat:withDictionary:andWithEncoding:error:")]
		bool PrintStoredFormat (string formatPathOnPrinter, NSMutableDictionary vars, NSStringEncoding encoding, out NSError error);
	}

	//	[Model]
	[BaseType (typeof (NSObject))]
	public partial interface GraphicsUtil {

		[Bind ("printImageFromFile:atX:atY:error:")]
		bool PrintImageFromFile (string path, int x, int y, out NSError error);

		[Bind ("printImageFromFile:atX:atY:withWidth:withHeight:andIsInsideFormat:error:")]
		bool PrintImageFromFile (string path, int x, int y, int width, int height, bool isInsideFormat, out NSError error);

		[Bind ("printImage:atX:atY:withWidth:withHeight:andIsInsideFormat:error:")]
		bool PrintImage (CGImage image, int x, int y, int width, int height, bool isInsideFormat, out NSError error);

		[Bind ("storeImage:withImage:withWidth:andWithHeight:error:")]
		bool StoreImage (string printerDriveAndFileName, CGImage image, int width, int height, out NSError error);

		[Bind ("storeImage:withPathOnDevice:withWidth:andWithHeight:error:")]
		bool StoreImage (string printerDriveAndFileName, string imageFilePathOnDevice, int width, int height, out NSError error);
	}

	//	[Model]
	[BaseType (typeof (NSObject))]
	public partial interface MagCardReader {

		// An array of three strings corresponding to the tracks of the card. If a track could not be read that
		// * string will be empty.

		// TODO verify
		[Bind ("read:error:")]
		string [] Read (int timeoutMS, out NSError error);
	}

	//	[Model]
	[BaseType (typeof (NSObject))]
	public partial interface ZebraPrinterConnection {

		[Bind ("toString"), Internal]
		string ToStringInternal ();

		[Bind ("getMaxTimeoutForRead"), Internal]
		int GetMaxTimeoutForRead ();

		[Bind ("getTimeToWaitForMoreData"), Internal]
		int GetTimeToWaitForMoreData ();

		[Bind ("isConnected"), Internal]
		bool GetIsConnected ();

		[Bind ("open")]
		bool Open ();

		[Bind ("close")]
		void Close ();

		[Bind ("write:error:")]
		int TryWrite (NSData data, out NSError error);

		[Bind ("read:")]
		NSData Read (out NSError error);

		[Bind ("hasBytesAvailable"), Internal]
		bool GetHasBytesAvailable ();

		[Bind ("waitForData:")]
		void WaitForData (int maxTimeout);
	}

	[BaseType (typeof (ZebraPrinterConnection))]
	public partial interface MfiBtPrinterConnection {

		[Bind ("initWithSerialNumber:")]
		IntPtr Constructor ([NullAllowed] string aSerialNumber);

		[Bind ("initWithSerialNumber:withMaxTimeoutForRead:andWithTimeToWaitForMoreData:")]
		IntPtr Constructor ([NullAllowed] string aSerialNumber, int aMaxTimeoutForRead, int aTimeToWaitForMoreData);

		[Bind ("timeToWaitAfterWriteInMilliseconds:"), Internal]
		void SetTimeToWaitAfterWriteInMilliseconds (int value);

		[Bind ("timeToWaitAfterReadInMilliseconds:"), Internal]
		void SetTimeToWaitAfterReadInMilliseconds (int value);
	}

	[BaseType (typeof (NSObject))]
	public partial interface NetworkDiscoverer {

		[Static, Bind ("multicastWithHops:error:")]
		DiscoveredPrinter [] Multicast (int hops, out NSError error);

		[Static, Bind ("multicastWithHops:andWaitForResponsesTimeout:error:")]
		DiscoveredPrinter [] Multicast (int hops, int waitForResponsesTimeout, out NSError error);

		[Static, Bind ("subnetSearchWithRange:error:")]
		DiscoveredPrinter [] SubnetSearch (string subnetRange, out NSError error);

		[Static, Bind ("subnetSearchWithRange:andWaitForResponsesTimeout:error:")]
		DiscoveredPrinter [] SubnetSearch (string subnetRange, int waitForResponsesTimeout, out NSError error);

		[Static, Bind ("directedBroadcastWithIpAddress:error:")]
		DiscoveredPrinter [] DirectedBroadcast (string ipAddress, out NSError error);

		[Static, Bind ("directedBroadcastWithIpAddress:andWaitForResponsesTimeout:error:")]
		DiscoveredPrinter [] DirectedBroadcast (string ipAddress, int waitForResponsesTimeout, out NSError error);

		[Static, Bind ("localBroadcast:")]
		DiscoveredPrinter [] LocalBroadcast (out NSError error);

		[Static, Bind ("localBroadcastWithTimeout:error:")]
		DiscoveredPrinter [] LocalBroadcast (int waitForResponsesTimeout, out NSError error);
	}



	[BaseType (typeof (NSObject))]
	public partial interface PrinterStatus {

		[Bind ("isReadyToPrint"), Internal]
		bool GetIsReadyToPrint ();

		[Bind ("setIsReadyToPrint:"), Internal]
		void SetIsReadyToPrint (bool value);

		[Bind ("isHeadOpen"), Internal]
		bool GetIsHeadOpen ();

		[Bind ("setIsHeadOpen:"), Internal]
		void SetIsHeadOpen (bool value);

		[Bind ("isHeadCold"), Internal]
		bool GetIsHeadCold ();

		[Bind ("setIsHeadCold:"), Internal]
		void SetIsHeadCold (bool value);

		[Bind ("isHeadTooHot"), Internal]
		bool GetIsHeadTooHot ();

		[Bind ("setIsHeadTooHot:"), Internal]
		void SetIsHeadTooHot (bool value);

		[Bind ("isPaperOut"), Internal]
		bool GetIsPaperOut ();

		[Bind ("setIsPaperOut:"), Internal]
		void SetIsPaperOut (bool value);

		[Bind ("isRibbonOut"), Internal]
		bool GetIsRibbonOut ();

		[Bind ("setIsRibbonOut:"), Internal]
		void SetIsRibbonOut (bool value);

		[Bind ("isReceiveBufferFull"), Internal]
		bool GetIsReceiveBufferFull ();

		[Bind ("setIsReceiveBufferFull:"), Internal]
		void SetIsReceiveBufferFull (bool value);

		[Bind ("isPaused"), Internal]
		bool GetIsPaused ();

		[Bind ("setIsPaused:"), Internal]
		void SetIsPaused (bool value);

		[Bind ("labelLengthInDots"), Internal]
		int GetLabelLengthInDots ();

		[Bind ("setLabelLengthInDots:"), Internal]
		void SetLabelLengthInDots (int value);

		[Bind ("numberOfFormatsInReceiveBuffer"), Internal]
		int GetNumberOfFormatsInReceiveBuffer();

		[Bind ("setNumberOfFormatsInReceiveBuffer:"), Internal]
		void SetNumberOfFormatsInReceiveBuffer (int value);

		[Bind ("labelsRemainingInBatch"), Internal]
		int GetLabelsRemainingInBatch ();

		[Bind ("setLabelsRemainingInBatch:"), Internal]
		void SetLabelsRemainingInBatch (int value);

		[Bind ("isPartialFormatInProgress"), Internal]
		bool GetIsPartialFormatInProgress ();

		[Bind ("setPsPartialFormatInProgress:"), Internal]
		void SetIsPartialFormatInProgress (bool value);

		[Bind ("printMode"), Internal]
		ZplPrintMode GetPrintMode ();

		[Bind ("setPrintMode:"), Internal]
		void SetPrintMode (ZplPrintMode value);
	}

	[BaseType (typeof (NSObject))]
	public partial interface PrinterStatusMessages {

		[Static, Bind ("HEAD_OPEN_MSG"), Internal]
		string GetHEAD_OPEN_MSG ();

		[Static, Bind ("HEAD_TOO_HOT_MSG"), Internal]
		string GetHEAD_TOO_HOT_MSG ();

		[Static, Bind ("PAPER_OUT_MSG"), Internal]
		string GetPAPER_OUT_MSG ();

		[Static, Bind ("RIBBON_OUT_MSG"), Internal]
		string GetRIBBON_OUT_MSG ();

		[Static, Bind ("RECEIVE_BUFFER_FULL_MSG"), Internal]
		string GetRECEIVE_BUFFER_FULL_MSG ();

		[Static, Bind ("PAUSE_MSG"), Internal]
		string GetPAUSE_MSG ();

		[Bind ("initWithPrinterStatus:"), Internal]
		IntPtr Constructor (PrinterStatus aPrinterStatus);

		[Bind ("getStatusMessage"), Internal]
		string [] GetStatusMessage ();
	}

	[BaseType (typeof (NSObject))]
	public partial interface SGD {

		[Static, Bind ("SET:withValue:andWithPrinterConnection:error:")]
		bool SET (string setting, string value, ZebraPrinterConnection printerConnection, out NSError error);

		[Static, Bind ("SET:withValueAsInt:andWithPrinterConnection:error:")]
		bool SET (string setting, int value, ZebraPrinterConnection printerConnection, out NSError error);

		[Static, Bind ("GET:withPrinterConnection:error:")]
		string GET (string setting, ZebraPrinterConnection printerConnection, out NSError error);

		[Static, Bind ("GET:withPrinterConnection:withMaxTimeoutForRead:andWithTimeToWaitForMoreData:error:")]
		string GET (string setting, ZebraPrinterConnection printerConnection, int maxTimeoutForRead, int timeToWaitForMoreData, out NSError error);

		[Static, Bind ("DO:withValue:andWithPrinterConnection:error:")]
		string DO (string setting, string value, ZebraPrinterConnection printerConnection, out NSError error);

		[Static, Bind ("DO:withValue:withPrinterConnection:withMaxTimeoutForRead:andWithTimeToWaitForMoreData:error:")]
		string DO (string setting, string value, ZebraPrinterConnection printerConnection, int maxTimeoutForRead, int timeToWaitForMoreData, out NSError error);
	}

	//	[Model]
	[BaseType (typeof (NSObject))]
	public partial interface SmartCardReader {

		[Bind ("getATR:")]
		NSData GetATR (out NSError error);

		[Bind ("doCommand:error:")]
		NSData DoCommand (string asciiHexData, out NSError error);

		[Bind ("close:")]
		bool Close (out NSError error);
	}

	[BaseType (typeof (ZebraPrinterConnection))]
	public partial interface TcpPrinterConnection {

		[Bind ("initWithAddress:andWithPort:")]
		IntPtr Constructor ([NullAllowed]string anAddress, int aPort);

		[Bind ("initWithAddress:withPort:withMaxTimeoutForRead:andWithTimeToWaitForMoreData:")]
		IntPtr Constructor ([NullAllowed]string anAddress, int aPort, int aMaxTimeoutForRead, int aTimeToWaitForMoreData);

		[Static, Bind ("DEFAULT_MAX_TIMEOUT_FOR_READ"), Internal]
		int GetDEFAULT_MAX_TIMEOUT_FOR_READ ();

		[Static, Bind ("DEFAULT_TIME_TO_WAIT_FOR_MORE_DATA"), Internal]
		int GetDEFAULT_TIME_TO_WAIT_FOR_MORE_DATA ();

		[Bind ("setMaxTimeoutForOpen:"), Internal]
		void SetMaxTimeoutForOpen (int value);
	}

	//	[Model]
	[BaseType (typeof (NSObject))]
	public partial interface ToolsUtil {

		[Bind ("calibrate:")]
		bool Calibrate (out NSError error);

		[Bind ("restoreDefaults:")]
		bool RestoreDefaults (out NSError error);

		[Bind ("printConfigurationLabel:")]
		bool PrintConfigurationLabel (out NSError error);

		[Bind ("sendCommand:error:")]
		bool SendCommand (string command, out NSError error);

		[Bind ("reset:")]
		bool Reset (out NSError error);
	}

	//	[Model]
	[BaseType (typeof (NSObject))]
	public partial interface ZebraPrinter {

		[Bind ("getPrinterControlLanguage"), Internal]
		PrinterLanguage GetPrinterControlLanguage ();

		[Bind ("getFormatUtil"), Internal]
		FormatUtil GetFormatUtil ();

		[Bind ("getFileUtil"), Internal]
		FileUtil GetFileUtil ();

		[Bind ("getGraphicsUtil"), Internal]
		GraphicsUtil GetGraphicsUtil ();

		[Bind ("getCurrentStatus:")]
		PrinterStatus GetCurrentStatus (out NSError error);

		[Bind ("getMagCardReader"), Internal]
		MagCardReader GetMagCardReader ();

		[Bind ("getSmartCardReader"), Internal]
		SmartCardReader GetSmartCardReader ();

		[Bind ("getToolsUtil"), Internal]
		ToolsUtil GetToolsUtil ();
	}

	[BaseType (typeof (NSObject))]
	public partial interface ZebraPrinterFactory {

		[Static, Bind ("getInstance:error:")]
		ZebraPrinter GetInstance (ZebraPrinterConnection connection, out NSError error);

		//TODO cpclPrefixes may be wrong
		[Static, Bind ("getInstance:withCpclPrefixes:error:")]
		ZebraPrinter GetInstance (ZebraPrinterConnection connection, string [] cpclPrefixes, out NSError error);

		[Static, Bind ("getInstance:withPrinterLanguage:")]
		ZebraPrinter GetInstance (ZebraPrinterConnection connection, PrinterLanguage language);
	}

	[BaseType (typeof (ZebraPrinterConnection))]
	public partial interface LineaBtPrinterConnection {

		[Bind ("initWithMacAddress:andWithPin:")]
		IntPtr Constructor (string aMacAddress, string pinCode);

		[Bind ("initWithMacAddress:withPin:withMaxTimeoutForRead:andWithTimeToWaitForMoreData:")]
		IntPtr Constructor (string aMacAddress, string pinCode, int aMaxTimeoutForRead, int aTimeToWaitForMoreData);

		[Bind ("setTimeToWaitAfterWriteInMilliseconds:"), Internal]
		void SetTimeToWaitAfterWriteInMilliseconds (int value);
	}
}

