using Xamarin.Forms;
using System;
namespace com.ithiredguns.orlandocodecamp
{
	public partial class App : Application
	{
		public static MasterDetailPage MasterDetailPage;
		public static bool IsUserLoggedOn { get; set; }

		public static OCCDataService occDataService ;


		public App()
		{
			InitializeComponent();

			//MainPage = new OrlandoCodeCampPage();

			occDataService = new OCCDataService();

			occDataService.Init();
			

			MainPage = GetMainPage();

			MainPage.SetValue(NavigationPage.BarTextColorProperty, Color.White);
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes

			occDataService.Refresh();
		}

		public static Page GetMainPage()
		{
			////Check if "always logged in " is checked.
			bool loggedIn = false;
			loggedIn = true; //not implementing now

			if (loggedIn)
			{
				IsUserLoggedOn = true;
				return new RootPage(false);
			}
			else
			{
				IsUserLoggedOn = false;
				return new RootPage(true);
			}
		}
	}
}
