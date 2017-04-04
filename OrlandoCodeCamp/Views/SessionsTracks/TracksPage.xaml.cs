using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace com.ithiredguns.orlandocodecamp
{
	public partial class TracksPage : ContentPage
	{
		private TracksViewModel vm;
		public TracksPage()
		{
			InitializeComponent();
			vm = new TracksViewModel();
			NavigationPage.SetBackButtonTitle(this, "Tracks");

			lstTracks.ItemsSource = GetTracks();
			if (GetTracks() != null)
			{
				Title = "Tracks (Total: " + GetTracks().Count.ToString() + " )";
			}
			else
			{
				Title = "Tracks";
			}
		}

		ObservableCollection<Track> GetTracks(string searchText = null)
		{

			if(String.IsNullOrWhiteSpace(searchText))
				 return vm.AllTracks;
			return vm.AllTracks.Where(c => c.Name.StartsWith(searchText,StringComparison.CurrentCultureIgnoreCase)).ToObservableCollection();
		}

		void Handle_Refreshing(object sender, System.EventArgs e)
		{
			App.occDataService.Refresh();
			lstTracks.ItemsSource = GetTracks();
			lstTracks.EndRefresh();

		}

		void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
		{
			lstTracks.ItemsSource = GetTracks(e.NewTextValue);
		}

		void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			 var track = e.Item as Track;

			//create the model here itself for SessionInformation

			ObservableCollection<Session> sessions = App.occDataService.AllSessions(false);

			ObservableCollection<Session> sessionsFilteredByTracks = new ObservableCollection<Session>();
			foreach (Session s in sessions)
			{
				if (s.TrackID == track.ID)
				{
					if (s.Track == null)
					{
						s.Track = GetTrackFromAllTracks(track.ID);
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

					sessionsFilteredByTracks.Add(s);


				}

				//also fill in the TimeSlot 

			

			}

		sessionsFilteredByTracks=
				sessionsFilteredByTracks.OrderBy(st => st.TimeslotID).ToObservableCollection<Session>();



			//DisplayAlert("Selected: ", track.ID.ToString() + " - " + track.Name, "Ok");
			Navigation.PushAsync(new SessionsPage(sessionsFilteredByTracks,track.Name));

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
