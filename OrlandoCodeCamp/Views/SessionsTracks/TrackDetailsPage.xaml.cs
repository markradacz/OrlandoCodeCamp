using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace com.ithiredguns.orlandocodecamp
{
	public partial class TrackDetailsPage : ContentPage
	{
		public TrackDetailsPage()
		{
		}
		public TrackDetailsPage(Track track)
		{
			InitializeComponent();
			ObservableCollection<Session> sessions = App.occDataService.AllSessions(false).Where(c => c.TrackID == track.ID).ToObservableCollection();
			lstSessionDetails.ItemsSource = sessions;
		}
	}
}
