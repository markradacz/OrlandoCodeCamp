using System;
using System.Collections.ObjectModel;

namespace com.ithiredguns.orlandocodecamp
{
	public class TimingsViewModel
	{
		public ObservableCollection<Timeslot> AllTimeslots { get; set; }
		public TimingsViewModel()
		{
			AllTimeslots = App.occDataService.AllTimeSlots(false);

		}
	}
}
