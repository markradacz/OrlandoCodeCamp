using System;
namespace com.ithiredguns.orlandocodecamp
{
	public class Session

	{

		public int SessionID { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }


		public int Level { get; set; }

		public string KeyWords { get; set; }

		//to display or hide sessions, for instance, keynote, lunch, etc

		public bool? Special { get; set; }

		public bool IsApproved { get; set; }

		public int SpeakerID { get; set; }

		 

		public Speaker Speaker { get; set; }

		public string CoSpeakers { get; set; }

		public int? TrackID { get; set; }

		 

		public Track Track { get; set; }

		public int? TimeslotID { get; set; }

		 

		public Timeslot Timeslot { get; set; }


		public string ShortDescription
		{
			get
			{
				if (!String.IsNullOrWhiteSpace(Description))
				{
					if (Description.Length >= 150)
						return Description.Substring(0, 150) + " ...";
					else
					{
						return Description + "  ...";
					}
				}
				else
					return String.Empty;
			}
		}

		public string DescriptionLowerCase
		{
			get
			{
				if (!String.IsNullOrWhiteSpace(Description))
				{
					return Description.ToLower();
				}
				else
				{
					return String.Empty;
				}
			}
		}

		public string SpeakerAvatarURL
		{
			get
			{
				try
				{
					if (Speaker != null)
					{
						return Speaker.AvatarURL ?? " ";
					}
					else
					{
						return String.Empty;
					}
				}
				catch (Exception ex)
				{
					Xamarin.Insights.Report(ex);
					return " ";
				}
			}
		}
		public string SpeakerFullName
		{
			get
			{
				if (Speaker != null)
				{
					return Speaker.FullName??" ";
				}
				else
				{
					return String.Empty;
				}
			}
		}


		public string SpeakerCompany
		{
			get
			{
				try
				{
					if (Speaker != null)
					{
						return Speaker.Company ?? " ";
					}
					else
					{
						return String.Empty;
					}
				}
				catch (Exception ex)
				{
					Xamarin.Insights.Report(ex);
					return " ";
				}
			}
		}

		public string TimeslotInfo
		{
			get
			{
				try
				{
					if (Timeslot != null)
					{
						return Timeslot.StartTime + " - " + Timeslot.EndTime;
					}
					else
					{
						return String.Empty;
					}
				}
				catch (Exception ex)
				{
					Xamarin.Insights.Report(ex);
					return " ";
				}
			}
		}

		public string TrackRoomNumber
		{
			get
			{
				try
				{
					if (Track != null)
					{
						return Track.RoomNumber;
					}
					else
					{
						return String.Empty;
					}
				}
				catch (Exception ex)
				{
					Xamarin.Insights.Report(ex);
					return " ";
				}
			}
		}


	}
}
