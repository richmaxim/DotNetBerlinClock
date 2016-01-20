using System;
using System.Globalization;


namespace BerlinClock
{
    public class Time24hParser : ITimeParser
    {
        // Time templates
        const string EndOfDayTime = "24:00:00";
        const string TimePattern = @"hh\:mm\:ss";

        public TimeSpan parseTime(string aTime)
        {
            return aTime == EndOfDayTime ? new TimeSpan(1, 00, 00, 00) :
                                           TimeSpan.ParseExact(aTime, TimePattern, CultureInfo.InvariantCulture);
        }
    }
}
