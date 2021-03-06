﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ithiredguns.orlandocodecamp
{
    public interface IAnalytics
    {
        bool Enabled { get; set; }

        void Init();

        void SetUser(string identifier, Dictionary<string, string> userProperties = null);

        void LogViewLoaded(string name);

        void LogViewUnloaded(string name);

        void LogViewDisplayed(string name);

        void LogViewHidden(string name);

        void LogEvent(string name, string category, string eventName, string eventData);

        void LogError(string name, string title, string message);

        void LogPerformance(string category, TimeSpan performanceCounter, Dictionary<string, string> values = null);
    }
}
