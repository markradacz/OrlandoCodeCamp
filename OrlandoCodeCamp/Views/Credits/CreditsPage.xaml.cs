using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace com.ithiredguns.orlandocodecamp
{
	public partial class CreditsPage : ContentPage
	{
		public CreditsPage()
		{
			InitializeComponent();
			CreditsViewModel vm= new CreditsViewModel();
			lstCredits.ItemsSource = vm.Credits;
		}

		void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			var credit = e.Item as Credit;

			if (!String.IsNullOrWhiteSpace(credit.Website))
			{
				if (!credit.Website.StartsWith("http", StringComparison.CurrentCultureIgnoreCase))
				{
					Device.OpenUri(new Uri("http://" + credit.Website));
				}
				else
				{

					Device.OpenUri(new Uri(credit.Website));
				}
			}
		}
	}
}
