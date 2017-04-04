using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
 

namespace com.ithiredguns.orlandocodecamp
{
	public partial class RootPage : MasterDetailPage
	{
		private bool _showLogin;

		public RootPage() : this(false)
		{
		}
		public RootPage(bool showLogin)
		{

			InitializeComponent();
			_showLogin = showLogin;

			// Empty pages are initially set to get optimal launch experience
			Master = new ContentPage { Title = "Orlando Code Camp" };
			Detail = new NavigationPage(new ContentPage());

			if (!_showLogin)
			{
				Master = new MainMenuPage(new NavigationService(Navigation, LaunchActivityInDetail));
				Detail = new NavigationPage(new AnnouncementsPage());
			}

		}
		public async void OnSettingsTapped(Object sender, EventArgs e)
		{
			await Navigation.PushAsync(new SettingsPage());
		}


		protected async override void OnAppearing()
		{
			base.OnAppearing();

			ActivityCoordinator.ActivitySelected += ActivityCoordinator_ActivitySelected;


			if (_showLogin)
			{
				_showLogin = false;

				await Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
				await Task.Delay(500)
				   .ContinueWith(t => NavigationService.BeginInvokeOnMainThreadAsync(InitializeMasterDetail));


			}

			//InitializeMasterDetail(); 
			////await Task.Delay(500)
			////             .ContinueWith(t => NavigationService.BeginInvokeOnMainThreadAsync(InitializeMasterDetail));

		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();

			ActivityCoordinator.ActivitySelected -= ActivityCoordinator_ActivitySelected;
		}

		private void InitializeMasterDetail()
		{
			Master = new MainMenuPage(new NavigationService(Navigation, LaunchActivityInDetail));
			Detail = new NavigationPage(new HomePage());
		}

		private void LaunchActivityInDetail(Page page, bool animated)
		{

			Detail = new NavigationPage(page);

			IsPresented = false;
		}

		private void ActivityCoordinator_ActivitySelected(object sender, ActivityEventArgs e)
		{
			if (e.Activity.PageType == typeof(RootPage))
			{
				IsPresented = true;
			}
		}
	}
}
