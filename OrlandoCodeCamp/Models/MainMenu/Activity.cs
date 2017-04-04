using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace com.ithiredguns.orlandocodecamp
{
	public class Activity
	{
		private readonly string _name;
		private readonly bool _modal;
		private readonly char _icon;
		private readonly Type _pageType;
		private readonly string _backgroundImage;
		private readonly bool _justNotifyNavigateIntent;
		private readonly Action<INavigation> _customNavigation;

		public Activity(string name, Type pageType, string backgroundImage, char icon = '\uf054', 
		                bool modal = false, bool justNotifyNavigateIntent = false, 
		                Action<INavigation> customNavigation = null)
		{
			_name = name;
			_pageType = pageType;
			_icon = icon;
			_backgroundImage = backgroundImage;
			_modal = modal;
			_justNotifyNavigateIntent = justNotifyNavigateIntent;
			_customNavigation = customNavigation;
		}

		public string Name
		{
			get
			{
				return _name;
			}
		}

		public char Icon
		{
			get
			{
				return _icon;
			}
		}

		public string BackgroundImage
		{
			get
			{
				return _backgroundImage;
			}
		}

		public async Task NavigateToActivity(INavigation navigation)
		{
			ActivityCoordinator.RaiseActivitySelected(this);

			if (_justNotifyNavigateIntent)
			{
				return;
			}

			if (_customNavigation != null)
			{
				_customNavigation(navigation);
				return;
			}

			int popCount = 0;
			int firstPageToPopIndex = 0;

			for (int i = navigation.NavigationStack.Count - 1; i >= 0; i--)
			{
				if (navigation.NavigationStack[i].GetType() == _pageType)
				{
					firstPageToPopIndex = i + 1;
					popCount = navigation.NavigationStack.Count - 1 - i;
					break;
				}
			}

			if (popCount > 0)
			{
				for (int i = 1; i < popCount; i++)
				{
					navigation.RemovePage(navigation.NavigationStack[firstPageToPopIndex]);
				}

				await navigation.PopAsync();

				return;
			}

			var page = CreateContentPage();

			if (_modal)
			{
				await navigation.PushModalAsync(new NavigationPage(page));
			}
			else {
				await navigation.PushAsync(page);
			}
		}

		private Page CreateContentPage()
		{
			var page = Activator.CreateInstance(_pageType) as Page;

			System.Diagnostics.Debug.Assert(page != null);

			return page;
		}

		public Type PageType
		{
			get
			{
				return _pageType;
			}
		}
	}
}
