using System;

namespace ZebraSDK
{
	public partial class ZebraPrinter {

		public PrinterLanguage PrinterControlLanguage {get { return GetPrinterControlLanguage ();}}

		public FormatUtil FormatUtil {get { return GetFormatUtil ();}}

		public FileUtil FileUtil {get { return GetFileUtil ();}}

		public GraphicsUtil GraphicsUtil {get { return GetGraphicsUtil ();}}

		public MagCardReader MagCardReader {get { return GetMagCardReader ();}}

		public SmartCardReader SmartCardReader {get { return GetSmartCardReader ();}}

		public ToolsUtil ToolsUtil {get { return GetToolsUtil ();}}
	}
}

