using System;
using System.Runtime.CompilerServices;
using Android.App;
using Android.Content;
using com.ithiredguns.orlandocodecamp.Droid;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Telephony;
using System.Linq;


[assembly: Dependency("PhoneCall_Droid", LoadHint.Always)]

namespace com.ithiredguns.orlandocodecamp.Droid
{
	public class PhoneCall_Droid : IPhoneCall
	{

		public void MakePhoneCall(string phoneNumber)
		{
			try
			{
				var uri = Android.Net.Uri.Parse(string.Format("tel:{0}", phoneNumber));

				var intent = new Intent(Intent.ActionCall, uri);

				var context = Xamarin.Forms.Forms.Context;
				if (IsIntentAvailable(context, intent))
				{

					Xamarin.Forms.Forms.Context.StartActivity(intent);
				}

			}
			catch (Exception ex)
			{
				new AlertDialog.Builder(Android.App.Application.Context).SetPositiveButton("OK", (sender, args) =>
				 {
					 //User pressed OK
				 })
							   .SetMessage(ex.ToString())
							   .SetTitle("Android Exception")
							   .Show();
			}
		}

		public static bool IsIntentAvailable(Context context, Intent intent)
		{

			var packageManager = context.PackageManager;

			var list = packageManager.QueryIntentServices(intent, 0)
				.Union(packageManager.QueryIntentActivities(intent, 0));
			if (list.Any())
				return true;

			TelephonyManager mgr = TelephonyManager.FromContext(context);
			return mgr.PhoneType != PhoneType.None;
		}
	}
}
