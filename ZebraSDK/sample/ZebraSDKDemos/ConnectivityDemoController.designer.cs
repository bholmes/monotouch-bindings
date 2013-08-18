// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace ZebraSDKDemos
{
	[Register ("ConnectivityDemoController")]
	partial class ConnectivityDemoController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton testButton { get; set; }

		[Action ("TouchButtonPressed:")]
		partial void TouchButtonPressed (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (testButton != null) {
				testButton.Dispose ();
				testButton = null;
			}
		}
	}
}
