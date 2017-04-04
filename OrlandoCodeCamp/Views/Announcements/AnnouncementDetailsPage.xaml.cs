using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace com.ithiredguns.orlandocodecamp
{
	public partial class AnnouncementDetailsPage : ContentPage
	{
		private AnnouncementDetailsViewModel vm;
		public AnnouncementDetailsPage()
		{
			InitializeComponent();
		}
		public AnnouncementDetailsPage(AnnouncementDetailsViewModel viewModel)
		{
			InitializeComponent();
			vm = viewModel;
			BindingContext = viewModel;
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();

			outerScrollView.Scrolled += OnScroll;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			outerScrollView.Scrolled -= OnScroll;
		}

		public void OnScroll(object sender, ScrolledEventArgs e)
		{
			//var imageHeight = img.Height * 2;
			var scrollRegion = layeringGrid.Height - outerScrollView.Height;
			//var parallexRegion = imageHeight - outerScrollView.Height;
			var parallexRegion = 100 - outerScrollView.Height;
			var factor = outerScrollView.ScrollY - parallexRegion * (outerScrollView.ScrollY / scrollRegion);
			//img.TranslationY = factor;
			//img.Opacity = 1 - (factor / imageHeight);
			//headers.Scale = 1 - ((factor) / (imageHeight * 2));
		}


		//async void OnTapGestureRecognizerSpeakerTapped(object sender, EventArgs args)
		//{
		//	Speaker speaker = vm.Session.Speaker;
		//	if (speaker == null)
		//	{
		//		speaker = App.occDataService.AllSpeakers(false).ToList().FirstOrDefault(s => s.ID == vm.Session.SpeakerID);
		//	}


		//	var speakerView = new SpeakerViewPage(speaker);

		//	await Navigation.PushAsync(speakerView);
		//}
	}
}
