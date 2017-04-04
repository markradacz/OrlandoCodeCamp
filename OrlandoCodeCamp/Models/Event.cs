using System;
namespace com.ithiredguns.orlandocodecamp
{
	public class Event

	{

		public int ID { get; set; }

		public string Name { get; set; }

		public double GPSLatitude { get; set; }
		public double GPSLongitude { get; set; }
		public string ContactEmail { get; set; }

		public string SocialMediaHashtag { get; set; }

		public System.DateTime EventStart { get; set; }

		public System.DateTime EventEnd { get; set; }

		public string CompleteAddress { get; set; }

		public bool IsCurrent { get; set; }

		public bool? AttendeeRegistrationOpen { get; set; }

		public bool? SpeakerRegistrationOpen { get; set; }

	}
}
