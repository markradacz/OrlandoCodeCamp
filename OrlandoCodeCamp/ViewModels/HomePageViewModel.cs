using System;
namespace com.ithiredguns.orlandocodecamp
{
	public class HomePageViewModel
	{
		private readonly char _icon = '\uf0da';
		public char CaretRightIcon
		{
			get
			{
				return _icon;
			}
		}
		public char NavigationIcon
		{
			get
			{
				return '\uf14e';
			}
		}
		public char PhoneIcon
		{
			get
			{
				return '\uf098';
			}
		}
		public char ChevronRightIcon
		{
			get
			{
				return '\uf054';
			}
		}
		public char EventIcon
		{
			get
			{
				return '\uf073';
			}
		}
		public char EmailIcon
		{
			get
			{
				return '\uf003';
			}
		}
		/*
		public string Address1 { get; set; }

		public string CityStateCountryZip { get; set; }

		public double GPSLatitude { get;  set; }

		public double GPSLongitude { get; set; }

		public string EventLocationName { get; set; }


		public string InitialContact { get; set; }

		public string Email { get; set; }
		public string EventTimings { get; set; }
		public string EventBuildingInfo { get; set; }
			
		*/

		public Event EventInfo
		{
			get;set;
		}

		public Event APEventInfo
		{
			get; set;
		}

		public string EventHours
		{
			get
			{
				if (APEventInfo != null)
				{
					return string.Format("{0:t}", APEventInfo.EventStart) + " to " + string.Format("{0:t}", APEventInfo.EventEnd);
				}
				else
				{
					return string.Empty;
				}
			}


		}

		public string APEventTimings
		{
			get
			{
				if (EventInfo != null)
				{
					return string.Format("{0:M/d/yyyy h:mm tt}", APEventInfo.EventStart) + " to " + string.Format("{0:t}", APEventInfo.EventEnd);
				}
				else
				{
					return string.Empty;
				}
			}


		}


		public string EventTimings { 
			get
			{
				if (EventInfo != null)
				{
					return string.Format("{0:M/d/yyyy h:mm tt}", EventInfo.EventStart) + " to " + string.Format("{0:t}", EventInfo.EventEnd);
				}
				else
				{
					return string.Empty;
				}
			}
		
		
		}



		public string StreetAddress
		{
			get
			{
				if (EventInfo != null)
				{
					if (!String.IsNullOrWhiteSpace(EventInfo.CompleteAddress))
					{
						char[] numChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
						int indexOfStreetAddress = EventInfo.CompleteAddress.IndexOfAny(numChars);
						if (indexOfStreetAddress > -1)
						{
							return EventInfo.CompleteAddress.Substring(indexOfStreetAddress);
						}
						else
						{
							return String.Empty;
						}

					}
					else
					{
						return String.Empty;
					}
				}
				else
				{
					return String.Empty;
				}
			}
		}

	}

}

