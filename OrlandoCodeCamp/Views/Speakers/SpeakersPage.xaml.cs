using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace com.ithiredguns.orlandocodecamp
{
	public partial class SpeakersPage : ContentPage
	{
		SpeakersViewModel vm;

		bool _isRefresh = false;
		public SpeakersPage()
		{
			InitializeComponent();

			 vm = new SpeakersViewModel();
			 NavigationPage.SetBackButtonTitle(this, "");
			lstSpeakers.ItemsSource = GetSpeakers();

		}

		ObservableCollection<Speaker> GetSpeakers(string searchText = null)
		{

			if (String.IsNullOrWhiteSpace(searchText))
				return vm.SpeakersList;
			return vm.SpeakersList.Where(spkr => spkr.FullNameLowerCase.Contains(searchText.ToLower())).ToObservableCollection();
		}


		private async void OnItemTapped(Object sender, EventArgs e)
		{
			var selectedItem = ((ListView)sender).SelectedItem;
			var speaker = (Speaker)selectedItem;

			var speakerView = new SpeakerViewPage(speaker);

			await Navigation.PushAsync(speakerView);
		}

		void Handle_Refreshing(object sender, System.EventArgs e)
		{
			Task.Run(() =>
			{
				App.occDataService.Refresh(); // AS ALL THE DATA IS DEPENEDED ON THIS.

				Device.BeginInvokeOnMainThread(() =>
				{
					vm = new SpeakersViewModel();
					speakerSearch.Text = String.Empty;
					lstSpeakers.ItemsSource = GetSpeakers();
					lstSpeakers.EndRefresh();
				});


			});

		 


		}

		void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
		{
			lstSpeakers.ItemsSource = GetSpeakers(e.NewTextValue);
		}



		protected override void OnAppearing()
		{
			base.OnAppearing();

			 
		}

	}
}
