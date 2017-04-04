
/**  
* OCCDataService - a simple class for calling WEB API and collecting Data for APP
* @author  Srinath Nanduri ( www.ithiredguns.com) ithiredguns@gmail.com
* @version 1.0 
*  
*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace com.ithiredguns.orlandocodecamp
{
	public class OCCDataService
	{

		 Event _event = null;

		 HttpClient _client;

		//string _allTracksUrl = "http://orlandocodecamp.com/api/TrackList";
		//string _allTimeSlotsUrl = "http://orlandocodecamp.com/api/TimeslotList";
		//string _allSessionsUrl = "http://orlandocodecamp.com/api/SessionList";
		//string _allSpeakersUrl = "http://orlandocodecamp.com/api/SpeakerList";
		//string _allSponsorsUrl = "http://orlandocodecamp.com/api/SponsorList";
		//string _allAnnouncementsUrl = "http://orlandocodecamp.com/api/AnnouncementList";



		string _allTracksUrl = Application.Current.Resources["AllTracksUrl"] as String;
		string _allTimeSlotsUrl = Application.Current.Resources["AllTimeslotsUrl"] as String;
		string _allSessionsUrl = Application.Current.Resources["AllSessionsUrl"] as String;
		string _allSpeakersUrl = Application.Current.Resources["AllSpeakersUrl"] as String;
		string _allSponsorsUrl = Application.Current.Resources["AllSponsorsUrl"] as String;
		string _allAnnouncementsUrl = Application.Current.Resources["AllAnnouncementsUrl"] as String;
 		string _eventInfoUrl = Application.Current.Resources["EventInfoUrl"] as String;



		ObservableCollection<Track> _allTracksList = null;
		DateTime _timeOfLastTracksRefresh = DateTime.UtcNow;
		int _refreshTracksCount = 0;

		ObservableCollection<Timeslot> _allTimeSlotsList = null;
		DateTime _timeOfLastTimeslotsRefresh = DateTime.UtcNow;
		int _refreshTimeslotsCount = 0;
		 
		ObservableCollection<Session> _allSessionsList = null;
		DateTime _timeOfLastSessionsRefresh = DateTime.UtcNow;
		int _refreshSessionsCount = 0;

		ObservableCollection<Speaker> _allSpeakersList = null;
		DateTime _timeOfLastSpeakersRefresh = DateTime.UtcNow;
		int _refreshSpeakersCount = 0;

		ObservableCollection<Sponsor> _allSponsorsList = null;
		DateTime _timeOfLastSponsorsRefresh = DateTime.UtcNow;
		int _refreshSponsorsCount = 0;

		ObservableCollection<Announcement> _allAnnouncementsList = null; 
		DateTime _timeOfLastAnnouncementsRefresh  = DateTime.UtcNow;
		int _refreshAnnouncementsCount = 0;



		public DateTime TimeOfLastTracksRefresh
		{
			get
			{
				return _timeOfLastTracksRefresh;
			}
			set
			{
				_timeOfLastTracksRefresh = value;

			}
		}

		public int RefreshTracksCount
		{
			get
			{
				_refreshTracksCount++;
				return _refreshTracksCount;
			}
			set
			{
				_refreshTracksCount = value;
			}

		}


		public DateTime TimeOfLastTimeslotsRefresh
		{
			get
			{
				return _timeOfLastTimeslotsRefresh;
			}
			set
			{
				_timeOfLastTimeslotsRefresh = value;
			}
		}

		public int RefreshTimeslotsCount
		{
			get
			{
				_refreshTimeslotsCount++;
				return _refreshTimeslotsCount;
			}
			set
			{
				_refreshTimeslotsCount = value;
			}

		}

		public DateTime TimeOfLastSessionsRefresh
		{
			get
			{
				return _timeOfLastSessionsRefresh;
			}
			set
			{
				_timeOfLastSessionsRefresh = value;
			}
		}

		public int RefreshSessionsCount
		{
			get
			{
				_refreshSessionsCount++;
				return _refreshSessionsCount;
			}
			set
			{
				_refreshSessionsCount = value;
			}

		}

		public DateTime TimeOfLastSpeakersRefresh
		{
			get
			{
				return _timeOfLastSpeakersRefresh;
			}
			set
			{
				_timeOfLastSpeakersRefresh = value;
			}
		}

		public int RefreshSpeakersCount
		{
			get
			{
				_refreshSpeakersCount++;
				return _refreshSpeakersCount;
			}
			set
			{
				_refreshSpeakersCount = value;
			}

		}


		public DateTime TimeOfLastSponsorsRefresh
		{
			get
			{
				return _timeOfLastSponsorsRefresh;
			}
			set
			{
				_timeOfLastSponsorsRefresh = value;
			}
		}

		public int RefreshSponsorsCount
		{
			get
			{
				_refreshSponsorsCount++;
				return _refreshSponsorsCount;
			}
			set
			{
				_refreshSponsorsCount = value;
			}

		}



		public DateTime TimeOfLastAnnouncementsRefresh
		{
			get
			{
				return _timeOfLastAnnouncementsRefresh;
			}set
			{
				_timeOfLastAnnouncementsRefresh = value;
			}
		}

		public int RefreshAnnouncementsCount
		{
			get
			{
				_refreshAnnouncementsCount++;
				return _refreshAnnouncementsCount;
			}
			set
			{
				_refreshAnnouncementsCount = value;
			}
			 
		}






		public ObservableCollection<Track> Tracks
		{
			get
			{
				return _allTracksList;
			}
			set
			{
				_allTracksList = value;
			}
		}

		public ObservableCollection<Timeslot> Timeslots
		{
			get
			{
				return _allTimeSlotsList;
			}
			set
			{
				_allTimeSlotsList = value;
			}
		}

		public ObservableCollection<Session> Sessions
		{
			get
			{
				return _allSessionsList;
			}set
			{
				_allSessionsList = value;
			}
		}

		public ObservableCollection<Speaker> Speakers
		{
			get
			{
				return _allSpeakersList;
			}
			set
			{
				_allSpeakersList = value;
			}
		}

		public ObservableCollection<Sponsor> Sponsors
		{
			get
			{
				return _allSponsorsList;
			}
			set
			{
				_allSponsorsList = value;
			}
		}

		public ObservableCollection<Announcement> Announcements
		{
			get
			{
				return _allAnnouncementsList;
			}
			set
			{
				_allAnnouncementsList = value;
			}
		}

		public Event Event
		{
			get
			{
				return _event;
			}set
			{
				_event = value;
			}
		}

		public  ObservableCollection<Track> AllTracks(bool refresh)
		{


			if (refresh)
			{
				Task.Run(()=>GetAllTracksFromServer());	

				 
			}
			return _allTracksList;
		}



		public async void Init()
		{

			await Task.Run(() => Refresh()) ;
		}


		public void Refresh()
		{
			 AllAnnouncements(true);
			EventInfo(true);
			 AllTracks(true);
			AllSessions(true);
			 AllTimeSlots(true);
			AllSpeakers(true);
			AllSponsors(true); 
		}


		public ObservableCollection<Timeslot> AllTimeSlots(bool refresh)
		{
			//if (refresh)
			//{
			//	_allTimeSlotsList = null;
			//}

			//if (_allTimeSlotsList == null)
			//{
			//	GetAllTimeslotsFromServer();


			//}

			if (refresh)
			{
				Task.Run(()=>GetAllTimeslotsFromServer()); 
				return _allTimeSlotsList;
			}
			else
			{
				return _allTimeSlotsList;
			}
		}


		public ObservableCollection<Session> AllSessions(bool refresh)
		{
			//if (refresh)
			//{
			//	_allSessionsList = null;
			//}

			//if (_allSessionsList == null)
			//{
			//	GetAllSessionsFromServer();

			//}

			//

			if (refresh)
			{
				 GetAllSessionsFromServer();
				return _allSessionsList;
			}
			else
			{
				return _allSessionsList;
			}
		}

		public  ObservableCollection<Speaker> AllSpeakers(bool refresh)
		{
			//if (refresh)
			//{
			//	_allSpeakersList = null;
			//}

			//if (_allSpeakersList == null)
			//{
			//	GetAllSpeakersFromServer();

			//}
			//return _allSpeakersList;

			if (refresh)
			{
				Task.Run( () => GetAllSpeakersFromServer());
				return _allSpeakersList;
			}
			else
			{
				return _allSpeakersList;
			}


		}

		public  ObservableCollection<Sponsor> AllSponsors(bool refresh)
		{
			//if (refresh)
			//{
			//	_allSponsorsList = null;
			//}

			//if (_allSponsorsList == null)
			//{
			//	GetAllSponsorsFromServer();

			//}
			//return _allSponsorsList;

			if (refresh)
			{
				Task.Run(()=>GetAllSponsorsFromServer()); 
				return _allSponsorsList;
			}
			else
			{
				return _allSponsorsList;
			}

		}
		public  ObservableCollection<Announcement> AllAnnouncements(bool refresh)
		{
			//if (refresh)
			//{
			//	_allAnnouncementsList = null;
			//}

			//if (_allAnnouncementsList== null)
			//{
			//	GetAllAnnouncementsFromServer();

			//}
			//return _allAnnouncementsList;

			if (refresh)
			{
				Task.Run(()=> GetAllAnnouncementsFromServer()) ;

				return _allAnnouncementsList;
			}
			else
			{
				return _allAnnouncementsList;
			}

		}

		public ObservableCollection<Announcement> AllAnnouncements(bool check, bool refresh)
		{
			if (check)
			{
				if (_allAnnouncementsList != null)
				{
					return _allAnnouncementsList;
				}
				else
				{
					if (refresh)
					{
						_allAnnouncementsList = null;
					}

					if (_allAnnouncementsList == null)
					{
						Task.Run(()=>GetAllAnnouncementsFromServer()); 

					}
					return _allAnnouncementsList;
				}
			}
			else
			{
			  return	AllAnnouncements(refresh);
			}

		}

		public  Event EventInfo(bool refresh)
		{
			if (refresh)
			{
				Task.Run(()=>GetEventInfoFromServer()); 
				return _event;
			}
			else
			{
				return _event;
			}
		}


		async Task GetAllSessionsFromServer()
		{

			try
			{
				_client = new HttpClient();
				var content = await _client.GetStringAsync(_allSessionsUrl);
				//_allSessionsList = JsonConvert.DeserializeObject<ObservableCollection<Session>>(content);

				var sessions = JsonConvert.DeserializeObject<List<Session>>(content).OrderBy(a => a.Name);

				_allSessionsList = new ObservableCollection<Session>();

				foreach (Session s in sessions)
				{

					_allSessionsList.Add(s);
				}
			}
			catch (Exception ex)
			{
				_allSessionsList = null;
			}

			 

		}


		async Task<ObservableCollection<Timeslot>> GetAllTimeslotsFromServer()
		{
			try
			{
				_client = new HttpClient();
				var content = await _client.GetStringAsync(_allTimeSlotsUrl);
				//_allTimeSlotsList = JsonConvert.DeserializeObject<ObservableCollection<Timeslot>>(content);

				var timeslots = JsonConvert.DeserializeObject<List<Timeslot>>(content).OrderBy(a => a.Rank);

			 
					_allTimeSlotsList = new ObservableCollection<Timeslot>();
				 

				foreach (Timeslot t in timeslots)
				{
					_allTimeSlotsList.Add(t);
				}
			}
			catch (Exception ex)
			{
				_allTimeSlotsList = null;
			}

			return _allTimeSlotsList;
		}


		 async Task<ObservableCollection<Track>>  GetAllTracksFromServer()
		{
			try
			{
				_client = new HttpClient();
				var content = await _client.GetStringAsync(_allTracksUrl);

				var tracks = JsonConvert.DeserializeObject<List<Track>>(content).OrderBy(a => a.Name);

				 
					_allTracksList = new ObservableCollection<Track>();
				 
				foreach (Track t in tracks)
				{
					_allTracksList.Add(t);
				}
			}
			catch (Exception ex)
			{
				_allTracksList = null;
			}
			return _allTracksList;
			 

		}

		async Task<ObservableCollection<Speaker>> GetAllSpeakersFromServer()
		{
			try
			{
				_client = new HttpClient();
				var content = await _client.GetStringAsync(_allSpeakersUrl);

				var speakers = JsonConvert.DeserializeObject<List<Speaker>>(content).OrderBy(a => a.FullName);

				 
				_allSpeakersList = new ObservableCollection<Speaker>();
				 
				foreach (Speaker s in speakers)
				{
					_allSpeakersList.Add(s);
				}
			}
			catch (Exception ex)
			{
				_allSpeakersList = null;
			}
			return _allSpeakersList;
		}

		async Task<ObservableCollection<Sponsor>> GetAllSponsorsFromServer()
		{
			try
			{
				_client = new HttpClient();
				var content = await _client.GetStringAsync(_allSponsorsUrl);

				var sponsors = JsonConvert.DeserializeObject<List<Sponsor>>(content).OrderBy(a => a.CompanyName);

			 
				 _allSponsorsList = new ObservableCollection<Sponsor>();
				 
				foreach (Sponsor s in sponsors)
				{
					_allSponsorsList.Add(s);

				}
			}
			catch (Exception ex)
			{
				_allSponsorsList = null;
			}

			return _allSponsorsList;

		}

		public async Task<ObservableCollection<Announcement>> GetAllAnnouncementsFromServer()
		{
			try
			{
				_client = new HttpClient();
				var content = await _client.GetStringAsync(_allAnnouncementsUrl);

				//var announcements = JsonConvert.DeserializeObject<List<Announcement>>(content).OrderBy(a => a.Rank);

				//do not order so that it can be controlled by API 
				var announcements = JsonConvert.DeserializeObject<List<Announcement>>(content);

				 
					_allAnnouncementsList = new ObservableCollection<Announcement>();
				 
				foreach (Announcement a in announcements)
				{
					_allAnnouncementsList.Add(a);

				}

				_refreshAnnouncementsCount++;

			}
			catch (Exception ex)
			{
				_allAnnouncementsList = null;
			}

			return _allAnnouncementsList;
		}

		async Task<Event> GetEventInfoFromServer()
		{
			bool seed = false;
			try
			{
				_client = new HttpClient();
				var content = await _client.GetStringAsync(_eventInfoUrl);

				//var announcements = JsonConvert.DeserializeObject<List<Announcement>>(content).OrderBy(a => a.Rank);

				//do not order so that it can be controlled by API 
				var eventInfo = JsonConvert.DeserializeObject<Event>(content);

				if (eventInfo == null)
				{
					seed = true;
				}
			}
			catch (Exception e)
			{
				seed = true;
			}
			finally
			{
				if (seed)
				{
					_event = new Event();
					_event.ID = 1;
					_event.AttendeeRegistrationOpen = true;
					_event.CompleteAddress = "University Partnership Building, Seminole State College (Sanford), 100 Weldon Blvd, Sanford FL 32746";
					_event.EventStart = DateTime.Parse(" 4/8/2017 8:00:00 AM");
					_event.EventEnd = DateTime.Parse ("4/8/2017 5:00:00 PM");
					_event.IsCurrent = true;
					_event.SocialMediaHashtag = "#OrlandoCC";
					_event.SpeakerRegistrationOpen = true;
					_event.Name = "Orlando Codecamp 2017";
					_event.ContactEmail = "board@onetug.com";

				}


			}
			return _event;
			 
		}


	}
}
