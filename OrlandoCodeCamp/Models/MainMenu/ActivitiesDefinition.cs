using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace com.ithiredguns.orlandocodecamp
{
	public static class ActivitiesDefinition
	{
		private static List<ActivityCategory> _activitiesCategoryList;
		private static Dictionary<string, ActivityCategory> _activitiesCategories;
		private static List<Activity> _allActivities;
		private static List<ActivityGroup> _activitiesGroupedByCategory;

		//private static ObservableCollection<Trip> _allTrips;


		public static string[] _categoriesColors = {
			"#c01e5c",
			"#ab1958",
			"#861350",
			"#473957",
			"#554666",
			"#5a5586",
			"#4d75a5",
			"#509acb",
			"#5abaeb"
		};

		public static List<ActivityCategory> ActivitiesCategoryList
		{
			get
			{
				if (_activitiesCategoryList == null)
					InitializeActivities();

				return _activitiesCategoryList;
			}
		}

		public static Dictionary<string, ActivityCategory> ActivitiesCategories
		{
			get
			{
				if (_activitiesCategories == null)
				{
					InitializeActivities();
				}

				return _activitiesCategories;
			}
		}

		public static List<Activity> AllActivities
		{
			get
			{
				if (_allActivities == null)
				{
					InitializeActivities();
				}
				return _allActivities;
			}
		}


		//public static ObservableCollection<Trip> InCompleteTrips
		//{
		//	get
		//	{
		//		if (_allTrips == null)
		//		{
		//			InitializeTrips();
		//		}

		//		if (_allTrips != null)
		//		{
		//			ObservableCollection<Trip> trips = new ObservableCollection<Trip>();
		//			foreach (Trip tp in _allTrips)
		//			{
		//				if (tp.IsCompleted == false)
		//				{
		//					trips.Add(tp);
		//				}
		//			}
		//			return trips;
		//		}
		//		else {
		//			return new ObservableCollection<Trip>();
		//		}
		//	}
		//}

		//public static ObservableCollection<Trip>  CompletedTrips
		//{
		//	get
		//	{
		//		if (_allTrips == null)
		//		{
		//			InitializeTrips();
		//		}

		//		if (_allTrips != null)
		//		{
		//			ObservableCollection<Trip>  trips = new ObservableCollection<Trip>();
		//			foreach (Trip tp in _allTrips)
		//			{
		//				if (tp.IsCompleted == true)
		//				{
		//					trips.Add(tp);
		//				}
		//			}
		//			return trips;
		//		}
		//		else {
		//			return new ObservableCollection<Trip>();
		//		}
		//	}
		//}


		public static List<ActivityGroup> ActivitiesGroupedByCategory
		{
			get
			{
				if (_activitiesGroupedByCategory == null)
				{
					InitializeActivities();
				}

				return _activitiesGroupedByCategory;
			}
		}

		public static ObservableCollection<Announcement> Announcements { get; internal set; }
		public static ObservableCollection<Announcement> UnReadAnnouncements { get; internal set; }

		internal static void InitializeActivities()
		{
			var categories = new Dictionary<string, ActivityCategory>();


			//TODO: Implement Saving read announcements to local SQLLite

			Announcements = App.occDataService.AllAnnouncements(false);
			UnReadAnnouncements = App.occDataService.AllAnnouncements(false);
			//categories.Add(
			//	"SOCIAL",
			//	new ActivityCategory
			//	{
			//		Name = "Social",
			//		BackgroundColor = Color.FromHex(_categoriesColors[0]),
			//		BackgroundImage = ActivityData.DashboardImagesList[6],
			//		Icon = '\uf0e6',
			//		ActivitiesList = new List<Activity> {
			//			new Activity("User Profile", typeof(ProfilePage), ActivityData.DashboardImagesList[6], '\uf007'),
			//			new Activity("Social", typeof(SocialPage), ActivityData.DashboardImagesList[6], '\uf0e6'),
			//			new Activity("Social Variant", typeof(SocialVariantPage), ActivityData.DashboardImagesList[6], '\uf0e6'),
			//		}
			//	}
			//);

			categories.Add(
				"GENERAL",
				new ActivityCategory
				{
					Name = "General",
					BackgroundColor = Color.FromHex(_categoriesColors[1]),
					//	BackgroundImage = ActivityData.DashboardImagesList[4],
					Icon = '\uf0f6',
					ActivitiesList = new List<Activity> {
					new Activity("Home", typeof(HomePage), ActivityData.DashboardImagesList[4], '\uf015'),
						new Activity("Announcements", typeof(AnnouncementsPage), ActivityData.DashboardImagesList[4], '\uf0a1')
					}
				}
			);
			categories.Add(
				"ACTIVITIES",
				new ActivityCategory
				{
					Name = "Sessions",
					BackgroundColor = Color.FromHex(_categoriesColors[1]),
				//	BackgroundImage = ActivityData.DashboardImagesList[4],
					Icon = '\uf0f6',
					ActivitiesList = new List<Activity> {
						 
						new Activity("Tracks", typeof(TracksPage), ActivityData.DashboardImagesList[4], '\uf121'),
						new Activity("Times", typeof(TimingsPage), ActivityData.DashboardImagesList[4], '\uf017'),
						new Activity("Speakers", typeof(SpeakersPage), ActivityData.DashboardImagesList[4], '\uf2c0')
					}
				}
			);

			categories.Add(
				"SPONSORS",
				new ActivityCategory
				{
					Name = "Sponsors",
					BackgroundColor = Color.FromHex(_categoriesColors[1]),
					//BackgroundImage = ActivityData.DashboardImagesList[4],
					Icon = '\uf0f6',
					ActivitiesList = new List<Activity> {
						new Activity("Platinum", typeof(PlatinumSponsorsPage), ActivityData.DashboardImagesList[4], '\uf005'),
						new Activity("Gold", typeof(GoldSponsorsPage), ActivityData.DashboardImagesList[4], '\uf123'),
						new Activity("Silver", typeof(SilverSponsorsPage), ActivityData.DashboardImagesList[4], '\uf089'),
						new Activity("Other", typeof(OtherSponsorsPage), ActivityData.DashboardImagesList[4], '\uf006'),
						new Activity("All", typeof(AllSponsorsPage), ActivityData.DashboardImagesList[4], '\uf2b5')

					}
				}
			);

			//categories.Add(
			//	"DASHBOARD",
			//	new SampleCategory
			//	{
			//		Name = "Dashboards",
			//		BackgroundColor = Color.FromHex(_categoriesColors[2]),
			//		BackgroundImage = SampleData.DashboardImagesList[3],
			//		Icon = '\uf009',
			//		ActivitiesList = new List<Sample> {
			//			new Sample("Icons Dashboard", typeof(DashboardPage), SampleData.DashboardImagesList[3], '\uf009'),
			//			new Sample("Flat Dashboard", typeof(DashboardFlatPage), SampleData.DashboardImagesList[3], '\uf009'),
			//			new Sample("Images Dashboard", typeof(DashboardWithImagesPage), SampleData.DashboardImagesList[3], '\uf009'),
			//		}
			//	}
			//);


			//categories.Add(
			//	"NAVIGATION",
			//	new SampleCategory
			//	{
			//		Name = "Navigation",
			//		BackgroundColor = Color.FromHex(_categoriesColors[3]),
			//		BackgroundImage = SampleData.DashboardImagesList[2],
			//		Icon = '\uf0c9',
			//		ActivitiesList = new List<Sample> {
			//			new Sample("RootPage", typeof(RootPage), SampleData.DashboardImagesList[2], '\uf0c9', false, true),
			//			new Sample("Categories List Flat", typeof(CategoriesListFlatPage), SampleData.DashboardImagesList[2], '\uf03a'),
			//			new Sample("Image Categories", typeof(CategoriesListWithImagesPage), SampleData.DashboardImagesList[2], '\uf03a'),
			//			new Sample("Icon Categories", typeof(CategoriesListWithIconsPage), SampleData.DashboardImagesList[2], '\uf03a'),
			//			new Sample("Custom NavBar", typeof(CustomNavBarPage), SampleData.DashboardImagesList[2], '\uf022'),
			//		}
			//	}
			//);

			/*
			 *  logins later
			 * 
			categories.Add(
				"LOGINS",
				new ActivityCategory
				{
					Name = "Logins",
					BackgroundColor = Color.FromHex(_categoriesColors[4]),
					BackgroundImage = ActivityData.DashboardImagesList[5],
					Icon = '\uf023',
					ActivitiesList = new List<Activity> {
						new Activity("Login", typeof(LoginPage), ActivityData.DashboardImagesList[5], '\uf023', true),
						new Activity("Register", typeof(RegisterPage), ActivityData.DashboardImagesList[5], '\uf25d', true),
						new Activity("Password Recovery", typeof(RecoverPasswordPage), ActivityData.DashboardImagesList[5], '\uf0e2', true),
					new Activity("Sign Out",typeof(SignOutPage),ActivityData.DashboardImagesList[5],'\uf09c',true)

					}
				}
			);
			*/
			//categories.Add(
			//	"ECOMMERCE",
			//	new SampleCategory
			//	{
			//		Name = "Ecommerce",
			//		BackgroundColor = Color.FromHex(_categoriesColors[5]),
			//		BackgroundImage = SampleData.DashboardImagesList[1],
			//		Icon = '\uf07a',
			//		ActivitiesList = new List<Sample> {
			//			new Sample("Products Grid", typeof(ProductsGridPage), SampleData.DashboardImagesList[1] , '\uf0db'),
			//			new Sample("Products Grid Variant", typeof(ProductsGridVariantPage), SampleData.DashboardImagesList[1] , '\uf0db'),
			//			new Sample("Product Item View", typeof(ProductItemViewPage), SampleData.DashboardImagesList[1], '\uf06b'),
			//			new Sample("Products Carousel", typeof(ProductsCarouselPage), SampleData.DashboardImagesList[1], '\uf06b'),
			//		}
			//	}
			//);

			//categories.Add(
			//	"WALKTROUGH",
			//	new SampleCategory
			//	{
			//		Name = "Walkthroughs",
			//		BackgroundColor = Color.FromHex(_categoriesColors[6]),
			//		BackgroundImage = SampleData.DashboardImagesList[7],
			//		Icon = '\uf0d0',
			//		ActivitiesList = new List<Sample> {
			//			new Sample("Walkthrough", typeof(WalkthroughPage), SampleData.DashboardImagesList[7], '\uf0d0', true),
			//			new Sample("Walkthrough Variant", typeof(WalkthroughVariantPage), SampleData.DashboardImagesList[7], '\uf0d0', true),
			//		}
			//	}
			//);
			/*
			categories.Add(
				"MESSAGES",
				new ActivityCategory
				{
					Name = "Messages",
					BackgroundColor = Color.FromHex(_categoriesColors[7]),
					BackgroundImage = ActivityData.DashboardImagesList[8],
					Icon = '\uf003',
					ActivitiesList = new List<Activity> {
						new Activity("Messages", typeof(MessagesListPage), ActivityData.DashboardImagesList[8], '\uf003'),
						new Activity("Chat Messages List", typeof(ChatMessagesListPage), ActivityData.DashboardImagesList[8], '\uf0e6'),
					}
				}
			);
			*/

			categories.Add(
				"ABOUT",
				new ActivityCategory
				{
					//Name = "Settings, Themes",
					Name = "About",
					BackgroundColor = Color.FromHex(_categoriesColors[8]),
					BackgroundImage = ActivityData.DashboardImagesList[0],
					Icon = '\uf1fc',
					ActivitiesList = new List<Activity> {
						//new Activity("Native controls", typeof(ThemePage), SampleData.DashboardImagesList[0], '\uf1fc'),
						//new Sample("Custom Renderers", typeof(CustomRenderersPage), SampleData.DashboardImagesList[0], '\uf1fc'),
						//new Sample("Grial Common Views", typeof(CommonViewsPage), SampleData.DashboardImagesList[0], '\uf1fc'),
					//	new Activity("Settings Page", typeof(SettingsPage), ActivityData.DashboardImagesList[0], '\uf085'),
						new Activity("OCC", typeof(AboutPage), ActivityData.DashboardImagesList[0], '\uf129'),
						new Activity("FAQ", typeof(FAQPage), ActivityData.DashboardImagesList[0], '\uf128'),
						new Activity("App Credits", typeof(CreditsPage),ActivityData.DashboardImagesList[0],'\uf2b5')
						//new Sample("Tabs", typeof(TabsPage), SampleData.DashboardImagesList[0], '\uf114'),
					}
				}
			);


			_activitiesCategories = categories;

			_activitiesCategoryList = new List<ActivityCategory>();

			foreach (var activity in _activitiesCategories.Values)
			{
				_activitiesCategoryList.Add(activity);
			}

			_allActivities = new List<Activity>();

			_activitiesGroupedByCategory = new List<ActivityGroup>();

			foreach (var activityCategory in ActivitiesCategories.Values)
			{

				var activityItem = new ActivityGroup(activityCategory.Name.ToUpper());

				foreach (var activity in activityCategory.ActivitiesList)
				{
					_allActivities.Add(activity);
					activityItem.Add(activity);
				}

				_activitiesGroupedByCategory.Add(activityItem);
			}
		}

		public static void InitializeTrips()
		{
			//List<Trip> _trips = new List<Trip>()
			//{
			//	//new Trip(){IsCompleted=true, Id = 1},
			//	//new Trip(){IsCompleted=false, Id =2},
			//	//new Trip(){IsCompleted=true, Id = 3},
			//	//new Trip(){IsCompleted=true, Id =4},
			//	//new Trip(){IsCompleted=true, Id = 5},
			//	//new Trip(){IsCompleted=true, Id =6},
			//	//new Trip(){IsCompleted=true, Id = 7},
			//	//new Trip(){IsCompleted=false, Id =8},
			//	//new Trip(){IsCompleted=true, Id = 9},
			//	//new Trip(){IsCompleted=true, Id =10},
			//	//new Trip(){IsCompleted=true, Id = 11},
			//	//new Trip(){IsCompleted=false, Id =12},




			//};
			//_allTrips = _trips;

			//_allTrips = TripData.AllTrips;

		}

		private static void RootPageCustomNavigation(INavigation navigation)
		{
			ActivityCoordinator.RaisePresentMainMenuOnAppearance();
			navigation.PopToRootAsync();
		}
	}

	public class ActivityGroup : List<Activity>
	{
		private readonly string _name;

		public ActivityGroup(string name)
		{
			_name = name;
		}

		public string Name
		{
			get
			{
				return _name;
			}
		}
	}
}
