using System;
using MonoTouch.Foundation;

namespace ZebraSDK
{
	public partial class FieldDescriptionData
	{
		public NSNumber FieldNumber { get{return GetFieldNumber ();} }

		public string FieldName { get{return GetFieldName ();} }
	}
}

