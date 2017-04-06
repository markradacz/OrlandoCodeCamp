using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace com.ithiredguns.orlandocodecamp
{
    public class InsightsAnalytics : IAnalytics
    {
        #region IAnalyticsService implementation

        public bool Enabled
        {
            get;
            set;
        }

        Action _insightsInitializer;

        public InsightsAnalytics(Action insightsInitializer)
        {
            if (insightsInitializer == null)
                throw new ArgumentNullException("insightsInitializer");

            _insightsInitializer = insightsInitializer;
        }

        public void Init()
        {
            _insightsInitializer.Invoke();
            Enabled = Xamarin.Insights.IsInitialized;
        }

        public void SetUser(string identifier, Dictionary<string, string> userProperties)
        {
            if (Enabled && Xamarin.Insights.IsInitialized)
                Xamarin.Insights.Identify(identifier, userProperties);
        }

        public void LogViewLoaded(string name)
        {
            if (Enabled && Xamarin.Insights.IsInitialized)
                Xamarin.Insights.Track(
                    Helpers.TrackingConstants.ViewLoaded,
                    new Dictionary<string, string>(){
                        { Helpers.TrackingConstants.ViewName, name }
                    }
                );
        }

        public void LogViewUnloaded(string name)
        {
            if (Enabled && Xamarin.Insights.IsInitialized)
                Xamarin.Insights.Track(
                    Helpers.TrackingConstants.ViewUnloaded,
                    new Dictionary<string, string>(){
                        { Helpers.TrackingConstants.ViewName, name }
                    }
                );
        }

        public void LogViewDisplayed(string name)
        {
            if (Enabled && Xamarin.Insights.IsInitialized)
                Xamarin.Insights.Track(
                    Helpers.TrackingConstants.ViewDisplayed,
                    new Dictionary<string, string>(){
                        { Helpers.TrackingConstants.ViewName, name }
                    }
                );
        }

        public void LogViewHidden(string name)
        {
            if (Enabled && Xamarin.Insights.IsInitialized)
                Xamarin.Insights.Track(
                    Helpers.TrackingConstants.ViewHidden,
                    new Dictionary<string, string>(){
                        { Helpers.TrackingConstants.ViewName, name }
                    }
                );
        }

        public void LogError(string name, string title, string message)
        {
            if (Enabled && Xamarin.Insights.IsInitialized)
                Xamarin.Insights.Track(
                    Helpers.TrackingConstants.UserError,
                    new Dictionary<string, string>(){
                        { Helpers.TrackingConstants.UserErrorView, name },
                        { Helpers.TrackingConstants.UserErrorTitle, title },
                        { Helpers.TrackingConstants.UserErrorMessage, message }
                    }
                );
        }

        public void LogEvent(string name, string category, string eventName, string eventData)
        {
            if (Enabled && Xamarin.Insights.IsInitialized)
                Xamarin.Insights.Track(
                    name,
                    new Dictionary<string, string>(){
                        { Helpers.TrackingConstants.Category, category },
                        { Helpers.TrackingConstants.EventName, eventName },
                        { Helpers.TrackingConstants.EventData, eventData },
                    }
                );
        }

        public void LogPerformance(string category, TimeSpan performanceCounter, Dictionary<string, string> values = null)
        {
            if (values == null)
                values = new Dictionary<string, string>();

            values["Duration"] = ((long)performanceCounter.TotalMilliseconds).ToString();

            if (Enabled && Xamarin.Insights.IsInitialized)
                Xamarin.Insights.Track(
                    String.Format("Performance - {0}", category),
                    values
                );
        }

        #endregion
    }
}
