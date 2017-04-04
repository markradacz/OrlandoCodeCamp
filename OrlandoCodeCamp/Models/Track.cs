using System;
using System.Collections.Generic;

namespace com.ithiredguns.orlandocodecamp
{
	public class Track

	{

		public int ID { get; set; }

		public string Name { get; set; }

		//probably should be a FK from another table

		public string RoomNumber { get; set; }

		public List<Session> Sessions { get; set; }

	}
}
