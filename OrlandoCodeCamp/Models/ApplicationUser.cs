using System;
namespace com.ithiredguns.orlandocodecamp
{
	public class ApplicationUser 
	{

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Location { get; set; }

		public string Twitter { get; set; }

		public int? AvatarID { get; set; }

		public bool? RSVP { get; set; }

		public bool? Volunteer { get; set; }

		public Speaker Speaker { get; set; }

	}
}
