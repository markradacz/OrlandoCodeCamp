using System;
namespace com.ithiredguns.orlandocodecamp
{
	public class SessionDetailViewModel
	{
		public SessionDetailViewModel():this(App.occDataService.AllSessions(false)[0])
		{
		}
		public SessionDetailViewModel(Session session)
		{
			this.Session = session;
		}
		public Session Session { get; private set; }
	}
}

