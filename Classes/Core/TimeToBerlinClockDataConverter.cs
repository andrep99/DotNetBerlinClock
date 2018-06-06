using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BerlinClock.Classes.Utils;

namespace BerlinClock.Classes
{
    class TimeToBerlinClockDataConverter : ITimeToBerlinClockDataConverter
    {
        public BerlinClockData ConvertParsedTimeToBerlinClockData(ParsedTimeWithExtraMidnight parsedTimeWithExtraMidnight)
        {
            if (!parsedTimeWithExtraMidnight.IsValid()) throw new ArgumentException("Time for converting is not valid");

            var berlinClockData = new BerlinClockData();

            berlinClockData.IsOneSecondLightActive = parsedTimeWithExtraMidnight.Seconds.IsEvenNumber();
            berlinClockData.FiveHoursLightsCount = parsedTimeWithExtraMidnight.Hours / BerlinClockDefinition.HoursPerFiveHourLight;
            berlinClockData.OneHourLightsCount = parsedTimeWithExtraMidnight.Hours % BerlinClockDefinition.HoursPerFiveHourLight;
            berlinClockData.FiveMinutesLightsCount = parsedTimeWithExtraMidnight.Minutes / BerlinClockDefinition.MinutesPerFiveMinuteLight;
            berlinClockData.OneMinuteLightsCount = parsedTimeWithExtraMidnight.Minutes % BerlinClockDefinition.MinutesPerFiveMinuteLight;

            return berlinClockData;
        }


    }
}
