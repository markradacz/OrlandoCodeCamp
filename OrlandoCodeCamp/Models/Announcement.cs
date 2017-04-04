using System;
namespace com.ithiredguns.orlandocodecamp
{
	public class Announcement

	{

		public int ID { get; set; }

		public string Message { get; set; }

		public int Rank { get; set; }

		public System.DateTime PublishOn { get; set; }

		public System.DateTime ExpiresOn { get; set; }

		public string ShortDescription
		{
			get
			{
				if (!String.IsNullOrWhiteSpace(Message))
				{
					if (Message.Length >= 150)
						return Message.Substring(0, 150) + " ...";
					else
					{
						return Message + "  ...";
					}
				}
				else
					return String.Empty;
			}
		}


	}
}
