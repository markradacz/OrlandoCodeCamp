using System;
namespace com.ithiredguns.orlandocodecamp
{
	public class AnnouncementDetailsViewModel
	{
		public AnnouncementDetailsViewModel(): this(App.occDataService.AllAnnouncements(false)[0])
		{
		}
		public AnnouncementDetailsViewModel(Announcement announcement)
		{
			this.Announcement = announcement;
		}
		public Announcement Announcement { get; private set; }
	}
}
