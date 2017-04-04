using System;
namespace com.ithiredguns.orlandocodecamp
{
	public class Sponsor

	{
		private string _avatarUrl;
		public int ID { get; set; }

		public string CompanyName { get; set; }

		public string SponsorLevel { get; set; }

		public string Bio { get; set; }

		public string Twitter { get; set; }

		public string Website { get; set; }

		public string AvatarURL
		{
			get
			{
				return "http://orlandocodecamp.com" + _avatarUrl;
			}
			set
			{
				_avatarUrl = value;
			}
		}

		public string SponsorBackgroundColor
		{
			get
			{
				if (!String.IsNullOrWhiteSpace(SponsorLevel))
				{
					if (SponsorLevel.Trim().Equals("Gold", StringComparison.CurrentCultureIgnoreCase))
					{
						return "#FFD700";
					}
					else if (SponsorLevel.Trim().Equals("Platinum", StringComparison.CurrentCultureIgnoreCase))
					{
						return "#e5e4e2";
					}
					else if (SponsorLevel.Trim().Equals("Silver", StringComparison.CurrentCultureIgnoreCase))
					{
						return "#c0c0c0";
					}
					else
					{
						return "#acacac";
					}

				}
				else
				{
					return "#c303030"; //silver 
				}
			}
		}

	}
}
