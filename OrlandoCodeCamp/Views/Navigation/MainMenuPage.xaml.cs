using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace com.ithiredguns.orlandocodecamp
{
	public partial class MainMenuPage : ContentPage
	{
		private readonly INavigation _navigation;
		ObservableCollection<Announcement> _announcements = new ObservableCollection<Announcement>();

		public MainMenuPage()
		{
			InitializeComponent();
		}

		public MainMenuPage(INavigation navigation)
		{
 			InitializeComponent();

			_navigation = navigation;


		}

		protected override async void OnAppearing()
		{
			 _announcements = await this.GetAllAnnouncementsFromServer();
			BindingContext = new ActivitiesViewModel(_navigation, _announcements);
		}

		public async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var activity = activityListView.SelectedItem as Activity;

			if (activity != null)
			{
				if (activity.PageType == typeof(RootPage))
				{
					await DisplayAlert("Hey", string.Format("You are already here, on activity {0}.", activity.Name), "OK");
				}
				else if (activity.PageType == typeof(LoginPage))
				{
					if (App.IsUserLoggedOn)
					{
						// User already logged on..
						await DisplayAlert("Hey", "You are already logged in", "OK");
					}
					else
					{
						await activity.NavigateToActivity(_navigation);
					}
				}
				else if (activity.PageType == typeof(RecoverPasswordPage))
				{
					if (App.IsUserLoggedOn)
					{
						// User already logged on..
						await DisplayAlert("Hey", "You are already logged in", "OK");
					}
					else
					{
						await activity.NavigateToActivity(_navigation);
					}
				}
				else if (activity.PageType == typeof(SignOutPage))
				{
					if (!App.IsUserLoggedOn)
					{
						// User already logged on..
						await DisplayAlert("Hey", "You are already signed out", "OK");
					}
					else
					{
						await activity.NavigateToActivity(_navigation);
					}
				}

				else
				{
					await activity.NavigateToActivity(_navigation);
				}

				activityListView.SelectedItem = null;
			}
		}

		private async void OnCloseButtonClicked(object sender, EventArgs args)
		{
			await Navigation.PopAsync();
		}

		public async Task<ObservableCollection<Announcement>> GetAllAnnouncementsFromServer()
		{
			HttpClient _client = new HttpClient();
			string _allAnnouncementsUrl = "http://orlandocodecamp.com/api/AnnouncementList";


			try
			{

				var content = await _client.GetStringAsync(_allAnnouncementsUrl);

				//var announcements = JsonConvert.DeserializeObject<List<Announcement>>(content).OrderBy(a => a.Rank);

				//do not order so that it can be controlled by API 
				var announcements = JsonConvert.DeserializeObject<List<Announcement>>(content);

				_announcements = new ObservableCollection<Announcement>();

				foreach (Announcement a in announcements)
				{
					_announcements.Add(a);

				}
			}
			catch (Exception ex)
			{
				_announcements = new ObservableCollection<Announcement>(); //just point to blank 
			}

			return _announcements;
		}

	}

}
