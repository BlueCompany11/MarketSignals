using SignalSources.Interfaces;
using System.Collections.Generic;

namespace SignalSources.Taapi
{
    public class IntervalsProvider: IIntervalsProvider
    { 
        public List<string> GetIntervals()
        {
            return new List<string> { Intervals.OneMinute, Intervals.FiveMinute, Intervals.FifteenMinute, Intervals.ThirtyMinute, Intervals.OneHour,  Intervals.TwoHours, Intervals.FourHours, Intervals.TwelveHours, Intervals.OneDay, Intervals.OneWeek };
        }
    }
}
