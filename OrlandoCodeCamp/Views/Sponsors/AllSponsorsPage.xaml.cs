using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Linq;

namespace com.ithiredguns.orlandocodecamp
{
	public partial class AllSponsorsPage : ContentPage
	{
		public AllSponsorsPage()
		{
			InitializeComponent();

		  var allSponsors = App.occDataService.AllSponsors(false);
			if (allSponsors != null)
			{
				lstSponsorDetails.ItemsSource = allSponsors.OrderBy(s=>s.CompanyName);
			}
			NavigationPage.SetBackButtonTitle(this, "");
		}

		void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			var sponsor = e.Item as Sponsor;

			Navigation.PushAsync(new SponsorDetailsPage(sponsor));

		}

		void OnTapGestureRecognizerTapped(object sender, EventArgs args)
		{

			Device.OpenUri(new Uri("http://orlandocodecamp.com/documents/ContributorInformation.pdf"));
		}


	}
}
