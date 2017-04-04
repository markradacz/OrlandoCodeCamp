using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace com.ithiredguns.orlandocodecamp
{
	public partial class SessionsPage : ContentPage
	{

		ObservableCollection<Session> _sessions;
		public SessionsPage()
		{
			InitializeComponent();

		}

		public SessionsPage(ObservableCollection<Session> sessions, string title )
		{
			 
			InitializeComponent();
			//this.Title = sessions[0].Track.Name;
			this.Title = title;
			_sessions = sessions;

			lstSessionDetails.ItemsSource = GetSessions();
		}

		ObservableCollection<Session> GetSessions(string searchText = null)
		{
			if (String.IsNullOrWhiteSpace(searchText))
				return _sessions;
			return _sessions.Where(s => s.DescriptionLowerCase.Contains(searchText.ToLower())).ToObservableCollection();
		}

		void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
		{
			lstSessionDetails.ItemsSource = GetSessions(e.NewTextValue);
		}

		void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			var session = e.Item as Session;
			Navigation.PushAsync(new SessionDetailsPage(new SessionDetailViewModel(session)));
		}
	}
}
