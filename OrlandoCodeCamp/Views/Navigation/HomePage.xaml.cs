using System;
using System.Collections.Generic;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace com.ithiredguns.orlandocodecamp
{
	public partial class HomePage : ContentPage
	{
		private string _address;
		 private string _initialContactPhone;

		private HomePageViewModel vm;

		public HomePage()
		{
			InitializeComponent();

			 vm = new HomePageViewModel();

				vm.EventInfo = App.occDataService.EventInfo(false);
				//this.BindingContext = vm;


				// Initialize the values in APP Load through webservice
				//vm.Address1 = "100 Weldon Blvd";
				//vm.CityStateCountryZip = "Sanford,FL,USA,32746";
				//vm.EventLocationName = "University Partnership Bldg";
				//vm.GPSLatitude = 28.7422565;
				//vm.GPSLongitude = -81.30546979999997;
				//vm.InitialContact = "board@onetug.com";
				//vm.Email = "board@onetug.com";
				//vm.EventTimings = "4/8/2016 8:00:00 AM to 4/8/2016 5:00:00 PM";
				//vm.EventBuildingInfo = "University Partnership Building, Seminole State College (Sanford)";

				

				//this.BindingContext = vm;

			//   var position = new Position(vm.EventInfo.GPSLatitude, vm.EventInfo.GPSLongitude);

		
			 

			//MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(1)));
			////_address = vm.Address1 + "," + vm.CityStateCountryZip;
			////_initialContactPhone = vm.InitialContact;

			//_address = vm.EventInfo.CompleteAddress;
			//_initialContactPhone = vm.EventInfo.ContactEmail;

			//var pin = new Pin()
			//{
			//	Address = _address,
			//	Position = position,
			//	//Label = vm.EventLocationName +","+vm.EventBuildingInfo,
			//	Label = vm.EventInfo.Name + "," + vm.EventInfo.CompleteAddress,
			//	Type = PinType.Place

			//};
			//MyMap.HasZoomEnabled = true;
			//MyMap.Pins.Add(pin);
		}


		protected override async void OnAppearing()
		{
			base.OnAppearing();

			if (App.occDataService.EventInfo(false) != null)
			{
				//EventInfo is loaded
				vm.EventInfo = App.occDataService.EventInfo(false);

			}
			else
			{

				vm.EventInfo = await this.GetEventInfoFromServer(); 
			}

			this.BindingContext = vm;


			if (vm.EventInfo != null)
			{
				var position = new Position(vm.EventInfo.GPSLatitude, vm.EventInfo.GPSLongitude);

				MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(1)));
				//_address = vm.EventInfo.CompleteAddress;
				_address = vm.StreetAddress;
				_initialContactPhone = vm.EventInfo.ContactEmail;

				var pin = new Pin()
				{
					Address = _address,
					Position = position,
					//Label = vm.EventLocationName +","+vm.EventBuildingInfo,
					//Label = vm.EventInfo.Name + "," + vm.EventInfo.CompleteAddress,
					Label = vm.EventInfo.Name,
					Type = PinType.Place

				};
				MyMap.HasZoomEnabled = true;
				MyMap.Pins.Add(pin);

			}


		}

		async Task<Event> GetEventInfoFromServer()
		{

			HttpClient _client = new HttpClient();
			string _eventUrl = Application.Current.Resources["EventInfoUrl"] as String;

			Event _event = null;

			try
			{

				var content = await _client.GetStringAsync(_eventUrl);

				//var announcements = JsonConvert.DeserializeObject<List<Announcement>>(content).OrderBy(a => a.Rank);

				//do not order so that it can be controlled by API 
				_event = JsonConvert.DeserializeObject<Event>(content);


				App.occDataService.Event = _event;
			}
			catch (Exception ex)
			{
				_event = new Event(); //just point to blank 
			}

			return _event;



		}

		private void OnGetDirectionsClicked(object sender, EventArgs args)
		{
			//			var address = _address;

			var address = vm.StreetAddress;
			switch (Device.OS)
			{
				case TargetPlatform.iOS:
					//Device.OpenUri(
					//  new Uri(string.Format("http://maps.apple.com/?ll={0}",vm.EventInfo.GPSLatitude+","+vm.EventInfo.GPSLongitude)));

					Device.OpenUri(new Uri(String.Format("http://maps.apple.com/?daddr={0}",address)));
				
					break;

				case TargetPlatform.Android:
					//	Device.OpenUri(
					//	  new Uri(string.Format("geo:0,0?q={0}", WebUtility.UrlEncode(address))));

					Device.OpenUri(
						new Uri(string.Format("geo:latitude,longitude",vm.EventInfo.GPSLatitude,vm.EventInfo.GPSLongitude)));
				
					break;
				case TargetPlatform.Windows:
				case TargetPlatform.WinPhone:
					Device.OpenUri(
					  new Uri(string.Format("bingmaps:?cp={0}", vm.EventInfo.GPSLatitude+"~"+vm.EventInfo.GPSLongitude)));
					break;
			}
		}

		private void OnEmailClicked(object sender, EventArgs args)
		{
			 
			////Call phone..
			//DisplayAlert("Calling phone", "Call Phone " + _initialContactPhone, "ok");
			//DependencyService.Get<IPhoneCall>().MakePhoneCall(_initialContactPhone);


			//open email

			Device.OpenUri(new Uri("mailto:" + vm.EventInfo.ContactEmail ));

		}
	}
}
