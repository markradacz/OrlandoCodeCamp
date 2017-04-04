using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace com.ithiredguns.orlandocodecamp
{
	public partial class SpeakerViewPage : ContentPage
	{
		private Speaker _speaker;
		public SpeakerViewPage()
		{
			InitializeComponent();
		}

		public SpeakerViewPage(Speaker speaker)
		{
			InitializeComponent();
			_speaker = speaker;
			BindingContext = speaker;
		}


		void OnTapGestureRecognizerWebsiteTapped(object sender, EventArgs args)
		{
			if (!String.IsNullOrWhiteSpace(_speaker.Website))
			{
				if (!_speaker.Website.StartsWith("http", StringComparison.CurrentCultureIgnoreCase))
				{
					Device.OpenUri(new Uri("http://"+_speaker.Website));
				}
				else
				{

					Device.OpenUri(new Uri(_speaker.Website));
				}
			}
		}

		void OnTapGestureRecognizerBlogTapped(object sender, EventArgs args)
		{
			if (!String.IsNullOrWhiteSpace(_speaker.Blog))
				Device.OpenUri(new Uri(_speaker.Blog));
		}
		void OnTapGestureRecognizerTwitterTapped(object sender, EventArgs args)
		{
			if (!String.IsNullOrWhiteSpace(_speaker.Twitter))
				Device.OpenUri(new Uri("twitter://user?user_id="+_speaker.Twitter.Replace("@","")));

		
		}

	}
}
