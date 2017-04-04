using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;

namespace com.ithiredguns.orlandocodecamp.iOS
{
	public static class Appearance
	{
		public static UIColor AccentColor = ExportedColors.AccentColor.ToUIColor();
		public static UIColor TextColor = ExportedColors.InverseTextColor.ToUIColor();

		public static void Configure()
		{
			UINavigationBar.Appearance.BarTintColor = AccentColor;
			//UINavigationBar.Appearance.BarTintColor = new Xamarin.Forms.Color(17,100,180).ToUIColor();
			UINavigationBar.Appearance.TintColor = TextColor;
			UINavigationBar.Appearance.TitleTextAttributes = new UIStringAttributes
			{
				ForegroundColor = TextColor,
			};

			UIProgressView.Appearance.ProgressTintColor = AccentColor;

			UISlider.Appearance.MinimumTrackTintColor = AccentColor;
			UISlider.Appearance.MaximumTrackTintColor = AccentColor;
			UISlider.Appearance.ThumbTintColor = AccentColor;

			UISwitch.Appearance.OnTintColor = AccentColor;

			UITableViewHeaderFooterView.Appearance.TintColor = AccentColor;

			UITableView.Appearance.SectionIndexBackgroundColor = AccentColor;
			UITableView.Appearance.SeparatorColor = AccentColor;

			UITabBar.Appearance.TintColor = AccentColor;

			UITextField.Appearance.TintColor = AccentColor;

			UIButton.Appearance.TintColor = AccentColor;
			UIButton.Appearance.SetTitleColor(AccentColor, UIControlState.Normal);
		}
	}
}
