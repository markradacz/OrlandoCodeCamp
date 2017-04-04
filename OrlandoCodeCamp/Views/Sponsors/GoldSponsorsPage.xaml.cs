using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace com.ithiredguns.orlandocodecamp
{
	public partial class GoldSponsorsPage : ContentPage
	{
		public GoldSponsorsPage()
		{
			InitializeComponent();
			var allSponsors = App.occDataService.AllSponsors(false);
			if (allSponsors != null)
			{
				lstSponsorDetails.ItemsSource = allSponsors.
												Where(s=>s.SponsorLevel.Equals("Gold", StringComparison.CurrentCultureIgnoreCase)).
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
