using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        // Conversion
        const int SecondsPerHour = 3600;
        const int SecondsPerMinute = 60;
        const int MinutesPerHour = 60;
        // Lamps
        const char YellowLamp = 'Y';
        const char RedLamp = 'R';
        const char OffLamp = 'O';
        // Lamps count
        const byte SecondsRowLampsCount = 1;
        const byte Hour1stRowLampsCount = 4;
        const byte Hour2ndRowLampsCount = 4;
        const byte Minute1stRowLampsCount = 11;
        const byte Minute2ndRowLampsCount = 4;

        private readonly ITimeParser _timeParser;
        private readonly IClockRenderer _clockRenderer;

        public TimeConverter(ITimeParser timeParser, IClockRenderer clockRenderer)
        {
            _timeParser = timeParser;
            _clockRenderer = clockRenderer;
        }

        public string convertTime(string aTime)
        {
            var time = _timeParser.parseTime(aTime);

            _clockRenderer.Reset();

            int seconds = (int)time.TotalSeconds;
            RenderSecondsLampRow(seconds);

            int hour = seconds / SecondsPerHour;
            RenderHourLampsRows(hour);

            int minute = seconds / SecondsPerMinute - hour * MinutesPerHour;
            RenderMinuteLampsRows(minute);

            return _clockRenderer.Render();
        }

        private void RenderSecondsLampRow(int seconds)
        {
            // On the top of the clock there is a yellow lamp that blinks on / off every two seconds.
            _clockRenderer.Write(seconds % 2 == 0 ? YellowLamp : OffLamp);
        }

        private void RenderHourLampsRows(int hour)
        {
            _clockRenderer.WriteLine();
            // The top two rows of lamps are red. 
            // These indicate the hours of a day. In the top row there are 4 red lamps. 
            // Every lamp represents 5 hours.
            for (byte i = 0; i < Hour1stRowLampsCount; i++)
            {
                _clockRenderer.Write(hour - (i + 1) * 5 >= 0 ? RedLamp : OffLamp);
            }
            _clockRenderer.WriteLine();

            // In the lower row of red lamps every lamp represents 1 hour. 
            int rest = hour % 5;
            for (byte i = 0; i < Hour2ndRowLampsCount; i++)
            {
                _clockRenderer.Write(rest - i > 0 ? RedLamp : OffLamp);
            }
        }

        private void RenderMinuteLampsRows(int minute)
        {
            _clockRenderer.WriteLine();
            // The two rows of lamps at the bottom count the minutes.The first of these rows has 11 lamps, the second 4.In the
            // first row every lamp represents 5 minutes.In this first row the 3rd, 6th and 9th lamp are red and indicate the first
            // quarter, half and last quarter of an hour.The other lamps are yellow.
            for (byte i = 0; i < Minute1stRowLampsCount; i++)
            {
                if (minute - (i + 1) * 5 >= 0)
                {
                    _clockRenderer.Write((i + 1) % 3 == 0 ? RedLamp : YellowLamp);
                }
                else
                {
                    _clockRenderer.Write(OffLamp);
                }
            }
            _clockRenderer.WriteLine();

            int rest = minute % 5;
            // In the last row with 4 lamps every lamp represents 1 minute.
            for (byte i = 0; i < Minute2ndRowLampsCount; i++)
            {
                _clockRenderer.Write(rest - i > 0 ? YellowLamp : OffLamp);
            }
        }
    }
}
