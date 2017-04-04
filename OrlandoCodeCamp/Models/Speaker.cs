using System;
using System.Collections.Generic;

namespace com.ithiredguns.orlandocodecamp
{
	public class Speaker

	{

		 
		private string _avatarUrl;

		public int ID { get; set; }

		public string FullName { get; set; }

		public string Company { get; set; }

		public string Title { get; set; }

		public string Bio { get; set; }

		public string Twitter { get; set; }

		public string Website { get; set; }

		public string Blog { get; set; }

		public string AvatarURL
		{
			get
			{
				if (!String.IsNullOrWhiteSpace(_avatarUrl))
				{

					if ((_avatarUrl.Contains("http://")) || _avatarUrl.Contains("https://"))
						return _avatarUrl;
					else

					{
						return "http://orlandocodecamp.com" + _avatarUrl;
					}
				}
				else
				{
					return "http://orlandocodecamp.com/images/ONETUGlogo.png";
				}
			}
			set
			{
				_avatarUrl = value;
			}
		}

		public string MVPDetails { get; set; }

		public string AuthorDetails { get; set; }

		public string NoteToOrganizers { get; set; }

		//to display or hide speakers, for instance, the organizers

		public bool? Special { get; set; }

		public string ApplicationUserId { get; set; }

		 

		public ApplicationUser AppUser { get; set; }

		public List<Session> Sessions { get; set; }

		public string FullNameLowerCase
		{
			get
			{
				if (!String.IsNullOrWhiteSpace(FullName))
				{
					return FullName.ToLower();
				}
				else
				{
					return String.Empty;
				}
			}
		}

	}
}
