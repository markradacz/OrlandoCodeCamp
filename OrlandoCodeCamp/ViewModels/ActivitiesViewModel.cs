using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace com.ithiredguns.orlandocodecamp
{
	public class ActivitiesViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private Activity _selectedActivity;

		public ActivitiesViewModel(INavigation navigation, ObservableCollection<Announcement> announcements)
		{
			ActivitiesCategories = new List<ActivityCategory>(ActivitiesDefinition.ActivitiesCategories.Values);
			AllActivities = ActivitiesDefinition.AllActivities;
			ActivitiesGroupedByCategory = ActivitiesDefinition.ActivitiesGroupedByCategory;

			////Trips Info

			// UnReadAnnouncements = ActivitiesDefinition.UnReadAnnouncements;
			//UnReadAnnouncements = App.occDataService.AllAnnouncements(false);
			UnReadAnnouncements = announcements;
		}

		public List<ActivityCategory> ActivitiesCategories { get; set; }

		public List<Activity> AllActivities { get; set; }
		 public ObservableCollection<Announcement>  UnReadAnnouncements { get; set; }
		//public ObservableCollection<Trip>  CompletedTrips { get; set; }

		public List<ActivityGroup> ActivitiesGroupedByCategory { get; set; }

		public Activity SelectedActivity
		{
			get
			{
				return _selectedActivity;
			}

			set
			{
				if (value != _selectedActivity)
				{
					_selectedActivity = value;

					RaisePropertyChanged("SelectedActivity");
				}
			}
		}

		private void RaisePropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
