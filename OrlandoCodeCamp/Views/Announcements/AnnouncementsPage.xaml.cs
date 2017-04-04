using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace com.ithiredguns.orlandocodecamp
{
	public partial class AnnouncementsPage : ContentPage
	{
		//private bool _isBusy;
		//private int count = 0;
		private ObservableCollection<Announcement> _announcements = new ObservableCollection<Announcement>();
		public AnnouncementsPage()
		{
			InitializeComponent(); 
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			try
			{
				if (App.occDataService.RefreshAnnouncementsCount > 1)
				{
					//Been refreshed and hence can check against time

					TimeSpan difference = DateTime.UtcNow - App.occDataService.TimeOfLastAnnouncementsRefresh;
					if (difference.TotalMinutes > 10)
					{
						//It's been more than 10 min , so refresh

						lstAnnouncementDetails.IsRefreshing = true;
						_announcements = await this.GetAllAnnouncementsFromServer();
						lstAnnouncementDetails.ItemsSource = _announcements;
						lstAnnouncementDetails.IsRefreshing = false;
						App.occDataService.TimeOfLastAnnouncementsRefresh = DateTime.UtcNow;
					}
					else
					{
						lstAnnouncementDetails.IsRefreshing = true;
						_announcements = App.occDataService.Announcements;
						if (_announcements == null)
						{
							//set it to empty
							_announcements = new ObservableCollection<Announcement>();
						}
						lstAnnouncementDetails.ItemsSource = _announcements;
						lstAnnouncementDetails.IsRefreshing = false;

					}
				}
				else
				{
					lstAnnouncementDetails.IsRefreshing = true;
					_announcements = await this.GetAllAnnouncementsFromServer();
					lstAnnouncementDetails.ItemsSource = _announcements;
					lstAnnouncementDetails.IsRefreshing = false;
					App.occDataService.TimeOfLastAnnouncementsRefresh = DateTime.UtcNow;

					//No need to set the AnnouncementsCount as it is incremented with the get{} anyway

				}
			}
			catch (Exception ex)
			{
				//show empty set;
				lstAnnouncementDetails.IsRefreshing = true;
				lstAnnouncementDetails.ItemsSource = new ObservableCollection<Announcement>();
				lstAnnouncementDetails.IsRefreshing = false;
			}
		}
		 

		//public AnnouncementsPage(ObservableCollection<Announcement> announcements)
		//{

		//	InitializeComponent(); 

		//	lstAnnouncementDetails.ItemsSource = announcements;
		//}

		void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			var announcement = e.Item as Announcement;
			Navigation.PushAsync(new AnnouncementDetailsPage(new AnnouncementDetailsViewModel(announcement)));
		}


		public async Task<ObservableCollection<Announcement>> GetAllAnnouncementsFromServer()
		{
			HttpClient _client = new HttpClient();
			string _allAnnouncementsUrl = Application.Current.Resources["AllAnnouncementsUrl"] as String;


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
				App.occDataService.Announcements = _announcements;
			}
			catch (Exception ex)
			{
				_announcements = new ObservableCollection<Announcement>(); //just point to blank 
			}

			return _announcements;
		}

	}
}
