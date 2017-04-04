using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using ImageCircle.Forms.Plugin.iOS;
using UIKit;
using Xamarin.Forms.Maps;
using com.ithiredguns.orlandocodecamp;

namespace com.ithiredguns.orlandocodecamp.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
			ImageCircleRenderer.Init();
			Xamarin.FormsMaps.Init();
			Appearance.Configure();
			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}
