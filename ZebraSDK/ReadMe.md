##Zebra SDK

You will need to download the Link-OS SDK from [here](http://www.zebra.com/us/en/products-services/software/link-os/link-os-sdk.html).  Extract libZSDK_API.a and libdtdev.a and place then in the external directory.


#### Sample Code

```csharp
public void Test ()
{
	NSError err;
	string ip = "ADD YOUR DEVICE IP HERE";
	int port = 10; // Set the correct port here.

	var connection = new TcpPrinterConnection (ip, port);

	var printer = ZebraPrinterFactory.GetInstance (connection, out err);
	if (printer != null) {
		var language = printer.PrinterControlLanguage;

		string testLabel;
		if (language == PrinterLanguage.ZPL) {
			testLabel = @"^XA^FO17,16^GB379,371,8^FS^FT65,255^A0N,135,134^FDTEST^FS^XZ";
		} else if (language == PrinterLanguage.CPCL) {
			testLabel = @"! 0 200 200 406 1\r\nON-FEED IGNORE\r\nBOX 20 20 380 380 8\r\nT 0 6 137 177 TEST\r\nPRINT\r\n";
		} else
			throw new NotImplementedException ();

		var data = NSData.FromString (testLabel);

		try {
			connection.Write (data);
		}catch (NSErrorException) {
			// Handle error
		}
	}
}
```
