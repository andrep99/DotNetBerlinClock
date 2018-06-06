using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    static class BerlinClockDefinition
    {
        public const int MaxNumberOfFiveHoursLights = 4; 
        public const int MaxNumberOfOneHourLights = 4;
        public const int MaxNumberOfFiveMinutesLights = 11;
        public const int MaxNumberOfOneMinuteLights = 4;

        public static readonly int[] IndecesOfQuarters = { 2, 5, 8 };

        public const int HoursPerFiveHourLight = 5;
        public const int MinutesPerFiveMinuteLight = 5;
    }
}
