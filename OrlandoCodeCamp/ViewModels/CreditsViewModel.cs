using System;
using System.Collections.Generic;

namespace com.ithiredguns.orlandocodecamp
{
	public class CreditsViewModel
	{
		public List<Credit> Credits
		{
			get
			{
				return new List<Credit>()
				{
					new Credit(){FullName="Srinath Nanduri",AvatarUrl="http://www.ithiredguns.com/images/srinath.png",Website="http://www.ithiredguns.com", CompanyName="I.T Hired Guns Inc."},
					new Credit(){FullName=" Santosh Hari", AvatarUrl="https://pbs.twimg.com/profile_images/700069404151779329/hrJgLZNg_400x400.jpg",CompanyName="Spectrum Bridge",Website="http://www.spectrumbridge.com"},
					new Credit(){FullName="Mark Radacz", AvatarUrl="http://photos3.meetupstatic.com/photos/event/a/d/c/6/highres_442724486.jpeg" , CompanyName="",Website="http://www.xradapp.com"}
				};
			}
		}
	}
}
