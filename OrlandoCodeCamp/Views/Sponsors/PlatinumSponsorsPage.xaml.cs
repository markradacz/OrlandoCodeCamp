using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Linq;

namespace com.ithiredguns.orlandocodecamp
{
	public partial class PlatinumSponsorsPage : ContentPage
	{
		public PlatinumSponsorsPage()
		{
			InitializeComponent();
		    var allSponsors = App.occDataService.AllSponsors(false);
			if (allSponsors != null)
			{
				lstSponsorDetails.ItemsSource = allSponsors.
												Where(s => s.SponsorLevel.Equals("Platinum", StringComparison.CurrentCultureIgnoreCase)).
												OrderBy(s => s.CompanyName);
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

			Device.OpenUri(new Uri("http://orlandocodecamp.azurewebsites.net/documents/ContributorInformation.pdf"));
		}
	}
}
