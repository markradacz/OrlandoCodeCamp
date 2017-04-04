using System;
namespace com.ithiredguns.orlandocodecamp
{
	public class ActivityCoordinator
	{
		public static event EventHandler<ActivityEventArgs> SelectedActivityChanged;
		public static event EventHandler<EventArgs> PresentMainMenuOnAppearance;
		public static event EventHandler<ActivityEventArgs> ActivitySelected;

		private static Activity _selectedActivity = null;

		public static void RaisePresentMainMenuOnAppearance()
		{
			if (PresentMainMenuOnAppearance != null)
			{
				PresentMainMenuOnAppearance(typeof(ActivityCoordinator), null);
			}
		}

		public static void RaiseActivitySelected(Activity activity)
		{
			if (ActivitySelected != null)
			{
				ActivitySelected(typeof(ActivityCoordinator), new ActivityEventArgs(activity));
			}
		}

		public static Activity SelectedActivity
		{
			get
			{
				return _selectedActivity;
			}

			set
			{
				if (_selectedActivity != value)
				{
					_selectedActivity = value;

					if (SelectedActivityChanged != null)
					{
						SelectedActivityChanged(typeof(ActivityCoordinator), new ActivityEventArgs(value));
					}
				}
			}
		}
	}

	public class ActivityEventArgs : EventArgs
	{
		private readonly Activity _activity;

		public ActivityEventArgs(Activity newActivity)
		{
			_activity = newActivity;
		}

		public Activity Activity
		{
			get
			{
				return _activity;
			}
		}
	}
}
