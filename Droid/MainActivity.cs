﻿using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics.Drawables;
using ImageCircle.Forms.Plugin.Droid;
using Android;
using Xamarin.Forms;
using Splat;
using com.ithiredguns.orlandocodecamp;

namespace OrlandoCodeCamp.Droid
{
	[Activity(Theme = "@style/MyTheme.Splash",
		LaunchMode = LaunchMode.SingleInstance,
		MainLauncher = true, NoHistory = true,
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
		ScreenOrientation = ScreenOrientation.Portrait,
		WindowSoftInputMode = SoftInput.AdjustPan)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;
			base.SetTheme(Resource.Style.MyTheme);

			base.OnCreate(bundle);

			ImageCircleRenderer.Init();
			Xamarin.FormsMaps.Init(this, bundle);
			global::Xamarin.Forms.Forms.Init(this, bundle);

			Locator.CurrentMutable.RegisterLazySingleton(
				() => new InsightsAnalytics(() =>
						Xamarin.Insights.Initialize(
						"4210544450842ddd6a192e67c5977783c907a7c8", //production id
						this)
				),
				typeof(IAnalytics));

			LoadApplication(new App());
		}
	}
}
