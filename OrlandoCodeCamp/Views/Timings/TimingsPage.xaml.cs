using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace com.ithiredguns.orlandocodecamp
{
	public partial class TimingsPage : ContentPage
	{
		private TimingsViewModel vm;
		public TimingsPage()
		{
			InitializeComponent();
		
		
			vm = new TimingsViewModel();
			NavigationPage.SetBackButtonTitle(this, "Timings");

			lstTimings.ItemsSource = GetTimings();
			Title = "Timings";
		}

		ObservableCollection<Timeslot> GetTimings(string searchText = null)
		{

			if (String.IsNullOrWhiteSpace(searchText))
				return vm.AllTimeslots;
			else
				return new ObservableCollection<Timeslot>();
			//return vm.AllTimings.Where(c => c.Room.StartsWith(searchText, StringComparison.CurrentCultureIgnoreCase)).ToObservableCollection();
		}

		//void Handle_Refreshing(object sender, System.EventArgs e)
		//{
		//	App.occDataService.Refresh();
		//	lstTracks.ItemsSource = GetTracks();
		//	lstTracks.EndRefresh();

		//}

		//void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
		//{
		//	lstTracks.ItemsSource = GetTracks(e.NewTextValue);
		//}

		void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			var timeslot = e.Item as Timeslot;

			//create the model here itself for SessionInformation

			ObservableCollection<Session> sessions = App.occDataService.AllSessions(false);

			ObservableCollection<Session> sessionsFilteredByTiming = new ObservableCollection<Session>();
			foreach (Session s in sessions)
			{
				if (s.TimeslotID == timeslot.ID)
				{
					if (s.Track == null)
					{
						if (s.TrackID != null)
						{
							s.Track = GetTrackFromAllTracks(s.TrackID.Value);
						}

					}

					if (s.Timeslot == null)
					{
						if ((s.TimeslotID != null) || (s.TimeslotID > 0))
						{
							s.Timeslot = GetTimeslotFromAllTimeslots(s.TimeslotID);
						}
					}

					if (s.SpeakerID >= 0)
					{
						s.Speaker = GetSpeakerFromAllSpeakers(s.SpeakerID);

					}

					sessionsFilteredByTiming.Add(s);


				}

				//also fill in the TimeSlot 



			}

			sessionsFilteredByTiming =
					sessionsFilteredByTiming.OrderBy(st => st.Track.RoomNumber).ToObservableCollection<Session>();



			//DisplayAlert("Selected: ", track.ID.ToString() + " - " + track.Name, "Ok");
			Navigation.PushAsync(new SessionsPage(sessionsFilteredByTiming,timeslot.TimeslotFullString));

		}

		Timeslot GetTimeslotFromAllTimeslots(int? timeslotID)
		{

			if (timeslotID > 0)
			{
				var allTimeslots = App.occDataService.AllTimeSlots(false);
				var timeslot = allTimeslots.SingleOrDefault(t => t.ID == timeslotID);
				return timeslot;
			}
			else
			{
				return null;
			}

		}

		Track GetTrackFromAllTracks(int trackID)
		{
			var allTracks = App.occDataService.AllTracks(false);
			var track = allTracks.SingleOrDefault(s => s.ID == trackID);
			return track;
		}

		Speaker GetSpeakerFromAllSpeakers(int speakerID)
		{
			var allSpeakers = App.occDataService.AllSpeakers(false);
			var speaker = allSpeakers.SingleOrDefault(spk => spk.ID == speakerID);
			return speaker;

		}

		void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
			//lstTracks.SelectedItem = null;
		}
	}
}
