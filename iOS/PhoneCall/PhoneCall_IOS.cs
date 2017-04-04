using System;
using Foundation;
using UIKit;
using Xamarin.Forms;
using com.ithiredguns.orlandocodecamp.iOS;

[assembly: Dependency(typeof(PhoneCall_IOS))]
namespace com.ithiredguns.orlandocodecamp.iOS
{
	public class PhoneCall_IOS : IPhoneCall
	{


		public void MakePhoneCall(string phoneNumber)
		{
			try
			{
				NSUrl url = new NSUrl(string.Format(@"telprompt://{0}", phoneNumber));
				UIApplication.SharedApplication.OpenUrl(url);
			}
			catch (Exception ex)
			{
				UIAlertView alert = new UIAlertView();
				alert.Title = "iOS Exception";
				alert.AddButton("OK");
				alert.Message = ex.ToString();
				alert.Show();
			}
		}
	}
}
