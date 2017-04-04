using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace com.ithiredguns.orlandocodecamp
{
	public partial class SponsorDetailsPage : ContentPage
	{
		
		private Sponsor _sponsor = null;

		public SponsorDetailsPage()
		{
			InitializeComponent();
		}

		public SponsorDetailsPage(Sponsor sponsor)
		{
			InitializeComponent();
			_sponsor = sponsor;
			this.BindingContext = sponsor;
			 
		}

		void OnTapGestureRecognizerWebsiteTapped(object sender, EventArgs args)
		{
			if (!String.IsNullOrWhiteSpace(_sponsor.Website))
				if (!_sponsor.Website.StartsWith("http", StringComparison.CurrentCultureIgnoreCase))
				{
					Device.OpenUri(new Uri("http://"+_sponsor.Website));
				}
				else
				{
					Device.OpenUri(new Uri(_sponsor.Website));
				}
		}
	}
}
