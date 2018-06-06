using BerlinClock.Classes;
using System;

namespace BerlinClock
{
    public class BerlinClockData
    {
        public bool IsOneSecondLightActive { get; set; }
        public int FiveHoursLightsCount { get; set; }
        public int OneHourLightsCount { get; set; }
        public int FiveMinutesLightsCount { get; set; }
        public int OneMinuteLightsCount { get; set; }

        public bool IsValid()
        {
            var isValid = 
                    FiveHoursLightsCount >= 0 && FiveHoursLightsCount <= BerlinClockDefinition.MaxNumberOfFiveHoursLights &&
                    OneHourLightsCount >= 0 && OneHourLightsCount <= BerlinClockDefinition.MaxNumberOfOneHourLights &&
                    FiveMinutesLightsCount >= 0 && FiveMinutesLightsCount <= BerlinClockDefinition.MaxNumberOfFiveMinutesLights &&
                    OneMinuteLightsCount >= 0 && OneMinuteLightsCount <= BerlinClockDefinition.MaxNumberOfOneMinuteLights;

            return isValid;
        }

    }
}