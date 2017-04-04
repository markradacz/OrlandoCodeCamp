using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace com.ithiredguns.orlandocodecamp
{
	public static class Extensions
	{
		public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> col)
		{
			return new ObservableCollection<T>(col);
		}
	}
}
