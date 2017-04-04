using System;
using System.Collections.ObjectModel;

namespace com.ithiredguns.orlandocodecamp
{
	public class TracksViewModel
	{
		public ObservableCollection<Track> AllTracks { get; set; }
		public TracksViewModel()
		{
			AllTracks = App.occDataService.AllTracks(false);
		}
		public String TrackCount
		{
			get
			{
				if (AllTracks != null)
				{
					return "Tracks : " + AllTracks.Count.ToString();
				}
				else
				{
					return "Tracks";
				}
			}

		}
	}
}
