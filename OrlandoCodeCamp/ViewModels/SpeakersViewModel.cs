using System;
using System.Collections.ObjectModel;

namespace com.ithiredguns.orlandocodecamp
{
	public class SpeakersViewModel
	{
		public ObservableCollection<Speaker> SpeakersList
		{
			get
			{
				return App.occDataService.AllSpeakers(false);
			}set
			{
				App.occDataService.Speakers = value;
			}
		}
	}
}
